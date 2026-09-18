Imports System.Windows.Forms
Imports BusinessObjects
Imports Microsoft.Office.Interop
Imports MapiObjects

Public Class dlgJdTypeOnbudsman
    Private URights As UserRights = UserRights.Instance
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
    Private Sub Changelayout()
        Dim style As FontStyle = CInt(da.Settings.FontStyle)
        Dim newFont As Font = New System.Drawing.Font(da.Settings.FontFamily, da.Settings.FontSize, style)
        Me.Font = newFont
        'Me.ParentForm.Font = newFont
    End Sub
    Private Sub uctdIndienDatum_Load(sender As Object, e As EventArgs) Handles uctdIndienDatum.Load
        Try
            Changelayout()
            BindForm()

            Me.Text = MyFase.Fase.Description

            AddHandler rbGegrond.CheckedChanged, AddressOf rbReactie_CheckedChanged
            AddHandler rbDeelOngegrond.CheckedChanged, AddressOf rbReactie_CheckedChanged
            AddHandler rbOnGegrond.CheckedChanged, AddressOf rbReactie_CheckedChanged
            AddHandler rbAfwachting.CheckedChanged, AddressOf rbReactie_CheckedChanged
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
                    'Haal datum oordeel op van de klacht
                    If MyIBBDossier.ListIBBFases.Count > 0 Then
                        Dim VorigeFase As IBBFase = MyIBBDossier.ListIBBFases.Item(MyIBBDossier.ListIBBFases.Count - 1)
                        Select Case VorigeFase.Fase.Type
                            Case "KL"
                                .Indiendatum = VorigeFase.DateField9
                        End Select
                    Else
                        .Indiendatum = Today
                    End If
                Else

                    'uctdIndienDatum.Enabled = False
                End If

                uctdIndienDatum.Value = .Indiendatum
                tbHoorzitting.Text = .HoorzittingText
                uctdHoorzitting.Value = .Hoorzittingdatum
                UctdReactietermijn.Value = .Ingebreke
                uctdReactieOordeel.Value = .DateField9
                tbOpmerkingen2.Text = .Opmerkingen2

                Select Case MyFase.Besluit
                    Case 0
                        rbAfwachting.Checked = True
                    Case 1
                        rbGegrond.Checked = True
                    Case 2
                        rbDeelOngegrond.Checked = True
                    Case 3
                        rbOnGegrond.Checked = True
                    Case 4
                        'Klacht ingetrokken!
                End Select


                If Not MyFase.Found Then
                    'indien nieuw vul standaard data in
                    'uctdDatumBesluit_TextChanged()
                End If

            End With
            ' uctdVoorlopigBeroep_TextChanged()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateMyFaseClass()
        Try
            With MyFase
                .Indiendatum = uctdIndienDatum.Value
                .HoorzittingText = tbHoorzitting.Text
                .Hoorzittingdatum = uctdHoorzitting.Value
                .Ingebreke = UctdReactietermijn.Value
                .DateField9 = uctdReactieOordeel.Value
                .Opmerkingen2 = tbOpmerkingen2.Text

                If rbAfwachting.Checked = True Then
                    .Besluit = 0
                ElseIf rbGegrond.Checked = True Then
                    .Besluit = 1
                ElseIf rbDeelOngegrond.Checked = True Then
                    .Besluit = 2
                ElseIf rbOnGegrond.Checked = True Then
                    .Besluit = 3
                End If

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Try
            'Throw New Exception("sorry, verwerkt nog niets")
            'Exit Sub
            If MyFase.TypeId = -1 Then
                Throw New Exception("Fase onbekend!!")
                Exit Sub
            End If

            If String.IsNullOrEmpty(uctdIndienDatum.Value) Then
                Throw New Exception("indien datum verplicht!!")
                Exit Sub
            End If

            If rbAfwachting.Checked = False AndAlso String.IsNullOrEmpty(uctdReactieOordeel.Value) Then
                uctdReactieOordeel.Focus()
                Throw New Exception("Datum Reactie Oordeel ontbreekt!")
                Exit Sub
            End If

            UpdateMyFaseClass()

            If Not MyFase.Found Then MyFase.Save()

            If MyFase.Besluit <> 1 Or MyFase.Besluit <> 4 Then
                ValidateOutlook()
            End If

            save()

            _MyOriginalFase = Nothing

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Try

            Dim bOutlookChanges As Boolean = False

            'Indiendatum
            Dim lbl1 As New Label
            Dim chk1 As New CheckBox
            If MyFase.Indiendatum <> _MyOriginalFase.Indiendatum Then
                bOutlookChanges = True
                chk1.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryObjectionId) Then aot = " toevoegen"
                lbl1.Text = "Indiendatum reminder in outlook" & aot
            Else
                chk1.Enabled = Not String.IsNullOrEmpty(MyFase.Indiendatum)
                lbl1.Text = "Indiendatum is ongewijzigd"
            End If

            'Hoorzittingdatum
            Dim lbl2 As New Label
            Dim chk2 As New CheckBox
            If MyFase.Hoorzittingdatum <> _MyOriginalFase.Hoorzittingdatum Then
                bOutlookChanges = True
                chk2.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryHoorzittingId) Then aot = " toevoegen"
                lbl2.Text = "Datum Hoorzitting reminder in outlook" & aot
            Else
                chk2.Enabled = Not String.IsNullOrEmpty(MyFase.Hoorzittingdatum)
                lbl2.Text = "Datum Hoorzitting is ongewijzigd"
            End If

            'Reactietermijn  datum 
            Dim lbl3 As New Label
            Dim chk3 As New CheckBox
            If MyFase.Ingebreke <> _MyOriginalFase.Ingebreke Then
                bOutlookChanges = True
                chk3.Checked = True
                Dim aot As String = " aanpassen"
                If String.IsNullOrEmpty(MyFase.CalEntryBesluitId) Then aot = " toevoegen"
                lbl3.Text = "Datum Reactietermijn reminder in outlook" & aot
            Else
                chk3.Enabled = Not String.IsNullOrEmpty(MyFase.Ingebreke)
                lbl3.Text = "Datum Reactietermijn verzuimtermijn is ongewijzigd"
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

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    Exit Sub
                Else
                    If chk1.Checked = True Then btnIndienDatum_Click(Me, New EventArgs)
                    If chk2.Checked = True Then btnOutlookHoorzitting_Click(Me, New EventArgs)
                    If chk3.Checked = True Then btnOutlookReactietermijn_Click(Me, New EventArgs)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub rbReactie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ActiveControl Is sender Then
            If rbAfwachting.Checked = True Then
                MyFase.Besluit = 0
            ElseIf rbGegrond.Checked = True Then
                MyFase.Besluit = 1
            ElseIf rbDeelOngegrond.Checked = True Then
                MyFase.Besluit = 2
            ElseIf rbOnGegrond.Checked = True Then
                MyFase.Besluit = 3
            End If
        End If


    End Sub

    Private Sub btnIndienDatum_Click(sender As Object, e As EventArgs) Handles btnIndienDatum.Click
        Try
            UpdateOutlook("Indiendatum")

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

    Private Sub btnOutlookReactietermijn_Click(sender As Object, e As EventArgs) Handles btnOutlookReactietermijn.Click
        Try

            UpdateOutlook("Ingebreke")

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