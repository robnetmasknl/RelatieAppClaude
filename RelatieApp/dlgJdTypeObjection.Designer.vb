<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgJdTypeObjection
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOutlookBezwaar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.uctdVovoDat1 = New RelatieApp.uctd()
        Me.chkVoVoRecall = New System.Windows.Forms.CheckBox()
        Me.btnOutlookVoVoDat = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.uctdVovoVerweerSchrift = New RelatieApp.ucTextDate()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.uctdVovoIndienDatum = New RelatieApp.ucTextDate()
        Me.rbVoVoAfwachting = New System.Windows.Forms.RadioButton()
        Me.tbVovotoev = New System.Windows.Forms.TextBox()
        Me.rbVoVoToegewezen = New System.Windows.Forms.RadioButton()
        Me.rbVoVoAfgewezen = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.uctdVovoDatUit = New RelatieApp.ucTextDate()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.uctdVovoDat = New RelatieApp.ucTextDate()
        Me.chkVovoCB = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOutlookHerstelVerzuim = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkAanhBezw = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblBezwaartermijn = New System.Windows.Forms.Label()
        Me.uctdBeslissingBezwaar = New RelatieApp.ucTextDate()
        Me.rbAfwachting = New System.Windows.Forms.RadioButton()
        Me.rbNietOntv = New System.Windows.Forms.RadioButton()
        Me.rbOnGegrond = New System.Windows.Forms.RadioButton()
        Me.rbGegrond = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbOpmerkingen = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblWeken2 = New System.Windows.Forms.Label()
        Me.tbWeken2 = New System.Windows.Forms.TextBox()
        Me.btnOutlookEindeBeslis = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbOpmerkingen2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbWeken1 = New System.Windows.Forms.TextBox()
        Me.chkIntrekking = New System.Windows.Forms.CheckBox()
        Me.grpInGebreke = New System.Windows.Forms.GroupBox()
        Me.tbInGebreke = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.uctdBeslissingIngebreke = New RelatieApp.ucTextDate()
        Me.chkIngebrekestelling = New System.Windows.Forms.CheckBox()
        Me.TabCtrl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblBezwaar = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnOutlookHoorzitting = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnOutlookSchriftelijkeReactie = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnDeleteAppoinments = New System.Windows.Forms.Button()
        Me.tbKenmerk = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnClearDbCalEntries = New System.Windows.Forms.Button()
        Me.grpExtraWkn = New System.Windows.Forms.GroupBox()
        Me.rdExtraHand = New System.Windows.Forms.RadioButton()
        Me.rdExtra6 = New System.Windows.Forms.RadioButton()
        Me.rdExtraUit = New System.Windows.Forms.RadioButton()
        Me.uctdSchriftelijkeReactie = New RelatieApp.ucTextDate()
        Me.uctdHoorzitting = New RelatieApp.ucTextDate()
        Me.uctdBezwaarschrift = New RelatieApp.ucTextDate()
        Me.uctdVerloopigBezwaar = New RelatieApp.ucTextDate()
        Me.uctdHerstelverzuimtermijn = New RelatieApp.ucTextDate()
        Me.uctdDecisionDate = New RelatieApp.ucTextDate()
        Me.uctdEindeBeslisTermijn = New RelatieApp.ucTextDate()
        Me.uctdBezwaarTermijn = New RelatieApp.ucTextDate()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpInGebreke.SuspendLayout()
        Me.TabCtrl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.grpExtraWkn.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(371, 703)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Bezwaar  termijn "
        '
        'btnOutlookBezwaar
        '
        Me.btnOutlookBezwaar.Location = New System.Drawing.Point(281, 50)
        Me.btnOutlookBezwaar.Name = "btnOutlookBezwaar"
        Me.btnOutlookBezwaar.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookBezwaar.TabIndex = 3
        Me.btnOutlookBezwaar.Text = "naar agenda"
        Me.btnOutlookBezwaar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.uctdVovoDat1)
        Me.GroupBox1.Controls.Add(Me.chkVoVoRecall)
        Me.GroupBox1.Controls.Add(Me.btnOutlookVoVoDat)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.uctdVovoVerweerSchrift)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.uctdVovoIndienDatum)
        Me.GroupBox1.Controls.Add(Me.rbVoVoAfwachting)
        Me.GroupBox1.Controls.Add(Me.tbVovotoev)
        Me.GroupBox1.Controls.Add(Me.rbVoVoToegewezen)
        Me.GroupBox1.Controls.Add(Me.rbVoVoAfgewezen)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.uctdVovoDatUit)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.uctdVovoDat)
        Me.GroupBox1.Controls.Add(Me.chkVovoCB)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 264)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'uctdVovoDat1
        '
        Me.uctdVovoDat1.Location = New System.Drawing.Point(350, 105)
        Me.uctdVovoDat1.Name = "uctdVovoDat1"
        Me.uctdVovoDat1.Size = New System.Drawing.Size(130, 27)
        Me.uctdVovoDat1.TabIndex = 46
        '
        'chkVoVoRecall
        '
        Me.chkVoVoRecall.AutoSize = True
        Me.chkVoVoRecall.ForeColor = System.Drawing.Color.Red
        Me.chkVoVoRecall.Location = New System.Drawing.Point(121, 21)
        Me.chkVoVoRecall.Name = "chkVoVoRecall"
        Me.chkVoVoRecall.Size = New System.Drawing.Size(102, 17)
        Me.chkVoVoRecall.TabIndex = 45
        Me.chkVoVoRecall.Text = "VoVo Intrekking"
        Me.chkVoVoRecall.UseVisualStyleBackColor = True
        '
        'btnOutlookVoVoDat
        '
        Me.btnOutlookVoVoDat.Location = New System.Drawing.Point(263, 110)
        Me.btnOutlookVoVoDat.Name = "btnOutlookVoVoDat"
        Me.btnOutlookVoVoDat.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookVoVoDat.TabIndex = 44
        Me.btnOutlookVoVoDat.Text = "naar agenda"
        Me.btnOutlookVoVoDat.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Verweerschrift"
        '
        'uctdVovoVerweerSchrift
        '
        Me.uctdVovoVerweerSchrift.Location = New System.Drawing.Point(120, 74)
        Me.uctdVovoVerweerSchrift.Name = "uctdVovoVerweerSchrift"
        Me.uctdVovoVerweerSchrift.Size = New System.Drawing.Size(137, 27)
        Me.uctdVovoVerweerSchrift.TabIndex = 2
        Me.uctdVovoVerweerSchrift.Value = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Indiendatum"
        '
        'uctdVovoIndienDatum
        '
        Me.uctdVovoIndienDatum.Location = New System.Drawing.Point(121, 41)
        Me.uctdVovoIndienDatum.Name = "uctdVovoIndienDatum"
        Me.uctdVovoIndienDatum.Size = New System.Drawing.Size(137, 27)
        Me.uctdVovoIndienDatum.TabIndex = 1
        Me.uctdVovoIndienDatum.Value = ""
        '
        'rbVoVoAfwachting
        '
        Me.rbVoVoAfwachting.AutoSize = True
        Me.rbVoVoAfwachting.Location = New System.Drawing.Point(328, 84)
        Me.rbVoVoAfwachting.Name = "rbVoVoAfwachting"
        Me.rbVoVoAfwachting.Size = New System.Drawing.Size(77, 17)
        Me.rbVoVoAfwachting.TabIndex = 7
        Me.rbVoVoAfwachting.TabStop = True
        Me.rbVoVoAfwachting.Tag = "0"
        Me.rbVoVoAfwachting.Text = "afwachting"
        Me.rbVoVoAfwachting.UseVisualStyleBackColor = True
        '
        'tbVovotoev
        '
        Me.tbVovotoev.Location = New System.Drawing.Point(14, 173)
        Me.tbVovotoev.MaxLength = 140
        Me.tbVovotoev.Multiline = True
        Me.tbVovotoev.Name = "tbVovotoev"
        Me.tbVovotoev.Size = New System.Drawing.Size(462, 62)
        Me.tbVovotoev.TabIndex = 6
        '
        'rbVoVoToegewezen
        '
        Me.rbVoVoToegewezen.AutoSize = True
        Me.rbVoVoToegewezen.Location = New System.Drawing.Point(328, 63)
        Me.rbVoVoToegewezen.Name = "rbVoVoToegewezen"
        Me.rbVoVoToegewezen.Size = New System.Drawing.Size(83, 17)
        Me.rbVoVoToegewezen.TabIndex = 6
        Me.rbVoVoToegewezen.TabStop = True
        Me.rbVoVoToegewezen.Tag = "2"
        Me.rbVoVoToegewezen.Text = "toegewezen"
        Me.rbVoVoToegewezen.UseVisualStyleBackColor = True
        '
        'rbVoVoAfgewezen
        '
        Me.rbVoVoAfgewezen.AutoSize = True
        Me.rbVoVoAfgewezen.Location = New System.Drawing.Point(328, 41)
        Me.rbVoVoAfgewezen.Name = "rbVoVoAfgewezen"
        Me.rbVoVoAfgewezen.Size = New System.Drawing.Size(77, 17)
        Me.rbVoVoAfgewezen.TabIndex = 5
        Me.rbVoVoAfgewezen.TabStop = True
        Me.rbVoVoAfgewezen.Tag = "1"
        Me.rbVoVoAfgewezen.Text = "afgewezen"
        Me.rbVoVoAfgewezen.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Datum uitspraak"
        '
        'uctdVovoDatUit
        '
        Me.uctdVovoDatUit.Location = New System.Drawing.Point(121, 140)
        Me.uctdVovoDatUit.Name = "uctdVovoDatUit"
        Me.uctdVovoDatUit.Size = New System.Drawing.Size(137, 27)
        Me.uctdVovoDatUit.TabIndex = 4
        Me.uctdVovoDatUit.Value = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Datum zitting "
        '
        'uctdVovoDat
        '
        Me.uctdVovoDat.Location = New System.Drawing.Point(121, 107)
        Me.uctdVovoDat.Name = "uctdVovoDat"
        Me.uctdVovoDat.Size = New System.Drawing.Size(137, 27)
        Me.uctdVovoDat.TabIndex = 3
        Me.uctdVovoDat.Value = ""
        '
        'chkVovoCB
        '
        Me.chkVovoCB.AutoSize = True
        Me.chkVovoCB.Location = New System.Drawing.Point(68, 21)
        Me.chkVovoCB.Name = "chkVovoCB"
        Me.chkVovoCB.Size = New System.Drawing.Size(15, 14)
        Me.chkVovoCB.TabIndex = 0
        Me.chkVovoCB.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "VoVo"
        '
        'btnOutlookHerstelVerzuim
        '
        Me.btnOutlookHerstelVerzuim.Location = New System.Drawing.Point(281, 115)
        Me.btnOutlookHerstelVerzuim.Name = "btnOutlookHerstelVerzuim"
        Me.btnOutlookHerstelVerzuim.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookHerstelVerzuim.TabIndex = 8
        Me.btnOutlookHerstelVerzuim.Text = "naar agenda"
        Me.btnOutlookHerstelVerzuim.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Herstel verzuimtermijn"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Aanhouding bezwaar"
        '
        'chkAanhBezw
        '
        Me.chkAanhBezw.AutoSize = True
        Me.chkAanhBezw.Location = New System.Drawing.Point(142, 150)
        Me.chkAanhBezw.Name = "chkAanhBezw"
        Me.chkAanhBezw.Size = New System.Drawing.Size(15, 14)
        Me.chkAanhBezw.TabIndex = 9
        Me.chkAanhBezw.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblBezwaartermijn)
        Me.GroupBox2.Controls.Add(Me.uctdBeslissingBezwaar)
        Me.GroupBox2.Controls.Add(Me.rbAfwachting)
        Me.GroupBox2.Controls.Add(Me.rbNietOntv)
        Me.GroupBox2.Controls.Add(Me.rbOnGegrond)
        Me.GroupBox2.Controls.Add(Me.rbGegrond)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 48)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Beslissing op bezwaar"
        '
        'lblBezwaartermijn
        '
        Me.lblBezwaartermijn.AutoSize = True
        Me.lblBezwaartermijn.BackColor = System.Drawing.Color.Transparent
        Me.lblBezwaartermijn.ForeColor = System.Drawing.Color.Red
        Me.lblBezwaartermijn.Location = New System.Drawing.Point(292, 53)
        Me.lblBezwaartermijn.Name = "lblBezwaartermijn"
        Me.lblBezwaartermijn.Size = New System.Drawing.Size(0, 13)
        Me.lblBezwaartermijn.TabIndex = 5
        '
        'uctdBeslissingBezwaar
        '
        Me.uctdBeslissingBezwaar.Location = New System.Drawing.Point(350, 17)
        Me.uctdBeslissingBezwaar.Name = "uctdBeslissingBezwaar"
        Me.uctdBeslissingBezwaar.Size = New System.Drawing.Size(137, 27)
        Me.uctdBeslissingBezwaar.TabIndex = 4
        Me.uctdBeslissingBezwaar.Value = ""
        '
        'rbAfwachting
        '
        Me.rbAfwachting.Location = New System.Drawing.Point(269, 24)
        Me.rbAfwachting.Name = "rbAfwachting"
        Me.rbAfwachting.Size = New System.Drawing.Size(77, 17)
        Me.rbAfwachting.TabIndex = 3
        Me.rbAfwachting.Tag = "0"
        Me.rbAfwachting.Text = "afwachting"
        Me.rbAfwachting.UseVisualStyleBackColor = True
        '
        'rbNietOntv
        '
        Me.rbNietOntv.Location = New System.Drawing.Point(162, 24)
        Me.rbNietOntv.Name = "rbNietOntv"
        Me.rbNietOntv.Size = New System.Drawing.Size(104, 17)
        Me.rbNietOntv.TabIndex = 2
        Me.rbNietOntv.Tag = "3"
        Me.rbNietOntv.Text = "Niet ontvankelijk"
        Me.rbNietOntv.UseVisualStyleBackColor = True
        '
        'rbOnGegrond
        '
        Me.rbOnGegrond.Location = New System.Drawing.Point(78, 24)
        Me.rbOnGegrond.Name = "rbOnGegrond"
        Me.rbOnGegrond.Size = New System.Drawing.Size(78, 17)
        Me.rbOnGegrond.TabIndex = 1
        Me.rbOnGegrond.Tag = "2"
        Me.rbOnGegrond.Text = "Ongegrond"
        Me.rbOnGegrond.UseVisualStyleBackColor = True
        '
        'rbGegrond
        '
        Me.rbGegrond.Location = New System.Drawing.Point(6, 24)
        Me.rbGegrond.Name = "rbGegrond"
        Me.rbGegrond.Size = New System.Drawing.Size(66, 17)
        Me.rbGegrond.TabIndex = 0
        Me.rbGegrond.Tag = "1"
        Me.rbGegrond.Text = "Gegrond"
        Me.rbGegrond.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Einde beslistermijn"
        '
        'tbOpmerkingen
        '
        Me.tbOpmerkingen.Location = New System.Drawing.Point(17, 29)
        Me.tbOpmerkingen.MaxLength = 255
        Me.tbOpmerkingen.Multiline = True
        Me.tbOpmerkingen.Name = "tbOpmerkingen"
        Me.tbOpmerkingen.Size = New System.Drawing.Size(493, 65)
        Me.tbOpmerkingen.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Opmerkingen"
        '
        'lblWeken2
        '
        Me.lblWeken2.AutoSize = True
        Me.lblWeken2.Location = New System.Drawing.Point(424, 151)
        Me.lblWeken2.Name = "lblWeken2"
        Me.lblWeken2.Size = New System.Drawing.Size(90, 13)
        Me.lblWeken2.TabIndex = 49
        Me.lblWeken2.Text = "Weken na besluit"
        Me.lblWeken2.Visible = False
        '
        'tbWeken2
        '
        Me.tbWeken2.Location = New System.Drawing.Point(383, 148)
        Me.tbWeken2.MaxLength = 2
        Me.tbWeken2.Name = "tbWeken2"
        Me.tbWeken2.Size = New System.Drawing.Size(37, 20)
        Me.tbWeken2.TabIndex = 10
        Me.tbWeken2.Text = "6"
        '
        'btnOutlookEindeBeslis
        '
        Me.btnOutlookEindeBeslis.Location = New System.Drawing.Point(281, 243)
        Me.btnOutlookEindeBeslis.Name = "btnOutlookEindeBeslis"
        Me.btnOutlookEindeBeslis.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookEindeBeslis.TabIndex = 16
        Me.btnOutlookEindeBeslis.Text = "naar agenda"
        Me.btnOutlookEindeBeslis.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Datum besluit"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 156)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Opmerkingen 2"
        '
        'tbOpmerkingen2
        '
        Me.tbOpmerkingen2.Location = New System.Drawing.Point(17, 172)
        Me.tbOpmerkingen2.MaxLength = 255
        Me.tbOpmerkingen2.Multiline = True
        Me.tbOpmerkingen2.Name = "tbOpmerkingen2"
        Me.tbOpmerkingen2.Size = New System.Drawing.Size(493, 65)
        Me.tbOpmerkingen2.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(424, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Weken na besluit"
        '
        'tbWeken1
        '
        Me.tbWeken1.Location = New System.Drawing.Point(383, 50)
        Me.tbWeken1.MaxLength = 2
        Me.tbWeken1.Name = "tbWeken1"
        Me.tbWeken1.Size = New System.Drawing.Size(37, 20)
        Me.tbWeken1.TabIndex = 4
        Me.tbWeken1.Text = "6"
        '
        'chkIntrekking
        '
        Me.chkIntrekking.AutoSize = True
        Me.chkIntrekking.ForeColor = System.Drawing.Color.Red
        Me.chkIntrekking.Location = New System.Drawing.Point(281, 20)
        Me.chkIntrekking.Name = "chkIntrekking"
        Me.chkIntrekking.Size = New System.Drawing.Size(73, 17)
        Me.chkIntrekking.TabIndex = 1
        Me.chkIntrekking.Text = "Intrekking"
        Me.chkIntrekking.UseVisualStyleBackColor = True
        '
        'grpInGebreke
        '
        Me.grpInGebreke.Controls.Add(Me.tbInGebreke)
        Me.grpInGebreke.Controls.Add(Me.Label2)
        Me.grpInGebreke.Controls.Add(Me.uctdBeslissingIngebreke)
        Me.grpInGebreke.Controls.Add(Me.chkIngebrekestelling)
        Me.grpInGebreke.Location = New System.Drawing.Point(17, 243)
        Me.grpInGebreke.Name = "grpInGebreke"
        Me.grpInGebreke.Size = New System.Drawing.Size(496, 127)
        Me.grpInGebreke.TabIndex = 11
        Me.grpInGebreke.TabStop = False
        Me.grpInGebreke.Text = "Beslissing op ingebrekestelling "
        '
        'tbInGebreke
        '
        Me.tbInGebreke.Enabled = False
        Me.tbInGebreke.Location = New System.Drawing.Point(16, 52)
        Me.tbInGebreke.Multiline = True
        Me.tbInGebreke.Name = "tbInGebreke"
        Me.tbInGebreke.Size = New System.Drawing.Size(462, 65)
        Me.tbInGebreke.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Ingebrekestelling"
        '
        'uctdBeslissingIngebreke
        '
        Me.uctdBeslissingIngebreke.Enabled = False
        Me.uctdBeslissingIngebreke.Location = New System.Drawing.Point(155, 19)
        Me.uctdBeslissingIngebreke.Name = "uctdBeslissingIngebreke"
        Me.uctdBeslissingIngebreke.Size = New System.Drawing.Size(137, 27)
        Me.uctdBeslissingIngebreke.TabIndex = 1
        Me.uctdBeslissingIngebreke.Value = ""
        '
        'chkIngebrekestelling
        '
        Me.chkIngebrekestelling.AutoSize = True
        Me.chkIngebrekestelling.Location = New System.Drawing.Point(107, 26)
        Me.chkIngebrekestelling.Name = "chkIngebrekestelling"
        Me.chkIngebrekestelling.Size = New System.Drawing.Size(15, 14)
        Me.chkIngebrekestelling.TabIndex = 0
        Me.chkIngebrekestelling.UseVisualStyleBackColor = True
        '
        'TabCtrl
        '
        Me.TabCtrl.Controls.Add(Me.TabPage1)
        Me.TabCtrl.Controls.Add(Me.TabPage2)
        Me.TabCtrl.Location = New System.Drawing.Point(-2, 300)
        Me.TabCtrl.Name = "TabCtrl"
        Me.TabCtrl.SelectedIndex = 0
        Me.TabCtrl.Size = New System.Drawing.Size(552, 401)
        Me.TabCtrl.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpInGebreke)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.tbOpmerkingen)
        Me.TabPage1.Controls.Add(Me.tbOpmerkingen2)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(544, 375)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Algemeen"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(544, 375)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "VoVo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(29, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 13)
        Me.Label10.TabIndex = 219
        Me.Label10.Text = "Voorlopig bezwaar"
        '
        'lblBezwaar
        '
        Me.lblBezwaar.AutoSize = True
        Me.lblBezwaar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBezwaar.Location = New System.Drawing.Point(281, 87)
        Me.lblBezwaar.Name = "lblBezwaar"
        Me.lblBezwaar.Size = New System.Drawing.Size(76, 13)
        Me.lblBezwaar.TabIndex = 220
        Me.lblBezwaar.Text = "Bezwaarschrift"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(29, 184)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 13)
        Me.Label17.TabIndex = 226
        Me.Label17.Text = "Hoorzitting"
        '
        'btnOutlookHoorzitting
        '
        Me.btnOutlookHoorzitting.Location = New System.Drawing.Point(281, 177)
        Me.btnOutlookHoorzitting.Name = "btnOutlookHoorzitting"
        Me.btnOutlookHoorzitting.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookHoorzitting.TabIndex = 12
        Me.btnOutlookHoorzitting.Text = "naar agenda"
        Me.btnOutlookHoorzitting.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(29, 215)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 13)
        Me.Label18.TabIndex = 229
        Me.Label18.Text = "Schriftelijke reactie "
        '
        'btnOutlookSchriftelijkeReactie
        '
        Me.btnOutlookSchriftelijkeReactie.Location = New System.Drawing.Point(281, 210)
        Me.btnOutlookSchriftelijkeReactie.Name = "btnOutlookSchriftelijkeReactie"
        Me.btnOutlookSchriftelijkeReactie.Size = New System.Drawing.Size(75, 23)
        Me.btnOutlookSchriftelijkeReactie.TabIndex = 14
        Me.btnOutlookSchriftelijkeReactie.Text = "naar agenda"
        Me.btnOutlookSchriftelijkeReactie.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.RelatieApp.My.Resources.Resource1.Question321
        Me.btnHelp.Location = New System.Drawing.Point(515, -3)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(40, 41)
        Me.btnHelp.TabIndex = 237
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnDeleteAppoinments
        '
        Me.btnDeleteAppoinments.Location = New System.Drawing.Point(371, 273)
        Me.btnDeleteAppoinments.Name = "btnDeleteAppoinments"
        Me.btnDeleteAppoinments.Size = New System.Drawing.Size(149, 23)
        Me.btnDeleteAppoinments.TabIndex = 230
        Me.btnDeleteAppoinments.Text = "DeleteFutureAppointments"
        Me.btnDeleteAppoinments.UseVisualStyleBackColor = True
        '
        'tbKenmerk
        '
        Me.tbKenmerk.Location = New System.Drawing.Point(140, 275)
        Me.tbKenmerk.Name = "tbKenmerk"
        Me.tbKenmerk.Size = New System.Drawing.Size(217, 20)
        Me.tbKenmerk.TabIndex = 18
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(29, 278)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 239
        Me.Label19.Text = "Kenmerk:"
        '
        'btnClearDbCalEntries
        '
        Me.btnClearDbCalEntries.Location = New System.Drawing.Point(374, 15)
        Me.btnClearDbCalEntries.Name = "btnClearDbCalEntries"
        Me.btnClearDbCalEntries.Size = New System.Drawing.Size(125, 23)
        Me.btnClearDbCalEntries.TabIndex = 240
        Me.btnClearDbCalEntries.Text = "ClearDbCalEntries"
        Me.btnClearDbCalEntries.UseVisualStyleBackColor = True
        Me.btnClearDbCalEntries.Visible = False
        '
        'grpExtraWkn
        '
        Me.grpExtraWkn.Controls.Add(Me.rdExtraHand)
        Me.grpExtraWkn.Controls.Add(Me.rdExtra6)
        Me.grpExtraWkn.Controls.Add(Me.rdExtraUit)
        Me.grpExtraWkn.Location = New System.Drawing.Point(371, 174)
        Me.grpExtraWkn.Name = "grpExtraWkn"
        Me.grpExtraWkn.Size = New System.Drawing.Size(149, 94)
        Me.grpExtraWkn.TabIndex = 241
        Me.grpExtraWkn.TabStop = False
        Me.grpExtraWkn.Text = "Extra weken"
        '
        'rdExtraHand
        '
        Me.rdExtraHand.AutoSize = True
        Me.rdExtraHand.Location = New System.Drawing.Point(12, 67)
        Me.rdExtraHand.Name = "rdExtraHand"
        Me.rdExtraHand.Size = New System.Drawing.Size(76, 17)
        Me.rdExtraHand.TabIndex = 2
        Me.rdExtraHand.TabStop = True
        Me.rdExtraHand.Text = "Handmatig"
        Me.rdExtraHand.UseVisualStyleBackColor = True
        '
        'rdExtra6
        '
        Me.rdExtra6.AutoSize = True
        Me.rdExtra6.Location = New System.Drawing.Point(12, 44)
        Me.rdExtra6.Name = "rdExtra6"
        Me.rdExtra6.Size = New System.Drawing.Size(66, 17)
        Me.rdExtra6.TabIndex = 1
        Me.rdExtra6.TabStop = True
        Me.rdExtra6.Text = "6 weken"
        Me.rdExtra6.UseVisualStyleBackColor = True
        '
        'rdExtraUit
        '
        Me.rdExtraUit.AutoSize = True
        Me.rdExtraUit.Location = New System.Drawing.Point(12, 20)
        Me.rdExtraUit.Name = "rdExtraUit"
        Me.rdExtraUit.Size = New System.Drawing.Size(51, 17)
        Me.rdExtraUit.TabIndex = 0
        Me.rdExtraUit.TabStop = True
        Me.rdExtraUit.Text = "Geen"
        Me.rdExtraUit.UseVisualStyleBackColor = True
        '
        'uctdSchriftelijkeReactie
        '
        Me.uctdSchriftelijkeReactie.Location = New System.Drawing.Point(140, 208)
        Me.uctdSchriftelijkeReactie.Name = "uctdSchriftelijkeReactie"
        Me.uctdSchriftelijkeReactie.Size = New System.Drawing.Size(137, 27)
        Me.uctdSchriftelijkeReactie.TabIndex = 13
        Me.uctdSchriftelijkeReactie.Value = ""
        '
        'uctdHoorzitting
        '
        Me.uctdHoorzitting.Location = New System.Drawing.Point(140, 175)
        Me.uctdHoorzitting.Name = "uctdHoorzitting"
        Me.uctdHoorzitting.Size = New System.Drawing.Size(137, 27)
        Me.uctdHoorzitting.TabIndex = 11
        Me.uctdHoorzitting.Value = ""
        '
        'uctdBezwaarschrift
        '
        Me.uctdBezwaarschrift.Location = New System.Drawing.Point(383, 81)
        Me.uctdBezwaarschrift.Name = "uctdBezwaarschrift"
        Me.uctdBezwaarschrift.Size = New System.Drawing.Size(137, 27)
        Me.uctdBezwaarschrift.TabIndex = 6
        Me.uctdBezwaarschrift.Value = ""
        '
        'uctdVerloopigBezwaar
        '
        Me.uctdVerloopigBezwaar.Location = New System.Drawing.Point(140, 81)
        Me.uctdVerloopigBezwaar.Name = "uctdVerloopigBezwaar"
        Me.uctdVerloopigBezwaar.Size = New System.Drawing.Size(137, 27)
        Me.uctdVerloopigBezwaar.TabIndex = 5
        Me.uctdVerloopigBezwaar.Value = ""
        '
        'uctdHerstelverzuimtermijn
        '
        Me.uctdHerstelverzuimtermijn.Location = New System.Drawing.Point(140, 113)
        Me.uctdHerstelverzuimtermijn.Name = "uctdHerstelverzuimtermijn"
        Me.uctdHerstelverzuimtermijn.Size = New System.Drawing.Size(137, 27)
        Me.uctdHerstelverzuimtermijn.TabIndex = 7
        Me.uctdHerstelverzuimtermijn.Value = ""
        '
        'uctdDecisionDate
        '
        Me.uctdDecisionDate.Location = New System.Drawing.Point(140, 15)
        Me.uctdDecisionDate.Name = "uctdDecisionDate"
        Me.uctdDecisionDate.Size = New System.Drawing.Size(137, 27)
        Me.uctdDecisionDate.TabIndex = 0
        Me.uctdDecisionDate.Value = ""
        '
        'uctdEindeBeslisTermijn
        '
        Me.uctdEindeBeslisTermijn.Location = New System.Drawing.Point(140, 241)
        Me.uctdEindeBeslisTermijn.Name = "uctdEindeBeslisTermijn"
        Me.uctdEindeBeslisTermijn.Size = New System.Drawing.Size(137, 27)
        Me.uctdEindeBeslisTermijn.TabIndex = 15
        Me.uctdEindeBeslisTermijn.Value = ""
        '
        'uctdBezwaarTermijn
        '
        Me.uctdBezwaarTermijn.Location = New System.Drawing.Point(140, 48)
        Me.uctdBezwaarTermijn.Name = "uctdBezwaarTermijn"
        Me.uctdBezwaarTermijn.Size = New System.Drawing.Size(137, 27)
        Me.uctdBezwaarTermijn.TabIndex = 2
        Me.uctdBezwaarTermijn.Value = ""
        '
        'dlgJdTypeObjection
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(551, 739)
        Me.Controls.Add(Me.grpExtraWkn)
        Me.Controls.Add(Me.btnClearDbCalEntries)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.tbKenmerk)
        Me.Controls.Add(Me.btnDeleteAppoinments)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnOutlookSchriftelijkeReactie)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.uctdSchriftelijkeReactie)
        Me.Controls.Add(Me.btnOutlookHoorzitting)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.uctdHoorzitting)
        Me.Controls.Add(Me.lblBezwaar)
        Me.Controls.Add(Me.uctdBezwaarschrift)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkAanhBezw)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.uctdVerloopigBezwaar)
        Me.Controls.Add(Me.uctdHerstelverzuimtermijn)
        Me.Controls.Add(Me.TabCtrl)
        Me.Controls.Add(Me.btnOutlookHerstelVerzuim)
        Me.Controls.Add(Me.chkIntrekking)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.tbWeken1)
        Me.Controls.Add(Me.btnOutlookEindeBeslis)
        Me.Controls.Add(Me.uctdDecisionDate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblWeken2)
        Me.Controls.Add(Me.tbWeken2)
        Me.Controls.Add(Me.uctdEindeBeslisTermijn)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnOutlookBezwaar)
        Me.Controls.Add(Me.uctdBezwaarTermijn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgJdTypeObjection"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bezwaar"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpInGebreke.ResumeLayout(False)
        Me.grpInGebreke.PerformLayout()
        Me.TabCtrl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.grpExtraWkn.ResumeLayout(False)
        Me.grpExtraWkn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents uctdBezwaarTermijn As RelatieApp.ucTextDate
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOutlookBezwaar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents uctdVovoDatUit As RelatieApp.ucTextDate
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents uctdVovoDat As RelatieApp.ucTextDate
    Friend WithEvents chkVovoCB As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbVovotoev As System.Windows.Forms.TextBox
    Friend WithEvents rbVoVoToegewezen As System.Windows.Forms.RadioButton
    Friend WithEvents rbVoVoAfgewezen As System.Windows.Forms.RadioButton
    Friend WithEvents btnOutlookHerstelVerzuim As System.Windows.Forms.Button
    Friend WithEvents uctdHerstelverzuimtermijn As RelatieApp.ucTextDate
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkAanhBezw As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNietOntv As System.Windows.Forms.RadioButton
    Friend WithEvents rbOnGegrond As System.Windows.Forms.RadioButton
    Friend WithEvents rbGegrond As System.Windows.Forms.RadioButton
    Friend WithEvents uctdEindeBeslisTermijn As RelatieApp.ucTextDate
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbOpmerkingen As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbAfwachting As System.Windows.Forms.RadioButton
    Friend WithEvents rbVoVoAfwachting As System.Windows.Forms.RadioButton
    Friend WithEvents lblWeken2 As System.Windows.Forms.Label
    Friend WithEvents tbWeken2 As System.Windows.Forms.TextBox
    Friend WithEvents btnOutlookEindeBeslis As System.Windows.Forms.Button
    Friend WithEvents uctdDecisionDate As RelatieApp.ucTextDate
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbOpmerkingen2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbWeken1 As System.Windows.Forms.TextBox
    Friend WithEvents chkIntrekking As System.Windows.Forms.CheckBox
    Friend WithEvents grpInGebreke As System.Windows.Forms.GroupBox
    Friend WithEvents tbInGebreke As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents uctdBeslissingIngebreke As RelatieApp.ucTextDate
    Friend WithEvents chkIngebrekestelling As System.Windows.Forms.CheckBox
    Friend WithEvents uctdBezwaarschrift As RelatieApp.ucTextDate
    Friend WithEvents TabCtrl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents uctdVerloopigBezwaar As RelatieApp.ucTextDate
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblBezwaar As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents uctdHoorzitting As RelatieApp.ucTextDate
    Friend WithEvents btnOutlookHoorzitting As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents uctdSchriftelijkeReactie As RelatieApp.ucTextDate
    Friend WithEvents uctdBeslissingBezwaar As RelatieApp.ucTextDate
    Friend WithEvents btnOutlookSchriftelijkeReactie As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents uctdVovoVerweerSchrift As RelatieApp.ucTextDate
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents uctdVovoIndienDatum As RelatieApp.ucTextDate
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnOutlookVoVoDat As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAppoinments As System.Windows.Forms.Button
    Friend WithEvents tbKenmerk As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkVoVoRecall As System.Windows.Forms.CheckBox
    Friend WithEvents uctdVovoDat1 As RelatieApp.uctd
    Friend WithEvents btnClearDbCalEntries As System.Windows.Forms.Button
    Friend WithEvents grpExtraWkn As System.Windows.Forms.GroupBox
    Friend WithEvents rdExtraHand As System.Windows.Forms.RadioButton
    Friend WithEvents rdExtra6 As System.Windows.Forms.RadioButton
    Friend WithEvents rdExtraUit As System.Windows.Forms.RadioButton
    Friend WithEvents lblBezwaartermijn As Label
End Class
