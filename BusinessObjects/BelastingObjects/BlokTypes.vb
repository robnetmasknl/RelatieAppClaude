Public Class BlokTypes
    Inherits tblBlokTypes
    Private da As New DataAccess
    Enum Via
        ID
        TEMPLATENAAM
    End Enum
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "TEMPLATENAAM" Then
            ohelper.FillObject(Me, GetByTEMPLATENAAM(id))
        End If
    End Sub

    Private _BlokTypesList As List(Of BlokTypes)
    Public ReadOnly Property Lijst() As List(Of BlokTypes)
        Get
            If _BlokTypesList Is Nothing Then
                _BlokTypesList = New List(Of BlokTypes)
                Dim _BlokType As New BlokTypes
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM bloktypes"
                _BlokTypesList = ohelper.MapDataTableToList(Of BlokTypes)(_BlokType.GetList(sql))
            End If
            Return _BlokTypesList
        End Get
    End Property

    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM bloktypes where id = @id"
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
    Public Function GetByTEMPLATENAAM(ByVal GetId As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM bloktypes where tempnaam = @tempnaam"
            Dim param() As Object = {"@tempnaam", GetId}
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
                Id = da.InsertString(Me, "blokken", "Id", True)
            Else
                da.UpdateString(Me, "blokken", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "blokken")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
