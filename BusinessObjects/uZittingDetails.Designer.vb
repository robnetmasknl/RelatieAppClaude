<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uZittingDetails
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
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "HH:mm"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(3, 0)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.ShowUpDown = True
        Me.dtpStart.Size = New System.Drawing.Size(58, 20)
        Me.dtpStart.TabIndex = 0
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "HH:mm"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(100, 0)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.ShowUpDown = True
        Me.dtpEnd.Size = New System.Drawing.Size(58, 20)
        Me.dtpEnd.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "tot"
        '
        'uZittingDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.dtpStart)
        Me.Name = "uZittingDetails"
        Me.Size = New System.Drawing.Size(166, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private durationSpan As TimeSpan

    Private Sub uZittingDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        'dtpStart.MinDate = New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)
        'dtpStart.MaxDate = New Date(Now.Year, Now.Month, Now.Day, 23, 59, 0)
        'dtpEnd.MinDate = New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)
        'dtpEnd.MaxDate = New Date(Now.Year, Now.Month, Now.Day, 23, 59, 0)
        durationSpan = dtpEnd.Value - dtpStart.Value
    End Sub

    Private Sub dtpStart_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles dtpStart.Validating

        '' If Me.dtpEnd.Value < Me.dtpStart.Value Then
        Me.dtpEnd.Value = dtpStart.Value.AddMinutes(durationSpan.TotalMinutes)
        ' End If
    End Sub

    Private Sub dtpEnd_Validated(sender As Object, e As EventArgs) Handles dtpEnd.Validated
        If dtpEnd.Value < dtpStart.Value Then
            dtpEnd.Value = dtpStart.Value
        End If
    End Sub
End Class
