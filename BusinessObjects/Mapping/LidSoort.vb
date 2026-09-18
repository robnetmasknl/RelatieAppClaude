Public Class LidSoort
    Inherits tblLidsoorten
    Private da As New DataAccess

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Lidsoorten where id = @id"
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
            If Me.Id = 0 Then
                Id = da.InsertString(Me, "Lidsoorten", "Id", True)
            Else

                'If da.isChanged(Me, "Lidsoorten", "Id", Me.Id) Then
                da.UpdateString(Me, "Lidsoorten", "Id")
                'End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            da.DeleteString(Me, "Lidsoorten")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Function GetList(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As Data.DataTable
    '    Dim oDS As Data.DataSet
    '    Try
    '        oDS = da.ExecuteDataset(sql, parameters)
    '        Return oDS.Tables(0)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        oDS = Nothing
    '    End Try
    'End Function

    'Private _LidSoortPeriodes As List(Of LidSoortPeriode)
    'Public ReadOnly Property LidSoortPeriodes() As List(Of LidSoortPeriode)
    '    Get
    '        If _LidSoortPeriodes Is Nothing Then
    '            _LidSoortPeriodes = New List(Of LidSoortPeriode)
    '            Dim _LidSoortPeriode As New LidSoortPeriode
    '            Dim ohelper As New Helper
    '            Dim sql As String = "SELECT * FROM LidSoortPerioden WHERE lidsoortid = @lidsoortid ORDER BY datumin DESC"
    '            Dim param() As Object = {"@lidsoortid", Id}
    '            _LidSoortPeriodes = ohelper.MapDataTableToList(Of LidSoortPeriode)(_LidSoortPeriode.GetList(sql, param))
    '        End If

    '        Return _LidSoortPeriodes
    '    End Get
    'End Property

End Class
