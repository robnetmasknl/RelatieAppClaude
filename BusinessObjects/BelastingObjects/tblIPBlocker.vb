Public Class tblIpBlocker
#Region "members"
    Private _Id As Int32 = 0
    Private _RequestGUID As Guid
    Private _IPADDRESS As String = String.Empty
    Private _TimeStamp As DateTime = DateTime.MinValue
    Private _SearchName As String = String.Empty
    Private _SearchDOB As String = String.Empty
    Private _Type As String = String.Empty
    Private _Attempts As Int32 = 0

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
    <MapperColumn("RequestGUID", SqlDbType.uniqueidentifier)> _
    Public Property RequestGUID() As Guid
        Get
            Return _RequestGUID
        End Get
        Set(ByVal value As Guid)
            _RequestGUID = Value
        End Set
    End Property
    <MapperColumn("IPADDRESS", SqlDbType.nvarchar)> _
    Public Property IPADDRESS() As String
        Get
            Return _IPADDRESS
        End Get
        Set(ByVal value As String)
            _IPADDRESS = Value
        End Set
    End Property
    <MapperColumn("TimeStamp")> _
Public Property TimeStamp() As DateTime
        Get
            Return _TimeStamp
        End Get
        Set(ByVal value As DateTime)
            _TimeStamp = value
        End Set
    End Property
    <MapperColumn("SearchName", SqlDbType.varchar)> _
    Public Property SearchName() As String
        Get
            Return _SearchName
        End Get
        Set(ByVal value As String)
            _SearchName = Value
        End Set
    End Property
    <MapperColumn("SearchDOB", SqlDbType.date)> _
    Public Property SearchDOB() As String
        Get
            Return _SearchDOB
        End Get
        Set(ByVal value As String)
            _SearchDOB = Value
        End Set
    End Property
    <MapperColumn("Type", SqlDbType.VarChar)> _
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

    <MapperColumn("Attempts", SqlDbType.Int)> _
    Public Property Attempts() As Int32
        Get
            Return _Attempts
        End Get
        Set(ByVal value As Int32)
            _Attempts = value
        End Set
    End Property
#End Region

End Class