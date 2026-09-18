<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJumbling
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
        Me.lbColumn = New System.Windows.Forms.Label()
        Me.lbTable = New System.Windows.Forms.Label()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.PreText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PreLenght = New System.Windows.Forms.TextBox()
        Me.lsbColums = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblConnection = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbColumn
        '
        Me.lbColumn.AutoSize = True
        Me.lbColumn.Location = New System.Drawing.Point(41, 83)
        Me.lbColumn.Name = "lbColumn"
        Me.lbColumn.Size = New System.Drawing.Size(92, 13)
        Me.lbColumn.TabIndex = 54
        Me.lbColumn.Text = "Selecteer kolom..."
        '
        'lbTable
        '
        Me.lbTable.AutoSize = True
        Me.lbTable.Location = New System.Drawing.Point(41, 56)
        Me.lbTable.Name = "lbTable"
        Me.lbTable.Size = New System.Drawing.Size(84, 13)
        Me.lbTable.TabIndex = 52
        Me.lbTable.Text = "Selecteer tabel.."
        '
        'cmbTables
        '
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(131, 53)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(162, 21)
        Me.cmbTables.TabIndex = 51
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(308, 152)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 60
        Me.btnOk.Text = "ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'PreText
        '
        Me.PreText.Location = New System.Drawing.Point(131, 181)
        Me.PreText.Name = "PreText"
        Me.PreText.Size = New System.Drawing.Size(162, 20)
        Me.PreText.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(57, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "voorloop text"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "totale lengte"
        '
        'PreLenght
        '
        Me.PreLenght.Location = New System.Drawing.Point(131, 207)
        Me.PreLenght.Name = "PreLenght"
        Me.PreLenght.Size = New System.Drawing.Size(162, 20)
        Me.PreLenght.TabIndex = 63
        Me.PreLenght.Text = "5"
        '
        'lsbColums
        '
        Me.lsbColums.AllowDrop = True
        Me.lsbColums.FormattingEnabled = True
        Me.lsbColums.Location = New System.Drawing.Point(131, 80)
        Me.lsbColums.Name = "lsbColums"
        Me.lsbColums.Size = New System.Drawing.Size(162, 95)
        Me.lsbColums.TabIndex = 66
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(400, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 23)
        Me.Button1.TabIndex = 69
        Me.Button1.Text = "update alle naw velden"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblConnection
        '
        Me.lblConnection.AutoSize = True
        Me.lblConnection.Location = New System.Drawing.Point(128, 19)
        Me.lblConnection.Name = "lblConnection"
        Me.lblConnection.Size = New System.Drawing.Size(76, 13)
        Me.lblConnection.TabIndex = 70
        Me.lblConnection.Text = "sql connection"
        '
        'frmJumbling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 291)
        Me.Controls.Add(Me.lblConnection)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lsbColums)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PreLenght)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PreText)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lbColumn)
        Me.Controls.Add(Me.lbTable)
        Me.Controls.Add(Me.cmbTables)
        Me.Name = "frmJumbling"
        Me.Text = "Jumbling"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbColumn As Label
    Friend WithEvents lbTable As Label
    Friend WithEvents cmbTables As ComboBox
    Friend WithEvents btnOk As Button
    Friend WithEvents PreText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PreLenght As TextBox
    Friend WithEvents lsbColums As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents lblConnection As Label
End Class
