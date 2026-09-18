<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgJdTypeOnbudsman
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
        Me.tbOpmerkingen2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.tbHoorzitting = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOutlookHoorzitting = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnOutlookReactietermijn = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbAfwachting = New System.Windows.Forms.RadioButton()
        Me.rbDeelOngegrond = New System.Windows.Forms.RadioButton()
        Me.rbOnGegrond = New System.Windows.Forms.RadioButton()
        Me.rbGegrond = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnIndienDatum = New System.Windows.Forms.Button()
        Me.uctdReactieOordeel = New RelatieApp.ucTextDate()
        Me.UctdReactietermijn = New RelatieApp.ucTextDate()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(326, 396)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 13
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
        'tbOpmerkingen2
        '
        Me.tbOpmerkingen2.Location = New System.Drawing.Point(28, 268)
        Me.tbOpmerkingen2.MaxLength = 255
        Me.tbOpmerkingen2.Multiline = True
        Me.tbOpmerkingen2.Name = "tbOpmerkingen2"
        Me.tbOpmerkingen2.Size = New System.Drawing.Size(440, 99)
        Me.tbOpmerkingen2.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = "Omschrijving "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Indiendatum"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(29, 7)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 16)
        Me.lblError.TabIndex = 215
        '
        'tbHoorzitting
        '
        Me.tbHoorzitting.Location = New System.Drawing.Point(134, 61)
        Me.tbHoorzitting.MaxLength = 255
        Me.tbHoorzitting.Multiline = True
        Me.tbHoorzitting.Name = "tbHoorzitting"
        Me.tbHoorzitting.Size = New System.Drawing.Size(334, 50)
        Me.tbHoorzitting.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 224
        Me.Label7.Text = "Hoorzitting"
        '
        'btnOutlookHoorzitting
        '
        Me.btnOutlookHoorzitting.Location = New System.Drawing.Point(265, 119)
        Me.btnOutlookHoorzitting.Name = "btnOutlookHoorzitting"
        Me.btnOutlookHoorzitting.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookHoorzitting.TabIndex = 4
        Me.btnOutlookHoorzitting.Text = "naar agenda"
        Me.btnOutlookHoorzitting.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 238
        Me.Label8.Text = "Hoorzitting datum"
        '
        'btnOutlookReactietermijn
        '
        Me.btnOutlookReactietermijn.Location = New System.Drawing.Point(265, 152)
        Me.btnOutlookReactietermijn.Name = "btnOutlookReactietermijn"
        Me.btnOutlookReactietermijn.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookReactietermijn.TabIndex = 6
        Me.btnOutlookReactietermijn.Text = "naar agenda"
        Me.btnOutlookReactietermijn.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(27, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 241
        Me.Label11.Text = "Reactietermijn"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 188)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 244
        Me.Label12.Text = "Oordeel"
        '
        'rbAfwachting
        '
        Me.rbAfwachting.Location = New System.Drawing.Point(382, 223)
        Me.rbAfwachting.Name = "rbAfwachting"
        Me.rbAfwachting.Size = New System.Drawing.Size(78, 17)
        Me.rbAfwachting.TabIndex = 11
        Me.rbAfwachting.Tag = "0"
        Me.rbAfwachting.Text = "Afwachting"
        Me.rbAfwachting.UseVisualStyleBackColor = True
        '
        'rbDeelOngegrond
        '
        Me.rbDeelOngegrond.Location = New System.Drawing.Point(152, 223)
        Me.rbDeelOngegrond.Name = "rbDeelOngegrond"
        Me.rbDeelOngegrond.Size = New System.Drawing.Size(140, 17)
        Me.rbDeelOngegrond.TabIndex = 9
        Me.rbDeelOngegrond.Tag = "2"
        Me.rbDeelOngegrond.Text = "Gedeeltelijk ongegrond"
        Me.rbDeelOngegrond.UseVisualStyleBackColor = True
        '
        'rbOnGegrond
        '
        Me.rbOnGegrond.Location = New System.Drawing.Point(298, 223)
        Me.rbOnGegrond.Name = "rbOnGegrond"
        Me.rbOnGegrond.Size = New System.Drawing.Size(78, 17)
        Me.rbOnGegrond.TabIndex = 10
        Me.rbOnGegrond.Tag = "3"
        Me.rbOnGegrond.Text = "Ongegrond"
        Me.rbOnGegrond.UseVisualStyleBackColor = True
        '
        'rbGegrond
        '
        Me.rbGegrond.Location = New System.Drawing.Point(80, 223)
        Me.rbGegrond.Name = "rbGegrond"
        Me.rbGegrond.Size = New System.Drawing.Size(66, 17)
        Me.rbGegrond.TabIndex = 8
        Me.rbGegrond.Tag = "1"
        Me.rbGegrond.Text = "Gegrond"
        Me.rbGegrond.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Reactie "
        '
        'btnIndienDatum
        '
        Me.btnIndienDatum.Location = New System.Drawing.Point(265, 32)
        Me.btnIndienDatum.Name = "btnIndienDatum"
        Me.btnIndienDatum.Size = New System.Drawing.Size(75, 23)
        Me.btnIndienDatum.TabIndex = 1
        Me.btnIndienDatum.Text = "naar agenda"
        Me.btnIndienDatum.UseVisualStyleBackColor = True
        '
        'uctdReactieOordeel
        '
        Me.uctdReactieOordeel.Location = New System.Drawing.Point(134, 181)
        Me.uctdReactieOordeel.Name = "uctdReactieOordeel"
        Me.uctdReactieOordeel.Size = New System.Drawing.Size(137, 27)
        Me.uctdReactieOordeel.TabIndex = 7
        Me.uctdReactieOordeel.Value = ""
        '
        'UctdReactietermijn
        '
        Me.UctdReactietermijn.Location = New System.Drawing.Point(134, 150)
        Me.UctdReactietermijn.Name = "UctdReactietermijn"
        Me.UctdReactietermijn.Size = New System.Drawing.Size(137, 27)
        Me.UctdReactietermijn.TabIndex = 5
        Me.UctdReactietermijn.Value = ""
        '
        'uctdHoorzitting
        '
        Me.uctdHoorzitting.Location = New System.Drawing.Point(134, 117)
        Me.uctdHoorzitting.Name = "uctdHoorzitting"
        Me.uctdHoorzitting.Size = New System.Drawing.Size(137, 27)
        Me.uctdHoorzitting.TabIndex = 3
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
        Me.btnHelp.Location = New System.Drawing.Point(445, -5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 41)
        Me.btnHelp.TabIndex = 246
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'dlgJdTypeOnbudsman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 437)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnIndienDatum)
        Me.Controls.Add(Me.rbAfwachting)
        Me.Controls.Add(Me.rbDeelOngegrond)
        Me.Controls.Add(Me.rbOnGegrond)
        Me.Controls.Add(Me.rbGegrond)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.uctdReactieOordeel)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnOutlookReactietermijn)
        Me.Controls.Add(Me.UctdReactietermijn)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnOutlookHoorzitting)
        Me.Controls.Add(Me.uctdHoorzitting)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbHoorzitting)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.uctdIndienDatum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbOpmerkingen2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "dlgJdTypeOnbudsman"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nationale ombudsman"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents tbOpmerkingen2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents uctdIndienDatum As RelatieApp.ucTextDate
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents tbHoorzitting As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOutlookHoorzitting As System.Windows.Forms.Button
    Friend WithEvents uctdHoorzitting As RelatieApp.ucTextDate
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnOutlookReactietermijn As System.Windows.Forms.Button
    Friend WithEvents UctdReactietermijn As RelatieApp.ucTextDate
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents uctdReactieOordeel As RelatieApp.ucTextDate
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbAfwachting As System.Windows.Forms.RadioButton
    Friend WithEvents rbDeelOngegrond As System.Windows.Forms.RadioButton
    Friend WithEvents rbOnGegrond As System.Windows.Forms.RadioButton
    Friend WithEvents rbGegrond As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnIndienDatum As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
