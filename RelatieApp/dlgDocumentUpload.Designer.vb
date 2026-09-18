<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDocumentUpload
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
        Me.cmbFases = New System.Windows.Forms.ComboBox()
        Me.lblFase = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbOnderwerp = New System.Windows.Forms.TextBox()
        Me.tbSelectedFile = New System.Windows.Forms.TextBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.ofFile = New System.Windows.Forms.OpenFileDialog()
        Me.chkConcept = New System.Windows.Forms.CheckBox()
        Me.btnHelp = New System.Windows.Forms.Button()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(353, 122)
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
        'cmbFases
        '
        Me.cmbFases.FormattingEnabled = True
        Me.cmbFases.Location = New System.Drawing.Point(112, 75)
        Me.cmbFases.Name = "cmbFases"
        Me.cmbFases.Size = New System.Drawing.Size(356, 21)
        Me.cmbFases.TabIndex = 109
        '
        'lblFase
        '
        Me.lblFase.AutoSize = True
        Me.lblFase.Location = New System.Drawing.Point(25, 80)
        Me.lblFase.Name = "lblFase"
        Me.lblFase.Size = New System.Drawing.Size(33, 13)
        Me.lblFase.TabIndex = 108
        Me.lblFase.Text = "Fase:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Bestand:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Onderwerp:"
        '
        'tbOnderwerp
        '
        Me.tbOnderwerp.Location = New System.Drawing.Point(112, 49)
        Me.tbOnderwerp.MaxLength = 100
        Me.tbOnderwerp.Name = "tbOnderwerp"
        Me.tbOnderwerp.Size = New System.Drawing.Size(356, 20)
        Me.tbOnderwerp.TabIndex = 105
        '
        'tbSelectedFile
        '
        Me.tbSelectedFile.Enabled = False
        Me.tbSelectedFile.Location = New System.Drawing.Point(112, 23)
        Me.tbSelectedFile.Name = "tbSelectedFile"
        Me.tbSelectedFile.Size = New System.Drawing.Size(260, 20)
        Me.tbSelectedFile.TabIndex = 104
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(378, 20)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(90, 23)
        Me.btnFile.TabIndex = 103
        Me.btnFile.Text = "Selecteer bestand"
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'chkConcept
        '
        Me.chkConcept.AutoSize = True
        Me.chkConcept.Location = New System.Drawing.Point(112, 102)
        Me.chkConcept.Name = "chkConcept"
        Me.chkConcept.Size = New System.Drawing.Size(66, 17)
        Me.chkConcept.TabIndex = 110
        Me.chkConcept.Text = "Concept"
        Me.chkConcept.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.RelatieApp.My.Resources.Resource1.Question321
        Me.btnHelp.Location = New System.Drawing.Point(472, -5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 41)
        Me.btnHelp.TabIndex = 247
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'dlgDocumentUpload
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(511, 163)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.chkConcept)
        Me.Controls.Add(Me.cmbFases)
        Me.Controls.Add(Me.lblFase)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbOnderwerp)
        Me.Controls.Add(Me.tbSelectedFile)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgDocumentUpload"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document toevoegen."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cmbFases As System.Windows.Forms.ComboBox
    Friend WithEvents lblFase As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbOnderwerp As System.Windows.Forms.TextBox
    Friend WithEvents tbSelectedFile As System.Windows.Forms.TextBox
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents ofFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkConcept As System.Windows.Forms.CheckBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button

End Class
