<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgSMS))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.grpCredentials = New System.Windows.Forms.GroupBox
        Me.btnFile = New System.Windows.Forms.Button
        Me.tbStartTime = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbLastRun = New System.Windows.Forms.TextBox
        Me.tbLogFilePath = New System.Windows.Forms.TextBox
        Me.tbService = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fbdQueue = New System.Windows.Forms.FolderBrowserDialog
        Me.lnkAbout = New System.Windows.Forms.LinkLabel
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnContinue = New System.Windows.Forms.Button
        Me.btnPause = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.ssServiceStatus = New System.Windows.Forms.StatusStrip
        Me.sslblService = New System.Windows.Forms.ToolStripStatusLabel
        Me.tmrCheckStatus = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDll = New System.Windows.Forms.Button
        Me.tbSMSPort = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tbSMSDllName = New System.Windows.Forms.TextBox
        Me.tbSMSHost = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ofdDll = New System.Windows.Forms.OpenFileDialog
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpCredentials.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssServiceStatus.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(283, 448)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'grpCredentials
        '
        Me.grpCredentials.Controls.Add(Me.btnFile)
        Me.grpCredentials.Controls.Add(Me.tbStartTime)
        Me.grpCredentials.Controls.Add(Me.Label4)
        Me.grpCredentials.Controls.Add(Me.tbLastRun)
        Me.grpCredentials.Controls.Add(Me.tbLogFilePath)
        Me.grpCredentials.Controls.Add(Me.tbService)
        Me.grpCredentials.Controls.Add(Me.Label3)
        Me.grpCredentials.Controls.Add(Me.Label2)
        Me.grpCredentials.Controls.Add(Me.Label1)
        Me.grpCredentials.Location = New System.Drawing.Point(8, 239)
        Me.grpCredentials.Name = "grpCredentials"
        Me.grpCredentials.Size = New System.Drawing.Size(455, 154)
        Me.grpCredentials.TabIndex = 8
        Me.grpCredentials.TabStop = False
        Me.grpCredentials.Text = "Service settings"
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(381, 72)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(48, 23)
        Me.btnFile.TabIndex = 9
        Me.btnFile.Text = "kies..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'tbStartTime
        '
        Me.tbStartTime.Location = New System.Drawing.Point(122, 52)
        Me.tbStartTime.Name = "tbStartTime"
        Me.tbStartTime.Size = New System.Drawing.Size(252, 20)
        Me.tbStartTime.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "StartTime"
        '
        'tbLastRun
        '
        Me.tbLastRun.Location = New System.Drawing.Point(122, 101)
        Me.tbLastRun.Name = "tbLastRun"
        Me.tbLastRun.Size = New System.Drawing.Size(252, 20)
        Me.tbLastRun.TabIndex = 6
        '
        'tbLogFilePath
        '
        Me.tbLogFilePath.Location = New System.Drawing.Point(122, 76)
        Me.tbLogFilePath.Name = "tbLogFilePath"
        Me.tbLogFilePath.Size = New System.Drawing.Size(252, 20)
        Me.tbLogFilePath.TabIndex = 5
        '
        'tbService
        '
        Me.tbService.Location = New System.Drawing.Point(122, 26)
        Me.tbService.Name = "tbService"
        Me.tbService.Size = New System.Drawing.Size(252, 20)
        Me.tbService.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "LastRun"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "LogFile"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Service:"
        '
        'lnkAbout
        '
        Me.lnkAbout.AutoSize = True
        Me.lnkAbout.Location = New System.Drawing.Point(551, 9)
        Me.lnkAbout.Name = "lnkAbout"
        Me.lnkAbout.Size = New System.Drawing.Size(35, 13)
        Me.lnkAbout.TabIndex = 10
        Me.lnkAbout.TabStop = True
        Me.lnkAbout.Text = "About"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnStop
        '
        Me.btnStop.AccessibleDescription = "Button used to Stop the Windows Service."
        Me.btnStop.AccessibleName = "Stop Button"
        Me.btnStop.Enabled = False
        Me.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStop.Location = New System.Drawing.Point(350, 410)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 23
        Me.btnStop.Text = "Sto&p"
        '
        'btnContinue
        '
        Me.btnContinue.AccessibleDescription = "Button used to Continue the Windows Service."
        Me.btnContinue.AccessibleName = "Continue Button"
        Me.btnContinue.Enabled = False
        Me.btnContinue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnContinue.Location = New System.Drawing.Point(262, 410)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(75, 23)
        Me.btnContinue.TabIndex = 22
        Me.btnContinue.Text = "&Continue"
        '
        'btnPause
        '
        Me.btnPause.AccessibleDescription = "Button used to Pause the Windows Service."
        Me.btnPause.AccessibleName = "Pause Button"
        Me.btnPause.Enabled = False
        Me.btnPause.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPause.Location = New System.Drawing.Point(174, 410)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(75, 23)
        Me.btnPause.TabIndex = 21
        Me.btnPause.Text = "&Pause"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(86, 410)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 20
        Me.btnStart.Text = "Start service"
        '
        'ssServiceStatus
        '
        Me.ssServiceStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslblService})
        Me.ssServiceStatus.Location = New System.Drawing.Point(0, 490)
        Me.ssServiceStatus.Name = "ssServiceStatus"
        Me.ssServiceStatus.Size = New System.Drawing.Size(467, 22)
        Me.ssServiceStatus.TabIndex = 24
        Me.ssServiceStatus.Text = "StatusStrip1"
        '
        'sslblService
        '
        Me.sslblService.Name = "sslblService"
        Me.sslblService.Size = New System.Drawing.Size(19, 17)
        Me.sslblService.Text = "...."
        '
        'tmrCheckStatus
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDll)
        Me.GroupBox1.Controls.Add(Me.tbSMSPort)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.tbSMSDllName)
        Me.GroupBox1.Controls.Add(Me.tbSMSHost)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 164)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SMScomfort settings"
        '
        'btnDll
        '
        Me.btnDll.Location = New System.Drawing.Point(381, 65)
        Me.btnDll.Name = "btnDll"
        Me.btnDll.Size = New System.Drawing.Size(48, 23)
        Me.btnDll.TabIndex = 16
        Me.btnDll.Text = "kies..."
        Me.btnDll.UseVisualStyleBackColor = True
        '
        'tbSMSPort
        '
        Me.tbSMSPort.Location = New System.Drawing.Point(122, 45)
        Me.tbSMSPort.Name = "tbSMSPort"
        Me.tbSMSPort.Size = New System.Drawing.Size(252, 20)
        Me.tbSMSPort.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "SMS Port:"
        '
        'tbSMSDllName
        '
        Me.tbSMSDllName.Location = New System.Drawing.Point(122, 69)
        Me.tbSMSDllName.Name = "tbSMSDllName"
        Me.tbSMSDllName.Size = New System.Drawing.Size(252, 20)
        Me.tbSMSDllName.TabIndex = 13
        '
        'tbSMSHost
        '
        Me.tbSMSHost.Location = New System.Drawing.Point(122, 19)
        Me.tbSMSHost.Name = "tbSMSHost"
        Me.tbSMSHost.Size = New System.Drawing.Size(252, 20)
        Me.tbSMSHost.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "SMS smscomfort.dll"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "SMS Host:"
        '
        'ofdDll
        '
        Me.ofdDll.FileName = "SmsComfortAPI.dll"
        Me.ofdDll.Filter = """dll files|*.dll"""
        '
        'dlgSMS
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(467, 512)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ssServiceStatus)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lnkAbout)
        Me.Controls.Add(Me.grpCredentials)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSMS"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Standaard instellingen"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpCredentials.ResumeLayout(False)
        Me.grpCredentials.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssServiceStatus.ResumeLayout(False)
        Me.ssServiceStatus.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents grpCredentials As System.Windows.Forms.GroupBox
    Friend WithEvents tbLastRun As System.Windows.Forms.TextBox
    Friend WithEvents tbLogFilePath As System.Windows.Forms.TextBox
    Friend WithEvents tbService As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbStartTime As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fbdQueue As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lnkAbout As System.Windows.Forms.LinkLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ssServiceStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents sslblService As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents tmrCheckStatus As System.Windows.Forms.Timer
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDll As System.Windows.Forms.Button
    Friend WithEvents tbSMSPort As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbSMSDllName As System.Windows.Forms.TextBox
    Friend WithEvents tbSMSHost As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ofdDll As System.Windows.Forms.OpenFileDialog

End Class
