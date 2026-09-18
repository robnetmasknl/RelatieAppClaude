Imports System.Windows.Forms
Imports System.IO
Imports ServiceScan2
Imports System.ServiceProcess
Imports BusinessObjects


Public Class dlgSettings
    Private Settings As ServiceSettings
    Private URights As UserRights = UserRights.Instance
    Private isServiceInstalled As Boolean = False
    Private isServiceRunning As Boolean
    Private myService As ServiceController
    Private da As DataAccess


    Private Sub dlgSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not URights.IsInGroup("rel_admins") Then
                OK_Button.Enabled = False
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''rel_admins''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Text = Text & "U heeft NIET de voldoende rechten!"
            Else

                Settings = New ServiceSettings(enServiceType.Scan2)

                With Settings.MyProperties
                    Me.tbConfigFile.Text = .DataAccessConfigFile
                    Me.tbService.Text = .ServiceName
                    Me.dtpStartTime.Value = .StartTime
                    Me.tbLogFilePath.Text = .LogFilePath
                    Me.tbLastRun.Text = .LastRun
                    Me.tbInterval.Text = .Interval
                    Me.tbQueuePath.Text = .ScanDir
                    Me.tbExtensions.Text = .Extensions
                End With

                da = New DataAccess(Settings.MyProperties.DataAccessConfigFile)

                tbServer.Text = da.Settings.ServerIP
                tbDatabase.Text = da.Settings.DataBase
                tbAccount.Text = da.Settings.Account
                tbPassword.Text = CryptoService.Decrypt(da.Settings.password)

                CheckServiceInstallation()
                UpdateServiceStatus()
                Me.tmrCheckStatus.Enabled = True


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Try

            SaveSettings()

            MessageBox.Show("Wijzigingen zijn opgeslagen", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveSettings()
        Try

            da.Settings.ServerIP = tbServer.Text
            da.Settings.DataBase = tbDatabase.Text
            da.Settings.Account = tbAccount.Text
            If String.IsNullOrEmpty(tbPassword.Text) Then
                da.Settings.password = CryptoService.Encrypt("default")
            Else
                da.Settings.password = CryptoService.Encrypt(tbPassword.Text)
            End If

            With Settings.MyProperties
                .DataAccessConfigFile = Me.tbConfigFile.Text
                .ServiceName = Me.tbService.Text
                .StartTime = Me.dtpStartTime.Value
                .LogFilePath = Me.tbLogFilePath.Text
                .LastRun = Me.tbLastRun.Text
                .Interval = Me.tbInterval.Text
                .ScanDir = Me.tbQueuePath.Text
                .Extensions = Me.tbExtensions.Text
            End With

            da.Settings.Save()
            Settings.Save()

            '  ServiceSettings._Instance = Nothing

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        myService.Continue()
        UpdateServiceStatus()
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        myService.Pause()
        UpdateServiceStatus()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        myService.Stop()
        UpdateServiceStatus()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        SaveSettings()
        myService.Start()
        UpdateServiceStatus()
    End Sub

    Private Sub tmrCheckStatus_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrCheckStatus.Tick
        UpdateServiceStatus()
    End Sub
    Private Sub UpdateServiceStatus()

        Me.tmrCheckStatus.Enabled = False

        If Not (myService Is Nothing) Then
            CheckServiceInstallation()

            Select Case myService.Status
                Case ServiceControllerStatus.Stopped
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = True
                    Me.btnStop.Enabled = False
                Case ServiceControllerStatus.Running
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = True
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = True
                Case ServiceControllerStatus.Paused
                    Me.btnContinue.Enabled = True
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = True
                Case Else
                    Me.btnContinue.Enabled = False
                    Me.btnPause.Enabled = False
                    Me.btnStart.Enabled = False
                    Me.btnStop.Enabled = False
            End Select

            Me.sslblService.Text = "Service Status: " + myService.Status.ToString()
        Else
            Me.btnContinue.Enabled = False
            Me.btnPause.Enabled = False
            Me.btnStart.Enabled = False
            Me.btnStop.Enabled = False
        End If

        Me.tmrCheckStatus.Enabled = True
    End Sub
    Private Sub CheckServiceInstallation()
        ' Verify to see if the service is installed.
        Try
            Dim installedServices() As ServiceController
            Dim tmpService As ServiceController
            Dim i As Integer = 0

            ' Shut off the timer so it doesn't raise events while were in this code
            Me.tmrCheckStatus.Enabled = False

            installedServices = ServiceController.GetServices()

            For Each tmpService In installedServices
                If tmpService.ServiceName = Settings.ServiceName Then
                    isServiceInstalled = True
                    myService = tmpService
                End If
            Next tmpService

            If myService Is Nothing Then
                Throw New Exception(Settings.ServiceName & " Service niet gevonden")
            End If

            Me.sslblService.Text = "ServiceType: " + myService.ServiceType.GetType.ToString
            Me.tmrCheckStatus.Enabled = True

        Catch ex As Exception
            Me.sslblService.Text = "Check Service Installation: " & ex.Message
            Me.tmrCheckStatus.Enabled = True
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            With Me.ofdConfig
                .Reset()
                If String.IsNullOrEmpty(Me.tbConfigFile.Text) Then
                    .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                Else
                    Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                    .InitialDirectory = Me.tbConfigFile.Text
                End If

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.tbConfigFile.Text = .FileName
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFile_Click_1(sender As Object, e As EventArgs) Handles btnFile.Click
        Try
            With Me.fbdQueue
                .Reset()
                If String.IsNullOrEmpty(Me.tbQueuePath.Text) Then
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                Else
                    Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                    .SelectedPath = Me.tbQueuePath.Text
                End If

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.tbQueuePath.Text = .SelectedPath
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            With Me.fbdQueue
                .Reset()
                If String.IsNullOrEmpty(Me.tbLogFilePath.Text) Then
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                Else
                    Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                    .SelectedPath = Me.tbLogFilePath.Text
                End If

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.tbLogFilePath.Text = .SelectedPath
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
