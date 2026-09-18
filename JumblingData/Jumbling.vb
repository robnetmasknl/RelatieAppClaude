Imports System.IO
Imports System.Text
Imports BusinessObjects
Public Class Jumbling
    Private da As New DataAccess
    Public Event GenerateComplete(ByVal iCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)


    Private iCounter As Integer = 0
    Private iTotalCounter As Integer = 0

    Private status As Integer = 0
    Private Function GetRelaties() As DataTable
        Try
            Dim dt As New DataTable
            Dim da As New DataAccess
            Dim paramDate As New ArrayList


            RaiseEvent GenerateStatus("Bezig met ophalen van leden")
            Dim sql As String = "SELECT id, lidnr, achternaam, init , tussenvoegsel, adres, huisnr, huisnrtv, postcode, ZipCode, plaats, land " &
                    "FROM relaties "
            dt = da.ExecuteDataTable(sql & " > 0", paramDate.ToArray)

            iTotalCounter = dt.Rows.Count
            RaiseEvent GenerateStatus(iTotalCounter & " leden gevonden")

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetRandomString(ByVal iLength As Integer) As String
        Dim sResult As String = ""
        Dim rdm As New Random()

        For i As Integer = 1 To iLength
            sResult &= ChrW(rdm.Next(32, 60))
        Next

        Return sResult
    End Function
End Class
