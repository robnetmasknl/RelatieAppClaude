Imports System.Management
Imports BusinessObjects
Imports OfficeObjects
Imports System.IO

Public Class frmSearchDocuments
    Private Declare Function WNetGetConnection Lib "mpr.dll" Alias _
 "WNetGetConnectionA" _
 (ByVal lpszLocalName As String, _
 ByVal lpszRemoteName As String, _
 ByRef cbRemoteName As Int32) As Int32
    'Private WithEvents _thSearchDocuments As SearchDocuments
    'Private Status As String = ""
    'Private ExpHandler As Boolean = False
    'Private Ready As Boolean = False
    'Private iCounter As Integer = 0
    'Private iCounterTotal As Integer = 0

    'Public Sub GenerateCompleteHandler(ByVal _iCounter As Integer) Handles _thSearchDocuments.GenerateComplete
    '    Ready = True
    '    iCounter = _iCounter
    'End Sub
    'Public Sub GenerateStatusHandler(ByVal _message As String) Handles _thSearchDocuments.GenerateStatus
    '    Status = _message
    'End Sub
    'Public Sub GenerateExpHandler(ByVal exp As Exception) Handles _thSearchDocuments.GenerateExp
    '    Status = "ERROR:" & exp.Message
    '    ExpHandler = True
    'End Sub

    'Public Sub GenerateCounter(ByVal _iCounter As Integer, ByVal _iCounterTotal As Integer) Handles _thSearchDocuments.GenerateCounter
    '    iCounter = _iCounter
    '    iCounterTotal = _iCounterTotal
    'End Sub
    'Private m_PercentDone As Integer
    'Public Sub percent(ByVal value As Integer)
    '    Me.ProgressBar.Value = value
    'End Sub
    'Public Sub Tmr_Tick()
    '    If m_PercentDone > 999 Then m_PercentDone = 0
    '    m_PercentDone = m_PercentDone + 5
    '    ProgressBar.Value = m_PercentDone

    'End Sub
    Public DossierNr As String = String.Empty

    Private Sub frmSearchDocuments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Dim p As String
            'p = Space(100)

            'WNetGetConnection("P:", p, 100)

            Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            TranslateDriveletter(DocumentPathSetting.Waarde)
            'Me.tbSearhPath.Text = GetUncSourcePath(DocumentPathSetting.Waarde)
            ' Me.tbIndex.Text = GetUncSourcePath("P:")

            If Not WDSDocuments.IsDesktopSearchInstalled Then
                'Return
                'Throw New Exception("Desktop Search niet geinstalleerd.")
                lblError.Text = "Desktop Search niet geinstalleerd."
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub Lookup(ByVal text As String)


        Try
            dgvDossiers.DataSource = Nothing
            WDSDocuments.MyIndex = Me.tbIndex.Text & "."
            WDSDocuments.MyScope = "'file:" & Me.tbSearhPath.Text & "'"
            If Not WDSDocuments.MyScope.Contains(":\") AndAlso Not WDSDocuments.MyScope.Contains("\\") Then
                Throw New Exception("Zoekpad is niet correct")
            End If
            dgvDossiers.DataSource = WDSDocuments.PerformSearch(text)
            dgvDossiers.AutoResizeColumns()

        Catch x As Exception
            MessageBox.Show(x.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            TranslateDriveletter(tbSearhPath.Text)
            Lookup(Me.tbZoekveld.Text)
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        Try
            fbdSave.Description = "Selecteer de zoek locatie..."
            DossierNr = String.Empty

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim _selectedpath As String = fbdSave.SelectedPath
                TranslateDriveletter(_selectedpath)
                'Dim _driveletter As String = _selectedpath.Substring(0, _selectedpath.IndexOf(":\") + 1)
                'Dim _selectedfolder As String = _selectedpath.Substring(_driveletter.Length)
                'Dim _uncpath As String = GetUncSourcePath(_driveletter).ToString
                'If _driveletter = _uncpath Then
                '    tbIndex.Text = ""
                'Else
                '    Dim istart As Integer = _uncpath.IndexOf("\\")
                '    Dim iend As Integer = _uncpath.IndexOf("\", 2) - 2
                '    tbIndex.Text = _uncpath.Substring(2, iend).ToString
                'End If
                'tbSearhPath.Text = _uncpath.Trim
                'tbSearhPath.AppendText(_selectedfolder)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TranslateDriveletter(ByVal SearchPatch As String)

        Dim _driveletter As String = SearchPatch.Substring(0, SearchPatch.IndexOf(":\") + 1)
        Dim _selectedfolder As String = SearchPatch.Substring(_driveletter.Length)
        Dim _uncpath As String = GetUncSourcePath(_driveletter).ToString

        If String.IsNullOrEmpty(_driveletter) Then
            Dim istart As Integer = SearchPatch.IndexOf("\\")
            Dim iend As Integer = SearchPatch.IndexOf("\", 2) - 2
            tbIndex.Text = SearchPatch.Substring(2, iend).ToString
        ElseIf _driveletter = _uncpath Then
            tbIndex.Text = ""

        Else
            Dim istart As Integer = _uncpath.IndexOf("\\")
            Dim iend As Integer = _uncpath.IndexOf("\", 2) - 2
            tbIndex.Text = _uncpath.Substring(2, iend).ToString
        End If
        tbSearhPath.Text = _uncpath.Trim
        tbSearhPath.AppendText(_selectedfolder)

        If Not String.IsNullOrEmpty(DossierNr) Then
            If Not tbSearhPath.Text.EndsWith(DossierNr) Then
                tbSearhPath.AppendText("\" & DossierNr)
            End If

        End If
    End Sub
    Private Function GetUncSourcePath(ByVal driveLetter As String) As String
        If String.IsNullOrEmpty(driveLetter) Then Return driveLetter ' New ArgumentNullException("driveLetter")
        If (driveLetter < "a"c OrElse driveLetter > "z") AndAlso (driveLetter < "A"c OrElse driveLetter > "Z") Then Throw New ArgumentOutOfRangeException("driveLetter", "driveLetter must be a letter from A to Z")

        Dim _unc As String
        _unc = Space(100)
        WNetGetConnection(driveLetter, _unc, 100)
        If _unc.Trim.Length = 0 Then
            Return driveLetter
        End If

        Return _unc
    End Function

    Private Sub dgvDossiers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDossiers.DoubleClick
        Try
            System.Diagnostics.Process.Start(Me.dgvDossiers.SelectedRows(0).Cells("location").Value)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub _btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try

    '        ZoekInFiles()
    '        Exit Sub

    '        Dim sedo As New SearchDocuments
    '        Dim FileList As New List(Of FileInfo)

    '        'FileList = sedo.Search(tbSearhPath.Text, Me.tbZoekveld.Text)
    '        'Me.dgvDossiers.DataSource = FileList


    '        Ready = False
    '        ExpHandler = False
    '        Status = ""

    '        Me.Cursor = Cursors.WaitCursor
    '        ' Me.btnProcess.Enabled = False
    '        Me.btnFile.Enabled = False

    '        _thSearchDocuments = New SearchDocuments
    '        Dim thGenerate As New System.Threading.Thread(AddressOf _thSearchDocuments.Search)
    '        _thSearchDocuments.SearchPath = tbSearhPath.Text
    '        _thSearchDocuments.SearchPhrase = tbZoekveld.Text
    '        thGenerate.Start()

    '        Me.lblProcess.Text = "Bezig met zoeken......"
    '        ProgressBar.Maximum = 1000

    '        My.Application.DoEvents()

    '        Dim iPadright As Integer = 1
    '        Dim sPadRight As String = ""
    '        While Ready = False
    '            iPadright += 1
    '            If iPadright = 25 Then
    '                Tmr_Tick()
    '                iPadright = 1
    '            End If
    '            lblProcess.Text = "bezig met " & iCounter & " van " & iCounterTotal 'Status & iCounter
    '            Me.Refresh()
    '            If Status.Contains("ERROR") Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '            If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
    '                thGenerate.Abort()
    '                lblProcess.Text = Status & " AFGEBROKEN."
    '                Me.Cursor = Cursors.Default
    '                Exit While
    '            End If
    '            My.Application.DoEvents()
    '        End While

    '        If Ready And ExpHandler = False Then
    '            FileList = _thSearchDocuments.Result
    '            Me.dgvDossiers.DataSource = FileList
    '            lblProcess.Text = Status
    '        End If

    '        ProgressBar.Value = 1000
    '        My.Application.DoEvents()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub ZoekInFiles()
    '    Try
    '        Dim sedo As New SearchDocuments
    '        'sedo.SearchWindowsLib(tbZoekveld.Text)
    '        ' MessageBox.Show(sedo.SearchWindowsLib(tbZoekveld.Text))
    '        Me.dgvDossiers.DataSource = sedo.SearchWindowsLib(tbZoekveld.Text)
    '        'Dim list As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
    '        'list = My.Computer.FileSystem.FindInFiles("D:\", "D:\Backup nertmnb05\Mijn documenten", True, FileIO.SearchOption.SearchAllSubDirectories)

    '        'For Each Name As String In list
    '        '    MessageBox.Show(Name)
    '        'Next

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub


End Class