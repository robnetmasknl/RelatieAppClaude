<MapperTable("Helpdesk", "Id")> _
Public Class tblHelpdesk
#Region "members"
    Private _Id As Int32 = 0
    Private _LidId As Int32 = 0
    Private _DossierId As Int32 = 0
    Private _Subject As String = String.Empty
    Private _Memo As String = String.Empty
    Private _CreateDate As String = String.Empty
    Private _CreateBy As String = String.Empty
#End Region

#Region "Properties"

    <MapperColumn("Id", SqlDbType.Int)> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("LidId", SqlDbType.Int)> _
    Public Property LidId() As Int32
        Get
            Return _LidId
        End Get
        Set(ByVal value As Int32)
            _LidId = value
        End Set
    End Property
    <MapperColumn("DossierId", SqlDbType.Int)> _
    Public Property DossierId() As Int32
        Get
            Return _DossierId
        End Get
        Set(ByVal value As Int32)
            _DossierId = value
        End Set
    End Property
    <MapperColumn("Subject", SqlDbType.VarChar)> _
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property
    <MapperColumn("Memo", SqlDbType.Text)> _
    Public Property Memo() As String
        Get
            Return _Memo
        End Get
        Set(ByVal value As String)
            _Memo = value
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
    <MapperColumn("CreateBy", SqlDbType.VarChar)> _
    Public Property CreateBy() As String
        Get
            Return _CreateBy
        End Get
        Set(ByVal value As String)
            _CreateBy = value
        End Set
    End Property

#End Region

End Class

