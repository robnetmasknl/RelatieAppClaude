<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgInstance
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.grpInstantie = New System.Windows.Forms.GroupBox
        Me.tbInstantieOud = New System.Windows.Forms.TextBox
        Me.dtpInstantie = New System.Windows.Forms.DateTimePicker
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.cmbContrInstanties = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpInstantie.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(103, 228)
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
        'grpInstantie
        '
        Me.grpInstantie.Controls.Add(Me.tbInstantieOud)
        Me.grpInstantie.Controls.Add(Me.dtpInstantie)
        Me.grpInstantie.Controls.Add(Me.Label34)
        Me.grpInstantie.Controls.Add(Me.Label33)
        Me.grpInstantie.Controls.Add(Me.cmbContrInstanties)
        Me.grpInstantie.Controls.Add(Me.Label31)
        Me.grpInstantie.Location = New System.Drawing.Point(12, 12)
        Me.grpInstantie.Name = "grpInstantie"
        Me.grpInstantie.Padding = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.grpInstantie.Size = New System.Drawing.Size(234, 146)
        Me.grpInstantie.TabIndex = 104
        Me.grpInstantie.TabStop = False
        Me.grpInstantie.Text = "Instantie"
        '
        'tbInstantieOud
        '
        Me.tbInstantieOud.Location = New System.Drawing.Point(56, 98)
        Me.tbInstantieOud.Name = "tbInstantieOud"
        Me.tbInstantieOud.ReadOnly = True
        Me.tbInstantieOud.Size = New System.Drawing.Size(121, 20)
        Me.tbInstantieOud.TabIndex = 108
        '
        'dtpInstantie
        '
        Me.dtpInstantie.CustomFormat = "dd-MM-yyyy"
        Me.dtpInstantie.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstantie.Location = New System.Drawing.Point(56, 63)
        Me.dtpInstantie.Name = "dtpInstantie"
        Me.dtpInstantie.Size = New System.Drawing.Size(121, 20)
        Me.dtpInstantie.TabIndex = 106
        Me.dtpInstantie.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(8, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 107
        Me.Label34.Text = "Sinds:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(8, 101)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(34, 13)
        Me.Label33.TabIndex = 105
        Me.Label33.Text = "Vorig:"
        '
        'cmbContrInstanties
        '
        Me.cmbContrInstanties.FormattingEnabled = True
        Me.cmbContrInstanties.Location = New System.Drawing.Point(54, 26)
        Me.cmbContrInstanties.Name = "cmbContrInstanties"
        Me.cmbContrInstanties.Size = New System.Drawing.Size(123, 21)
        Me.cmbContrInstanties.TabIndex = 104
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(8, 29)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(40, 13)
        Me.Label31.TabIndex = 103
        Me.Label31.Text = "Huidig:"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 31)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Let op! Wijzigingen worden direct opgeslagen na bevestiging van dit scherm."
        '
        'dlgInstance
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(261, 269)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpInstantie)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgInstance"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Wijzig Instantie"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpInstantie.ResumeLayout(False)
        Me.grpInstantie.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents grpInstantie As System.Windows.Forms.GroupBox
    Friend WithEvents tbInstantieOud As System.Windows.Forms.TextBox
    Friend WithEvents dtpInstantie As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmbContrInstanties As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
