
Public Class plaatsingen
    Inherits tblPlaatsingen
    Private da As New DataAccess

    Enum Via
        ID
        BYCODE
        BYPLAATSING
    End Enum
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "BYCODE" Then
            ohelper.FillObject(Me, GetByCode(id))
        ElseIf Via.ToString = "BYPLAATSING" Then
            ohelper.FillObject(Me, GetByPlaatsing(id))
        End If
    End Sub

    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM plaatsingen where id = @id"
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
    Public Function GetByCode(ByVal getcode As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM plaatsingen where code = @code"
            Dim param() As Object = {"@code", getcode}
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

    Public Function GetByPlaatsing(ByVal LikePlaatsing As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM plaatsingen where plaatsing = @plaatsing"
            Dim param() As Object = {"@plaatsing", LikePlaatsing}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                sql = "SELECT * FROM plaatsingen where plaatsing like @plaatsing"
                Dim param1() As Object = {"@plaatsing", "%" & LikePlaatsing}
                oDr = da.ExecuteDataRow(sql, param1)
            End If

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
            If Me.Found = False Then
                P_Id = da.InsertString(Me, "plaatsingen", "P_Id", True)
            Else
                da.UpdateString(Me, "plaatsingen", "P_Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "plaatsingen")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class


