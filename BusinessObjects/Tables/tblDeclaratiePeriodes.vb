Public Class tblDeclaratiePeriodes
#Region "members"
    Private _Id As Int32 = 0
    Private _LidId As Int32 = 0
    Private _PeriodeMnd As Int32 = 0
    Private _PeriodeJaar As Int32 = 0
    Private _Omschrijving As String = String.Empty
    Private _CreatedDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
    Private _Submitted As Boolean = False

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
    <MapperColumn("PeriodeMnd", SqlDbType.int)> _
    Public Property PeriodeMnd() As Int32
        Get
            Return _PeriodeMnd
        End Get
        Set(ByVal value As Int32)
            _PeriodeMnd = Value
        End Set
    End Property
    <MapperColumn("PeriodeJaar", SqlDbType.int)> _
    Public Property PeriodeJaar() As Int32
        Get
            Return _PeriodeJaar
        End Get
        Set(ByVal value As Int32)
            _PeriodeJaar = Value
        End Set
    End Property
    <MapperColumn("Omschrijving", SqlDbType.varchar)> _
    Public Property Omschrijving() As String
        Get
            Return _Omschrijving
        End Get
        Set(ByVal value As String)
            _Omschrijving = Value
        End Set
    End Property
    <MapperColumn("CreatedDate", SqlDbType.datetime)> _
    Public Property CreatedDate() As String
        Get
            Return _CreatedDate
        End Get
        Set(ByVal value As String)
            _CreatedDate = Value
        End Set
    End Property
    <MapperColumn("CreatedBy", SqlDbType.varchar)> _
    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = Value
        End Set
    End Property
    <MapperColumn("Submitted", SqlDbType.bit)>
    Public Property Submitted() As Boolean
        Get
            Return _Submitted
        End Get
        Set(ByVal value As Boolean)
            _Submitted = Value
        End Set
    End Property

    'Private _rowguid As Guid
    '<MapperColumn("rowguid", SqlDbType.UniqueIdentifier)>
    'Public Property rowguid() As Guid
    '    Get
    '        Return _rowguid
    '    End Get
    '    Set(ByVal value As Guid)
    '        _rowguid = value
    '    End Set
    'End Property

#End Region

End Class