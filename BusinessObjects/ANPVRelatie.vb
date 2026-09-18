
Public Class ANPVRelatie
    Inherits Relaties

    Private da As New DataAccess
    Public Sub New(ByVal id As String, ByVal geb As Date)

        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetByRegNrGeb(id, geb))


    End Sub
    Public Function GetByRegNrGeb(ByVal lidnr As String, ByVal geb As Date) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Relaties where rnr = @lidnr And geboortedatum = @GebDatum"
            Dim param() As Object = {"@lidnr", lidnr, "@GebDatum", geb}

            oDr = da.ExecuteDataRow(sql, param)

            If Not oDr Is Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
End Class
