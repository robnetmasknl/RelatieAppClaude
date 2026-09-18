<MapperTable("Locaties", "Id")> _
Public Class tblLocaties
#Region "members"
    Private _Id As Int32 = 0
    Private _Locatie As String = String.Empty
    Private _Toegankelijkheid As Boolean = False
    Private _Address1 As String = String.Empty
    Private _Address2 As String = String.Empty
    Private _Address3 As String = String.Empty
    Private _Street As String = String.Empty
    Private _Postcode As String = String.Empty
    Private _Plaats As String = String.Empty
    Private _Cancel As Boolean = False
    Private _LocatieNieuw As Boolean = False
    Private _Offline As Boolean = False

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
    <MapperColumn("Locatie")> _
    Public Property Locatie() As String
        Get
            Return _Locatie
        End Get
        Set(ByVal value As String)
            _Locatie = value
        End Set
    End Property
    <MapperColumn("Toegankelijkheid")> _
    Public Property Toegankelijkheid() As Boolean
        Get
            Return _Toegankelijkheid
        End Get
        Set(ByVal value As Boolean)
            _Toegankelijkheid = value
        End Set
    End Property
    <MapperColumn("Address1")> _
    Public Property Address1() As String
        Get
            Return _Address1
        End Get
        Set(ByVal value As String)
            _Address1 = value
        End Set
    End Property
    <MapperColumn("Address2")> _
    Public Property Address2() As String
        Get
            Return _Address2
        End Get
        Set(ByVal value As String)
            _Address2 = value
        End Set
    End Property
    <MapperColumn("Address3")> _
    Public Property Address3() As String
        Get
            Return _Address3
        End Get
        Set(ByVal value As String)
            _Address3 = value
        End Set
    End Property
    <MapperColumn("Street")> _
    Public Property Street() As String
        Get
            Return _Street
        End Get
        Set(ByVal value As String)
            _Street = value
        End Set
    End Property
    <MapperColumn("Postcode")> _
    Public Property Postcode() As String
        Get
            Return _Postcode
        End Get
        Set(ByVal value As String)
            _Postcode = value
        End Set
    End Property
    <MapperColumn("Plaats")> _
    Public Property Plaats() As String
        Get
            Return _Plaats
        End Get
        Set(ByVal value As String)
            _Plaats = value
        End Set
    End Property
    <MapperColumn("Cancel")> _
    Public Property Cancel() As Boolean
        Get
            Return _Cancel
        End Get
        Set(ByVal value As Boolean)
            _Cancel = value
        End Set
    End Property
    <MapperColumn("LocatieNieuw")>
    Public Property LocatieNieuw() As Boolean
        Get
            Return _LocatieNieuw
        End Get
        Set(ByVal value As Boolean)
            _LocatieNieuw = value
        End Set
    End Property
    <MapperColumn("Offline")>
    Public Property Offline() As Boolean
        Get
            Return _Offline
        End Get
        Set(ByVal value As Boolean)
            _Offline = value
        End Set
    End Property
#End Region

End Class
