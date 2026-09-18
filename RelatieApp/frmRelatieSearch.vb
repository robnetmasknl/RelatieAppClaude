Imports BusinessObjects
Imports System.ComponentModel
Imports System.Management


Public Class frmRelatieSearch
    Public status As Integer = 0
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    Public Sub New(Optional ByVal _status As Integer = 0)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        status = _status
    End Sub

    Enum eStatus
        Actief
        Nonactief
        voorportaal
    End Enum

    Private Sub btnLidId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLidId.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim _Leden As New RelatiesSearch(status)

            dgvLeden.DataSource = _Leden.LikeNr(tbLidId.Text, RelatiesSearch.eSearchOption.LidId)
            dgvLeden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'tbLidId.Text = ""

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmRelatieSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If CreateDefaultLabels Then CreateLabelXml(Me, Me.Name, True)
        If CreateDefaultLabels Then CreateLabelXml(dgvLeden, Me.Name, False)

        GetLabelText(Me, Me.Name)
        GetHeaderText(dgvLeden, Me.Name)

        rbAchternaam.Checked = True
        dgvLeden.AutoGenerateColumns = False

        If My.User.Name.ToUpper = "NETMASK\BERT" Then
            Me.tbZoekveld.Text = "moll"
            grpAdmin.Visible = True
            ' dgvLeden.Columns("id").Visible = True
        ElseIf URights.UserName.ToUpper = "RKO" Then
            grpAdmin.Visible = True
            ' dgvLeden.Columns("id").Visible = True
        Else
            grpAdmin.Visible = False
        End If

        'Dim i As Integer = 0
        'For Each col As DataGridViewTextBoxColumn In dgvLeden.Columns
        '    i += 1
        '    col.HeaderText = GetHeaderText(col, Me.Name)

        'Next

        If status > 0 Then
            Select Case status
                Case 1
                    Me.BackColor = Color.CornflowerBlue 'BMO aangepast bug 1325
                Case 2
                    Me.BackColor = Color.Beige 'BMO aangepast bug 1325
            End Select

            Dim MyEnumVal As eStatus
            MyEnumVal = CType(status, eStatus)
            Me.Text = "Relaties zoeken in " & MyEnumVal.ToString
        End If

    End Sub
    Private Sub FillCmbPlaats()
        Dim dtPlaatsen As DataTable = da.ExecuteDataTable("SELECT distinct plaats FROM Relaties ORDER BY plaats")

        Dim dr As DataRow
        dr = dtPlaatsen.NewRow
        dr("plaats") = "Selecteer een plaats."
        dtPlaatsen.Rows.Add(dr)
        cmbPlaats.DataSource = dtPlaatsen
        cmbPlaats.DisplayMember = "plaats"
        cmbPlaats.ValueMember = "plaats"
        cmbPlaats.SelectedValue = 0
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim _Leden As New RelatiesSearch(status)
            tbZoekveld.Text = tbZoekveld.Text.TrimEnd

            If rbAchternaam.Checked Then
                dgvLeden.DataSource = _Leden.ByNAME(tbZoekveld.Text)
            ElseIf rbLidNr.Checked Then
                dgvLeden.DataSource = _Leden.LikeNr(tbZoekveld.Text, RelatiesSearch.eSearchOption.LidNr)
            ElseIf rbNaamPc.Checked Then
                Dim pc As String = tbHuisNr.Text.Trim
                If String.IsNullOrEmpty(pc) Then
                    Throw New Exception("U heeft gekozen voor zoeken op postcode," & vbCrLf & "maar nog geen postcode opgegeven.")
                End If
                dgvLeden.DataSource = _Leden.ByNAME_PC(tbZoekveld.Text, pc)
            ElseIf rbPCHuisNr.Checked Then
                Dim postcode As String = tbZoekveld.Text.Trim
                If String.IsNullOrEmpty(postcode) Then
                    Throw New Exception("U heeft gekozen voor zoeken op postcode," & vbCrLf & "maar nog geen postcode opgegeven.")
                End If
                dgvLeden.DataSource = _Leden.ByHuisNr_PC(tbHuisNr.Text, postcode)
            ElseIf rbRegNr.Checked Then
                dgvLeden.DataSource = _Leden.LikeNr(tbZoekveld.Text, RelatiesSearch.eSearchOption.RegNr)
            ElseIf rbRekNr.Checked Then
                dgvLeden.DataSource = _Leden.LikeNr(tbZoekveld.Text, RelatiesSearch.eSearchOption.RekNr)
            ElseIf rbPlaats.Checked Then
                dgvLeden.DataSource = _Leden.LikeNr(tbZoekveld.Text & ";" & cmbPlaats.SelectedValue, RelatiesSearch.eSearchOption.Plaats)
            End If

            dgvLeden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Event ColumnHeaderMouseClick As DataGridViewCellMouseEventHandler

    Public Sub OpenFrmLid()
        Try
            Dim ChildForm As New frmRelatie(Me.dgvLeden.SelectedRows(0).Cells("id").Value)
            ChildForm.MdiParent = Main
            'ChildForm.WindowState = FormWindowState.Maximized
            ChildForm.Show()
            Try ' workarround omdat het VBM icon niet zichtbaar wordt in de menubalk.
                If TypeName(Main.MenuStrip.Items(0)) = "SystemMenuItem" Then
                    Dim t As Long
                    t = Main.MenuStrip.Height
                    Main.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                    Main.MenuStrip.Height = t
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
            'Throw ex
            MessageBox.Show(ex.Message, "OpenFrmLid", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLeden_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLeden.DataSourceChanged
        tssSearch1.Text = "aantal gevonden resultaten: " & dgvLeden.RowCount - 1
    End Sub

    Private Sub dgvLeden_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLeden.DoubleClick
        Try
            'If Not Owner Is Nothing AndAlso Owner.Name = "frmBoekingen" Then
            '    Me.DialogResult = Windows.Forms.DialogResult.OK
            '    Me.Close()
            '    Exit Try
            'End If

            OpenFrmLid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "dgvLeden_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLeden_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLeden.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dgvLeden_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub dgvLeden_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLeden.KeyUp
        Try
            If e.KeyData = Keys.Enter Then
                If Not Owner Is Nothing AndAlso Owner.Name = "frmBoekingen" Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                    Exit Try
                End If

                OpenFrmLid()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        Try
            Dim ChildForm As New frmRelatie
            ChildForm.MdiParent = Main
            ChildForm.WindowState = FormWindowState.Maximized

            ChildForm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub radioChanged()
        If rbAchternaam.Checked Then
            lbSearch.Text = "Naam:"
        ElseIf rbNaamPc.Checked Then
            lbSearch.Text = "Naam:"
        ElseIf rbPCHuisNr.Checked Then
            lbSearch.Text = "Postcode:"
        ElseIf rbPlaats.Checked Then
            lbSearch.Text = "Naam:"
        ElseIf rbLidNr.Checked Then
            lbSearch.Text = "werknemernr:"
        ElseIf rbRegNr.Checked Then
            lbSearch.Text = "Reg.nummer:"
        ElseIf rbRekNr.Checked Then
            lbSearch.Text = "Rek.nummer:"

        End If
    End Sub
    Private Sub rbNaamPc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNaamPc.CheckedChanged
        Try
            lbPC.Visible = rbNaamPc.Checked
            tbHuisNr.Visible = rbNaamPc.Checked
            If Not rbNaamPc.Checked Then
                tbHuisNr.Text = ""
                lbPC.Text = "Huisnr:"
            Else
                lbPC.Text = "Postcode"
            End If
            radioChanged()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbAchternaam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAchternaam.CheckedChanged
        radioChanged()
    End Sub
    Private Sub rbPCHuisNr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPCHuisNr.CheckedChanged
        Try
            lbPC.Visible = rbPCHuisNr.Checked
            tbHuisNr.Visible = rbPCHuisNr.Checked
            If rbPCHuisNr.Checked Then
                lbSearch.Text = "Postcode"
            Else
                lbSearch.Text = "Zoekveld"
            End If
            If Not rbPCHuisNr.Checked Then
                tbHuisNr.Text = ""
            End If
            radioChanged()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub rbPlaats_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPlaats.CheckedChanged
        Try
            lbPC.Visible = False
            tbHuisNr.Visible = False

            lbPlaats.Visible = rbPlaats.Checked
            cmbPlaats.Visible = rbPlaats.Checked
            If rbPlaats.Checked Then
                FillCmbPlaats()
                tbHuisNr.Text = ""
                lbSearch.Text = "Naam"
            Else
                lbSearch.Text = "Zoekveld"
            End If
            radioChanged()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub rbRekNr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRekNr.CheckedChanged
        radioChanged()
    End Sub

    Private Sub rbRegNr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRegNr.CheckedChanged
        radioChanged()
    End Sub

    Private Sub rbLidNr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLidNr.CheckedChanged
        radioChanged()
    End Sub

    Private Sub btnSignal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignal.Click
        Try
            ' SearchIndex("agip")
            Dim myUtils As New Utilities
            Dim dt As DataTable = myUtils.SignaleringList
            ' MessageBox.Show(dt.Rows.Count)
            dgvLeden.DataSource = dt
            dgvLeden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SearchIndex(ByVal value)
        'Dim LateBoundObject As ManagementObject
        'LateBoundObject = New ManagementObject(Nothing, New ManagementPath("\\nertmdc03\root\CIMV2:Win32_Service.Name=""CiSvc"""), Nothing)
        'MessageBox.Show(CType(LateBoundObject("caption"), String))
        'LateBoundObject.Dispose()

        Dim MyQuery As String = "SELECT * FROM Win32_PrintJob"
        Using MyManagementObjectSearcher As New ManagementObjectSearcher(MyQuery)
            Using MyManagementObjectCollection As ManagementObjectCollection = MyManagementObjectSearcher.[Get]()
                For Each MyManagementObject As ManagementObject In MyManagementObjectCollection
                    Console.WriteLine(MyManagementObject("JobID"))
                Next
            End Using
        End Using

    End Sub

 
    Private Sub tbZoekveld_TextChanged(sender As Object, e As EventArgs) Handles tbZoekveld.TextChanged
        If rbNaamPc.Checked Or rbRegNr.Checked Or rbPCHuisNr.Checked Or rbRekNr.Checked Or rbRekNr.Checked Then

        Else
            If tbZoekveld.Text.Length = 1 Then
                If IsNumeric(tbZoekveld.Text) Then rbLidNr.Checked = True
                If IsAlphabet(tbZoekveld.Text) Then rbAchternaam.Checked = True
            End If
        End If

    End Sub


End Class