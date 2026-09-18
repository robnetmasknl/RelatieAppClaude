Imports BusinessObjects
Imports System.ComponentModel

<DefaultBindingProperty("Value")> _
Public Class ucTextDate
    Implements INotifyPropertyChanged

    'Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) 'Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    Public Event GenerateTextChanged()
    Public Event TbChanged()
    Public Event TbLeave()

    Dim MinDateValue As DateTime = "30-12-1899"
    <System.ComponentModel.Bindable(True)> _
    Public Shadows Property Value() As [Object]
        Get
            Return tb.Text
        End Get
        Set(ByVal value As [Object])
            tb.Text = value
            NotifyPropertyChanged("Value")
        End Set
    End Property

    Public Event Valuechanged As EventHandler

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

    Private Sub tb_Leave(sender As Object, e As EventArgs) Handles tb.Leave
        RaiseEvent tbLeave()
    End Sub
    Private Sub tb_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb.Validated
        Try
            If String.IsNullOrEmpty(sender.text) Then Exit Try
            If Not Utilities.ValidateDate(sender.text) Then
                sender.focus()
                Throw New Exception("Geen geldig datum formaat" & vbCrLf & "Juiste formaat: ''dd-MM-jjjj''")
            Else
                RaiseEvent Valuechanged(sender, e)
                NotifyPropertyChanged("Value")
                RaiseEvent GenerateTextChanged()
                'RaiseEvent Validated(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub tb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb.TextChanged
        Try

            'NotifyPropertyChanged("Value")
            RaiseEvent TbChanged()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
