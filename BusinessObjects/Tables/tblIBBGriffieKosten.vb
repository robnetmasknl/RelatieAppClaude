Public Class tblIBBGriffieKosten

#Region "members"
    Private _Id As Int32 = 0
    Private _DossierId As Int32 = 0
    Private _IBBFaseId As Int32 = 0
    Private _GriffieDate As String = String.Empty
    Private _Amount As Decimal = 0
    Private _Paid As Boolean
    Private _PaymentDate As String = String.Empty
    Private _RepaidGriffieDate As String = String.Empty
    Private _RepaidClientDate As String = String.Empty
    Private _CreateDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
    Private _Details As String = String.Empty
#End Region

#Region "Properties"

    <MapperColumn("Id", SqlDbType.Int)> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = Value
        End Set
    End Property
    <MapperColumn("DossierId", SqlDbType.Int)> _
    Public Property DossierId() As Int32
        Get
            Return _DossierId
        End Get
        Set(ByVal value As Int32)
            _DossierId = Value
        End Set
    End Property
    <MapperColumn("IBBFaseId", SqlDbType.Int)> _
    Public Property IBBFaseId() As Int32
        Get
            Return _IBBFaseId
        End Get
        Set(ByVal value As Int32)
            _IBBFaseId = Value
        End Set
    End Property
    <MapperColumn("GriffieDate", SqlDbType.DateTime)> _
    Public Property GriffieDate() As String
        Get
            Return _GriffieDate
        End Get
        Set(ByVal value As String)
            _GriffieDate = Value
        End Set
    End Property
    <MapperColumn("Amount", SqlDbType.Decimal)> _
    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = Value
        End Set
    End Property
    <MapperColumn("Paid", SqlDbType.Bit)> _
    Public Property Paid() As Boolean
        Get
            Return _Paid
        End Get
        Set(ByVal value As Boolean)
            _Paid = Value
        End Set
    End Property
    <MapperColumn("PaymentDate", SqlDbType.DateTime)> _
    Public Property PaymentDate() As String
        Get
            Return _PaymentDate
        End Get
        Set(ByVal value As String)
            _PaymentDate = Value
        End Set
    End Property
    <MapperColumn("RepaidGriffieDate", SqlDbType.DateTime)> _
    Public Property RepaidGriffieDate() As String
        Get
            Return _RepaidGriffieDate
        End Get
        Set(ByVal value As String)
            _RepaidGriffieDate = value
        End Set
    End Property

    <MapperColumn("RepaidClientDate", SqlDbType.DateTime)> _
Public Property RepaidClientDate() As String
        Get
            Return _RepaidClientDate
        End Get
        Set(ByVal value As String)
            _RepaidClientDate = value
        End Set
    End Property
    <MapperColumn("CreateDate", SqlDbType.DateTime)> _
    Public Property CreateDate() As String
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As String)
            _CreateDate = Value
        End Set
    End Property
    <MapperColumn("CreatedBy", SqlDbType.VarChar)> _
    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = Value
        End Set
    End Property
    <MapperColumn("Details", SqlDbType.VarChar)> _
    Public Property Details() As String
        Get
            Return _Details
        End Get
        Set(ByVal value As String)
            _Details = value
        End Set
    End Property
#End Region

End Class
