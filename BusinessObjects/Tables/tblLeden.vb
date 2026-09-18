<MapperTable("Leden_", "Id")> _
Public Class tblLeden

    Private _Id As Int32 = 0
    Private _lidnr As String = "0"
    Private _wnrt As String = String.Empty
    Private _rnr As String = String.Empty
    Private _achternaam As String = String.Empty
    Private _init As String = String.Empty
    Private _tussenvoegsel As String = String.Empty
    Private _geslacht As String = String.Empty
    Private _email As String = String.Empty
    Private _postcode As String = String.Empty
    Private _adres As String = String.Empty
    Private _huisnr As String = String.Empty
    Private _huisnrtv As String = String.Empty
    Private _plaats As String = String.Empty
    Private _land As String = String.Empty
    Private _wachtwoord As String = String.Empty
    Private _bevestigd As Boolean = False
    Private _geboortedatum As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _indatum As String = String.Empty

    Private _telefoonnummer As String = String.Empty
    Private _mobiel As String = String.Empty
    Private _bond As Int32 = 0
    Private _Status As Int32 = 0

    'Private _alv As Boolean = False
    'Private _kerstkaart As Boolean = False
    'Private _lid_natres As Boolean = False
    'Private _veteraan As Boolean = False
    'Private _nato As Boolean = False
    'Private _BOM As Boolean = False
    'Private _DAP As Boolean = False

    Private _b_email As String = String.Empty
    Private _b_mobiel As String = String.Empty
    Private _b_telefoon As String = String.Empty
    Private _b_belastingadviseur As Boolean = False
    Private _LastChangeDate As DateTime


    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("lidnr")> _
    Public Property lidnr() As String
        Get
            Return _lidnr
        End Get
        Set(ByVal value As String)
            _lidnr = value
        End Set
    End Property
    <MapperColumn("achternaam")> _
    Public Property achternaam() As String
        Get
            Return _achternaam
        End Get
        Set(ByVal value As String)
            _achternaam = value
        End Set
    End Property
    <MapperColumn("init")> _
    Public Property init() As String
        Get
            Return _init
        End Get
        Set(ByVal value As String)
            _init = value
        End Set
    End Property
    <MapperColumn("tussenvoegsel")> _
    Public Property tussenvoegsel() As String
        Get
            Return _tussenvoegsel
        End Get
        Set(ByVal value As String)
            _tussenvoegsel = value
        End Set
    End Property
    <MapperColumn("geslacht")> _
    Public Property geslacht() As String
        Get
            Return _geslacht
        End Get
        Set(ByVal value As String)
            _geslacht = value
        End Set
    End Property
    <MapperColumn("email")> _
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    <MapperColumn("postcode")> _
    Public Property postcode() As String
        Get
            Return _postcode
        End Get
        Set(ByVal value As String)
            _postcode = value
        End Set
    End Property
    <MapperColumn("adres")> _
    Public Property adres() As String
        Get
            Return _adres
        End Get
        Set(ByVal value As String)
            _adres = value
        End Set
    End Property
    <MapperColumn("huisnr")> _
    Public Property huisnr() As String
        Get
            Return _huisnr
        End Get
        Set(ByVal value As String)
            _huisnr = value
        End Set
    End Property
    <MapperColumn("huisnrtv")> _
    Public Property huisnrtv() As String
        Get
            Return _huisnrtv
        End Get
        Set(ByVal value As String)
            _huisnrtv = value
        End Set
    End Property
    <MapperColumn("plaats")> _
    Public Property plaats() As String
        Get
            Return _plaats
        End Get
        Set(ByVal value As String)
            _plaats = value
        End Set
    End Property
    <MapperColumn("land")> _
    Public Property land() As String
        Get
            Return _land
        End Get
        Set(ByVal value As String)
            _land = value
        End Set
    End Property
    <MapperColumn("wachtwoord")> _
    Public Property wachtwoord() As String
        Get
            Return _wachtwoord
        End Get
        Set(ByVal value As String)
            _wachtwoord = value
        End Set
    End Property
    <MapperColumn("bevestigd")> _
    Public Property bevestigd() As Boolean
        Get
            Return _bevestigd
        End Get
        Set(ByVal value As Boolean)
            _bevestigd = value
        End Set
    End Property
    <MapperColumn("geboortedatum", SqlDbType.DateTime)> _
    Public Property geboortedatum() As String
        Get
            Return _geboortedatum
        End Get
        Set(ByVal value As String)
            _geboortedatum = value
        End Set
    End Property
    <MapperColumn("indatum", SqlDbType.DateTime)> _
    Public Property indatum() As String
        Get
            Return _indatum
        End Get
        Set(ByVal value As String)
            'value = New DateTime(value.Year, value.Month, value.Day)
            _indatum = value
        End Set
    End Property
    <MapperColumn("telefoonnummer")> _
    Public Property telefoonnummer() As String
        Get
            Return _telefoonnummer
        End Get
        Set(ByVal value As String)
            _telefoonnummer = value
        End Set
    End Property
    <MapperColumn("mobiel")> _
    Public Property mobiel() As String
        Get
            Return _mobiel
        End Get
        Set(ByVal value As String)
            _mobiel = value
        End Set
    End Property
    <MapperColumn("bond")> _
     Public Property bond() As Int32
        Get
            Return _bond
        End Get
        Set(ByVal value As Int32)
            _bond = value
        End Set
    End Property

    <MapperColumn("Status")> _
