Imports BusinessObjects

Partial Class password
    Inherits System.Web.UI.Page
    Private _utils As New Utilities
    Private _lidnr As String = "0"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                MultiView1.SetActiveView(ResetView)
            Else
                MultiView1.SetActiveView(ResetDoneView)
            End If



        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try

            Dim lid As New WebLid(tbLidNr.Text, WebLid.Via.LIDNR)

            If lid.Found Then

                If String.IsNullOrEmpty(lid.b_email) Then
                    Me.lblError.Text = "Sorry, Uw emailadres is bij ons niet bekend. <br> Bel dan met de VBM (070-3155111) om uw juiste email adres te registreren."""
                    MultiView1.SetActiveView(ResetView)
                Else
                    MultiView1.SetActiveView(VerifyView)
                    'Dim BasicMail As String = lid.b_email
                    'Dim mailDomain As String = BasicMail.Remove(0, BasicMail.IndexOf("@"))
                    'Dim mailName As String = BasicMail.Substring(0, BasicMail.IndexOf("@"))
                    'Dim LastChars As String = ""
                    'Dim FirstChars As String = ""
                    'Dim sChar As String = ""

                    'Select Case mailName.Length
                    '    Case Is < 6
                    '        LastChars = mailName.Remove(0, mailName.Length - 2)
                    '        For i = 1 To (mailName.Length - LastChars.Length)
                    '            sChar = "*" & sChar
                    '        Next
                    '        mailName = sChar & LastChars
                    '    Case Else
                    '        LastChars = mailName.Remove(0, mailName.Length - 2)
                    '        FirstChars = mailName.Substring(0, 1)
                    '        For i = 1 To (mailName.Length - LastChars.Length - 1)
                    '            sChar = "*" & sChar
                    '        Next
                    '        mailName = FirstChars & sChar & LastChars
                    'End Select

                    Dim VerifyText As String = "Als u op de knop hieronder klikt wordt er een email gestuurd naar " & lid.EmailMasker & " (uw email adres is gedeeltelijk verborgen) " & _
                        "<br>Is dit niet uw email adres? Bel dan met de VBM (070-3155111) om uw juiste email adres te registreren."
                    lblVerifyEmail.Text = VerifyText

                End If
            Else
                Me.lblError.Text = "Sorry, Uw lidmaatschapnummer is bij ons niet bekend"
            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            Dim NewActivation As New Activatie
            Dim lid As New WebLid(tbLidNr.Text, WebLid.Via.LIDNR)
            If lid.Found Then
                If String.IsNullOrEmpty(lid.b_email) Then
                    Me.lblError.Text = "Sorry, Uw emailadres is bij ons niet bekend"
                    MultiView1.SetActiveView(ResetView)
                Else
                    With NewActivation
                        .IPADDRESS = Request.UserHostAddress()
                        .Lidnr = tbLidNr.Text
                        .DateSend = Now
                        .DateConfirmd = Data.SqlTypes.SqlDateTime.MinValue
                        .Type = "passwordreset"
                        .SearchId = lid.Id
                        .Save()
                    End With

                    Dim oEmail As New Email
                    oEmail.Address = lid.b_email
                    oEmail.Name = lid.FullName

                    Dim oMailer As New Mailer
                    oMailer.MailSubject = "VBM aanmelding:"

                    Dim Body As String = oMailer.BodyTemplate("passwordreset")
                    Body = Body.Replace("xACHTERNAAM", lid.achternaam)
                    Body = Body.Replace("xURL", _utils.CurrentSite)
                    Body = Body.Replace("xGUID", NewActivation.ActivatieGUID.ToString)
                    Body = Body.Replace("xLIDNR", lid.lidnr)
                    Body = Body.Replace("xLIDBOEKING", lid.Boeking_Message.Replace(vbCrLf, "<br/>"))
                    oMailer.MailBody = Body
                    oMailer.SendEmbeddedImages(oEmail)

                    Response.Redirect("confirm.aspx?reset=yes")
                End If
            Else
                Me.lblError.Text = "Sorry, Uw lidmaatschapnummer is bij ons niet bekend"
            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
End Class
