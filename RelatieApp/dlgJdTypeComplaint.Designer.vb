<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgJdTypeComplaint
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
        Me.lblError = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbOpmerkingen2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbIndiener = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbOpmerkingen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbInstantie = New System.Windows.Forms.TextBox()
        Me.tbHoorzitting = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbAdvies = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rbDeelOngegrond = New System.Windows.Forms.RadioButton()
        Me.rbOnGegrond = New System.Windows.Forms.RadioButton()
        Me.rbGegrond = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnOutlookHoorzitting = New System.Windows.Forms.Button()
        Me.btnOutlookReactietermijn = New System.Windows.Forms.Button()
        Me.rbAfwachting = New System.Windows.Forms.RadioButton()
        Me.uctdReactieOordeel = New RelatieApp.ucTextDate()
        Me.UctdReactietermijn = New RelatieApp.ucTextDate()
        Me.uctdAdvies = New RelatieApp.ucTextDate()
        Me.uctdHoorzitting = New RelatieApp.ucTextDate()
        Me.uctdIndienDatum = New RelatieApp.ucTextDate()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(331, 574)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 17
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
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(29, 7)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 16)
        Me.lblError.TabIndex = 206
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 208
        Me.Label1.Text = "Indiendatum"
        '
        'tbOpmerkingen2
        '
        Me.tbOpmerkingen2.Location = New System.Drawing.Point(28, 469)
        Me.tbOpmerkingen2.MaxLength = 255
        Me.tbOpmerkingen2.Multiline = True
        Me.tbOpmerkingen2.Name = "tbOpmerkingen2"
        Me.tbOpmerkingen2.Size = New System.Drawing.Size(440, 99)
        Me.tbOpmerkingen2.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 453)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "Omschrijving "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 427)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 214
        Me.Label3.Text = "Reactie "
        '
        'tbIndiener
        '
        Me.tbIndiener.Location = New System.Drawing.Point(134, 62)
        Me.tbIndiener.Name = "tbIndiener"
        Me.tbIndiener.Size = New System.Drawing.Size(334, 20)
        Me.tbIndiener.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 216
        Me.Label2.Text = "Indiener"
        '
        'tbOpmerkingen
        '
        Me.tbOpmerkingen.Location = New System.Drawing.Point(134, 114)
        Me.tbOpmerkingen.MaxLength = 255
        Me.tbOpmerkingen.Multiline = True
        Me.tbOpmerkingen.Name = "tbOpmerkingen"
        Me.tbOpmerkingen.Size = New System.Drawing.Size(334, 50)
        Me.tbOpmerkingen.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 218
        Me.Label4.Text = "Omschrijving"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 220
        Me.Label6.Text = "Instantie"
        '
        'tbInstantie
        '
        Me.tbInstantie.Location = New System.Drawing.Point(134, 88)
        Me.tbInstantie.Name = "tbInstantie"
        Me.tbInstantie.Size = New System.Drawing.Size(334, 20)
        Me.tbInstantie.TabIndex = 2
        '
        'tbHoorzitting
        '
        Me.tbHoorzitting.Location = New System.Drawing.Point(134, 170)
        Me.tbHoorzitting.MaxLength = 255
        Me.tbHoorzitting.Multiline = True
        Me.tbHoorzitting.Name = "tbHoorzitting"
        Me.tbHoorzitting.Size = New System.Drawing.Size(334, 50)
        Me.tbHoorzitting.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 222
        Me.Label7.Text = "Hoorzitting"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 224
        Me.Label8.Text = "Hoorzitting datum"
        '
        'tbAdvies
        '
        Me.tbAdvies.Location = New System.Drawing.Point(134, 259)
        Me.tbAdvies.MaxLength = 255
        Me.tbAdvies.Multiline = True
        Me.tbAdvies.Name = "tbAdvies"
        Me.tbAdvies.Size = New System.Drawing.Size(334, 50)
        Me.tbAdvies.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 226
        Me.Label9.Text = "Advies"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 322)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 228
        Me.Label10.Text = "Advies datum"
        '
        'rbDeelOngegrond
        '
        Me.rbDeelOngegrond.Location = New System.Drawing.Point(152, 425)
        Me.rbDeelOngegrond.Name = "rbDeelOngegrond"
        Me.rbDeelOngegrond.Size = New System.Drawing.Size(140, 17)
        Me.rbDeelOngegrond.TabIndex = 13
        Me.rbDeelOngegrond.Tag = "2"
        Me.rbDeelOngegrond.Text = "Gedeeltelijk ongegrond"
        Me.rbDeelOngegrond.UseVisualStyleBackColor = True
        '
        'rbOnGegrond
        '
        Me.rbOnGegrond.Location = New System.Drawing.Point(298, 425)
        Me.rbOnGegrond.Name = "rbOnGegrond"
        Me.rbOnGegrond.Size = New System.Drawing.Size(78, 17)
        Me.rbOnGegrond.TabIndex = 14
        Me.rbOnGegrond.Tag = "3"
        Me.rbOnGegrond.Text = "Ongegrond"
        Me.rbOnGegrond.UseVisualStyleBackColor = True
        '
        'rbGegrond
        '
        Me.rbGegrond.Location = New System.Drawing.Point(80, 425)
        Me.rbGegrond.Name = "rbGegrond"
        Me.rbGegrond.Size = New System.Drawing.Size(66, 17)
        Me.rbGegrond.TabIndex = 12
        Me.rbGegrond.Tag = "1"
        Me.rbGegrond.Text = "Gegrond"
        Me.rbGegrond.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(27, 355)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 233
        Me.Label11.Text = "Reactietermijn"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 385)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 235
        Me.Label12.Text = "Oordeel"
        '
        'btnOutlookHoorzitting
        '
        Me.btnOutlookHoorzitting.Location = New System.Drawing.Point(265, 228)
        Me.btnOutlookHoorzitting.Name = "btnOutlookHoorzitting"
        Me.btnOutlookHoorzitting.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookHoorzitting.TabIndex = 6
        Me.btnOutlookHoorzitting.Text = "naar agenda"
        Me.btnOutlookHoorzitting.UseVisualStyleBackColor = True
        '
        'btnOutlookReactietermijn
        '
        Me.btnOutlookReactietermijn.Location = New System.Drawing.Point(265, 350)
        Me.btnOutlookReactietermijn.Name = "btnOutlookReactietermijn"
        Me.btnOutlookReactietermijn.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookReactietermijn.TabIndex = 10
        Me.btnOutlookReactietermijn.Text = "naar agenda"
        Me.btnOutlookReactietermijn.UseVisualStyleBackColor = True
        '
        'rbAfwachting
        '
        Me.rbAfwachting.Location = New System.Drawing.Point(382, 425)
        Me.rbAfwachting.Name = "rbAfwachting"
        Me.rbAfwachting.Size = New System.Drawing.Size(78, 17)
        Me.rbAfwachting.TabIndex = 15
        Me.rbAfwachting.Tag = "0"
        Me.rbAfwachting.Text = "Afwachting"
        Me.rbAfwachting.UseVisualStyleBackColor = True
        '
        'uctdReactieOordeel
        '
        Me.uctdReactieOordeel.Location = New System.Drawing.Point(134, 381)
        Me.uctdReactieOordeel.Name = "uctdReactieOordeel"
        Me.uctdReactieOordeel.Size = New System.Drawing.Size(137, 27)
        Me.uctdReactieOordeel.TabIndex = 11
        Me.uctdReactieOordeel.Value = ""
        '
        'UctdReactietermijn
        '
        Me.UctdReactietermijn.Location = New System.Drawing.Point(134, 348)
        Me.UctdReactietermijn.Name = "UctdReactietermijn"
        Me.UctdReactietermijn.Size = New System.Drawing.Size(137, 27)
        Me.UctdReactietermijn.TabIndex = 9
        Me.UctdReactietermijn.Value = ""
        '
        'uctdAdvies
        '
        Me.uctdAdvies.Location = New System.Drawing.Point(134, 315)
        Me.uctdAdvies.Name = "uctdAdvies"
        Me.uctdAdvies.Size = New System.Drawing.Size(137, 27)
        Me.uctdAdvies.TabIndex = 8
        Me.uctdAdvies.Value = ""
        '
        'uctdHoorzitting
        '
        Me.uctdHoorzitting.Location = New System.Drawing.Point(134, 226)
        Me.uctdHoorzitting.Name = "uctdHoorzitting"
        Me.uctdHoorzitting.Size = New System.Drawing.Size(137, 27)
        Me.uctdHoorzitting.TabIndex = 5
        Me.uctdHoorzitting.Value = ""
        '
        'uctdIndienDatum
        '
        Me.uctdIndienDatum.Location = New System.Drawing.Point(134, 28)
        Me.uctdIndienDatum.Name = "uctdIndienDatum"
        Me.uctdIndienDatum.Size = New System.Drawing.Size(137, 27)
        Me.uctdIndienDatum.TabIndex = 0
        Me.uctdIndienDatum.Value = ""
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.RelatieApp.My.Resources.Resource1.Question321
        Me.btnHelp.Location = New System.Drawing.Point(452, -4)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 41)
        Me.btnHelp.TabIndex = 236
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'dlgJdTypeComplaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 615)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.rbAfwachting)
        Me.Controls.Add(Me.btnOutlookReactietermijn)
        Me.Controls.Add(Me.btnOutlookHoorzitting)
        Me.Controls.Add(Me.uctdReactieOordeel)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.UctdReactietermijn)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.rbDeelOngegrond)
        Me.Controls.Add(Me.rbOnGegrond)
        Me.Controls.Add(Me.rbGegrond)
        Me.Controls.Add(Me.uctdAdvies)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tbAdvies)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.uctdHoorzitting)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbHoorzitting)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbInstantie)
        Me.Controls.Add(Me.tbOpmerkingen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbIndiener)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbOpmerkingen2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.uctdIndienDatum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "dlgJdTypeComplaint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Klacht"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents uctdIndienDatum As RelatieApp.ucTextDate
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbOpmerkingen2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbIndiener As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbOpmerkingen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbInstantie As System.Windows.Forms.TextBox
    Friend WithEvents tbHoorzitting As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents uctdHoorzitting As RelatieApp.ucTextDate
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbAdvies As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents uctdAdvies As RelatieApp.ucTextDate
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rbDeelOngegrond As System.Windows.Forms.RadioButton
    Friend WithEvents rbOnGegrond As System.Windows.Forms.RadioButton
    Friend WithEvents rbGegrond As System.Windows.Forms.RadioButton
    Friend WithEvents UctdReactietermijn As RelatieApp.ucTextDate
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents uctdReactieOordeel As RelatieApp.ucTextDate
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnOutlookHoorzitting As System.Windows.Forms.Button
    Friend WithEvents btnOutlookReactietermijn As System.Windows.Forms.Button
    Friend WithEvents rbAfwachting As System.Windows.Forms.RadioButton
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
