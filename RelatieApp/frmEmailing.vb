Imports BusinessObjects
Imports OfficeObjects
Imports System.IO
Imports System.Runtime.InteropServices

Public Class frmEmailing
    Private da As New DataAccess
    Private myTemplates As DataTable = New DataTable
    Private myTemplateDoc As BusinessObjects.tblTemplates

    Public myMailTemplateId As Integer
    Public bWrite2Correspondetie As Boolean = False

    Private dtPost As New DataTable
    Private dtMail As New DataTable

    Private _MailingTable As DataTable = Nothing
    Public Property MailingTable() As DataTable
        Get
            Return _MailingTable
        End Get
        Set(ByVal value As DataTable)
            _MailingTable = value
        End Set
    End Property

#Region "Thread Brieven"

    Private WithEvents _thMailing As MailingThread
    Private Status As String = ""
    Dim ExpMessage As String = String.Empty
    Private ready As Boolean = False
    Private ExpHandler As Boolean = False
    Private m_PercentDone As Integer = 0
    Private Counter As Integer = 0


    Public Sub percent(ByVal value As Integer)
        Me.ProgressBarWord.Value = value
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

    Private Sub frmEmailing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            myTemplates = da.ExecuteDataTable("SELECT * FROM Templates WHERE (Bond = 0 OR BOND = 1) ORDER BY afdeling, omschrijving")
            _thEMailing = New EwsMailer(False)

            Dim mnu As New ToolStripMenuItem
            Dim mnu1 As New ToolStripMenuItem
            mnu.Text = "Kies brief sjabloon"
            Dim tmpGroup As String = "Kies brief sjabloon"
            For Each rw As DataRow In myTemplates.Rows
                If rw.Item("Afdeling").ToString.ToLower = "email" Then Continue For
                If tmpGroup <> rw.Item("Afdeling") Then
                    mnu1 = New ToolStripMenuItem
                    mnu1.Text = rw.Item("Afdeling")
                    mnu1.Size = New Point(150, 20)
                    mnu1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                    AddHandler mnu1.DropDownItemClicked, AddressOf LoadTemplate
                End If
                mnu1.DropDownItems.Add(rw.Item("omschrijving"))

                mnu.DropDownItems.Add(mnu1)
                tmpGroup = rw.Item("Afdeling")
            Next

            mnu.Owner = ToolStrip1
            mnu.Enabled = True


            tbfileSave.Text = My.Settings.ReportsPath

            dtPost = MailingTable.Copy
            dtPost.Clear()
            dtMail = MailingTable.Copy
            dtMail.Clear()

            For Each dr As DataRow In MailingTable.Rows
                If String.IsNullOrEmpty(dr.Item("Email")) Then
                    dtPost.ImportRow(dr)
                Else
                    dtMail.ImportRow(dr)
                End If
            Next

            lblMailCount.Text = dtMail.Rows.Count
            lblPostCount.Text = dtPost.Rows.Count

            If myMailTemplateId > 0 Then
                Dim MailTempate As BusinessObjects.tblTemplates = New BusinessObjects.tblTemplates(myMailTemplateId)
                LoadMailTemplate(MailTempate.FullName)
            End If

            If dtMail.Rows.Count > 0 Then
                'validatie emailadressen en voor de zekerheid alle adressen trimmen.
                For Each dr As DataRow In dtMail.Rows
                    Dim ValAddress As String = dr.Item("Email")
                    'en eventuele accents vervangen.
                    ValAddress = RemoveAccentMarks(ValAddress)
                    If Not ValidEmail(ValAddress.Trim) Then
                        Throw New Exception("emailadres " & ValAddress.Trim & " van lidnr " & dr.Item("lidnr") & " is ongeldig!")
                    Else
                        dr.Item("Email") = ValAddress.Trim
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
        End Try
    End Sub
    Private Sub LoadTemplate(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs)
        Try
            Dim _afdeling As String = DirectCast(sender, System.Windows.Forms.ToolStripMenuItem).Text
            Dim _sjabloon As String = e.ClickedItem.ToString
            Dim _Id As Integer = FindTemplate(_sjabloon, _afdeling)

            If _Id > 0 Then

                myTemplateDoc = New BusinessObjects.tblTemplates(_Id)
                tbTemplate.Text = myTemplateDoc.Naam

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
    'Private Sub FilltvBrieven()
    '    Try
    '        Dim tmpGroup As String = "Brieven"
    '        Dim cnode As TreeNode
    '        Dim inode As Integer = -1

    '        For Each rw As DataRow In myTemplates.Rows
    '            Dim CatchEmpty As String = rw.Item("Afdeling")
    '            If String.IsNullOrEmpty(CatchEmpty) Then CatchEmpty = "standaard"
    '            If tmpGroup <> CatchEmpty Then
    '                tvBrieven.Nodes.Add(CatchEmpty)
    '                If inode < 0 Then
    '                    inode = 0
    '                Else
    '                    inode += 1
    '                End If

    '            End If
    '            cnode = tvBrieven.Nodes(inode)
    '            cnode.Nodes.Add(rw.Item("id"), rw.Item("omschrijving"))
    '            tmpGroup = CatchEmpty
    '        Next

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub tvBrieven_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim N As TreeNode = CType(sender, Windows.Forms.TreeView).SelectedNode
    '    Try
    '        If Not N Is Nothing Then
    '            Dim Soort As String = String.Empty
    '            If Not N.Parent Is Nothing Then Soort = N.Parent.Text
    '            Dim i As Integer = 0
    '            If Integer.TryParse(N.Name, i) Then

    '                tbTemplate.Text = N.Text
    '                MyTemplateDoc = New BusinessObjects.tblTemplates(N.Name)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub


    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Try
            fbdSave.Description = "Selecteer de opslag locatie..."

            If Not My.Settings.ReportsPath = "" Then
                fbdSave.SelectedPath = My.Settings.ReportsPath
                fbdSave.Description = "huidige opslag locatie..." & vbCrLf & vbCrLf & fbdSave.SelectedPath
            End If

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.ReportsPath = fbdSave.SelectedPath
                My.Settings.Save()
                tbfileSave.Text = fbdSave.SelectedPath
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btAtt_Click(sender As Object, e As EventArgs) Handles btAtt.Click
        Try
            If Not My.Settings.ReportsPath = "" Then
                ofFile.InitialDirectory = My.Settings.ReportsPath
            End If

            If ofFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.tbAttachment.Text = ofFile.FileName
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadMailTemplate(ByVal MailTemplate As String)
        Try
            If String.IsNullOrEmpty(MailTemplate) Then Exit Sub

            _thEMailing = New EwsMailer(False)
            _thEMailing.SetBodyTemplate(MailTemplate)
            HtmlTextbox1.Text = _thEMailing._BodyTemplate
            'lijst sharedmailbox ophalen.
            Dim listAlternateMailbox As List(Of String) = _thEMailing.getAlternateMailboxCollection()
            cmbSender.DataSource = listAlternateMailbox

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TestEmail(SendTo As String)
        Try

            ValidateConditions()

            Dim dtTest As DataTable = dtMail.Copy
            dtTest.Clear()

            dtTest.ImportRow(dtMail.Rows(0))
            dtTest.Rows(0).Item("email") = SendTo

            Me.Cursor = Cursors.WaitCursor

            Status_email = ""
            ready_email = False
            ExpHandler_email = False
            Counter_email = 0

            Dim TotalLineCount As Integer = dtTest.Rows.Count
            Dim thEMailing As New System.Threading.Thread(AddressOf _thEMailing.Process)

            ''*** attachment toevoegen ***
            If Not String.IsNullOrEmpty(tbAttachment.Text) Then
                Dim fi As IO.FileInfo = New IO.FileInfo(tbAttachment.Text)
                If Not fi.Exists Then Throw New Exception("Kan " & tbAttachment.Text & " niet vinden.")

                dtTest.Columns.Add("Attfile", Type.GetType("System.String"))
                For Each dr As DataRow In dtTest.Rows
                    Dim AttFileName As String = String.Empty
                    dr("Attfile") = tbAttachment.Text
                Next
            End If


            _thEMailing.SendFrom = cmbSender.SelectedItem
            _thEMailing.Subject = tbSubject.Text
            _thEMailing._BodyTemplate = HtmlTextbox1.Text
            _thEMailing.bWrite2Correspondetie = bWrite2Correspondetie
            _thEMailing.MailingTable = dtTest

            thEMailing.Start()

            Me.ProgressBar.Maximum = TotalLineCount + 1
            Application.DoEvents()
            While ready_email = False

                Me.percent_email(Counter_email)
                Me.lblMailStatus.Text = Status_email
                If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler_email = True Then
                    _thEMailing.IsTerminating = True
                    _thEMailing.bAbort = True
                    thEMailing.Join()
                    Me.Cursor = Cursors.Default
                    ProgressBar.Value = ProgressBar.Minimum
                    Exit While
                End If
                My.Application.DoEvents()
            End While


            If ready_email And ExpHandler_email = False Then
                ProgressBar.Value = ProgressBar.Minimum
                Me.lblMailStatus.Text = "Test bericht verzonden"
            ElseIf ready_email And ExpHandler_email = True Then
                MessageBox.Show(ExpMessage_email, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ProgressBar.Value = ProgressBar.Minimum
                Me.lblMailStatus.Text = Status_email
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            OK_Button.Enabled = True
        End Try


    End Sub

    Private Sub Emailing()
        Try
            If dtMail.Rows.Count > 0 Then

                Me.Cursor = Cursors.WaitCursor

                Status_email = ""
                ready_email = False
                ExpHandler_email = False
                Counter_email = 0

                Dim TotalLineCount As Integer = dtMail.Rows.Count
                Dim thEMailing As New System.Threading.Thread(AddressOf _thEMailing.Process)

                ''*** attachment toevoegen ***
                If Not String.IsNullOrEmpty(tbAttachment.Text) Then
                    Dim fi As IO.FileInfo = New IO.FileInfo(tbAttachment.Text)
                    If Not fi.Exists Then Throw New Exception("Kan " & tbAttachment.Text & " niet vinden.")

                    dtMail.Columns.Add("Attfile", Type.GetType("System.String"))
                    For Each dr As DataRow In dtMail.Rows
                        Dim AttFileName As String = String.Empty
                        dr("Attfile") = tbAttachment.Text
                    Next
                End If

                _thEMailing.SendFrom = cmbSender.SelectedItem
                _thEMailing.Subject = tbSubject.Text
                _thEMailing._BodyTemplate = HtmlTextbox1.Text
                _thEMailing.MailingTable = dtMail
                _thEMailing.bWrite2Correspondetie = bWrite2Correspondetie

                thEMailing.Start()

                Me.ProgressBar.Maximum = TotalLineCount + 1
                Application.DoEvents()
                While ready_email = False
                    'Me.Refresh()
                    Me.percent_email(Counter_email)
                    Me.lblMailStatus.Text = Status_email
                    If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler_email = True Then
                        _thEMailing.IsTerminating = True
                        _thEMailing.bAbort = True
                        thEMailing.Join()
                        Me.Cursor = Cursors.Default
                        ProgressBar.Value = ProgressBar.Minimum
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

            End If


            If ready_email And ExpHandler_email = False Then
                ProgressBar.Value = ProgressBar.Maximum
                Me.lblMailStatus.Text = Status_email
            ElseIf ready_email And ExpHandler_email = True Then
                MessageBox.Show(ExpMessage_email, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ProgressBar.Value = ProgressBar.Maximum
                Me.lblMailStatus.Text = Status_email
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            OK_Button.Enabled = True
            'Me.btnSearch.Enabled = True
            'Me.btnReset.Enabled = True
            'Me.btnReset.Text = "Reset"
            'btnReset.DialogResult = Windows.Forms.DialogResult.None
        End Try


    End Sub
    Private Sub Merge()
        Try

            If myTemplateDoc Is Nothing Then
                Throw New Exception("Er is nog geen sjabloon geselecteerd!")
            End If

            If dtPost.Rows.Count > 0 Then

                Me.Cursor = Cursors.WaitCursor

                Status = ""
                ready = False
                ExpHandler = False
                Counter = 0
                Dim TotalLineCount As Integer = dtPost.Rows.Count
                _thMailing = New MailingThread

                Dim thMailing As New System.Threading.Thread(AddressOf _thMailing.Process)


                _thMailing.MailingTable = dtPost
                _thMailing.TemplateId = myTemplateDoc.Id
                _thMailing.bWrite2Correspondetie = bWrite2Correspondetie
                thMailing.Start()

                Me.ProgressBarWord.Maximum = TotalLineCount + 1
                Application.DoEvents()
                While ready = False

                    ' Me.Text = "Bezig met verwerken van Mailing "
                    Me.percent(Counter)
                    Me.lbPostStatus.Text = Status
                    If Me.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
                        _thMailing.IsTerminating = True
                        _thMailing.bAbort = True
                        thMailing.Join()
                        Me.Cursor = Cursors.Default
                        ProgressBarWord.Value = ProgressBarWord.Minimum
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                If ready And ExpHandler = False Then
                    ProgressBarWord.Value = ProgressBarWord.Maximum
                    Me.lbPostStatus.Text = Status
                ElseIf ready And ExpHandler = True Then
                    MessageBox.Show(ExpMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ProgressBarWord.Value = ProgressBarWord.Maximum
                    Me.lbPostStatus.Text = Status
                End If
            Else
                MessageBox.Show("Er is nog geen selectie gemaakt.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            'Me.btnProcess.Enabled = True
            'Me.btnSearch.Enabled = True
            'Me.btnReset.Enabled = True
            'Me.btnReset.Text = "Reset"
            'btnReset.DialogResult = Windows.Forms.DialogResult.None
        End Try
    End Sub

    Private Sub ValidateConditions()

        ' eerst alles valideren. 
        If dtPost.Rows.Count > 0 Then
            ' indien er post adressen zijn, is er een brief sjabloon geselecteerd en kan deze ook worden gevonden?
            ' is Word open - dan verzoeken afsluiten.
            If myTemplateDoc Is Nothing Then _
                Throw New Exception("Er is nog geen sjabloon geselecteerd!")
            If Not File.Exists(myTemplateDoc.FullName) Then _
                Throw New Exception("Het sjabloon " & myTemplateDoc.FullName & " kan niet worden gevonden!")
            If IsWordRunning() Then _
                Throw New Exception("Word is actief. sluit deze eerst af!")
        End If

        ' is er een mail template geselecteerd indien er mailadressen zijn (nvt. er wordt altijd een default body geladen)
        If dtMail.Rows.Count > 0 Then
            If String.IsNullOrEmpty(_thEMailing.myEmailAddress) Then _
                Throw New Exception("Er is nog geen connectie met mailserver")
            'validatie emailadressen en voor de zekerheid alle adressen trimmen.
            For Each dr As DataRow In dtMail.Rows
                Dim ValAddress As String = dr.Item("Email")
                If Not ValidEmail(ValAddress.Trim) Then
                    Throw New Exception("emailadres " & ValAddress.Trim & " van lidnr " & dr.Item("lidnr") & " is ongeldig!")
                Else
                    dr.Item("Email") = ValAddress.Trim
                End If
            Next
        End If

    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Try
            ValidateConditions()

            'Bug:1151: mogelijkheid hebben om alleen de brieven opnieuw te maken zonder de emails te versturen. 

            Dim dlgAskSend As New dlgAskIt
            With dlgAskSend
                .StartPosition = FormStartPosition.CenterScreen
                .Width = 450
                .Height = 200

                Dim mylabel As New Label
                mylabel.Location = New Point(.Location.X + 20, 20)
                mylabel.Name = "lbl"
                mylabel.Text = "Zet de corresponderende checkbox uit indien u brieven\of email niet wilt verwerken "
                mylabel.AutoSize = True
                .Controls.Add(mylabel)

                Dim mychk1 As New CheckBox
                mychk1.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 15)
                mychk1.Name = "mychk1"
                mychk1.Text = "verwerk brieven"
                mychk1.AutoSize = True
                mychk1.Checked = True
                .Controls.Add(mychk1)

                Dim mychk2 As New CheckBox
                mychk2.Location = New Point(mychk1.Location.X, mychk1.Location.Y + mychk1.Size.Height + 15)
                mychk2.Name = "mychk2"
                mychk2.Text = "verwerk mailing"
                mychk2.AutoSize = True
                mychk2.Checked = True
                .Controls.Add(mychk2)

                .ShowDialog()

                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.OK_Button.Enabled = False
                    If mychk1.Checked = True Then
                        If dtPost.Rows.Count > 0 Then Merge()
                    End If
                    If mychk2.Checked = True Then
                        If dtMail.Rows.Count > 0 Then Emailing()
                    End If

                End If

            End With





        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            'Me.btnProcess.Enabled = True
            'Me.btnSearch.Enabled = True
            'Me.btnReset.Enabled = True
            'Me.btnReset.Text = "Reset"
            'btnReset.DialogResult = Windows.Forms.DialogResult.None
        End Try
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    'Private _ews As EwsMailer
    'Public Property ews() As EwsMailer
    '    Get
    '        If _ews Is Nothing Then
    '            _ews = New EwsMailer(False)
    '        End If
    '        Return _ews
    '    End Get
    '    Set(ByVal value As EwsMailer)
    '        _ews = value
    '    End Set
    'End Property

    Private Sub btLoadBody_Click(sender As Object, e As EventArgs) Handles btLoadBody.Click
        Try

            With ofdBody
                .Reset()
                .CheckFileExists = True
                .CheckPathExists = True
                .Filter = "html files (*.html)|*.html"
                .Multiselect = False
                .Title = "Selecteer een html sjabloon"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    LoadMailTemplate(ofdBody.FileName)
                End If
            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btTestMail_Click(sender As Object, e As EventArgs) Handles btTestMail.Click
        Try
            Dim dlgAskAge As New dlgAskIt
            dlgAskAge.StartPosition = FormStartPosition.CenterScreen
            dlgAskAge.Width = 450

            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAskAge.Location.X + 20, 20)
            mylabel.Name = "lbl"
            mylabel.Text = "In het bericht wordt 1 vd geselecteerde leden gebruikt als voorbeeld."
            mylabel.AutoSize = True
            dlgAskAge.Controls.Add(mylabel)

            Dim mylabel2 As New Label
            mylabel2.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 5)
            mylabel2.Text = "Alleen het emailadres wordt aangepast voor het verzenden van het test bericht."
            mylabel2.AutoSize = True
            dlgAskAge.Controls.Add(mylabel2)

            Dim lbeMail As New Label
            lbeMail.Location = New Point(mylabel2.Location.X, mylabel2.Location.Y + mylabel2.Size.Height + 15)
            lbeMail.Text = "Naar welk emailadres wilt u de testmail sturen?"
            lbeMail.AutoSize = True
            dlgAskAge.Controls.Add(lbeMail)

            Dim tbeMail As New TextBox
            tbeMail.Location = New Point(lbeMail.Location.X, lbeMail.Location.Y + lbeMail.Size.Height + 20)
            'tbeMail.Location = New Point(lbeMail.Size.Width + 30, lbeMail.Location.Y - 5)
            tbeMail.Name = "tbeMail"
            tbeMail.Text = _thEMailing.myEmailAddress ' " .......@mijnvbm.nl"
            dlgAskAge.Controls.Add(tbeMail)


            dlgAskAge.ShowDialog()

            If dlgAskAge.DialogResult = Windows.Forms.DialogResult.OK Then
                If Not tbeMail.Text = "" And ValidEmail(tbeMail, New System.ComponentModel.CancelEventArgs) Then
                    TestEmail(tbeMail.Text)
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub tbAttachment_TextChanged(sender As Object, e As EventArgs) Handles tbAttachment.TextChanged

    End Sub
End Class