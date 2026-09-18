Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Microsoft.Identity.Client
Imports Newtonsoft.Json.Linq

''' <summary>
''' App-only (client-credentials) access to Microsoft Graph, replacing the EWS/delegated-MSAL
''' stack (GetMytoken/EwsService). No interactive sign-in: the app authenticates as itself using
''' the "RelatieApp EWS" Entra registration's ClientId/TenantId (existing settings) plus a client
''' secret stored encrypted as the "GraphClientSecret" setting.
''' </summary>
Public Class GraphNotFoundException
    Inherits Exception
    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class

Public Class GraphRequestException
    Inherits Exception
    Public ReadOnly StatusCode As HttpStatusCode
    Public Sub New(statusCode As HttpStatusCode, message As String)
        MyBase.New(message)
        Me.StatusCode = statusCode
    End Sub
End Class

''' <summary>Lichte vervanging van EWS' Folder-object voor mailFolders-resultaten.</summary>
Public Class GraphMailFolder
    Public Property Id As String
    Public Property DisplayName As String
    Public Property ParentFolderId As String
    Public Property ChildFolderCount As Integer

    Public Sub New(json As JObject)
        Id = CStr(json("id"))
        DisplayName = CStr(json("displayName"))
        ParentFolderId = CStr(json("parentFolderId"))
        Dim cfc = json("childFolderCount")
        ChildFolderCount = If(cfc IsNot Nothing, CInt(cfc), 0)
    End Sub
End Class

Public Module GraphService

    Private Const GraphBaseUrl As String = "https://graph.microsoft.com/v1.0/"

    Private ReadOnly Http As New HttpClient()

    Private _accessToken As String = ""
    Private _accessTokenExpires As DateTimeOffset = DateTimeOffset.MinValue

    Private Async Function GetAccessTokenAsync() As Threading.Tasks.Task(Of String)
        If Not String.IsNullOrEmpty(_accessToken) AndAlso DateTimeOffset.UtcNow < _accessTokenExpires Then
            Return _accessToken
        End If

        Dim clientId = GetSysSettingOf("ClientId")
        Dim tenantId = GetSysSettingOf("TenantId")
        Dim clientSecret = CryptoService.Decrypt(GetSysSettingOf("GraphClientSecret"))

        Dim cca = ConfidentialClientApplicationBuilder.Create(clientId).
            WithClientSecret(clientSecret).
            WithTenantId(tenantId).
            Build()

        Dim scopes = New String() {"https://graph.microsoft.com/.default"}
        Dim result = Await cca.AcquireTokenForClient(scopes).ExecuteAsync()

        _accessToken = result.AccessToken
        _accessTokenExpires = result.ExpiresOn.AddMinutes(-2)

        Return _accessToken
    End Function

    Private Function ResolveUrl(pathOrUrl As String) As String
        If pathOrUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) Then Return pathOrUrl
        Return GraphBaseUrl & pathOrUrl.TrimStart("/"c)
    End Function

    Private Async Function SendAsync(method As HttpMethod, pathOrUrl As String, Optional jsonBody As JObject = Nothing) As Threading.Tasks.Task(Of HttpResponseMessage)
        Dim token = Await GetAccessTokenAsync()
        Dim req As New HttpRequestMessage(method, ResolveUrl(pathOrUrl))
        req.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)

        If jsonBody IsNot Nothing Then
            req.Content = New StringContent(jsonBody.ToString(Newtonsoft.Json.Formatting.None), Encoding.UTF8, "application/json")
        End If

        Dim resp = Await Http.SendAsync(req)
        Return resp
    End Function

    Private Async Function EnsureSuccessAsync(resp As HttpResponseMessage, context As String) As Threading.Tasks.Task
        If resp.IsSuccessStatusCode Then Return

        Dim body = Await resp.Content.ReadAsStringAsync()

        If resp.StatusCode = HttpStatusCode.NotFound Then
            Throw New GraphNotFoundException($"Graph 404 op '{context}': {body}")
        End If

        Throw New GraphRequestException(resp.StatusCode, $"Graph fout ({CInt(resp.StatusCode)}) op '{context}': {body}")
    End Function

    ''' <summary>GET die een los object teruggeeft (bv. /users/{upn}/messages/{id}).</summary>
    Public Async Function GraphGetAsync(path As String) As Threading.Tasks.Task(Of JObject)
        Dim resp = Await SendAsync(HttpMethod.Get, path)
        Await EnsureSuccessAsync(resp, path)
        Dim body = Await resp.Content.ReadAsStringAsync()
        Return JObject.Parse(body)
    End Function

    ''' <summary>GET van een verzameling (bv. childFolders/messages), volgt automatisch @odata.nextLink.</summary>
    Public Async Function GraphGetCollectionAsync(path As String) As Threading.Tasks.Task(Of List(Of JObject))
        Dim results As New List(Of JObject)
        Dim nextUrl As String = path

        Do While Not String.IsNullOrEmpty(nextUrl)
            Dim resp = Await SendAsync(HttpMethod.Get, nextUrl)
            Await EnsureSuccessAsync(resp, path)
            Dim body = Await resp.Content.ReadAsStringAsync()
            Dim parsed = JObject.Parse(body)

            For Each item In parsed("value")
                results.Add(CType(item, JObject))
            Next

            nextUrl = CStr(parsed("@odata.nextLink"))
        Loop

        Return results
    End Function

    ''' <summary>GET van raw bytes (bv. /messages/{id}/$value voor MIME-content).</summary>
    Public Async Function GraphGetBytesAsync(path As String) As Threading.Tasks.Task(Of Byte())
        Dim resp = Await SendAsync(HttpMethod.Get, path)
        Await EnsureSuccessAsync(resp, path)
        Return Await resp.Content.ReadAsByteArrayAsync()
    End Function

    Public Async Function GraphPostAsync(path As String, body As JObject) As Threading.Tasks.Task(Of JObject)
        Dim resp = Await SendAsync(HttpMethod.Post, path, body)
        Await EnsureSuccessAsync(resp, path)
        If resp.StatusCode = HttpStatusCode.NoContent Then Return Nothing
        Dim respBody = Await resp.Content.ReadAsStringAsync()
        If String.IsNullOrWhiteSpace(respBody) Then Return Nothing
        Return JObject.Parse(respBody)
    End Function

    Public Async Function GraphPatchAsync(path As String, body As JObject) As Threading.Tasks.Task(Of JObject)
        Dim resp = Await SendAsync(New HttpMethod("PATCH"), path, body)
        Await EnsureSuccessAsync(resp, path)
        If resp.StatusCode = HttpStatusCode.NoContent Then Return Nothing
        Dim respBody = Await resp.Content.ReadAsStringAsync()
        If String.IsNullOrWhiteSpace(respBody) Then Return Nothing
        Return JObject.Parse(respBody)
    End Function

    Public Async Function GraphDeleteAsync(path As String) As Threading.Tasks.Task
        Dim resp = Await SendAsync(HttpMethod.Delete, path)
        Await EnsureSuccessAsync(resp, path)
    End Function

    ''' <summary>Controleert of een mailbox/agenda bereikbaar is (vervangt EwsService.ValidateMailbox/ValidateCalendarFolder).</summary>
    Public Async Function ValidateMailboxAsync(upn As String) As Threading.Tasks.Task(Of Boolean)
        Try
            Await GraphGetAsync($"users/{Uri.EscapeDataString(upn)}/mailFolders/inbox")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Async Function ValidateCalendarAsync(upn As String) As Threading.Tasks.Task(Of Boolean)
        Try
            Await GraphGetAsync($"users/{Uri.EscapeDataString(upn)}/calendar")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>Eén mailFolder ophalen, via id of well-known naam ("inbox", "deleteditems", ...).</summary>
    Public Async Function GraphGetFolderAsync(upn As String, folderIdOrWellKnownName As String) As Threading.Tasks.Task(Of GraphMailFolder)
        Dim json = Await GraphGetAsync($"users/{Uri.EscapeDataString(upn)}/mailFolders/{folderIdOrWellKnownName}")
        Return New GraphMailFolder(json)
    End Function

    ''' <summary>Directe subfolders (leeg parentFolderId = top-level, EWS' MsgFolderRoot).</summary>
    Public Async Function GraphGetChildFoldersAsync(upn As String, parentFolderId As String) As Threading.Tasks.Task(Of List(Of GraphMailFolder))
        Dim escapedUpn = Uri.EscapeDataString(upn)
        Dim path = If(String.IsNullOrEmpty(parentFolderId), $"users/{escapedUpn}/mailFolders", $"users/{escapedUpn}/mailFolders/{parentFolderId}/childFolders")
        Dim items = Await GraphGetCollectionAsync(path)
        Return items.Select(Function(j) New GraphMailFolder(j)).ToList()
    End Function

    ''' <summary>Zoekt recursief (alle niveaus) de eerste folder waarvoor matches(DisplayName) True is - vervangt EWS' FindFolders met FolderTraversal.Deep + stoppen bij eerste match.</summary>
    Public Async Function GraphFindFolderAsync(upn As String, rootFolderId As String, matches As Func(Of String, Boolean)) As Threading.Tasks.Task(Of GraphMailFolder)
        Dim children = Await GraphGetChildFoldersAsync(upn, rootFolderId)

        For Each child In children
            If matches(child.DisplayName) Then Return child
        Next

        For Each child In children
            Dim found = Await GraphFindFolderAsync(upn, child.Id, matches)
            If found IsNot Nothing Then Return found
        Next

        Return Nothing
    End Function

    ''' <summary>Zoekt recursief (alle niveaus) alle folders waarvoor matches(DisplayName) True is - vervangt EWS' FindFolders met FolderTraversal.Deep zonder early-exit.</summary>
    Public Async Function GraphFindAllFoldersAsync(upn As String, rootFolderId As String, matches As Func(Of String, Boolean)) As Threading.Tasks.Task(Of List(Of GraphMailFolder))
        Dim results As New List(Of GraphMailFolder)
        Dim children = Await GraphGetChildFoldersAsync(upn, rootFolderId)

        For Each child In children
            If matches(child.DisplayName) Then results.Add(child)
            results.AddRange(Await GraphFindAllFoldersAsync(upn, child.Id, matches))
        Next

        Return results
    End Function

    ''' <summary>
    ''' Voert een async Graph-aanroep synchroon uit vanuit de (niet-async) WinForms/service-code.
    ''' Start op een threadpool-thread zodat awaits niet op de aanroepende (UI-)SynchronizationContext
    ''' proberen te vervolgen - zelfde reden als de Task.Run(...).Wait() in de oude EwsService-code.
    ''' GetAwaiter().GetResult() geeft de originele exception door (geen AggregateException), zodat
    ''' aanroepers specifiek op GraphNotFoundException kunnen vangen.
    ''' </summary>
    Public Function GraphSync(Of T)(func As Func(Of Threading.Tasks.Task(Of T))) As T
        Return Threading.Tasks.Task.Run(func).GetAwaiter().GetResult()
    End Function

    Public Sub GraphSync(func As Func(Of Threading.Tasks.Task))
        Threading.Tasks.Task.Run(func).GetAwaiter().GetResult()
    End Sub

End Module
