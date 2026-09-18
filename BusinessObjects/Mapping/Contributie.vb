Public Class Contributie
    Inherits tblContributie
    Private da As New DataAccess

    Enum Via
        ID
        LIDSOORTID
    End Enum

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LIDSOORTID" Then
            ohelper.FillObject(Me, GetByLIDSOORTID(id))
        End If
    End Sub
    Public Sub New(ByVal id As String, ByVal DateIn As DateTime)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetByDateIn(id, DateIn))

    End Sub
    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Contributie where id = @id"
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
    Public Function GetByDateIn(ByVal id As Int32, ByVal DateIn As DateTime) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            'TODO :>= @DateIn waarschijnlijk omdraaien. Is per 04-01-2012 gedaan.nog niet definitief
            Dim sql As String = "SELECT TOP 1 * FROM Contributie where (lidsoortid = @lidsoortid AND sedert <= @DateIn) ORDER BY sedert DESC"
            Dim param() As Object = {"@lidsoortid", id.ToString, "@DateIn", DateIn}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                sql = "SELECT TOP 1 * FROM Contributie where (lidsoortid = @lidsoortid AND sedert >= @DateIn) ORDER BY sedert DESC"
                oDr = da.ExecuteDataRow(sql, param)
            End If
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

    Public Function GetByLIDSOORTID(ByVal id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Contributie where lidsoortid = @lidsoortid"
            Dim param() As Object = {"@lidsoortid", id.ToString}
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
                Id = da.InsertString(Me, "Contributie", "Id", True)
            Else
                'If da.isChanged(Me, "Contributie", "Id", Me.Id,Me.) Then
                da.UpdateString(Me, "Contributie", "Id")
                'End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            'Dim da As New DataAccess
            da.DeleteString(Me, "Contributie")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

