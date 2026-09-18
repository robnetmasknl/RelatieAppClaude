Imports BusinessObjects
Imports System
Imports System.Activities
Imports System.Data

Partial Class Reservation
    Inherits System.Web.UI.Page
    Private _utils As New Utilities
    Private _blokid As Integer = 0
    Private _lidnr As String = "0"
    Private _lid As WebLid
    Private BeschikbareBlokken As List(Of Blok)

    Public ReadOnly Property lid() As WebLid
        Get
            If _lid Is Nothing Then
                If _lidnr Is Nothing Then Throw New Exception("Er is geen lidmaatschapnummer bekend. Meld u eerst aan!")
                _lid = New WebLid(_lidnr, WebLid.Via.LIDNR)

                If _lid.Id = 0 Then
                    Throw New Exception("Het lidmaatschapnummer " & _lidnr & " is niet gevonden.")
                End If
            End If

            Return _lid
        End Get
    End Property
    Private _LocatiesList As List(Of Locaties)
    Public ReadOnly Property LocatiesList() As List(Of Locaties)
        Get
            If _LocatiesList Is Nothing Then
                _LocatiesList = New List(Of Locaties)
                Dim _Locatie As New Locaties
                Dim ohelper As New Helper
                _Locatie.Id = 0
                _Locatie.Locatie = "Selecteer.."
                _LocatiesList.Add(_Locatie)
                Dim sql As String = "SELECT * FROM locaties WHERE [Cancel] = 'False' AND Offline = 0 ORDER BY Locatie"
                _LocatiesList.AddRange(ohelper.MapDataTableToList(Of Locaties)(_Locatie.GetList(sql)))

            End If
            Return _LocatiesList
        End Get
    End Property
    Private _VolgendeBoeking As Boeking
    Public Property VolgendeBoeking() As Boeking
        Get

            Return _VolgendeBoeking
        End Get
        Set(ByVal value As Boeking)
            _VolgendeBoeking = value
        End Set
    End Property
    Private _HuidigBlok As Blok
    Public Property HuidigBlok() As Blok
        Get
            If _HuidigBlok Is Nothing Then
                _HuidigBlok = New Blok(_blokid, Blok.Via.ID)
            End If

            Return _HuidigBlok
        End Get
        Set(ByVal value As Blok)
            _HuidigBlok = value
        End Set
    End Property

    Private _BoekingTable As DataTable
    Public ReadOnly Property BoekingTable() As DataTable
        Get
            If _BoekingTable Is Nothing Then
                _BoekingTable = New DataTable
                _BoekingTable.TableName = "boekingen"
                '_BoekingTable.Columns.Add("locatie", Type.GetType("System.String"))
                '_BoekingTable.Columns.Add("datum", Type.GetType("System.DateTime"))
                _BoekingTable.Columns.Add("adviseur", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("tijdstip", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("lidnr", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("naam", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("telefoonnummer", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("mobiel", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("relatieId", Type.GetType("System.String"))

            End If
            Return _BoekingTable
        End Get
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            _lidnr = Session("lidnr")
            If lid.wachtwoord <> Session("onthouden") Then
                Me.lblError.Text = "Fout wachtwoord!"
                Response.End()
            Else
                If Not IsPostBack Then


                    If lid.b_belastingadviseur Then
                        lbWelcome.Text = "Welkom " & lid.FullName
                        ddlLocations_adviseurs.Visible = True
                        MultiView1.SetActiveView(ReservationView)
                        ddlLocations_adviseurs.DataSource = LocatiesList
                        ddlLocations_adviseurs.DataValueField = "Id"
                        ddlLocations_adviseurs.DataTextField = "Locatie"
                        ddlLocations_adviseurs.DataBind()
                        MultiView1.SetActiveView(BlokViewAdviseur_new)
                    Else

                        If Not String.IsNullOrEmpty(Request.QueryString("blokid")) Then
                            _blokid = Request.QueryString("blokid")
                            If lid.CurrentBoeking.Found Then
                                lblError.Text = "heeft al een boeking"
                            End If


                            VolgendeBoeking = HuidigBlok.EerstVolgendeBoeking
                            Me.hiddenBlokid.Value = _blokid
                            Me.hiddenVolgendeBoekingid.Value = VolgendeBoeking.Id

                            'If lid.b_belastingadviseur Then
                            '    lblError.Text = "Joepie ik ben advi-zeur!"

                            '    Me.lblLidnr_adv.Text = _lidnr
                            '    Me.lbllocatie_adv.Text = HuidigBlok.LocatieNaam
                            '    Me.lblTijdstip_adv.Text = HuidigBlok.VolgendeTijdstip
                            '    'Me.lblAdviseur.Text = HuidigBlok.AdviseurNaam
                            '    'Me.lblError.Text = ""

                            '    'BoekingLijst = New BoekingLijst(_blokid)
                            '    Dim _BoekingLijst As New BoekingLijst(_blokid)
                            '    If _BoekingLijst.ByBlok.Count > 0 Then
                            '        Me.grdvBoekingen_adv.DataSource = _BoekingLijst.ByBlok
                            '        Me.grdvBoekingen_adv.DataBind()
                            '    Else
                            '        Me.grdvBlokken.DataSource = _BoekingLijst.ByBlok
                            '        Me.grdvBlokken.DataBind()
                            '    End If

                            '    MultiView1.SetActiveView(BlokViewAdviseur)
                            'Else


                            VolgendeBoeking = HuidigBlok.EerstVolgendeBoeking
                            Me.hiddenBlokid.Value = _blokid
                            Me.hiddenVolgendeBoekingid.Value = VolgendeBoeking.Id
                            Me.lblLidnr.Text = _lidnr
                            Me.lbllocatie.Text = HuidigBlok.LocatieNaam
                            Me.lblTijdstip.Text = HuidigBlok.VolgendeTijdstip
                            'Me.lblAdviseur.Text = HuidigBlok.AdviseurNaam
                            Me.lblError.Text = ""
                            Me.btnConfrim.BackColor = Drawing.Color.LightBlue


                            'BoekingLijst = New BoekingLijst(_blokid)
                            Dim _BoekingLijst As New BoekingLijst(_blokid)
                            If _BoekingLijst.ByBlok.Count > 0 Then
                                Me.grdvBoekingen.DataSource = _BoekingLijst.ByBlok
                                Me.grdvBoekingen.DataBind()
                            Else
                                Me.grdvBlokken.DataSource = _BoekingLijst.ByBlok
                                Me.grdvBlokken.DataBind()
                            End If

                            MultiView1.SetActiveView(BlokView)
                            'End If

                        ElseIf Not String.IsNullOrEmpty(Request.QueryString("boekingid")) Then

                            If lid.CurrentBoeking.Found Then
                                lblError.Text = lid.Boeking_Message.Replace(vbCrLf, "<BR/>")
                            End If

                            VolgendeBoeking = New Boeking(Request.QueryString("boekingid"), Boeking.Via.ID)

                            If Not VolgendeBoeking.relatieId = 0 Then
                                lblError.Text = "De door u geselcteerde tijdstip is al gereserveerd!"

                                Response.Redirect("Reservation.aspx?BlokId=" & VolgendeBoeking.blokId)
                            End If

                            _blokid = VolgendeBoeking.blokId
                            Me.hiddenBlokid.Value = VolgendeBoeking.blokId
                            Me.hiddenVolgendeBoekingid.Value = VolgendeBoeking.Id
                            Me.lblLidnr.Text = _lidnr
                            Me.lbllocatie.Text = HuidigBlok.LocatieNaam
                            Me.lblTijdstip.Text = VolgendeBoeking.tijdstip
                            'Me.lblAdviseur.Text = HuidigBlok.AdviseurNaam
                            Me.lblError.Text = ""


                            Dim _BoekingLijst As New BoekingLijst(_blokid)
                            If _BoekingLijst.ByBlok.Count > 0 Then
                                Me.grdvBoekingen.DataSource = _BoekingLijst.ByBlok
                                Me.grdvBoekingen.DataBind()
                            Else
                                Me.grdvBlokken.DataSource = _BoekingLijst.ByBlok
                                Me.grdvBlokken.DataBind()
                            End If
                            MultiView1.SetActiveView(BlokView)
                        Else
                            If lid.CurrentBoeking.Found Then
                                lblError.Text = lid.Boeking_Message.Replace(vbCrLf, "<BR/>")
                                ddlLocations.Visible = False
                            Else


                                'Me.lblError.Text = Session("volmacht")
                                If Session("volmacht") = "vmja" Then
                                    ddlLocations.Visible = False
                                    MultiView1.SetActiveView(VolmachtView)
                                ElseIf Session("volmacht") = "vmnee" Then
                                    ddlLocations.Visible = True
                                    MultiView1.SetActiveView(ReservationView)
                                    ddlLocations.DataSource = LocatiesList
                                    ddlLocations.DataValueField = "Id"
                                    ddlLocations.DataTextField = "Locatie"
                                    ddlLocations.DataBind()
                                End If

                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub ddlLocations_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLocations.SelectedIndexChanged
        Try
            If Me.ddlLocations.SelectedValue > 0 Then
                Dim _Blokken As New BlokkenLijst
                BeschikbareBlokken = New List(Of Blok)
                _Blokken._LocatieId = Me.ddlLocations.SelectedValue

                If _Blokken.ByLocatie.Count > 0 Then
                    For Each Blok In _Blokken.ByLocatie
                        If Not Blok.Vol Then
                            If Blok.datum > Today Then
                                BeschikbareBlokken.Add(Blok)
                            End If

                        End If
                    Next
                    Me.grdvBlokken.DataSource = BeschikbareBlokken
                    Me.grdvBlokken.DataBind()
                    Me.lblError.Text = ""
                Else
                    Me.grdvBlokken.DataSource = Nothing
                    Me.grdvBlokken.DataBind()
                    Me.lblError.Text = "Geen gegevens gevonden voor uw locatie!"
                End If
            Else
                Me.grdvBlokken.DataSource = Nothing
                Me.grdvBlokken.DataBind()
                Me.lblError.Text = ""
            End If


        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
    Protected Sub ddlLocations_adviseurs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLocations_adviseurs.SelectedIndexChanged
        Try
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
            'Me.lblError.Text = ""
            lblSelected.Text = ""

            If Me.ddlLocations_adviseurs.SelectedValue > 0 Then
                Dim _Blokken As New BlokkenLijst
                BeschikbareBlokken = New List(Of Blok)
                BeschikbareBlokken = _Blokken.DatumLijstByLocatie(Me.ddlLocations_adviseurs.SelectedValue)

                If BeschikbareBlokken.Count > 0 Then
                    Me.lblError.Text = BeschikbareBlokken.Count & " data gevonden voor uw locatie!" ' <br> Selecteer de gewenste datum in de lijst hieronder."
                    ddlData.DataSource = BeschikbareBlokken
                    ddlData.DataValueField = "datum"
                    ddlData.DataTextField = "datum"
                    ddlData.DataBind()
                    ddlData_SelectedIndexChanged(Me, New EventArgs)
                End If
            Else
                Me.ddlData.DataSource = Nothing
                Me.ddlData.DataBind()
                Me.lblError.Text = ""
            End If



        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
    Protected Sub ddlData_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlData.SelectedIndexChanged
        Try
            If Not String.IsNullOrEmpty(ddlData.SelectedValue) Then
                Me.lblError.Text = ddlData.SelectedValue
                Dim oDatumLijst As New BlokkenLijst
                Dim MyDatumLijst As List(Of Blok) = Nothing
                MyDatumLijst = oDatumLijst.GetBlokByLocationDate(ddlData.SelectedValue, ddlLocations_adviseurs.SelectedValue)
                Me.lblError.Text = ""

                Dim newRow As DataRow
                newRow = BoekingTable.NewRow

                For Each CurrentBlok As Blok In MyDatumLijst
                    If CurrentBlok.AantalBoekingen > 0 Then
                        For Each CurrentBoeking As Boeking In CurrentBlok.Boekingen
                            If Not CurrentBoeking.relatieId = 0 Then
                                Dim lid As New WebLid(CurrentBoeking.relatieId, WebLid.Via.ID)
                                newRow = BoekingTable.NewRow
                                'newRow.Item("locatie") = LocatieNaam
                                'newRow.Item("datum") = CurrentBoeking.
                                newRow.Item("adviseur") = CurrentBlok.AdviseurNaam
                                newRow.Item("tijdstip") = Format(CurrentBoeking.tijdstip, "HH:mm")
                                newRow.Item("lidnr") = lid.lidnr
                                newRow.Item("naam") = lid.FullName
                                newRow.Item("telefoonnummer") = lid.b_telefoon
                                newRow.Item("mobiel") = lid.b_mobiel
                                newRow.Item("relatieId") = lid.Id
                                BoekingTable.Rows.Add(newRow)
                            End If
                        Next
                    End If
                Next

                Me.GridView1.DataSource = BoekingTable
                Me.GridView1.DataBind()
                Dim dd As Date = ddlData.SelectedValue
                lblSelected.Text = "Boekingoverzicht van locatie " & MyDatumLijst.Item(0).LocatieNaam & " op " & dd.ToShortDateString
            Else

                Me.lblError.Text = "??"
            End If


        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
    Protected Sub btnConfrim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfrim.Click
        Try


            Dim NewBoeking As New Boeking(hiddenVolgendeBoekingid.Value, Boeking.Via.ID)
            If Not NewBoeking.lidnr = "0" Then
                Throw New Exception("De door u geselcteerde tijdstip is al gereserveerd!")
            End If

            With NewBoeking
                '.lidnr = lblLidnr.Text
                .relatieId = lid.Id
                '.lidnr = lid.Id
                .voorlopig = True
                .Save()
            End With
            Dim NewActivation As New Activatie

            With NewActivation
                .IPADDRESS = Request.UserHostAddress()
                .Lidnr = lblLidnr.Text
                'TODO:BM tbv omzetten nr naar id
                ' .Lidnr = lid.Id
                .DateSend = Now
                .DateConfirmd = Data.SqlTypes.SqlDateTime.MinValue
                .Type = "reservationid"
                .SearchId = NewBoeking.Id
                .Save()
            End With

            Dim oEmail As New Email
            oEmail.Address = lid.b_email
            oEmail.Name = lid.FullName

            Dim oMailer As New Mailer
            Dim Body As String = String.Empty

            'BMO:19-11-2020: indien van ANPV dan andere template
            If lid.lidnr.ToUpper.StartsWith("TA") Then
                oMailer.MailSubject = "ANPV Reservering belastinghulp:"
                Body = oMailer.BodyTemplate("reserveringANPV")
            Else
                oMailer.MailSubject = "VBM reservering:"
                Body = oMailer.BodyTemplate("reservering")

            End If

            Dim LastName As String = lid.achternaam
            If Not String.IsNullOrEmpty(lid.tussenvoegsel) Then LastName = lid.tussenvoegsel & " " & LastName

            Body = Body.Replace("xACHTERNAAM", LastName)
            Body = Body.Replace("xURL", _utils.CurrentSite)
            Body = Body.Replace("xGUID", NewActivation.ActivatieGUID.ToString)
            Body = Body.Replace("xLIDNR", lid.lidnr)
            Body = Body.Replace("xLIDBOEKING", lid.Boeking_Message.Replace(vbCrLf, "<br/>"))

            oMailer.MailBody = Body
            oMailer.SendEmbeddedImages(oEmail)

            'BMO:19-11-2020: indien van ANPV dan kopie naar leden admin
            Dim oEmailANPV As New Email
            oEmailANPV.Address = "ledenadministratie@anpv.nl"
            oEmailANPV.Name = "ledenadministratie"
            If lid.lidnr.ToUpper.StartsWith("TA") Then oMailer.SendEmbeddedImages(oEmailANPV)

            'wacht niet meer op de bevestiging via mail maar redirect naar de bevestingspagina.
            Response.Redirect("confirm.aspx?activatieid=" & NewActivation.ActivatieGUID.ToString)
            Response.End()

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub


    Protected Sub btnVMAkkoord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVMAkkoord.Click
        Try

            'Dim boeking As Boeking = boeking.GetBoekingByVM
            '_blokid = 1515
            '_blokid = ConfigurationManager.AppSettings("volmachtblokid")

            VolgendeBoeking = New Boeking
            VolgendeBoeking.GetBoekingByVM()

            'hiddenBlokid.Value = _blokid
            hiddenVolgendeBoekingid.Value = VolgendeBoeking.Id

            Dim NewBoeking As New Boeking(hiddenVolgendeBoekingid.Value, Boeking.Via.ID)


            If Not NewBoeking.lidnr = "0" Then
                Throw New Exception("De door u geselcteerde tijdstip is al gereserveerd!")
            End If

            With NewBoeking
                .relatieId = lid.Id
                .voorlopig = True
                .Save()
            End With

            Dim NewActivation As New Activatie
            With NewActivation
                .IPADDRESS = Request.UserHostAddress()
                .Lidnr = _lidnr
                .DateSend = Now
                .DateConfirmd = Data.SqlTypes.SqlDateTime.MinValue
                .Type = "volmachtid"
                .SearchId = NewBoeking.Id
                .Save()
            End With

            Dim oEmail As New Email
            oEmail.Address = lid.b_email
            oEmail.Name = lid.FullName

            Dim oMailer As New Mailer
            Dim Body As String = String.Empty

            Try

                Dim weekNo As Integer = Utilities.GetWeekNumber(NewBoeking.Blok.datum)
                oMailer.MailSubject = "VBM aangifte:"
                Body = oMailer.BodyTemplate("reserveringVolmacht")


                Dim LastName As String = lid.achternaam
                If Not String.IsNullOrEmpty(lid.tussenvoegsel) Then LastName = lid.tussenvoegsel & " " & LastName

                Body = Body.Replace("xACHTERNAAM", LastName)
                Body = Body.Replace("xURL", _utils.CurrentSite)
                Body = Body.Replace("xGUID", NewActivation.ActivatieGUID.ToString)
                Body = Body.Replace("xWEEK", weekNo)
                'Body = Body.Replace("xLIDBOEKING", lid.Boeking_Message.Replace(vbCrLf, "<br/>"))
                oMailer.MailBody = Body
                oMailer.SendEmbeddedImages(oEmail)
            Catch ex As Exception

            End Try


            'wacht niet meer op de bevestiging via mail maar redirect naar de bevestingspagina.
            Response.Redirect("confirm.aspx?activatieid=" & NewActivation.ActivatieGUID.ToString)
            Response.End()

        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub grdvBoekingen_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvBoekingen.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                If HuidigBlok.vultype = 3 Then
                    'dan moet het de mogelijkheid krijgen om rondom te kunnen selecteren.
                    Dim tmpboeking As New Boeking
                    tmpboeking = HuidigBlok.Boekingen(e.Row.RowIndex)
                    If tmpboeking.lidnr = "0" Then
                        Dim hl As HyperLink = CType(e.Row.Cells(0).FindControl("hlBlokId"), HyperLink)
                        hl.NavigateUrl = "~/Reservation.aspx?boekingid=" & tmpboeking.Id
                        hl.Text = "selecteer"
                        hl.ToolTip = "selecteer eerst het juiste tijdstip en bevestig deze door de knop ""Reserveer"""
                    End If
                Else
                    grdvBoekingen.Visible = False
                    Dim hl As HyperLink = CType(e.Row.Cells(0).FindControl("hlBlokId"), HyperLink)
                    hl.Visible = False
                End If
            End If
        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
    'Protected Sub grdvBoekingen_adv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvBoekingen_adv.RowDataBound
    '    Try
    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            If HuidigBlok.vultype = 3 Then
    '                'dan moet het de mogelijkheid krijgen om rondom te kunnen selecteren.
    '                Dim tmpboeking As New Boeking
    '                tmpboeking = HuidigBlok.Boekingen(e.Row.RowIndex)
    '                If tmpboeking.lidnr = "0" Then
    '                    Dim hl As HyperLink = CType(e.Row.Cells(0).FindControl("hlBlokId_adv"), HyperLink)
    '                    hl.NavigateUrl = "~/Reservation.aspx?boekingid=" & tmpboeking.Id
    '                    hl.Text = "selecteer"
    '                    hl.ToolTip = "selecteer eerst het juiste tijdstip en bevestig deze door de knop ""bevestig"""
    '                End If
    '            Else
    '                grdvBoekingen_adv.Visible = False
    '                Dim hl As HyperLink = CType(e.Row.Cells(0).FindControl("hlBlokId_adv"), HyperLink)
    '                hl.Visible = False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Me.lblError.Text = ex.Message
    '    End Try
    'End Sub
    Protected Sub grdvBlokken_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvBlokken.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                'Dim _Blokken As New BlokkenLijst
                'Dim BeschikbareBlokken As New List(Of Blok)
                '_Blokken._LocatieId = Me.ddlLocations.SelectedValue
                'For Each Blok In _Blokken.ByLocatie
                '    If Not Blok.Vol Then
                '        BeschikbareBlokken.Add(Blok)
                '    End If
                'Next
                Dim tmpBlok As New Blok
                tmpBlok = BeschikbareBlokken(e.Row.RowIndex)

                Dim hl As HyperLink = CType(e.Row.Cells(0).FindControl("hlDateId"), HyperLink)
                hl.NavigateUrl = "~/Reservation.aspx?BlokId=" & tmpBlok.Id
                hl.Text = tmpBlok.datum.ToLongDateString
                hl.ToolTip = "selecteer eerst het juiste datum."

            End If
        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub
End Class
