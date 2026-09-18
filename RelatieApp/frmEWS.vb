Imports BusinessObjects
Imports Newtonsoft.Json.Linq

Public Class frmEWS

    Private _ews As EwsTest
    Public Property ews() As EwsTest
        Get
            If _ews Is Nothing Then
                _ews = New EwsTest(Me.chkUseSystemSetting.Checked)
            End If
            Return _ews
        End Get
        Set(ByVal value As EwsTest)
            _ews = value
        End Set
    End Property

    'Private _ewsMailer As EwsMailer
    'Public Property ewsMailer() As EwsMailer
    '    Get
    '        If _ewsMailer Is Nothing Then
    '            _ewsMailer = New EwsMailer(Me.chkUseSystemSetting.Checked)
    '        End If
    '        Return _ewsMailer
    '    End Get
    '    Set(ByVal value As EwsMailer)
    '        _ewsMailer = value
    '    End Set
    'End Property
    Private Sub chkUseSystemSetting_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseSystemSetting.CheckedChanged
        Try
            _ews = Nothing
            lvItems.Clear()
            wbMessage.DocumentText = ""

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmEWS_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub


    Private Sub tvFolders_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvFolders.AfterSelect
        Try
            Try
                Dim iTN As Integer = 0
                Dim cnode As TreeNode = New TreeNode
                cnode = e.Node
                ews.ListOfSubFolders = Nothing
                For Each _folder As GraphMailFolder In ews.GetSubFolders(e.Node.Name)
                    cnode.Nodes.Add(_folder.Id, _folder.DisplayName)
                Next

                ews.GetItems(e.Node.Name)

                Dim lstViewItem As ListViewItem = New ListViewItem()
                lvItems.Clear()
                lvItems.Enabled = True
                lvItems.Columns.Add("Datum", 100, HorizontalAlignment.Left)
                lvItems.Columns.Add("Van", 100, HorizontalAlignment.Left)
                lvItems.Columns.Add("Onderwerp", 400, HorizontalAlignment.Left)
                lvItems.Columns.Add("uid", 10, HorizontalAlignment.Left)
                lvItems.View = View.Details

                For Each item As Berichten In ews.MailItems
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = item.ReceivedDate
                    lstViewItem.SubItems.Add(item.FromName)
                    lstViewItem.SubItems.Add(item.Subject)
                    lstViewItem.SubItems.Add(item.Header)
                    lvItems.Items.Add(lstViewItem)
                Next


            Catch ex As Exception
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try





            ews.completeListOfFolderIds = Nothing
            ews.EwsFolder()

            Me.tvFolders.Nodes.Clear()
            Dim iTN As Integer = 0
            Dim cnode As TreeNode = New TreeNode
            Dim cnode1 As TreeNode = New TreeNode
            Dim itn1 As Integer = 0

            'Graph's mailFolders eindpunt geeft alleen echte mailfolders terug, dus de vroegere
            'type-check voor search-/contacts-/tasks-/agendafolders is niet meer nodig.
            For Each _folder As GraphMailFolder In ews.completeListOfFolderIds
                tvFolders.Nodes.Add(_folder.Id, _folder.DisplayName)
                cnode = tvFolders.Nodes(iTN)
                iTN = iTN + 1
                ews.ListOfSubFolders = Nothing
                For Each _cnfolder As GraphMailFolder In ews.GetSubFolders(_folder.Id)
                    cnode.Nodes.Add(_cnfolder.Id, _cnfolder.DisplayName)
                Next
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub AddSubNode(tnode As TreeNode, folderid As String)

    End Sub

    Private Sub lvItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvItems.SelectedIndexChanged
        Try
            If lvItems.SelectedItems.Count = 1 Then
                Dim msg As JObject = ews.GetItem(lvItems.SelectedItems(0).SubItems(3).Text)
                Dim body = msg("body")
                Dim content As String = If(body IsNot Nothing, CStr(body("content")), String.Empty)

                If body IsNot Nothing AndAlso String.Equals(CStr(body("contentType")), "text", StringComparison.OrdinalIgnoreCase) Then
                    wbMessage.DocumentText = Replace(content, vbCrLf, "<br>")
                Else
                    wbMessage.DocumentText = content
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'Dim lid As New Lidmaat(0, Lidmaat.Via.LIDNR)
            Dim MyTemplate As New BusinessObjects.tblTemplates(92)

            Dim MasterFile As String = String.Empty
            Dim TemplatePath As String = String.Empty

            TemplatePath = MyTemplate.DefaultLocation & MyTemplate.Afdeling
            MasterFile = TemplatePath & MyTemplate.Naam

            Dim Body As String = ews.BodyTemplate((MasterFile))

            Dim LidBody As String = Body.Replace("xACHTERNAAM", "bert")
            'LidBody = LidBody.Replace("xURL", _utils.CurrentSite)
            'LidBody = LidBody.Replace("xGUID", NewActivation.ActivatieGUID.ToString)
            'LidBody = LidBody.Replace("xLIDNR", lid.lidnr)
            'LidBody = LidBody.Replace("xLIDBOEKING", lid.Boeking_Message.Replace(vbCrLf, "<br/>"))


            ews.sendmail(tbTo.Text, "VBM Mailing", LidBody)

            LidBody = Body.Replace("xACHTERNAAM", "publiek2")
            ews.sendmail("publiek2@netmask.nl", "VBM Mailing", LidBody)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub btnMailer_Click_1(sender As Object, e As EventArgs) Handles btnMailer.Click
        Try
            Dim oEmail As New Email
            oEmail.Address = tbTo.Text
            oEmail.Name = tbTo.Text

            Dim oMailer As New Mailer
            oMailer.MailSubject = "VBM mailing:"

            Dim Body As String = oMailer.BodyTemplate("mailing")
            Body = Body.Replace("xACHTERNAAM", "lid.achternaam")
            Body = Body.Replace("xURL", "_utils.CurrentSite")
            Body = Body.Replace("xGUID", "ActivatieGUID.")
            oMailer.MailBody = Body
            oMailer.SendEmbeddedImages(oEmail)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ews.EwsFolder()

            Dim lijst As String = ""
            For Each map In ews.completeListOfFolderIds
                lijst = lijst & vbCrLf & map.DisplayName
            Next
            MessageBox.Show(lijst)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class