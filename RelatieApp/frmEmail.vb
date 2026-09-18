Imports BusinessObjects
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Net.Mail
Imports System.Text
Imports MapiObjects

Public Class frmEmail
    Dim BerichtenId As Integer = -1

    Public Sub New(byId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        BerichtenId = byId
        FillBericht()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private _MyOutlookAccount As Outlook.Account
    Public ReadOnly Property MyOutlookAccount() As Outlook.Account
        Get
            If _MyOutlookAccount Is Nothing Then
                Dim MO As New MapiObject(GetSysSettingOf("IBBCalAccount"))
                _MyOutlookAccount = MO.MyOutlookAccount
            End If
            Return _MyOutlookAccount
        End Get
    End Property
    Private _Bericht As Berichten
    Public ReadOnly Property Bericht() As Berichten
        Get
            If _Bericht Is Nothing Then
                _Bericht = New Berichten(BerichtenId)
            End If
            Return _Bericht
        End Get
    End Property

    Private Sub chkOutlookUser_CheckedChanged(sender As Object, e As EventArgs) Handles chkOutlookUser.CheckedChanged
        Try

            If chkOutlookUser.Checked Then
                tbFrom.Text = MyOutlookAccount.CurrentUser.Name
            Else
                tbFrom.Text = ""
            End If

            tbFrom.ReadOnly = chkOutlookUser.Checked

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillBericht()
        Try
            If Bericht.Found Then
                With Bericht
                    tbFrom.Text = .FromAddress
                    '.ToAddress
                    tbSubject.Text = .Subject
                    If .isHTML Then
                        WebBrowser1.DocumentText = .BodyText
                    Else
                        rtbBody.Text = .BodyText
                    End If

                    .isHTML = True
                End With


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Try

            Dim oMailer As New Mailer


            If chkOutlookUser.Checked Then
                oMailer.MailSenderDisplayName = MyOutlookAccount.CurrentUser.Name
                oMailer.MailSender = MyOutlookAccount.SmtpAddress
            Else
                oMailer.MailSender = tbFrom.Text
                oMailer.MailSenderDisplayName = tbFrom.Text
            End If

            oMailer.MailRecipient = tbTo.Text
            oMailer.MailSubject = tbSubject.Text
            If Not String.IsNullOrEmpty(tbAtt.Text) Then
                oMailer.AddAttachment(tbAtt.Text)
            End If

            Dim Body As String = rtbBody.Text
            oMailer.MailBody = Body

            oMailer.SendMail()

            'Dim oEmail As New Email
            'oEmail.Address = tbTo.Text
            'oEmail.Name = tbTo.Text
            'oMailer.SendEmbeddedImages(oEmail)
            Dim MyBericht As New Berichten
            With MyBericht
                .FromAddress = oMailer.MailSender
                .ToAddress = oMailer.MailRecipient
                .Subject = oMailer.MailSubject
                .BodyText = oMailer.MailBody
                .DossierId = 2
                .CreateDate = Now
                .isHTML = True
                .Save()
            End With

            'If Not String.IsNullOrEmpty(myFullFileName) Then
            '    Dim NewIBBdocument As New IBBDocument
            '    NewIBBdocument.DossierId = myIBBDossier.Id
            '    NewIBBdocument.Location = myFullFileName
            '    NewIBBdocument.Onderwerp = Me.tbShortDescription.Text.Trim
            '    NewIBBdocument.Template = "msg"
            '    NewIBBdocument.Bericht.DossierId = myIBBDossier.Id
            '    NewIBBdocument.Bericht.ReceivedDate = MyCurrentMail.ReceivedTime
            '    NewIBBdocument.Bericht.Subject = Me.tbShortDescription.Text.Trim
            '    NewIBBdocument.Bericht.FromName = Me.tbSenderName.Text.Trim
            '    NewIBBdocument.Bericht.FromAddress = MyCurrentMail.SenderEmailAddress.ToString
            '    If MyCurrentMail.BodyFormat = Outlook.OlBodyFormat.olFormatHTML Then
            '        NewIBBdocument.Bericht.BodyText = MyCurrentMail.HTMLBody
            '        NewIBBdocument.Bericht.isHTML = 1
            '    Else
            '        NewIBBdocument.Bericht.isHTML = 0
            '        NewIBBdocument.Bericht.BodyText = MyCurrentMail.Body
            '    End If
            '    NewIBBdocument.Bericht.Header = MyCurrenHeader
            '    NewIBBdocument.Bericht.Save()
            '    NewIBBdocument.BerichtenId = NewIBBdocument.Bericht.Id
            '    NewIBBdocument.Save()
            'End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub rtbBody_TextChanged(sender As Object, e As EventArgs) Handles rtbBody.TextChanged
        ' WebBrowser1.DocumentText = rtbBody.Text
        'WebBrowser1.DocumentText = XmlEncode(rtbBody.Text)

        'Dim s As String = rtbBody.Text


    End Sub
    Private Sub chkHTML_CheckedChanged(sender As Object, e As EventArgs) Handles chkHTML.CheckedChanged

        WebBrowser1.DocumentText = rtbBody.Text
        WebBrowser1.Document.Write(WebBrowser1.DocumentText)
        'WebBrowser1.Document.Body.SetAttribute("contentEditable", "true")
    End Sub

    Private Sub btnAtt_Click(sender As Object, e As EventArgs) Handles btnAtt.Click
        Try
            With Me.OpenFileDialog1
                .Reset()

                If Me.tbAtt.Text = "" Then
                    '.InitialDirectory = Application.StartupPath
                End If
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .Multiselect = False
                .Title = "Select a file"
                .ValidateNames = True
                If .ShowDialog() = DialogResult.OK Then
                    Me.tbAtt.Text = .FileName
                    'My.Settings.Save()
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAttClear_Click(sender As Object, e As EventArgs) Handles btnAttClear.Click
        Me.tbAtt.Text = ""
    End Sub



End Class