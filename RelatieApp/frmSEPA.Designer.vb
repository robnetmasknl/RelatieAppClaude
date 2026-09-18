<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSEPA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSEPA))
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbAmount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvSoorten = New System.Windows.Forms.ListView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSelectie = New System.Windows.Forms.Label()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.btnSEPA = New System.Windows.Forms.Button()
        Me.btnControleSEPA = New System.Windows.Forms.Button()
        Me.tbFixDesription = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnControleSEPASpec = New System.Windows.Forms.Button()
        Me.tbfile = New System.Windows.Forms.TextBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSeq = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(296, 109)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(90, 21)
        Me.cmbYear.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Bestand voor jaar:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(172, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Bestand voor maand:"
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(296, 82)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(90, 21)
        Me.cmbMonth.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(36, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Lidsoort(en):"
        '
        'tbAmount
        '
        Me.tbAmount.Location = New System.Drawing.Point(296, 53)
        Me.tbAmount.Name = "tbAmount"
        Me.tbAmount.Size = New System.Drawing.Size(90, 20)
        Me.tbAmount.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(172, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Bedrag in centen:"
        '
        'lvSoorten
        '
        Me.lvSoorten.FullRowSelect = True
        Me.lvSoorten.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvSoorten.HideSelection = False
        Me.lvSoorten.Location = New System.Drawing.Point(12, 53)
        Me.lvSoorten.Name = "lvSoorten"
        Me.lvSoorten.Size = New System.Drawing.Size(154, 334)
        Me.lvSoorten.TabIndex = 0
        Me.lvSoorten.UseCompatibleStateImageBehavior = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(172, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Selectie:"
        '
        'lblSelectie
        '
        Me.lblSelectie.AutoSize = True
        Me.lblSelectie.Location = New System.Drawing.Point(293, 26)
        Me.lblSelectie.Name = "lblSelectie"
        Me.lblSelectie.Size = New System.Drawing.Size(19, 13)
        Me.lblSelectie.TabIndex = 57
        Me.lblSelectie.Text = "...."
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(172, 227)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(16, 13)
        Me.lblProcess.TabIndex = 60
        Me.lblProcess.Text = "..."
        '
        'btnSEPA
        '
        Me.btnSEPA.Enabled = False
        Me.btnSEPA.Location = New System.Drawing.Point(406, 191)
        Me.btnSEPA.Name = "btnSEPA"
        Me.btnSEPA.Size = New System.Drawing.Size(90, 23)
        Me.btnSEPA.TabIndex = 6
        Me.btnSEPA.Text = "SEPA"
        Me.btnSEPA.UseVisualStyleBackColor = True
        '
        'btnControleSEPA
        '
        Me.btnControleSEPA.Location = New System.Drawing.Point(406, 162)
        Me.btnControleSEPA.Name = "btnControleSEPA"
        Me.btnControleSEPA.Size = New System.Drawing.Size(90, 23)
        Me.btnControleSEPA.TabIndex = 5
        Me.btnControleSEPA.Text = "Controle SEPA"
        Me.btnControleSEPA.UseVisualStyleBackColor = True
        '
        'tbFixDesription
        '
        Me.tbFixDesription.Location = New System.Drawing.Point(296, 136)
        Me.tbFixDesription.Name = "tbFixDesription"
        Me.tbFixDesription.Size = New System.Drawing.Size(200, 20)
        Me.tbFixDesription.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(172, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Vaste Omschrijving:"
        '
        'btnControleSEPASpec
        '
        Me.btnControleSEPASpec.Location = New System.Drawing.Point(316, 48)
        Me.btnControleSEPASpec.Name = "btnControleSEPASpec"
        Me.btnControleSEPASpec.Size = New System.Drawing.Size(117, 23)
        Me.btnControleSEPASpec.TabIndex = 2
        Me.btnControleSEPASpec.Text = "Controle SEPA spec."
        Me.btnControleSEPASpec.UseVisualStyleBackColor = True
        '
        'tbfile
        '
        Me.tbfile.Location = New System.Drawing.Point(110, 19)
        Me.tbfile.Name = "tbfile"
        Me.tbfile.Size = New System.Drawing.Size(200, 20)
        Me.tbfile.TabIndex = 0
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(316, 18)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(117, 23)
        Me.btnFile.TabIndex = 1
        Me.btnFile.Text = "Selecteer..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "csv ledenbestand"
        '
        'cmbSeq
        '
        Me.cmbSeq.FormattingEnabled = True
        Me.cmbSeq.Items.AddRange(New Object() {"FRST", "RCUR", "OOFF", "FNAL"})
        Me.cmbSeq.Location = New System.Drawing.Point(316, 77)
        Me.cmbSeq.Name = "cmbSeq"
        Me.cmbSeq.Size = New System.Drawing.Size(117, 21)
        Me.cmbSeq.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbfile)
        Me.GroupBox1.Controls.Add(Me.cmbSeq)
        Me.GroupBox1.Controls.Add(Me.btnControleSEPASpec)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnFile)
        Me.GroupBox1.Location = New System.Drawing.Point(188, 262)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(464, 125)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "voor gewijzigde iban"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(295, 74)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "1) maak een ; csv.1e lidnr,2e oude iban" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2) select frst of rcur" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3) run controle " &
    "sepa spec" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4) run sepa"
        '
        'frmSEPA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 470)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbFixDesription)
        Me.Controls.Add(Me.btnControleSEPA)
        Me.Controls.Add(Me.btnSEPA)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.lblSelectie)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lvSoorten)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbAmount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbMonth)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSEPA"
        Me.Text = "Sepa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvSoorten As System.Windows.Forms.ListView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSelectie As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents btnSEPA As System.Windows.Forms.Button
    Friend WithEvents btnControleSEPA As System.Windows.Forms.Button
    Friend WithEvents tbFixDesription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnControleSEPASpec As System.Windows.Forms.Button
    Friend WithEvents tbfile As System.Windows.Forms.TextBox
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSeq As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
