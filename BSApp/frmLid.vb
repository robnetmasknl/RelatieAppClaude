Imports BusinessObjects
Imports OfficeObjects

Public Class frmLid
    Private _RelId As Integer = 0
    Private MyRelatieCopy As Lidmaat
    Private _lid As Lidmaat
    Public Property lid() As Lidmaat
        Get
            If _lid Is Nothing Then
                If _RelId = 0 Then
                    _lid = New Lidmaat
                    _lid.Status = 3
                Else
                    _lid = New Lidmaat(_RelId, Lidmaat.Via.ID)
                End If
                MyRelatieCopy = _lid.ShallowCopy()
            End If
            Return _lid
        End Get
        Set(ByVal value As Lidmaat)
            _lid = value
        End Set
    End Property
    'Private _Boeking As Boeking
    'Public Property Boeking() As Boeking
    '    Get
    '        If lid.lidnr <> _DummyValue Then
    '            _Boeking = New Boeking(lid.Id, Boeking.Via.RELID)
    '            'MyRelatieCopy = _lid.ShallowCopy()
    '        End If
    '        Return _Boeking
    '    End Get
    '    Set(ByVal value As Boeking)
    '        _Boeking = value
    '    End Set
    'End Property

    Public Sub New(ByVal id As String)

        InitializeComponent()
        _RelId = id

    End Sub
    Public Sub New()
        InitializeComponent()

    End Sub

    Private Sub frmLid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If My.User.Name.ToLower.Contains("bert") Then
            '    Button1.Visible = True
            'End If

            FillCmb()
            BindTexBox()

            Select Case lid.geslacht.ToUpper
                Case "MAN"
                    rbMan.Checked = True
                    rbWoman.Checked = False
                    rbUnkown.Checked = False
                Case "VROUW"
                    rbMan.Checked = False
                    rbWoman.Checked = True
                    rbUnkown.Checked = False
                Case "ONBEKEND"
                    rbMan.Checked = False
                    rbWoman.Checked = False
                    rbUnkown.Checked = True
            End Select

            AddHandler rbMan.CheckedChanged, AddressOf rbGeslacht_CheckedChanged
            AddHandler rbWoman.CheckedChanged, AddressOf rbGeslacht_CheckedChanged
            AddHandler rbUnkown.CheckedChanged, AddressOf rbGeslacht_CheckedChanged

            AddHandler cmbBond.Validating, AddressOf cmb_Validating

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillCmb()
        Try
            Dim da As New DataAccess
            Dim Bonden As DataTable = da.ExecuteDataTable("SELECT * FROM Bonden ORDER BY Omschrijving")


            'Dim dr As DataRow = Bonden.NewRow
            'dr("id") = 0
            'dr("Omschrijving") = "Selecteer een Bond."

            'Bonden.Rows.Add(dr)
            'cmbBond.DataSource = Bonden
            'cmbBond.DisplayMember = "Omschrijving"
            'cmbBond.ValueMember = "id"

            If lid.Bond = 0 Then
                Dim dr As DataRow = Bonden.NewRow
                dr("id") = 0
                dr("Omschrijving") = "Selecteer een Bond."
                Bonden.Rows.InsertAt(dr, 0)
            End If
            cmbBond.DataSource = Bonden
            cmbBond.DisplayMember = "Omschrijving"
            cmbBond.ValueMember = "id"
            cmbBond.SelectedValue = lid.Bond



        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BindTexBox()
        Try

            With lid
                Me.Text = .FullName
                tbAchternaam.DataBindings.Add("Text", lid, "achternaam")
                'If _lidnr = "0" Then
                '    tbLidNr.Visible = True
                '    tbLidNr.DataBindings.Add("Text", lid, "lidnr") ' .Text = .lidnr
                'Else
                tbLidNr.Visible = False
                lblLidNr.DataBindings.Add("Text", lid, "lidnr") ' .Text = .lidnr
                'End If

                tbTussenvoegsel.DataBindings.Add("Text", lid, "tussenvoegsel")
                tbInit.DataBindings.Add("Text", lid, "init")
                tbAdres.DataBindings.Add("Text", lid, "adres")
                tbHuisNr.DataBindings.Add("Text", lid, "huisnr")
                tbHuisNrTv.DataBindings.Add("Text", lid, "huisnrtv")
                tbPostCode.DataBindings.Add("Text", lid, "postcode")
                tbPlaats.DataBindings.Add("Text", lid, "plaats")
                tbLand.DataBindings.Add("Text", lid, "land")

                tbTelefoon.DataBindings.Add("Text", lid, "telefoonnummer")
                tbMobiel.DataBindings.Add("Text", lid, "mobiel")
                tbEmail.DataBindings.Add("Text", lid, "email")
                dtpDOB.DataBindings.Add("Text", lid, "geboortedatum")
                tbWachtwoord.DataBindings.Add("Text", lid, "wachtwoord")
                rbYes.DataBindings.Add("Checked", lid, "bevestigd", True)
                rbNo.Checked = Not rbYes.Checked
                'lid.bevestigd = True

                tbTelefoon_b.DataBindings.Add("Text", lid, "b_telefoon")
                tbMobiel_b.DataBindings.Add("Text", lid, "b_mobiel")
                tbEmail_b.DataBindings.Add("Text", lid, "b_email")

                'cmbBond.SelectedValue = lid.Bond

                FillBoekingen()

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _DummyValue As String
    Public ReadOnly Property DummyValue() As String
        Get
            If _DummyValue Is Nothing Then
                Dim sys As New Systeeminstellingen("DummyNr", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _DummyValue = sys.Waarde
            End If

            Return _DummyValue
        End Get
    End Property
    Private Sub FillBoekingen()
        Try

            gbConfirm.Visible = True

            If _RelId = "0" Then Exit Sub
            If lid.Found = False Then Exit Sub

            If lid.lidnr <> _DummyValue Then
                Dim Boeking As New Boeking(lid.Id, Boeking.Via.RELID)
                If Not Boeking.Found Then
                    lblBoeking_Message.Text = lid.FullName & " heeft nog geen boeking. "
                Else
                    lblBoeking_Message.Text = lid.Boeking_Message
                    If Boeking.voorlopig Then
                        chkVerwerkt.CheckState = CheckState.Checked
                    Else
                        chkVerwerkt.CheckState = CheckState.Unchecked
                    End If
                End If

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkVerwerkt_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerwerkt.CheckedChanged
        Try
            If chkVerwerkt.Focused Then
                Dim Boeking2Confirm As New Boeking(lid.Id, Boeking.Via.RELID)
                If Boeking2Confirm.Found Then
                    Dim MyMessage As String = ""
                    If Boeking2Confirm.voorlopig Then 'indien voorlopig(is nu functie verwerkt) = true dan vragen om uit te zetten
                        MyMessage = "Weet u zeker dat de aangifte van " & vbCrLf & Boeking2Confirm.LidNaam & " NIET is verwerkt?"
                        lid.bevestigd = False
                    Else
                        MyMessage = "Weet u zeker dat de aangifte van " & vbCrLf & Boeking2Confirm.LidNaam & " is verwerkt?"
                        lid.bevestigd = True
                    End If
                    Dim dlgRes As DialogResult = MessageBox.Show(MyMessage, "Let OP!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If dlgRes = DialogResult.Yes Then
                        Boeking2Confirm.voorlopig = chkVerwerkt.CheckState
                        Boeking2Confirm.Save()
                        FillBoekingen()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConfirmBooking_Click_1(sender As Object, e As EventArgs)

    End Sub
    Private Sub Save()
        Try
            Me.SelectNextControl(tbAchternaam, True, True, True, True)

            Dim result As String = ""
            result = RequiredValues()

            If Not String.IsNullOrEmpty(result) Then
                Dim dlgRes As DialogResult = MessageBox.Show(result & vbCrLf & "Wilt u toch opslaan?", My.Application.Info.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If dlgRes <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If

            If lid.TimeStampChanged Then
                Dim dlgAsk As New dlgAskIt
                dlgAsk.StartPosition = FormStartPosition.CenterScreen
                dlgAsk.Height = 150
                Dim mylabel As New Label
                mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                mylabel.Name = "lbl"
                mylabel.Text = "Er zijn tussentijdse wijzigingen geweest." & vbCrLf & "Als u door gaat worden deze overschreven." & vbCrLf & "Doorgaan?"
                mylabel.AutoSize = True
                dlgAsk.Controls.Add(mylabel)
                dlgAsk.OK_Button.Text = "Ja"
                dlgAsk.Cancel_Button.Text = "Nee"

                dlgAsk.ShowDialog()

                If dlgAsk.DialogResult <> DialogResult.OK Then
                    Dim myHistory As New History
                    myHistory.LidId = lid.Id
                    myHistory.TableName = "Relaties"
                    myHistory.Veld = "Waarschuwing tussentijdse wijziging"
                    myHistory.WaardeOud = ""
                    myHistory.WaardeNieuw = "beantwoordt met Nee"
                    myHistory.MutDate = Now
                    myHistory.MutDoor = "bsapp" 'URights.UserName
                    myHistory.Save()
                    Exit Sub
                Else
                    Dim myHistory As New History
                    myHistory.LidId = lid.Id
                    myHistory.TableName = "Relaties"
                    myHistory.Veld = "Waarschuwing tussentijdse wijziging"
                    myHistory.WaardeOud = ""
                    myHistory.WaardeNieuw = "beantwoordt met Ja"
                    myHistory.MutDate = Now
                    myHistory.MutDoor = "bsapp" 'URights.UserName
                    myHistory.Save()

                End If
            End If

            If String.IsNullOrEmpty(lid.lidnr) Or lid.lidnr = "0" Then
                Dim da As New DataAccess
                Dim NewNumber As String = da.MaxLidNr("Select max(lidnr )As newNr FROM relaties where LEFT(lidnr,2) = 'T0'")

                    If String.IsNullOrEmpty(NewNumber) Then
                    NewNumber = 1
                    NewNumber = NewNumber.PadLeft(9, "0")
                    NewNumber = "T" & NewNumber
                Else
                    Dim inumber As Integer = NewNumber.Substring(1, NewNumber.Length - 1)
                    NewNumber = inumber + 1
                    NewNumber = NewNumber.PadLeft(9, "0")
                    NewNumber = "T" & NewNumber
                End If

                lid.lidnr = NewNumber
            End If

            lid.Save()
            tbLidNr.Text = lid.lidnr
            lblLidNr.Text = lid.lidnr


            MessageBox.Show("opgeslagen!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValues() As String
        Try
            Dim result As String = ""
            Dim DOB As Date
            DOB = Date.ParseExact(lid.geboortedatum, "dd-MM-yyyy", Nothing)

            Dim _Age As Double = DateDiff(DateInterval.Year, DOB, DateTime.Now)
            If _Age > 100 Then
                Return "Persoon is ouder dan 100 jaar controleer geb. datum."
            ElseIf _Age < 15 Then
                Return "Persoon is jonger dan 15 jaar controleer geb. datum."
            End If

            If String.IsNullOrEmpty(_lid.b_email) Then
                Return "Er is nog geen emailadres ingevuld."
            End If

            If String.IsNullOrEmpty(_lid.b_mobiel) AndAlso String.IsNullOrEmpty(_lid.b_telefoon) Then
                Return "Er is nog geen mobiel of vast telefoonnummer ingevuld."
            End If

            Return result

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            Save()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CloseToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Save()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For Each ChildForm As Form In Me.ParentForm.MdiChildren
            If ChildForm.Name = Me.Name Then
                ChildForm.Close()
                ChildForm = New frmLid(0)
                ChildForm.MdiParent = MainForm
                ChildForm.WindowState = FormWindowState.Maximized
                ChildForm.Show()
            End If
        Next


    End Sub

    Private Sub rbNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNo.CheckedChanged
        lid.bevestigd = Not rbNo.Checked
    End Sub

    Private Sub rbYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbYes.CheckedChanged
        lid.bevestigd = Not rbNo.Checked
    End Sub

    Private Sub rbGeslacht_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ActiveControl Is sender Then
            Dim radio As New RadioButton
            radio = sender
            Select Case radio.Text.ToUpper
                Case "MAN"
                    rbMan.Checked = True
                    rbWoman.Checked = False
                    rbUnkown.Checked = False
                Case "VROUW"
                    rbMan.Checked = False
                    rbWoman.Checked = True
                    rbUnkown.Checked = False
                Case "ONBEKEND"
                    rbMan.Checked = False
                    rbWoman.Checked = False
                    rbUnkown.Checked = True
            End Select
            lid.geslacht = radio.Text.ToUpper
        End If
    End Sub


    Private Sub tsbtBoekingDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtBoekingDelete.Click
        Try
            Dim Boeking2Delete As New Boeking(lid.Id, Boeking.Via.RELID)
            If Boeking2Delete.Found Then
                Dim dlgRes As DialogResult = MessageBox.Show("Weet u zeker de boeking van " & vbCrLf & _
                            Boeking2Delete.LidNaam & " wilt verwijderen?", "LET OP!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dlgRes = DialogResult.Yes Then
                    'Boeking2Delete.lidnr = "0"
                    Boeking2Delete.relatieId = 0
                    Boeking2Delete.voorlopig = True
                    Boeking2Delete.Save()
                    FillBoekingen()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbtWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbBond_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBond.SelectedIndexChanged
        Try
            If ActiveControl Is sender Then
                lid.Bond = cmbBond.SelectedValue
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbWord.Click
        Try
            Dim MyLocatie As New Locaties(lid.CurrentBoeking.Blok.locatieid)
            Dim sys As Systeeminstellingen = Nothing

            If MyLocatie.Offline = True Then
                sys = New Systeeminstellingen("BevestigingtemplateMachtiging", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            Else
                sys = New Systeeminstellingen("Bevestigingtemplate", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            End If

            If Not sys.Found Then
                Throw New Exception("geen gegevens voor template! controleer systeeminstellingen!")
            End If

            Dim newWord As New WordMerge
            newWord.CurrentDr = lid.ExportRow
            newWord.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\mailing.txt"
            newWord.WordMergeBelasting(sys.Waarde)

            'Dim MyTemplate As New tblTemplates(1)
            'If Not MyTemplate.Found Then Throw New Exception("instelling default templatepath niet gevonden!")
            'If String.IsNullOrEmpty(MyTemplate.DefaultLocation) Then Throw New Exception("geen locatie gegevens voor standaard template!")


            'newWord.TemplatePath = MyTemplate.DefaultLocation
            'newWord.Template = "\Bevestiging"


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPostcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostcode.Click
        Try
            Dim pctext As String = tbPostCode.Text
            pctext = pctext.Replace(" ", "")
            Dim huisnrtext As String = tbHuisNr.Text

            Dim pc As New PostCode(pctext, huisnrtext)
            lid.adres = pc.Straat
            lid.plaats = pc.Plaats

            tbAdres.Text = pc.Straat
            tbPlaats.Text = pc.Plaats

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Dim cmb As ComboBox = sender
            If cmb.Text = "" Then

            ElseIf sender.SelectedValue Is Nothing Then
                MessageBox.Show("code " & cmb.Text & " is niet gevonden", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class