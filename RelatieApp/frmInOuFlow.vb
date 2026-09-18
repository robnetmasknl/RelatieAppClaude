Imports OfficeObjects

Public Class frmInOuFlow
    Private LocationPath As String = ""
    Private WithEvents _thSegmentationReport As SegmentationReport
    Private Status As String = ""
    Private ExpHandler As Boolean = False
    Private Ready As Boolean = False
    Private iCounter As Integer = 0
    Private iCounterTotal As Integer = 0

    Public Sub GenerateCompleteHandler(ByVal _iCounter As Integer) Handles _thSegmentationReport.GenerateComplete
        Ready = True
        iCounter = _iCounter
    End Sub
    Public Sub GenerateStatusHandler(ByVal _message As String) Handles _thSegmentationReport.GenerateStatus
        Status = _message
    End Sub
    Public Sub GenerateExpHandler(ByVal exp As Exception) Handles _thSegmentationReport.GenerateExp
        Status = "ERROR:" & exp.Message
        ExpHandler = True
    End Sub

    Public Sub GenerateCounter(ByVal _iCounter As Integer, ByVal _iCounterTotal As Integer) Handles _thSegmentationReport.GenerateCounter
        iCounter = _iCounter
        iCounterTotal = _iCounterTotal
    End Sub
    Private m_PercentDone As Integer
    Public Sub percent(ByVal value As Integer)
        Me.ProgressBar.Value = value
    End Sub
    Public Sub Tmr_Tick()
        If m_PercentDone > 999 Then m_PercentDone = 0
        m_PercentDone = m_PercentDone + 5
        ProgressBar.Value = m_PercentDone

    End Sub
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Try
            'Exit Sub
            LocationPath = tbfileSave.Text
            If String.IsNullOrEmpty(LocationPath) Then Throw New Exception("Er is nog geen opslag locatie opgegeven!")

            Ready = False
            ExpHandler = False
            Status = ""

            Me.Cursor = Cursors.WaitCursor
            Me.btnProcess.Enabled = False
            Me.btnFile.Enabled = False

            _thSegmentationReport = New SegmentationReport
            Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportInOut)
            _thSegmentationReport.LocationPath = LocationPath
            _thSegmentationReport.DateIn = dtpStart.Value ' New Date("2010", "06", "01")
            _thSegmentationReport.DateOut = dtpEnd.Value 'new Date("2011", "02", "24")
            thGenerate.Start()

            Me.lblProcess.Text = "Bezig met verslag van in- en Uitstroom leden......"
            ProgressBar.Maximum = 1000

            My.Application.DoEvents()

            Dim iPadright As Integer = 1
            Dim sPadRight As String = ""
            While Ready = False
                iPadright += 1
                If iPadright = 25 Then
                    Tmr_Tick()
                    iPadright = 1
                End If
                lblProcess.Text = Status & iCounter
                Me.Refresh()
                If Status.Contains("ERROR") Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
                If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
                    thGenerate.Abort()
                    lblProcess.Text = Status & " AFGEBROKEN."
                    Me.Cursor = Cursors.Default
                    Exit While
                End If
                My.Application.DoEvents()
            End While

            If Ready And ExpHandler = False Then
                lblProcess.Text = Status
            End If

            ProgressBar.Value = 1000
            My.Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Me.Cursor = Cursors.Default
            Me.btnProcess.Enabled = True
            Me.btnFile.Enabled = True
        End Try

    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        Try
            fbdSave.Description = "Selecteer de opslag locatie..."

            If Not My.Settings.ReportsPath = "" Then
                fbdSave.SelectedPath = My.Settings.ReportsPath
                fbdSave.Description = "huidige opslag locatie..." & vbCrLf & vbCrLf & fbdSave.SelectedPath
            End If

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.ReportsPath = fbdSave.SelectedPath
                My.Settings.Save()
                tbfileSave.Text = fbdSave.SelectedPath
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmInOuFlow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ProgressBar.Minimum = 0
            ProgressBar.Value = ProgressBar.Minimum
            ProgressBar.Visible = True

            dtpStart.Value = DateAdd(DateInterval.Month, -3, Today)
            dtpEnd.Value = Today

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Class