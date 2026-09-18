Public Class SepaVersions
    Inherits List(Of tblSepa)
    Private da As New DataAccess

    Public Sub New()
        GetByCreateDate(Today)
    End Sub

    Public Sub GetByCreateDate(ByVal CreateDate As DateTime)
        Try
            Dim sql As String = "SELECT * FROM sepa where YEAR(CreateDate) = @CreateYear AND MONTH(CreateDate) = @CreateMonth ORDER BY version"
            Dim param() As Object = {"@CreateYear", CreateDate.Year, "@CreateMonth", CreateDate.Month}
            Dim ohelper As New Helper
            ohelper.MapDataTableToListObject(Of tblSepa)(Me, da.ExecuteDataTable(sql, param))

            For i As Integer = 0 To Count - 1
                Me(i).List = Me
            Next

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function HighestVersion() As tblSepa
        Try
            Dim query As IEnumerable(Of tblSepa) = Nothing
            query = Me(0).List.OrderByDescending(Function(tblSepa) tblSepa.Version)

            Return query(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class


