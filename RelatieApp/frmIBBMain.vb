Imports BusinessObjects

Public Class frmIBBMain
    Private URights As UserRights = UserRights.Instance
    Private lstDossiernr As New List(Of String)
    Private DossierSource As New AutoCompleteStringCollection()

    Private Sub frmIBBMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If URights.IsInGroup("rel_admins") Then
                'ga dan door
            ElseIf URights.IsInGroup("rel_ibb_admins") Then
                'ga dan door
            ElseIf URights.IsInGroup("rel_ibb_users") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            Dim da As New DataAccess

            Dim sql As String = "Select R.achternaam  + ' - ' + onderwerp + ' :' + CAST(D.DossierNr as varchar) as list from IBBDossiers D " &
                                "inner join Relaties R on r.Id = D.LidId"
            lstDossiernr = da.GetListOfString(sql)

            'lstDossiernr = da.GetListOfString("Select dossiernr from IBBDossiers")
            'lstDossiernr = da.GetListOfString("Select dossiernr + ' - ' + Onderwerp as do from IBBDossiers")
            DossierSource.AddRange(lstDossiernr.ToArray)
            tbDossierNr.AutoCompleteCustomSource = DossierSource
            tbDossierNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            tbDossierNr.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim tblBehandelaren As DataTable = da.ExecuteDataTable("SELECT * FROM behandelaren ORDER BY naam")

            Dim dr As DataRow = tblBehandelaren.NewRow
            dr("id") = 0
            dr("Naam") = "Selecteer een behandelaar."
            'dr("id_naam") = "Selecteer een behandelaar."
            tblBehandelaren.Rows.InsertAt(dr, 0)
            cmbBehandelaar.DataSource = tblBehandelaren
            cmbBehandelaar.DisplayMember = "Naam"
            cmbBehandelaar.ValueMember = "id"
            cmbBehandelaar.SelectedValue = 0

            'FillListViewDossiers()
            ' FillListViewRelaties(True)
            FillTreeView()

            AddHandler rbAll.CheckedChanged, AddressOf rbDossiers_CheckedChanged
            AddHandler rbActive.CheckedChanged, AddressOf rbDossiers_CheckedChanged
            AddHandler rbActiveFase.CheckedChanged, AddressOf rbDossiers_CheckedChanged

            rbActive.Checked = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub FillListViewRelaties(ByVal bOpendossiers As Nullable(Of Boolean))
        Try
            Dim _IBBRelaties As New IBBDossierList
            lv.Clear()

            Me.lv.Columns.Add("Naam", 150, HorizontalAlignment.Left)
            lv.Columns.Add("lidnr", 100, HorizontalAlignment.Left)
            lv.Columns.Add("id", 0, HorizontalAlignment.Left)
            lv.View = View.Details
            lv.StateImageList = ImageList1

            If rbAll.Checked Then
                bOpendossiers = False
            ElseIf rbActive.Checked Then
                bOpendossiers = True
            ElseIf rbActiveFase.Checked Then
                bOpendossiers = Nothing
            End If

            Dim lstViewItem As ListViewItem = New ListViewItem()

            Dim iBehandelaar As Integer = -1
            If cmbBehandelaar.SelectedValue > 0 Then
                iBehandelaar = cmbBehandelaar.SelectedValue
            End If

            If bOpendossiers = True Then
                For Each rel As Relaties In _IBBRelaties.OpenIBBRelatieLijst(iBehandelaar)
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = rel.FullName
                    lstViewItem.SubItems.Add(rel.lidnr)
                    lstViewItem.SubItems.Add(rel.Id)
                    lv.Items.Add(lstViewItem)
                Next
            ElseIf bOpendossiers = False Then
                For Each rel As Relaties In _IBBRelaties.IBBRelatieLijst(iBehandelaar)
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = rel.FullName
                    lstViewItem.SubItems.Add(rel.lidnr)
                    lstViewItem.SubItems.Add(rel.Id)
                    lv.Items.Add(lstViewItem)
                Next
            Else
                For Each rel As Relaties In _IBBRelaties.OpenIBBMetFaseRelatieLijst(iBehandelaar)
                    lstViewItem = New ListViewItem()
                    lstViewItem.Text = rel.FullName
                    lstViewItem.SubItems.Add(rel.lidnr)
                    lstViewItem.SubItems.Add(rel.Id)
                    lv.Items.Add(lstViewItem)
                Next
            End If

            lstViewItem = New ListViewItem()
            lstViewItem.Text = "Nieuwe dossier toevoegen"
            lstViewItem.SubItems.Add("0")
            lstViewItem.SubItems.Add("0")
            lv.Items.Add(lstViewItem)

            lv.EnsureVisible(0)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillListViewDossiers()
        Try
            Dim _dossiers As New IBBDossierList

            lv.Clear()

            Me.lv.Columns.Add("Dossiers", 75, HorizontalAlignment.Left)
            lv.Columns.Add("Naam", 100, HorizontalAlignment.Left)
            lv.Columns.Add("Onderwerp", 150, HorizontalAlignment.Left)
            lv.Columns.Add("id", 0, HorizontalAlignment.Left)
            lv.View = View.Details
            lv.StateImageList = ImageList1

            Dim lstViewItem As ListViewItem = New ListViewItem()

            For Each dos As IBBDossier In _dossiers.Lijst
                lstViewItem = New ListViewItem()
                lstViewItem.Text = dos.DossierNr
                lstViewItem.SubItems.Add(dos.MyRelatie.FullName)
                lstViewItem.SubItems.Add(dos.Onderwerp)
                lstViewItem.SubItems.Add(dos.Id)
                lv.Items.Add(lstViewItem)
            Next

            lstViewItem = New ListViewItem()
            lstViewItem.Text = "Nieuwe dossier toevoegen"
            lstViewItem.SubItems.Add("0")
            lstViewItem.SubItems.Add("0")
            lstViewItem.SubItems.Add("0")
            lv.Items.Add(lstViewItem)
            lv.EnsureVisible(lv.Items.Count - 1)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillTreeView()
        Try
            Dim _dossiers As New IBBDossierList
            tvDossiers.Nodes.Clear()
            Dim inode As Integer = 0
            Dim cnode As TreeNode
            For Each dossier In _dossiers.MoerderDossiers
                tvDossiers.Nodes.Add(dossier.DossierNr & " - " & dossier.MyRelatie.FullName & " - " & dossier.Onderwerp & " - Behandelaar: " & dossier.Behandelaar)
                cnode = tvDossiers.Nodes(inode)
                For Each child In dossier.ChildDossiers
                    cnode.Nodes.Add(child.DossierNr & " - " & child.MyRelatie.FullName & " - " & child.Onderwerp & " - Behandelaar: " & child.Behandelaar)
                    cnode.SelectedImageIndex = 11
                    cnode.ImageIndex = 11
                Next
                inode += 1
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ItemChosen(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvDossiers.DoubleClick
        Try
            Dim N As TreeNode = CType(sender, Windows.Forms.TreeView).SelectedNode
            Dim tnDOSSIERNR As String = N.Text

            tnDOSSIERNR = tnDOSSIERNR.Substring(0, tnDOSSIERNR.IndexOf("-") - 1)

            Dim ChildForm As New frmIBBDossier
            ChildForm.MdiParent = Main
            ChildForm.WindowState = FormWindowState.Maximized
            ChildForm.MyIBBDossier = New IBBDossier(tnDOSSIERNR, IBBDossier.VIA.DOSSIERNR)
            ChildForm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub lv_DoubleClick(sender As Object, e As EventArgs) Handles lv.DoubleClick
        Try

            If dgvDossiers.Rows.Count = 1 Then
                OpenDossier()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged
        Try
            dgvDossiers.DataSource = Nothing
            dgvDossiers.AutoGenerateColumns = False

            If Not lv.SelectedItems.Count = 0 Then
                Dim SelectedItem As Integer = Me.lv.SelectedItems(0).SubItems(2).Text
                FillDossiers()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub FillDossiers()
        Try

            Dim _dossiers As New IBBDossierList
            Me.dgvDossiers.DataSource = _dossiers.LijstByLidId(lv.SelectedItems(0).SubItems(2).Text)
            'If _dossiers.LijstByLidId(lv.SelectedItems(0).SubItems(2).Text).Count = 1 Then
            '    dgvDossiers.Rows(0).Selected = True
            '    OpenDossier()
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OpenDossier()

        Try

            'If String.IsNullOrEmpty(MyToken) Then
            '    Dim authResult1 = Threading.Tasks.Task.Run(Function() GetMytoken())
            '    authResult1.Wait()
            'End If


            If dgvDossiers.SelectedRows.Count > 0 Then
                Dim ChildForm As New frmIBBDossier
                ChildForm.MdiParent = Main
                'ChildForm.WindowState = FormWindowState.Maximized
                'ChildForm.MyRelatie = MyRelatie
                ChildForm.MyIBBDossier = New IBBDossier(dgvDossiers.SelectedRows(0).Cells("Id").Value, IBBDossier.VIA.ID)
                ChildForm.Show()
                Try ' workarround omdat het  icon niet zichtbaar wordt in de menubalk.
                    If TypeName(Main.MenuStrip.Items(0)) = "SystemMenuItem" Then
                        Dim t As Long
                        t = Main.MenuStrip.Height
                        Main.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                        Main.MenuStrip.Height = t
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvDossiers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDossiers.DoubleClick
        Try
            OpenDossier()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim myDossier As New IBBDossier

            Dim myDOSSIERNR As String = tbDossierNr.Text
            myDOSSIERNR = myDOSSIERNR.Substring(myDOSSIERNR.LastIndexOf(":") + 1, myDOSSIERNR.Length - myDOSSIERNR.LastIndexOf(":") - 1)
            myDossier = New IBBDossier(myDOSSIERNR, IBBDossier.VIA.DOSSIERNR)
            If myDossier.Found Then
                Dim ChildForm As New frmIBBDossier
                ChildForm.MdiParent = Main
                ChildForm.WindowState = FormWindowState.Maximized
                ChildForm.MyIBBDossier = New IBBDossier(myDossier.Id, IBBDossier.VIA.ID)
                ChildForm.Show()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click

        If btnExpand.Text = "Uitvouwen" Then
            tvDossiers.ExpandAll()
            btnExpand.Text = "Invouwen"
            btnExpand.ImageIndex = 9
        ElseIf btnExpand.Text = "Invouwen" Then
            tvDossiers.CollapseAll()
            btnExpand.Text = "Uitvouwen"
            btnExpand.ImageIndex = 10
        End If
    End Sub
    Private Sub rbDossiers_CheckedChanged(sender As Object, e As EventArgs)
        If rbAll.Checked Then
            FillListViewRelaties(False)
        ElseIf rbActive.Checked Then
            FillListViewRelaties(True)
        ElseIf rbActiveFase.Checked Then
            FillListViewRelaties(Nothing)
        End If
    End Sub


    Private Sub btnKenmerk_Click(sender As Object, e As EventArgs) Handles btnKenmerk.Click
        Try

            If Not String.IsNullOrEmpty(tbKenmerk.Text) Then
                dgvDossiers.DataSource = Nothing
                dgvDossiers.AutoGenerateColumns = False
                Dim _dossiers As New IBBDossierList
                Me.dgvDossiers.DataSource = _dossiers.LijstByKenmerk(tbKenmerk.Text.Trim)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


  
    Private Sub cmbBehandelaar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBehandelaar.SelectedIndexChanged
        Try
            If TypeOf sender.SelectedValue Is Integer Then
                FillListViewRelaties(Nothing)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMFA_Click(sender As Object, e As EventArgs) Handles btnMFA.Click
        Try
            MessageBox.Show("Handmatig inloggen is niet meer nodig: de mailkoppeling gebruikt nu een app-only verbinding met Microsoft Graph.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class