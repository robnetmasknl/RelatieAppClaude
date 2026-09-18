Imports BusinessObjects

Public Class dlgOpzegging
    Private da As New DataAccess
    Public dlgeindedatum As String = ""
    Public dlgeindereden As Integer = 0
    Public dlgNSK_JN As Int32 = 0
    Public dlgNSKdatum As String = ""

    Private Sub UcEindeDatum_TextChanged() Handles UcEindeDatum.GenerateTextChanged

        UcNSKDatum.tb.Text = UcEindeDatum.tb.Text

    End Sub
    Private Sub InOutValue(ByVal opzegid As Integer)
        Try
            Dim NSKValue As String = String.Empty
            Dim paramlist As New ArrayList
            paramlist.Add("@OpzegId")
            paramlist.Add(opzegid)

            NSKValue = da.ExecuteScalar("SELECT NSKAfmelden FROM opzeggingen WHERE Id = @OpzegId", paramlist.ToArray).ToString

            If Not String.IsNullOrEmpty(NSKValue) Then
                Select Case NSKValue
                    Case "J"
                        If dlgNSK_JN > 0 Then
                            MessageBox.Show("uuh wat nu?" & vbCrLf & "Er staat al een NSK opdracht klaar!")
                        End If
                        chkNSK.Checked = True
                        UcNSKDatum.Value = Me.UcEindeDatum.Value
                    Case "N"
                        chkNSK.Checked = False
                        UcNSKDatum.Value = ""
                End Select
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dlgOpzegging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim EindeReden As DataTable = da.ExecuteDataTable("SELECT * FROM opzeggingen ORDER BY id")
        cmbEindeReden.DataSource = EindeReden
        cmbEindeReden.DisplayMember = "omschrijving"
        cmbEindeReden.ValueMember = "id"
        cmbEindeReden.SelectedValue = dlgeindereden


        UcEindeDatum.tb.Text = dlgeindedatum
        UcNSKDatum.tb.Text = dlgNSKdatum

        If dlgNSK_JN = 2 Then
            chkNSK.Checked = True
        ElseIf dlgNSK_JN = 1 Then
            MessageBox.Show("Relatie staat al klaar voor aanmelding NSK", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'chkNSK.Enabled = False
            'UcNSKDatum.Enabled = False
        End If

    End Sub
    Private Sub chkNSK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNSK.CheckedChanged
        If dlgNSK_JN = 1 Then Exit Sub
        If chkNSK.Checked Then
            dlgNSK_JN = 2
        Else
            dlgNSK_JN = 0
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If String.IsNullOrEmpty(UcEindeDatum.Value) And cmbEindeReden.SelectedValue <> 0 Then
                UcEindeDatum.tb.Focus()
                Throw New Exception("Einde datum is verplicht")
            ElseIf String.IsNullOrEmpty(UcNSKDatum.Value) And chkNSK.Checked Then
                UcNSKDatum.tb.Focus()
                Throw New Exception("NSK datum is verplicht")
            Else
                dlgeindereden = cmbEindeReden.SelectedValue
                dlgeindedatum = UcEindeDatum.Value
                dlgNSKdatum = UcNSKDatum.Value

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbEindeReden_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEindeReden.SelectedIndexChanged
        Try
            If ActiveControl Is sender Then
                InOutValue(cmbEindeReden.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class