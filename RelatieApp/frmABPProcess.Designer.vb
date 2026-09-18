<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABPProcess
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btnFile = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbfile = New System.Windows.Forms.TextBox
        Me.btnProcess = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CurrentTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.lblCurrentTime = New System.Windows.Forms.Label
        Me.lblStart = New System.Windows.Forms.Label
        Me.lblStop = New System.Windows.Forms.Label
        Me.lbllengte = New System.Windows.Forms.Label
        Me.lblProcess = New System.Windows.Forms.Label
        Me.lbResult = New System.Windows.Forms.Label
        Me.cmbMonth = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbYear = New System.Windows.Forms.ComboBox
        Me.ReadOnlyComboProvider1 = New BusinessObjects.ReadOnlyComboProvider
        Me.lblNew = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(493, 59)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(75, 23)
        Me.btnFile.TabIndex = 5
        Me.btnFile.Text = "Selecteer..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Bestand..."
        '
        'tbfile
        '
        Me.tbfile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RelatieApp.My.MySettings.Default, "NskPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbfile.Location = New System.Drawing.Point(106, 61)
        Me.tbfile.Name = "tbfile"
        Me.tbfile.Size = New System.Drawing.Size(381, 20)
        Me.tbfile.TabIndex = 3
        Me.tbfile.Text = Global.RelatieApp.My.MySettings.Default.NskPath
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(493, 88)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 6
        Me.btnProcess.Text = "Verwerken"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(493, 117)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CurrentTimer
        '
        Me.CurrentTimer.Interval = 1000
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar.Location = New System.Drawing.Point(0, 411)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(705, 23)
        Me.ProgressBar.TabIndex = 31
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCurrentTime.Location = New System.Drawing.Point(103, 116)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(264, 24)
        Me.lblCurrentTime.TabIndex = 32
        Me.lblCurrentTime.Text = "tijd:"
        '
        'lblStart
        '
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblStart.Location = New System.Drawing.Point(103, 140)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(264, 24)
        Me.lblStart.TabIndex = 33
        Me.lblStart.Text = "gestart om:"
        '
        'lblStop
        '
        Me.lblStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblStop.Location = New System.Drawing.Point(103, 164)
        Me.lblStop.Name = "lblStop"
        Me.lblStop.Size = New System.Drawing.Size(264, 24)
        Me.lblStop.TabIndex = 34
        Me.lblStop.Text = "gestopt om:"
        '
        'lbllengte
        '
        Me.lbllengte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbllengte.Location = New System.Drawing.Point(103, 188)
        Me.lbllengte.Name = "lbllengte"
        Me.lbllengte.Size = New System.Drawing.Size(465, 24)
        Me.lbllengte.TabIndex = 35
        Me.lbllengte.Text = "tijd lengte:"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(103, 300)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(16, 13)
        Me.lblProcess.TabIndex = 36
        Me.lblProcess.Text = "..."
        '
        'lbResult
        '
        Me.lbResult.AutoSize = True
        Me.lbResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbResult.Location = New System.Drawing.Point(103, 236)
        Me.lbResult.Name = "lbResult"
        Me.lbResult.Size = New System.Drawing.Size(22, 13)
        Me.lbResult.TabIndex = 37
        Me.lbResult.Text = "....."
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(152, 87)
        Me.cmbMonth.Name = "cmbMonth"
        Me.ReadOnlyComboProvider1.SetOrigDropDownStyle(Me.cmbMonth, System.Windows.Forms.ComboBoxStyle.DropDown)
        Me.ReadOnlyComboProvider1.SetReadOnly(Me.cmbMonth, False)
        Me.cmbMonth.Size = New System.Drawing.Size(90, 21)
        Me.cmbMonth.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Contributie voor Maand:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(248, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Jaar:"
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(284, 87)
        Me.cmbYear.Name = "cmbYear"
        Me.ReadOnlyComboProvider1.SetOrigDropDownStyle(Me.cmbYear, System.Windows.Forms.ComboBoxStyle.DropDown)
        Me.ReadOnlyComboProvider1.SetReadOnly(Me.cmbYear, False)
        Me.cmbYear.Size = New System.Drawing.Size(90, 21)
        Me.cmbYear.TabIndex = 42
        '
        'lblNew
        '
        Me.lblNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblNew.Location = New System.Drawing.Point(103, 212)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(465, 24)
        Me.lblNew.TabIndex = 43
        Me.lblNew.Text = "Aantal nieuw:"
        '
        'frmNSKProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 434)
        Me.Controls.Add(Me.lblNew)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.lbResult)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.lbllengte)
        Me.Controls.Add(Me.lblStop)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblCurrentTime)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbfile)
        Me.Name = "frmNSKProcess"
        Me.Text = "NSK bestand verwerken"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbfile As System.Windows.Forms.TextBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CurrentTimer As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCurrentTime As System.Windows.Forms.Label
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblStop As System.Windows.Forms.Label
    Friend WithEvents lbllengte As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents lbResult As System.Windows.Forms.Label
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents ReadOnlyComboProvider1 As BusinessObjects.ReadOnlyComboProvider
    Friend WithEvents lblNew As System.Windows.Forms.Label
End Class
