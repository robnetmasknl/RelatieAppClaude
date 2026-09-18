Imports BusinessObjects
Imports System.Data

Partial Class Declaration
    Inherits System.Web.UI.Page

    Protected mylidid As Int32 = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Page.EnableViewState = True

    End Sub
    Protected Sub VisiblePlaceHolders(ByVal ph As String)
        phLogin.Visible = False
        phLoginSucces.Visible = False
        phCreatePeriode.Visible = False
        phSelectedPeriod.Visible = False
        Select Case ph
            Case Is = "phLogin"
                phLogin.Visible = True
            Case "phLoginSucces"
                phLoginSucces.Visible = True
                If MonthList.Items.Count = 0 Then
                    GetMyMonthList(MonthList, True)
                    GetMyYearList(YearList, 5, 0, True)
                End If
            Case "phCreatePeriode"
                phCreatePeriode.Visible = True
            Case "phSelectedPeriod"
                phSelectedPeriod.Visible = True
            Case Else
                phErrors.Visible = True
        End Select


    End Sub
    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnSend.Click
        Try
            VisiblePlaceHolders("niets")

            Dim _logindecl As New LoginDecl
            mylidid = _logindecl.Login(Me.tbLidNr.Text, Me.tbPassword.Text)
            Me.tbhidid.Value = mylidid

            If mylidid > 0 Then
                VisiblePlaceHolders("phLoginSucces")
            Else
                VisiblePlaceHolders("phLogin")
                Label1.Text = "U bent NIET aangemeld. Controleer uw inloggegevens!"
            End If


        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    'Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnSend.Click
    '    Try
    '        FindPeriode()
    '    Catch ex As Exception
    '        ShowError(ex.Message)
    '    End Try
    'End Sub
    'Protected Sub FindPeriode()
    'Try
    '    If Calendar1.SelectedDate > Today Then
    '        lbCalendar.Text = "U kunt geen declaraties invoeren op toekomstige data"
    '    Else
    '        lbCalendar.Text = "en toen..."
    '        Dim DeclaratiePeriode As New DeclaratiePeriodes(Me.tbhidid.Value, Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Year)
    '        If DeclaratiePeriode.Found Then
    '            lbPeriode.Text = "gevonden periode - " & DeclaratiePeriode.PeriodName & " - " & DeclaratiePeriode.Omschrijving
    '            VisiblePlaceHolders("phSelectedPeriod")
    '            LoadDeclarations()

    '        Else
    '            VisiblePlaceHolders("phCreatePeriode")
    '            lbCreatePeriode.Text = "periode: " & Calendar1.SelectedDate.Month & " niet gevonden. Wilt u de periode aanmaken?"
    '        End If
    '    End If

    'Catch ex As Exception
    '    ShowError(ex.Message)
    'End Try
    '' End Sub
    Protected Sub FindPeriodeBtn()
        Try
            Dim Mydate As New Date(YearList.SelectedValue, MonthList.SelectedValue, "1")
            Dim CurrentPeriod As New Date(Today.Year, Today.Month, "1")

            If Mydate > CurrentPeriod Then
                lbCalendar.Text = "U kunt geen declaraties invoeren op toekomstige data"
            Else
                lbCalendar.Text = "en toen..."
                Dim DeclaratiePeriode As New DeclaratiePeriodes(Me.tbhidid.Value, MonthList.SelectedValue, YearList.SelectedValue)
                If DeclaratiePeriode.Found Then
                    lbPeriode.Text = "gevonden periode - " & DeclaratiePeriode.PeriodName & " - " & DeclaratiePeriode.Omschrijving
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
            Dim DeclaratiePeriode As New DeclaratiePeriodes(Me.tbhidid.Value, MonthList.SelectedValue, YearList.SelectedValue)
            gvDeclarations.DataSource = DeclaratiePeriode.GetDeclarationTable
            gvDeclarations.DataBind()

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Public Sub gvDeclarations_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gvDeclarations.ItemDataBound
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

    End Sub
    Public Sub gvDeclarations_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvDeclarations.EditCommand
        gvDeclarations.EditItemIndex = CInt(e.Item.ItemIndex)
        LoadDeclarations()
    End Sub
    Private Sub gvDeclarations_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvDeclarations.CancelCommand
        gvDeclarations.EditItemIndex = -1
        LoadDeclarations()
    End Sub
    Private Sub gvDeclarations_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvDeclarations.UpdateCommand
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
                MyDeclaratie.DeclaratieDate = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(3).Controls(0)
                MyDeclaratie.Omschrijving = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(4).Controls(0)
                MyDeclaratie.Onkosten = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(5).Controls(0)
                MyDeclaratie.OnkOmsc = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(6).Controls(0)
                MyDeclaratie.Kilometers = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(7).Controls(0)
                MyDeclaratie.OnkOV = Server.HtmlEncode(CurrentTextBox.Text)
                CurrentTextBox = e.Item.Cells(8).Controls(0)
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
    Protected Sub btAddDeclaration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btAddDeclaration.Click
        Try
            Dim dt As New DataTable
            Dim dr As DataRow
            LoadDeclarations()
            dt = gvDeclarations.DataSource
            dr = dt.NewRow
            Dim DeclaratiePeriode As New DeclaratiePeriodes(Me.tbhidid.Value, MonthList.SelectedValue, YearList.SelectedValue)

            dr.Item("DeclPerId") = DeclaratiePeriode.Id
            dt.Rows.Add(dr)
            gvDeclarations.DataSource = dt
            gvDeclarations.DataBind()

            gvDeclarations.EditItemIndex = CInt(dt.Rows.Count)



        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    'Protected Sub gvDeclarations_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gvDeclarations.ItemDataBound
    '    Try
    '        If e.Row.RowType = DataControlRowType.DataRow Then
    '            '    'e.Row.Cells(1).Text = "1" 'term.StartDate.ToString("dd-MM-yyyy")
    '            '    Dim tmp As String = e.Row.Cells(1).Text
    '            '    e.Row.Cells(1).Text = tmp("dd-MM-yyyy")
    '            e.Row.Cells(3).Text = "" & String.Format("{0:c}", e.Row.Cells(3).Text)
    '            '    'e.Row.Cells(4).Text = "1" 'IIf(term.Invoiced, "ja", "nee")
    '        End If
    '    Catch ex As Exception
    '        ShowError(ex.Message)
    '    End Try

    'End Sub
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

    Private Sub ShowError(ByVal message As String)
        Try
            phErrors.Visible = True
            Me.lbError.Text = message
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub



    'Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
    '    Dim onmouseoverStyle As String = "this.style.backgroundColor='#D4EDFF'"
    '    Dim onmouseoutStyle As String = "this.style.backgroundColor='@BackColor'"
    '    Dim rowBackColor As String = String.Empty

    '    e.Cell.Attributes.Add("onmouseover", onmouseoverStyle)
    '    e.Cell.Attributes.Add("onmouseout", onmouseoutStyle.Replace("@BackColor", rowBackColor))

    '    If Not e.Day.IsWeekend Then
    '        e.Cell.Attributes.Add("onmouseover", onmouseoverStyle)
    '        e.Cell.Attributes.Add("onmouseout", onmouseoutStyle.Replace("@BackColor", rowBackColor))
    '    End If

    'End Sub
    Public Sub GetMyMonthList(ByVal MyddlMonthList As DropDownList, ByVal SetCurruntMonth As Boolean)
        Dim month As DateTime = Convert.ToDateTime("1/1/2000")
        For i As Integer = 0 To 11

            Dim NextMont As DateTime = month.AddMonths(i)
            Dim list As New ListItem()
            list.Text = NextMont.ToString("MMMM")
            list.Value = NextMont.Month.ToString()
            MyddlMonthList.Items.Add(list)
        Next
        If SetCurruntMonth = True Then
            MyddlMonthList.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = True
        End If
    End Sub

    Public Sub GetMyYearList(ByVal MyddlYearList As DropDownList, ByVal YearPre As Integer, ByVal YearSuf As Integer, ByVal SetCurruntYear As Boolean)
        Dim iYear As Integer = Today.Year
        Dim FisrtYear As Integer = iYear - YearPre
        Dim LastYear As Integer = iYear + YearSuf

        For i As Integer = FisrtYear To LastYear
            Dim list As New ListItem()
            list.Text = i
            list.Value = i
            MyddlYearList.Items.Add(list)
        Next
        If SetCurruntYear = True Then
            MyddlYearList.Items.FindByValue(iYear).Selected = True
        End If
    End Sub
End Class
