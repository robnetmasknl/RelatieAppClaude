<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoekingen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoekingen))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpDatum = New System.Windows.Forms.DateTimePicker()
        Me.dtpAanvang = New System.Windows.Forms.DateTimePicker()
        Me.lblAdviseur = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tbLidNr = New System.Windows.Forms.TextBox()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbBrief = New System.Windows.Forms.ToolStripButton()
        Me.tsbAdviseurAanpassen = New System.Windows.Forms.ToolStripButton()
        Me.tbRelatieId = New System.Windows.Forms.TextBox()
        Me.dgvBoekingen = New System.Windows.Forms.DataGridView()
        Me.delete = New BusinessObjects.DataGridViewDisableButton()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lidnaam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lidnr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tijdstip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Voorlopig = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.relatieId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvBoekingen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpDatum
        '
        Me.dtpDatum.CustomFormat = "dd-MM-yyyy"
        Me.dtpDatum.Enabled = False
        Me.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDatum.Location = New System.Drawing.Point(126, 80)
        Me.dtpDatum.Name = "dtpDatum"
        Me.dtpDatum.Size = New System.Drawing.Size(152, 20)
        Me.dtpDatum.TabIndex = 28
        '
        'dtpAanvang
        '
        Me.dtpAanvang.CustomFormat = "HH:mm"
        Me.dtpAanvang.Enabled = False
        Me.dtpAanvang.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAanvang.Location = New System.Drawing.Point(126, 110)
        Me.dtpAanvang.Name = "dtpAanvang"
        Me.dtpAanvang.ShowUpDown = True
        Me.dtpAanvang.Size = New System.Drawing.Size(152, 20)
        Me.dtpAanvang.TabIndex = 27
        Me.dtpAanvang.Value = New Date(2010, 9, 24, 15, 30, 9, 0)
        '
        'lblAdviseur
        '
        Me.lblAdviseur.Location = New System.Drawing.Point(11, 29)
        Me.lblAdviseur.Name = "lblAdviseur"
        Me.lblAdviseur.Size = New System.Drawing.Size(865, 15)
        Me.lblAdviseur.TabIndex = 23
        Me.lblAdviseur.Text = "Adviseur..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Lidmaatschapnummer:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Aanvang:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Datum:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(284, 110)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Opslaan"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tbLidNr
        '
        Me.tbLidNr.BackColor = System.Drawing.Color.White
        Me.tbLidNr.Location = New System.Drawing.Point(126, 54)
        Me.tbLidNr.Name = "tbLidNr"
        Me.tbLidNr.ReadOnly = True
        Me.tbLidNr.Size = New System.Drawing.Size(152, 20)
        Me.tbLidNr.TabIndex = 32
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(284, 56)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(75, 23)
        Me.btSearch.TabIndex = 33
        Me.btSearch.Text = "Zoeken"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Boekingen:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbBrief, Me.tsbAdviseurAanpassen, Me.tsbRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(899, 25)
        Me.ToolStrip1.TabIndex = 37
        Me.ToolStrip1.Text = "Brief"
        '
        'tsbBrief
        '
        Me.tsbBrief.Image = Global.BSApp.My.Resources.Images.icon_word
        Me.tsbBrief.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBrief.Name = "tsbBrief"
        Me.tsbBrief.Size = New System.Drawing.Size(51, 22)
        Me.tsbBrief.Text = "Brief"
        '
        'tsbAdviseurAanpassen
        '
        Me.tsbAdviseurAanpassen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAdviseurAanpassen.Image = CType(resources.GetObject("tsbAdviseurAanpassen.Image"), System.Drawing.Image)
        Me.tsbAdviseurAanpassen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdviseurAanpassen.Name = "tsbAdviseurAanpassen"
        Me.tsbAdviseurAanpassen.Size = New System.Drawing.Size(117, 22)
        Me.tsbAdviseurAanpassen.Text = "Adviseur Aanpassen"
        '
        'tbRelatieId
        '
        Me.tbRelatieId.BackColor = System.Drawing.Color.White
        Me.tbRelatieId.Location = New System.Drawing.Point(378, 58)
        Me.tbRelatieId.Name = "tbRelatieId"
        Me.tbRelatieId.ReadOnly = True
        Me.tbRelatieId.Size = New System.Drawing.Size(91, 20)
        Me.tbRelatieId.TabIndex = 38
        '
        'dgvBoekingen
        '
        Me.dgvBoekingen.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        Me.dgvBoekingen.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBoekingen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBoekingen.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvBoekingen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBoekingen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.delete, Me.id, Me.Lidnaam, Me.Lidnr, Me.Tijdstip, Me.Voorlopig, Me.relatieId})
        Me.dgvBoekingen.Location = New System.Drawing.Point(12, 184)
        Me.dgvBoekingen.MultiSelect = False
        Me.dgvBoekingen.Name = "dgvBoekingen"
        Me.dgvBoekingen.RowHeadersVisible = False
        Me.dgvBoekingen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBoekingen.Size = New System.Drawing.Size(875, 381)
        Me.dgvBoekingen.TabIndex = 0
        '
        'delete
        '
        Me.delete.FillWeight = 75.0!
        Me.delete.HeaderText = "verwijderen"
        Me.delete.Name = "delete"
        Me.delete.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.delete.Text = "verwijderen"
        Me.delete.UseColumnTextForButtonValue = True
        Me.delete.Width = 75
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.FillWeight = 50.0!
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'Lidnaam
        '
        Me.Lidnaam.DataPropertyName = "Lidnaam"
        Me.Lidnaam.FillWeight = 200.0!
        Me.Lidnaam.HeaderText = "Lidnaam"
        Me.Lidnaam.Name = "Lidnaam"
        Me.Lidnaam.ReadOnly = True
        Me.Lidnaam.Width = 200
        '
        'Lidnr
        '
        Me.Lidnr.DataPropertyName = "Lidnr"
        Me.Lidnr.HeaderText = "Lidnr"
        Me.Lidnr.Name = "Lidnr"
        Me.Lidnr.ReadOnly = True
        Me.Lidnr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Tijdstip
        '
        Me.Tijdstip.DataPropertyName = "Tijdstip"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "dd-MM-yyyy HH:mm"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tijdstip.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tijdstip.FillWeight = 150.0!
        Me.Tijdstip.HeaderText = "Tijdstip"
        Me.Tijdstip.Name = "Tijdstip"
        Me.Tijdstip.ReadOnly = True
        Me.Tijdstip.Width = 150
        '
        'Voorlopig
        '
        Me.Voorlopig.DataPropertyName = "Voorlopig"
        Me.Voorlopig.FalseValue = "False"
        Me.Voorlopig.HeaderText = "Verwerkt"
        Me.Voorlopig.Name = "Voorlopig"
        Me.Voorlopig.ReadOnly = True
        Me.Voorlopig.TrueValue = "True"
        '
        'relatieId
        '
        Me.relatieId.DataPropertyName = "relatieId"
        Me.relatieId.HeaderText = "relatieId"
        Me.relatieId.Name = "relatieId"
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRefresh.Image = Global.BSApp.My.Resources.Images.refresh
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tsbRefresh.Text = "vernieuwen"
        '
        'frmBoekingen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 577)
        Me.Controls.Add(Me.tbRelatieId)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btSearch)
        Me.Controls.Add(Me.tbLidNr)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dtpDatum)
        Me.Controls.Add(Me.dtpAanvang)
        Me.Controls.Add(Me.lblAdviseur)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvBoekingen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBoekingen"
        Me.Text = "Boekingen"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvBoekingen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBoekingen As System.Windows.Forms.DataGridView
    Friend WithEvents dtpDatum As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpAanvang As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAdviseur As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tbLidNr As System.Windows.Forms.TextBox
    Friend WithEvents btSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbBrief As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbRelatieId As System.Windows.Forms.TextBox
    Friend WithEvents tsbAdviseurAanpassen As System.Windows.Forms.ToolStripButton
    Friend WithEvents delete As BusinessObjects.DataGridViewDisableButton
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Lidnaam As DataGridViewTextBoxColumn
    Friend WithEvents Lidnr As DataGridViewTextBoxColumn
    Friend WithEvents Tijdstip As DataGridViewTextBoxColumn
    Friend WithEvents Voorlopig As DataGridViewCheckBoxColumn
    Friend WithEvents relatieId As DataGridViewTextBoxColumn
    Friend WithEvents tsbRefresh As ToolStripButton
End Class
