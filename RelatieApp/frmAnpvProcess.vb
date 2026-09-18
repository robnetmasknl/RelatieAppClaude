Imports BusinessObjects
Imports System.IO
Imports OfficeObjects

Public Class frmAnpvProcess
    Private URights As UserRights = UserRights.Instance
    Private dStart As DateTime
    Private dStop As DateTime
    Private dCurrentTime As DateTime
    Private ts As TimeSpan

    Private WithEvents _thNPFile As ANPVFile

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

    Public Sub IndexCompleteHandler(ByVal _Counter As Integer) Handles _thNPFile.GenerateComplete
        Ready = True
        'Utils.WriteLog(Status & vbCrLf & "nieuw:" & iNew & vbCrLf & "aangepast:" & iUpdated, True)
    End Sub
    Public Sub IndexExpHandler(ByVal exp As Exception) Handles _thNPFile.GenerateExp
        Ready = True
        ExpHandler = True
        'Utils.WriteLog(exp.Message & vbCrLf & "nieuw:" & iNew & vbCrLf & "aangepast:" & iUpdated, False)
        MessageBox.Show(exp.Message, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Throw exp

    End Sub
    Public Sub IndexStatusHandler(ByVal _message As String) Handles _thNPFile.GenerateStatus
        Status = _message
    End Sub
    Public Sub IndexCounter(ByVal _Counter As Integer) Handles _thNPFile.GenerateCounter
        LineCounter = _Counter
    End Sub
    Public Sub NewCounter(ByVal _Counter As Integer) Handles _thNPFile.GenerateNewCounter
        iNewCounter = _Counter
    End Sub

    Private Sub frmABPProcess_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub

    Private Sub frmAnpvProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If URights.IsInGroup("rel_admins") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            btnProcess.Enabled = False

            CurrentTimer.Start()
            UpdateCurrentTime()
            ProgressBar.Minimum = 0
            ProgressBar.Value = ProgressBar.Minimum
            ProgressBar.Visible = True
            cmbMonth.Enabled = False
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
                .DefaultExt = "xlsx"
                .Filter = "Excel files|*.xlsx|" & "csv files|*.csv"
                .Multiselect = False
                .Title = "Select a file"
                .ValidateNames = True
                If .ShowDialog() = DialogResult.OK Then
                    Me.tbfile.Text = .FileName
                    My.Settings.Save()
                    ReadExcel(Me.tbfile.Text)

                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim dtExcel As New DataTable
    Public Sub ReadExcel(ExcelFile As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Text = "Bezig met inlezen van Excel file"

            cmbMonth.Enabled = False

            Dim _excel As New MyExcel
            dtExcel = _excel.Excelds(ExcelFile).Tables(0)

            For Each col As DataColumn In dtExcel.Columns
                If col.ColumnName.Contains("ANPV") Then cmbMonth.Items.Add(col.ColumnName)
            Next

            cmbMonth.Enabled = True
            Me.Text = "selecteer nu een maand"

        Catch ex As Exception
            Throw ex
        Finally
            Me.Cursor = Cursors.Default
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
            TotalLineCount = dtExcel.Rows.Count

            _thNPFile = New ANPVFile

            Dim thNPFile As New System.Threading.Thread(AddressOf _thNPFile.Process)
            With _thNPFile
                .dtExcel = dtExcel
                .LineCount = TotalLineCount
                '    .IndexFilePath = tbfile.Text
                Dim sMaand As String = cmbMonth.SelectedItem
                Dim sYear As String = cmbMonth.SelectedItem
                .ContributieCol = cmbMonth.SelectedItem
                .ContributieMaand = sMaand.Substring(sMaand.Length - 2)
                .ContributieJaar = sMaand.Substring(sMaand.Length - 6, 4)

                '    If String.IsNullOrEmpty(.IndexFilePath.Trim) Then Throw New Exception("Er is geen file geselecteerd.")
                '    If Not IO.File.Exists(.IndexFilePath) Then Throw New Exception("file niet gevonden.")
                If .ContributieMaand = 0 Then Throw New Exception("Er is nog geen maand opgegeven.")
                If .ContributieMaand > 12 Then Throw New Exception("Opgegeven maand is ongeldig.")
                If .ContributieJaar = 0 Then Throw New Exception("Er is nog geen Jaar opgegeven.")
                If .ContributieJaar > Now.Year Then Throw New Exception("Opgegeven jaar mag niet in de toekomst zijn.")
            End With

            thNPFile.Start()

            Me.lblStart.Text = "Gestart om: " & Now.ToLongTimeString
            dStart = DateTime.Now
            Me.Text = "Bezig ...!!"
            Me.ProgressBar.Maximum = TotalLineCount + 1
            Application.DoEvents()
            While Ready = False
                Me.Cursor = Cursors.WaitCursor
                Me.Text = "Bezig met verwerken van contributie "
                Me.Refresh()
                Me.percent(LineCounter)
                Me.lblProcess.Text = Status
                ' Me.lblNew.Text = "Aantal nieuw: " & iNewCounter
                If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
                    thNPFile.Abort()
                    Me.Cursor = Cursors.Default
                    Exit While
                End If
                My.Application.DoEvents()
            End While

            If ExpHandler = True Then
                thNPFile.Abort()
            End If

            If Ready And ExpHandler = False Then _
                MessageBox.Show("Klaar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim SeparationLine As String = ""
            Dim result As String = ""

            If _thNPFile.sbErrors.Length > 0 Then
                result &= "FOUTEN: " & vbCrLf
                result &= _thNPFile.sbErrors.ToString & vbCrLf & vbCrLf
                result &= SeparationLine.PadRight(35, "+") & vbCrLf
            End If

            result &= "verslag verwerkt in : " & _thNPFile.ContributieMaand & " - " & _thNPFile.ContributieJaar & vbCrLf
            result &= "verwerkt EURO " & (_thNPFile.ProcessedAmount / 100) & vbCrLf
            result &= "Totaal geupdate EURO " & (_thNPFile.TotalAmount / 100) & vbCrLf
            result &= "Niet verwerkt EURO: " & (_thNPFile.MissedAmount / 100) & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "Afwijkende bedragen: " & vbCrLf
            result &= _thNPFile.sbAberrations.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "niet gevonden relaties:(niet toegevoegd) " & vbCrLf
            result &= _thNPFile.sbNewRelations.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "gevonden relaties in VOORPORTAAL: " & vbCrLf
            result &= _thNPFile.sbInPortal.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "gevonden relaties in HISTORY of met einddatum: " & vbCrLf
            result &= _thNPFile.sbInHistory.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            result &= "relaties bij anpv met CI maar niet in CI bestand of geen bedrag: " & vbCrLf
            result &= _thNPFile.sbInCiNoAmount.ToString & vbCrLf & vbCrLf
            result &= SeparationLine.PadRight(35, "+") & vbCrLf

            If Ready And ExpHandler = False Then
                Dim ResultFile As String = "\ANPV\" & "NP_VERSLAG_" & _thNPFile.ContributieJaar & _thNPFile.ContributieMaand & ".txt"
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

    Private Sub cmbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonth.SelectedIndexChanged
        Try
            If Not String.IsNullOrEmpty(cmbMonth.SelectedItem.ToString) Then
                btnProcess.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class