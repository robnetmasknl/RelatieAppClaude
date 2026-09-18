Public Class tblIBBDocuments

#Region "members"
    Private _Id As Int32 = 0
    Private _Location As String = String.Empty
    Private _jdTypeId As Int32 = 0
    Private _DossierId As Int32 = 0
    Private _LidId As String = String.Empty
    Private _Onderwerp As String = String.Empty
    Private _Template As String = String.Empty
    Private _CreateDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
    Private _BerichtenId As Int32 = 0
    Private _Concept As Boolean = False
    Private _LocationType As String = String.Empty
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
    <MapperColumn("Location")> _
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = Value
        End Set
    End Property
    <MapperColumn("jdTypeId")> _
    Public Property jdTypeId() As Int32
        Get
            Return _jdTypeId
        End Get
        Set(ByVal value As Int32)
            _jdTypeId = Value
        End Set
    End Property
    <MapperColumn("DossierId")> _
    Public Property DossierId() As Int32
        Get
            Return _DossierId
        End Get
        Set(ByVal value As Int32)
            _DossierId = Value
        End Set
    End Property
    <MapperColumn("LidId")> _
    Public Property LidId() As String
        Get
            Return _LidId
        End Get
        Set(ByVal value As String)
            _LidId = Value
        End Set
    End Property
    <MapperColumn("Onderwerp")> _
Public Property Onderwerp() As String
        Get
            Return _Onderwerp
        End Get
        Set(ByVal value As String)
            If value.Length > 100 Then
                Throw New Exception("De waarde van kolom Onderwerp in tabel IBBDocuments is te groot.")
            End If

            _Onderwerp = value
        End Set
    End Property
    <MapperColumn("Template")> _
    Public Property Template() As String
        Get
            Return _Template
        End Get
        Set(ByVal value As String)
            _Template = Value
        End Set
    End Property
    <MapperColumn("CreateDate", SqlDbType.DateTime)> _
    Public Property CreateDate() As String
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As String)
            _CreateDate = value
        End Set
    End Property
    <MapperColumn("CreatedBy")> _
    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = Value
        End Set
    End Property
    <MapperColumn("BerichtenId")> _
    Public Property BerichtenId() As Int32
        Get
            Return _BerichtenId
        End Get
        Set(ByVal value As Int32)
            _BerichtenId = value
        End Set
    End Property
    <MapperColumn("Concept", SqlDbType.Bit)> _
    Public Property Concept() As Boolean
        Get
            Return _Concept
        End Get
        Set(ByVal value As Boolean)
            _Concept = value
        End Set
    End Property
#End Region

    <MapperColumn("LocationType", SqlDbType.VarChar)> _
    Public Property LocationType() As String
        Get
            Return _LocationType
        End Get
        Set(ByVal value As String)
            _LocationType = Value
        End Set
    End Property

    Private _Classificatie As Int32 = -1
    <MapperColumn("Classificatie", SqlDbType.Int)> _
    Public Property Classificatie() As Int32
        Get
            Return _Classificatie
        End Get
        Set(ByVal value As Int32)
            _Classificatie = value
        End Set
    End Property
End Class
