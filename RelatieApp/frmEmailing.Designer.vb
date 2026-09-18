<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmailing))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTemplate = New System.Windows.Forms.TextBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fbdSave = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.tbfileSave = New System.Windows.Forms.TextBox()
        Me.HtmlTextbox1 = New GvS.Controls.HtmlTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbSubject = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbAttachment = New System.Windows.Forms.TextBox()
        Me.btAtt = New System.Windows.Forms.Button()
        Me.ofFile = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbPostStatus = New System.Windows.Forms.Label()
        Me.lblMailStatus = New System.Windows.Forms.Label()
        Me.lblPostCount = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.lblMailCount = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.btLoadBody = New System.Windows.Forms.Button()
        Me.ofdBody = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProgressBarWord = New System.Windows.Forms.ProgressBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btTestMail = New System.Windows.Forms.Button()
        Me.cmbSender = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(326, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 13)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Deze brief gaat naar relaties zonder email adres."
        '
        'tbTemplate
        '
        Me.tbTemplate.Location = New System.Drawing.Point(90, 44)
        Me.tbTemplate.Name = "tbTemplate"
        Me.tbTemplate.ReadOnly = True
        Me.tbTemplate.Size = New System.Drawing.Size(230, 20)
        Me.tbTemplate.TabIndex = 137
        '
        'btnFile
        '
        Me.btnFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFile.ImageIndex = 7
        Me.btnFile.ImageList = Me.ImageList1
        Me.btnFile.Location = New System.Drawing.Point(326, 68)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(97, 23)
        Me.btnFile.TabIndex = 140
        Me.btnFile.Text = "Selecteer..."
        Me.btnFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFile.UseVisualStyleBackColor = True
        Me.btnFile.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "search.ico")
        Me.ImageList1.Images.SetKeyName(1, "+.ico")
        Me.ImageList1.Images.SetKeyName(2, "ok.ico")
        Me.ImageList1.Images.SetKeyName(3, "mail.ico")
        Me.ImageList1.Images.SetKeyName(4, "delete.ico")
        Me.ImageList1.Images.SetKeyName(5, "mail.ico")
        Me.ImageList1.Images.SetKeyName(6, "reload.ico")
        Me.ImageList1.Images.SetKeyName(7, "file open.ico")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Opslaan in ..."
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "Brief sjabloon"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(932, 121)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(165, 29)
        Me.TableLayoutPanel1.TabIndex = 142
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OK_Button.ImageIndex = 6
        Me.OK_Button.ImageList = Me.ImageList1
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(76, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Verwerken"
        Me.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cancel_Button.ImageIndex = 4
        Me.Cancel_Button.ImageList = Me.ImageList1
        Me.Cancel_Button.Location = New System.Drawing.Point(85, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(76, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Sluiten"
        Me.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbfileSave
        '
        Me.tbfileSave.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RelatieApp.My.MySettings.Default, "ReportsPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbfileSave.Location = New System.Drawing.Point(90, 70)
        Me.tbfileSave.Name = "tbfileSave"
        Me.tbfileSave.ReadOnly = True
        Me.tbfileSave.Size = New System.Drawing.Size(230, 20)
        Me.tbfileSave.TabIndex = 138
        Me.tbfileSave.Text = Global.RelatieApp.My.MySettings.Default.ReportsPath
        Me.tbfileSave.Visible = False
        '
        'HtmlTextbox1
        '
        Me.HtmlTextbox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HtmlTextbox1.Fonts = New String() {"Corbel", "Corbel, Verdana, Arial, Helvetica, sans-serif", "Georgia, Times New Roman, Times, serif", "Consolas, Courier New, Courier, monospace"}
        Me.HtmlTextbox1.IllegalPatterns = New String() {"<script.*?>", "<\w+\s+.*?(j|java|vb|ecma)script:.*?>", "<\w+(\s+|\s+.*?\s+)on\w+\s*=.+?>", "</?input.*?>"}
        Me.HtmlTextbox1.Location = New System.Drawing.Point(131, 264)
        Me.HtmlTextbox1.Name = "HtmlTextbox1"
        Me.HtmlTextbox1.Padding = New System.Windows.Forms.Padding(1)
        Me.HtmlTextbox1.ShowHtmlSource = False
        Me.HtmlTextbox1.Size = New System.Drawing.Size(966, 416)
        Me.HtmlTextbox1.TabIndex = 143
        Me.HtmlTextbox1.ToolbarStyle = GvS.Controls.ToolbarStyles.AlwaysInternal
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Onderwerp"
        '
        'tbSubject
        '
        Me.tbSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSubject.Location = New System.Drawing.Point(131, 202)
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Size = New System.Drawing.Size(537, 20)
        Me.tbSubject.TabIndex = 144
        Me.tbSubject.Text = "VBM Mailing"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "Bijlage (optioneel) "
        '
        'tbAttachment
        '
        Me.tbAttachment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAttachment.Location = New System.Drawing.Point(131, 231)
        Me.tbAttachment.Name = "tbAttachment"
        Me.tbAttachment.ReadOnly = True
        Me.tbAttachment.Size = New System.Drawing.Size(537, 20)
        Me.tbAttachment.TabIndex = 146
        '
        'btAtt
        '
        Me.btAtt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAtt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAtt.ImageIndex = 7
        Me.btAtt.ImageList = Me.ImageList1
        Me.btAtt.Location = New System.Drawing.Point(674, 229)
        Me.btAtt.Name = "btAtt"
        Me.btAtt.Size = New System.Drawing.Size(121, 23)
        Me.btAtt.TabIndex = 148
        Me.btAtt.Text = "Selecteer bijlage"
        Me.btAtt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAtt.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar.Location = New System.Drawing.Point(0, 717)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(1122, 23)
        Me.ProgressBar.TabIndex = 149
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lbPostStatus)
        Me.GroupBox3.Controls.Add(Me.lblMailStatus)
        Me.GroupBox3.Controls.Add(Me.lblPostCount)
        Me.GroupBox3.Controls.Add(Me.label9)
        Me.GroupBox3.Controls.Add(Me.lblMailCount)
        Me.GroupBox3.Controls.Add(Me.label8)
        Me.GroupBox3.Location = New System.Drawing.Point(787, 36)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(310, 79)
        Me.GroupBox3.TabIndex = 150
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status"
        '
        'lbPostStatus
        '
        Me.lbPostStatus.AutoSize = True
        Me.lbPostStatus.Location = New System.Drawing.Point(116, 26)
        Me.lbPostStatus.Name = "lbPostStatus"
        Me.lbPostStatus.Size = New System.Drawing.Size(13, 13)
        Me.lbPostStatus.TabIndex = 129
        Me.lbPostStatus.Text = "0"
        '
        'lblMailStatus
        '
        Me.lblMailStatus.AutoSize = True
        Me.lblMailStatus.Location = New System.Drawing.Point(116, 48)
        Me.lblMailStatus.Name = "lblMailStatus"
        Me.lblMailStatus.Size = New System.Drawing.Size(13, 13)
        Me.lblMailStatus.TabIndex = 128
        Me.lblMailStatus.Text = "0"
        '
        'lblPostCount
        '
        Me.lblPostCount.AutoSize = True
        Me.lblPostCount.Location = New System.Drawing.Point(78, 26)
        Me.lblPostCount.Name = "lblPostCount"
        Me.lblPostCount.Size = New System.Drawing.Size(13, 13)
        Me.lblPostCount.TabIndex = 127
        Me.lblPostCount.Text = "0"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(9, 26)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(63, 13)
        Me.label9.TabIndex = 126
        Me.label9.Text = "Aantal post:"
        '
        'lblMailCount
        '
        Me.lblMailCount.AutoSize = True
        Me.lblMailCount.Location = New System.Drawing.Point(78, 48)
        Me.lblMailCount.Name = "lblMailCount"
        Me.lblMailCount.Size = New System.Drawing.Size(13, 13)
        Me.lblMailCount.TabIndex = 125
        Me.lblMailCount.Text = "0"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(9, 48)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(61, 13)
        Me.label8.TabIndex = 124
        Me.label8.Text = "Aantal mail:"
        '
        'btLoadBody
        '
        Me.btLoadBody.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btLoadBody.ImageIndex = 7
        Me.btLoadBody.ImageList = Me.ImageList1
        Me.btLoadBody.Location = New System.Drawing.Point(12, 264)
        Me.btLoadBody.Name = "btLoadBody"
        Me.btLoadBody.Size = New System.Drawing.Size(102, 30)
        Me.btLoadBody.TabIndex = 151
        Me.btLoadBody.Text = "Mail sjabloon"
        Me.btLoadBody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btLoadBody.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(90, 183)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1009, 10)
        Me.GroupBox1.TabIndex = 152
        Me.GroupBox1.TabStop = False
        '
        'ProgressBarWord
        '
        Me.ProgressBarWord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarWord.Location = New System.Drawing.Point(0, 156)
        Me.ProgressBarWord.Name = "ProgressBarWord"
        Me.ProgressBarWord.Size = New System.Drawing.Size(1122, 23)
        Me.ProgressBarWord.TabIndex = 153
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1122, 25)
        Me.ToolStrip1.TabIndex = 154
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btTestMail
        '
        Me.btTestMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btTestMail.ImageIndex = 3
        Me.btTestMail.ImageList = Me.ImageList1
        Me.btTestMail.Location = New System.Drawing.Point(12, 297)
        Me.btTestMail.Name = "btTestMail"
        Me.btTestMail.Size = New System.Drawing.Size(102, 30)
        Me.btTestMail.TabIndex = 155
        Me.btTestMail.Text = "Test mail"
        Me.btTestMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btTestMail, "Voert de validatie uit en verzend een test mail naar opgegeven adres.")
        Me.btTestMail.UseVisualStyleBackColor = True
        '
        'cmbSender
        '
        Me.cmbSender.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSender.BackColor = System.Drawing.Color.White
        Me.cmbSender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSender.DropDownWidth = 200
        Me.cmbSender.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSender.FormattingEnabled = True
        Me.cmbSender.Location = New System.Drawing.Point(674, 201)
        Me.cmbSender.Name = "cmbSender"
        Me.cmbSender.Size = New System.Drawing.Size(121, 21)
        Me.cmbSender.TabIndex = 156
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(801, 205)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "Selecteer de afzender."
        '
        'frmEmailing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 740)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbSender)
        Me.Controls.Add(Me.btTestMail)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ProgressBarWord)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btLoadBody)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.btAtt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbAttachment)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbSubject)
        Me.Controls.Add(Me.HtmlTextbox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbfileSave)
        Me.Controls.Add(Me.tbTemplate)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmailing"
        Me.Text = "(E)mailing"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbTemplate As System.Windows.Forms.TextBox
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbfileSave As System.Windows.Forms.TextBox
    Friend WithEvents fbdSave As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents HtmlTextbox1 As GvS.Controls.HtmlTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbAttachment As System.Windows.Forms.TextBox
    Friend WithEvents btAtt As System.Windows.Forms.Button
    Friend WithEvents ofFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMailCount As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents lblPostCount As System.Windows.Forms.Label
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents btLoadBody As System.Windows.Forms.Button
    Friend WithEvents ofdBody As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBarWord As System.Windows.Forms.ProgressBar
    Friend WithEvents lbPostStatus As System.Windows.Forms.Label
    Friend WithEvents lblMailStatus As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btTestMail As System.Windows.Forms.Button
    Friend WithEvents cmbSender As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
