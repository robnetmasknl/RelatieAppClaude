Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Web
Imports System.Reflection
Imports System.Xml
Imports System.Xml.Serialization

Public Enum enServiceType
    Opzeggingen
    SMS
    IBBCalendar
End Enum

<System.Xml.Serialization.XmlRoot("ServiceSettings")> _
Public Class ServiceSettings
    Inherits SettingsIBBCalendar

    Private MySettingsBase As New SettingsIBBCalendar

    Public MyProperties As Object
    Private MyRegKey As Microsoft.Win32.RegistryKey
    Private ServiceType As enServiceType
    Private _IsLoaded As Boolean = False

    Public Shared _Instance As ServiceSettings
    Public Shared Function Instance(ByVal WhatService As enServiceType) As ServiceSettings
        If _Instance Is Nothing Then
            _Instance = New ServiceSettings(WhatService)
        End If

        Return _Instance
    End Function
    '<XmlIgnore()> _
    'Public Property IsLoaded() As Boolean
    '    Get
    '        Return _IsLoaded
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _IsLoaded = value
    '    End Set
    'End Property
    Public Sub New()
        Load()
    End Sub
    Public Sub New(ByVal WhatService As enServiceType)
        ServiceType = WhatService
        Load()
    End Sub
 

    'Private Function ConfigFile() As System.IO.FileInfo
    '    Try
    '        Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo("D:\Dotnet\VBMNOV\VBMNOV_2012\ServiceIBBCalendar\bin\Debug\service.config")

    '        'Als configfile nog niet bestaan maak dan de default aan
    '        If Not FileInfo.Exists Then CreateFirstConfig(FileInfo)

    '        Return FileInfo
    '    Catch ex As Exception
    '        'Throw New Exception("ConfigFile")
    '        Throw ex
    '    End Try
    'End Function
    'Public Sub Load()
    '    Try
    '        'If IsLoaded Then Exit Sub
    '        'IsLoaded = True

    '        Dim xDeSerializer As XmlSerializer
    '        Dim xTextReader As XmlTextReader
    '        xDeSerializer = New XmlSerializer(MySettingsBase.GetType)
    '        xTextReader = New XmlTextReader(File.OpenText(ConfigFile.FullName))
    '        xTextReader.Namespaces = False


    '        'laad de gevonden settings
    '        MySettingsBase = xDeSerializer.Deserialize(xTextReader)
    '        xTextReader.Close()

    '        Dim props() As PropertyInfo = MySettingsBase.GetType().GetProperties()
    '        For Each prop As PropertyInfo In props
    '            SetProperty(Me, prop.Name, prop.GetValue(MySettingsBase, Nothing))
    '        Next


    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Function SetProperty(ByVal obj As Object, ByVal propertyName As String, ByVal val As Object) As Boolean

    '    Dim pi As System.Reflection.PropertyInfo = obj.GetType().GetProperty(propertyName)

    '    Try
    '        If pi Is Nothing Then
    '            Return False
    '        End If

    '        ' convert the value to the expected type
    '        val = Convert.ChangeType(val, pi.PropertyType)

    '        ' attempt the assignment
    '        pi.SetValue(obj, val, Nothing)

    '        Return True
    '    Catch
    '        Return False
    '    End Try
    'End Function

    'Private Sub CreateFirstConfig(ByVal filename As System.IO.FileInfo)
    '    Try
    '        Dim xmldoc As New XmlDocument
    '        Dim MemeroyOutput As New IO.MemoryStream
    '        Dim xSerializer As New XmlSerializer(Me.GetType)

    '        Dim fileIOPerm As FileIOPermission
    '        'controleren of er genoeg rechten zijn om de configmap op te slaan
    '        fileIOPerm = New FileIOPermission(FileIOPermissionAccess.Write, filename.DirectoryName.Replace("\VBMNOV", ""))
    '        If Not SecurityManager.IsGranted(fileIOPerm) Then
    '            Throw New Exception("U heeft niet voldoende rechten om configuratiemap te maken in " & filename.DirectoryName.Replace("\VBMNOV", "") & "." & vbCrLf & "Vraag uw systeembeheerder dit e controleren")
    '        End If

    '        Dim di As New IO.DirectoryInfo(filename.DirectoryName)
    '        If Not di.Exists Then di.Create()

    '        'controleren of er genoeg rechten zijn om de config op te slaan
    '        fileIOPerm = New FileIOPermission(FileIOPermissionAccess.Write, filename.DirectoryName)
    '        If Not SecurityManager.IsGranted(fileIOPerm) Then
    '            Throw New Exception("U heeft niet voldoende rechten om configuratiefile op te slaan in " & filename.DirectoryName & "." & vbCrLf & "Vraag uw systeembeheerder dit e controleren")
    '        End If

    '        xSerializer.Serialize(MemeroyOutput, Me)
    '        MemeroyOutput.Position = 0
    '        xmldoc.Load(MemeroyOutput)
    '        xmldoc.Save(filename.ToString)
    '        xmldoc = Nothing

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Public Sub Save()
    '    Try
    '        Dim xmldoc As New XmlDocument
    '        Dim MemeroyOutput As New IO.MemoryStream
    '        Dim xSerializer As New XmlSerializer(Me.GetType)
    '        xSerializer.Serialize(MemeroyOutput, Me)
    '        MemeroyOutput.Position = 0
    '        xmldoc.Load(MemeroyOutput)
    '        xmldoc.Save(ConfigFile.FullName)
    '        xmldoc = Nothing
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    'Dim _MyConnectionString As String = ""
    'Public Property MyConnectionString() As String
    '    Get
    '        If String.IsNullOrEmpty(_MyConnectionString) Then
    '            Dim password As String = ""
    '            If BusinessObjects.CryptoService.Decrypt(MyProperties.password).ToUpper = "DEFAULT" Then
    '                password = ""
    '            Else
    '                password = BusinessObjects.CryptoService.Decrypt(MyProperties.password)
    '            End If

    '            _MyConnectionString = "server=" & MyProperties.ServerIP & ";" _
    '                               & "user id=" & MyProperties.Account & ";" _
    '                               & "password=" & password & ";" _
    '                               & "database= " & MyProperties.DataBase

    '        End If
    '        Return _MyConnectionString
    '    End Get
    '    Set(ByVal value As String)
    '        _MyConnectionString = value
    '    End Set
    'End Property
    Public Sub Load()
        Try

            Select Case ServiceType
                Case enServiceType.IBBCalendar
                    MyProperties = New SettingsIBBCalendar
                    'Case enServiceType.SMS
                    '    MyProperties = New SettingsSMS
                Case Else
                    Throw New Exception("Er is geen setting module opgegeven.")
            End Select

            Try
                MyRegKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\VBM\" & ServiceType.ToString, True)
            Catch ex As Exception
                MyRegKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\VBM\" & ServiceType.ToString, False)
            End Try

            If MyRegKey Is Nothing Then
                'dan moet de sleutel nog worden gemaakt en daarna de reg2 weer vullen.
                My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\VBM\" & ServiceType.ToString)
                MyRegKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\VBM\" & ServiceType.ToString, True)

            End If

            Dim props() As PropertyInfo = MyProperties.GetType().GetProperties()
            For Each prop As PropertyInfo In props
                Dim val As Object = MyRegKey.GetValue(prop.Name)
                If String.IsNullOrEmpty(val) Then
                    SetRegistry(prop.Name, GetProperty(Me.MyProperties, prop.Name, Nothing))
                End If
                SetProperty(Me.MyProperties, prop.Name, MyRegKey.GetValue(prop.Name))
            Next



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function SetRegistry(ByVal propertyName As String, ByVal val As Object) As Boolean
        Try
            'schrijf key + value in het register
            MyRegKey.SetValue(propertyName, val)

            Return True
        Catch
            Return False

        End Try
    End Function
    Function GetProperty(ByVal obj As Object, ByVal propertyName As String, ByVal val As Object) As Object

        Dim pi As System.Reflection.PropertyInfo = obj.GetType().GetProperty(propertyName)

        Try
            If pi Is Nothing Then
                Return False
            End If

            Return pi.GetValue(obj, val)
        Catch
            Return False
        End Try
    End Function
    Function SetProperty(ByVal obj As Object, ByVal propertyName As String, ByVal val As Object) As Boolean

        Dim pi As System.Reflection.PropertyInfo = obj.GetType().GetProperty(propertyName)

        Try
            If pi Is Nothing Then
                Return False
            End If

            ' convert the value to the expected type
            val = Convert.ChangeType(val, pi.PropertyType)

            ' attempt the assignment
            pi.SetValue(obj, val, Nothing)

            Return True
        Catch
            Return False
        End Try
    End Function


    Public Sub Save()
        Try
            Dim props() As PropertyInfo = MyProperties.GetType().GetProperties()
            For Each prop As PropertyInfo In props
                If SetRegistry(prop.Name, GetProperty(Me.MyProperties, prop.Name, Nothing)) = False Then
                    Throw New Exception("Indien u register aanpassingen wilt doorvoeren moet u de applicatie ''als administrator'' uitvoeren!")
                End If
            Next
            _Instance = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
