<MapperTable("clieop", "Id")> _
Public Class tblclieop
    Private da As New DataAccess
    Public List As ClieopVersions
#Region "members"
    Private _id As Int32 = 0
    Private _Createdate As String = ""
    Private _Version As Int32 = 0
#End Region

#Region "Properties"

    <MapperColumn("id", SqlDbType.Int)> _
    Public Property id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    <MapperColumn("Createdate", SqlDbType.DateTime)> _
    Public Property Createdate() As String
        Get
            Return _Createdate
        End Get
        Set(ByVal value As String)
            _Createdate = value
        End Set
    End Property
    <MapperColumn("Version", SqlDbType.Int)> _
    Public Property Version() As Int32
        Get
            Return _Version
        End Get
        Set(ByVal value As Int32)
            _Version = value
        End Set
    End Property
    'Private _Jaar As Integer
    '<MapperColumn("Jaar", SqlDbType.Int)> _
    'Public Property Jaar() As Integer
    '    Get
    '        Return _Jaar
    '    End Get
    '    Set(ByVal value As Integer)
    '        _Jaar = value
    '    End Set
    'End Property
    'Private _Periode As Integer
    '<MapperColumn("Periode", SqlDbType.Int)> _
    'Public Property Periode() As Integer
    '    Get
    '        Return _Periode
    '    End Get
    '    Set(ByVal value As Integer)
    '        _Periode = value
    '    End Set
    'End Property

#End Region
#Region "Functies"
    Public Sub New()

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
    Public Sub Save()
        Try
            If Me.id = Nothing Then
                id = da.InsertString(Me, "clieop", "id", True)
            Else
                da.UpdateString(Me, "clieop", "id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


End Class