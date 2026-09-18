Public Class CustomArgs
    Inherits EventArgs
    Private privateCancel As Boolean
    Public Property Cancel() As Boolean
        Get
            Return privateCancel
        End Get
        Set(ByVal value As Boolean)
            privateCancel = value
        End Set
    End Property
    Private privateMessage As String
    Public Property Message() As String
        Get
            Return privateMessage
        End Get
        Set(ByVal value As String)
            privateMessage = value
        End Set
    End Property
    Private privateNavigateTo As String
    Public Property NavigateTo() As String
        Get
            Return privateNavigateTo
        End Get
        Set(ByVal value As String)
            privateNavigateTo = value
        End Set
    End Property
End Class
