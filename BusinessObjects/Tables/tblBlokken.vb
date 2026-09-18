<MapperTable("Blokken", "Id")> _
Public Class tblBlokken
    Private _Id As Int32 = 0
    Private _locatieid As Int32 = 0
    Private _datum As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private _adviseurid As Int32 = 0
    Private _vultype As Int32 = 0
    Private _bloktypeid As Int32 = 0

    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("locatieid")> _
    Public Property locatieid() As Int32
        Get
            Return _locatieid
        End Get
        Set(ByVal value As Int32)
            _locatieid = value
        End Set
    End Property
    <MapperColumn("datum")> _
    Public Property datum() As DateTime
        Get
            Return _datum
        End Get
        Set(ByVal value As DateTime)
            _datum = value
        End Set
    End Property
    <MapperColumn("adviseurid")> _
    Public Property adviseurid() As Int32
        Get
            Return _adviseurid
        End Get
        Set(ByVal value As Int32)
            _adviseurid = value
        End Set
    End Property
    <MapperColumn("vultype")> _
    Public Property vultype() As Int32
        Get
            Return _vultype
        End Get
        Set(ByVal value As Int32)
            _vultype = value
        End Set
    End Property
    <MapperColumn("bloktypeid")> _
    Public Property bloktypeid() As Int32
        Get
            Return _bloktypeid
        End Get
        Set(ByVal value As Int32)
            _bloktypeid = value
        End Set
    End Property

End Class
