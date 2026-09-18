Imports BusinessObjects
Imports System.Data.SqlClient

Public Class MaintenanceStd
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess
    Private cmd As SqlCommand
    Private adp As SqlDataAdapter
    Private ds As DataSet
    Public Maintain As String = ""
    Public MaintainText As String = ""
    Public CreateLabels As Boolean = CreateDefaultLabels

    Public Sub New(ByVal _Maintain As String, ByVal _MaintainText As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.CenterToParent()
        ' Add any initialization after the InitializeComponent() call.
        MaintainText = _MaintainText
        Maintain = _Maintain.ToLower
        Me.Text = "Onderhoud " & MaintainText
    End Sub

    Private Sub MaintenanceStd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim AllowIBBGroups() As Object = {"rel_ibb_users", "rel_admins", "rel_ibb_admins"}

            'CreateLabels = True

            If URights.IsMemberOfOne(AllowIBBGroups) And Maintain = "ibbgroepen" Then
                ProcessIbbGroepen()
                tb1.Visible = False
                Exit Sub
            End If

            If URights.IsInGroup("rel_admins") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''rel_admins''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            Select Case Maintain
                Case "lidsoorten"
                    ProcessLidSoorten()
                Case "bonden"
                    ProcessBonden()
                Case "dienstvakken"
                    ProcessDienstVakken()
                Case "contributie"
                    ProcessContributie()
                Case "kmonderdelen"
                    ProcessKmOnderdelen()
                Case "plaatsingen"
                    ProcessPlaatsingen()
                Case "rangen"
                    ProcessRangen()
                Case "contr_instanties"
                    ProcessContr_Instanties()
                Case "functies"
                    ProcessFuncties()
                Case "behandelaren"
                    ProcessBehandelaren()
                Case "systeeminstellingen"
                    btnEncrypt.Visible = True
                    ProcessSysteemInstellingen()
                Case "fadvies"
                    ProcessAdvies()
                Case "rubrieken"
                    ProcessRubrieken()
                Case Else
                    Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProcessAdvies()
        Try
            Dim sql As String = "SELECT * FROM fadvies ORDER BY Omschrijving"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            dgvMaintenance.Columns("id").Visible = False

            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvMaintenance.AllowUserToAddRows = False
            dgvMaintenanceRefresh()
            btAdd.Visible = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessRubrieken()
        Try

            Dim sql As String = "SELECT * FROM IBBRubrieken ORDER BY Rubriek"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            dgvMaintenance.Columns("id").Visible = False
            'dgvMaintenance.Columns("id").ReadOnly = True
            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ProcessSysteemInstellingen()
        Try

            Dim sql As String = "SELECT * FROM systeeminstellingen ORDER BY zoeknaam"

            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            dgvMaintenance.Columns("id").Visible = False

            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessBonden()
        Try
            Dim sql As String = "SELECT * FROM Bonden ORDER BY Omschrijving"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            dgvMaintenance.Columns("id").Visible = False

            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvMaintenance.AllowUserToAddRows = False
            dgvMaintenanceRefresh()
            btAdd.Visible = True

            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessFuncties()
        Try
            Dim sql As String = "SELECT * FROM fsoort ORDER BY Omschrijving"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            'Dim col As New DataGridViewButtonColumn
            'col.DataPropertyName = "Kleur"
            'col.Name = "Kleur"
            'dgvMaintenance.Columns.Add(col)
            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            dgvMaintenance.Columns("id").Visible = False

            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvMaintenance.AllowUserToAddRows = False
            dgvMaintenanceRefresh()
            btAdd.Visible = True

            'Deze headers mogen niet aangepast worden.
            'If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain)
            'GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessContributie()
        Try

            Dim lidsoorten As DataTable = da.ExecuteDataTable("SELECT * FROM lidsoorten ORDER BY Omschrijving")

            Dim cmbLidsoorten As New DataGridViewComboBoxColumn
            cmbLidsoorten.DataSource = lidsoorten
            cmbLidsoorten.DisplayMember = "Omschrijving"
            cmbLidsoorten.ValueMember = "id"
            cmbLidsoorten.DataPropertyName = "lidsoortid"
            cmbLidsoorten.HeaderText = "lidsoort"

            Dim col As New CalendarColumn()
            col.DataPropertyName = "sedert"
            col.Name = "sedert"

            Dim sql As String = "SELECT * FROM Contributie ORDER BY lidsoortid,sedert"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, "Contributie")

            With dgvMaintenance
                .Columns.Add(cmbLidsoorten)
                .Columns.Add(col)

                .DataSource = ds
                .DataMember = "Contributie"
                .Columns("id").Visible = False
                .Columns("sedert").HeaderText = "ingangsdatum "
                .Columns("mbedrag").HeaderText = "maand bedrag"
                .Columns("obedrag").HeaderText = "oude bedrag"
                .Columns("mkorting").HeaderText = "maand korting"
                .Columns("okorting").HeaderText = "oude korting"
            End With
            '' Deze mag niet aangepast worden
            'If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessLidSoorten()
        Try
            Dim sql As String = "SELECT * FROM lidsoorten ORDER BY Omschrijving"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            dgvMaintenance.Columns("id").Visible = False
            'dgvContributies.Columns("sedert").HeaderText = "ingangsdatum "
            'dgvContributies.Columns("mbedrag").HeaderText = "maand bedrag"
            'dgvContributies.Columns("obedrag").HeaderText = "oude bedrag"
            'dgvContributies.Columns("mkorting").HeaderText = "maand korting"
            'dgvContributies.Columns("okorting").HeaderText = "oude korting"

            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessDienstVakken()
        Try

            Dim sql As String = "SELECT * FROM dienstvakken ORDER BY dienstvak"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            'dgvMaintenance.Columns("id").Visible = False
            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessKmOnderdelen()
        Try

            Dim sql As String = "SELECT * FROM kmonderdelen ORDER BY  kmonderdeel"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            'dgvMaintenance.Columns("id").Visible = False
            'dgvMaintenance.Columns("id").ReadOnly = True
            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessPlaatsingen()
        Try

            Dim sql As String = "SELECT * FROM Plaatsingen ORDER BY Plaatsing"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            'dgvMaintenance.Columns("id").Visible = False
            'dgvMaintenance.Columns("id").ReadOnly = True
            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessRangen()
        Try

            Dim sql As String = "SELECT * FROM rangen ORDER BY Rang"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            'dgvMaintenance.Columns("id").Visible = False
            'dgvMaintenance.Columns("id").ReadOnly = True
            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessContr_Instanties()
        Try

            Dim sql As String = "SELECT * FROM Contr_Instanties ORDER BY naam"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            'dgvMaintenance.Columns("id").ReadOnly = True
            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProcessBehandelaren()
        Try

            Dim sql As String = "SELECT * FROM Behandelaren"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            'dgvMaintenance.Columns("id").ReadOnly = True
            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessIbbGroepen()
        Try

            Dim sql As String = "SELECT * FROM IBBGroepen"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)

            dgvMaintenance.DataSource = ds
            dgvMaintenance.DataMember = Maintain
            dgvMaintenance.Columns("id").ReadOnly = True

            If CreateLabels Then CreateLabelXml(dgvMaintenance, Me.Name + "_" + Maintain, True)
            GetHeaderText(dgvMaintenance, Me.Name + "_" + Maintain)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim cmdbuilder As New SqlCommandBuilder(adp)
            Dim i As Integer
            i = adp.Update(ds, Maintain)
            MessageBox.Show("Aantal geupdate: " & i, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SelectNextRow(ByVal idx As Integer)
        Try
            If idx + 1 >= dgvMaintenance.Rows.Count Then
                dgvMaintenance.CurrentCell = dgvMaintenance.Rows(0).Cells(3)
            Else
                dgvMaintenance.CurrentCell = dgvMaintenance.Rows(idx + 1).Cells(3)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvMaintenanceRefresh()
        For Each rw As DataGridViewRow In dgvMaintenance.Rows
            If Maintain.ToUpper = "FUNCTIES" Then
                Try
                    If rw.Cells("colorargb").Value IsNot DBNull.Value Then
                        rw.DefaultCellStyle.BackColor = Color.FromArgb(rw.Cells("colorargb").Value)
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        Next
        dgvMaintenance.Refresh()
    End Sub

    Private Sub dgvMaintenance_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMaintenance.DoubleClick
        Try
            If Maintain.ToUpper = "FUNCTIES" Then
                Dim dlg As New dlgFunctieMaintenance
                dlg.tbSoort.Text = dgvMaintenance.SelectedRows(0).Cells("Soort").Value
                dlg.tbDescription.Text = dgvMaintenance.SelectedRows(0).Cells("omschrijving").Value
                dlg.tbColor.Text = dgvMaintenance.SelectedRows(0).Cells("colorargb").Value
                dlg.ShowDialog()
                If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    dgvMaintenance.SelectedRows(0).Cells("Soort").Value = dlg.tbSoort.Text
                    dgvMaintenance.SelectedRows(0).Cells("omschrijving").Value = dlg.tbDescription.Text
                    dgvMaintenance.SelectedRows(0).Cells("colorargb").Value = dlg.tbColor.Text
                    SelectNextRow(dgvMaintenance.SelectedRows(0).Index)
                    btnSave_Click(sender, New EventArgs)
                    dgvMaintenanceRefresh()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Private Sub dgvMaintenance_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMaintenance.CellClick
    '    Try
    '        Dim gr As New DataGridView
    '        gr = sender

    '        If e.RowIndex > 0 And e.ColumnIndex >= 0 Then
    '            If TypeOf (gr.Rows(e.RowIndex).Cells(e.ColumnIndex)).OwningColumn Is DataGridViewButtonColumn Then
    '                If gr.Rows(e.RowIndex).Cells(2).Value.ToString = "" Then
    '                    MessageBox.Show("Vul eerst gegevens in en daarna de kleur bepalen!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Exit Sub
    '                Else
    '                    With Me.ColorDialog1
    '                        .Reset()
    '                        If .ShowDialog() = DialogResult.OK Then
    '                            gr.Rows(e.RowIndex).Cells("colorargb").Value = ColorDialog1.Color.ToArgb
    '                            SelectNextRow(e.RowIndex)
    '                            btnSave_Click(sender, New EventArgs)
    '                        End If
    '                        dgvMaintenanceRefresh()
    '                    End With
    '                End If
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub dgvMaintenance_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvMaintenance.RowsRemoved
        If e.RowIndex > 0 Then
            If ds.HasChanges Then
                'Dim dtDeleted As DataTable = ds.Tables(Maintain).GetChanges(DataRowState.Deleted)

                dgvMaintenance.Rows(dgvMaintenance.Rows.Count - 1).Selected = True
                btnSave_Click(sender, New EventArgs)
                dgvMaintenanceRefresh()
            End If

        End If
    End Sub

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        Try
            If Maintain.ToUpper = "FUNCTIES" Then
                Dim dlg As New dlgFunctieMaintenance
                dlg.ShowDialog()
                If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    Dim row As DataRow = ds.Tables(0).NewRow
                    row("Id") = da.ExecuteScalar("select max(Id) FROM fsoort") + 1
                    row("Soort") = dlg.tbSoort.Text
                    row("omschrijving") = dlg.tbDescription.Text
                    row("colorargb") = dlg.tbColor.Text
                    ds.Tables(0).Rows.Add(row)
                    btnSave_Click(sender, New EventArgs)
                    dgvMaintenanceRefresh()
                End If
            ElseIf Maintain.ToUpper = "FADVIES" Then
                Dim dlg As New dlgFunctieMaintenance
                With dlg
                    .Text = "toevoegen"
                    .Label1.Text = "Naam"
                    .tbColor.Visible = False
                    .Label3.Visible = False
                    .btColor.Visible = False
                    .ShowDialog()
                End With

                If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    Dim row As DataRow = ds.Tables(0).NewRow
                    row("Id") = da.ExecuteScalar("select max(Id) FROM fadvies") + 1
                    row("naam") = dlg.tbSoort.Text
                    row("omschrijving") = dlg.tbDescription.Text
                    ds.Tables(0).Rows.Add(row)
                    btnSave_Click(sender, New EventArgs)
                    dgvMaintenanceRefresh()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        Try
            Dim pw As String = tb1.Text
            tb1.Text = CryptoService.Encrypt(pw)
            tb1.PasswordChar = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tb1_TextChanged(sender As Object, e As EventArgs) Handles tb1.TextChanged
        tb1.PasswordChar = "*"
    End Sub
End Class