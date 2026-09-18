Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgInstance
    'Private da As New DataAccess
    'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    '    MyRelatie.myLid_contributie.Save()
    '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '    Me.Close()
    'End Sub

    'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End Sub
    'Private MyRelatie As Relaties
    'Private myclone As Lid_contributie
    'Public Sub New(ByVal _Relatie As Relaties)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    MyRelatie = _Relatie
    '    myclone = MyRelatie.myLid_contributie.Clone

    '    'MyRelatieClone = New RelatieRollBack(MyRelatie)
    '    Dim ContributieInstanties As DataTable = da.ExecuteDataTable("SELECT * FROM Contr_instanties ORDER BY naam")
    '    cmbContrInstanties.DataSource = ContributieInstanties
    '    cmbContrInstanties.DisplayMember = "naam"
    '    cmbContrInstanties.ValueMember = "id"
    '    cmbContrInstanties.SelectedValue = MyRelatie.myLid_contributie.contr_instantieid

    '    'tbContrInstanties.Text = MyRelatie.myLid_contributie.InstantieNaam
    '    tbInstantieOud.Text = "" 'MyRelatie.myLid_contributie.InstantieNaamVorig
    '    dtpInstantie.Value = MyRelatie.myLid_contributie.datum

    'End Sub

    'Private Sub cmbContrInstanties_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbContrInstanties.SelectedIndexChanged
    '    Try
    '        If ActiveControl Is sender Then
    '            MyRelatie.myLid_contributie.contr_instantieid = cmbContrInstanties.SelectedValue
    '            tbInstantieOud.Text = myclone.contr_instantieid
    '            MyRelatie.myLid_contributie.datum = dtpInstantie.Value
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class
