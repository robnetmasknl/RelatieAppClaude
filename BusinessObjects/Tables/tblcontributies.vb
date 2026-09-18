<MapperTable("contributies", "Id")> _
Public Class tblcontributies
#Region "members"
    Private _Id As Int32 = 0
    Private _jaar As String = String.Empty
    Private _lidid As Int32 = 0
    Private _jan As Double = 0
    Private _feb As Double = 0
    Private _mar As Double = 0
    Private _apr As Double = 0
    Private _mei As Double = 0
    Private _jun As Double = 0
    Private _jul As Double = 0
    Private _aug As Double = 0
    Private _sep As Double = 0
    Private _okt As Double = 0
    Private _nov As Double = 0
    Private _dec As Double = 0
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
    <MapperColumn("jaar")> _
    Public Property jaar() As String
        Get
            Return _jaar
        End Get
        Set(ByVal value As String)
            _jaar = value
        End Set
    End Property
    <MapperColumn("lidid")> _
    Public Property lidid() As Int32
        Get
            Return _lidid
        End Get
        Set(ByVal value As Int32)
            _lidid = value
        End Set
    End Property
    <MapperColumn("jan")> _
    Public Property jan() As Double
        Get
            Return _jan
        End Get
        Set(ByVal value As Double)
            _jan = value
        End Set
    End Property
    <MapperColumn("feb")> _
    Public Property feb() As Double
        Get
            Return _feb
        End Get
        Set(ByVal value As Double)
            _feb = value
        End Set
    End Property
    <MapperColumn("mar")> _
    Public Property mar() As Double
        Get
            Return _mar
        End Get
        Set(ByVal value As Double)
            _mar = value
        End Set
    End Property
    <MapperColumn("apr")> _
    Public Property apr() As Double
        Get
            Return _apr
        End Get
        Set(ByVal value As Double)
            _apr = value
        End Set
    End Property
    <MapperColumn("mei")> _
    Public Property mei() As Double
        Get
            Return _mei
        End Get
        Set(ByVal value As Double)
            _mei = value
        End Set
    End Property
    <MapperColumn("jun")> _
    Public Property jun() As Double
        Get
            Return _jun
        End Get
        Set(ByVal value As Double)
            _jun = value
        End Set
    End Property
    <MapperColumn("jul")> _
    Public Property jul() As Double
        Get
            Return _jul
        End Get
        Set(ByVal value As Double)
            _jul = value
        End Set
    End Property
    <MapperColumn("aug")> _
    Public Property aug() As Double
        Get
            Return _aug
        End Get
        Set(ByVal value As Double)
            _aug = value
        End Set
    End Property
    <MapperColumn("sep")> _
    Public Property sep() As Double
        Get
            Return _sep
        End Get
        Set(ByVal value As Double)
            _sep = value
        End Set
    End Property
    <MapperColumn("okt")> _
    Public Property okt() As Double
        Get
            Return _okt
        End Get
        Set(ByVal value As Double)
            _okt = value
        End Set
    End Property
    <MapperColumn("nov")> _
    Public Property nov() As Double
        Get
            Return _nov
        End Get
        Set(ByVal value As Double)
            _nov = value
        End Set
    End Property
    <MapperColumn("dec")> _
    Public Property dec() As Double
        Get
            Return _dec
        End Get
        Set(ByVal value As Double)
            _dec = value
        End Set
    End Property

#End Region

End Class