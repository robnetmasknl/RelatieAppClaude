<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lstvRefused = New System.Windows.Forms.ListView()
        Me.lstvProcessed = New System.Windows.Forms.ListView()
        Me.btnReader = New System.Windows.Forms.Button()
        Me.mnu = New System.Windows.Forms.MenuStrip()
        Me.mnuitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrReadQ = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCheckStatus = New System.Windows.Forms.Timer(Me.components)
        Me.sbrServiceStatus = New System.Windows.Forms.StatusBar()
        Me.sbp1 = New System.Windows.Forms.StatusBarPanel()
        Me.sbp2 = New System.Windows.Forms.StatusBarPanel()
        Me.tbLogInterval = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mnu.SuspendLayout()
        CType(Me.sbp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbp2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStop
        '
        Me.btnStop.AccessibleDescription = "Button used to Stop the Windows Service."
        Me.btnStop.AccessibleName = "Stop Button"
        Me.btnStop.Enabled = False
        Me.btnStop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStop.Location = New System.Drawing.Point(342, 520)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 22
        Me.btnStop.Text = "Sto&p"
        '
        'btnContinue
        '
        Me.btnContinue.AccessibleDescription = "Button used to Continue the Windows Service."
        Me.btnContinue.AccessibleName = "Continue Button"
        Me.btnContinue.Enabled = False
        Me.btnContinue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnContinue.Location = New System.Drawing.Point(254, 520)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(75, 23)
        Me.btnContinue.TabIndex = 21
        Me.btnContinue.Text = "&Continue"
        '
        'btnPause
        '
        Me.btnPause.AccessibleDescription = "Button used to Pause the Windows Service."
        Me.btnPause.AccessibleName = "Pause Button"
        Me.btnPause.Enabled = False
        Me.btnPause.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPause.Location = New System.Drawing.Point(166, 520)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(75, 23)
        Me.btnPause.TabIndex = 20
        Me.btnPause.Text = "&Pause"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(77, 520)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 19
        Me.btnStart.Text = "Start service"
        '
        'lstvRefused
        '
        Me.lstvRefused.Location = New System.Drawing.Point(77, 57)
        Me.lstvRefused.Name = "lstvRefused"
        Me.lstvRefused.Size = New System.Drawing.Size(679, 213)
        Me.lstvRefused.TabIndex = 18
        Me.lstvRefused.UseCompatibleStateImageBehavior = False
        '
        'lstvProcessed
        '
        Me.lstvProcessed.Location = New System.Drawing.Point(77, 291)
        Me.lstvProcessed.Name = "lstvProcessed"
        Me.lstvProcessed.Size = New System.Drawing.Size(679, 223)
        Me.lstvProcessed.TabIndex = 17
        Me.lstvProcessed.UseCompatibleStateImageBehavior = False
        '
        'btnReader
        '
        Me.btnReader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReader.ImageIndex = 5
        Me.btnReader.Location = New System.Drawing.Point(762, 73)
        Me.btnReader.Name = "btnReader"
        Me.btnReader.Size = New System.Drawing.Size(86, 23)
        Me.btnReader.TabIndex = 16
        Me.btnReader.Text = "Start"
        Me.btnReader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReader.UseVisualStyleBackColor = True
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuitem, Me.DocumentenToolStripMenuItem1})
        Me.mnu.Location = New System.Drawing.Point(0, 0)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(903, 24)
        Me.mnu.TabIndex = 23
        Me.mnu.Text = "Bestand"
        '
        'mnuitem
        '
        Me.mnuitem.Name = "mnuitem"
        Me.mnuitem.Size = New System.Drawing.Size(61, 20)
        Me.mnuitem.Text = "Settings"
        '
        'DocumentenToolStripMenuItem1
        '
        Me.DocumentenToolStripMenuItem1.Name = "DocumentenToolStripMenuItem1"
        Me.DocumentenToolStripMenuItem1.Size = New System.Drawing.Size(88, 20)
        Me.DocumentenToolStripMenuItem1.Text = "Documenten"
        '
        'tmrReadQ
        '
        '
        'tmrCheckStatus
        '
        '
        'sbrServiceStatus
        '
        Me.sbrServiceStatus.Location = New System.Drawing.Point(0, 584)
        Me.sbrServiceStatus.Name = "sbrServiceStatus"
        Me.sbrServiceStatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbp1, Me.sbp2})
        Me.sbrServiceStatus.ShowPanels = True
        Me.sbrServiceStatus.Size = New System.Drawing.Size(903, 22)
        Me.sbrServiceStatus.TabIndex = 24
        '
        'sbp1
        '
        Me.sbp1.Name = "sbp1"
        Me.sbp1.Width = 250
        '
        'sbp2
        '
        Me.sbp2.Name = "sbp2"
        Me.sbp2.Width = 250
        '
        'tbLogInterval
        '
        Me.tbLogInterval.Location = New System.Drawing.Point(762, 124)
        Me.tbLogInterval.Name = "tbLogInterval"
        Me.tbLogInterval.Size = New System.Drawing.Size(86, 20)
        Me.tbLogInterval.TabIndex = 25
        Me.tbLogInterval.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(762, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "refresh log min."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(762, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Start/Stop log"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 606)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbLogInterval)
        Me.Controls.Add(Me.sbrServiceStatus)
        Me.Controls.Add(Me.mnu)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lstvRefused)
        Me.Controls.Add(Me.lstvProcessed)
        Me.Controls.Add(Me.btnReader)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Scan2Ibb"
        Me.mnu.ResumeLayout(False)
        Me.mnu.PerformLayout()
        CType(Me.sbp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbp2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lstvRefused As System.Windows.Forms.ListView
    Friend WithEvents lstvProcessed As System.Windows.Forms.ListView
    Friend WithEvents btnReader As System.Windows.Forms.Button
    Friend WithEvents mnu As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuitem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DocumentenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrReadQ As System.Windows.Forms.Timer
    Friend WithEvents tmrCheckStatus As System.Windows.Forms.Timer
    Friend WithEvents sbrServiceStatus As System.Windows.Forms.StatusBar
    Friend WithEvents sbp1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbp2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tbLogInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
