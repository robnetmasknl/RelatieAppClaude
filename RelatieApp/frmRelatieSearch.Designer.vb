<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatieSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatieSearch))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbSearch = New System.Windows.Forms.Label()
        Me.tbZoekveld = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvLeden = New System.Windows.Forms.DataGridView()
        Me.Lidnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iban = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.achternaam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.init = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tussenvoegsel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.huisnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.huisnrtv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Postcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plaats = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.geboortedatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefoonnummer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mobiel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbAchternaam = New System.Windows.Forms.RadioButton()
        Me.rbLidNr = New System.Windows.Forms.RadioButton()
        Me.btOk = New System.Windows.Forms.Button()
        Me.tbHuisNr = New System.Windows.Forms.TextBox()
        Me.lbPC = New System.Windows.Forms.Label()
        Me.rbNaamPc = New System.Windows.Forms.RadioButton()
        Me.btNew = New System.Windows.Forms.Button()
        Me.rbRegNr = New System.Windows.Forms.RadioButton()
        Me.rbRekNr = New System.Windows.Forms.RadioButton()
        Me.rbPCHuisNr = New System.Windows.Forms.RadioButton()
        Me.grpAdmin = New System.Windows.Forms.GroupBox()
        Me.btnSignal = New System.Windows.Forms.Button()
        Me.tbLidId = New System.Windows.Forms.TextBox()
        Me.btnLidId = New System.Windows.Forms.Button()
        Me.cmbPlaats = New System.Windows.Forms.ComboBox()
        Me.rbPlaats = New System.Windows.Forms.RadioButton()
        Me.lbPlaats = New System.Windows.Forms.Label()
        Me.ssSearchMain = New System.Windows.Forms.StatusStrip()
        Me.tssSearch1 = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvLeden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAdmin.SuspendLayout()
        Me.ssSearchMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbSearch
        '
        Me.lbSearch.AutoSize = True
        Me.lbSearch.Location = New System.Drawing.Point(14, 15)
        Me.lbSearch.Name = "lbSearch"
        Me.lbSearch.Size = New System.Drawing.Size(55, 13)
        Me.lbSearch.TabIndex = 14
        Me.lbSearch.Text = "Zoekveld:"
        '
        'tbZoekveld
        '
        Me.tbZoekveld.Location = New System.Drawing.Point(84, 12)
        Me.tbZoekveld.Name = "tbZoekveld"
        Me.tbZoekveld.Size = New System.Drawing.Size(173, 20)
        Me.tbZoekveld.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.ImageIndex = 0
        Me.btnSearch.ImageList = Me.ImageList1
        Me.btnSearch.Location = New System.Drawing.Point(606, 15)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Zoek"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "search.ico")
        Me.ImageList1.Images.SetKeyName(1, "+.ico")
        Me.ImageList1.Images.SetKeyName(2, "ok.ico")
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
        Me.dgvLeden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLeden.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Lidnr, Me.rnr, Me.iban, Me.achternaam, Me.init, Me.tussenvoegsel, Me.FullAddress, Me.huisnr, Me.huisnrtv, Me.Postcode, Me.plaats, Me.email, Me.geboortedatum, Me.telefoonnummer, Me.mobiel, Me.vn, Me.id})
        Me.dgvLeden.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLeden.Location = New System.Drawing.Point(12, 142)
        Me.dgvLeden.MultiSelect = False
        Me.dgvLeden.Name = "dgvLeden"
        Me.dgvLeden.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLeden.RowHeadersVisible = False
        Me.dgvLeden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLeden.Size = New System.Drawing.Size(984, 443)
        Me.dgvLeden.TabIndex = 11
        '
        'Lidnr
        '
        Me.Lidnr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Lidnr.DataPropertyName = "Lidnr"
        Me.Lidnr.FillWeight = 200.0!
        Me.Lidnr.HeaderText = "Lidnr"
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
        'iban
        '
        Me.iban.DataPropertyName = "iban"
        Me.iban.HeaderText = "iban"
        Me.iban.Name = "iban"
        Me.iban.Width = 52
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.Format = "dd-MM-yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.geboortedatum.DefaultCellStyle = DataGridViewCellStyle2
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
        'vn
        '
        Me.vn.DataPropertyName = "titelachter"
        Me.vn.HeaderText = "vn"
        Me.vn.Name = "vn"
        Me.vn.Width = 44
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        Me.id.Width = 40
        '
        'rbAchternaam
        '
        Me.rbAchternaam.AutoSize = True
        Me.rbAchternaam.Location = New System.Drawing.Point(263, 12)
        Me.rbAchternaam.Name = "rbAchternaam"
        Me.rbAchternaam.Size = New System.Drawing.Size(96, 17)
        Me.rbAchternaam.TabIndex = 2
        Me.rbAchternaam.TabStop = True
        Me.rbAchternaam.Text = "op achternaam"
        Me.rbAchternaam.UseVisualStyleBackColor = True
        '
        'rbLidNr
        '
        Me.rbLidNr.AutoSize = True
        Me.rbLidNr.Location = New System.Drawing.Point(419, 11)
        Me.rbLidNr.Name = "rbLidNr"
        Me.rbLidNr.Size = New System.Drawing.Size(101, 17)
        Me.rbLidNr.TabIndex = 6
        Me.rbLidNr.TabStop = True
        Me.rbLidNr.Text = "op werknemernr"
        Me.rbLidNr.UseVisualStyleBackColor = True
        '
        'btOk
        '
        Me.btOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOk.ImageIndex = 2
        Me.btOk.ImageList = Me.ImageList1
        Me.btOk.Location = New System.Drawing.Point(606, 66)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(75, 23)
        Me.btOk.TabIndex = 13
        Me.btOk.Text = "Ok"
        Me.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOk.UseVisualStyleBackColor = True
        Me.btOk.Visible = False
        '
        'tbHuisNr
        '
        Me.tbHuisNr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbHuisNr.Location = New System.Drawing.Point(84, 36)
        Me.tbHuisNr.MaxLength = 7
        Me.tbHuisNr.Name = "tbHuisNr"
        Me.tbHuisNr.Size = New System.Drawing.Size(173, 20)
        Me.tbHuisNr.TabIndex = 9
        Me.tbHuisNr.Visible = False
        '
        'lbPC
        '
        Me.lbPC.AutoSize = True
        Me.lbPC.Location = New System.Drawing.Point(14, 39)
        Me.lbPC.Name = "lbPC"
        Me.lbPC.Size = New System.Drawing.Size(38, 13)
        Me.lbPC.TabIndex = 15
        Me.lbPC.Text = "huisnr:"
        Me.lbPC.Visible = False
        '
        'rbNaamPc
        '
        Me.rbNaamPc.AutoSize = True
        Me.rbNaamPc.Location = New System.Drawing.Point(263, 30)
        Me.rbNaamPc.Name = "rbNaamPc"
        Me.rbNaamPc.Size = New System.Drawing.Size(145, 17)
        Me.rbNaamPc.TabIndex = 3
        Me.rbNaamPc.TabStop = True
        Me.rbNaamPc.Text = "op achternaam/postcode"
        Me.rbNaamPc.UseVisualStyleBackColor = True
        '
        'btNew
        '
        Me.btNew.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btNew.ImageIndex = 1
        Me.btNew.ImageList = Me.ImageList1
        Me.btNew.Location = New System.Drawing.Point(606, 40)
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(75, 23)
        Me.btNew.TabIndex = 12
        Me.btNew.Text = "Nieuw"
        Me.btNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btNew.UseVisualStyleBackColor = True
        '
        'rbRegNr
        '
        Me.rbRegNr.AutoSize = True
        Me.rbRegNr.Location = New System.Drawing.Point(419, 29)
        Me.rbRegNr.Name = "rbRegNr"
        Me.rbRegNr.Size = New System.Drawing.Size(95, 17)
        Me.rbRegNr.TabIndex = 7
        Me.rbRegNr.TabStop = True
        Me.rbRegNr.Text = "op reg.nummer"
        Me.rbRegNr.UseVisualStyleBackColor = True
        '
        'rbRekNr
        '
        Me.rbRekNr.AutoSize = True
        Me.rbRekNr.Location = New System.Drawing.Point(419, 47)
        Me.rbRekNr.Name = "rbRekNr"
        Me.rbRekNr.Size = New System.Drawing.Size(60, 17)
        Me.rbRekNr.TabIndex = 8
        Me.rbRekNr.Text = "op iban"
        Me.rbRekNr.UseVisualStyleBackColor = False
        '
        'rbPCHuisNr
        '
        Me.rbPCHuisNr.AutoSize = True
        Me.rbPCHuisNr.Location = New System.Drawing.Point(263, 48)
        Me.rbPCHuisNr.Name = "rbPCHuisNr"
        Me.rbPCHuisNr.Size = New System.Drawing.Size(117, 17)
        Me.rbPCHuisNr.TabIndex = 4
        Me.rbPCHuisNr.TabStop = True
        Me.rbPCHuisNr.Text = "op postcode/huisnr"
        Me.rbPCHuisNr.UseVisualStyleBackColor = True
        '
        'grpAdmin
        '
        Me.grpAdmin.Controls.Add(Me.btnSignal)
        Me.grpAdmin.Controls.Add(Me.tbLidId)
        Me.grpAdmin.Controls.Add(Me.btnLidId)
        Me.grpAdmin.Location = New System.Drawing.Point(735, 32)
        Me.grpAdmin.Name = "grpAdmin"
        Me.grpAdmin.Size = New System.Drawing.Size(200, 80)
        Me.grpAdmin.TabIndex = 18
        Me.grpAdmin.TabStop = False
        Me.grpAdmin.Text = "admin"
        '
        'btnSignal
        '
        Me.btnSignal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSignal.ImageIndex = 0
        Me.btnSignal.ImageList = Me.ImageList1
        Me.btnSignal.Location = New System.Drawing.Point(104, 15)
        Me.btnSignal.Name = "btnSignal"
        Me.btnSignal.Size = New System.Drawing.Size(75, 23)
        Me.btnSignal.TabIndex = 15
        Me.btnSignal.Text = "signalering"
        Me.btnSignal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSignal.UseVisualStyleBackColor = True
        '
        'tbLidId
        '
        Me.tbLidId.Location = New System.Drawing.Point(6, 45)
        Me.tbLidId.Name = "tbLidId"
        Me.tbLidId.Size = New System.Drawing.Size(173, 20)
        Me.tbLidId.TabIndex = 14
        '
        'btnLidId
        '
        Me.btnLidId.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLidId.ImageIndex = 0
        Me.btnLidId.ImageList = Me.ImageList1
        Me.btnLidId.Location = New System.Drawing.Point(6, 16)
        Me.btnLidId.Name = "btnLidId"
        Me.btnLidId.Size = New System.Drawing.Size(75, 23)
        Me.btnLidId.TabIndex = 0
        Me.btnLidId.Text = "Zoek"
        Me.btnLidId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLidId.UseVisualStyleBackColor = True
        '
        'cmbPlaats
        '
        Me.cmbPlaats.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPlaats.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlaats.DropDownWidth = 150
        Me.cmbPlaats.FormattingEnabled = True
        Me.cmbPlaats.Location = New System.Drawing.Point(84, 62)
        Me.cmbPlaats.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbPlaats.Name = "cmbPlaats"
        Me.cmbPlaats.Size = New System.Drawing.Size(172, 21)
        Me.cmbPlaats.TabIndex = 10
        Me.cmbPlaats.Visible = False
        '
        'rbPlaats
        '
        Me.rbPlaats.AutoSize = True
        Me.rbPlaats.Location = New System.Drawing.Point(263, 66)
        Me.rbPlaats.Name = "rbPlaats"
        Me.rbPlaats.Size = New System.Drawing.Size(68, 17)
        Me.rbPlaats.TabIndex = 5
        Me.rbPlaats.TabStop = True
        Me.rbPlaats.Text = "op plaats"
        Me.rbPlaats.UseVisualStyleBackColor = False
        '
        'lbPlaats
        '
        Me.lbPlaats.AutoSize = True
        Me.lbPlaats.Location = New System.Drawing.Point(14, 65)
        Me.lbPlaats.Name = "lbPlaats"
        Me.lbPlaats.Size = New System.Drawing.Size(39, 13)
        Me.lbPlaats.TabIndex = 16
        Me.lbPlaats.Text = "Plaats:"
        Me.lbPlaats.Visible = False
        '
        'ssSearchMain
        '
        Me.ssSearchMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssSearch1})
        Me.ssSearchMain.Location = New System.Drawing.Point(0, 589)
        Me.ssSearchMain.Name = "ssSearchMain"
        Me.ssSearchMain.Size = New System.Drawing.Size(1008, 22)
        Me.ssSearchMain.TabIndex = 0
        Me.ssSearchMain.Text = "StatusStrip1"
        '
        'tssSearch1
        '
        Me.tssSearch1.Name = "tssSearch1"
        Me.tssSearch1.Size = New System.Drawing.Size(52, 17)
        Me.tssSearch1.Text = "resultaat"
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
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FullName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Naam"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "FullAddress"
        Me.DataGridViewTextBoxColumn3.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Adres"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Postcode"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Postcode"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "email"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "geboortedatum"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle3.Format = "dd-MM-yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn6.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "geboortedatum"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "telefoonnummer"
        Me.DataGridViewTextBoxColumn7.HeaderText = "telefoonnummer"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "mobiel"
        Me.DataGridViewTextBoxColumn8.HeaderText = "mobiel"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "email"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "geboortedatum"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle4.Format = "dd-MM-yyyy"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn10.HeaderText = "geboortedatum"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "telefoonnummer"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle5.Format = "dd-MM-yyyy"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn11.HeaderText = "telefoonnummer"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "mobiel"
        Me.DataGridViewTextBoxColumn12.HeaderText = "mobiel"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "mobiel"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle6.Format = "dd-MM-yyyy"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn13.HeaderText = "mobiel"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "telefoonnummer"
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
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn16.HeaderText = "id"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 40
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "email"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "geboortedatum"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle7.Format = "dd-MM-yyyy"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn18.HeaderText = "geboortedatum"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "telefoonnummer"
        Me.DataGridViewTextBoxColumn19.HeaderText = "telefoonnummer"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "mobiel"
        Me.DataGridViewTextBoxColumn20.HeaderText = "mobiel"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'frmRelatieSearch
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 611)
        Me.Controls.Add(Me.ssSearchMain)
        Me.Controls.Add(Me.lbPlaats)
        Me.Controls.Add(Me.rbPlaats)
        Me.Controls.Add(Me.cmbPlaats)
        Me.Controls.Add(Me.grpAdmin)
        Me.Controls.Add(Me.rbPCHuisNr)
        Me.Controls.Add(Me.rbRekNr)
        Me.Controls.Add(Me.rbRegNr)
        Me.Controls.Add(Me.btNew)
        Me.Controls.Add(Me.rbNaamPc)
        Me.Controls.Add(Me.tbHuisNr)
        Me.Controls.Add(Me.lbPC)
        Me.Controls.Add(Me.btOk)
        Me.Controls.Add(Me.rbLidNr)
        Me.Controls.Add(Me.rbAchternaam)
        Me.Controls.Add(Me.dgvLeden)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.tbZoekveld)
        Me.Controls.Add(Me.lbSearch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRelatieSearch"
        Me.Text = "Relatie zoeken:"
        CType(Me.dgvLeden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAdmin.ResumeLayout(False)
        Me.grpAdmin.PerformLayout()
        Me.ssSearchMain.ResumeLayout(False)
        Me.ssSearchMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbSearch As System.Windows.Forms.Label
    Friend WithEvents tbZoekveld As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvLeden As System.Windows.Forms.DataGridView
    Friend WithEvents rbAchternaam As System.Windows.Forms.RadioButton
    Friend WithEvents rbLidNr As System.Windows.Forms.RadioButton
    Friend WithEvents btOk As System.Windows.Forms.Button
    Friend WithEvents tbHuisNr As System.Windows.Forms.TextBox
    Friend WithEvents lbPC As System.Windows.Forms.Label
    Friend WithEvents rbNaamPc As System.Windows.Forms.RadioButton
    Friend WithEvents btNew As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbRegNr As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbRekNr As System.Windows.Forms.RadioButton
    Friend WithEvents rbPCHuisNr As System.Windows.Forms.RadioButton
    Friend WithEvents grpAdmin As System.Windows.Forms.GroupBox
    Friend WithEvents tbLidId As System.Windows.Forms.TextBox
    Friend WithEvents btnLidId As System.Windows.Forms.Button
    Friend WithEvents cmbPlaats As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbPlaats As System.Windows.Forms.RadioButton
    Friend WithEvents lbPlaats As System.Windows.Forms.Label
    Friend WithEvents btnSignal As System.Windows.Forms.Button
    Friend WithEvents ssSearchMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tssSearch1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Lidnr As DataGridViewTextBoxColumn
    Friend WithEvents rnr As DataGridViewTextBoxColumn
    Friend WithEvents iban As DataGridViewTextBoxColumn
    Friend WithEvents achternaam As DataGridViewTextBoxColumn
    Friend WithEvents init As DataGridViewTextBoxColumn
    Friend WithEvents tussenvoegsel As DataGridViewTextBoxColumn
    Friend WithEvents FullAddress As DataGridViewTextBoxColumn
    Friend WithEvents huisnr As DataGridViewTextBoxColumn
    Friend WithEvents huisnrtv As DataGridViewTextBoxColumn
    Friend WithEvents Postcode As DataGridViewTextBoxColumn
    Friend WithEvents plaats As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents geboortedatum As DataGridViewTextBoxColumn
    Friend WithEvents telefoonnummer As DataGridViewTextBoxColumn
    Friend WithEvents mobiel As DataGridViewTextBoxColumn
    Friend WithEvents vn As DataGridViewTextBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
End Class
