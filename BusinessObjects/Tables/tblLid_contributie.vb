<MapperTable("Lid_contributie", "Id")> _
Public Class tblLid_contributie
#Region "members"
    Private _Id As Int32 = 0
    Private _relatieid As Int32 = 0
    Private _contr_instantieid As Int32 = 0
    Private _datum As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private _mutatie As Int32 = 0
    Private _mutatiedatum As DateTime = Data.SqlTypes.SqlDateTime.MinValue
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
    <MapperColumn("relatieid")> _
    Public Property relatieid() As Int32
        Get
            Return _relatieid
        End Get
        Set(ByVal value As Int32)
            _relatieid = value
        End Set
    End Property
    <MapperColumn("contr_instantieid")> _
    Public Property contr_instantieid() As Int32
        Get
            Return _contr_instantieid
        End Get
        Set(ByVal value As Int32)
            _contr_instantieid = value
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
    <MapperColumn("mutatie")> _
    Public Property mutatie() As Int32
        Get
            Return _mutatie
        End Get
        Set(ByVal value As Int32)
            _mutatie = value
        End Set
    End Property
    <MapperColumn("mutatiedatum")> _
    Public Property mutatiedatum() As DateTime
        Get
            Return _mutatiedatum
        End Get
        Set(ByVal value As DateTime)
            _mutatiedatum = value
        End Set
    End Property

#End Region

End Class