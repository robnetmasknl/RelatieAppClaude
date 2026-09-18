
<MapperTable("relaties", "Id")> _
Public Class tblRelaties
#Region "members"
    Private MinDateValue As DateTime = "30-12-1899"
    Private _Id As Int32 = 0
    Private _lidnr As String = "0"
    Private _wnrt As String = String.Empty
    Private _rnr As String = String.Empty
    Private _achternaam As String = String.Empty
    Private _init As String = String.Empty
    Private _tussenvoegsel As String = String.Empty
    Private _titelvoor As String = String.Empty
    Private _titelachter As String = String.Empty
    Private _geslacht As String = String.Empty
    Private _email As String = String.Empty
    Private _postcode As String = String.Empty
    Private _ZipCode As String = String.Empty
    Private _adres As String = String.Empty
    Private _huisnr As String = String.Empty
    Private _huisnrtv As String = String.Empty
    Private _plaats As String = String.Empty
    Private _land As String = String.Empty
    Private _wachtwoord As String = String.Empty
    Private _bevestigd As Boolean = False
    Private _geboortedatum As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _telefoonnummer As String = String.Empty
    Private _telefax As String = String.Empty
    Private _mobiel As String = String.Empty
    'Private _faxwerk As String = String.Empty
    Private _telwerk As String = String.Empty
    Private _emailwerk As String = String.Empty
    Private _bankrek As Int64 = 0
    Private _lidtype As String = String.Empty
    Private _mutdatum As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _mut_door As Int32 = 0
    Private _indatum As String = String.Empty
    Private _eindedatum As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _eindereden As Int32 = 0
    Private _bond As Int32 = 0
    Private _lidmzo As String = String.Empty
    Private _donatie_msf As Double = 0
    Private _aantal_triv As Int32 = 0
    Private _aantal_xr As Int32 = 0
    Private _erelid As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _lid_verdienste As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _zilver As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _goud As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _alv As Boolean = False
    Private _kerstkaart As Boolean = False
    Private _afdeling As Int32 = 0
    Private _plaatsing As Int32 = 0
    Private _kmond As Int32 = 0
    Private _rang As Int32 = 0
    Private _dienstvak As Int32 = 0
    Private _flo_pen As String = String.Empty 'Data.SqlTypes.SqlDateTime.MinValue
    Private _lid_natres As Boolean = False
    Private _veteraan As Boolean = False
    Private _Instantieid As Int32 = 0
    Private _InstantieDatum As String = String.Empty
    Private _InstantieIdVorig As Int32 = 0
    Private _Status As Int32 = 0
    Private _nato As Boolean = False
    Private _Cadeau As String = String.Empty
    Private _CadeauDatum As String = String.Empty
    Private _Samenlevingscontract As String = String.Empty
    Private _Loi As String = String.Empty
    Private _BOM As Boolean = False
    Private _DAP As Boolean = False
    Private _Fase As Integer = 0
    Private _NSKInOut As Int32 = 0
    Private _NSKDatum As String = String.Empty
    Private _m_nsk As Boolean = False

    Private _b_email As String = String.Empty
    Private _b_mobiel As String = String.Empty
    Private _b_telefoon As String = String.Empty
    Private _Nazorg As Int32 = 0
    Private _b_belastingadviseur As Boolean = False
    Private _IBAN As String = String.Empty
    Private _BIC As String = String.Empty
    Private _TrivReden As Int32 = 0
    ' Private _Helpdesk As String = String.Empty
    Private _Sitevizier As Boolean = False
    Private _XrReden As Int32 = 0
    Private _InstroomDatum As String = String.Empty
    Private _LastChangeDate As DateTime
    Private _Notities As String = String.Empty
    Private _Alarmering As Boolean = False
    Private _Rijbewijs75 As Boolean = False
    Private _Rijbewijs75Date As String = String.Empty
    Private _Puzzel As String = String.Empty
    Private _Dienjaar As Boolean = False

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
    <MapperColumn("lidnr")> _
    Public Property lidnr() As String
        Get
            Return _lidnr
        End Get
        Set(ByVal value As String)
            _lidnr = value
        End Set
    End Property
    <MapperColumn("wnrt")> _
    Public Property wnrt() As String
        Get
            Return _wnrt
        End Get
        Set(ByVal value As String)
            _wnrt = value
        End Set
    End Property
    <MapperColumn("rnr")> _
    Public Property rnr() As String
        Get
            Return _rnr
        End Get
        Set(ByVal value As String)
            _rnr = value
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
    <MapperColumn("titelvoor")> _
    Public Property titelvoor() As String
        Get
            Return _titelvoor
        End Get
        Set(ByVal value As String)
            _titelvoor = value
        End Set
    End Property
    <MapperColumn("titelachter")> _
    Public Property titelachter() As String
        Get
            Return _titelachter
        End Get
        Set(ByVal value As String)
            _titelachter = value
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
    <MapperColumn("ZipCode")> _
    Public Property ZipCode() As String
        Get
            Return _ZipCode
        End Get
        Set(ByVal value As String)
            _ZipCode = value
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
    <MapperColumn("telefoonnummer")> _
    Public Property telefoonnummer() As String
        Get
            Return _telefoonnummer
        End Get
        Set(ByVal value As String)
            _telefoonnummer = value
        End Set
    End Property
    <MapperColumn("telefax")> _
    Public Property telefax() As String
        Get
            Return _telefax
        End Get
        Set(ByVal value As String)
            _telefax = value
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
    '<MapperColumn("faxwerk")> _
    'Public Property faxwerk() As String
    '    Get
    '        Return _faxwerk
    '    End Get
    '    Set(ByVal value As String)
    '        _faxwerk = value
    '    End Set
    'End Property
    <MapperColumn("telwerk")> _
    Public Property telwerk() As String
        Get
            Return _telwerk
        End Get
        Set(ByVal value As String)
            _telwerk = value
        End Set
    End Property
    <MapperColumn("emailwerk")> _
    Public Property emailwerk() As String
        Get
            Return _emailwerk
        End Get
        Set(ByVal value As String)
            _emailwerk = value
        End Set
    End Property

    <MapperColumn("bankrek")> _
    Public Property bankrek() As Int64
        Get
            Return _bankrek
        End Get
        Set(ByVal value As Int64)
            _bankrek = value
        End Set
    End Property
    <MapperColumn("lidtype")> _
    Public Property lidtype() As String
        Get
            Return _lidtype
        End Get
        Set(ByVal value As String)
            _lidtype = value
        End Set
    End Property
    <MapperColumn("mutdatum", SqlDbType.DateTime)> _
    Public Property mutdatum() As String
        Get
            Return _mutdatum
        End Get
        Set(ByVal value As String)
            _mutdatum = value
        End Set
    End Property
    <MapperColumn("mut_door")> _
    Public Property mut_door() As Int32
        Get
            Return _mut_door
        End Get
        Set(ByVal value As Int32)
            _mut_door = value
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
    <MapperColumn("eindedatum", SqlDbType.DateTime)> _
    Public Property eindedatum() As String
        Get
            Return _eindedatum
        End Get
        Set(ByVal value As String)
            _eindedatum = value
        End Set
    End Property
    <MapperColumn("eindereden")> _
    Public Property eindereden() As Int32
        Get
            Return _eindereden
        End Get
        Set(ByVal value As Int32)
            _eindereden = value
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
    <MapperColumn("lidmzo")> _
    Public Property lidmzo() As String
        Get
            Return _lidmzo
        End Get
        Set(ByVal value As String)
            _lidmzo = value
        End Set
    End Property
    <MapperColumn("donatie_msf")> _
    Public Property donatie_msf() As Double
        Get
            Return _donatie_msf
        End Get
        Set(ByVal value As Double)
            _donatie_msf = value
        End Set
    End Property
    <MapperColumn("aantal_triv")> _
    Public Property aantal_triv() As Int32
        Get
            Return _aantal_triv
        End Get
        Set(ByVal value As Int32)
            _aantal_triv = value
        End Set
    End Property
    <MapperColumn("aantal_xr")> _
    Public Property aantal_xr() As Int32
        Get
            Return _aantal_xr
        End Get
        Set(ByVal value As Int32)
            _aantal_xr = value
        End Set
    End Property
    <MapperColumn("erelid", SqlDbType.DateTime)> _
    Public Property erelid() As String
        Get
            Return _erelid
        End Get
        Set(ByVal value As String)
            _erelid = value
        End Set
    End Property
    <MapperColumn("lid_verdienste", SqlDbType.DateTime)> _
    Public Property lid_verdienste() As String
        Get
            Return _lid_verdienste
        End Get
        Set(ByVal value As String)
            _lid_verdienste = value
        End Set
    End Property
    <MapperColumn("zilver", SqlDbType.DateTime)> _
    Public Property zilver() As String
        Get
            Return _zilver
        End Get
        Set(ByVal value As String)
            _zilver = value
        End Set
    End Property
    <MapperColumn("goud", SqlDbType.DateTime)> _
    Public Property goud() As String
        Get
            Return _goud
        End Get
        Set(ByVal value As String)
            _goud = value
        End Set
    End Property
    <MapperColumn("alv")> _
    Public Property alv() As Boolean
        Get
            Return _alv
        End Get
        Set(ByVal value As Boolean)
            _alv = value
        End Set
    End Property
    <MapperColumn("kerstkaart")> _
    Public Property kerstkaart() As Boolean
        Get
            Return _kerstkaart
        End Get
        Set(ByVal value As Boolean)
            _kerstkaart = value
        End Set
    End Property
    <MapperColumn("afdeling")> _
    Public Property afdeling() As Int32
        Get
            Return _afdeling
        End Get
        Set(ByVal value As Int32)
            _afdeling = value
        End Set
    End Property
    <MapperColumn("plaatsing")> _
    Public Property plaatsing() As Int32
        Get
            Return _plaatsing
        End Get
        Set(ByVal value As Int32)
            _plaatsing = value
        End Set
    End Property
    <MapperColumn("kmond")> _
    Public Property kmond() As Int32
        Get
            Return _kmond
        End Get
        Set(ByVal value As Int32)
            _kmond = value
        End Set
    End Property
    <MapperColumn("rang")> _
    Public Property rang() As Int32
        Get
            Return _rang
        End Get
        Set(ByVal value As Int32)
            _rang = value
        End Set
    End Property
    <MapperColumn("dienstvak")> _
    Public Property dienstvak() As Int32
        Get
            Return _dienstvak
        End Get
        Set(ByVal value As Int32)
            _dienstvak = value
        End Set
    End Property
    <MapperColumn("flo_pen", SqlDbType.DateTime)> _
    Public Property flo_pen() As String
        Get
            Return _flo_pen
        End Get
        Set(ByVal value As String)
            _flo_pen = value
        End Set
    End Property
    <MapperColumn("lid_natres")> _
    Public Property lid_natres() As Boolean
        Get
            Return _lid_natres
        End Get
        Set(ByVal value As Boolean)
            _lid_natres = value
        End Set
    End Property
    <MapperColumn("veteraan")> _
    Public Property veteraan() As Boolean
        Get
            Return _veteraan
        End Get
        Set(ByVal value As Boolean)
            _veteraan = value
        End Set
    End Property

    <MapperColumn("Instantieid")> _
    Public Property Instantieid() As Int32
        Get
            Return _Instantieid
        End Get
        Set(ByVal value As Int32)
            _Instantieid = value
        End Set
    End Property
    <MapperColumn("InstantieDatum", SqlDbType.DateTime)> _
    Public Property InstantieDatum() As String
        Get
            Return _InstantieDatum
        End Get
        Set(ByVal value As String)
            _InstantieDatum = value
        End Set
    End Property
    <MapperColumn("InstantieIdVorig")> _
    Public Property InstantieIdVorig() As Int32
        Get
            Return _InstantieIdVorig
        End Get
        Set(ByVal value As Int32)
            _InstantieIdVorig = value
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
    <MapperColumn("NATO")> _
    Public Property nato() As Boolean
        Get
            Return _nato
        End Get
        Set(ByVal value As Boolean)
            _nato = value
        End Set
    End Property
    <MapperColumn("Cadeau")> _
