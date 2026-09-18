<MapperTable("Boekingen", "Id")> _
Public Class tblBoekingen
    Private _Id As Int32 = 0
    Private _blokId As Int32 = 0
    'Private _lidnr As String = "0"
    Private _relatieId As Int32 = 0
    Private _tijdstip As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private _voorlopig As Boolean = False

    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("blokId")> _
    Public Property blokId() As Int32
        Get
            Return _blokId
        End Get
        Set(ByVal value As Int32)
            _blokId = value
        End Set
    End Property
    '<MapperColumn("lidnr")> _
    'Public Property lidnr() As String
    '    Get
    '        Return _lidnr
    '    End Get
    '    Set(ByVal value As String)
    '        _lidnr = value
    '    End Set
    'End Property
    <MapperColumn("relatieId")> _
    Public Property relatieId() As Int32
        Get
            Return _relatieId
        End Get
        Set(ByVal value As Int32)
            _relatieId = value
        End Set
    End Property
    <MapperColumn("tijdstip")> _
    Public Property tijdstip() As DateTime
        Get
            Return _tijdstip
        End Get
        Set(ByVal value As DateTime)
            _tijdstip = value
        End Set
    End Property
    <MapperColumn("voorlopig")> _
    Public Property voorlopig() As Boolean
        Get
            Return _voorlopig
        End Get
        Set(ByVal value As Boolean)
            _voorlopig = value
        End Set
    End Property

End Class
