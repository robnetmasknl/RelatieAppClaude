<MapperTable("Contributie", "Id")> _
Public Class tblContributie
#Region "members"
    Private _Id As Int32 = 0
    Private _lidsoortid As Int32 = 0
    Private _sedert As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private _mbedrag As Int32 = 0 'maand bedrag
    Private _obedrag As Int32 = 0 'oude bedrag
    Private _mkorting As Int32 = 0 'maand korting
    Private _okorting As Int32 = 0 'oude korting
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
    <MapperColumn("lidsoortid")> _
    Public Property lidsoortid() As Int32
        Get
            Return _lidsoortid
        End Get
        Set(ByVal value As Int32)
            _lidsoortid = value
        End Set
    End Property
    <MapperColumn("sedert")> _
    Public Property sedert() As DateTime
        Get
            Return _sedert
        End Get
        Set(ByVal value As DateTime)
            _sedert = value
        End Set
    End Property
    <MapperColumn("mbedrag")> _
    Public Property mbedrag() As Int32
        Get
            Return _mbedrag
        End Get
        Set(ByVal value As Int32)
            _mbedrag = value
        End Set
    End Property
    <MapperColumn("obedrag")> _
    Public Property obedrag() As Int32
        Get
            Return _obedrag
        End Get
        Set(ByVal value As Int32)
            _obedrag = value
        End Set
    End Property
    <MapperColumn("mkorting")> _
    Public Property mkorting() As Int32
        Get
            Return _mkorting
        End Get
        Set(ByVal value As Int32)
            _mkorting = value
        End Set
    End Property
    <MapperColumn("okorting")> _
    Public Property okorting() As Int32
        Get
            Return _okorting
        End Get
        Set(ByVal value As Int32)
            _okorting = value
        End Set
    End Property

#End Region

End Class