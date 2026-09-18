<MapperTable("storneringen", "Id")> _
Public Class tblstorneringen
#Region "members"
    Private _Id As Int32 = 0
    Private _jaar As String = String.Empty
    Private _periode As String = String.Empty
    Private _lidid As Int32 = 0
    Private _bedrag As Double
    Private _teller As Int32 = 0
    Private _eindereden As String = String.Empty
    Private _status As String = String.Empty
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
    <MapperColumn("jaar")> _
    Public Property jaar() As String
        Get
            Return _jaar
        End Get
        Set(ByVal value As String)
            _jaar = value
        End Set
    End Property
    <MapperColumn("periode")> _
    Public Property periode() As String
        Get
            Return _periode
        End Get
        Set(ByVal value As String)
            _periode = value
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
    <MapperColumn("bedrag")> _
    Public Property bedrag() As Double
        Get
            Return _bedrag
        End Get
        Set(ByVal value As Double)
            Try
                Dim i As Integer = Int32.Parse(value)
            Catch ex As Exception
                Throw New Exception("Foutieve invoer! Geef het bedrag in centen (zonder '','')")
            End Try
            _bedrag = value
        End Set
    End Property
    <MapperColumn("teller")> _
    Public Property teller() As Int32
        Get
            Return _teller
        End Get
        Set(ByVal value As Int32)
            _teller = value
        End Set
    End Property
    <MapperColumn("eindereden")> _
    Public Property eindereden() As String
        Get
            Return _eindereden
        End Get
        Set(ByVal value As String)
            _eindereden = value
        End Set
    End Property
    <MapperColumn("status")> _
Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
#End Region

End Class