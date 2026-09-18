Public Class ClieopVersions
    Inherits List(Of tblclieop)
    Private da As New DataAccess

    Public Sub New()
        GetByCreateDate(Today)
    End Sub

    Public Sub GetByCreateDate(ByVal CreateDate As DateTime)
        Try
            Dim sql As String = "SELECT * FROM clieop where YEAR(CreateDate) = @CreateYear AND MONTH(CreateDate) = @CreateMonth ORDER BY version"
            Dim param() As Object = {"@CreateYear", CreateDate.Year, "@CreateMonth", CreateDate.Month}
            Dim ohelper As New Helper
            ohelper.MapDataTableToListObject(Of tblclieop)(Me, da.ExecuteDataTable(sql, param))

            For i As Integer = 0 To Count - 1
                Me(i).List = Me
            Next

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function HighestVersion() As tblclieop
        Try
            Dim query As IEnumerable(Of tblclieop) = Nothing
            query = Me(0).List.OrderByDescending(Function(tblclieop) tblclieop.Version)

            Return query(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
