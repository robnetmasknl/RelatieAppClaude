<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgNewBlok
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblAdviseur = New System.Windows.Forms.Label
        Me.dtpDatum = New System.Windows.Forms.DateTimePicker
        Me.cmbLocaties = New System.Windows.Forms.ComboBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmbBlokTypes = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbVutype = New System.Windows.Forms.ComboBox
        Me.lblTijdsduur = New System.Windows.Forms.Label
        Me.lblPauze = New System.Windows.Forms.Label
        Me.lblBlokken = New System.Windows.Forms.Label
        Me.lblAanvang = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(128, 289)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "locatie:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Datum:"
        '
        'lblAdviseur
        '
        Me.lblAdviseur.AutoSize = True
        Me.lblAdviseur.Location = New System.Drawing.Point(27, 19)
        Me.lblAdviseur.Name = "lblAdviseur"
        Me.lblAdviseur.Size = New System.Drawing.Size(57, 13)
        Me.lblAdviseur.TabIndex = 8
        Me.lblAdviseur.Text = "Adviseur..."
        '
        'dtpDatum
        '
        Me.dtpDatum.CustomFormat = "dd-MM-yyyy"
        Me.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDatum.Location = New System.Drawing.Point(114, 84)
        Me.dtpDatum.Name = "dtpDatum"
        Me.dtpDatum.Size = New System.Drawing.Size(152, 20)
        Me.dtpDatum.TabIndex = 13
        '
        'cmbLocaties
        '
        Me.cmbLocaties.FormattingEnabled = True
        Me.cmbLocaties.Location = New System.Drawing.Point(114, 57)
        Me.cmbLocaties.Name = "cmbLocaties"
        Me.cmbLocaties.Size = New System.Drawing.Size(152, 21)
        Me.cmbLocaties.TabIndex = 15
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmbBlokTypes
        '
        Me.cmbBlokTypes.FormattingEnabled = True
        Me.cmbBlokTypes.Location = New System.Drawing.Point(114, 112)
        Me.cmbBlokTypes.Name = "cmbBlokTypes"
        Me.cmbBlokTypes.Size = New System.Drawing.Size(152, 21)
        Me.cmbBlokTypes.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "BlokTemplate"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Vultype:"
        '
        'cmbVutype
        '
        Me.cmbVutype.FormattingEnabled = True
        Me.cmbVutype.Location = New System.Drawing.Point(114, 139)
        Me.cmbVutype.Name = "cmbVutype"
        Me.cmbVutype.Size = New System.Drawing.Size(152, 21)
        Me.cmbVutype.TabIndex = 14
        '
        'lblTijdsduur
        '
        Me.lblTijdsduur.AutoSize = True
        Me.lblTijdsduur.Location = New System.Drawing.Point(27, 246)
        Me.lblTijdsduur.Name = "lblTijdsduur"
        Me.lblTijdsduur.Size = New System.Drawing.Size(60, 13)
        Me.lblTijdsduur.TabIndex = 25
        Me.lblTijdsduur.Text = "lblTijdsduur"
        '
        'lblPauze
        '
        Me.lblPauze.AutoSize = True
        Me.lblPauze.Location = New System.Drawing.Point(27, 223)
        Me.lblPauze.Name = "lblPauze"
        Me.lblPauze.Size = New System.Drawing.Size(47, 13)
        Me.lblPauze.TabIndex = 24
        Me.lblPauze.Text = "lblPauze"
        '
        'lblBlokken
        '
        Me.lblBlokken.AutoSize = True
        Me.lblBlokken.Location = New System.Drawing.Point(27, 198)
        Me.lblBlokken.Name = "lblBlokken"
        Me.lblBlokken.Size = New System.Drawing.Size(56, 13)
        Me.lblBlokken.TabIndex = 23
        Me.lblBlokken.Text = "lblBlokken"
        '
        'lblAanvang
        '
        Me.lblAanvang.AutoSize = True
        Me.lblAanvang.Location = New System.Drawing.Point(27, 174)
        Me.lblAanvang.Name = "lblAanvang"
        Me.lblAanvang.Size = New System.Drawing.Size(60, 13)
        Me.lblAanvang.TabIndex = 22
        Me.lblAanvang.Text = "lblAanvang"
        '
        'dlgNewBlok
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(286, 330)
        Me.Controls.Add(Me.lblTijdsduur)
        Me.Controls.Add(Me.lblPauze)
        Me.Controls.Add(Me.lblBlokken)
        Me.Controls.Add(Me.lblAanvang)
        Me.Controls.Add(Me.cmbBlokTypes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbLocaties)
        Me.Controls.Add(Me.cmbVutype)
        Me.Controls.Add(Me.dtpDatum)
        Me.Controls.Add(Me.lblAdviseur)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgNewBlok"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nieuw blok..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAdviseur As System.Windows.Forms.Label
    Friend WithEvents dtpDatum As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbLocaties As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbBlokTypes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTijdsduur As System.Windows.Forms.Label
    Friend WithEvents lblPauze As System.Windows.Forms.Label
    Friend WithEvents lblBlokken As System.Windows.Forms.Label
    Friend WithEvents lblAanvang As System.Windows.Forms.Label
    Friend WithEvents cmbVutype As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
