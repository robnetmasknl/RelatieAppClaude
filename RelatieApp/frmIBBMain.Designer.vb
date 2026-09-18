<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIBBMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIBBMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lv = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvDossiers = New System.Windows.Forms.DataGridView()
        Me.tbDossierNr = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tvDossiers = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExpand = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbKenmerk = New System.Windows.Forms.TextBox()
        Me.btnKenmerk = New System.Windows.Forms.Button()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbActive = New System.Windows.Forms.RadioButton()
        Me.rbActiveFase = New System.Windows.Forms.RadioButton()
        Me.cmbBehandelaar = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DossierNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Onderwerp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Besluit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnMFA = New System.Windows.Forms.Button()
        CType(Me.dgvDossiers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lv
        '
        Me.lv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lv.HideSelection = False
        Me.lv.Location = New System.Drawing.Point(22, 76)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(306, 664)
        Me.lv.TabIndex = 0
        Me.lv.UseCompatibleStateImageBehavior = False
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
        Me.ImageList1.Images.SetKeyName(9, "zoom-.ico")
        Me.ImageList1.Images.SetKeyName(10, "zoom+.ico")
        Me.ImageList1.Images.SetKeyName(11, "user group.ico")
        Me.ImageList1.Images.SetKeyName(12, "user2.ico")
        '
        'dgvDossiers
        '
        Me.dgvDossiers.AllowUserToResizeRows = False
        Me.dgvDossiers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDossiers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDossiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDossiers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.DossierNr, Me.CreateDate, Me.Onderwerp, Me.Fase, Me.Besluit})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDossiers.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDossiers.Location = New System.Drawing.Point(349, 76)
        Me.dgvDossiers.Name = "dgvDossiers"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDossiers.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDossiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDossiers.Size = New System.Drawing.Size(623, 399)
        Me.dgvDossiers.TabIndex = 1
        '
        'tbDossierNr
        '
        Me.tbDossierNr.Location = New System.Drawing.Point(63, 14)
        Me.tbDossierNr.Name = "tbDossierNr"
        Me.tbDossierNr.Size = New System.Drawing.Size(265, 20)
        Me.tbDossierNr.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(341, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Open"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tvDossiers
        '
        Me.tvDossiers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvDossiers.ImageIndex = 12
        Me.tvDossiers.ImageList = Me.ImageList1
        Me.tvDossiers.Location = New System.Drawing.Point(349, 528)
        Me.tvDossiers.Name = "tvDossiers"
        Me.tvDossiers.SelectedImageIndex = 0
        Me.tvDossiers.Size = New System.Drawing.Size(623, 212)
        Me.tvDossiers.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Naam:"
        '
        'btnExpand
        '
        Me.btnExpand.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExpand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpand.ImageIndex = 10
        Me.btnExpand.ImageList = Me.ImageList1
        Me.btnExpand.Location = New System.Drawing.Point(349, 499)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(82, 23)
        Me.btnExpand.TabIndex = 8
        Me.btnExpand.Text = "Uitvouwen"
        Me.btnExpand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExpand.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(606, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Dubbelklik op het gewenste dossier om te openen."
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(437, 504)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Moeder dossiers"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(439, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Kenmerk:"
        '
        'tbKenmerk
        '
        Me.tbKenmerk.Location = New System.Drawing.Point(497, 13)
        Me.tbKenmerk.Name = "tbKenmerk"
        Me.tbKenmerk.Size = New System.Drawing.Size(265, 20)
        Me.tbKenmerk.TabIndex = 13
        '
        'btnKenmerk
        '
        Me.btnKenmerk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKenmerk.ImageIndex = 10
        Me.btnKenmerk.ImageList = Me.ImageList1
        Me.btnKenmerk.Location = New System.Drawing.Point(768, 12)
        Me.btnKenmerk.Name = "btnKenmerk"
        Me.btnKenmerk.Size = New System.Drawing.Size(75, 23)
        Me.btnKenmerk.TabIndex = 15
        Me.btnKenmerk.Text = "Zoek"
        Me.btnKenmerk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKenmerk.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Location = New System.Drawing.Point(22, 47)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(83, 17)
        Me.rbAll.TabIndex = 17
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "Alle dossiers"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbActive
        '
        Me.rbActive.AutoSize = True
        Me.rbActive.Location = New System.Drawing.Point(111, 47)
        Me.rbActive.Name = "rbActive"
        Me.rbActive.Size = New System.Drawing.Size(102, 17)
        Me.rbActive.TabIndex = 18
        Me.rbActive.TabStop = True
        Me.rbActive.Text = "Actieve dossiers"
        Me.rbActive.UseVisualStyleBackColor = True
        '
        'rbActiveFase
        '
        Me.rbActiveFase.AutoSize = True
        Me.rbActiveFase.Location = New System.Drawing.Point(219, 47)
        Me.rbActiveFase.Name = "rbActiveFase"
        Me.rbActiveFase.Size = New System.Drawing.Size(94, 17)
        Me.rbActiveFase.TabIndex = 19
        Me.rbActiveFase.TabStop = True
        Me.rbActiveFase.Text = "actief met fase"
        Me.rbActiveFase.UseVisualStyleBackColor = True
        '
        'cmbBehandelaar
        '
        Me.cmbBehandelaar.FormattingEnabled = True
        Me.cmbBehandelaar.Location = New System.Drawing.Point(405, 46)
        Me.cmbBehandelaar.Name = "cmbBehandelaar"
        Me.cmbBehandelaar.Size = New System.Drawing.Size(151, 21)
        Me.cmbBehandelaar.TabIndex = 91
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(334, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Behandelaar:"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Dossiernr"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Dossiernr"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CreateDate"
        Me.DataGridViewTextBoxColumn2.HeaderText = "aanmaakdatum"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Onderwerp"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Onderwerp"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Onderwerp"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Onderwerp"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Fase"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Besluit"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'DossierNr
        '
        Me.DossierNr.DataPropertyName = "DossierNr"
        Me.DossierNr.HeaderText = "Dossiernr"
        Me.DossierNr.Name = "DossierNr"
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "aanmaakdatum"
        Me.CreateDate.Name = "CreateDate"
        '
        'Onderwerp
        '
        Me.Onderwerp.DataPropertyName = "Onderwerp"
        Me.Onderwerp.HeaderText = "Onderwerp"
        Me.Onderwerp.Name = "Onderwerp"
        '
        'Fase
        '
        Me.Fase.HeaderText = "Fase"
        Me.Fase.Name = "Fase"
        '
        'Besluit
        '
        Me.Besluit.HeaderText = "Besluit"
        Me.Besluit.Name = "Besluit"
        '
        'btnMFA
        '
        Me.btnMFA.Location = New System.Drawing.Point(871, 11)
        Me.btnMFA.Name = "btnMFA"
        Me.btnMFA.Size = New System.Drawing.Size(75, 23)
        Me.btnMFA.TabIndex = 92
        Me.btnMFA.Text = "MFA"
        Me.btnMFA.UseVisualStyleBackColor = True
        '
        'frmIBBMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 762)
        Me.Controls.Add(Me.btnMFA)
        Me.Controls.Add(Me.cmbBehandelaar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.rbActiveFase)
        Me.Controls.Add(Me.rbActive)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.btnKenmerk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbKenmerk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExpand)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tvDossiers)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.tbDossierNr)
        Me.Controls.Add(Me.dgvDossiers)
        Me.Controls.Add(Me.lv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIBBMain"
        Me.Text = "IBB hoofdscherm"
        CType(Me.dgvDossiers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dgvDossiers As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DossierNr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Onderwerp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Besluit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbDossierNr As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents tvDossiers As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExpand As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbKenmerk As System.Windows.Forms.TextBox
    Friend WithEvents btnKenmerk As System.Windows.Forms.Button
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbActive As System.Windows.Forms.RadioButton
    Friend WithEvents rbActiveFase As System.Windows.Forms.RadioButton
    Friend WithEvents cmbBehandelaar As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnMFA As Button
End Class
