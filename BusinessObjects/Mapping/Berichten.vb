Public Class Berichten
    Inherits tblBerichten
    Private da As New DataAccess
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub


    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Berichten where id = @id"
            Dim param() As Object = {"@id", GetId}
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

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Public Sub Save()
        Try

            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "Berichten", "Id", True)

            Else
                da.UpdateString(Me, "Berichten", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess

            Dim param() As Object = {"@id", Id}
            Dim sql As String = "DELETE FROM Berichten WHERE Id = @id"
            da.ExecuteScalar(sql, param)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private _boCategory As String = String.Empty
    Public Property boCategory() As String
        Get
            Return _boCategory
        End Get
        Set(ByVal value As String)
            _boCategory = value
        End Set
    End Property

    'Private _boFolderId As String = String.Empty
    'Public Property boFolderId() As String
    '    Get
    '        Return _boFolderId
    '    End Get
    '    Set(ByVal value As String)
    '        _boFolderId = value
    '    End Set
    'End Property
End Class
