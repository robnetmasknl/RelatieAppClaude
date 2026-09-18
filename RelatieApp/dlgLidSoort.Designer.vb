<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgLidSoort
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.dtpDatumIn = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbLidSoorten = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbokorting = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbmkorting = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbobedrag = New System.Windows.Forms.TextBox()
        Me.dtpSedert = New System.Windows.Forms.DateTimePicker()
        Me.tbmbedrag = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbNskIgnore = New System.Windows.Forms.RadioButton()
        Me.rbNSKStoppen = New System.Windows.Forms.RadioButton()
        Me.rbNSKStarten = New System.Windows.Forms.RadioButton()
        Me.UcNSKDatum = New RelatieApp.ucTextDate()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkNSK = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(120, 310)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
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
        'dtpDatumIn
        '
        Me.dtpDatumIn.CustomFormat = "dd-MM-yyyy"
        Me.dtpDatumIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDatumIn.Location = New System.Drawing.Point(132, 48)
        Me.dtpDatumIn.Name = "dtpDatumIn"
        Me.dtpDatumIn.Size = New System.Drawing.Size(121, 20)
        Me.dtpDatumIn.TabIndex = 79
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "Ingangs datum:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Lidsoort:"
        '
        'cmbLidSoorten
        '
        Me.cmbLidSoorten.FormattingEnabled = True
        Me.cmbLidSoorten.Location = New System.Drawing.Point(132, 21)
        Me.cmbLidSoorten.Name = "cmbLidSoorten"
        Me.cmbLidSoorten.Size = New System.Drawing.Size(145, 21)
        Me.cmbLidSoorten.TabIndex = 76
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.tbokorting)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.tbmkorting)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.tbobedrag)
        Me.GroupBox2.Controls.Add(Me.dtpSedert)
        Me.GroupBox2.Controls.Add(Me.tbmbedrag)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(268, 90)
        Me.GroupBox2.TabIndex = 81
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contributie:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "korting oud:"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "korting nu:"
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 76)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 13)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "contributie oud:"
        Me.Label15.Visible = False
        '
        'tbokorting
        '
        Me.tbokorting.Enabled = False
        Me.tbokorting.Location = New System.Drawing.Point(120, 99)
        Me.tbokorting.Name = "tbokorting"
        Me.tbokorting.Size = New System.Drawing.Size(121, 20)
        Me.tbokorting.TabIndex = 75
        Me.tbokorting.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "contributie nu:"
        '
        'tbmkorting
        '
        Me.tbmkorting.Enabled = False
        Me.tbmkorting.Location = New System.Drawing.Point(120, 86)
        Me.tbmkorting.Name = "tbmkorting"
        Me.tbmkorting.Size = New System.Drawing.Size(121, 20)
        Me.tbmkorting.TabIndex = 74
        Me.tbmkorting.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 13)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "met ingang van:"
        '
        'tbobedrag
        '
        Me.tbobedrag.Enabled = False
        Me.tbobedrag.Location = New System.Drawing.Point(120, 73)
        Me.tbobedrag.Name = "tbobedrag"
        Me.tbobedrag.Size = New System.Drawing.Size(121, 20)
        Me.tbobedrag.TabIndex = 73
        Me.tbobedrag.Visible = False
        '
        'dtpSedert
        '
        Me.dtpSedert.CustomFormat = "MM-yyyy"
        Me.dtpSedert.Enabled = False
        Me.dtpSedert.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSedert.Location = New System.Drawing.Point(120, 21)
        Me.dtpSedert.Name = "dtpSedert"
        Me.dtpSedert.Size = New System.Drawing.Size(121, 20)
        Me.dtpSedert.TabIndex = 71
        '
        'tbmbedrag
        '
        Me.tbmbedrag.Enabled = False
        Me.tbmbedrag.Location = New System.Drawing.Point(120, 54)
        Me.tbmbedrag.Name = "tbmbedrag"
        Me.tbmbedrag.Size = New System.Drawing.Size(121, 20)
        Me.tbmbedrag.TabIndex = 72
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbNskIgnore)
        Me.GroupBox1.Controls.Add(Me.rbNSKStoppen)
        Me.GroupBox1.Controls.Add(Me.rbNSKStarten)
        Me.GroupBox1.Controls.Add(Me.UcNSKDatum)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkNSK)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 97)
        Me.GroupBox1.TabIndex = 82
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "NSK"
        '
        'rbNskIgnore
        '
        Me.rbNskIgnore.AutoSize = True
        Me.rbNskIgnore.Location = New System.Drawing.Point(9, 65)
        Me.rbNskIgnore.Name = "rbNskIgnore"
        Me.rbNskIgnore.Size = New System.Drawing.Size(108, 17)
        Me.rbNskIgnore.TabIndex = 85
        Me.rbNskIgnore.TabStop = True
        Me.rbNskIgnore.Text = "Geen aanpassing"
        Me.rbNskIgnore.UseVisualStyleBackColor = True
        '
        'rbNSKStoppen
        '
        Me.rbNSKStoppen.AutoSize = True
        Me.rbNSKStoppen.Location = New System.Drawing.Point(9, 42)
        Me.rbNSKStoppen.Name = "rbNSKStoppen"
        Me.rbNSKStoppen.Size = New System.Drawing.Size(116, 17)
        Me.rbNSKStoppen.TabIndex = 84
        Me.rbNSKStoppen.TabStop = True
        Me.rbNSKStoppen.Text = "Contributie stoppen"
        Me.rbNSKStoppen.UseVisualStyleBackColor = True
        '
        'rbNSKStarten
        '
        Me.rbNSKStarten.AutoSize = True
        Me.rbNSKStarten.Location = New System.Drawing.Point(9, 19)
        Me.rbNSKStarten.Name = "rbNSKStarten"
        Me.rbNSKStarten.Size = New System.Drawing.Size(110, 17)
        Me.rbNSKStarten.TabIndex = 83
        Me.rbNSKStarten.TabStop = True
        Me.rbNSKStarten.Text = "Contributie starten"
        Me.rbNSKStarten.UseVisualStyleBackColor = True
        '
        'UcNSKDatum
        '
        Me.UcNSKDatum.Location = New System.Drawing.Point(128, 39)
        Me.UcNSKDatum.Name = "UcNSKDatum"
        Me.UcNSKDatum.Size = New System.Drawing.Size(130, 27)
        Me.UcNSKDatum.TabIndex = 82
        Me.UcNSKDatum.Value = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(145, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "melding datum:"
        '
        'chkNSK
        '
        Me.chkNSK.AutoSize = True
        Me.chkNSK.Location = New System.Drawing.Point(137, 66)
        Me.chkNSK.Name = "chkNSK"
        Me.chkNSK.Size = New System.Drawing.Size(104, 17)
        Me.chkNSK.TabIndex = 0
        Me.chkNSK.Text = "Aanmelden NSK"
        Me.chkNSK.UseVisualStyleBackColor = True
        Me.chkNSK.Visible = False
        '
        'ToolTip1
        '
        '
        'dlgLidSoort
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(322, 357)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtpDatumIn)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbLidSoorten)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgLidSoort"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgLidSoort"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents dtpDatumIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbLidSoorten As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpSedert As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbmbedrag As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbokorting As System.Windows.Forms.TextBox
    Friend WithEvents tbmkorting As System.Windows.Forms.TextBox
    Friend WithEvents tbobedrag As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkNSK As System.Windows.Forms.CheckBox
    Friend WithEvents UcNSKDatum As RelatieApp.ucTextDate
    Friend WithEvents rbNSKStoppen As System.Windows.Forms.RadioButton
    Friend WithEvents rbNSKStarten As System.Windows.Forms.RadioButton
    Friend WithEvents rbNskIgnore As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As ToolTip
End Class