Public Property Cadeau() As String
        Get
            Return _Cadeau
        End Get
        Set(ByVal value As String)
            _Cadeau = value
        End Set
    End Property
    <MapperColumn("CadeauDatum", SqlDbType.DateTime)> _
    Public Property CadeauDatum() As String
        Get
            Return _CadeauDatum
        End Get
        Set(ByVal value As String)
            _CadeauDatum = value
        End Set
    End Property
    <MapperColumn("Samenlevingscontract", SqlDbType.DateTime)> _
    Public Property Samenlevingscontract() As String
        Get
            Return _Samenlevingscontract
        End Get
        Set(ByVal value As String)
            _Samenlevingscontract = value
        End Set
    End Property
    <MapperColumn("Loi", SqlDbType.DateTime)> _
    Public Property Loi() As String
        Get
            Return _Loi
        End Get
        Set(ByVal value As String)
            _Loi = value
        End Set
    End Property
    <MapperColumn("BOM")> _
    Public Property BOM() As Boolean
        Get
            Return _BOM
        End Get
        Set(ByVal value As Boolean)
            _BOM = value
        End Set
    End Property
    <MapperColumn("DAP")> _
    Public Property DAP() As Boolean
        Get
            Return _DAP
        End Get
        Set(ByVal value As Boolean)
            _DAP = value
        End Set
    End Property
    <MapperColumn("Fase")> _
    Public Property Fase() As Integer
        Get
            Return _Fase
        End Get
        Set(ByVal value As Integer)
            _Fase = value
        End Set
    End Property
    ''' <summary>
    ''' aan- of afmelden bij NSK via nsk bestand
    ''' NSKInOut: 1 = aanmelden
    ''' NSKInOut: 2 = afmelden
    ''' null of 0 = niets
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <MapperColumn("NSKInOut", SqlDbType.Int)> _
    Public Property NSKInOut() As Int32
        Get
            Return _NSKInOut
        End Get
        Set(ByVal value As Int32)
            _NSKInOut = value
        End Set
    End Property
    ''' <summary>
    ''' Datum voor het NSK aan-/ afmelden.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <MapperColumn("NSKDatum", SqlDbType.DateTime)> _
    Public Property NSKDatum() As String
        Get
            Return _NSKDatum
        End Get
        Set(ByVal value As String)
            _NSKDatum = value
        End Set
    End Property
    ''' <summary>
    ''' veld LeeftijdCheck toegevoegd aan tabel lidsoorten. 
    ''' tijdens de nsk verwerking wordt hier gekeken of de mailing status "m_nsk" moet worden aangezet 
    ''' als de lidleeftijd groter is dan de hier opgegeven leeftijd.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <MapperColumn("m_nsk")> _
    Public Property m_nsk() As Boolean
        Get
            Return _m_nsk
        End Get
        Set(ByVal value As Boolean)
            _m_nsk = value
        End Set
    End Property


    <MapperColumn("b_email", SqlDbType.VarChar)> _
    Public Property b_email() As String
        Get
            Return _b_email
        End Get
        Set(ByVal value As String)
            _b_email = Value
        End Set
    End Property
    <MapperColumn("b_mobiel", SqlDbType.VarChar)> _
    Public Property b_mobiel() As String
        Get
            Return _b_mobiel
        End Get
        Set(ByVal value As String)
            _b_mobiel = Value
        End Set
    End Property
    <MapperColumn("b_telefoon", SqlDbType.VarChar)> _
    Public Property b_telefoon() As String
        Get
            Return _b_telefoon
        End Get
        Set(ByVal value As String)
            _b_telefoon = Value
        End Set
    End Property

    <MapperColumn("Nazorg", SqlDbType.Int)> _
    Public Property Nazorg() As Int32
        Get
            Return _Nazorg
        End Get
        Set(ByVal value As Int32)
            _Nazorg = value
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
    <MapperColumn("IBAN", SqlDbType.VarChar)> _
    Public Property IBAN() As String
        Get
            Return _IBAN
        End Get
        Set(ByVal value As String)
            _IBAN = value
        End Set
    End Property
    <MapperColumn("BIC", SqlDbType.VarChar)> _
    Public Property BIC() As String
        Get
            Return _BIC
        End Get
        Set(ByVal value As String)
            _BIC = value
        End Set
    End Property
    <MapperColumn("TrivReden", SqlDbType.Int)> _
    Public Property TrivReden() As Int32
        Get
            Return _TrivReden
        End Get
        Set(ByVal value As Int32)
            _TrivReden = value
        End Set
    End Property
    <MapperColumn("Sitevizier", SqlDbType.Bit)> _
    Public Property Sitevizier() As Boolean
        Get
            Return _Sitevizier
        End Get
        Set(ByVal value As Boolean)
            _Sitevizier = value
        End Set
    End Property
    <MapperColumn("XrReden", SqlDbType.Int)> _
    Public Property XrReden() As Int32
        Get
            Return _XrReden
        End Get
        Set(ByVal value As Int32)
            _XrReden = value
        End Set
    End Property
    <MapperColumn("InstroomDatum", SqlDbType.DateTime)> _
    Public Property InstroomDatum() As String
        Get
            Return _InstroomDatum
        End Get
        Set(ByVal value As String)
            _InstroomDatum = value
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
    '<MapperColumn("Helpdesk", SqlDbType.Text)> _
    'Public Property Helpdesk() As String
    '    Get
    '        Return _Helpdesk
    '    End Get
    '    Set(ByVal value As String)
    '        _Helpdesk = value
    '    End Set
    'End Property
    <MapperColumn("Notities", SqlDbType.VarChar)>
    Public Property Notities() As String
        Get
            Return _Notities
        End Get
        Set(ByVal value As String)
            _Notities = value
        End Set
    End Property
    <MapperColumn("Alarmering")>
    Public Property Alarmering() As Boolean
        Get
            Return _Alarmering
        End Get
        Set(ByVal value As Boolean)
            _Alarmering = value
        End Set
    End Property
    <MapperColumn("Rijbewijs75")>
    Public Property Rijbewijs75() As Boolean
        Get
            Return _Rijbewijs75
        End Get
        Set(ByVal value As Boolean)
            _Rijbewijs75 = value
        End Set
    End Property

    <MapperColumn("Rijbewijs75Date", SqlDbType.DateTime)>
    Public Property Rijbewijs75Date() As String
        Get
            Return _Rijbewijs75Date
        End Get
        Set(ByVal value As String)
            _Rijbewijs75Date = value
        End Set
    End Property
    <MapperColumn("Dienjaar")>
    Public Property Dienjaar() As Boolean
        Get
            Return _Dienjaar
        End Get
        Set(ByVal value As Boolean)
            _Dienjaar = value
        End Set
    End Property

    <MapperColumn("Puzzel", SqlDbType.DateTime)>
    Public Property Puzzel() As String
        Get
            Return _Puzzel
        End Get
        Set(ByVal value As String)
            _Puzzel = value
        End Set
    End Property
#End Region

End Class