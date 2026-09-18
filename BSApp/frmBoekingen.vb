Imports BusinessObjects
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles

Public Class frmBoekingen
    Private Utils As New Utilities
    Private _blokid As Integer = 0
    Private _newBoeking As Boeking
    Private _SelectedBlok As Blok
    Private _relatie As Lidmaat
    Public Sub New(ByVal id As Integer)

        InitializeComponent()
        _blokid = id

    End Sub
    Public Sub New()
        InitializeComponent()

    End Sub

    Public Event BoekingClosing(ByVal Message As String)

    Private Sub frmBoekingen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            RaiseEvent BoekingClosing(_newBoeking.LidNaam)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub frmBoekingen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dgvBoekingen.AutoGenerateColumns = False

            FillBoekingen()

            'AddHandler tbLidNr.Validating, AddressOf Utils.ValidNummeriek

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillBoekingen()
        Try
            _SelectedBlok = New Blok(_blokid, Blok.Via.ID)
            dgvBoekingen.DataSource = _SelectedBlok.Boekingen
            Me.Text = "boekingen voor " & _SelectedBlok.AdviseurNaam & " op locatie " & _SelectedBlok.LocatieNaam
            Me.lblAdviseur.Text = "Nieuwe boeking bij adviseur " & _SelectedBlok.AdviseurNaam & " op locatie " & _SelectedBlok.LocatieNaam

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OpenFrmLid()
        Try
            If dgvBoekingen.ContainsFocus Then
                If dgvBoekingen.SelectedRows.Count > 0 Then
                    If Me.dgvBoekingen.SelectedRows(0).Cells("relatieId").Value <> "0" Then
                        Dim ChildForm As New frmLid(Me.dgvBoekingen.SelectedRows(0).Cells("relatieId").Value)
                        ChildForm.MdiParent = MainForm
                        ChildForm.WindowState = FormWindowState.Maximized
                        ChildForm.Show()
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private _DummyValue As String
    Public ReadOnly Property DummyValue() As String
        Get
            If _DummyValue Is Nothing Then
                Dim sys As New Systeeminstellingen("DummyNr", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _DummyValue = sys.Waarde
            End If

            Return _DummyValue
        End Get
    End Property
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If _newBoeking Is Nothing Then Throw New Exception("U heeft nog geen boekingsregel geselecteerd!")
            If String.IsNullOrEmpty(tbRelatieId.Text) Or tbRelatieId.Text = "0" Then Throw New Exception("U heeft nog geen lidmaatschapnr opgegeven!")

            'BMO	bug 1242: Check of tel/mob is gevuld
            If tbLidNr.Text <> DummyValue Then
                Dim lid As New Lidmaat(tbRelatieId.Text, Lidmaat.Via.ID)
                If lid.Found Then
                    If String.IsNullOrEmpty(lid.b_mobiel) AndAlso String.IsNullOrEmpty(lid.b_telefoon) Then
                        Dim _message As String = lid.FullName & " heeft nog geen telefoonnummer opgegeven. "
                        Dim ChildForm As New frmLid(tbRelatieId.Text)
                        If Not String.IsNullOrEmpty(lid.mobiel) Then
                            ChildForm.lid.b_mobiel = lid.mobiel
                            ChildForm.tbMobiel_b.ForeColor = Color.Red
                            ChildForm.lblmobileError.ForeColor = Color.Red
                        End If

                        ChildForm.lblmobileError.Visible = True
                        ChildForm.Text = _message
                        ChildForm.MdiParent = MainForm
                        ChildForm.WindowState = FormWindowState.Maximized
                        ChildForm.Show()
                        Exit Try
                    End If
                End If
            End If

            'Dim tryBoeking As New Boeking(tbRelatieId.Text, Boeking.Via.RELID)
            'If tryBoeking.Found Then
            '    If tryBoeking.lidnr <> tryBoeking.DummyValue Then
            '        Dim _message As String = tryBoeking.LidNaam & " heeft al een boeking op " & tryBoeking.tijdstip.ToLongDateString & " om " & tryBoeking.tijdstip.ToLongTimeString
            '        MessageBox.Show(_message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        tryBoeking = Nothing
            '        Exit Try
            '    End If
            'End If

            With _newBoeking
                '.lidnr = tbLidNr.Text
                .relatieId = tbRelatieId.Text
                .tijdstip = dtpAanvang.Value
                .blokId = _SelectedBlok.Id
                .voorlopig = False
                If Not String.IsNullOrEmpty(.IfExistLidBoeking) Then Throw New Exception(.IfExistLidBoeking)
                .Save()
            End With

            _SelectedBlok = New Blok(_blokid, Blok.Via.ID)
            FillBoekingen()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvBoekingen_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBoekingen.CellClick
        Try
            Dim gr As New DataGridView
            gr = sender
            Select Case e.RowIndex
                Case Is > -1
                    If gr.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText.ToLower = "disabled" Then
                        Exit Sub
                    End If
            End Select

            Select Case e.ColumnIndex
                Case Is > -1
                    Select Case gr.Columns(e.ColumnIndex).Name.ToLower
                        Case "delete"
                            Dim Boeking2Delete As New Boeking(Me.dgvBoekingen.SelectedRows(0).Cells("Id").Value, Boeking.Via.ID)
                            If Boeking2Delete.relatieId = 0 Then _
                                    Throw New Exception("Er kunnen geen basis regels verwijderd worden!")

                            Dim dlgRes As DialogResult = MessageBox.Show("Weet u zeker de boeking van " & vbCrLf & _
                                        Boeking2Delete.LidNaam & " wilt verwijderen?", "LET OP!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If dlgRes = DialogResult.Yes Then
                                ' Boeking2Delete.lidnr = "0"
                                Boeking2Delete.relatieId = 0
                                Boeking2Delete.voorlopig = True
                                Boeking2Delete.Save()
                                FillBoekingen()
                            End If
                    End Select
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvBoekingen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBoekingen.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvBoekingen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBoekingen.DoubleClick
        Try
            OpenFrmLid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvBoekingen_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBoekingen.SelectionChanged
        Try
            'If dgvBoekingen.ContainsFocus Then
            If dgvBoekingen.SelectedRows.Count > 0 Then
                Dim _id As String = Me.dgvBoekingen.SelectedRows(0).Cells("Id").Value
                If Not String.IsNullOrEmpty(_id) Then
                    _newBoeking = New Boeking(_id, Boeking.Via.ID)
                    Me.dtpDatum.Value = _newBoeking.tijdstip.ToShortDateString
                    Me.dtpAanvang.Value = _newBoeking.tijdstip
                    'tbLidNr.Text = _newBoeking.lidnr
                End If
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChangeAdv_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSearch.Click
        Try
            Dim frmLeden As New frmLeden
            frmLeden.btOk.Visible = True
            frmLeden.Owner = Me
            frmLeden.Width = 850
            frmLeden.Height = 400
            frmLeden.StartPosition = FormStartPosition.CenterParent
            frmLeden.ShowDialog()
            If frmLeden.DialogResult = Windows.Forms.DialogResult.OK Then
                If frmLeden.dgvLeden.SelectedRows.Count > 0 Then
                    tbLidNr.Text = frmLeden.dgvLeden.SelectedRows(0).Cells("lidnr").Value
                    tbRelatieId.Text = frmLeden.dgvLeden.SelectedRows(0).Cells("relid").Value
                Else
                    tbLidNr.Text = ""
                    tbRelatieId.Text = ""
                End If
            End If
            Dim result As String = frmLeden.DialogResult

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvBoekingen_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvBoekingen.DataBindingComplete
        Try
            For Each rw As DataGridViewRow In dgvBoekingen.Rows
                If rw.Cells("Tijdstip").Value = _SelectedBlok.VolgendeTijdstip Then
                    rw.DefaultCellStyle.BackColor = Color.LightGreen
                    dgvBoekingen.Item(0, rw.Index).Selected = True
                    Me.dtpDatum.Value = rw.Cells("Tijdstip").Value.ToShortDateString
                    Me.dtpAanvang.Value = rw.Cells("Tijdstip").Value
                End If
                If rw.Cells("lidnr").Value = "0" Then
                    Dim buttonCell As DataGridViewDisableButtonCell = _
                                       CType(dgvBoekingen.Rows(rw.Index).Cells("delete"),  _
                                       DataGridViewDisableButtonCell)
                    buttonCell.Enabled = False
                    buttonCell.Value = Nothing
                    buttonCell.ErrorText = "disabled"
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tsbBrief_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBrief.Click
        Try
            If dgvBoekingen.SelectedRows.Count > 0 AndAlso Me.dgvBoekingen.SelectedRows(0).Cells("lidnr").Value <> "0" Then

                Dim lid As New Lidmaat(dgvBoekingen.SelectedRows(0).Cells("lidnr").Value, Lidmaat.Via.LIDNR)

                Dim MyLocatie As New Locaties(lid.CurrentBoeking.Blok.locatieid)
                Dim sys As Systeeminstellingen = Nothing

                If MyLocatie.Offline = True Then
                    sys = New Systeeminstellingen("BevestigingtemplateMachtiging", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                Else
                    sys = New Systeeminstellingen("Bevestigingtemplate", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                End If

                If Not sys.Found Then
                    Throw New Exception("geen gegevens voor template! controleer systeeminstellingen!")
                End If

                Dim newWord As New OfficeObjects.WordMerge
                newWord.CurrentDr = lid.ExportRow
                newWord.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\mailing.txt"
                newWord.WordMergeBelasting(sys.Waarde)

            Else
                Throw New Exception("U heeft nog geen boeking geselecteerd of een boeking zonder ledennummer!")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub tsbAdviseurAanpassen_Click(sender As Object, e As EventArgs) Handles tsbAdviseurAanpassen.Click
        Dim OriginalID As Integer = -1
        Try
            OriginalID = _SelectedBlok.adviseurid
            Dim TopForm As New dlgAdviseurs
            TopForm.Text = "selecteer Adviseur"
            Dim result As DialogResult = TopForm.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                _SelectedBlok.adviseurid = TopForm.cmbAdviseurs.SelectedItem.id

                'Controleer of de adviseur al ergens op die datum aanwezig is.
                Dim ValidateBlokLijst As New BlokkenLijst
                ValidateBlokLijst._AdviseurId = _SelectedBlok.adviseurid
                For Each blokje As Blok In ValidateBlokLijst.ByAdviseur
                    If blokje.datum = _SelectedBlok.datum Then Throw New Exception(blokje.AdviseurNaam & " kan niet op 2 plekken tegelijk zijn!")
                Next

                _SelectedBlok.Save()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            _SelectedBlok.adviseurid = OriginalID
        End Try
    End Sub

    Private Sub tsbRefresh_Click(sender As Object, e As EventArgs) Handles tsbRefresh.Click
        FillBoekingen()
    End Sub
End Class