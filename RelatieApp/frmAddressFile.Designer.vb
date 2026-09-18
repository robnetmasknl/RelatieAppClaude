<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddressFile
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
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.fbdSave = New System.Windows.Forms.FolderBrowserDialog
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnProcess = New System.Windows.Forms.Button
        Me.btnFile = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.tbfileSave = New System.Windows.Forms.TextBox
        Me.lblProcess = New System.Windows.Forms.Label
        Me.rbTrivizier = New System.Windows.Forms.RadioButton
        Me.rbXrcise = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar.Location = New System.Drawing.Point(0, 390)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(668, 23)
        Me.ProgressBar.TabIndex = 39
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(500, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(500, 67)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 43
        Me.btnProcess.Text = "Verwerken"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(500, 38)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(75, 23)
        Me.btnFile.TabIndex = 42
        Me.btnFile.Text = "Selecteer..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Opslaan in ..."
        '
        'tbfileSave
        '
        Me.tbfileSave.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.RelatieApp.My.MySettings.Default, "ReportsPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbfileSave.Location = New System.Drawing.Point(113, 40)
        Me.tbfileSave.Name = "tbfileSave"
        Me.tbfileSave.Size = New System.Drawing.Size(381, 20)
        Me.tbfileSave.TabIndex = 40
        Me.tbfileSave.Text = Global.RelatieApp.My.MySettings.Default.ReportsPath
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcess.Location = New System.Drawing.Point(110, 136)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(17, 16)
        Me.lblProcess.TabIndex = 45
        Me.lblProcess.Text = "..."
        '
        'rbTrivizier
        '
        Me.rbTrivizier.AutoSize = True
        Me.rbTrivizier.Location = New System.Drawing.Point(113, 76)
        Me.rbTrivizier.Name = "rbTrivizier"
        Me.rbTrivizier.Size = New System.Drawing.Size(105, 17)
        Me.rbTrivizier.TabIndex = 46
        Me.rbTrivizier.Text = "Trivizier bestand."
        Me.rbTrivizier.UseVisualStyleBackColor = True
        '
        'rbXrcise
        '
        Me.rbXrcise.AutoSize = True
        Me.rbXrcise.Location = New System.Drawing.Point(113, 99)
        Me.rbXrcise.Name = "rbXrcise"
        Me.rbXrcise.Size = New System.Drawing.Size(95, 17)
        Me.rbXrcise.TabIndex = 47
        Me.rbXrcise.Text = "Xrcise bestand"
        Me.rbXrcise.UseVisualStyleBackColor = True
        '
        'frmAddressFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 413)
        Me.Controls.Add(Me.rbXrcise)
        Me.Controls.Add(Me.rbTrivizier)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbfileSave)
        Me.Controls.Add(Me.ProgressBar)
        Me.Name = "frmAddressFile"
        Me.Text = "Maken verzendbestand"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents fbdSave As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbfileSave As System.Windows.Forms.TextBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents rbTrivizier As System.Windows.Forms.RadioButton
    Friend WithEvents rbXrcise As System.Windows.Forms.RadioButton
End Class
