Public Class Verzekeringen
    Inherits List(Of Verzekering)
    Private da As New DataAccess

    Public Sub New()

    End Sub
    Public Sub New(ByVal lidid As Integer)
        Dim ohelper As New Helper
        GetByLIDID(lidid)
    End Sub

    Public Sub GetByLIDID(ByVal id As Int32)
        Try
            Dim sql As String = "SELECT * FROM Verzekeringen where lidid = @lidid"
            Dim param() As Object = {"@lidid", id}

            Dim ohelper As New Helper
            ohelper.MapDataTableToListObject(Of Verzekering)(Me, da.ExecuteDataTable(sql, param))

            For i As Integer = 0 To Count - 1
                Me(i).List = Me
            Next

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
End Class
