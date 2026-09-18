Imports BusinessObjects

Partial Class logincls
    Inherits System.Web.UI.Page
    Private _lidnr As String = "0"
    Private _utils As New Utilities

    Private _lid As WebLid
    Public ReadOnly Property lid() As WebLid
        Get
            If _lid Is Nothing Then
                _lid = New WebLid(_lidnr, WebLid.Via.LIDNR)

                If _lid.Id = "0" Then
                    Throw New Exception("Het lidmaatschapnummer " & _lidnr & " is niet gevonden.")
                End If
            End If

            Return _lid
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Page.Title = "Inlogscherm"
            MultiView1.SetActiveView(LoginView)

            If Not Request.QueryString("lidnr") = Nothing Then
                _lidnr = Request.QueryString("lidnr")
                Me.tbLidNr.Text = _lidnr
                If lid.wachtwoord = "default" Or lid.wachtwoord = "" Then
                    MultiView1.SetActiveView(RegistrationView)
                    Me.btnRegister.Visible = True
                    Me.lblError.Text = ""
                    Me.lblLidnrReg.Text = lid.lidnr
                    Me.lblNameReg.Text = lid.FullName

                    Me.lblDateOfBirthReg.Text = lid.geboortedatum
                    Me.lblLidsindsReg.Text = lid.indatum
                    'Me.tbTelephoneReg.Text = lid.b_telefoon
                    'Me.tbMobileReg.Text = lid.b_mobiel
                    Me.lblError.Text = "U heeft nog niet aangemeld! <br/> U kunt zich hier aanmelden!"
                End If

            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try


    End Sub


    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try
            'controle of er binnen x aantal seconden via het zelfde IP een request is gedaan
            'zo ja afvangen.
            Dim NewIpBlocker As New IpBlocker
            NewIpBlocker = New IpBlocker(Request.UserHostAddress, IpBlocker.Via.IP)
            If NewIpBlocker.ToManyAttemps Then
                With NewIpBlocker
                    '.IPADDRESS = Request.UserHostAddress()
                    .SearchName = _lidnr
                    .TimeStamp = Now
                    .SearchDOB = ""
                    .Type = "LogonRequest"
                    .Attempts = .Attempts + 1
                    .Save()
                    Me.lblError.Text = "Teveel pogingen vanaf dit IP adres! <br> Probeer het over " & .TimeBetweenFailures & " minuten nog eens!"
                End With
            Else
                Me.lblError.Text = ""
                _lidnr = Me.tbLidNr.Text
                Session("onthouden") = Me.tbPassword.Text

                If lid.wachtwoord = Session("onthouden") Then
                    'If lid.bevestigd Then
                    Session("lidnr") = _lidnr
                    'controleer of er een email adres aanwezig is
                    If String.IsNullOrEmpty(lid.b_email) Then
                        ''BMO:16-11-2020: tbv ANPV ("TA") registratie overslaan, maar direct naar invullen contactgegevens
                        If lid.lidnr.ToUpper.StartsWith("TA") Then
                            MultiView1.SetActiveView(ANPVView)
                            Me.btnRegisterA.Visible = True
                            Me.lblError.Text = ""
                            Me.lblLidnrRegTA.Text = lid.lidnr
                            Me.tbNameRegTA.Text = lid.achternaam
                            Me.tbEmailTA.Text = lid.b_email
                            Me.tbTelephoneRegTA.Text = lid.b_telefoon
                            Me.tbMobileRegTA.Text = lid.b_mobiel
                        Else
                            MultiView1.SetActiveView(RegistrationView)
                            Me.btnRegister.Visible = True
                            Me.lblError.Text = ""
                            Me.lblLidnrReg.Text = lid.lidnr
                            Me.lblNameReg.Text = lid.FullName
                            Me.lblLidsindsReg.Text = lid.indatum
                            Me.tbEmail.Text = lid.b_email
                            Me.tbTelephoneReg.Text = lid.b_telefoon
                            Me.tbMobileReg.Text = lid.b_mobiel

                            tbWachtwoord.TextMode = TextBoxMode.SingleLine
                            tbWachtwoord.Text = lid.wachtwoord
                            tbWachtwoord.Visible = False

                            tbWachtwoordConfirm.TextMode = TextBoxMode.SingleLine
                            tbWachtwoordConfirm.Text = lid.wachtwoord
                            tbWachtwoordConfirm.Visible = False
                            Me.lblDateOfBirthReg.Text = lid.geboortedatum '.ToLongDateString
                        End If

                        Me.lblError.Text = "U heeft nog geen emailadres opgegeven! <br/> Controleer uw gegevens!"
                    Else
                        'bugid:1134: Controle of het account nog actief lid is.
                        'vul het controlle veld met een datum in de toekomst, zodat er iig een datum staat. kan niet verifieren met een leeg datefield
                        'indien eindedatum bestaat het overschrijven met die datum 
                        Dim eindedatum As Date = Today.AddYears(1)
                        If Not String.IsNullOrEmpty(lid.eindedatum) Then eindedatum = CDate(lid.eindedatum)
                        If lid.Status <> 0 And eindedatum < Now Then
                            Me.lblError.Text = "U bent geen actief lid. Neem contact op met het secretariaat om een reservering te maken."
                            _lid = Nothing
                        Else
                            'Vraag controle email.Indien nee, door gaan naar nieuw email adres invoeren en weer bevestigen. 
                            'bugid:1242 Check of tel/mob is gevuld
                            Dim VerifyText As String = "Uw email adres is " & lid.b_email
                                If String.IsNullOrEmpty(lid.b_mobiel) AndAlso String.IsNullOrEmpty(lid.b_telefoon) Then
                                    Me.lblError.Text = "U heeft nog geen telefoonnummer opgegeven! <br/> Controleer uw gegevens!"
                                    VerifyText = "Wijzig uw gegevens."
                                    btnYes.Visible = False
                                    BtnNo.Text = "Ja"
                                ElseIf Not String.IsNullOrEmpty(lid.b_mobiel) And lid.b_mobiel.Length > 4 Then
                                    VerifyText &= " en uw mobiele nr eindigt op " & lid.b_mobiel.Substring(lid.b_mobiel.Length - 3) & "<br> Is dit juist?"
                                Else
                                    VerifyText &= "? <br> Is dit juist?"
                                End If
                                lblVerifyEmail.Text = VerifyText

                            'BMO:16-11-2020: tbv ANPV ("TA") verificatie overslaan, maar direct naar boeken
                            If lid.bankrek = 0 Then
                                Session("volmacht") = "vmnee"
                            Else
                                Session("volmacht") = "vmja"
                            End If
                            MultiView1.SetActiveView(VerifyView)
                            'MultiView1.SetActiveView(VolmachtView)

                            'FillFields()
                        End If
                        End If
                        'Else
                        '    Me.lblError.Text = "U heeft uw aanmelding nog niet bevestigd"
                        '    _lid = Nothing
                        'End If

                    Else
                    If lid.wachtwoord = "default" Or lid.wachtwoord = "" Then
                        MultiView1.SetActiveView(RegistrationView)
                        Me.btnRegister.Visible = True
                        Me.lblError.Text = ""
                        Me.lblLidnrReg.Text = lid.lidnr
                        Me.lblNameReg.Text = lid.FullName
                        'Me.lblAdresReg.Text = lid.FullAddress
                        'Me.lblPostcodeReg.Text = lid.postcode
                        'Me.lblWoonplaatsReg.Text = lid.plaats
                        'Me.tbTelephoneReg.Text = lid.b_telefoon
                        'Me.tbMobileReg.Text = lid.b_mobiel
                        'Me.tbEmail.Text = lid.email
                        'Me.tbWachtwoord.Text = "" '_Lid.wachtwoord
                        Me.lblDateOfBirthReg.Text = lid.geboortedatum
                        Me.lblLidsindsReg.Text = lid.indatum
                        Me.lblError.Text = "U heeft nog niet aangemeld! <br/> U kunt zich hier aanmelden!"
                    Else
                        With NewIpBlocker
                            .IPADDRESS = Request.UserHostAddress()
                            .SearchName = _lidnr
                            .TimeStamp = Now
                            .SearchDOB = ""
                            .Type = "LogonRequest"
                            .Attempts = .Attempts + 1
                            .Save()
                        End With
                    End If
                    MultiView1.SetActiveView(LoginView)
                    Me.tbLidNr.Text = _lidnr
                    Me.lblError.Text = "Inloggen mislukt. Controleer uw gegevens!"
                    _lid = Nothing
                End If
            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try

    End Sub
    Protected Sub btnVMJa_Click(sender As Object, e As EventArgs) Handles btnVMJa.Click
        Try
            Session("volmacht") = "vmja"
            Response.Redirect("Reservation.aspx")
            FillFields()
        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try

    End Sub
    Protected Sub btnVMNee_Click(sender As Object, e As EventArgs) Handles btnVMNee.Click
        Try
            Session("volmacht") = "vmnee"
            Response.Redirect("Reservation.aspx")
            FillFields()
        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try

    End Sub
    Protected Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Try
            If Session("volmacht") = "vmnee" Then
                Response.Redirect("Reservation.aspx")
            Else
                MultiView1.SetActiveView(VolmachtView)
            End If
            'FillFields()
        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try

    End Sub
    Protected Sub BtnNo_Click(sender As Object, e As EventArgs) Handles BtnNo.Click
        Try
            MultiView1.SetActiveView(ChangeMailView)

            tbChangeEmail.Text = lid.b_email
            tbChangePhone.Text = lid.b_telefoon
            tbChangeMobile.Text = lid.b_mobiel

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
    Protected Sub btnSaveMail_Click(sender As Object, e As EventArgs) Handles btnSaveMail.Click
        Try
            _lidnr = Me.tbLidNr.Text

            If lid.wachtwoord = Session("onthouden") Then
                'If lid.bevestigd Then
                If String.IsNullOrEmpty(Me.tbChangePhone.Text) AndAlso String.IsNullOrEmpty(Me.tbChangeMobile.Text) Then
                        Throw New Exception("Geef minstens 1 telefoonnummer op!")
                    End If

                    With lid
                        Dim myHistory As New History
                        If .b_email <> Me.tbChangeEmail.Text Then
                            myHistory = New History
                            myHistory.LidId = .Id
                            myHistory.TableName = "relaties via web"
                            myHistory.Veld = "b_email"
                            myHistory.WaardeOud = .b_email
                            myHistory.WaardeNieuw = Me.tbChangeEmail.Text
                            myHistory.MutDate = Now
                            myHistory.MutDoor = Request.UserHostAddress()
                            myHistory.Save()
                            .bevestigd = False
                        End If
                        If .b_telefoon <> Me.tbChangePhone.Text Then
                            myHistory = New History
                            myHistory.LidId = .Id
                            myHistory.TableName = "relaties via web"
                            myHistory.Veld = "b_telefoon"
                            myHistory.WaardeOud = .b_telefoon
                            myHistory.WaardeNieuw = Me.tbTelephoneReg.Text
                            myHistory.MutDate = Now
                            myHistory.MutDoor = Request.UserHostAddress()
                            myHistory.Save()
                        End If
                        .b_telefoon = Me.tbChangePhone.Text

                        If .b_mobiel <> Me.tbChangeMobile.Text Then
                            myHistory = New History
                            myHistory.LidId = .Id
                            myHistory.TableName = "relaties via web"
                            myHistory.Veld = "b_mobiel"
                            myHistory.WaardeOud = .b_mobiel
                            myHistory.WaardeNieuw = Me.tbMobileReg.Text
                            myHistory.MutDate = Now
                            myHistory.MutDoor = Request.UserHostAddress()
                            myHistory.Save()
                        End If
                        .b_mobiel = Me.tbChangeMobile.Text
                        .b_email = Me.tbChangeEmail.Text
                        .Save()
                    End With

                    'BMO:16-11-2020: tbv ANPV ("TA") bevestigd op true zetten. 
                    'zodat er geen bevestiging wordt verrzonden\gevraagd, maar direct naar reservering
                    If lid.lidnr.ToUpper.StartsWith("TA") Then
                        lid.bevestigd = True
                        lid.Save()
                    End If

                'If lid.bevestigd = False Then
                '        Dim bevestigd As New Activatie()
                '        With bevestigd
                '            .IPADDRESS = Request.UserHostAddress()
                '            .Lidnr = Me.tbLidNr.Text
                '            .DateSend = Now
                '            .DateConfirmd = Data.SqlTypes.SqlDateTime.MinValue
                '            .Type = "emailreset"
                '            .SearchId = lid.Id
                '            .Save()
                '        End With

                '        Dim oEmail As New Email
                '        oEmail.Address = lid.b_email
                '        oEmail.Name = lid.FullName

                '        Dim oMailer As New Mailer
                '        oMailer.MailSubject = "VBM notificatie:"
                '        Dim Body As String = oMailer.BodyTemplate("emailreset")
                '        Body = Body.Replace("xACHTERNAAM", lid.achternaam)
                '        Body = Body.Replace("xURL", _utils.CurrentSite)
                '        Body = Body.Replace("xGUID", bevestigd.ActivatieGUID.ToString)
                '        Body = Body.Replace("xLIDNR", lid.lidnr)
                '        Body = Body.Replace("xLIDBOEKING", lid.Boeking_Message.Replace(vbCrLf, "<br/>"))

                '        oMailer.MailBody = Body
                '        oMailer.SendEmbeddedImages(oEmail)

                '        Response.Redirect("confirm.aspx?activation=yes")
                '    Else
                '    'Response.Redirect("Reservation.aspx")
                'FillFields()
                MultiView1.SetActiveView(VolmachtView)
                'End If

            End If
            'End If


        Catch ex As Exception
            MultiView1.SetActiveView(ChangeMailView)
            Me.lblError.Text = ex.Message

        End Try
    End Sub
    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Try
            If String.IsNullOrEmpty(Me.tbWachtwoord.Text) Then
                Throw New Exception("Geen wachtwoord opgegeven")
            End If

            If String.IsNullOrEmpty(Me.tbTelephoneReg.Text) AndAlso String.IsNullOrEmpty(Me.tbMobileReg.Text) Then
                Throw New Exception("Geef minstens 1 telefoonnummer op!")
            End If

            _lidnr = Me.tbLidNr.Text
            With lid
                Dim myHistory As New History
                If .b_email <> Me.tbEmail.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "b_email"
                    myHistory.WaardeOud = .b_email
                    myHistory.WaardeNieuw = Me.tbEmail.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .b_email = Me.tbEmail.Text

                If .b_telefoon <> Me.tbTelephoneReg.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "b_telefoon"
                    myHistory.WaardeOud = .b_telefoon
                    myHistory.WaardeNieuw = Me.tbTelephoneReg.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .b_telefoon = Me.tbTelephoneReg.Text

                If .b_mobiel <> Me.tbMobileReg.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "b_mobiel"
                    myHistory.WaardeOud = .b_mobiel
                    myHistory.WaardeNieuw = Me.tbMobileReg.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .b_mobiel = Me.tbMobileReg.Text

                If .wachtwoord <> Me.tbWachtwoord.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "wachtwoord"
                    myHistory.WaardeOud = .wachtwoord
                    myHistory.WaardeNieuw = Me.tbWachtwoord.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .wachtwoord = Me.tbWachtwoord.Text

                .Save()
            End With

            Dim bevestigd As New Activatie()
            With bevestigd
                .IPADDRESS = Request.UserHostAddress()
                .Lidnr = Me.tbLidNr.Text
                .DateSend = Now
                .DateConfirmd = Data.SqlTypes.SqlDateTime.MinValue
                .Type = "activatieid"
                .SearchId = lid.Id
                .Save()
            End With

            Dim oEmail As New Email
            oEmail.Address = lid.b_email
            oEmail.Name = lid.FullName

            Dim oMailer As New Mailer
            oMailer.MailSubject = "VBM notificatie:"
            Dim Body As String = oMailer.BodyTemplate("login")
            Body = Body.Replace("xACHTERNAAM", lid.achternaam)
            Body = Body.Replace("xURL", _utils.CurrentSite)
            Body = Body.Replace("xGUID", bevestigd.ActivatieGUID.ToString)
            Body = Body.Replace("xLIDNR", lid.lidnr)
            Body = Body.Replace("xLIDBOEKING", lid.Boeking_Message.Replace(vbCrLf, "<br/>"))

            oMailer.MailBody = Body
            oMailer.SendEmbeddedImages(oEmail)

            Response.Redirect("confirm.aspx?activation=yes")

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try

    End Sub
    Protected Sub FillFields()
        Try

            _lidnr = Me.tbLidNr.Text
            Page.Title = "Lidmaatschap NAW"

            If String.IsNullOrEmpty(lid.lidnr) Then
                Me.lblError.Text = "Inloggen mislukt!"

            Else
                Me.lblError.Text = ""
                Me.LblLidNr.Text = lid.lidnr
                Me.lblName.Text = lid.FullName
                Me.lblEmail.Text = lid.b_email
                Me.lblWachtwoord.Text = "************" '_Lid.wachtwoord
                Me.lblConfirmd.Text = lid.bevestigd
                Me.lblDateOfBirth.Text = lid.geboortedatum '.ToLongDateString

                MultiView1.SetActiveView(LoginResult)
            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnRegisterA_Click(sender As Object, e As EventArgs) Handles btnRegisterA.Click
        Try
            If String.IsNullOrEmpty(Me.tbTelephoneRegTA.Text) AndAlso String.IsNullOrEmpty(Me.tbMobileRegTA.Text) Then
                Throw New Exception("Geef minstens 1 telefoonnummer op!")
            End If

            _lidnr = Me.tbLidNr.Text
            With lid
                Dim myHistory As New History
                If .achternaam <> Me.tbEmailTA.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "achternaam"
                    myHistory.WaardeOud = .achternaam
                    myHistory.WaardeNieuw = Me.tbNameRegTA.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .achternaam = Me.tbNameRegTA.Text

                If .init <> Me.tbInitTA.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "initalen"
                    myHistory.WaardeOud = .init
                    myHistory.WaardeNieuw = Me.tbInitTA.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .init = Me.tbInitTA.Text

                If .b_email <> Me.tbEmailTA.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "b_email"
                    myHistory.WaardeOud = .b_email
                    myHistory.WaardeNieuw = Me.tbEmailTA.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .b_email = Me.tbEmailTA.Text

                If .b_telefoon <> Me.tbTelephoneRegTA.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "b_telefoon"
                    myHistory.WaardeOud = .b_telefoon
                    myHistory.WaardeNieuw = Me.tbTelephoneRegTA.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .b_telefoon = Me.tbTelephoneRegTA.Text

                If .b_mobiel <> Me.tbMobileRegTA.Text Then
                    myHistory = New History
                    myHistory.LidId = .Id
                    myHistory.TableName = "relaties via web"
                    myHistory.Veld = "b_mobiel"
                    myHistory.WaardeOud = .b_mobiel
                    myHistory.WaardeNieuw = Me.tbMobileRegTA.Text
                    myHistory.MutDate = Now
                    myHistory.MutDoor = Request.UserHostAddress()
                    myHistory.Save()
                End If
                .b_mobiel = Me.tbMobileRegTA.Text
                .Save()
            End With

            Response.Redirect("Reservation.aspx")
            FillFields()

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
End Class
