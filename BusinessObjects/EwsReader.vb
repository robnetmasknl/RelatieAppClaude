Imports BusinessObjects
Imports Newtonsoft.Json.Linq

''' <summary>
''' Leest mailfolders/berichten via Microsoft Graph (app-only). Klasse-naam "EwsReader" is
''' behouden om de bestaande aanroepers (IBBDossier, frmIBBDossier, frmRelatie) ongewijzigd
''' te laten; er wordt intern niets meer met EWS gedaan.
''' </summary>
Public Class EwsReader

    Public Sub New(UseSystemSetting As Boolean)
        'Parameter behouden voor bron-compatibiliteit; app-only Graph-auth wordt altijd gebruikt.
    End Sub

    Private _MailboxUpn As String
    Public Property MailboxUpn() As String
        Get
            If String.IsNullOrEmpty(_MailboxUpn) Then _MailboxUpn = GetSysSettingOf("ESDefaultAgenda")
            Return _MailboxUpn
        End Get
        Set(ByVal value As String)
            _MailboxUpn = value
        End Set
    End Property

    Private _completeListOfFolderIds As List(Of GraphMailFolder)
    Public Property completeListOfFolderIds() As List(Of GraphMailFolder)
        Get
            If _completeListOfFolderIds Is Nothing Then
                _completeListOfFolderIds = New List(Of GraphMailFolder)
            End If
            Return _completeListOfFolderIds
        End Get
        Set(ByVal value As List(Of GraphMailFolder))
            _completeListOfFolderIds = value
        End Set
    End Property

    Private _ListOfSubFolders As List(Of GraphMailFolder)
    Public Property ListOfSubFolders() As List(Of GraphMailFolder)
        Get
            If _ListOfSubFolders Is Nothing Then
                _ListOfSubFolders = New List(Of GraphMailFolder)
            End If
            Return _ListOfSubFolders
        End Get
        Set(ByVal value As List(Of GraphMailFolder))
            _ListOfSubFolders = value
        End Set
    End Property

    Private _SystemFolder As GraphMailFolder
    Public Property SystemFolder() As GraphMailFolder
        Get
            Return _SystemFolder
        End Get
        Set(ByVal value As GraphMailFolder)
            _SystemFolder = value
        End Set
    End Property

    Private _MailItems As List(Of Berichten)
    Public Property MailItems() As List(Of Berichten)
        Get
            Return _MailItems
        End Get
        Set(ByVal value As List(Of Berichten))
            _MailItems = value
        End Set
    End Property

    ''' <summary>Directe subfolders van ByFolderID (shallow) - vervangt EWS FindFolders zonder Deep traversal.</summary>
    Public Function GetSubFolders(ByFolderID As String) As List(Of GraphMailFolder)
        ListOfSubFolders.AddRange(GraphSync(Function() GraphGetChildFoldersAsync(MailboxUpn, ByFolderID)))
        Return ListOfSubFolders
    End Function

    Public Function SharedRootFolder() As GraphMailFolder
        Try
            If String.IsNullOrEmpty(GetSysSettingOf("ESDefaultFolder")) Then
                'geen waarde dan de inbox folder van ESDefaultAgenda
                Return GraphSync(Function() GraphGetFolderAsync(MailboxUpn, "inbox"))
            End If

            Dim matchName = GetSysSettingOf("ESDefaultFolder")
            Return GraphSync(Function() GraphFindFolderAsync(MailboxUpn, String.Empty, Function(name) String.Equals(name, matchName, StringComparison.OrdinalIgnoreCase)))

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SharedDossierFolder(DossierNr As String) As GraphMailFolder
        Try
            Return GraphSync(Function() GraphFindFolderAsync(MailboxUpn, "inbox", Function(name) name IsNot Nothing AndAlso name.IndexOf(DossierNr, StringComparison.OrdinalIgnoreCase) >= 0))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EwsFolder(DossierNr As String)
        Try
            completeListOfFolderIds = GraphSync(Function() GraphFindAllFoldersAsync(MailboxUpn, String.Empty, Function(name) name IsNot Nothing AndAlso name.IndexOf(DossierNr, StringComparison.OrdinalIgnoreCase) >= 0))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetItems(ByFolderID As String)
        MailItems = New List(Of Berichten)

        Dim items = GraphSync(Function() GraphGetCollectionAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/mailFolders/{ByFolderID}/messages?$top=999"))

        For Each i As JObject In items
            Dim NewBericht As New Berichten
            With NewBericht
                Dim fromAddr = i("from")
                If fromAddr IsNot Nothing AndAlso fromAddr("emailAddress") IsNot Nothing Then
                    .FromName = CStr(fromAddr("emailAddress")("name"))
                Else
                    .FromName = "n.a."
                End If

                .Header = CStr(i("id"))
                .Subject = CStr(i("subject"))
                .ReceivedDate = CDate(i("receivedDateTime"))

                Dim toNames As New List(Of String)
                If i("toRecipients") IsNot Nothing Then
                    For Each r In i("toRecipients")
                        toNames.Add(CStr(r("emailAddress")("address")))
                    Next
                End If
                .ToAddress = String.Join("; ", toNames)

                Dim categories As New List(Of String)
                If i("categories") IsNot Nothing Then
                    For Each c In i("categories")
                        categories.Add(CStr(c))
                    Next
                End If
                .boCategory = String.Join(",", categories)
            End With
            MailItems.Add(NewBericht)
        Next
    End Sub

    ''' <summary>Geeft het ruwe Graph message-object terug (id, subject, body, categories, ...).</summary>
    Public Function GetItem(ByUid As String) As JObject
        Try
            Return GraphSync(Function() GraphGetAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/messages/{ByUid}"))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>Ruwe MIME-content van een bericht (vervangt EWS PropertySet(EmailMessageSchema.MimeContent)), voor .eml-export.</summary>
    Public Function GetMimeContent(ByUid As String) As Byte()
        Try
            Return GraphSync(Function() GraphGetBytesAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/messages/{ByUid}/$value"))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>Verplaatst het bericht naar Verwijderde items - vervangt EWS' Delete(DeleteMode.SoftDelete).</summary>
    Public Sub DeleteItem(ByUid As String)
        Try
            Dim body As New JObject()
            body("destinationId") = "deletedItems"
            GraphSync(Function() GraphPostAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/messages/{ByUid}/move", body))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>Zet de Outlook-categorieën van een bericht - vervangt EWS' Categories.Clear/Add + Update.</summary>
    Public Sub UpdateCategories(ByUid As String, categories As IEnumerable(Of String))
        Try
            Dim body As New JObject()
            body("categories") = New JArray(categories.ToArray())
            GraphSync(Function() GraphPatchAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/messages/{ByUid}", body))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
