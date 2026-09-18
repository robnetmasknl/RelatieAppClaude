Imports System.Windows.Forms
Imports BusinessObjects
Imports Microsoft.Office.Interop
Imports MapiObjects

Public Class dlgJdTypePetition
    Private da As New DataAccess
    Private FaseId As Integer = -1
    Private DossierId As Integer = -1
    Public FaseTypeId As Integer = -1
  
    ' Private MapiObject As New MapiObject(GetSysSettingOf("IBBCalAccount"))

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

    Public Sub New(ByVal bydossierid As Integer, Optional ByVal byfaseid As Integer = -1)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        FaseId = byfaseid
        DossierId = bydossierid
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Changelayout()
        Dim style As FontStyle = CInt(da.Settings.FontStyle)
        Dim newFont As Font = New System.Drawing.Font(da.Settings.FontFamily, da.Settings.FontSize, style)
        Me.Font = newFont
        'Me.ParentForm.Font = newFont
    End Sub
    Private Sub dlgJdTypePetition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Changelayout()
            BindForm()

            'TODO BMO
            chkIntrekking.Visible = da.IsNetmask

            Me.Text = MyFase.Fase.Description

            'If MyFase.Besluit <> 0 Then EnabledDisabledFormControls(Me, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If String.IsNullOrEmpty(uctdIndienDatum.Value) Then
                Throw New Exception("indien datum verplicht!!")
                Exit Sub
            End If

            If rbAfwachting.Checked = False AndAlso String.IsNullOrEmpty(uctdBesluit.Value) Then
                uctdBesluit.Focus()
                Throw New Exception("Datum besluit ontbreekt en is nodig voor de volgende fase!")
                Exit Sub
            End If

            If Not MyFase.Found Then MyFase.Save()
            save()
            ValidateOutlook()


            _MyOriginalFase = Nothing

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
    Private Sub BindForm()
        Try
            With MyFase
                If Not MyFase.Found Then
                    Me.Text &= " - Nieuw"
                    .DossierId = DossierId
                    .TypeId = FaseTypeId
                    uctdIndienDatum.Value = Today
                    tbWeken.Text = 8

                    'If Not MyFase.AllPhasesClosed() And Not MyFase.Fase.Seq = 0 Then Throw New Exception("Er kunnen niet meer dan 1 open fases zijn, bezwaarfase uitgezonderd!")

                Else
                    uctdIndienDatum.Value = .Indiendatum
                    UctdEindeBeslisTermijn.Value = .Ingebreke
                End If

                Select Case .Besluit
                    Case 0
                        rbAfwachting.Checked = True
                    Case 1
                        rbAfgewezen.Checked = True
                    Case 2
                        rbToegekend.Checked = True
                    Case 4
                        ' ingetrokken!
                End Select

                uctdBesluit.Value = .Beslisdatum
                chkIngebrekestelling.Checked = .IngebrekeStelling
                uctdInGebreke.Value = .IngebrekeBeslissingDatum
                tbInGebreke.Text = .IngebrekeOpmerkingen
                chkAanHouding.Checked = .AanhBezw
                tbOpmerking.Text = .Opmerkingen
                chkIntrekking.Checked = .Intrekking

                If Not MyFase.NextJFaseExist And Not String.IsNullOrEmpty(MyFase.Beslisdatum) Then
                    'dan de tijdelijke reminder label zetten
                    Dim EindeBeroepDatum As Date = Format(MyFase.Beslisdatum)
                    MyFase.DateTempObjection = EindeBeroepDatum.AddDays((6 * 7))
                    Dim jdtr As jdTranslate = New jdTranslate(MyFase.TypeId, "DateTempObjection")
                    lblBezwaartermijn.Text = jdtr.Description & " " & EindeBeroepDatum.AddDays((6 * 7))

                End If

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateMyFaseClass()
        Try
            With MyFase
                .DossierId = DossierId
                .Indiendatum = Me.uctdIndienDatum.Value
                .Ingebreke = Me.UctdEindeBeslisTermijn.Value

                If rbAfwachting.Checked Then
                    .Besluit = 0 'niets
                ElseIf rbAfgewezen.Checked Then
                    .Besluit = 1 'afgewezen
                ElseIf rbToegekend.Checked Then
                    .Besluit = 2 'toegekend
                End If

                'Als is ingetrokken, besluit overrulen met 4
                If chkIntrekking.Checked Then .Besluit = 4

                .Beslisdatum = Me.uctdBesluit.Value

                .IngebrekeStelling = chkIngebrekestelling.Checked
                .IngebrekeBeslissingDatum = Me.uctdInGebreke.Value
                .IngebrekeOpmerkingen = tbInGebreke.Text
                .AanhBezw = chkAanHouding.Checked
                .Opmerkingen = tbOpmerking.Text

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub save()
        Try
            With MyFase
                .DossierId = DossierId
                .Indiendatum = Me.uctdIndienDatum.Value
                .Ingebreke = Me.UctdEindeBeslisTermijn.Value

                If rbAfwachting.Checked Then
                    .Besluit = 0 'niets
                ElseIf rbAfgewezen.Checked Then
                    .Besluit = 1 'afgewezen
                ElseIf rbToegekend.Checked Then
                    .Besluit = 2 'toegekend
                End If
                .Beslisdatum = Me.uctdBesluit.Value

                .IngebrekeStelling = chkIngebrekestelling.Checked
                .IngebrekeBeslissingDatum = Me.uctdInGebreke.Value
                .IngebrekeOpmerkingen = tbInGebreke.Text
                .AanhBezw = chkAanHouding.Checked
                .Opmerkingen = tbOpmerking.Text

                'bmo: onduidelijk of er nu wel of geen reminder moet worden gezet bij einde verzoek
                'If Not MyFase.NextJFaseExist And Not String.IsNullOrEmpty(MyFase.Beslisdatum) Then
                '    'dan de tijdelijke reminder zetten
                '    Dim EindeBeroepDatum As Date = Format(MyFase.Beslisdatum)
                '    MyFase.DateTempObjection = EindeBeroepDatum.AddDays((6 * 7))
                '    MyFase.UpdateAppointmentEWS("DateTempObjection")
                '    Dim jdtr As jdTranslate = New jdTranslate(MyFase.TypeId, "DateTempObjection")
                '    lblBezwaartermijn.Text = jdtr.Description & " " & EindeBeroepDatum.AddDays((6 * 7))
                'End If

                .Save()

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ValidateOutlook()
        Dim results As New List(Of String)
        Try
            If MyFase.Ingebreke <> _MyOriginalFase.Ingebreke Then
                results.Add("Datum einde beslistermijn is aangepast.")
            End If
            If MyFase.Beslisdatum <> _MyOriginalFase.Beslisdatum Then
                results.Add("Datum ''besluit'' is aangepast.")
            End If

            If results.Count > 0 Then
                Dim value As String = String.Join(",", results.ToArray)
                ' If ExchangeUserEnabled Then
                Dim dlgRes As DialogResult = MessageBox.Show(value & vbCrLf & "Wilt u dat de reminder in outlook ook wordt aangepast?", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If dlgRes <> DialogResult.Yes Then
                    Exit Sub
                Else
                    UpdateOutlook("Ingebreke")
                    UpdateOutlook("Beslisdatum")
                End If
                'Else
                'MessageBox.Show(value & vbCrLf & "De reminder in outlook kan niet worden aangepast?", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' End If

            End If

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

    Private Sub btnOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutlook.Click
        Try
            UpdateOutlook("Ingebreke")
            UpdateOutlook("Beslisdatum")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tbWeken_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbWeken.TextChanged
        Try
            'If chkAanHouding.Checked = True Then
            '    UctdEindeBeslisTermijn.Value = ""
            'Else
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
            UctdEindeBeslisTermijn.Value = ObjectionDate
            'End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub rbAfwachting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAfwachting.Click
    '    Try
    '        If sender Is ActiveControl Then
    '            If Not MyIBBDossier.AllPhasesClosed(MyFase.Id) Then
    '                MessageBox.Show("Er kunnen niet meer dan 1 open fase zijn!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Select Case MyFase.Besluit
    '                    Case 0
    '                        rbAfwachting.Checked = True
    '                    Case 1
    '                        rbAfgewezen.Checked = True
    '                    Case 2
    '                        rbToegekend.Checked = True
    '                End Select
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub chkIngebrekestelling_CheckedChanged(sender As Object, e As EventArgs) Handles chkIngebrekestelling.CheckedChanged
        If Not chkIngebrekestelling.Checked Then
            uctdInGebreke.Value = ""
            tbInGebreke.Text = ""
        End If
        uctdInGebreke.Enabled = chkIngebrekestelling.Checked
        tbInGebreke.Enabled = chkIngebrekestelling.Checked
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim ModuleName As String = Me.Name
        Try
            OpenHelpUrl(ModuleName)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkAanHouding_CheckedChanged(sender As Object, e As EventArgs) Handles chkAanHouding.CheckedChanged
        Try
            If chkAanHouding.Focused AndAlso chkAanHouding.Checked Then
                UctdEindeBeslisTermijn.Value = ""
            ElseIf chkAanHouding.Checked = False Then
                Dim iObjectionPeriod As Integer = 8
                Dim DecisionDate As Date = uctdIndienDatum.Value
                Dim ObjectionDate As Date = DecisionDate.AddDays(iObjectionPeriod * 7)
                UctdEindeBeslisTermijn.Value = ObjectionDate

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub chkIntrekking_CheckedChanged(sender As Object, e As EventArgs) Handles chkIntrekking.CheckedChanged
        Try
            If Not chkIntrekking.Focused Then Exit Sub
            If chkIntrekking.Checked Then
                Dim dlgAsk As New dlgAskIt
                Dim LastY As Integer = 0
                Dim iLabelPositionX As Integer = 0
                Dim mylabel As New Label

                Dim lbl1 As New Label
                Dim tb1 As New TextBox
                Dim lbl3 As New Label

                dlgAsk.StartPosition = FormStartPosition.CenterScreen
                mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                mylabel.Text = "Vul een reden voor het intrekken?"
                mylabel.AutoSize = True
                dlgAsk.Controls.Add(mylabel)

                tb1.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
                tb1.Name = "tb1"
                tb1.Text = ""
                tb1.Size = New Size(dlgAsk.Size.Width - 50, 35)
                dlgAsk.Controls.Add(tb1)
                LastY = tb1.Location.Y
                iLabelPositionX = tb1.Location.X + 20

                Dim mylabel1 As New Label
                mylabel1.Location = New Point(mylabel.Location.X, LastY + 40)
                mylabel1.Text = "Deze fase wordt hierdoor afgesloten!"
                mylabel1.AutoSize = True
                LastY = mylabel1.Location.Y
                dlgAsk.Controls.Add(mylabel1)

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    chkIntrekking.Checked = False
                    Exit Sub
                Else
                    'sluit huidige fase
                    MyFase.DeleteFutureAppointmentsEWS()
                    uctdBesluit.Value = Today
                    MyFase.Besluit = 4
                    MyFase.Intrekking = True
                    MyFase.Save()

                    If Not MyIBBDossier.AllPhasesClosed Then
                        chkIntrekking.Checked = False
                        MessageBox.Show("Er is nog een Fase niet afgesloten," & vbCrLf & "U dient deze eerst af te handelen voordat u het dossier kan sluiten.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim ChildForm As frmIBBDossier = DirectCast(Me.Owner, RelatieApp.frmIBBDossier)
                    If ChildForm Is Nothing Then
                        MessageBox.Show("Het scherm IBBDossier is afgesloten en daardoor niet meer aan te spreken", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ChildForm.MyIBBDossier.AfgehandeldReden = tb1.Text
                        ChildForm.tbAfgehandeld.Text = tb1.Text
                        ChildForm.MyIBBDossier.Afgehandeld = True
                        ChildForm.chkAfgehandeld.Checked = True
                        ChildForm.uctdEndDate.tb.Text = Today
                        Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                        ChildForm.Save()
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