Public Property Status() As Int32
        Get
            Return _Status
        End Get
        Set(ByVal value As Int32)
            _Status = value
        End Set
    End Property
    '    <MapperColumn("alv")> _
    'Public Property alv() As Boolean
    '        Get
    '            Return _alv
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _alv = value
    '        End Set
    '    End Property
    '    <MapperColumn("kerstkaart")> _
    'Public Property kerstkaart() As Boolean
    '        Get
    '            Return _kerstkaart
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _kerstkaart = value
    '        End Set
    '    End Property
    '    <MapperColumn("lid_natres")> _
    'Public Property lid_natres() As Boolean
    '        Get
    '            Return _lid_natres
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _lid_natres = value
    '        End Set
    '    End Property
    '    <MapperColumn("veteraan")> _
    '    Public Property veteraan() As Boolean
    '        Get
    '            Return _veteraan
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _veteraan = value
    '        End Set
    '    End Property
    '    <MapperColumn("nato")> _
    'Public Property nato() As Boolean
    '        Get
    '            Return _nato
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _nato = value
    '        End Set
    '    End Property
    '    <MapperColumn("BOM")> _
    'Public Property BOM() As Boolean
    '        Get
    '            Return _BOM
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _BOM = value
    '        End Set
    '    End Property
    '    <MapperColumn("DAP")> _
    '    Public Property DAP() As Boolean
    '        Get
    '            Return _DAP
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _DAP = value
    '        End Set
    '    End Property

    <MapperColumn("b_email", SqlDbType.VarChar)> _
    Public Property b_email() As String
        Get
            Return _b_email
        End Get
        Set(ByVal value As String)
            _b_email = value
        End Set
    End Property
    <MapperColumn("b_mobiel", SqlDbType.VarChar)> _
    Public Property b_mobiel() As String
        Get
            Return _b_mobiel
        End Get
        Set(ByVal value As String)
            _b_mobiel = value
        End Set
    End Property
    <MapperColumn("b_telefoon", SqlDbType.VarChar)> _
    Public Property b_telefoon() As String
        Get
            Return _b_telefoon
        End Get
        Set(ByVal value As String)
            _b_telefoon = value
        End Set
    End Property
    <MapperColumn("b_belastingadviseur", SqlDbType.Bit)> _
    Public Property b_belastingadviseur() As Boolean
        Get
            Return _b_belastingadviseur
        End Get
        Set(ByVal value As Boolean)
            _b_belastingadviseur = value
        End Set
    End Property
    <MapperColumn("LastChangeDate", SqlDbType.DateTime)> _
    Public Property LastChangeDate() As DateTime
        Get
            Return _LastChangeDate
        End Get
        Set(ByVal value As DateTime)
            _LastChangeDate = value
        End Set
    End Property
End Class
