Imports BusinessObjects
Imports System.Text
Imports OfficeObjects

Public Class frmlocaties
    Private Selectedlocatie As Locaties

    Private WithEvents frmBoeking As frmBoekingen
    Public Sub ChangeCompleteHandler(ByVal _message As String) Handles frmBoeking.BoekingClosing
        FillBlokken()
    End Sub

    Private Sub frmlocaties_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dgvBlokken.AutoGenerateColumns = False
            FillListViewLocaties()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FillListViewLocaties()
        Try
            lvLocaties.Clear()

            lvLocaties.Columns.Add("Naam", 150, HorizontalAlignment.Left)
            lvLocaties.Columns.Add("Blokken", 25, HorizontalAlignment.Left)
            lvLocaties.Columns.Add("id", 0, HorizontalAlignment.Left)
            lvLocaties.View = View.Details
            lvLocaties.StateImageList = ImageList1

            Dim lstViewItem As ListViewItem = New ListViewItem()
            Dim _Locaties As New Locaties
            For Each loc As Locaties In _Locaties.Lijst
                lstViewItem = New ListViewItem()
                lstViewItem.Text = loc.Locatie
                If loc.Blokken.Count > 0 Then
                    lstViewItem.StateImageIndex = 0
                Else
                    lstViewItem.StateImageIndex = 1
                End If
                lstViewItem.SubItems.Add(loc.Blokken.Count)
                lstViewItem.SubItems.Add(loc.Id)
                lstViewItem.Name = loc.Locatie
                lvLocaties.Items.Add(lstViewItem)
            Next
            lstViewItem = New ListViewItem()
            lstViewItem.Text = "Nieuwe locatie toevoegen"
            lstViewItem.SubItems.Add("0")
            lstViewItem.SubItems.Add("0")
            lvLocaties.Items.Add(lstViewItem)
            lvLocaties.EnsureVisible(lvLocaties.Items.Count - 1)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillBlokken(Optional ByVal SelectedCol As String = "")
        Try
            dgvBlokken.DataSource = Nothing
            Selectedlocatie = New Locaties(Selectedlocatie.Id)

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
                Case "AdviseurNaam"
                    Dim sortedList = From entry In Selectedlocatie.Blokken Order By entry.AdviseurNaam Ascending Select entry
                    Dim list = sortedList.ToList
                    dgvBlokken.DataSource = list
                Case "Datum"
                    Dim sortedList = From entry In Selectedlocatie.Blokken Order By entry.datum Ascending Select entry
                    Dim list = sortedList.ToList
                    dgvBlokken.DataSource = list
                Case "AantalBeschikbaar"
                    Dim sortedList = From entry In Selectedlocatie.Blokken Order By entry.AantalBeschikbaar Ascending Select entry
                    Dim list = sortedList.ToList
                    dgvBlokken.DataSource = list
                Case Else
                    dgvBlokken.DataSource = Selectedlocatie.Blokken
            End Select



            'dgvBlokken.DataSource = Selectedlocatie.Blokken
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
            lblNaam.Text = Selectedlocatie.Locatie
            lblAantalBlokken.Text = Selectedlocatie.AantalBlokken
            lblAantalBoekingen.Text = Selectedlocatie.AantalBoekingen
            lblAantalBeschikbaar.Text = Selectedlocatie.AantalBeschikbaar

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvBlokken_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvBlokken.ColumnHeaderMouseClick

        FillBlokken(dgvBlokken.Columns(e.ColumnIndex).Name)

    End Sub
    Private Sub lvLocaties_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLocaties.SelectedIndexChanged
        Try
            dgvBlokken.DataSource = Nothing
            If Not lvLocaties.SelectedItems.Count = 0 Then
                Dim SelectedItem As Integer = Me.lvLocaties.SelectedItems(0).SubItems(2).Text

                If SelectedItem = 0 Then
                    Dim TopForm As New dlgNewlocatie
                    TopForm.Text = "Nieuwe locatie toevoegen"
                    Dim result As DialogResult = TopForm.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        FillListViewLocaties()
                    End If

                Else
                    Selectedlocatie = New Locaties(SelectedItem)
                    FillBlokken()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub OpenBoekingen()
        Try
            frmBoeking = New frmBoekingen(Me.dgvBlokken.SelectedRows(0).Cells("Id").Value)
            frmBoeking.MdiParent = MainForm
            frmBoeking.WindowState = FormWindowState.Maximized
            frmBoeking.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvBlokken_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBlokken.DoubleClick
        Try
            OpenBoekingen()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvBlokken_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBlokken.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvBlokken_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBlokken.KeyUp
        Try
            If e.KeyData = Keys.Enter Then
                OpenBoekingen()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ContextBewerken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextBewerken.Click
        Try
            If Not lvLocaties.SelectedItems.Count = 0 Then
                Dim SelectedItem As Integer = Me.lvLocaties.SelectedItems(0).SubItems(2).Text

                If SelectedItem > 0 Then
                    Dim TopForm As New dlgNewlocatie
                    TopForm.Text = "Locatie bewerken"
                    TopForm.LocatieId = SelectedItem
                    Dim result As DialogResult = TopForm.ShowDialog()
                    If result = Windows.Forms.DialogResult.OK Then
                        FillListViewLocaties()
                    End If

                Else
                    Selectedlocatie = New Locaties(SelectedItem)
                    FillBlokken()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private _MyDocuments As String = ""
    Public ReadOnly Property MyDocuments() As String
        Get
            If String.IsNullOrEmpty(_MyDocuments) Then
                _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            Return _MyDocuments
        End Get
    End Property
    Private Sub btnPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintList.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim MyLocaties As New Locaties
            Dim sb As New StringBuilder
            Dim sbHeader As New StringBuilder
            Dim bHeader As Boolean = False
            Dim sbDatum As New StringBuilder
            Dim bDatum As Boolean = False
            Dim sbBlok As New StringBuilder
            Dim bBlok As Boolean = False
            Dim SeparationLine As String = ""

            Dim oDatumLijst As BlokkenLijst
            Dim MyDatumLijst As List(Of Blok) = Nothing
            Dim BloksByDate As List(Of Blok) = Nothing
            For Each locatie As Locaties In MyLocaties.Lijst
                bHeader = False
                sbHeader = New StringBuilder
                sbHeader.Append(SeparationLine.PadRight(65, "=") & vbCrLf)
                sbHeader.Append(locatie.Locatie.ToUpper & vbCrLf)
                sbHeader.Append(SeparationLine.PadRight(65, "=") & vbCrLf)
                oDatumLijst = New BlokkenLijst
                MyDatumLijst = New List(Of Blok)
                MyDatumLijst = oDatumLijst.DatumLijstByLocatie(locatie.Id)
                For Each LocatieBlok In MyDatumLijst
                    bDatum = False
                    BloksByDate = New List(Of Blok)
                    BloksByDate = oDatumLijst.GetBlokByLocationDate(LocatieBlok.datum, LocatieBlok.locatieid)
                    sbDatum = New StringBuilder
                    sbDatum.Append("Datum:" & LocatieBlok.datum & vbCrLf)
                    sbDatum.Append("Locatie:" & locatie.Locatie & vbCrLf)
                    sbBlok = New StringBuilder
                    For Each CurrentBlok As Blok In BloksByDate
                        If CurrentBlok.AantalBoekingen > 0 Then
                            bDatum = True
                            sbBlok.Append("Aantal boekingen:" & CurrentBlok.AantalBoekingen & vbCrLf)
                            sbBlok.Append("Aantal totaal:" & CurrentBlok.AantalTotaal & vbCrLf)
                            sbBlok.Append(SeparationLine.PadRight(35, "-") & vbCrLf)
                            sbBlok.Append(vbCrLf)
                            For Each CurrentBoeking As Boeking In CurrentBlok.Boekingen
                                If Not CurrentBoeking.lidnr = "0" Then
                                    sbBlok.Append("tijdstip:" & CurrentBoeking.tijdstip.ToShortTimeString & vbCrLf)
                                    sbBlok.Append("Lidnr:" & CurrentBoeking.lidnr & vbCrLf)
                                    sbBlok.Append("Naam:" & CurrentBoeking.LidNaam & vbCrLf)
                                    sbBlok.Append("Adviseur:" & CurrentBoeking.Blok.AdviseurNaam & vbCrLf)
                                    sbBlok.Append(vbCrLf)
                                End If
                            Next
                        End If

                    Next

                    If bDatum Then
                        If bHeader = False Then
                            sb.Append(vbCrLf & vbCrLf & sbHeader.ToString & vbCrLf)
                            bHeader = True
                        End If
                        sb.Append(sbDatum.ToString)
                        sb.Append(sbBlok.ToString)
                        sb.Append(SeparationLine.PadRight(35, "+") & vbCrLf)
                    End If
                Next
            Next

            WriteFile(MyDocuments & "\boekingen.txt", sb.ToString)
            System.Diagnostics.Process.Start(MyDocuments & "\boekingen.txt")
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkShowDummies_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowDummies.CheckedChanged
        Try
            If Not lvLocaties.SelectedItems.Count = 0 Then
                FillBlokken()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class