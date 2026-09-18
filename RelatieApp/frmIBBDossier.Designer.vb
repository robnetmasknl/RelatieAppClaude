<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIBBDossier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIBBDossier))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpRegister = New System.Windows.Forms.GroupBox()
        Me.lblHiddenId = New System.Windows.Forms.Label()
        Me.btnSearchDossier = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tbMoederDossier = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbRubriek = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRegistratienr = New System.Windows.Forms.Label()
        Me.cmbBehandelaar = New System.Windows.Forms.ComboBox()
        Me.lblLidNr = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbCreateDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRelatienaam = New System.Windows.Forms.Label()
        Me.tbMut_door = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.uctdEndDate = New RelatieApp.ucTextDate()
        Me.tbAfgehandeld = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkAfgehandeld = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbOnderwerp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbDossiernr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabJdTypes = New System.Windows.Forms.TabPage()
        Me.wbBody = New System.Windows.Forms.WebBrowser()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.btnSearchMail = New System.Windows.Forms.Button()
        Me.tbSearchMail = New System.Windows.Forms.TextBox()
        Me.lblNotitie = New System.Windows.Forms.Label()
        Me.btnLegenda = New System.Windows.Forms.Button()
        Me.lblvIBBFasesDisabled = New System.Windows.Forms.Label()
        Me.btnShowAll = New System.Windows.Forms.Button()
        Me.lbDocs = New System.Windows.Forms.Label()
        Me.lvIBBDocuments = New System.Windows.Forms.ListView()
        Me.cntxDocuments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintTool = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmDeleteDoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnderwerpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetCatdevToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlauwToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OranjeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaarsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoodToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RozeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BruinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OlijfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WijzigFaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.lvIBBFases = New System.Windows.Forms.ListView()
        Me.cntxPhases = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmPhaseDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ULabel3 = New RelatieApp.uLabel()
        Me.tbNotities = New System.Windows.Forms.TextBox()
        Me.TabGriffie = New System.Windows.Forms.TabPage()
        Me.grpGriffie = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbGriffieDetails = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.uctdPaymentDate = New RelatieApp.ucTextDate()
        Me.cmbTypes = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnGriffieSave = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnGriffieNew = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkGriffiePaid = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbGriffieAmount = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.uctdRepaidClientDate = New RelatieApp.ucTextDate()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.uctdRepaidGriffieDate = New RelatieApp.ucTextDate()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.uctdGriffieDate = New RelatieApp.ucTextDate()
        Me.tbGriffieTotal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvGriffieKosten = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Paid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepaidGriffieDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepaidClientDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ULabel4 = New RelatieApp.uLabel()
        Me.TabProces = New System.Windows.Forms.TabPage()
        Me.ULabel5 = New RelatieApp.uLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tbProcessDetails = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.uctdProcessReceived = New RelatieApp.ucTextDate()
        Me.cmbProcessFase = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnProcessSave = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnProcessNew = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tbProcessAmount = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.uctdProcessLetter = New RelatieApp.ucTextDate()
        Me.dgvProcessKosten = New System.Windows.Forms.DataGridView()
        Me.pcId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcLetterDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabExtern = New System.Windows.Forms.TabPage()
        Me.ULabel6 = New RelatieApp.uLabel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.tbExternDetails = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbExternFases = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.btnExternSave = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnExternNew = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tbExternAmount = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.uctdExternPaid = New RelatieApp.ucTextDate()
        Me.dgvExterneKosten = New System.Windows.Forms.DataGridView()
        Me.extId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.extAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtDatePaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lvExternDocumenten = New System.Windows.Forms.ListView()
        Me.btnAddExternDoc = New System.Windows.Forms.Button()
        Me.TabDossier = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbOpmerkingen = New System.Windows.Forms.TextBox()
        Me.ULabel7 = New RelatieApp.uLabel()
        Me.TabCorrespondentie = New System.Windows.Forms.TabPage()
        Me.dgvIbbDocuments = New System.Windows.Forms.DataGridView()
        Me.cntxCorrespondentie = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveConcept = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintCorrespondentie = New System.Windows.Forms.ToolStripMenuItem()
        Me.ULabel1 = New RelatieApp.uLabel()
        Me.ofFile = New System.Windows.Forms.OpenFileDialog()
        Me.fbdSave = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCurrentPhase = New System.Windows.Forms.Label()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbChanges = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbOpenLid = New System.Windows.Forms.ToolStripButton()
        Me.tsbSearchDoc = New System.Windows.Forms.ToolStripButton()
        Me.tsbUpdateAppointments = New System.Windows.Forms.ToolStripButton()
        Me.tsbHelp = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbIBBGroep = New System.Windows.Forms.ComboBox()
        Me.rbKlacht = New System.Windows.Forms.RadioButton()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.rbJuridisch = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
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
        Me.grpRegister.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabJdTypes.SuspendLayout()
        Me.cntxDocuments.SuspendLayout()
        Me.cntxPhases.SuspendLayout()
        Me.TabGriffie.SuspendLayout()
        Me.grpGriffie.SuspendLayout()
        CType(Me.dgvGriffieKosten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabProces.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvProcessKosten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabExtern.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvExterneKosten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDossier.SuspendLayout()
        Me.TabCorrespondentie.SuspendLayout()
        CType(Me.dgvIbbDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cntxCorrespondentie.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRegister
        '
        Me.grpRegister.Controls.Add(Me.lblHiddenId)
        Me.grpRegister.Controls.Add(Me.btnSearchDossier)
        Me.grpRegister.Controls.Add(Me.tbMoederDossier)
        Me.grpRegister.Controls.Add(Me.Label14)
        Me.grpRegister.Controls.Add(Me.cmbRubriek)
        Me.grpRegister.Controls.Add(Me.Label9)
        Me.grpRegister.Controls.Add(Me.lblRegistratienr)
        Me.grpRegister.Controls.Add(Me.cmbBehandelaar)
        Me.grpRegister.Controls.Add(Me.lblLidNr)
        Me.grpRegister.Controls.Add(Me.Label8)
        Me.grpRegister.Controls.Add(Me.tbCreateDate)
        Me.grpRegister.Controls.Add(Me.Label1)
        Me.grpRegister.Controls.Add(Me.lblRelatienaam)
        Me.grpRegister.Controls.Add(Me.tbMut_door)
        Me.grpRegister.Controls.Add(Me.Label37)
        Me.grpRegister.Controls.Add(Me.Label13)
        Me.grpRegister.Controls.Add(Me.Label11)
        Me.grpRegister.Controls.Add(Me.Label2)
        Me.grpRegister.Location = New System.Drawing.Point(8, 28)
        Me.grpRegister.Name = "grpRegister"
        Me.grpRegister.Size = New System.Drawing.Size(968, 67)
        Me.grpRegister.TabIndex = 68
        Me.grpRegister.TabStop = False
        '
        'lblHiddenId
        '
        Me.lblHiddenId.AutoSize = True
        Me.lblHiddenId.Location = New System.Drawing.Point(885, 41)
        Me.lblHiddenId.Name = "lblHiddenId"
        Me.lblHiddenId.Size = New System.Drawing.Size(0, 13)
        Me.lblHiddenId.TabIndex = 98
        '
        'btnSearchDossier
        '
        Me.btnSearchDossier.ImageIndex = 4
        Me.btnSearchDossier.ImageList = Me.ImageList1
        Me.btnSearchDossier.Location = New System.Drawing.Point(851, 36)
        Me.btnSearchDossier.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSearchDossier.Name = "btnSearchDossier"
        Me.btnSearchDossier.Size = New System.Drawing.Size(24, 22)
        Me.btnSearchDossier.TabIndex = 97
        Me.btnSearchDossier.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "search.ico")
        Me.ImageList1.Images.SetKeyName(1, "+.ico")
        Me.ImageList1.Images.SetKeyName(2, "ok.ico")
        Me.ImageList1.Images.SetKeyName(3, "mail.ico")
        Me.ImageList1.Images.SetKeyName(4, "find.ico")
        Me.ImageList1.Images.SetKeyName(5, "email.ico")
        Me.ImageList1.Images.SetKeyName(6, "folder.ico")
        Me.ImageList1.Images.SetKeyName(7, "flag blue.ico")
        Me.ImageList1.Images.SetKeyName(8, "flag red.ico")
        Me.ImageList1.Images.SetKeyName(9, "flag yellow.ico")
        Me.ImageList1.Images.SetKeyName(10, "ungroup.ico")
        '
        'tbMoederDossier
        '
        Me.tbMoederDossier.Enabled = False
        Me.tbMoederDossier.Location = New System.Drawing.Point(726, 38)
        Me.tbMoederDossier.Name = "tbMoederDossier"
        Me.tbMoederDossier.Size = New System.Drawing.Size(118, 20)
        Me.tbMoederDossier.TabIndex = 96
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(637, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "Moederdossier:"
        '
        'cmbRubriek
        '
        Me.cmbRubriek.FormattingEnabled = True
        Me.cmbRubriek.Location = New System.Drawing.Point(480, 35)
        Me.cmbRubriek.Name = "cmbRubriek"
        Me.cmbRubriek.Size = New System.Drawing.Size(151, 21)
        Me.cmbRubriek.TabIndex = 91
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(409, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Rubriek:"
        '
        'lblRegistratienr
        '
        Me.lblRegistratienr.AutoSize = True
        Me.lblRegistratienr.Location = New System.Drawing.Point(257, 38)
        Me.lblRegistratienr.Name = "lblRegistratienr"
        Me.lblRegistratienr.Size = New System.Drawing.Size(66, 13)
        Me.lblRegistratienr.TabIndex = 77
        Me.lblRegistratienr.Text = "Registratienr"
        '
        'cmbBehandelaar
        '
        Me.cmbBehandelaar.FormattingEnabled = True
        Me.cmbBehandelaar.Location = New System.Drawing.Point(480, 13)
        Me.cmbBehandelaar.Name = "cmbBehandelaar"
        Me.cmbBehandelaar.Size = New System.Drawing.Size(151, 21)
        Me.cmbBehandelaar.TabIndex = 89
        '
        'lblLidNr
        '
        Me.lblLidNr.AutoSize = True
        Me.lblLidNr.Location = New System.Drawing.Point(86, 38)
        Me.lblLidNr.Name = "lblLidNr"
        Me.lblLidNr.Size = New System.Drawing.Size(32, 13)
        Me.lblLidNr.TabIndex = 76
        Me.lblLidNr.Text = "LidNr"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(409, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Behandelaar:"
        '
        'tbCreateDate
        '
        Me.tbCreateDate.Location = New System.Drawing.Point(726, 13)
        Me.tbCreateDate.Name = "tbCreateDate"
        Me.tbCreateDate.Size = New System.Drawing.Size(118, 20)
        Me.tbCreateDate.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Dossier van:"
        '
        'lblRelatienaam
        '
        Me.lblRelatienaam.AutoSize = True
        Me.lblRelatienaam.Location = New System.Drawing.Point(86, 16)
        Me.lblRelatienaam.Name = "lblRelatienaam"
        Me.lblRelatienaam.Size = New System.Drawing.Size(13, 13)
        Me.lblRelatienaam.TabIndex = 73
        Me.lblRelatienaam.Text = ".."
        '
        'tbMut_door
        '
        Me.tbMut_door.Enabled = False
        Me.tbMut_door.Location = New System.Drawing.Point(885, 13)
        Me.tbMut_door.Name = "tbMut_door"
        Me.tbMut_door.Size = New System.Drawing.Size(63, 20)
        Me.tbMut_door.TabIndex = 72
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(850, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(31, 13)
        Me.Label37.TabIndex = 71
        Me.Label37.Text = "door:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(637, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Aanmaakdatum:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(182, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Registratienr."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Werknemernr:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.uctdEndDate)
        Me.GroupBox1.Controls.Add(Me.tbAfgehandeld)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.chkAfgehandeld)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.tbOnderwerp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbDossiernr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(968, 82)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        '
        'uctdEndDate
        '
        Me.uctdEndDate.Location = New System.Drawing.Point(296, 13)
        Me.uctdEndDate.Name = "uctdEndDate"
        Me.uctdEndDate.Size = New System.Drawing.Size(130, 27)
        Me.uctdEndDate.TabIndex = 95
        Me.uctdEndDate.Value = ""
        '
        'tbAfgehandeld
        '
        Me.tbAfgehandeld.Location = New System.Drawing.Point(539, 20)
        Me.tbAfgehandeld.Name = "tbAfgehandeld"
        Me.tbAfgehandeld.Size = New System.Drawing.Size(423, 20)
        Me.tbAfgehandeld.TabIndex = 94
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(432, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 13)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "Reden afgehandeld:"
        '
        'chkAfgehandeld
        '
        Me.chkAfgehandeld.AutoSize = True
        Me.chkAfgehandeld.Location = New System.Drawing.Point(275, 21)
        Me.chkAfgehandeld.Name = "chkAfgehandeld"
        Me.chkAfgehandeld.Size = New System.Drawing.Size(15, 14)
        Me.chkAfgehandeld.TabIndex = 92
        Me.chkAfgehandeld.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(199, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "Afgehandeld:"
        '
        'tbOnderwerp
        '
        Me.tbOnderwerp.Location = New System.Drawing.Point(89, 53)
        Me.tbOnderwerp.Name = "tbOnderwerp"
        Me.tbOnderwerp.Size = New System.Drawing.Size(859, 20)
        Me.tbOnderwerp.TabIndex = 83
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Onderwerp:"
        '
        'tbDossiernr
        '
        Me.tbDossiernr.Location = New System.Drawing.Point(89, 19)
        Me.tbDossiernr.Name = "tbDossiernr"
        Me.tbDossiernr.Size = New System.Drawing.Size(98, 20)
        Me.tbDossiernr.TabIndex = 81
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Dossiernr.:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabJdTypes)
        Me.TabControl1.Controls.Add(Me.TabGriffie)
        Me.TabControl1.Controls.Add(Me.TabProces)
        Me.TabControl1.Controls.Add(Me.TabExtern)
        Me.TabControl1.Controls.Add(Me.TabDossier)
        Me.TabControl1.Controls.Add(Me.TabCorrespondentie)
        Me.TabControl1.Location = New System.Drawing.Point(0, 261)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1184, 495)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 84
        '
        'TabJdTypes
        '
        Me.TabJdTypes.AutoScroll = True
        Me.TabJdTypes.Controls.Add(Me.wbBody)
        Me.TabJdTypes.Controls.Add(Me.Label41)
        Me.TabJdTypes.Controls.Add(Me.btnSearchMail)
        Me.TabJdTypes.Controls.Add(Me.tbSearchMail)
        Me.TabJdTypes.Controls.Add(Me.lblNotitie)
        Me.TabJdTypes.Controls.Add(Me.btnLegenda)
        Me.TabJdTypes.Controls.Add(Me.lblvIBBFasesDisabled)
        Me.TabJdTypes.Controls.Add(Me.btnShowAll)
        Me.TabJdTypes.Controls.Add(Me.lbDocs)
        Me.TabJdTypes.Controls.Add(Me.lvIBBDocuments)
        Me.TabJdTypes.Controls.Add(Me.Label6)
        Me.TabJdTypes.Controls.Add(Me.btnProcess)
        Me.TabJdTypes.Controls.Add(Me.lvIBBFases)
        Me.TabJdTypes.Controls.Add(Me.ULabel3)
        Me.TabJdTypes.Controls.Add(Me.tbNotities)
        Me.TabJdTypes.Location = New System.Drawing.Point(4, 22)
        Me.TabJdTypes.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabJdTypes.Name = "TabJdTypes"
        Me.TabJdTypes.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabJdTypes.Size = New System.Drawing.Size(1176, 469)
        Me.TabJdTypes.TabIndex = 3
        Me.TabJdTypes.Text = "Juridisch"
        Me.TabJdTypes.UseVisualStyleBackColor = True
        '
        'wbBody
        '
        Me.wbBody.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.wbBody.Location = New System.Drawing.Point(801, 90)
        Me.wbBody.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbBody.Name = "wbBody"
        Me.wbBody.ScrollBarsEnabled = False
        Me.wbBody.Size = New System.Drawing.Size(367, 334)
        Me.wbBody.TabIndex = 106
        Me.wbBody.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(516, 38)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(93, 13)
        Me.Label41.TabIndex = 107
        Me.Label41.Text = "Zoek tekst in mail:"
        '
        'btnSearchMail
        '
        Me.btnSearchMail.ImageIndex = 4
        Me.btnSearchMail.ImageList = Me.ImageList1
        Me.btnSearchMail.Location = New System.Drawing.Point(768, 33)
        Me.btnSearchMail.Name = "btnSearchMail"
        Me.btnSearchMail.Size = New System.Drawing.Size(27, 23)
        Me.btnSearchMail.TabIndex = 104
        Me.ToolTip1.SetToolTip(Me.btnSearchMail, "Legenda classificatie")
        Me.btnSearchMail.UseVisualStyleBackColor = True
        '
        'tbSearchMail
        '
        Me.tbSearchMail.Location = New System.Drawing.Point(615, 35)
        Me.tbSearchMail.Name = "tbSearchMail"
        Me.tbSearchMail.Size = New System.Drawing.Size(149, 20)
        Me.tbSearchMail.TabIndex = 103
        '
        'lblNotitie
        '
        Me.lblNotitie.AutoSize = True
        Me.lblNotitie.Location = New System.Drawing.Point(829, 66)
        Me.lblNotitie.Name = "lblNotitie"
        Me.lblNotitie.Size = New System.Drawing.Size(42, 13)
        Me.lblNotitie.TabIndex = 102
        Me.lblNotitie.Text = "Notities"
        '
        'btnLegenda
        '
        Me.btnLegenda.ImageIndex = 10
        Me.btnLegenda.ImageList = Me.ImageList1
        Me.btnLegenda.Location = New System.Drawing.Point(559, 61)
        Me.btnLegenda.Name = "btnLegenda"
        Me.btnLegenda.Size = New System.Drawing.Size(27, 23)
        Me.btnLegenda.TabIndex = 100
        Me.ToolTip1.SetToolTip(Me.btnLegenda, "Legenda classificatie")
        Me.btnLegenda.UseVisualStyleBackColor = True
        '
        'lblvIBBFasesDisabled
        '
        Me.lblvIBBFasesDisabled.AutoSize = True
        Me.lblvIBBFasesDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvIBBFasesDisabled.Location = New System.Drawing.Point(10, 42)
        Me.lblvIBBFasesDisabled.Name = "lblvIBBFasesDisabled"
        Me.lblvIBBFasesDisabled.Size = New System.Drawing.Size(23, 13)
        Me.lblvIBBFasesDisabled.TabIndex = 99
        Me.lblvIBBFasesDisabled.Text = "...."
        '
        'btnShowAll
        '
        Me.btnShowAll.Location = New System.Drawing.Point(592, 61)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.Size = New System.Drawing.Size(107, 23)
        Me.btnShowAll.TabIndex = 98
        Me.btnShowAll.Text = "Alle documenten"
        Me.btnShowAll.UseVisualStyleBackColor = True
        '
        'lbDocs
        '
        Me.lbDocs.AutoSize = True
        Me.lbDocs.Location = New System.Drawing.Point(387, 66)
        Me.lbDocs.Name = "lbDocs"
        Me.lbDocs.Size = New System.Drawing.Size(20, 13)
        Me.lbDocs.TabIndex = 97
        Me.lbDocs.Text = "bij "
        '
        'lvIBBDocuments
        '
        Me.lvIBBDocuments.AllowDrop = True
        Me.lvIBBDocuments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvIBBDocuments.ContextMenuStrip = Me.cntxDocuments
        Me.lvIBBDocuments.FullRowSelect = True
        Me.lvIBBDocuments.HideSelection = False
        Me.lvIBBDocuments.LargeImageList = Me.ImageList1
        Me.lvIBBDocuments.Location = New System.Drawing.Point(212, 90)
        Me.lvIBBDocuments.MultiSelect = False
        Me.lvIBBDocuments.Name = "lvIBBDocuments"
        Me.lvIBBDocuments.Size = New System.Drawing.Size(583, 334)
        Me.lvIBBDocuments.TabIndex = 96
        Me.lvIBBDocuments.UseCompatibleStateImageBehavior = False
        '
        'cntxDocuments
        '
        Me.cntxDocuments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintTool, Me.tsmDeleteDoc, Me.OnderwerpToolStripMenuItem, Me.SetCatdevToolStripMenuItem, Me.WijzigFaseToolStripMenuItem})
        Me.cntxDocuments.Name = "cntxDocuments"
        Me.cntxDocuments.Size = New System.Drawing.Size(207, 114)
        '
        'PrintTool
        '
        Me.PrintTool.Name = "PrintTool"
        Me.PrintTool.Size = New System.Drawing.Size(206, 22)
        Me.PrintTool.Text = "Print"
        '
        'tsmDeleteDoc
        '
        Me.tsmDeleteDoc.Name = "tsmDeleteDoc"
        Me.tsmDeleteDoc.Size = New System.Drawing.Size(206, 22)
        Me.tsmDeleteDoc.Text = "Verwijder"
        '
        'OnderwerpToolStripMenuItem
        '
        Me.OnderwerpToolStripMenuItem.Name = "OnderwerpToolStripMenuItem"
        Me.OnderwerpToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.OnderwerpToolStripMenuItem.Text = "Wijzig onderwerp\datum"
        '
        'SetCatdevToolStripMenuItem
        '
        Me.SetCatdevToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeelToolStripMenuItem, Me.GroenToolStripMenuItem, Me.BlauwToolStripMenuItem, Me.OranjeToolStripMenuItem, Me.PaarsToolStripMenuItem, Me.RoodToolStripMenuItem, Me.RozeToolStripMenuItem, Me.BruinToolStripMenuItem, Me.OlijfToolStripMenuItem, Me.GeenToolStripMenuItem})
        Me.SetCatdevToolStripMenuItem.Name = "SetCatdevToolStripMenuItem"
        Me.SetCatdevToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.SetCatdevToolStripMenuItem.Text = "Classificatie"
        '
        'GeelToolStripMenuItem
        '
        Me.GeelToolStripMenuItem.Name = "GeelToolStripMenuItem"
        Me.GeelToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.GeelToolStripMenuItem.Text = "Geel"
        '
        'GroenToolStripMenuItem
        '
        Me.GroenToolStripMenuItem.Name = "GroenToolStripMenuItem"
        Me.GroenToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.GroenToolStripMenuItem.Text = "Groen"
        '
        'BlauwToolStripMenuItem
        '
        Me.BlauwToolStripMenuItem.Name = "BlauwToolStripMenuItem"
        Me.BlauwToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.BlauwToolStripMenuItem.Text = "Blauw"
        '
        'OranjeToolStripMenuItem
        '
        Me.OranjeToolStripMenuItem.Name = "OranjeToolStripMenuItem"
        Me.OranjeToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.OranjeToolStripMenuItem.Text = "Oranje"
        '
        'PaarsToolStripMenuItem
        '
        Me.PaarsToolStripMenuItem.Name = "PaarsToolStripMenuItem"
        Me.PaarsToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.PaarsToolStripMenuItem.Text = "Paars"
        '
        'RoodToolStripMenuItem
        '
        Me.RoodToolStripMenuItem.Name = "RoodToolStripMenuItem"
        Me.RoodToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.RoodToolStripMenuItem.Text = "Rood"
        '
        'RozeToolStripMenuItem
        '
        Me.RozeToolStripMenuItem.Name = "RozeToolStripMenuItem"
        Me.RozeToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.RozeToolStripMenuItem.Text = "roze"
        '
        'BruinToolStripMenuItem
        '
        Me.BruinToolStripMenuItem.Name = "BruinToolStripMenuItem"
        Me.BruinToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.BruinToolStripMenuItem.Text = "Bruin"
        '
        'OlijfToolStripMenuItem
        '
        Me.OlijfToolStripMenuItem.Name = "OlijfToolStripMenuItem"
        Me.OlijfToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.OlijfToolStripMenuItem.Text = "Olijf"
        '
        'GeenToolStripMenuItem
        '
        Me.GeenToolStripMenuItem.Name = "GeenToolStripMenuItem"
        Me.GeenToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.GeenToolStripMenuItem.Text = "Geen"
        '
        'WijzigFaseToolStripMenuItem
        '
        Me.WijzigFaseToolStripMenuItem.Name = "WijzigFaseToolStripMenuItem"
        Me.WijzigFaseToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.WijzigFaseToolStripMenuItem.Text = "Wijzig Fase"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Documenten:"
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(705, 61)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(90, 23)
        Me.btnProcess.TabIndex = 95
        Me.btnProcess.Text = "Toevoegen"
        Me.ToolTip1.SetToolTip(Me.btnProcess, "U kunt ook drag & Drop gebruiken")
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'lvIBBFases
        '
        Me.lvIBBFases.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvIBBFases.ContextMenuStrip = Me.cntxPhases
        Me.lvIBBFases.HideSelection = False
        Me.lvIBBFases.Location = New System.Drawing.Point(14, 61)
        Me.lvIBBFases.Name = "lvIBBFases"
        Me.lvIBBFases.Size = New System.Drawing.Size(183, 363)
        Me.lvIBBFases.TabIndex = 93
        Me.lvIBBFases.UseCompatibleStateImageBehavior = False
        '
        'cntxPhases
        '
        Me.cntxPhases.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmPhaseDelete})
        Me.cntxPhases.Name = "cntxPhases"
        Me.cntxPhases.Size = New System.Drawing.Size(136, 26)
        '
        'tsmPhaseDelete
        '
        Me.tsmPhaseDelete.Name = "tsmPhaseDelete"
        Me.tsmPhaseDelete.Size = New System.Drawing.Size(135, 22)
        Me.tsmPhaseDelete.Text = "verwijderen"
        '
        'ULabel3
        '
        Me.ULabel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.ULabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ULabel3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ULabel3.Location = New System.Drawing.Point(0, 3)
        Me.ULabel3.Name = "ULabel3"
        Me.ULabel3.Size = New System.Drawing.Size(1176, 21)
        Me.ULabel3.TabIndex = 92
        Me.ULabel3.Text = "Juridische stappen"
        '
        'tbNotities
        '
        Me.tbNotities.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbNotities.Location = New System.Drawing.Point(832, 90)
        Me.tbNotities.Multiline = True
        Me.tbNotities.Name = "tbNotities"
        Me.tbNotities.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbNotities.Size = New System.Drawing.Size(236, 317)
        Me.tbNotities.TabIndex = 101
        '
        'TabGriffie
        '
        Me.TabGriffie.Controls.Add(Me.grpGriffie)
        Me.TabGriffie.Controls.Add(Me.tbGriffieTotal)
        Me.TabGriffie.Controls.Add(Me.Label15)
        Me.TabGriffie.Controls.Add(Me.dgvGriffieKosten)
        Me.TabGriffie.Controls.Add(Me.ULabel4)
        Me.TabGriffie.Location = New System.Drawing.Point(4, 22)
        Me.TabGriffie.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabGriffie.Name = "TabGriffie"
        Me.TabGriffie.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabGriffie.Size = New System.Drawing.Size(1176, 469)
        Me.TabGriffie.TabIndex = 4
        Me.TabGriffie.Text = "Griffiekosten"
        Me.TabGriffie.UseVisualStyleBackColor = True
        '
        'grpGriffie
        '
        Me.grpGriffie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpGriffie.Controls.Add(Me.Label25)
        Me.grpGriffie.Controls.Add(Me.tbGriffieDetails)
        Me.grpGriffie.Controls.Add(Me.Label24)
        Me.grpGriffie.Controls.Add(Me.uctdPaymentDate)
        Me.grpGriffie.Controls.Add(Me.cmbTypes)
        Me.grpGriffie.Controls.Add(Me.Label23)
        Me.grpGriffie.Controls.Add(Me.btnGriffieSave)
        Me.grpGriffie.Controls.Add(Me.Label22)
        Me.grpGriffie.Controls.Add(Me.btnGriffieNew)
        Me.grpGriffie.Controls.Add(Me.Label16)
        Me.grpGriffie.Controls.Add(Me.chkGriffiePaid)
        Me.grpGriffie.Controls.Add(Me.Label17)
        Me.grpGriffie.Controls.Add(Me.Label18)
        Me.grpGriffie.Controls.Add(Me.tbGriffieAmount)
        Me.grpGriffie.Controls.Add(Me.Label19)
        Me.grpGriffie.Controls.Add(Me.uctdRepaidClientDate)
        Me.grpGriffie.Controls.Add(Me.Label20)
        Me.grpGriffie.Controls.Add(Me.uctdRepaidGriffieDate)
        Me.grpGriffie.Controls.Add(Me.Label21)
        Me.grpGriffie.Controls.Add(Me.uctdGriffieDate)
        Me.grpGriffie.Location = New System.Drawing.Point(683, 60)
        Me.grpGriffie.Name = "grpGriffie"
        Me.grpGriffie.Size = New System.Drawing.Size(252, 324)
        Me.grpGriffie.TabIndex = 109
        Me.grpGriffie.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 246)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 13)
        Me.Label25.TabIndex = 117
        Me.Label25.Text = "Details:"
        '
        'tbGriffieDetails
        '
        Me.tbGriffieDetails.Location = New System.Drawing.Point(9, 262)
        Me.tbGriffieDetails.Name = "tbGriffieDetails"
        Me.tbGriffieDetails.Size = New System.Drawing.Size(208, 20)
        Me.tbGriffieDetails.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 127)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 13)
        Me.Label24.TabIndex = 114
        Me.Label24.Text = "Griffie betaald:"
        '
        'uctdPaymentDate
        '
        Me.uctdPaymentDate.Location = New System.Drawing.Point(87, 114)
        Me.uctdPaymentDate.Name = "uctdPaymentDate"
        Me.uctdPaymentDate.Size = New System.Drawing.Size(130, 27)
        Me.uctdPaymentDate.TabIndex = 3
        Me.uctdPaymentDate.Value = ""
        '
        'cmbTypes
        '
        Me.cmbTypes.FormattingEnabled = True
        Me.cmbTypes.Location = New System.Drawing.Point(87, 210)
        Me.cmbTypes.Name = "cmbTypes"
        Me.cmbTypes.Size = New System.Drawing.Size(132, 21)
        Me.cmbTypes.TabIndex = 6
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(173, 293)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(46, 13)
        Me.Label23.TabIndex = 112
        Me.Label23.Text = "Opslaan"
        '
        'btnGriffieSave
        '
        Me.btnGriffieSave.ImageIndex = 2
        Me.btnGriffieSave.ImageList = Me.ImageList1
        Me.btnGriffieSave.Location = New System.Drawing.Point(149, 288)
        Me.btnGriffieSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnGriffieSave.Name = "btnGriffieSave"
        Me.btnGriffieSave.Size = New System.Drawing.Size(24, 22)
        Me.btnGriffieSave.TabIndex = 8
        Me.btnGriffieSave.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(105, 293)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 110
        Me.Label22.Text = "Nieuw"
        '
        'btnGriffieNew
        '
        Me.btnGriffieNew.ImageIndex = 1
        Me.btnGriffieNew.ImageList = Me.ImageList1
        Me.btnGriffieNew.Location = New System.Drawing.Point(81, 288)
        Me.btnGriffieNew.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnGriffieNew.Name = "btnGriffieNew"
        Me.btnGriffieNew.Size = New System.Drawing.Size(24, 22)
        Me.btnGriffieNew.TabIndex = 109
        Me.btnGriffieNew.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 97
        Me.Label16.Text = "Datum:"
        '
        'chkGriffiePaid
        '
        Me.chkGriffiePaid.AutoSize = True
        Me.chkGriffiePaid.Location = New System.Drawing.Point(87, 94)
        Me.chkGriffiePaid.Name = "chkGriffiePaid"
        Me.chkGriffiePaid.Size = New System.Drawing.Size(15, 14)
        Me.chkGriffiePaid.TabIndex = 2
        Me.chkGriffiePaid.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 98
        Me.Label17.Text = "Bedrag:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 13)
        Me.Label18.TabIndex = 99
        Me.Label18.Text = "Cliënt betaald:"
        '
        'tbGriffieAmount
        '
        Me.tbGriffieAmount.Location = New System.Drawing.Point(87, 63)
        Me.tbGriffieAmount.Name = "tbGriffieAmount"
        Me.tbGriffieAmount.Size = New System.Drawing.Size(100, 20)
        Me.tbGriffieAmount.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 157)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 13)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "Griffie terug:"
        '
        'uctdRepaidClientDate
        '
        Me.uctdRepaidClientDate.Location = New System.Drawing.Point(87, 177)
        Me.uctdRepaidClientDate.Name = "uctdRepaidClientDate"
        Me.uctdRepaidClientDate.Size = New System.Drawing.Size(130, 27)
        Me.uctdRepaidClientDate.TabIndex = 5
        Me.uctdRepaidClientDate.Value = ""
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 186)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 101
        Me.Label20.Text = "Cliënt terug:"
        '
        'uctdRepaidGriffieDate
        '
        Me.uctdRepaidGriffieDate.Location = New System.Drawing.Point(87, 144)
        Me.uctdRepaidGriffieDate.Name = "uctdRepaidGriffieDate"
        Me.uctdRepaidGriffieDate.Size = New System.Drawing.Size(130, 27)
        Me.uctdRepaidGriffieDate.TabIndex = 4
        Me.uctdRepaidGriffieDate.Value = ""
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 216)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 13)
        Me.Label21.TabIndex = 102
        Me.Label21.Text = "Fase:"
        '
        'uctdGriffieDate
        '
        Me.uctdGriffieDate.Location = New System.Drawing.Point(87, 24)
        Me.uctdGriffieDate.Name = "uctdGriffieDate"
        Me.uctdGriffieDate.Size = New System.Drawing.Size(130, 27)
        Me.uctdGriffieDate.TabIndex = 0
        Me.uctdGriffieDate.Value = ""
        '
        'tbGriffieTotal
        '
        Me.tbGriffieTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGriffieTotal.Location = New System.Drawing.Point(818, 34)
        Me.tbGriffieTotal.Name = "tbGriffieTotal"
        Me.tbGriffieTotal.Size = New System.Drawing.Size(100, 20)
        Me.tbGriffieTotal.TabIndex = 96
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(681, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 13)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "Openstaande kosten:"
        '
        'dgvGriffieKosten
        '
        Me.dgvGriffieKosten.AllowUserToAddRows = False
        Me.dgvGriffieKosten.AllowUserToDeleteRows = False
        Me.dgvGriffieKosten.AllowUserToResizeColumns = False
        Me.dgvGriffieKosten.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        Me.dgvGriffieKosten.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGriffieKosten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvGriffieKosten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGriffieKosten.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Datum, Me.Amount, Me.Paid, Me.PaymentDate, Me.RepaidGriffieDate, Me.RepaidClientDate})
        Me.dgvGriffieKosten.Location = New System.Drawing.Point(13, 60)
        Me.dgvGriffieKosten.Name = "dgvGriffieKosten"
        Me.dgvGriffieKosten.ReadOnly = True
        Me.dgvGriffieKosten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGriffieKosten.Size = New System.Drawing.Size(644, 324)
        Me.dgvGriffieKosten.TabIndex = 94
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'Datum
        '
        Me.Datum.DataPropertyName = "GriffieDate"
        Me.Datum.HeaderText = "Datum"
        Me.Datum.Name = "Datum"
        Me.Datum.ReadOnly = True
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "Amount"
        Me.Amount.HeaderText = "Bedrag"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'Paid
        '
        Me.Paid.DataPropertyName = "Paid"
        Me.Paid.HeaderText = "Betaald"
        Me.Paid.Name = "Paid"
        Me.Paid.ReadOnly = True
        '
        'PaymentDate
        '
        Me.PaymentDate.DataPropertyName = "PaymentDate"
        Me.PaymentDate.HeaderText = "griffie betaald"
        Me.PaymentDate.Name = "PaymentDate"
        Me.PaymentDate.ReadOnly = True
        '
        'RepaidGriffieDate
        '
        Me.RepaidGriffieDate.DataPropertyName = "RepaidGriffieDate"
        Me.RepaidGriffieDate.HeaderText = "griffie terug"
        Me.RepaidGriffieDate.Name = "RepaidGriffieDate"
        Me.RepaidGriffieDate.ReadOnly = True
        '
        'RepaidClientDate
        '
        Me.RepaidClientDate.DataPropertyName = "RepaidClientDate"
        Me.RepaidClientDate.HeaderText = "Client terug"
        Me.RepaidClientDate.Name = "RepaidClientDate"
        Me.RepaidClientDate.ReadOnly = True
        Me.RepaidClientDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RepaidClientDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ULabel4
        '
        Me.ULabel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.ULabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ULabel4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ULabel4.Location = New System.Drawing.Point(0, 3)
        Me.ULabel4.Name = "ULabel4"
        Me.ULabel4.Size = New System.Drawing.Size(1176, 21)
        Me.ULabel4.TabIndex = 93
        Me.ULabel4.Text = "Griffiekosten"
        '
        'TabProces
        '
        Me.TabProces.Controls.Add(Me.ULabel5)
        Me.TabProces.Controls.Add(Me.GroupBox3)
        Me.TabProces.Controls.Add(Me.dgvProcessKosten)
        Me.TabProces.Location = New System.Drawing.Point(4, 22)
        Me.TabProces.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabProces.Name = "TabProces"
        Me.TabProces.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabProces.Size = New System.Drawing.Size(1176, 469)
        Me.TabProces.TabIndex = 5
        Me.TabProces.Text = "Proceskosten"
        Me.TabProces.UseVisualStyleBackColor = True
        '
        'ULabel5
        '
        Me.ULabel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.ULabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ULabel5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ULabel5.Location = New System.Drawing.Point(0, 3)
        Me.ULabel5.Name = "ULabel5"
        Me.ULabel5.Size = New System.Drawing.Size(1176, 21)
        Me.ULabel5.TabIndex = 114
        Me.ULabel5.Text = "Proceskosten"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.tbProcessDetails)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.uctdProcessReceived)
        Me.GroupBox3.Controls.Add(Me.cmbProcessFase)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.btnProcessSave)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.btnProcessNew)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.tbProcessAmount)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.uctdProcessLetter)
        Me.GroupBox3.Location = New System.Drawing.Point(683, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(252, 356)
        Me.GroupBox3.TabIndex = 113
        Me.GroupBox3.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(9, 143)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 13)
        Me.Label26.TabIndex = 117
        Me.Label26.Text = "Details:"
        '
        'tbProcessDetails
        '
        Me.tbProcessDetails.Location = New System.Drawing.Point(12, 159)
        Me.tbProcessDetails.MaxLength = 255
        Me.tbProcessDetails.Multiline = True
        Me.tbProcessDetails.Name = "tbProcessDetails"
        Me.tbProcessDetails.Size = New System.Drawing.Size(226, 107)
        Me.tbProcessDetails.TabIndex = 4
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 86)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(95, 13)
        Me.Label27.TabIndex = 114
        Me.Label27.Text = "Datum ontvangen:"
        '
        'uctdProcessReceived
        '
        Me.uctdProcessReceived.Location = New System.Drawing.Point(108, 81)
        Me.uctdProcessReceived.Name = "uctdProcessReceived"
        Me.uctdProcessReceived.Size = New System.Drawing.Size(130, 27)
        Me.uctdProcessReceived.TabIndex = 2
        Me.uctdProcessReceived.Value = ""
        '
        'cmbProcessFase
        '
        Me.cmbProcessFase.FormattingEnabled = True
        Me.cmbProcessFase.Location = New System.Drawing.Point(108, 114)
        Me.cmbProcessFase.Name = "cmbProcessFase"
        Me.cmbProcessFase.Size = New System.Drawing.Size(130, 21)
        Me.cmbProcessFase.TabIndex = 3
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(192, 284)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 112
        Me.Label28.Text = "Opslaan"
        '
        'btnProcessSave
        '
        Me.btnProcessSave.ImageIndex = 2
        Me.btnProcessSave.ImageList = Me.ImageList1
        Me.btnProcessSave.Location = New System.Drawing.Point(168, 279)
        Me.btnProcessSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnProcessSave.Name = "btnProcessSave"
        Me.btnProcessSave.Size = New System.Drawing.Size(24, 22)
        Me.btnProcessSave.TabIndex = 5
        Me.btnProcessSave.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(124, 284)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(37, 13)
        Me.Label29.TabIndex = 110
        Me.Label29.Text = "Nieuw"
        '
        'btnProcessNew
        '
        Me.btnProcessNew.ImageIndex = 1
        Me.btnProcessNew.ImageList = Me.ImageList1
        Me.btnProcessNew.Location = New System.Drawing.Point(100, 279)
        Me.btnProcessNew.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnProcessNew.Name = "btnProcessNew"
        Me.btnProcessNew.Size = New System.Drawing.Size(24, 22)
        Me.btnProcessNew.TabIndex = 6
        Me.btnProcessNew.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(9, 56)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(97, 13)
        Me.Label30.TabIndex = 97
        Me.Label30.Text = "Datum toekenning:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(9, 25)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(44, 13)
        Me.Label31.TabIndex = 98
        Me.Label31.Text = "Bedrag:"
        '
        'tbProcessAmount
        '
        Me.tbProcessAmount.Location = New System.Drawing.Point(108, 22)
        Me.tbProcessAmount.Name = "tbProcessAmount"
        Me.tbProcessAmount.Size = New System.Drawing.Size(100, 20)
        Me.tbProcessAmount.TabIndex = 0
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(9, 117)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(33, 13)
        Me.Label35.TabIndex = 102
        Me.Label35.Text = "Fase:"
        '
        'uctdProcessLetter
        '
        Me.uctdProcessLetter.Location = New System.Drawing.Point(108, 48)
        Me.uctdProcessLetter.Name = "uctdProcessLetter"
        Me.uctdProcessLetter.Size = New System.Drawing.Size(130, 27)
        Me.uctdProcessLetter.TabIndex = 1
        Me.uctdProcessLetter.Value = ""
        '
        'dgvProcessKosten
        '
        Me.dgvProcessKosten.AllowUserToAddRows = False
        Me.dgvProcessKosten.AllowUserToDeleteRows = False
        Me.dgvProcessKosten.AllowUserToResizeColumns = False
        Me.dgvProcessKosten.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue
        Me.dgvProcessKosten.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProcessKosten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvProcessKosten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcessKosten.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pcId, Me.pcAmount, Me.pcLetterDate, Me.pcReceived})
        Me.dgvProcessKosten.Location = New System.Drawing.Point(13, 49)
        Me.dgvProcessKosten.Name = "dgvProcessKosten"
        Me.dgvProcessKosten.ReadOnly = True
        Me.dgvProcessKosten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProcessKosten.Size = New System.Drawing.Size(644, 349)
        Me.dgvProcessKosten.TabIndex = 110
        '
        'pcId
        '
        Me.pcId.DataPropertyName = "Id"
        Me.pcId.HeaderText = "Id"
        Me.pcId.Name = "pcId"
        Me.pcId.ReadOnly = True
        Me.pcId.Visible = False
        '
        'pcAmount
        '
        Me.pcAmount.DataPropertyName = "Amount"
        Me.pcAmount.HeaderText = "Bedrag"
        Me.pcAmount.Name = "pcAmount"
        Me.pcAmount.ReadOnly = True
        '
        'pcLetterDate
        '
        Me.pcLetterDate.DataPropertyName = "DateLetter"
        Me.pcLetterDate.HeaderText = "Datum brief"
        Me.pcLetterDate.Name = "pcLetterDate"
        Me.pcLetterDate.ReadOnly = True
        '
        'pcReceived
        '
        Me.pcReceived.DataPropertyName = "DateReceived"
        Me.pcReceived.HeaderText = "Datum ontvangen"
        Me.pcReceived.Name = "pcReceived"
        Me.pcReceived.ReadOnly = True
        Me.pcReceived.Width = 125
        '
        'TabExtern
        '
        Me.TabExtern.Controls.Add(Me.ULabel6)
        Me.TabExtern.Controls.Add(Me.Label32)
        Me.TabExtern.Controls.Add(Me.tbExternDetails)
        Me.TabExtern.Controls.Add(Me.GroupBox4)
        Me.TabExtern.Controls.Add(Me.dgvExterneKosten)
        Me.TabExtern.Controls.Add(Me.lvExternDocumenten)
        Me.TabExtern.Controls.Add(Me.btnAddExternDoc)
        Me.TabExtern.Location = New System.Drawing.Point(4, 22)
        Me.TabExtern.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabExtern.Name = "TabExtern"
        Me.TabExtern.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabExtern.Size = New System.Drawing.Size(1176, 469)
        Me.TabExtern.TabIndex = 6
        Me.TabExtern.Text = "Externe deskundige"
        Me.TabExtern.UseVisualStyleBackColor = True
        '
        'ULabel6
        '
        Me.ULabel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.ULabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ULabel6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ULabel6.Location = New System.Drawing.Point(0, 3)
        Me.ULabel6.Name = "ULabel6"
        Me.ULabel6.Size = New System.Drawing.Size(1176, 21)
        Me.ULabel6.TabIndex = 120
        Me.ULabel6.Text = "Externe deskundige"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(613, 9)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(42, 13)
        Me.Label32.TabIndex = 119
        Me.Label32.Text = "Details:"
        '
        'tbExternDetails
        '
        Me.tbExternDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbExternDetails.Location = New System.Drawing.Point(598, 30)
        Me.tbExternDetails.MaxLength = 255
        Me.tbExternDetails.Multiline = True
        Me.tbExternDetails.Name = "tbExternDetails"
        Me.tbExternDetails.Size = New System.Drawing.Size(343, 204)
        Me.tbExternDetails.TabIndex = 118
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbExternFases)
        Me.GroupBox4.Controls.Add(Me.Label34)
        Me.GroupBox4.Controls.Add(Me.btnExternSave)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Controls.Add(Me.btnExternNew)
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.tbExternAmount)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.uctdExternPaid)
        Me.GroupBox4.Location = New System.Drawing.Point(337, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(242, 209)
        Me.GroupBox4.TabIndex = 115
        Me.GroupBox4.TabStop = False
        '
        'cmbExternFases
        '
        Me.cmbExternFases.FormattingEnabled = True
        Me.cmbExternFases.Location = New System.Drawing.Point(89, 81)
        Me.cmbExternFases.Name = "cmbExternFases"
        Me.cmbExternFases.Size = New System.Drawing.Size(130, 21)
        Me.cmbExternFases.TabIndex = 113
        Me.cmbExternFases.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(177, 113)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(46, 13)
        Me.Label34.TabIndex = 112
        Me.Label34.Text = "Opslaan"
        '
        'btnExternSave
        '
        Me.btnExternSave.ImageIndex = 2
        Me.btnExternSave.ImageList = Me.ImageList1
        Me.btnExternSave.Location = New System.Drawing.Point(153, 108)
        Me.btnExternSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnExternSave.Name = "btnExternSave"
        Me.btnExternSave.Size = New System.Drawing.Size(24, 22)
        Me.btnExternSave.TabIndex = 111
        Me.btnExternSave.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(113, 113)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(37, 13)
        Me.Label36.TabIndex = 110
        Me.Label36.Text = "Nieuw"
        '
        'btnExternNew
        '
        Me.btnExternNew.ImageIndex = 1
        Me.btnExternNew.ImageList = Me.ImageList1
        Me.btnExternNew.Location = New System.Drawing.Point(89, 108)
        Me.btnExternNew.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnExternNew.Name = "btnExternNew"
        Me.btnExternNew.Size = New System.Drawing.Size(24, 22)
        Me.btnExternNew.TabIndex = 109
        Me.btnExternNew.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(9, 56)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(41, 13)
        Me.Label38.TabIndex = 97
        Me.Label38.Text = "Datum:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(9, 25)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(44, 13)
        Me.Label39.TabIndex = 98
        Me.Label39.Text = "Bedrag:"
        '
        'tbExternAmount
        '
        Me.tbExternAmount.Location = New System.Drawing.Point(89, 22)
        Me.tbExternAmount.Name = "tbExternAmount"
        Me.tbExternAmount.Size = New System.Drawing.Size(100, 20)
        Me.tbExternAmount.TabIndex = 106
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(9, 84)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(33, 13)
        Me.Label40.TabIndex = 102
        Me.Label40.Text = "Fase:"
        Me.Label40.Visible = False
        '
        'uctdExternPaid
        '
        Me.uctdExternPaid.Location = New System.Drawing.Point(89, 48)
        Me.uctdExternPaid.Name = "uctdExternPaid"
        Me.uctdExternPaid.Size = New System.Drawing.Size(130, 27)
        Me.uctdExternPaid.TabIndex = 103
        Me.uctdExternPaid.Value = ""
        '
        'dgvExterneKosten
        '
        Me.dgvExterneKosten.AllowUserToAddRows = False
        Me.dgvExterneKosten.AllowUserToDeleteRows = False
        Me.dgvExterneKosten.AllowUserToResizeColumns = False
        Me.dgvExterneKosten.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue
        Me.dgvExterneKosten.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvExterneKosten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExterneKosten.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.extId, Me.extAmount, Me.ExtDatePaid})
        Me.dgvExterneKosten.Location = New System.Drawing.Point(13, 30)
        Me.dgvExterneKosten.MultiSelect = False
        Me.dgvExterneKosten.Name = "dgvExterneKosten"
        Me.dgvExterneKosten.ReadOnly = True
        Me.dgvExterneKosten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExterneKosten.Size = New System.Drawing.Size(308, 204)
        Me.dgvExterneKosten.TabIndex = 114
        '
        'extId
        '
        Me.extId.DataPropertyName = "Id"
        Me.extId.HeaderText = "Id"
        Me.extId.Name = "extId"
        Me.extId.ReadOnly = True
        Me.extId.Visible = False
        '
        'extAmount
        '
        Me.extAmount.DataPropertyName = "Amount"
        Me.extAmount.HeaderText = "Bedrag"
        Me.extAmount.Name = "extAmount"
        Me.extAmount.ReadOnly = True
        '
        'ExtDatePaid
        '
        Me.ExtDatePaid.DataPropertyName = "DatePaid"
        Me.ExtDatePaid.HeaderText = "Datum betaald"
        Me.ExtDatePaid.Name = "ExtDatePaid"
        Me.ExtDatePaid.ReadOnly = True
        Me.ExtDatePaid.Width = 120
        '
        'lvExternDocumenten
        '
        Me.lvExternDocumenten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvExternDocumenten.ContextMenuStrip = Me.cntxDocuments
        Me.lvExternDocumenten.HideSelection = False
        Me.lvExternDocumenten.Location = New System.Drawing.Point(13, 257)
        Me.lvExternDocumenten.MultiSelect = False
        Me.lvExternDocumenten.Name = "lvExternDocumenten"
        Me.lvExternDocumenten.Size = New System.Drawing.Size(566, 150)
        Me.lvExternDocumenten.TabIndex = 98
        Me.lvExternDocumenten.UseCompatibleStateImageBehavior = False
        '
        'btnAddExternDoc
        '
        Me.btnAddExternDoc.Location = New System.Drawing.Point(585, 257)
        Me.btnAddExternDoc.Name = "btnAddExternDoc"
        Me.btnAddExternDoc.Size = New System.Drawing.Size(90, 23)
        Me.btnAddExternDoc.TabIndex = 97
        Me.btnAddExternDoc.Text = "Toevoegen"
        Me.btnAddExternDoc.UseVisualStyleBackColor = True
        '
        'TabDossier
        '
        Me.TabDossier.BackColor = System.Drawing.Color.Transparent
        Me.TabDossier.Controls.Add(Me.Label5)
        Me.TabDossier.Controls.Add(Me.tbOpmerkingen)
        Me.TabDossier.Controls.Add(Me.ULabel7)
        Me.TabDossier.Location = New System.Drawing.Point(4, 22)
        Me.TabDossier.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabDossier.Name = "TabDossier"
        Me.TabDossier.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabDossier.Size = New System.Drawing.Size(1176, 469)
        Me.TabDossier.TabIndex = 0
        Me.TabDossier.Text = "Opmerkingen"
        Me.TabDossier.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Opmerkingen:"
        '
        'tbOpmerkingen
        '
        Me.tbOpmerkingen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbOpmerkingen.Location = New System.Drawing.Point(13, 56)
        Me.tbOpmerkingen.Multiline = True
        Me.tbOpmerkingen.Name = "tbOpmerkingen"
        Me.tbOpmerkingen.Size = New System.Drawing.Size(643, 227)
        Me.tbOpmerkingen.TabIndex = 92
        '
        'ULabel7
        '
        Me.ULabel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.ULabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ULabel7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ULabel7.Location = New System.Drawing.Point(0, 3)
        Me.ULabel7.Name = "ULabel7"
        Me.ULabel7.Size = New System.Drawing.Size(1176, 21)
        Me.ULabel7.TabIndex = 91
        Me.ULabel7.Text = "Opmerkingen"
        '
        'TabCorrespondentie
        '
        Me.TabCorrespondentie.BackColor = System.Drawing.Color.Transparent
        Me.TabCorrespondentie.Controls.Add(Me.dgvIbbDocuments)
        Me.TabCorrespondentie.Controls.Add(Me.ULabel1)
        Me.TabCorrespondentie.Location = New System.Drawing.Point(4, 22)
        Me.TabCorrespondentie.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabCorrespondentie.Name = "TabCorrespondentie"
        Me.TabCorrespondentie.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TabCorrespondentie.Size = New System.Drawing.Size(1176, 469)
        Me.TabCorrespondentie.TabIndex = 2
        Me.TabCorrespondentie.Text = "Correspondentie"
        Me.TabCorrespondentie.UseVisualStyleBackColor = True
        '
        'dgvIbbDocuments
        '
        Me.dgvIbbDocuments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvIbbDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIbbDocuments.ContextMenuStrip = Me.cntxCorrespondentie
        Me.dgvIbbDocuments.Location = New System.Drawing.Point(15, 48)
        Me.dgvIbbDocuments.MultiSelect = False
        Me.dgvIbbDocuments.Name = "dgvIbbDocuments"
        Me.dgvIbbDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIbbDocuments.Size = New System.Drawing.Size(710, 337)
        Me.dgvIbbDocuments.TabIndex = 96
        '
        'cntxCorrespondentie
        '
        Me.cntxCorrespondentie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveConcept, Me.PrintCorrespondentie})
        Me.cntxCorrespondentie.Name = "cntxDocuments"
        Me.cntxCorrespondentie.Size = New System.Drawing.Size(155, 48)
        '
        'RemoveConcept
        '
        Me.RemoveConcept.Name = "RemoveConcept"
        Me.RemoveConcept.Size = New System.Drawing.Size(154, 22)
        Me.RemoveConcept.Text = "Maak Definitief"
        '
        'PrintCorrespondentie
        '
        Me.PrintCorrespondentie.Name = "PrintCorrespondentie"
        Me.PrintCorrespondentie.Size = New System.Drawing.Size(154, 22)
        Me.PrintCorrespondentie.Text = "Print"
        '
        'ULabel1
        '
        Me.ULabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ULabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ULabel1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ULabel1.Location = New System.Drawing.Point(0, 3)
        Me.ULabel1.Name = "ULabel1"
        Me.ULabel1.Size = New System.Drawing.Size(1176, 21)
        Me.ULabel1.TabIndex = 92
        Me.ULabel1.Text = "Correspondentie"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblCurrentPhase)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 189)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(470, 49)
        Me.GroupBox2.TabIndex = 85
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Juridisch"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(87, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Fase in afwachting: "
        '
        'lblCurrentPhase
        '
        Me.lblCurrentPhase.AutoSize = True
        Me.lblCurrentPhase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPhase.Location = New System.Drawing.Point(206, 20)
        Me.lblCurrentPhase.Name = "lblCurrentPhase"
        Me.lblCurrentPhase.Size = New System.Drawing.Size(122, 13)
        Me.lblCurrentPhase.TabIndex = 83
        Me.lblCurrentPhase.Text = "Fase in afwachting: "
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'tsbChanges
        '
        Me.tsbChanges.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbChanges.Name = "tsbChanges"
        Me.tsbChanges.Size = New System.Drawing.Size(73, 22)
        Me.tsbChanges.Text = "Wijzigingen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.toolStripSeparator, Me.tsbChanges, Me.ToolStripSeparator3, Me.tsbOpenLid, Me.tsbSearchDoc, Me.tsbUpdateAppointments, Me.tsbHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 67
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbOpenLid
        '
        Me.tsbOpenLid.Image = Global.RelatieApp.My.Resources.Resource1.user
        Me.tsbOpenLid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpenLid.Name = "tsbOpenLid"
        Me.tsbOpenLid.Size = New System.Drawing.Size(112, 22)
        Me.tsbOpenLid.Text = "open ledenkaart"
        '
        'tsbSearchDoc
        '
        Me.tsbSearchDoc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSearchDoc.Name = "tsbSearchDoc"
        Me.tsbSearchDoc.Size = New System.Drawing.Size(108, 22)
        Me.tsbSearchDoc.Text = "Zoek documenten"
        '
        'tsbUpdateAppointments
        '
        Me.tsbUpdateAppointments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbUpdateAppointments.Image = CType(resources.GetObject("tsbUpdateAppointments.Image"), System.Drawing.Image)
        Me.tsbUpdateAppointments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbUpdateAppointments.Name = "tsbUpdateAppointments"
        Me.tsbUpdateAppointments.Size = New System.Drawing.Size(92, 22)
        Me.tsbUpdateAppointments.Text = "update outlook"
        '
        'tsbHelp
        '
        Me.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHelp.Image = Global.RelatieApp.My.Resources.Resource1.Question321
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(23, 22)
        Me.tsbHelp.Text = "Help"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbIBBGroep)
        Me.GroupBox5.Controls.Add(Me.rbKlacht)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Controls.Add(Me.rbJuridisch)
        Me.GroupBox5.Location = New System.Drawing.Point(502, 189)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(474, 49)
        Me.GroupBox5.TabIndex = 87
        Me.GroupBox5.TabStop = False
        '
        'cmbIBBGroep
        '
        Me.cmbIBBGroep.FormattingEnabled = True
        Me.cmbIBBGroep.Location = New System.Drawing.Point(240, 15)
        Me.cmbIBBGroep.Name = "cmbIBBGroep"
        Me.cmbIBBGroep.Size = New System.Drawing.Size(151, 21)
        Me.cmbIBBGroep.TabIndex = 98
        '
        'rbKlacht
        '
        Me.rbKlacht.AutoSize = True
        Me.rbKlacht.Location = New System.Drawing.Point(103, 16)
        Me.rbKlacht.Name = "rbKlacht"
        Me.rbKlacht.Size = New System.Drawing.Size(55, 17)
        Me.rbKlacht.TabIndex = 1
        Me.rbKlacht.TabStop = True
        Me.rbKlacht.Tag = "K"
        Me.rbKlacht.Text = "Klacht"
        Me.rbKlacht.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(204, 20)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(37, 13)
        Me.Label33.TabIndex = 97
        Me.Label33.Text = "groep:"
        '
        'rbJuridisch
        '
        Me.rbJuridisch.AutoSize = True
        Me.rbJuridisch.Checked = True
        Me.rbJuridisch.Location = New System.Drawing.Point(31, 16)
        Me.rbJuridisch.Name = "rbJuridisch"
        Me.rbJuridisch.Size = New System.Drawing.Size(66, 17)
        Me.rbJuridisch.TabIndex = 0
        Me.rbJuridisch.TabStop = True
        Me.rbJuridisch.Tag = "J"
        Me.rbJuridisch.Text = "Juridisch"
        Me.rbJuridisch.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CreateDate"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CreateDate"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Onderwerp"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Onderwerp"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Location"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Location"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "jdTypeId"
        Me.DataGridViewTextBoxColumn4.HeaderText = "jdTypeId"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "RepaidDate"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Terugbetaald"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "RepaidClientDate"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Client terug"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Amount"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Bedrag"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DateLetter"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Datum brief"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DateReceived"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Datum ontvangen"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 125
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Amount"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Bedrag"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "DatePaid"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Datum betaald"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 120
        '
        'frmIBBDossier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpRegister)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIBBDossier"
        Me.Text = "IBB Dossier"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.grpRegister.ResumeLayout(False)
        Me.grpRegister.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabJdTypes.ResumeLayout(False)
        Me.TabJdTypes.PerformLayout()
        Me.cntxDocuments.ResumeLayout(False)
        Me.cntxPhases.ResumeLayout(False)
        Me.TabGriffie.ResumeLayout(False)
        Me.TabGriffie.PerformLayout()
        Me.grpGriffie.ResumeLayout(False)
        Me.grpGriffie.PerformLayout()
        CType(Me.dgvGriffieKosten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabProces.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvProcessKosten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabExtern.ResumeLayout(False)
        Me.TabExtern.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvExterneKosten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDossier.ResumeLayout(False)
        Me.TabDossier.PerformLayout()
        Me.TabCorrespondentie.ResumeLayout(False)
        CType(Me.dgvIbbDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cntxCorrespondentie.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpRegister As System.Windows.Forms.GroupBox
    Friend WithEvents tbCreateDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRelatienaam As System.Windows.Forms.Label
    Friend WithEvents tbMut_door As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLidNr As System.Windows.Forms.Label
    Friend WithEvents lblRegistratienr As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbDossiernr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbOnderwerp As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabDossier As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbOpmerkingen As System.Windows.Forms.TextBox
    Friend WithEvents ULabel7 As RelatieApp.uLabel
    Friend WithEvents TabCorrespondentie As System.Windows.Forms.TabPage
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents ULabel1 As RelatieApp.uLabel
    Friend WithEvents ofFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents fbdSave As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbRubriek As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbBehandelaar As System.Windows.Forms.ComboBox
    Friend WithEvents tbAfgehandeld As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkAfgehandeld As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbMoederDossier As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvIbbDocuments As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearchDossier As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TabJdTypes As System.Windows.Forms.TabPage
    Friend WithEvents ULabel3 As RelatieApp.uLabel
    Friend WithEvents lvIBBFases As System.Windows.Forms.ListView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvIBBDocuments As System.Windows.Forms.ListView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbDocs As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbChanges As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnShowAll As System.Windows.Forms.Button
    Friend WithEvents lblvIBBFasesDisabled As System.Windows.Forms.Label
    Friend WithEvents tsbSearchDoc As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCurrentPhase As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabGriffie As System.Windows.Forms.TabPage
    Friend WithEvents ULabel4 As RelatieApp.uLabel
    Friend WithEvents tbGriffieTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents grpGriffie As System.Windows.Forms.GroupBox
    Friend WithEvents chkGriffiePaid As System.Windows.Forms.CheckBox
    Friend WithEvents tbGriffieAmount As System.Windows.Forms.TextBox
    Friend WithEvents uctdRepaidClientDate As RelatieApp.ucTextDate
    Friend WithEvents uctdRepaidGriffieDate As RelatieApp.ucTextDate
    Friend WithEvents uctdGriffieDate As RelatieApp.ucTextDate
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnGriffieSave As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnGriffieNew As System.Windows.Forms.Button
    Friend WithEvents cmbTypes As System.Windows.Forms.ComboBox
    Friend WithEvents dgvGriffieKosten As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents uctdPaymentDate As RelatieApp.ucTextDate
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Datum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Paid As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepaidGriffieDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepaidClientDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cntxDocuments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cntxCorrespondentie As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveConcept As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintCorrespondentie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblHiddenId As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tbGriffieDetails As System.Windows.Forms.TextBox
    Friend WithEvents TabProces As System.Windows.Forms.TabPage
    Friend WithEvents ULabel5 As RelatieApp.uLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents tbProcessDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents uctdProcessReceived As RelatieApp.ucTextDate
    Friend WithEvents cmbProcessFase As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnProcessSave As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnProcessNew As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents tbProcessAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents uctdProcessLetter As RelatieApp.ucTextDate
    Friend WithEvents dgvProcessKosten As System.Windows.Forms.DataGridView
    Friend WithEvents pcId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcLetterDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabExtern As System.Windows.Forms.TabPage
    Friend WithEvents lvExternDocumenten As System.Windows.Forms.ListView
    Friend WithEvents btnAddExternDoc As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbExternFases As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents btnExternSave As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnExternNew As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents tbExternAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents uctdExternPaid As RelatieApp.ucTextDate
    Friend WithEvents dgvExterneKosten As System.Windows.Forms.DataGridView
    Friend WithEvents extId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents extAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtDatePaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents tbExternDetails As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ULabel6 As RelatieApp.uLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbKlacht As System.Windows.Forms.RadioButton
    Friend WithEvents rbJuridisch As System.Windows.Forms.RadioButton
    Friend WithEvents tsbHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbUpdateAppointments As System.Windows.Forms.ToolStripButton
    Friend WithEvents uctdEndDate As RelatieApp.ucTextDate
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmbIBBGroep As System.Windows.Forms.ComboBox
    Friend WithEvents tsmDeleteDoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnderwerpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetCatdevToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlauwToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OranjeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaarsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RoodToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLegenda As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tsbOpenLid As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNotitie As System.Windows.Forms.Label
    Friend WithEvents tbNotities As System.Windows.Forms.TextBox
    Friend WithEvents RozeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BruinToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OlijfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cntxPhases As ContextMenuStrip
    Friend WithEvents tsmPhaseDelete As ToolStripMenuItem
    Friend WithEvents btnSearchMail As Button
    Friend WithEvents tbSearchMail As TextBox
    Friend WithEvents wbBody As WebBrowser
    Friend WithEvents Label41 As Label
    Friend WithEvents WijzigFaseToolStripMenuItem As ToolStripMenuItem
End Class
