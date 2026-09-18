Imports BusinessObjects
Imports OfficeObjects
Imports System.Text

Public Class frmMailing
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess
    Private dt As New DataTable
    Private myTemplates As DataTable = New DataTable

#Region "Thread Brieven"

    Private WithEvents _thMailing As MailingThread
    Private Status As String = ""
    Dim ExpMessage As String = String.Empty
    Private ready As Boolean = False
    Private ExpHandler As Boolean = False
    Private m_PercentDone As Integer = 0
    Private Counter As Integer = 0


    Public Sub percent(ByVal value As Integer)
        Me.ProgressBar.Value = value
    End Sub
    Public Sub IndexCompleteHandler(ByVal _Counter As Integer) Handles _thMailing.GenerateComplete
        ready = True
    End Sub
    Public Sub IndexExpHandler(ByVal exp As Exception) Handles _thMailing.GenerateExp
        ready = True
        ExpHandler = True
        ExpMessage = "ERROR:" & exp.Message
        ' MessageBox.Show(exp.Message, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Public Sub IndexStatusHandler(ByVal _message As String) Handles _thMailing.GenerateStatus
        Status = _message
    End Sub
    Public Sub IndexCounter(ByVal _Counter As Integer) Handles _thMailing.GenerateCounter
        Counter = _Counter
    End Sub

#End Region
#Region "Thread Email"

    Private WithEvents _thEMailing As EwsMailer
    Private Status_email As String = ""
    Dim ExpMessage_email As String = String.Empty
    Private ready_email As Boolean = False
    Private ExpHandler_email As Boolean = False
    Private m_PercentDone_email As Integer = 0
    Private Counter_email As Integer = 0

    Public Sub percent_email(ByVal value As Integer)
        Me.ProgressBar.Value = value
    End Sub
    Public Sub IndexCompleteHandler_email(ByVal _Counter As Integer) Handles _thEMailing.GenerateComplete
        ready_email = True
    End Sub
    Public Sub IndexExpHandler_email(ByVal exp As Exception) Handles _thEMailing.GenerateExp
        ready_email = True
        ExpHandler_email = True
        ExpMessage_email = "ERROR:" & exp.Message

    End Sub
    Public Sub IndexStatusHandler_email(ByVal _message As String) Handles _thEMailing.GenerateStatus
        Status_email = _message
    End Sub
    Public Sub IndexCounter_email(ByVal _Counter As Integer) Handles _thEMailing.GenerateCounter
        Counter_email = _Counter
    End Sub

