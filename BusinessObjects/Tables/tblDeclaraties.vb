Public Class tblDeclaraties
#Region "members"
    Private _Id As Int32 = 0
    Private _DeclPerId As Int32 = 0
    Private _DeclaratieDate As String = String.Empty
    Private _Omschrijving As String = String.Empty
    ' Private _Promomateriaal As String = String.Empty
    Private _Uren As Decimal = 0.0
    Private _Onkosten As Decimal = 0.0
    Private _OnkOmsc As String = String.Empty
    Private _Kilometers As Decimal = 0.0
    Private _OnkOV As Decimal
    Private _KmOmsc As String = String.Empty
    Private _CreatedDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
    Private _Maaltijden As Decimal = 0.0
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
    <MapperColumn("DeclPerId", SqlDbType.int)> _
    Public Property DeclPerId() As Int32
        Get
            Return _DeclPerId
        End Get
        Set(ByVal value As Int32)
            _DeclPerId = Value
        End Set
    End Property
    <MapperColumn("DeclaratieDate", SqlDbType.DateTime)> _
    Public Property DeclaratieDate() As String
        Get
            Return _DeclaratieDate
        End Get
        Set(ByVal value As String)
            _DeclaratieDate = value
        End Set
    End Property
    <MapperColumn("Omschrijving", SqlDbType.VarChar)> _
    Public Property Omschrijving() As String
        Get
            Return _Omschrijving
        End Get
        Set(ByVal value As String)
            _Omschrijving = value
        End Set
    End Property

    '<MapperColumn("Promomateriaal", SqlDbType.VarChar)> _
    'Public Property Promomateriaal() As String
    '    Get
    '        Return _Promomateriaal
    '    End Get
    '    Set(ByVal value As String)
    '        _Promomateriaal = value
    '    End Set
    'End Property
    <MapperColumn("Uren", SqlDbType.Decimal)> _
    Public Property Uren() As Decimal
        Get
            Return _Uren
        End Get
        Set(ByVal value As Decimal)
            _Uren = value
        End Set
    End Property
    <MapperColumn("Onkosten", SqlDbType.Decimal)> _
    Public Property Onkosten() As Decimal
        Get
            Return _Onkosten
        End Get
        Set(ByVal value As Decimal)
            _Onkosten = value
        End Set
    End Property
    <MapperColumn("OnkOmsc", SqlDbType.VarChar)> _
    Public Property OnkOmsc() As String
        Get
            Return _OnkOmsc
        End Get
        Set(ByVal value As String)
            _OnkOmsc = value
        End Set
    End Property
    <MapperColumn("Kilometers", SqlDbType.Decimal)> _
    Public Property Kilometers() As Decimal
        Get
            Return _Kilometers
        End Get
        Set(ByVal value As Decimal)
            _Kilometers = value
        End Set
    End Property
    <MapperColumn("OnkOV", SqlDbType.Decimal)> _
    Public Property OnkOV() As Decimal
        Get
            Return _OnkOV
        End Get
        Set(ByVal value As Decimal)
            _OnkOV = value
        End Set
    End Property
    <MapperColumn("KmOmsc", SqlDbType.VarChar)> _
    Public Property KmOmsc() As String
        Get
            Return _KmOmsc
        End Get
        Set(ByVal value As String)
            _KmOmsc = value
        End Set
    End Property
    <MapperColumn("CreatedDate", SqlDbType.DateTime)> _
    Public Property CreatedDate() As String
        Get
            Return _CreatedDate
        End Get
        Set(ByVal value As String)
            _CreatedDate = value
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
    <MapperColumn("Maaltijden", SqlDbType.Decimal)>
    Public Property Maaltijden() As Decimal
        Get
            Return _Maaltijden
        End Get
        Set(ByVal value As Decimal)
            _Maaltijden = value
        End Set
    End Property
#End Region

End Class