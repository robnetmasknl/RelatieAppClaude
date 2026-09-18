Imports System.Net.Mail
Imports System.Net
Imports System.Net.Mime
Imports System.Text.RegularExpressions

Public Class Mailer
    Private MailServer As SmtpClient

    Private _MailHost As String = ""
    Private _MailSender As String = ""
    Private _MailSenderDisplayName As String = ""
    Private _MailRecipient As String = ""
    Private _MailSubject As String = ""
    Private _MailBody As String = ""
    Private _UserName As String = ""
    Private _PassWord As String = ""
    Private _BodyPlainText As String = ""
    Private _MailSalutation As String = ""

    Private _WithSendEmbeddedImages As Boolean = False
    Private _ImageLocation As String = ""
    Private _AttColl As Mail.AttachmentCollection
    Private _Att As Mail.Attachment
    Private _ImageView As AlternateView

    Private _settings As Settings = Settings.Instance
    Public Sub New()
        '_settings = New Settings

    End Sub

    Public Property BodyPlainText() As String
        Get
            Return _BodyPlainText
        End Get
        Set(ByVal value As String)
            _BodyPlainText = value
        End Set
    End Property

    Public Property WithSendEmbeddedImages() As Boolean
        Get
            Return _WithSendEmbeddedImages
        End Get
        Set(ByVal value As Boolean)
            _WithSendEmbeddedImages = value
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

    Public Property ImageLocation() As String
        Get
            If _ImageLocation.Length = 0 Then Throw New Exception("Er is geen image locatie opgegeven")
            Return _ImageLocation
        End Get
        Set(ByVal value As String)
            _ImageLocation = value
        End Set
    End Property

    Public Property AttColl() As Mail.AttachmentCollection
        Get
            Return _AttColl
        End Get
        Set(ByVal value As Mail.AttachmentCollection)
            _AttColl = value
        End Set
    End Property

    Public Property Att() As Mail.Attachment
        Get
            Return _Att
        End Get
        Set(ByVal value As Mail.Attachment)
            _Att = value
        End Set
    End Property

    Public Property ImageView() As AlternateView
        Get

            Dim ext As String = System.IO.Path.GetExtension(_ImageLocation)
            Dim MediaType As String = ""
            Select Case ext.ToLower
                Case ".gif"
                    MediaType = MediaTypeNames.Image.Gif
                Case ".jpeg", ".jpg"
                    MediaType = MediaTypeNames.Image.Jpeg
                Case ".tif", ".tiff"
                    MediaType = MediaTypeNames.Image.Tiff
            End Select
            _ImageView = New AlternateView(_ImageLocation, MediaType)
            _ImageView.ContentId = "uniqueId"
            _ImageView.TransferEncoding = TransferEncoding.Base64

            Return _ImageView
        End Get
        Set(ByVal value As AlternateView)
            _ImageView = value
        End Set
    End Property


    Private _IsResolved As Boolean = False

    Public Property MailHost() As String
        Get
            _MailHost = _settings.Mailserver
            If _MailHost.Length = 0 Then Throw New Exception("Er is geen mailserver opgegeven")
            Return _MailHost
        End Get
        Set(ByVal value As String)
            _MailHost = value
        End Set
    End Property

    Public Property MailSender() As String
        Get
            If String.IsNullOrEmpty(_MailSender) Then
                _MailSender = _settings.MailSenderEmail
            End If

            If _MailSender.Length = 0 Then Throw New Exception("Er is geen afzender opgegeven")
            Return _MailSender
        End Get
        Set(ByVal value As String)
            _MailSender = value
        End Set
    End Property
    Public Property MailSenderDisplayName() As String
        Get
            If String.IsNullOrEmpty(_MailSenderDisplayName) Then
                _MailSenderDisplayName = _settings.MailSenderName
            End If

            If _MailSenderDisplayName.Trim.Length = 0 Then
                Return _MailSender
            Else
                Return _MailSenderDisplayName
            End If
        End Get
        Set(ByVal value As String)
            _MailSenderDisplayName = value
        End Set
    End Property
    Public Property MailRecipient() As String
        Get
            If _MailRecipient.Length = 0 Then Throw New Exception("Er is geen Recipient opgegeven")
            Return _MailRecipient
        End Get
        Set(ByVal value As String)
            _MailRecipient = value
        End Set
    End Property

    Public Property MailSalutation() As String
        Get
            Return _MailSalutation
        End Get
        Set(ByVal value As String)
            _MailSalutation = value
        End Set
    End Property

    Public Property MailSubject() As String
        Get
            If _MailSubject.Length = 0 Then Throw New Exception("Er is geen onderwerp opgegeven")
            Return _MailSubject
        End Get
        Set(ByVal value As String)
            _MailSubject = value
        End Set
    End Property

    Public Property MailBody() As String
        Get
            If _MailBody.Length = 0 Then Throw New Exception("Er is geen body opgegeven")
            Return _MailBody
        End Get
        Set(ByVal value As String)
            _MailBody = value
        End Set
    End Property
    Private _BodyTemplate As String

    ' Dim mySetting As Settings = Settings.Instance

    Public Property BodyTemplate(ByVal TemplateName As String) As String
        Get
            Dim _Content As String
            Dim _Reader As IO.StreamReader
            Try

                _Reader = New IO.StreamReader(_settings.LogFilePath & "\" & TemplateName & ".html")
                _Content = _Reader.ReadToEnd()
                _Reader.Close()
                _BodyTemplate = _Content

                Dim rx As Regex
                Dim Matches As MatchCollection
                rx = New Regex("src", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                Matches = rx.Matches(_BodyTemplate)

                ImageList = New List(Of EmbeddedImages)
                Dim _EmbeddedImages As EmbeddedImages
                For Each _img As Match In Matches
                    _EmbeddedImages = New EmbeddedImages
                    _EmbeddedImages.ImageName = _BodyTemplate.Substring(_img.Index + 5, _BodyTemplate.IndexOf("""", _img.Index + 5) - _img.Index - 5)
                    _EmbeddedImages.ImageLocation = _settings.LogFilePath & "\" & _EmbeddedImages.ImageName
                    ImageList.Add(_EmbeddedImages)
                Next


                For Each embImg In ImageList
                    _BodyTemplate = _BodyTemplate.Replace(embImg.ImageName, "cid:" & embImg.ImageName.Substring(0, embImg.ImageName.LastIndexOf(".")))
                Next



                ImageLocation = _settings.LogFilePath & "\banner.jpg"
                WithSendEmbeddedImages = True
            Catch Ex As Exception
                Throw Ex
            End Try

            Return _BodyTemplate
        End Get
        Set(ByVal value As String)
            _BodyTemplate = value
        End Set
    End Property

    Public Property Username() As String
        Get
            _UserName = _settings.MailAccount
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property PassWord() As String
        Get
            _PassWord = _settings.MailAccountPassword
            Return _PassWord
        End Get
        Set(ByVal value As String)
            _PassWord = value
        End Set
    End Property
    Public Property IsResolved() As Boolean
        Get
            Return _IsResolved
        End Get
        Set(ByVal value As Boolean)
            _IsResolved = value
        End Set
    End Property

    Public Sub ResolveMailServer()
        If Not IsResolved Then
            Dim _IP As IPAddress = Nothing
            Dim _ResolvedMailhost As New IPHostEntry
            Try
                _ResolvedMailhost = Dns.GetHostEntry(MailHost)
                MailHost = _ResolvedMailhost.HostName
                If MailHost.Length = 0 Then
                    Throw New Exception("Er is geen mailserver opgegeven")
                End If
                IsResolved = True
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Public Function MailMessage() As MailMessage
        Try
            ResolveMailServer()

            MailMessage = New MailMessage(New MailAddress(MailSender, MailSenderDisplayName), New MailAddress(MailRecipient))
            If Not Att Is Nothing Then
                MailMessage.Attachments.Add(Att)
            End If

            MailMessage.BodyEncoding = System.Text.Encoding.Default
            MailMessage.Subject = MailSubject.Trim()
            MailMessage.Body = MailBody.Trim() & vbCrLf
            MailMessage.Priority = MailPriority.Normal
            MailMessage.IsBodyHtml = True
            Return MailMessage
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function Validatemail() As Boolean
        Dim bValid As Boolean = False
        Try
            If MailHost.Length = 0 Then Throw New Exception("Er is geen mailserver opgegeven")
            If MailSender.Length = 0 Then Throw New Exception("Er is geen mailserver opgegeven")
            If Me.WithSendEmbeddedImages Then
                Dim test As String = ImageLocation
            Else
                'If MailBody.Trim.Length = 0 Then Throw New Exception("Er is geen body opgegeven")
                Dim test As String = MailBody
            End If

            Return bValid
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub SendMail()
        Try
            MailServer = New SmtpClient
            MailServer.Host = MailHost
            'SendEmbeddedImages()
            MailServer.Send(MailMessage)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function MailMessageEmbeddedImages(ByVal _email As Email) As MailMessage
        Try
            ResolveMailServer()
            MailMessageEmbeddedImages = New MailMessage(New MailAddress(MailSender, MailSenderDisplayName), New MailAddress(_email.Address, _email.Name))

            If Not Att Is Nothing Then MailMessageEmbeddedImages.Attachments.Add(Att)

            Dim plainBody As String = BodyPlainText
            Dim plainView As AlternateView = AlternateView.CreateAlternateViewFromString(plainBody, Nothing, MediaTypeNames.Text.Plain)
            Dim htmlBody As String = Me.MailBody

            'htmlBody = htmlBody.Replace("<Geachte ##>", _email.Salutation)

            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, MediaTypeNames.Text.Html)

            For Each embImg In ImageList
                Dim banner As New LinkedResource(embImg.ImageLocation)
                banner.ContentId = embImg.ImageName.Substring(0, embImg.ImageName.LastIndexOf("."))
                htmlView.LinkedResources.Add(banner)
            Next

            MailMessageEmbeddedImages.AlternateViews.Add(plainView)
            MailMessageEmbeddedImages.AlternateViews.Add(htmlView)
            ' EmbeddedImages.AlternateViews.Add(ImageView)

            MailMessageEmbeddedImages.Subject = MailSubject.Trim()

            Return MailMessageEmbeddedImages
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub SendEmbeddedImages(ByVal _email As Email)
        Try
            Dim MailServer As SmtpClient
            MailServer = New SmtpClient
            MailServer.Host = MailHost
            If Not String.IsNullOrEmpty(PassWord) Then
                MailServer.Credentials = New NetworkCredential(Username, PassWord)
            End If


            If Not String.IsNullOrEmpty(_email.Address) Then
                If IsNetmask() Then ' dan is het een testomgeving en mag het niet naar buiten.
                    If _email.Address.EndsWith("netmask.nl") Then
                        'dan gaat het naar netmask en is het goed
                    Else
                        'dan stond er een extern addres en dus aanpassen.
                        If _email.Address = "bert997@gmail.com" Then
                            'dan gaat het naar mij en is het goed
                        Else
                            _email.Address = "bert@netmask.nl"
                        End If

                    End If
                End If
            End If


            MailServer.Send(MailMessageEmbeddedImages(_email))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
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
    Public Sub AddAttachment(FileAttachment As String)
        Try
            Att = New Mail.Attachment(FileAttachment)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

