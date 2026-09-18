Public Class vbm

    Private da As New DataAccess
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub

    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM vbm where id = @id"
            Dim param() As Object = {"@id", GetId}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
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

#Region "members"
    Private _wnr As String = ""
    Private _wnrt As String = ""
    Private _rnr As String = ""
    Private _vl As String = ""
    Private _vz As String = ""
    Private _naam As String = ""
    Private _titelvoor As String = ""
    Private _titelachter As String = ""
    Private _adres As String = ""
    Private _huisnr As String = ""
    Private _huisnrtoev As String = ""
    Private _postcode As String = ""
    Private _plaats As String = ""
    Private _land As String = ""
    Private _telefoon As String = ""
    Private _telefax As String = ""
    Private _email As String = ""
    Private _gebdat As String = ""
    Private _bgrek As String = ""
    Private _geslacht As String = ""
    Private _mutdatum As String = ""
    Private _indatum As String = ""
    Private _eindedatum As String = ""
    Private _eindereden As String = ""
    Private _lidbbt As String = ""
    Private _lidnov As String = ""
    Private _lidmzo As String = ""
    Private _lidkader As String = ""
    Private _donatie As String = ""
    Private _atl_triv As String = ""
    Private _atl_xr As String = ""
    Private _contr_inst As String = ""
    Private _c_instsedert As String = ""
    Private _c_instoud As String = ""
    Private _lidsoort As String = ""
    Private _lidsrtsedert As String = ""
    Private _lidsrtoud As String = ""
    Private _gebruiker As String = ""
    Private _erelid As Boolean
    Private _lid_verdienste As Boolean
    Private _kerstkaart As Boolean
    Private _alv As Boolean
    Private _correspondent As Boolean
    Private _bedrag As String = ""
    Private _zilver_even As Boolean
    Private _zilver_oneven As Boolean
    Private _afdeling As String = ""
    Private _bom As Boolean
    Private _mobiel As String = ""
    Private _tel_werk As String = ""
    Private _fax_werk As String = ""
    Private _spelddrager As Boolean
    Private _origine As String = ""
    Private _plaatsing As String = ""
    Private _kmd As String = ""
    Private _rang As String = ""
    Private _dienstvak As String = ""
    Private _lidvnr As String = ""
    Private _tmpadres As Boolean
    Private _idnr As String = ""
    Private _veteraan As Boolean
    Private _flopen As String = ""
    Private _speld As String = ""
    Private _nskadresaut As String = ""
#End Region

