Public Class History
    Inherits tblHistory
    Private da As New DataAccess

    Enum Via
        ID
        LIDNR
        MUTDATE
        LASTMUT
    End Enum
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LIDNR" Then
            ohelper.FillObject(Me, GetByLIDNR(id))
        ElseIf Via.ToString = "MUTDATE" Then
            ohelper.FillObject(Me, GetByMUTDATE(id))
        ElseIf Via.ToString = "LASTMUT" Then
            ohelper.FillObject(Me, GetBylastMutById(id))
        End If
    End Sub

    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM history where id = @id ORDER BY mutdate"
            Dim param() As Object = {"@id", GetId}
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
    Public Function GetByLIDNR(ByVal GetId As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM history where lidId = @LIDNR ORDER BY mutdate"
            Dim param() As Object = {"@LIDNR", GetId}
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
    Public Function GetBylastMutById(ByVal GetId As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT TOP 1 * FROM history where lidId = @LIDNR ORDER BY mutdate DESC"
            Dim param() As Object = {"@LIDNR", GetId}
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
    Public Function GetByMUTDATE(ByVal mutdate As DateTime) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM history where mutdate = @mutdate ORDER BY mutdate"
            Dim param() As Object = {"@mutdate", mutdate}
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
                Id = da.InsertString(Me, "history", "Id", True)
            Else
                da.UpdateString(Me, "history", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "history")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
