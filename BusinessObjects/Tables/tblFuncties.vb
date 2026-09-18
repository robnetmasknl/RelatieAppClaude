<MapperTable("Functies", "Id")> _
Public Class tblFuncties
#Region "members"
    Private _Id As Int32 = 0
    Private _lidid As Int32 = 0
    Private _functie As Int32 = 0
    Private _adviesgroep As Int32 = 0
    Private _orgaan As Int32 = 0
    Private _datumin As String = String.Empty
    Private _afdeling As Int32 = 0
    Private _datumuit As String = String.Empty
    Private _Toon As Boolean = False
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
    <MapperColumn("lidid", SqlDbType.Int)> _
    Public Property lidid() As Int32
        Get
            Return _lidid
        End Get
        Set(ByVal value As Int32)
            _lidid = value
        End Set
    End Property
    <MapperColumn("functie", SqlDbType.Int)> _
    Public Property functie() As Int32
        Get
            Return _functie
        End Get
        Set(ByVal value As Int32)
            _functie = value
        End Set
    End Property
    <MapperColumn("adviesgroep", SqlDbType.Int)> _
    Public Property adviesgroep() As Int32
        Get
            Return _adviesgroep
        End Get
        Set(ByVal value As Int32)
            _adviesgroep = value
        End Set
    End Property
    <MapperColumn("orgaan", SqlDbType.Int)> _
    Public Property orgaan() As Int32
        Get
            Return _orgaan
        End Get
        Set(ByVal value As Int32)
            _orgaan = value
        End Set
    End Property
    <MapperColumn("datumin", SqlDbType.DateTime)> _
    Public Property datumin() As String
        Get
            Return _datumin
        End Get
        Set(ByVal value As String)
            _datumin = value
        End Set
    End Property
    <MapperColumn("datumuit", SqlDbType.DateTime)> _
    Public Property datumuit() As String
        Get
            Return _datumuit
        End Get
        Set(ByVal value As String)
            _datumuit = value
        End Set
    End Property
    <MapperColumn("afdeling", SqlDbType.Int)> _
    Public Property afdeling() As Int32
        Get
            Return _afdeling
        End Get
        Set(ByVal value As Int32)
            _afdeling = value
        End Set
    End Property
    <MapperColumn("toon")> _
    Public Property Toon() As Boolean
        Get
            Return _Toon
        End Get
        Set(ByVal value As Boolean)
            _Toon = value
        End Set
    End Property

#End Region

End Class