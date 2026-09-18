<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgJdTypeVnV
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbWeken = New System.Windows.Forms.TextBox()
        Me.uctdBesluit = New RelatieApp.ucTextDate()
        Me.UctdGebrekestelling = New RelatieApp.ucTextDate()
        Me.uctdIndienDatum = New RelatieApp.ucTextDate()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbChoice = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbAfwachting = New System.Windows.Forms.RadioButton()
        Me.rbToegekend = New System.Windows.Forms.RadioButton()
        Me.rbAfgewezen = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnOutlookReactie = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnOutlookHoorzitting = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.uctdHoorzitting = New RelatieApp.ucTextDate()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(331, 246)
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(396, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "Aantal weken"
        '
        'tbWeken
        '
        Me.tbWeken.Location = New System.Drawing.Point(362, 124)
        Me.tbWeken.MaxLength = 2
        Me.tbWeken.Name = "tbWeken"
        Me.tbWeken.Size = New System.Drawing.Size(28, 20)
        Me.tbWeken.TabIndex = 203
        '
        'uctdBesluit
        '
        Me.uctdBesluit.Location = New System.Drawing.Point(144, 192)
        Me.uctdBesluit.Name = "uctdBesluit"
        Me.uctdBesluit.Size = New System.Drawing.Size(137, 27)
        Me.uctdBesluit.TabIndex = 204
        Me.uctdBesluit.Value = ""
        '
        'UctdGebrekestelling
        '
        Me.UctdGebrekestelling.Location = New System.Drawing.Point(145, 120)
        Me.UctdGebrekestelling.Name = "UctdGebrekestelling"
        Me.UctdGebrekestelling.Size = New System.Drawing.Size(137, 27)
        Me.UctdGebrekestelling.TabIndex = 202
        Me.UctdGebrekestelling.Value = ""
        '
        'uctdIndienDatum
        '
        Me.uctdIndienDatum.Location = New System.Drawing.Point(143, 28)
        Me.uctdIndienDatum.Name = "uctdIndienDatum"
        Me.uctdIndienDatum.Size = New System.Drawing.Size(137, 27)
        Me.uctdIndienDatum.TabIndex = 201
        Me.uctdIndienDatum.Value = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "Datum besluit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Reactietermijn"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Datum voornemen"
        '
        'cmbChoice
        '
        Me.cmbChoice.FormattingEnabled = True
        Me.cmbChoice.Location = New System.Drawing.Point(143, 64)
        Me.cmbChoice.Name = "cmbChoice"
        Me.cmbChoice.Size = New System.Drawing.Size(271, 21)
        Me.cmbChoice.TabIndex = 209
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 210
        Me.Label3.Text = "Keuzelijst "
        '
        'rbAfwachting
        '
        Me.rbAfwachting.AutoSize = True
        Me.rbAfwachting.Location = New System.Drawing.Point(338, 160)
        Me.rbAfwachting.Name = "rbAfwachting"
        Me.rbAfwachting.Size = New System.Drawing.Size(77, 17)
        Me.rbAfwachting.TabIndex = 213
        Me.rbAfwachting.TabStop = True
        Me.rbAfwachting.Text = "afwachting"
        Me.rbAfwachting.UseVisualStyleBackColor = True
        '
        'rbToegekend
        '
        Me.rbToegekend.AutoSize = True
        Me.rbToegekend.Location = New System.Drawing.Point(240, 160)
        Me.rbToegekend.Name = "rbToegekend"
        Me.rbToegekend.Size = New System.Drawing.Size(76, 17)
        Me.rbToegekend.TabIndex = 212
        Me.rbToegekend.TabStop = True
        Me.rbToegekend.Text = "toegekend"
        Me.rbToegekend.UseVisualStyleBackColor = True
        '
        'rbAfgewezen
        '
        Me.rbAfgewezen.AutoSize = True
        Me.rbAfgewezen.Location = New System.Drawing.Point(144, 160)
        Me.rbAfgewezen.Name = "rbAfgewezen"
        Me.rbAfgewezen.Size = New System.Drawing.Size(80, 17)
        Me.rbAfgewezen.TabIndex = 211
        Me.rbAfgewezen.TabStop = True
        Me.rbAfgewezen.Text = "afgewezen "
        Me.rbAfgewezen.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 214
        Me.Label5.Text = "Besluit  "
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(34, 9)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 16)
        Me.lblError.TabIndex = 215
        '
        'btnOutlookReactie
        '
        Me.btnOutlookReactie.Location = New System.Drawing.Point(274, 122)
        Me.btnOutlookReactie.Name = "btnOutlookReactie"
        Me.btnOutlookReactie.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookReactie.TabIndex = 216
        Me.btnOutlookReactie.Text = "naar agenda"
        Me.ToolTip1.SetToolTip(Me.btnOutlookReactie, "Zet in Outlook agenda")
        Me.btnOutlookReactie.UseVisualStyleBackColor = True
        '
        'btnOutlookHoorzitting
        '
        Me.btnOutlookHoorzitting.Location = New System.Drawing.Point(274, 91)
        Me.btnOutlookHoorzitting.Name = "btnOutlookHoorzitting"
        Me.btnOutlookHoorzitting.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookHoorzitting.TabIndex = 230
        Me.btnOutlookHoorzitting.Text = "naar agenda"
        Me.btnOutlookHoorzitting.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(34, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 13)
        Me.Label17.TabIndex = 229
        Me.Label17.Text = "Hoorzitting"
        '
        'uctdHoorzitting
        '
        Me.uctdHoorzitting.Location = New System.Drawing.Point(144, 89)
        Me.uctdHoorzitting.Name = "uctdHoorzitting"
        Me.uctdHoorzitting.Size = New System.Drawing.Size(137, 27)
        Me.uctdHoorzitting.TabIndex = 228
        Me.uctdHoorzitting.Value = ""
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.RelatieApp.My.Resources.Resource1.Question321
        Me.btnHelp.Location = New System.Drawing.Point(451, -6)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 41)
        Me.btnHelp.TabIndex = 247
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'dlgJdTypeVnV
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(489, 287)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnOutlookHoorzitting)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.uctdHoorzitting)
        Me.Controls.Add(Me.btnOutlookReactie)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.rbAfwachting)
        Me.Controls.Add(Me.rbToegekend)
        Me.Controls.Add(Me.rbAfgewezen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbChoice)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbWeken)
        Me.Controls.Add(Me.uctdBesluit)
        Me.Controls.Add(Me.UctdGebrekestelling)
        Me.Controls.Add(Me.uctdIndienDatum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgJdTypeVnV"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Voornemen"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbWeken As System.Windows.Forms.TextBox
    Friend WithEvents uctdBesluit As RelatieApp.ucTextDate
    Friend WithEvents UctdGebrekestelling As RelatieApp.ucTextDate
    Friend WithEvents uctdIndienDatum As RelatieApp.ucTextDate
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbChoice As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbAfwachting As System.Windows.Forms.RadioButton
    Friend WithEvents rbToegekend As System.Windows.Forms.RadioButton
    Friend WithEvents rbAfgewezen As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnOutlookReactie As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnOutlookHoorzitting As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents uctdHoorzitting As RelatieApp.ucTextDate
    Friend WithEvents btnHelp As System.Windows.Forms.Button

End Class
