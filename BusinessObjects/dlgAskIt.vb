Imports System.Windows.Forms

Public Class dlgAskIt
    Private Sub dlgAskIt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim cmb As New ComboBox
            cmb = Me.Controls.Item("cmbLidSoorten")
            If Not cmb Is Nothing Then
                cmb.SelectedValue = 7
            End If

            'For Each ctrl As Control In Me.Controls
            '    If TypeOf ctrl Is RadioButton Then
            '        Dim rd As RadioButton = Nothing
            '        rd = DirectCast(ctrl, RadioButton)
            '        AddHandler rd.CheckedChanged, AddressOf radioCheckedChanged
            '    End If
            'Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub radioCheckedChanged()
    '    Try
    '        Dim rdZilver As New RadioButton
    '        rdZilver = Me.Controls.Item("rdZilver")
    '        If Not rdZilver Is Nothing Then
    '            Dim tb As New TextBox
    '            tb = Me.Controls.Item("tbMonths")
    '            tb.Enabled = rdZilver.Checked
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class