#Region "Properties"

    <MapperColumn("wnr", SqlDbType.NVarChar)> _
    Public Property wnr() As String
        Get
            Return _wnr
        End Get
        Set(ByVal value As String)
            _wnr = Value
        End Set
    End Property
    <MapperColumn("wnrt", SqlDbType.NVarChar)> _
    Public Property wnrt() As String
        Get
            Return _wnrt
        End Get
        Set(ByVal value As String)
            _wnrt = Value
        End Set
    End Property
    <MapperColumn("rnr", SqlDbType.NVarChar)> _
    Public Property rnr() As String
        Get
            Return _rnr
        End Get
        Set(ByVal value As String)
            _rnr = Value
        End Set
    End Property
    <MapperColumn("vl", SqlDbType.NVarChar)> _
    Public Property vl() As String
        Get
            Return _vl
        End Get
        Set(ByVal value As String)
            _vl = Value
        End Set
    End Property
    <MapperColumn("vz", SqlDbType.NVarChar)> _
    Public Property vz() As String
        Get
            Return _vz
        End Get
        Set(ByVal value As String)
            _vz = Value
        End Set
    End Property
    <MapperColumn("naam", SqlDbType.NVarChar)> _
    Public Property naam() As String
        Get
            Return _naam
        End Get
        Set(ByVal value As String)
            _naam = Value
        End Set
    End Property
    <MapperColumn("titelvoor", SqlDbType.NVarChar)> _
    Public Property titelvoor() As String
        Get
            Return _titelvoor
        End Get
        Set(ByVal value As String)
            _titelvoor = Value
        End Set
    End Property
    <MapperColumn("titelachter", SqlDbType.NVarChar)> _
    Public Property titelachter() As String
        Get
            Return _titelachter
        End Get
        Set(ByVal value As String)
            _titelachter = Value
        End Set
    End Property
    <MapperColumn("adres", SqlDbType.NVarChar)> _
    Public Property adres() As String
        Get
            Return _adres
        End Get
        Set(ByVal value As String)
            _adres = Value
        End Set
    End Property
    <MapperColumn("huisnr", SqlDbType.NVarChar)> _
    Public Property huisnr() As String
        Get
            Return _huisnr
        End Get
        Set(ByVal value As String)
            _huisnr = Value
        End Set
    End Property
    <MapperColumn("huisnrtoev", SqlDbType.NVarChar)> _
    Public Property huisnrtoev() As String
        Get
            Return _huisnrtoev
        End Get
        Set(ByVal value As String)
            _huisnrtoev = Value
        End Set
    End Property
    <MapperColumn("postcode", SqlDbType.NVarChar)> _
    Public Property postcode() As String
        Get
            Return _postcode
        End Get
        Set(ByVal value As String)
            _postcode = Value
        End Set
    End Property
    <MapperColumn("plaats", SqlDbType.NVarChar)> _
    Public Property plaats() As String
        Get
            Return _plaats
        End Get
        Set(ByVal value As String)
            _plaats = Value
        End Set
    End Property
    <MapperColumn("land", SqlDbType.NVarChar)> _
    Public Property land() As String
        Get
            Return _land
        End Get
        Set(ByVal value As String)
            _land = Value
        End Set
    End Property
    <MapperColumn("telefoon", SqlDbType.NVarChar)> _
    Public Property telefoon() As String
        Get
            Return _telefoon
        End Get
        Set(ByVal value As String)
            _telefoon = Value
        End Set
    End Property
    <MapperColumn("telefax", SqlDbType.NVarChar)> _
    Public Property telefax() As String
        Get
            Return _telefax
        End Get
        Set(ByVal value As String)
            _telefax = Value
        End Set
    End Property
    <MapperColumn("email", SqlDbType.NVarChar)> _
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = Value
        End Set
    End Property
    <MapperColumn("gebdat", SqlDbType.DateTime)> _
    Public Property gebdat() As String
        Get
            Return _gebdat
        End Get
        Set(ByVal value As String)
            _gebdat = Value
        End Set
    End Property
    <MapperColumn("bgrek", SqlDbType.NVarChar)> _
    Public Property bgrek() As String
        Get
            Return _bgrek
        End Get
        Set(ByVal value As String)
            _bgrek = Value
        End Set
    End Property
    <MapperColumn("geslacht", SqlDbType.NVarChar)> _
    Public Property geslacht() As String
        Get
            Return _geslacht
        End Get
        Set(ByVal value As String)
            _geslacht = Value
        End Set
    End Property
    <MapperColumn("mutdatum", SqlDbType.DateTime)> _
    Public Property mutdatum() As String
        Get
            Return _mutdatum
        End Get
        Set(ByVal value As String)
            _mutdatum = Value
        End Set
    End Property
    <MapperColumn("indatum", SqlDbType.DateTime)> _
    Public Property indatum() As String
        Get
            Return _indatum
        End Get
        Set(ByVal value As String)
            _indatum = Value
        End Set
    End Property
    <MapperColumn("eindedatum", SqlDbType.DateTime)> _
    Public Property eindedatum() As String
        Get
            Return _eindedatum
        End Get
        Set(ByVal value As String)
            _eindedatum = Value
        End Set
    End Property
    <MapperColumn("eindereden", SqlDbType.NVarChar)> _
    Public Property eindereden() As String
        Get
            Return _eindereden
        End Get
        Set(ByVal value As String)
            _eindereden = Value
        End Set
    End Property
    <MapperColumn("lidbbt", SqlDbType.NVarChar)> _
    Public Property lidbbt() As String
        Get
            Return _lidbbt
        End Get
        Set(ByVal value As String)
            _lidbbt = Value
        End Set
    End Property
    <MapperColumn("lidnov", SqlDbType.NVarChar)> _
    Public Property lidnov() As String
        Get
            Return _lidnov
        End Get
        Set(ByVal value As String)
            _lidnov = Value
        End Set
    End Property
    <MapperColumn("lidmzo", SqlDbType.NVarChar)> _
    Public Property lidmzo() As String
        Get
            Return _lidmzo
        End Get
        Set(ByVal value As String)
            _lidmzo = Value
        End Set
    End Property
    <MapperColumn("lidkader", SqlDbType.NVarChar)> _
    Public Property lidkader() As String
        Get
            Return _lidkader
        End Get
        Set(ByVal value As String)
            _lidkader = Value
        End Set
    End Property
    <MapperColumn("donatie", SqlDbType.NVarChar)> _
    Public Property donatie() As String
        Get
            Return _donatie
        End Get
        Set(ByVal value As String)
            _donatie = Value
        End Set
    End Property
    <MapperColumn("atl_triv", SqlDbType.NVarChar)> _
    Public Property atl_triv() As String
        Get
            Return _atl_triv
        End Get
        Set(ByVal value As String)
            _atl_triv = Value
        End Set
    End Property
    <MapperColumn("atl_xr", SqlDbType.NVarChar)> _
    Public Property atl_xr() As String
        Get
            Return _atl_xr
        End Get
        Set(ByVal value As String)
            _atl_xr = Value
        End Set
    End Property
    <MapperColumn("contr_inst", SqlDbType.NVarChar)> _
    Public Property contr_inst() As String
        Get
            Return _contr_inst
        End Get
        Set(ByVal value As String)
            _contr_inst = Value
        End Set
    End Property
    <MapperColumn("c_instsedert", SqlDbType.NVarChar)> _
    Public Property c_instsedert() As String
        Get
            Return _c_instsedert
        End Get
        Set(ByVal value As String)
            _c_instsedert = Value
        End Set
    End Property
    <MapperColumn("c_instoud", SqlDbType.NVarChar)> _
    Public Property c_instoud() As String
        Get
            Return _c_instoud
        End Get
        Set(ByVal value As String)
            _c_instoud = Value
        End Set
    End Property
    <MapperColumn("lidsoort", SqlDbType.NVarChar)> _
    Public Property lidsoort() As String
        Get
            Return _lidsoort
        End Get
        Set(ByVal value As String)
            _lidsoort = Value
        End Set
    End Property
    <MapperColumn("lidsrtsedert", SqlDbType.NVarChar)> _
    Public Property lidsrtsedert() As String
        Get
            Return _lidsrtsedert
        End Get
        Set(ByVal value As String)
            _lidsrtsedert = Value
        End Set
    End Property
    <MapperColumn("lidsrtoud", SqlDbType.NVarChar)> _
    Public Property lidsrtoud() As String
        Get
            Return _lidsrtoud
        End Get
        Set(ByVal value As String)
            _lidsrtoud = Value
        End Set
    End Property
    <MapperColumn("gebruiker", SqlDbType.NVarChar)> _
    Public Property gebruiker() As String
        Get
            Return _gebruiker
        End Get
        Set(ByVal value As String)
            _gebruiker = Value
        End Set
    End Property
    <MapperColumn("erelid", SqlDbType.Bit)> _
    Public Property erelid() As Boolean
        Get
            Return _erelid
        End Get
        Set(ByVal value As Boolean)
            _erelid = Value
        End Set
    End Property
    <MapperColumn("lid_verdienste", SqlDbType.Bit)> _
    Public Property lid_verdienste() As Boolean
        Get
            Return _lid_verdienste
        End Get
        Set(ByVal value As Boolean)
            _lid_verdienste = Value
        End Set
    End Property
    <MapperColumn("kerstkaart", SqlDbType.Bit)> _
    Public Property kerstkaart() As Boolean
        Get
            Return _kerstkaart
        End Get
        Set(ByVal value As Boolean)
            _kerstkaart = Value
        End Set
    End Property
    <MapperColumn("alv", SqlDbType.Bit)> _
    Public Property alv() As Boolean
        Get
            Return _alv
        End Get
        Set(ByVal value As Boolean)
            _alv = Value
        End Set
    End Property
    <MapperColumn("correspondent", SqlDbType.Bit)> _
    Public Property correspondent() As Boolean
        Get
            Return _correspondent
        End Get
        Set(ByVal value As Boolean)
            _correspondent = Value
        End Set
    End Property
    <MapperColumn("bedrag", SqlDbType.NVarChar)> _
    Public Property bedrag() As String
        Get
            Return _bedrag
        End Get
        Set(ByVal value As String)
            _bedrag = Value
        End Set
    End Property
    <MapperColumn("zilver_even", SqlDbType.Bit)> _
    Public Property zilver_even() As Boolean
        Get
            Return _zilver_even
        End Get
        Set(ByVal value As Boolean)
            _zilver_even = Value
        End Set
    End Property
    <MapperColumn("zilver_oneven", SqlDbType.Bit)> _
    Public Property zilver_oneven() As Boolean
        Get
            Return _zilver_oneven
        End Get
        Set(ByVal value As Boolean)
            _zilver_oneven = Value
        End Set
    End Property
    <MapperColumn("afdeling", SqlDbType.NVarChar)> _
    Public Property afdeling() As String
        Get
            Return _afdeling
        End Get
        Set(ByVal value As String)
            _afdeling = Value
        End Set
    End Property
    <MapperColumn("bom", SqlDbType.Bit)> _
    Public Property bom() As Boolean
        Get
            Return _bom
        End Get
        Set(ByVal value As Boolean)
            _bom = Value
        End Set
    End Property
    <MapperColumn("mobiel", SqlDbType.NVarChar)> _
    Public Property mobiel() As String
        Get
            Return _mobiel
        End Get
        Set(ByVal value As String)
            _mobiel = Value
        End Set
    End Property
    <MapperColumn("tel_werk", SqlDbType.NVarChar)> _
    Public Property tel_werk() As String
        Get
            Return _tel_werk
        End Get
        Set(ByVal value As String)
            _tel_werk = Value
        End Set
    End Property
    <MapperColumn("fax_werk", SqlDbType.NVarChar)> _
    Public Property fax_werk() As String
        Get
            Return _fax_werk
        End Get
        Set(ByVal value As String)
            _fax_werk = Value
        End Set
    End Property
    <MapperColumn("spelddrager", SqlDbType.Bit)> _
    Public Property spelddrager() As Boolean
        Get
            Return _spelddrager
        End Get
        Set(ByVal value As Boolean)
            _spelddrager = Value
        End Set
    End Property
    <MapperColumn("origine", SqlDbType.NVarChar)> _
    Public Property origine() As String
        Get
            Return _origine
        End Get
        Set(ByVal value As String)
            _origine = Value
        End Set
    End Property
    <MapperColumn("plaatsing", SqlDbType.NVarChar)> _
    Public Property plaatsing() As String
        Get
            Return _plaatsing
        End Get
        Set(ByVal value As String)
            _plaatsing = Value
        End Set
    End Property
    <MapperColumn("kmd", SqlDbType.NVarChar)> _
    Public Property kmd() As String
        Get
            Return _kmd
        End Get
        Set(ByVal value As String)
            _kmd = Value
        End Set
    End Property
    <MapperColumn("rang", SqlDbType.NVarChar)> _
    Public Property rang() As String
        Get
            Return _rang
        End Get
        Set(ByVal value As String)
            _rang = Value
        End Set
    End Property
    <MapperColumn("dienstvak", SqlDbType.NVarChar)> _
    Public Property dienstvak() As String
        Get
            Return _dienstvak
        End Get
        Set(ByVal value As String)
            _dienstvak = Value
        End Set
    End Property
    <MapperColumn("lidvnr", SqlDbType.NVarChar)> _
    Public Property lidvnr() As String
        Get
            Return _lidvnr
        End Get
        Set(ByVal value As String)
            _lidvnr = Value
        End Set
    End Property
    <MapperColumn("tmpadres", SqlDbType.Bit)> _
    Public Property tmpadres() As Boolean
        Get
            Return _tmpadres
        End Get
        Set(ByVal value As Boolean)
            _tmpadres = Value
        End Set
    End Property
    <MapperColumn("idnr", SqlDbType.NVarChar)> _
    Public Property idnr() As String
        Get
            Return _idnr
        End Get
        Set(ByVal value As String)
            _idnr = Value
        End Set
    End Property
    <MapperColumn("veteraan", SqlDbType.Bit)> _
    Public Property veteraan() As Boolean
        Get
            Return _veteraan
        End Get
        Set(ByVal value As Boolean)
            _veteraan = Value
        End Set
    End Property
    <MapperColumn("flopen", SqlDbType.DateTime)> _
    Public Property flopen() As String
        Get
            Return _flopen
        End Get
        Set(ByVal value As String)
            _flopen = Value
        End Set
    End Property
    <MapperColumn("speld", SqlDbType.DateTime)> _
    Public Property speld() As String
        Get
            Return _speld
        End Get
        Set(ByVal value As String)
            _speld = Value
        End Set
    End Property
    <MapperColumn("nskadresaut", SqlDbType.NVarChar)> _
    Public Property nskadresaut() As String
        Get
            Return _nskadresaut
        End Get
        Set(ByVal value As String)
            _nskadresaut = Value
        End Set
    End Property

#End Region



End Class