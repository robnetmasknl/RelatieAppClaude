Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgNewlocatie
    Public LocatieId As Integer = 0
    Private NewLocatie As Locaties = Nothing

    Private Sub dlgNewlocatie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not LocatieId = 0 Then
                NewLocatie = New Locaties(LocatieId)
                With NewLocatie
                    tblocatie.Text = .Locatie
                    chkToegankelijk.Checked = .Toegankelijkheid
                    tbAdres1.Text = .Address1
                    tbAdres2.Text = .Address2
                    tbAdres3.Text = .Address3
                    tbStraat.Text = .Street
                    tbPostcode.Text = .Postcode
                    tbPlaats.Text = .Plaats
                    chkCancel.Checked = .Cancel
                    chkNewLocation.Checked = .LocatieNieuw
                End With

            Else
                NewLocatie = New Locaties
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If String.IsNullOrEmpty(tblocatie.Text.Trim) Then Throw New Exception("Er is geen locatienaam opgegeven")
            With NewLocatie
                .Locatie = tblocatie.Text.Trim
                .Toegankelijkheid = chkToegankelijk.Checked
                .Address1 = tbAdres1.Text
                .Address2 = tbAdres2.Text
                .Address3 = tbAdres3.Text
                .Street = tbStraat.Text
                .Postcode = tbPostcode.Text
                .Plaats = tbPlaats.Text
                .Cancel = chkCancel.Checked
                .LocatieNieuw = chkNewLocation.Checked
                .Save()
            End With


            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
