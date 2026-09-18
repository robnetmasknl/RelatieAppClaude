Imports BusinessObjects

Public Class frmAddressFile
    Private URights As UserRights = UserRights.Instance
    Private LocationPath As String = ""
    Private WithEvents _thAddressFile As AddressFile
    Private Status As String = ""
    Private ExpHandler As Boolean = False
    Private Ready As Boolean = False
    Private iCounter As Integer = 0

    Private Sub frmAddressFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If URights.IsInGroup("rel_admins") Then
                'ga dan door
            ElseIf URights.IsInGroup("rel_users") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''rel_admins''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            ProgressBar.Minimum = 0
            ProgressBar.Value = ProgressBar.Minimum
            ProgressBar.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub GenerateCompleteHandler(ByVal _iCounter As Integer) Handles _thAddressFile.GenerateComplete
        Ready = True
        iCounter = _iCounter
    End Sub
    Public Sub GenerateStatusHandler(ByVal _message As String) Handles _thAddressFile.GenerateStatus
        Status = _message
    End Sub
    Public Sub GenerateExpHandler(ByVal exp As Exception) Handles _thAddressFile.GenerateExp
        Status = "ERROR:" & exp.Message
        ExpHandler = True
    End Sub
    Public Sub GenerateCounter(ByVal _iCounter As Integer) Handles _thAddressFile.GenerateCounter
        iCounter = _iCounter
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

            Dim myHistory As New History
            myHistory.LidId = 0
            myHistory.TableName = "verzendbestand"
            myHistory.Veld = "Beveiliging"
            myHistory.WaardeOud = ""
            myHistory.WaardeNieuw = "verzendbestand door " & URights.UserName
            myHistory.MutDate = Now
            myHistory.MutDoor = URights.UserName
            myHistory.Save()


            _thAddressFile = New AddressFile
            Dim thGenerate As New System.Threading.Thread(AddressOf _thAddressFile.Process)
            _thAddressFile.LocationPath = LocationPath
            If rbTrivizier.Checked Then
                _thAddressFile.SendType = AddressFile.eType.TRIVIZIER
            ElseIf rbXrcise.Checked Then
                _thAddressFile.SendType = AddressFile.eType.XRCISE
            Else
                _thAddressFile.SendType = AddressFile.eType.NONE
            End If

            thGenerate.Start()

            Me.lblProcess.Text = "Bezig met ...."
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
            Me.Refresh()

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



    Private Sub tbfileSave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbfileSave.TextChanged

    End Sub
End Class