Imports System.Windows.Forms

Public Class dlgFunctieMaintenance

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Try
            If tbColor.Visible Then
                Dim TryColor As Color = Color.FromArgb(tbColor.Text)
            End If

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor.Click
        Try
            With Me.ColorDialog1
                .Reset()
                If .ShowDialog() = DialogResult.OK Then
                    tbColor.Text = ColorDialog1.Color.ToArgb
                    tbColor.BackColor = Color.FromArgb(tbColor.Text)
                End If

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbColor.TextChanged
        Try
            If Not String.IsNullOrEmpty(tbColor.Text) Then
                tbColor.BackColor = Color.FromArgb(tbColor.Text)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
