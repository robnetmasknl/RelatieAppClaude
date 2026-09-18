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
    Scan2
End Enum

<System.Xml.Serialization.XmlRoot("ServiceSettings")> _
Public Class ServiceSettings
    Inherits SettingObjects

    Private MySettingsBase As New SettingObjects
    Public MyProperties As Object
    Private MyRegKey As Microsoft.Win32.RegistryKey
    Private ServiceType As enServiceType

    Public Sub New()
        Load()
    End Sub
    Public Sub New(ByVal WhatService As enServiceType)
        ServiceType = WhatService
        Load()
    End Sub

    Public Sub Load()
        Try

            Select Case ServiceType
                Case enServiceType.Scan2
                    MyProperties = New SettingObjects
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
            ' _Instance = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
