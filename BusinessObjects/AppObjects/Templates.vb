Public Class Templates
    Private da As New DataAccess
    Private _dtTemplates As DataTable
    Public ReadOnly Property dtTemplates() As DataTable
        Get
            If _dtTemplates Is Nothing Then
                _dtTemplates = da.ExecuteDataTable("SELECT * FROM Templates WHERE (Bond = 0 OR BOND = 1) ORDER BY afdeling, omschrijving")
            End If
            Return _dtTemplates
        End Get
    End Property

    Public Function GetTemplateId(ByVal TemplateName As String, ByVal DepartmentName As String) As Integer
        Try
            Dim dv As New DataView(dtTemplates)
            Dim _filter As String = "Afdeling = '" & DepartmentName.Trim & "'"
            dv.RowFilter = _filter
            dv.Sort = "Id"

            For Each row As DataRowView In dv
                If row.Item("Omschrijving").ToString = TemplateName Then
                    Return row.Item("Id")
                End If
            Next

            Return 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
