Imports BusinessObjects
Imports System.ComponentModel

<DefaultBindingProperty("Text")> _
Public Class uctd

    Dim MinDateValue As DateTime = "30-12-1899"

    Private Sub btnDatum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        Try
            Dim tb As TextBox = FindFormControl(Me, sender.tag)
            Dim DateValue As DateTime
            If tb.Text = String.Empty Or tb.Text = MinDateValue.ToShortDateString Then
                DateValue = Today
            Else
                DateValue = tb.Text
            End If
            Dim TopForm As New dlgDate(DateValue)
            Dim result As DialogResult = TopForm.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                tb.Text = Format(TopForm.ndtpDatum.Value, "dd-MM-yyyy")
                Me.SelectNextControl(ActiveControl, True, True, True, True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Event Valuechanged As EventHandler
    Private Sub tb_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb.Validated
        Try
            If String.IsNullOrEmpty(sender.text) Then Exit Try
            If Not Utilities.ValidateDate(sender.text) Then
                sender.focus()
                Throw New Exception("Geen geldig datum formaat" & vbCrLf & "Juiste formaat: ''dd-MM-jjjj''")
            Else
                RaiseEvent Valuechanged(sender, e)
                Text = tb.Text
                'RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Value"))
                ' NotifyPropertyChanged("Text")
                'RaiseEvent GenerateTextChanged()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
