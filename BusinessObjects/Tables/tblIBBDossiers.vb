<MapperTable("IBBDossiers", "Id")> _
Public Class tblIBBDossiers
#Region "members"
    Private _Id As Int32 = 0
    Private _LidId As Int32 = 0
    Private _CreateDate As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private _DossierNr As Int32 = 0
    Private _BehandelaarId As Int32 = 0
    Private _RubriekId As Int32 = 0
    Private _Onderwerp As String = String.Empty
    Private _Opmerkingen As String = String.Empty
    Private _Afgehandeld As Boolean
    Private _AfgehandeldReden As String = String.Empty
    Private _MoederDossier As Int32 = 0
    Private _AlertDate As String = String.Empty
    Private _ExtDeskText As String = String.Empty
    Private _DossierSort As String = String.Empty
    Private _EndDate As String = String.Empty
    Private _IBBGroep As Int32 = 0
    'Private _MutDate As String = String.Empty
    Private _Notities As String = String.Empty
#End Region

#Region "Properties"

    <MapperColumn("Id", SqlDbType.int)> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = Value
        End Set
    End Property
    <MapperColumn("LidId", SqlDbType.int)> _
    Public Property LidId() As Int32
        Get
            Return _LidId
        End Get
        Set(ByVal value As Int32)
            _LidId = Value
        End Set
    End Property
    <MapperColumn("CreateDate", SqlDbType.DateTime2)> _
    Public Property CreateDate() As DateTime
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As DateTime)
            _CreateDate = value
        End Set
    End Property
    <MapperColumn("DossierNr", SqlDbType.Int)> _
    Public Property DossierNr() As Int32
        Get
            Return _DossierNr
        End Get
        Set(ByVal value As Int32)
            _DossierNr = value
        End Set
    End Property
    <MapperColumn("BehandelaarId", SqlDbType.int)> _
    Public Property BehandelaarId() As Int32
        Get
            Return _BehandelaarId
        End Get
        Set(ByVal value As Int32)
            _BehandelaarId = Value
        End Set
    End Property
    <MapperColumn("RubriekId", SqlDbType.int)> _
    Public Property RubriekId() As Int32
        Get
            Return _RubriekId
        End Get
        Set(ByVal value As Int32)
            _RubriekId = Value
        End Set
    End Property
    <MapperColumn("Onderwerp", SqlDbType.varchar)> _
    Public Property Onderwerp() As String
        Get
            Return _Onderwerp
        End Get
        Set(ByVal value As String)
            _Onderwerp = Value
        End Set
    End Property
    <MapperColumn("Opmerkingen", SqlDbType.varchar)> _
    Public Property Opmerkingen() As String
        Get
            Return _Opmerkingen
        End Get
        Set(ByVal value As String)
            _Opmerkingen = Value
        End Set
    End Property
    <MapperColumn("Afgehandeld", SqlDbType.bit)> _
    Public Property Afgehandeld() As Boolean
        Get
            Return _Afgehandeld
        End Get
        Set(ByVal value As Boolean)
            _Afgehandeld = Value
        End Set
    End Property
    <MapperColumn("AfgehandeldReden", SqlDbType.varchar)> _
    Public Property AfgehandeldReden() As String
        Get
            Return _AfgehandeldReden
        End Get
        Set(ByVal value As String)
            _AfgehandeldReden = Value
        End Set
    End Property
    <MapperColumn("MoederDossier", SqlDbType.int)> _
    Public Property MoederDossier() As Int32
        Get
            Return _MoederDossier
        End Get
        Set(ByVal value As Int32)
            _MoederDossier = Value
        End Set
    End Property
    <MapperColumn("AlertDate", SqlDbType.DateTime)> _
    Public Property AlertDate() As String
        Get
            Return _AlertDate
        End Get
        Set(ByVal value As String)
            _AlertDate = value
        End Set
    End Property

    <MapperColumn("ExtDeskText", SqlDbType.VarChar)> _
    Public Property ExtDeskText() As String
        Get
            Return _ExtDeskText
        End Get
        Set(ByVal value As String)
            _ExtDeskText = value
        End Set
    End Property
    <MapperColumn("DossierSort", SqlDbType.VarChar)> _
    Public Property DossierSort() As String
        Get
            Return _DossierSort
        End Get
        Set(ByVal value As String)
            _DossierSort = value
        End Set
    End Property
    <MapperColumn("EndDate", SqlDbType.DateTime)> _
    Public Property EndDate() As String
        Get
            Return _EndDate
        End Get
        Set(ByVal value As String)
            _EndDate = value
        End Set
    End Property
    <MapperColumn("IBBGroep", SqlDbType.Int)> _
    Public Property IBBGroep() As Int32
        Get
            Return _IBBGroep
        End Get
        Set(ByVal value As Int32)
            _IBBGroep = value
        End Set
    End Property
    <MapperColumn("Notities", SqlDbType.VarChar)> _
    Public Property Notities() As String
        Get
            Return _Notities
        End Get
        Set(ByVal value As String)
            _Notities = value
        End Set
    End Property
    '<MapperColumn("MutDate", SqlDbType.DateTime)> _
    'Public Property MutDate() As String
    '    Get
    '        Return _MutDate
    '    End Get
    '    Set(ByVal value As String)
    '        _MutDate = value
    '    End Set
    'End Property
#End Region

End Class