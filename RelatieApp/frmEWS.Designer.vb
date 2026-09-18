<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEWS
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lvItems = New System.Windows.Forms.ListView()
        Me.wbMessage = New System.Windows.Forms.WebBrowser()
        Me.tbTo = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnMailer = New System.Windows.Forms.Button()
        Me.chkUseSystemSetting = New System.Windows.Forms.CheckBox()
        Me.tvFolders = New System.Windows.Forms.TreeView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "laden maar "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lvItems
        '
        Me.lvItems.HideSelection = False
        Me.lvItems.Location = New System.Drawing.Point(235, 74)
        Me.lvItems.Name = "lvItems"
        Me.lvItems.Size = New System.Drawing.Size(562, 325)
        Me.lvItems.TabIndex = 1
        Me.lvItems.UseCompatibleStateImageBehavior = False
        '
        'wbMessage
        '
        Me.wbMessage.Location = New System.Drawing.Point(12, 443)
        Me.wbMessage.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMessage.Name = "wbMessage"
        Me.wbMessage.Size = New System.Drawing.Size(785, 270)
        Me.wbMessage.TabIndex = 3
        '
        'tbTo
        '
        Me.tbTo.Location = New System.Drawing.Point(413, 22)
        Me.tbTo.Name = "tbTo"
        Me.tbTo.Size = New System.Drawing.Size(213, 20)
        Me.tbTo.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(632, 22)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "send ews"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnMailer
        '
        Me.btnMailer.Location = New System.Drawing.Point(713, 22)
        Me.btnMailer.Name = "btnMailer"
        Me.btnMailer.Size = New System.Drawing.Size(75, 23)
        Me.btnMailer.TabIndex = 6
        Me.btnMailer.Text = "send smtp"
        Me.btnMailer.UseVisualStyleBackColor = True
        '
        'chkUseSystemSetting
        '
        Me.chkUseSystemSetting.AutoSize = True
        Me.chkUseSystemSetting.Location = New System.Drawing.Point(268, 24)
        Me.chkUseSystemSetting.Name = "chkUseSystemSetting"
        Me.chkUseSystemSetting.Size = New System.Drawing.Size(139, 17)
        Me.chkUseSystemSetting.TabIndex = 7
        Me.chkUseSystemSetting.Text = "systeemsetting afzender"
        Me.chkUseSystemSetting.UseVisualStyleBackColor = True
        '
        'tvFolders
        '
        Me.tvFolders.Location = New System.Drawing.Point(12, 74)
        Me.tvFolders.Name = "tvFolders"
        Me.tvFolders.Size = New System.Drawing.Size(197, 325)
        Me.tvFolders.TabIndex = 8
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(120, 22)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmEWS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 759)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.tvFolders)
        Me.Controls.Add(Me.chkUseSystemSetting)
        Me.Controls.Add(Me.btnMailer)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.tbTo)
        Me.Controls.Add(Me.wbMessage)
        Me.Controls.Add(Me.lvItems)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmEWS"
        Me.Text = "frmEWS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lvItems As System.Windows.Forms.ListView
    Friend WithEvents wbMessage As System.Windows.Forms.WebBrowser
    Friend WithEvents tbTo As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnMailer As System.Windows.Forms.Button
    Friend WithEvents chkUseSystemSetting As System.Windows.Forms.CheckBox
    Friend WithEvents tvFolders As System.Windows.Forms.TreeView
    Friend WithEvents Button3 As Button
End Class
