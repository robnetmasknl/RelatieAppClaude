Imports System.Windows.Forms

Public Class dlgDate
    Private NewDate As DateTime
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mcDate.SetDate(NewDate)
        ndtpDatum.Value = NewDate
    End Sub

    Public Sub New(ByVal _date As DateTime)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        NewDate = _date
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dtpInDatum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            mcDate.SetDate(ndtpDatum.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mcDate_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcDate.DateChanged
        Try
            ndtpDatum.Value = mcDate.SelectionStart
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ndtpDatum_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ndtpDatum.ValueChanged
        Try
            mcDate.SetDate(ndtpDatum.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
