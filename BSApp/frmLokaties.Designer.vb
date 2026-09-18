<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmlocaties
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmlocaties))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvLocaties = New System.Windows.Forms.ListView()
        Me.ContextLocaties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextBewerken = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvBlokken = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdviseurNaam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aanvang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tijdsduur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Volgendetijdstip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aantal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AantalBoekingen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AantalBeschikbaar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblAantalBlokken = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAantalBeschikbaar = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAantalBoekingen = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNaam = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPrintList = New System.Windows.Forms.Button()
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
        Me.chkShowDummies = New System.Windows.Forms.CheckBox()
        Me.ContextLocaties.SuspendLayout()
        CType(Me.dgvBlokken, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "locaties:"
        '
        'lvLocaties
        '
        Me.lvLocaties.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvLocaties.ContextMenuStrip = Me.ContextLocaties
        Me.lvLocaties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvLocaties.HideSelection = False
        Me.lvLocaties.Location = New System.Drawing.Point(12, 56)
        Me.lvLocaties.Name = "lvLocaties"
        Me.lvLocaties.Size = New System.Drawing.Size(182, 490)
        Me.lvLocaties.TabIndex = 13
        Me.lvLocaties.UseCompatibleStateImageBehavior = False
        '
        'ContextLocaties
        '
        Me.ContextLocaties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextBewerken})
        Me.ContextLocaties.Name = "ContextLocaties"
        Me.ContextLocaties.Size = New System.Drawing.Size(126, 26)
        '
        'ContextBewerken
        '
        Me.ContextBewerken.Name = "ContextBewerken"
        Me.ContextBewerken.Size = New System.Drawing.Size(125, 22)
        Me.ContextBewerken.Text = "Bewerken"
        '
        'dgvBlokken
        '
        Me.dgvBlokken.AllowUserToAddRows = False
        Me.dgvBlokken.AllowUserToDeleteRows = False
        Me.dgvBlokken.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBlokken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBlokken.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.AdviseurNaam, Me.Datum, Me.Aanvang, Me.Tijdsduur, Me.Volgendetijdstip, Me.Aantal, Me.AantalBoekingen, Me.AantalBeschikbaar, Me.Vol})
        Me.dgvBlokken.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvBlokken.Location = New System.Drawing.Point(221, 151)
        Me.dgvBlokken.MultiSelect = False
        Me.dgvBlokken.Name = "dgvBlokken"
        Me.dgvBlokken.RowHeadersVisible = False
        Me.dgvBlokken.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvBlokken.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBlokken.Size = New System.Drawing.Size(671, 395)
        Me.dgvBlokken.TabIndex = 15
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'AdviseurNaam
        '
        Me.AdviseurNaam.DataPropertyName = "AdviseurNaam"
        Me.AdviseurNaam.HeaderText = "Adviseur"
        Me.AdviseurNaam.Name = "AdviseurNaam"
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
        DataGridViewCellStyle5.Format = "HH:mm"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Aanvang.DefaultCellStyle = DataGridViewCellStyle5
        Me.Aanvang.HeaderText = "Aanvang"
        Me.Aanvang.Name = "Aanvang"
        '
        'Tijdsduur
        '
        Me.Tijdsduur.DataPropertyName = "BlokTypeTijdsduur"
        Me.Tijdsduur.HeaderText = "Tijdsduur"
        Me.Tijdsduur.Name = "Tijdsduur"
        '
        'Volgendetijdstip
        '
        Me.Volgendetijdstip.DataPropertyName = "Volgendetijdstip"
        Me.Volgendetijdstip.HeaderText = "Volgend tijdstip"
        Me.Volgendetijdstip.Name = "Volgendetijdstip"
        '
        'Aantal
        '
        Me.Aantal.DataPropertyName = "BlokTypeAantal"
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
        'lblAantalBlokken
        '
        Me.lblAantalBlokken.AutoSize = True
        Me.lblAantalBlokken.Location = New System.Drawing.Point(363, 77)
        Me.lblAantalBlokken.Name = "lblAantalBlokken"
        Me.lblAantalBlokken.Size = New System.Drawing.Size(16, 13)
        Me.lblAantalBlokken.TabIndex = 23
        Me.lblAantalBlokken.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Aantal blokken:"
        '
        'lblAantalBeschikbaar
        '
        Me.lblAantalBeschikbaar.AutoSize = True
        Me.lblAantalBeschikbaar.Location = New System.Drawing.Point(363, 122)
        Me.lblAantalBeschikbaar.Name = "lblAantalBeschikbaar"
        Me.lblAantalBeschikbaar.Size = New System.Drawing.Size(16, 13)
        Me.lblAantalBeschikbaar.TabIndex = 21
        Me.lblAantalBeschikbaar.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Aantal beschikbare:"
        '
        'lblAantalBoekingen
        '
        Me.lblAantalBoekingen.AutoSize = True
        Me.lblAantalBoekingen.Location = New System.Drawing.Point(363, 100)
        Me.lblAantalBoekingen.Name = "lblAantalBoekingen"
        Me.lblAantalBoekingen.Size = New System.Drawing.Size(16, 13)
        Me.lblAantalBoekingen.TabIndex = 19
        Me.lblAantalBoekingen.Text = "..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Aantal boekingen:"
        '
        'lblNaam
        '
        Me.lblNaam.AutoSize = True
        Me.lblNaam.Location = New System.Drawing.Point(363, 56)
        Me.lblNaam.Name = "lblNaam"
        Me.lblNaam.Size = New System.Drawing.Size(16, 13)
        Me.lblNaam.TabIndex = 17
        Me.lblNaam.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "locatie:"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "home.ico")
        Me.ImageList1.Images.SetKeyName(1, "home_zw.ico")
        '
        'btnPrintList
        '
        Me.btnPrintList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintList.Location = New System.Drawing.Point(817, 56)
        Me.btnPrintList.Name = "btnPrintList"
        Me.btnPrintList.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintList.TabIndex = 24
        Me.btnPrintList.Text = "Print lijst"
        Me.btnPrintList.UseVisualStyleBackColor = True
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "AdviseurNaam"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Adviseur"
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
        DataGridViewCellStyle6.Format = "HH:mm"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn4.HeaderText = "Aanvang"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BlokTypeTijdsduur"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Tijdsduur"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Volgendetijdstip"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Volgend tijdstip"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "BlokTypeAantal"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Aantal"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "AantalBoekingen"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Boekingen"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "AantalBeschikbaar"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Beschikbaar"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Vol"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Vol"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'chkShowDummies
        '
        Me.chkShowDummies.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkShowDummies.AutoSize = True
        Me.chkShowDummies.Location = New System.Drawing.Point(805, 33)
        Me.chkShowDummies.Name = "chkShowDummies"
        Me.chkShowDummies.Size = New System.Drawing.Size(87, 17)
        Me.chkShowDummies.TabIndex = 25
        Me.chkShowDummies.Text = "Geblokkeerd"
        Me.chkShowDummies.UseVisualStyleBackColor = True
        '
        'frmlocaties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 571)
        Me.Controls.Add(Me.chkShowDummies)
        Me.Controls.Add(Me.btnPrintList)
        Me.Controls.Add(Me.lblAantalBlokken)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblAantalBeschikbaar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblAantalBoekingen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNaam)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvBlokken)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvLocaties)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmlocaties"
        Me.Text = "locaties"
        Me.ContextLocaties.ResumeLayout(False)
        CType(Me.dgvBlokken, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvLocaties As System.Windows.Forms.ListView
    Friend WithEvents dgvBlokken As System.Windows.Forms.DataGridView
    Friend WithEvents lblAantalBlokken As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblAantalBeschikbaar As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAantalBoekingen As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNaam As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdviseurNaam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Datum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aanvang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tijdsduur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Volgendetijdstip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aantal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AantalBoekingen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AantalBeschikbaar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextLocaties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextBewerken As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrintList As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents chkShowDummies As CheckBox
End Class
