Imports BusinessObjects
Imports System.Data

Partial Class Declaration
    Inherits System.Web.UI.Page

    Protected _LidId As Int32 = -1
    Private _PeriodId As Integer = -1
    Private _Relatie As Relaties
    Public ReadOnly Property MyRelatie() As Relaties
        Get
            If _Relatie Is Nothing AndAlso _LidId > 0 Then
                _Relatie = New Relaties(_LidId, Relaties.Via.ID)
            End If
            Return _Relatie
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RegisterPostBackControl()
        Page.EnableViewState = True

        VisiblePlaceHolders(Session("PhRecruiters"))
        If Session("PhRecruiters") = "phLoginSucces" Then
            Login()
        End If

        Me.lbError.Text = ""

    End Sub

    Private Sub RegisterPostBackControl()
        ' Dim sm As ScriptManager = CType(Page.Master.FindControl("ScriptManager1"), ScriptManager)
        Dim sm As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        sm.RegisterPostBackControl(btnNextPeriodimg)
        sm.RegisterPostBackControl(btnPrevPeriodimg)
        sm.RegisterPostBackControl(btAddDeclaration)
        sm.RegisterPostBackControl(btCreateCancel)
        sm.RegisterPostBackControl(btCreatePeriode)
        sm.RegisterPostBackControl(btnLogin)
        sm.RegisterPostBackControl(gvDeclarations)

    End Sub

    Protected Sub VisiblePlaceHolders(ByVal ph As String)
        phLogin.Visible = False
        phLoginSucces.Visible = False
        phCreatePeriode.Visible = False
        phSelectedPeriod.Visible = False
        Select Case ph
            Case Is = "phLogin"
                phLogin.Visible = True
                Session("PhRecruiters") = "phLogin"
            Case "phLoginSucces"
                Session("PhRecruiters") = "phLoginSucces"
                phLoginSucces.Visible = True
                btAddDeclaration.Visible = False
                If MonthList.Items.Count = 0 Then
                    GetMyMonthListWeb(MonthList, True)
                    GetMyYearListWeb(YearList, 2, 0, True)
                End If
            Case "phCreatePeriode"
                phCreatePeriode.Visible = True
                Session("PhRecruiters") = "phCreatePeriode"
            Case "phSelectedPeriod"
                phSelectedPeriod.Visible = True
                Session("PhRecruiters") = "phSelectedPeriod"
            Case Else
                VisiblePlaceHolders("phLogin")
        End Select


    End Sub
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Login()

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Protected Sub Login()
        Try
            VisiblePlaceHolders("niets")
            Dim NewIpBlocker As New IpBlocker
            NewIpBlocker = New IpBlocker(Request.UserHostAddress, IpBlocker.Via.IP)
            If NewIpBlocker.ToManyAttemps Then
                With NewIpBlocker
                    .SearchName = Me.tbLidNr.Text
                    .TimeStamp = Now
                    .SearchDOB = "" 'Me.tbPassword.Text
                    .Type = "DeclarationLogin"
                    .Attempts = .Attempts + 1
                    .Save()
                    Me.Label1.Text = "Teveel pogingen vanaf dit IP adres! <br> Probeer het over " & .TimeBetweenFailures & " minuten nog eens!"
                End With
            Else

                Dim myLogindecl As New LoginDecl

                If Not Session("nr4669") Is Nothing AndAlso Not Session("pw4669") Is Nothing Then
                    _LidId = myLogindecl.Login(Session("nr4669"), Session("pw4669"))
                Else
                    _LidId = myLogindecl.Login(Me.tbLidNr.Text, Me.tbPassword.Text)
                    If _LidId > 0 Then
                        Session("nr4669") = Me.tbLidNr.Text
                        Session("pw4669") = Me.tbPassword.Text
                        Session("id4669") = _LidId
                    End If
                End If

                Me.tbhidid.Value = _LidId

                If _LidId > 0 Then
                    VisiblePlaceHolders("phLoginSucces")
                    lbWelcomelogin.Text = "Welkom " & MyRelatie.FullName
                Else
                    With NewIpBlocker
                        .IPADDRESS = Request.UserHostAddress()
                        .SearchName = Me.tbLidNr.Text
                        .TimeStamp = Now
                        .SearchDOB = "" 'Me.tbPassword.Text
                        .Type = "DeclarationLogin"
                        .Attempts = .Attempts + 1
                        .Save()
                    End With

                    VisiblePlaceHolders("phLogin")
                    Label1.Text = "U bent NIET aangemeld. Controleer uw inloggegevens!"
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub FindPeriodeBtn()
        Try
            If Session("id4669") Is Nothing Then
                Login()
            End If

            Dim Mydate As New Date(YearList.SelectedValue, MonthList.SelectedValue, "1")
            Dim CurrentPeriod As New Date(Today.Year, Today.Month, "1")

            If Mydate > CurrentPeriod Then
                lbCalendar.Text = "U kunt geen declaraties invoeren op toekomstige data"
                LoadDeclarations()
            Else
                lbCalendar.Text = ""
                Dim DeclaratiePeriode As New DeclaratiePeriodes(Session("id4669"), MonthList.SelectedValue, YearList.SelectedValue)
                If DeclaratiePeriode.Found Then

                    lbPeriode.Text = "geselecteerde periode: " & DeclaratiePeriode.PeriodName & ". <br/> omschrijving:" & DeclaratiePeriode.Omschrijving
                    If DeclaratiePeriode.Submitted Then
                        lbPeriode.Text &= " is afgesloten. Toevoegen en/of bewerken is niet meer mogelijk."
                        lbPeriode.ForeColor = Drawing.Color.Red
                    Else
                        lbPeriode.ForeColor = Drawing.Color.Black
                    End If
                    VisiblePlaceHolders("phLoginSucces")
                    LoadDeclarations()

                Else
                    VisiblePlaceHolders("phCreatePeriode")
                    lbCreatePeriode.Text = "periode: " & MonthList.Text & "-" & YearList.Text & " niet gevonden. Wilt u de periode aanmaken?"
                End If
            End If

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Private Sub LoadDeclarations()
        Try
            Dim DeclaratiePeriode As DeclaratiePeriodes
            If _PeriodId > 0 Then
                DeclaratiePeriode = New DeclaratiePeriodes(_PeriodId)
            Else
                DeclaratiePeriode = New DeclaratiePeriodes(Session("id4669"), MonthList.SelectedValue, YearList.SelectedValue)
            End If

            tbhidLock.Value = DeclaratiePeriode.Submitted.ToString
            gvDeclarations.DataSource = DeclaratiePeriode.GetDeclarationTable
            gvDeclarations.DataBind()

            If DeclaratiePeriode.Found Then
                If DeclaratiePeriode.Submitted = True Then
                    btAddDeclaration.Visible = False
                Else
                    btAddDeclaration.Visible = True
                End If

                Dim dt As New DataTable
                dt = gvDeclarations.DataSource

                Dim dtTotals As New DataTable
                dtTotals = dt.Clone

                Dim col As New DataColumn
                col.ColumnName = "TotalAmountKm"
                dtTotals.Columns.Add(col)
                col = New DataColumn
                col.ColumnName = "TotalAmountHours"
                dtTotals.Columns.Add(col)
                col = New DataColumn
                col.ColumnName = "PeriodTotalCompensation"
                dtTotals.Columns.Add(col)
                col = New DataColumn
                col.ColumnName = "TotalMeals"
                dtTotals.Columns.Add(col)

                Dim dr As DataRow
                dr = dtTotals.NewRow
                dr.Item("Uren") = DeclaratiePeriode.TotalHours
                dr.Item("Onkosten") = DeclaratiePeriode.TotalExpense
                dr.Item("Kilometers") = DeclaratiePeriode.TotalKm
                ' dr.Item("OnkOV") = DeclaratiePeriode.TotalPublicTransport
                dr.Item("TotalAmountKm") = " € " & DeclaratiePeriode.TotalAmountKm
                dr.Item("TotalAmountHours") = " € " & DeclaratiePeriode.TotalAmountHours
                dr.Item("PeriodTotalCompensation") = " € " & DeclaratiePeriode.PeriodTotalCompensation
                dr.Item("TotalMeals") = " € " & DeclaratiePeriode.TotalMeals

                'Dim dr As DataRow
                'dr = dtTotals.NewRow
                'dr.Item("Uren") = DeclaratiePeriode.TotalHours
                'dr.Item("Onkosten") = DeclaratiePeriode.TotalExpense
                'dr.Item("Kilometers") = DeclaratiePeriode.TotalKm
                'dr.Item("OnkOV") = DeclaratiePeriode.TotalPublicTransport
                dtTotals.Rows.Add(dr)

                gvTotals.DataSource = dtTotals
                gvTotals.DataBind()

            Else
                gvTotals.DataSource = Nothing
                gvTotals.DataBind()
                btAddDeclaration.Visible = False
            End If
            If tbhidLock.Value = "True" Then
                gvDeclarations.Columns(0).Visible = False
                gvDeclarations.Columns(getDeclarationsColumnID("Verwijder")).Visible = False
            Else
                gvDeclarations.Columns(0).Visible = True
                gvDeclarations.Columns(getDeclarationsColumnID("Verwijder")).Visible = True
            End If

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Function getDeclarationsColumnID(ByVal columnName As String) As Integer

        Dim columnID As Integer = 0
        For Each column As DataGridColumn In gvDeclarations.Columns
            If column.HeaderText.ToLower = columnName.ToLower Then
                columnID = gvDeclarations.Columns.IndexOf(column)
                Return columnID
            End If
        Next
        Return columnID
    End Function
  
    Public Sub gvDeclarations_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gvDeclarations.ItemDataBound
        If tbhidLock.Value = "True" Then
            Exit Sub
        Else
            If (e.Item.ItemType = ListItemType.EditItem) Then
                Dim i As Integer
                For i = 1 To e.Item.Controls.Count - 1
                    If (e.Item.Controls(i).Controls(0).GetType().ToString() = "System.Web.UI.WebControls.TextBox") Then
                        Dim tb As TextBox
                        tb = e.Item.Controls(i).Controls(0)
                        If i = 1 Then tb.Visible = False 'ID overslaan

                        If i = 2 And tb.Text = "" Then
                            Dim Mydate As New Date(YearList.SelectedValue, MonthList.SelectedValue, "1")
                            tb.Text = Mydate.ToShortDateString
                            tb.BorderStyle = BorderStyle.Groove
                            tb.Font.Italic = True
                        End If

                        Select Case i
                            Case 2
                                tb.Width = New Unit(100)
                            Case 3 'Omschrijving algemeen
                                tb.MaxLength = 160
                                tb.TextMode = TextBoxMode.MultiLine
                                tb.Width = New Unit(300)
                            Case 7, 9 ' 6= Onkosten Omschrijving en 9 = km Omschrijving
                                tb.MaxLength = 60
                                tb.TextMode = TextBoxMode.SingleLine
                                tb.Width = New Unit(300)
                            Case 6
                                tb.Width = New Unit(60)
                            Case 4, 5, 6, 8
                                tb.Width = New Unit(50)
                        End Select

                        If tb.ReadOnly Then
                            'overslaan
                        Else
                            tb.Text = Server.HtmlDecode(tb.Text)
                            tb.BorderStyle = BorderStyle.Groove
                            tb.Font.Italic = True
                        End If
                    End If
                Next
            End If
        End If
    End Sub
    Public Sub gvDeclarations_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvDeclarations.EditCommand
        Try

            If tbhidLock.Value = "True" Then
                Exit Sub
            Else
                gvDeclarations.EditItemIndex = CInt(e.Item.ItemIndex)
                LoadDeclarations()
            End If

        Catch ex As Exception
            ShowError(ex.Message)
        End Try


    End Sub
    Private Sub gvDeclarations_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvDeclarations.CancelCommand
        gvDeclarations.EditItemIndex = -1
        LoadDeclarations()
    End Sub
    Public Sub gvDeclarations_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvDeclarations.UpdateCommand
        Try
            Dim DeclaratiePeriode As New DeclaratiePeriodes(Me.tbhidid.Value, MonthList.SelectedValue, YearList.SelectedValue)
            Dim MyDeclaratie As Declaraties
            If gvDeclarations.DataKeys(CInt(e.Item.ItemIndex)).ToString = "" Then
                MyDeclaratie = New Declaraties
            Else
                MyDeclaratie = New Declaraties(gvDeclarations.DataKeys(CInt(e.Item.ItemIndex)))
            End If
            Dim CurrentTextBox As TextBox

            CurrentTextBox = e.Item.Cells(1).Controls(0)  ' DeclPerId()
            MyDeclaratie.DeclPerId = DeclaratiePeriode.Id

            CurrentTextBox = e.Item.Cells(2).Controls(0) 'DeclaratieDate
            'controle op datum. moet wel in  dezelfde periode blijven.
            Dim declDate As New DateTime
            declDate = DateTime.Parse(CurrentTextBox.Text)

            If declDate.Month = DeclaratiePeriode.PeriodeMnd And declDate.Year = DeclaratiePeriode.PeriodeJaar Then
                'If declDate.Day >= Today.Day Then
                '    CurrentTextBox.BackColor = Drawing.Color.Red
                '    Throw New Exception("U kunt geen declaraties invoeren op toekomstige data")
                'End If
                Dim icell As Integer = 3
                MyDeclaratie.DeclaratieDate = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(icell).Controls(0)
                icell += 1
                MyDeclaratie.Omschrijving = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(icell).Controls(0)
                icell += 1
                'MyDeclaratie.Promomateriaal = Server.HtmlEncode(CurrentTextBox.Text)
                'If MyDeclaratie.Promomateriaal.Length > 80 Then Throw New Exception("veld Promomateriaal mag niet groter zijn dan 80 chars!")
                'CurrentTextBox = e.Item.Cells(icell).Controls(0)
                'icell += 1
                MyDeclaratie.Uren = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(icell).Controls(0)
                icell += 1
                MyDeclaratie.Maaltijden = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(icell).Controls(0)
                icell += 1
                MyDeclaratie.Onkosten = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(icell).Controls(0)
                icell += 1
                MyDeclaratie.OnkOmsc = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(icell).Controls(0)
                icell += 1
                MyDeclaratie.Kilometers = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(icell).Controls(0)
                icell += 1
                'MyDeclaratie.OnkOV = Server.HtmlEncode(CurrentTextBox.Text)
                'CurrentTextBox = e.Item.Cells(icell).Controls(0)

                MyDeclaratie.KmOmsc = Server.HtmlEncode(CurrentTextBox.Text)
                MyDeclaratie.CreatedDate = Today

                MyDeclaratie.Save()
                gvDeclarations.EditItemIndex = -1
                LoadDeclarations()
            Else
                CurrentTextBox.BackColor = Drawing.Color.Red
                Throw New Exception("Declaratie datum valt niet in de geselecteerde periode")
            End If

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub


    Public Sub gvDeclarations_DeleteCommand(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles gvDeclarations.DeleteCommand

        Try
            If tbhidLock.Value = "True" Then
                Exit Sub
            Else
                Dim MyDeclaratie As Declaraties
                If gvDeclarations.Items.Count >= (e.Item.ItemIndex + 1) Then
                    MyDeclaratie = New Declaraties(gvDeclarations.DataKeys(CInt(e.Item.ItemIndex)))
                    If MyDeclaratie.Found Then
                        MyDeclaratie.Remove()
                        LoadDeclarations()
                    End If
                End If
            End If


        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    Protected Sub btAddDeclaration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btAddDeclaration.Click
        Try
            If tbhidLock.Value = "True" Then
                Exit Sub
            Else

                Dim dt As New DataTable
                Dim dr As DataRow
                LoadDeclarations()
                dt = gvDeclarations.DataSource
                dr = dt.NewRow
                gvDeclarations.EditItemIndex = CInt(dt.Rows.Count)

                Dim DeclaratiePeriode As New DeclaratiePeriodes(Me.tbhidid.Value, MonthList.SelectedValue, YearList.SelectedValue)

                dr.Item("DeclPerId") = DeclaratiePeriode.Id
                dr.Item("Uren") = 0
                dr.Item("Maaltijden") = 0
                dr.Item("Onkosten") = 0
                dr.Item("Kilometers") = 0
                dr.Item("OnkOV") = 0
                dt.Rows.Add(dr)
                gvDeclarations.DataSource = dt
                gvDeclarations.DataBind()

            End If


        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    

    Protected Sub btnPrevPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim Mydate As New Date(YearList.SelectedValue, MonthList.SelectedValue, "1")
            Dim PrevDate As Date = DateAdd(DateInterval.Month, -1, Mydate)

            YearList.SelectedIndex = YearList.Items.IndexOf(YearList.Items.FindByValue(PrevDate.Year))
            MonthList.SelectedIndex = PrevDate.Month - 1

            FindPeriodeBtn()
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Protected Sub btnNextPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim Mydate As New Date(YearList.SelectedValue, MonthList.SelectedValue, "1")
            Dim PrevDate As Date = DateAdd(DateInterval.Month, 1, Mydate)

            YearList.SelectedIndex = YearList.Items.IndexOf(YearList.Items.FindByValue(PrevDate.Year))
            MonthList.SelectedIndex = PrevDate.Month - 1

            FindPeriodeBtn()
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Protected Sub btnSearchPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            FindPeriodeBtn()
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim DeclaratiePeriode As New DeclaratiePeriodes
            With DeclaratiePeriode
                .LidId = Me.tbhidid.Value
                .PeriodeMnd = MonthList.SelectedValue
                .PeriodeJaar = YearList.SelectedValue
                .Omschrijving = tbPerDescription.Text
                .CreatedDate = Now
                .CreatedBy = Me.tbhidid.Value
                .Save()
            End With
            FindPeriodeBtn()
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    Protected Sub btnCreateCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            VisiblePlaceHolders("phLoginSucces")
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Private Sub ShowError(ByVal message As String)
        Try
            phErrors.Visible = True
            Me.lbError.Text = message
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

End Class
