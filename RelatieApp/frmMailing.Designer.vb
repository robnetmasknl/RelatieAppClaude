<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMailing
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMailing))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextRelatie = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenRelatieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDienjaar = New System.Windows.Forms.CheckBox()
        Me.btnSql = New System.Windows.Forms.Button()
        Me.cmbIBBGroep = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cmbLidAfdeling = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkM_NSK = New System.Windows.Forms.CheckBox()
        Me.cmbPlaatsing = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbAdvies = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.utdFunctie = New RelatieApp.ucTextDate()
        Me.cmbAfdeling = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbOrgaan = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFuncties = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.chkBOM = New System.Windows.Forms.CheckBox()
        Me.utdFloPen = New RelatieApp.ucTextDate()
        Me.chkZilver = New System.Windows.Forms.CheckBox()
        Me.chkGoud = New System.Windows.Forms.CheckBox()
        Me.chkNato = New System.Windows.Forms.CheckBox()
        Me.cmbRang = New System.Windows.Forms.ComboBox()
        Me.cmbKMonderdeel = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkVeteraan = New System.Windows.Forms.CheckBox()
        Me.chkLid_natres = New System.Windows.Forms.CheckBox()
        Me.chkKerstkaart = New System.Windows.Forms.CheckBox()
        Me.chkALV = New System.Windows.Forms.CheckBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cmbBond = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblAantal = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.CurrentTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvLeden = New System.Windows.Forms.DataGridView()
        Me.Lidnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vnaam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.achternaam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.init = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tussenvoegsel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.huisnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.huisnrtv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Postcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plaats = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.afdeling = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.geboortedatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefoonnummer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mobiel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InDatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tvBrieven = New System.Windows.Forms.TreeView()
        Me.chkAddSearch = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnResetSearch = New System.Windows.Forms.Button()
        Me.chkWriteCorrespondetie = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextRelatie.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvLeden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextRelatie
        '
        Me.ContextRelatie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenRelatieToolStripMenuItem})
        Me.ContextRelatie.Name = "ContextRelatie"
        Me.ContextRelatie.Size = New System.Drawing.Size(149, 26)
        '
        'OpenRelatieToolStripMenuItem
        '
        Me.OpenRelatieToolStripMenuItem.Name = "OpenRelatieToolStripMenuItem"
        Me.OpenRelatieToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.OpenRelatieToolStripMenuItem.Text = "ga naar relatie"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDienjaar)
        Me.GroupBox1.Controls.Add(Me.btnSql)
        Me.GroupBox1.Controls.Add(Me.cmbIBBGroep)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.cmbLidAfdeling)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.chkM_NSK)
        Me.GroupBox1.Controls.Add(Me.cmbPlaatsing)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbAdvies)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.utdFunctie)
        Me.GroupBox1.Controls.Add(Me.cmbAfdeling)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbOrgaan)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbFuncties)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.chkBOM)
        Me.GroupBox1.Controls.Add(Me.utdFloPen)
        Me.GroupBox1.Controls.Add(Me.chkZilver)
        Me.GroupBox1.Controls.Add(Me.chkGoud)
        Me.GroupBox1.Controls.Add(Me.chkNato)
        Me.GroupBox1.Controls.Add(Me.cmbRang)
        Me.GroupBox1.Controls.Add(Me.cmbKMonderdeel)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.chkVeteraan)
        Me.GroupBox1.Controls.Add(Me.chkLid_natres)
        Me.GroupBox1.Controls.Add(Me.chkKerstkaart)
        Me.GroupBox1.Controls.Add(Me.chkALV)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.cmbBond)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(602, 233)
        Me.GroupBox1.TabIndex = 116
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criteria:"
        '
        'chkDienjaar
        '
        Me.chkDienjaar.AutoSize = True
        Me.chkDienjaar.Location = New System.Drawing.Point(21, 201)
        Me.chkDienjaar.Name = "chkDienjaar"
        Me.chkDienjaar.Size = New System.Drawing.Size(65, 17)
        Me.chkDienjaar.TabIndex = 165
        Me.chkDienjaar.Text = "Dienjaar"
        Me.chkDienjaar.UseVisualStyleBackColor = True
        '
        'btnSql
        '
        Me.btnSql.Location = New System.Drawing.Point(560, 195)
        Me.btnSql.Name = "btnSql"
        Me.btnSql.Size = New System.Drawing.Size(29, 23)
        Me.btnSql.TabIndex = 137
        Me.btnSql.Text = "sql"
        Me.btnSql.UseVisualStyleBackColor = True
        Me.btnSql.Visible = False
        '
        'cmbIBBGroep
        '
        Me.cmbIBBGroep.FormattingEnabled = True
        Me.cmbIBBGroep.Location = New System.Drawing.Point(213, 202)
        Me.cmbIBBGroep.Name = "cmbIBBGroep"
        Me.cmbIBBGroep.Size = New System.Drawing.Size(151, 21)
        Me.cmbIBBGroep.TabIndex = 164
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(161, 205)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(51, 13)
        Me.Label33.TabIndex = 163
        Me.Label33.Text = "ibbgroep:"
        '
        'cmbLidAfdeling
        '
        Me.cmbLidAfdeling.FormattingEnabled = True
        Me.cmbLidAfdeling.Location = New System.Drawing.Point(212, 58)
        Me.cmbLidAfdeling.Name = "cmbLidAfdeling"
        Me.cmbLidAfdeling.Size = New System.Drawing.Size(152, 21)
        Me.cmbLidAfdeling.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(161, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 162
        Me.Label8.Text = "Afdeling:"
        '
        'chkM_NSK
        '
        Me.chkM_NSK.AutoSize = True
        Me.chkM_NSK.Location = New System.Drawing.Point(389, 183)
        Me.chkM_NSK.Name = "chkM_NSK"
        Me.chkM_NSK.Size = New System.Drawing.Size(83, 17)
        Me.chkM_NSK.TabIndex = 161
        Me.chkM_NSK.Text = "NSK mailing"
        Me.chkM_NSK.UseVisualStyleBackColor = True
        '
        'cmbPlaatsing
        '
        Me.cmbPlaatsing.DropDownWidth = 160
        Me.cmbPlaatsing.FormattingEnabled = True
        Me.cmbPlaatsing.Location = New System.Drawing.Point(212, 175)
        Me.cmbPlaatsing.Name = "cmbPlaatsing"
        Me.cmbPlaatsing.Size = New System.Drawing.Size(152, 21)
        Me.cmbPlaatsing.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(161, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 159
        Me.Label7.Text = "Plaatsing:"
        '
        'cmbAdvies
        '
        Me.cmbAdvies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAdvies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAdvies.DropDownWidth = 150
        Me.cmbAdvies.FormattingEnabled = True
        Me.cmbAdvies.Location = New System.Drawing.Point(437, 58)
        Me.cmbAdvies.Name = "cmbAdvies"
        Me.cmbAdvies.Size = New System.Drawing.Size(142, 21)
        Me.cmbAdvies.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(386, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "Adviesgr:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(369, 19)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(5, 208)
        Me.GroupBox4.TabIndex = 156
        Me.GroupBox4.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(386, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "fdatum"
        '
        'utdFunctie
        '
        Me.utdFunctie.Location = New System.Drawing.Point(437, 139)
        Me.utdFunctie.Name = "utdFunctie"
        Me.utdFunctie.Size = New System.Drawing.Size(152, 27)
        Me.utdFunctie.TabIndex = 20
        Me.utdFunctie.Value = ""
        '
        'cmbAfdeling
        '
        Me.cmbAfdeling.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAfdeling.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAfdeling.DropDownWidth = 150
        Me.cmbAfdeling.FormattingEnabled = True
        Me.cmbAfdeling.Location = New System.Drawing.Point(437, 112)
        Me.cmbAfdeling.Name = "cmbAfdeling"
        Me.cmbAfdeling.Size = New System.Drawing.Size(142, 21)
        Me.cmbAfdeling.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(386, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Func.Afd."
        '
        'cmbOrgaan
        '
        Me.cmbOrgaan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOrgaan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOrgaan.DropDownWidth = 150
        Me.cmbOrgaan.FormattingEnabled = True
        Me.cmbOrgaan.Location = New System.Drawing.Point(437, 85)
        Me.cmbOrgaan.Name = "cmbOrgaan"
        Me.cmbOrgaan.Size = New System.Drawing.Size(142, 21)
        Me.cmbOrgaan.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(386, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Orgaan:"
        '
        'cmbFuncties
        '
        Me.cmbFuncties.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFuncties.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFuncties.DropDownWidth = 150
        Me.cmbFuncties.FormattingEnabled = True
        Me.cmbFuncties.Location = New System.Drawing.Point(437, 30)
        Me.cmbFuncties.Name = "cmbFuncties"
        Me.cmbFuncties.Size = New System.Drawing.Size(142, 21)
        Me.cmbFuncties.TabIndex = 14
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(386, 33)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(45, 13)
        Me.Label60.TabIndex = 143
        Me.Label60.Text = "Functie:"
        '
        'chkBOM
        '
        Me.chkBOM.AutoSize = True
        Me.chkBOM.Location = New System.Drawing.Point(21, 133)
        Me.chkBOM.Name = "chkBOM"
        Me.chkBOM.Size = New System.Drawing.Size(113, 17)
        Me.chkBOM.TabIndex = 5
        Me.chkBOM.Text = "(BOM) Lid van MC"
        Me.chkBOM.UseVisualStyleBackColor = True
        '
        'utdFloPen
        '
        Me.utdFloPen.Location = New System.Drawing.Point(212, 142)
        Me.utdFloPen.Name = "utdFloPen"
        Me.utdFloPen.Size = New System.Drawing.Size(152, 27)
        Me.utdFloPen.TabIndex = 12
        Me.utdFloPen.Value = ""
        '
        'chkZilver
        '
        Me.chkZilver.AutoSize = True
        Me.chkZilver.Location = New System.Drawing.Point(21, 156)
        Me.chkZilver.Name = "chkZilver"
        Me.chkZilver.Size = New System.Drawing.Size(52, 17)
        Me.chkZilver.TabIndex = 6
        Me.chkZilver.Text = "Zilver"
        Me.chkZilver.UseVisualStyleBackColor = True
        '
        'chkGoud
        '
        Me.chkGoud.AutoSize = True
        Me.chkGoud.Location = New System.Drawing.Point(21, 179)
        Me.chkGoud.Name = "chkGoud"
        Me.chkGoud.Size = New System.Drawing.Size(52, 17)
        Me.chkGoud.TabIndex = 7
        Me.chkGoud.Text = "Goud"
        Me.chkGoud.UseVisualStyleBackColor = True
        '
        'chkNato
        '
        Me.chkNato.AutoSize = True
        Me.chkNato.Location = New System.Drawing.Point(21, 87)
        Me.chkNato.Name = "chkNato"
        Me.chkNato.Size = New System.Drawing.Size(114, 17)
        Me.chkNato.TabIndex = 3
        Me.chkNato.Text = "Gevaarlijke stoffen"
        Me.chkNato.UseVisualStyleBackColor = True
        '
        'cmbRang
        '
        Me.cmbRang.FormattingEnabled = True
        Me.cmbRang.Location = New System.Drawing.Point(212, 117)
        Me.cmbRang.Name = "cmbRang"
        Me.cmbRang.Size = New System.Drawing.Size(152, 21)
        Me.cmbRang.TabIndex = 11
        '
        'cmbKMonderdeel
        '
        Me.cmbKMonderdeel.FormattingEnabled = True
        Me.cmbKMonderdeel.Location = New System.Drawing.Point(212, 90)
        Me.cmbKMonderdeel.Name = "cmbKMonderdeel"
        Me.cmbKMonderdeel.Size = New System.Drawing.Size(152, 21)
        Me.cmbKMonderdeel.TabIndex = 10
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(161, 120)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(36, 13)
        Me.Label23.TabIndex = 127
        Me.Label23.Text = "Rang:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(161, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 126
        Me.Label20.Text = "Kmdeel:"
        '
        'chkVeteraan
        '
        Me.chkVeteraan.AutoSize = True
        Me.chkVeteraan.Location = New System.Drawing.Point(21, 110)
        Me.chkVeteraan.Name = "chkVeteraan"
        Me.chkVeteraan.Size = New System.Drawing.Size(69, 17)
        Me.chkVeteraan.TabIndex = 4
        Me.chkVeteraan.Text = "Veteraan"
        Me.chkVeteraan.UseVisualStyleBackColor = True
        '
        'chkLid_natres
        '
        Me.chkLid_natres.AutoSize = True
        Me.chkLid_natres.Location = New System.Drawing.Point(21, 64)
        Me.chkLid_natres.Name = "chkLid_natres"
        Me.chkLid_natres.Size = New System.Drawing.Size(68, 17)
        Me.chkLid_natres.TabIndex = 2
        Me.chkLid_natres.Text = "lid natres"
        Me.chkLid_natres.UseVisualStyleBackColor = True
        '
        'chkKerstkaart
        '
        Me.chkKerstkaart.AutoSize = True
        Me.chkKerstkaart.Location = New System.Drawing.Point(21, 42)
        Me.chkKerstkaart.Name = "chkKerstkaart"
        Me.chkKerstkaart.Size = New System.Drawing.Size(73, 17)
        Me.chkKerstkaart.TabIndex = 1
        Me.chkKerstkaart.Text = "kerstkaart"
        Me.chkKerstkaart.UseVisualStyleBackColor = True
        '
        'chkALV
        '
        Me.chkALV.AutoSize = True
        Me.chkALV.Location = New System.Drawing.Point(21, 19)
        Me.chkALV.Name = "chkALV"
        Me.chkALV.Size = New System.Drawing.Size(38, 17)
        Me.chkALV.TabIndex = 0
        Me.chkALV.Text = "av"
        Me.chkALV.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(161, 147)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(45, 13)
        Me.Label39.TabIndex = 119
        Me.Label39.Text = "Flo pen:"
        '
        'cmbBond
        '
        Me.cmbBond.FormattingEnabled = True
        Me.cmbBond.Location = New System.Drawing.Point(212, 30)
        Me.cmbBond.Name = "cmbBond"
        Me.cmbBond.Size = New System.Drawing.Size(152, 21)
        Me.cmbBond.TabIndex = 8
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(161, 33)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 13)
        Me.Label25.TabIndex = 116
        Me.Label25.Text = "Bond:"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(626, 56)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(106, 23)
        Me.btnSearch.TabIndex = 117
        Me.btnSearch.Text = "&Zoeken"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(626, 131)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(106, 23)
        Me.btnReset.TabIndex = 119
        Me.btnReset.Text = "Wis &Resultaten"
        Me.ToolTip1.SetToolTip(Me.btnReset, "Alle selecties en resultaten verwijderen.")
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 267)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(944, 23)
        Me.ProgressBar.TabIndex = 121
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblAantal)
        Me.GroupBox3.Controls.Add(Me.label1)
        Me.GroupBox3.Controls.Add(Me.lblStatus)
        Me.GroupBox3.Location = New System.Drawing.Point(627, 177)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(329, 78)
        Me.GroupBox3.TabIndex = 122
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status"
        '
        'lblAantal
        '
        Me.lblAantal.AutoSize = True
        Me.lblAantal.Location = New System.Drawing.Point(104, 22)
        Me.lblAantal.Name = "lblAantal"
        Me.lblAantal.Size = New System.Drawing.Size(13, 13)
        Me.lblAantal.TabIndex = 125
        Me.lblAantal.Text = "0"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(91, 13)
        Me.label1.TabIndex = 124
        Me.label1.Text = "Aantal gevonden:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(7, 38)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Status"
        '
        'CurrentTimer
        '
        Me.CurrentTimer.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(678, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Briefsoort:"
        '
        'dgvLeden
        '
        Me.dgvLeden.AllowUserToOrderColumns = True
        Me.dgvLeden.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        Me.dgvLeden.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLeden.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLeden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeden.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLeden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLeden.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Lidnr, Me.rnr, Me.vnaam, Me.achternaam, Me.init, Me.tussenvoegsel, Me.FullAddress, Me.huisnr, Me.huisnrtv, Me.Postcode, Me.plaats, Me.afdeling, Me.email, Me.geboortedatum, Me.telefoonnummer, Me.mobiel, Me.InDatum, Me.id})
        Me.dgvLeden.ContextMenuStrip = Me.ContextRelatie
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLeden.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLeden.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLeden.Location = New System.Drawing.Point(12, 296)
        Me.dgvLeden.Name = "dgvLeden"
        Me.dgvLeden.RightToLeft = System.Windows.Forms.RightToLeft.No
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLeden.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvLeden.RowHeadersVisible = False
        Me.dgvLeden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLeden.Size = New System.Drawing.Size(954, 425)
        Me.dgvLeden.TabIndex = 131
        '
        'Lidnr
        '
        Me.Lidnr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Lidnr.DataPropertyName = "Lidnr"
        Me.Lidnr.FillWeight = 200.0!
        Me.Lidnr.HeaderText = "medewerker"
        Me.Lidnr.MinimumWidth = 100
        Me.Lidnr.Name = "Lidnr"
        '
        'rnr
        '
        Me.rnr.DataPropertyName = "rnr"
        Me.rnr.HeaderText = "rnr"
        Me.rnr.Name = "rnr"
        Me.rnr.Width = 44
        '
        'vnaam
        '
        Me.vnaam.DataPropertyName = "titelachter"
        Me.vnaam.HeaderText = "vnaam"
        Me.vnaam.Name = "vnaam"
        Me.vnaam.Width = 64
        '
        'achternaam
        '
        Me.achternaam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.achternaam.DataPropertyName = "achternaam"
        Me.achternaam.HeaderText = "Naam"
        Me.achternaam.Name = "achternaam"
        Me.achternaam.Width = 60
        '
        'init
        '
        Me.init.DataPropertyName = "init"
        Me.init.HeaderText = "init"
        Me.init.Name = "init"
        Me.init.Width = 45
        '
        'tussenvoegsel
        '
        Me.tussenvoegsel.DataPropertyName = "tussenvoegsel"
        Me.tussenvoegsel.FillWeight = 50.0!
        Me.tussenvoegsel.HeaderText = "tussenv."
        Me.tussenvoegsel.Name = "tussenvoegsel"
        Me.tussenvoegsel.Width = 72
        '
        'FullAddress
        '
        Me.FullAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FullAddress.DataPropertyName = "adres"
        Me.FullAddress.HeaderText = "Adres"
        Me.FullAddress.Name = "FullAddress"
        Me.FullAddress.Width = 59
        '
        'huisnr
        '
        Me.huisnr.DataPropertyName = "huisnr"
        Me.huisnr.HeaderText = "huisnr"
        Me.huisnr.Name = "huisnr"
        Me.huisnr.Width = 60
        '
        'huisnrtv
        '
        Me.huisnrtv.DataPropertyName = "huisnrtv"
        Me.huisnrtv.HeaderText = "huisnrtv"
        Me.huisnrtv.Name = "huisnrtv"
        Me.huisnrtv.Width = 69
        '
        'Postcode
        '
        Me.Postcode.DataPropertyName = "Postcode"
        Me.Postcode.HeaderText = "Postcode"
        Me.Postcode.Name = "Postcode"
        Me.Postcode.Width = 77
        '
        'plaats
        '
        Me.plaats.DataPropertyName = "plaats"
        Me.plaats.HeaderText = "Plaats"
        Me.plaats.Name = "plaats"
        Me.plaats.Width = 61
        '
        'afdeling
        '
        Me.afdeling.DataPropertyName = "afdelingnaam"
        Me.afdeling.HeaderText = "afdeling"
        Me.afdeling.Name = "afdeling"
        Me.afdeling.Width = 69
        '
        'email
        '
        Me.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.email.DataPropertyName = "email"
        Me.email.HeaderText = "Email"
        Me.email.Name = "email"
        Me.email.Width = 57
        '
        'geboortedatum
        '
        Me.geboortedatum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.geboortedatum.DataPropertyName = "geboortedatum"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.Format = "dd-MM-yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.geboortedatum.DefaultCellStyle = DataGridViewCellStyle3
        Me.geboortedatum.HeaderText = "geboortedatum"
        Me.geboortedatum.Name = "geboortedatum"
        Me.geboortedatum.Width = 103
        '
        'telefoonnummer
        '
        Me.telefoonnummer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.telefoonnummer.DataPropertyName = "telefoonnummer"
        Me.telefoonnummer.HeaderText = "telefoonnummer"
        Me.telefoonnummer.Name = "telefoonnummer"
        Me.telefoonnummer.Width = 107
        '
        'mobiel
        '
        Me.mobiel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.mobiel.DataPropertyName = "mobiel"
        Me.mobiel.HeaderText = "mobiel"
        Me.mobiel.Name = "mobiel"
        Me.mobiel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mobiel.Width = 62
        '
        'InDatum
        '
        Me.InDatum.DataPropertyName = "InDatum"
        Me.InDatum.HeaderText = "InDatum"
        Me.InDatum.Name = "InDatum"
        Me.InDatum.Width = 72
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        Me.id.Width = 40
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(978, 25)
        Me.ToolStrip1.TabIndex = 132
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "home.ico")
        Me.ImageList1.Images.SetKeyName(1, "home_zw.ico")
        '
        'tvBrieven
        '
        Me.tvBrieven.Location = New System.Drawing.Point(738, 37)
        Me.tvBrieven.Name = "tvBrieven"
        Me.tvBrieven.Size = New System.Drawing.Size(218, 117)
        Me.tvBrieven.TabIndex = 134
        Me.ToolTip1.SetToolTip(Me.tvBrieven, "dubbelklik op de brief om verwerking te starten.")
        '
        'chkAddSearch
        '
        Me.chkAddSearch.AutoSize = True
        Me.chkAddSearch.Location = New System.Drawing.Point(637, 83)
        Me.chkAddSearch.Name = "chkAddSearch"
        Me.chkAddSearch.Size = New System.Drawing.Size(81, 17)
        Me.chkAddSearch.TabIndex = 135
        Me.chkAddSearch.Text = "Toevoegen"
        Me.ToolTip1.SetToolTip(Me.chkAddSearch, "Zet aan om nieuwe resultaten toe te voegen aan de huidige resultaat.")
        Me.chkAddSearch.UseVisualStyleBackColor = True
        '
        'btnResetSearch
        '
        Me.btnResetSearch.Location = New System.Drawing.Point(626, 106)
        Me.btnResetSearch.Name = "btnResetSearch"
        Me.btnResetSearch.Size = New System.Drawing.Size(106, 23)
        Me.btnResetSearch.TabIndex = 136
        Me.btnResetSearch.Text = "Wis &Criteria"
        Me.ToolTip1.SetToolTip(Me.btnResetSearch, "Alleen selecties verwijderen.")
        Me.btnResetSearch.UseVisualStyleBackColor = True
        '
        'chkWriteCorrespondetie
        '
        Me.chkWriteCorrespondetie.AutoSize = True
        Me.chkWriteCorrespondetie.Location = New System.Drawing.Point(738, 160)
        Me.chkWriteCorrespondetie.Name = "chkWriteCorrespondetie"
        Me.chkWriteCorrespondetie.Size = New System.Drawing.Size(181, 17)
        Me.chkWriteCorrespondetie.TabIndex = 137
        Me.chkWriteCorrespondetie.Text = "Toevoegen aan correspondentie"
        Me.chkWriteCorrespondetie.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Lidnr"
        Me.DataGridViewTextBoxColumn1.FillWeight = 200.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Lidnr"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "init"
        Me.DataGridViewTextBoxColumn2.FillWeight = 200.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "init"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "tussenvoegsel"
        Me.DataGridViewTextBoxColumn3.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "tussenv."
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "achternaam"
        Me.DataGridViewTextBoxColumn4.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Naam"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "adres"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Adres"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "huisnr"
        Me.DataGridViewTextBoxColumn6.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "huisnr"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "huisnrtv"
        Me.DataGridViewTextBoxColumn7.HeaderText = "huisnrtv"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Postcode"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Postcode"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 77
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "plaats"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Plaats"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 61
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "email"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "geboortedatum"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle6.Format = "dd-MM-yyyy"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn11.HeaderText = "geboortedatum"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "telefoonnummer"
        Me.DataGridViewTextBoxColumn12.HeaderText = "telefoonnummer"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "mobiel"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle7.Format = "dd-MM-yyyy"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn13.HeaderText = "mobiel"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "telefoonnummer"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle8.Format = "dd-MM-yyyy"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn14.HeaderText = "telefoonnummer"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "mobiel"
        Me.DataGridViewTextBoxColumn15.HeaderText = "mobiel"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "mobiel"
        Me.DataGridViewTextBoxColumn16.HeaderText = "mobiel"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn17.HeaderText = "id"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 40
        '
        'frmMailing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 721)
        Me.Controls.Add(Me.chkWriteCorrespondetie)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgvLeden)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkAddSearch)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.btnResetSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tvBrieven)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMailing"
        Me.Text = "Mailing"
        Me.ContextRelatie.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvLeden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkVeteraan As System.Windows.Forms.CheckBox
    Friend WithEvents chkLid_natres As System.Windows.Forms.CheckBox
    Friend WithEvents chkKerstkaart As System.Windows.Forms.CheckBox
    Friend WithEvents chkALV As System.Windows.Forms.CheckBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cmbBond As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbRang As System.Windows.Forms.ComboBox
    Friend WithEvents cmbKMonderdeel As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents CurrentTimer As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextRelatie As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenRelatieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkNato As System.Windows.Forms.CheckBox
    Friend WithEvents dgvLeden As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkZilver As System.Windows.Forms.CheckBox
    Friend WithEvents chkGoud As System.Windows.Forms.CheckBox
    Friend WithEvents utdFloPen As RelatieApp.ucTextDate
    Friend WithEvents chkBOM As System.Windows.Forms.CheckBox
    Friend WithEvents cmbFuncties As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbOrgaan As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbAfdeling As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents utdFunctie As RelatieApp.ucTextDate
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAdvies As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbPlaatsing As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkM_NSK As System.Windows.Forms.CheckBox
    Friend WithEvents cmbLidAfdeling As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tvBrieven As System.Windows.Forms.TreeView
    Friend WithEvents lblAantal As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents chkAddSearch As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnResetSearch As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbIBBGroep As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnSql As System.Windows.Forms.Button
    Friend WithEvents chkWriteCorrespondetie As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents Lidnr As DataGridViewTextBoxColumn
    Friend WithEvents rnr As DataGridViewTextBoxColumn
    Friend WithEvents vnaam As DataGridViewTextBoxColumn
    Friend WithEvents achternaam As DataGridViewTextBoxColumn
    Friend WithEvents init As DataGridViewTextBoxColumn
    Friend WithEvents tussenvoegsel As DataGridViewTextBoxColumn
    Friend WithEvents FullAddress As DataGridViewTextBoxColumn
    Friend WithEvents huisnr As DataGridViewTextBoxColumn
    Friend WithEvents huisnrtv As DataGridViewTextBoxColumn
    Friend WithEvents Postcode As DataGridViewTextBoxColumn
    Friend WithEvents plaats As DataGridViewTextBoxColumn
    Friend WithEvents afdeling As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents geboortedatum As DataGridViewTextBoxColumn
    Friend WithEvents telefoonnummer As DataGridViewTextBoxColumn
    Friend WithEvents mobiel As DataGridViewTextBoxColumn
    Friend WithEvents InDatum As DataGridViewTextBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents chkDienjaar As CheckBox
End Class
