Public Class tblDeclaratieSettings
#Region "members"
    Private _Id As Int32 = 0
    Private _AmountKm As Decimal = 0.0
    Private _AmountHour As Decimal = 0.0
    Private _StartDate As String = String.Empty
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
    <MapperColumn("AmountKm", SqlDbType.decimal)> _
    Public Property AmountKm() As Decimal
        Get
            Return _AmountKm
        End Get
        Set(ByVal value As Decimal)
            _AmountKm = Value
        End Set
    End Property
    <MapperColumn("AmountHour", SqlDbType.decimal)> _
    Public Property AmountHour() As Decimal
        Get
            Return _AmountHour
        End Get
        Set(ByVal value As Decimal)
            _AmountHour = Value
        End Set
    End Property
    <MapperColumn("StartDate", SqlDbType.date)> _
    Public Property StartDate() As String
        Get
            Return _StartDate
        End Get
        Set(ByVal value As String)
            _StartDate = Value
        End Set
    End Property

#End Region

End Class