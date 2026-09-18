Imports BusinessObjects
Imports System.Drawing.Printing
Imports MapiObjects
Imports System.IO
Imports Microsoft.Office.Interop

Public Class frmIBBDossier
    Public Event Added(ByVal added As Boolean)
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess
    Private myTemplates As Templates = New Templates
    Public MyIBBDossier As IBBDossier
    Private MinDateValue As DateTime = "30-12-1899"
    Private TempEmlPath = System.IO.Path.GetTempPath()

    'Private myFasesList As List(Of IBBFase)
    Private iCurrentFaseType As Integer = -1

    Private _MyRelatie As Relaties
    Public Property MyRelatie() As Relaties
        Get
            If _MyRelatie Is Nothing Then
                _MyRelatie = New Relaties(MyIBBDossier.LidId, Relaties.Via.ID)
            End If
            Return _MyRelatie
        End Get
        Set(ByVal value As Relaties)
            _MyRelatie = value
        End Set
    End Property

    Private _ews As EwsReader
    Public Property ews() As EwsReader
        Get
            If _ews Is Nothing Then
                _ews = New EwsReader(True)
            End If
            Return _ews
        End Get
        Set(ByVal value As EwsReader)
            _ews = value
        End Set
    End Property

    'Private Sub FontSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontSizeToolStripMenuItem.Click
    '    Dim frm As New FontDialog
    '    frm.Font = Me.Font
    '    frm.ShowDialog()
    '    da.Settings.FontSize = frm.Font.Size
    '    da.Settings.FontFamily = frm.Font.FontFamily.Name
    '     da.Settings.FontStyle = frm.Font.Style
    '    da.Settings.Save()
    '    Changelayout()
    'End Sub
    Private Sub Changelayout()
        Dim style As FontStyle = CInt(da.Settings.FontStyle)
        Dim newFont As Font = New System.Drawing.Font(da.Settings.FontFamily, da.Settings.FontSize, style)
        Me.Font = newFont
        'Me.ParentForm.Font = newFont
    End Sub

    Private Sub frmIBBDossier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ' Changelayout()

            lblHiddenId.Visible = False
            If URights.IsInGroup("rel_admins") Then
                'ga dan door
                lblHiddenId.Visible = True
            ElseIf URights.IsInGroup("rel_ibb_admins") Then
                'ga dan door
            ElseIf URights.IsInGroup("rel_ibb_users") Then
                'ga dan door
                'eventueel controleren of dit de behandelaar is?
                'maar dan alleen als het in de systeeminstellingen op true staat.
                Dim SetbPermissions As String = GetSysSettingOf("SetDossierDirPermissions", False)
                If SetbPermissions.ToLower = "true" Then
                    If Not MyIBBDossier Is Nothing Then
                        If MyIBBDossier.myBehandelaar.ExchangeAccount.ToLower <> URights.UserName.ToLower Then
                            Dim myHistory As New History
                            myHistory.LidId = MyIBBDossier.Id
                            myHistory.TableName = "IBBDossiers"
                            myHistory.Veld = "Beveiliging"
                            myHistory.WaardeOud = ""
                            myHistory.WaardeNieuw = "inlogpoging door " & URights.UserName
                            myHistory.MutDate = Now
                            myHistory.MutDoor = URights.UserName
                            myHistory.Save()
                            MessageBox.Show(URights.UserName & ", U bent niet de behandelaar van dit dossier!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                        End If
                    End If
                End If

            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If CreateDefaultLabels Then CreateLabelXml(Me, Me.Name, True)
            GetLabelText(Me, Me.Name)

            If MyRelatie Is Nothing Then
                Throw New Exception("Er is geen relatie!")
            End If

            lblRelatienaam.Text = MyRelatie.FullName
            lblLidNr.Text = MyRelatie.lidnr
            lblRegistratienr.Text = MyRelatie.rnr

            tbDossiernr.Enabled = MyIBBDossier Is Nothing

            If MyIBBDossier Is Nothing Then
                'Throw New Exception("Er is geen IBBDossier!")
                MyIBBDossier = New IBBDossier
                MyIBBDossier.DossierNr = MyIBBDossier.NewDossierNr
                MyIBBDossier.LidId = MyRelatie.Id
                MyIBBDossier.CreateDate = Today
                Dim rbJuridish As New RadioButton
                Dim rbKlacht As New RadioButton

                rbKlacht.Text = "Klacht"
                Dim dlgAsk As New dlgAskIt
                Dim LastY As Integer = 0
                Dim iLabelPositionX As Integer = 0
                Dim mylabel As New Label
                dlgAsk.Name = "dlgAskJK"
                dlgAsk.StartPosition = FormStartPosition.CenterScreen
                mylabel.Name = "lblText"
                mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                mylabel.Text = "Is het dossier een juridisch- of een klachtenprocedure"
                mylabel.AutoSize = True
                dlgAsk.Controls.Add(mylabel)

                rbJuridish.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
                rbJuridish.Name = "rbJuridish"
                rbJuridish.Text = "juridisch"
                rbJuridish.Checked = True
                dlgAsk.Controls.Add(rbJuridish)
                LastY = rbJuridish.Location.Y
                iLabelPositionX = rbJuridish.Location.X + 20

                rbKlacht.Location = New Point(mylabel.Location.X, LastY + 20)
                rbKlacht.Name = "rbKlacht"
                rbKlacht.Text = "Klacht"
                dlgAsk.Controls.Add(rbKlacht)
                LastY = rbKlacht.Location.Y
                iLabelPositionX = rbJuridish.Location.X + 20

                If CreateDefaultLabels Then CreateLabelXml(dlgAsk, dlgAsk.Name, True)
                GetLabelText(dlgAsk, "dlgAskJK")

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    Exit Sub
                Else

                    If rbKlacht.Checked Then
                        MyIBBDossier.DossierSort = "K"
                    ElseIf rbJuridish.Checked Then
                        MyIBBDossier.DossierSort = "J"
                    End If
                End If
            Else
                If MyIBBDossier.ListIBBFases.Count > 0 Then
                    rbKlacht.Enabled = False
                    rbJuridisch.Enabled = False
                End If

            End If

            lblHiddenId.Text = MyIBBDossier.Id
            'Dim EmailBerichten As List(Of Berichten)
            'EmailBerichten = MyIBBDossier.EmailBerichten

            BindTexBox()
            GriffieKostenUpdate()
            ProcessKostenUpdate()
            ExterneKostenUpdate()

            FillCmb()
            FillListViewTypes()
            FillAllDocuments()
            FillListViewDocuments()


            AddHandler rbJuridisch.CheckedChanged, AddressOf rbSort_CheckedChanged
            AddHandler rbKlacht.CheckedChanged, AddressOf rbSort_CheckedChanged

            AddHandler GeelToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler GroenToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler BlauwToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler OranjeToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler PaarsToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler RoodToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler RozeToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler BruinToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler OlijfToolStripMenuItem.Click, AddressOf Classificatie_Click
            AddHandler GeenToolStripMenuItem.Click, AddressOf Classificatie_Click


            tbOnderwerp.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BindTexBox()
        Try

            MyIBBDossier.LidId = MyRelatie.Id

            tbCreateDate.DataBindings.Add("Text", MyIBBDossier, "CreateDate", True)
            ' tbEndDate.DataBindings.Add("Text", MyIBBDossier, "EndDate")
            ' tbEndDate.DataBindings.Add("Text", MyIBBDossier, "EndDate", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")
            uctdEndDate.Value = MyIBBDossier.EndDate
            'tbMut_door.DataBindings.Add("Text", MyIBBDossier, "CreateDate")
            cmbRubriek.DataBindings.Add("SelectedValue", MyIBBDossier, "RubriekId", True)
            tbMoederDossier.DataBindings.Add("Text", MyIBBDossier, "MoederDossier")
            tbDossiernr.DataBindings.Add("Text", MyIBBDossier, "dossierNr")
            tbOnderwerp.DataBindings.Add("Text", MyIBBDossier, "Onderwerp")
            tbAfgehandeld.DataBindings.Add("Text", MyIBBDossier, "AfgehandeldReden")
            chkAfgehandeld.DataBindings.Add("Checked", MyIBBDossier, "Afgehandeld", True)
            tbOpmerkingen.DataBindings.Add("Text", MyIBBDossier, "Opmerkingen")
            tbExternDetails.DataBindings.Add("Text", MyIBBDossier, "ExtDeskText")
            cmbIBBGroep.DataBindings.Add("SelectedValue", MyIBBDossier, "IBBGroep", True)
            tbNotities.DataBindings.Add("Text", MyIBBDossier, "Notities", True)

            If MyIBBDossier.DossierSort = "J" Then
                Me.rbJuridisch.Checked = True
            Else
                Me.rbKlacht.Checked = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GriffieKostenUpdate()
        Try
            'MyIBBDossier._ListGriffieKosten = Nothing

            Dim GriffieBindingSource As New BindingSource
            GriffieBindingSource.DataSource = Me.MyIBBDossier.ListGriffieKosten(True)
            dgvGriffieKosten.AutoGenerateColumns = False
            dgvGriffieKosten.DataSource = GriffieBindingSource

            Dim dcTotalGriffie As Decimal = 0
            For Each griffie As IBBGriffieKosten In Me.MyIBBDossier.ListGriffieKosten
                If String.IsNullOrEmpty(griffie.RepaidClientDate) Then
                    dcTotalGriffie += griffie.Amount
                End If
            Next

            tbGriffieTotal.Text = dcTotalGriffie

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessKostenUpdate()
        Try

            Dim ProcessCostBindingSource As New BindingSource
            ProcessCostBindingSource.DataSource = Me.MyIBBDossier.ListProcessKosten(True)
            dgvProcessKosten.AutoGenerateColumns = False
            dgvProcessKosten.DataSource = ProcessCostBindingSource


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ExterneKostenUpdate()
        Try

            Dim ExterneCostBindingSource As New BindingSource
            ExterneCostBindingSource.DataSource = Me.MyIBBDossier.ListExterneKosten(True)
            dgvExterneKosten.AutoGenerateColumns = False
            dgvExterneKosten.DataSource = ExterneCostBindingSource


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillCmb()
        Try
            Dim tblBehandelaren As DataTable = da.ExecuteDataTable("SELECT * FROM behandelaren ORDER BY naam")
            Dim tblRubrieken As DataTable = da.ExecuteDataTable("SELECT * FROM IBBRubrieken ORDER BY Rubriek")
            Dim tblIbbGroepen As DataTable = da.ExecuteDataTable("SELECT * FROM IBBGroepen ORDER BY Groep")

            If MyIBBDossier.BehandelaarId = 0 Then
                Dim dr As DataRow = tblBehandelaren.NewRow
                dr("id") = 0
                dr("Naam") = "Selecteer een behandelaar."
                'dr("id_naam") = "Selecteer een behandelaar."
                tblBehandelaren.Rows.InsertAt(dr, 0)
            End If
            cmbBehandelaar.DataSource = tblBehandelaren
            cmbBehandelaar.DisplayMember = "Naam"
            cmbBehandelaar.ValueMember = "id"
            cmbBehandelaar.SelectedValue = MyIBBDossier.BehandelaarId


            If MyIBBDossier.RubriekId = 0 Then
                Dim dr As DataRow = tblRubrieken.NewRow
                dr("Id") = 0
                dr("rubriek") = "Selecteer een rubriek."
                tblRubrieken.Rows.InsertAt(dr, 0)
            End If
            cmbRubriek.DataSource = tblRubrieken
            cmbRubriek.DisplayMember = "rubriek"
            cmbRubriek.ValueMember = "id"
            cmbRubriek.SelectedValue = MyIBBDossier.RubriekId

            If MyIBBDossier.IBBGroep = 0 Then
                Dim dr As DataRow = tblIbbGroepen.NewRow
                dr("Id") = 0
                dr("Groep") = "Selecteer een Groep."
                tblIbbGroepen.Rows.InsertAt(dr, 0)
            End If
            cmbIBBGroep.DataSource = tblIbbGroepen
            cmbIBBGroep.DisplayMember = "Groep"
            cmbIBBGroep.ValueMember = "id"
            cmbIBBGroep.SelectedValue = MyIBBDossier.IBBGroep



            Dim mnu As New ToolStripMenuItem
            Dim mnu1 As New ToolStripMenuItem
            mnu.Text = "Brieven"
            Dim tmpGroup As String = "Brieven"
            For Each rw As DataRow In myTemplates.dtTemplates.Rows
                If rw.Item("Afdeling").ToString.ToLower = "email" Then Continue For
                If tmpGroup <> rw.Item("Afdeling") Then
                    mnu1 = New ToolStripMenuItem
                    mnu1.Text = rw.Item("Afdeling")
                    mnu1.Size = New Point(150, 20)
                    mnu1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                    AddHandler mnu1.DropDownItemClicked, AddressOf CreateDoc
                End If
                mnu1.DropDownItems.Add(rw.Item("omschrijving"))

                mnu.DropDownItems.Add(mnu1)
                tmpGroup = rw.Item("Afdeling")
            Next

            mnu.Owner = ToolStrip1

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillGriffieTypes()
        Try
            cmbTypes.DataSource = Nothing
            cmbTypes.Items.Clear()
            Dim sql As String = "SELECT fs.Id, jd.description, jd.Type, fs.DossierId, jd.Seq FROM IBBFases fs " & _
                                  "inner join jdTypes jd on fs.TypeId = jd.Id " & _
                                  "where DossierId = @DossierId " & _
                                  "order by jd.seq "
            Dim param() As Object = {"@DossierId", MyIBBDossier.Id}
            Dim tblTypes As DataTable = da.ExecuteDataTable(sql, param)

            ' Dim tblTypes As DataTable = da.ExecuteDataTable("SELECT * FROM IBBGriffieKostenTypes Order By Id")
            Dim dr2 As DataRow = tblTypes.NewRow
            dr2("Id") = 0
            dr2("Type") = 0
            dr2("Description") = "geen"
            dr2("Seq") = 0
            tblTypes.Rows.InsertAt(dr2, 0)

            cmbTypes.DataSource = tblTypes
            cmbTypes.DisplayMember = "Description"
            cmbTypes.ValueMember = "Id"

            Dim tblProcessFases As DataTable
            tblProcessFases = tblTypes.Clone

            For Each rw As DataRow In tblTypes.Rows
                Select Case DirectCast(rw.Item("Seq"), Integer)
                    Case Is = 0
                        tblProcessFases.ImportRow(rw)
                    Case Is >= 20
                        tblProcessFases.ImportRow(rw)
                End Select
            Next

            cmbProcessFase.DataSource = tblProcessFases
            cmbProcessFase.DisplayMember = "Description"
            cmbProcessFase.ValueMember = "Id"

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub FillListViewTypes(Optional bRenew As Boolean = False)
        Try
            lvIBBFases.Clear()
            Dim lstViewItem As ListViewItem = New ListViewItem()

            If Me.MyIBBDossier.Id = 0 Then
                lvIBBFases.Enabled = False
                lblvIBBFasesDisabled.Visible = True
                lblvIBBFasesDisabled.Text = "nieuw dossier eerst opslaan."
            Else
                Me.Text = "IBB dossier: " & MyRelatie.FullName
                'If Not MyIBBDossier.CurrentFase Is Nothing Then
                'lblCurrentPhase.Text = MyIBBDossier.CurrentFase.Fase.Description
                lblCurrentPhase.Text = MyIBBDossier.CurrentFasesText
                'End If


                lvIBBFases.Enabled = True
                lblvIBBFasesDisabled.Visible = False
                ' Dim _jdtypes As New IBBDossierFaseList
                ' myFasesList = MyIBBDossier.ListIBBFases(True) '_jdtypes.FasesByDossier(Me.MyIBBDossier.Id)

                lvIBBFases.Columns.Add("Fase", 50, HorizontalAlignment.Left)
                lvIBBFases.Columns.Add("Datum", 80, HorizontalAlignment.Left)
                lvIBBFases.Columns.Add("besluit", 100, HorizontalAlignment.Left)
                lvIBBFases.Columns.Add("id", 0, HorizontalAlignment.Left)
                lvIBBFases.Columns.Add("TypeId", 0, HorizontalAlignment.Left)
                lvIBBFases.View = View.Details
                'lvJdTypes.StateImageList = ImageList1


                Dim AllowNewFase As Boolean = Not MyIBBDossier.Afgehandeld

                For Each jdt As IBBFase In MyIBBDossier.ListIBBFases(bRenew) ' myFasesList '_jdtypes.FasesByDossier(Me.MyIBBDossier.Id)
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = jdt.Fase.Type
                    lstViewItem.SubItems.Add(jdt.Indiendatum)
                    lstViewItem.SubItems.Add(jdt.Besluit)
                    lstViewItem.SubItems.Add(jdt.Id)
                    lstViewItem.SubItems.Add(jdt.TypeId)
                    lvIBBFases.Items.Add(lstViewItem)
                    'If AllowNewFase = True Then
                    '    AllowNewFase = jdt.Besluit <> 0
                    'End If
                Next

                If AllowNewFase = True Then
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = "Nieuwe toevoegen"
                    lstViewItem.SubItems.Add("0")
                    lstViewItem.SubItems.Add("0")
                    lstViewItem.SubItems.Add("0")
                    lstViewItem.SubItems.Add("0")
                    lvIBBFases.Items.Add(lstViewItem)
                End If

                If lvIBBFases.Items.Count > 1 Then
                    lvIBBFases.EnsureVisible(lvIBBFases.Items.Count - 1)
                End If

            End If

            FillGriffieTypes()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnDatum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim tb As TextBox = FindFormControl(Me, sender.tag)
            Dim DateValue As DateTime
            If tb.Text = String.Empty Or tb.Text = MinDateValue.ToShortDateString Then
                DateValue = Today
            Else
                DateValue = tb.Text
            End If
            Dim TopForm As New dlgDate(DateValue)
            Dim result As DialogResult = TopForm.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                tb.Text = Format(TopForm.ndtpDatum.Value, "dd-MM-yyyy")
                Me.SelectNextControl(ActiveControl, True, True, True, True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tb_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If String.IsNullOrEmpty(sender.text) Then Exit Try
            'sender.text = Replace(sender.text, "--", "-")
            If Not Utilities.ValidateDate(sender.text) Then
                'probeer dan of het een misschien kortedatum is
                Try
                    Dim tmpdate As Date = sender.text
                    sender.text = Format(sender.text, tmpdate.ToShortDateString)
                Catch ex As Exception
                    sender.focus()
                    Throw New Exception("Geen geldig datum formaat" & vbCrLf & "Juiste formaat: ''dd-MM-jjjj''")
                End Try

                If Not Utilities.ValidateDate(sender.text) Then
                    sender.focus()
                    Throw New Exception("Geen geldig datum formaat" & vbCrLf & "Juiste formaat: ''dd-MM-jjjj''")
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbSort_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ActiveControl Is sender Then
            Dim radio As New RadioButton
            radio = sender
            MyIBBDossier.DossierSort = radio.Tag
        End If
    End Sub
    Private Sub CreateDoc(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs)
        Try
            If MyIBBDossier.Id < 1 Then Throw New Exception("Het dossier moet eerst worden opgeslagen!")

            Dim _afdeling As String = DirectCast(sender, System.Windows.Forms.ToolStripMenuItem).Text
            Dim _sjabloon As String = e.ClickedItem.ToString
            Dim _TemplateId As Integer = myTemplates.GetTemplateId(_sjabloon, _afdeling)

            If _TemplateId > 0 Then
                Dim newWord As New OfficeObjects.WordMerge
                newWord.CurrentDr = MyRelatie.ExportRow
                'newWord.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\merge.txt"
                newWord.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\merge.txt"

                Dim dlgSave As New dlgDocSave
                Dim chk As New CheckBox
                chk.Text = "IBB Concept"
                chk.Width = 107
                chk.AutoSize = False
                chk.Anchor = CType(System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
                With dlgSave.TableLayoutPanel1
                    .RowStyles.Add(New RowStyle(SizeType.AutoSize = 0))
                    .RowCount += 1
                    .Controls.Add(chk, 0, 0)
                End With


                Dim result As DialogResult = dlgSave.ShowDialog()
                If result = Windows.Forms.DialogResult.Yes Then
                    newWord.MergeIBB(_TemplateId, MyIBBDossier, True, chk.Checked)
                ElseIf result = Windows.Forms.DialogResult.No Then
                    newWord.MergeIBB(_TemplateId, MyIBBDossier, False, False)
                ElseIf result = Windows.Forms.DialogResult.Cancel Then
                    'doe dan nix
                End If
                newWord = Nothing

                FillListViewDocuments()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Friend Sub Save()
        Try
            If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_ibb_users") Or URights.IsInGroup("rel_ibb_admins") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Me.SelectNextControl(ActiveControl, True, True, True, True)

            Dim NewDossier As Boolean = False
            If MyIBBDossier.Id = Nothing Then
                NewDossier = True
                RaiseEvent Added(True)
            End If

            MyIBBDossier.EndDate = uctdEndDate.Value
            MyIBBDossier.Save()

            FillListViewTypes()


            If NewDossier Then
                MyIBBDossier.CreateDossierDir()
                If MyIBBDossier.BehandelaarId > 0 Then
                    MyIBBDossier.setDossierDirPermissions()
                End If
            End If


            Dim dlg As New frmSaved()
            dlg.lblResult.Text = "Opgeslagen"
            dlg.StartPosition = FormStartPosition.CenterScreen
            dlg.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Try
            If MyIBBDossier.Id < 1 Then Throw New Exception("Het dossier moet eerst worden opgeslagen!")

            Dim dlg As New dlgDocumentUpload(MyIBBDossier.Id, dlgDocumentUpload.Via.IBB, iCurrentFaseType)

            If Not My.Settings.ReportsPath = "" Then
                dlg.ofFile.InitialDirectory = My.Settings.ReportsPath
            End If

            Dim result As DialogResult = dlg.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                FillListViewDocuments(dlg.cmbFases.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            Save()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBehandelaar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBehandelaar.SelectedIndexChanged
        Try
            If Not sender Is Me.ActiveControl Then Exit Sub

            If sender.SelectedValue <> MyIBBDossier.BehandelaarId Then
                If MyIBBDossier.HasActiveCalendarAppointments() Then
                    Dim NewHandlerId As Integer = sender.SelectedValue
                    Dim dlgResult As DialogResult

                    dlgResult = MessageBox.Show("Er kunnen nog toekomstige agenda afspraken voor de huidige behandelaar zijn," & vbCrLf &
                                        "Wilt u deze verwijderen en nieuwe aanmaken voor " & sender.text, My.Application.Info.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                    If dlgResult = Windows.Forms.DialogResult.OK Then
                        MyIBBDossier.ChangeDossierHandler(NewHandlerId)
                    Else
                        sender.SelectedValue = MyIBBDossier.BehandelaarId
                        Exit Sub
                    End If

                End If
            End If


            If TypeOf sender.SelectedValue Is Integer Then
                'Behandelaar en dossiermap rechten aanpassen.
                Dim OldAccount As String = MyIBBDossier.myBehandelaar.ExchangeAccount
                MyIBBDossier.BehandelaarId = sender.SelectedValue
                Dim newAccount As Behandelaar = New Behandelaar(MyIBBDossier.BehandelaarId, BusinessObjects.Behandelaar.Via.ID)
                MyIBBDossier.ChangeDossierDirPermissions(OldAccount, newAccount.ExchangeAccount)

            ElseIf sender.SelectedValue Is Nothing Then
                MyIBBDossier.BehandelaarId = 0
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Function ActiveCalendarAppointments() As Boolean
    '    Dim result As Boolean = False
    '    If MyIBBDossier.Found Then
    '        ' If MyIBBDossier.ListIBBFases(True).Count > 0 Then
    '        For Each f As IBBFase In MyIBBDossier.ListIBBFases
    '            If Not String.IsNullOrEmpty(f.CalEntryObjectionId) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntryHerstelId) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntryHoorzittingId) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntry8) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntryBesluitId) Then Return True

    '            If Not String.IsNullOrEmpty(f.CalEntryObjectionIdHandler) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntryHerstelIdHandler) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntryHoorzittingIdHandler) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntryHandler8) Then Return True
    '            If Not String.IsNullOrEmpty(f.CalEntryBesluitIdHandler) Then Return True
    '        Next
    '        'End If
    '    End If
    '    Return result
    'End Function

    Private Sub lvIBBFases_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvIBBFases.DoubleClick
        Try
            If Not lvIBBFases.SelectedItems.Count = 0 Then
                If Me.MyIBBDossier.Id = 0 Then
                    MyIBBDossier.Save()
                ElseIf IBBDossierChanged() Then
                    Dim dlgSaveResult As DialogResult
                    dlgSaveResult = MessageBox.Show("Er zijn nog niet opgeslagen gegevens." & _
                                    vbCrLf & "kies OK om de gegevens alsnog op te slaan.", My.Application.Info.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)



                    If dlgSaveResult = Windows.Forms.DialogResult.OK Then
                        If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_ibb_users") Then
                            Save()
                            Exit Sub
                        Else
                            MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                End If

                Dim result As Windows.Forms.DialogResult
                Dim SelectedItem As Integer = lvIBBFases.SelectedItems(0).SubItems(3).Text
                ' Dim CreateNextPhase As Boolean = False

                If SelectedItem = 0 Then

                    Dim CurrentFase As Integer = 0
                    If MyIBBDossier.ListIBBFases(True).Count > 0 Then
                        For Each _fase As IBBFase In MyIBBDossier.ListIBBFases()
                            If _fase.Fase.Seq > CurrentFase Then
                                CurrentFase = _fase.Fase.Seq
                            End If
                        Next
                    End If

                    Dim dlgNew As New dlgJdPhase(Me.MyIBBDossier.Id, CurrentFase, MyIBBDossier.DossierSort)
                    dlgNew.ShowDialog()
                    'dlgNew.Location = New Point(Me.Location.X, 10)


                    result = dlgNew.DialogResult

                Else
                    Dim SelectedType As String = lvIBBFases.SelectedItems(0).Text
                    If SelectedType = "VRZ" Then
                        Dim dlg As New dlgJdTypePetition(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                    ElseIf SelectedType = "BF" Then
                        Dim dlg As New dlgJdTypeObjection(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                        'CreateNextPhase = dlg.CreateNextPhase
                    ElseIf SelectedType = "RB" Then
                        Dim dlg As New dlgJdTypeCourt(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                        'CreateNextPhase = dlg.CreateNextPhase
                    ElseIf SelectedType = "CRVB" Then
                        Dim dlg As New dlgJdCentralBoard(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                        'CreateNextPhase = dlg.CreateNextPhase
                    ElseIf SelectedType = "VN" Then
                        Dim dlg As New dlgJdTypeVnV(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                    ElseIf SelectedType = "KL" Then
                        Dim dlg As New dlgJdTypeComplaint(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                    ElseIf SelectedType = "NO" Then
                        Dim dlg As New dlgJdTypeOnbudsman(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                    ElseIf SelectedType = "CLM" Then
                        Dim dlg As New dlgJdTypeClaim(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.Text = lvIBBFases.SelectedItems(0).SubItems(2).Text
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                    Else
                        Dim dlg As New dlgJdTypePetition(Me.MyIBBDossier.Id, SelectedItem)
                        dlg.Owner = Me
                        dlg.Text = lvIBBFases.SelectedItems(0).SubItems(2).Text
                        dlg.ShowDialog()
                        result = dlg.DialogResult
                    End If
                    'Dim iType As Integer = lvIBBFases.SelectedItems(0).SubItems(4).Text
                    'If iType = 1 Then
                    '    Dim dlg As New dlgJdTypePetition(Me.MyIBBDossier.Id, SelectedItem)
                    '    dlg.Owner = Me
                    '    dlg.ShowDialog()
                    '    result = dlg.DialogResult
                    'ElseIf iType = 2 Then
                    '    Dim dlg As New dlgJdTypeObjection(Me.MyIBBDossier.Id, SelectedItem)
                    '    dlg.Owner = Me
                    '    dlg.ShowDialog()
                    '    result = dlg.DialogResult
                    '    'CreateNextPhase = dlg.CreateNextPhase
                    'ElseIf iType = 3 Then
                    '    Dim dlg As New dlgJdTypeCourt(Me.MyIBBDossier.Id, SelectedItem)
                    '    dlg.Owner = Me
                    '    dlg.ShowDialog()
                    '    result = dlg.DialogResult
                    '    'CreateNextPhase = dlg.CreateNextPhase
                    'ElseIf iType = 4 Then
                    '    Dim dlg As New dlgJdCentralBoard(Me.MyIBBDossier.Id, SelectedItem)
                    '    dlg.Owner = Me
                    '    dlg.ShowDialog()
                    '    result = dlg.DialogResult
                    '    'CreateNextPhase = dlg.CreateNextPhase
                    'ElseIf iType = 5 Then
                    '    Dim dlg As New dlgJdTypeVnV(Me.MyIBBDossier.Id, SelectedItem)
                    '    dlg.Owner = Me
                    '    dlg.ShowDialog()
                    '    result = dlg.DialogResult
                    'End If



                End If

                If result = Windows.Forms.DialogResult.OK Then
                    'If CreateNextPhase Then
                    '    CreateNext()
                    '    CreateNextPhase = False
                    'Else
                    FillListViewTypes(True)
                    'End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'Private Sub CreateNext()
    '    Try
    '        Dim CurrentFase As Integer = 0
    '        Dim iType As Integer = -1
    '        For Each _fase As IBBFase In MyIBBDossier.ListIBBFases(True)
    '            If _fase.Fase.Seq > CurrentFase Then
    '                CurrentFase = _fase.Fase.Seq
    '            End If
    '        Next

    '        Dim param() As Object = {"@nextSeq", CurrentFase}
    '        iType = da.ExecuteScalar("SELECT Id FROM jdTypes Where seq > @nextSeq Order By seq", param)

    '        Dim result As Windows.Forms.DialogResult

    '        If iType = 1 Then
    '            Dim dlg As New dlgJdTypePetition(Me.MyIBBDossier.Id)
    '            dlg.Owner = Me
    '            dlg.FaseTypeId = iType
    '            dlg.ShowDialog()
    '            result = dlg.DialogResult
    '        ElseIf iType = 2 Then
    '            Dim dlg As New dlgJdTypeObjection(Me.MyIBBDossier.Id)
    '            dlg.Owner = Me
    '            dlg.FaseTypeId = iType
    '            dlg.ShowDialog()
    '            result = dlg.DialogResult
    '        ElseIf iType = 3 Then
    '            Dim dlg As New dlgJdTypeCourt(Me.MyIBBDossier.Id)
    '            dlg.Owner = Me
    '            dlg.FaseTypeId = iType
    '            dlg.ShowDialog()
    '            result = dlg.DialogResult
    '        ElseIf iType = 4 Then
    '            Dim dlg As New dlgJdCentralBoard(Me.MyIBBDossier.Id)
    '            dlg.Owner = Me
    '            dlg.FaseTypeId = iType
    '            dlg.ShowDialog()
    '            result = dlg.DialogResult
    '        ElseIf iType = 5 Then
    '            Dim dlg As New dlgJdTypeVnV(Me.MyIBBDossier.Id)
    '            dlg.Owner = Me
    '            dlg.FaseTypeId = iType
    '            dlg.ShowDialog()
    '            result = dlg.DialogResult
    '        End If

    '        'If result = Windows.Forms.DialogResult.OK Then
    '        FillListViewTypes(True)
    '        'End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Sub lvJdTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvIBBFases.SelectedIndexChanged
        Try
            If Not lvIBBFases.SelectedItems.Count = 0 Then
                Dim SelectedItem As Integer = lvIBBFases.SelectedItems(0).SubItems(4).Text
                iCurrentFaseType = SelectedItem
                FillListViewDocuments(SelectedItem)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillAllDocuments()
        Try

            Dim sql As String = "SELECT * FROM IBBDocuments where DossierId = @DossierId"
            Dim param() As Object = {"@DossierId", Me.MyIBBDossier.Id}
            Dim dt As DataTable = da.ExecuteDataTable(sql, param)
            'dgvIbbDocuments.AutoGenerateColumns = False
            dgvIbbDocuments.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub FillListViewDocuments(Optional ByVal jdtype As Integer = -1)
        Try
            lvIBBDocuments.Clear()

            With lvIBBDocuments
                .StateImageList = ImageList1
                .Columns.Add("datum", 95, HorizontalAlignment.Left)
                .Columns.Add("fase", 40, HorizontalAlignment.Left)
                .Columns.Add("onderwerp", 225, HorizontalAlignment.Left)
                .Columns.Add("naam", 200, HorizontalAlignment.Left)
                .Columns.Add("lokatie", 0, HorizontalAlignment.Left)
                .Columns.Add("template", 0, HorizontalAlignment.Left)
                .Columns.Add("id", 0, HorizontalAlignment.Left)
                '.Columns.Add("class", "class", 40, HorizontalAlignment.Center, 6)
                .View = View.Details

                Dim lstViewItem As ListViewItem = New ListViewItem()

                For Each doc As IBBDocument In MyIBBDossier.ListDocuments(jdtype, True)
                    lstViewItem = New ListViewItem()
                    If doc.Template = "msg" Then
                        lstViewItem.StateImageIndex = 3
                    Else
                        lstViewItem.StateImageIndex = 6
                    End If

                    'geel = 1, groen = 2, blauw = 3, oranje = 4, paars = 5, rood = 6 , roze = 7,bruin = 8, olijf = 9
                    Select Case doc.Classificatie
                        Case 1
                            lstViewItem.BackColor = Color.Yellow
                        Case 2
                            lstViewItem.BackColor = Color.LightGreen
                        Case 3
                            lstViewItem.BackColor = Color.LightBlue
                        Case 4
                            lstViewItem.BackColor = Color.Orange
                        Case 5
                            lstViewItem.BackColor = Color.Orchid
                        Case 6
                            lstViewItem.BackColor = Color.OrangeRed
                        Case 7
                            lstViewItem.BackColor = Color.LightPink
                        Case 8
                            lstViewItem.BackColor = Color.Chocolate
                        Case 9
                            lstViewItem.BackColor = Color.Olive
                    End Select

                    If doc.Template = "msg" Then
                        lstViewItem.Text = doc.Bericht.ReceivedDate
                    Else
                        lstViewItem.Text = doc.CreateDate
                    End If


                    lstViewItem.SubItems.Add(doc.Fase.Type)
                    lstViewItem.SubItems.Add(doc.Onderwerp)
                    'Bug:1153: presenteer afzender ipv filename igv email
                    If doc.Template = "msg" Then
                        lstViewItem.SubItems.Add(doc.Bericht.FromName)
                    Else
                        lstViewItem.SubItems.Add(doc.DocumentName)
                    End If

                    lstViewItem.SubItems.Add(doc.Location)
                    lstViewItem.SubItems.Add(doc.Template)
                    lstViewItem.SubItems.Add(doc.Id)

                    .Items.Add(lstViewItem)

                Next

                'Try
                '    Dim level As String = String.Empty
                '    For Each doc As IBBDocument In MyIBBDossier.ListEmails(jdtype, True)
                '        lstViewItem = New ListViewItem()
                '        lstViewItem.StateImageIndex = 5

                '        level = doc.Bericht.boCategory.ToLower
                '        Select Case level
                '            Case "geel", "high"
                '                lstViewItem.BackColor = Color.Yellow
                '            Case "groen", "medium"
                '                lstViewItem.BackColor = Color.LightGreen
                '            Case "blauw", "low"
                '                lstViewItem.BackColor = Color.LightBlue
                '            Case "oranje"
                '                lstViewItem.BackColor = Color.Orange
                '            Case "paars"
                '                lstViewItem.BackColor = Color.Orchid
                '            Case "rood"
                '                lstViewItem.BackColor = Color.OrangeRed
                '            Case "roze" 'roze = 7,bruin = 8, olijf = 9
                '                lstViewItem.BackColor = Color.LightPink
                '            Case "bruin"
                '                lstViewItem.BackColor = Color.Chocolate
                '            Case "olijf"
                '                lstViewItem.BackColor = Color.Olive
                '        End Select

                '        lstViewItem.Text = doc.CreateDate
                '        lstViewItem.SubItems.Add(doc.Fase.Type)
                '        lstViewItem.SubItems.Add(doc.Onderwerp)
                '        lstViewItem.SubItems.Add(doc.DocumentName)
                '        lstViewItem.SubItems.Add(doc.Location)
                '        lstViewItem.SubItems.Add(doc.Template)
                '        lstViewItem.SubItems.Add(doc.EmailId)
                '        .Items.Add(lstViewItem)
                '    Next
                '    'If .Items.Count > 1 Then
                '    '    .EnsureVisible(.Items.Count - 1)
                '    'End If
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try

            End With

            If jdtype > 0 Then
                lbDocs.Text = "bij fase.."
            Else
                lbDocs.Text = "bij dossier"
            End If

            lvExternDocumenten.Clear()
            With lvExternDocumenten
                .Columns.Add("datum", 75, HorizontalAlignment.Left)
                .Columns.Add("fase", 50, HorizontalAlignment.Left)
                .Columns.Add("onderwerp", 150, HorizontalAlignment.Left)
                .Columns.Add("naam", 150, HorizontalAlignment.Left)
                .Columns.Add("lokatie", 0, HorizontalAlignment.Left)
                .Columns.Add("template", 0, HorizontalAlignment.Left)
                .View = View.Details

                Dim lstViewItem As ListViewItem = New ListViewItem()
                For Each doc As IBBDocument In MyIBBDossier.ListDocumentsExt(jdtype, True)
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = doc.CreateDate
                    lstViewItem.SubItems.Add(doc.Fase.Type)
                    lstViewItem.SubItems.Add(doc.Onderwerp)
                    lstViewItem.SubItems.Add(doc.DocumentName)
                    lstViewItem.SubItems.Add(doc.Location)
                    lstViewItem.SubItems.Add(doc.Template)
                    .Items.Add(lstViewItem)
                Next

                'If .Items.Count > 1 Then
                '    .EnsureVisible(.Items.Count - 1)
                'End If
            End With

            ' Call the sort method to manually sort.
            lvIBBDocuments.Sorting = SortOrder.Descending
            lvIBBDocuments.Sort()
            lvIBBDocuments.ListViewItemSorter = New ListViewItemComparer(0, lvIBBDocuments.Sorting)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Dim sortColumn As Integer = -1
    Private Sub lvIBBDocuments_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvIBBDocuments.ColumnClick
        Try

            ' Determine whether the column is the same as the last column clicked.
            If e.Column <> sortColumn Then
                ' Set the sort column to the new column.
                sortColumn = e.Column
                ' Set the sort order to ascending by default.
                lvIBBDocuments.Sorting = SortOrder.Ascending
            Else
                ' Determine what the last sort order was and change it.
                If lvIBBDocuments.Sorting = SortOrder.Ascending Then
                    lvIBBDocuments.Sorting = SortOrder.Descending
                Else
                    lvIBBDocuments.Sorting = SortOrder.Ascending
                End If
            End If
            ' Call the sort method to manually sort.
            lvIBBDocuments.Sort()
            ' Set the ListViewItemSorter property to a new ListViewItemComparer object.
            lvIBBDocuments.ListViewItemSorter = New ListViewItemComparer(e.Column, lvIBBDocuments.Sorting)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub lvIBBDocuments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvIBBDocuments.DoubleClick
        Try
            If Not lvIBBDocuments.SelectedItems.Count = 0 Then
                Dim SelectedItem As String = lvIBBDocuments.SelectedItems(0).SubItems(4).Text
                Dim SelectedType As String = lvIBBDocuments.SelectedItems(0).SubItems(5).Text
                If SelectedType.ToLower = "msg" Then
                    ' bug: 894 voor het openen van een msg bestand eerst op "alleen lezen" zetten
                    System.IO.File.SetAttributes(SelectedItem, FileAttributes.ReadOnly)
                    System.Diagnostics.Process.Start(SelectedItem)
                ElseIf SelectedType.ToLower = "ewsmail" Then

                    Dim EmailId As String = lvIBBDocuments.SelectedItems(0).SubItems(6).Text
                    Dim mimeContent As Byte() = ews.GetMimeContent(EmailId)
                    Dim emlFileName As String = TempEmlPath & Replace(Guid.NewGuid.ToString, "-", "") & ".eml"

                    Using fs As New IO.FileStream(emlFileName, FileMode.Create, FileAccess.Write)
                        fs.Write(mimeContent, 0, mimeContent.Length)
                    End Using

                    System.Diagnostics.Process.Start(emlFileName)

                Else
                    System.Diagnostics.Process.Start(SelectedItem)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lvExternDocumenten_DoubleClick(sender As Object, e As EventArgs) Handles lvExternDocumenten.DoubleClick
        Try
            If Not lvExternDocumenten.SelectedItems.Count = 0 Then
                Dim SelectedItem As String = lvExternDocumenten.SelectedItems(0).SubItems(4).Text
                Dim SelectedType As String = lvExternDocumenten.SelectedItems(0).SubItems(5).Text
                If SelectedType.ToLower = "msg" Then
                    Dim myMapi As New MapiObject(False)
                    myMapi.OpenMailFile(SelectedItem)
                Else
                    System.Diagnostics.Process.Start(SelectedItem)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbChanges.Click
        Try
            Dim ChildForm As New frmHistory(MyIBBDossier.Id, True)
            ChildForm.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function IBBDossierChanged() As Boolean
        Try
            Return da.isChanged(MyIBBDossier, "IBBDossiers", "Id", MyIBBDossier.Id, MyIBBDossier.Id, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub DeleteTempEmlFiles()
        Try

            For Each f In Directory.GetFiles(TempEmlPath, "*.eml", SearchOption.TopDirectoryOnly)
                File.Delete(f)
            Next
        Catch ex As UnauthorizedAccessException
        End Try
    End Sub
    Private Sub frmIBBDossier_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            DeleteTempEmlFiles()

            If IBBDossierChanged() Then
                Dim frmSave As New dlgSaveYesNo
                frmSave.Width = 550
                frmSave.btnYes.Text = "Doorgaan"
                frmSave.btnNo.Text = "Terug"
                frmSave.lblSave.Text = "Er zijn nog niet opgeslagen gegevens. Als u doorgaat gaan deze verloren." &
                                    vbCrLf & "Kies Opslaan om gegevens alsnog op te slaan."
                frmSave.Text = "Opslaan?"
                frmSave.ShowDialog()
                If frmSave.DialogResult = Windows.Forms.DialogResult.OK Then
                    If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_ibb_users") Then
                        Try
                            Save()
                        Catch exSave As Exception
                            e.Cancel = True
                            Throw exSave
                        End Try

                    Else
                        MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        e.Cancel = True
                    End If

                ElseIf frmSave.DialogResult = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                ElseIf frmSave.DialogResult = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = False
                End If

            End If

            'MyToken = ""

        Catch ex As Exception
            'e.Cancel = True
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
        Try
            FillListViewDocuments()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbSearchDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSearchDoc.Click
        Try
            Dim frmSearch As New frmSearchDocuments
            frmSearch.MdiParent = Main
            frmSearch.WindowState = FormWindowState.Maximized
            frmSearch.StartPosition = FormStartPosition.CenterParent
            frmSearch.DossierNr = MyIBBDossier.DossierNr

            frmSearch.Show()


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGriffieNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGriffieNew.Click
        Try
            Griffie = New IBBGriffieKosten()
            uctdGriffieDate.Value = Griffie.GriffieDate
            tbGriffieAmount.Text = Griffie.Amount
            chkGriffiePaid.Checked = Griffie.Paid
            uctdPaymentDate.Value = Griffie.PaymentDate
            uctdRepaidGriffieDate.Value = Griffie.RepaidGriffieDate
            uctdRepaidClientDate.Value = Griffie.RepaidClientDate

            cmbTypes.SelectedValue = Griffie.IBBFaseId
            tbGriffieDetails.Text = Griffie.Details

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Griffie As IBBGriffieKosten

    Private Sub dgvGriffieKosten_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvGriffieKosten.SelectionChanged
        Try
            If dgvGriffieKosten.SelectedRows.Count > 0 Then
                Griffie = New IBBGriffieKosten(dgvGriffieKosten.SelectedRows(0).Cells("Id").Value)
                uctdGriffieDate.Value = Griffie.GriffieDate
                tbGriffieAmount.Text = Griffie.Amount
                chkGriffiePaid.Checked = Griffie.Paid
                uctdPaymentDate.Value = Griffie.PaymentDate
                uctdRepaidGriffieDate.Value = Griffie.RepaidGriffieDate
                uctdRepaidClientDate.Value = Griffie.RepaidClientDate
                cmbTypes.SelectedValue = Griffie.IBBFaseId
                tbGriffieDetails.Text = Griffie.Details
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGriffieSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGriffieSave.Click
        Try
            If Griffie Is Nothing Then
                Griffie = New IBBGriffieKosten
            End If
            With Griffie
                .DossierId = MyIBBDossier.Id
                .Amount = tbGriffieAmount.Text
                .GriffieDate = uctdGriffieDate.Value
                .Paid = chkGriffiePaid.Checked
                .PaymentDate = uctdPaymentDate.Value
                .RepaidGriffieDate = uctdRepaidGriffieDate.Value
                .RepaidClientDate = uctdRepaidClientDate.Value
                .IBBFaseId = cmbTypes.SelectedValue
                .Details = tbGriffieDetails.Text
                .Save()
            End With

            GriffieKostenUpdate()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private myProcessKosten As IBBProcessKosten
    Private Sub btnProcessNew_Click(sender As Object, e As EventArgs) Handles btnProcessNew.Click
        Try
            myProcessKosten = New IBBProcessKosten
            With myProcessKosten
                tbProcessAmount.Text = .Amount
                uctdProcessLetter.Value = .DateLetter
                uctdProcessReceived.Value = .DateReceived
                cmbProcessFase.SelectedValue = .IBBFaseId
                tbProcessDetails.Text = .Details
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProcessSave_Click(sender As Object, e As EventArgs) Handles btnProcessSave.Click
        Try
            If myProcessKosten Is Nothing Then
                myProcessKosten = New IBBProcessKosten
            End If
            With myProcessKosten
                .DossierId = MyIBBDossier.Id
                .Amount = tbProcessAmount.Text
                .DateLetter = uctdProcessLetter.Value
                .DateReceived = uctdProcessReceived.Value
                .IBBFaseId = cmbProcessFase.SelectedValue
                .Details = tbProcessDetails.Text
                .Save()
            End With
            ProcessKostenUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvProcessKosten_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProcessKosten.SelectionChanged
        Try

            If dgvProcessKosten.SelectedRows.Count > 0 Then
                myProcessKosten = New IBBProcessKosten(dgvProcessKosten.SelectedRows(0).Cells("pcId").Value)
                With myProcessKosten
                    tbProcessAmount.Text = .Amount
                    uctdProcessLetter.Value = .DateLetter
                    uctdProcessReceived.Value = .DateReceived
                    cmbProcessFase.SelectedValue = .IBBFaseId
                    tbProcessDetails.Text = .Details
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private myExterneKosten As IBBExterneKosten
    Private Sub btnExternNew_Click(sender As Object, e As EventArgs) Handles btnExternNew.Click
        Try
            myExterneKosten = New IBBExterneKosten
            With myExterneKosten
                tbExternAmount.Text = .Amount
                uctdExternPaid.Value = .DatePaid
                'cmbExternFases.SelectedValue = .IBBFaseId
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExternSave_Click(sender As Object, e As EventArgs) Handles btnExternSave.Click
        Try
            If myExterneKosten Is Nothing Then
                myExterneKosten = New IBBExterneKosten
            End If
            With myExterneKosten
                .DossierId = MyIBBDossier.Id
                .Amount = tbExternAmount.Text
                .DatePaid = uctdExternPaid.Value
                '.IBBFaseId = cmbProcessFase.SelectedValue
                .Save()
            End With
            ExterneKostenUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvExterneKosten_SelectionChanged(sender As Object, e As EventArgs) Handles dgvExterneKosten.SelectionChanged
        Try

            If dgvExterneKosten.SelectedRows.Count > 0 Then
                myExterneKosten = New IBBExterneKosten(dgvExterneKosten.SelectedRows(0).Cells("extId").Value)
                With myExterneKosten
                    tbExternAmount.Text = .Amount
                    uctdExternPaid.Value = .DatePaid
                    'cmbExternFases.SelectedValue = .IBBFaseId
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PrintTool_Click(sender As Object, e As EventArgs) Handles PrintTool.Click
        Try
            If lvIBBDocuments.SelectedItems.Count = 1 Then
                Dim SelectedItem As String = lvIBBDocuments.SelectedItems(0).SubItems(4).Text
                PrintFileProcess(SelectedItem)
            Else
                Throw New Exception("U kunt 1 document tegelijk printen.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsmDeleteDoc_Click(sender As Object, e As EventArgs) Handles tsmDeleteDoc.Click
        Try
            If lvIBBDocuments.SelectedItems.Count = 1 Then
                Dim SelectedType As String = lvIBBDocuments.SelectedItems(0).SubItems(5).Text
                If SelectedType.ToLower = "ewsmail" Then
                    'MessageBox.Show("U kunt hier geen mail uit de mailbox verwijderen", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If MessageBox.Show("Weet u zeker dat u deze mail wilt verwijderen?.", "Verwijderen", _
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        ews.DeleteItem(lvIBBDocuments.SelectedItems(0).SubItems(6).Text)
                    End If

                Else
                    If MessageBox.Show("Weet u zeker dat u dit document wilt verwijderen?.", "Verwijderen", _
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim doc As IBBDocument = New IBBDocument(lvIBBDocuments.SelectedItems(0).SubItems(6).Text, IBBDocument.VIA.ID)

                        If doc.Found Then doc.Remove(True)

                    End If
                End If
                FillListViewDocuments()
            Else
                Throw New Exception("U kunt 1 document tegelijk verwijderen.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnderwerpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnderwerpToolStripMenuItem.Click
        Try
            If lvIBBDocuments.SelectedItems.Count = 1 Then
                Dim SelectedType As String = lvIBBDocuments.SelectedItems(0).SubItems(5).Text
                If SelectedType.ToLower = "ewsmail" Then
                    MessageBox.Show("U kunt hier geen mail onderwerpen aanpassen", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim doc As IBBDocument = New IBBDocument(lvIBBDocuments.SelectedItems(0).SubItems(6).Text, IBBDocument.VIA.ID)
                    If doc.Found Then
                        Dim dlgAsk As New dlgAskIt
                        Dim LastY As Integer = 0
                        Dim iLabelPositionX As Integer = 0
                        Dim mylabel As New Label
                        Dim mylabelDate As New Label
                        Dim tbDate As New TextBox

                        Dim lbl1 As New Label
                        Dim tb1 As New TextBox
                        Dim lbl3 As New Label

                        dlgAsk.StartPosition = FormStartPosition.CenterScreen
                        mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                        mylabel.Text = "U kunt hier het onderwerp aanpassen."
                        mylabel.AutoSize = True
                        dlgAsk.Controls.Add(mylabel)
                        LastY = mylabel.Location.Y

                        tb1.Location = New Point(mylabel.Location.X, LastY + 20)
                        tb1.Name = "tb1"
                        tb1.Text = doc.Onderwerp
                        tb1.Size = New Size(dlgAsk.Size.Width - 50, 35)
                        dlgAsk.Controls.Add(tb1)
                        LastY = tb1.Location.Y
                        iLabelPositionX = tb1.Location.X + 20

                        mylabelDate.Location = New Point(mylabel.Location.X, LastY + 40)
                        mylabelDate.Text = "Datum"
                        mylabelDate.AutoSize = True
                        dlgAsk.Controls.Add(mylabelDate)
                        LastY = mylabelDate.Location.Y

                        tbDate.Location = New Point(mylabel.Location.X, LastY + 20)
                        tbDate.Name = "tbDate"
                        tbDate.Text = doc.CreateDate
                        tbDate.AutoSize = True
                        If SelectedType.ToLower = "msg" Then tbDate.Enabled = False
                        dlgAsk.Controls.Add(tbDate)
                        LastY = tbDate.Location.Y

                        dlgAsk.ShowDialog()
                            If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then
                                doc.CreateDate = tbDate.Text
                                doc.Onderwerp = tb1.Text
                                doc.Save()
                                FillListViewDocuments()
                            End If
                        End If
                    End If
            Else
                Throw New Exception("U kunt 1 document tegelijk bewerken.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Classificatie_Click(sender As Object, e As EventArgs)
        Try
            SetClassification(DirectCast(sender, System.Windows.Forms.ToolStripMenuItem).Text.ToLower)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetClassification(level As String)
        Try
            If Not lvIBBDocuments.SelectedItems.Count = 0 Then
                Dim SelectedItem As String = lvIBBDocuments.SelectedItems(0).SubItems(4).Text
                Dim SelectedType As String = lvIBBDocuments.SelectedItems(0).SubItems(5).Text

                If SelectedType.ToLower = "ewsmail" Then
                    Dim categories As New List(Of String)
                    If Not level.ToLower = "none" Then categories.Add(level)
                    ews.UpdateCategories(lvIBBDocuments.SelectedItems(0).SubItems(6).Text, categories)
                Else
                    Dim doc As IBBDocument = New IBBDocument(lvIBBDocuments.SelectedItems(0).SubItems(6).Text, IBBDocument.VIA.ID)
                    If doc.Found Then
                        Dim levelcolor As Int32 = -1
                        levelcolor = DirectCast([Enum].Parse(GetType(eCategory), level), eCategory)
                        doc.Classificatie = levelcolor
                        doc.Save()
                    End If
                End If
                FillListViewDocuments()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub RemoveConcept_Click(sender As Object, e As EventArgs) Handles RemoveConcept.Click
        Try
            Dim concept As New IBBDocument(dgvIbbDocuments.SelectedRows(0).Cells("Id").Value, IBBDocument.VIA.ID)

            If concept.Found Then
                If concept.Concept = True Then
                    Dim dlgAsk As New dlgAskIt
                    dlgAsk.StartPosition = FormStartPosition.CenterScreen
                    dlgAsk.Size = New Drawing.Size(350, 200)

                    Dim mylabel As New Label
                    mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                    mylabel.Text = "Wilt U het concept document " & concept.Onderwerp & " definitief maken?"
                    mylabel.AutoSize = True
                    dlgAsk.Controls.Add(mylabel)

                    Dim lblFase As New Label
                    lblFase.Location = New Point(dlgAsk.Location.X + 20, mylabel.Height + 40)
                    lblFase.Text = "Selecteer een fase waaraan u dit document wilt koppelen."
                    lblFase.AutoSize = True
                    dlgAsk.Controls.Add(lblFase)

                    Dim sql As String = "select * " & _
                                        "from ibbfases ibb " & _
                                        "right join jdTypes t on ibb.TypeId = t.Id " & _
                                        "where dossierid = @dossierid"
                    Dim myFaseList As New ComboBox
                    Dim param() As Object = {"@dossierid", concept.DossierId}
                    Dim tblFases As DataTable = da.ExecuteDataTable(sql, param)
                    Dim dr As DataRow = tblFases.NewRow
                    dr("TypeId") = 0
                    dr("Description") = "Geen."
                    tblFases.Rows.InsertAt(dr, 0)

                    myFaseList.DataSource = tblFases
                    myFaseList.DisplayMember = "Description"
                    myFaseList.ValueMember = "TypeId"
                    myFaseList.Location = New Point(dlgAsk.Location.X + 20, lblFase.Location.Y + lblFase.Height + 20)
                    myFaseList.AutoSize = True
                    dlgAsk.Controls.Add(myFaseList)

                    dlgAsk.ShowDialog()

                    If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then
                        If myFaseList.SelectedValue > 0 Then
                            concept.jdTypeId = myFaseList.SelectedValue
                        End If
                        concept.Concept = False
                        concept.Save()
                    End If
                Else
                    MessageBox.Show("Het geselecteerde documetent is geen concept!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub PrintCorrespondentie_Click(sender As Object, e As EventArgs) Handles PrintCorrespondentie.Click
        Try
            Dim files As New List(Of String)
            Dim PrintDoc As New IBBDocument(dgvIbbDocuments.SelectedRows(0).Cells("Id").Value, IBBDocument.VIA.ID)
            If PrintDoc.Found Then
                PrintFileProcess(PrintDoc.Location)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    'Private Sub tsbEmail_Click(sender As Object, e As EventArgs)
    '    Try

    '        Dim TopForm As New frmEmail
    '        'TopForm.TopMost = True
    '        TopForm.ShowDialog()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub uctdEndDate_TbChanged() Handles uctdEndDate.TbChanged

        If String.IsNullOrEmpty(uctdEndDate.Value) And chkAfgehandeld.Checked Then
            uctdEndDate.Focus()
            uctdEndDate.tb.BackColor = Color.Red
        Else
            uctdEndDate.tb.BackColor = Color.White
        End If

    End Sub
    Private Sub chkAfgehandeld_CheckedChanged(sender As Object, e As EventArgs) Handles chkAfgehandeld.CheckedChanged
        Try

            If chkAfgehandeld.Checked And Not MyIBBDossier.AllPhasesClosed() Then
                chkAfgehandeld.Checked = False
                MessageBox.Show("Er is nog een Fase niet afgesloten," & vbCrLf & "U dient deze eerst af te handelen voordat u het dossier kan sluiten.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf chkAfgehandeld.Checked And String.IsNullOrEmpty(uctdEndDate.Value) Then
                If MyIBBDossier.Afgehandeld = True Then
                    uctdEndDate.Focus()
                    uctdEndDate.tb.BackColor = Color.Red
                Else
                    uctdEndDate.Value = Today
                End If

            ElseIf Not chkAfgehandeld.Checked And Not String.IsNullOrEmpty(uctdEndDate.Value) Then
                uctdEndDate.Value = String.Empty
            End If

            'BM:'volgens Wijzigingen IBB 12-11-2013 kunnen fase direct 
            'in de dialoog venster worden geopend, dus het onderstaande hoeft niet meer

            'If chkAfgehandeld.Focus AndAlso chkAfgehandeld.Checked = False Then
            '    Dim CurrentFase As Integer = 0
            '    Dim LaatsteFase As IBBFase = Nothing
            '    For Each _fase As IBBFase In MyIBBDossier.ListIBBFases(True)
            '        If _fase.Fase.Seq > CurrentFase Then
            '            CurrentFase = _fase.Fase.Seq
            '            LaatsteFase = _fase
            '        End If
            '    Next

            '    LaatsteFase.Besluit = 0
            '    LaatsteFase.Intrekking = False
            '    LaatsteFase.BeslissingBezwaar = String.Empty
            '    LaatsteFase.Save()
            '    MessageBox.Show("laatste fase " & LaatsteFase.Fase.Description & "  is weer geopend?", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    LaatsteFase = Nothing
            ' FillListViewTypes()
            ' End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearchDossier_Click(sender As Object, e As EventArgs) Handles btnSearchDossier.Click
        Try
            Dim lstDossiernr As New List(Of String)
            Dim DossierSource As New AutoCompleteStringCollection()
            tbMoederDossier.Enabled = True
            lstDossiernr = da.GetListOfString("Select dossiernr from IBBDossiers")
            DossierSource.AddRange(lstDossiernr.ToArray)
            tbMoederDossier.AutoCompleteCustomSource = DossierSource
            tbMoederDossier.AutoCompleteMode = AutoCompleteMode.Suggest
            tbMoederDossier.AutoCompleteSource = AutoCompleteSource.CustomSource
            tbMoederDossier.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddExternDoc_Click(sender As Object, e As EventArgs) Handles btnAddExternDoc.Click
        Try
            If Me.MyIBBDossier.Id = 0 Then
                MessageBox.Show("nieuw dossier eerst opslaan.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim dlg As New dlgDocumentUpload(MyIBBDossier.Id, dlgDocumentUpload.Via.IBBEXT)

            If Not My.Settings.ReportsPath = "" Then
                dlg.ofFile.InitialDirectory = My.Settings.ReportsPath
            End If

            Dim result As DialogResult = dlg.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                FillListViewDocuments()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        Dim ModuleName As String = Me.Name
        Try
            OpenHelpUrl(ModuleName)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbUpdateAppointments_Click(sender As Object, e As EventArgs) Handles tsbUpdateAppointments.Click
        Try
            'Dim myMapiObject As New MapiObject(GetSysSettingOf("IBBCalAccount"))
            For Each fs As IBBFase In MyIBBDossier.ListIBBFases(True)
                ' fs.UpdateFutureAppointments(myMapiObject)
                fs.UpdateFutureAppointmentEWS()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnLegenda_Click(sender As Object, e As EventArgs) Handles btnLegenda.Click
        Dim dlg As New dlgLegenda
        dlg.ShowDialog()
    End Sub

    Private Sub tsbOpenLid_Click(sender As Object, e As EventArgs) Handles tsbOpenLid.Click
        Try

            Dim frm As New Main
            frm = Me.ParentForm
            Dim ChildForm As frmRelatie = frm.FindRelatieform(MyIBBDossier.MyRelatie.Id)

            If ChildForm Is Nothing Then
                Dim newfrm As New frmRelatie(MyIBBDossier.MyRelatie.Id)
                newfrm.MdiParent = Main
                newfrm.Show()
            ElseIf ChildForm.MyRelatie.Id = MyIBBDossier.MyRelatie.Id Then
                ChildForm.Focus()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Const PR_HEADER As String = "http://schemas.microsoft.com/mapi/proptag/0x007D001E"
    Const PR_SENT_REPRESENTING_ENTRYID As String = "http://schemas.microsoft.com/mapi/proptag/0x00410102"

    Private Sub lvIBBDocuments_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvIBBDocuments.DragDrop
        Try
            If MyIBBDossier.Id < 1 Then Throw New Exception("Het dossier moet eerst worden opgeslagen!")

            Dim results As String = String.Empty
            If e.Data.GetDataPresent("FileGroupDescriptor") Then
                If e.Data.GetFormats(False)(1) = "FileGroupDescriptor" Then
                    Dim FilePath As String = GetOutlookAttachment(e, "FileGroupDescriptor")
                    Dim file As IO.FileInfo
                    file = New FileInfo(FilePath)
                    Dim dlgDocument As New dlgDocumentUpload(MyIBBDossier.Id, dlgDocumentUpload.Via.IBB, iCurrentFaseType)
                    dlgDocument.cmbFases.SelectedItem = iCurrentFaseType
                    dlgDocument.tbSelectedFile.Text = FilePath
                    dlgDocument.tbOnderwerp.Text = file.Name.Replace(file.Extension, "")
                    dlgDocument.ProcessIBB(True)

                    results &= "- " & file.Name & ", " & vbCrLf
                Else
                    Dim OL As Microsoft.Office.Interop.Outlook.Application = New Microsoft.Office.Interop.Outlook.Application
                    Dim olItem As Microsoft.Office.Interop.Outlook.MailItem

                    Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                    If Not DocumentPathSetting.Found Then Throw New Exception("Geen Systeeminstellingen voor IBBFiles gevonden!")
                    Dim DocumentPath As String = DocumentPathSetting.Waarde & "\"
                    Dim FullDocumentPath As String = DocumentPath & MyIBBDossier.DossierNr & "\email"

                    If Not Directory.Exists(FullDocumentPath) Then
                        Directory.CreateDirectory(FullDocumentPath)
                    End If

                    For Each olItem In OL.ActiveExplorer.Selection
                        If String.IsNullOrEmpty(olItem.Subject) Then Throw New Exception("Bericht zonder onderwerp kan niet worden verwerkt!")

                        Dim sFileName As String = System.Text.RegularExpressions.Regex.Replace(olItem.Subject.Trim, "[\/\\\:\?\*\<\>\|""""]", "") & ".msg"
                        'hyphen\dash van apple wordt niet goed verwerkt.
                        'sFileName = System.Text.RegularExpressions.Regex.Replace(sFileName.Trim, "-", "_") & ".msg"

                        Dim NewIbbDocument As New IBBDocument
                        With NewIbbDocument
                            .DossierId = MyIBBDossier.Id
                            .jdTypeId = iCurrentFaseType
                            .LidId = MyRelatie.Id

                            Dim subject As String = olItem.Subject.Trim
                            If subject.Length >= 100 Then subject = olItem.Subject.Trim.Substring(0, 99)
                            .Onderwerp = subject
                            .Template = "msg"

                            .Bericht.DossierId = MyIBBDossier.Id
                            .Bericht.ReceivedDate = olItem.ReceivedTime
                            .Bericht.Subject = subject
                            'Dim objAtt As Outlook.Attachment
                            'For Each objAtt In olItem.Attachments
                            '    Dim iAtt As Integer = objAtt.Size
                            'Next


                            'Bug:1158  - probleem slepen vanuit de ‘verzonden items’ naar ibbdocumenten opgelost
                            If olItem.ReceivedByName Is Nothing Then
                                ' dan is het een verzonden item en vullen we het met de porperty "To"
                                .Bericht.ToName = System.Text.RegularExpressions.Regex.Replace(olItem.To.Trim, "[\/\\\:\?\*'\<\>\|""""]", "")
                            Else
                                .Bericht.ToName = olItem.ReceivedByName

                            End If
                            .Bericht.FromName = olItem.SenderName

                            If olItem.SenderEmailAddress.ToUpper.Contains("/CN=RECIPIENTS") Then
                                Dim iStart As Integer = olItem.SenderEmailAddress.ToUpper.LastIndexOf("/CN=RECIPIENTS")
                                Dim iLength As Integer = olItem.SenderEmailAddress.Length
                                .Bericht.FromAddress = olItem.SenderEmailAddress.Substring(iStart, iLength - iStart)
                            Else
                                .Bericht.FromAddress = olItem.SenderEmailAddress
                            End If

                            If olItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML Then
                                .Bericht.BodyText = olItem.HTMLBody
                                .Bericht.isHTML = 1
                            Else
                                .Bericht.isHTML = 0
                                .Bericht.BodyText = olItem.Body
                            End If
                            .Bericht.Header = olItem.PropertyAccessor.GetProperty(PR_HEADER)
                            .Bericht.CreateDate = Today
                            .Bericht.CreatedBy = URights.UserName
                            .Bericht.Save()

                            'sFileName = sFileName & "-" & .Bericht.Id
                            sFileName = sFileName.Insert(sFileName.ToLower.LastIndexOf(".msg"), "-" & .Bericht.Id)
                            olItem.SaveAs(FullDocumentPath & "\" & sFileName, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG)

                            .Location = FullDocumentPath & "\" & sFileName
                            .BerichtenId = .Bericht.Id
                            .Save()

                            'Bug:894 - zet kenmerk op "alleen lezen" ter voorkoming van foutmelding bij meerdere keren openen.
                            System.IO.File.SetAttributes(FullDocumentPath & "\" & sFileName, FileAttributes.ReadOnly)
                        End With

                        results &= "- " & olItem.Subject.Replace(":", "") & ", " & vbCrLf

                        OL.ActiveExplorer.RemoveFromSelection(olItem)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(olItem)
                        olItem = Nothing

                    Next

                    OL = Nothing

                    Outlook2010Workaround()

                End If

            ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
                Dim file As IO.FileInfo
                For Each path In files
                    file = New FileInfo(path)
                    Dim dlgDocument As New dlgDocumentUpload(MyIBBDossier.Id, dlgDocumentUpload.Via.IBB, iCurrentFaseType)
                    dlgDocument.cmbFases.SelectedValue = iCurrentFaseType
                    dlgDocument.tbSelectedFile.Text = path
                    dlgDocument.tbOnderwerp.Text = file.Name.Replace(file.Extension, "")
                    dlgDocument.ProcessIBB()

                    results &= "- " & file.Name & ", " & vbCrLf
                Next
            Else
                MsgBox("FileType is niet herkend.")
            End If

            FillListViewDocuments(iCurrentFaseType)

            ' MessageBox.Show(results & " zijn verwerkt.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            FillListViewDocuments(iCurrentFaseType)
        End Try

    End Sub

    Private _OutlookActiveExplorer As Outlook.Explorer = Nothing
    Public Sub Outlook2010Workaround()

        Dim oOutlook As Outlook.Application = New Outlook.Application
        Dim oExplorer As Outlook.Explorer = oOutlook.ActiveExplorer()

        Try
            If Not oOutlook.Version.StartsWith("14") Then
                Return 'alleen doorgaan indien het outlook 2010 is vanwege het niet leeg maken van de selectie.
            End If

            Dim oFolder As Outlook.Folder = oExplorer.CurrentFolder

            oExplorer.CurrentFolder = oOutlook.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderOutbox)
            oExplorer.CurrentFolder = oFolder

            _OutlookActiveExplorer = oExplorer

        Catch ex As System.Exception
        Finally

        End Try

    End Sub
    Private Sub lvIBBDocuments_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvIBBDocuments.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        ElseIf e.Data.GetDataPresent("DataFormats.Text") Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Public Function GetOutlookAttachment(ByVal e As System.Windows.Forms.DragEventArgs, DataTypeName As String) As String

        Try
            Dim theStream As IO.Stream = DirectCast(e.Data.GetData(DataTypeName), IO.Stream)
            Dim fileGroupDescriptor As Byte() = New Byte(511) {}
            theStream.Read(fileGroupDescriptor, 0, 512)
            ' used to build the filename from the FileGroupDescriptor block 
            Dim fileName As New System.Text.StringBuilder("")
            ' this trick gets the filename of the passed attached file 
            Dim i As Integer = 76
            While fileGroupDescriptor(i) <> 0
                fileName.Append(Convert.ToChar(fileGroupDescriptor(i)))
                i += 1
            End While

            theStream.Close()

            Dim path As String = IO.Path.GetTempPath()
            ' put the zip file into the temp directory 
            Dim theFile As String = path + fileName.ToString()

            Dim ms As IO.MemoryStream = DirectCast(e.Data.GetData("FileContents", True), IO.MemoryStream)

            ' allocate enough bytes to hold the raw data 

            Dim fileBytes As Byte() = New Byte(CInt(ms.Length) - 1) {}
            ' set starting position at first byte and read in the raw data 
            ms.Position = 0
            ms.Read(fileBytes, 0, CInt(ms.Length))
            ' create a file and save the raw zip file to it 
            Dim fs As New IO.FileStream(theFile, IO.FileMode.Create)
            fs.Write(fileBytes, 0, CInt(fileBytes.Length))
            fs.Close()
            ' close the file 
            Return theFile
        Catch ex As Exception
            'handle error here
            Return String.Empty
        End Try

    End Function

    Private Sub cntxPhases_Click(sender As Object, e As EventArgs) Handles cntxPhases.Click
        Try
            Dim ErrorList As New List(Of String)

            Dim SelectedItem As Integer = lvIBBFases.SelectedItems(0).SubItems(3).Text
            Dim myPhase As IBBFase = New IBBFase(SelectedItem, IBBFase.Via.ID)

            If Not myPhase.Found Then Throw New Exception("Fase niet gevonden!")

            'Controleren of er hogere Fases zijn.
            For Each _fase As IBBFase In MyIBBDossier.ListIBBFases()
                If _fase.Fase.Seq > myPhase.Fase.Seq Then
                    ErrorList.Add("- heeft al een vervolg fase. ")
                    Exit For
                End If
            Next

            'Controleren of er documenten aan de fase hangen
            If MyIBBDossier.ListDocuments(SelectedItem).Count > 0 Then
                ErrorList.Add("- heeft al gekoppelde documenten. ")
            End If

            ''Controleren of er emailberichten aan de fase hangen
            '' heeft geen ref naar de fase id dus kan niet gecontroleerd worden.
            'If MyIBBDossier.ListEmails(SelectedItem).Count > 0 Then
            '    ErrorList.Add("- heeft al gekoppelde emailberichten. ")
            'End If

            If ErrorList.Count > 0 Then
                ErrorList.Insert(0, "Kan " & myPhase.Fase.Description & " niet verwijderen vanwege de volgende reden(en): ")
                MessageBox.Show(String.Join(vbCrLf, ErrorList.ToArray()), myPhase.Fase.Description, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'Controleren op toekomstige agenada items
                If myPhase.HasFutureAppointments() Then
                    'ErrorList.Add("- Eventulele toekomstige agenda items worden verwijderd." & vbCrLf)
                    myPhase.DeleteFutureAppointmentsEWS(False)
                End If
                myPhase.Remove()
                FillListViewTypes(True)

                'Dim dlgResult As DialogResult
                'dlgResult = MessageBox.Show(String.Join(vbCrLf, ErrorList.ToArray()), myPhase.Fase.Description, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                'If dlgResult = Windows.Forms.DialogResult.OK Then
                '    myPhase.DeleteFutureAppointmentsEWS(False)
                '    'myPhase.Remove()
                'Else
                '    Exit Sub
                'End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearchMail_Click(sender As Object, e As EventArgs) Handles btnSearchMail.Click
        Try
            FillListViewDocumentsBySearch(tbSearchMail.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillListViewDocumentsBySearch(ByVal SearchValue As String)
        Try
            lvIBBDocuments.Clear()

            With lvIBBDocuments
                .StateImageList = ImageList1
                .Columns.Add("datum", 95, HorizontalAlignment.Left)
                .Columns.Add("fase", 40, HorizontalAlignment.Left)
                .Columns.Add("onderwerp", 225, HorizontalAlignment.Left)
                .Columns.Add("naam", 200, HorizontalAlignment.Left)
                .Columns.Add("lokatie", 0, HorizontalAlignment.Left)
                .Columns.Add("template", 0, HorizontalAlignment.Left)
                .Columns.Add("id", 0, HorizontalAlignment.Left)
                '.Columns.Add("class", "class", 40, HorizontalAlignment.Center, 6)
                .View = View.Details

                Dim lstViewItem As ListViewItem = New ListViewItem()

                For Each doc As IBBDocument In MyIBBDossier.ListDocumentsSearch(SearchValue, True)
                    lstViewItem = New ListViewItem()
                    If doc.Template = "msg" Then
                        lstViewItem.StateImageIndex = 3
                    Else
                        lstViewItem.StateImageIndex = 6
                    End If

                    'geel = 1, groen = 2, blauw = 3, oranje = 4, paars = 5, rood = 6 , roze = 7,bruin = 8, olijf = 9
                    Select Case doc.Classificatie
                        Case 1
                            lstViewItem.BackColor = Color.Yellow
                        Case 2
                            lstViewItem.BackColor = Color.LightGreen
                        Case 3
                            lstViewItem.BackColor = Color.LightBlue
                        Case 4
                            lstViewItem.BackColor = Color.Orange
                        Case 5
                            lstViewItem.BackColor = Color.Orchid
                        Case 6
                            lstViewItem.BackColor = Color.OrangeRed
                        Case 7
                            lstViewItem.BackColor = Color.LightPink
                        Case 8
                            lstViewItem.BackColor = Color.Chocolate
                        Case 9
                            lstViewItem.BackColor = Color.Olive
                    End Select

                    lstViewItem.Text = doc.CreateDate
                    lstViewItem.SubItems.Add(doc.Fase.Type)
                    lstViewItem.SubItems.Add(doc.Onderwerp)
                    'Bug:1153: presenteer afzender ipv filename igv email
                    If doc.Template = "msg" Then
                        lstViewItem.SubItems.Add(doc.Bericht.FromName)
                    Else
                        lstViewItem.SubItems.Add(doc.DocumentName)
                    End If

                    lstViewItem.SubItems.Add(doc.Location)
                    lstViewItem.SubItems.Add(doc.Template)
                    lstViewItem.SubItems.Add(doc.Id)

                    .Items.Add(lstViewItem)

                Next

                'If .Items.Count > 1 Then
                '    .EnsureVisible(.Items.Count - 1)
                'End If

            End With

            ' Call the sort method to manually sort.
            lvIBBDocuments.Sorting = SortOrder.Descending
            lvIBBDocuments.Sort()
            lvIBBDocuments.ListViewItemSorter = New ListViewItemComparer(0, lvIBBDocuments.Sorting)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lvIBBDocuments_LostFocus(sender As Object, e As EventArgs) Handles lvIBBDocuments.LostFocus
        wbBody.Visible = False
        lblNotitie.Text = "Notities"
    End Sub

    Private Sub lvIBBDocuments_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvIBBDocuments.ItemSelectionChanged
        Try
            Dim lvItem As ListView = sender
            Dim ibbtype As String = e.Item.SubItems(5).Text
            If ibbtype = "msg" Then
                Dim ibbdoc As IBBDocument = New IBBDocument(e.Item.SubItems(6).Text, IBBDocument.VIA.ID)
                If ibbdoc.Found And ibbdoc.Template = "msg" Then
                    wbBody.Visible = True
                    If Not ibbdoc.Bericht.isHTML = 1 Then
                        Dim stext As String = ibbdoc.Bericht.BodyText
                        stext = Replace(stext, "&", "&amp;")
                        stext = Replace(stext, "", "'")
                        stext = Replace(stext, ">", "&gt;")
                        stext = Replace(stext, "<", "&lt;")
                        stext = Replace(stext, """", "&quot;")
                        stext = Replace(stext, vbCrLf, "<BR>")
                        stext = Replace(stext, "  ", " &nbsp;")
                        wbBody.DocumentText = "<HTML><HEAD></HEAD><BODY>" & stext & "</BODY></HTML>"
                    Else
                        wbBody.DocumentText = ibbdoc.Bericht.BodyText
                    End If
                    lblNotitie.Text = "Preview"
                End If
            Else
                wbBody.Visible = False
                lblNotitie.Text = "Notities"
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WijzigFaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WijzigFaseToolStripMenuItem.Click
        Try
            If lvIBBDocuments.SelectedItems.Count = 1 Then
                Dim SelectedType As String = lvIBBDocuments.SelectedItems(0).SubItems(5).Text
                If SelectedType.ToLower = "ewsmail" Then
                    MessageBox.Show("U kunt hier geen mail aanpassen", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim doc As IBBDocument = New IBBDocument(lvIBBDocuments.SelectedItems(0).SubItems(6).Text, IBBDocument.VIA.ID)
                    If doc.Found Then
                        Dim dlgAsk As New dlgAskIt
                        Dim LastY As Integer = 0
                        Dim iLabelPositionX As Integer = 0
                        Dim mylabel As New Label
                        Dim myFaseList As New ComboBox

                        Dim FaseTable As New DataTable
                        FaseTable.Columns.Add("Id")
                        FaseTable.Columns.Add("Description")

                        For Each jdt As IBBFase In MyIBBDossier.ListIBBFases(True)
                            Dim FaseRow As DataRow = FaseTable.NewRow()
                            FaseRow("Id") = jdt.Fase.Id
                            FaseRow("Description") = jdt.Fase.Description
                            FaseTable.Rows.Add(FaseRow)
                        Next

                        myFaseList.DataSource = FaseTable
                        myFaseList.DisplayMember = "Description"
                        myFaseList.ValueMember = "Id"

                        dlgAsk.StartPosition = FormStartPosition.CenterScreen
                        mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                        mylabel.Text = "U kunt hier de fase toekennen\aanpassen."
                        mylabel.AutoSize = True
                        dlgAsk.Controls.Add(mylabel)
                        LastY = mylabel.Location.Y

                        myFaseList.Location = New Point(mylabel.Location.X, LastY + 20)
                        myFaseList.Name = "tb1"
                        myFaseList.Size = New Size(dlgAsk.Size.Width - 50, 35)
                        myFaseList.AutoSize = True
                        dlgAsk.Controls.Add(myFaseList)
                        LastY = cmbTypes.Location.Y
                        iLabelPositionX = cmbTypes.Location.X + 20

                        dlgAsk.ShowDialog()
                        If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then
                            doc.jdTypeId = myFaseList.SelectedValue
                            doc.Save()
                            FillListViewDocuments()
                        End If
                    End If
                End If
            Else
                Throw New Exception("U kunt 1 document tegelijk bewerken.")
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    'Private Sub tbNotities_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNotities.KeyDown
    '    Try
    '        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.OemSemicolon Then
    '            tbNotities.AppendText(Today.ToShortDateString)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    ' End Sub


End Class


' Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub

    Public Sub New(column As Integer, order As SortOrder)
        col = column
        Me.order = order
    End Sub
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer
        ' Determine whether the type being compared is a date type.
        Try
            ' Parse the two objects passed as a parameter as a DateTime.
            Dim firstDate As System.DateTime = DateTime.Parse(CType(x, ListViewItem).SubItems(col).Text)
            Dim secondDate As System.DateTime = DateTime.Parse(CType(y, ListViewItem).SubItems(col).Text)
            ' Compare the two dates.
            returnVal = DateTime.Compare(firstDate, secondDate)
            ' If neither compared object has a valid date format, compare as a string.
        Catch
            ' Compare the two items as a string.
            returnVal = [String].Compare(CType(x,  _
                              ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End Try

        ' Determine whether the sort order is descending.
        If order = SortOrder.Descending Then
            ' Invert the value returned by String.Compare.
            returnVal *= -1
        End If
        Return returnVal
    End Function
    'Public Function Compare(x As Object, y As Object) As Integer _
    '                    Implements System.Collections.IComparer.Compare
    '    Dim returnVal As Integer = -1
    '    returnVal = [String].Compare(CType(x,  _
    '                    ListViewItem).SubItems(col).Text, _
    '                    CType(y, ListViewItem).SubItems(col).Text)
    '    ' Determine whether the sort order is descending.
    '    If order = SortOrder.Descending Then
    '        ' Invert the value returned by String.Compare.
    '        returnVal *= -1
    '    End If

    '    Return returnVal
    'End Function
End Class