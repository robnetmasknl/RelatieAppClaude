<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeden
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeden))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbSearch = New System.Windows.Forms.Label()
        Me.tbZoekveld = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvLeden = New System.Windows.Forms.DataGridView()
        Me.Lidnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Postcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.geboortedatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefoonnummer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mobiel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bevestigd = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.relid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbAchternaam = New System.Windows.Forms.RadioButton()
        Me.rbLidNr = New System.Windows.Forms.RadioButton()
        Me.btOk = New System.Windows.Forms.Button()
        Me.tbPC = New System.Windows.Forms.TextBox()
        Me.lbPC = New System.Windows.Forms.Label()
        Me.rbNaamPc = New System.Windows.Forms.RadioButton()
        Me.btNew = New System.Windows.Forms.Button()
        Me.rbPCHuisNr = New System.Windows.Forms.RadioButton()
        CType(Me.dgvLeden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbSearch
        '
        Me.lbSearch.AutoSize = True
        Me.lbSearch.Location = New System.Drawing.Point(14, 15)
        Me.lbSearch.Name = "lbSearch"
        Me.lbSearch.Size = New System.Drawing.Size(55, 13)
        Me.lbSearch.TabIndex = 0
        Me.lbSearch.Text = "Zoekveld:"
        '
        'tbZoekveld
        '
        Me.tbZoekveld.Location = New System.Drawing.Point(75, 12)
        Me.tbZoekveld.Name = "tbZoekveld"
        Me.tbZoekveld.Size = New System.Drawing.Size(173, 20)
        Me.tbZoekveld.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.ImageIndex = 0
        Me.btnSearch.ImageList = Me.ImageList1
        Me.btnSearch.Location = New System.Drawing.Point(528, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 4
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
        Me.dgvLeden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLeden.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Lidnr, Me.FullName, Me.FullAddress, Me.Postcode, Me.email, Me.geboortedatum, Me.telefoonnummer, Me.mobiel, Me.bevestigd, Me.relid})
        Me.dgvLeden.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLeden.Location = New System.Drawing.Point(12, 89)
        Me.dgvLeden.MultiSelect = False
        Me.dgvLeden.Name = "dgvLeden"
        Me.dgvLeden.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLeden.RowHeadersVisible = False
        Me.dgvLeden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLeden.Size = New System.Drawing.Size(944, 499)
        Me.dgvLeden.TabIndex = 5
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
        'FullName
        '
        Me.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FullName.DataPropertyName = "FullName"
        Me.FullName.HeaderText = "Naam"
        Me.FullName.Name = "FullName"
        Me.FullName.Width = 60
        '
        'FullAddress
        '
        Me.FullAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.FullAddress.DataPropertyName = "FullAddress"
        Me.FullAddress.HeaderText = "Adres"
        Me.FullAddress.Name = "FullAddress"
        Me.FullAddress.Width = 59
        '
        'Postcode
        '
        Me.Postcode.DataPropertyName = "Postcode"
        Me.Postcode.HeaderText = "Postcode"
        Me.Postcode.Name = "Postcode"
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
        'bevestigd
        '
        Me.bevestigd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.bevestigd.DataPropertyName = "bevestigd"
        Me.bevestigd.HeaderText = "Verwerkt"
        Me.bevestigd.Name = "bevestigd"
        Me.bevestigd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.bevestigd.Width = 74
        '
        'relid
        '
        Me.relid.DataPropertyName = "Id"
        Me.relid.HeaderText = "relid"
        Me.relid.Name = "relid"
        '
        'rbAchternaam
        '
        Me.rbAchternaam.AutoSize = True
        Me.rbAchternaam.Location = New System.Drawing.Point(254, 12)
        Me.rbAchternaam.Name = "rbAchternaam"
        Me.rbAchternaam.Size = New System.Drawing.Size(96, 17)
        Me.rbAchternaam.TabIndex = 3
        Me.rbAchternaam.TabStop = True
        Me.rbAchternaam.Text = "op achternaam"
        Me.rbAchternaam.UseVisualStyleBackColor = True
        '
        'rbLidNr
        '
        Me.rbLidNr.AutoSize = True
        Me.rbLidNr.Location = New System.Drawing.Point(405, 12)
        Me.rbLidNr.Name = "rbLidNr"
        Me.rbLidNr.Size = New System.Drawing.Size(87, 17)
        Me.rbLidNr.TabIndex = 5
        Me.rbLidNr.TabStop = True
        Me.rbLidNr.Text = "op lidnummer"
        Me.rbLidNr.UseVisualStyleBackColor = True
        '
        'btOk
        '
        Me.btOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btOk.ImageIndex = 2
        Me.btOk.ImageList = Me.ImageList1
        Me.btOk.Location = New System.Drawing.Point(528, 60)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(75, 23)
        Me.btOk.TabIndex = 6
        Me.btOk.Text = "Ok"
        Me.btOk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btOk.UseVisualStyleBackColor = True
        Me.btOk.Visible = False
        '
        'tbPC
        '
        Me.tbPC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbPC.Location = New System.Drawing.Point(75, 36)
        Me.tbPC.MaxLength = 7
        Me.tbPC.Name = "tbPC"
        Me.tbPC.Size = New System.Drawing.Size(173, 20)
        Me.tbPC.TabIndex = 2
        Me.tbPC.Visible = False
        '
        'lbPC
        '
        Me.lbPC.AutoSize = True
        Me.lbPC.Location = New System.Drawing.Point(14, 39)
        Me.lbPC.Name = "lbPC"
        Me.lbPC.Size = New System.Drawing.Size(54, 13)
        Me.lbPC.TabIndex = 7
        Me.lbPC.Text = "postcode:"
        Me.lbPC.Visible = False
        '
        'rbNaamPc
        '
        Me.rbNaamPc.AutoSize = True
        Me.rbNaamPc.Location = New System.Drawing.Point(254, 32)
        Me.rbNaamPc.Name = "rbNaamPc"
        Me.rbNaamPc.Size = New System.Drawing.Size(145, 17)
        Me.rbNaamPc.TabIndex = 4
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
        Me.btNew.Location = New System.Drawing.Point(528, 34)
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(75, 23)
        Me.btNew.TabIndex = 8
        Me.btNew.Text = "Nieuw"
        Me.btNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btNew.UseVisualStyleBackColor = True
        '
        'rbPCHuisNr
        '
        Me.rbPCHuisNr.AutoSize = True
        Me.rbPCHuisNr.Location = New System.Drawing.Point(405, 32)
        Me.rbPCHuisNr.Name = "rbPCHuisNr"
        Me.rbPCHuisNr.Size = New System.Drawing.Size(117, 17)
        Me.rbPCHuisNr.TabIndex = 9
        Me.rbPCHuisNr.TabStop = True
        Me.rbPCHuisNr.Text = "op postcode/huisnr"
        Me.rbPCHuisNr.UseVisualStyleBackColor = True
        '
        'frmLeden
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 611)
        Me.Controls.Add(Me.rbPCHuisNr)
        Me.Controls.Add(Me.btNew)
        Me.Controls.Add(Me.rbNaamPc)
        Me.Controls.Add(Me.tbPC)
        Me.Controls.Add(Me.lbPC)
        Me.Controls.Add(Me.btOk)
        Me.Controls.Add(Me.rbLidNr)
        Me.Controls.Add(Me.rbAchternaam)
        Me.Controls.Add(Me.dgvLeden)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.tbZoekveld)
        Me.Controls.Add(Me.lbSearch)
        Me.Name = "frmLeden"
        Me.Text = "Leden"
        CType(Me.dgvLeden, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents tbPC As System.Windows.Forms.TextBox
    Friend WithEvents lbPC As System.Windows.Forms.Label
    Friend WithEvents rbNaamPc As System.Windows.Forms.RadioButton
    Friend WithEvents btNew As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents rbPCHuisNr As RadioButton
    Friend WithEvents Lidnr As DataGridViewTextBoxColumn
    Friend WithEvents FullName As DataGridViewTextBoxColumn
    Friend WithEvents FullAddress As DataGridViewTextBoxColumn
    Friend WithEvents Postcode As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents geboortedatum As DataGridViewTextBoxColumn
    Friend WithEvents telefoonnummer As DataGridViewTextBoxColumn
    Friend WithEvents mobiel As DataGridViewTextBoxColumn
    Friend WithEvents bevestigd As DataGridViewCheckBoxColumn
    Friend WithEvents relid As DataGridViewTextBoxColumn
End Class
