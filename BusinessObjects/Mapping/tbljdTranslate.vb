Public Class tbljdTranslate
#Region "members"
    Private _Id As Int32 = 0
    Private _JdTypeId As Int32 = 0
    Private _DBColumn As String = String.Empty
    Private _Description As String = String.Empty
    Private _CalEntryField As String = String.Empty
    Private _CalEntryFieldHandler As String = String.Empty
    Private _ReminderInDays As Int32 = 0
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
    <MapperColumn("JdTypeId", SqlDbType.int)> _
    Public Property JdTypeId() As Int32
        Get
            Return _JdTypeId
        End Get
        Set(ByVal value As Int32)
            _JdTypeId = Value
        End Set
    End Property
    <MapperColumn("DBColumn", SqlDbType.varchar)> _
    Public Property DBColumn() As String
        Get
            Return _DBColumn
        End Get
        Set(ByVal value As String)
            _DBColumn = Value
        End Set
    End Property
    <MapperColumn("Description", SqlDbType.varchar)> _
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = Value
        End Set
    End Property
    <MapperColumn("CalEntryField", SqlDbType.varchar)> _
    Public Property CalEntryField() As String
        Get
            Return _CalEntryField
        End Get
        Set(ByVal value As String)
            _CalEntryField = Value
        End Set
    End Property
    <MapperColumn("CalEntryFieldHandler", SqlDbType.varchar)> _
    Public Property CalEntryFieldHandler() As String
        Get
            Return _CalEntryFieldHandler
        End Get
        Set(ByVal value As String)
            _CalEntryFieldHandler = Value
        End Set
    End Property
    <MapperColumn("ReminderInDays", SqlDbType.Int)>
    Public Property ReminderInDays() As Int32
        Get
            Return _ReminderInDays
        End Get
        Set(ByVal value As Int32)
            _ReminderInDays = value
        End Set
    End Property
#End Region

End Class