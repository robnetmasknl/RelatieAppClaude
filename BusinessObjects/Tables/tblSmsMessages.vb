<MapperTable("SmsMessages", "Id")> _
Public Class tblSmsMessages
#Region "members"
    Private _Id As Int32 = 0
    Private _LidId As String = String.Empty
    Private _BoekingId As Int32 = 0
    Private _Mobile As String = String.Empty
    Private _Message As String = String.Empty
    Private _Status As String = String.Empty
    Private _CreatedDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
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
    <MapperColumn("LidId", SqlDbType.VarChar)> _
    Public Property LidId() As String
        Get
            Return _LidId
        End Get
        Set(ByVal value As String)
            _LidId = value
        End Set
    End Property
    <MapperColumn("BoekingId", SqlDbType.Int)> _
    Public Property BoekingId() As Int32
        Get
            Return _BoekingId
        End Get
        Set(ByVal value As Int32)
            _BoekingId = value
        End Set
    End Property
    <MapperColumn("Mobile", SqlDbType.VarChar)> _
    Public Property Mobile() As String
        Get
            Return _Mobile
        End Get
        Set(ByVal value As String)

            _Mobile = value
        End Set
    End Property
    <MapperColumn("Message", SqlDbType.VarChar)> _
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property
    <MapperColumn("Status", SqlDbType.VarChar)> _
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    <MapperColumn("CreatedDate", SqlDbType.DateTime)> _
    Public Property CreatedDate() As String
        Get
            Return _CreatedDate
        End Get
        Set(ByVal value As String)
            _CreatedDate = value
        End Set
    End Property
    <MapperColumn("CreatedBy", SqlDbType.VarChar)> _
    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property

#End Region

End Class