<MapperTable("Leden_", "Id")>
Public Class tblWebLid

    Private _Id As Int32 = 0
    Private _lidnr As String = "0"

    Private _achternaam As String = String.Empty
    Private _init As String = String.Empty
    Private _tussenvoegsel As String = String.Empty
    Private _geslacht As String = String.Empty
    Private _bankrek As Int64 = 0

    Private _wachtwoord As String = String.Empty
    Private _bevestigd As Boolean = False
    Private _geboortedatum As String = String.Empty
    Private _indatum As String = String.Empty
    Private _eindedatum As String = String.Empty

    Private _bond As Int32 = 0
    Private _Status As Int32 = 0

    Private _b_email As String = String.Empty
    Private _b_mobiel As String = String.Empty
    Private _b_telefoon As String = String.Empty
    Private _b_belastingadviseur As Boolean = False

    Private _LastChangeDate As DateTime


    <MapperColumn("Id")>
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("lidnr")>
    Public Property lidnr() As String
        Get
            Return _lidnr
        End Get
        Set(ByVal value As String)
            _lidnr = value
        End Set
    End Property
    <MapperColumn("achternaam")>
    Public Property achternaam() As String
        Get
            Return _achternaam
        End Get
        Set(ByVal value As String)
            _achternaam = value
        End Set
    End Property
    <MapperColumn("init")>
    Public Property init() As String
        Get
            Return _init
        End Get
        Set(ByVal value As String)
            _init = value
        End Set
    End Property
    <MapperColumn("tussenvoegsel")>
    Public Property tussenvoegsel() As String
        Get
            Return _tussenvoegsel
        End Get
        Set(ByVal value As String)
            _tussenvoegsel = value
        End Set
    End Property
    <MapperColumn("geslacht")>
    Public Property geslacht() As String
        Get
            Return _geslacht
        End Get
        Set(ByVal value As String)
            _geslacht = value
        End Set
    End Property
    <MapperColumn("bankrek")>
    Public Property bankrek() As Int64
        Get
            Return _bankrek
        End Get
        Set(ByVal value As Int64)
            _bankrek = value
        End Set
    End Property
    <MapperColumn("wachtwoord")>
    Public Property wachtwoord() As String
        Get
            Return _wachtwoord
        End Get
        Set(ByVal value As String)
            _wachtwoord = value
        End Set
    End Property
    <MapperColumn("bevestigd")>
    Public Property bevestigd() As Boolean
        Get
            Return _bevestigd
        End Get
        Set(ByVal value As Boolean)
            _bevestigd = value
        End Set
    End Property
    <MapperColumn("geboortedatum", SqlDbType.DateTime)>
    Public Property geboortedatum() As String
        Get
            Return _geboortedatum
        End Get
        Set(ByVal value As String)
            _geboortedatum = value
        End Set
    End Property
    <MapperColumn("indatum", SqlDbType.DateTime)>
    Public Property indatum() As String
        Get
            Return _indatum
        End Get
        Set(ByVal value As String)
            'value = New DateTime(value.Year, value.Month, value.Day)
            _indatum = value
        End Set
    End Property

    <MapperColumn("eindedatum", SqlDbType.DateTime)>
    Public Property eindedatum() As String
        Get
            Return _eindedatum
        End Get
        Set(ByVal value As String)
            _eindedatum = value
        End Set
    End Property
    <MapperColumn("bond")>
    Public Property bond() As Int32
        Get
            Return _bond
        End Get
        Set(ByVal value As Int32)
            _bond = value
        End Set
    End Property

    <MapperColumn("Status")>
    Public Property Status() As Int32
        Get
            Return _Status
        End Get
        Set(ByVal value As Int32)
            _Status = value
        End Set
    End Property

    <MapperColumn("b_email", SqlDbType.VarChar)>
    Public Property b_email() As String
        Get
            Return _b_email
        End Get
        Set(ByVal value As String)
            _b_email = value
        End Set
    End Property
    <MapperColumn("b_mobiel", SqlDbType.VarChar)>
    Public Property b_mobiel() As String
        Get
            Return _b_mobiel
        End Get
        Set(ByVal value As String)
            _b_mobiel = value
        End Set
    End Property
    <MapperColumn("b_telefoon", SqlDbType.VarChar)>
    Public Property b_telefoon() As String
        Get
            Return _b_telefoon
        End Get
        Set(ByVal value As String)
            _b_telefoon = value
        End Set
    End Property
    <MapperColumn("b_belastingadviseur", SqlDbType.Bit)>
    Public Property b_belastingadviseur() As Boolean
        Get
            Return _b_belastingadviseur
        End Get
        Set(ByVal value As Boolean)
            _b_belastingadviseur = value
        End Set
    End Property
    <MapperColumn("LastChangeDate", SqlDbType.DateTime)>
    Public Property LastChangeDate() As DateTime
        Get
            Return _LastChangeDate
        End Get
        Set(ByVal value As DateTime)
            _LastChangeDate = value
        End Set
    End Property
End Class