#End Region

    Private Sub frmMailing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If URights.IsInGroup("rel_admins") Then
                'ga dan door
                btnSql.Visible = True
            ElseIf URights.IsInGroup("rel_users") Then
                'ga dan door
            ElseIf URights.IsInGroup("rel_readers_mailing") Then
                'ga dan door
            ElseIf URights.IsInGroup("rel_functies") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If CreateDefaultLabels Then CreateLabelXml(Me, Me.Name, True)
            If CreateDefaultLabels Then CreateLabelXml(dgvLeden, Me.Name, False)

            GetLabelText(Me, Me.Name)
            GetHeaderText(dgvLeden, Me.Name)

            dgvLeden.AutoGenerateColumns = False
            FillCombo()

            CurrentTimer.Start()
            ProgressBar.Minimum = 0
            ProgressBar.Value = ProgressBar.Minimum
            ProgressBar.Visible = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub CurrentTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrentTimer.Tick
        'UpdateCurrentTime()
    End Sub
    Private Sub FillCombo()
        Try

            Dim Bonden As DataTable = da.ExecuteDataTable("SELECT * FROM Bonden ORDER BY Omschrijving")
            Dim kmonderdelen As DataTable = da.ExecuteDataTable("SELECT * FROM kmonderdelen ORDER BY kmonderdeel")
            Dim Rangen As DataTable = da.ExecuteDataTable("SELECT * FROM Rangen ORDER BY Id")
            'Dim Templates As DataTable = da.ExecuteDataTable("SELECT * FROM Templates WHERE (Bond = 0 OR BOND = 1) ORDER BY Naam")
            myTemplates = da.ExecuteDataTable("SELECT * FROM Templates WHERE (Bond = 0 OR BOND = 1) ORDER BY afdeling, omschrijving")

            Dim dr As DataRow
            dr = Bonden.NewRow
            dr("id") = 0
            dr("Omschrijving") = "Selecteer een Bond."
            Bonden.Rows.Add(dr)
            cmbBond.DataSource = Bonden
            cmbBond.DisplayMember = "Omschrijving"
            cmbBond.ValueMember = "id"
            cmbBond.SelectedValue = 0

            cmbKMonderdeel.DataSource = kmonderdelen
            cmbKMonderdeel.DisplayMember = "kmonderdeel"
            cmbKMonderdeel.ValueMember = "id"
            cmbKMonderdeel.SelectedValue = 0

            cmbRang.DataSource = Rangen
            cmbRang.DisplayMember = "Rang"
            cmbRang.ValueMember = "id"
            cmbRang.SelectedValue = 0

            'cmbBriefSoort.DataSource = Templates
            'cmbBriefSoort.DisplayMember = "omschrijving"
            'cmbBriefSoort.ValueMember = "id"

            Dim FunctieTable As DataTable = da.ExecuteDataTable("SELECT * FROM fsoort ORDER BY Omschrijving")
            cmbFuncties.DataSource = FunctieTable
            cmbFuncties.DisplayMember = "Soort"
            cmbFuncties.ValueMember = "id"
            cmbFuncties.SelectedValue = 0

            Dim AdviesTable As DataTable = da.ExecuteDataTable("SELECT * FROM fadvies ORDER BY Naam")
            cmbAdvies.DataSource = AdviesTable
            cmbAdvies.DisplayMember = "Naam"
            cmbAdvies.ValueMember = "id"
            cmbAdvies.SelectedValue = 0


            'cmbOrgaan            
            Dim OrgaanTable As DataTable = da.ExecuteDataTable("SELECT * FROM fOrgaan ORDER BY orgaan")
            cmbOrgaan.DataSource = OrgaanTable
            cmbOrgaan.DisplayMember = "orgaan"
            cmbOrgaan.ValueMember = "id"
            cmbOrgaan.SelectedValue = 0

            Dim AfdelingenTable As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch FROM Afdelingen ORDER BY Omschrijving")
            cmbAfdeling.DataSource = AfdelingenTable
            cmbAfdeling.DisplayMember = "id_omsch"
            cmbAfdeling.ValueMember = "id"
            cmbAfdeling.SelectedValue = 0

            Dim LidAfdelingenTable As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch FROM Afdelingen ORDER BY Omschrijving")
            cmbLidAfdeling.DataSource = LidAfdelingenTable
            cmbLidAfdeling.DisplayMember = "id_omsch"
            cmbLidAfdeling.ValueMember = "id"
            cmbLidAfdeling.SelectedValue = 0


            Dim PlaatsingTable As DataTable = da.ExecuteDataTable("SELECT p_id,plaatsing, left(CAST(code as varchar) + SPACE(5),5) + ' | ' + Plaatsing as code_plaatsing  FROM Plaatsingen ORDER BY Plaatsing")
            cmbPlaatsing.DataSource = PlaatsingTable
            cmbPlaatsing.DisplayMember = "code_Plaatsing"
            cmbPlaatsing.ValueMember = "p_id"
            cmbPlaatsing.SelectedValue = 0


            Dim AllowIBBGroups() As Object = {"rel_ibb_users", "rel_admins", "rel_ibb_admins"}

            If URights.IsMemberOfOne(AllowIBBGroups) Then
                Dim tblIbbGroepen As DataTable = da.ExecuteDataTable("SELECT * FROM IBBGroepen ORDER BY Groep")
                cmbIBBGroep.DataSource = tblIbbGroepen
                cmbIBBGroep.DisplayMember = "Groep"
                cmbIBBGroep.ValueMember = "id"
                cmbIBBGroep.SelectedValue = 0
            End If


            Dim mnu As New ToolStripMenuItem
            Dim mnu1 As New ToolStripMenuItem
            mnu.Text = "Brieven"
            Dim tmpGroup As String = "Brieven"
            For Each rw As DataRow In myTemplates.Rows
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
            FilltvBrieven()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
 
    Private Sub FilltvBrieven()
        Try
            Dim tmpGroup As String = "Brieven"
            Dim cnode As TreeNode
            Dim inode As Integer = -1

            For Each rw As DataRow In myTemplates.Rows
                Dim CatchEmpty As String = rw.Item("Afdeling")
                If String.IsNullOrEmpty(CatchEmpty) Then CatchEmpty = "standaard"
                If tmpGroup <> CatchEmpty Then
                    tvBrieven.Nodes.Add(CatchEmpty)
                    If inode < 0 Then
                        inode = 0
                    Else
                        inode += 1
                    End If

                End If
                cnode = tvBrieven.Nodes(inode)
                cnode.Nodes.Add(rw.Item("id"), rw.Item("omschrijving"))
                tmpGroup = CatchEmpty
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub tvBrieven_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvBrieven.DoubleClick
        Dim N As TreeNode = CType(sender, Windows.Forms.TreeView).SelectedNode
        Try
            If Not N Is Nothing Then
                Dim Soort As String = String.Empty
                If Not N.Parent Is Nothing Then Soort = N.Parent.Text
                Dim i As Integer = 0
                If Integer.TryParse(N.Name, i) Then
                    If Soort.ToLower = "email" Then
                        'Emailing(N.Name)
                        Email_Post_Mailing(N.Name)
                    ElseIf Soort.ToLower = "emailpost" Then
                        Email_Post_Mailing(N.Name)
                    Else
                        Merge(N.Name)
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private _ews As EwsMailer
    Public Property ews() As EwsMailer
        Get
            If _ews Is Nothing Then
                _ews = New EwsMailer(False)
            End If
            Return _ews
        End Get
        Set(ByVal value As EwsMailer)
            _ews = value
        End Set
    End Property

    'Private Sub Emailing(ByVal TemplateId As Integer)
    '    Try
    '        'maak selectie
    '        'haal de template '(incl) pad op
    '        'geef selectie door aan mailer
    '        'geef template door aan mailer
    '        'mailer maakt standaard body en de img lijst
    '        'mailer start process
    '        'mailer process loopt en controlleert emailadres
    '        'mailers  stuurt mail


    '        Dim MyTemplate As New BusinessObjects.tblTemplates(TemplateId)
    '        '  Dim Body As String = ews.BodyTemplate(MyTemplate.locatie & MyTemplate.Naam)
    '        Dim LidBody As String = String.Empty

    '        If dgvLeden.Rows.Count > 0 Then

    '            Me.Cursor = Cursors.WaitCursor
    '            Me.btnSearch.Enabled = False
    '            Me.btnReset.Text = "Annuleren"
    '            btnReset.DialogResult = Windows.Forms.DialogResult.Cancel

    '            Status_email = ""
    '            ready_email = False
    '            ExpHandler_email = False
    '            Counter_email = 0
    '            _thEMailing = New EwsMailer

    '            Dim TotalLineCount As Integer = dgvLeden.Rows.Count
    '            Dim thEMailing As New System.Threading.Thread(AddressOf _thEMailing.Process)

    '            Dim selectedRowCount As Integer = dgvLeden.Rows.GetRowCount(DataGridViewElementStates.Selected)
    '            Dim dtMailing As New DataTable
    '            dtMailing = dgvLeden.DataSource.Copy


    '            If selectedRowCount > 1 Then
    '                dtMailing.Rows.Clear()
    '                For Each dataGridViewRow As DataGridViewRow In dgvLeden.SelectedRows
    '                    Dim dataRowView As DataRowView = DirectCast(dataGridViewRow.DataBoundItem, DataRowView)
    '                    dtMailing.ImportRow(dataRowView.Row)
    '                Next
    '            End If

    '            ' ''*** test mailmerger + att + mail of post) ***
    '            'dtMailing.Columns.Add("Attfile", Type.GetType("System.String"))
    '            'For Each dr As DataRow In dtMailing.Rows
    '            '    Dim AttFileName As String = String.Empty
    '            '    Dim oWord As New OfficeObjects.WordMerge
    '            '    dr("Attfile") = oWord.MergeSingle(4, dr)
    '            'Next
    '            ' ''*** ENIDE test mailmerger + att + mail of post) ***

    '            Dim MasterFile As String = String.Empty
    '            Dim TemplatePath As String = String.Empty

    '            TemplatePath = MyTemplate.DefaultLocation & MyTemplate.Afdeling
    '            MasterFile = TemplatePath & MyTemplate.Naam

    '            '[ _thEMailing.SetBodyTemplate(MyTemplate.locatie & MyTemplate.Naam)
    '            _thEMailing.SetBodyTemplate(MasterFile)
    '            _thEMailing.MailingTable = dtMailing
    '            ' _thEMailing.TemplateId = id
    '            thEMailing.Start()

    '            Me.ProgressBar.Maximum = TotalLineCount + 1
    '            Application.DoEvents()
    '            While ready_email = False

    '                Me.Text = "Bezig met verwerken van Mailing "
    '                'Me.Refresh()
    '                Me.percent_email(Counter_email)
    '                Me.lblStatus.Text = Status_email
    '                If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
    '                    _thEMailing.IsTerminating = True
    '                    _thEMailing.bAbort = True
    '                    thEMailing.Join()
    '                    Me.Cursor = Cursors.Default
    '                    ProgressBar.Value = ProgressBar.Minimum
    '                    Exit While
    '                End If
    '                My.Application.DoEvents()
    '            End While

    '        End If


    '        If ready_email And ExpHandler_email = False Then
    '            MessageBox.Show("Klaar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            ProgressBar.Value = ProgressBar.Maximum
    '            Me.lblStatus.Text = Status_email
    '        ElseIf ready_email And ExpHandler_email = True Then
    '            MessageBox.Show(ExpMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            ProgressBar.Value = ProgressBar.Maximum
    '            Me.lblStatus.Text = Status_email
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        Me.Cursor = Cursors.Default
    '        'Me.btnProcess.Enabled = True
    '        Me.btnSearch.Enabled = True
    '        Me.btnReset.Enabled = True
    '        Me.btnReset.Text = "Reset"
    '        btnReset.DialogResult = Windows.Forms.DialogResult.None
    '    End Try


    'End Sub
    Private Sub Merge(ByVal id As Integer)
        Try

            If id < 1 Then
                Throw New Exception("Er is nog geen sjabloon geselecteerd!")
            End If

            If dgvLeden.Rows.Count > 0 Then

                Me.Cursor = Cursors.WaitCursor
                Me.btnSearch.Enabled = False
                Me.btnReset.Text = "Annuleren"
                btnReset.DialogResult = Windows.Forms.DialogResult.Cancel

                Status = ""
                ready = False
                ExpHandler = False
                Counter = 0
                Dim TotalLineCount As Integer = dgvLeden.Rows.Count
                _thMailing = New MailingThread

                Dim thMailing As New System.Threading.Thread(AddressOf _thMailing.Process)

                Dim selectedRowCount As Integer = dgvLeden.Rows.GetRowCount(DataGridViewElementStates.Selected)
                Dim dtMailing As New DataTable
                dtMailing = dgvLeden.DataSource.Copy

                If selectedRowCount > 1 Then
                    dtMailing.Rows.Clear()
                    For Each dataGridViewRow As DataGridViewRow In dgvLeden.SelectedRows
                        Dim dataRowView As DataRowView = DirectCast(dataGridViewRow.DataBoundItem, DataRowView)
                        dtMailing.ImportRow(dataRowView.Row)
                    Next
                End If

                _thMailing.MailingTable = dtMailing
                _thMailing.TemplateId = id
                _thMailing.bWrite2Correspondetie = chkWriteCorrespondetie.Checked
                thMailing.Start()

                Me.ProgressBar.Maximum = TotalLineCount + 1
                Application.DoEvents()
                While ready = False

                    Me.Text = "Bezig met verwerken van Mailing "
                    'Me.Refresh()
                    Me.percent(Counter)
                    Me.lblStatus.Text = Status
                    If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
                        _thMailing.IsTerminating = True
                        _thMailing.bAbort = True
                        thMailing.Join()
                        Me.Cursor = Cursors.Default
                        ProgressBar.Value = ProgressBar.Minimum
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                'Me.lblStatus.Text = Status

                'If ExpHandler = True Then
                '    thMailing.Abort()
                'End If

                If ready And ExpHandler = False Then
                    MessageBox.Show("Klaar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ProgressBar.Value = ProgressBar.Maximum
                    Me.lblStatus.Text = Status
                ElseIf ready And ExpHandler = True Then
                    MessageBox.Show(ExpMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ProgressBar.Value = ProgressBar.Maximum
                    Me.lblStatus.Text = Status
                End If
            Else
                MessageBox.Show("Er is nog geen selectie gemaakt.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            'Me.btnProcess.Enabled = True
            Me.btnSearch.Enabled = True
            Me.btnReset.Enabled = True
            Me.btnReset.Text = "Reset"
            btnReset.DialogResult = Windows.Forms.DialogResult.None
        End Try
    End Sub
    Private Sub Email_Post_Mailing(ByVal TemplateId As Integer)
        Try
            ' If dgvLeden.Rows.Count > 0 Then
            If Not dgvLeden.DataSource Is Nothing Then

                Dim frmEmail As New frmEmailing
                frmEmail.MailingTable = dgvLeden.DataSource.Copy
                frmEmail.myMailTemplateId = TemplateId
                frmEmail.StartPosition = FormStartPosition.CenterScreen
                frmEmail.bWrite2Correspondetie = chkWriteCorrespondetie.Checked
                frmEmail.ShowDialog()
            Else
                Throw New Exception("U heeft nog geen selectie klaar staan.")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub CreateDoc(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs)
        Try
            Dim _afdeling As String = DirectCast(sender, System.Windows.Forms.ToolStripMenuItem).Text
            Dim _sjabloon As String = e.ClickedItem.ToString
            Dim _Id As Integer = FindTemplate(_sjabloon, _afdeling)

            If _Id > 0 Then
                Merge(_Id)
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

    Private Sub btnResetSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetSearch.Click
        Try
            If Not DialogResult = Windows.Forms.DialogResult.Cancel Then
                Reset(False)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Reset(Optional ByVal bClearAll As Boolean = True)
        Try
            Dim bAddCechboxValue As Boolean = Me.chkAddSearch.Checked

            For Each ctrl In Me.Controls
                If TypeOf (ctrl) Is TextBox Then
                    Dim textbox As TextBox = ctrl
                    textbox.Text = ""
                ElseIf TypeOf (ctrl) Is DateTimePicker Then
                    Dim DateTimePicker As DateTimePicker = ctrl
                    DateTimePicker.Value = "1-1-1900"
                ElseIf TypeOf (ctrl) Is ComboBox Then
                    Dim ComboBox As ComboBox = ctrl
                    ComboBox.SelectedIndex = 0
                ElseIf TypeOf (ctrl) Is CheckBox Then
                    Dim CheckBox As CheckBox = ctrl
                    CheckBox.Checked = False
                End If

                If TypeOf (ctrl) Is GroupBox Then
                    Dim groupbox As GroupBox = ctrl
                    For Each ctrl1 In groupbox.Controls
                        If TypeOf (ctrl1) Is TextBox Then
                            Dim textbox As TextBox = ctrl1
                            textbox.Text = ""
                        ElseIf TypeOf (ctrl1) Is DateTimePicker Then
                            Dim DateTimePicker As DateTimePicker = ctrl1
                            DateTimePicker.Value = "1-1-1900"
                        ElseIf TypeOf (ctrl1) Is ComboBox Then
                            Dim ComboBox As ComboBox = ctrl1
                            ComboBox.SelectedValue = 0
                        ElseIf TypeOf (ctrl1) Is CheckBox Then
                            Dim CheckBox As CheckBox = ctrl1
                            CheckBox.Checked = False
                        End If
                    Next
                End If
            Next
            utdFloPen.tb.Text = ""
            utdFloPen.Value = ""
            utdFunctie.tb.Text = ""
            utdFunctie.Value = ""

            chkAddSearch.Checked = bAddCechboxValue

            If bClearAll Then
                dt.Clear()
                dgvLeden.DataSource = Nothing
                lblAantal.Text = 0
                ProgressBar.Value = ProgressBar.Minimum
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'bugid 441: Omte voorkomen dat een zelfde relatie meerdere keren voorkomt omdat die voldoet aan meerdere voorwaardes
            'is de DISTINCT aan de query toegevoegd.
            'Dim sql As String = "SELECT DISTINCT rel.* ,afd.omschrijving as afdelingnaam " & _
            '                    "FROM relaties rel " & _
            '                    "LEFT JOIN afdelingen afd ON rel.afdeling = afd.id WHERE "

            Dim sql As String = "SELECT DISTINCT rel.* ,afd.omschrijving as afdelingnaam " & _
                    "FROM relaties rel " & _
                    "LEFT JOIN afdelingen afd ON rel.afdeling = afd.id " & _
                    "LEFT JOIN IBBDossiers ibb ON rel.Id = ibb.LidId " & _
                    "WHERE "


            Dim bFuncties As Boolean = False
            Dim sqlcbx As String = ""
            Dim paramlist As New ArrayList
            Dim sAndOr As String = ""
            Dim sAndOrc As String = ""
            ' Dim sbCriteria As StringBuilder = New StringBuilder
            'sbCriteria.Append("gezocht op:")

            If cmbBond.SelectedValue > 0 Then
                sql &= sAndOr & "bond = @bond "
                paramlist.Add("@bond")
                paramlist.Add(cmbBond.SelectedValue)
                sAndOr = "AND "
                'sbCriteria.AppendLine("bond:" & cmbBond.SelectedText)
            End If

            If cmbKMonderdeel.SelectedValue > 0 Then
                sql &= sAndOr & "kmond = @kmond "
                paramlist.Add("@kmond")
                paramlist.Add(cmbKMonderdeel.SelectedValue)
                sAndOr = "AND "
            End If

            If cmbRang.SelectedValue > 0 Then
                sql &= sAndOr & "rang = @rang "
                paramlist.Add("@rang")
                paramlist.Add(cmbRang.SelectedValue)
                sAndOr = "AND "
            End If

            If cmbPlaatsing.SelectedValue > 0 Then
                sql &= sAndOr & "Plaatsing = @Plaatsing "
                paramlist.Add("@Plaatsing")
                paramlist.Add(cmbPlaatsing.SelectedValue)
                sAndOr = "AND "
            End If


            If cmbLidAfdeling.SelectedValue > 0 Then
                sql &= sAndOr & "rel.afdeling = @LidAfdeling "
                paramlist.Add("@LidAfdeling")
                paramlist.Add(cmbLidAfdeling.SelectedValue)
                sAndOr = "AND "
            End If

            If chkALV.Checked Then
                sqlcbx &= sAndOrc & "alv = @alv "
                paramlist.Add("@alv")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            If chkKerstkaart.Checked Then
                sqlcbx &= sAndOrc & "Kerstkaart = @Kerstkaart "
                paramlist.Add("@Kerstkaart")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            If chkLid_natres.Checked Then
                sqlcbx &= sAndOrc & "Lid_natres = @Lid_natres "
                paramlist.Add("@Lid_natres")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            If chkNato.Checked Then
                sqlcbx &= sAndOrc & "nato = @nato "
                paramlist.Add("@nato")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            If chkDienjaar.Checked Then
                sqlcbx &= sAndOrc & "Dienjaar = @Dienjaar"
                paramlist.Add("@Dienjaar")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            If chkVeteraan.Checked Then
                sqlcbx &= sAndOrc & "Veteraan = @Veteraan "
                paramlist.Add("@Veteraan")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            If chkBOM.Checked Then
                sqlcbx &= sAndOrc & "BOM = @BOM "
                paramlist.Add("@BOM")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            'If chkErelid.Checked Then
            '    sqlcbx &= sAndOrc & "erelid IS NOT NULL "
            '    sAndOrc = "OR "
            'End If

            'If chkLidVerdienste.Checked Then
            '    sqlcbx &= sAndOrc & "lid_verdienste IS NOT NULL "
            '    sAndOrc = "OR "
            'End If

            If chkZilver.Checked Then
                If Not String.IsNullOrEmpty(utdFloPen.Value) Then
                    sql &= sAndOr & "ZILVER >= @flo_pen "
                    sAndOr = "OR "
                Else
                    sqlcbx &= sAndOrc & "zilver IS NOT NULL "
                    sAndOrc = "OR "
                End If
            End If

            If chkGoud.Checked Then
                If Not String.IsNullOrEmpty(utdFloPen.Value) Then
                    sql &= sAndOr & "GOUD >= @flo_pen "
                    sAndOr = "OR "
                Else
                    sqlcbx &= sAndOrc & "goud IS NOT NULL "
                    sAndOrc = "AND "
                End If
            End If

            If Not String.IsNullOrEmpty(utdFloPen.Value) Then
                If Not chkGoud.Checked And Not chkZilver.Checked Then
                    sql &= sAndOr & "flo_pen >= @flo_pen "
                End If
                paramlist.Add("@flo_pen")
                paramlist.Add(CDate(utdFloPen.Value))
                sAndOr = "AND "
            End If


                If cmbFuncties.SelectedValue > 0 Then
                bFuncties = True
                'sql &= sAndOr & "functies.functie = @functie AND (functies.datumuit >= @FunctieDatUit OR functies.datumuit IS NULL ) "
                sql &= sAndOr & "functies.functie = @functie "
                paramlist.Add("@functie")
                paramlist.Add(cmbFuncties.SelectedValue)
                'paramlist.Add("@FunctieDatUit")
                'paramlist.Add(Today)
                 sAndOr = "AND "
            End If

            If cmbAdvies.SelectedValue > 0 Then
                bFuncties = True
                sql &= sAndOr & "functies.Adviesgroep = @Advies "
                paramlist.Add("@Advies")
                paramlist.Add(cmbAdvies.SelectedValue)
                sAndOr = "AND "
            End If

            If cmbOrgaan.SelectedValue > 0 Then
                bFuncties = True
                sql &= sAndOr & "functies.Orgaan = @Orgaan "
                paramlist.Add("@Orgaan")
                paramlist.Add(cmbOrgaan.SelectedValue)
                sAndOr = "AND "
            End If

            If cmbAfdeling.SelectedValue > 0 Then
                bFuncties = True
                sql &= sAndOr & "functies.Afdeling = @Afdeling "
                paramlist.Add("@Afdeling")
                paramlist.Add(cmbAfdeling.SelectedValue)
                sAndOr = "AND "
            End If

            If cmbIBBGroep.SelectedValue > 0 Then
                sql &= sAndOr & "ibb.IBBGroep = @IBBGroep "
                paramlist.Add("@IBBGroep")
                paramlist.Add(cmbIBBGroep.SelectedValue)
                sAndOr = "AND "
            End If

            If Not String.IsNullOrEmpty(utdFunctie.Value) Then
                If Not bFuncties = True Then
                    Throw New Exception("U heeft nog geen functie criteria opgegeven")
                End If
                sql &= sAndOr & "functies.datumin >= @datumin "
                paramlist.Add("@datumin")
                paramlist.Add(CDate(utdFunctie.Value))
                sAndOr = "AND "
            End If

            If chkM_NSK.Checked Then
                sqlcbx &= sAndOrc & "m_nsk = @m_nsk "
                paramlist.Add("@m_nsk")
                paramlist.Add(1)
                sAndOrc = "OR "
            End If

            If Not String.IsNullOrEmpty(sqlcbx) Then
                sqlcbx = sAndOr & " (" & sqlcbx & ") "
                sql = sql & sqlcbx
            End If

            If bFuncties = True Then
                sql &= "AND (functies.datumuit >= @FunctieDatUit OR functies.datumuit IS NULL )"
                paramlist.Add("@FunctieDatUit")
                paramlist.Add(Today)
                sql = sql.Replace("FROM relaties rel ", "FROM relaties rel LEFT JOIN Functies on Rel.Id = functies.lidid ")
            End If

                If String.IsNullOrEmpty(sAndOr) And String.IsNullOrEmpty(sqlcbx) Then
                    Throw New Exception("U heeft nog geen selectie criteria opgegeven")
                End If


                sql &= " AND (eindedatum >= @eindedatum OR eindedatum IS NULL)AND Status = 0"
                paramlist.Add("@eindedatum")
                paramlist.Add(Today)


                dgvLeden.AutoGenerateColumns = False
                If dt.Rows.Count = 0 Or Not chkAddSearch.Checked Then
                    dt = New DataTable
                    dt = da.ExecuteDataTable(sql, paramlist.ToArray)
                Else
                    Dim dtTemp As DataTable = da.ExecuteDataTable(sql, paramlist.ToArray)
                    For Each dr As DataRow In dtTemp.Rows
                        If Not RelatieExists(dr.Item("lidnr")) Then
                            dt.ImportRow(dr)
                        End If
                    Next
                End If

                dgvLeden.DataSource = dt
                dgvLeden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                lblAantal.Text = dt.Rows.Count
                'tbCriteria.AppendText(tbCriteria.Lines.Count() & ")" & sbCriteria.ToString & vbCrLf)

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub FillFromQuickMail(ByVal QuickTable As DataTable)
        Try
            If Not QuickTable Is Nothing Then
                Reset()
                'dgvLeden.AutoGenerateColumns = True
                If QuickTable.TableName = "Leeftijd" Then
                    AddDataTableStyle("Leeftijd")
                End If
                dgvLeden.DataSource = QuickTable
                dgvLeden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                lblAantal.Text = QuickTable.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub AddDataTableStyle(ByVal NewColumnName As String)

        Dim contcolumn As New DataGridViewTextBoxColumn

        With contcolumn
            .HeaderText = NewColumnName
            .Name = NewColumnName
            .DataPropertyName = NewColumnName
        End With
        dgvLeden.Columns.Insert(1, contcolumn)
    End Sub
    Private Function RelatieExists(ByVal lidnr As String) As Boolean
        Try
            Dim result As Boolean = False
            For Each dr As DataRow In dt.Rows
                If dr.Item("lidnr") = lidnr Then
                    Return True
                End If
            Next

            Return result
        Catch ex As Exception

        End Try
    End Function
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            If Not DialogResult = Windows.Forms.DialogResult.Cancel Then
                Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
    '    Try
    '        If cmbBriefSoort.SelectedValue < 1 Then
    '            Throw New Exception("Er is nog geen sjabloon geselecteerd!")
    '        End If
    '        If dt.Rows.Count > 0 Then
    '            Me.Cursor = Cursors.WaitCursor
    '            Me.btnProcess.Enabled = False
    '            Me.btnSearch.Enabled = False
    '            'Me.btnReset.Enabled = False
    '            Me.btnReset.Text = "Annuleren"
    '            btnReset.DialogResult = Windows.Forms.DialogResult.Cancel

    '            Status = ""
    '            ready = False
    '            ExpHandler = False
    '            Counter = 0
    '            Dim TotalLineCount As Integer = dt.Rows.Count
    '            _thMailing = New MailingThread

    '            Dim thMailing As New System.Threading.Thread(AddressOf _thMailing.Process)
    '            _thMailing.MailingTable = dt
    '            _thMailing.TemplateId = cmbBriefSoort.SelectedValue
    '            thMailing.Start()

    '            Me.ProgressBar.Maximum = TotalLineCount + 1
    '            Application.DoEvents()
    '            While ready = False

    '                Me.Text = "Bezig met verwerken van Mailing "
    '                'Me.Refresh()
    '                Me.percent(Counter)
    '                Me.lblStatus.Text = Status
    '                If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
    '                    _thMailing.bAbort = True
    '                    'thMailing.Abort()
    '                    _thMailing.IsTerminating = True
    '                    thMailing.Join()
    '                    Me.Cursor = Cursors.Default
    '                    ProgressBar.Value = ProgressBar.Minimum
    '                    Exit While
    '                End If
    '                My.Application.DoEvents()
    '            End While

    '            'Me.lblStatus.Text = Status

    '            If ExpHandler = True Then
    '                thMailing.Abort()
    '            End If

    '            If ready And ExpHandler = False Then
    '                MessageBox.Show("Klaar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                ProgressBar.Value = ProgressBar.Maximum
    '                Me.lblStatus.Text = Status
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        Me.Cursor = Cursors.Default
    '        Me.btnProcess.Enabled = True
    '        Me.btnSearch.Enabled = True
    '        Me.btnReset.Enabled = True
    '        Me.btnReset.Text = "Reset"
    '        btnReset.DialogResult = Windows.Forms.DialogResult.None
    '    End Try
    'End Sub

    Private Sub OpenRelatieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenRelatieToolStripMenuItem.Click
        Try
            Dim ChildForm As New frmRelatie(Me.dgvLeden.SelectedRows(0).Cells("id").Value)
            ChildForm.MdiParent = Main
            ChildForm.WindowState = FormWindowState.Maximized
            ChildForm.Show()
            If TypeName(Main.MenuStrip.Items(0)) = "SystemMenuItem" Then
                Dim t As Long
                t = Main.MenuStrip.Height
                Main.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                Main.MenuStrip.Height = t
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnReset_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.MouseHover
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub btnReset_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnReset.MouseMove
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub btnReset_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.MouseLeave
    '    If Not ready = False Then
    '        Me.Cursor = Cursors.WaitCursor
    '    End If
    'End Sub


    Private Sub btnSql_Click(sender As Object, e As EventArgs) Handles btnSql.Click
        Try
            Dim dlg As New dlgSqlMailing
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.ShowDialog()
            Dim sqlTmp As String = String.Empty
            Try
                If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    dgvLeden.AutoGenerateColumns = False

                    dt = New DataTable
                    Dim sWhereFirst As String = dlg.tbWhereFirst.Text.Trim
                    If Not sWhereFirst = String.Empty Then
                        If Not sWhereFirst.StartsWith(" ") Then
                            sWhereFirst = " " & sWhereFirst
                        End If
                    End If

                    sqlTmp = dlg.txtSQL.Text
                    dt = da.ExecuteDataTable(dlg.tbSqlFrom.Text & sWhereFirst & " WHERE " & dlg.txtSQL.Text)

                    dgvLeden.DataSource = dt
                    dgvLeden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                    lblAantal.Text = dt.Rows.Count
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

                dlg.StartPosition = FormStartPosition.CenterParent
                dlg.txtSQL.Text = sqlTmp
                dlg.ShowDialog()
            End Try



        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class