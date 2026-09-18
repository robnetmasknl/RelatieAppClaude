Public Class Storneringen
    Inherits List(Of Stornering)
    Private da As New DataAccess

    Public Sub New()

    End Sub
    Public Sub New(ByVal lidid As Integer)
        Dim ohelper As New Helper
        GetByLIDID(lidid)
    End Sub
    Public Sub New(ByVal lidid As Integer, ByVal jaar As Integer)
        Dim ohelper As New Helper
        GetByLIDIDYEAR(lidid, jaar)
    End Sub
    Public Sub GetByLIDID(ByVal id As Int32)
        Try
            Dim sql As String = "SELECT * FROM Storneringen where lidid = @lidid"
            Dim param() As Object = {"@lidid", id}

            Dim ohelper As New Helper
            ohelper.MapDataTableToListObject(Of Stornering)(Me, da.ExecuteDataTable(sql, param))

            For i As Integer = 0 To Count - 1
                Me(i).List = Me
            Next

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub GetByLIDIDYEAR(ByVal id As Int32, ByVal jaar As Integer)
        Try
            Dim sql As String = "SELECT * FROM Storneringen where lidid = @lidid AND jaar = @jaar"
            Dim param() As Object = {"@lidid", id, "@jaar", jaar}

            Dim ohelper As New Helper
            ohelper.MapDataTableToListObject(Of Stornering)(Me, da.ExecuteDataTable(sql, param))

            For i As Integer = 0 To Count - 1
                Me(i).List = Me
            Next

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function TotalAmount() As Decimal
        Dim Amount As Decimal = 0.0
        For i As Integer = 0 To Count - 1
            Amount += Me(i).bedrag
        Next
        Return Amount
    End Function
End Class
