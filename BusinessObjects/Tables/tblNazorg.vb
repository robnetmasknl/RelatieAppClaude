<MapperTable("Nazorg", "Id")> _
Public Class tblNazorg
#Region "members"
    Private _Id As Int32 = 0
    Private _Lidid As Int32 = 0
    Private _Bloemen As Int32 = 0
    Private _Uitvaart As Int32 = 0
    Private _UitvaartAdres1 As String = String.Empty
    Private _UitvaartAdres2 As String = String.Empty
    Private _UitvaartAdres3 As String = String.Empty
    Private _UitvaartAdres4 As String = String.Empty
    Private _LaatsteRang As String = String.Empty
    Private _TrivMelding As Int32 = 0
    Private _NabestaandeRegel1 As String = String.Empty
    Private _NabestaandeRegel2 As String = String.Empty
    Private _NabestaandeRegel3 As String = String.Empty
    Private _NabestaandeRegel4 As String = String.Empty
    Private _NabestaandeTel As String = String.Empty
    Private _Opgebaard As Int32 = 0
    Private _NazorgMedewerker As String = String.Empty

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
    <MapperColumn("Lidid", SqlDbType.Int)> _
    Public Property Lidid() As Int32
        Get
            Return _Lidid
        End Get
        Set(ByVal value As Int32)
            _Lidid = value
        End Set
    End Property
    <MapperColumn("Bloemen", SqlDbType.Int)> _
    Public Property Bloemen() As Int32
        Get
            Return _Bloemen
        End Get
        Set(ByVal value As Int32)
            _Bloemen = value
        End Set
    End Property

    <MapperColumn("Uitvaart", SqlDbType.Int)> _
    Public Property Uitvaart() As Int32
        Get
            Return _Uitvaart
        End Get
        Set(ByVal value As Int32)
            _Uitvaart = value
        End Set
    End Property
    <MapperColumn("UitvaartAdres1", SqlDbType.VarChar)> _
    Public Property UitvaartAdres1() As String
        Get
            Return _UitvaartAdres1
        End Get
        Set(ByVal value As String)
            _UitvaartAdres1 = value
        End Set
    End Property
    <MapperColumn("UitvaartAdres2", SqlDbType.VarChar)> _
    Public Property UitvaartAdres2() As String
        Get
            Return _UitvaartAdres2
        End Get
        Set(ByVal value As String)
            _UitvaartAdres2 = value
        End Set
    End Property
    <MapperColumn("UitvaartAdres3", SqlDbType.VarChar)> _
    Public Property UitvaartAdres3() As String
        Get
            Return _UitvaartAdres3
        End Get
        Set(ByVal value As String)
            _UitvaartAdres3 = value
        End Set
    End Property
    <MapperColumn("UitvaartAdres4", SqlDbType.VarChar)> _
    Public Property UitvaartAdres4() As String
        Get
            Return _UitvaartAdres4
        End Get
        Set(ByVal value As String)
            _UitvaartAdres4 = value
        End Set
    End Property
    <MapperColumn("LaatsteRang", SqlDbType.VarChar)> _
    Public Property LaatsteRang() As String
        Get
            Return _LaatsteRang
        End Get
        Set(ByVal value As String)
            _LaatsteRang = value
        End Set
    End Property
    <MapperColumn("TrivMelding", SqlDbType.Int)> _
    Public Property TrivMelding() As Int32
        Get
            Return _TrivMelding
        End Get
        Set(ByVal value As Int32)
            _TrivMelding = value
        End Set
    End Property
    <MapperColumn("NabestaandeRegel1", SqlDbType.VarChar)> _
    Public Property NabestaandeRegel1() As String
        Get
            Return _NabestaandeRegel1
        End Get
        Set(ByVal value As String)
            _NabestaandeRegel1 = value
        End Set
    End Property
    <MapperColumn("NabestaandeRegel2", SqlDbType.VarChar)> _
    Public Property NabestaandeRegel2() As String
        Get
            Return _NabestaandeRegel2
        End Get
        Set(ByVal value As String)
            _NabestaandeRegel2 = value
        End Set
    End Property
    <MapperColumn("NabestaandeRegel3", SqlDbType.VarChar)> _
    Public Property NabestaandeRegel3() As String
        Get
            Return _NabestaandeRegel3
        End Get
        Set(ByVal value As String)
            _NabestaandeRegel3 = value
        End Set
    End Property
    <MapperColumn("NabestaandeRegel4", SqlDbType.VarChar)> _
    Public Property NabestaandeRegel4() As String
        Get
            Return _NabestaandeRegel4
        End Get
        Set(ByVal value As String)
            _NabestaandeRegel4 = value
        End Set
    End Property
    <MapperColumn("NabestaandeTel", SqlDbType.VarChar)> _
    Public Property NabestaandeTel() As String
        Get
            Return _NabestaandeTel
        End Get
        Set(ByVal value As String)
            _NabestaandeTel = value
        End Set
    End Property

    <MapperColumn("Opgebaard", SqlDbType.Int)> _
    Public Property Opgebaard() As Int32
        Get
            Return _Opgebaard
        End Get
        Set(ByVal value As Int32)
            _Opgebaard = value
        End Set
    End Property
    <MapperColumn("NazorgMedewerker", SqlDbType.VarChar)> _
    Public Property NazorgMedewerker() As String
        Get
            Return _NazorgMedewerker
        End Get
        Set(ByVal value As String)
            _NazorgMedewerker = value
        End Set
    End Property
#End Region

End Class