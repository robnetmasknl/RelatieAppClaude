Imports BusinessObjects
Imports System.Text

Public Class frmSqlBuild
    Private da As New DataAccess

    Private Sub frmSqlBuild_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lsbTables.DataSource = da.GetTableNames("")

        cmbColumns.DataSource = da.GetColumnsNames("Relaties")

        Dim CompareTable As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "showname"
        CompareTable.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "RealValue"
        CompareTable.Columns.Add(col)



        Dim dr As DataRow
        dr = CompareTable.NewRow
        dr("RealValue") = " = "
        dr("showname") = "EQ"
        CompareTable.Rows.Add(dr)

        dr = CompareTable.NewRow
        dr("RealValue") = " like "
        dr("showname") = "like "
        CompareTable.Rows.Add(dr)

        dr = CompareTable.NewRow
        dr("RealValue") = " <= "
        dr("showname") = "LT"
        CompareTable.Rows.Add(dr)

        dr = CompareTable.NewRow
        dr("RealValue") = " >= "
        dr("showname") = "GT"
        CompareTable.Rows.Add(dr)


        cmbCompare.DataSource = CompareTable
        cmbCompare.DisplayMember = "showname"
        cmbCompare.ValueMember = "RealValue"
        cmbCompare.SelectedValue = 0





    End Sub

    Private Sub lsbTables_DoubleClick(sender As Object, e As EventArgs) Handles lsbTables.DoubleClick
        Me.lblTableName.Text = Me.lsbTables.SelectedItem
        Me.lsbColums.DataSource = da.GetColumnsNames(Me.lsbTables.SelectedItem)
        Me.lsbWhat.DataSource = da.GetColumnsNames(Me.lsbTables.SelectedItem)
        Me.txtFrom.Text = Me.lsbTables.SelectedItem
        'cmbColumns.DataSource = da.GetColumnsNames(Me.lsbTables.SelectedItem)
    End Sub

    'Private Sub lsbColums_DoubleClick(sender As Object, e As EventArgs) Handles lsbColums.DoubleClick
    '    Me.txtWhere.Text = Me.lsbColums.SelectedItem
    'End Sub


    Private Sub btnCreateSQL_Click(sender As Object, e As EventArgs) Handles btnCreateSQL.Click

        Dim sql As String = "SELECT DISTINCT rel.* ,afd.omschrijving as afdelingnaam " & _
        "FROM relaties rel " & _
        "LEFT JOIN afdelingen afd ON rel.afdeling = afd.id " & _
        "LEFT JOIN IBBDossiers ibb ON rel.Id = ibb.LidId " & _
        "WHERE "

        Me.txtSQL.Text = sql
        'Me.txtSQL.AppendText("SELECT ")
        'Dim sWhat As String = ""
        'For Each o As String In Me.lsbWhat.SelectedItems
        '    sWhat &= o & ", "
        'Next
        'sWhat = sWhat.Remove(sWhat.Length - 2, 2)
        'Me.txtSQL.AppendText(sWhat)
        'Me.txtSQL.AppendText(" FROM ")
        'Me.txtSQL.AppendText(Me.txtFrom.Text)
        'Me.txtSQL.AppendText(" WHERE ")
        Me.txtSQL.AppendText(cmbColumns.SelectedValue)
        Me.txtSQL.AppendText(cmbCompare.SelectedValue)
        Me.txtSQL.AppendText(Me.txtIs.Text)

    End Sub

 
    Private Sub btnSqlRun_Click(sender As Object, e As EventArgs) Handles btnSqlRun.Click
        Try
            Dim tbl As DataTable = da.ExecuteDataTable(txtSQL.Text)
            MessageBox.Show(tbl.Rows.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class