<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uctd
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tb = New System.Windows.Forms.TextBox()
        Me.btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb
        '
        Me.tb.Location = New System.Drawing.Point(3, 6)
        Me.tb.Name = "tb"
        Me.tb.Size = New System.Drawing.Size(100, 20)
        Me.tb.TabIndex = 2
        '
        'btn
        '
        Me.btn.Image = Global.RelatieApp.My.Resources.Resource1.calendar1
        Me.btn.Location = New System.Drawing.Point(103, 3)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(28, 25)
        Me.btn.TabIndex = 3
        Me.btn.Tag = "tb"
        Me.btn.UseVisualStyleBackColor = True
        '
        'uctd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tb)
        Me.Controls.Add(Me.btn)
        Me.Name = "uctd"
        Me.Size = New System.Drawing.Size(130, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb As System.Windows.Forms.TextBox
    Friend WithEvents btn As System.Windows.Forms.Button

End Class
