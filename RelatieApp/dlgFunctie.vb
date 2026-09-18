Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgFunctie
    Dim da As New DataAccess
    Private _LidId As Int32 = 0
    Private _FunctieId As Int32 = 0
    Private URights As UserRights = UserRights.Instance
    Private _MyLidFunctie As LidFunctie
    Public Property MyLidFunctie() As LidFunctie
        Get
            If _MyLidFunctie Is Nothing Then
                _MyLidFunctie = New LidFunctie(_FunctieID, LidFunctie.Via.ID)
            End If
            Return _MyLidFunctie
        End Get
        Set(ByVal value As LidFunctie)
            _MyLidFunctie = value
        End Set
    End Property

    Public Sub New(ByVal RelatieId As Integer)

        InitializeComponent()
        _LidId = RelatieId

    End Sub
    Public Sub New(ByVal RelatieId As Integer, ByVal FunctieID As Integer)

        InitializeComponent()
        _lidid = RelatieId
        _FunctieId = FunctieID

    End Sub
    Private Sub dlgFunctie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_Users") Or URights.IsInGroup("rel_functies") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van 1 van de volgende groepen: ''rel_admins'',''rel_Users'' of ''rel_functies''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If


            Dim FunctieTable As DataTable = da.ExecuteDataTable("SELECT *,left(CAST(Soort as varchar) + SPACE(5),25) + ' | ' + omschrijving as id_omsch  FROM fsoort ORDER BY Id")
            cmbFuncties.DataSource = FunctieTable
            cmbFuncties.DisplayMember = "id_omsch"
            cmbFuncties.ValueMember = "id"

            Dim AdviesTable As DataTable = da.ExecuteDataTable("SELECT *,left(CAST(naam as varchar) + SPACE(5),25) + ' | ' + omschrijving as id_omsch FROM fAdvies ORDER BY naam")
            cmbAdvies.DataSource = AdviesTable
            cmbAdvies.DisplayMember = "id_omsch"
            cmbAdvies.ValueMember = "id"

            'cmbOrgaan            
            Dim OrgaanTable As DataTable = da.ExecuteDataTable("SELECT *,left(CAST(orgaan as varchar) + SPACE(5),25) + ' | ' + omschrijving as id_omsch FROM fOrgaan ORDER BY orgaan")
            cmbOrgaan.DataSource = OrgaanTable
            cmbOrgaan.DisplayMember = "id_omsch"
            cmbOrgaan.ValueMember = "id"


            Dim AfdelingenTable As DataTable = da.ExecuteDataTable("SELECT *, left(CAST(id as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch FROM Afdelingen ORDER BY Omschrijving")
            cmbAfdeling.DataSource = AfdelingenTable
            cmbAfdeling.DisplayMember = "id_omsch"
            cmbAfdeling.ValueMember = "id"

            'lblRelatieId.Text = MyRelatie.lidnr

            If _FunctieId > 0 Then
                cmbFuncties.SelectedValue = MyLidFunctie.functie
                cmbAdvies.SelectedValue = MyLidFunctie.adviesgroep
                cmbOrgaan.SelectedValue = MyLidFunctie.orgaan
                cmbAfdeling.SelectedValue = MyLidFunctie.afdeling
                utdFunctieInd.Value = MyLidFunctie.datumin
                utdFunctieEind.Value = MyLidFunctie.datumuit
                cbToon.Checked = MyLidFunctie.Toon
            Else
                cbToon.Checked = False
                cmbAfdeling.SelectedValue = 0
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If String.IsNullOrEmpty(utdFunctieInd.Value) Then
                utdFunctieInd.tb.Focus()
                Throw New Exception("Ingangs datum is verplicht")
            Else
                MyLidFunctie.lidid = _LidId
                MyLidFunctie.functie = cmbFuncties.SelectedValue
                MyLidFunctie.adviesgroep = cmbAdvies.SelectedValue()
                MyLidFunctie.orgaan = cmbOrgaan.SelectedValue
                MyLidFunctie.afdeling = cmbAfdeling.SelectedValue
                MyLidFunctie.datumin = utdFunctieInd.Value
                MyLidFunctie.datumuit = utdFunctieEind.Value
                MyLidFunctie.Toon = cbToon.Checked
                MyLidFunctie.Save()

                If MyLidFunctie.Toon = True Then
                    Dim MyRelatie As New Relaties(MyLidFunctie.lidid, Relaties.Via.ID)
                    If MyRelatie.Found Then
                        For Each MyFunctie In MyRelatie.LidFuncties
                            If Not MyFunctie.Id = MyLidFunctie.Id Then
                                MyFunctie.Toon = False
                                MyFunctie.Save()
                            End If
                        Next
                    End If
                End If
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


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try

            MyLidFunctie.Remove()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
