Public Class ServiceOpzeggingen


    'Private Settings As ServiceSettings = ServiceSettings.Instance(enServiceType.Opzeggingen)
    Private ServiceSettings As ServiceSettings

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Try
            ServiceSettings = New ServiceSettings(enServiceType.Opzeggingen)
            Timer1.Interval = ServiceSettings.MyProperties.Interval * 1000
            Timer1.Enabled = True
            Timer1.Start()

            EventLog.WriteEntry("Opzeggingen Service", "Opzeggingen Service was Started at " + DateTime.Now.ToString())
        Catch ex As Exception
            EventLog.WriteEntry("Opzeggingen Service", "On start: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Try
            Timer1.Stop()

            EventLog.WriteEntry("Opzeggingen Service", "Opzeggingen Service was Stopped at " + DateTime.Now.ToString())
        Catch ex As Exception
            EventLog.WriteEntry("Opzeggingen Service", "On Stop: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        'System.Diagnostics.Debugger.Break()

        ServiceSettings = New ServiceSettings(enServiceType.Opzeggingen)
        Dim lastrun As Date = ServiceSettings.MyProperties.Lastrun
        If lastrun.Date = Today Then Exit Sub
        Dim StartUp As Date = ServiceSettings.MyProperties.starttime
        If Now.TimeOfDay >= StartUp.TimeOfDay Then
            EventLog.WriteEntry("Opzeggingen Service", "Opzeggingen Service StartProcess at " + DateTime.Now.ToString())
            StartProcess()

        End If

    End Sub

    Private WithEvents _thOpzeggingen As CheckOpzeggingen
    Private Complete As Boolean = False
    Private ExpHandler As Boolean = False
    Public Sub GenerateCompleteHandler(ByVal Ready As Boolean) Handles _thOpzeggingen.GenerateComplete
        Complete = True
    End Sub
    Public Sub GenerateExpHandler(ByVal exp As Exception) Handles _thOpzeggingen.GenerateExp
        ExpHandler = True
    End Sub


    Private Sub StartProcess()
        Try
            Timer1.Stop()

            _thOpzeggingen = New CheckOpzeggingen
            Dim thOpzeggingen As New System.Threading.Thread(AddressOf _thOpzeggingen.Process)
            _thOpzeggingen.LogFilepath = ServiceSettings.MyProperties.LogFilePath
            thOpzeggingen.Start()
            thOpzeggingen.Join()

            While Complete = False
                'wachtentotdieklaaris
                If ExpHandler = True Then
                    thOpzeggingen.Abort()
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

            StartElcoProcess()

            If ServiceSettings.MyProperties.ResetXRcise Then
                StartXRCiseProcess()
            End If


            Timer1.Start()

        Catch ex As Exception
            Complete = True

            ' EventLog.WriteEntry("VBMServices", "On Stop: " & ex.Message, EventLogEntryType.Error)

            EventLog.WriteEntry("Opzeggingen Service ", "Process error:" & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private WithEvents _thResetElco As ResetElco
    Private CompleteElco As Boolean = False
    Private ExpHandlerElco As Boolean = False
    Public Sub GenerateCompleteElcoHandler(ByVal Ready As Boolean) Handles _thResetElco.GenerateComplete
        CompleteElco = True
    End Sub
    Public Sub GenerateExpElcoHandler(ByVal exp As Exception) Handles _thResetElco.GenerateExp
        ExpHandlerElco = True
    End Sub
    Private Sub StartElcoProcess()
        Try
            'Timer1.Stop()

            _thResetElco = New ResetElco
            Dim thResetElco As New System.Threading.Thread(AddressOf _thResetElco.Process)
            _thResetElco.LogFilepath = ServiceSettings.MyProperties.LogFilePath
            thResetElco.Start()
            thResetElco.Join()

            While CompleteElco = False
                'wachtentotdieklaaris
                If ExpHandlerElco = True Then
                    thResetElco.Abort()
                    Exit While
                End If
            End While

            CompleteElco = False
            Timer1.Start()

        Catch ex As Exception
            CompleteElco = True
            EventLog.WriteEntry("Reset Elco Service ", "Process error:" & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private WithEvents _thXRCise As CheckXRCise
    Private CompleteXRCise As Boolean = False
    Private ExpHandlerXRCise As Boolean = False
    Public Sub GenerateCompleteXRCiseHandler(ByVal Ready As Boolean) Handles _thXRCise.GenerateComplete
        CompleteXRCise = True
    End Sub

    Public Sub GenerateExpXRCiseHandler(ByVal exp As Exception) Handles _thXRCise.GenerateExp
        ExpHandlerXRCise = True
    End Sub
    Private Sub StartXRCiseProcess()
        Try
            'Bug:1758 was updated - XRCise op 0 zetten indien ouder dan 35 jaar

            _thXRCise = New CheckXRCise
            Dim thXRCise As New System.Threading.Thread(AddressOf _thXRCise.Process)
            _thXRCise.LogFilepath = ServiceSettings.MyProperties.LogFilePath
            thXRCise.Start()
            thXRCise.Join()

            While CompleteElco = False
                'wachtentotdieklaaris
                If ExpHandlerXRCise = True Then
                    thXRCise.Abort()
                    Exit While
                End If
            End While

            CompleteXRCise = False
            Timer1.Start()

        Catch ex As Exception
            CompleteElco = True
            EventLog.WriteEntry(" XRCise Service ", "Process error:" & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub
End Class
