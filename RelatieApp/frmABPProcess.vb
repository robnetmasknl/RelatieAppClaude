Imports BusinessObjects
Imports System.IO

Public Class frmABPProcess
    Private URights As UserRights = UserRights.Instance
    Private dStart As DateTime
    Private dStop As DateTime
    Private dCurrentTime As DateTime
    Private ts As TimeSpan

    Private WithEvents _thABPFile As ABPFile
    Private Status As String = ""
    Private Ready As Boolean = False
    Private ExpHandler As Boolean = False
    Private LineCounter As Integer = 0
    Private iNewCounter As Integer = 0
    Private TotalLineCount As Integer = 0

    Private m_PercentDone As Integer
    Public Sub percent(ByVal value As Integer)
        Me.ProgressBar.Value = value
    End Sub

    Public Sub IndexCompleteHandler(ByVal _Counter As Integer) Handles _thABPFile.GenerateComplete
        Ready = True
        'Utils.WriteLog(Status & vbCrLf & "nieuw:" & iNew & vbCrLf & "aangepast:" & iUpdated, True)
    End Sub
    Public Sub IndexExpHandler(ByVal exp As Exception) Handles _thABPFile.GenerateExp
        Ready = True
        ExpHandler = True
        'Utils.WriteLog(exp.Message & vbCrLf & "nieuw:" & iNew & vbCrLf & "aangepast:" & iUpdated, False)
        MessageBox.Show(exp.Message, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Throw exp

    End Sub
    Public Sub IndexStatusHandler(ByVal _message As String) Handles _thABPFile.GenerateStatus
        Status = _message
    End Sub
    Public Sub IndexCounter(ByVal _Counter As Integer) Handles _thABPFile.GenerateCounter
        LineCounter = _Counter
    End Sub
    Public Sub NewCounter(ByVal _Counter As Integer) Handles _thABPFile.GenerateNewCounter
        iNewCounter = _Counter
    End Sub

    Private Sub frmABPProcess_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub

    Private Sub frmABPProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If URights.IsInGroup("rel_admins") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            CurrentTimer.Start()
            UpdateCurrentTime()
            ProgressBar.Minimum = 0
            ProgressBar.Value = ProgressBar.Minimum
            ProgressBar.Visible = True

            Dim dt As DataTable
            Dim col As DataColumn
            Dim dr As DataRow

            dt = New DataTable
            col = New DataColumn
            col.ColumnName = "id"
            dt.Columns.Add(col)
            col = New DataColumn
            col.ColumnName = "omschrijving"
            dt.Columns.Add(col)

            dr = dt.NewRow
            dr("id") = 0
            dr("omschrijving") = "maand..."
            dt.Rows.Add(dr)

            Dim i As Integer = 1
            Do While i <= 12
                dr = dt.NewRow
                dr("id") = i
                dr("omschrijving") = MonthName(i, True)
                dt.Rows.Add(dr)
                i = i + 1
            Loop
            cmbMonth.DataSource = dt
            cmbMonth.DisplayMember = "omschrijving"
            cmbMonth.ValueMember = "id"
            ReadOnlyComboProvider1.SetReadOnly(Me.cmbMonth, True)

            Dim iYear As Integer = Now.Year - 3
            Dim dtYear As New DataTable
            dtYear = dt.Clone

            i = 1
            Do While i <= 8
                dr = dtYear.NewRow
                dr("id") = iYear
                dr("omschrijving") = iYear
                dtYear.Rows.Add(dr)
                iYear += 1
                i = i + 1
            Loop

            cmbYear.DataSource = dtYear
            cmbYear.DisplayMember = "omschrijving"
            cmbYear.ValueMember = "id"
            cmbYear.SelectedValue = Now.Year
            ReadOnlyComboProvider1.SetReadOnly(Me.cmbYear, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CurrentTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrentTimer.Tick
        UpdateCurrentTime()
    End Sub
    Private Sub UpdateCurrentTime()
        Try
            Me.lblCurrentTime.Text = Now.ToLongTimeString
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tijd()
        Me.lblStop.Text = "Gestopt om: " & Now.ToLongTimeString
        dStop = DateTime.Now
        ts = dStop.Subtract(dStart)
        Me.lbllengte.Text = "tijdsduur: " & ts.Hours & " uren, " & ts.Minutes & " min., " & ts.Seconds & " sec. "
    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        Try
            With Me.OpenFileDialog1
                .Reset()

                If Me.tbfile.Text = "" Then
                    .InitialDirectory = Application.StartupPath
                End If
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "csv"
                .Filter = "Text files (*.txt)|*.txt|" & "csv files|*.csv"
                .Multiselect = False
                .Title = "Select a file"
                .ValidateNames = True
                If .ShowDialog() = DialogResult.OK Then
                    Me.tbfile.Text = .FileName
                    My.Settings.Save()
                    'If CheckFile() = True Then
                    '    Me.TSStatus.Text = "kies verwerken..."
                    '    'Me.btnVerwerk.Enabled = True
                    '    'Me.btnTape.Enabled = True
                    '    'Me.lblStart.Text = "Gestart om: "
                    '    'Me.lblStop.Text = "Gestopt om: "
                    '    'Me.lbllengte.Text = ""
                    'End If
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.btnProcess.Enabled = False
            Me.btnFile.Enabled = False



            Status = ""
            Ready = False
            ExpHandler = False
            LineCounter = 0
            iNewCounter = 0
            TotalLineCount = GetLineCount(Me.tbfile.Text)

            _thABPFile = New ABPFile

            Dim thABPFile As New System.Threading.Thread(AddressOf _thABPFile.Process)
            With _thABPFile
                .LineCount = TotalLineCount
                .IndexFilePath = tbfile.Text
                .ContributieMaand = cmbMonth.SelectedValue
                .ContributieJaar = cmbYear.SelectedValue

                If String.IsNullOrEmpty(.IndexFilePath.Trim) Then Throw New Exception("Er is geen file geselecteerd.")
                If Not IO.File.Exists(.IndexFilePath) Then Throw New Exception("file niet gevonden.")
                If .ContributieMaand = 0 Then Throw New Exception("Er is nog geen maand opgegeven.")
                If .ContributieMaand > 12 Then Throw New Exception("Opgegeven maand is ongeldig.")
                If .ContributieJaar = 0 Then Throw New Exception("Er is nog geen Jaar opgegeven.")
                If .ContributieJaar > Now.Year Then Throw New Exception("Opgegeven jaar mag niet in de toekomst zijn.")
            End With

            thABPFile.Start()

            Me.lblStart.Text = "Gestart om: " & Now.ToLongTimeString
            dStart = DateTime.Now
            Me.Text = "Bezig ...!!"
            Me.ProgressBar.Maximum = TotalLineCount + 1
            Application.DoEvents()
            While Ready = False
                Me.Cursor = Cursors.WaitCursor
                Me.Text = "Bezig met verwerken van Indexfile "
                Me.Refresh()
                Me.percent(LineCounter)
                Me.lblProcess.Text = Status
                Me.lblNew.Text = "Aantal nieuw: " & iNewCounter
                If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
                    thABPFile.Abort()
                    Me.Cursor = Cursors.Default
                    Exit While
                End If
                My.Application.DoEvents()
            End While

            If ExpHandler = True Then
                thABPFile.Abort()
            End If

            If Ready And ExpHandler = False Then _
                MessageBox.Show("Klaar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim SeparationLine As String = ""
            Dim result As String = ""

            If _thABPFile.sbErrors.Length > 0 Then
                result &= "FOUTEN: " & vbCrLf
                result &= _thABPFile.sbErrors.ToString & vbCrLf & vbCrLf
                result &= SeparationLine.PadRight(35, "+") & vbCrLf
            End If

            result &= "Afwijkende bedragen: " & vbCrLf
            result &= _thABPFile.sbAberrations.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "Nieuwe relaties in ABP:(niet toegevoegd) " & vbCrLf
            result &= _thABPFile.sbNewAbroad.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            'result &= "Nieuwe toegevoegd: " & vbCrLf
            'result &= _thABPFile.sbNewRelations.ToString & vbCrLf & vbCrLf
            'result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "gevonden Lidnrs in VOORPORTAAL bestand: " & vbCrLf
            result &= _thABPFile.sbInPortal.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "gevonden Lidnrs in HISTORY bestand: " & vbCrLf
            result &= _thABPFile.sbInHistory.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "Niet gevonden Lidnrs eindigend op 01, maar wel op 00: " & vbCrLf
            result &= _thABPFile.sbWrongLIDNR00.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "Wel in VBM, Niet in ABP: " & vbCrLf
            result &= _thABPFile.sbNotInABP.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "Afwijkende Instanties: " & vbCrLf
            result &= _thABPFile.sbWrongABPID.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            If Ready And ExpHandler = False Then
                Dim ResultFile As String = "\ABP\" & "ABP_VERSLAG_" & _thABPFile.ContributieJaar & _thABPFile.ContributieMaand & ".txt"
                WriteFile(MyDocuments & ResultFile, result)
                System.Diagnostics.Process.Start(MyDocuments & ResultFile)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tijd()
            Me.Cursor = Cursors.Default
            Me.btnProcess.Enabled = True
            Me.btnFile.Enabled = True
        End Try
    End Sub
    Private _MyDocuments As String = ""
    Public ReadOnly Property MyDocuments() As String
        Get
            If String.IsNullOrEmpty(_MyDocuments) Then
                _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            Return _MyDocuments
        End Get
    End Property
    Public Function GetLineCount(ByVal FileName As String) As Integer
        Dim total As Integer = 0

        If File.Exists(FileName) Then
            Dim buffer(32 * 1024) As Char
            Dim i As Integer
            Dim read As Integer

            Dim reader As TextReader = File.OpenText(FileName)
            read = reader.Read(buffer, 0, buffer.Length)

            While (read > 0)
                i = 0
                While i < read

                    If buffer(i) = Chr(10) Then
                        total += 1
                    End If

                    i += 1
                End While

                read = reader.Read(buffer, 0, buffer.Length)
            End While

            reader.Close()
            reader = Nothing

            If Not buffer(i - 1) = Chr(10) Then
                total += 1
            End If

        End If

        Return total
    End Function


End Class