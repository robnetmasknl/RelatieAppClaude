Public Class SettingsIpBlocker
    Private _ServerIP As String = ""
    Private _Account As String = ""
    Private _password As String
    Private _DataBase As String = ""

    Public Property ServerIP() As String
        Get
            Return _ServerIP
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then value = "VBDENAP01\SQLEXPRESS"
            _ServerIP = value
        End Set
    End Property

    Public Property Account() As String
        Get
            Return _Account
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then value = "sa"
            _Account = value
        End Set
    End Property

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then value = "q8COQdVi6r7UWRt3ftYB+g==" 'CryptoService.Encrypt("default")
            _password = value
        End Set
    End Property

    Public Property DataBase() As String
        Get
            Return _DataBase
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then value = "VBM"
            _DataBase = value
        End Set
    End Property

    Private _ServiceName As String
    Public Property ServiceName() As String
        Get
            If String.IsNullOrEmpty(_ServiceName) Then
                _ServiceName = "ipbservice"
            End If
            Return _ServiceName
        End Get
        Set(ByVal value As String)
            _ServiceName = value
        End Set
    End Property
    Private _StartTime As DateTime = "01-01-2000 23:00"
    Public Property StartTime() As DateTime
        Get
            Return _StartTime
        End Get
        Set(ByVal value As DateTime)
            _StartTime = value
        End Set
    End Property
    Private _LogFilePath As String
    Public Property LogFilePath() As String
        Get
            If String.IsNullOrEmpty(_LogFilePath) Then
                _LogFilePath = "C:\"
            End If
            Return _LogFilePath
        End Get
        Set(ByVal value As String)
            _LogFilePath = value
        End Set
    End Property
    Private _LastRun As DateTime = "01-01-2000 23:00"
    Public Property LastRun() As DateTime
        Get
            Return _LastRun
        End Get
        Set(ByVal value As DateTime)
            _LastRun = value
        End Set
    End Property
    Private _Interval As Integer = 60
    Public Property Interval() As Integer
        Get
            Return _Interval
        End Get
        Set(ByVal value As Integer)
            _Interval = value
        End Set
    End Property


End Class
