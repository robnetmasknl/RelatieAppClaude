<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSqlBuild
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
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lsbColums = New System.Windows.Forms.ListBox()
        Me.lsbTables = New System.Windows.Forms.ListBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnSqlRun = New System.Windows.Forms.Button()
        Me.btnCreateSQL = New System.Windows.Forms.Button()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.txtIs = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lsbWhat = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.cmbCompare = New System.Windows.Forms.ComboBox()
        Me.cmbColumns = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Location = New System.Drawing.Point(320, 61)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(74, 13)
        Me.lblTableName.TabIndex = 7
        Me.lblTableName.Text = "Columns van :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(249, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Columns van :"
        '
        'lsbColums
        '
        Me.lsbColums.AllowDrop = True
        Me.lsbColums.FormattingEnabled = True
        Me.lsbColums.Location = New System.Drawing.Point(333, 77)
        Me.lsbColums.Name = "lsbColums"
        Me.lsbColums.Size = New System.Drawing.Size(222, 95)
        Me.lsbColums.TabIndex = 5
        '
        'lsbTables
        '
        Me.lsbTables.FormattingEnabled = True
        Me.lsbTables.Location = New System.Drawing.Point(21, 77)
        Me.lsbTables.Name = "lsbTables"
        Me.lsbTables.Size = New System.Drawing.Size(233, 95)
        Me.lsbTables.TabIndex = 4
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(795, 284)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnExcel.TabIndex = 37
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnSqlRun
        '
        Me.btnSqlRun.Location = New System.Drawing.Point(714, 284)
        Me.btnSqlRun.Name = "btnSqlRun"
        Me.btnSqlRun.Size = New System.Drawing.Size(75, 23)
        Me.btnSqlRun.TabIndex = 36
        Me.btnSqlRun.Text = "SQL Run"
        Me.btnSqlRun.UseVisualStyleBackColor = True
        '
        'btnCreateSQL
        '
        Me.btnCreateSQL.Location = New System.Drawing.Point(633, 284)
        Me.btnCreateSQL.Name = "btnCreateSQL"
        Me.btnCreateSQL.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateSQL.TabIndex = 35
        Me.btnCreateSQL.Text = "SQL"
        Me.btnCreateSQL.UseVisualStyleBackColor = True
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(101, 322)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(779, 179)
        Me.txtSQL.TabIndex = 34
        '
        'txtIs
        '
        Me.txtIs.Location = New System.Drawing.Point(748, 212)
        Me.txtIs.Name = "txtIs"
        Me.txtIs.Size = New System.Drawing.Size(132, 20)
        Me.txtIs.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(446, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "WHERE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(264, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "FROM"
        '
        'lsbWhat
        '
        Me.lsbWhat.FormattingEnabled = True
        Me.lsbWhat.Location = New System.Drawing.Point(101, 212)
        Me.lsbWhat.Name = "lsbWhat"
        Me.lsbWhat.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lsbWhat.Size = New System.Drawing.Size(153, 95)
        Me.lsbWhat.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "SELECT "
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(308, 212)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(132, 20)
        Me.txtFrom.TabIndex = 26
        '
        'cmbCompare
        '
        Me.cmbCompare.FormattingEnabled = True
        Me.cmbCompare.Location = New System.Drawing.Point(633, 209)
        Me.cmbCompare.Name = "cmbCompare"
        Me.cmbCompare.Size = New System.Drawing.Size(102, 21)
        Me.cmbCompare.TabIndex = 38
        '
        'cmbColumns
        '
        Me.cmbColumns.FormattingEnabled = True
        Me.cmbColumns.Location = New System.Drawing.Point(503, 211)
        Me.cmbColumns.Name = "cmbColumns"
        Me.cmbColumns.Size = New System.Drawing.Size(121, 21)
        Me.cmbColumns.TabIndex = 39
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(503, 279)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmSqlBuild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 581)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbColumns)
        Me.Controls.Add(Me.cmbCompare)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnSqlRun)
        Me.Controls.Add(Me.btnCreateSQL)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.txtIs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lsbWhat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.lblTableName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lsbColums)
        Me.Controls.Add(Me.lsbTables)
        Me.Name = "frmSqlBuild"
        Me.Text = "frmSqlBuild"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTableName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lsbColums As System.Windows.Forms.ListBox
    Friend WithEvents lsbTables As System.Windows.Forms.ListBox
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnSqlRun As System.Windows.Forms.Button
    Friend WithEvents btnCreateSQL As System.Windows.Forms.Button
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents txtIs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lsbWhat As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents cmbCompare As System.Windows.Forms.ComboBox
    Friend WithEvents cmbColumns As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
