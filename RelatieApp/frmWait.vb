Public Class frmWait
    Private m_PercentDone As Integer
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub frmWait_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pbTaskProgress.Minimum = 0
        ' pbTaskProgress.Maximum = 1000
        pbTaskProgress.Value = pbTaskProgress.Minimum
        pbTaskProgress.Visible = True
    End Sub
    Public Sub Tmr_Tick()
        If m_PercentDone > 999 Then m_PercentDone = 0
        m_PercentDone = m_PercentDone + 5
        pbTaskProgress.Value = m_PercentDone

    End Sub
    Public Sub percent(ByVal value As Integer)
        pbTaskProgress.Value = value
    End Sub

    Private Sub lblHypPath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblHypPath.LinkClicked
        Try
            System.Diagnostics.Process.Start(Me.lblHypPath.Text)

        Catch ex As Exception

        End Try
    End Sub
End Class