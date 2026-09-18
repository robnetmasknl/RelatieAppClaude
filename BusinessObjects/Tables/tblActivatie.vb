<MapperTable("Activatie", "Id")> _
Public Class tblActivatie

    Private _Id As Int32 = 0
    Private _ActivatieGUID As Guid
    Private _IPADDRESS As String = ""
    Private _Lidnr As String = "0"
    Private _DateSend As DateTime
    Private _DateConfirmd As DateTime
    Private _Type As String = ""
    Private _SearchId As Int32 = 0


    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property

    <MapperColumn("ActivatieGUID")> _
    Public Property ActivatieGUID() As Guid
        Get
            Return _ActivatieGUID
        End Get
        Set(ByVal value As Guid)
            _ActivatieGUID = value
        End Set
    End Property
    <MapperColumn("IPADDRESS")> _
    Public Property IPADDRESS() As String
        Get
            Return _IPADDRESS
        End Get
        Set(ByVal value As String)
            _IPADDRESS = value
        End Set
    End Property
    <MapperColumn("Lidnr")> _
    Public Property Lidnr() As String
        Get
            Return _Lidnr
        End Get
        Set(ByVal value As String)
            _Lidnr = value
        End Set
    End Property
    <MapperColumn("DateSend")> _
    Public Property DateSend() As DateTime
        Get
            Return _DateSend
        End Get
        Set(ByVal value As DateTime)
            _DateSend = value
        End Set
    End Property
    <MapperColumn("DateConfirmd")> _
    Public Property DateConfirmd() As DateTime
        Get
            Return _DateConfirmd
        End Get
        Set(ByVal value As DateTime)
            _DateConfirmd = value
        End Set
    End Property
    <MapperColumn("Type")> _
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

    <MapperColumn("SearchId")> _
    Public Property SearchId() As Int32
        Get
            Return _SearchId
        End Get
        Set(ByVal value As Int32)
            _SearchId = value
        End Set
    End Property

End Class
