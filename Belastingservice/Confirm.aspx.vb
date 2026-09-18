Imports System.Globalization
Imports BusinessObjects

Partial Class Confirm
    Inherits System.Web.UI.Page

    Private bevestigd As Activatie
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        MultiView1.SetActiveView(ConfirmView)
        Page.Title = "Bevestiging"
        Try
            If Not IsPostBack Then
                If Not String.IsNullOrEmpty(Request.QueryString("activation")) Then
                    Exit Sub
                ElseIf Not String.IsNullOrEmpty(Request.QueryString("reservation")) Then
                    Exit Sub
                ElseIf Not String.IsNullOrEmpty(Request.QueryString("reset")) Then
                    Exit Sub
                ElseIf Not String.IsNullOrEmpty(Request.QueryString("resetemail")) Then
                    Exit Sub
                End If

                Dim activatieid As String = Request.QueryString("activatieid")
                If Not String.IsNullOrEmpty(activatieid) Then
                    bevestigd = New Activatie(activatieid)
                    If Not bevestigd.Found Then
                        lblError.Text = "Sorry, Uw bevestigings id kon niet worden gevonden." & vbCrLf &
                                        "U kunt contact opnemen met tel. 070-3155111 zodat zij u verder kunnen helpen"
                        Exit Sub
                    End If

                    Select Case bevestigd.Type.ToLower
                        Case "activatieid"
                            ProcessActivation()
                        Case "reservationid"
                            ProcessReservation()
                        Case "passwordreset"
                            ProcessPasswordReset()
                        Case "emailreset"
                            ProcessEmailReset()
                        Case "volmachtid"
                            ProcessVolmacht()
                    End Select

                End If


            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
    Protected Sub ProcessActivation()
        Try
            Dim DateSend As DateTime = bevestigd.DateSend
            Dim DateConfirmd As DateTime = Now
            Dim Time2Confirm As TimeSpan = DateConfirmd.Subtract(DateSend)
            MultiView1.SetActiveView(ProcessedActivationView)

            If Time2Confirm.TotalDays <= 8 Then
                bevestigd.DateConfirmd = Now
                bevestigd.IPADDRESS = Request.UserHostAddress()

                Dim ConfirmLid As New WebLid(bevestigd.Lidnr, WebLid.Via.LIDNR)
                ConfirmLid.bevestigd = True
                ConfirmLid.Save()
                bevestigd.Save()
                ' Response.Write(bevestigd.IPADDRESS)

                lblPA_Message.Text = ConfirmLid.FullName & " bedankt voor uw bevestiging. " & vbCrLf &
                " u kunt nu <a href=""login.aspx?lidnr=" & ConfirmLid.lidnr & """>HIER</a>  inloggen met met lidnummer " &
                ConfirmLid.lidnr & " en het door u opgegeven wachtwoord."

            Else
                lblError.Text = "Helaas, te laat."
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub ProcessReservation()
        Try
            Dim DateSend As DateTime = bevestigd.DateSend
            Dim DateConfirmd As DateTime = Now
            Dim Time2Confirm As TimeSpan = DateConfirmd.Subtract(DateSend)

            MultiView1.SetActiveView(ProcessedReservationView)
            If Time2Confirm.TotalDays <= 2 Then
                bevestigd.DateConfirmd = Now
                bevestigd.IPADDRESS = Request.UserHostAddress()
                bevestigd.Save()
                'zoek resevering en bevestig
                Dim newBoeking As New Boeking(bevestigd.SearchId, Boeking.Via.ID)
                If newBoeking.Found Then
                    newBoeking.voorlopig = False
                    newBoeking.Save()
                    Dim MyLocatie As New Locaties(newBoeking.Blok.locatieid)

                    Dim LocationAdres123 As String = ""
                    Dim LocationAdres As String = ""
                    Dim LocationNew As String = ""

                    If MyLocatie.Found Then

                        With MyLocatie
                            If .LocatieNieuw Then LocationNew &= "<BR/><font color='red'> <b>LET OP: NIEUWE LOCATIE, </b></font>" & vbCrLf
                            If Not String.IsNullOrEmpty(.Address1) Then LocationAdres123 &= .Address1 & ", "
                            If Not String.IsNullOrEmpty(.Address2) Then LocationAdres123 &= .Address2 & ", "
                            If Not String.IsNullOrEmpty(.Address3) Then LocationAdres123 &= .Address3 & ", "
                            If Not String.IsNullOrEmpty(.Street) Then LocationAdres &= .Street & ", "
                            If Not String.IsNullOrEmpty(.Postcode) Then LocationAdres &= .Postcode & ", "
                            If Not String.IsNullOrEmpty(.Plaats) Then LocationAdres &= .Plaats & ", "
                        End With

                        If LocationAdres123.EndsWith(", ") Then LocationAdres123 = LocationAdres123.Remove(LocationAdres123.LastIndexOf(", "), 2)
                        If LocationAdres.EndsWith(", ") Then LocationAdres = LocationAdres.Remove(LocationAdres.LastIndexOf(", "), 2)


                        If Not String.IsNullOrEmpty(LocationAdres123) Then LocationAdres123 = "<BR/> Adres: " & LocationAdres123 & vbCrLf
                        If Not String.IsNullOrEmpty(LocationAdres) Then LocationAdres = "<BR/> Adres: " & LocationAdres & vbCrLf
                    End If

                    lblPR_Message.Text = newBoeking.LidNaam & " bedankt voor uw reservering. <BR/>" & vbCrLf &
                                    "<BR/> Uw heeft het volgende gereserveerd:<BR/>" & LocationNew & vbCrLf &
                                    "<BR/> locatie: " & newBoeking.Blok.LocatieNaam & vbCrLf &
                                    LocationAdres123 & LocationAdres &
                                    "<BR/> datum: " & newBoeking.tijdstip.ToLongDateString & vbCrLf &
                                    "<BR/> Tijdstip: " & newBoeking.tijdstip.ToShortTimeString
                Else
                    Me.lblError.Text = "Sorry, Uw reservering kan niet worden gevonden." & vbCrLf &
                                                            "<BR/>U kunt contact opnemen met ??? zodat zij u verder kunnen helpen"
                End If

            Else
                lblError.Text = "Helaas, te laat."
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub ProcessPasswordReset()
        Try
            Dim DateSend As DateTime = bevestigd.DateSend
            Dim DateConfirmd As DateTime = Now
            Dim Time2Confirm As TimeSpan = DateConfirmd.Subtract(DateSend)
            MultiView1.SetActiveView(ProcessedPasswordView)

            If Time2Confirm.TotalDays <= 8 Then
                bevestigd.DateConfirmd = Now
                bevestigd.IPADDRESS = Request.UserHostAddress()

                Dim ConfirmLid As New WebLid(bevestigd.Lidnr, WebLid.Via.LIDNR)
                ConfirmLid.wachtwoord = ""
                ConfirmLid.bevestigd = True
                ConfirmLid.Save()
                bevestigd.Save()
                ' Response.Write(bevestigd.IPADDRESS)

                lblPP_Message.Text = ConfirmLid.FullName & " U kunt nu <a href=""login.aspx?lidnr=" & ConfirmLid.lidnr & """> HIER </a> uw wachtwoord opnieuw opgeven. " & vbCrLf &
                                    "<BR/> ******************************************************"

            Else
                lblError.Text = "Helaas, te laat."
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub ProcessEmailReset()
        Try
            Dim DateSend As DateTime = bevestigd.DateSend
            Dim DateConfirmd As DateTime = Now
            Dim Time2Confirm As TimeSpan = DateConfirmd.Subtract(DateSend)
            MultiView1.SetActiveView(ProcessedEmailView)

            If Time2Confirm.TotalDays <= 8 Then
                bevestigd.DateConfirmd = Now
                bevestigd.IPADDRESS = Request.UserHostAddress()

                Dim ConfirmLid As New WebLid(bevestigd.Lidnr, WebLid.Via.LIDNR)
                ConfirmLid.bevestigd = True
                ConfirmLid.Save()
                bevestigd.Save()
                ' Response.Write(bevestigd.IPADDRESS)

                lblEmail_Message.Text = ConfirmLid.FullName & " Uw email adres is gewijzigd." & vbCrLf &
                    "<BR/><a href=""login.aspx?lidnr=" & ConfirmLid.lidnr & """> U kunt HIER klikken om in te loggen.</a> " & vbCrLf &
                                    "<BR/> ******************************************************"

            Else
                lblError.Text = "Helaas, U heeft niet binnen 8 dagen gereageerd."
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub ProcessVolmacht()
        Try
            Dim DateSend As DateTime = bevestigd.DateSend
            Dim DateConfirmd As DateTime = Now
            Dim Time2Confirm As TimeSpan = DateConfirmd.Subtract(DateSend)

            MultiView1.SetActiveView(ProcessedVolmachtView)
            If Time2Confirm.TotalDays <= 2 Then
                bevestigd.DateConfirmd = Now
                bevestigd.IPADDRESS = Request.UserHostAddress()
                bevestigd.Save()
                'zoek resevering en bevestig
                Dim newBoeking As New Boeking(bevestigd.SearchId, Boeking.Via.ID)
                If newBoeking.Found Then
                    newBoeking.voorlopig = False
                    newBoeking.Save()
                    Dim MyLocatie As New Locaties(newBoeking.Blok.locatieid)

                    Dim LocationAdres123 As String = ""
                    Dim LocationAdres As String = ""
                    Dim LocationNew As String = ""

                    If MyLocatie.Found Then


                    End If

                    Dim weekNo As Integer = Utilities.GetWeekNumber(newBoeking.Blok.datum)

                    lblVolmacht_Message.Text = newBoeking.LidNaam & ", Bedankt voor uw aanmelding. Er is een bevestigingsmail gestuurd.<BR/>" & vbCrLf &
                         "<BR/> We gaan uw aangifte(n) 2024 oppakken in week " & weekNo & ". <BR/>"

                Else
                    Me.lblError.Text = "Sorry, Uw reservering kan niet worden gevonden." & vbCrLf &
                                    "<BR/>U kunt contact opnemen met ??? zodat zij u verder kunnen helpen"
                End If

            Else
                lblError.Text = "Helaas, te laat."
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
