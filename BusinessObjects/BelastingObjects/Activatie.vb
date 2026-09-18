Public Class Activatie
    Inherits tblActivatie

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)

        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))


    End Sub

    Public Function GetById(ByVal id As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim da As New DataAccess

            Dim sql As String = "SELECT * FROM Activatie where ActivatieGUID= @ActivatieGUID"
            Dim param() As Object = {"@ActivatieGUID", New Guid(CType(id, String))}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
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
            Dim da As New DataAccess

            If Me.Id = 0 Then
                Me.ActivatieGUID = Guid.NewGuid
                Id = da.InsertString(Me, "Activatie", "Id", True)
            Else
                da.UpdateString(Me, "Activatie", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "Activatie")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
End Class
