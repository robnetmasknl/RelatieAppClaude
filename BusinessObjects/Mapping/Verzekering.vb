Public Class Verzekering
    Inherits tblVerzekeringen

    Private da As New DataAccess
    Public List As Verzekeringen

    Enum Via
        ID
        LIDID
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LIDID" Then
            ohelper.FillObject(Me, GetByLIDID(id))
        End If
    End Sub
    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Verzekeringen where id = @id"
            Dim param() As Object = {"@id", Id}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function

    Public Function GetByLIDID(ByVal id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Verzekeringen where lidid = @lidid"
            Dim param() As Object = {"@lidid", id.ToString}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
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
                Id = da.InsertString(Me, "Verzekeringen", "Id", True)
            Else
                If da.isChanged(Me, "Verzekeringen", "Id", Me.Id, Me.Lidid) Then
                    da.UpdateString(Me, "Verzekeringen", "Id")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            da.DeleteString(Me, "Verzekeringen")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
