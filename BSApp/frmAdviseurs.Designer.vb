<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdviseurs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdviseurs))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lvAdviseurs = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvBlokken = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocatieNaam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aanvang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tijdsduur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Volgendetijdstip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VanafOfTot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aantal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AantalBoekingen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AantalBeschikbaar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNaam = New System.Windows.Forms.Label()
        Me.lblAantalBoekingen = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAantalBeschikbaar = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAantalBlokken = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NieuwBlokToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btEditBlok = New System.Windows.Forms.Button()
        Me.btAddBlok = New System.Windows.Forms.Button()
        Me.btDeleteBlok = New System.Windows.Forms.Button()
        Me.chkShowDummies = New System.Windows.Forms.CheckBox()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
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
        CType(Me.dgvBlokken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvAdviseurs
        '
        Me.lvAdviseurs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvAdviseurs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvAdviseurs.HideSelection = False
        Me.lvAdviseurs.LargeImageList = Me.ImageList1
        Me.lvAdviseurs.Location = New System.Drawing.Point(12, 56)
        Me.lvAdviseurs.Name = "lvAdviseurs"
        Me.lvAdviseurs.Size = New System.Drawing.Size(182, 503)
        Me.lvAdviseurs.TabIndex = 1
        Me.lvAdviseurs.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "user.ico")
        Me.ImageList1.Images.SetKeyName(1, "user2.ico")
        Me.ImageList1.Images.SetKeyName(2, "home.ico")
        Me.ImageList1.Images.SetKeyName(3, "add.ico")
        Me.ImageList1.Images.SetKeyName(4, "delete.ico")
        Me.ImageList1.Images.SetKeyName(5, "file_edit.ico")
        Me.ImageList1.Images.SetKeyName(6, "file_new.ico")
        Me.ImageList1.Images.SetKeyName(7, "No.png")
        Me.ImageList1.Images.SetKeyName(8, "Paper-pencil.png")
        '
        'dgvBlokken
        '
        Me.dgvBlokken.AllowUserToAddRows = False
        Me.dgvBlokken.AllowUserToDeleteRows = False
        Me.dgvBlokken.AllowUserToOrderColumns = True
        Me.dgvBlokken.AllowUserToResizeRows = False
        Me.dgvBlokken.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBlokken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBlokken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.LocatieNaam, Me.Datum, Me.Aanvang, Me.Tijdsduur, Me.Volgendetijdstip, Me.VanafOfTot, Me.Aantal, Me.AantalBoekingen, Me.AantalBeschikbaar, Me.Vol})
        Me.dgvBlokken.Location = New System.Drawing.Point(223, 153)
        Me.dgvBlokken.Name = "dgvBlokken"
        Me.dgvBlokken.RowHeadersVisible = False
        Me.dgvBlokken.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBlokken.Size = New System.Drawing.Size(672, 406)
        Me.dgvBlokken.TabIndex = 2
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'LocatieNaam
        '
        Me.LocatieNaam.DataPropertyName = "LocatieNaam"
        Me.LocatieNaam.HeaderText = "Locatie"
        Me.LocatieNaam.Name = "LocatieNaam"
        '
        'Datum
        '
        Me.Datum.DataPropertyName = "Datum"
        Me.Datum.HeaderText = "Datum"
        Me.Datum.Name = "Datum"
        '
        'Aanvang
        '
        Me.Aanvang.DataPropertyName = "BlokTypeAanvang"
        DataGridViewCellStyle1.Format = "HH:mm"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Aanvang.DefaultCellStyle = DataGridViewCellStyle1
        Me.Aanvang.HeaderText = "Aanvang"
        Me.Aanvang.Name = "Aanvang"
        '
        'Tijdsduur
        '
        Me.Tijdsduur.DataPropertyName = "BlokTypeTijdsDuur"
        Me.Tijdsduur.HeaderText = "Tijdsduur"
        Me.Tijdsduur.Name = "Tijdsduur"
        '
        'Volgendetijdstip
        '
        Me.Volgendetijdstip.DataPropertyName = "Volgendetijdstip"
        DataGridViewCellStyle2.Format = "HH:mm"
        Me.Volgendetijdstip.DefaultCellStyle = DataGridViewCellStyle2
        Me.Volgendetijdstip.HeaderText = "Volgend tijdstip"
        Me.Volgendetijdstip.Name = "Volgendetijdstip"
        '
        'VanafOfTot
        '
        Me.VanafOfTot.DataPropertyName = "VanafOfTot"
        Me.VanafOfTot.HeaderText = "VanafOfTot"
        Me.VanafOfTot.Name = "VanafOfTot"
        '
        'Aantal
        '
        Me.Aantal.DataPropertyName = "AantalTotaal"
        Me.Aantal.HeaderText = "Aantal"
        Me.Aantal.Name = "Aantal"
        '
        'AantalBoekingen
        '
        Me.AantalBoekingen.DataPropertyName = "AantalBoekingen"
        Me.AantalBoekingen.HeaderText = "Boekingen"
        Me.AantalBoekingen.Name = "AantalBoekingen"
        '
        'AantalBeschikbaar
        '
        Me.AantalBeschikbaar.DataPropertyName = "AantalBeschikbaar"
        Me.AantalBeschikbaar.HeaderText = "Beschikbaar"
        Me.AantalBeschikbaar.Name = "AantalBeschikbaar"
        '
        'Vol
        '
        Me.Vol.DataPropertyName = "Vol"
        Me.Vol.HeaderText = "Vol"
        Me.Vol.Name = "Vol"
        Me.Vol.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Adviseur:"
        '
        'lblNaam
        '
        Me.lblNaam.AutoSize = True
        Me.lblNaam.Location = New System.Drawing.Point(365, 56)
        Me.lblNaam.Name = "lblNaam"
        Me.lblNaam.Size = New System.Drawing.Size(16, 13)
        Me.lblNaam.TabIndex = 4
        Me.lblNaam.Text = "..."
        '
        'lblAantalBoekingen
        '
        Me.lblAantalBoekingen.AutoSize = True
        Me.lblAantalBoekingen.Location = New System.Drawing.Point(365, 101)
        Me.lblAantalBoekingen.Name = "lblAantalBoekingen"
        Me.lblAantalBoekingen.Size = New System.Drawing.Size(16, 13)
        Me.lblAantalBoekingen.TabIndex = 6
        Me.lblAantalBoekingen.Text = "..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Aantal boekingen:"
        '
        'lblAantalBeschikbaar
        '
        Me.lblAantalBeschikbaar.AutoSize = True
        Me.lblAantalBeschikbaar.Location = New System.Drawing.Point(365, 123)
        Me.lblAantalBeschikbaar.Name = "lblAantalBeschikbaar"
        Me.lblAantalBeschikbaar.Size = New System.Drawing.Size(16, 13)
        Me.lblAantalBeschikbaar.TabIndex = 8
        Me.lblAantalBeschikbaar.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(220, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Aantal beschikbare:"
        '
        'lblAantalBlokken
        '
        Me.lblAantalBlokken.AutoSize = True
        Me.lblAantalBlokken.Location = New System.Drawing.Point(365, 78)
        Me.lblAantalBlokken.Name = "lblAantalBlokken"
        Me.lblAantalBlokken.Size = New System.Drawing.Size(16, 13)
        Me.lblAantalBlokken.TabIndex = 10
        Me.lblAantalBlokken.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(220, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Aantal blokken:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NieuwBlokToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(925, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NieuwBlokToolStripMenuItem
        '
        Me.NieuwBlokToolStripMenuItem.Image = Global.BSApp.My.Resources.Images.calendar
        Me.NieuwBlokToolStripMenuItem.Name = "NieuwBlokToolStripMenuItem"
        Me.NieuwBlokToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.NieuwBlokToolStripMenuItem.Text = "Nieuw blok"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Adviseurs:"
        '
        'btEditBlok
        '
        Me.btEditBlok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btEditBlok.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btEditBlok.ImageIndex = 8
        Me.btEditBlok.ImageList = Me.ImageList1
        Me.btEditBlok.Location = New System.Drawing.Point(811, 51)
        Me.btEditBlok.Name = "btEditBlok"
        Me.btEditBlok.Size = New System.Drawing.Size(84, 23)
        Me.btEditBlok.TabIndex = 13
        Me.btEditBlok.Text = "Bewerken"
        Me.btEditBlok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btEditBlok.UseVisualStyleBackColor = True
        '
        'btAddBlok
        '
        Me.btAddBlok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAddBlok.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAddBlok.ImageIndex = 3
        Me.btAddBlok.ImageList = Me.ImageList1
        Me.btAddBlok.Location = New System.Drawing.Point(811, 80)
        Me.btAddBlok.Name = "btAddBlok"
        Me.btAddBlok.Size = New System.Drawing.Size(84, 23)
        Me.btAddBlok.TabIndex = 14
        Me.btAddBlok.Text = "Nieuw"
        Me.btAddBlok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAddBlok.UseVisualStyleBackColor = True
        '
        'btDeleteBlok
        '
        Me.btDeleteBlok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btDeleteBlok.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btDeleteBlok.ImageIndex = 7
        Me.btDeleteBlok.ImageList = Me.ImageList1
        Me.btDeleteBlok.Location = New System.Drawing.Point(811, 109)
        Me.btDeleteBlok.Name = "btDeleteBlok"
        Me.btDeleteBlok.Size = New System.Drawing.Size(84, 23)
        Me.btDeleteBlok.TabIndex = 15
        Me.btDeleteBlok.Text = "Verwijderen"
        Me.btDeleteBlok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btDeleteBlok.UseVisualStyleBackColor = True
        '
        'chkShowDummies
        '
        Me.chkShowDummies.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowDummies.AutoSize = True
        Me.chkShowDummies.Location = New System.Drawing.Point(811, 28)
        Me.chkShowDummies.Name = "chkShowDummies"
        Me.chkShowDummies.Size = New System.Drawing.Size(87, 17)
        Me.chkShowDummies.TabIndex = 16
        Me.chkShowDummies.Text = "Geblokkeerd"
        Me.chkShowDummies.UseVisualStyleBackColor = True
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.Text = ""
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "LocatieNaam"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Locatie"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Datum"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Datum"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "BlokTypeAanvang"
        DataGridViewCellStyle3.Format = "HH:mm"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.HeaderText = "Aanvang"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BlokTypeTijdsDuur"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Tijdsduur"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Volgendetijdstip"
        DataGridViewCellStyle4.Format = "HH:mm"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn6.HeaderText = "Volgend tijdstip"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "VanafOfTot"
        Me.DataGridViewTextBoxColumn7.HeaderText = "VanafOfTot"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "AantalTotaal"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Aantal"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "AantalBoekingen"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Boekingen"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "AantalBeschikbaar"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Beschikbaar"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Vol"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Vol"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "HaveDummies"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Dummy"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'frmAdviseurs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 571)
        Me.Controls.Add(Me.chkShowDummies)
        Me.Controls.Add(Me.btDeleteBlok)
        Me.Controls.Add(Me.btAddBlok)
        Me.Controls.Add(Me.btEditBlok)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblAantalBlokken)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblAantalBeschikbaar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblAantalBoekingen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNaam)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvBlokken)
        Me.Controls.Add(Me.lvAdviseurs)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmAdviseurs"
        Me.Text = "Adviseurs overzicht"
        CType(Me.dgvBlokken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvAdviseurs As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNaam As System.Windows.Forms.Label
    Friend WithEvents lblAantalBoekingen As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAantalBeschikbaar As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAantalBlokken As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NieuwBlokToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvBlokken As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btEditBlok As System.Windows.Forms.Button
    Friend WithEvents btAddBlok As System.Windows.Forms.Button
    Friend WithEvents btDeleteBlok As System.Windows.Forms.Button
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
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents chkShowDummies As CheckBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents LocatieNaam As DataGridViewTextBoxColumn
    Friend WithEvents Datum As DataGridViewTextBoxColumn
    Friend WithEvents Aanvang As DataGridViewTextBoxColumn
    Friend WithEvents Tijdsduur As DataGridViewTextBoxColumn
    Friend WithEvents Volgendetijdstip As DataGridViewTextBoxColumn
    Friend WithEvents VanafOfTot As DataGridViewTextBoxColumn
    Friend WithEvents Aantal As DataGridViewTextBoxColumn
    Friend WithEvents AantalBoekingen As DataGridViewTextBoxColumn
    Friend WithEvents AantalBeschikbaar As DataGridViewTextBoxColumn
    Friend WithEvents Vol As DataGridViewTextBoxColumn
End Class
