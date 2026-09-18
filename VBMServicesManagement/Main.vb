Public Class Main

    Private Sub btnOpzeggingen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpzeggingen.Click
        Dim dlg As New dlgOpzeggingen
        dlg.ShowDialog()

    End Sub

    Private Sub btnSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSMS.Click
        Dim dlg As New dlgSMS
        dlg.ShowDialog()
    End Sub

    Private Sub btnIbbCalendar_Click(sender As Object, e As EventArgs) Handles btnIbbCalendar.Click
        Dim dlg As New dlgIBBCalendar
        dlg.ShowDialog()

    End Sub
End Class
