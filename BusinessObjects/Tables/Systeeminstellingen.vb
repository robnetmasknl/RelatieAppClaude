
<MapperTable("Systeeminstellingen", "Id")> _
Public Class Systeeminstellingen
    Inherits tblSysteeminstellingen
    Private da As New DataAccess

    Enum Via
        ID
        ZOEKNAAM
    End Enum

    Enum eBond
        ALLEN = 0
        VBM = 1
        NOV = 2
    End Enum
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via, ByRef _bond As eBond)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id, _bond))
        ElseIf Via.ToString = "ZOEKNAAM" Then
            ohelper.FillObject(Me, GetByZOEKNAAM(id, CInt(_bond)))
        End If
    End Sub

    Public Function GetById(ByVal GetId As Int32, ByRef _bond As eBond) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Systeeminstellingen where id = @id AND Bond = @bond"
            Dim param() As Object = {"@id", GetId, "@bond", CInt(_bond)}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetByZOEKNAAM(ByVal GetId As String, ByRef _bond As eBond) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Systeeminstellingen where zoeknaam = @ZOEKNAAM AND Bond = @bond"
            Dim param() As Object = {"@ZOEKNAAM", GetId, "@bond", _bond}
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
                Id = da.InsertString(Me, "Systeeminstellingen", "Id", True)
            Else
                da.UpdateString(Me, "Systeeminstellingen", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "Systeeminstellingen")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

Public Class tblSysteeminstellingen
#Region "members"
    Private _Id As Int32 = 0
    Private _Bond As Int32 = 0
    Private _Zoeknaam As String = ""
    Private _Omschijving As String = ""
    Private _Waarde As String = ""
#End Region

#Region "Properties"

    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("Bond")> _
    Public Property Bond() As Int32
        Get
            Return _Bond
        End Get
        Set(ByVal value As Int32)
            _Bond = value
        End Set
    End Property
    <MapperColumn("Zoeknaam")> _
    Public Property Zoeknaam() As String
        Get
            Return _Zoeknaam
        End Get
        Set(ByVal value As String)
            _Zoeknaam = value
        End Set
    End Property
    <MapperColumn("Omschijving")> _
    Public Property Omschijving() As String
        Get
            Return _Omschijving
        End Get
        Set(ByVal value As String)
            _Omschijving = value
        End Set
    End Property
    <MapperColumn("Waarde")> _
    Public Property Waarde() As String
        Get
            Return _Waarde
        End Get
        Set(ByVal value As String)
            _Waarde = value
        End Set
    End Property

#End Region

End Class