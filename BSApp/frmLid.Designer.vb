<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLid
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLid))
        Me.lblLidNr = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.tbTelefoon = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbMobiel = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbWachtwoord = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CloseToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtBoekingDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbWord = New System.Windows.Forms.ToolStripButton()
        Me.lblBoeking_Message = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbLidNr = New System.Windows.Forms.TextBox()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbUnkown = New System.Windows.Forms.RadioButton()
        Me.rbWoman = New System.Windows.Forms.RadioButton()
        Me.rbMan = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.rbYes = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAchternaam = New System.Windows.Forms.TextBox()
        Me.tbInit = New System.Windows.Forms.TextBox()
        Me.tbTussenvoegsel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbAdres = New System.Windows.Forms.TextBox()
        Me.tbHuisNr = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbPostCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbPlaats = New System.Windows.Forms.TextBox()
        Me.tbHuisNrTv = New System.Windows.Forms.TextBox()
        Me.tbLand = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbBond = New System.Windows.Forms.ComboBox()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.btnPostcode = New System.Windows.Forms.Button()
        Me.tbEmail_b = New System.Windows.Forms.TextBox()
        Me.tbMobiel_b = New System.Windows.Forms.TextBox()
        Me.tbTelefoon_b = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gbConfirm = New System.Windows.Forms.GroupBox()
        Me.chkVerwerkt = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblmobileError = New System.Windows.Forms.Label()
        Me.ToolStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbConfirm.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblLidNr
        '
        Me.lblLidNr.AutoSize = True
        Me.lblLidNr.Location = New System.Drawing.Point(210, 37)
        Me.lblLidNr.Name = "lblLidNr"
        Me.lblLidNr.Size = New System.Drawing.Size(26, 13)
        Me.lblLidNr.TabIndex = 8
        Me.lblLidNr.Text = "lidnr"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "lidnr:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Geboortedatum:"
        '
        'dtpDOB
        '
        Me.dtpDOB.CustomFormat = "dd-MM-yyyy"
        Me.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDOB.Location = New System.Drawing.Point(213, 278)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Size = New System.Drawing.Size(211, 20)
        Me.dtpDOB.TabIndex = 13
        '
        'tbTelefoon
        '
        Me.tbTelefoon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbTelefoon.Location = New System.Drawing.Point(213, 199)
        Me.tbTelefoon.Name = "tbTelefoon"
        Me.tbTelefoon.ReadOnly = True
        Me.tbTelefoon.Size = New System.Drawing.Size(211, 20)
        Me.tbTelefoon.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Telefoonnummer:"
        '
        'tbMobiel
        '
        Me.tbMobiel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbMobiel.Location = New System.Drawing.Point(213, 225)
        Me.tbMobiel.Name = "tbMobiel"
        Me.tbMobiel.ReadOnly = True
        Me.tbMobiel.Size = New System.Drawing.Size(211, 20)
        Me.tbMobiel.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Mobiel:"
        '
        'tbWachtwoord
        '
        Me.tbWachtwoord.Location = New System.Drawing.Point(213, 304)
        Me.tbWachtwoord.Name = "tbWachtwoord"
        Me.tbWachtwoord.Size = New System.Drawing.Size(211, 20)
        Me.tbWachtwoord.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 311)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Wachtwoord:"
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.CloseToolStripButton, Me.SaveToolStripButton, Me.ToolStripSeparator1, Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.tsbtBoekingDelete, Me.tsbWord})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(899, 25)
        Me.ToolStrip.TabIndex = 26
        Me.ToolStrip.Text = "ToolStrip"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "Open"
        '
        'CloseToolStripButton
        '
        Me.CloseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CloseToolStripButton.Image = CType(resources.GetObject("CloseToolStripButton.Image"), System.Drawing.Image)
        Me.CloseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseToolStripButton.Name = "CloseToolStripButton"
        Me.CloseToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CloseToolStripButton.Text = "Sluiten (CTRL+C)"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "Opslaan (CTRL+S)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtBoekingDelete
        '
        Me.tsbtBoekingDelete.Image = Global.BSApp.My.Resources.Images.No
        Me.tsbtBoekingDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtBoekingDelete.Name = "tsbtBoekingDelete"
        Me.tsbtBoekingDelete.Size = New System.Drawing.Size(134, 22)
        Me.tsbtBoekingDelete.Text = "Boeking verwijderen"
        '
        'tsbWord
        '
        Me.tsbWord.Image = Global.BSApp.My.Resources.Images.icon_word
        Me.tsbWord.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbWord.Name = "tsbWord"
        Me.tsbWord.Size = New System.Drawing.Size(51, 22)
        Me.tsbWord.Text = "Brief"
        '
        'lblBoeking_Message
        '
        Me.lblBoeking_Message.AutoSize = True
        Me.lblBoeking_Message.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoeking_Message.Location = New System.Drawing.Point(210, 396)
        Me.lblBoeking_Message.Name = "lblBoeking_Message"
        Me.lblBoeking_Message.Size = New System.Drawing.Size(74, 20)
        Me.lblBoeking_Message.TabIndex = 31
        Me.lblBoeking_Message.Text = "Boeking"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.CloseToolStripMenuItem, Me.NewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(899, 24)
        Me.MenuStrip1.TabIndex = 32
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'tbLidNr
        '
        Me.tbLidNr.Location = New System.Drawing.Point(271, 37)
        Me.tbLidNr.Name = "tbLidNr"
        Me.tbLidNr.Size = New System.Drawing.Size(211, 20)
        Me.tbLidNr.TabIndex = 33
        Me.tbLidNr.Visible = False
        '
        'tbEmail
        '
        Me.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEmail.Location = New System.Drawing.Point(213, 251)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.ReadOnly = True
        Me.tbEmail.Size = New System.Drawing.Size(211, 20)
        Me.tbEmail.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Email:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(530, 295)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Verwerkt:"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 341)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Geslacht:"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbUnkown)
        Me.GroupBox1.Controls.Add(Me.rbWoman)
        Me.GroupBox1.Controls.Add(Me.rbMan)
        Me.GroupBox1.Location = New System.Drawing.Point(213, 324)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(211, 30)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'rbUnkown
        '
        Me.rbUnkown.AutoSize = True
        Me.rbUnkown.Location = New System.Drawing.Point(119, 9)
        Me.rbUnkown.Name = "rbUnkown"
        Me.rbUnkown.Size = New System.Drawing.Size(75, 17)
        Me.rbUnkown.TabIndex = 46
        Me.rbUnkown.Text = "Onbekend"
        Me.rbUnkown.UseVisualStyleBackColor = True
        '
        'rbWoman
        '
        Me.rbWoman.AutoSize = True
        Me.rbWoman.Location = New System.Drawing.Point(58, 9)
        Me.rbWoman.Name = "rbWoman"
        Me.rbWoman.Size = New System.Drawing.Size(55, 17)
        Me.rbWoman.TabIndex = 45
        Me.rbWoman.Text = "Vrouw"
        Me.rbWoman.UseVisualStyleBackColor = True
        '
        'rbMan
        '
        Me.rbMan.AutoSize = True
        Me.rbMan.Location = New System.Drawing.Point(12, 9)
        Me.rbMan.Name = "rbMan"
        Me.rbMan.Size = New System.Drawing.Size(46, 17)
        Me.rbMan.TabIndex = 44
        Me.rbMan.Text = "Man"
        Me.rbMan.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbNo)
        Me.GroupBox2.Controls.Add(Me.rbYes)
        Me.GroupBox2.Location = New System.Drawing.Point(522, 311)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(210, 28)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(57, 7)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(36, 17)
        Me.rbNo.TabIndex = 40
        Me.rbNo.Text = "Ja"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Location = New System.Drawing.Point(11, 7)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(45, 17)
        Me.rbYes.TabIndex = 39
        Me.rbYes.Text = "Nee"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Achternaam/Tussenvoegsel/Initalen:"
        '
        'tbAchternaam
        '
        Me.tbAchternaam.Location = New System.Drawing.Point(213, 65)
        Me.tbAchternaam.Name = "tbAchternaam"
        Me.tbAchternaam.Size = New System.Drawing.Size(211, 20)
        Me.tbAchternaam.TabIndex = 1
        '
        'tbInit
        '
        Me.tbInit.Location = New System.Drawing.Point(522, 65)
        Me.tbInit.Name = "tbInit"
        Me.tbInit.Size = New System.Drawing.Size(71, 20)
        Me.tbInit.TabIndex = 3
        '
        'tbTussenvoegsel
        '
        Me.tbTussenvoegsel.Location = New System.Drawing.Point(430, 65)
        Me.tbTussenvoegsel.Name = "tbTussenvoegsel"
        Me.tbTussenvoegsel.Size = New System.Drawing.Size(86, 20)
        Me.tbTussenvoegsel.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Straat/huisnr/Toevoeging:"
        '
        'tbAdres
        '
        Me.tbAdres.Location = New System.Drawing.Point(213, 92)
        Me.tbAdres.Name = "tbAdres"
        Me.tbAdres.Size = New System.Drawing.Size(211, 20)
        Me.tbAdres.TabIndex = 4
        '
        'tbHuisNr
        '
        Me.tbHuisNr.Location = New System.Drawing.Point(430, 92)
        Me.tbHuisNr.Name = "tbHuisNr"
        Me.tbHuisNr.Size = New System.Drawing.Size(86, 20)
        Me.tbHuisNr.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Postcode/Plaats:"
        '
        'tbPostCode
        '
        Me.tbPostCode.Location = New System.Drawing.Point(213, 118)
        Me.tbPostCode.Name = "tbPostCode"
        Me.tbPostCode.Size = New System.Drawing.Size(106, 20)
        Me.tbPostCode.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Land:"
        '
        'tbPlaats
        '
        Me.tbPlaats.Location = New System.Drawing.Point(325, 118)
        Me.tbPlaats.Name = "tbPlaats"
        Me.tbPlaats.Size = New System.Drawing.Size(268, 20)
        Me.tbPlaats.TabIndex = 8
        '
        'tbHuisNrTv
        '
        Me.tbHuisNrTv.Location = New System.Drawing.Point(522, 92)
        Me.tbHuisNrTv.Name = "tbHuisNrTv"
        Me.tbHuisNrTv.Size = New System.Drawing.Size(71, 20)
        Me.tbHuisNrTv.TabIndex = 6
        '
        'tbLand
        '
        Me.tbLand.Location = New System.Drawing.Point(213, 144)
        Me.tbLand.Name = "tbLand"
        Me.tbLand.Size = New System.Drawing.Size(380, 20)
        Me.tbLand.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 371)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Bond:"
        '
        'cmbBond
        '
        Me.cmbBond.FormattingEnabled = True
        Me.cmbBond.Location = New System.Drawing.Point(214, 362)
        Me.cmbBond.Name = "cmbBond"
        Me.cmbBond.Size = New System.Drawing.Size(210, 21)
        Me.cmbBond.TabIndex = 17
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "ledenkaart"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'btnPostcode
        '
        Me.btnPostcode.Location = New System.Drawing.Point(146, 115)
        Me.btnPostcode.Name = "btnPostcode"
        Me.btnPostcode.Size = New System.Drawing.Size(61, 23)
        Me.btnPostcode.TabIndex = 50
        Me.btnPostcode.Text = "Postcode"
        Me.btnPostcode.UseVisualStyleBackColor = True
        '
        'tbEmail_b
        '
        Me.tbEmail_b.Location = New System.Drawing.Point(430, 251)
        Me.tbEmail_b.Name = "tbEmail_b"
        Me.tbEmail_b.Size = New System.Drawing.Size(211, 20)
        Me.tbEmail_b.TabIndex = 53
        '
        'tbMobiel_b
        '
        Me.tbMobiel_b.Location = New System.Drawing.Point(430, 225)
        Me.tbMobiel_b.Name = "tbMobiel_b"
        Me.tbMobiel_b.Size = New System.Drawing.Size(211, 20)
        Me.tbMobiel_b.TabIndex = 52
        Me.ToolTip1.SetToolTip(Me.tbMobiel_b, "Mobielnummer verplicht")
        '
        'tbTelefoon_b
        '
        Me.tbTelefoon_b.Location = New System.Drawing.Point(430, 199)
        Me.tbTelefoon_b.Name = "tbTelefoon_b"
        Me.tbTelefoon_b.Size = New System.Drawing.Size(211, 20)
        Me.tbTelefoon_b.TabIndex = 51
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(479, 183)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "via website:"
        '
        'gbConfirm
        '
        Me.gbConfirm.Controls.Add(Me.chkVerwerkt)
        Me.gbConfirm.Location = New System.Drawing.Point(5, 428)
        Me.gbConfirm.Name = "gbConfirm"
        Me.gbConfirm.Size = New System.Drawing.Size(177, 52)
        Me.gbConfirm.TabIndex = 56
        Me.gbConfirm.TabStop = False
        Me.gbConfirm.Text = "Boeking:"
        '
        'chkVerwerkt
        '
        Me.chkVerwerkt.AutoSize = True
        Me.chkVerwerkt.Location = New System.Drawing.Point(6, 26)
        Me.chkVerwerkt.Name = "chkVerwerkt"
        Me.chkVerwerkt.Size = New System.Drawing.Size(112, 17)
        Me.chkVerwerkt.TabIndex = 58
        Me.chkVerwerkt.Text = "Aangifte verwerkt."
        Me.chkVerwerkt.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'lblmobileError
        '
        Me.lblmobileError.AutoSize = True
        Me.lblmobileError.Location = New System.Drawing.Point(647, 232)
        Me.lblmobileError.Name = "lblmobileError"
        Me.lblmobileError.Size = New System.Drawing.Size(123, 13)
        Me.lblmobileError.TabIndex = 57
        Me.lblmobileError.Text = "voorstel mobielnummer !!"
        Me.lblmobileError.Visible = False
        '
        'frmLid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 577)
        Me.Controls.Add(Me.lblmobileError)
        Me.Controls.Add(Me.gbConfirm)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tbEmail_b)
        Me.Controls.Add(Me.tbMobiel_b)
        Me.Controls.Add(Me.tbTelefoon_b)
        Me.Controls.Add(Me.btnPostcode)
        Me.Controls.Add(Me.cmbBond)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.tbEmail)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.tbLidNr)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.lblBoeking_Message)
        Me.Controls.Add(Me.tbWachtwoord)
        Me.Controls.Add(Me.tbMobiel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbTelefoon)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpDOB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbLand)
        Me.Controls.Add(Me.tbHuisNrTv)
        Me.Controls.Add(Me.tbPlaats)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbPostCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbHuisNr)
        Me.Controls.Add(Me.lblLidNr)
        Me.Controls.Add(Me.tbAdres)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbTussenvoegsel)
        Me.Controls.Add(Me.tbInit)
        Me.Controls.Add(Me.tbAchternaam)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmLid"
        Me.Text = "Gegevens van ..."
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbConfirm.ResumeLayout(False)
        Me.gbConfirm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLidNr As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbTelefoon As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbMobiel As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbWachtwoord As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblBoeking_Message As System.Windows.Forms.Label
    Friend WithEvents CloseToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbLidNr As System.Windows.Forms.TextBox
    Friend WithEvents tbEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tsbtBoekingDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbUnkown As System.Windows.Forms.RadioButton
    Friend WithEvents rbWoman As System.Windows.Forms.RadioButton
    Friend WithEvents rbMan As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAchternaam As System.Windows.Forms.TextBox
    Friend WithEvents tbInit As System.Windows.Forms.TextBox
    Friend WithEvents tbTussenvoegsel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbAdres As System.Windows.Forms.TextBox
    Friend WithEvents tbHuisNr As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbPostCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbPlaats As System.Windows.Forms.TextBox
    Friend WithEvents tbHuisNrTv As System.Windows.Forms.TextBox
    Friend WithEvents tbLand As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbBond As System.Windows.Forms.ComboBox
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents tsbWord As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPostcode As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbEmail_b As System.Windows.Forms.TextBox
    Friend WithEvents tbMobiel_b As System.Windows.Forms.TextBox
    Friend WithEvents tbTelefoon_b As System.Windows.Forms.TextBox
    Friend WithEvents gbConfirm As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lblmobileError As Label
    Friend WithEvents chkVerwerkt As CheckBox
End Class
