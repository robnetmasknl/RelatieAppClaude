Public Class Declaraties
    Inherits tblDeclaraties
    Private da As New DataAccess

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub

    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Declaraties where id = @id"
            Dim param() As Object = {"@id", GetId}
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

    Public Sub Save()
        Try
            Dim _declaratieperiode As New DeclaratiePeriodes(Me.DeclPerId)
            Dim _declaratiedate As New DateTime
            _declaratiedate = DateTime.Parse(Me.DeclaratieDate)

            If _declaratiedate.Month = _declaratieperiode.PeriodeMnd And _declaratiedate.Year = _declaratieperiode.PeriodeJaar Then
                If Me.Id = Nothing Then
                    Id = da.InsertString(Me, "Declaraties", "Id", True)
                Else
                    da.UpdateString(Me, "Declaraties", "Id")
                End If
            Else
                Throw New Exception("Declaratie datum valt niet in de periode datum")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "Declaraties")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
