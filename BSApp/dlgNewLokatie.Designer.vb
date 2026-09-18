<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgNewlocatie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgNewlocatie))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tblocatie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkToegankelijk = New System.Windows.Forms.CheckBox()
        Me.tbAdres1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbAdres2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbStraat = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbPostcode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkCancel = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbPlaats = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbAdres3 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkNewLocation = New System.Windows.Forms.CheckBox()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(291, 303)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 9
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
        Me.Label1.Location = New System.Drawing.Point(30, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "locatie:"
        '
        'tblocatie
        '
        Me.tblocatie.Location = New System.Drawing.Point(124, 31)
        Me.tblocatie.Name = "tblocatie"
        Me.tblocatie.Size = New System.Drawing.Size(285, 20)
        Me.tblocatie.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Toegankelijk voor minder validen:"
        '
        'chkToegankelijk
        '
        Me.chkToegankelijk.AutoSize = True
        Me.chkToegankelijk.Location = New System.Drawing.Point(293, 63)
        Me.chkToegankelijk.Name = "chkToegankelijk"
        Me.chkToegankelijk.Size = New System.Drawing.Size(15, 14)
        Me.chkToegankelijk.TabIndex = 1
        Me.chkToegankelijk.UseVisualStyleBackColor = True
        '
        'tbAdres1
        '
        Me.tbAdres1.Location = New System.Drawing.Point(124, 83)
        Me.tbAdres1.Name = "tbAdres1"
        Me.tbAdres1.Size = New System.Drawing.Size(285, 20)
        Me.tbAdres1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Adres1:"
        '
        'tbAdres2
        '
        Me.tbAdres2.Location = New System.Drawing.Point(124, 109)
        Me.tbAdres2.Name = "tbAdres2"
        Me.tbAdres2.Size = New System.Drawing.Size(285, 20)
        Me.tbAdres2.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Adres2:"
        '
        'tbStraat
        '
        Me.tbStraat.Location = New System.Drawing.Point(124, 160)
        Me.tbStraat.Name = "tbStraat"
        Me.tbStraat.Size = New System.Drawing.Size(285, 20)
        Me.tbStraat.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Straat:"
        '
        'tbPostcode
        '
        Me.tbPostcode.Location = New System.Drawing.Point(124, 186)
        Me.tbPostcode.Name = "tbPostcode"
        Me.tbPostcode.Size = New System.Drawing.Size(285, 20)
        Me.tbPostcode.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Postcode:"
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.Location = New System.Drawing.Point(167, 240)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(15, 14)
        Me.chkCancel.TabIndex = 8
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(121, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Cancel"
        '
        'tbPlaats
        '
        Me.tbPlaats.Location = New System.Drawing.Point(124, 212)
        Me.tbPlaats.Name = "tbPlaats"
        Me.tbPlaats.Size = New System.Drawing.Size(285, 20)
        Me.tbPlaats.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Plaats:"
        '
        'tbAdres3
        '
        Me.tbAdres3.Location = New System.Drawing.Point(124, 135)
        Me.tbAdres3.Name = "tbAdres3"
        Me.tbAdres3.Size = New System.Drawing.Size(285, 20)
        Me.tbAdres3.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(30, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Adres3:"
        '
        'chkNewLocation
        '
        Me.chkNewLocation.AutoSize = True
        Me.chkNewLocation.CheckAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkNewLocation.Checked = True
        Me.chkNewLocation.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNewLocation.Location = New System.Drawing.Point(213, 240)
        Me.chkNewLocation.Name = "chkNewLocation"
        Me.chkNewLocation.Size = New System.Drawing.Size(96, 17)
        Me.chkNewLocation.TabIndex = 21
        Me.chkNewLocation.Text = "Nieuwe locatie"
        Me.chkNewLocation.UseVisualStyleBackColor = True
        '
        'dlgNewlocatie
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(449, 344)
        Me.Controls.Add(Me.chkNewLocation)
        Me.Controls.Add(Me.tbAdres3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbPlaats)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkCancel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbPostcode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbStraat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbAdres2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbAdres1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkToegankelijk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tblocatie)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgNewlocatie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "locatie:"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tblocatie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkToegankelijk As System.Windows.Forms.CheckBox
    Friend WithEvents tbAdres1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbAdres2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbStraat As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbPostcode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbPlaats As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbAdres3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkNewLocation As CheckBox
End Class
