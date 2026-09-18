Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Web
Imports System.Reflection

Public Enum enSettingEnviroment
    App
    Web
    svc
End Enum

<System.Xml.Serialization.XmlRoot("applicationSettings")> _
Public Class Settings
    Inherits SettingsBase

    Private MySettingsBase As New SettingsBase
    Private _IsLoaded As Boolean = False

    Public Shared _Instance As Settings
    Public Shared Function Instance(Optional ByVal AlternativeConfig As String = Nothing) As Settings

        If _Instance Is Nothing Then
            If AlternativeConfig = Nothing Then
                _Instance = New Settings()
            Else
                _Instance = New Settings(AlternativeConfig)
            End If
        End If

        Return _Instance
    End Function

    <XmlIgnore()> _
    Public Property IsLoaded() As Boolean
        Get
            Return _IsLoaded
        End Get
        Set(ByVal value As Boolean)
            _IsLoaded = value
        End Set
    End Property
    Public Sub New()
        Load()
    End Sub
    Public Sub New(AlternativeConfig As String)
        AlternativeConfigPath = AlternativeConfig
        Load()
    End Sub

    Private _AlternativeConfigPath As String
    Public Property AlternativeConfigPath() As String
        Get
            Return _AlternativeConfigPath
        End Get
        Set(ByVal value As String)
            _AlternativeConfigPath = value
        End Set
    End Property

  
    Public Overridable ReadOnly Property SettingEnvironment() As enSettingEnviroment
        Get
            If HttpContext.Current Is Nothing Then
                Return enSettingEnviroment.App
            Else
                Return enSettingEnviroment.Web
            End If
        End Get
    End Property

    Private Function ConfigFile() As System.IO.FileInfo
        Try
            'System.Diagnostics.Debugger.Break()
            Dim _ApplicationData As String = ""
            If Not String.IsNullOrEmpty(AlternativeConfigPath) Then
                _ApplicationData = System.IO.Path.GetDirectoryName(AlternativeConfigPath)
            ElseIf SettingEnvironment = enSettingEnviroment.App Then
                _ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\RelatieApp"
            ElseIf SettingEnvironment = enSettingEnviroment.Web Then
                _ApplicationData = HttpContext.Current.Server.MapPath("~") & "\VBM"
            End If

            LogFilePath = _ApplicationData

            Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(_ApplicationData & "\RelatieApp.config")

            'Als configfile nog niet bestaan maak dan de default aan
            If Not FileInfo.Exists Then CreateFirstConfig(FileInfo)

            Return FileInfo
        Catch ex As Exception
            'Throw New Exception("ConfigFile")
            Throw ex
        End Try
    End Function
    Public Sub Load()
        Try
            If IsLoaded Then Exit Sub
            IsLoaded = True

            Dim xDeSerializer As XmlSerializer
            Dim xTextReader As XmlTextReader
            xDeSerializer = New XmlSerializer(MySettingsBase.GetType)
            xTextReader = New XmlTextReader(File.OpenText(ConfigFile.FullName))
            xTextReader.Namespaces = False

            'laad de gevonden settings
            MySettingsBase = xDeSerializer.Deserialize(xTextReader)
            xTextReader.Close()

            Dim props() As PropertyInfo = MySettingsBase.GetType().GetProperties()
            For Each prop As PropertyInfo In props
                SetProperty(Me, prop.Name, prop.GetValue(MySettingsBase, Nothing))
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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

    Private Sub CreateFirstConfig(ByVal filename As System.IO.FileInfo)
        Try
            Dim xmldoc As New XmlDocument
            Dim MemeroyOutput As New IO.MemoryStream
            Dim xSerializer As New XmlSerializer(Me.GetType)

            Dim fileIOPerm As FileIOPermission
            'controleren of er genoeg rechten zijn om de configmap op te slaan
            fileIOPerm = New FileIOPermission(FileIOPermissionAccess.Write, filename.DirectoryName.Replace("\RelatieApp", ""))
            If Not SecurityManager.IsGranted(fileIOPerm) Then
                Throw New Exception("U heeft niet voldoende rechten om configuratiemap te maken in " & filename.DirectoryName.Replace("\RelatieApp", "") & "." & vbCrLf & "Vraag uw systeembeheerder dit e controleren")
            End If

            Dim di As New IO.DirectoryInfo(filename.DirectoryName)
            If Not di.Exists Then di.Create()

            'controleren of er genoeg rechten zijn om de config op te slaan
            fileIOPerm = New FileIOPermission(FileIOPermissionAccess.Write, filename.DirectoryName)
            If Not SecurityManager.IsGranted(fileIOPerm) Then
                Throw New Exception("U heeft niet voldoende rechten om configuratiefile op te slaan in " & filename.DirectoryName & "." & vbCrLf & "Vraag uw systeembeheerder dit e controleren")
            End If

            'probeer een copy op te halen vanuit het programma directory
            Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(My.Application.Info.DirectoryPath & "\RelatieApp.config")
            If FileInfo.Exists Then
                FileInfo.CopyTo(filename.ToString)
            Else
                xSerializer.Serialize(MemeroyOutput, Me)
                MemeroyOutput.Position = 0
                xmldoc.Load(MemeroyOutput)
                xmldoc.Save(filename.ToString)
            End If

            xmldoc = Nothing

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Save()
        Try
            Dim xmldoc As New XmlDocument
            Dim MemeroyOutput As New IO.MemoryStream
            Dim xSerializer As New XmlSerializer(Me.GetType)
            xSerializer.Serialize(MemeroyOutput, Me)
            MemeroyOutput.Position = 0
            xmldoc.Load(MemeroyOutput)
            xmldoc.Save(ConfigFile.FullName)
            xmldoc = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
