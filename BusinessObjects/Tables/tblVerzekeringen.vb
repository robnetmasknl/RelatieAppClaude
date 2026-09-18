<MapperTable("Verzekeringen", "Id")> _
Public Class tblVerzekeringen
#Region "members"
    Private _Id As Int32 = 0
    Private _Lidid As Int32 = 0
    Private _Soort As String = String.Empty
    Private _Verzekeraar As String = String.Empty
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
    <MapperColumn("Soort", SqlDbType.VarChar)> _
    Public Property Soort() As String
        Get
            Return _Soort
        End Get
        Set(ByVal value As String)
            _Soort = value
        End Set
    End Property
    <MapperColumn("Verzekeraar", SqlDbType.VarChar)> _
    Public Property Verzekeraar() As String
        Get
            Return _Verzekeraar
        End Get
        Set(ByVal value As String)
            _Verzekeraar = value
        End Set
    End Property

#End Region

End Class