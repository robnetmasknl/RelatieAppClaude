<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgIbbReports
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.cmbBehandelaar = New System.Windows.Forms.ComboBox()
        Me.lblHandler = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbSavePath = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.fbdSave = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblVan = New System.Windows.Forms.Label()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.tbSearchText = New System.Windows.Forms.TextBox()
        Me.lblVanToevoeging = New System.Windows.Forms.Label()
        Me.cmbRubriek = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbIBBGroep = New System.Windows.Forms.ComboBox()
        Me.lblIBBGroep = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(321, 249)
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
        'cmbBehandelaar
        '
        Me.cmbBehandelaar.FormattingEnabled = True
        Me.cmbBehandelaar.Location = New System.Drawing.Point(113, 61)
        Me.cmbBehandelaar.Name = "cmbBehandelaar"
        Me.cmbBehandelaar.Size = New System.Drawing.Size(260, 21)
        Me.cmbBehandelaar.TabIndex = 91
        '
        'lblHandler
        '
        Me.lblHandler.AutoSize = True
        Me.lblHandler.Location = New System.Drawing.Point(42, 64)
        Me.lblHandler.Name = "lblHandler"
        Me.lblHandler.Size = New System.Drawing.Size(70, 13)
        Me.lblHandler.TabIndex = 90
        Me.lblHandler.Text = "Behandelaar:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Opslaan in:"
        '
        'tbSavePath
        '
        Me.tbSavePath.Enabled = False
        Me.tbSavePath.Location = New System.Drawing.Point(113, 35)
        Me.tbSavePath.Name = "tbSavePath"
        Me.tbSavePath.Size = New System.Drawing.Size(260, 20)
        Me.tbSavePath.TabIndex = 109
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(379, 32)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 23)
        Me.btnSave.TabIndex = 108
        Me.btnSave.Text = "Selecteer bestand"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblVan
        '
        Me.lblVan.AutoSize = True
        Me.lblVan.Location = New System.Drawing.Point(42, 141)
        Me.lblVan.Name = "lblVan"
        Me.lblVan.Size = New System.Drawing.Size(35, 13)
        Me.lblVan.TabIndex = 112
        Me.lblVan.Text = "Van..."
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "dd-MM-yyyy"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(113, 138)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(95, 20)
        Me.dtpStart.TabIndex = 111
        Me.dtpStart.Value = New Date(2010, 1, 1, 0, 0, 0, 0)
        '
        'tbSearchText
        '
        Me.tbSearchText.Location = New System.Drawing.Point(113, 159)
        Me.tbSearchText.Name = "tbSearchText"
        Me.tbSearchText.Size = New System.Drawing.Size(260, 20)
        Me.tbSearchText.TabIndex = 113
        Me.tbSearchText.Visible = False
        '
        'lblVanToevoeging
        '
        Me.lblVanToevoeging.AutoSize = True
        Me.lblVanToevoeging.Location = New System.Drawing.Point(214, 141)
        Me.lblVanToevoeging.Name = "lblVanToevoeging"
        Me.lblVanToevoeging.Size = New System.Drawing.Size(35, 13)
        Me.lblVanToevoeging.TabIndex = 114
        Me.lblVanToevoeging.Text = "Van..."
        Me.lblVanToevoeging.Visible = False
        '
        'cmbRubriek
        '
        Me.cmbRubriek.FormattingEnabled = True
        Me.cmbRubriek.Location = New System.Drawing.Point(113, 85)
        Me.cmbRubriek.Name = "cmbRubriek"
        Me.cmbRubriek.Size = New System.Drawing.Size(260, 21)
        Me.cmbRubriek.TabIndex = 116
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Rubriek:"
        '
        'cmbIBBGroep
        '
        Me.cmbIBBGroep.FormattingEnabled = True
        Me.cmbIBBGroep.Location = New System.Drawing.Point(113, 109)
        Me.cmbIBBGroep.Name = "cmbIBBGroep"
        Me.cmbIBBGroep.Size = New System.Drawing.Size(260, 21)
        Me.cmbIBBGroep.TabIndex = 118
        Me.cmbIBBGroep.Visible = False
        '
        'lblIBBGroep
        '
        Me.lblIBBGroep.AutoSize = True
        Me.lblIBBGroep.Location = New System.Drawing.Point(42, 112)
        Me.lblIBBGroep.Name = "lblIBBGroep"
        Me.lblIBBGroep.Size = New System.Drawing.Size(56, 13)
        Me.lblIBBGroep.TabIndex = 117
        Me.lblIBBGroep.Text = "IBBGroep:"
        Me.lblIBBGroep.Visible = False
        '
        'dlgIbbReports
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(479, 290)
        Me.Controls.Add(Me.cmbIBBGroep)
        Me.Controls.Add(Me.lblIBBGroep)
        Me.Controls.Add(Me.cmbRubriek)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVanToevoeging)
        Me.Controls.Add(Me.tbSearchText)
        Me.Controls.Add(Me.lblVan)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbSavePath)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbBehandelaar)
        Me.Controls.Add(Me.lblHandler)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgIbbReports"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ibb Overzichten"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cmbBehandelaar As System.Windows.Forms.ComboBox
    Friend WithEvents lblHandler As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbSavePath As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents fbdSave As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblVan As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbSearchText As System.Windows.Forms.TextBox
    Friend WithEvents lblVanToevoeging As System.Windows.Forms.Label
    Friend WithEvents cmbRubriek As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbIBBGroep As ComboBox
    Friend WithEvents lblIBBGroep As Label
End Class
