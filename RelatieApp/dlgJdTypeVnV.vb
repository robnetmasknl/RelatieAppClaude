Imports System.Windows.Forms
Imports BusinessObjects
Imports Microsoft.Office.Interop
Imports MapiObjects

Public Class dlgJdTypeVnV
    Private da As New DataAccess
    Private FaseId As Integer = -1
    Private DossierId As Integer = -1
    Public FaseTypeId As Integer = -1
    'Private MapiObject As New MapiObject(GetSysSettingOf("IBBCalAccount"))

    Private _MyOriginalFase As IBBFase
    Private Sub CloneMyFase()
        _MyOriginalFase = _MyFase.Clone
    End Sub

    Private _MyFase As IBBFase
    Public Property MyFase() As IBBFase
        Get
            If IsNothing(_MyFase) Then
                _MyFase = New IBBFase(FaseId, IBBFase.Via.ID)
                _MyOriginalFase = _MyFase.Clone
            End If

            Return _MyFase
        End Get
        Set(ByVal value As IBBFase)
            _MyFase = value
        End Set
    End Property

    Private _MyIBBDossier As IBBDossier
    Public ReadOnly Property MyIBBDossier() As IBBDossier
        Get
            If IsNothing(_MyIBBDossier) Then
                _MyIBBDossier = New IBBDossier(DossierId, IBBDossier.VIA.ID)
            End If
            Return _MyIBBDossier
        End Get
    End Property

    'Private _ExchangeUserEnabled As Boolean = False
    'Public ReadOnly Property ExchangeUserEnabled() As Boolean
    '    Get
    '        Return _ExchangeUserEnabled
    '    End Get
    'End Property

    'Private _ExchangeJuristEnable As Boolean = False
    'Public ReadOnly Property ExchangeJuristEnable() As Boolean
    '    Get
    '        Return _ExchangeJuristEnable
    '    End Get
    'End Property
    Public Sub New(ByVal bydossierid As Integer, Optional ByVal byfaseid As Integer = -1)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        FaseId = byfaseid
        DossierId = bydossierid
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dlgJdTypeVnV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            BindForm()

            Me.Text = MyFase.Fase.Description

            ''If MyFase.Besluit <> 0 Then EnabledDisabledFormControls(Me, False)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try


    End Sub

    Private Sub BindForm()
        Try
            Dim tlbReasons As DataTable = da.ExecuteDataTable("SELECT * FROM jdChoice  Order By Description")
            If MyFase.VnVChoice = 0 Then
                Dim dr As DataRow = tlbReasons.NewRow
                dr("Id") = 0
                dr("Description") = "Maak keuze."
                tlbReasons.Rows.InsertAt(dr, 0)
            End If
            cmbChoice.DataSource = tlbReasons
            cmbChoice.DisplayMember = "Description"
            cmbChoice.ValueMember = "Id"
            cmbChoice.SelectedValue = MyFase.VnVChoice


            With MyFase
                If Not MyFase.Found Then
                    Me.Text &= " - Nieuw"
                    .DossierId = DossierId
                    .TypeId = FaseTypeId
                    uctdIndienDatum.Value = Today
                    tbWeken.Text = 2

                    If Not MyFase.AllPhasesClosed() And Not MyFase.Fase.Seq = 0 Then Throw New Exception("VnV Er kunnen niet meer dan 1 open fases zijn, bezwaarfase uitgezonderd!")

                Else
                    uctdIndienDatum.Value = .Indiendatum
                    UctdGebrekestelling.Value = .Ingebreke
                End If

                Select Case .Besluit
                    Case 0
                        rbAfwachting.Checked = True
                    Case 1
                        rbAfgewezen.Checked = True
                    Case 2
                        rbToegekend.Checked = True
                End Select

                uctdHoorzitting.Value = .Hoorzittingdatum
                uctdBesluit.Value = .Beslisdatum

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try

            If rbAfwachting.Checked = False AndAlso String.IsNullOrEmpty(uctdBesluit.Value) Then
                uctdBesluit.Focus()
                Throw New Exception("Datum besluit ontbreekt en is nodig voor de volgende fase!")
                Exit Sub
            End If

            UpdateMyFaseClass()

            If Not MyFase.Found Then MyFase.Save()
            ValidateOutlook()
            save()

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub UpdateMyFaseClass()
        Try
            With MyFase
                .DossierId = DossierId
                .VnVChoice = cmbChoice.SelectedValue
                .Hoorzittingdatum = uctdHoorzitting.Value
                .Indiendatum = uctdIndienDatum.Value
                .Ingebreke = UctdGebrekestelling.Value

                If rbAfwachting.Checked Then
                    .Besluit = 0 'niets
                ElseIf rbAfgewezen.Checked Then
                    .Besluit = 1 'afgewezen
                ElseIf rbToegekend.Checked Then
                    .Besluit = 2 'toegekend
                End If

                .Beslisdatum = uctdBesluit.Value

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub save()
        Try

            MyFase.Save()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ValidateOutlook()
        Dim results As New List(Of String)
        Try

            If MyFase.Ingebreke <> _MyOriginalFase.Ingebreke Then
                results.Add("Datum reactie termijn is aangepast.")
            End If

            If MyFase.Hoorzittingdatum <> _MyOriginalFase.Hoorzittingdatum Then
                results.Add("Datum Hoorzitting is aangepast.")
            End If

            If results.Count > 0 Then
                Dim value As String = String.Join(",", results.ToArray)
                'If ExchangeUserEnabled Then
                Dim dlgRes As DialogResult = MessageBox.Show(value & vbCrLf & "Wilt u dat de reminder in outlook ook wordt aangepast?", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If dlgRes <> DialogResult.Yes Then
                    Exit Sub
                Else
                    btnOutlookReactie_Click(Me, New EventArgs)
                    btnOutlookHoorzitting_Click(Me, New EventArgs)
                End If
                'Else
                '    MessageBox.Show(value & vbCrLf & "De reminder in outlook kan niet worden aangepast?", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
  
    Private Sub btnOutlookReactie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutlookReactie.Click
        Try
            UpdateOutlook("Ingebreke")
            'ProcessOutlook()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub tbWeken_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbWeken.TextChanged
        Try
            If String.IsNullOrEmpty(tbWeken.Text) Then
                Exit Sub
            End If

            If String.IsNullOrEmpty(uctdIndienDatum.tb.Text) Then
                Throw New Exception("De Indientdatum is niet ingevuld!")
            End If

            If Not IsNumeric(tbWeken.Text) Then
                Throw New Exception("het aantal weken is niet correct ingevuld!")
            End If

            Dim iObjectionPeriod As Integer = tbWeken.Text
            Dim DecisionDate As Date = uctdIndienDatum.Value
            Dim ObjectionDate As Date = DecisionDate.AddDays(iObjectionPeriod * 7)
            UctdGebrekestelling.Value = ObjectionDate

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnOutlookHoorzitting_Click(sender As Object, e As EventArgs) Handles btnOutlookHoorzitting.Click
        Try

            UpdateOutlook("Hoorzittingdatum")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateOutlook(ByVal dbcolumn As String)
        Try
            UpdateMyFaseClass()


            MyFase.UpdateAppointmentEWS(dbcolumn)

            'ook even de clone updaten, anders komt de vraag nog een keer bij alfsluiten from.
            CloneMyFase()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim ModuleName As String = Me.Name
        Try
            OpenHelpUrl(ModuleName)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
