Imports System.Windows.Forms
Imports BusinessObjects
Imports Microsoft.Office.Interop
Imports MapiObjects

Public Class dlgJdCentralBoard
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance
    Private FaseId As Integer = -1
    Private DossierId As Integer = -1
    Public FaseTypeId As Integer = -1
    'Private MapiObject As New MapiObject(GetSysSettingOf("IBBCalAccount"))
    Private AppointmentSettings As New AppointmentSettings
    Public CreateNextPhase As Boolean = False

    Private bsFase As BindingSource

    Dim haschanged As Boolean = False
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

        InitializeComponent()
        FaseId = byfaseid
        DossierId = bydossierid

    End Sub
    Private Sub Changelayout()
        Dim style As FontStyle = CInt(da.Settings.FontStyle)
        Dim newFont As Font = New System.Drawing.Font(da.Settings.FontFamily, da.Settings.FontSize, style)
        Me.Font = newFont

        If da.Settings.FontSize >= 9 Then
            Me.Location = New Point(Me.Location.X, 10)
        End If

    End Sub
    Private Sub dlgJdTypeCourt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Changelayout()
            BindForm()


            'If MyFase.Besluit <> 0 Then EnabledDisabledFormControls(Me, False)

            AddHandler rbGegrond.CheckedChanged, AddressOf rbBob_CheckedChanged
            AddHandler rbOnGegrond.CheckedChanged, AddressOf rbBob_CheckedChanged
            AddHandler rbNietOntv.CheckedChanged, AddressOf rbBob_CheckedChanged
            AddHandler rbAfwachting.CheckedChanged, AddressOf rbBob_CheckedChanged

            AddHandler rbVoVoAfgewezen.CheckedChanged, AddressOf rbVovo_CheckedChanged
            AddHandler rbVoVoAfwachting.CheckedChanged, AddressOf rbVovo_CheckedChanged
            AddHandler rbVoVoToegewezen.CheckedChanged, AddressOf rbVovo_CheckedChanged

            Me.Text = MyFase.Fase.Description

            'Me.btnOutlookBezwaar.Enabled = ExchangeUserEnabled
            'Me.btnOutlookHerstelVerzuim.Enabled = ExchangeUserEnabled
            'Me.btnOutlookHoorzitting.Enabled = ExchangeUserEnabled
            ''Me.OK_Button.Enabled = ExchangeUserEnabled

            'AddHandler uctdHerstelverzuimtermijn.GenerateTextChanged, AddressOf uctdDatumBesluit_TextChanged

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

    End Sub
    Private Sub BindForm()
        Try
            With MyFase
                If Not MyFase.Found Then
                    Me.Text &= " - Nieuw"
                    .DossierId = DossierId
                    .TypeId = FaseTypeId
                    .Besluit = 0
                    .CreateDate = Now
                    .CreatedBy = URights.UserName

                    If Not MyFase.AllPhasesClosed() And Not MyFase.Fase.Seq = 0 Then Throw New Exception("CR Er kunnen niet meer dan 1 open fases zijn, bezwaarfase uitgezonderd!")

                    'haal de data uit de vorige fase indien aanwezig, anders datum vandaag
                    If MyIBBDossier.ListIBBFases.Count > 0 Then
                        ' Dim VorigeFase As IBBFase = MyIBBDossier.ListIBBFases.First

                        Dim VorigeFase As IBBFase = New IBBFase
                        For Each fs In MyIBBDossier.ListIBBFases
                            If fs.Fase.Type = "RB" Then
                                VorigeFase = fs
                            End If
                        Next

                        .Beslisdatum = VorigeFase.BeslissingBezwaar
                        .Indiendatum = VorigeFase.DateTempObjection
                    Else
                        .Beslisdatum = Today
                    End If

                Else
                    'uctdDatumBesluit.Enabled = False
                End If


                uctdDatumBesluit.Value = .Beslisdatum
                uctdBeroepsTermijn.Value = .Indiendatum
                uctdVoorlopigBeroep.Value = .VoorloopigBezwaar
                uctdBeroepSchrift.Value = .Bezwaarschrift
                uctdHerstelverzuimtermijn.Value = .Herstelverzuimtermijn

                chkAanhBeroep.Checked = .AanhBezw
                uctdZitting.Value = .Hoorzittingdatum

                uctdVerweerschrift.Value = .DateField9
                uctdReactieVerweer.Value = .DateField8

                tbTussenUitspraak.Text = .Opmerkingen
                uctdBeslissingBeroep.Value = .BeslissingBezwaar
                tbKenmerk.Text = .Kenmerk

                Select Case MyFase.Besluit
                    Case 0
                        rbAfwachting.Checked = True
                    Case 1
                        rbGegrond.Checked = True
                    Case 2
                        rbOnGegrond.Checked = True
                    Case 3
                        rbNietOntv.Checked = True
                    Case 4
                        'Bezwaar ingetrokken!
                End Select


                tbOpmerkingen2.Text = .Opmerkingen2

                chkVovoCB.Checked = .VovoCB
                uctdVovoDat.Value = .VovoDat
                uctdVovoDatUit.Value = .VovoDatuit
                uctdVovoIndienDatum.Value = .DateField10
                uctdVovoVerweerSchrift.Value = .DateField11
                tbVovotoev.Text = .VovoToev
                chkVoVoRecall.Checked = .VoVoRecall
                chkIntrekking.Checked = .Intrekking

                Select Case MyFase.VovoUitsp
                    Case 0
                        rbVoVoAfwachting.Checked = True
                    Case 1
                        rbVoVoAfgewezen.Checked = True
                    Case 2
                        rbVoVoToegewezen.Checked = True
                End Select


                'weekvelden standaard vullen indien datum NIET gevuld
                If String.IsNullOrEmpty(uctdBeroepsTermijn.tb.Text) Then
                    tbWeken1.Text = 6
                Else
                    CalculateWeeks()
                End If

                If Not MyFase.Found Then
                    'indien nieuw vul standaard data in
                    uctdDatumBesluit_TextChanged()
                End If

            End With

            uctdVoorlopigBeroep_TextChanged()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateMyFaseClass()
        Try
            With MyFase

                .Intrekking = chkIntrekking.Checked

                .Beslisdatum = uctdDatumBesluit.Value
                .Indiendatum = uctdBeroepsTermijn.Value
                .VoorloopigBezwaar = uctdVoorlopigBeroep.Value
                .Bezwaarschrift = uctdBeroepSchrift.Value
                .Herstelverzuimtermijn = uctdHerstelverzuimtermijn.Value
                .AanhBezw = chkAanhBeroep.Checked
                .Hoorzittingdatum = uctdZitting.Value


                .DateField9 = uctdVerweerschrift.Value
                .DateField8 = uctdReactieVerweer.Value

                If rbAfwachting.Checked = True Then
                    .Besluit = 0
                ElseIf rbGegrond.Checked = True Then
                    .Besluit = 1
                ElseIf rbOnGegrond.Checked = True Then
                    .Besluit = 2
                ElseIf rbNietOntv.Checked = True Then
                    .Besluit = 3
                End If
                'Als bezwaar is ingetrokken, besluit overrulen met 4
                If chkIntrekking.Checked Then .Besluit = 4
                .BeslissingBezwaar = uctdBeslissingBeroep.Value
                .Kenmerk = tbKenmerk.Text

                .Opmerkingen = tbTussenUitspraak.Text
                .Opmerkingen2 = tbOpmerkingen2.Text

                .VovoCB = chkVovoCB.Checked
                .VovoDat = uctdVovoDat.Value
                .VovoDatuit = uctdVovoDatUit.Value
                .DateField10 = uctdVovoIndienDatum.Value
                .DateField11 = uctdVovoVerweerSchrift.Value
                .VovoToev = tbVovotoev.Text
                .VoVoRecall = chkVoVoRecall.Checked

                If rbVoVoAfgewezen.Checked = True Then
                    .VovoUitsp = 1
                ElseIf rbVoVoToegewezen.Checked = True Then
                    .VovoUitsp = 2
                Else
                    .VovoUitsp = 0
                End If

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            If String.IsNullOrEmpty(uctdDatumBesluit.Value) Then
                Throw New Exception("Datum besluit verplicht!!")
                Exit Sub
            End If

            If rbAfwachting.Checked = False AndAlso String.IsNullOrEmpty(uctdBeslissingBeroep.Value) Then
                uctdBeslissingBeroep.Focus()
                Throw New Exception("Datum Beslissing Bezwaar ontbreekt")
                Exit Sub
            End If

            UpdateMyFaseClass()

            haschanged = da.isChanged(MyFase, "IBBFases", "Id", MyFase.Id, MyFase.Id, False)
            If Not MyFase.Found Then MyFase.Save()

            If MyFase.Besluit <> 1 Or MyFase.Besluit <> 4 Then
                ValidateOutlook()
            End If


            save()
            haschanged = False

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
    Private Sub save()
        Try
            If MyFase.TypeId = -1 Then Throw New Exception("Fase onbekend!!")

            Dim bUpdateEWS As Boolean = False
            'Als beslissingdatum is ingevuld
            If Not String.IsNullOrEmpty(MyFase.BeslissingBezwaar) Then
                'alleen als er wat is gewijzigd
                If Not haschanged Then Exit Sub
                'Verwijder alle toekomstige afspaken, behalve bij status "afwachting", maar dan zou ook geen beslissingdatum moeten zijn
                If Not rbAfwachting.Checked Then MyFase.DeleteFutureAppointmentsEWS()
                'en er nog geen volgende fase is aangemaakt
                If Not MyFase.NextJFaseExist Then
                    'dan de tijdelijke reminder zetten
                    Dim EindeBeroepDatum As Date = Format(MyFase.BeslissingBezwaar)
                    MyFase.DateTempObjection = EindeBeroepDatum.AddDays((6 * 7))
                    bUpdateEWS = True
                End If
            End If

            MyFase.Save()

            'dan de tijdelijke reminder verwerken
            If bUpdateEWS Then MyFase.UpdateAppointmentEWS("DateTempObjection")

            'Dim msgErrors As String = String.Empty

            'For Each msg In MyFase.AppointmentErrorList
            '    msgErrors += msg & vbCrLf
            'Next
            'MessageBox.Show(msgErrors, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub rbBob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rbName As String = DirectCast(sender, RadioButton).Name

        If rbAfwachting.Checked = True Then
            MyFase.Besluit = 0
        ElseIf rbGegrond.Checked = True Then
            MyFase.Besluit = 1
        ElseIf rbOnGegrond.Checked = True Then  'And rbName.ToLower = "rbongegrond" Then
            'Dim dlgRes As DialogResult = MessageBox.Show("Na het opslaan zal er automatisch een volgende fase worden aangemaakt.", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            'If dlgRes <> DialogResult.Yes Then
            '    CheckrbBob()
            '    Exit Sub
            'End If
            MyFase.Besluit = 2
        ElseIf rbNietOntv.Checked = True Then
            MyFase.Besluit = 3
        End If
        'Als bezwaar is ingetrokken, besluit overrulen met 4
        If chkIntrekking.Checked Then MyFase.Besluit = 4

    End Sub
    Private Sub CheckrbBob()
        Try
            Select Case MyFase.Besluit
                Case 0
                    rbAfwachting.Checked = True
                Case 1
                    rbGegrond.Checked = True
                Case 2
                    rbOnGegrond.Checked = True
                Case 3
                    rbNietOntv.Checked = True
                Case 4
                    'Bezwaar ingetrokken!
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub rbVovo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ActiveControl Is sender Then
            Dim radio As New RadioButton
            radio = sender
            MyFase.VovoUitsp = radio.Tag
        End If
    End Sub


    Private Sub ValidateOutlook()
        Try
            Dim lbl1 As New Label
            Dim lbl2 As New Label
            Dim lbl3 As New Label
            Dim lbl4 As New Label
            Dim lbl5 As New Label
            Dim chk1 As New CheckBox
            Dim chk2 As New CheckBox
            Dim chk3 As New CheckBox
            Dim chk4 As New CheckBox
            Dim chk5 As New CheckBox
            Dim lbl6 As New Label
            Dim chk6 As New CheckBox

            Dim bOutlookChanges As Boolean = False

            'Bezwaar termijn
            If MyFase.Indiendatum <> _MyOriginalFase.Indiendatum Then
                bOutlookChanges = True
                chk1.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryObjectionId) Then aot = " toevoegen"
                lbl1.Text = "Datum beroep termijn reminder in outlook" & aot
            Else
                lbl1.Text = "Datum beroep termijn is ongewijzigd"
                chk1.Enabled = Not String.IsNullOrEmpty(MyFase.Indiendatum)
            End If

            'Herstel verzuim
            If MyFase.Herstelverzuimtermijn <> _MyOriginalFase.Herstelverzuimtermijn Then
                bOutlookChanges = True
                chk2.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryHerstelId) Then aot = " toevoegen"
                lbl2.Text = "Datum Herstel verzuimtermijn reminder in outlook" & aot
            Else
                chk2.Enabled = Not String.IsNullOrEmpty(MyFase.Herstelverzuimtermijn)
                lbl2.Text = "Datum Herstel verzuimtermijn is ongewijzigd"
            End If

            'Hoorzitting
            If MyFase.Hoorzittingdatum <> _MyOriginalFase.Hoorzittingdatum Then
                bOutlookChanges = True
                chk3.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryHoorzittingId) Then aot = " toevoegen"
                lbl3.Text = "Datum Hoorzitting reminder in outlook" & aot
            Else
                chk3.Enabled = Not String.IsNullOrEmpty(MyFase.Hoorzittingdatum)
                lbl3.Text = "Datum Hoorzitting termijn is ongewijzigd"
            End If

            'Vovo datum
            If MyFase.VovoDat <> _MyOriginalFase.VovoDat Then
                bOutlookChanges = True
                chk6.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryBesluitId) Then aot = " toevoegen"
                lbl6.Text = "Datum vovo zitting reminder in outlook" & aot
            Else
                chk6.Enabled = Not String.IsNullOrEmpty(MyFase.VovoDat)
                lbl6.Text = "Datum vovo zitting  termijn is ongewijzigd"
            End If

            Dim AanpassenOfToevoegen As String = " aanpassen?"
            'If haschanged = True AndAlso chk1.Checked = False AndAlso chk2.Checked = False AndAlso chk3.Checked = False AndAlso chk4.Checked = False Then
            '    bOutlookChanges = True
            '    AanpassenOfToevoegen = " toevoegen?"
            'End If


            If bOutlookChanges = True Then
                Dim dlgAsk As New dlgAskIt
                Dim LastY As Integer = 0
                Dim iLabelPositionX As Integer = 0
                Dim mylabel As New Label

                dlgAsk.StartPosition = FormStartPosition.CenterScreen
                mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                mylabel.Text = "Wilt u ook de reminders in outlook ook" & AanpassenOfToevoegen
                mylabel.AutoSize = True
                dlgAsk.Controls.Add(mylabel)

                chk1.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
                chk1.Name = "chk1"
                chk1.Text = ""
                chk1.AutoSize = True
                dlgAsk.Controls.Add(chk1)
                LastY = chk1.Location.Y
                iLabelPositionX = chk1.Location.X + 20

                lbl1.Location = New Point(iLabelPositionX, LastY)
                lbl1.AutoSize = True
                dlgAsk.Controls.Add(lbl1)

                chk2.Location = New Point(mylabel.Location.X, LastY + 20)
                chk2.Name = "chk2"
                chk2.Text = ""
                chk2.AutoSize = True
                dlgAsk.Controls.Add(chk2)
                LastY = chk2.Location.Y

                lbl2.Location = New Point(iLabelPositionX, LastY)
                lbl2.AutoSize = True
                dlgAsk.Controls.Add(lbl2)

                chk3.Location = New Point(mylabel.Location.X, LastY + 20)
                chk3.Name = "chk3"
                chk3.Text = ""
                chk3.AutoSize = True
                dlgAsk.Controls.Add(chk3)
                LastY = chk3.Location.Y

                lbl3.Location = New Point(iLabelPositionX, LastY)
                lbl3.AutoSize = True
                dlgAsk.Controls.Add(lbl3)

                chk6.Location = New Point(mylabel.Location.X, LastY + 20)
                chk6.Name = "chk6"
                chk6.Text = ""
                chk6.AutoSize = True
                dlgAsk.Controls.Add(chk6)
                LastY = chk6.Location.Y

                lbl6.Location = New Point(iLabelPositionX, LastY)
                lbl6.AutoSize = True
                dlgAsk.Controls.Add(lbl6)

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    Exit Sub
                Else
                    If chk1.Checked = True Then btnOutlookBezwaar_Click(Me, New EventArgs)
                    If chk2.Checked = True Then btnOutlookHerstelVerzuim_Click(Me, New EventArgs)
                    If chk3.Checked = True Then btnOutlookHoorzitting_Click(Me, New EventArgs)
                    If chk6.Checked = True Then btnOutlookVoVoDat_Click(Me, New EventArgs)
                End If
            End If

        Catch ex As Exception
            Throw ex
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

                Dim mylabel2 As New Label
                mylabel2.Location = New Point(mylabel.Location.X, LastY + 20)
                mylabel2.Text = "Intrekking beroep wordt " & Today
                mylabel2.AutoSize = True
                LastY = mylabel2.Location.Y
                dlgAsk.Controls.Add(mylabel2)

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    chkIntrekking.Checked = False
                    Exit Sub
                Else
                    'sluit huidige fase
                    uctdBeslissingBeroep.Value = Today
                    MyFase.Besluit = 4
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
                        'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                        'ChildForm.Save()
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnOutlookBezwaar_Click(sender As Object, e As EventArgs) Handles btnOutlookBezwaar.Click
        Try
            UpdateOutlook("Indiendatum")

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnOutlookHerstelVerzuim_Click(sender As Object, e As EventArgs) Handles btnOutlookHerstelVerzuim.Click
        Try
            UpdateOutlook("Herstelverzuimtermijn")

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnOutlookHoorzitting_Click(sender As Object, e As EventArgs) Handles btnOutlookHoorzitting.Click
        Try
            UpdateOutlook("Hoorzittingdatum")

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub uctdVoorlopigBeroep_TextChanged() Handles uctdVoorlopigBeroep.GenerateTextChanged
        Try
            Try
                If Not String.IsNullOrEmpty(uctdVoorlopigBeroep.Value) Then 'AndAlso Not chkAanhBeroep.Checked
                    lblBezwaar.Text = "Nadere gronden"
                Else
                    lblBezwaar.Text = "Beroepschrift"
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkAanhBeroep_CheckedChanged(sender As Object, e As EventArgs) Handles chkAanhBeroep.CheckedChanged
        Try

            If chkAanhBeroep.Focused AndAlso chkAanhBeroep.Checked Then
                If String.IsNullOrEmpty(uctdVoorlopigBeroep.Value) Then
                    chkAanhBeroep.Checked = False
                    Throw New Exception("Een aanhouding kan alleen indien er al een voorlopig beroep is gedaan")
                    Exit Sub
                End If
                Dim dlgRes As DialogResult = MessageBox.Show("Let op! Als u doorgaat wordt ''Herstel verzuimtermijn'' direct verwijderd. " & _
                                                             "incl de Outlook reminders.", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    DeleteHerstelverzuimtermijn()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uctdDatumBesluit_TextChanged() Handles uctdDatumBesluit.GenerateTextChanged
        Try
            'controleer of er daadwerkelijk iets is gewijzigd
            If uctdDatumBesluit.Value = MyFase.Beslisdatum Then
                Exit Sub
            End If

            If String.IsNullOrEmpty(uctdDatumBesluit.tb.Text) Then
                Throw New Exception("datum besluit is niet ingevuld!")
            End If

            If Not String.IsNullOrEmpty(tbWeken1.Text) AndAlso Not IsNumeric(tbWeken1.Text) Then
                Throw New Exception("Aantal weken is niet correct ingevuld!")
            End If

            If Not String.IsNullOrEmpty(tbWeken2.Text) AndAlso Not IsNumeric(tbWeken2.Text) Then
                Throw New Exception("Aantal weken is niet correct ingevuld!")
            End If

            If String.IsNullOrEmpty(uctdBeroepsTermijn.Value) Then
                Dim DecisionDate As Date = uctdDatumBesluit.Value
                uctdBeroepsTermijn.Value = DecisionDate.AddDays(CInt(tbWeken1.Text) * 7)
            End If

            UpdateMyFaseClass()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CalculateWeeks()
        Try
            If Not String.IsNullOrEmpty(uctdDatumBesluit.Value) AndAlso Not String.IsNullOrEmpty(uctdBeroepsTermijn.Value) Then
                Dim iWeek As Integer = DateDiff(DateInterval.Weekday, uctdDatumBesluit.Value, uctdBeroepsTermijn.Value)
                tbWeken1.Text = iWeek
            End If

            ''als Herstelverzuimtermijn dan hier vanuit gaan.
            'If Not String.IsNullOrEmpty(uctdDatumBesluit.Value) AndAlso Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Then
            '    Dim iWeek As Integer = DateDiff(DateInterval.Weekday, uctdHerstelverzuimtermijn.Value, uctdEindeBeslisTermijn.Value)
            '    tbWeken2.Text = iWeek
            '    lblWeken2.Text = "Weken na Herstel"
            'ElseIf Not String.IsNullOrEmpty(uctdEindeBeslisTermijn.Value) Then
            '    Dim iWeek As Integer = DateDiff(DateInterval.Weekday, uctdDatumBesluit.Value, uctdEindeBeslisTermijn.Value)
            '    tbWeken2.Text = iWeek
            '    lblWeken2.Text = "Weken na Besluit"
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub tbWeken1_TextChanged(sender As Object, e As EventArgs) Handles tbWeken1.TextChanged
        Try
            'om een loop te voorkomen, dit alleen uit voeren als het via tbweken wordt aangepast.
            If Not tbWeken1.Focused Then Exit Sub

            If Not String.IsNullOrEmpty(tbWeken1.Text) AndAlso Not String.IsNullOrEmpty(uctdBeroepsTermijn.Value) Then
                Dim DecisionDate As Date = uctdDatumBesluit.Value
                uctdBeroepsTermijn.Value = DecisionDate.AddDays(CInt(tbWeken1.Text) * 7)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub uctdBeroepSchrift_GenerateTextChanged() Handles uctdBeroepSchrift.GenerateTextChanged
        Try

            If Not String.IsNullOrEmpty(uctdBeroepSchrift.Value) Then

                If Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Then
                    'Alleen uitvoeren als er uberhaupt een waarde was.

                    Dim dlgRes As DialogResult = MessageBox.Show("Let op! Als u doorgaat wordt ''Herstel verzuimtermijn'' direct verwijderd. " & _
                                                                 "incl de Outlook reminders.", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If dlgRes = Windows.Forms.DialogResult.Yes Then
                        DeleteHerstelverzuimtermijn()
                    Else
                        uctdBeroepSchrift.Value = String.Empty
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteHerstelverzuimtermijn()
        Try
            uctdHerstelverzuimtermijn.Value = String.Empty
            MyFase.UpdateAppointmentEWS("Herstelverzuimtermijn")
            _MyOriginalFase.Herstelverzuimtermijn = String.Empty

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ModuleName As String = Me.Name
        Try
            OpenHelpUrl(ModuleName)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnOutlookVoVoDat_Click(sender As Object, e As EventArgs) Handles btnOutlookVoVoDat.Click
        Try
            UpdateOutlook("VoVoDat")
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateOutlook(ByVal dbcolumn As String)
        Try

            UpdateMyFaseClass()

            MyFase.UpdateAppointmentEWS(dbcolumn)

            'ook even de clone updaten, anders komt de vraag nog een keer bij alfsluiten from.
            CloneMyFase()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
