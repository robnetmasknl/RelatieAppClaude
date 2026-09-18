Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgLidSoort
    Private URights As UserRights = UserRights.Instance
    Private _lidid As Int32 = 0
    Private _periodeid As Int32 = 0

    Public dlgNSK_JN As Int32 = 0
    Public dlgNSKdatum As String = ""
    Public dlgResetPlaatsing As Boolean = False

    'Private _MyRelatie As Relaties
    'Public Property MyRelatie() As Relaties
    '    Get
    '        If _MyRelatie Is Nothing Then
    '            If _lidid = 0 Then
    '                _MyRelatie = New Relaties
    '            Else
    '                _MyRelatie = New Relaties(_lidid, Relaties.Via.ID)
    '            End If

    '        End If
    '        Return _MyRelatie
    '    End Get
    '    Set(ByVal value As Relaties)
    '        _MyRelatie = value
    '    End Set
    'End Property

    Public _SelectedPeriode As LidSoortPeriode
    Public Property SelectedPeriode() As LidSoortPeriode
        Get
            If _SelectedPeriode Is Nothing Then
                _SelectedPeriode = New LidSoortPeriode(_periodeid, LidSoortPeriode.Via.ID)
            End If

            Return _SelectedPeriode
        End Get
        Set(ByVal value As LidSoortPeriode)
            _SelectedPeriode = value
        End Set
    End Property

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub New(ByVal RelatieId As Integer)

        InitializeComponent()
        _lidid = RelatieId

    End Sub
    Public Sub New(ByVal RelatieId As Integer, ByVal PeriodeID As Integer)

        InitializeComponent()
        _lidid = RelatieId
        _periodeid = PeriodeID

    End Sub
    Private Sub frmLidSoort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_Users") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            Dim da As New DataAccess
            Dim lidsoorten As DataTable = da.ExecuteDataTable("SELECT * FROM lidsoorten ORDER BY sequence")
            cmbLidSoorten.DataSource = lidsoorten
            cmbLidSoorten.DisplayMember = "Omschrijving"
            cmbLidSoorten.ValueMember = "id"

            If _periodeid > 0 Then
                cmbLidSoorten.SelectedValue = SelectedPeriode.lidsoortid
                dtpDatumIn.Value = SelectedPeriode.datumin
                ValueChanged()
            End If

            AddHandler rbNSKStarten.CheckedChanged, AddressOf rbNSK_CheckedChanged
            AddHandler rbNSKStoppen.CheckedChanged, AddressOf rbNSK_CheckedChanged
            AddHandler rbNskIgnore.CheckedChanged, AddressOf rbNSK_CheckedChanged


            UcNSKDatum.tb.Text = dlgNSKdatum
            If dlgNSK_JN = 0 Then
                rbNskIgnore.Checked = True
            ElseIf dlgNSK_JN = 1 Then
                'chkNSK.Checked = True
                rbNSKStarten.Checked = True
            ElseIf dlgNSK_JN = 2 Then
                MessageBox.Show("Relatie staat al klaar voor afmelding NSK", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'chkNSK.Enabled = False
                UcNSKDatum.Enabled = False
                rbNSKStoppen.Checked = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private _SelectedLidSoort As LidSoort
    Public Property SelectedLidSoort() As LidSoort
        Get
            Return _SelectedLidSoort
        End Get
        Set(ByVal value As LidSoort)
            _SelectedLidSoort = value
        End Set
    End Property

    Private Sub cmbLidSoorten_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLidSoorten.SelectedIndexChanged, cmbLidSoorten.SelectedIndexChanged
        Try
            If ActiveControl Is sender Then
                ValueChanged()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub ValueChanged()
        Try
            SelectedLidSoort = New LidSoort(cmbLidSoorten.SelectedValue)
            Dim selectedContributie As New Contributie(SelectedLidSoort.Id, dtpDatumIn.Value)
            With selectedContributie
                If .Found Then
                    dtpSedert.Value = .sedert
                    tbmbedrag.Text = .mbedrag
                    tbobedrag.Text = .obedrag
                    tbmkorting.Text = .mkorting
                    tbokorting.Text = .okorting
                Else
                    dtpSedert.Value = New DateTime("1900", "01", "01")
                    tbmbedrag.Text = .mbedrag
                    tbobedrag.Text = .obedrag
                    tbmkorting.Text = .mkorting
                    tbokorting.Text = .okorting
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dtpDatumIn_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDatumIn.ValueChanged, dtpDatumIn.ValueChanged
        Try
            If ActiveControl Is sender Then
                ValueChanged()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            ValueChanged()

            If rbNSKStarten.Checked Or rbNSKStoppen.Checked Then
                'dan moet er een datum NSK gevuld zijn.
                If UcNSKDatum.Value.ToString = "" Then
                    Throw New Exception("Bij NSK aan/afmelden, mag melding datum niet leeg zijn!")
                End If
            End If

            SelectedPeriode.lidid = _lidid
            SelectedPeriode.lidsoortid = cmbLidSoorten.SelectedValue
            SelectedPeriode.datumin = dtpDatumIn.Value.Date
            SelectedPeriode.Save()

            dlgNSKdatum = UcNSKDatum.Value

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub chkNSK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNSK.CheckedChanged
    '    If dlgNSK_JN = 2 Then Exit Sub
    '    If chkNSK.Checked Then
    '        dlgNSK_JN = 1
    '    Else
    '        dlgNSK_JN = 0
    '    End If
    'End Sub

    Private Sub rbNSK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If ActiveControl Is sender Then
                Dim radio As New RadioButton
                radio = sender
                If radio.Name.ToUpper = "RBNSKSTARTEN" Then
                    dlgNSK_JN = 1
                ElseIf radio.Name.ToUpper = "RBNSKSTOPPEN" Then
                    dlgNSK_JN = 2
                ElseIf radio.Name.ToUpper = "RBNSKIGNORE" Then
                    dlgNSK_JN = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup
        ToolTip1.SetToolTip(UcNSKDatum, "Gebruik eerste dag bij aanmelden en laaste dag bij afmelden")
    End Sub
End Class
