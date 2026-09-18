Imports System.Xml
Imports System.Xml.Serialization

<System.Xml.Serialization.XmlRoot("applicationSettings")> _
Public Class SettingsBase
    Private _ServerIP As String = "AP02\SQLEXPRESS"
    Private _Account As String = "sa"
    Private _password As String = "q8COQdVi6r7UWRt3ftYB+g==" 'CryptoService.Encrypt("default")
    Private _DataBase As String = "VBM"
    Private _LogFilePath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\VBM"
    Private _SettingFilePath As String

    Public Property ServerIP() As String
        Get
            Return _ServerIP
        End Get
        Set(ByVal value As String)
            ' If String.IsNullOrEmpty(value) Then value = "AP02\SQLEXPRESS"
            _ServerIP = value
        End Set
    End Property

    Public Property Account() As String
        Get
            Return _Account
        End Get
        Set(ByVal value As String)
            'If String.IsNullOrEmpty(value) Then value = "sa"
            _Account = value
        End Set
    End Property

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            ' If String.IsNullOrEmpty(value) Then value = "q8COQdVi6r7UWRt3ftYB+g==" 'CryptoService.Encrypt("default")
            _password = value
        End Set
    End Property

    Public Property DataBase() As String
        Get
            Return _DataBase
        End Get
        Set(ByVal value As String)
            ' If String.IsNullOrEmpty(value) Then value = "VBM"
            _DataBase = value
        End Set
    End Property

    Public Property LogFilePath() As String
        Get
            Return _LogFilePath
        End Get
        Set(ByVal value As String)
            'If String.IsNullOrEmpty(value) Then _
            '        value = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\VBM"
            _LogFilePath = value
        End Set
    End Property

    Private _FontFamily As String = "Microsoft Sans Serif"
    Public Property FontFamily() As String
        Get
            Return _FontFamily
        End Get
        Set(ByVal value As String)
            _FontFamily = value
        End Set
    End Property
    Private _FontStyle As String = "0"
    Public Property FontStyle() As String
        Get
            Return _FontStyle
        End Get
        Set(ByVal value As String)
            _FontStyle = value
        End Set
    End Property
    Private _Fontsize As Single = 9
    Public Property FontSize() As Single
        Get
            Return _Fontsize
        End Get
        Set(ByVal value As Single)
            If String.IsNullOrEmpty(value) Then _
                    value = 8.25
            _Fontsize = value
        End Set
    End Property


    'Zet dit aan om NIET domein pc aan te kunnen melden
    'Private _DomainUser As String = ""
    'Public Property DomainUser() As String
    '    Get
    '        Return _DomainUser
    '    End Get
    '    Set(ByVal value As String)
    '        If String.IsNullOrEmpty(value) Then value = ""
    '        _DomainUser = value
    '    End Set
    'End Property

#Region "Email"
    Private _Mailserver As String = "ex01.vbm.loc"
    Private _MailSenderName As String = "VBM"
    Private _MailSenderEmail As String = "info@mijnvbm.nl"
    Private _MailAccountPassword As String = "q8COQdVi6r7UWRt3ftYB+g==" 'CryptoService.Encrypt("default")
    Private _MailAccount As String = "info@mijnvbm.nl"

    Public Property Mailserver() As String
        Get
            Return _Mailserver
        End Get
        Set(ByVal value As String)
            'If String.IsNullOrEmpty(value) Then value = "ex01.vbm.loc"
            _Mailserver = value
        End Set
    End Property

    Public Property MailSenderName() As String
        Get
            Return _MailSenderName
        End Get
        Set(ByVal value As String)
            ' If String.IsNullOrEmpty(value) Then value = "VBM"
            _MailSenderName = value
        End Set
    End Property

    Public Property MailSenderEmail() As String
        Get
            Return _MailSenderEmail
        End Get
        Set(ByVal value As String)
            'If String.IsNullOrEmpty(value) Then value = "info@mijnvbm.nl"
            _MailSenderEmail = value
        End Set
    End Property

    Public Property MailAccountPassword() As String
        Get
            Return _MailAccountPassword
        End Get
        Set(ByVal value As String)
            'If String.IsNullOrEmpty(value) Then value = "q8COQdVi6r7UWRt3ftYB+g==" 'CryptoService.Encrypt("default")
            _MailAccountPassword = value
        End Set
    End Property

    Public Property MailAccount() As String
        Get
            Return _MailAccount
        End Get
        Set(ByVal value As String)
            'If String.IsNullOrEmpty(value) Then value = "info@mijnvbm.nl"
            _MailAccount = value
        End Set
    End Property
#End Region
End Class
