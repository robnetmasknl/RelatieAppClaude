Imports BusinessObjects
Imports System.Reflection
Imports System.Text

''' <summary>
''' Haal de leden op aan de hand van de lidsoort selecties op de opgeven jaar/maand
''' Haal de al betaalde contributie bedrag op
''' schrijf het nieuwe bedrag weg incl de eventuele al betaalde bedrag
''' </summary>
''' <remarks></remarks>
Public Class frmSEPA
    Private URights As UserRights = UserRights.Instance

    Public Event GenerateComplete(ByVal iCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)

    Private iCounter As Integer = 0
    Private Status As String = ""
    Private Ready As Boolean = False
    Private ExpHandler As Boolean = False
    Private bAnpv As Boolean = False

    ' Private WithEvents _thContributieBatch As ContributieBatch
    Private WithEvents _thBaBeProcess As BaBeProcess

    'Private LineCounter As Integer = 0
    'Private iNewCounter As Integer = 0
    'Private TotalLineCount As Integer = 0


    'Public Sub IndexCompleteHandler(ByVal _Counter As Integer) Handles _thContributieBatch.GenerateComplete
    '    Ready = True
    'End Sub
    'Public Sub IndexExpHandler(ByVal exp As Exception) Handles _thContributieBatch.GenerateExp
    '    Ready = True
    '    ExpHandler = True
    '    'MessageBox.Show(exp.Message, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Status = "ERROR: " & exp.Message
    'End Sub
    'Public Sub IndexStatusHandler(ByVal _message As String) Handles _thContributieBatch.GenerateStatus
    '    Status = _message
    'End Sub
    'Public Sub IndexCounter(ByVal _Counter As Integer) Handles _thContributieBatch.GenerateCounter
    '    iCounter = _Counter
    'End Sub



    Public Sub IndexCompleteHandlerSEPA(ByVal _Counter As Integer) Handles _thBaBeProcess.GenerateComplete
        Ready = True
    End Sub
    Public Sub IndexExpHandlerSEPA(ByVal exp As Exception) Handles _thBaBeProcess.GenerateExp
        Ready = True
        ExpHandler = True
        'MessageBox.Show(exp.Message, "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Status = "ERROR: " & exp.Message
    End Sub
    Public Sub IndexStatusHandlerSEPA(ByVal _message As String) Handles _thBaBeProcess.GenerateStatus
        Status = _message
    End Sub
    Public Sub IndexCounterSEPA(ByVal _Counter As Integer) Handles _thBaBeProcess.GenerateCounter
        iCounter = _Counter
    End Sub


    Private Sub frmSepa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_sepa") Then
                'ga dan door
            Else
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''rel_admins'' of ''rel_sepa''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            Dim SetAnpvMenu As String = GetSysSettingOf("SetAnpvMenu", False)
            If SetAnpvMenu.ToLower = "true" Then
                bAnpv = True
            End If


            FillCmb()
            For Each Control In Me.Controls
                If TypeOf (Control) Is TextBox Then
                    Dim textbox As TextBox = Control
                    AddHandler textbox.LostFocus, AddressOf FocusListview
                ElseIf TypeOf (Control) Is Button Then
                    Dim Button As Button = Control
                    AddHandler Button.LostFocus, AddressOf FocusListview
                ElseIf TypeOf (Control) Is ComboBox Then
                    Dim ComboBox As ComboBox = Control
                    AddHandler ComboBox.SelectedIndexChanged, AddressOf FocusListview
                End If
            Next

            _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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

            Dim da As New DataAccess
            Dim lidsoorten As DataTable = da.ExecuteDataTable("SELECT * FROM lidsoorten ORDER BY Omschrijving")

            lvSoorten.Columns.Add("id", 25, HorizontalAlignment.Left)
            lvSoorten.Columns.Add("soort", 115, HorizontalAlignment.Left)
            lvSoorten.View = View.Details
            Dim lstViewItem As ListViewItem = New ListViewItem()
            For Each row As DataRow In lidsoorten.Rows
                If row("soort") = "0" Then Continue For
                lstViewItem = New ListViewItem()
                lstViewItem.Text = row("soort")
                lstViewItem.SubItems.Add(row("Omschrijving"))
                lvSoorten.Items.Add(lstViewItem)
            Next

            lvSoorten.EnsureVisible(lvSoorten.Items.Count - 1)
            cmbSeq.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private _MyDocuments As String
    Public ReadOnly Property MyDocuments() As String
        Get
            Return _MyDocuments
        End Get
    End Property

    Private Sub FocusListview()
        Try
            If lvSoorten.SelectedItems.Count > 0 Then

                'lvSoorten.Focus()
                lblSelectie.Text = ""
                For Each item As ListViewItem In lvSoorten.SelectedItems
                    If item.Text = "0" Then Continue For
                    lblSelectie.Text &= item.Text & " , "
                Next

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub lvSoorten_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSoorten.SelectedIndexChanged
        Try
            FocusListview()
            btnSEPA.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnControleSEPA_Click(sender As Object, e As EventArgs) Handles btnControleSEPA.Click
        Try

            Dim MaxTransactie As String = 10 '0000

            Dim soort As String = ""
            For Each item As ListViewItem In lvSoorten.SelectedItems
                If item.Text = "0" Then Continue For
                soort &= "'" & item.Text & "' ,"
            Next
            If soort.EndsWith(",") Then
                soort = soort.Substring(0, soort.LastIndexOf(","))
            End If

            If soort.Length < 1 Then
                Throw New Exception("Er is/zijn nog geen lidsoort(en) geselecteerd!")
            End If


            Status = ""
            Ready = False
            ExpHandler = False

            cmbYear.Enabled = False
            cmbMonth.Enabled = False
            lvSoorten.Enabled = False
            tbAmount.Enabled = False
            tbFixDesription.Enabled = False

            _thBaBeProcess = New BaBeProcess
            Dim BatchResult As String = ""
            Dim thBaBeProcess As New System.Threading.Thread(AddressOf _thBaBeProcess.testRun)
            With _thBaBeProcess
                ._MaxTransactieCount = GetSysSettingOf("CLIEOP")
                '._SenderIdentificatie = "CLIPT" & Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10)
                ._PeriodeYear = cmbYear.SelectedValue
                ._PeriodeMonth = cmbMonth.SelectedValue
                ._AccountNumber = GetSysSettingOf("SEPA_IBAN")
                ._CompanyName = "VBM"
                ._CompanyBICcode = GetSysSettingOf("SEPA_BIC")
                ._IncassantId = GetSysSettingOf("SEPA_IncassantId")
                ._LidSoorten = soort
                ._BatchAmount = tbAmount.Text
                ._FixedDescription = tbFixDesription.Text
                .bAnpv = bAnpv

                Dim SEPA_COLL As Integer
                Dim result As Boolean = Int32.TryParse(GetSysSettingOf("SEPA_COLLDT"), SEPA_COLL)
                Dim SEPA_COLLDT As Date = LastDayCurrentMonth()
                If result Then
                    SEPA_COLLDT = LastDayCurrentMonth.AddDays((SEPA_COLL * -1))
                Else
                    Throw New Exception("Er is geen SEPA_COLLDT gevonden of veld bevat geen nummeriek waarde in de systeem instellingen." & vbCrLf _
                        & "Laat de systeembeheer controleren of het record ''SEPA_COLLDT'' aanwezig is en gevuld!")
                End If

                ._RequestedCollectionDate = SEPA_COLLDT


                'validate verplichte waardes
                If ._PeriodeMonth = 0 Then Throw New Exception("Er is nog geen maand opgegeven.")
                If ._PeriodeMonth > 12 Then Throw New Exception("Opgegeven maand is ongeldig.")
                If ._PeriodeYear = 0 Then Throw New Exception("Er is nog geen Jaar opgegeven.")

                If String.IsNullOrEmpty(._AccountNumber) Then _
                    Throw New Exception("Er is geen IBAN gevonden in de systeem instellingen." & vbCrLf _
                        & "Laat de systeembeheer controleren of het record ''SEPA_IBAN'' aanwezig is en gevuld!")

                If String.IsNullOrEmpty(._IncassantId) Then _
                    Throw New Exception("Er is geen IncassantId gevonden in de systeem instellingen." & vbCrLf _
                        & "Laat de systeembeheer controleren of het record ''SEPA_IncassantId'' aanwezig is en gevuld!")


                thBaBeProcess.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()

                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = ""
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1
                    End If
                    frm.lbMessage.Text = Status
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        thBaBeProcess.Abort()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                If ExpHandler = True Then
                    thBaBeProcess.Abort()
                End If

                BatchResult = "Ontbrekende/ongeldige IBAN/BIC:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbAccountnumbers.ToString
                BatchResult = "Ontbrekende achternaam:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbLastName.ToString
                BatchResult &= vbCrLf & "Ontbrekende bedragen:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbNoAmount.ToString
                BatchResult &= vbCrLf & "Ontbrekende Indienstdatum:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbIndDatum.ToString
                BatchResult &= vbCrLf & "Afwijkende bedragen:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbAberrations.ToString
                BatchResult &= vbCrLf & "Meegenomen storneringen:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbStorno.ToString

                If Not String.IsNullOrEmpty(_thBaBeProcess.sbNatres.ToString) Then
                    BatchResult &= vbCrLf & "Natres leden met NSK instantie:" & vbCrLf
                    BatchResult &= _thBaBeProcess.sbNatres.ToString
                End If

                'If Ready And ExpHandler = False Then _
                '    MessageBox.Show("Klaar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End With

            WriteFile(MyDocuments & "\BatchResult.txt", BatchResult, False)
            lblProcess.Text = "U kunt nu SEPA bestand aanmaken op basis van deze testrun."

            System.Diagnostics.Process.Start("notepad.exe", MyDocuments & "\BatchResult.txt")


            btnSEPA.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmbYear.Enabled = True
            cmbMonth.Enabled = True
            lvSoorten.Enabled = True
            tbAmount.Enabled = True
            tbFixDesription.Enabled = True
        End Try
    End Sub

    Private Sub btnSEPA_Click(sender As Object, e As EventArgs) Handles btnSEPA.Click
        Try
            ' _thContributieBatch = New ContributieBatch
            Dim BatchResult As String = ""
            Dim thBaBeProcess As New System.Threading.Thread(AddressOf _thBaBeProcess.Create)
            With _thBaBeProcess

                Ready = False
                iCounter = 0
                Status = ""

                'If ._ = "" Then Throw New Exception("Voer eerst de testrun uit!")

                If ._PeriodeMonth = 0 Then Throw New Exception("Er is nog geen maand opgegeven.")
                If ._PeriodeMonth > 12 Then Throw New Exception("Opgegeven maand is ongeldig.")
                If ._PeriodeYear = 0 Then Throw New Exception("Er is nog geen Jaar opgegeven.")
                'If ._PeriodeYear > Now.Year Then Throw New Exception("Opgegeven jaar mag niet in de toekomst zijn.")

                thBaBeProcess.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()

                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = ""
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1
                    End If
                    frm.lbMessage.Text = Status & vbCrLf & iCounter
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Or ExpHandler = True Then
                        thBaBeProcess.Abort()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.Text = "Was bezig...."
                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                If ExpHandler = True Then
                    thBaBeProcess.Abort()
                Else
                    Process.Start("explorer.exe", MyDocuments)
                End If

            End With


            _thBaBeProcess = Nothing

   
            btnSEPA.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tbAmount.Enabled = True
            lvSoorten.Enabled = True
            cmbMonth.Enabled = True
            cmbYear.Enabled = True
            btnSEPA.Enabled = False
            tbFixDesription.Enabled = True
        End Try
    End Sub


    Private Sub btnControleSEPASpec_Click(sender As Object, e As EventArgs) Handles btnControleSEPASpec.Click
        Try

            Dim MaxTransactie As String = 10 '0000


            'Dim soort As String = ""
            'For Each item As ListViewItem In lvSoorten.SelectedItems
            '    If item.Text = "0" Then Continue For
            '    soort &= "'" & item.Text & "' ,"
            'Next
            'If soort.EndsWith(",") Then
            '    soort = soort.Substring(0, soort.LastIndexOf(","))
            'End If

            'If soort.Length < 1 Then
            '    Throw New Exception("Er is/zijn nog geen lidsoort(en) geselecteerd!")
            'End If


            Status = ""
            Ready = False
            ExpHandler = False

            cmbYear.Enabled = False
            cmbMonth.Enabled = False
            lvSoorten.Enabled = False
            tbAmount.Enabled = False
            tbFixDesription.Enabled = False

            _thBaBeProcess = New BaBeProcess
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(tbfile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(";")
                Dim currentRow As String()
                _thBaBeProcess._LidNummersList = New List(Of Babelidnrs)
                Dim mylid As New Babelidnrs
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        mylid = New Babelidnrs
                        mylid.lidnr = currentRow(0)
                        mylid.OldIban = currentRow(1)
                        _thBaBeProcess._LidNummersList.Add(mylid)
                    Catch ex As Microsoft.VisualBasic.
                                FileIO.MalformedLineException
                        Throw New Exception("Line " & ex.Message & "is is niet goed of niet aanwezig.")
                    End Try
                End While
            End Using


            Dim BatchResult As String = ""
            Dim thBaBeProcess As New System.Threading.Thread(AddressOf _thBaBeProcess.testSpecificRun)
            With _thBaBeProcess
                ._MaxTransactieCount = GetSysSettingOf("CLIEOP")
                '._SenderIdentificatie = "CLIPT" & Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10)
                ._PeriodeYear = cmbYear.SelectedValue
                ._PeriodeMonth = cmbMonth.SelectedValue
                ._AccountNumber = GetSysSettingOf("SEPA_IBAN")
                ._CompanyName = "VBM"
                ._CompanyBICcode = GetSysSettingOf("SEPA_BIC")
                ._IncassantId = GetSysSettingOf("SEPA_IncassantId")
                ._LidSoorten = String.Empty
                ._BatchAmount = tbAmount.Text
                ._FixedDescription = tbFixDesription.Text
                ._SequenceType = cmbSeq.SelectedItem

                Dim SEPA_COLL As Integer
                Dim result As Boolean = Int32.TryParse(GetSysSettingOf("SEPA_COLLDT"), SEPA_COLL)
                Dim SEPA_COLLDT As Date = LastDayCurrentMonth()
                If result Then
                    SEPA_COLLDT = LastDayCurrentMonth.AddDays((SEPA_COLL * -1))
                Else
                    Throw New Exception("Er is geen SEPA_COLLDT gevonden of veld bevat geen nummeriek waarde in de systeem instellingen." & vbCrLf _
                        & "Laat de systeembeheer controleren of het record ''SEPA_COLLDT'' aanwezig is en gevuld!")
                End If

                ._RequestedCollectionDate = SEPA_COLLDT


                'validate verplichte waardes
                If ._PeriodeMonth = 0 Then Throw New Exception("Er is nog geen maand opgegeven.")
                If ._PeriodeMonth > 12 Then Throw New Exception("Opgegeven maand is ongeldig.")
                If ._PeriodeYear = 0 Then Throw New Exception("Er is nog geen Jaar opgegeven.")

                If String.IsNullOrEmpty(._AccountNumber) Then _
                    Throw New Exception("Er is geen IBAN gevonden in de systeem instellingen." & vbCrLf _
                        & "Laat de systeembeheer controleren of het record ''SEPA_IBAN'' aanwezig is en gevuld!")

                If String.IsNullOrEmpty(._IncassantId) Then _
                    Throw New Exception("Er is geen IncassantId gevonden in de systeem instellingen." & vbCrLf _
                        & "Laat de systeembeheer controleren of het record ''SEPA_IncassantId'' aanwezig is en gevuld!")


                thBaBeProcess.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()

                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = ""
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1
                    End If
                    frm.lbMessage.Text = Status
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        thBaBeProcess.Abort()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                If ExpHandler = True Then
                    thBaBeProcess.Abort()
                End If

                BatchResult = "Ontbrekende IBANnummers:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbAccountnumbers.ToString
                BatchResult = "Ontbrekende Indienstdatum:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbIndDatum.ToString
                BatchResult &= vbCrLf & "Afwijkende bedragen:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbAberrations.ToString
                BatchResult &= vbCrLf & "Meegenomen storneringen:" & vbCrLf
                BatchResult &= _thBaBeProcess.sbStorno.ToString

                If Not String.IsNullOrEmpty(_thBaBeProcess.sbNatres.ToString) Then
                    BatchResult &= vbCrLf & "Natres leden met NSK instantie:" & vbCrLf
                    BatchResult &= _thBaBeProcess.sbNatres.ToString
                End If


                'If Ready And ExpHandler = False Then _
                '    MessageBox.Show("Klaar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End With

            'MyContributieBatch = New ContributieBatch("CLIPT", cmbYear.SelectedValue, cmbMonth.SelectedValue, RekNr, soort, tbAmount.Text)


            WriteFile(MyDocuments & "\BatchResult.txt", BatchResult, False)
            lblProcess.Text = "U kunt nu SEPA bestand aanmaken op basis van deze testrun."

            System.Diagnostics.Process.Start("notepad.exe", MyDocuments & "\BatchResult.txt")

            btnSEPA.Enabled = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmbYear.Enabled = True
            cmbMonth.Enabled = True
            lvSoorten.Enabled = True
            tbAmount.Enabled = True
            tbFixDesription.Enabled = True
        End Try
    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Try

            With Me.OpenFileDialog1
                .Reset()

                If Not My.Settings.ReportsPath = "" Then
                    .InitialDirectory = My.Settings.ReportsPath
                End If
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = "csv"
                .Filter = "Text files (*.txt)|*.txt|" & "csv files|*.csv"
                .Multiselect = False
                .Title = "Select a file"
                .ValidateNames = True
                If .ShowDialog() = DialogResult.OK Then
                    Me.tbfile.Text = .FileName
                    My.Settings.Save()
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        Try
            Status = ""
            iCounter = 0
            Ready = False
            ExpHandler = False

            _thBaBeProcess = New BaBeProcess
            '_thContributieBatch = New ContributieBatch

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbAmount_TextChanged(sender As Object, e As EventArgs) Handles tbAmount.TextChanged
        btnSEPA.Enabled = False

    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonth.SelectedIndexChanged
        btnSEPA.Enabled = False
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYear.SelectedIndexChanged
        btnSEPA.Enabled = False
    End Sub

End Class