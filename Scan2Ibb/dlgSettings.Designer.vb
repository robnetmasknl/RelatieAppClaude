<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSettings
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
        Me.fbdQueue = New System.Windows.Forms.FolderBrowserDialog()
        Me.tbDatabase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.tbAccount = New System.Windows.Forms.TextBox()
        Me.tbServer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpCredentials = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.tbQueuePath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbConfigFile = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.tbInterval = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbLastRun = New System.Windows.Forms.TextBox()
        Me.tbLogFilePath = New System.Windows.Forms.TextBox()
        Me.tbService = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tmrCheckStatus = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ofdConfig = New System.Windows.Forms.OpenFileDialog()
        Me.ssServiceStatus = New System.Windows.Forms.StatusStrip()
        Me.sslblService = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tbExtensions = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpCredentials.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssServiceStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbDatabase
        '
        Me.tbDatabase.Location = New System.Drawing.Point(105, 52)
        Me.tbDatabase.Name = "tbDatabase"
        Me.tbDatabase.Size = New System.Drawing.Size(252, 20)
        Me.tbDatabase.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Database"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(105, 101)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(120)
        Me.tbPassword.Size = New System.Drawing.Size(252, 20)
        Me.tbPassword.TabIndex = 6
        '
        'tbAccount
        '
        Me.tbAccount.Location = New System.Drawing.Point(105, 76)
        Me.tbAccount.Name = "tbAccount"
        Me.tbAccount.Size = New System.Drawing.Size(252, 20)
        Me.tbAccount.TabIndex = 5
        '
        'tbServer
        '
        Me.tbServer.Location = New System.Drawing.Point(105, 26)
        Me.tbServer.Name = "tbServer"
        Me.tbServer.Size = New System.Drawing.Size(252, 20)
        Me.tbServer.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Server IP"
        '
        'grpCredentials
        '
        Me.grpCredentials.Controls.Add(Me.tbDatabase)
        Me.grpCredentials.Controls.Add(Me.Label4)
        Me.grpCredentials.Controls.Add(Me.tbPassword)
        Me.grpCredentials.Controls.Add(Me.tbAccount)
        Me.grpCredentials.Controls.Add(Me.tbServer)
        Me.grpCredentials.Controls.Add(Me.Label3)
        Me.grpCredentials.Controls.Add(Me.Label2)
        Me.grpCredentials.Controls.Add(Me.Label1)
        Me.grpCredentials.Location = New System.Drawing.Point(12, 65)
        Me.grpCredentials.Name = "grpCredentials"
        Me.grpCredentials.Size = New System.Drawing.Size(548, 133)
        Me.grpCredentials.TabIndex = 12
        Me.grpCredentials.TabStop = False
        Me.grpCredentials.Text = "Credentials"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Account"
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(378, 151)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(75, 23)
        Me.btnFile.TabIndex = 6
        Me.btnFile.Text = "Locatie"
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'tbQueuePath
        '
        Me.tbQueuePath.Location = New System.Drawing.Point(120, 153)
        Me.tbQueuePath.Name = "tbQueuePath"
        Me.tbQueuePath.Size = New System.Drawing.Size(252, 20)
        Me.tbQueuePath.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Scan directorie"
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(418, 531)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.tbConfigFile)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(486, 35)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(378, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "kies..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbConfigFile
        '
        Me.tbConfigFile.Location = New System.Drawing.Point(122, 9)
        Me.tbConfigFile.Name = "tbConfigFile"
        Me.tbConfigFile.Size = New System.Drawing.Size(252, 20)
        Me.tbConfigFile.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Config File"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbExtensions)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnFile)
        Me.GroupBox1.Controls.Add(Me.tbQueuePath)
        Me.GroupBox1.Controls.Add(Me.btnOpen)
        Me.GroupBox1.Controls.Add(Me.btnReset)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtpStartTime)
        Me.GroupBox1.Controls.Add(Me.tbInterval)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tbLastRun)
        Me.GroupBox1.Controls.Add(Me.tbLogFilePath)
        Me.GroupBox1.Controls.Add(Me.tbService)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 228)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 221)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service settings"
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(430, 72)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(50, 23)
        Me.btnOpen.TabIndex = 27
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(380, 102)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(48, 23)
        Me.btnReset.TabIndex = 26
        Me.btnReset.Text = "reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'dtpStartTime
        '
        Me.dtpStartTime.CustomFormat = "HH:mm:ss"
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpStartTime.Location = New System.Drawing.Point(120, 50)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.ShowUpDown = True
        Me.dtpStartTime.Size = New System.Drawing.Size(68, 20)
        Me.dtpStartTime.TabIndex = 25
        Me.dtpStartTime.Value = New Date(2011, 5, 9, 23, 0, 0, 0)
        '
        'tbInterval
        '
        Me.tbInterval.Location = New System.Drawing.Point(120, 127)
        Me.tbInterval.Name = "tbInterval"
        Me.tbInterval.Size = New System.Drawing.Size(252, 20)
        Me.tbInterval.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Interval (min.)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(381, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "kies..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "StartTime"
        '
        'tbLastRun
        '
        Me.tbLastRun.Location = New System.Drawing.Point(120, 101)
        Me.tbLastRun.Name = "tbLastRun"
        Me.tbLastRun.Size = New System.Drawing.Size(252, 20)
        Me.tbLastRun.TabIndex = 6
        '
        'tbLogFilePath
        '
        Me.tbLogFilePath.Location = New System.Drawing.Point(120, 76)
        Me.tbLogFilePath.Name = "tbLogFilePath"
        Me.tbLogFilePath.Size = New System.Drawing.Size(252, 20)
        Me.tbLogFilePath.TabIndex = 5
        '
        'tbService
        '
        Me.tbService.Location = New System.Drawing.Point(120, 26)
        Me.tbService.Name = "tbService"
        Me.tbService.Size = New System.Drawing.Size(252, 20)
        Me.tbService.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "LastRun"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "LogFile"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Service:"
        '
        'tmrCheckStatus
        '
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ssServiceStatus
        '
        Me.ssServiceStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslblService})
        Me.ssServiceStatus.Location = New System.Drawing.Point(0, 562)
        Me.ssServiceStatus.Name = "ssServiceStatus"
        Me.ssServiceStatus.Size = New System.Drawing.Size(587, 22)
        Me.ssServiceStatus.TabIndex = 40
        Me.ssServiceStatus.Text = "StatusStrip1"
        '
        'sslblService
        '
        Me.sslblService.Name = "sslblService"
        Me.sslblService.Size = New System.Drawing.Size(19, 17)
        Me.sslblService.Text = "...."
        '
        'btnStop
        '
        Me.btnStop.AccessibleDescription = "Button used to Stop the Windows Service."
        Me.btnStop.AccessibleName = "Stop Button"
        Me.btnStop.Enabled = False
        Me.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStop.Location = New System.Drawing.Point(358, 455)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 44
        Me.btnStop.Text = "Sto&p"
        '
        'btnContinue
        '
        Me.btnContinue.AccessibleDescription = "Button used to Continue the Windows Service."
        Me.btnContinue.AccessibleName = "Continue Button"
        Me.btnContinue.Enabled = False
        Me.btnContinue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnContinue.Location = New System.Drawing.Point(270, 455)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(75, 23)
        Me.btnContinue.TabIndex = 43
        Me.btnContinue.Text = "&Continue"
        '
        'btnPause
        '
        Me.btnPause.AccessibleDescription = "Button used to Pause the Windows Service."
        Me.btnPause.AccessibleName = "Pause Button"
        Me.btnPause.Enabled = False
        Me.btnPause.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPause.Location = New System.Drawing.Point(182, 455)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(75, 23)
        Me.btnPause.TabIndex = 42
        Me.btnPause.Text = "&Pause"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(94, 455)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 41
        Me.btnStart.Text = "Start service"
        '
        'tbExtensions
        '
        Me.tbExtensions.Location = New System.Drawing.Point(120, 179)
        Me.tbExtensions.Name = "tbExtensions"
        Me.tbExtensions.Size = New System.Drawing.Size(252, 20)
        Me.tbExtensions.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 182)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Allowed Extensions"
        Me.ToolTip1.SetToolTip(Me.Label6, "gescheiden door semicolon ;")
        '
        'dlgSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 584)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.ssServiceStatus)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpCredentials)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "dlgSettings"
        Me.Text = "dlgSettings"
        Me.grpCredentials.ResumeLayout(False)
        Me.grpCredentials.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssServiceStatus.ResumeLayout(False)
        Me.ssServiceStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbdQueue As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tbDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents tbAccount As System.Windows.Forms.TextBox
    Friend WithEvents tbServer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpCredentials As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents tbQueuePath As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbConfigFile As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents dtpStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbLastRun As System.Windows.Forms.TextBox
    Friend WithEvents tbLogFilePath As System.Windows.Forms.TextBox
    Friend WithEvents tbService As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tmrCheckStatus As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ofdConfig As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ssServiceStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents sslblService As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents tbExtensions As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
