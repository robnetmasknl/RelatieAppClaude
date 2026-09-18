<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnpvProcess
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
        Me.components = New System.ComponentModel.Container()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.lbResult = New System.Windows.Forms.Label()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.lbllengte = New System.Windows.Forms.Label()
        Me.lblStop = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblCurrentTime = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.CurrentTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbfile = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ReadOnlyComboProvider1 = New BusinessObjects.ReadOnlyComboProvider()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(102, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Contributie voor Maand:"
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(226, 63)
        Me.cmbMonth.Name = "cmbMonth"
        Me.ReadOnlyComboProvider1.SetOrigDropDownStyle(Me.cmbMonth, System.Windows.Forms.ComboBoxStyle.DropDown)
        Me.ReadOnlyComboProvider1.SetReadOnly(Me.cmbMonth, False)
        Me.cmbMonth.Size = New System.Drawing.Size(158, 21)
        Me.cmbMonth.TabIndex = 56
        '
        'lbResult
        '
        Me.lbResult.AutoSize = True
        Me.lbResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbResult.Location = New System.Drawing.Point(103, 207)
        Me.lbResult.Name = "lbResult"
        Me.lbResult.Size = New System.Drawing.Size(22, 13)
        Me.lbResult.TabIndex = 55
        Me.lbResult.Text = "....."
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(103, 271)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(16, 13)
        Me.lblProcess.TabIndex = 54
        Me.lblProcess.Text = "..."
        '
        'lbllengte
        '
        Me.lbllengte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbllengte.Location = New System.Drawing.Point(103, 159)
        Me.lbllengte.Name = "lbllengte"
        Me.lbllengte.Size = New System.Drawing.Size(465, 24)
        Me.lbllengte.TabIndex = 53
        Me.lbllengte.Text = "tijd lengte:"
        '
        'lblStop
        '
        Me.lblStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblStop.Location = New System.Drawing.Point(103, 135)
        Me.lblStop.Name = "lblStop"
        Me.lblStop.Size = New System.Drawing.Size(264, 24)
        Me.lblStop.TabIndex = 52
        Me.lblStop.Text = "gestopt om:"
        '
        'lblStart
        '
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblStart.Location = New System.Drawing.Point(103, 111)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(264, 24)
        Me.lblStart.TabIndex = 51
        Me.lblStart.Text = "gestart om:"
        '
        'lblCurrentTime
        '
        Me.lblCurrentTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCurrentTime.Location = New System.Drawing.Point(103, 87)
        Me.lblCurrentTime.Name = "lblCurrentTime"
        Me.lblCurrentTime.Size = New System.Drawing.Size(264, 24)
        Me.lblCurrentTime.TabIndex = 50
        Me.lblCurrentTime.Text = "tijd:"
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar.Location = New System.Drawing.Point(0, 427)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(800, 23)
        Me.ProgressBar.TabIndex = 49
        '
        'CurrentTimer
        '
        Me.CurrentTimer.Interval = 1000
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(493, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(493, 61)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 47
        Me.btnProcess.Text = "Verwerken"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(493, 30)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(75, 23)
        Me.btnFile.TabIndex = 46
        Me.btnFile.Text = "Selecteer..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Bestand..."
        '
        'tbfile
        '
        Me.tbfile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RelatieApp.My.MySettings.Default, "NskPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbfile.Location = New System.Drawing.Point(106, 32)
        Me.tbfile.Name = "tbfile"
        Me.tbfile.Size = New System.Drawing.Size(381, 20)
        Me.tbfile.TabIndex = 44
        Me.tbfile.Text = Global.RelatieApp.My.MySettings.Default.NskPath
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmAnpvProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
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
        Me.Name = "frmAnpvProcess"
        Me.Text = "Import NP contributie"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReadOnlyComboProvider1 As BusinessObjects.ReadOnlyComboProvider
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents lbResult As Label
    Friend WithEvents lblProcess As Label
    Friend WithEvents lbllengte As Label
    Friend WithEvents lblStop As Label
    Friend WithEvents lblStart As Label
    Friend WithEvents lblCurrentTime As Label
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents CurrentTimer As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents btnProcess As Button
    Friend WithEvents btnFile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tbfile As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
