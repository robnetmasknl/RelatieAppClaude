Imports BusinessObjects
Imports System.ComponentModel

Public Class frmAdviseurs

    Private SelectedAdviseur As Adviseur = Nothing

    Public Event ColumnHeaderMouseClick As DataGridViewCellMouseEventHandler

    Private WithEvents frmBoeking As frmBoekingen
    Public Sub ChangeCompleteHandler(ByVal _message As String) Handles frmBoeking.BoekingClosing
        Try
            FillBoekingen()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmAdviseurs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dgvBlokken.AutoGenerateColumns = False
            FillListViewAdviseurs()

            btDeleteBlok.Enabled = False
            btEditBlok.Enabled = False
            For Each Control In Me.Controls
                'If TypeOf(Control) = TextBox 
                If TypeOf (Control) Is TextBox Then
                    Dim textbox As TextBox = Control
                    AddHandler textbox.LostFocus, AddressOf CheckSelectedRow
                ElseIf TypeOf (Control) Is Button Then
                    Dim Button As Button = Control
                    AddHandler Button.LostFocus, AddressOf CheckSelectedRow
                ElseIf TypeOf (Control) Is ListView Then
                    Dim ListView As ListView = Control
                    AddHandler ListView.LostFocus, AddressOf CheckSelectedRow
                ElseIf TypeOf (Control) Is DataGridView Then
                    Dim DataGridView As DataGridView = Control
                    AddHandler DataGridView.LostFocus, AddressOf CheckSelectedRow
                End If
            Next

            CheckSelectedRow()



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CheckSelectedRow()
        Try
            btDeleteBlok.Enabled = dgvBlokken.SelectedRows.Count > 0
            btEditBlok.Enabled = dgvBlokken.SelectedRows.Count > 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillListViewAdviseurs()
        Try
            Dim _adviseurs As New AdviseursLijst
            lvAdviseurs.Clear()

            Me.lvAdviseurs.Columns.Add("Naam", 150, HorizontalAlignment.Left)
            lvAdviseurs.Columns.Add("Blokken", 25, HorizontalAlignment.Left)
            lvAdviseurs.Columns.Add("id", 0, HorizontalAlignment.Left)
            lvAdviseurs.View = View.Details
            lvAdviseurs.StateImageList = ImageList1

            Dim lstViewItem As ListViewItem = New ListViewItem()
            For Each Adv As Adviseur In _adviseurs.Lijst
                lstViewItem = New ListViewItem()
                lstViewItem.Text = Adv.naam
                If Adv.Blokken.Count > 0 Then
                    lstViewItem.StateImageIndex = 0
                Else
                    lstViewItem.StateImageIndex = 1
                End If
                lstViewItem.SubItems.Add(Adv.Blokken.Count)
                lstViewItem.SubItems.Add(Adv.Id)
                lvAdviseurs.Items.Add(lstViewItem)
            Next

            lstViewItem = New ListViewItem()
            lstViewItem.Text = "Nieuwe adviseur toevoegen"
            lstViewItem.SubItems.Add("0")
            lstViewItem.SubItems.Add("0")
            lvAdviseurs.Items.Add(lstViewItem)
            lvAdviseurs.EnsureVisible(lvAdviseurs.Items.Count - 1)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillBoekingen(Optional ByVal SelectedCol As String = "")
        Try

            dgvBlokken.DataSource = Nothing
            SelectedAdviseur = New Adviseur(SelectedAdviseur.Id)

            If chkShowDummies.CheckState = CheckState.Checked Then
                If dgvBlokken.Columns.Contains("AantalDummies") = False Then
                    Dim colDummy As New DataGridViewColumn
                    colDummy = dgvBlokken.Columns("Aantal").Clone
                    colDummy.Name = "AantalDummies"
                    colDummy.HeaderText = "AantalDummies"
                    colDummy.DataPropertyName = "AantalDummies"
                    colDummy.Visible = True
                    dgvBlokken.Columns.Add(colDummy)
                End If
            Else
                If dgvBlokken.Columns.Contains("AantalDummies") = True Then
                    dgvBlokken.Columns.Remove("AantalDummies")
                End If
            End If


            Select Case SelectedCol
                Case "LocatieNaam"
                    Dim sortedList = From entry In SelectedAdviseur.Blokken Order By entry.LocatieNaam Ascending Select entry
                    Dim list = sortedList.ToList
                    dgvBlokken.DataSource = list
                Case "datum"
                    Dim sortedList = From entry In SelectedAdviseur.Blokken Order By entry.datum Ascending Select entry
                    Dim list = sortedList.ToList
                    dgvBlokken.DataSource = list
                Case "AantalBeschikbaar"
                    Dim sortedList = From entry In SelectedAdviseur.Blokken Order By entry.AantalBeschikbaar Ascending Select entry
                    Dim list = sortedList.ToList
                    dgvBlokken.DataSource = list
                Case Else
                    dgvBlokken.DataSource = SelectedAdviseur.Blokken
            End Select


            For Each rw As DataGridViewRow In dgvBlokken.Rows
                If rw.Cells("Vol").Value.ToString = "True" Then
                    rw.DefaultCellStyle.BackColor = Color.Red
                End If
                If chkShowDummies.CheckState = CheckState.Checked Then
                    If rw.Cells("AantalDummies").Value = 0 Then
                        'rw.DefaultCellStyle.BackColor = Color.Orange
                    ElseIf rw.Cells("AantalDummies").Value >= 3 Then
                        rw.DefaultCellStyle.BackColor = Color.Orange
                    ElseIf rw.Cells("AantalDummies").Value >= 0 Then
                        rw.DefaultCellStyle.BackColor = Color.Yellow
                    End If
                End If
            Next
            dgvBlokken.Refresh()
            For Each col As DataGridViewColumn In dgvBlokken.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            'dgvBlokken.Columns.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


            Me.lblNaam.Text = SelectedAdviseur.naam
            Me.lblAantalBlokken.Text = SelectedAdviseur.AantalBlokken
            Me.lblAantalBoekingen.Text = SelectedAdviseur.AantalBoekingen
            Me.lblAantalBeschikbaar.Text = SelectedAdviseur.AantalBeschikbaar
            Me.NieuwBlokToolStripMenuItem.Text = "Nieuw blok voor " & SelectedAdviseur.naam

            FillListViewAdviseurs()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvBlokken_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvBlokken.ColumnHeaderMouseClick

        ' Dim newColumn As DataGridViewColumn = dgvBlokken.Columns(e.ColumnIndex).Name
        FillBoekingen(dgvBlokken.Columns(e.ColumnIndex).Name)

    End Sub


    Private Sub lvAdviseurs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAdviseurs.SelectedIndexChanged
        Try
            dgvBlokken.DataSource = Nothing
            If Not lvAdviseurs.SelectedItems.Count = 0 Then
                Dim SelectedItem As Integer = Me.lvAdviseurs.SelectedItems(0).SubItems(2).Text

                If SelectedItem = 0 Then
                    Dim TopForm As New dlgNewAdviseur
                    TopForm.Text = "Nieuwe adviseur toevoegen"
                    Dim result As DialogResult = TopForm.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        FillListViewAdviseurs()
                    End If
                Else
                    SelectedAdviseur = New Adviseur(SelectedItem)
                    FillBoekingen()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OpenBoekingen()
        Try
            frmBoeking = New frmBoekingen(Me.dgvBlokken.SelectedRows(0).Cells("Id").Value)
            frmBoeking.MdiParent = MainForm
            frmBoeking.WindowState = FormWindowState.Maximized
            frmBoeking.Show()

            'FillBoekingen()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub NieuwBlokToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NieuwBlokToolStripMenuItem.Click
        Try
            If SelectedAdviseur Is Nothing Then _
                            Throw New Exception("Er is nog geen adviseur geselecteerd." & vbCrLf & "kies een adviseur en prbeer het nog eens")
            Dim TopForm As New dlgNewBlok
            TopForm.Text = "Nieuwe blok toevoegen"
            TopForm.Adviseur = SelectedAdviseur
            TopForm.ShowDialog()
            FillBoekingen()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btEditBlok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditBlok.Click
        Try
            OpenBoekingen()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btAddBlok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddBlok.Click
        Try
            NieuwBlokToolStripMenuItem_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btDeleteBlok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDeleteBlok.Click
        Try

            Dim Blok2Delete As New Blok(Me.dgvBlokken.SelectedRows(0).Cells("Id").Value, Blok.Via.ID)
            Dim dlgRes As DialogResult
            dlgRes = MessageBox.Show("Weet u zeker het blok van " & vbCrLf & _
                                     Blok2Delete.AdviseurNaam & " op " & Blok2Delete.datum & _
                                     " in " & Blok2Delete.LocatieNaam & " wilt verwijderen?" _
                                     , "LET OP!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRes = DialogResult.Yes Then
                Blok2Delete.Remove()
                FillBoekingen()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub dgvBlokken_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBlokken.CellClick
    '    Try
    '        Dim gr As New DataGridView
    '        gr = sender
    '        Select Case e.ColumnIndex
    '            Case Is > -1
    '                Select Case gr.Columns(e.ColumnIndex).Name.ToLower
    '                    Case "delete1", "delete"
    '                        Dim Blok2Delete As New Blok(Me.dgvBlokken.SelectedRows(0).Cells("Id").Value, Blok.Via.ID)
    '                        Dim dlgRes As DialogResult
    '                        dlgRes = MessageBox.Show("Weet u zeker het blok van " & vbCrLf & _
    '                                                 Blok2Delete.AdviseurNaam & " op " & Blok2Delete.datum & _
    '                                                 " in " & Blok2Delete.LocatieNaam & " wilt verwijderen?" _
    '                                                 , "LET OP!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                        If dlgRes = DialogResult.Yes Then
    '                            Blok2Delete.Remove()
    '                            FillBoekingen()
    '                        End If
    '                End Select
    '        End Select
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub dgvBlokken_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBlokken.DoubleClick
        Try
            OpenBoekingen()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvBlokken_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBlokken.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvBlokken_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBlokken.KeyUp
        Try
            If e.KeyData = Keys.Enter Then
                OpenBoekingen()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkShowDummies_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowDummies.CheckedChanged
        Try
            If Not lvAdviseurs.SelectedItems.Count = 0 Then
                FillBoekingen()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub dgvBlokken_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBlokken.CellContentClick

    '    dgvBlokken.Sort(dgvBlokken.Columns(1), ListSortDirection.Ascending)

    'End Sub
End Class