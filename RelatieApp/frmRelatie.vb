Imports BusinessObjects
Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO

Public Class frmRelatie
    Private URights As UserRights = UserRights.Instance
    Dim MinDateValue As DateTime = "30-12-1899"
    Private da As New DataAccess
    'Private _lidnr As String = "0"
    Private _lidid As Integer = 0
    Private _MyRelatie As Relaties
    Private MyRelatieCopy As Relaties
    Private MyNazorg As Nazorg

    'Private cmdAssurance As SqlClient.SqlCommand
    'Private daAssurance As SqlClient.SqlDataAdapter
    'Private dsAssurance As DataSet

    'Private WithEvents dsHelpdesk As New DataSet
    'Private WithEvents daHelpdesk As New SqlClient.SqlDataAdapter
    'Private bs_helpdesk As New BindingSource

    Private EindeReden As DataTable = da.ExecuteDataTable("SELECT * FROM opzeggingen ORDER BY id")

    Private myTemplates As DataTable = New DataTable

    Private AllowDocumentsGroups() As Object = Nothing
    Private AllowBrievenGroups() As Object = Nothing
    Private AllowHelpdeskMailDelete() As Object = Nothing
    Private AllowBtnDeleteIBB() As Object = Nothing
    Private AllowBtnRelatieExport As Object = Nothing

    Private WithEvents frmIBBDossier As frmIBBDossier
    Public Sub frmChangedHandler(ByVal renew As Boolean) Handles frmIBBDossier.Added
        If renew Then

        End If
    End Sub

    Public Property MyRelatie() As Relaties
        Get
            If _MyRelatie Is Nothing Then
                If _lidid = 0 Then
                    _MyRelatie = New Relaties
                    _MyRelatie.lidnr = ""
                    _MyRelatie.indatum = New Date(Now.Year, Now.Month, Now.Day)
                    _MyRelatie.aantal_triv = 1
                Else
                    ' _MyRelatie = New Relaties(_lidid, Relaties.Via.LIDNR)
                    _MyRelatie = New Relaties(_lidid, Relaties.Via.ID)
                End If
                MyRelatieCopy = _MyRelatie.ShallowCopy()
            End If
            Return _MyRelatie
        End Get
        Set(ByVal value As Relaties)
            _MyRelatie = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal id As String)
        InitializeComponent()
        '_lidnr = id
        _lidid = id
    End Sub

    Private Sub frmRelatie_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim haschanged As Boolean = False

            If MyRelatie.IsChanged(MyRelatieCopy) Then
                haschanged = True
            End If

            If haschanged = False Then
                haschanged = HasChangesPayments()
            End If

            If haschanged = False And Not MyNazorg Is Nothing Then
                haschanged = da.isChanged(MyNazorg, "Nazorg", "Id", MyNazorg.Id, MyNazorg.Id, False)
            End If

            If MyRelatie.Helpdesk.Memo <> MyRelatieCopy.Helpdesk.Memo Then
                haschanged = True
            End If

            If haschanged Then
                Dim frmSave As New dlgSaveYesNo
                frmSave.btnYes.Text = "Doorgaan"
                frmSave.btnNo.Text = "Terug"
                frmSave.lblSave.Text = "Uw wijzigingen zijn nog niet opgeslagen. Als u doorgaat gaan deze verloren." &
                                    vbCrLf & "Kies Opslaan om de wijzigingen alsnog op te slaan."
                frmSave.Text = "Opslaan?"
                frmSave.ShowDialog()
                If frmSave.DialogResult = Windows.Forms.DialogResult.OK Then
                    If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_users") Then
                        If ValidateRelatieSettings() Then
                            Save()
                        Else
                            e.Cancel = True
                        End If

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

            'daAssurance.Dispose()
            'dsAssurance.Dispose()
            'daHelpdesk.Dispose()
            If Not daPayments Is Nothing Then
                cmdPayments.Dispose()
                dsPayments.Dispose()
                daPayments.Dispose()
            End If

            da.CloseAllPool()
            SqlConnection.ClearAllPools()

            da = Nothing

        Catch ex As Exception
            'e.Cancel = True
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private lstPages As List(Of TabPage)
    Private Sub AddTabPages(tabname As TabPage)
        Try
            If Not TabControl1.TabPages.Contains(tabname) Then
                TabControl1.TabPages.Add(tabname)
                'Dim i As Integer = TabControl1.TabPages.Count
                'If i > 0 Then i -= 1
                'TabControl1.TabPages.Insert(i, tabname)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmRelatie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lstPages = New List(Of TabPage)
            For Each tab As TabPage In TabControl1.TabPages
                If tab.Name = "Tabtmp" Then Continue For
                lstPages.Add(tab)
            Next

            If CreateDefaultLabels Then CreateLabelXml(Me, Me.Name, True)
            GetLabelText(Me, Me.Name)

            DisabledFormControls(Me, True)
            RemoveTabpages(TabControl1, True)

            Me.SaveToolStripButton.Enabled = False
            Me.NewToolStripButton.Enabled = False
            Me.btnSaveHelpDesk.Enabled = False
            Me.tbHelpdeskNotities.Enabled = False



            If URights.IsInGroup("rel_users") Then
                'alle tabbladen RW , IBB en Helpdesk hidden
                For Each tab As TabPage In lstPages
                    If tab.Name.ToLower = "tabhelpdesk" Then Continue For
                    If tab.Name.ToLower = "tabibb" Then Continue For
                    AddTabPages(tab)
                Next
                DisabledFormControls(Me, False)
                tbLidNr.Enabled = True
                Me.SaveToolStripButton.Enabled = True
                Me.NewToolStripButton.Enabled = True
            End If

            If URights.IsInGroup("rel_functies") Then
                'alleen algemene gegevens R en Functies RW
                AddTabPages(TabLidmaatschap)
                AddTabPages(TabFunctions)
                DisabledFormControls(TabFunctions, False)
            End If

            If URights.IsInGroup("rel_readers") Or URights.IsInGroup("rel_readers_mailing") Then
                'dan alleen lezen Correspondentie RW en geen heldesk en IBB
                For Each tab As TabPage In lstPages
                    If tab.Name.ToLower = "tabhelpdesk" Then Continue For
                    If tab.Name.ToLower = "tabibb" Then Continue For
                    AddTabPages(tab)
                Next
                DisabledFormControls(TabCorrespondentie, False)
            End If

            If URights.IsInGroup("rel_adres") Then
                ' dan alleen naw RW en brieven. rest alleen R
                For Each tab As TabPage In lstPages
                    If tab.Name.ToLower = "tabhelpdesk" Then Continue For
                    If tab.Name.ToLower = "tabibb" Then Continue For
                    AddTabPages(tab)
                Next
                DisabledFormControls(TabCorrespondentie, False)
                DisabledFormControls(grpName, False)
                DisabledFormControls(grpNAW, False)
                DisabledFormControls(grpMV, False)
                DisabledFormControls(grpContact, False)
                DisabledFormControls(grpIndeling, False)
                DisabledFormControls(grpDiversen, False)

                Me.SaveToolStripButton.Enabled = True
                tsbChanges.Enabled = True
            End If

            If URights.IsInGroup("rel_blad") Then
                ' Triv en xrcize en reden aanzetten 
                AddTabPages(TabLidmaatschap)
                cmbTrivReden.Enabled = True
                tbAantal_Xr.Enabled = True
                tbAantal_triv.Enabled = True
                cmbXrReden.Enabled = True
                chkSiteVizier.Enabled = True
                Me.SaveToolStripButton.Enabled = True
            End If

            If URights.IsInGroup("rel_ibb_users") Then
                'alleen algemene gegevens, heldesk RW en IBB R
                AddTabPages(TabLidmaatschap)
                'DisabledFormControls(TabLidmaatschap, True)
                AddTabPages(TabHelpdesk)
                AddTabPages(TabIBB)
                DisabledFormControls(TabHelpdesk, False)
                dgvIBB.Enabled = True
                'DisabledFormControls(ToolStrip1, False)
            End If

            If URights.IsInGroup("rel_ibb_admins") Then
                'alleen algemene gegevens R en IBB en Helpdesk RW
                AddTabPages(TabLidmaatschap)
                'DisabledFormControls(TabLidmaatschap, True)
                AddTabPages(TabHelpdesk)
                AddTabPages(TabIBB)
                DisabledFormControls(TabIBB, False)
                DisabledFormControls(TabHelpdesk, False)

            End If


            If URights.IsInGroup("rel_admins") Then
                'dan alles RW
                cmbStatus.Visible = True
                cmbStatus.Enabled = True
                tbLidNr.Enabled = True
                For Each tab As TabPage In lstPages
                    AddTabPages(tab)
                Next
                DisabledFormControls(Me, False)
                Me.SaveToolStripButton.Enabled = True
                Me.NewToolStripButton.Enabled = True
                'Hide_FormControls(Me, False)
            End If

            'If Not URights.IsInGroup("rel_admins") Then
            '    'dan dit nog een keer uitzetten
            '    'cmbStatus.Visible = False
            '    cmbStatus.Enabled = False
            '    tbLidNr.Enabled = False
            'End If

            If TabControl1.TabPages.Count > 1 Then
                TabControl1.TabPages.Remove(Tabtmp)
            End If

            AllowDocumentsGroups = {"rel_admins", "rel_readers", "rel_users"}
            AllowBrievenGroups = {"rel_admins", "rel_readers", "rel_users", "rel_ibb_admins", "rel_ibb_users", "rel_adres"}

            Dim sAllowHelpdeskMailDelete As String = GetSysSettingOf("AllowHelpdeskMailDelete", True)
            AllowHelpdeskMailDelete = sAllowHelpdeskMailDelete.Trim.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)

            Dim sAllowBtnDeleteIBB As String = GetSysSettingOf("AllowDeleteIBB", True)
            AllowBtnDeleteIBB = sAllowBtnDeleteIBB.Trim.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)

            Dim sAllowRelatieExport As String = GetSysSettingOf("AllowRelatieExport", True)
            AllowBtnRelatieExport = sAllowRelatieExport.Trim.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)


            FillCmb()
            ' FillHelpDesk()
            BindTexBox()

            'uitgefaseerd bugid:1767
            'FillAssurance()


            If MyRelatie.Found Then
                FillListViewContributies()
                FillListViewPaymentsContributies()
                FillListViewFuncties()

                Select Case MyRelatie.geslacht.ToUpper
                    Case "MAN"
                        rbMan.Checked = True
                        rbWoman.Checked = False
                        rbUnkown.Checked = False
                    Case "VROUW"
                        rbMan.Checked = False
                        rbWoman.Checked = True
                        rbUnkown.Checked = False
                    Case "ONBEKEND"
                        rbMan.Checked = False
                        rbWoman.Checked = False
                        rbUnkown.Checked = True
                End Select

            End If



            AddHandler rbFase1.CheckedChanged, AddressOf rbFase_CheckedChanged
            AddHandler rbFase2.CheckedChanged, AddressOf rbFase_CheckedChanged
            AddHandler rbFase3.CheckedChanged, AddressOf rbFase_CheckedChanged

            AddHandler rbMan.CheckedChanged, AddressOf rbGeslacht_CheckedChanged
            AddHandler rbWoman.CheckedChanged, AddressOf rbGeslacht_CheckedChanged
            AddHandler rbUnkown.CheckedChanged, AddressOf rbGeslacht_CheckedChanged

            AddHandler btnGebdatum.Click, AddressOf btnDatum_Click
            AddHandler btnInDatum.Click, AddressOf btnDatum_Click
            'AddHandler btnSpeldDragerGoud.Click, AddressOf btnDatum_Click
            'AddHandler btnSpeldDrager.Click, AddressOf btnDatum_Click
            AddHandler btnGoud.Click, AddressOf btnDatum_Click
            AddHandler btnZilver.Click, AddressOf btnDatum_Click
            AddHandler btnFlo_pen.Click, AddressOf btnDatum_Click
            ' AddHandler btnEindeDatum.Click, AddressOf btnDatum_Click

            AddHandler tbGebdatum.Validated, AddressOf tb_textChanged
            AddHandler tbInDatum.Validated, AddressOf tb_textChanged
            'AddHandler tbSpeldDragerGoud.Validated, AddressOf tb_textChanged
            'AddHandler tbSpelddrager.Validated, AddressOf tb_textChanged
            AddHandler tbZilver.Validated, AddressOf tb_textChanged
            AddHandler tbGoud.Validated, AddressOf tb_textChanged
            AddHandler tbFlo_pen.Validated, AddressOf tb_textChanged
            'AddHandler tbEindeDatum.Validated, AddressOf tb_textChanged
            AddHandler tbInstantiedatum.Validated, AddressOf tb_textChanged

            AddHandler cmbAfdeling.Validating, AddressOf cmb_Validating
            AddHandler cmbKMonderdeel.Validating, AddressOf cmb_Validating
            AddHandler cmbDienstvak.Validating, AddressOf cmb_Validating
            AddHandler cmbPlaatsing.Validating, AddressOf cmb_Validating
            AddHandler cmbRang.Validating, AddressOf cmb_Validating
            AddHandler cmbBond.Validating, AddressOf cmb_Validating
            AddHandler cmbContrInstanties.Validating, AddressOf cmb_Validating
            AddHandler cmbContrInstantiesVorig.Validating, AddressOf cmb_Validating
            AddHandler cmbStatus.Validating, AddressOf cmb_Validating
            AddHandler cmbTrivReden.Validating, AddressOf cmb_Validating

            AddHandler tbEmail.Validating, AddressOf ValidEmail
            AddHandler tbEmailWerk.Validating, AddressOf ValidEmail

            AddHandler Me.lvFuncties.ColumnClick, AddressOf lvFuncties_ColumnClick

            AddHandler Me.tbJan.Validating, AddressOf CheckInt
            AddHandler Me.tbFeb.Validating, AddressOf CheckInt
            AddHandler Me.tbMrt.Validating, AddressOf CheckInt
            AddHandler Me.tbApr.Validating, AddressOf CheckInt
            AddHandler Me.tbMei.Validating, AddressOf CheckInt
            AddHandler Me.tbJun.Validating, AddressOf CheckInt
            AddHandler Me.tbJul.Validating, AddressOf CheckInt
            AddHandler Me.tbAug.Validating, AddressOf CheckInt
            AddHandler Me.tbSep.Validating, AddressOf CheckInt
            AddHandler Me.tbOkt.Validating, AddressOf CheckInt
            AddHandler Me.tbNov.Validating, AddressOf CheckInt
            AddHandler Me.tbDec.Validating, AddressOf CheckInt

            AddHandler rbBegrafenis.CheckedChanged, AddressOf rbUitvaart_CheckedChanged
            AddHandler rbCrematie.CheckedChanged, AddressOf rbUitvaart_CheckedChanged
            AddHandler rbNvtUitvaart.CheckedChanged, AddressOf rbUitvaart_CheckedChanged

            AddHandler rbNazorgJa.CheckedChanged, AddressOf rbNazorg_CheckedChanged
            AddHandler rbNazorgNee.CheckedChanged, AddressOf rbNazorg_CheckedChanged

            AddHandler rbBloemenJa.CheckedChanged, AddressOf rbBloemen_CheckedChanged
            AddHandler rbBloemenNee.CheckedChanged, AddressOf rbBloemen_CheckedChanged

            AddHandler rbTrivMeldingJa.CheckedChanged, AddressOf rbTrivMelding_CheckedChanged
            AddHandler rbTrivMeldingNee.CheckedChanged, AddressOf rbTrivMelding_CheckedChanged

            AddHandler rbOpgebaardJa.CheckedChanged, AddressOf rbOpgebaard_CheckedChanged
            AddHandler rbOpgebaardNee.CheckedChanged, AddressOf rbOpgebaard_CheckedChanged

            AddHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            AddHandler tbBic.Validating, AddressOf ValidAlphaNummeric

            Me.btnSMS.Visible = mGeneral.HaveSMSApplication

            Dim SetAutoLidNr As String = GetSysSettingOf("SetAutolidnr", False)
            If SetAutoLidNr.ToLower = "true" Then
                tbLidNr.Enabled = False
            Else
                If Not MyRelatie.Found Then Me.tbLidNr.Select()
            End If

            'Dim Alarm As Boolean = False
            ' Dim _BackColor As Global.System.Drawing.Color = Color.FromArgb(255, 126, 190, 135)

            If MyRelatie.Status = 0 Then
                Me.btNewIBB.Enabled = True
            Else
                Me.btNewIBB.Enabled = False
            End If

            If MyRelatie.Alarmering Then
                Me.Text = Me.Text & " *** " & "ALARMERING"

                Dim s_BackColor As String = GetSysSettingOf("Alarmering", True)
                Dim a As Array = s_BackColor.Split(",")
                Dim _BackColor As Global.System.Drawing.Color = Color.FromArgb(a(0), a(1), a(2), a(3))

                Me.BackColor = _BackColor
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FillCmb()
        Try
            Dim Bonden As DataTable = da.ExecuteDataTable("SELECT * FROM Bonden ORDER BY Omschrijving")

            Dim Afdelingen As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch FROM Afdelingen ORDER BY Omschrijving")
            Dim kmonderdelen As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + kmonderdeel as id_omsch FROM kmonderdelen ORDER BY kmonderdeel")
            'Dim Dienstvakken As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(dienstvak as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch FROM Dienstvakken ORDER BY dienstvak")
            Dim Plaatsingen As DataTable = da.ExecuteDataTable("SELECT p_id,plaatsing, left(CAST(code as varchar) + SPACE(5),5) + ' | ' + Plaatsing as code_plaatsing  FROM Plaatsingen ORDER BY Plaatsing")
            Dim Rangen As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + rang as id_omsch FROM Rangen ORDER BY Id")
            Dim TrivizierRedenen As DataTable = da.ExecuteDataTable("SELECT * FROM TrivizierRedenen ORDER BY reden")
            'Dim Lidsoorten As DataTable = da.ExecuteDataTable("SELECT * FROM Lidsoorten ORDER BY soort")
            Dim ContributieInstanties As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + Naam as id_omsch FROM Contr_instanties ORDER BY Id")
            Dim ContributieInstanties_Vorig As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + Naam as id_omsch FROM Contr_instanties ORDER BY Id")
            myTemplates = da.ExecuteDataTable("SELECT * FROM Templates WHERE (Bond = 0 OR BOND = 1) ORDER BY afdeling, omschrijving")
            Dim XrRedenen As DataTable = da.ExecuteDataTable("SELECT * FROM TrivizierRedenen ORDER BY reden")

            If MyRelatie.Found Then
                Dim dr As DataRow = TrivizierRedenen.NewRow
                dr("id") = 0
                dr("reden") = "Selecteer"
                TrivizierRedenen.Rows.InsertAt(dr, 0)
                cmbTrivReden.DataSource = TrivizierRedenen
                cmbTrivReden.DisplayMember = "Reden"
                cmbTrivReden.ValueMember = "id"
                cmbTrivReden.SelectedValue = MyRelatie.TrivReden
                If MyRelatie.aantal_triv > 0 Then
                    cmbTrivReden.Enabled = False
                End If
            End If

            If MyRelatie.Found Then
                Dim dr As DataRow = XrRedenen.NewRow
                dr("id") = 0
                dr("reden") = "Selecteer"
                XrRedenen.Rows.InsertAt(dr, 0)
                cmbXrReden.DataSource = XrRedenen
                cmbXrReden.DisplayMember = "Reden"
                cmbXrReden.ValueMember = "id"
                cmbXrReden.SelectedValue = MyRelatie.XrReden
                If MyRelatie.aantal_xr > 0 Then
                    cmbXrReden.Enabled = False
                End If
            End If

            If MyRelatie.bond = 0 And Bonden.Rows.Count = 1 Then
                If Not MyRelatie.Found Then
                    MyRelatie.bond = Bonden.Rows(0).Item("id")
                End If
            ElseIf MyRelatie.bond = 0 Then
                Dim dr As DataRow = Bonden.NewRow
                dr("id") = 0
                dr("Omschrijving") = "Selecteer een Bond."
                Bonden.Rows.InsertAt(dr, 0)
            End If
            cmbBond.DataSource = Bonden
            cmbBond.DisplayMember = "Omschrijving"
            cmbBond.ValueMember = "id"
            cmbBond.SelectedValue = MyRelatie.bond

            If MyRelatie.afdeling = 0 Then
                Dim dr As DataRow = Afdelingen.NewRow
                dr("id") = 0
                dr("Omschrijving") = ""
                dr("id_omsch") = "Selecteer een Afdeling."
                Afdelingen.Rows.InsertAt(dr, 0)
            End If
            cmbAfdeling.DataSource = Afdelingen
            cmbAfdeling.DisplayMember = "id_omsch"
            cmbAfdeling.ValueMember = "id"
            cmbAfdeling.SelectedValue = MyRelatie.afdeling

            If MyRelatie.kmond = 0 Then
                Dim dr As DataRow = kmonderdelen.NewRow
                dr("id") = 0
                dr("kmonderdeel") = ""
                dr("id_omsch") = "Selecteer een onderdeel."
                kmonderdelen.Rows.InsertAt(dr, 0)
            End If
            cmbKMonderdeel.DataSource = kmonderdelen
            cmbKMonderdeel.DisplayMember = "id_omsch"
            cmbKMonderdeel.ValueMember = "id"
            cmbKMonderdeel.SelectedValue = MyRelatie.kmond

            'If Not MyRelatie.kmond = 0 Then
            FillDienstvak()
                'End If


                If MyRelatie.plaatsing = 0 Then
                Dim dr As DataRow = Plaatsingen.NewRow
                dr("p_id") = 0
                dr("Plaatsing") = ""
                dr("code_Plaatsing") = "Selecteer een plaatsing."
                Plaatsingen.Rows.InsertAt(dr, 0)
            End If
            cmbPlaatsing.DataSource = Plaatsingen
            cmbPlaatsing.DisplayMember = "code_Plaatsing"
            cmbPlaatsing.ValueMember = "p_id"
            cmbPlaatsing.SelectedValue = MyRelatie.plaatsing

            If MyRelatie.rang = 0 Then
                Dim dr As DataRow = Rangen.NewRow
                dr("id") = 0
                dr("rang") = ""
                dr("id_omsch") = "Selecteer een rang."
                Rangen.Rows.InsertAt(dr, 0)
            End If
            cmbRang.DataSource = Rangen
            cmbRang.DisplayMember = "id_omsch"
            cmbRang.ValueMember = "id"
            cmbRang.SelectedValue = MyRelatie.rang

            If MyRelatie.Instantieid = 0 Then
                Dim dr As DataRow = ContributieInstanties.NewRow
                dr("id") = 0
                dr("naam") = ""
                dr("id_omsch") = "Selecteer een instantie."
                ContributieInstanties.Rows.InsertAt(dr, 0)
            End If
            cmbContrInstanties.DataSource = ContributieInstanties
            cmbContrInstanties.DisplayMember = "Naam"
            cmbContrInstanties.ValueMember = "id"
            cmbContrInstanties.SelectedValue = MyRelatie.Instantieid


            If MyRelatie.InstantieIdVorig = 0 Then
                Dim dr As DataRow = ContributieInstanties_Vorig.NewRow
                dr("id") = 0
                dr("naam") = ""
                dr("id_omsch") = "Selecteer een instantie."
                ContributieInstanties_Vorig.Rows.InsertAt(dr, 0)
            End If
            cmbContrInstantiesVorig.DataSource = ContributieInstanties_Vorig
            cmbContrInstantiesVorig.DisplayMember = "Naam"
            cmbContrInstantiesVorig.ValueMember = "id"
            cmbContrInstantiesVorig.SelectedValue = MyRelatie.InstantieIdVorig

            Dim StatusTable As New DataTable
            StatusTable.TableName = "status"
            StatusTable.Columns.Add("id", Type.GetType("System.Int32"))
            StatusTable.Columns.Add("omschrijving", Type.GetType("System.String"))
            StatusTable.Columns.Add("id_omsch", Type.GetType("System.String"))

            Dim StatusRow As DataRow
            StatusRow = StatusTable.NewRow
            StatusRow.Item("id") = 0
            StatusRow.Item("omschrijving") = "Actieve leden"
            StatusRow.Item("id_omsch") = "0     | Actieve leden"
            StatusTable.Rows.Add(StatusRow)

            StatusRow = StatusTable.NewRow
            StatusRow.Item("id") = 1
            StatusRow.Item("omschrijving") = "Leden historie"
            StatusRow.Item("id_omsch") = "1     | Leden historie"
            StatusTable.Rows.Add(StatusRow)

            StatusRow = StatusTable.NewRow
            StatusRow.Item("id") = 2
            StatusRow.Item("omschrijving") = "Leden voorportaal"
            StatusRow.Item("id_omsch") = "2     | Leden voorportaal"
            StatusTable.Rows.Add(StatusRow)

            cmbStatus.DataSource = StatusTable
            cmbStatus.DisplayMember = "id_omsch"
            cmbStatus.ValueMember = "id"
            cmbStatus.SelectedValue = MyRelatie.Status

            'cmbEindeReden.DataSource = EindeReden
            'cmbEindeReden.DisplayMember = "omschrijving"
            'cmbEindeReden.ValueMember = "id"
            'cmbEindeReden.SelectedValue = MyRelatie.eindereden

            FindEindeReden()


            'tscDocs.ComboBox.DataSource = myTemplates
            'tscDocs.ComboBox.DisplayMember = "omschrijving"
            'tscDocs.ComboBox.ValueMember = "id"

            Dim mnu As New ToolStripMenuItem
            Dim mnu1 As New ToolStripMenuItem
            mnu.Text = "Brieven"
            Dim tmpGroup As String = "Brieven"
            For Each rw As DataRow In myTemplates.Rows
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
            mnu.Enabled = False
            If URights.IsMemberOfOne(AllowBrievenGroups) Then
                mnu.Enabled = True
            End If

            tsmDelete.Enabled = False
            If URights.IsMemberOfOne(AllowHelpdeskMailDelete) Then
                tsmDelete.Enabled = True
            End If

            'bug:1141 - alleen groepen gedefineerd in systeeminstellingen "AllowDeleteIBB"  kunnen nu IBBdossiers verwijderen.
            BtnDeleteIBB.Enabled = False
            If URights.IsMemberOfOne(AllowBtnDeleteIBB) Then
                BtnDeleteIBB.Enabled = True
            End If

            'bug:1149 - alleen groepen gedefineerd in systeeminstellingen "AllowRelatieExport"  mogen de export uitvoeren.
            tsbXML.Enabled = False
            If URights.IsMemberOfOne(AllowBtnRelatieExport) Then
                tsbXML.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillDienstvak()
        Try
            ' cmbDienstvak.DataSource = Nothing
            Dim kmId As Integer = cmbKMonderdeel.SelectedValue
            Dim paramdv As New ArrayList
            paramdv.Add("@kmId")
            paramdv.Add(kmId)
            Dim dtDienstvakken As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(dienstvak as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch " &
                                                                "FROM Dienstvakken " &
                                                                "WHERE kmId = @kmId OR kmId IS NULL " &
                                                                "ORDER BY dienstvak", paramdv.ToArray)

            If MyRelatie.dienstvak = 0 Then
                Dim id_omschrijving As String = "Selecteer een dienstvak."
                If MyRelatie.kmond = 0 Then
                    id_omschrijving = "Selecteer eerst " & Label20.Text
                End If
                Dim dr As DataRow = dtDienstvakken.NewRow
                dr("id") = 0
                dr("Omschrijving") = ""
                dr("id_omsch") = id_omschrijving
                dtDienstvakken.Rows.InsertAt(dr, 0)
            End If

            cmbDienstvak.DataSource = dtDienstvakken
            cmbDienstvak.DisplayMember = "id_omsch"
            cmbDienstvak.ValueMember = "id"
            If MyRelatie.dienstvak > 0 Then
                cmbDienstvak.SelectedValue = MyRelatie.dienstvak
            Else
                cmbDienstvak.SelectedValue = 0
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CreateDoc(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs)
        Try
            If MyRelatie.Id = 0 Then Throw New Exception("Dit is een nieuwe relatie, deze eerst opslaan!")

            Dim _afdeling As String = DirectCast(sender, System.Windows.Forms.ToolStripMenuItem).Text
            Dim _sjabloon As String = e.ClickedItem.ToString
            Dim _Id As Integer = FindTemplate(_sjabloon, _afdeling)

            If _Id > 0 Then
                Dim newWord As New OfficeObjects.WordMerge
                newWord.CurrentDr = MyRelatie.ExportRow
                newWord.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\merge.txt"
                'newWord.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\merge.txt"

                Dim dlgSave As New dlgDocSave
                Dim result As DialogResult = dlgSave.ShowDialog()
                If result = Windows.Forms.DialogResult.Yes Then
                    newWord.Merge(_Id, MyRelatie, True)
                ElseIf result = Windows.Forms.DialogResult.No Then
                    newWord.Merge(_Id, MyRelatie, False)
                ElseIf result = Windows.Forms.DialogResult.Cancel Then
                    'doe dan nix
                End If
                newWord = Nothing
                GetCorrespondentie()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FindTemplate(ByVal TemplateName As String, ByVal DepartmentName As String) As Integer
        Try
            Dim dv As New DataView(myTemplates)
            Dim _filter As String = "Afdeling = '" & DepartmentName.Trim & "'"
            dv.RowFilter = _filter
            dv.Sort = "Id"

            For Each row As DataRowView In dv
                If row.Item("Omschrijving").ToString = TemplateName Then
                    Return row.Item("Id")
                End If
            Next

            Return 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub BindTexBox()
        Try
            With MyRelatie
                If Not MyRelatie.Found Then
                    Me.Text = "Nieuw"
                Else
                    Me.Text = .FullName
                End If

                'group Registratie
                If MyRelatie.lidnr = "0" Then
                    tbLidNr.Enabled = True
                    tbLidNr.DataBindings.Add("Text", MyRelatie, "lidnr")
                Else
                    'tbLidNr.Enabled = URights.IsInGroup("rel_admins")
                    tbLidNr.DataBindings.Add("Text", MyRelatie, "lidnr")
                End If
                'tbOrigine.DataBindings.Add("Text", MyRelatie, "WNRT")
                tbRegistratienr.DataBindings.Add("Text", MyRelatie, "RNR")
                dtpMutatieDatum.DataBindings.Add("Text", MyRelatie, "MutDate")
                tbMut_door.DataBindings.Add("Text", MyRelatie, "MutDoor")

                'group NAW
                tbVoorvoegsel.DataBindings.Add("Text", MyRelatie, "titelvoor")
                tbInit.DataBindings.Add("Text", MyRelatie, "init")
                tbTussenvoegsel.DataBindings.Add("Text", MyRelatie, "tussenvoegsel")
                tbAchternaam.DataBindings.Add("Text", MyRelatie, "achternaam")
                tbAchtervoegsel.DataBindings.Add("Text", MyRelatie, "titelachter")

                tbAdres.DataBindings.Add("Text", MyRelatie, "adres")
                tbHuisNr.DataBindings.Add("Text", MyRelatie, "huisnr")
                tbHuisNrTv.DataBindings.Add("Text", MyRelatie, "huisnrtv")
                tbPostCode.DataBindings.Add("Text", MyRelatie, "postcode")
                tbPlaats.DataBindings.Add("Text", MyRelatie, "plaats")
                tbLand.DataBindings.Add("Text", MyRelatie, "land")
                tbZipCode.DataBindings.Add("Text", MyRelatie, "ZipCode")

                'group Contact
                tbTelefoon.DataBindings.Add("Text", MyRelatie, "telefoonnummer")
                tbMobiel.DataBindings.Add("Text", MyRelatie, "mobiel")
                tbTelefax.DataBindings.Add("Text", MyRelatie, "Telefax")
                tbEmail.DataBindings.Add("Text", MyRelatie, "email")
                tbEmailWerk.DataBindings.Add("Text", MyRelatie, "emailwerk")
                tbTelWerk.DataBindings.Add("Text", MyRelatie, "telwerk")
                tbNotities.DataBindings.Add("Text", MyRelatie, "Notities")

                tbDonatie_MSF.DataBindings.Add("Text", MyRelatie, "Donatie_MSF")
                tbAantal_triv.DataBindings.Add("Text", MyRelatie, "Aantal_triv")
                tbAantal_Xr.DataBindings.Add("Text", MyRelatie, "Aantal_Xr")

                tbGebdatum.DataBindings.Add("Text", MyRelatie, "geboortedatum", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")
                tbInDatum.DataBindings.Add("Text", MyRelatie, "InDatum", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")
                tbEindeDatum.DataBindings.Add("Text", MyRelatie, "EindeDatum", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")

                'tbSpeldDragerGoud.DataBindings.Add("Text", MyRelatie, "erelid", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")
                'tbSpelddrager.DataBindings.Add("Text", MyRelatie, "lid_verdienste", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")

                tbZilver.DataBindings.Add("Text", MyRelatie, "zilver", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")
                tbGoud.DataBindings.Add("Text", MyRelatie, "goud", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")

                tbFlo_pen.DataBindings.Add("Text", MyRelatie, "flo_pen", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")


                chkALV.DataBindings.Add("Checked", MyRelatie, "alv", True)
                chkAvFunctie.DataBindings.Add("Checked", MyRelatie, "alv", True)

                chkKerstkaart.DataBindings.Add("Checked", MyRelatie, "kerstkaart", True)
                chkKerstkaartFnc.DataBindings.Add("Checked", MyRelatie, "kerstkaart", True)



                chkLid_natres.DataBindings.Add("Checked", MyRelatie, "Lid_natres", True)
                chkLid_natresFnc.DataBindings.Add("Checked", MyRelatie, "Lid_natres", True)

                chkNato.DataBindings.Add("Checked", MyRelatie, "nato", True)
                chkNatoFnc.DataBindings.Add("Checked", MyRelatie, "nato", True)

                chkDienjaar.DataBindings.Add("Checked", MyRelatie, "Dienjaar", True)


                chkVeteraan.DataBindings.Add("Checked", MyRelatie, "Veteraan", True)
                chkVeteraanFnc.DataBindings.Add("Checked", MyRelatie, "Veteraan", True)

                chkBOM.DataBindings.Add("Checked", MyRelatie, "BOM", True)
                chkBOMfnc.DataBindings.Add("Checked", MyRelatie, "BOM", True)

                'chkDAP.DataBindings.Add("Checked", MyRelatie, "DAP", True)

                'tbBankRek.DataBindings.Add("Text", MyRelatie, "BankRek", True)
                tbIBAN.DataBindings.Add("Text", MyRelatie, "IBAN", True)
                tbBic.DataBindings.Add("Text", MyRelatie, "BIC", True)

                cmbContrInstanties.DataBindings.Add("SelectedValue", MyRelatie, "InstantieId", True)
                tbInstantiedatum.DataBindings.Add("Text", MyRelatie, "InstantieDatum", True, DataSourceUpdateMode.OnPropertyChanged, Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")
                cmbContrInstantiesVorig.DataBindings.Add("SelectedValue", MyRelatie, "InstantieIdVorig", True)

                cmbAfdeling.DataBindings.Add("SelectedValue", MyRelatie, "Afdeling")
                cmbKMonderdeel.DataBindings.Add("SelectedValue", MyRelatie, "kmond")
                cmbDienstvak.DataBindings.Add("SelectedValue", MyRelatie, "dienstvak")
                cmbRang.DataBindings.Add("SelectedValue", MyRelatie, "rang")
                cmbPlaatsing.DataBindings.Add("SelectedValue", MyRelatie, "plaatsing")
                cmbStatus.DataBindings.Add("SelectedValue", MyRelatie, "status")

                utdSLContract.tb.DataBindings.Add("text", MyRelatie, "Samenlevingscontract")
                utdLoi.tb.DataBindings.Add("text", MyRelatie, "Loi")
                utdCadeauDate.tb.DataBindings.Add("text", MyRelatie, "CadeauDatum")

                tbCadeau.DataBindings.Add("text", MyRelatie, "Cadeau")
                'chkNazorg.DataBindings.Add("Checked", MyRelatie, "nazorg", True)
                chkSiteVizier.DataBindings.Add("Checked", MyRelatie, "SiteVizier", True)

                rbNazorgJa.Checked = MyRelatie.Nazorg = 1
                rbNazorgNee.Checked = MyRelatie.Nazorg = 2


                chkBelastingAdv.DataBindings.Add("Checked", MyRelatie, "b_belastingadviseur", True)
                chkAlarmering.DataBindings.Add("Checked", MyRelatie, "Alarmering", True)


                utdRijbewijskeuring75.tb.DataBindings.Add("text", MyRelatie, "Rijbewijs75Date")
                chkRijbewijskeuring75.DataBindings.Add("Checked", MyRelatie, "Rijbewijs75", True)

                utdPuzzel.tb.DataBindings.Add("text", MyRelatie, "Puzzel")

                'bs_helpdesk.DataSource = dsHelpdesk.Tables(0)
                'tbHelpdeskNotities.DataBindings.Add("text", bs_helpdesk, "Memo", True)
                'Dim hlpdsk As Helpdesk = MyRelatie.Helpdesk
                tbHelpdeskNotities.DataBindings.Add("text", MyRelatie.Helpdesk, "Memo", True)

                'tbWachtwoord.DataBindings.Add("Text", MyRelatie, "wachtwoord")
                'rbYes.DataBindings.Add("Checked", MyRelatie, "bevestigd", True)
                'rbNo.Checked = Not rbYes.Checked
                '
                ' lblHuidigLidsoort.Text = "Huidig lidsoort: " & MyRelatie.CurrentPeriode.myLidSoort.soort
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillListViewPaymentsContributies()
        Try

            lstvPaymentsYears.Clear()
            With lstvPaymentsYears
                .Columns.Add("jaar", 75, HorizontalAlignment.Left)
                .Columns.Add("id", 0, HorizontalAlignment.Left)
                .View = View.Details

                Dim bCurrentYear As Boolean = False
                Dim lstViewItem As ListViewItem = New ListViewItem()
                For Each per As Contributies In MyRelatie.myContributies
                    If per.jaar = Now.Year Then bCurrentYear = True
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = per.jaar
                    lstViewItem.SubItems.Add(per.Id)
                    .Items.Add(lstViewItem)
                Next

                'Als er voor het huidige jaar nog geen contributie record is , 
                'maak deze dan aan. 
                'If lstvPaymentsYears.FindItemWithText(Now.Year) Is Nothing Then 'And MyRelatie.eindereden = 0 
                If bCurrentYear = False Then
                    Dim newContributies As New Contributies
                    newContributies.lidid = MyRelatie.Id
                    newContributies.jaar = Now.Year
                    newContributies.Save()

                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = newContributies.jaar
                    lstViewItem.SubItems.Add(newContributies.Id)
                    .Items.Add(lstViewItem)
                End If

                .Sorting = System.Windows.Forms.SortOrder.Descending
                .EnsureVisible(.Items.Count - 1)
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnNewYear_Click(sender As Object, e As EventArgs) Handles btnNewYear.Click
        Try
            Dim iYear As Integer = 0
            For Each per As Contributies In MyRelatie.myContributies
                If per.jaar > iYear Then iYear = per.jaar
            Next
            iYear = iYear + 1

            Dim newContributies As New Contributies
            newContributies.lidid = MyRelatie.Id
            newContributies.jaar = iYear
            newContributies.Save()
            FillListViewPaymentsContributies()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillListViewContributies()
        Try

            lvContributies.Clear()
            With lvContributies
                .Columns.Add("datum ingang", 150, HorizontalAlignment.Left)
                .Columns.Add("soort", 150, HorizontalAlignment.Left)
                '.Columns.Add("fase", 50, HorizontalAlignment.Left)
                '.Columns.Add("sedert", 150, HorizontalAlignment.Left)
                .Columns.Add("contributie", 100, HorizontalAlignment.Left)
                .Columns.Add("korting", 100, HorizontalAlignment.Left)
                If URights.IsInGroup("rel_admins") Then
                    .Columns.Add("id", 0, HorizontalAlignment.Left)
                Else
                    .Columns.Add("id", 0, HorizontalAlignment.Left)
                End If

                .View = View.Details
                '.StateImageList = ImageList1

                Dim lstViewItem As ListViewItem = New ListViewItem()
                For Each per As LidSoortPeriode In MyRelatie.LidSoortPerioden
                    lstViewItem = New ListViewItem()
                    If per.Id = MyRelatie.CurrentPeriode.Id Then
                        lstViewItem.BackColor = Color.GreenYellow
                    End If

                    lstViewItem.Text = per.datumin.ToShortDateString
                    lstViewItem.SubItems.Add(per.myLidSoort.omschrijving)
                    'If per.Fase > 0 Then
                    '    lstViewItem.SubItems.Add(per.Fase)
                    'Else
                    '    lstViewItem.SubItems.Add("")
                    'End If

                    'lstViewItem.SubItems.Add(per.myContributie.sedert.ToShortDateString)
                    lstViewItem.SubItems.Add(per.myContributie.mbedrag)
                    lstViewItem.SubItems.Add(per.myContributie.mkorting)
                    lstViewItem.SubItems.Add(per.Id)
                    .Items.Add(lstViewItem)
                Next

                lstViewItem = New ListViewItem()
                lstViewItem.Text = "Nieuw lidsoort toekennen"
                lstViewItem.SubItems.Add("0")
                lstViewItem.SubItems.Add("0")
                lstViewItem.SubItems.Add("0")
                'lstViewItem.SubItems.Add("0")
                ' lstViewItem.SubItems.Add("0")
                .Items.Add(lstViewItem)
                .EnsureVisible(.Items.Count - 1)
            End With

            lblHuidigLidsoort.Text = "Huidig lidsoort: " & MyRelatie.CurrentPeriode.myLidSoort.omschrijving

            If MyRelatie.CurrentPeriode.myLidSoort.Fase = True Then
                grpFase.Visible = True
                Select Case MyRelatie.Fase
                    Case 1
                        rbFase1.Checked = True
                    Case 2
                        rbFase2.Checked = True
                    Case 3
                        rbFase3.Checked = True
                End Select
            Else
                MyRelatie.Fase = 0
                grpFase.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillListViewFuncties()
        Try

            lvFuncties.Clear()
            With lvFuncties
                .Columns.Add(New ColHeader("soort", 100, HorizontalAlignment.Left, True))
                .Columns.Add(New ColHeader("advies", 100, HorizontalAlignment.Left, True))
                .Columns.Add(New ColHeader("orgaan", 100, HorizontalAlignment.Left, True))
                .Columns.Add(New ColHeader("afdeling", 100, HorizontalAlignment.Left, True))
                .Columns.Add(New ColHeader("datum in", 100, HorizontalAlignment.Left, True))
                .Columns.Add(New ColHeader("datum uit", 100, HorizontalAlignment.Left, True))
                .Columns.Add(New ColHeader("toon", 35, HorizontalAlignment.Center, True))
                .Columns.Add(New ColHeader("id", 0, HorizontalAlignment.Left, True))

                .View = View.Details
                Dim lstViewItem As ListViewItem = New ListViewItem()
                For Each func As LidFunctie In MyRelatie.LidFuncties
                    lstViewItem = New ListViewItem()
                    lstViewItem.BackColor = Color.FromArgb(func.myFunctieSoort.colorargb)
                    lstViewItem.Text = func.myFunctieSoort.soort
                    lstViewItem.SubItems.Add(func.AdviesNaam)
                    lstViewItem.SubItems.Add(func.OrgaanNaam)
                    lstViewItem.SubItems.Add(func.AfdelingNaam)
                    lstViewItem.SubItems.Add(func.datumin)
                    lstViewItem.SubItems.Add(func.datumuit)
                    lstViewItem.SubItems.Add(func.Toon)
                    lstViewItem.SubItems.Add(func.Id)
                    .Items.Add(lstViewItem)
                Next

                If .Items.Count < 1 Then
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = "geen functies"
                    lstViewItem.SubItems.Add("0")
                    lstViewItem.SubItems.Add("0")
                    'lstViewItem.SubItems.Add("0")
                    'lstViewItem.SubItems.Add("0")
                    .Items.Add(lstViewItem)
                End If

                .EnsureVisible(.Items.Count - 1)

                lblSignalering.Visible = False
                For Each functie In MyRelatie.LidFuncties
                    If functie.IsCurrent And functie.Toon Then
                        lblSignalering.Visible = True
                        lblSignalering.ForeColor = Color.FromArgb(functie.myFunctieSoort.colorargb)
                        lblSignalering.Text = "Signalering Functie " ' & functie.myFunctieSoort.soort
                    End If
                Next

            End With

            lvFuncties_ColumnClick(lvFuncties, New ColumnClickEventArgs(0))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lvFuncties_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)

        Dim clickedCol As ColHeader = CType(Me.lvFuncties.Columns(e.Column), ColHeader)
        Dim numItems As Integer = Me.lvFuncties.Items.Count
        Me.lvFuncties.BeginUpdate()

        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New ListViewSorter(Me.lvFuncties.Items(i), e.Column))
        Next i

        SortArray.Sort(0, SortArray.Count, New ListViewSorter.SortComparer(clickedCol.ascending))

        Me.lvFuncties.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.lvFuncties.Items.Add(CType(SortArray(z), ListViewSorter).sortItem)
        Next z
        Me.lvFuncties.EndUpdate()

    End Sub


    '    Try
    '        'using connection As SqlConnection = da.GetConnection()

    '        Dim sql As String = "SELECT * FROM verzekeringen WHERE lidid = @lidid ORDER BY id"
    '        cmdAssurance = New SqlClient.SqlCommand(sql, da.GetConnection)
    '        cmdAssurance.Parameters.AddWithValue("@lidid", MyRelatie.Id)

    '        daAssurance = New SqlClient.SqlDataAdapter(cmdAssurance)
    '        dsAssurance = New DataSet
    '        daAssurance.Fill(dsAssurance, "verzekeringen")

    '        dgvAssurance.DataSource = dsAssurance
    '        dgvAssurance.DataMember = "verzekeringen"

    '        'dgvAssurance.DataSource = MyRelatie.MyVerzekeringen
    '        dgvAssurance.Columns("id").Visible = False
    '        dgvAssurance.Columns("lidid").Visible = False





    '        ' End Using

    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub FillHelpDesk()
    '    Try
    '        ' Using connection As SqlConnection = da.GetConnection()
    '        Dim sql As String = "SELECT * FROM Helpdesk where LidId = @LidId"
    '        daHelpdesk.SelectCommand = New SqlClient.SqlCommand
    '        daHelpdesk.SelectCommand.Connection = da.GetConnection
    '        daHelpdesk.SelectCommand.CommandText = sql
    '        daHelpdesk.SelectCommand.CommandType = CommandType.Text
    '        daHelpdesk.SelectCommand.Parameters.AddWithValue("@lidid", MyRelatie.Id)

    '        dsHelpdesk = New DataSet("Helpdesk")
    '        daHelpdesk.Fill(dsHelpdesk, "Helpdesk")

    '        Dim myBuilder As SqlClient.SqlCommandBuilder = New SqlClient.SqlCommandBuilder(daHelpdesk)
    '        myBuilder.GetUpdateCommand()

    '        'End Using


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    ' 
    Private Sub tbLidNr_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbLidNr.Validating
        Try
            If MyRelatie.lidnr <> tbLidNr.Text Then
                Dim testRelatie As New Relaties(tbLidNr.Text, Relaties.Via.LIDNR)
                If testRelatie.Found Then
                    MessageBox.Show(tbLidNr.Text & " bestaat al.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tbLidNr.BackColor = Color.Red
                    sender.focus()
                Else
                    tbLidNr.BackColor = Color.White
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFunctieAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFunctieAdd.Click
        Try
            Dim TopForm As New dlgFunctie(MyRelatie.Id)
            TopForm.Text = "Nieuwe functie toekennen"
            Dim result As DialogResult = TopForm.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                'MyRelatie._CurrentPeriode = Nothing
                MyRelatie._LidFuncties = Nothing
                FillListViewFuncties()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lvContributies_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvContributies.DoubleClick
        Try
            If Not lvContributies.SelectedItems.Count = 0 Then
                Dim SelectedItem As Integer = Me.lvContributies.SelectedItems(0).SubItems(Me.lvContributies.SelectedItems(0).SubItems.Count - 1).Text

                'bugid 1474: Plaatsing code leegmaken indien postactief

                If SelectedItem = 0 Then
                    Dim TopForm As New dlgLidSoort(MyRelatie.Id)
                    TopForm.Text = "Nieuwe lidsoort toekennen"
                    TopForm.dlgNSK_JN = MyRelatie.NSKInOut
                    TopForm.dlgNSKdatum = MyRelatie.NSKDatum
                    Dim result As DialogResult = TopForm.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        MyRelatie._LidSoortPerioden = Nothing
                        MyRelatie._CurrentPeriode = Nothing
                        MyRelatie.NSKInOut = TopForm.dlgNSK_JN
                        MyRelatie.NSKDatum = TopForm.dlgNSKdatum
                        If TopForm.SelectedLidSoort.ResetPlaatsing Then cmbPlaatsing.SelectedValue = 0
                        FillListViewContributies()
                    End If
                Else
                    Dim TopForm As New dlgLidSoort(MyRelatie.Id, SelectedItem)
                    TopForm.Text = "lidsoort wijzigen"
                    TopForm.dlgNSK_JN = MyRelatie.NSKInOut
                    TopForm.dlgNSKdatum = MyRelatie.NSKDatum
                    Dim result As DialogResult = TopForm.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        MyRelatie._LidSoortPerioden = Nothing
                        MyRelatie._CurrentPeriode = Nothing
                        MyRelatie.NSKInOut = TopForm.dlgNSK_JN
                        MyRelatie.NSKDatum = TopForm.dlgNSKdatum
                        If TopForm.SelectedLidSoort.ResetPlaatsing Then cmbPlaatsing.SelectedValue = 0

                        FillListViewContributies()
                    End If
                End If


                'Dim result As DialogResult = dlgOpzegging.ShowDialog()
                'If result = Windows.Forms.DialogResult.OK Then
                '    MyRelatie.eindedatum = dlgOpzegging.dlgeindedatum
                '    MyRelatie.eindereden = dlgOpzegging.dlgeindereden
                '    MyRelatie.NSKInOut = dlgOpzegging.dlgNSK_JN
                '    MyRelatie.NSKDatum = dlgOpzegging.dlgNSKdatum
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbFase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ActiveControl Is sender Then
            Dim radio As New RadioButton
            radio = sender
            MyRelatie.Fase = radio.Tag
        End If
    End Sub
    Private Sub rbGeslacht_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ActiveControl Is sender Then
            Dim radio As New RadioButton
            radio = sender
            Select Case radio.Text.ToUpper
                Case "MAN"
                    rbMan.Checked = True
                    rbWoman.Checked = False
                    rbUnkown.Checked = False
                Case "VROUW"
                    rbMan.Checked = False
                    rbWoman.Checked = True
                    rbUnkown.Checked = False
                Case "ONBEKEND"
                    rbMan.Checked = False
                    rbWoman.Checked = False
                    rbUnkown.Checked = True
            End Select
            MyRelatie.geslacht = radio.Text.ToUpper

        End If
    End Sub

    Friend Sub Save()
        Try
            If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_users") Or URights.IsInGroup("rel_adres") Or URights.IsInGroup("rel_blad") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Me.SelectNextControl(ActiveControl, True, True, True, True)

            If MyRelatie.TimeStampChanged Then
                Dim dlgAsk As New dlgAskIt
                dlgAsk.StartPosition = FormStartPosition.CenterScreen
                dlgAsk.Height = 150
                Dim mylabel As New Label
                mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                mylabel.Name = "lbl"
                mylabel.Text = "Er zijn tussentijdse wijzigingen geweest." & vbCrLf & "Als u door gaat worden deze overschreven." & vbCrLf & "Doorgaan?"
                mylabel.AutoSize = True
                dlgAsk.Controls.Add(mylabel)
                dlgAsk.OK_Button.Text = "Ja"
                dlgAsk.Cancel_Button.Text = "Nee"

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    Dim myHistory As New History
                    myHistory.LidId = MyRelatie.Id
                    myHistory.TableName = "Relaties"
                    myHistory.Veld = "Waarschuwing tussentijdse wijziging"
                    myHistory.WaardeOud = ""
                    myHistory.WaardeNieuw = "beantwoordt met Nee"
                    myHistory.MutDate = Now
                    myHistory.MutDoor = URights.UserName
                    myHistory.Save()
                    Exit Sub
                Else
                    Dim myHistory As New History
                    myHistory.LidId = MyRelatie.Id
                    myHistory.TableName = "Relaties"
                    myHistory.Veld = "Waarschuwing tussentijdse wijziging"
                    myHistory.WaardeOud = ""
                    myHistory.WaardeNieuw = "beantwoordt met Ja"
                    myHistory.MutDate = Now
                    myHistory.MutDoor = URights.UserName
                    myHistory.Save()

                End If
            End If


            If Not ValidateRelatieSettings() Then
                Exit Sub
            End If

            'nieuw lidnr
            Dim SetAutoLidNr As String = GetSysSettingOf("SetAutolidnr", False)
            If SetAutoLidNr.ToLower = "true" Then
                If String.IsNullOrEmpty(MyRelatie.lidnr) Or MyRelatie.lidnr = "0" Then
                    MyRelatie.lidnr = da.MaxLidNr("SELECT MAX(CAST(lidnr AS int)) AS maxnr FROM relaties") + 1
                    tbLidNr.Text = MyRelatie.lidnr
                End If
            End If



            'Dim cmdbuilder As New SqlClient.SqlCommandBuilder(daAssurance)
            'If dsAssurance.HasChanges Then
            '    Dim myHistory As History
            '    For Each row As DataRow In dsAssurance.Tables(0).Rows
            '        Dim ValueOld As String = ""
            '        Dim ValueNew As String = ""
            '        If row.HasVersion(DataRowVersion.Original) And row.HasVersion(DataRowVersion.Current) Then
            '            'dan misschien gewijzigd
            '            ValueOld = row("soort", DataRowVersion.Original) & "\" & row("Verzekeraar", DataRowVersion.Original)
            '            ValueNew = row("soort", DataRowVersion.Current) & "\" & row("Verzekeraar", DataRowVersion.Current)
            '            If ValueOld = ValueNew Then Continue For 'dan is er niets gewijzigd 
            '        ElseIf Not row.HasVersion(DataRowVersion.Original) Then
            '            'dan nieuw
            '            row.Item("Lidid") = MyRelatie.Id
            '            ValueOld = "toegevoegd"
            '            ValueNew = row("soort", DataRowVersion.Current) & "\" & row("Verzekeraar", DataRowVersion.Current)
            '        ElseIf Not row.HasVersion(DataRowVersion.Current) Then
            '            'dan verwijderd
            '            ValueOld = row("soort", DataRowVersion.Original) & "\" & row("Verzekeraar", DataRowVersion.Original)
            '            ValueNew = "verwijderd"
            '        End If

            '        myHistory = New History
            '        myHistory.LidId = MyRelatie.Id
            '        myHistory.TableName = "Verzekering"
            '        myHistory.Veld = "soort\verzekeraar"
            '        myHistory.WaardeOud = ValueOld
            '        myHistory.WaardeNieuw = ValueNew
            '        myHistory.MutDate = Now
            '        myHistory.MutDoor = URights.UserName
            '        myHistory.Save()
            '    Next
            '    daAssurance.Update(dsAssurance, "verzekeringen")
            'End If

            'If UC_Payments1.HasChanges Then
            '    UC_Payments1.Save()
            'End If

            If HasChangesPayments() Then
                SavePayments()
            End If

            If Not MyNazorg Is Nothing Then
                MyNazorg.Save()
            End If

            If MyRelatie.Id > 0 Then SaveHelpDesk(Me)
            'BugID:  1684 :SaveHelpDesk  - Alleen opslaan als het geen nieuwe relatie betreft.

            MyRelatie.Save()
            MyRelatieCopy = MyRelatie.ShallowCopy()



            FillListViewContributies()
            FillListViewPaymentsContributies()
            FillListViewFuncties()

            'MessageBox.Show("opgeslagen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim dlg As New frmSaved()
            dlg.lblResult.Text = "Opgeslagen"
            dlg.StartPosition = FormStartPosition.CenterScreen
            dlg.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function ValidateRelatieSettings() As Boolean
        Try
            Dim result As Boolean = False
            Dim results As New List(Of String)
            If Not String.IsNullOrEmpty(MyRelatie.IBAN) Then
                'BugID: 1132: BIC code niet langer verplicht 
                ' If String.IsNullOrEmpty(MyRelatie.BIC) Then results.Add("- BIC code moet ingevuld zijn als iban Is ingevuld.")

                'If MyRelatie.IBAN.Substring(0, 2) = "NL" Then
                '    If MyRelatie.BIC.Length <> 8 Then results.Add("- BIC code moet 8 characters hebben.")
                '    If Not ValidAlphaNummeric(MyRelatie.BIC) Then results.Add("- BIC code mag alleen letters en cijfers bevatten.")
                'Else
                '    If MyRelatie.BIC.Length > 10 Then results.Add("- Buitenlandse BIC code mag max. 10 characters hebben.")
                '    If Not ValidAlphaNummeric(MyRelatie.BIC) Then results.Add("- BIC code mag alleen letters en cijfers bevatten.")
                'End If

            End If

            If Not String.IsNullOrEmpty(MyRelatie.postcode) AndAlso Not String.IsNullOrEmpty(MyRelatie.ZipCode) Then
                results.Add("postcode NL en postcode buitenland mogen niet beide gevuld zijn.")
            End If

            If Not String.IsNullOrEmpty(MyRelatie.land) AndAlso Not String.IsNullOrEmpty(MyRelatie.postcode) Then
                results.Add("Indien Land Is gevuld moet postcode NL leeg zijn en postcode buitenland worden gebruikt.")
            End If

            If Not tbEmail.Text = "" Then
                If ValidEmail(tbEmail.Text) = False Then _
                    results.Add("Het E-mailadres heeft een ongeldig formaat. voorbeeld 'naam@domein.nl' ")
            End If

            If results.Count > 0 Then
                result = False
                Dim value As String = String.Join(vbCrLf, results.ToArray)
                MessageBox.Show("Corrigeer de onderstaande gegevens:" & vbCrLf & value, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                result = True
            End If

            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try

            Save()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "comboboxen"
    Private Sub cmbTrivReden_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTrivReden.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.TrivReden = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.TrivReden = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tbAantal_triv_TextChanged(sender As Object, e As EventArgs) Handles tbAantal_triv.TextChanged
        Try
            If String.IsNullOrEmpty(tbAantal_triv.Text.ToString) Then tbAantal_triv.Text = 0
            If tbAantal_triv.Text <> "0" Then
                If tbAantal_triv.Enabled Then cmbTrivReden.Enabled = False
                MyRelatie.TrivReden = 0
                cmbTrivReden.SelectedValue = 0
            Else
                If tbAantal_triv.Enabled Then cmbTrivReden.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbXrReden_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbXrReden.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.XrReden = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.XrReden = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tbAantal_Xr_TextChanged(sender As Object, e As EventArgs) Handles tbAantal_Xr.TextChanged
        Try
            If String.IsNullOrEmpty(tbAantal_Xr.Text.ToString) Then tbAantal_Xr.Text = 0
            If tbAantal_Xr.Text <> "0" Then
                If tbAantal_Xr.Enabled Then cmbXrReden.Enabled = False
                MyRelatie.XrReden = 0
                cmbXrReden.SelectedValue = 0
            Else
                If tbAantal_Xr.Enabled Then cmbXrReden.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbBond_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBond.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.bond = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.bond = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbAfdeling_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAfdeling.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.afdeling = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.afdeling = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbKMonderdeel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbKMonderdeel.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.kmond = sender.SelectedValue
                If Not MyRelatie.kmond = 0 Then
                    FillDienstvak()
                End If
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.kmond = 0
                'FillDienstvak()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbDienstvak_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDienstvak.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                'MyRelatie.dienstvak = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.dienstvak = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbPlaatsing_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPlaatsing.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.plaatsing = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.plaatsing = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbRang_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRang.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.rang = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.rang = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbContrInstanties_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbContrInstanties.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.Instantieid = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.Instantieid = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbContrInstantiesVorig_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbContrInstantiesVorig.TextChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                MyRelatie.InstantieIdVorig = sender.SelectedValue
            ElseIf sender.SelectedValue Is Nothing Then
                MyRelatie.InstantieIdVorig = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub cmbStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.TextChanged
    '    Try
    '        If TypeOf sender.SelectedValue Is Integer Then
    '            MyRelatie.Status = sender.SelectedValue
    '        ElseIf sender.SelectedValue Is Nothing Then
    '            MyRelatie.Status = 0
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                If cmbStatus.SelectedValue = 0 Then
                    If MyRelatie.Status = 1 Then
                        Dim dlgAsk As New dlgAskIt
                        Dim LastY As Integer = 0
                        Dim iLabelPositionX As Integer = 0
                        Dim lbl1 As New Label
                        Dim dtp As New DateTimePicker
                        Dim lbl2 As New Label
                        Dim lbl3 As New Label

                        dlgAsk.StartPosition = FormStartPosition.CenterScreen
                        lbl1.Location = New Point(dlgAsk.Location.X + 20, 20)
                        lbl1.Text = "Deze persoon als instroom aangeven?"
                        lbl1.Font = New Font(lbl1.Font, FontStyle.Bold)
                        lbl1.AutoSize = True
                        dlgAsk.Controls.Add(lbl1)
                        LastY = lbl1.Location.Y
                        iLabelPositionX = lbl1.Location.X + 20

                        lbl2.Location = New Point(lbl1.Location.X, LastY + 30)
                        lbl2.Text = "Vul dan hier onder de datum van instroom en kies ''JA''"
                        lbl2.AutoSize = True
                        dlgAsk.Controls.Add(lbl2)
                        LastY = lbl2.Location.Y
                        iLabelPositionX = lbl2.Location.X + 20

                        dtp.Location = New Point(lbl1.Location.X + 5, LastY + 20)
                        dtp.Name = "dtp"
                        dtp.Format = DateTimePickerFormat.Custom
                        dtp.CustomFormat = "dd-MM-yyyy"
                        dtp.Value = Today
                        dlgAsk.Controls.Add(dtp)
                        LastY = dtp.Location.Y
                        iLabelPositionX = dtp.Location.X + 20

                        lbl3.Location = New Point(lbl1.Location.X, LastY + 40)
                        lbl3.Text = "Vergeet niet de ''Einde datum'' te verwijderen!"
                        lbl3.AutoSize = True
                        lbl3.Font = New Font(lbl1.Font, FontStyle.Bold)
                        dlgAsk.Controls.Add(lbl3)
                        LastY = lbl2.Location.Y
                        iLabelPositionX = lbl2.Location.X + 20

                        dlgAsk.OK_Button.Text = "Ja"
                        dlgAsk.Cancel_Button.Text = "Nee"

                        dlgAsk.ShowDialog()

                        If dlgAsk.DialogResult <> DialogResult.OK Then
                            Exit Sub
                        Else
                            MyRelatie.InstroomDatum = dtp.Value
                        End If
                    End If
                    'MessageBox.Show("is nu weer nul en was " & MyRelatie.Status)
                Else
                    If MyRelatie.HasOpenDossiers Then
                        MessageBox.Show("Er zijn open dossiers voor deze persoon, dus dit mag niet.")
                        cmbStatus.SelectedValue = 0
                    End If
                End If
                End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim cmb As ComboBox = sender
            If cmb.Text = "" Then

            ElseIf sender.SelectedValue Is Nothing Then
                MessageBox.Show("code " & cmb.Text & " is niet gevonden", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    Private Sub tbPostCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbPostCode.KeyUp
        Try
            If e.KeyData <> Keys.Delete And e.KeyData <> Keys.Back Then
                If tbPostCode.Text.Length = 4 Then
                    tbPostCode.AppendText(" ")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbPostCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPostCode.LostFocus
        Try
            Dim tb As TextBox = sender
            If tb.Text.Length >= 4 Then
                cmbAfdeling.SelectedValue = da.CheckPostcode_Afdeling(tbPostCode.Text.Substring(0, 4))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lstvPaymentsYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstvPaymentsYears.SelectedIndexChanged
        Try
            If Not lstvPaymentsYears.SelectedItems.Count = 0 Then
                If HasChangesPayments() Then
                    MessageBox.Show("er zijn wijzigingen in de contributies. Deze eerst opslaan!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Try
                End If
                Dim SelectedItem As Integer = Me.lstvPaymentsYears.SelectedItems(0).SubItems(1).Text
                If SelectedItem = 0 Then

                Else
                    lblYear.Text = "Contributie overzicht jaar: " & lstvPaymentsYears.SelectedItems(0).SubItems(0).Text
                    'UC_Payments1.Fillpayments(SelectedItem)
                    Fillpayments(SelectedItem)
                    CalcRest()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbChanges.Click
        Try
            Dim ChildForm As New frmHistory(MyRelatie.Id)
            ChildForm.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbBond_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBond.SelectedIndexChanged
        Try
            If ActiveControl Is sender Then
                Dim Bonden As DataTable = da.ExecuteDataTable("SELECT * FROM Bonden ORDER BY Omschrijving")
                Dim param() As Object = {"@id", cmbBond.SelectedValue}
                Dim rw As DataRow = da.ExecuteDataRow("SELECT * FROM Bonden WHERE id = @id ORDER BY Omschrijving", param)
                If Not rw Is Nothing Then
                    If rw("Xrcise").ToString = "True" Then
                        Me.tbAantal_Xr.Text = "1"
                    Else
                        Me.tbAantal_Xr.Text = "0"
                    End If
                End If
                Me.tbAantal_Xr.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnEindeDatum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEindeDatum.Click
        Try
            Dim dlgOpzegging As New dlgOpzegging
            dlgOpzegging.StartPosition = FormStartPosition.CenterScreen
            dlgOpzegging.dlgeindedatum = MyRelatie.eindedatum
            dlgOpzegging.dlgeindereden = MyRelatie.eindereden
            dlgOpzegging.dlgNSK_JN = MyRelatie.NSKInOut
            dlgOpzegging.dlgNSKdatum = MyRelatie.NSKDatum


            'valdatie op bestaande open dossiers maken.
            If MyRelatie.HasOpenDossiers Then
                Dim dlgAsk As New dlgAskIt
                Dim LastY As Integer = 0
                Dim iLabelPositionX As Integer = 0
                Dim mylabel As New Label
                Dim mylabel2 As New Label

                dlgAsk.Height = 150
                dlgAsk.Width = 550
                dlgAsk.StartPosition = FormStartPosition.CenterScreen
                Dim myfont As Font = New Font(dlgAsk.Font, FontStyle.Bold)

                mylabel.Font = myfont
                mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                mylabel.Text = "Er zijn nog openstaande dossiers. Deze moeten eerst worden afgehandeld!"
                mylabel.AutoSize = True

                mylabel2.Font = myfont
                mylabel2.Location = New Point(dlgAsk.Location.X + 20, 50)
                mylabel2.Text = String.Join(vbCrLf, MyRelatie.ListOpenDossiers.ToArray)
                mylabel2.AutoSize = True

                dlgAsk.Controls.Add(mylabel)
                dlgAsk.Controls.Add(mylabel2)
                'dlgAsk.OK_Button.Text = "Ja"
                dlgAsk.Text = "open dossiers "
                dlgAsk.OK_Button.Visible = False
                dlgAsk.Cancel_Button.Text = "OK"

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If



            Dim result As DialogResult = dlgOpzegging.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                MyRelatie.eindedatum = dlgOpzegging.dlgeindedatum
                MyRelatie.eindereden = dlgOpzegging.dlgeindereden
                MyRelatie.NSKInOut = dlgOpzegging.dlgNSK_JN
                MyRelatie.NSKDatum = dlgOpzegging.dlgNSKdatum
                tbEindeDatum.Text = MyRelatie.NSKDatum
                FindEindeReden()
                If Not dlgOpzegging.dlgeindereden = 0 Then

                    ' controleer dan of de datum in de toekomst ligt.
                    ' zoniet dan de status bijwerken.
                    Dim eindedatum As DateTime = dlgOpzegging.dlgeindedatum
                    If eindedatum <= Today Then
                        MyRelatie.Status = 1
                        cmbStatus.SelectedValue = 1
                    End If
                Else
                    MessageBox.Show("U heeft een opzegging ongedaan gemaakt. " & vbCrLf & _
                                    "De status wordt hiermee NIET autmatisch aanpast en moet handmatig worden gewijzigd!", _
                                    My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FindEindeReden()
        Dim foundRows() As DataRow
        foundRows = EindeReden.Select("Id = " & MyRelatie.eindereden)
        If foundRows.Length > 0 Then
            lblRedenOpzegging.Text = foundRows(0).Item("omschrijving")
        Else
            lblRedenOpzegging.Text = "..."
        End If
        EindeReden_Validating()
    End Sub
    Private Sub EindeReden_Validating()
        Try
            If lblRedenOpzegging.Text.ToString.ToUpper = "OVERLEDEN" Then
                If Not String.IsNullOrEmpty(MyRelatie.erelid) Or Not String.IsNullOrEmpty(MyRelatie.lid_verdienste) Then
                    lblAlarm.Text = "!!!!ALARM!!!! = spelddrager!!!!"
                    lblAlarm.ForeColor = Color.Red
                    tmrSignal.Start()
                    lblAlarm.Visible = True
                End If
            Else
                lblAlarm.Visible = False
                tmrSignal.Stop()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetCorrespondentie()
        Try
            Dim sql As String = "SELECT * FROM Documents WHERE lidId = @lidid AND (BerichtenId is NULL or BerichtenId = 0) ORDER BY CreateDate DESC"
            Dim param() As Object = {"@lidid", MyRelatie.Id}
            Dim dt As DataTable = da.ExecuteDataTable(sql, param)
            dgvDocuments.AutoGenerateColumns = False
            dgvDocuments.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetStorno()
        Try
            dgvStorno.DataSource = Nothing
            Dim sql As String = "SELECT * FROM storneringen WHERE lidId = @lidId ORDER BY id DESC"
            Dim param() As Object = {"@lidId", MyRelatie.Id}
            Dim dt As DataTable = da.ExecuteDataTable(sql, param)
            dgvStorno.AutoGenerateColumns = False
            dgvStorno.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GetIBB()
        Try
            Dim sql As String = "SELECT IBBdossiers.Id,DossierNr,Onderwerp, CreateDate,naam as Behandelaar,Afgehandeld " & _
                                "FROM IBBdossiers " & _
                                "LEFT JOIN Behandelaren on IBBdossiers.behandelaarid = Behandelaren.Id " & _
                                "WHERE lidId = @lidId ORDER BY createdate DESC"
            Dim param() As Object = {"@lidId", MyRelatie.Id}
            Dim dt As DataTable = da.ExecuteDataTable(sql, param)
            dgvIBB.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GetNazorg()
        Try
            If lblRedenOpzegging.Text.ToString.ToUpper = "OVERLEDEN" Then
                Me.lblDatumOverlijden.Text = Me.tbEindeDatum.Text
                Me.ULabelNazorg.Text = "Nazorg"
                Me.grbHideAfterCare.Visible = True
                Me.grbHideAfterCare.SendToBack()
                If MyNazorg Is Nothing Then
                    MyNazorg = New Nazorg(MyRelatie.Id, Nazorg.Via.LIDID)
                    If Not MyNazorg.Found Then 'dan wordt het een nieuwe. Vul dan eenmalig het lidid en laatste rang in.
                        MyNazorg.Lidid = MyRelatie.Id
                        MyNazorg.LaatsteRang = MyRelatie.RangNaamOnly
                    End If

                    'chkBloemen.DataBindings.Add("Checked", MyNazorg, "Bloemen", True)
                    Select Case MyNazorg.Bloemen
                        Case 1
                            rbBloemenJa.Checked = True
                        Case 2
                            rbBloemenNee.Checked = True
                        Case Else
                            rbBloemenJa.Checked = False
                            rbBloemenNee.Checked = False
                    End Select

                    Select Case MyNazorg.Uitvaart
                        Case 0
                            rbNvtUitvaart.Checked = True
                        Case 1
                            rbBegrafenis.Checked = True
                        Case 2
                            rbCrematie.Checked = True
                    End Select

                    tbLaatsteRang.DataBindings.Add("text", MyNazorg, "LaatsteRang")
                    'chkTrivMelding.DataBindings.Add("Checked", MyNazorg, "TrivMelding", True)
                    Select Case MyNazorg.TrivMelding
                        Case 1
                            rbTrivMeldingJa.Checked = True
                        Case 2
                            rbTrivMeldingNee.Checked = True
                        Case Else
                            rbTrivMeldingJa.Checked = False
                            rbTrivMeldingNee.Checked = False
                    End Select

                    Select Case MyNazorg.Opgebaard
                        Case 1
                            rbOpgebaardJa.Checked = True
                        Case 2
                            rbOpgebaardNee.Checked = True
                        Case Else
                            rbOpgebaardJa.Checked = False
                            rbOpgebaardNee.Checked = False
                    End Select

                    tbNabestaandeRegel1.DataBindings.Add("text", MyNazorg, "NabestaandeRegel1")
                    tbNabestaandeRegel2.DataBindings.Add("text", MyNazorg, "NabestaandeRegel2")
                    tbNabestaandeRegel3.DataBindings.Add("text", MyNazorg, "NabestaandeRegel3")
                    tbNabestaandeRegel4.DataBindings.Add("text", MyNazorg, "NabestaandeRegel4")
                    tbNazorgMedewerker.DataBindings.Add("text", MyNazorg, "NazorgMedewerker")

                    tbNabestaandeTel.DataBindings.Add("text", MyNazorg, "NabestaandeTel")

                    tbUitvaartAdres1.DataBindings.Add("text", MyNazorg, "UitvaartAdres1")
                    tbUitvaartAdres2.DataBindings.Add("text", MyNazorg, "UitvaartAdres2")
                    tbUitvaartAdres3.DataBindings.Add("text", MyNazorg, "UitvaartAdres3")
                    tbUitvaartAdres4.DataBindings.Add("text", MyNazorg, "UitvaartAdres4")
                    tbNabestaandeRegel1.Focus()
                End If
            Else
                Me.ULabelNazorg.Text = "Alleen beschikbaar indien eindedatum en overleden is ingevuld!"
                Me.grbHideAfterCare.BringToFront()
                Me.grbHideAfterCare.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillMailList()
        'If MyRelatie.Id = 0 Then Exit Sub

        Dim _lvItem As ListViewItem = New ListViewItem()
        Try
            With lvMail
                .Clear()

                .Columns.Add("ID", 50, HorizontalAlignment.Left)
                .Columns.Add("onderwerp", 150, HorizontalAlignment.Left)
                .Columns.Add("van", 100, HorizontalAlignment.Left)
                .Columns.Add("ontvangen", 100, HorizontalAlignment.Left)
                .View = View.Details


                _lvItem = New ListViewItem
                '_lvItem.Text = 0
                '_lvItem.SubItems.Add("Nieuwe toevoegen")
                '_lvItem.SubItems.Add("")
                '_lvItem.SubItems.Add("")
                '.Items.Add(_lvItem)
                _lvItem = Nothing
                For Each msg As Berichten In MyRelatie.EmailBerichten
                    _lvItem = New ListViewItem
                    _lvItem.Text = msg.Id
                    _lvItem.SubItems.Add(msg.Subject)
                    _lvItem.SubItems.Add(msg.FromName)
                    _lvItem.SubItems.Add(msg.ReceivedDate)
                    .Items.Add(_lvItem)
                    _lvItem = Nothing
                Next

                If .Items.Count > 1 Then
                    .EnsureVisible(.Items.Count - 1)
                End If

            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lvMail_DoubleClick(sender As Object, e As EventArgs) Handles lvMail.DoubleClick
        Try
            With lvMail
                If Not .SelectedItems.Count = 0 Then
                    Dim SelectedItem As String = .SelectedItems(0).Text
                    Dim SelectedDoc As Documents = New Documents(SelectedItem, Documents.Via.BerichtenId)
                    If SelectedDoc.Found Then
                        System.Diagnostics.Process.Start(SelectedDoc.Location)
                    End If
                    SelectedDoc = Nothing
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnStornoAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStornoAdd.Click
        Try
            Dim TopForm As New dlgStorno(MyRelatie)
            TopForm.Text = "Nieuwe stornering"
            Dim result As DialogResult = TopForm.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                GetStorno()
                FillListViewPaymentsContributies()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            If TabControl1.SelectedTab.Name = "TabContributie" Then
                If MyRelatie.Id = 0 Then
                    If MessageBox.Show("Dit is een nieuw lid." _
                                    & vbCrLf & "U moet eerst de gegevens opslaan", "IOpslaan", MessageBoxButtons.YesNo, _
                                    MessageBoxIcon.Question) = DialogResult.Yes Then
                        Save()
                    Else
                        '
                    End If
                End If
                If Not lstvPaymentsYears.FindItemWithText(Now.Year) Is Nothing Then
                    lstvPaymentsYears.Items(Me.lstvPaymentsYears.FindItemWithText(Now.Year).Index).Selected = True
                End If
            ElseIf TabControl1.SelectedTab.Name = "TabCorrespondentie" Then
                GetCorrespondentie()
            ElseIf TabControl1.SelectedTab.Name = "TabIBB" Then
                GetIBB()
            ElseIf TabControl1.SelectedTab.Name = "TabStorno" Then
                GetStorno()
            ElseIf TabControl1.SelectedTab.Name.ToUpper = "TABNAZORG" Then
                GetNazorg()
            ElseIf TabControl1.SelectedTab.Name.ToUpper = "TABHELPDESK" Then
                FillMailList()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDocuments_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocuments.CellClick
        Try
            Dim gr As New DataGridView
            gr = sender
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                If TypeOf (gr.Rows(e.RowIndex).Cells(e.ColumnIndex)).OwningColumn Is DataGridViewButtonColumn Then
                    Dim DocId As Integer = gr.Rows(e.RowIndex).Cells("id").Value
                    If MessageBox.Show("Weet u zeker dat u dit document wilt verwijderen?.", "Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim NewDocument As New Documents(DocId)
                        NewDocument.Remove(True)
                        GetCorrespondentie()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub dgvDocuments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDocuments.DoubleClick
        Try

            If dgvDocuments.SelectedRows.Count > 0 Then
                If URights.IsMemberOfOne(AllowDocumentsGroups) Then
                    System.Diagnostics.Process.Start(Me.dgvDocuments.SelectedRows(0).Cells("Locatie").Value)
                Else
                    MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                'If Not URights.IsInGroup("rel_admins") Then
                '    Dim NewDocument As New Documents(Me.dgvDocuments.SelectedRows(0).Cells("Id").Value)
                '    If NewDocument.CreatedBy <> URights.UserName Then
                '        NewDocument = Nothing
                '        Throw New Exception("Alleen de eigenaar of admins mogen dit documetent openen.")
                '    End If

                'End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        Try
            Dim ChildForm As New frmRelatie
            ChildForm.MdiParent = Main
            ChildForm.WindowState = FormWindowState.Maximized

            ChildForm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btNewIBB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNewIBB.Click
        Try
            Dim ChildForm As frmIBBDossier = Main.FindChild("frmIBBDossier")
            If ChildForm Is Nothing Then
                ChildForm = New frmIBBDossier
                ChildForm.MdiParent = Main
                ChildForm.WindowState = FormWindowState.Maximized
                ChildForm.MyRelatie = MyRelatie
                'ChildForm.utddatumaanmaak.Value = Today
                ChildForm.Show()
                'If TypeName(Me.MenuStrip.Items(0)) = "SystemMenuItem" Then
                '    Dim t As Long
                '    t = Me.MenuStrip.Height
                '    Me.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                '    Me.MenuStrip.Height = t    'otherwise it goes too big.
                'End If

            Else
                ChildForm.Activate()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub dgvIBB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvIBB.DoubleClick
        Try
            If dgvIBB.SelectedRows.Count > 0 Then
                Dim ChildForm As New frmIBBDossier
                ChildForm.MdiParent = Main
                ChildForm.WindowState = FormWindowState.Maximized
                ChildForm.MyRelatie = MyRelatie
                ChildForm.MyIBBDossier = New IBBDossier(dgvIBB.SelectedRows(0).Cells("Id").Value, IBBDossier.VIA.ID)
                ChildForm.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub btnPostcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostcode.Click
        Try
            Dim pctext As String = tbPostCode.Text
            pctext = pctext.Replace(" ", "")
            Dim huisnrtext As String = tbHuisNr.Text

            Dim pc As New PostCode(pctext, huisnrtext)
            MyRelatie.adres = pc.Straat
            MyRelatie.plaats = pc.Plaats

            tbAdres.Text = pc.Straat
            tbPlaats.Text = pc.Plaats

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub lvFuncties_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFuncties.DoubleClick
        Try
            If Not lvFuncties.SelectedItems.Count = 0 Then
                Dim SelectedItem As Integer = Me.lvFuncties.SelectedItems(0).SubItems(Me.lvFuncties.SelectedItems(0).SubItems.Count - 1).Text

                If SelectedItem = 0 Then
                    'Dim TopForm As New dlgFunctie(MyRelatie.Id)
                    'TopForm.Text = "Nieuwe lidsoort toekennen"
                    'Dim result As DialogResult = TopForm.ShowDialog()
                    'If result = Windows.Forms.DialogResult.OK Then
                    '    MyRelatie._LidFuncties = Nothing
                    '    'MyRelatie._CurrentPeriode = Nothing
                    '    FillListViewFuncties()
                    'End If
                Else
                    Dim TopForm As New dlgFunctie(MyRelatie.Id, SelectedItem)
                    TopForm.Text = "Functie wijzigen"
                    Dim result As DialogResult = TopForm.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        MyRelatie._LidFuncties = Nothing
                        'MyRelatie._CurrentPeriode = Nothing
                        FillListViewFuncties()
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmail.Click
        Try
            If Not tbEmail.Text = "" And ValidEmail(tbEmail, New System.ComponentModel.CancelEventArgs) Then
                System.Diagnostics.Process.Start("mailto:" & tbEmail.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnEmailWerk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmailWerk.Click
        Try
            If Not tbEmailWerk.Text = "" And ValidEmail(tbEmailWerk, New System.ComponentModel.CancelEventArgs) Then
                System.Diagnostics.Process.Start("mailto:" & tbEmailWerk.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click

        Try
            Main.RelatiePrint()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSaveFunctiekaart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFunctiekaart.Click
        Try
            Dim HistoryList As New List(Of History)
            Dim myHistory As History = Nothing

            Dim checkValue As Boolean = False
            checkValue = da.ExecuteScalar("Select alv FROM relaties WHERE id = " & MyRelatie.Id)
            If chkAvFunctie.Checked <> checkValue Then
                myHistory = New History
                myHistory.LidId = MyRelatie.Id
                myHistory.TableName = "relaties"
                myHistory.Veld = "alv"
                myHistory.WaardeOud = checkValue
                myHistory.WaardeNieuw = chkAvFunctie.Checked
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                HistoryList.Add(myHistory)
            End If

            checkValue = da.ExecuteScalar("Select kerstkaart FROM relaties WHERE id = " & MyRelatie.Id)
            If chkKerstkaartFnc.Checked <> checkValue Then
                myHistory = New History
                myHistory.LidId = MyRelatie.Id
                myHistory.TableName = "relaties"
                myHistory.Veld = "kerstkaart"
                myHistory.WaardeOud = checkValue
                myHistory.WaardeNieuw = chkKerstkaartFnc.Checked
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                HistoryList.Add(myHistory)
            End If
            checkValue = da.ExecuteScalar("Select lid_natres FROM relaties WHERE id = " & MyRelatie.Id)
            If chkLid_natresFnc.Checked <> checkValue Then
                myHistory = New History
                myHistory.LidId = MyRelatie.Id
                myHistory.TableName = "relaties"
                myHistory.Veld = "lid_natres"
                myHistory.WaardeOud = checkValue
                myHistory.WaardeNieuw = chkLid_natresFnc.Checked
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                HistoryList.Add(myHistory)
            End If
            checkValue = da.ExecuteScalar("Select veteraan FROM relaties WHERE id = " & MyRelatie.Id)
            If chkVeteraanFnc.Checked <> checkValue Then
                myHistory = New History
                myHistory.LidId = MyRelatie.Id
                myHistory.TableName = "relaties"
                myHistory.Veld = "veteraan"
                myHistory.WaardeOud = checkValue
                myHistory.WaardeNieuw = chkVeteraanFnc.Checked
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                HistoryList.Add(myHistory)
            End If
            checkValue = da.ExecuteScalar("Select NATO FROM relaties WHERE id = " & MyRelatie.Id)
            If chkNatoFnc.Checked <> checkValue Then
                myHistory = New History
                myHistory.LidId = MyRelatie.Id
                myHistory.TableName = "relaties"
                myHistory.Veld = "NATO"
                myHistory.WaardeOud = checkValue
                myHistory.WaardeNieuw = chkNatoFnc.Checked
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                HistoryList.Add(myHistory)
            End If
            checkValue = da.ExecuteScalar("Select bom FROM relaties WHERE id = " & MyRelatie.Id)
            If chkBOMfnc.Checked <> checkValue Then
                myHistory = New History
                myHistory.LidId = MyRelatie.Id
                myHistory.TableName = "relaties"
                myHistory.Veld = "BOM"
                myHistory.WaardeOud = checkValue
                myHistory.WaardeNieuw = chkBOMfnc.Checked
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                HistoryList.Add(myHistory)
            End If
            Dim sql As String = _
                    "Update Relaties " & _
                        "SET [alv] = @alv " & _
                        ",[kerstkaart] = @kerstkaart " & _
                        ",[lid_natres] = @lid_natres " & _
                        ",[veteraan] = @veteraan " & _
                        ",[NATO] = @NATO " & _
                        ",[BOM] = @BOM " & _
                    "WHERE id = @lidid"

            Dim paramlist As New ArrayList
            paramlist.Add("@lidid")
            paramlist.Add(MyRelatie.Id)
            paramlist.Add("@alv")
            paramlist.Add(chkAvFunctie.CheckState)
            paramlist.Add("@kerstkaart")
            paramlist.Add(chkKerstkaartFnc.CheckState)
            paramlist.Add("@lid_natres")
            paramlist.Add(chkLid_natresFnc.CheckState)
            paramlist.Add("@veteraan")
            paramlist.Add(chkVeteraanFnc.CheckState)
            paramlist.Add("@NATO")
            paramlist.Add(chkNatoFnc.CheckState)
            paramlist.Add("@BOM")
            paramlist.Add(chkBOMfnc.CheckState)
            da.ExecuteScalar(sql, paramlist.ToArray)

            MyRelatieCopy = MyRelatie.ShallowCopy()

            For Each History In HistoryList
                History.Save()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub SaveHelpDesk(sender As Object)
        Try
            'bs_helpdesk.EndEdit()
            Dim bHelpdeskUpdate As Boolean = False
            If MyRelatie.Id = 0 Then Throw New Exception("SaveHelpDesk error - Er is nog geen relatieId. Sla eerst de nieuwe relatie gegevens op voor de helpdeskmemo.")

            'If dsHelpdesk.HasChanges Then
            '    daHelpdesk.Update(dsHelpdesk, "Helpdesk")
            '    bHelpdeskUpdate = True
            'Else
            If Not String.IsNullOrEmpty(tbHelpdeskNotities.Text) AndAlso Not MyRelatie.Helpdesk.Found Then
                    'dus is het een nieuwe, dus toevoegen
                    'Dim newRow As DataRow = dsHelpdesk.Tables(0).NewRow
                    'ds.Tables(0).Rows.Add(newRow)
                    MyRelatie.Helpdesk.LidId = MyRelatie.Id
                    MyRelatie.Helpdesk.Memo = tbHelpdeskNotities.Text
                    MyRelatie.Helpdesk.CreateBy = URights.UserName
                    MyRelatie.Helpdesk.CreateDate = Now
                    MyRelatie.Helpdesk.Save()

                    bHelpdeskUpdate = True
                End If
            If MyRelatie.Helpdesk.Memo <> MyRelatieCopy.Helpdesk.Memo Then
                bHelpdeskUpdate = True
                MyRelatie.Helpdesk.Save()
                MyRelatieCopy = _MyRelatie.ShallowCopy()
            End If

            If bHelpdeskUpdate = True Then
                Dim myHistory As History
                myHistory = New History
                myHistory.LidId = MyRelatie.Id
                myHistory.TableName = "Helpdesk"
                myHistory.Veld = "Memo"
                myHistory.WaardeOud = "notitie"
                myHistory.WaardeNieuw = "notitie"
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            End If

            If sender.name = "btnSaveHelpDesk" Then
                MessageBox.Show("opgeslagen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnSaveHelpDesk_Click(sender As Object, e As EventArgs) Handles btnSaveHelpDesk.Click
        Try
            SaveHelpDesk(sender)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private bVisible As Boolean = False
    Private Sub tmrSignal_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrSignal.Tick
        lblAlarm.Visible = bVisible
        bVisible = Not bVisible
    End Sub

    Private Sub tbRegistratienr_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbRegistratienr.Validated
        Try
            If tbGebdatum.Text = "" And tbRegistratienr.Text.Length >= 6 Then
                Dim jaar As String = tbRegistratienr.Text.Substring(0, 2)
                Dim maand As String = tbRegistratienr.Text.Substring(2, 2)
                Dim dag As String = tbRegistratienr.Text.Substring(4, 2)
                Dim Gebdatum As String
                If CInt(jaar) <= 20 Then
                    Gebdatum = dag.PadLeft(2, "0") & "-" & maand.PadLeft(2, "0") & "-20" & jaar
                Else
                    Gebdatum = dag.PadLeft(2, "0") & "-" & maand.PadLeft(2, "0") & "-19" & jaar
                End If
                Dim TryDate As DateTime
                If (DateTime.TryParse(Gebdatum, TryDate)) Then
                    tbGebdatum.Text = Gebdatum
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private URights As UserRights = UserRights.Instance
    'Private da As New DataAccess
    Private cmdPayments As SqlCommand
    Private daPayments As SqlDataAdapter
    Private dsPayments As DataSet
    Private cmdbuilder As SqlCommandBuilder
    Private bsds As BindingSource
    'Private lidid As Integer = 0
    Private Sub CheckInt(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim tb As TextBox = sender
        Try
            If tb.Text <> "" Then
                Dim i As Integer = Int32.Parse(tb.Text)
            End If

            ErrorProvider1.SetError(tb, "")
            CalcRest()

        Catch ex As Exception
            ErrorProvider1.SetError(tb, tb.Text & ": Foutieve invoer! Geef het bedrag in centen (zonder '','')")
            tb.Text = "0"
        End Try
    End Sub

    Public Function HasChangesPayments() As Boolean
        Try
            If dsPayments Is Nothing Then Return False
            bsds.EndEdit()
            Return dsPayments.HasChanges

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function SavePayments() As Boolean
        Try
            If dsPayments Is Nothing Then Return False
            bsds.EndEdit()

            If dsPayments.HasChanges Then
                Dim cmdbuilder As New SqlClient.SqlCommandBuilder(daPayments)
                Dim myHistory As History = Nothing
                For Each col As DataColumn In dsPayments.Tables(0).Columns
                    If dsPayments.Tables(0).Rows(0).Item(col, DataRowVersion.Current) <> dsPayments.Tables(0).Rows(0).Item(col, DataRowVersion.Original) Then
                        myHistory = New History
                        myHistory.LidId = MyRelatie.Id
                        myHistory.TableName = "Contributies"
                        myHistory.Veld = col.ColumnName & " " & dsPayments.Tables(0).Rows(0).Item("jaar", DataRowVersion.Original)
                        myHistory.WaardeOud = dsPayments.Tables(0).Rows(0).Item(col, DataRowVersion.Original)
                        myHistory.WaardeNieuw = dsPayments.Tables(0).Rows(0).Item(col, DataRowVersion.Current)
                        myHistory.MutDate = Now
                        myHistory.MutDoor = URights.UserName
                        myHistory.Save()
                    End If
                Next
            End If
            daPayments.Update(dsPayments, "Contributies")

            Return dsPayments.HasChanges

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub Fillpayments(ByVal id As Integer)
        Try
            'If Not dsPayments Is Nothing Then
            '    bsds.EndEdit()
            '    If dsPayments.HasChanges Then
            '        Throw New Exception("Wijziging in contributie eerst opslaan voordat u een ander jaar selecteert")
            '    End If
            'End If

            Dim BindingControl As Control
            For Each BindingControl In Me.grpPayments.Controls
                BindingControl.DataBindings.Clear()
            Next

            'Using connection As SqlConnection = da.GetConnection()

            Dim sql As String = "SELECT * FROM Contributies where id = " & id

            cmdPayments = New SqlCommand(sql, da.GetConnection)
            daPayments = New SqlDataAdapter(cmdPayments)
            dsPayments = New DataSet
            daPayments.Fill(dsPayments, "Contributies")
            da.GetConnection.Close()

            cmdbuilder = New SqlCommandBuilder(daPayments)
            bsds = New BindingSource
            bsds.DataSource = dsPayments.Tables("Contributies")

            tbJan.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "jan", True))
            tbFeb.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "feb", True))
            tbMrt.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "mar", True))
            tbApr.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "apr", True))
            tbMei.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "mei", True))
            tbJun.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "jun", True))
            tbJul.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "jul", True))
            tbAug.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "aug", True))
            tbSep.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "sep", True))
            tbOkt.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "okt", True))
            tbNov.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "nov", True))
            tbDec.DataBindings.Add(New System.Windows.Forms.Binding("Text", bsds, "dec", True))

            FillContibitie(MyRelatie.Id, dsPayments.Tables(0).Rows(0).Item("jaar"))
            ' End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub FillContibitie(ByVal LidId As Integer, ByVal jaar As Integer)
        Try

            Dim relatie As New Relaties(LidId, Relaties.Via.ID)
            If relatie.MyRang.Korting = True Then
                lblContributieKorting.Visible = True
                lblContributieKorting.Text = "Korting op rang!!"
            Else
                lblContributieKorting.Visible = False
                lblContributieKorting.Text = "GEEN Korting op rang!!"
            End If

            tbContrJan.Text = relatie.SelectedPeriode(New Date(jaar, "01", "01")).myContributie.mbedrag
            tbContrFeb.Text = relatie.SelectedPeriode(New Date(jaar, "02", "01")).myContributie.mbedrag
            tbContrMrt.Text = relatie.SelectedPeriode(New Date(jaar, "03", "01")).myContributie.mbedrag
            tbContrApr.Text = relatie.SelectedPeriode(New Date(jaar, "04", "01")).myContributie.mbedrag
            tbContrMei.Text = relatie.SelectedPeriode(New Date(jaar, "05", "01")).myContributie.mbedrag
            tbContrJun.Text = relatie.SelectedPeriode(New Date(jaar, "06", "01")).myContributie.mbedrag
            tbContrJul.Text = relatie.SelectedPeriode(New Date(jaar, "07", "01")).myContributie.mbedrag
            tbContrAug.Text = relatie.SelectedPeriode(New Date(jaar, "08", "01")).myContributie.mbedrag
            tbContrSep.Text = relatie.SelectedPeriode(New Date(jaar, "09", "01")).myContributie.mbedrag
            tbContrOkt.Text = relatie.SelectedPeriode(New Date(jaar, "10", "01")).myContributie.mbedrag
            tbContrNov.Text = relatie.SelectedPeriode(New Date(jaar, "11", "01")).myContributie.mbedrag
            tbContrDec.Text = relatie.SelectedPeriode(New Date(jaar, "12", "01")).myContributie.mbedrag

            'CalcRest()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub CalcRest()
        Try

            tbRestJan.Text = tbContrJan.Text - tbJan.Text
            tbRestFeb.Text = tbContrFeb.Text - tbFeb.Text
            tbRestMrt.Text = tbContrMrt.Text - tbMrt.Text
            tbRestApr.Text = tbContrApr.Text - tbApr.Text
            tbRestMei.Text = tbContrMei.Text - tbMei.Text
            tbRestJun.Text = tbContrJun.Text - tbJun.Text
            tbRestjul.Text = tbContrJul.Text - tbJul.Text
            tbRestAug.Text = tbContrAug.Text - tbAug.Text
            tbRestSep.Text = tbContrSep.Text - tbSep.Text
            tbRestOkt.Text = tbContrOkt.Text - tbOkt.Text
            tbRestNov.Text = tbContrNov.Text - tbNov.Text
            tbRestDec.Text = tbContrDec.Text - tbDec.Text

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNext.Click
        Dim frm As New Main
        frm = Me.ParentForm
        frm.FindChild("frmRelatieSearch")
        Dim ChildForm As frmRelatieSearch = frm.FindChild("frmRelatieSearch")
        If ChildForm Is Nothing Then
            MessageBox.Show("Het zoekscherm is afgesloten en daardoor niet meer aan te spreken", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If ChildForm.dgvLeden.RowCount > 1 Then
                Dim RowCount As Integer = ChildForm.dgvLeden.RowCount - 1
                If (ChildForm.dgvLeden.SelectedRows(0).Index + 1) < RowCount Then
                    ChildForm.dgvLeden.Rows(ChildForm.dgvLeden.SelectedRows(0).Index + 1).Selected = True
                    Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                    ChildForm.OpenFrmLid()
                Else
                    MessageBox.Show("Einde zoekresultaten", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBack.Click
        Dim frm As New Main
        frm = Me.ParentForm
        frm.FindChild("frmRelatieSearch")
        Dim ChildForm As frmRelatieSearch = frm.FindChild("frmRelatieSearch")
        If ChildForm Is Nothing Then
            MessageBox.Show("Het zoekscherm is afgesloten en daardoor niet meer aan te spreken", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If ChildForm.dgvLeden.RowCount > 1 Then
                Dim RowCount As Integer = ChildForm.dgvLeden.RowCount - 1
                If ChildForm.dgvLeden.SelectedRows(0).Index > 0 Then
                    ChildForm.dgvLeden.Rows(ChildForm.dgvLeden.SelectedRows(0).Index - 1).Selected = True
                    Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                    ChildForm.OpenFrmLid()
                Else
                    MessageBox.Show("Einde zoekresultaten", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If


        End If
    End Sub

    Private Sub dgvStorno_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvStorno.DoubleClick
        Try
            If dgvStorno.SelectedRows.Count > 0 Then
                Dim TopForm As New dlgStorno(MyRelatie, dgvStorno.SelectedRows(0).Cells("stornoId").Value)
                TopForm.Text = "Stornering aanpassen"
                Dim result As DialogResult = TopForm.ShowDialog()
                If result = Windows.Forms.DialogResult.OK Then
                    GetStorno()
                    FillListViewPaymentsContributies()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbUitvaart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If ActiveControl Is sender Then

        Select Case True
            Case rbBegrafenis.Checked
                grpUitvaartAdres.Visible = True
                MyNazorg.Uitvaart = 1
            Case rbCrematie.Checked
                grpUitvaartAdres.Visible = True
                MyNazorg.Uitvaart = 2
            Case rbNvtUitvaart.Checked
                grpUitvaartAdres.Visible = False
                MyNazorg.Uitvaart = 0
        End Select


        'End If
    End Sub
    Private Sub rbNazorg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Select Case True
            Case rbNazorgJa.Checked
                MyRelatie.Nazorg = 1
            Case rbNazorgNee.Checked
                MyRelatie.Nazorg = 2
            Case Else
                MyRelatie.Nazorg = 0
        End Select

    End Sub

    Private Sub rbBloemen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case True
            Case rbBloemenJa.Checked
                MyNazorg.Bloemen = 1
            Case rbBloemenNee.Checked
                MyNazorg.Bloemen = 2
            Case Else
                MyNazorg.Bloemen = 0
        End Select
    End Sub
    Private Sub rbTrivMelding_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case True
            Case rbTrivMeldingJa.Checked
                MyNazorg.TrivMelding = 1
            Case rbTrivMeldingNee.Checked
                MyNazorg.TrivMelding = 2
            Case Else
                MyNazorg.TrivMelding = 0
        End Select
    End Sub
    Private Sub rbOpgebaard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case True
            Case rbOpgebaardJa.Checked
                MyNazorg.Opgebaard = 1
            Case rbOpgebaardNee.Checked
                MyNazorg.Opgebaard = 2
            Case Else
                MyNazorg.Opgebaard = 0
        End Select
    End Sub
    'Private Sub chkBloemen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBloemen.CheckedChanged
    '    Try

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub btnSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSMS.Click
        Try
            Process.Start(My.Application.Info.DirectoryPath & "\SmsApp.exe", tbMobiel.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Try
            'ofFile.Title = "Selecteer het bestand..."
            If MyRelatie.Id = 0 Then Throw New Exception("Dit is een nieuwe relatie, deze eerst opslaan!")

            Dim dlg As New dlgDocumentUpload(MyRelatie.Id, dlgDocumentUpload.Via.RELATIE, -1)

            If Not My.Settings.ReportsPath = "" Then
                dlg.ofFile.InitialDirectory = My.Settings.ReportsPath
            End If

            Dim result As DialogResult = dlg.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                GetCorrespondentie()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub tscDocs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tscDocs.SelectedIndexChanged
    '    Try
    '        If tscDocs.ComboBox.Focused Then
    '            If tscDocs.ComboBox.SelectedValue > 1 Then
    '                Dim newWord As New OfficeObjects.WordMerge
    '                newWord.CurrentDr = MyRelatie.ExportRow
    '                newWord.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\merge.txt"

    '                Dim dlgSave As New dlgDocSave
    '                Dim result As DialogResult = dlgSave.ShowDialog()
    '                If result = Windows.Forms.DialogResult.Yes Then
    '                    newWord.Merge(tscDocs.ComboBox.SelectedValue, MyRelatie, True)
    '                ElseIf result = Windows.Forms.DialogResult.No Then
    '                    newWord.Merge(tscDocs.ComboBox.SelectedValue, MyRelatie, False)
    '                ElseIf result = Windows.Forms.DialogResult.Cancel Then
    '                    'doe dan nix
    '                End If
    '                newWord = Nothing
    '                GetCorrespondentie()
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub tbInstantiedatum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbInstantiedatum.TextChanged
    '    Try
    '        Dim tb As TextBox = sender
    '        If tb.Text.Length = 2 Or tb.Text.Length = 5 Then
    '            tb.AppendText("-")
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'elfproef aanzetten of nog niet?
    'Private Sub tbBankRek_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBankRek.Validating
    '    Try
    '        If Not tbBankRek.Text = "0" AndAlso Not String.IsNullOrEmpty(tbBankRek.Text) Then
    '            If Elfproef(tbBankRek.Text, eElfCheckType.Account) = False Then
    '                sender.focus()
    '                Throw New Exception("Rekeningnummer voldoet niet aan de elfproef" & vbCrLf & "Controleer opnieuw.")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub tb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyData = Keys.Delete Then
    '            e.Handled = True
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub tb_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyData = Keys.Delete Then
    '            sender.Text = "" 'Format(MinDateValue, "dd-MM-yyyy")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub cmbEindeReden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEindeReden.SelectedIndexChanged
    '    Try
    '        If ActiveControl Is sender Then
    '            If tbEindeDatum.Text = "" Then 'Data.SqlTypes.SqlDateTime.MinValue.ToString Then
    '                MessageBox.Show("geef eerst de opzegdatum op en selecteer dan de reden!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                tbEindeDatum.Focus()
    '                cmbEindeReden.SelectedValue = 0
    '            Else
    '                MyRelatie.eindereden = sender.SelectedValue
    '                ' TODO: of niet? Als lidmaatschap wordt opgezegd een lidsoort ''beeindigt'' maken met opzegdatum als ingangsdatum
    '                'Dim newLidsoort As New LidSoortPeriode
    '                'newLidsoort.lidid = MyRelatie.Id
    '                'newLidsoort.lidsoortid = 10
    '                'newLidsoort.datumin = tbEindeDatum.Text
    '                'newLidsoort.Save()
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub BtnDeleteIBB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteIBB.Click
        Try
            'dgvIBB
            If dgvIBB.SelectedRows.Count = 0 Then
                MessageBox.Show("U heeft nog geen dossier geselecteerd!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dgvIBB.SelectedRows.Count > 1 Then
                MessageBox.Show("U kunt niet meerdere dossiers tegelijk verwijderen!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dgvIBB.SelectedRows.Count = 1 Then
                Dim ibb2delete As IBBDossier
                ibb2delete = New IBBDossier(dgvIBB.SelectedRows(0).Cells("Id").Value, IBBDossier.VIA.ID)
                If Not ibb2delete.Found Then
                    MessageBox.Show("Dossier niet gevonden!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim dlgAsk As New dlgAskIt
                    Dim LastY As Integer = 0
                    Dim iLabelPositionX As Integer = 0
                    Dim mylabel As New Label
                    Dim mylabel2 As New Label

                    dlgAsk.Height = 150
                    dlgAsk.Width = 550
                    dlgAsk.StartPosition = FormStartPosition.CenterScreen
                    Dim myfont As Font = New Font(dlgAsk.Font, FontStyle.Bold)

                    mylabel.Font = myfont
                    mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                    mylabel.Text = "Weet u zeker dat u het dossier " & ibb2delete.DossierNr & "EN alle refererende gegevens wilt verwijderen?"
                    mylabel.AutoSize = True

                    mylabel2.Font = myfont
                    mylabel2.Location = New Point(dlgAsk.Location.X + 20, 50)
                    mylabel2.Text = "Eventuele agenda afspraken worden NIET verwijderd?"
                    mylabel2.AutoSize = True

                    dlgAsk.Controls.Add(mylabel)
                    dlgAsk.Controls.Add(mylabel2)
                    dlgAsk.OK_Button.Text = "Ja"
                    dlgAsk.Cancel_Button.Text = "Nee"

                    dlgAsk.ShowDialog()

                    If dlgAsk.DialogResult <> DialogResult.OK Then
                        Exit Sub
                    Else
                        ibb2delete.Remove()
                        GetIBB()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbIBAN_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tbIBAN.Validating
        Try
            If String.IsNullOrEmpty(tbIBAN.Text) Then Exit Sub

            If tbIBAN.Text.Substring(0, 2) = "NL" Then
                If validate_iban(tbIBAN.Text) = False Then
                    tbIBAN.Focus()
                    Throw New Exception("Controleer het IBAN nummer")
                End If
            End If

        Catch ex As Exception
            tbIBAN.Focus()
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub FillAssurance()
    '    Try

    '        With lvAssurance
    '            .Clear()
    '            .Columns.Add(New ColHeader("Verzekeraar", 100, HorizontalAlignment.Left, True))
    '            .Columns.Add(New ColHeader("Soort", 100, HorizontalAlignment.Left, True))
    '            .Columns.Add(New ColHeader("id", 0, HorizontalAlignment.Left, True))

    '            .View = View.Details
    '            Dim lstViewItem As ListViewItem = New ListViewItem()
    '            For Each verz As Verzekering In MyRelatie.MyVerzekeringen
    '                lstViewItem = New ListViewItem()
    '                lstViewItem.Text = verz.Verzekeraar
    '                lstViewItem.SubItems.Add(verz.Soort)
    '                lstViewItem.SubItems.Add(verz.Id)
    '                .Items.Add(lstViewItem)
    '            Next

    '            lstViewItem = New ListViewItem()
    '            lstViewItem.Text = "nieuw.."
    '            lstViewItem.SubItems.Add("..")
    '            lstViewItem.SubItems.Add("..")
    '            .Items.Add(lstViewItem)

    '            .EnsureVisible(.Items.Count - 1)

    '        End With

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Private Sub lvAssurance_DoubleClick(sender As Object, e As EventArgs) Handles lvAssurance.DoubleClick
    '    Try
    '        If Not lvAssurance.SelectedItems.Count = 0 Then

    '            Dim SelectedItem As Integer = Me.lvAssurance.SelectedItems(0).SubItems(Me.lvAssurance.SelectedItems(0).SubItems.Count - 1).Text
    '            Dim MyAssurance As New Verzekering(SelectedItem, Verzekering.Via.ID)

    '            Dim dlgAsk As New dlgAskIt
    '            Dim LastY As Integer = 0
    '            Dim iLabelPositionX As Integer = 0
    '            Dim mylabel As New Label
    '            Dim mytextbox As New TextBox
    '            Dim mylabel2 As New Label
    '            Dim mytextbox2 As New TextBox
    '            Dim myCheckbox As New CheckBox

    '            dlgAsk.Height = 200
    '            dlgAsk.Width = 350
    '            dlgAsk.StartPosition = FormStartPosition.CenterScreen
    '            Dim myfont As Font = New Font(dlgAsk.Font, FontStyle.Bold)

    '            mylabel.Font = myfont
    '            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
    '            mylabel.Text = "Soort"
    '            mylabel.AutoSize = True

    '            mytextbox.Font = myfont
    '            mytextbox.Location = New Point(dlgAsk.Location.X + 160, 20)
    '            mytextbox.Name = "Soort"
    '            mytextbox.Text = MyAssurance.Soort

    '            mylabel2.Font = myfont
    '            mylabel2.Location = New Point(dlgAsk.Location.X + 20, 50)
    '            mylabel2.Text = "Verzekeraar"
    '            mylabel2.AutoSize = True

    '            mytextbox2.Font = myfont
    '            mytextbox2.Location = New Point(dlgAsk.Location.X + 160, 50)
    '            mytextbox2.Text = MyAssurance.Verzekeraar
    '            mytextbox2.Name = "Verzekeraar"

    '            myCheckbox.Location = New Point(dlgAsk.Location.X + 20, dlgAsk.TableLayoutPanel1.Location.Y + 5)
    '            myCheckbox.Name = "myCheckbox"
    '            myCheckbox.Text = "verwijderen"
    '            myCheckbox.CheckAlign = ContentAlignment.MiddleRight
    '            myCheckbox.AutoSize = True

    '            dlgAsk.Controls.Add(mylabel)
    '            dlgAsk.Controls.Add(mylabel2)
    '            dlgAsk.Controls.Add(mytextbox)
    '            dlgAsk.Controls.Add(mytextbox2)
    '            dlgAsk.Controls.Add(myCheckbox)


    '            dlgAsk.OK_Button.Text = "Opslaan"
    '            dlgAsk.Text = "Verzekering "
    '            dlgAsk.OK_Button.Visible = True

    '            dlgAsk.ShowDialog()

    '            If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then
    '                If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_users") Then
    '                    Dim _chk As New CheckBox
    '                    _chk = dlgAsk.Controls.Item("myCheckbox")
    '                    If _chk.CheckState = CheckState.Checked Then
    '                        MyAssurance.Remove()
    '                    Else
    '                        Dim _tb As New TextBox
    '                        _tb = dlgAsk.Controls.Item("Soort")
    '                        MyAssurance.Soort = _tb.Text
    '                        _tb = dlgAsk.Controls.Item("Verzekeraar")
    '                        MyAssurance.Verzekeraar = _tb.Text
    '                        MyAssurance.Lidid = MyRelatie.Id
    '                        MyAssurance.Save()
    '                    End If
    '                    MyRelatie._MyVerzekeringen = Nothing
    '                    FillAssurance()
    '                Else
    '                    MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End If

    '            End If

    '        End If


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub tsmDelete_Click(sender As Object, e As EventArgs) Handles tsmDelete.Click
        Try
            'Bug:1142 was added - Helpdesk docs verwijderen
            If lvMail.SelectedItems.Count > 1 Then
                Throw New Exception("U kunt 1 document tegelijk verwijderen.")
            ElseIf lvMail.SelectedItems.Count = 1 Then

                If MessageBox.Show("Weet u zeker dat u dit document wilt verwijderen?.", "Verwijderen",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim SelectedDoc As Documents = New Documents(lvMail.SelectedItems(0).Text, Documents.Via.BerichtenId)
                    If SelectedDoc.Found Then SelectedDoc.Remove(True)

                End If
                FillMailList()
            Else
                Throw New Exception("Er is niet geselecteerd.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Const PR_HEADER As String = "http://schemas.microsoft.com/mapi/proptag/0x007D001E"
    Const PR_SENT_REPRESENTING_ENTRYID As String = "http://schemas.microsoft.com/mapi/proptag/0x00410102"

    Private Sub lvMail_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvMail.DragDrop
        Try
            If MyRelatie.Id < 1 Then Throw New Exception("Relatie moet eerst worden opgeslagen!")

            Dim results As String = String.Empty
            If e.Data.GetDataPresent("FileGroupDescriptor") Then
                If e.Data.GetFormats(False)(1) = "FileGroupDescriptor" Then
                    Dim FilePath As String = GetOutlookAttachment(e, "FileGroupDescriptor")
                    Dim file As IO.FileInfo
                    file = New FileInfo(FilePath)
                    Dim dlgDocument As New dlgDocumentUpload(MyRelatie.Id, dlgDocumentUpload.Via.RELATIE)
                    dlgDocument.tbSelectedFile.Text = FilePath
                    dlgDocument.tbOnderwerp.Text = file.Name.Replace(file.Extension, "")
                    dlgDocument.ProcessRelatie()

                    results &= "- " & file.Name & ", " & vbCrLf
                Else
                    Dim OL As Microsoft.Office.Interop.Outlook.Application = New Microsoft.Office.Interop.Outlook.Application
                    Dim olItem As Microsoft.Office.Interop.Outlook.MailItem

                    Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("FileSave", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                    If Not DocumentPathSetting.Found Then Throw New Exception("Geen Systeeminstellingen voor FileSave gevonden!")
                    Dim DocumentPath As String = DocumentPathSetting.Waarde & "\"
                    Dim FullDocumentPath As String = DocumentPath & MyRelatie.Id & "\email"

                    If Not Directory.Exists(FullDocumentPath) Then
                        Directory.CreateDirectory(FullDocumentPath)
                    End If

                    For Each olItem In OL.ActiveExplorer.Selection
                        If String.IsNullOrEmpty(olItem.Subject) Then Throw New Exception("Bericht zonder onderwerp kan niet worden verwerkt!")

                        Dim sFileName As String = System.Text.RegularExpressions.Regex.Replace(olItem.Subject.Trim, "[\/\\\:\?\*\<\>\|""""]", "") & ".msg"
                        'hyphen\dash van apple wordt niet goed verwerkt.
                        'sFileName = System.Text.RegularExpressions.Regex.Replace(sFileName.Trim, "-", "_") & ".msg"

                        Dim NewDocument As New Documents
                        With NewDocument
                            .LidId = MyRelatie.Id

                            Dim subject As String = olItem.Subject.Trim
                            If subject.Length >= 100 Then subject = olItem.Subject.Trim.Substring(0, 99)
                            ' .Onderwerp = subject
                            .Template = "msg"
                            .Bericht.RelatieId = MyRelatie.Id
                            .Bericht.ReceivedDate = olItem.ReceivedTime
                            .Bericht.Subject = subject

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

                            sFileName = sFileName.Insert(sFileName.ToLower.LastIndexOf(".msg"), "-" & .Bericht.Id)
                            olItem.SaveAs(FullDocumentPath & "\" & sFileName, Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG)

                            .Location = FullDocumentPath & "\" & sFileName
                            .BerichtenId = .Bericht.Id
                            .Save()

                            System.IO.File.SetAttributes(FullDocumentPath & "\" & sFileName, FileAttributes.ReadOnly)
                        End With

                        results &= "- " & olItem.Subject.Replace(":", "") & ", " & vbCrLf

                        OL.ActiveExplorer.RemoveFromSelection(olItem)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(olItem)
                        olItem = Nothing

                    Next

                    OL = Nothing

                    'Outlook2010Workaround()

                End If

            ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
                MessageBox.Show("Alleen emailberichten zijn toegestaan.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            FillMailList()


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            FillMailList()
        End Try

    End Sub
    Private Sub lvMail_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lvMail.DragEnter

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
    Private Sub tsbXML_Click(sender As Object, e As EventArgs) Handles tsbXML.Click
        Try

            If Not URights.IsMemberOfOne(AllowBtnRelatieExport) Then Throw New Exception("U heeft niet voldoende rechten voor deze opdracht!")

            Cursor.Current = Cursors.WaitCursor

            'Maak map met lidnummer
            Dim mySaveFullPath As String = MyDocuments & "\" & MyRelatie.lidnr
            If Not Directory.Exists(mySaveFullPath) Then
                Directory.CreateDirectory(mySaveFullPath)
            Else Throw New Exception("De map " & MyDocuments & "\" & MyRelatie.lidnr & " bestaat al. Verwijderd deze eerst.")
            End If


            Dim dr As DataRow = MyRelatie.ExportRow
            Dim writer As New XmlTextWriter(mySaveFullPath & "\RelatieData.xml", System.Text.Encoding.UTF8)
            Dim Myfile As IO.FileInfo


            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2

            writer.WriteStartElement("RELDATA")
            writer.WriteStartElement("Relatie")
            dr.Table.TableName = "Relatie"
            'maak een overzicht van beschikbare data uit de relatietabel, alleen als er een waarde in het veld staat wordt het veld getoond
            createNode(dr, writer)
            writer.WriteEndElement()

            'Als er documenten zijn maak er een overzicht van.
            'en kopie het document naar de map
            If MyRelatie.CorrespondentieList.Count > 0 Then
                writer.WriteStartElement("Correspondentie")
                For Each doc In MyRelatie.CorrespondentieList
                    ' writer.WriteStartElement(doc.id)
                    Try

                        Myfile = New FileInfo(doc.Location)
                        Myfile.CopyTo(mySaveFullPath & "\" & doc.DocumentName)
                        'alleen maar schrijven als het ook gevonden kan worden.
                        'als het niet gevonden wordt komt het hier niet maar naar exception
                        writer.WriteStartElement("Document")
                        writer.WriteString(doc.DocumentName)
                        writer.WriteEndElement()
                    Catch ex As Exception

                    End Try
                Next
                writer.WriteEndElement()
            End If

            'Als er ibb dossiers zijn maak er een overzicht van.
            If MyRelatie.MyIBBdossiers.Count > 0 Then
                writer.WriteStartElement("Dossiers")
                For Each ibb In MyRelatie.MyIBBdossiers
                    writer.WriteStartElement("Dossiernummer")
                    writer.WriteString(ibb.DossierNr)
                    writer.WriteEndElement()
                    'Als er ibb documenten zijn maak er een overzicht van.
                    If ibb.ListDocuments.Count > 0 Then
                        writer.WriteStartElement("Correspondentie")
                        For Each ibbdoc In ibb.ListDocuments
                            Try
                                Myfile = New FileInfo(ibbdoc.Location)
                                Myfile.CopyTo(mySaveFullPath & "\" & ibbdoc.DocumentName)
                                'alleen maar schrijven als het ook gevonden kan worden.
                                writer.WriteStartElement("Document")
                                writer.WriteString(ibbdoc.DocumentName)
                                writer.WriteEndElement()
                            Catch ex As Exception

                            End Try
                        Next

                        'Als er ibb berichten staan in de mailbox maak er een overzicht van.
                        For Each ibbdoc In ibb.ListEmails
                            Try
                                Dim EmailId As String = ibbdoc.EmailId
                                Dim mimeContent As Byte() = ews.GetMimeContent(EmailId)
                                Dim emlFileName As String = mySaveFullPath & "\" & Replace(Guid.NewGuid.ToString, "-", "") & ".eml"

                                Using fs As New IO.FileStream(emlFileName, FileMode.Create, FileAccess.Write)
                                    fs.Write(mimeContent, 0, mimeContent.Length)
                                End Using
                                'alleen maar schrijven als het ook gevonden kan worden.
                                writer.WriteStartElement("email")
                                writer.WriteString(ibbdoc.Onderwerp)
                                writer.WriteEndElement()
                            Catch ex As Exception

                            End Try
                        Next
                        writer.WriteEndElement()
                    End If

                Next
                writer.WriteEndElement()
            End If

            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()

            Cursor.Current = Cursors.Default
            MessageBox.Show("De gegevens zijn opgeslagen in de map " & mySaveFullPath, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub createNode(dr As DataRow, ByVal writer As XmlTextWriter)

        For Each col As DataColumn In dr.Table.Columns
            If String.IsNullOrEmpty(dr.Item(col).ToString) Then Continue For
            writer.WriteStartElement(col.ColumnName)
            writer.WriteString(dr.Item(col).ToString)
            writer.WriteEndElement()
        Next

    End Sub

    Private Sub OnderwerpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnderwerpToolStripMenuItem.Click
        Try

            If lvMail.SelectedItems.Count = 1 Then
                Dim doc As Berichten = New Berichten(lvMail.SelectedItems(0).SubItems(0).Text)
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
                    tb1.Text = doc.Subject
                    tb1.Size = New Size(dlgAsk.Size.Width - 50, 35)
                    dlgAsk.Controls.Add(tb1)
                    LastY = tb1.Location.Y
                    iLabelPositionX = tb1.Location.X + 20

                    dlgAsk.ShowDialog()
                    If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then
                        'doc.CreateDate = tbDate.Text
                        doc.Subject = tb1.Text
                        doc.Save()
                        FillMailList()
                    End If
                End If

            Else
                Throw New Exception("U kunt 1 document tegelijk bewerken.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbPostCode_TextChanged(sender As Object, e As EventArgs) Handles tbPostCode.TextChanged

    End Sub

    Private Sub utdRijbewijskeuring75_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub utdSLContract_Load(sender As Object, e As EventArgs)

    End Sub
End Class
