Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgNewBlok

    Private NewBlok As Blok
    Public Adviseur As Adviseur
    Private Utils As New Utilities

    Private _BlokTypesLijst As BlokTypes
    Public ReadOnly Property BlokTypesLijst() As BlokTypes
        Get
            If _BlokTypesLijst Is Nothing Then
                _BlokTypesLijst = New BlokTypes
            End If
            Return _BlokTypesLijst
        End Get
    End Property

    Private Sub dlgNewBlok_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lblAdviseur.Text = Adviseur.naam
            Dim LocatieLijst As New Locaties
            cmbLocaties.DataSource = LocatieLijst.Lijst
            cmbLocaties.DisplayMember = "locatie"
            cmbLocaties.ValueMember = "id"

            Dim vultypes As New VulTypes
            cmbVutype.DataSource = vultypes.list
            cmbVutype.DisplayMember = "value"
            cmbVutype.ValueMember = "id"


            cmbBlokTypes.DataSource = BlokTypesLijst.Lijst
            cmbBlokTypes.DisplayMember = "tempnaam"
            cmbBlokTypes.ValueMember = "id"

            'AddHandler tbAantal.Validating, AddressOf Utils.ValidNummeriek
            'AddHandler tbTijdsduur.Validating, AddressOf Utils.ValidNummeriek

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try

            NewBlok = New Blok
            With NewBlok
                .locatieId = cmbLocaties.SelectedValue
                .datum = dtpDatum.Value.ToShortDateString
                .adviseurid = Adviseur.Id
                .bloktypeid = cmbBlokTypes.SelectedValue
                .vultype = cmbVutype.SelectedValue
                .Save()
            End With

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub cmbBlokTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBlokTypes.SelectedIndexChanged
        Try

            lblAanvang.Text = "Aanvang: " & BlokTypesLijst.Lijst(cmbBlokTypes.SelectedIndex).aanvang
            lblBlokken.Text = "aantal: " & BlokTypesLijst.Lijst(cmbBlokTypes.SelectedIndex).aantal
            lblPauze.Text = "pauze na blok: " & BlokTypesLijst.Lijst(cmbBlokTypes.SelectedIndex).pauze
            lblTijdsduur.Text = "tijdsduur p blok: " & BlokTypesLijst.Lijst(cmbBlokTypes.SelectedIndex).tijdsduur

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
