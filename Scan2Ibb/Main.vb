Imports BusinessObjects
Imports System.IO
Imports System.ServiceProcess
Imports ServiceScan2


Public Class Main

    Private da As DataAccess
    Private ServiceSettings As ServiceSettings

    Delegate Sub SetTextCallback(ByVal [text] As String)
    Private lstViewItem As ListViewItem = New ListViewItem()

    Private isServiceInstalled As Boolean = False
    Private isServiceRunning As Boolean
    Private myService As ServiceController

    Private _QueuePath As String
    Private _ProcessedPath As String
    Private _BackupPath As String
    Private _ReportPath As String


    Public Property QueuePath() As String
        Get
            Return _QueuePath
        End Get
        Set(ByVal value As String)
            _QueuePath = value
        End Set
    End Property
    Public Property ProcessedPath() As String
        Get
            Return _ProcessedPath
        End Get
        Set(ByVal value As String)
            _ProcessedPath = value
        End Set
    End Property
    Public Property BackupPath() As String
        Get
            Return _BackupPath
        End Get
        Set(ByVal value As String)
            _BackupPath = value
        End Set
    End Property
    Public Property ReportPath() As String
        Get
            Return _ReportPath
        End Get
        Set(ByVal value As String)
            _ReportPath = value
        End Set
    End Property

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Init()
            lstvRefused.Columns.Add("geprobeerd om", 125, HorizontalAlignment.Left)
            lstvRefused.Columns.Add("Bestanddatum", 125, HorizontalAlignment.Left)
            lstvRefused.Columns.Add("Filename", 200, HorizontalAlignment.Left)
            lstvRefused.Columns.Add("Dossier", 125, HorizontalAlignment.Center)
            lstvRefused.Columns.Add("2Ibb", 50, HorizontalAlignment.Center)
            lstvRefused.View = View.Details

            lstvProcessed.Columns.Add("gearchiveerd op", 125, HorizontalAlignment.Left)
            lstvProcessed.Columns.Add("Bestanddatum", 125, HorizontalAlignment.Left)
            lstvProcessed.Columns.Add("Filename", 200, HorizontalAlignment.Left)
            lstvProcessed.Columns.Add("Dossier", 125, HorizontalAlignment.Center)
            lstvProcessed.Columns.Add("2Ibb", 50, HorizontalAlignment.Center)
            lstvProcessed.View = View.Details

            'tmrReader.Stop()
            'myService = New ServiceController
            CheckServiceInstallation()
            UpdateServiceStatus()
            Me.tmrCheckStatus.Enabled = True
            ' Me.tmrReader.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Init()
        Try

            ServiceSettings = New ServiceSettings(enServiceType.Scan2)

            da = New DataAccess(ServiceSettings.MyProperties.DataAccessConfigFile)


            If da.IsNetmask Then
                Me.Text = "Scan2Ibb[IsNetmask] "
            End If
            tmrReadQ.Interval = tbLogInterval.Text * 1000
            btnReader.Text = "Start"

            'Utils = New ScanLibrary.Utilities
            'QueuePath = ScanSettings.ScanDir
            'ProcessedPath = ScanSettings.ScanDir
            'tmrReadQ.Interval = ScanSettings.Seconds * 100


            'ReadLog()

        Catch ex As Exception
            EventLog.WriteEntry("Scan2Ibb", "init: form:" & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub
    Private Sub mnuitem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuitem.Click
        Try
            tmrReadQ.Stop()
            btnReader.Text = "Stop"
            Dim frm As New dlgSettings
            frm.ShowDialog()
            Init()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    
    Public Function ValidateDocument(ByVal FileNameNoExt As String) As Boolean
        Try
            Dim success As Boolean = False
            Dim sNumber As String = ""
            Dim iNumber As Integer = -1

            If FileNameNoExt.Length < 9 Then Return False
            If FileNameNoExt.Contains(" ") Then Return False
            If Not FileNameNoExt.Contains("_") Then Return False
            sNumber = FileNameNoExt.Substring(0, FileNameNoExt.IndexOf("_"))
            If sNumber.Length < 8 Then Return False
            If Not Integer.TryParse(sNumber, iNumber) Then Return False


            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private WithEvents myCheckScanFiles As CheckScanFiles
    Private Complete As Boolean = False
    Private ExpHandler As Boolean = False

    Public Sub GenerateCompleteHandler(ByVal Ready As Boolean) Handles myCheckScanFiles.GenerateComplete
        Complete = True
    End Sub
    Public Sub GenerateExpHandler(ByVal exp As Exception) Handles myCheckScanFiles.GenerateExp
        ExpHandler = True
        EventLog.WriteEntry("Scan2Ibb Service ", "Process error:" & exp.Message, EventLogEntryType.Error)
    End Sub

    Private Sub start()
    
        Try
            tmrReadQ.Stop()

            ExpHandler = False

            If String.IsNullOrEmpty(ServiceSettings.MyProperties.DataAccessConfigFile) Then
                Throw New Exception("Geen DataAccessConfigFile in de settings gevonden")
            End If

            myCheckScanFiles = New CheckScanFiles(ServiceSettings.MyProperties.DataAccessConfigFile)
            Dim thCheckScanFiles As New System.Threading.Thread(AddressOf myCheckScanFiles.Process)

            myCheckScanFiles.LogFilepath = ServiceSettings.MyProperties.LogFilePath
            myCheckScanFiles.ServiceSettings = ServiceSettings
            ReadLog()
            thCheckScanFiles.Start()
            thCheckScanFiles.Join()

            While Complete = False
                'wachtentotdieklaaris
                If ExpHandler = True Then
                    thCheckScanFiles.Abort()
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

            EventLog.WriteEntry("Scan2Ibb Service ", "Process error:" & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message)
        Finally
            tmrReadQ.Start()
        End Try

    End Sub
    Private Sub ReadLog()
        Try
            Dim objReader As StreamReader
            objReader = myCheckScanFiles.ReadLog(True)
            lstvProcessed.Items.Clear()
            Dim ProcessedList As New List(Of String)

            Do While objReader.Peek() >= 0
                ProcessedList.Add(objReader.ReadLine)
            Loop
            objReader.Close()

            ProcessedList.Reverse()
            For Each line As String In ProcessedList
                SetlstvProcessed(line)
            Next

            Dim RefusedList As New List(Of String)

            objReader = myCheckScanFiles.ReadLog(False)
            lstvRefused.Items.Clear()
            Do While objReader.Peek() >= 0
                RefusedList.Add(objReader.ReadLine)
            Loop
            objReader.Close()

            RefusedList.Reverse()
            For Each line As String In RefusedList
                SetlstvRefused(line)
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetlstvRefused(ByVal [text] As String)

        If Me.lstvRefused.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetlstvRefused)
            Me.Invoke(d, New Object() {[text]})
        Else
            Dim aText As Array
            lstViewItem = New ListViewItem()
            aText = text.Split(";")
            For i As Integer = 0 To UBound(aText)
                If i = 0 Then
                    lstViewItem.Text = aText(i)
                ElseIf i = 1 Then
                    lstViewItem.SubItems.Add(aText(i))
                    lstViewItem.Name = aText(i)
                Else
                    lstViewItem.SubItems.Add(aText(i))
                End If
            Next i
            lstvRefused.Items.Add(lstViewItem)
            ' lstvRefused.EnsureVisible(lstvRefused.Items.Count - 1)
            lstViewItem = Nothing
        End If
    End Sub
    Private Sub SetlstvProcessed(ByVal [text] As String)

        If Me.lstvProcessed.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetlstvProcessed)
            Me.Invoke(d, New Object() {[text]})
        Else
            Dim aText As Array
            lstViewItem = New ListViewItem()
            aText = text.Split(";")
            For i As Integer = 0 To UBound(aText)
                If i = 0 Then
                    lstViewItem.Text = aText(i)
                ElseIf i = 1 Then
                    lstViewItem.SubItems.Add(aText(i))
                    lstViewItem.Name = aText(i)
                Else
                    lstViewItem.SubItems.Add(aText(i))
                End If
            Next i
            lstvProcessed.Items.Add(lstViewItem)
            ' lstvProcessed.EnsureVisible(lstvProcessed.Items.Count - 1)
            lstViewItem = Nothing
        End If
    End Sub
    Private Sub tmrReadQ_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrReadQ.Tick
        'If da.IsNetmask Then ReadFiles()
        start()
    End Sub

    Private Sub tbLogInterval_TextChanged(sender As Object, e As EventArgs) Handles tbLogInterval.TextChanged
        Try
            btnReader.Text = "Stop"
            tmrReadQ.Stop()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnReader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReader.Click
        Try
            If btnReader.Text.ToUpper = "START" Then
                Init()
                btnReader.ImageIndex = 4
                btnReader.Text = "Stop"
                tmrReadQ.Start()
            Else
                btnReader.ImageIndex = 5
                btnReader.Text = "Start"
                tmrReadQ.Stop()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

            'Me.sbrServiceStatus.Text = "Service Status: " + myService.Status.ToString()
            Me.sbp1.Text = "Service Status: " + myService.Status.ToString()
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
                If tmpService.ServiceName = ServiceSettings.ServiceName Then
                    isServiceInstalled = True
                    myService = tmpService
                End If
            Next tmpService

            If myService Is Nothing Then
                Throw New Exception(ServiceSettings.ServiceName & " Service niet gevonden")
            End If

            Me.sbp2.Text = "Service name: " + myService.DisplayName
            Me.tmrCheckStatus.Enabled = True

        Catch ex As Exception
            Me.sbp2.Text = "CheckServiceInstallation: " & ex.Message
            Me.tmrCheckStatus.Enabled = True
        End Try
    End Sub
    'Private Sub ReadFiles()
    '    Try
    '        tmrReadQ.Stop()

    '        Dim FileListQueue As New List(Of IO.FileInfo)
    '        Dim diQueue As New IO.DirectoryInfo(Settings.MyProperties.ScanDir)
    '        FileListQueue.AddRange(diQueue.GetFiles("*.pdf", IO.SearchOption.AllDirectories))

    '        Dim _Document As IBBDocument
    '        Dim b2Ibb As Boolean = False
    '        Dim b2Wissel As Boolean = False
    '        If FileListQueue.Count > 0 Then
    '            For Each _file As IO.FileInfo In FileListQueue
    '                'controleer of er een setting.ini file aanwezig is.
    '                Dim CheckIniFile As New FileInfo(_file.Directory.FullName & "\settings.ini")
    '                ' indien niet het geval, dan deze file over slaan
    '                If Not CheckIniFile.Exists Then Continue For
    '                ' indien wel, dan gegevens uitlezen voor opslag en verwerking
    '                Dim myIniFile As New IniFile(_file.Directory.FullName & "\settings.ini")
    '                Dim bMailExpert As Boolean = myIniFile.GetBoolean("scan", "MailExpert", False)
    '                Dim IniDocumentMap As String = myIniFile.GetString("scan", "DocumentMap", "")
    '                Dim IniDocumentExt As String = myIniFile.GetString("scan", "DocumentExt", _file.Extension.Remove(0, 1))
    '                Dim IniWisselmap As String = myIniFile.GetString("scan", "Wisselmap", "")

    '                b2Wissel = False
    '                'Vervang eventuele spatie door streepje en pak hem opnieuw op
    '                If _file.Name.Contains(" ") Then
    '                    _file.MoveTo(_file.FullName.Replace(" ", "_"))
    '                    Continue For
    '                End If
    '                If Not String.IsNullOrEmpty(IniWisselmap) Then
    '                    Dim newName As String = _file.Name
    '                    Dim TestFile As New IO.FileInfo(IniWisselmap & "\" & newName)
    '                    Dim i As Integer = 1
    '                    Do Until TestFile.Exists = False
    '                        newName = i & "_" & _file.Name
    '                        TestFile = New IO.FileInfo(IniWisselmap & "\" & newName)
    '                        i += 1
    '                    Loop
    '                    _file.CopyTo(IniWisselmap & "\" & newName)
    '                    b2Wissel = True
    '                End If
    '                'If _file.Name.StartsWith(Me.ScanSettings.CopyChar) Then
    '                '    _file.Name.Replace(Me.ScanSettings.CopyChar, "")
    '                '    _file.MoveTo(_file.FullName.Replace(Me.ScanSettings.CopyChar, ""))

    '                '    Dim newName As String = _file.Name.Replace(Me.ScanSettings.CopyChar, "")
    '                '    Dim TestFile As New IO.FileInfo(Me.ScanSettings.CopyDir & "\" & newName)
    '                '    Dim i As Integer = 1
    '                '    Do Until TestFile.Exists = False
    '                '        newName = i & "_" & _file.Name
    '                '        TestFile = New IO.FileInfo(Me.ScanSettings.CopyDir & "\" & newName)
    '                '        i += 1
    '                '    Loop
    '                '    _file.CopyTo(Me.ScanSettings.CopyDir & "\" & newName)
    '                '    b2Wissel = True
    '                '    'Continue For
    '                'End If
    '                'Controleer of het document aan alle eisen voldoet
    '                b2Ibb = ValidateDocument(_file.Name.Replace(_file.Extension, ""))
    '                If b2Ibb Then
    '                    _Document = New IBBDocument
    '                    With _Document
    '                        '.bestandsExtensie = _file.Extension.Remove(0, 1)
    '                        '.ProcessFileName(_file.Name)
    '                        '.autorisatie_relaties = ScanSettings.hoofdrelatie_id
    '                        '.bestandOrigineel = _file.FullName
    '                        '.bestandsDatum = _file.CreationTime.ToOADate
    '                        '.upgeloadOp = Today.ToOADate
    '                        '.bestandsGrootte = _file.Length
    '                        '.bestandsSubtype = .bestandsExtensie
    '                        '.bestandsType = "application"
    '                        '.soort = "dossier"
    '                        '.OrgExtentie = IniDocumentExt
    '                        'b2Ibb = .Save()
    '                        'If b2Ibb Then
    '                        '    .MoveFile(_file)
    '                        '    If bMailExpert Then .sendmail() '15028008
    '                        'End If
    '                    End With
    '                End If

    '                'Schrijf het resultaat weg in logfile
    '                WriteFile()
    '                Utils.WriteLog(_file.CreationTime & ";" & _file.Name & ";" & b2Ibb.ToString & ";" & b2Wissel.ToString, b2Ibb)
    '                'niet gelukt dan verplaatsen
    '                Dim di As New DirectoryInfo(Me.Settings.MyProperties.ScanDir & "\False\")
    '                If Not di.Exists Then di.Create()
    '                If Not b2Ibb Then
    '                    Dim newName As String = _file.Name
    '                    Dim TestFile As New IO.FileInfo(di.FullName & newName)
    '                    Dim i As Integer = 1
    '                    Do Until TestFile.Exists = False
    '                        newName = i & "_" & _file.Name
    '                        TestFile = New IO.FileInfo(di.FullName & newName)
    '                        i += 1
    '                    Loop
    '                    _file.MoveTo(di.FullName & newName)
    '                End If

    '            Next
    '        End If

    '        FileListQueue = Nothing
    '        _Document = Nothing

    '    Catch ex As Exception
    '        EventLog.WriteEntry("Scan2Ibb Service", ex.Message, EventLogEntryType.Error)
    '    Finally
    '        tmrReadQ.Start()
    '    End Try

    'End Sub


End Class