<MapperTable("fsoort", "Id")> _
Public Class tblfsoort
#Region "members"
    Private _Id As Int32 = 0
    Private _soort As String = ""
    Private _omschrijving As String = ""
    Private _colorargb As Int32 = 0
#End Region

#Region "Properties"

    <MapperColumn("Id", SqlDbType.Int)> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("soort", SqlDbType.VarChar)> _
    Public Property soort() As String
        Get
            Return _soort
        End Get
        Set(ByVal value As String)
            _soort = value
        End Set
    End Property
    <MapperColumn("omschrijving", SqlDbType.VarChar)> _
    Public Property omschrijving() As String
        Get
            Return _omschrijving
        End Get
        Set(ByVal value As String)
            _omschrijving = value
        End Set
    End Property
    <MapperColumn("colorargb", SqlDbType.Int)> _
    Public Property colorargb() As Int32
        Get
            Return _colorargb
        End Get
        Set(ByVal value As Int32)
            _colorargb = value
        End Set
    End Property

#End Region

End Class