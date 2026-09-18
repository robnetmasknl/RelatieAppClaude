Public Class AppointmentSettings
    Private _Subject As String = String.Empty
    Private _Location As String = String.Empty
    Private _Body As String = String.Empty
    Private _AppStartTime As DateTime = Date.MinValue
    Private _AppEndTime As DateTime = Date.MinValue
    Private _Duration As Integer = -1
    Private _IsAllDayEvent As Boolean = False
    Private _ReminderMinutes As Integer = 0
    Private _AppEntryId As String = String.Empty
    Private _AppGlobalAppointmentID As String = String.Empty

    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property

    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property

    Public Property Body() As String
        Get
            Return _Body
        End Get
        Set(ByVal value As String)
            _Body = value
        End Set
    End Property

    Public Property AppStartTime() As DateTime
        Get
            Return _AppStartTime
        End Get
        Set(ByVal value As DateTime)
            _AppStartTime = value
        End Set
    End Property
    Public Property AppEndTime() As DateTime
        Get
            Return _AppEndTime
        End Get
        Set(ByVal value As DateTime)
            _AppEndTime = value
        End Set
    End Property
    Public Property Duration() As Integer
        Get
            Return _Duration
        End Get
        Set(ByVal value As Integer)
            _Duration = value
        End Set
    End Property
    Public Property IsAllDayEvent() As Boolean
        Get
            Return _IsAllDayEvent
        End Get
        Set(ByVal value As Boolean)
            _IsAllDayEvent = value
        End Set
    End Property
    Public Property ReminderMinutes() As Integer
        Get
            Return _ReminderMinutes
        End Get
        Set(ByVal value As Integer)
            _ReminderMinutes = value
        End Set
    End Property
    Public Property AppEntryId() As String
        Get
            Return _AppEntryId
        End Get
        Set(ByVal value As String)
            _AppEntryId = value
        End Set
    End Property

    Public Property AppGlobalAppointmentID() As String
        Get
            Return _AppGlobalAppointmentID
        End Get
        Set(ByVal value As String)
            _AppGlobalAppointmentID = value
        End Set
    End Property

End Class

