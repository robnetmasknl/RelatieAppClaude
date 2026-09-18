Imports BusinessObjects
Imports System.Data

Partial Class DeclarationPrint
    Inherits System.Web.UI.Page

    Protected mylidid As Int32 = -1
    Private PeriodId As Integer = -1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Request.UrlReferrer Is Nothing Then
                Dim PreviousPage As String = ExtractPageName(Request.UrlReferrer.ToString)
                If PreviousPage.ToLower = "management.aspx" Then
                    Dim _logindecl As New LoginDecl
                    mylidid = _logindecl.LoginManager(Session("nr4559"), Session("pw4559"))
                    If mylidid > 0 Then
                        PeriodId = CType(Page.Request("id").ToString(), Integer)
                        LoadDeclarations()
                    End If

                End If
            End If
        Catch ex As Exception
            ShowError(ex.Message)
        End Try

    End Sub
    Private Sub LoadDeclarations()
        Try
            Dim DeclaratiePeriode As DeclaratiePeriodes
            If PeriodId > 0 Then
                DeclaratiePeriode = New DeclaratiePeriodes(PeriodId)
                gvDeclarations.DataSource = DeclaratiePeriode.GetDeclarationTable
                gvDeclarations.DataBind()

                If DeclaratiePeriode.Found Then
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
                    col.ColumnName = "PeriodTotalBruto"
                    dtTotals.Columns.Add(col)
                    col = New DataColumn
                    col.ColumnName = "TotalMeals"
                    dtTotals.Columns.Add(col)


                    Dim dr As DataRow
                    dr = dtTotals.NewRow
                    dr.Item("Uren") = DeclaratiePeriode.TotalHours
                    dr.Item("Onkosten") = DeclaratiePeriode.TotalExpense
                    dr.Item("Kilometers") = DeclaratiePeriode.TotalKm
                    'dr.Item("OnkOV") = DeclaratiePeriode.TotalPublicTransport
                    dr.Item("TotalMeals") = " € " & DeclaratiePeriode.TotalMeals
                    dr.Item("TotalAmountKm") = " € " & DeclaratiePeriode.TotalAmountKm
                    dr.Item("TotalAmountHours") = " € " & DeclaratiePeriode.TotalAmountHours
                    'dr.Item("TotalAmountKm") = DeclaratiePeriode.TotalKm & " x " & DeclaratiePeriode.PeriodAmounts.AmountKm & " = € " & _
                    '                            DeclaratiePeriode.TotalAmountKm
                    'dr.Item("TotalAmountHours") = DeclaratiePeriode.TotalHours & " x " & DeclaratiePeriode.PeriodAmounts.AmountHour & " = € " & _
                    '                          DeclaratiePeriode.TotalAmountHours
                    dr.Item("PeriodTotalBruto") = " € " & DeclaratiePeriode.PeriodTotalCompensation
                    ' dr.Item("PeriodTotalNetto") = " € " & DeclaratiePeriode.PeriodTotalNetto
                    dtTotals.Rows.Add(dr)

                    gvTotals.DataSource = dtTotals
                    gvTotals.DataBind()
                    lbRecruiterName.Text = "Naam: " & DeclaratiePeriode.Relatie.FullName
                    lbPeriode.Text = "Periode: " & CType(DeclaratiePeriode.PeriodeMnd, eMaandFull).ToString & " - " & DeclaratiePeriode.PeriodeJaar
                    lbPeriodAmountPKm.Text = " € " & DeclaratiePeriode.PeriodAmounts.AmountKm & " per km"
                    lbPeriodAmountPHour.Text = " € " & DeclaratiePeriode.PeriodAmounts.AmountHour & " per uur"

                    'lblPromo.Text = String.Join(", ", DeclaratiePeriode.UsedPromoMaterial.ToArray)

                End If

            End If
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
    Private Sub ShowError(ByVal message As String)
        Try
            Me.lbError.Text = message
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    Protected Sub gvTotals_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTotals.RowDataBound
        Try

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
End Class
