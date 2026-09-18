<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgJdTypePetition
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbOpmerking = New System.Windows.Forms.TextBox()
        Me.rbAfgewezen = New System.Windows.Forms.RadioButton()
        Me.rbToegekend = New System.Windows.Forms.RadioButton()
        Me.btnOutlook = New System.Windows.Forms.Button()
        Me.rbAfwachting = New System.Windows.Forms.RadioButton()
        Me.tbWeken = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpInGebreke = New System.Windows.Forms.GroupBox()
        Me.tbInGebreke = New System.Windows.Forms.TextBox()
        Me.uctdInGebreke = New RelatieApp.ucTextDate()
        Me.chkIngebrekestelling = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.uctdBesluit = New RelatieApp.ucTextDate()
        Me.UctdEindeBeslisTermijn = New RelatieApp.ucTextDate()
        Me.uctdIndienDatum = New RelatieApp.ucTextDate()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkAanHouding = New System.Windows.Forms.CheckBox()
        Me.chkIntrekking = New System.Windows.Forms.CheckBox()
        Me.lblBezwaartermijn = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpInGebreke.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(331, 525)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 8
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
        Me.Label1.Location = New System.Drawing.Point(23, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Indiendatum"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Einde beslistermijn"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Besluit  "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Datum besluit"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 348)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Opmerkingen"
        '
        'tbOpmerking
        '
        Me.tbOpmerking.Location = New System.Drawing.Point(26, 363)
        Me.tbOpmerking.MaxLength = 255
        Me.tbOpmerking.Multiline = True
        Me.tbOpmerking.Name = "tbOpmerking"
        Me.tbOpmerking.Size = New System.Drawing.Size(440, 122)
        Me.tbOpmerking.TabIndex = 7
        '
        'rbAfgewezen
        '
        Me.rbAfgewezen.AutoSize = True
        Me.rbAfgewezen.Location = New System.Drawing.Point(131, 121)
        Me.rbAfgewezen.Name = "rbAfgewezen"
        Me.rbAfgewezen.Size = New System.Drawing.Size(80, 17)
        Me.rbAfgewezen.TabIndex = 3
        Me.rbAfgewezen.TabStop = True
        Me.rbAfgewezen.Text = "afgewezen "
        Me.rbAfgewezen.UseVisualStyleBackColor = True
        '
        'rbToegekend
        '
        Me.rbToegekend.AutoSize = True
        Me.rbToegekend.Location = New System.Drawing.Point(227, 121)
        Me.rbToegekend.Name = "rbToegekend"
        Me.rbToegekend.Size = New System.Drawing.Size(76, 17)
        Me.rbToegekend.TabIndex = 4
        Me.rbToegekend.TabStop = True
        Me.rbToegekend.Text = "toegekend"
        Me.rbToegekend.UseVisualStyleBackColor = True
        '
        'btnOutlook
        '
        Me.btnOutlook.Location = New System.Drawing.Point(325, 152)
        Me.btnOutlook.Name = "btnOutlook"
        Me.btnOutlook.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlook.TabIndex = 8
        Me.btnOutlook.Text = "naar agenda"
        Me.btnOutlook.UseVisualStyleBackColor = True
        '
        'rbAfwachting
        '
        Me.rbAfwachting.AutoSize = True
        Me.rbAfwachting.Location = New System.Drawing.Point(325, 121)
        Me.rbAfwachting.Name = "rbAfwachting"
        Me.rbAfwachting.Size = New System.Drawing.Size(77, 17)
        Me.rbAfwachting.TabIndex = 5
        Me.rbAfwachting.TabStop = True
        Me.rbAfwachting.Text = "afwachting"
        Me.rbAfwachting.UseVisualStyleBackColor = True
        '
        'tbWeken
        '
        Me.tbWeken.Location = New System.Drawing.Point(275, 86)
        Me.tbWeken.MaxLength = 2
        Me.tbWeken.Name = "tbWeken"
        Me.tbWeken.Size = New System.Drawing.Size(49, 20)
        Me.tbWeken.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(330, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Aantal weken"
        '
        'grpInGebreke
        '
        Me.grpInGebreke.Controls.Add(Me.tbInGebreke)
        Me.grpInGebreke.Controls.Add(Me.uctdInGebreke)
        Me.grpInGebreke.Location = New System.Drawing.Point(24, 242)
        Me.grpInGebreke.Name = "grpInGebreke"
        Me.grpInGebreke.Size = New System.Drawing.Size(439, 103)
        Me.grpInGebreke.TabIndex = 204
        Me.grpInGebreke.TabStop = False
        Me.grpInGebreke.Text = "Beslissing op ingebrekestelling "
        '
        'tbInGebreke
        '
        Me.tbInGebreke.Enabled = False
        Me.tbInGebreke.Location = New System.Drawing.Point(21, 52)
        Me.tbInGebreke.Multiline = True
        Me.tbInGebreke.Name = "tbInGebreke"
        Me.tbInGebreke.Size = New System.Drawing.Size(412, 40)
        Me.tbInGebreke.TabIndex = 206
        '
        'uctdInGebreke
        '
        Me.uctdInGebreke.Enabled = False
        Me.uctdInGebreke.Location = New System.Drawing.Point(21, 19)
        Me.uctdInGebreke.Name = "uctdInGebreke"
        Me.uctdInGebreke.Size = New System.Drawing.Size(137, 27)
        Me.uctdInGebreke.TabIndex = 204
        Me.uctdInGebreke.Value = ""
        '
        'chkIngebrekestelling
        '
        Me.chkIngebrekestelling.AutoSize = True
        Me.chkIngebrekestelling.Location = New System.Drawing.Point(130, 212)
        Me.chkIngebrekestelling.Name = "chkIngebrekestelling"
        Me.chkIngebrekestelling.Size = New System.Drawing.Size(15, 14)
        Me.chkIngebrekestelling.TabIndex = 201
        Me.chkIngebrekestelling.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 202
        Me.Label7.Text = "Ingebrekestelling"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(29, 7)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 16)
        Me.lblError.TabIndex = 205
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.RelatieApp.My.Resources.Resource1.Question321
        Me.btnHelp.Location = New System.Drawing.Point(451, -4)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 41)
        Me.btnHelp.TabIndex = 247
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'uctdBesluit
        '
        Me.uctdBesluit.Location = New System.Drawing.Point(131, 152)
        Me.uctdBesluit.Name = "uctdBesluit"
        Me.uctdBesluit.Size = New System.Drawing.Size(137, 27)
        Me.uctdBesluit.TabIndex = 6
        Me.uctdBesluit.Value = ""
        '
        'UctdEindeBeslisTermijn
        '
        Me.UctdEindeBeslisTermijn.Location = New System.Drawing.Point(132, 82)
        Me.UctdEindeBeslisTermijn.Name = "UctdEindeBeslisTermijn"
        Me.UctdEindeBeslisTermijn.Size = New System.Drawing.Size(137, 27)
        Me.UctdEindeBeslisTermijn.TabIndex = 1
        Me.UctdEindeBeslisTermijn.Value = ""
        '
        'uctdIndienDatum
        '
        Me.uctdIndienDatum.Location = New System.Drawing.Point(132, 30)
        Me.uctdIndienDatum.Name = "uctdIndienDatum"
        Me.uctdIndienDatum.Size = New System.Drawing.Size(137, 27)
        Me.uctdIndienDatum.TabIndex = 0
        Me.uctdIndienDatum.Value = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 249
        Me.Label8.Text = "Aanhouding verzoek "
        '
        'chkAanHouding
        '
        Me.chkAanHouding.AutoSize = True
        Me.chkAanHouding.Location = New System.Drawing.Point(132, 64)
        Me.chkAanHouding.Name = "chkAanHouding"
        Me.chkAanHouding.Size = New System.Drawing.Size(15, 14)
        Me.chkAanHouding.TabIndex = 248
        Me.chkAanHouding.UseVisualStyleBackColor = True
        '
        'chkIntrekking
        '
        Me.chkIntrekking.AutoSize = True
        Me.chkIntrekking.ForeColor = System.Drawing.Color.Red
        Me.chkIntrekking.Location = New System.Drawing.Point(275, 36)
        Me.chkIntrekking.Name = "chkIntrekking"
        Me.chkIntrekking.Size = New System.Drawing.Size(73, 17)
        Me.chkIntrekking.TabIndex = 250
        Me.chkIntrekking.Text = "Intrekking"
        Me.chkIntrekking.UseVisualStyleBackColor = True
        Me.chkIntrekking.Visible = False
        '
        'lblBezwaartermijn
        '
        Me.lblBezwaartermijn.AutoSize = True
        Me.lblBezwaartermijn.ForeColor = System.Drawing.Color.Red
        Me.lblBezwaartermijn.Location = New System.Drawing.Point(131, 182)
        Me.lblBezwaartermijn.Name = "lblBezwaartermijn"
        Me.lblBezwaartermijn.Size = New System.Drawing.Size(0, 13)
        Me.lblBezwaartermijn.TabIndex = 251
        '
        'dlgJdTypePetition
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(489, 566)
        Me.Controls.Add(Me.lblBezwaartermijn)
        Me.Controls.Add(Me.chkIntrekking)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkAanHouding)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.grpInGebreke)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkIngebrekestelling)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbWeken)
        Me.Controls.Add(Me.rbAfwachting)
        Me.Controls.Add(Me.btnOutlook)
        Me.Controls.Add(Me.uctdBesluit)
        Me.Controls.Add(Me.rbToegekend)
        Me.Controls.Add(Me.rbAfgewezen)
        Me.Controls.Add(Me.UctdEindeBeslisTermijn)
        Me.Controls.Add(Me.uctdIndienDatum)
        Me.Controls.Add(Me.tbOpmerking)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgJdTypePetition"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Verzoek"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpInGebreke.ResumeLayout(False)
        Me.grpInGebreke.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbOpmerking As System.Windows.Forms.TextBox
    Friend WithEvents uctdIndienDatum As RelatieApp.ucTextDate
    Friend WithEvents UctdEindeBeslisTermijn As RelatieApp.ucTextDate
    Friend WithEvents rbAfgewezen As System.Windows.Forms.RadioButton
    Friend WithEvents rbToegekend As System.Windows.Forms.RadioButton
    Friend WithEvents uctdBesluit As RelatieApp.ucTextDate
    Friend WithEvents btnOutlook As System.Windows.Forms.Button
    Friend WithEvents rbAfwachting As System.Windows.Forms.RadioButton
    Friend WithEvents tbWeken As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpInGebreke As System.Windows.Forms.GroupBox
    Friend WithEvents tbInGebreke As System.Windows.Forms.TextBox
    Friend WithEvents uctdInGebreke As RelatieApp.ucTextDate
    Friend WithEvents chkIngebrekestelling As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkAanHouding As System.Windows.Forms.CheckBox
    Friend WithEvents chkIntrekking As CheckBox
    Friend WithEvents lblBezwaartermijn As Label
End Class
