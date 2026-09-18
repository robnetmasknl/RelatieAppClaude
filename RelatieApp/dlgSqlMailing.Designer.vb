<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSqlMailing
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.cmbColumns = New System.Windows.Forms.ComboBox()
        Me.cmbCompare = New System.Windows.Forms.ComboBox()
        Me.btnCreateSQL = New System.Windows.Forms.Button()
        Me.txtIs = New System.Windows.Forms.TextBox()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.tbSqlFrom = New System.Windows.Forms.TextBox()
        Me.lblWhere = New System.Windows.Forms.Label()
        Me.tbWhereFirst = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(339, 49)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 45
        Me.btnOk.Text = "ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'cmbColumns
        '
        Me.cmbColumns.FormattingEnabled = True
        Me.cmbColumns.Location = New System.Drawing.Point(44, 25)
        Me.cmbColumns.Name = "cmbColumns"
        Me.cmbColumns.Size = New System.Drawing.Size(121, 21)
        Me.cmbColumns.TabIndex = 44
        '
        'cmbCompare
        '
        Me.cmbCompare.FormattingEnabled = True
        Me.cmbCompare.Location = New System.Drawing.Point(174, 23)
        Me.cmbCompare.Name = "cmbCompare"
        Me.cmbCompare.Size = New System.Drawing.Size(102, 21)
        Me.cmbCompare.TabIndex = 43
        '
        'btnCreateSQL
        '
        Me.btnCreateSQL.Location = New System.Drawing.Point(258, 50)
        Me.btnCreateSQL.Name = "btnCreateSQL"
        Me.btnCreateSQL.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateSQL.TabIndex = 42
        Me.btnCreateSQL.Text = "sql build"
        Me.btnCreateSQL.UseVisualStyleBackColor = True
        '
        'txtIs
        '
        Me.txtIs.Location = New System.Drawing.Point(282, 23)
        Me.txtIs.Name = "txtIs"
        Me.txtIs.Size = New System.Drawing.Size(132, 20)
        Me.txtIs.TabIndex = 41
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(44, 208)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(370, 45)
        Me.txtSQL.TabIndex = 46
        '
        'tbSqlFrom
        '
        Me.tbSqlFrom.Enabled = False
        Me.tbSqlFrom.Location = New System.Drawing.Point(44, 77)
        Me.tbSqlFrom.Multiline = True
        Me.tbSqlFrom.Name = "tbSqlFrom"
        Me.tbSqlFrom.Size = New System.Drawing.Size(370, 53)
        Me.tbSqlFrom.TabIndex = 47
        '
        'lblWhere
        '
        Me.lblWhere.AutoSize = True
        Me.lblWhere.Location = New System.Drawing.Point(41, 192)
        Me.lblWhere.Name = "lblWhere"
        Me.lblWhere.Size = New System.Drawing.Size(48, 13)
        Me.lblWhere.TabIndex = 48
        Me.lblWhere.Text = "WHERE"
        '
        'tbWhereFirst
        '
        Me.tbWhereFirst.Location = New System.Drawing.Point(44, 144)
        Me.tbWhereFirst.Multiline = True
        Me.tbWhereFirst.Name = "tbWhereFirst"
        Me.tbWhereFirst.Size = New System.Drawing.Size(370, 45)
        Me.tbWhereFirst.TabIndex = 49
        '
        'dlgSqlMailing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 300)
        Me.Controls.Add(Me.tbWhereFirst)
        Me.Controls.Add(Me.lblWhere)
        Me.Controls.Add(Me.tbSqlFrom)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cmbColumns)
        Me.Controls.Add(Me.cmbCompare)
        Me.Controls.Add(Me.btnCreateSQL)
        Me.Controls.Add(Me.txtIs)
        Me.Name = "dlgSqlMailing"
        Me.Text = "sql advanced"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents cmbColumns As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCompare As System.Windows.Forms.ComboBox
    Friend WithEvents btnCreateSQL As System.Windows.Forms.Button
    Friend WithEvents txtIs As System.Windows.Forms.TextBox
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents tbSqlFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblWhere As Label
    Friend WithEvents tbWhereFirst As TextBox
End Class
