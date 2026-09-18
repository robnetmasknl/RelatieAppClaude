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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgSettings))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.grpSettings = New System.Windows.Forms.GroupBox
        Me.tbMailAccountPassword = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbMailAccount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbMailSenderEmail = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.tbMailSenderName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbMailServer = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.grpCredentials = New System.Windows.Forms.GroupBox
        Me.btnTestConn = New System.Windows.Forms.Button
        Me.tbDatabase = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbPassword = New System.Windows.Forms.TextBox
        Me.tbAccount = New System.Windows.Forms.TextBox
        Me.tbServer = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fbdQueue = New System.Windows.Forms.FolderBrowserDialog
        Me.lnkAbout = New System.Windows.Forms.LinkLabel
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpSettings.SuspendLayout()
        Me.grpCredentials.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(529, 351)
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
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.tbMailAccountPassword)
        Me.grpSettings.Controls.Add(Me.Label10)
        Me.grpSettings.Controls.Add(Me.tbMailAccount)
        Me.grpSettings.Controls.Add(Me.Label9)
        Me.grpSettings.Controls.Add(Me.tbMailSenderEmail)
        Me.grpSettings.Controls.Add(Me.Label6)
        Me.grpSettings.Controls.Add(Me.tbMailSenderName)
        Me.grpSettings.Controls.Add(Me.Label8)
        Me.grpSettings.Controls.Add(Me.tbMailServer)
        Me.grpSettings.Controls.Add(Me.Label5)
        Me.grpSettings.Location = New System.Drawing.Point(19, 39)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(574, 172)
        Me.grpSettings.TabIndex = 9
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "MailSettings"
        '
        'tbMailAccountPassword
        '
        Me.tbMailAccountPassword.Location = New System.Drawing.Point(122, 123)
        Me.tbMailAccountPassword.Name = "tbMailAccountPassword"
        Me.tbMailAccountPassword.Size = New System.Drawing.Size(252, 20)
        Me.tbMailAccountPassword.TabIndex = 14
        Me.tbMailAccountPassword.UseSystemPasswordChar = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Account password:"
        '
        'tbMailAccount
        '
        Me.tbMailAccount.Location = New System.Drawing.Point(122, 97)
        Me.tbMailAccount.Name = "tbMailAccount"
        Me.tbMailAccount.Size = New System.Drawing.Size(252, 20)
        Me.tbMailAccount.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Mail account:"
        '
        'tbMailSenderEmail
        '
        Me.tbMailSenderEmail.Location = New System.Drawing.Point(122, 71)
        Me.tbMailSenderEmail.Name = "tbMailSenderEmail"
        Me.tbMailSenderEmail.Size = New System.Drawing.Size(252, 20)
        Me.tbMailSenderEmail.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Afzender email:"
        '
        'tbMailSenderName
        '
        Me.tbMailSenderName.Location = New System.Drawing.Point(122, 45)
        Me.tbMailSenderName.Name = "tbMailSenderName"
        Me.tbMailSenderName.Size = New System.Drawing.Size(252, 20)
        Me.tbMailSenderName.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Afzender naam:"
        '
        'tbMailServer
        '
        Me.tbMailServer.Location = New System.Drawing.Point(122, 19)
        Me.tbMailServer.Name = "tbMailServer"
        Me.tbMailServer.Size = New System.Drawing.Size(252, 20)
        Me.tbMailServer.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Mail server"
        '
        'grpCredentials
        '
        Me.grpCredentials.Controls.Add(Me.btnTestConn)
        Me.grpCredentials.Controls.Add(Me.tbDatabase)
        Me.grpCredentials.Controls.Add(Me.Label4)
        Me.grpCredentials.Controls.Add(Me.tbPassword)
        Me.grpCredentials.Controls.Add(Me.tbAccount)
        Me.grpCredentials.Controls.Add(Me.tbServer)
        Me.grpCredentials.Controls.Add(Me.Label3)
        Me.grpCredentials.Controls.Add(Me.Label2)
        Me.grpCredentials.Controls.Add(Me.Label1)
        Me.grpCredentials.Location = New System.Drawing.Point(15, 49)
        Me.grpCredentials.Name = "grpCredentials"
        Me.grpCredentials.Size = New System.Drawing.Size(574, 154)
        Me.grpCredentials.TabIndex = 8
        Me.grpCredentials.TabStop = False
        Me.grpCredentials.Text = "Database settings"
        '
        'btnTestConn
        '
        Me.btnTestConn.Location = New System.Drawing.Point(381, 69)
        Me.btnTestConn.Name = "btnTestConn"
        Me.btnTestConn.Size = New System.Drawing.Size(98, 23)
        Me.btnTestConn.TabIndex = 11
        Me.btnTestConn.Text = "Test Connection"
        Me.btnTestConn.UseVisualStyleBackColor = True
        '
        'tbDatabase
        '
        Me.tbDatabase.Location = New System.Drawing.Point(122, 52)
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
        Me.tbPassword.Location = New System.Drawing.Point(122, 101)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(252, 20)
        Me.tbPassword.TabIndex = 6
        Me.tbPassword.UseSystemPasswordChar = True
        '
        'tbAccount
        '
        Me.tbAccount.Location = New System.Drawing.Point(122, 76)
        Me.tbAccount.Name = "tbAccount"
        Me.tbAccount.Size = New System.Drawing.Size(252, 20)
        Me.tbAccount.TabIndex = 5
        '
        'tbServer
        '
        Me.tbServer.Location = New System.Drawing.Point(122, 26)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Account"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Database server:"
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(663, 291)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpCredentials)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(655, 265)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Database settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grpSettings)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(651, 265)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mail settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dlgSettings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(687, 383)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lnkAbout)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Standaard instellingen"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        Me.grpCredentials.ResumeLayout(False)
        Me.grpCredentials.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents tbMailServer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpCredentials As System.Windows.Forms.GroupBox
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents tbAccount As System.Windows.Forms.TextBox
    Friend WithEvents tbServer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbDatabase As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fbdQueue As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tbMailSenderName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnTestConn As System.Windows.Forms.Button
    Friend WithEvents lnkAbout As System.Windows.Forms.LinkLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tbMailAccountPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbMailAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbMailSenderEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage

End Class
