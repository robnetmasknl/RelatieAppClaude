<MapperTable("BlokTypes", "Id")> _
Public Class tblBlokTypes
    Private _Id As Int32 = 0
    Private _tempnaam As String = ""
    Private _aantal As Int32 = 0
    Private _aanvang As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private _tijdsduur As Int32 = 0
    Private _pauze As Int32 = 0
    Private _isMachtiging As Boolean = False

    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("tempnaam")> _
    Public Property tempnaam() As String
        Get
            Return _tempnaam
        End Get
        Set(ByVal value As String)
            _tempnaam = value
        End Set
    End Property
    <MapperColumn("aantal")> _
    Public Property aantal() As Int32
        Get
            Return _aantal
        End Get
        Set(ByVal value As Int32)
            _aantal = value
        End Set
    End Property
    <MapperColumn("aanvang")> _
    Public Property aanvang() As DateTime
        Get
            Return _aanvang
        End Get
        Set(ByVal value As DateTime)
            _aanvang = value
        End Set
    End Property
    <MapperColumn("tijdsduur")> _
    Public Property tijdsduur() As Int32
        Get
            Return _tijdsduur
        End Get
        Set(ByVal value As Int32)
            _tijdsduur = value
        End Set
    End Property
    <MapperColumn("pauze")>
    Public Property pauze() As Int32
        Get
            Return _pauze
        End Get
        Set(ByVal value As Int32)
            _pauze = value
        End Set
    End Property
    <MapperColumn("IsMachtiging")>
    Public Property IsMachtiging() As Boolean
        Get
            Return _isMachtiging
        End Get
        Set(ByVal value As Boolean)
            _isMachtiging = value
        End Set
    End Property

End Class
