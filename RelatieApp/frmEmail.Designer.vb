<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmail
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
        Me.tbFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbTo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbCC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbSubject = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbAtt = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.rtbBody = New System.Windows.Forms.RichTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.btnAtt = New System.Windows.Forms.Button()
        Me.btnAttClear = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkOutlookUser = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.chkHTML = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbFrom
        '
        Me.tbFrom.Location = New System.Drawing.Point(122, 34)
        Me.tbFrom.Name = "tbFrom"
        Me.tbFrom.Size = New System.Drawing.Size(280, 20)
        Me.tbFrom.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Van"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Aan"
        '
        'tbTo
        '
        Me.tbTo.Location = New System.Drawing.Point(122, 60)
        Me.tbTo.Name = "tbTo"
        Me.tbTo.Size = New System.Drawing.Size(280, 20)
        Me.tbTo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Kopie"
        '
        'tbCC
        '
        Me.tbCC.Location = New System.Drawing.Point(122, 86)
        Me.tbCC.Name = "tbCC"
        Me.tbCC.Size = New System.Drawing.Size(280, 20)
        Me.tbCC.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Onderwerp"
        '
        'tbSubject
        '
        Me.tbSubject.Location = New System.Drawing.Point(122, 112)
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Size = New System.Drawing.Size(586, 20)
        Me.tbSubject.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Bijlage"
        '
        'tbAtt
        '
        Me.tbAtt.BackColor = System.Drawing.SystemColors.Window
        Me.tbAtt.Location = New System.Drawing.Point(122, 151)
        Me.tbAtt.Name = "tbAtt"
        Me.tbAtt.ReadOnly = True
        Me.tbAtt.Size = New System.Drawing.Size(280, 20)
        Me.tbAtt.TabIndex = 8
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 211)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(984, 551)
        Me.TabControl1.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.rtbBody)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(976, 525)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Text"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'rtbBody
        '
        Me.rtbBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbBody.Location = New System.Drawing.Point(3, 3)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.Size = New System.Drawing.Size(970, 519)
        Me.rtbBody.TabIndex = 0
        Me.rtbBody.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.WebBrowser1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(976, 525)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "HTML"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(970, 519)
        Me.WebBrowser1.TabIndex = 0
        '
        'btnAtt
        '
        Me.btnAtt.Location = New System.Drawing.Point(408, 149)
        Me.btnAtt.Name = "btnAtt"
        Me.btnAtt.Size = New System.Drawing.Size(75, 23)
        Me.btnAtt.TabIndex = 13
        Me.btnAtt.Text = "Toevoegen"
        Me.btnAtt.UseVisualStyleBackColor = True
        '
        'btnAttClear
        '
        Me.btnAttClear.Location = New System.Drawing.Point(489, 149)
        Me.btnAttClear.Name = "btnAttClear"
        Me.btnAttClear.Size = New System.Drawing.Size(75, 23)
        Me.btnAttClear.TabIndex = 14
        Me.btnAttClear.Text = "Leeg"
        Me.btnAttClear.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSend.Location = New System.Drawing.Point(845, 37)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(113, 23)
        Me.btnSend.TabIndex = 15
        Me.btnSend.Text = "Verzenden"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(845, 66)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(113, 23)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Annuleren"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkOutlookUser
        '
        Me.chkOutlookUser.AutoSize = True
        Me.chkOutlookUser.Location = New System.Drawing.Point(408, 37)
        Me.chkOutlookUser.Name = "chkOutlookUser"
        Me.chkOutlookUser.Size = New System.Drawing.Size(146, 17)
        Me.chkOutlookUser.TabIndex = 17
        Me.chkOutlookUser.Text = "gebruik outlook gebruiker"
        Me.chkOutlookUser.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'chkHTML
        '
        Me.chkHTML.AutoSize = True
        Me.chkHTML.Location = New System.Drawing.Point(12, 188)
        Me.chkHTML.Name = "chkHTML"
        Me.chkHTML.Size = New System.Drawing.Size(56, 17)
        Me.chkHTML.TabIndex = 1
        Me.chkHTML.Text = "HTML"
        Me.chkHTML.UseVisualStyleBackColor = True
        '
        'frmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 762)
        Me.Controls.Add(Me.chkHTML)
        Me.Controls.Add(Me.chkOutlookUser)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.btnAttClear)
        Me.Controls.Add(Me.btnAtt)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbAtt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbSubject)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbCC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbFrom)
        Me.Name = "frmEmail"
        Me.Text = "Email"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbTo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbCC As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbAtt As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents rtbBody As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents btnAtt As System.Windows.Forms.Button
    Friend WithEvents btnAttClear As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkOutlookUser As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkHTML As System.Windows.Forms.CheckBox
End Class
