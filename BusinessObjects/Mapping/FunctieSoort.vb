Public Class FunctieSoort
    Inherits tblfsoort
    Private da As New DataAccess

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM fsoort where id = @id"
            Dim param() As Object = {"@id", Id}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
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
                Id = da.InsertString(Me, "fsoort", "Id", True)
            Else
                da.UpdateString(Me, "fsoort", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            'Dim da As New fsoort
            da.DeleteString(Me, "fsoort")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetList(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As Data.DataTable
        Dim oDS As Data.DataSet
        Try
            oDS = da.ExecuteDataset(sql, parameters)
            Return oDS.Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            oDS = Nothing
        End Try
    End Function
End Class
