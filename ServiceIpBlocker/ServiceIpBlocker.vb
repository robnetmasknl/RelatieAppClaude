Public Class ServiceIpBlocker
    Private ServiceSettings As ServiceSettings

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Try
            ServiceSettings = New ServiceSettings(enServiceType.IpBlocker)
            Timer1.Interval = ServiceSettings.MyProperties.Interval * 1000
            Timer1.Enabled = True
            Timer1.Start()

            EventLog.WriteEntry("IpBlocker Service", "IpBlocker Service was Started at " + DateTime.Now.ToString())
        Catch ex As Exception
            EventLog.WriteEntry("IpBlocker Service", "On start: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            Timer1.Stop()

            EventLog.WriteEntry("IpBlocker Service", "IpBlocker Service was Stopped at " + DateTime.Now.ToString())
        Catch ex As Exception
            EventLog.WriteEntry("IpBlocker Service", "On Stop: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub
    Private Sub Timer1_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        'System.Diagnostics.Debugger.Break()

        ServiceSettings = New ServiceSettings(enServiceType.Opzeggingen)
        Dim lastrun As Date = ServiceSettings.MyProperties.Lastrun
        If lastrun.Date = Today Then Exit Sub
        Dim StartUp As Date = ServiceSettings.MyProperties.starttime
        If Now.TimeOfDay >= StartUp.TimeOfDay Then
            EventLog.WriteEntry("IpBlocker Service", "IpBlocker Service StartProcess at " + DateTime.Now.ToString())
            StartProcess()
        End If

    End Sub
    Private WithEvents _thCleanIpAddresses As CleanIpAddresses
    Private Complete As Boolean = False
    Private ExpHandler As Boolean = False
    Public Sub GenerateCompleteHandler(ByVal Ready As Boolean) Handles _thCleanIpAddresses.GenerateComplete
        Complete = True
    End Sub
    Public Sub GenerateExpHandler(ByVal exp As Exception) Handles _thCleanIpAddresses.GenerateExp
        ExpHandler = True
    End Sub
    Private Sub StartProcess()
        Try
            Timer1.Stop()

            _thCleanIpAddresses = New CleanIpAddresses
            Dim thCleanIpAddresses As New System.Threading.Thread(AddressOf _thCleanIpAddresses.Process)
            _thCleanIpAddresses.LogFilepath = ServiceSettings.MyProperties.LogFilePath
            thCleanIpAddresses.Start()
            thCleanIpAddresses.Join()

            While Complete = False
                'wachtentotdieklaaris
                If ExpHandler = True Then
                    thCleanIpAddresses.Abort()
                    'ServiceSettings.MyProperties.lastrun = Now.AddDays(-1)
                    'ServiceSettings.Save()
                    Exit While
                End If
            End While

            If ExpHandler = False Then 'álleen updaten als het goed is afgerond
                ServiceSettings.MyProperties.lastrun = Now
                ServiceSettings.Save()
            End If

            Complete = False
            Timer1.Start()

        Catch ex As Exception
            Complete = True

            EventLog.WriteEntry("IpBlocker Service ", "Process error:" & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

End Class
