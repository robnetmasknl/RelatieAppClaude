Imports System.Windows.Forms
Imports BusinessObjects
Imports MapiObjects
Imports Microsoft.Office.Interop

Public Class dlgJdTypeObjection
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance
    Private FaseId As Integer = -1
    Private DossierId As Integer = -1
    Public FaseTypeId As Integer = -1
    ' Private MapiObject As New MapiObject(GetSysSettingOf("IBBCalAccount"))
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

        'If da.Settings.FontSize >= 9 Then
        Me.Location = New Point(Me.Location.X, 10)
        'End If

    End Sub
    Private Sub dlgJdTypeObjection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Changelayout()
            BindForm()

            Me.Text = MyFase.Fase.Description

            AddHandler rbGegrond.CheckedChanged, AddressOf rbBob_CheckedChanged
            AddHandler rbOnGegrond.CheckedChanged, AddressOf rbBob_CheckedChanged
            AddHandler rbNietOntv.CheckedChanged, AddressOf rbBob_CheckedChanged
            AddHandler rbAfwachting.CheckedChanged, AddressOf rbBob_CheckedChanged

            AddHandler rbVoVoAfgewezen.CheckedChanged, AddressOf rbVovo_CheckedChanged
            AddHandler rbVoVoAfwachting.CheckedChanged, AddressOf rbVovo_CheckedChanged
            AddHandler rbVoVoToegewezen.CheckedChanged, AddressOf rbVovo_CheckedChanged

            AddHandler rdExtraUit.CheckedChanged, AddressOf rdExtra_CheckedChanged
            AddHandler rdExtra6.CheckedChanged, AddressOf rdExtra_CheckedChanged
            AddHandler rdExtraHand.CheckedChanged, AddressOf rdExtra_CheckedChanged

            btnClearDbCalEntries.Visible = URights.UserName = "bert"

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
    Private Sub BindForm()
        Try
            With MyFase
                If Not MyFase.Found Then
                    Me.Text &= "Nieuw"
                    .DossierId = DossierId
                    .TypeId = FaseTypeId
                    .Besluit = 0
                    .CreateDate = Now
                    .CreatedBy = URights.UserName
                    'haal de indiendatum uit de vorige fase indien aanwezig, anders datum vandaag
                    If MyIBBDossier.ListIBBFases.Count > 0 Then
                        Dim VorigeFase As IBBFase = MyIBBDossier.ListIBBFases.First 'MyIBBDossier.ListIBBFases.Item(MyIBBDossier.ListIBBFases.Count - 1)
                        Select Case VorigeFase.Fase.Type
                            Case "VRZ", "VN", "CLM"
                                .Beslisdatum = VorigeFase.Beslisdatum
                            Case Else
                                .Beslisdatum = VorigeFase.BeslissingBezwaar
                        End Select
                    Else
                        .Beslisdatum = Today
                    End If

                Else
                    'uctdDecisionDate.Enabled = False
                End If

                uctdDecisionDate.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "Beslisdatum", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdBezwaarTermijn.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "Indiendatum", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdVerloopigBezwaar.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "VoorloopigBezwaar", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdBezwaarschrift.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "Bezwaarschrift", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdHerstelverzuimtermijn.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "Herstelverzuimtermijn", True, DataSourceUpdateMode.OnPropertyChanged))

                chkAanhBezw.DataBindings.Add("Checked", MyFase, "AanhBezw", True)
                '   chkExtra6Weken.DataBindings.Add("Checked", MyFase, "Extra6Weken", True)

                uctdHoorzitting.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "Hoorzittingdatum", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdSchriftelijkeReactie.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "DateField8", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdEindeBeslisTermijn.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "Ingebreke", True, DataSourceUpdateMode.OnPropertyChanged))

                tbKenmerk.DataBindings.Add(New Binding("Text", MyFase, "Kenmerk"))
                tbOpmerkingen.DataBindings.Add(New Binding("Text", MyFase, "Opmerkingen"))
                uctdBeslissingBezwaar.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "BeslissingBezwaar", True, DataSourceUpdateMode.OnPropertyChanged))

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

                tbOpmerkingen2.DataBindings.Add(New Binding("Text", MyFase, "Opmerkingen2"))

                chkIngebrekestelling.DataBindings.Add("Checked", MyFase, "IngebrekeStelling", True)
                uctdBeslissingIngebreke.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "IngebrekeBeslissingDatum", True, DataSourceUpdateMode.OnPropertyChanged))

                tbInGebreke.DataBindings.Add(New Binding("Text", MyFase, "IngebrekeOpmerkingen"))

                chkVovoCB.DataBindings.Add("Checked", MyFase, "VovoCB", True)
                uctdVovoDat.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "VovoDat", True, DataSourceUpdateMode.OnPropertyChanged)) ' Data.SqlTypes.SqlDateTime.MinValue, "dd-MM-yyyy")
                uctdVovoDatUit.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "VovoDatuit", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdVovoIndienDatum.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "DateField10", True, DataSourceUpdateMode.OnPropertyChanged))
                uctdVovoVerweerSchrift.tb.DataBindings.Add(New Binding("Text", Me.MyFase, "DateField11", True, DataSourceUpdateMode.OnPropertyChanged))
                tbVovotoev.DataBindings.Add(New Binding("Text", MyFase, "VovoToev"))
                chkVoVoRecall.DataBindings.Add("Checked", MyFase, "VoVoRecall", True)
                chkIntrekking.DataBindings.Add("Checked", MyFase, "Intrekking", True)

                Select Case MyFase.VovoUitsp
                    Case 0
                        rbVoVoAfwachting.Checked = True
                    Case 1
                        rbVoVoAfgewezen.Checked = True
                    Case 2
                        rbVoVoToegewezen.Checked = True
                End Select


                Select Case MyFase.ExtraWeken
                    Case 0
                        rdExtraUit.Checked = True
                    Case 1
                        rdExtra6.Checked = True
                    Case 2
                        rdExtraHand.Checked = True
                End Select


                CalculateWeeks()

                If Not MyFase.NextJFaseExist And Not String.IsNullOrEmpty(MyFase.BeslissingBezwaar) Then
                    'dan de tijdelijke reminder zetten
                    Dim EindeBeroepDatum As Date = Format(MyFase.BeslissingBezwaar)
                    MyFase.DateTempObjection = EindeBeroepDatum.AddDays((6 * 7))
                    Dim jdtr As jdTranslate = New jdTranslate(MyFase.TypeId, "DateTempObjection")
                    lblBezwaartermijn.Text = jdtr.Description & " " & EindeBeroepDatum.AddDays((6 * 7))
                End If

                If Not MyFase.Found Then UpdateDates()

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub uctdDecisionDate_Leave(sender As Object, e As EventArgs) Handles uctdDecisionDate.Leave
        Try 'uctdDecisionDate_TextChanged
            If MyFase.Beslisdatum <> _MyOriginalFase.Beslisdatum Then
                UpdateDates()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub uctdVerloopigBezwaar_Leave(sender As Object, e As EventArgs) Handles uctdVerloopigBezwaar.Leave
        Try   'uctdVerloopigBezwaar_TextChanged
            If MyFase.VoorloopigBezwaar <> _MyOriginalFase.VoorloopigBezwaar Then
                UpdateDates()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub uctdBezwaarschrift_Leave(sender As Object, e As EventArgs) Handles uctdBezwaarschrift.Leave
        Try    'uctdBezwaarschrift_TextChanged
            If MyFase.Bezwaarschrift <> _MyOriginalFase.Bezwaarschrift Then
                UpdateDates()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub uctdHerstelverzuimtermijn_Leave(sender As Object, e As EventArgs) Handles uctdHerstelverzuimtermijn.Leave
        Try   'uctdHerstelverzuimtermijn_TextChanged
            If MyFase.Herstelverzuimtermijn <> _MyOriginalFase.Herstelverzuimtermijn Then
                UpdateDates()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '
    Private Sub chkAanhBezw_CheckedChanged(sender As Object, e As EventArgs) Handles chkAanhBezw.CheckedChanged
        Try    'chkAanhBezw_CheckedChanged

            MyFase.AanhBezw = chkAanhBezw.Checked
            If chkAanhBezw.Focused Then
                If chkAanhBezw.Checked Then
                    If String.IsNullOrEmpty(uctdVerloopigBezwaar.Value) And String.IsNullOrEmpty(uctdBezwaarschrift.Value) Then
                        chkAanhBezw.Checked = False
                        Throw New Exception("Een aanhouding kan alleen indien er al een voorlopig bezwaar en/of een bezwaarschrift is gemaakt")
                        Exit Sub
                    End If
                    uctdEindeBeslisTermijn.tb.Text = ""
                End If

                UpdateDates()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '

    'Private Sub chkExtra6Weken_CheckedChanged(sender As Object, e As EventArgs) Handles chkExtra6Weken.CheckedChanged
    '    Try    'chkExtra6Weken_CheckedChanged
    '        If chkExtra6Weken.Focused Then
    '            MyFase.Extra6Weken = chkExtra6Weken.Checked
    '            UpdateDates()
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'tbWeken1_TextChanged
    Private Sub tbWeken1_TextChanged(sender As Object, e As EventArgs) Handles tbWeken1.TextChanged
        Try
            'om een loop te voorkomen, dit alleen uit voeren als het via tbweken wordt aangepast.
            If Not tbWeken1.Focused Then Exit Sub

            If Not String.IsNullOrEmpty(tbWeken1.Text) AndAlso Not String.IsNullOrEmpty(uctdBezwaarTermijn.Value) Then
                UpdateDates()
                uctdBezwaarTermijn.tb.Text = MyFase.Indiendatum
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalculateWeeks()
        Try
            If Not String.IsNullOrEmpty(uctdDecisionDate.Value) AndAlso Not String.IsNullOrEmpty(uctdBezwaarTermijn.Value) Then
                Dim iWeek As Integer = DateDiff(DateInterval.Weekday, uctdDecisionDate.Value, uctdBezwaarTermijn.Value)
                tbWeken1.Text = iWeek
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateDates()
        Try
            With MyFase

                'Bezwaartermijn=Datum besluit+weken1*7
                Dim DateDatumBesluit As Date
                Dim iWeeks As Integer = Int(tbWeken1.Text)

                If Not String.IsNullOrEmpty(uctdDecisionDate.tb.Text) Then
                    DateDatumBesluit = uctdDecisionDate.tb.Text
                    uctdBezwaarTermijn.tb.Text = DateDatumBesluit.AddDays(iWeeks * 7)
                End If

                tbWeken2.Text = 6
                ' *** aanpassing bg:971 ***
                ' *** Einde beslistermijn veld 6 extra weken wordt radio button met drie keuzes ***
                ' If .Extra6Weken = True Then tbWeken2.Text = 12
                Dim bUpdateEindebeslissing As Boolean = True
                If rdExtraUit.Checked = True Then
                    ' standaard
                ElseIf rdExtra6.Checked = True Then
                    tbWeken2.Text = 12
                ElseIf rdExtraHand.Checked = True Then
                    bUpdateEindebeslissing = False
                End If


                Dim DateBezwaarschrift As Date
                Dim DateBezwaarTermijn As Date

                If Not String.IsNullOrEmpty(uctdBezwaarschrift.tb.Text) Then
                    DateBezwaarschrift = uctdBezwaarschrift.tb.Text
                End If
                If Not String.IsNullOrEmpty(uctdBezwaarTermijn.tb.Text) Then
                    DateBezwaarTermijn = uctdBezwaarTermijn.tb.Text
                End If

                'If voorlopig bezwaar <> ‘’ Then
                If Not String.IsNullOrEmpty(uctdVerloopigBezwaar.tb.Text) Then
                    'Einde beslistermijn = ‘’
                    uctdEindeBeslisTermijn.tb.Text = ""
                    ' LabelBezwaarschrift = "Nadere gronden van Bezwaar"
                    lblWeken2.Text = "Weken na Herstel"
                    lblBezwaar.Text = "Nadere gronden"


                    'If Bezwaarschrift <> ‘’ Then
                    If Not String.IsNullOrEmpty(.Bezwaarschrift) Then
                        Dim iWeeks2 As Integer = Int(tbWeken2.Text)
                        'If Bezwaarschrift > bezwaartermijn Then
                        If DateBezwaarschrift > DateBezwaarTermijn Then
                            ' Einde Beslistermijn = Bezwaarschrift + weken2 * 7
                            If bUpdateEindebeslissing Then uctdEindeBeslisTermijn.tb.Text = DateBezwaarschrift.AddDays(iWeeks2 * 7)
                        Else
                            ' Einde Beslistermijn=Bezwaar terijn + weken2*7
                            If bUpdateEindebeslissing Then uctdEindeBeslisTermijn.tb.Text = DateBezwaarTermijn.AddDays(iWeeks2 * 7)
                        End If
                        'Herstelverzuimtermijn=’’
                        uctdHerstelverzuimtermijn.tb.Text = ""
                    Else
                        ' *** aanpassing bg:971 ***
                        ' *** Herstel verzuim termijn NIET automatisch vullen ***
                        'If String.IsNullOrEmpty(.Herstelverzuimtermijn) Then
                        '   Dim DateVerloopigBezwaar As Date = .VoorloopigBezwaar
                        '   uctdHerstelverzuimtermijn.tb.Text = DateVerloopigBezwaar.AddDays(4 * 7)
                        'End If
                        uctdEindeBeslisTermijn.tb.Text = ""
                    End If

                Else
                    'Herstelverzuimtermijn = ‘’
                    uctdHerstelverzuimtermijn.tb.Text = ""

                    'LabelBezwaarschrift = "Bezwaarschrift"
                    lblBezwaar.Text = "Bezwaarschrift"

                    Dim iWeeks2 As Integer = Int(tbWeken2.Text)

                    'If Bezwaarschrift <> ‘’ Then
                    If Not String.IsNullOrEmpty(.Bezwaarschrift) Then
                        'If Bezwaarschrift > bezwaartermijn 
                        If DateBezwaarschrift > DateBezwaarTermijn Then
                            'Einde Beslistermijn = Bezwaarschrift + weken2 * 7
                            If bUpdateEindebeslissing Then uctdEindeBeslisTermijn.tb.Text = DateBezwaarschrift.AddDays(iWeeks2 * 7)
                        Else
                            'Einde Beslistermijn=Bezwaar termijn + weken2*7
                            If bUpdateEindebeslissing Then uctdEindeBeslisTermijn.tb.Text = DateBezwaarTermijn.AddDays(iWeeks2 * 7)
                        End If
                    Else
                        ' Einde Beslistermijn=Datum besluit+weken1*7+weken2*7
                        If bUpdateEindebeslissing Then uctdEindeBeslisTermijn.tb.Text = DateDatumBesluit.AddDays((iWeeks * 7) + (iWeeks2 * 7))
                    End If

                End If

                If .AanhBezw = True Then
                    uctdHerstelverzuimtermijn.tb.Text = ""
                    uctdEindeBeslisTermijn.tb.Text = ""
                End If

            End With


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Sub UpdateFaseDates()
    '    Try
    '        With MyFase

    '            'Bezwaartermijn=Datum besluit+weken1*7
    '            Dim DateDatumBesluit As Date = .Beslisdatum
    '            Dim iWeeks As Integer = Int(tbWeken1.Text)
    '            .Indiendatum = DateDatumBesluit.AddDays(iWeeks * 7)
    '            'Weken2 = 6
    '            tbWeken2.Text = 6
    '            'If verzoek 6 weken extra =true then Weken2 = 12
    '            If .Extra6Weken = True Then tbWeken2.Text = 12



    '            If Not String.IsNullOrEmpty(.VoorloopigBezwaar) Then
    '                Dim DateBezwaarschrift As Date = .Bezwaarschrift
    '                Dim DateBezwaarTermijn As Date = .Indiendatum
    '                Dim DateEindeBeslisTermijn As Date = .Ingebreke
    '                ' If Aanhoudingbezwaar = ‘’ Then
    '                '		Einde beslistermijn = ‘’
    '                ' End If
    '                If .AanhBezw = True Then
    '                    .Ingebreke = ""
    '                End If

    '                ' LabelBezwaarschrift = "Nadere gronden van Bezwaar"
    '                lblWeken2.Text = "Weken na Herstel"
    '                lblBezwaar.Size = New Size(86, 35)
    '                lblBezwaar.Location = New Point(lblBezwaar.Location.X, 100)
    '                lblBezwaar.Text = "Nadere gronden van bezwaar"

    '                'If Bezwaarschrift <> ‘’ Then
    '                If Not String.IsNullOrEmpty(.Bezwaarschrift) Then
    '                    '   If Bezwaarschrift > bezwaartermijn Then

    '                    Dim iWeeks2 As Integer = Int(tbWeken2.Text)
    '                    If DateBezwaarschrift > DateBezwaarTermijn Then
    '                        ' Einde Beslistermijn = Bezwaarschrift + weken2 * 7
    '                        .Ingebreke = DateBezwaarschrift.AddDays(iWeeks2 * 7)
    '                    Else
    '                        ' Einde Beslistermijn=Bezwaar terijn+weken2*7

    '                        .Ingebreke = DateBezwaarTermijn.AddDays(iWeeks2 * 7)
    '                    End If
    '                    '   Herstelverzuimtermijn=’’
    '                    .Herstelverzuimtermijn = ""
    '                Else
    '                    '   If Herstelverzuimtermijn = ‘’ then
    '                    If String.IsNullOrEmpty(.Herstelverzuimtermijn) Then
    '                        Dim DateVerloopigBezwaar As Date = .VoorloopigBezwaar
    '                        'Herstelverzuimtermijn=Voorlopig bezwaar+4*7
    '                        .Herstelverzuimtermijn = DateVerloopigBezwaar.AddDays(4 * 7)
    '                    End If
    '                    '   Einde beslistermijn = ‘’
    '                    .Ingebreke = ""
    '                End If

    '            Else
    '                'Herstelverzuimtermijn = ‘’
    '                .Herstelverzuimtermijn = ""

    '                'LabelBezwaarschrift = "Bezwaarschrift"
    '                lblBezwaar.Size = New Size(76, 13)
    '                lblBezwaar.Location = New Point(284, 107)
    '                lblBezwaar.Text = "Bezwaarschrift"
    '                Dim iWeeks2 As Integer = Int(tbWeken2.Text)
    '                'If Bezwaarschrift <> ‘’ Then
    '                If Not String.IsNullOrEmpty(.Bezwaarschrift) Then
    '                    Dim DateBezwaarschrift As Date = .Bezwaarschrift
    '                    Dim DateBezwaarTermijn As Date = .Indiendatum
    '                    Dim DateEindeBeslisTermijn As Date = .Ingebreke
    '                    If DateBezwaarschrift > DateBezwaarTermijn Then
    '                        'Einde Beslistermijn = Bezwaarschrift + weken2 * 7
    '                        .Ingebreke = DateBezwaarschrift.AddDays(iWeeks2 * 7)
    '                    Else
    '                        'Einde Beslistermijn=Bezwaar terijn+weken2*7
    '                        .Ingebreke = DateBezwaarTermijn.AddDays(iWeeks2 * 7)
    '                    End If
    '                Else
    '                    ' Einde Beslistermijn=Datum besluit+weken1*7+weken2*7
    '                    .Ingebreke = DateDatumBesluit.AddDays((iWeeks * 7) + (iWeeks2 * 7))
    '                End If


    '            End If

    '            ' If Aanhoudingbezwaar = True Then
    '            '       Hestelverzuimtermijn=’’
    '            ' End If
    '            If .AanhBezw = True Then
    '                .Herstelverzuimtermijn = ""
    '            End If

    '        End With



    '        'Pas nu valideren of velden inderdaad gewijzigd zijn en zo ja, de reminder goed zetten.

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub UpdateMyFaseClass()
        Try
            With MyFase


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
            If String.IsNullOrEmpty(uctdDecisionDate.Value) Then
                Throw New Exception("Datum besluit verplicht!!")
                Exit Sub
            End If

            If rbAfwachting.Checked = False AndAlso String.IsNullOrEmpty(uctdBeslissingBezwaar.Value) Then
                uctdBeslissingBezwaar.Focus()
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

                    Dim jdtr As jdTranslate = New jdTranslate(MyFase.TypeId, "DateTempObjection")
                    lblBezwaartermijn.Text = jdtr.Description & " " & EindeBeroepDatum.AddDays((6 * 7))

                End If
            End If

            MyFase.Save()

            'dan de tijdelijke reminder verwerken
            If bUpdateEWS Then MyFase.UpdateAppointmentEWS("DateTempObjection")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub rdExtra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If rdExtraUit.Checked = True Then
                MyFase.ExtraWeken = 0
            ElseIf rdExtra6.Checked = True Then
                MyFase.ExtraWeken = 1
            ElseIf rdExtraHand.Checked = True Then
                MyFase.ExtraWeken = 2
            End If
            UpdateDates()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbBob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim rbName As String = DirectCast(sender, RadioButton).Name

            If rbAfwachting.Checked = True Then
                MyFase.Besluit = 0
            ElseIf rbGegrond.Checked = True Then
                MyFase.Besluit = 1
            ElseIf rbOnGegrond.Checked = True And rbName.ToLower = "rbongegrond" Then
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

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                lbl1.Text = "Datum Bezwaar termijn reminder in outlook" & aot
            Else
                chk1.Enabled = Not String.IsNullOrEmpty(MyFase.Indiendatum)
                lbl1.Text = "Datum Bezwaar termijn is ongewijzigd"
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

            'schriftelijke reactie
            If MyFase.DateField8 <> _MyOriginalFase.DateField8 Then
                bOutlookChanges = True
                chk4.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntry8) Then aot = " toevoegen"
                lbl4.Text = "Datum schriftelijke reactie reminder in outlook" & aot
            Else
                chk4.Enabled = Not String.IsNullOrEmpty(MyFase.DateField8)
                lbl4.Text = "Datum schriftelijke reactie is ongewijzigd"
            End If

            'Einde beslis termijn
            If MyFase.Ingebreke <> _MyOriginalFase.Ingebreke Then
                bOutlookChanges = True
                chk5.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryBesluitId) Then aot = " toevoegen"
                lbl5.Text = "Datum Einde beslis termijn reminder in outlook" & aot
            Else
                chk5.Enabled = Not String.IsNullOrEmpty(MyFase.Ingebreke)
                lbl5.Text = "Datum Einde beslis termijn is ongewijzigd"
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
                lbl6.Text = "Datum vovo zitting termijn is ongewijzigd"
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


                chk4.Location = New Point(mylabel.Location.X, LastY + 20)
                chk4.Name = "chk4"
                chk4.Text = ""
                chk4.AutoSize = True
                dlgAsk.Controls.Add(chk4)
                LastY = chk4.Location.Y

                lbl4.Location = New Point(iLabelPositionX, LastY)
                lbl4.AutoSize = True
                dlgAsk.Controls.Add(lbl4)

                chk5.Location = New Point(mylabel.Location.X, LastY + 20)
                chk5.Name = "chk5"
                chk5.Text = ""
                chk5.AutoSize = True
                dlgAsk.Controls.Add(chk5)
                LastY = chk5.Location.Y

                lbl5.Location = New Point(iLabelPositionX, LastY)
                lbl5.AutoSize = True
                dlgAsk.Controls.Add(lbl5)

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
                    If chk4.Checked = True Then btnOutlookSchriftelijkeReactie_Click(Me, New EventArgs)
                    If chk5.Checked = True Then btnOutlookEindeBeslis_Click(Me, New EventArgs)
                    If chk6.Checked = True Then btnOutlookVoVoDat_Click(Me, New EventArgs)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkIngebrekestelling_CheckedChanged(sender As Object, e As EventArgs) Handles chkIngebrekestelling.CheckedChanged
        If Not chkIngebrekestelling.Checked Then
            uctdBeslissingIngebreke.Value = ""
            tbInGebreke.Text = ""
        End If
        uctdBeslissingIngebreke.Enabled = chkIngebrekestelling.Checked
        tbInGebreke.Enabled = chkIngebrekestelling.Checked
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

                'Dim mylabel2 As New Label
                'mylabel2.Location = New Point(mylabel.Location.X, LastY + 20)
                'mylabel2.Text = "Beslissing Bezwaar wordt " & Today
                'mylabel2.AutoSize = True
                'LastY = mylabel2.Location.Y
                'dlgAsk.Controls.Add(mylabel2)

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    chkIntrekking.Checked = False
                    Exit Sub
                Else
                    'sluit huidige fase
                    uctdBeslissingBezwaar.Value = Today
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
                        ChildForm.uctdEndDate.tb.Text = Today
                        'Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
                        'ChildForm.Save()
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub



    'Private Sub uctdVerloopigBezwaar_TextChanged() Handles uctdVerloopigBezwaar.GenerateTextChanged
    '    Try

    '        If Not String.IsNullOrEmpty(uctdVerloopigBezwaar.Value) AndAlso Not chkAanhBezw.Checked Then

    '            'Alleen EindeBeslisTermijn leeg maken als er GEEN Bezwaarschrift is
    '            If String.IsNullOrEmpty(uctdBezwaarschrift.Value) Then uctdEindeBeslisTermijn.Value = String.Empty

    '            'volgens aanpassingen v2.9.5.1 doc het onderstaande toch maar weer niet.

    '            ''Voorlopig bezwaar, indien hier een datum wordt ingevuld wordt de “Herstel verzuimtermijn” gevuld met een datum 4 weken na Voorlopig bezwaar. 
    '            ''De einde beslistermijn wordt 6 weken na herstel verzuimtermijn.
    '            ''tenzij het vinkje verzoek 6 weken extra is aangevinkt. In dat geval wordt het 12 weken.
    '            'Dim myDate As Date = uctdVerloopigBezwaar.Value
    '            'uctdHerstelverzuimtermijn.Value = myDate.AddDays(4 * 7)

    '            'If chkExtra6Weken.Checked Then
    '            '    tbWeken2.Text = 12
    '            'Else
    '            '    tbWeken2.Text = 6
    '            'End If

    '            'myDate = uctdHerstelverzuimtermijn.Value
    '            'uctdEindeBeslisTermijn.Value = myDate.AddDays(Int(tbWeken2.Text) * 7)

    '            lblWeken2.Text = "Weken na Herstel"
    '            lblBezwaar.Size = New Size(86, 35)
    '            lblBezwaar.Location = New Point(lblBezwaar.Location.X, 100)
    '            lblBezwaar.Text = "Nadere gronden van bezwaar"

    '        Else
    '            lblBezwaar.Size = New Size(76, 13)
    '            lblBezwaar.Location = New Point(284, 107)
    '            lblBezwaar.Text = "Bezwaarschrift"
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub uctdBezwaarschrift_TextChanged() Handles uctdBezwaarschrift.Valuechanged
    '    Try
    '        'BM: volgens 2.9.5.1: 
    '        'Als nadere gronden wordt ingevuld, dan herstelverzuimtermijn en einde beslistermijn Leegmaken en reminders opruimen.
    '        'BM: volgens bg 690: 
    '        'einde beslistermijn leegmaken
    '        'BM: volgens bg 835: 
    '        'EindeBeslisTermijn toch maar weer vullen 

    '        If Not String.IsNullOrEmpty(uctdBezwaarschrift.Value) Then

    '            Dim myDate As Date = uctdBezwaarschrift.Value
    '            Dim iWeeks As Integer = Int(tbWeken2.Text)
    '            ' If chkExtra6Weken.Checked Then iWeeks += 6
    '            uctdEindeBeslisTermijn.Value = myDate.AddDays(iWeeks * 7)

    '            If Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Then
    '                'Alleen uitvoeren als er uberhaupt een waarde was.
    '                Dim dlgRes As DialogResult = MessageBox.Show("Let op! Als u doorgaat wordt ''Herstel verzuimtermijn'' direct verwijderd en datum ''BeslisTermijn'' aangepast. " & _
    '                                                             "incl de Outlook reminders.", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

    '                If dlgRes = Windows.Forms.DialogResult.Yes Then
    '                    DeleteHerstelverzuimtermijn()
    '                Else
    '                    uctdBezwaarschrift.Value = String.Empty
    '                End If
    '            End If

    '            'If Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Or Not String.IsNullOrEmpty(uctdEindeBeslisTermijn.Value) Then
    '            '    'Alleen uitvoeren als er uberhaupt een waarde was.

    '            '    Dim dlgRes As DialogResult = MessageBox.Show("Let op! Als u doorgaat worden ''Herstel verzuimtermijn'' en ''Einde beslistermijn'' direct verwijderd. " & _
    '            '                                                 "incl de Outlook reminders.", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

    '            '    If dlgRes = Windows.Forms.DialogResult.Yes Then
    '            '        DeleteHerstelverzuimtermijn()
    '            '        DeleteEindeBeslisTermijn()
    '            '    Else
    '            '        uctdBezwaarschrift.Value = String.Empty
    '            '    End If
    '            'End If

    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    'Private Sub uctdBezwaarTermijn_GenerateTextChanged() Handles uctdBezwaarTermijn.GenerateTextChanged
    '    Try
    '        If uctdBezwaarTermijn.Focused Then
    '            CalculateWeeks()
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub
    'Private Sub uctdDecisionDate_TextChanged() Handles uctdDecisionDate.GenerateTextChanged
    '    Try
    '        'controleer of er daadwerkelijk iets is gewijzigd
    '        If uctdDecisionDate.tb.Text = MyFase.Beslisdatum Then
    '            Exit Sub
    '        End If

    '        If String.IsNullOrEmpty(uctdDecisionDate.tb.Text) Then
    '            Throw New Exception("datum besluit is niet ingevuld!")
    '        End If

    '        If Not String.IsNullOrEmpty(tbWeken1.Text) AndAlso Not IsNumeric(tbWeken1.Text) Then
    '            Throw New Exception("Aantal weken is niet correct ingevuld!")
    '        End If

    '        'If Not String.IsNullOrEmpty(tbWeken2.Text) AndAlso Not IsNumeric(tbWeken2.Text) Then
    '        '    Throw New Exception("Aantal weken is niet correct ingevuld!")
    '        'End If


    '        Dim DecisionDate As Date = uctdDecisionDate.Value
    '        uctdBezwaarTermijn.Value = DecisionDate.AddDays(CInt(tbWeken1.Text) * 7)

    '        If Not String.IsNullOrEmpty(uctdVerloopigBezwaar.Value) Then
    '            Dim myDate As Date = uctdVerloopigBezwaar.Value
    '            uctdHerstelverzuimtermijn.Value = myDate.AddDays(4 * 7)


    '            If chkExtra6Weken.Checked Then
    '                tbWeken2.Text = 12
    '            Else
    '                tbWeken2.Text = 6
    '            End If
    '            lblWeken2.Text = "Weken na Herstel"
    '            myDate = uctdHerstelverzuimtermijn.Value
    '            uctdEindeBeslisTermijn.Value = myDate.AddDays(Int(tbWeken2.Text) * 7)

    '        ElseIf Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Then
    '            'BM: volgens 2.9.5.1: 
    '            'Herstelverzuimtermijn alleen handmatig invullen. Deze datum is pas bekend als de brief van JDV is ontvangen. 
    '            'Als herstelverzuimtermijn wordt ingevuld; einde beslistermijn leegmaken en reminders opruimen.

    '            'Dim HerstelDate As Date = uctdHerstelverzuimtermijn.Value
    '            'tbWeken2.Text = 12
    '            'lblWeken2.Text = "Weken na Herstel"
    '            'uctdEindeBeslisTermijn.Value = HerstelDate.AddDays(CInt(tbWeken2.Text) * 7)

    '        Else
    '            tbWeken2.Text = 12
    '            lblWeken2.Text = "Weken na Besluit"
    '            If Not String.IsNullOrEmpty(tbWeken2.Text) AndAlso Not String.IsNullOrEmpty(uctdBezwaarTermijn.tb.Text) Then
    '                uctdEindeBeslisTermijn.Value = DecisionDate.AddDays(CInt(tbWeken2.Text) * 7)
    '            End If
    '        End If

    '        UpdateMyFaseClass()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub uctdHerstelverzuimtermijn_TextChanged() Handles uctdHerstelverzuimtermijn.GenerateTextChanged
    '    Try
    '        'BM: volgens 2.9.5.1: 
    '        'Als herstelverzuimtermijn wordt ingevuld; einde beslistermijn leegmaken en reminders opruimen.
    '        If uctdHerstelverzuimtermijn.Value = MyFase.Herstelverzuimtermijn Then
    '            Exit Sub
    '        End If

    '        'If _MyOriginalFase.Herstelverzuimtermijn <> uctdHerstelverzuimtermijn.Value Then
    '        If Not String.IsNullOrEmpty(uctdBezwaarschrift.Value) Then
    '            uctdHerstelverzuimtermijn.Value = String.Empty
    '            Throw New Exception("Kan ''Herstelverzuimtermijn'' niet invullen als ''Bezwaarschrift'' is ingevuld!")
    '        End If
    '        If Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) And Not String.IsNullOrEmpty(uctdEindeBeslisTermijn.Value) Then

    '            Dim dlgRes As DialogResult = MessageBox.Show("Let op! Als u doorgaat wordt ''Einde beslistermijn'' direct verwijderd. " & _
    '                                                         "incl de Outlook reminders.", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

    '            If dlgRes = Windows.Forms.DialogResult.Yes Then
    '                DeleteEindeBeslisTermijn()
    '            End If
    '        End If
    '        'End If

    '        UpdateMyFaseClass()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub chkAanhBezw_CheckedChanged(sender As Object, e As EventArgs) Handles chkAanhBezw.CheckedChanged
    '    Try
    '        'Indien aanhouding bezwaar is ingediend is de Einde beslistermijn niet meer relevant. 
    '        'Een aanhouding kan alleen indien er al een (voorlopig) bezwaar is gemaakt. 
    '        'De velden Herstelverzuimtermijn en Einde beslistermijn moeten worden leeggemaakt inclusief verwijderen van Outlook reminders.


    '        If chkAanhBezw.Focused AndAlso chkAanhBezw.Checked Then
    '            If String.IsNullOrEmpty(uctdVerloopigBezwaar.Value) And String.IsNullOrEmpty(uctdBezwaarschrift.Value) Then
    '                chkAanhBezw.Checked = False
    '                Throw New Exception("Een aanhouding kan alleen indien er al een voorlopig bezwaar en/of een bezwaarschrift is gemaakt")
    '                Exit Sub
    '            End If

    '            Dim msgHerstel As String = String.Empty
    '            Dim msgEinde As String = String.Empty
    '            Dim msgEn As String = String.Empty
    '            Dim msgMeervoud As String = "wordt"

    '            If Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Then
    '                msgHerstel = " ''Herstel verzuimtermijn'' "
    '            End If

    '            If Not String.IsNullOrEmpty(uctdEindeBeslisTermijn.Value) Then
    '                msgEinde = "''Einde beslistermijn''"
    '            End If

    '            If String.IsNullOrEmpty(msgHerstel) AndAlso String.IsNullOrEmpty(msgEinde) Then
    '                'dan geen melding
    '            Else
    '                If Not String.IsNullOrEmpty(msgHerstel) AndAlso Not String.IsNullOrEmpty(msgEinde) Then
    '                    msgEn = " en "
    '                    msgMeervoud = "worden"
    '                End If
    '                Dim msgDialog As String = "Let op! Als u doorgaat " & msgMeervoud & msgHerstel & msgEn & msgEinde & " direct verwijderd. incl de Outlook reminders."
    '                Dim dlgRes As DialogResult = MessageBox.Show(msgDialog, My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '                If dlgRes = Windows.Forms.DialogResult.Yes Then
    '                    DeleteHerstelverzuimtermijn()
    '                    DeleteEindeBeslisTermijn()
    '                Else
    '                    chkAanhBezw.Checked = False
    '                End If
    '            End If
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private Sub chkExtra6Weken_CheckedChanged(sender As Object, e As EventArgs) Handles chkExtra6Weken.CheckedChanged
    '    Try
    '        If Not chkExtra6Weken.Focused Then Exit Sub

    ''De einde beslistermijn wordt 6 weken na herstel verzuimtermijn.
    ''tenzij het vinkje verzoek 6 weken extra is aangevinkt. In dat geval wordt het 12 weken.
    '        If chkExtra6Weken.Checked Then
    '            tbWeken2.Text = 12
    '        Else
    '            tbWeken2.Text = 6
    '        End If

    'Dim myDate As Date
    '        If Not String.IsNullOrEmpty(uctdDecisionDate.Value) Then
    ''tbWeken2.Text = tbWeken2.Text + 6
    '            myDate = uctdDecisionDate.Value
    '        End If
    '        If Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Then
    '            myDate = uctdHerstelverzuimtermijn.Value
    '        End If
    '        If Not String.IsNullOrEmpty(uctdBezwaarschrift.Value) And Not String.IsNullOrEmpty(uctdVerloopigBezwaar.Value) Then
    '            myDate = uctdBezwaarschrift.Value
    '        End If
    '        If String.IsNullOrEmpty(uctdBezwaarschrift.Value) And Not String.IsNullOrEmpty(uctdVerloopigBezwaar.Value) Then
    '            tbWeken2.Text = tbWeken2.Text + 6
    '        End If

    '        If Not myDate = Nothing Then
    '            uctdEindeBeslisTermijn.Value = myDate.AddDays(tbWeken2.Text * 7)
    '        End If

    '        uctdBezwaarschrift_TextChanged()

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub


    'Private Sub tbWeken1_TextChanged(sender As Object, e As EventArgs) Handles tbWeken1.TextChanged
    '    Try
    '        'om een loop te voorkomen, dit alleen uit voeren als het via tbweken wordt aangepast.
    '        If Not tbWeken1.Focused Then Exit Sub

    '        If Not String.IsNullOrEmpty(tbWeken1.Text) AndAlso Not String.IsNullOrEmpty(uctdBezwaarTermijn.Value) Then
    '            Dim DecisionDate As Date = uctdDecisionDate.Value
    '            uctdBezwaarTermijn.Value = DecisionDate.AddDays(CInt(tbWeken1.Text) * 7)
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    'Private Sub uctdEindeBeslisTermijn_GenerateTextChanged() Handles uctdEindeBeslisTermijn.GenerateTextChanged
    '    Try
    '        If Not String.IsNullOrEmpty(uctdHerstelverzuimtermijn.Value) Then
    '            Throw New Exception("Mag ''Einde Beslistermijn'' niet invullen als ''Herstelverzuimtermijn'' is ingevuld!")
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub DeleteHerstelverzuimtermijn()
        Try
            uctdHerstelverzuimtermijn.Value = String.Empty
            MyFase.UpdateAppointmentEWS("Herstelverzuimtermijn")
            _MyOriginalFase.Herstelverzuimtermijn = String.Empty

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DeleteHoorzittingdatum()
        Try
            uctdHoorzitting.Value = String.Empty
            MyFase.UpdateAppointmentEWS("Herstelverzuimtermijn")
            _MyOriginalFase.Hoorzittingdatum = String.Empty

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DeleteEindeBeslisTermijn()
        Try
            uctdEindeBeslisTermijn.Value = String.Empty
            MyFase.UpdateAppointmentEWS("Ingebreke")
            _MyOriginalFase.Ingebreke = String.Empty

        Catch ex As Exception
            Throw ex
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
    Private Sub btnOutlookEindeBeslis_Click(sender As Object, e As EventArgs) Handles btnOutlookEindeBeslis.Click
        Try
            UpdateOutlook("Ingebreke")

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnOutlookSchriftelijkeReactie_Click(sender As Object, e As EventArgs) Handles btnOutlookSchriftelijkeReactie.Click
        Try

            UpdateOutlook("DateField8")

        Catch ex As Exception
            Throw ex
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

            If MyFase.AppointmentErrorList.Count > 0 Then
                MessageBox.Show(String.Join(vbCrLf, MyFase.AppointmentErrorList.ToArray()), My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            MyFase.AppointmentErrorList.Clear()
            'ook even de clone updaten, anders komt de vraag nog een keer bij alfsluiten from.
            CloneMyFase()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDeleteAppoinments_Click(sender As Object, e As EventArgs) Handles btnDeleteAppoinments.Click
        Try
            MyFase.DeleteFutureAppointmentsEWS()

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



    Private Sub btnClearDbCalEntries_Click(sender As Object, e As EventArgs) Handles btnClearDbCalEntries.Click
        Try
            MyFase.ClearDBCalEntries()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


End Class
