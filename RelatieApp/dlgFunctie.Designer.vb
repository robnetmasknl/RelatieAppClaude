<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFunctie
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnDelete = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.cmbFuncties = New System.Windows.Forms.ComboBox
        Me.Label60 = New System.Windows.Forms.Label
        Me.cmbAdvies = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbOrgaan = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbAfdeling = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.utdFunctieEind = New RelatieApp.ucTextDate
        Me.utdFunctieInd = New RelatieApp.ucTextDate
        Me.cbToon = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnDelete, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(120, 272)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(215, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelete.Location = New System.Drawing.Point(74, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(65, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Verwijder"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(65, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(145, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(21, 193)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(70, 13)
        Me.Label62.TabIndex = 144
        Me.Label62.Text = "Datum einde:"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(21, 162)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(76, 13)
        Me.Label61.TabIndex = 143
        Me.Label61.Text = "Datum ingang:"
        '
        'cmbFuncties
        '
        Me.cmbFuncties.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFuncties.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFuncties.DropDownWidth = 150
        Me.cmbFuncties.FormattingEnabled = True
        Me.cmbFuncties.Location = New System.Drawing.Point(120, 32)
        Me.cmbFuncties.Name = "cmbFuncties"
        Me.cmbFuncties.Size = New System.Drawing.Size(212, 21)
        Me.cmbFuncties.TabIndex = 142
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(21, 35)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(45, 13)
        Me.Label60.TabIndex = 141
        Me.Label60.Text = "Functie:"
        '
        'cmbAdvies
        '
        Me.cmbAdvies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAdvies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAdvies.DropDownWidth = 150
        Me.cmbAdvies.FormattingEnabled = True
        Me.cmbAdvies.Location = New System.Drawing.Point(120, 59)
        Me.cmbAdvies.Name = "cmbAdvies"
        Me.cmbAdvies.Size = New System.Drawing.Size(212, 21)
        Me.cmbAdvies.TabIndex = 148
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Adviesgroep:"
        '
        'cmbOrgaan
        '
        Me.cmbOrgaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrgaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrgaan.DropDownWidth = 150
        Me.cmbOrgaan.FormattingEnabled = True
        Me.cmbOrgaan.Location = New System.Drawing.Point(120, 86)
        Me.cmbOrgaan.Name = "cmbOrgaan"
        Me.cmbOrgaan.Size = New System.Drawing.Size(212, 21)
        Me.cmbOrgaan.TabIndex = 150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "Orgaan:"
        '
        'cmbAfdeling
        '
        Me.cmbAfdeling.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAfdeling.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAfdeling.DropDownWidth = 150
        Me.cmbAfdeling.FormattingEnabled = True
        Me.cmbAfdeling.Location = New System.Drawing.Point(120, 113)
        Me.cmbAfdeling.Name = "cmbAfdeling"
        Me.cmbAfdeling.Size = New System.Drawing.Size(212, 21)
        Me.cmbAfdeling.TabIndex = 152
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 151
        Me.Label3.Text = "Afdeling:"
        '
        'utdFunctieEind
        '
        Me.utdFunctieEind.Location = New System.Drawing.Point(120, 187)
        Me.utdFunctieEind.Name = "utdFunctieEind"
        Me.utdFunctieEind.Size = New System.Drawing.Size(130, 27)
        Me.utdFunctieEind.TabIndex = 146
        Me.utdFunctieEind.Value = ""
        '
        'utdFunctieInd
        '
        Me.utdFunctieInd.Location = New System.Drawing.Point(120, 154)
        Me.utdFunctieInd.Name = "utdFunctieInd"
        Me.utdFunctieInd.Size = New System.Drawing.Size(130, 27)
        Me.utdFunctieInd.TabIndex = 145
        Me.utdFunctieInd.Value = ""
        '
        'cbToon
        '
        Me.cbToon.AutoSize = True
        Me.cbToon.Location = New System.Drawing.Point(120, 230)
        Me.cbToon.Name = "cbToon"
        Me.cbToon.Size = New System.Drawing.Size(130, 17)
        Me.cbToon.TabIndex = 154
        Me.cbToon.Text = "Tonen op relatiekaart."
        Me.cbToon.UseVisualStyleBackColor = True
        '
        'dlgFunctie
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(347, 313)
        Me.Controls.Add(Me.cbToon)
        Me.Controls.Add(Me.cmbAfdeling)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbOrgaan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbAdvies)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.cmbFuncties)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.utdFunctieEind)
        Me.Controls.Add(Me.utdFunctieInd)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgFunctie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Functie"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents cmbFuncties As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents utdFunctieEind As RelatieApp.ucTextDate
    Friend WithEvents utdFunctieInd As RelatieApp.ucTextDate
    Friend WithEvents cmbAdvies As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOrgaan As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAfdeling As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cbToon As System.Windows.Forms.CheckBox

End Class
