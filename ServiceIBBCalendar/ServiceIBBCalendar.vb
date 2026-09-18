Imports BusinessObjects

Public Class ServiceIBBCalendar

    Private ServiceSettings As ServiceSettings

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Try
            ServiceSettings = New ServiceSettings(enServiceType.IBBCalendar)
            Timer1.Interval = 60000 'timer kijkt elke minuut of het wat moet doen 'was voorheen reg instelling ServiceSettings.MyProperties.Interval * 1000
            Timer1.Enabled = True
            Timer1.Start()

            EventLog.WriteEntry("IBBCalendar Service", "IBBCalendar Service was Started at " + DateTime.Now.ToString())
        Catch ex As Exception
            EventLog.WriteEntry("IBBCalendar Service", "On start: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            Timer1.Stop()

            EventLog.WriteEntry("IBBCalendar Service", "IBBCalendar Service was Stopped at " + DateTime.Now.ToString())
        Catch ex As Exception
            EventLog.WriteEntry("IBBCalendar Service", "On Stop: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        'System.Diagnostics.Debugger.Break()

        ServiceSettings = New ServiceSettings(enServiceType.IBBCalendar)
        Dim lastrun As DateTime = ServiceSettings.MyProperties.LastRun

        Dim StartUp As DateTime = ServiceSettings.MyProperties.StartTime

        If StartUp < DateTime.Now Then
            EventLog.WriteEntry("IBBCalendar Service", "IBBCalendar Service StartProcess at " + DateTime.Now.ToString())
            StartProcess()
        End If

        'If lastrun.Date = Today Then Exit Sub
        'Dim StartUp As DateTime = ServiceSettings.MyProperties.StartTime

        'If Now.TimeOfDay >= StartUp.TimeOfDay Then
        '    EventLog.WriteEntry("IBBCalendar Service", "IBBCalendar Service StartProcess at " + DateTime.Now.ToString())
        '    StartProcess()
        'End If

    End Sub

    Private WithEvents myCheckIBBCalendar As CheckIBBCalendar
    Private Complete As Boolean = False
    Private ExpHandler As Boolean = False
    Public Sub GenerateCompleteHandler(ByVal Ready As Boolean) Handles myCheckIBBCalendar.GenerateComplete
        Complete = True
    End Sub
    Public Sub GenerateExpHandler(ByVal exp As Exception) Handles myCheckIBBCalendar.GenerateExp
        ExpHandler = True
        EventLog.WriteEntry("IBBCalendar Service ", "Process error:" & exp.Message, EventLogEntryType.Error)
    End Sub
    Private Sub StartProcess()
        Try
            Timer1.Stop()
            ExpHandler = False

            If String.IsNullOrEmpty(ServiceSettings.MyProperties.ConfigFilePath) Then
                Throw New Exception("Geen Configfilepath in de ssettings gevonden")
            End If

            myCheckIBBCalendar = New CheckIBBCalendar(ServiceSettings.MyProperties.ConfigFilePath)
            Dim thCheckIBBCalendar As New System.Threading.Thread(AddressOf myCheckIBBCalendar.Process)

            myCheckIBBCalendar.LogFilepath = ServiceSettings.MyProperties.LogFilePath
            thCheckIBBCalendar.Start()
            thCheckIBBCalendar.Join()

            While Complete = False
                'wachtentotdieklaaris
                If ExpHandler = True Then
                    thCheckIBBCalendar.Abort()
                    ServiceSettings.LastRun = Now.AddDays(-1)
                    ServiceSettings.Save()
                    Exit While
                End If
            End While

            If ExpHandler = False Then 'álleen updaten als het goed is afgerond
                ServiceSettings.MyProperties.LastRun = Now
                ServiceSettings.MyProperties.StartTime = Now.AddMinutes(ServiceSettings.MyProperties.Interval)
                ServiceSettings.Save()
            End If

            Complete = False
           
        Catch ex As Exception
            Complete = True

            EventLog.WriteEntry("IBBCalendar Service ", "Process error:" & ex.Message, EventLogEntryType.Error)
        Finally
            Timer1.Start()
        End Try
    End Sub

End Class
