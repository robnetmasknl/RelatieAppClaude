Public Class tblBehandelaren
#Region "members"
    Private _Id As Int32 = 0
    Private _Naam As String = String.Empty
    Private _Email As String = String.Empty
    Private _ExchangeAccount As String = String.Empty
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
    <MapperColumn("Naam", SqlDbType.varchar)> _
    Public Property Naam() As String
        Get
            Return _Naam
        End Get
        Set(ByVal value As String)
            _Naam = Value
        End Set
    End Property
    <MapperColumn("Email", SqlDbType.varchar)> _
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = Value
        End Set
    End Property
    <MapperColumn("ExchangeAccount", SqlDbType.varchar)> _
    Public Property ExchangeAccount() As String
        Get
            Return _ExchangeAccount
        End Get
        Set(ByVal value As String)
            _ExchangeAccount = Value
        End Set
    End Property

#End Region

End Class