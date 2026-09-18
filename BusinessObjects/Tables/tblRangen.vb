Public Class tblRangen
#Region "members"
    Private _Id As Int32 = 0
    Private _Rang As String = String.Empty
    Private _Korting As Boolean
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
    <MapperColumn("Rang", SqlDbType.varchar)> _
    Public Property Rang() As String
        Get
            Return _Rang
        End Get
        Set(ByVal value As String)
            _Rang = Value
        End Set
    End Property
    <MapperColumn("Korting", SqlDbType.bit)> _
    Public Property Korting() As Boolean
        Get
            Return _Korting
        End Get
        Set(ByVal value As Boolean)
            _Korting = Value
        End Set
    End Property

#End Region

End Class