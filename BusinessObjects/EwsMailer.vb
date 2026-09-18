Imports BusinessObjects
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

''' <summary>
''' Verstuurt mail via Microsoft Graph (app-only). Klasse-naam "EwsMailer" is behouden om de
''' bestaande aanroepers (frmMailing, frmEmailing) ongewijzigd te laten.
''' </summary>
Public Class EwsMailer

    Sub New()
        'Verbinding wordt niet meer per instantie opgezet; GraphService regelt authenticatie centraal.
    End Sub
    Public Sub New(UseSystemSetting As Boolean)
        'Parameter behouden voor bron-compatibiliteit.
    End Sub

    Private _EmailAddress As String = String.Empty
    Public ReadOnly Property myEmailAddress() As String
        Get
            Return _EmailAddress
        End Get
    End Property

    ''' <summary>
    ''' Valideert de connectie met de standaard verzendmailbox (ESA) en geeft de lijst met
    ''' toegestane "verzenden als"-mailboxen terug. Autodiscover/alternate-mailbox-enumeratie
    ''' bestaat niet in Graph app-only auth (er is geen "ingelogde gebruiker" om alternatieven
    ''' voor op te zoeken) - de lijst komt daarom uit de configureerbare instelling
    ''' "GraphSendFromMailboxes" (kommagescheiden) in plaats van Exchange Autodiscover.
    ''' </summary>
    Public Function getAlternateMailboxCollection() As List(Of String)
        Dim primary = GetSysSettingOf("ESA")

        Try
            GraphSync(Function() GraphGetAsync($"users/{Uri.EscapeDataString(primary)}/mailFolders/inbox"))
        Catch ex As Exception
            Throw New Exception("Kan geen verbinding maken met mailbox " & primary & ": " & ex.Message, ex)
        End Try

        _EmailAddress = primary

        Dim result As New List(Of String)
        result.Add(primary)

        Dim configured = GetSysSettingOf("GraphSendFromMailboxes", False)
        If Not String.IsNullOrEmpty(configured) Then
            For Each addr In configured.Split(New Char() {";"c, ","c}, StringSplitOptions.RemoveEmptyEntries)
                Dim trimmed = addr.Trim()
                If trimmed.Length > 0 AndAlso Not result.Contains(trimmed) Then result.Add(trimmed)
            Next
        End If

        Return result
    End Function

    Public Event GenerateComplete(ByVal iCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)
    Public bAbort As Boolean = False
    Private Counter As Integer = 0

    Private _IsTerminating As Boolean = False
    Public Property IsTerminating() As Boolean
        Get
            Return _IsTerminating
        End Get
        Set(ByVal value As Boolean)
            _IsTerminating = value
        End Set
    End Property

    Private Function IsNetmask() As Boolean
        Try
            Dim localHost As String = System.Net.Dns.GetHostName()

            Dim IPHEntry As System.Net.IPHostEntry
            Dim IPAdd() As System.Net.IPAddress
            IPHEntry = System.Net.Dns.GetHostEntry(localHost)
            IPAdd = IPHEntry.AddressList


            Dim i As Integer
            For i = 0 To IPAdd.GetUpperBound(0)
                If IPAdd(i).ToString.StartsWith("10.2.1.") Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private _MailingTable As DataTable = Nothing
    Public Property MailingTable() As DataTable
        Get
            Return _MailingTable
        End Get
        Set(ByVal value As DataTable)
            _MailingTable = value
        End Set
    End Property

    Private _Subject As String = String.Empty
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property

    Private _SendFrom As String = String.Empty
    Public Property SendFrom() As String
        Get
            Return _SendFrom
        End Get
        Set(ByVal value As String)
            _SendFrom = value
        End Set
    End Property

    ''' <summary>Mailbox waar /sendMail tegen wordt aangeroepen - SendFrom indien opgegeven, anders de standaard verzendmailbox (ESA).</summary>
    Private ReadOnly Property SendMailboxUpn() As String
        Get
            If Not String.IsNullOrEmpty(SendFrom) Then Return SendFrom
            Return GetSysSettingOf("ESA")
        End Get
    End Property

    Public _BodyTemplate As String
    Public Sub SetBodyTemplate(ByVal Template As String)

        Dim _Content As String
        Dim _Reader As IO.StreamReader
        Try
            Dim fi As IO.FileInfo = New IO.FileInfo(Template)
            If Not fi.Exists Then
                Throw New Exception("Kan " & Template & " niet vinden.")
            End If

            Dim floc As String = fi.DirectoryName

            _Reader = New IO.StreamReader(fi.FullName)
            _Content = _Reader.ReadToEnd()
            _Reader.Close()
            _BodyTemplate = _Content

            Dim rx As Regex
            Dim Matches As MatchCollection
            rx = New Regex("src", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Matches = rx.Matches(_BodyTemplate)

            Dim fiTestImg As IO.FileInfo

            ImageList = New List(Of EmbeddedImages)
            Dim _EmbeddedImages As EmbeddedImages
            For Each _img As Match In Matches
                _EmbeddedImages = New EmbeddedImages
                _EmbeddedImages.ImageName = _BodyTemplate.Substring(_img.Index + 5, _BodyTemplate.IndexOf("""", _img.Index + 5) - _img.Index - 5)
                _EmbeddedImages.ImageLocation = floc & "\" & _EmbeddedImages.ImageName
                Try
                    fiTestImg = New IO.FileInfo(_EmbeddedImages.ImageLocation)
                    If Not fiTestImg.Exists Then
                        Throw New Exception("Kan src" & _EmbeddedImages.ImageLocation & " niet vinden.")
                    End If
                Catch ex As Exception
                    Throw New Exception("Kan src" & _EmbeddedImages.ImageLocation & " niet vinden.")
                End Try

                ImageList.Add(_EmbeddedImages)
            Next


            For Each embImg In ImageList
                _BodyTemplate = _BodyTemplate.Replace(embImg.ImageName, "cid:" & embImg.ImageName)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public bWrite2Correspondetie As Boolean = False
    Public CorrespondentieList As List(Of Documents)

    Public Sub Process()
        Try
            If MailingTable Is Nothing Then
                RaiseEvent GenerateExp(New Exception("Er is nog geen data opgegeven!"))
            End If
            If MailingTable.Rows.Count = 0 Then
                RaiseEvent GenerateExp(New Exception("De opgegeven data bevat geen records!"))
            End If
            If String.IsNullOrEmpty(_BodyTemplate) Then
                RaiseEvent GenerateExp(New Exception("Er is nog geen body opgegeven!"))
            End If

            CorrespondentieList = New List(Of Documents)

            For Each dr As DataRow In MailingTable.Rows
                If IsTerminating Then
                    RaiseEvent GenerateStatus("IsTerminating")
                    RaiseEvent GenerateComplete(0)
                    Exit Sub
                End If
                Counter += 1

                If Counter Mod 10 = 0 Then
                    RaiseEvent GenerateStatus("Bezig met mailen van record " & Counter)
                    RaiseEvent GenerateCounter(Counter)
                End If

                '*** indien geen subject opgegeven gebruik dan de standaard.
                If Subject = String.Empty Then Subject = "Mailing"

                If dr.Table.Columns.Contains("Attfile") Then
                    sendmail(dr.Item("email"), Subject, PersonifyBody(dr), dr.Item("Attfile"))
                Else
                    sendmail(dr.Item("email"), Subject, PersonifyBody(dr))
                End If

                'Als bWrite2Correspondetie = True dan regel wegschrijven naar de relatiekaart
                If bWrite2Correspondetie Then
                    Dim NewDocument As New Documents
                    With NewDocument
                        .CreateDate = Now
                        .CreatedBy = Me.SendFrom
                        .Location = ""
                        .RefID = Subject
                        .LidId = dr.Item("Id").ToString
                        .Template = "emailing"
                        .Save()
                    End With
                End If

            Next

            RaiseEvent GenerateStatus("Klaar")
            RaiseEvent GenerateComplete(0)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try

    End Sub
    Private Function PersonifyBody(dr As DataRow) As String
        Try
            Dim LidBody As String = _BodyTemplate

            LidBody = LidBody.Replace("xACHTERNAAM", dr.Item("achternaam"))
            LidBody = LidBody.Replace("xLIDNR", dr.Item("lidnr"))
            LidBody = LidBody.Replace("xEMAIL", dr.Item("email"))
            LidBody = LidBody.Replace("xACHTERNAAM", dr.Item("achternaam"))
            LidBody = LidBody.Replace("xINIT", dr.Item("init"))
            LidBody = LidBody.Replace("xTUSSENVOEGSEL", dr.Item("tussenvoegsel"))
            LidBody = LidBody.Replace("xTITELVOOR", dr.Item("titelvoor"))
            LidBody = LidBody.Replace("xGESLACHT", dr.Item("geslacht"))
            LidBody = LidBody.Replace("xPOSTCODE", dr.Item("postcode"))
            LidBody = LidBody.Replace("xADRES", dr.Item("adres"))
            LidBody = LidBody.Replace("xHUISNRTV", dr.Item("huisnrtv"))
            LidBody = LidBody.Replace("xHUISNR", dr.Item("huisnr"))
            LidBody = LidBody.Replace("xPLAATS", dr.Item("plaats"))

            Return LidBody
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub sendmail(mySendTo As String, mySubject As String, ByVal myBody As String, Optional ByVal AttFileName As String = Nothing)
        Try
            Dim SendTo As String = mySendTo.Trim

            If Not String.IsNullOrEmpty(SendTo) Then
                If IsNetmask() Then
                    'dan is het een testomgeving en mag het niet naar buiten.
                    If SendTo.EndsWith("netmask.nl") Then
                        'dan gaat het naar netmask en is het goed
                    Else
                        'dan stond er een extern addres en dus aanpassen.
                        If SendTo = "bert997@gmail.com" Then
                            'dan gaat het naar mijn buitenom test en is het goed
                        Else
                            SendTo = "bert@netmask.nl"
                        End If
                    End If
                End If

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

                If Not String.IsNullOrEmpty(SendFrom) Then
                    Dim replyRecipient As New JObject()
                    Dim replyAddr As New JObject()
                    replyAddr("address") = SendFrom
                    replyRecipient("emailAddress") = replyAddr
                    message("replyTo") = New JArray(replyRecipient)
                End If

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

                If Not String.IsNullOrEmpty(AttFileName) Then
                    Dim fileBytes = IO.File.ReadAllBytes(AttFileName)
                    Dim fileAtt As New JObject()
                    fileAtt("@odata.type") = "#microsoft.graph.fileAttachment"
                    fileAtt("name") = IO.Path.GetFileName(AttFileName)
                    fileAtt("contentBytes") = Convert.ToBase64String(fileBytes)
                    attachments.Add(fileAtt)
                End If

                If attachments.Count > 0 Then message("attachments") = attachments

                Dim requestBody As New JObject()
                requestBody("message") = message
                requestBody("saveToSentItems") = True

                GraphSync(Function() GraphPostAsync($"users/{Uri.EscapeDataString(SendMailboxUpn)}/sendMail", requestBody))

            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

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
