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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnOpzeggingen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSMS = New System.Windows.Forms.Button()
        Me.btnIbbCalendar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOpzeggingen
        '
        Me.btnOpzeggingen.Location = New System.Drawing.Point(31, 67)
        Me.btnOpzeggingen.Name = "btnOpzeggingen"
        Me.btnOpzeggingen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpzeggingen.TabIndex = 0
        Me.btnOpzeggingen.Text = "Settings"
        Me.btnOpzeggingen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(112, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Opzeggingen && Elco service"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SMS service"
        '
        'btnSMS
        '
        Me.btnSMS.Location = New System.Drawing.Point(31, 105)
        Me.btnSMS.Name = "btnSMS"
        Me.btnSMS.Size = New System.Drawing.Size(75, 23)
        Me.btnSMS.TabIndex = 2
        Me.btnSMS.Text = "Settings"
        Me.btnSMS.UseVisualStyleBackColor = True
        '
        'btnIbbCalendar
        '
        Me.btnIbbCalendar.Location = New System.Drawing.Point(31, 29)
        Me.btnIbbCalendar.Name = "btnIbbCalendar"
        Me.btnIbbCalendar.Size = New System.Drawing.Size(75, 23)
        Me.btnIbbCalendar.TabIndex = 4
        Me.btnIbbCalendar.Text = "Settings"
        Me.btnIbbCalendar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(112, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "IBB Agenda service"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 470)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnIbbCalendar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSMS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOpzeggingen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Services management"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpzeggingen As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSMS As System.Windows.Forms.Button
    Friend WithEvents btnIbbCalendar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
