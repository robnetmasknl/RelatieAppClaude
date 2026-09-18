Imports System.Windows.Forms
Imports BusinessObjects

Imports System.IO
'Imports ServiceSMS
Imports System.ServiceProcess


Public Class dlgSMS

    ''Private Settings As ServiceSettings = ServiceSettings.Instance(enServiceType.SMS)
    'Private Settings As New ServiceSettings(enServiceType.SMS)
    'Private URights As UserRights = UserRights.Instance
    'Private isServiceInstalled As Boolean = False
    'Private isServiceRunning As Boolean
    'Private myService As ServiceController

    'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    '    Try

    '        SaveSettings()

    '        MessageBox.Show("Wijzigingen zijn opgeslagen", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '        Me.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End Sub

    'Private Sub dlgSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Try
    '        If Not URights.IsInGroup("rel_admins") Then
    '            OK_Button.Enabled = False
    '            MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''rel_admins''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Text = Text & "U heeft NIET de voldoende rechten!"
    '        Else
    '            'Settings = New ServiceSettings
    '            Me.tbSMSHost.Text = Settings.MyProperties.smshost
    '            Me.tbSMSPort.Text = Settings.MyProperties.smsport

    '            Me.tbService.Text = Settings.MyProperties.ServiceName
    '            Me.tbStartTime.Text = Settings.MyProperties.StartTime
    '            Me.tbLogFilePath.Text = Settings.MyProperties.LogFilePath
    '            Me.tbLastRun.Text = Settings.MyProperties.LastRun


    '            CheckServiceInstallation()
    '            UpdateServiceStatus()
    '            Me.tmrCheckStatus.Enabled = True


    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Sub
    'Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
    '    myService.Continue()
    '    UpdateServiceStatus()
    'End Sub

    'Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
    '    myService.Pause()
    '    UpdateServiceStatus()
    'End Sub

    'Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
    '    myService.Stop()
    '    UpdateServiceStatus()
    'End Sub

    'Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
    '    myService.Start()
    '    UpdateServiceStatus()
    'End Sub

    'Private Sub tmrCheckStatus_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrCheckStatus.Tick
    '    UpdateServiceStatus()
    'End Sub
    'Private Sub UpdateServiceStatus()

    '    Me.tmrCheckStatus.Enabled = False

    '    If Not (myService Is Nothing) Then
    '        CheckServiceInstallation()

    '        Select Case myService.Status
    '            Case ServiceControllerStatus.Stopped
    '                Me.btnContinue.Enabled = False
    '                Me.btnPause.Enabled = False
    '                Me.btnStart.Enabled = True
    '                Me.btnStop.Enabled = False
    '            Case ServiceControllerStatus.Running
    '                Me.btnContinue.Enabled = False
    '                Me.btnPause.Enabled = True
    '                Me.btnStart.Enabled = False
    '                Me.btnStop.Enabled = True
    '            Case ServiceControllerStatus.Paused
    '                Me.btnContinue.Enabled = True
    '                Me.btnPause.Enabled = False
    '                Me.btnStart.Enabled = False
    '                Me.btnStop.Enabled = True
    '            Case Else
    '                Me.btnContinue.Enabled = False
    '                Me.btnPause.Enabled = False
    '                Me.btnStart.Enabled = False
    '                Me.btnStop.Enabled = False
    '        End Select

    '        Me.sslblService.Text = "Service Status: " + myService.Status.ToString()
    '    Else
    '        Me.btnContinue.Enabled = False
    '        Me.btnPause.Enabled = False
    '        Me.btnStart.Enabled = False
    '        Me.btnStop.Enabled = False
    '    End If

    '    Me.tmrCheckStatus.Enabled = True
    'End Sub
    'Private Sub CheckServiceInstallation()
    '    ' Verify to see if the service is installed.
    '    Try
    '        Dim installedServices() As ServiceController
    '        Dim tmpService As ServiceController
    '        Dim i As Integer = 0

    '        ' Shut off the timer so it doesn't raise events while were in this code
    '        Me.tmrCheckStatus.Enabled = False

    '        installedServices = ServiceController.GetServices()

    '        For Each tmpService In installedServices
    '            If tmpService.ServiceName = Settings.MyProperties.ServiceName Then
    '                isServiceInstalled = True
    '                myService = tmpService
    '            End If
    '        Next tmpService

    '        If myService Is Nothing Then
    '            Throw New Exception(Settings.MyProperties.ServiceName & " Service niet gevonden")
    '        End If

    '        Me.sslblService.Text = "ServiceType: " + myService.ServiceType.GetType.ToString
    '        Me.tmrCheckStatus.Enabled = True

    '    Catch ex As Exception
    '        Me.sslblService.Text = "CheckServiceInstallation: " & ex.Message
    '        Me.tmrCheckStatus.Enabled = True
    '    End Try
    'End Sub
    'Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
    '    Try
    '        With Me.fbdQueue
    '            .Reset()
    '            If String.IsNullOrEmpty(Me.tbLogFilePath.Text) Then
    '                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent)
    '            Else
    '                Environment.GetFolderPath(Environment.SpecialFolder.Recent)
    '                .SelectedPath = Me.tbLogFilePath.Text
    '            End If

    '            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                Me.tbLogFilePath.Text = .SelectedPath
    '            End If
    '        End With

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    'Private Sub SaveSettings()
    '    Try
    '        Settings.MyProperties.smshost = Me.tbSMSHost.Text
    '        Settings.MyProperties.smsport = Me.tbSMSPort.Text

    '        Settings.MyProperties.ServiceName = Me.tbService.Text
    '        Settings.MyProperties.StartTime = Me.tbStartTime.Text
    '        Settings.MyProperties.LogFilePath = Me.tbLogFilePath.Text
    '        Settings.MyProperties.LastRun = Me.tbLastRun.Text

    '        Settings.Save()
    '        'ServiceSettings._Instance = Nothing

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Private Sub lnkAbout_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAbout.LinkClicked
    '    'Dim frmAbout As New AboutBox
    '    'frmAbout.ShowDialog(Me)
    'End Sub

    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()
    'End Sub


    'Private Sub btnDll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDll.Click
    '    Try
    '        With Me.ofdDll
    '            .Reset()
    '            If String.IsNullOrEmpty(Me.tbSMSDllName.Text) Then
    '                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Recent)
    '            Else
    '                Environment.GetFolderPath(Environment.SpecialFolder.Recent)
    '                .InitialDirectory = Me.tbSMSDllName.Text
    '            End If

    '            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                Me.tbSMSDllName.Text = .FileName
    '            End If
    '        End With
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class
