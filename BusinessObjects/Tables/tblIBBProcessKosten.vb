Public Class tblIBBProcessKosten
#Region "members"
    Private _Id As Int32 = 0
    Private _DossierId As Int32 = 0
    Private _IBBFaseId As Int32 = 0
    Private _Amount As Decimal
    Private _DateLetter As String = String.Empty
    Private _DateReceived As String = String.Empty
    Private _Details As String = String.Empty
    Private _CreateDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
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
    <MapperColumn("DossierId", SqlDbType.int)> _
    Public Property DossierId() As Int32
        Get
            Return _DossierId
        End Get
        Set(ByVal value As Int32)
            _DossierId = Value
        End Set
    End Property
    <MapperColumn("IBBFaseId", SqlDbType.int)> _
    Public Property IBBFaseId() As Int32
        Get
            Return _IBBFaseId
        End Get
        Set(ByVal value As Int32)
            _IBBFaseId = Value
        End Set
    End Property
    <MapperColumn("Amount", SqlDbType.decimal)> _
    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = Value
        End Set
    End Property
    <MapperColumn("DateLetter", SqlDbType.datetime)> _
    Public Property DateLetter() As String
        Get
            Return _DateLetter
        End Get
        Set(ByVal value As String)
            _DateLetter = Value
        End Set
    End Property
    <MapperColumn("DateReceived", SqlDbType.datetime)> _
    Public Property DateReceived() As String
        Get
            Return _DateReceived
        End Get
        Set(ByVal value As String)
            _DateReceived = Value
        End Set
    End Property
    <MapperColumn("Details", SqlDbType.varchar)> _
    Public Property Details() As String
        Get
            Return _Details
        End Get
        Set(ByVal value As String)
            _Details = Value
        End Set
    End Property
    <MapperColumn("CreateDate", SqlDbType.datetime)> _
    Public Property CreateDate() As String
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As String)
            _CreateDate = Value
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

#End Region

End Class