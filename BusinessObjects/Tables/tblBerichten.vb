Public Class tblBerichten

#Region "members"
    Private _Id As Int32 = 0
    Private _DossierId As Int32 = 0
    Private _RelatieId As Int32 = 0
    Private _ReceivedDate As String = String.Empty
    Private _FromAddress As String = String.Empty
    Private _FromName As String = String.Empty
    Private _ToAddress As String = String.Empty
    Private _ToName As String = String.Empty
    Private _Subject As String = String.Empty
    Private _BodyText As String = String.Empty
    Private _Header As String = String.Empty
    Private _isHTML As Int32 = 0
    Private _CreateDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
#End Region

#Region "Properties"

    <MapperColumn("Id", SqlDbType.Int)> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = Value
        End Set
    End Property
    <MapperColumn("DossierId")> _
    Public Property DossierId() As Int32
        Get
            Return _DossierId
        End Get
        Set(ByVal value As Int32)
            _DossierId = Value
        End Set
    End Property
    <MapperColumn("RelatieId")> _
    Public Property RelatieId() As Int32
        Get
            Return _RelatieId
        End Get
        Set(ByVal value As Int32)
            _RelatieId = value
        End Set
    End Property
    <MapperColumn("ReceivedDate", SqlDbType.DateTime)> _
    Public Property ReceivedDate() As String
        Get
            Return _ReceivedDate
        End Get
        Set(ByVal value As String)
            _ReceivedDate = value
        End Set
    End Property
    <MapperColumn("FromAddress", SqlDbType.VarChar)> _
    Public Property FromAddress() As String
        Get
            Return _FromAddress
        End Get
        Set(ByVal value As String)
            _FromAddress = value
        End Set
    End Property
    <MapperColumn("FromName", SqlDbType.VarChar)> _
    Public Property FromName() As String
        Get
            Return _FromName
        End Get
        Set(ByVal value As String)
            _FromName = value
        End Set
    End Property
    <MapperColumn("ToAddress", SqlDbType.VarChar)> _
    Public Property ToAddress() As String
        Get
            Return _ToAddress
        End Get
        Set(ByVal value As String)
            _ToAddress = value
        End Set
    End Property
    <MapperColumn("ToName", SqlDbType.VarChar)> _
    Public Property ToName() As String
        Get
            Return _ToName
        End Get
        Set(ByVal value As String)
            _ToName = value
        End Set
    End Property
    <MapperColumn("Subject", SqlDbType.VarChar)> _
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property
    <MapperColumn("BodyText", SqlDbType.VarChar)> _
    Public Property BodyText() As String
        Get
            Return _BodyText
        End Get
        Set(ByVal value As String)
            _BodyText = value
        End Set
    End Property
    <MapperColumn("Header", SqlDbType.VarChar)> _
    Public Property Header() As String
        Get
            Return _Header
        End Get
        Set(ByVal value As String)
            _Header = value
        End Set
    End Property
    <MapperColumn("isHTML", SqlDbType.Int)> _
    Public Property isHTML() As Int32
        Get
            Return _isHTML
        End Get
        Set(ByVal value As Int32)
            _isHTML = value
        End Set
    End Property
    <MapperColumn("CreateDate", SqlDbType.DateTime)> _
    Public Property CreateDate() As String
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As String)
            _CreateDate = value
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