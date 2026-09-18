<System.Xml.Serialization.XmlRoot("ServiceSettings")> _
Public Class SettingObjects
    Private _ServiceName As String
    Public Property ServiceName() As String
        Get
            If String.IsNullOrEmpty(_ServiceName) Then
                _ServiceName = "ServiceScan2Ibb"
            End If
            Return _ServiceName
        End Get
        Set(ByVal value As String)
            _ServiceName = value
        End Set
    End Property

    Private _ScanDir As String = ""
    Public Property ScanDir() As String
        Get
            Return _ScanDir
        End Get
        Set(ByVal value As String)
            _ScanDir = value
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
    Private _DataAccessConfigFile As String
    Public Property DataAccessConfigFile() As String
        Get
            If String.IsNullOrEmpty(_DataAccessConfigFile) Then
                _DataAccessConfigFile = "C:\"
            End If
            Return _DataAccessConfigFile
        End Get
        Set(ByVal value As String)
            _DataAccessConfigFile = value
        End Set
    End Property
    Private _Extensions As String
    Public Property Extensions() As String
        Get
            If String.IsNullOrEmpty(_Extensions) Then
                _Extensions = "*.pdf"
            End If
            Return _Extensions
        End Get
        Set(ByVal value As String)
            _Extensions = value
        End Set
    End Property
End Class
