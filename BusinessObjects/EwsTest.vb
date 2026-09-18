Imports BusinessObjects
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

''' <summary>
''' Backing class voor het diagnostische testscherm frmEWS ("Ewstest" menu) - Graph-backed (app-only).
''' Klasse-naam behouden voor bron-compatibiliteit met frmEWS.vb.
''' </summary>
Public Class EwsTest

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
            If _completeListOfFolderIds Is Nothing Then _completeListOfFolderIds = New List(Of GraphMailFolder)
            Return _completeListOfFolderIds
        End Get
        Set(ByVal value As List(Of GraphMailFolder))
            _completeListOfFolderIds = value
        End Set
    End Property

    Private _ListOfSubFolders As List(Of GraphMailFolder)
    Public Property ListOfSubFolders() As List(Of GraphMailFolder)
        Get
            If _ListOfSubFolders Is Nothing Then _ListOfSubFolders = New List(Of GraphMailFolder)
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

    Public Function GetSubFolders(ByFolderID As String) As List(Of GraphMailFolder)
        ListOfSubFolders.AddRange(GraphSync(Function() GraphGetChildFoldersAsync(MailboxUpn, ByFolderID)))
        Return ListOfSubFolders
    End Function

    ''' <summary>Top-level mailfolders van de mailbox (EWS' MsgFolderRoot-children).</summary>
    Public Sub EwsFolder()
        completeListOfFolderIds = GraphSync(Function() GraphGetChildFoldersAsync(MailboxUpn, String.Empty))
    End Sub

    Public Sub GetItems(ByFolderID As String)
        MailItems = New List(Of Berichten)
        Dim items = GraphSync(Function() GraphGetCollectionAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/mailFolders/{ByFolderID}/messages?$top=999"))

        For Each i As JObject In items
            Dim NewBericht As New Berichten
            With NewBericht
                Dim fromAddr = i("from")
                .FromName = If(fromAddr IsNot Nothing AndAlso fromAddr("emailAddress") IsNot Nothing, CStr(fromAddr("emailAddress")("name")), "n.a.")
                .Header = CStr(i("id"))
                .Subject = CStr(i("subject"))
                .ReceivedDate = CDate(i("receivedDateTime"))
            End With
            MailItems.Add(NewBericht)
        Next
    End Sub

    ''' <summary>Geeft het ruwe Graph message-object terug (id, subject, body, ...).</summary>
    Public Function GetItem(ByUid As String) As JObject
        Return GraphSync(Function() GraphGetAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/messages/{ByUid}"))
    End Function

    Public Sub sendmail(SendTo As String, mySubject As String, ByVal myBody As String)
        Dim message As New JObject()
        message("subject") = mySubject

        Dim body As New JObject()
        body("contentType") = "HTML"
        body("content") = myBody
        message("body") = body

        Dim toRecipient As New JObject()
        Dim toAddr As New JObject()
        toAddr("address") = SendTo
        toRecipient("emailAddress") = toAddr
        message("toRecipients") = New JArray(toRecipient)

        Dim attachments As New JArray()
        For Each embImg In ImageList
            Dim imgBytes = IO.File.ReadAllBytes(embImg.ImageLocation)
            Dim att As New JObject()
            att("@odata.type") = "#microsoft.graph.fileAttachment"
            att("name") = embImg.ImageName
            att("contentBytes") = Convert.ToBase64String(imgBytes)
            att("isInline") = True
            att("contentId") = embImg.ImageName
            attachments.Add(att)
        Next
        If attachments.Count > 0 Then message("attachments") = attachments

        Dim requestBody As New JObject()
        requestBody("message") = message
        requestBody("saveToSentItems") = True

        GraphSync(Function() GraphPostAsync($"users/{Uri.EscapeDataString(MailboxUpn)}/sendMail", requestBody))
    End Sub

    Private _BodyTemplate As String
    Public Property BodyTemplate(ByVal TemplatePath As String) As String
        Get
            Dim fi As New IO.FileInfo(TemplatePath)
            If Not fi.Exists Then Throw New Exception("Kan " & TemplatePath & " niet vinden.")

            Dim content As String = IO.File.ReadAllText(fi.FullName)

            ImageList = New List(Of EmbeddedImages)
            Dim rx As New Regex("src", RegexOptions.IgnoreCase)
            For Each m As Match In rx.Matches(content)
                Dim img As New EmbeddedImages
                img.ImageName = content.Substring(m.Index + 5, content.IndexOf("""", m.Index + 5) - m.Index - 5)
                img.ImageLocation = fi.DirectoryName & "\" & img.ImageName
                ImageList.Add(img)
            Next

            For Each embImg In ImageList
                content = content.Replace(embImg.ImageName, "cid:" & embImg.ImageName)
            Next

            _BodyTemplate = content
            Return _BodyTemplate
        End Get
        Set(ByVal value As String)
            _BodyTemplate = value
        End Set
    End Property

    Private _ImageList As List(Of EmbeddedImages) = New List(Of EmbeddedImages)
    Public Property ImageList() As List(Of EmbeddedImages)
        Get
            Return _ImageList
        End Get
        Set(ByVal value As List(Of EmbeddedImages))
            _ImageList = value
        End Set
    End Property

    Partial Class EmbeddedImages
        Private _ImageLocation As String
        Public Property ImageLocation() As String
            Get
                Return _ImageLocation
            End Get
            Set(ByVal value As String)
                _ImageLocation = value
            End Set
        End Property
        Private _ImageName As String
        Public Property ImageName() As String
            Get
                Return _ImageName
            End Get
            Set(ByVal value As String)
                _ImageName = value
            End Set
        End Property
    End Class

End Class
