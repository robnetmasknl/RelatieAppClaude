Public Class Rangen
    Inherits tblRangen
    Private da As New DataAccess
#Region "Basic"
    Enum Via
        ID
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
            'ElseIf Via.ToString = "SHORTDESC" Then
            'ohelper.FillObject(Me, GetByShortDesc(id))
        End If
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
    Public Function GetById(ByVal id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM  Rangen where id = @id"
            Dim param() As Object = {"@id", id.ToString}
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
            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "Rangen", "Id", True)
            Else
                da.UpdateString(Me, "Rangen", "Id")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "Rangen")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class