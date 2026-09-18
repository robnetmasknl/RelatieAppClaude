Imports BusinessObjects
Imports System.ComponentModel

Public Class frmLeden
    'Private ledenlijst As New List(Of Lidmaat)

    Private Sub frmLeden_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        rbAchternaam.Checked = True
        dgvLeden.AutoGenerateColumns = False

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try

            Dim _Leden As New LedenLijst

            If rbAchternaam.Checked Then
                dgvLeden.DataSource = _Leden.ByNAME(tbZoekveld.Text)
            ElseIf rbLidNr.Checked Then
                dgvLeden.DataSource = _Leden.ByLidNrlike(tbZoekveld.Text)
            ElseIf rbNaamPc.Checked Then
                Dim pc As String = tbPC.Text.Trim
                If String.IsNullOrEmpty(pc) Then
                    Throw New Exception("U heeft gekozen voor zoeken op postcode," & vbCrLf & "maar nog geen postcode opgegeven.")
                End If
                dgvLeden.DataSource = _Leden.ByNAME_PC(tbZoekveld.Text, pc)
            ElseIf rbPCHuisNr.Checked Then
                Dim pc As String = tbPC.Text.Trim
                If String.IsNullOrEmpty(pc) Then
                    Throw New Exception("U heeft gekozen voor zoeken op postcode," & vbCrLf & "maar nog geen postcode opgegeven.")
                End If
                dgvLeden.DataSource = _Leden.ByNR_PC(tbZoekveld.Text, pc)
            End If

            'dgvLeden.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Event ColumnHeaderMouseClick As DataGridViewCellMouseEventHandler

    Private Sub OpenFrmLid()
        Try
            Dim ChildForm As New frmLid(Me.dgvLeden.SelectedRows(0).Cells("relid").Value)
            ChildForm.MdiParent = MainForm
            ChildForm.WindowState = FormWindowState.Maximized

            ChildForm.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
 
    Private Sub dgvLeden_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLeden.DoubleClick
        Try
            If Not Owner Is Nothing AndAlso Owner.Name = "frmBoekingen" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
                Exit Try
            End If

            OpenFrmLid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvLeden_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLeden.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

 
    Private Sub rbNaamPc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNaamPc.CheckedChanged
        Try
            lbPC.Visible = rbNaamPc.Checked
            tbPC.Visible = rbNaamPc.Checked
            If Not rbNaamPc.Checked Then
                tbPC.Text = ""
            End If
            radioChanged()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNew.Click
        Try
            Dim ChildForm As New frmLid()
            ChildForm.MdiParent = MainForm
            ChildForm.WindowState = FormWindowState.Maximized

            ChildForm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbPCHuisNr_CheckedChanged(sender As Object, e As EventArgs) Handles rbPCHuisNr.CheckedChanged
        Try
            lbPC.Visible = rbPCHuisNr.Checked
            tbPC.Visible = rbPCHuisNr.Checked
            If Not rbNaamPc.Checked Then
                tbPC.Text = ""
            End If
            radioChanged()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub radioChanged()
        If rbAchternaam.Checked Then
            lbSearch.Text = "Naam:"
        ElseIf rbNaamPc.Checked Then
            lbSearch.Text = "Naam:"
        ElseIf rbLidNr.Checked Then
            lbSearch.Text = "LidNr:"
        ElseIf rbPCHuisNr.Checked Then
            lbSearch.Text = "Huisnr:"
        Else

        End If
    End Sub

    Private Sub rbAchternaam_CheckedChanged(sender As Object, e As EventArgs) Handles rbAchternaam.CheckedChanged
        radioChanged()
    End Sub

    Private Sub rbLidNr_CheckedChanged(sender As Object, e As EventArgs) Handles rbLidNr.CheckedChanged
        radioChanged()
    End Sub


End Class