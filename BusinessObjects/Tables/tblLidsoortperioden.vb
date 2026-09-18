<MapperTable("Lidsoortperioden", "Id")> _
Public Class tblLidsoortperioden
#Region "members"
    Private _Id As Int32 = 0
    Private _lidid As Int32 = 0
    Private _lidsoortid As Int32 = 0
    Private _datumin As DateTime = Data.SqlTypes.SqlDateTime.MinValue

#End Region

#Region "Properties"

    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("lidid")> _
    Public Property lidid() As Int32
        Get
            Return _lidid
        End Get
        Set(ByVal value As Int32)
            _lidid = value
        End Set
    End Property
    <MapperColumn("lidsoortid")> _
    Public Property lidsoortid() As Int32
        Get
            Return _lidsoortid
        End Get
        Set(ByVal value As Int32)
            _lidsoortid = value
        End Set
    End Property
    <MapperColumn("datumin")> _
    Public Property datumin() As DateTime
        Get
            Return _datumin
        End Get
        Set(ByVal value As DateTime)
            _datumin = value
        End Set
    End Property

    'Private _Fase As Integer = 0
    '<MapperColumn("Fase")> _
    'Public Property Fase() As Integer
    '    Get
    '        Return _Fase
    '    End Get
    '    Set(ByVal value As Integer)
    '        _Fase = value
    '    End Set
    'End Property
#End Region

End Class