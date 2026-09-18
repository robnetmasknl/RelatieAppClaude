Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Web
Imports System.Reflection

Public Enum enServiceType
    Opzeggingen
    SMS
    IpBlocker
End Enum

Public Class ServiceSettings

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

    Public Property IsLoaded() As Boolean
        Get
            Return _IsLoaded
        End Get
        Set(ByVal value As Boolean)
            _IsLoaded = value
        End Set
    End Property
    Public Sub New(ByVal WhatService As enServiceType)
        ServiceType = WhatService
        Load()
    End Sub
    Dim _MyConnectionString As String = ""
    Public Property MyConnectionString() As String
        Get
            If String.IsNullOrEmpty(_MyConnectionString) Then
                Dim password As String = ""
                If BusinessObjects.CryptoService.Decrypt(MyProperties.password).ToUpper = "DEFAULT" Then
                    password = ""
                Else
                    password = BusinessObjects.CryptoService.Decrypt(MyProperties.password)
                End If

                _MyConnectionString = "server=" & MyProperties.ServerIP & ";" _
                                   & "user id=" & MyProperties.Account & ";" _
                                   & "password=" & password & ";" _
                                   & "database= " & MyProperties.DataBase

            End If
            Return _MyConnectionString
        End Get
        Set(ByVal value As String)
            _MyConnectionString = value
        End Set
    End Property
    Public Sub Load()
        Try

            Select Case ServiceType
                Case enServiceType.IpBlocker
                    MyProperties = New SettingsIpBlocker
                Case Else
                    Throw New Exception("Er is geen setting module opgegeven.")
            End Select


            MyRegKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\VBMNOV\" & ServiceType.ToString, True)
            If MyRegKey Is Nothing Then
                'dan moet de sleutel nog worden gemaakt en daarna de reg2 weer vullen.
                My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\VBMNOV\" & ServiceType.ToString)
                MyRegKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\VBMNOV\" & ServiceType.ToString, True)

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
                SetRegistry(prop.Name, GetProperty(Me.MyProperties, prop.Name, Nothing))
            Next
            _Instance = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
