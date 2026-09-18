<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgJdTypeClaim
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
        Me.lblBezwaartermijn = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkAanHouding = New System.Windows.Forms.CheckBox()
        Me.tbInGebreke = New System.Windows.Forms.TextBox()
        Me.uctdInGebreke = New RelatieApp.ucTextDate()
        Me.chkIntrekking = New System.Windows.Forms.CheckBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lblError = New System.Windows.Forms.Label()
        Me.grpInGebreke = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkIngebrekestelling = New System.Windows.Forms.CheckBox()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbWeken = New System.Windows.Forms.TextBox()
        Me.rbAfwachting = New System.Windows.Forms.RadioButton()
        Me.btnOutlook = New System.Windows.Forms.Button()
        Me.uctdBesluit = New RelatieApp.ucTextDate()
        Me.rbToegekend = New System.Windows.Forms.RadioButton()
        Me.rbAfgewezen = New System.Windows.Forms.RadioButton()
        Me.UctdEindeBeslisTermijn = New RelatieApp.ucTextDate()
        Me.uctdIndienDatum = New RelatieApp.ucTextDate()
        Me.tbOpmerking = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEindeBeslistermijn = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grpInGebreke.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBezwaartermijn
        '
        Me.lblBezwaartermijn.AutoSize = True
        Me.lblBezwaartermijn.ForeColor = System.Drawing.Color.Red
        Me.lblBezwaartermijn.Location = New System.Drawing.Point(118, 190)
        Me.lblBezwaartermijn.Name = "lblBezwaartermijn"
        Me.lblBezwaartermijn.Size = New System.Drawing.Size(0, 13)
        Me.lblBezwaartermijn.TabIndex = 276
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Aanhouding verzoek "
        '
        'chkAanHouding
        '
        Me.chkAanHouding.AutoSize = True
        Me.chkAanHouding.Location = New System.Drawing.Point(119, 72)
        Me.chkAanHouding.Name = "chkAanHouding"
        Me.chkAanHouding.Size = New System.Drawing.Size(15, 14)
        Me.chkAanHouding.TabIndex = 273
        Me.chkAanHouding.UseVisualStyleBackColor = True
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
        'chkIntrekking
        '
        Me.chkIntrekking.AutoSize = True
        Me.chkIntrekking.ForeColor = System.Drawing.Color.Red
        Me.chkIntrekking.Location = New System.Drawing.Point(262, 44)
        Me.chkIntrekking.Name = "chkIntrekking"
        Me.chkIntrekking.Size = New System.Drawing.Size(73, 17)
        Me.chkIntrekking.TabIndex = 275
        Me.chkIntrekking.Text = "Intrekking"
        Me.chkIntrekking.UseVisualStyleBackColor = True
        Me.chkIntrekking.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.RelatieApp.My.Resources.Resource1.Question321
        Me.btnHelp.Location = New System.Drawing.Point(438, 4)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 41)
        Me.btnHelp.TabIndex = 272
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(16, 15)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 16)
        Me.lblError.TabIndex = 271
        '
        'grpInGebreke
        '
        Me.grpInGebreke.Controls.Add(Me.tbInGebreke)
        Me.grpInGebreke.Controls.Add(Me.uctdInGebreke)
        Me.grpInGebreke.Location = New System.Drawing.Point(11, 250)
        Me.grpInGebreke.Name = "grpInGebreke"
        Me.grpInGebreke.Size = New System.Drawing.Size(439, 103)
        Me.grpInGebreke.TabIndex = 270
        Me.grpInGebreke.TabStop = False
        Me.grpInGebreke.Text = "Beslissing op ingebrekestelling "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 269
        Me.Label7.Text = "Ingebrekestelling"
        '
        'chkIngebrekestelling
        '
        Me.chkIngebrekestelling.AutoSize = True
        Me.chkIngebrekestelling.Location = New System.Drawing.Point(117, 220)
        Me.chkIngebrekestelling.Name = "chkIngebrekestelling"
        Me.chkIngebrekestelling.Size = New System.Drawing.Size(15, 14)
        Me.chkIngebrekestelling.TabIndex = 268
        Me.chkIngebrekestelling.UseVisualStyleBackColor = True
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
        Me.Label6.Location = New System.Drawing.Point(317, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Aantal weken"
        '
        'tbWeken
        '
        Me.tbWeken.Location = New System.Drawing.Point(262, 94)
        Me.tbWeken.MaxLength = 3
        Me.tbWeken.Name = "tbWeken"
        Me.tbWeken.Size = New System.Drawing.Size(49, 20)
        Me.tbWeken.TabIndex = 254
        '
        'rbAfwachting
        '
        Me.rbAfwachting.AutoSize = True
        Me.rbAfwachting.Location = New System.Drawing.Point(312, 129)
        Me.rbAfwachting.Name = "rbAfwachting"
        Me.rbAfwachting.Size = New System.Drawing.Size(77, 17)
        Me.rbAfwachting.TabIndex = 257
        Me.rbAfwachting.TabStop = True
        Me.rbAfwachting.Text = "afwachting"
        Me.rbAfwachting.UseVisualStyleBackColor = True
        '
        'btnOutlook
        '
        Me.btnOutlook.Location = New System.Drawing.Point(312, 160)
        Me.btnOutlook.Name = "btnOutlook"
        Me.btnOutlook.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlook.TabIndex = 260
        Me.btnOutlook.Text = "naar agenda"
        Me.btnOutlook.UseVisualStyleBackColor = True
        '
        'uctdBesluit
        '
        Me.uctdBesluit.Location = New System.Drawing.Point(118, 160)
        Me.uctdBesluit.Name = "uctdBesluit"
        Me.uctdBesluit.Size = New System.Drawing.Size(137, 27)
        Me.uctdBesluit.TabIndex = 258
        Me.uctdBesluit.Value = ""
        '
        'rbToegekend
        '
        Me.rbToegekend.AutoSize = True
        Me.rbToegekend.Location = New System.Drawing.Point(214, 129)
        Me.rbToegekend.Name = "rbToegekend"
        Me.rbToegekend.Size = New System.Drawing.Size(76, 17)
        Me.rbToegekend.TabIndex = 256
        Me.rbToegekend.TabStop = True
        Me.rbToegekend.Text = "toegekend"
        Me.rbToegekend.UseVisualStyleBackColor = True
        '
        'rbAfgewezen
        '
        Me.rbAfgewezen.AutoSize = True
        Me.rbAfgewezen.Location = New System.Drawing.Point(118, 129)
        Me.rbAfgewezen.Name = "rbAfgewezen"
        Me.rbAfgewezen.Size = New System.Drawing.Size(80, 17)
        Me.rbAfgewezen.TabIndex = 255
        Me.rbAfgewezen.TabStop = True
        Me.rbAfgewezen.Text = "afgewezen "
        Me.rbAfgewezen.UseVisualStyleBackColor = True
        '
        'UctdEindeBeslisTermijn
        '
        Me.UctdEindeBeslisTermijn.Location = New System.Drawing.Point(119, 90)
        Me.UctdEindeBeslisTermijn.Name = "UctdEindeBeslisTermijn"
        Me.UctdEindeBeslisTermijn.Size = New System.Drawing.Size(137, 27)
        Me.UctdEindeBeslisTermijn.TabIndex = 253
        Me.UctdEindeBeslisTermijn.Value = ""
        '
        'uctdIndienDatum
        '
        Me.uctdIndienDatum.Location = New System.Drawing.Point(119, 38)
        Me.uctdIndienDatum.Name = "uctdIndienDatum"
        Me.uctdIndienDatum.Size = New System.Drawing.Size(137, 27)
        Me.uctdIndienDatum.TabIndex = 252
        Me.uctdIndienDatum.Value = ""
        '
        'tbOpmerking
        '
        Me.tbOpmerking.Location = New System.Drawing.Point(13, 371)
        Me.tbOpmerking.MaxLength = 255
        Me.tbOpmerking.Multiline = True
        Me.tbOpmerking.Name = "tbOpmerking"
        Me.tbOpmerking.Size = New System.Drawing.Size(440, 122)
        Me.tbOpmerking.TabIndex = 259
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 356)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 266
        Me.Label5.Text = "Opmerkingen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 265
        Me.Label4.Text = "Datum besluit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Besluit  "
        '
        'lblEindeBeslistermijn
        '
        Me.lblEindeBeslistermijn.AutoSize = True
        Me.lblEindeBeslistermijn.Location = New System.Drawing.Point(10, 99)
        Me.lblEindeBeslistermijn.Name = "lblEindeBeslistermijn"
        Me.lblEindeBeslistermijn.Size = New System.Drawing.Size(93, 13)
        Me.lblEindeBeslistermijn.TabIndex = 267
        Me.lblEindeBeslistermijn.Text = "Einde beslistermijn"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 263
        Me.Label1.Text = "Indiendatum"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(318, 533)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 261
        '
        'dlgJdTypeClaim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 566)
        Me.Controls.Add(Me.lblBezwaartermijn)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkAanHouding)
        Me.Controls.Add(Me.chkIntrekking)
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
        Me.Controls.Add(Me.lblEindeBeslistermijn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "dlgJdTypeClaim"
        Me.Text = "Claim"
        Me.grpInGebreke.ResumeLayout(False)
        Me.grpInGebreke.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblBezwaartermijn As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chkAanHouding As CheckBox
    Friend WithEvents tbInGebreke As TextBox
    Friend WithEvents uctdInGebreke As ucTextDate
    Friend WithEvents chkIntrekking As CheckBox
    Friend WithEvents btnHelp As Button
    Friend WithEvents lblError As Label
    Friend WithEvents grpInGebreke As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chkIngebrekestelling As CheckBox
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents tbWeken As TextBox
    Friend WithEvents rbAfwachting As RadioButton
    Friend WithEvents btnOutlook As Button
    Friend WithEvents uctdBesluit As ucTextDate
    Friend WithEvents rbToegekend As RadioButton
    Friend WithEvents rbAfgewezen As RadioButton
    Friend WithEvents UctdEindeBeslisTermijn As ucTextDate
    Friend WithEvents uctdIndienDatum As ucTextDate
    Friend WithEvents tbOpmerking As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblEindeBeslistermijn As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class
