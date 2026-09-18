Imports BusinessObjects
Imports System.Text

Public Class dlgSqlMailing
    Private da As New DataAccess

    Private Sub dlgSqlMailing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
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
            tbSqlFrom.Text = "SELECT DISTINCT rel.* ,afd.omschrijving as afdelingnaam " &
                            "FROM relaties rel " &
                            "LEFT JOIN afdelingen afd ON rel.afdeling = afd.id " &
                            "LEFT JOIN IBBDossiers ibb ON rel.Id = ibb.LidId "

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnCreateSQL_Click(sender As Object, e As EventArgs) Handles btnCreateSQL.Click

    
        txtSQL.Text = BuildSqlText()
    End Sub
    Private Function BuildSqlText() As String
        Dim result As New StringBuilder
        result.Append(cmbColumns.SelectedValue)
        result.Append(cmbCompare.SelectedValue)
        result.Append(Me.txtIs.Text)

        Return result.ToString

    End Function
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            If String.IsNullOrEmpty(txtSQL.Text) Then
                txtSQL.Text = BuildSqlText()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class