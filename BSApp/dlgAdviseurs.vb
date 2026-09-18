Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgAdviseurs

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgAdviseurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'Dim vultypes As New VulTypes
            'cmbVutype.DataSource = vultypes.list
            'cmbVutype.DisplayMember = "value"
            'cmbVutype.ValueMember = "id"

            Dim _adviseurs As New AdviseursLijst
            cmbAdviseurs.DataSource = _adviseurs.Lijst
            cmbAdviseurs.DisplayMember = "naam"
            cmbAdviseurs.ValueMember = "Id"
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
