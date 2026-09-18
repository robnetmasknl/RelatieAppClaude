Imports System.Windows.Forms
Imports BusinessObjects


Public Class dlgStorno
    Dim da As New DataAccess
    Private _myRelatie As Relaties
    Private _StornoID As Int32 = 0
    Private URights As UserRights = UserRights.Instance

    Private _MyStornering As Stornering
    Public Property MyStornering() As Stornering
        Get
            If _MyStornering Is Nothing Then
                _MyStornering = New Stornering(_StornoID, Stornering.Via.ID)
            End If
            Return _MyStornering
        End Get
        Set(ByVal value As Stornering)
            _MyStornering = value
        End Set
    End Property


    Public Sub New(ByVal myRelatie As Relaties)

        InitializeComponent()
        _myRelatie = myRelatie

    End Sub
    Public Sub New(ByVal myRelatie As Relaties, ByVal StornoID As Integer)

        InitializeComponent()
        _myRelatie = myRelatie
        _StornoID = StornoID

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        With MyStornering
            .lidid = _myRelatie.Id
            .jaar = Me.cmbYear.SelectedValue
            .periode = Me.cmbMonth.SelectedValue
            .bedrag = Me.tbAmount.Text
            .teller = Me.tbTeller.Text
            .status = Me.tbStatus.Text.Trim
            If MyStornering.Id = 0 Then
                .eindereden = "0"
                Dim myHistory As New History
                myHistory.LidId = .lidid
                myHistory.TableName = "Storneringen"
                myHistory.Veld = "toegevoegd"
                myHistory.WaardeOud = "0"
                myHistory.WaardeNieuw = .bedrag
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            End If

            .Save()
        End With

        'Haal het storno bedrag af van de betaalde contributie maand
        Dim Contributie As Contributies
        Contributie = New Contributies(_myRelatie.Id, Contributies.Via.RELATIEID, Me.cmbYear.SelectedValue)
        Contributie.SubtractPayment(Me.tbAmount.Text, Me.cmbMonth.SelectedValue)
        Contributie.Save()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgStorno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_Users") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''admins'' of ''users'' ", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            FillCmb()

            Dim StornoAmount As Decimal = 0
            Dim ContributieAmount As Decimal = _myRelatie.CurrentPeriode.myContributie.mbedrag
            Dim StornoTeller As Integer = 1

            Me.lbRelatieNaam.Text = _myRelatie.FullName
            Me.BtnDelete.Enabled = False
            If _StornoID > 0 Then
                If MyStornering.status.ToLower.StartsWith("meegenomen in batch") Then
                    Me.OK_Button.Enabled = False
                    Me.Text = "IS AL VERWERKT!"
                Else
                    Me.BtnDelete.Enabled = True
                End If

                cmbMonth.SelectedValue = MyStornering.periode
                cmbYear.SelectedValue = MyStornering.jaar
                tbAmount.Text = MyStornering.bedrag
                tbStatus.Text = MyStornering.status
                tbTeller.Text = MyStornering.teller
            Else
        
                cmbMonth.SelectedValue = LastSepaPeriode.Month
                cmbYear.SelectedValue = LastSepaPeriode.Year

                Dim newDate As New Date(LastSepaPeriode.Year, LastSepaPeriode.Month, "01")
                newDate = newDate.AddMonths(-1)

                Dim myStorno As New Stornering(_myRelatie.Id, Stornering.Via.lIDID_PER, newDate)

                If myStorno.Found Then
                    StornoAmount = myStorno.bedrag
                    StornoTeller = myStorno.teller + 1
                End If

                MyStornering.teller = StornoTeller
                Me.tbAmount.Text = StornoAmount + ContributieAmount
                Me.tbStatus.Text = ""
                Me.tbTeller.Text = MyStornering.teller


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try

            Dim dlgAsk As New dlgAskIt
            dlgAsk.StartPosition = FormStartPosition.CenterScreen
            dlgAsk.Height = 150
            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
            mylabel.Name = "lbl"
            mylabel.Text = "Wilt u de stornering ongedaan maken? " & vbCrLf & _
                                    "Het bedrag " & MyStornering.bedrag & " wordt in de maand " & CType(MyStornering.periode, eMaandFull).ToString & " " & Me.cmbYear.SelectedValue & " opgeteld?"
            mylabel.AutoSize = True
            dlgAsk.Controls.Add(mylabel)
            dlgAsk.OK_Button.Text = "Ja"
            dlgAsk.Cancel_Button.Text = "Nee"

            dlgAsk.ShowDialog()
            If dlgAsk.DialogResult = DialogResult.OK Then
                MyStornering.Remove()

                Dim myHistory As New History
                myHistory.LidId = MyStornering.lidid
                myHistory.TableName = "Storneringen"
                myHistory.Veld = "Verwijderd"
                myHistory.WaardeOud = MyStornering.bedrag & ", " & CType(MyStornering.periode, eMaandFull).ToString
                myHistory.WaardeNieuw = "0"
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()

                'verwerk het storno bedrag weer met de contributie maand
                Dim Contributie As Contributies
                Contributie = New Contributies(_myRelatie.Id, Contributies.Via.RELATIEID, Me.cmbYear.SelectedValue)
                Contributie.AddPayment(MyStornering.bedrag, MyStornering.periode)
                Contributie.Save()

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private _LastSepaPeriode As Date = Date.MinValue
    Public Property LastSepaPeriode() As Date
        Get
            If _LastSepaPeriode = Date.MinValue Then
                Dim LastRun As New Systeeminstellingen("SEPAPERIODE", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                With LastRun
                    If .Found = False Then
                        .Bond = 0
                        .Zoeknaam = "SEPAPERIODE"
                        .Omschijving = "Laatste periode SEPA"
                        Dim newDate As New Date(Today.Year, Today.Month, "01")
                        .Waarde = newDate.AddMonths(-1)
                        .Save()
                    End If
                    _LastSepaPeriode = .Waarde
                End With
            End If

            Return _LastSepaPeriode
        End Get
        Set(ByVal value As Date)
            _LastSepaPeriode = value
        End Set
    End Property


    ' Private _LastClieopPeriode As Date = Date.MinValue
    'Public Property LastClieopPeriode() As Date
    '    Get
    '        If _LastClieopPeriode = Date.MinValue Then
    '            Dim LastRun As New Systeeminstellingen("CLIEOPPERIODE", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
    '            With LastRun
    '                If .Found = False Then
    '                    .Bond = 0
    '                    .Zoeknaam = "CLIEOPPERIODE"
    '                    .Omschijving = "Laatste periode clieop"
    '                    Dim newDate As New Date(Today.Year, Today.Month, "01")
    '                    .Waarde = newDate.AddMonths(-1)
    '                    .Save()
    '                End If
    '                _LastClieopPeriode = .Waarde
    '            End With
    '        End If

    '        Return _LastClieopPeriode
    '    End Get
    '    Set(ByVal value As Date)
    '        _LastClieopPeriode = value
    '    End Set
    'End Property

    Private Sub FillCmb()
        Try

            Dim dt As DataTable
            Dim col As DataColumn
            Dim dr As DataRow

            dt = New DataTable
            col = New DataColumn
            col.ColumnName = "id"
            dt.Columns.Add(col)
            col = New DataColumn
            col.ColumnName = "omschrijving"
            dt.Columns.Add(col)

            dr = dt.NewRow
            dr("id") = 0
            dr("omschrijving") = "maand"
            dt.Rows.Add(dr)

            Dim i As Integer = 1
            Do While i <= 12
                dr = dt.NewRow
                dr("id") = i
                dr("omschrijving") = MonthName(i, True)
                dt.Rows.Add(dr)
                i = i + 1
            Loop
            cmbMonth.DataSource = dt
            cmbMonth.DisplayMember = "omschrijving"
            cmbMonth.ValueMember = "id"

            Dim iYear As Integer = Now.Year - 3
            Dim dtYear As New DataTable
            dtYear = dt.Clone

            i = 1
            Do While i <= 8
                dr = dtYear.NewRow
                dr("id") = iYear
                dr("omschrijving") = iYear
                dtYear.Rows.Add(dr)
                iYear += 1
                i = i + 1
            Loop

            cmbYear.DataSource = dtYear
            cmbYear.DisplayMember = "omschrijving"
            cmbYear.ValueMember = "id"
            cmbYear.SelectedValue = Now.Year


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
