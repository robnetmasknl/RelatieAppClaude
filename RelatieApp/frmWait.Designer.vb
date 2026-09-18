<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWait
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWait))
        Me.lbMessage = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.pbTaskProgress = New System.Windows.Forms.ProgressBar()
        Me.lblHypPath = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lbMessage
        '
        Me.lbMessage.AutoSize = True
        Me.lbMessage.Location = New System.Drawing.Point(24, 46)
        Me.lbMessage.Name = "lbMessage"
        Me.lbMessage.Size = New System.Drawing.Size(39, 13)
        Me.lbMessage.TabIndex = 0
        Me.lbMessage.Text = "Label1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "applications.ico")
        Me.ImageList1.Images.SetKeyName(1, "cd.ico")
        Me.ImageList1.Images.SetKeyName(2, "cdr.ico")
        Me.ImageList1.Images.SetKeyName(3, "clock.ico")
        Me.ImageList1.Images.SetKeyName(4, "computer.ico")
        Me.ImageList1.Images.SetKeyName(5, "exec.ico")
        Me.ImageList1.Images.SetKeyName(6, "favorits.ico")
        Me.ImageList1.Images.SetKeyName(7, "files2.ico")
        Me.ImageList1.Images.SetKeyName(8, "files12.ico")
        Me.ImageList1.Images.SetKeyName(9, "files_edit.ico")
        Me.ImageList1.Images.SetKeyName(10, "files_text.ico")
        Me.ImageList1.Images.SetKeyName(11, "find.ico")
        Me.ImageList1.Images.SetKeyName(12, "folder_blue.ico")
        Me.ImageList1.Images.SetKeyName(13, "folder_documents.ico")
        Me.ImageList1.Images.SetKeyName(14, "folder_downloads.ico")
        Me.ImageList1.Images.SetKeyName(15, "folder_edit.ico")
        Me.ImageList1.Images.SetKeyName(16, "folder_favorits.ico")
        Me.ImageList1.Images.SetKeyName(17, "folder_find.ico")
        Me.ImageList1.Images.SetKeyName(18, "folder_grape.ico")
        Me.ImageList1.Images.SetKeyName(19, "folder_gray.ico")
        Me.ImageList1.Images.SetKeyName(20, "folder_green.ico")
        Me.ImageList1.Images.SetKeyName(21, "folder_home.ico")
        Me.ImageList1.Images.SetKeyName(22, "folder_html.ico")
        Me.ImageList1.Images.SetKeyName(23, "folder_locked.ico")
        Me.ImageList1.Images.SetKeyName(24, "folder_movies.ico")
        Me.ImageList1.Images.SetKeyName(25, "folder_red.ico")
        Me.ImageList1.Images.SetKeyName(26, "folder_sound.ico")
        Me.ImageList1.Images.SetKeyName(27, "folder_temporary.ico")
        Me.ImageList1.Images.SetKeyName(28, "folder_yellow.ico")
        Me.ImageList1.Images.SetKeyName(29, "home1.ico")
        Me.ImageList1.Images.SetKeyName(30, "mail.ico")
        Me.ImageList1.Images.SetKeyName(31, "network.ico")
        Me.ImageList1.Images.SetKeyName(32, "network_downloads.ico")
        Me.ImageList1.Images.SetKeyName(33, "network_find.ico")
        Me.ImageList1.Images.SetKeyName(34, "network_uploads.ico")
        Me.ImageList1.Images.SetKeyName(35, "sound.ico")
        Me.ImageList1.Images.SetKeyName(36, "trash.ico")
        Me.ImageList1.Images.SetKeyName(37, "trash_full.ico")
        Me.ImageList1.Images.SetKeyName(38, "down3.ico")
        Me.ImageList1.Images.SetKeyName(39, "up4.ico")
        Me.ImageList1.Images.SetKeyName(40, "edit.ico")
        Me.ImageList1.Images.SetKeyName(41, "add-printer.ico")
        Me.ImageList1.Images.SetKeyName(42, "delete.ico")
        Me.ImageList1.Images.SetKeyName(43, "ok.ico")
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.ImageIndex = 42
        Me.btnCancel.ImageList = Me.ImageList1
        Me.btnCancel.Location = New System.Drawing.Point(27, 20)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Annuleren"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.ImageIndex = 43
        Me.btnOk.ImageList = Me.ImageList1
        Me.btnOk.Location = New System.Drawing.Point(27, 20)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(80, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.UseVisualStyleBackColor = True
        Me.btnOk.Visible = False
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(24, 77)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(16, 13)
        Me.lblProcess.TabIndex = 3
        Me.lblProcess.Text = "..."
        '
        'pbTaskProgress
        '
        Me.pbTaskProgress.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbTaskProgress.Location = New System.Drawing.Point(0, 104)
        Me.pbTaskProgress.Name = "pbTaskProgress"
        Me.pbTaskProgress.Size = New System.Drawing.Size(320, 23)
        Me.pbTaskProgress.TabIndex = 4
        '
        'lblHypPath
        '
        Me.lblHypPath.AutoSize = True
        Me.lblHypPath.Location = New System.Drawing.Point(24, 46)
        Me.lblHypPath.Name = "lblHypPath"
        Me.lblHypPath.Size = New System.Drawing.Size(59, 13)
        Me.lblHypPath.TabIndex = 5
        Me.lblHypPath.TabStop = True
        Me.lblHypPath.Text = "LinkLabel1"
        Me.lblHypPath.Visible = False
        '
        'frmWait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 127)
        Me.Controls.Add(Me.lblHypPath)
        Me.Controls.Add(Me.pbTaskProgress)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lbMessage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWait"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ben bezig..."
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbMessage As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbTaskProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblHypPath As System.Windows.Forms.LinkLabel
End Class
