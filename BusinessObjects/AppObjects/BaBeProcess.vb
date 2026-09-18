Imports SEPAObjects
Imports System.Xml.Serialization
Imports System.IO

Public Class Babelidnrs
    Private _lidnr As String
    Public Property lidnr() As String
        Get
            Return _lidnr
        End Get
        Set(ByVal value As String)
            _lidnr = value
        End Set
    End Property
    Private _OldIban As String
    Public Property OldIban() As String
        Get
            Return _OldIban
        End Get
        Set(ByVal value As String)
            _OldIban = value
        End Set
    End Property

End Class
Public Class BaBeProcess

    Private da As New DataAccess
    Public Event GenerateComplete(ByVal iCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)


    Private iCounter As Integer = 0
    Private iTotalCounter As Integer = 0

    Private _dtSEPA As DataTable

    Public bAnpv As Boolean = False
    Public _BatchAmount As Integer
    Private bUseAantal As Boolean = False
    Public _MaxTransactieCount As Integer
    Public _SenderIdentificatie As String = String.Empty
    Public _PeriodeYear As String = String.Empty
    Public _PeriodeMonth As String = String.Empty
    Public _AccountNumber As String = String.Empty
    Public _CompanyName As String = String.Empty
    Public _CompanyBICcode As String = String.Empty
    Public _IncassantId As String = String.Empty
    Public _RequestedCollectionDate As Date = LastDayCurrentMonth()
    Public _FixedDescription As String = String.Empty


    Public _LidSoorten As String = String.Empty
    Public _LidNummers As String = String.Empty
    Public _SequenceType As String = "FRST"
    Public _LidNummersList As New List(Of Babelidnrs)


    Public StornoList As New Storneringen

    Public sbAccountnumbers As Text.StringBuilder
    Public sbLastName As Text.StringBuilder
    Public sbNoAmount As Text.StringBuilder
    Public sbIndDatum As Text.StringBuilder
    Public sbAberrations As Text.StringBuilder
    Public sbStorno As Text.StringBuilder
    Public sbNatres As Text.StringBuilder
    Public ClieopResult As String = ""

    Private totalAmount As Decimal = 0
    Private Function FindOldIBAN(lidnr) As String
        Try
            Dim result As String = String.Empty
            For Each nr In _LidNummersList
                If nr.lidnr = lidnr Then Return nr.OldIban
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function buildLidNrString() As String
        Dim result As String = String.Empty
        For Each nr In _LidNummersList
            result &= "'" & nr.lidnr & "' ,"
        Next
        If result.EndsWith(",") Then
            result = result.Substring(0, result.LastIndexOf(","))
        End If
        Return result
    End Function
    Public Sub New()

    End Sub

    Private _hashtotaal As Int64 = 0
    Public Property hashtotaal() As Int64
        Get
            Return _hashtotaal
        End Get
        Set(ByVal value As Int64)
            _hashtotaal = value
        End Set
    End Property

    Private _TransactieCount As Int32 = 0
    Public Property TransactieCount() As Int32
        Get
            Return _TransactieCount
        End Get
        Set(ByVal value As Int32)
            'If _TransactieCount >= _MaxTransactieCount Then
            '    ' RaiseEvent MaxTransaction(True)
            '    'Throw New Exception("Max van " & _MaxTransactieCount & " transacties overschreden.")
            'End If
            _TransactieCount = value
        End Set
    End Property

    Private Function IsNatres() As Boolean
        Try
            Dim arSoort As Array = Nothing
            arSoort = _LidSoorten.Replace("'", "").Split(",")
            For Each item In arSoort
                If item.trim = "N" Then Return True
            Next
            Return False
        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Function
    Private _dtRelaties As DataTable
    Public Property dtRelaties() As DataTable
        Get
            If _dtRelaties Is Nothing Then
                If String.IsNullOrEmpty(_LidSoorten) Then
                    _dtRelaties = GetSpecificRelations()
                Else
                    _dtRelaties = GetRelations()
                End If

            End If
            Return _dtRelaties
        End Get
        Set(ByVal value As DataTable)
            _dtRelaties = value
        End Set
    End Property
    Private _dtNatresNSK As DataTable
    Public Property dtNatresNSK() As DataTable
        Get
            If _dtNatresNSK Is Nothing Then
                _dtNatresNSK = GetNatresNSK()
            End If
            Return _dtNatresNSK
        End Get
        Set(ByVal value As DataTable)
            _dtNatresNSK = value
        End Set
    End Property
    Private _NSK_ID As Integer = -1
    Public ReadOnly Property NSK_ID() As Integer
        Get
            If _NSK_ID = -1 Then
                _NSK_ID = da.ExecuteScalar("select Id from Contr_instanties where naam = 'NSK'")
            End If

            Return _NSK_ID
        End Get
    End Property
    Private _BANK_ID As Integer = -1
    Public ReadOnly Property BANK_ID() As Integer
        Get
            If _BANK_ID = -1 Then
                Dim GetBankId As String = GetSysSettingOf("AutoIncassoId", False)
                If String.IsNullOrEmpty(GetBankId) Then
                    _BANK_ID = da.ExecuteScalar("select Id from Contr_instanties where naam = 'BANK'")
                Else
                    _BANK_ID = GetBankId
                End If
            End If

            Return _BANK_ID
        End Get
    End Property
    Private _NATRES_ID As Integer = -1
    Public ReadOnly Property NATRES_ID() As Integer
        Get
            If _NATRES_ID = -1 Then

                _NATRES_ID = da.ExecuteScalar("select Id from lidsoorten where soort = 'N'")
            End If

            Return _NATRES_ID
        End Get
    End Property
    Private Function GetRelations() As DataTable

        Try
            Dim dt As New DataTable
            Dim da As New DataAccess
            Dim paramDate As New ArrayList

            paramDate.Add("@datein")
            paramDate.Add(New Date(_PeriodeYear, _PeriodeMonth, "01"))
            paramDate.Add("@Instantie")
            paramDate.Add(BANK_ID)

            RaiseEvent GenerateStatus("Bezig met ophalen van relaties in lidsoort " & _LidSoorten)
            Dim sql As String = "SELECT relaties.id, lidnr, achternaam ,ls.omschrijving, bankrek ,ls.soort " & _
                    "from  relaties " & _
                    "inner join Lidsoorten ls on ls.id = " & _
                            "(SELECT TOP 1 lidsoortid FROM Lidsoortperioden where (lidid = relaties.id AND datumin <= @datein) ORDER BY datumin DESC) " & _
                    "WHERE ls.soort IN (" & _LidSoorten & ") AND Instantieid = @Instantie AND (eindedatum IS NULL OR eindedatum > @datein) AND Status = 0 "

            dt = da.ExecuteDataTable(sql, paramDate.ToArray)

            iTotalCounter = dt.Rows.Count
            If iTotalCounter = 0 Then RaiseEvent GenerateExp(New Exception("Er zijn geen relaties gevonden in huidige selectie!"))
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetSpecificRelations() As DataTable

        Try
            Dim dt As New DataTable
            Dim da As New DataAccess
            Dim paramDate As New ArrayList

            paramDate.Add("@datein")
            paramDate.Add(New Date(_PeriodeYear, _PeriodeMonth, "01"))
            paramDate.Add("@Instantie")
            paramDate.Add(BANK_ID)

            RaiseEvent GenerateStatus("Bezig met ophalen van relaties in specifieke leden ")
            Dim sql As String = "SELECT relaties.id, lidnr, achternaam ,ls.omschrijving, bankrek ,ls.soort " & _
                    "from  relaties " & _
                    "inner join Lidsoorten ls on ls.id = " & _
                            "(SELECT TOP 1 lidsoortid FROM Lidsoortperioden where (lidid = relaties.id AND datumin <= @datein) ORDER BY datumin DESC) " & _
                    "WHERE lidnr IN (" & buildLidNrString() & ") AND Instantieid = @Instantie AND (eindedatum IS NULL OR eindedatum > @datein) AND Status = 0 "

            dt = da.ExecuteDataTable(sql, paramDate.ToArray)

            iTotalCounter = dt.Rows.Count
            If iTotalCounter = 0 Then RaiseEvent GenerateExp(New Exception("Er zijn geen relaties gevonden in huidige selectie!"))
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetNatresNSK() As DataTable

        Try
            Dim dt As New DataTable
            Dim da As New DataAccess
            Dim paramDate As New ArrayList

            paramDate.Add("@datein")
            paramDate.Add(New Date(_PeriodeYear, _PeriodeMonth, "01"))
            paramDate.Add("@Instantie")
            paramDate.Add(NSK_ID)

            RaiseEvent GenerateStatus("Bezig met ophalen van relaties in lidsoort " & _LidSoorten)
            Dim sql As String = "SELECT relaties.id, lidnr, achternaam, '' as omschrijving, bankrek ,'' as soort " & _
                    "from  relaties " & _
                    "WHERE lid_natres = 1 AND Instantieid = @Instantie AND (eindedatum IS NULL OR eindedatum > @datein) AND Status = 0 "
            dt = da.ExecuteDataTable(sql, paramDate.ToArray)

            iTotalCounter += dt.Rows.Count
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub testRun()

        _dtSEPA = New DataTable
        Dim col As DataColumn
        Try

            col = New DataColumn
            col.ColumnName = "lidid"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "lidnr"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "IBAN"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "BIC"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "amount"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "name"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "DtOfSgntr"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "done"
            _dtSEPA.Columns.Add(col)

            Dim SEPARow As DataRow
            Dim relatie As Relaties
            Dim Contributie As Contributies

            sbAccountnumbers = New Text.StringBuilder
            sbLastName = New Text.StringBuilder
            sbNoAmount = New Text.StringBuilder
            sbIndDatum = New Text.StringBuilder
            sbAberrations = New Text.StringBuilder
            sbStorno = New Text.StringBuilder
            sbNatres = New Text.StringBuilder


            iCounter = 0
            If _BatchAmount = 0 Then bUseAantal = True

            For Each row As DataRow In dtRelaties.Rows
                iCounter += 1
                RaiseEvent GenerateStatus("Controle van " & iCounter & " van " & iTotalCounter)
                RaiseEvent GenerateCounter(iCounter)

                relatie = New Relaties(row("id"), Relaties.Via.ID)
                If relatie.Found Then
                    'Controleer of IBAN nummer aanwezig is.
                    If validate_iban(relatie.IBAN) = False Or relatie.IBAN = "0" Then
                        sbAccountnumbers.Append("lidnr: " & relatie.lidnr & " ;IBAN ongeldig of ontbreekt. " & vbCrLf)
                        'Geen IBAN dan kan je ook niet incasseren dus ga dan maar gelijk naar de volgende
                        Continue For
                        'BMO: 2017-12-04 Bug ID:  1132 'Short desc: BIC code niet langer verplicht 
                        'If Not validate_biccode(relatie.BIC) Then
                        '    sbAccountnumbers.Append("lidnr: " & relatie.lidnr & " ;BIC code ongeldig of ontbreekt. " & vbCrLf)
                        '    'Geen BIC code dan kan je ook niet incasseren dus overslaan
                        '    Continue For
                        'End If
                    End If

                    'Controleer of achternaam aanwezig is.(bgid 1513)
                    If String.IsNullOrEmpty(relatie.achternaam.Trim) Then
                        sbLastName.Append("lidnr: " & relatie.lidnr & " ;achternaam ontbreekt. " & vbCrLf)
                        'Geen achternaam dan kan je ook niet incasseren dus ga dan maar gelijk naar de volgende
                        Continue For
                    End If

                    'Controleer of indiendatum een geldig formaat heeft.
                    Dim testDate As Date = New Date(2000, 1, 1)
                    Try
                        If Date.TryParseExact(relatie.indatum, "dd-mm-yyyy", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.AllowWhiteSpaces, testDate) = False Then
                            sbIndDatum.Append("lidnr: " & relatie.lidnr & " ;indatum error. " & vbCrLf)
                            Continue For
                        End If
                    Catch ex As Exception
                        sbIndDatum.Append("lidnr: " & relatie.lidnr & " ;indatum ontbreekt. " & vbCrLf)
                        Continue For
                    End Try

                    'Haal het verwachte contributiebedrag op voor de selecteerde maand.
                    Contributie = New Contributies(relatie.Id, Contributies.Via.RELATIEID, _PeriodeYear)
                    Dim ContributieAmount As Integer = Contributie.ContributieAmount(_PeriodeMonth)


                    'Controleer het verwachte bedrag(excl. storno's) tegen het opgegeven bedrag.
                    If ContributieAmount <> _BatchAmount Then
                        sbAberrations.Append("lidnr: " & relatie.lidnr & " ;verwachtte bedrag: " & ContributieAmount & vbCrLf)
                    End If

                    'Controleer of er een storno is van de vorige periode.
                    'om te zorgen dat je in periode 12 van vorig jaar uitkomt bij selectie periode januari
                    'moet er eerst een datum van gemaakt.
                    Dim StornoAmount As Decimal = 0

                        Dim newDate As New Date(_PeriodeYear, _PeriodeMonth, "01")
                        newDate = newDate.AddMonths(-1)

                        Dim myStorno As New Stornering(relatie.Id, Stornering.Via.lIDID_PER, newDate)
                        If myStorno.Found Then
                            StornoAmount = myStorno.bedrag
                            sbStorno.AppendLine("lidnr: " & relatie.lidnr & " ;storno bedrag " & myStorno.bedrag & " ;periode: " & myStorno.periode & " ;reden: " & myStorno.eindereden & " ;teller: " & myStorno.teller & vbCrLf)
                            myStorno.status = "meegenomen in batch " & _PeriodeYear & "-" & _PeriodeMonth
                            myStorno.Save()
                        End If

                        SEPARow = _dtSEPA.NewRow
                        SEPARow.Item("lidid") = relatie.Id
                        SEPARow.Item("lidnr") = relatie.lidnr
                        SEPARow.Item("IBAN") = NoWhiteSpace(relatie.IBAN.ToUpper)
                        SEPARow.Item("BIC") = NoWhiteSpace(relatie.BIC.ToUpper)
                        SEPARow.Item("amount") = _BatchAmount + StornoAmount
                        SEPARow.Item("name") = ConvertAccent(relatie.achternaam)
                        SEPARow.Item("DtOfSgntr") = relatie.indatum
                        SEPARow.Item("done") = "N"
                        _dtSEPA.Rows.Add(SEPARow)

                    End If

            Next

            If IsNatres() Then
                iCounter = 0
                For Each row As DataRow In dtNatresNSK.Rows
                    iCounter += 1
                    RaiseEvent GenerateStatus("Controle van NatresNSK " & iCounter & " van " & dtNatresNSK.Rows.Count)
                    RaiseEvent GenerateCounter(iCounter)
                    sbNatres.Append("lidnr: " & row("lidnr") & " ;NSK <> BANK" & vbCrLf)
                Next
            End If

            RaiseEvent GenerateComplete(iCounter)
        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub
    Public Sub testSpecificRun()

        _dtSEPA = New DataTable
        Dim col As DataColumn
        Try

            col = New DataColumn
            col.ColumnName = "lidid"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "lidnr"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "IBAN"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "BIC"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "amount"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "name"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "DtOfSgntr"
            _dtSEPA.Columns.Add(col)

            col = New DataColumn
            col.ColumnName = "done"
            _dtSEPA.Columns.Add(col)

            Dim SEPARow As DataRow
            Dim relatie As Relaties
            Dim Contributie As Contributies

            sbAccountnumbers = New Text.StringBuilder
            sbIndDatum = New Text.StringBuilder
            sbAberrations = New Text.StringBuilder
            sbStorno = New Text.StringBuilder
            sbNatres = New Text.StringBuilder


            iCounter = 0
            For Each row As DataRow In dtRelaties.Rows
                iCounter += 1
                RaiseEvent GenerateStatus("Controle van " & iCounter & " van " & iTotalCounter)
                RaiseEvent GenerateCounter(iCounter)

                relatie = New Relaties(row("id"), Relaties.Via.ID)
                If relatie.Found Then
                    'Controleer of IBAN nummer aanwezig is.
                    If validate_iban(relatie.IBAN) = False Or relatie.IBAN = "0" Then
                        sbAccountnumbers.Append("lidnr: " & relatie.lidnr & " ;IBAN ontbreekt. " & vbCrLf)
                        'Geen IBAN dan kan je ook niet incasseren dus ga dan maar gelijk naar de volgende
                        Continue For
                    End If

                    'Controleer of indiendatum een geldig formaat heeft.
                    Dim testDate As Date = New Date(2000, 1, 1)
                    Try
                        If Date.TryParseExact(relatie.indatum, "dd-mm-yyyy", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.AllowWhiteSpaces, testDate) = False Then
                            sbIndDatum.Append("lidnr: " & relatie.lidnr & " ;indatum error. " & vbCrLf)
                            Continue For
                        End If
                    Catch ex As Exception
                        sbIndDatum.Append("lidnr: " & relatie.lidnr & " ;indatum ontbreekt. " & vbCrLf)
                        Continue For
                    End Try

                    'Haal het verwachte contributiebedrag op voor de selecteerde maand.
                    Contributie = New Contributies(relatie.Id, Contributies.Via.RELATIEID, _PeriodeYear)
                    Dim ContributieAmount As Integer = Contributie.ContributieAmount(_PeriodeMonth)

                    'Controleer het verwachte bedrag(excl. storno's) tegen het opgegeven bedrag.
                    If ContributieAmount <> _BatchAmount Then
                        sbAberrations.Append("lidnr: " & relatie.lidnr & " ;verwachtte bedrag: " & ContributieAmount & vbCrLf)
                    End If

                    'Controleer of er een storno is van de vorige periode.
                    'om te zorgen dat je in periode 12 van vorig jaar uitkomt bij selectie periode januari
                    'moet er eerst een datum van gemaakt.
                    Dim StornoAmount As Decimal = 0

                    Dim newDate As New Date(_PeriodeYear, _PeriodeMonth, "01")
                    newDate = newDate.AddMonths(-1)

                    Dim myStorno As New Stornering(relatie.Id, Stornering.Via.lIDID_PER, newDate)
                    If myStorno.Found Then
                        StornoAmount = myStorno.bedrag
                        sbStorno.AppendLine("lidnr: " & relatie.lidnr & " ;storno bedrag " & myStorno.bedrag & " ;periode: " & myStorno.periode & " ;reden: " & myStorno.eindereden & " ;teller: " & myStorno.teller & vbCrLf)
                        myStorno.status = "meegenomen in batch " & _PeriodeYear & "-" & _PeriodeMonth
                        myStorno.Save()
                    End If

                    SEPARow = _dtSEPA.NewRow
                    SEPARow.Item("lidid") = relatie.Id
                    SEPARow.Item("lidnr") = relatie.lidnr
                    SEPARow.Item("IBAN") = relatie.IBAN
                    SEPARow.Item("BIC") = relatie.BIC
                    SEPARow.Item("amount") = _BatchAmount + StornoAmount
                    SEPARow.Item("name") = ConvertAccent(relatie.achternaam)
                    SEPARow.Item("DtOfSgntr") = relatie.indatum
                    SEPARow.Item("done") = "N"
                    _dtSEPA.Rows.Add(SEPARow)

                End If

            Next

            If IsNatres() Then
                iCounter = 0
                For Each row As DataRow In dtNatresNSK.Rows
                    iCounter += 1
                    RaiseEvent GenerateStatus("Controle van NatresNSK " & iCounter & " van " & dtNatresNSK.Rows.Count)
                    RaiseEvent GenerateCounter(iCounter)
                    sbNatres.Append("lidnr: " & row("lidnr") & " ;NSK <> BANK" & vbCrLf)
                Next
            End If

            RaiseEvent GenerateComplete(iCounter)
        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub

    Private _Value As String
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property

    Public NewSEPA As tblSepa
    Public Sub Create()
        Try
            runsplit()
            WriteLastSepaRun()

            RaiseEvent GenerateStatus("SEPA klaar")
            RaiseEvent GenerateComplete(iCounter)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub

    Public Sub runsplit()
        Dim newDebet As DirectDebitTransactionInformation9
        Dim Contributie As Contributies
        iCounter = 0
        iTotalCounter = _dtSEPA.Rows.Count

        Dim DrctDbtTxInfList As New List(Of DirectDebitTransactionInformation9)
        For Each row As DataRow In _dtSEPA.Rows

            If row("done") = "J" Then Continue For
            If _TransactieCount >= _MaxTransactieCount Then
                SaveVersion(DrctDbtTxInfList)
                iCounter = 0
                totalAmount = 0
                _TransactieCount = 0
                DrctDbtTxInfList = New List(Of DirectDebitTransactionInformation9)
            End If

            iCounter += 1
            RaiseEvent GenerateStatus("sepa record van " & iCounter & " van " & iTotalCounter)
            RaiseEvent GenerateCounter(iCounter)
            row("done") = "J"

            'Als er geen rekNr is dan overslaan.
            If String.IsNullOrEmpty(row("IBAN")) Then Continue For

            Dim bIBANChanced As Boolean = False

            'contributie verwerken in database
            Contributie = New Contributies(row("lidid"), Contributies.Via.RELATIEID, _PeriodeYear)
            'ter voorkomen van optellen van meerder contributie bedragen bij bijv. vast lopen wordt het niet meer opgeteld maar overschreven met het bedrag uit de run.
            'Contributie.AddPayment(CType(row("amount"), Decimal), CType(_PeriodeMonth, eMaand))
            Contributie.ReplacePayment(CType(row("amount"), Decimal), CType(_PeriodeMonth, eMaand))
            Contributie.Save()

            newDebet = New DirectDebitTransactionInformation9

            With newDebet
                .PmtId = New PaymentIdentification1
                'Het veld <EndToEndId></EndToEndId> moet de unieke referentie van de SDD-transactie bevatten. 
                'Deze wordt in elke R-transactie (afkeuring, stornering) teruggemeld. Dit is vergelijkbaar met het veld Betalingskenmerk in de ClieOp03.
                .PmtId.EndToEndId = row("lidnr")

                Dim formatAmount As String = row("amount")
                If formatAmount.Length > 2 Then
                    formatAmount = formatAmount.Insert(formatAmount.Length - 2, ".")
                End If

                .InstdAmt = New DirectDebitTransactionInformation9.InstructedAmount("EUR", formatAmount)

                .DrctDbtTx = New DirectDebitTransaction6
                .DrctDbtTx.MndtRltdInf = New MandateRelatedInformation6
                .DrctDbtTx.MndtRltdInf.MndtId = row("lidnr")

                Dim DateOfSign As Date = row("DtOfSgntr")
                If DateOfSign > Today Then
                    DateOfSign = Today.AddDays(-1)
                End If
                .DrctDbtTx.MndtRltdInf.DtOfSgntr = Format(DateOfSign, "yyyy-MM-dd")

                'If _LidNummers.Contains(row("lidnr")) Then
                '    bIBANChanced = True
                'End If
                Dim OldIban As String = FindOldIBAN(row("lidnr"))
                If Not String.IsNullOrEmpty(OldIban) Then
                    bIBANChanced = True
                End If

                If bIBANChanced Then
                    'TODO wel of niet amd
                    .DrctDbtTx.MndtRltdInf.AmdmntInd = "true"
                    .DrctDbtTx.MndtRltdInf.AmdmntInfDtls = New AmendmentInformationDetails6
                    .DrctDbtTx.MndtRltdInf.AmdmntInfDtls.OrgnlDbtrAcct = New CashAccount16
                    .DrctDbtTx.MndtRltdInf.AmdmntInfDtls.OrgnlDbtrAcct.Id.IBAN = OldIban

                    .DrctDbtTx.MndtRltdInf.AmdmntInfDtls.OrgnlDbtrAgt = New BranchAndFinancialInstitutionIdentification4
                    .DrctDbtTx.MndtRltdInf.AmdmntInfDtls.OrgnlDbtrAgt.FinInstnId = New BranchAndFinancialInstitutionIdentification4.FinancialInstitutionIdentification7
                    .DrctDbtTx.MndtRltdInf.AmdmntInfDtls.OrgnlDbtrAgt.FinInstnId.Othr = New GenericFinancialIdentification1
                    .DrctDbtTx.MndtRltdInf.AmdmntInfDtls.OrgnlDbtrAgt.FinInstnId.Othr.Id = "SMNDA"
                End If


                'Wettelijk is vastgesteld dat voor binnenlandse SEPA-betalingen per 1 februari 2014 alleen nog de IBAN vereist is. 
                'De BIC verdwijnt dus per 1 februari 2014 voor binnenlandse betalingen. Per 1 februari 2016 verdwijnt de BIC tevens voor buitenlandse SEPA-betalingen.
                .DbtrAgt = New BranchAndFinancialInstitutionIdentification4
                .DbtrAgt.FinInstnId = New BranchAndFinancialInstitutionIdentification4.FinancialInstitutionIdentification7
                'Bug:1144 - Sepa BIC codes verwijderen 
                '.DbtrAgt.FinInstnId.BIC = row("BIC") 'BIC code BANK debiteur

                .Dbtr = New PartyIdentification32
                .Dbtr.Nm = row("name")

                .DbtrAcct = New CashAccount16
                .DbtrAcct.Id = New AccountIdentification4Choice
                .DbtrAcct.Id.IBAN = row("IBAN")

                .RmtInf = New RemittanceInformation5
                If Not String.IsNullOrEmpty(_FixedDescription) Then
                    .RmtInf.Ustrd = _FixedDescription
                Else
                    .RmtInf.Ustrd = row("lidnr")
                End If

            End With

            DrctDbtTxInfList.Add(newDebet)
            totalAmount += row("amount")
            _TransactieCount += 1
        Next

        SaveVersion(DrctDbtTxInfList)
    End Sub
    Public Sub SaveVersion(_DrctDbtTxInf As List(Of DirectDebitTransactionInformation9))
        Dim SepaVersionsList As New SepaVersions
        NewSEPA = New tblSepa
        NewSEPA.Createdate = Today
        NewSEPA.Version = SepaVersionsList.Count + 1

        Dim cstDoc As XMLPain = New XMLPain
        'Dim MessageIdentification As CstmrDrctDbtInitn = New CstmrDrctDbtInitn
        With cstDoc.CstmrDrctDbtInitn

            '.GrpHdr.MsgId = _SenderIdentificatie   'message-id-001" 'Point to point reference, assigned by the instructing party and sent to the next party in the chain, to unambiguously identify the message.
            .GrpHdr.MsgId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10)
            .GrpHdr.NbOfTxs = "0" 'Number of individual transactions contained in the message.
            .GrpHdr.CtrlSum = "0" 'Total of all individual amounts included in the message
            .GrpHdr.InitgPty.Nm = _CompanyName 'cfg.CompanyName '‘Name’ is limited to 70 characters in length.

            'PaymentInformation
            'Het veld <PmtInfId></PmtInfId> moet een unieke identificatie bevatten voor de Payment Information block (= batch). 
            'Dit is vergelijkbaar met het veld Batchidentificatie in de ClieOp03 (alleen in Equens-variant aanwezig, voor Postbank-variant is dit veld afwezig).
            .PmtInf.PmtInfId = "20" 'Unique identification, as assigned by a sending party, to unambiguously identify the payment information group within the message.
            .PmtInf.PmtMtd = "DD" 'One of the following PaymentMethod2Code values must be used: DD -  DirectDebit
            .PmtInf.NbOfTxs = "0" 'Number of individual transactions contained in the payment information group.
            .PmtInf.CtrlSum = "0" 'Total of all individual amounts included in the group.

            'PaymentTypeInformation - ServiceLevel
            .PmtInf.PmtTpInf.SvcLvl = New CodeProprietary
            .PmtInf.PmtTpInf.SvcLvl.Cd = "SEPA" 'Only ‘SEPA’ is allowed.

            'PaymentTypeInformation - LocalInstrument
            .PmtInf.PmtTpInf.LclInstrm = New CodeProprietary
            .PmtInf.PmtTpInf.LclInstrm.Cd = "CORE" 'Only ‘CORE’, ‘COR1’ or ‘B2B’ are allowed.

            'PaymentTypeInformation - SequenceType
            .PmtInf.PmtTpInf.SeqTp = _SequenceType 'Allowed codes: FRST, RCUR, OOFF, FNAL

            'PaymentTypeInformation - CategoryPurpose
            .PmtInf.PmtTpInf.CtgyPurp = New CodeProprietary
            .PmtInf.PmtTpInf.CtgyPurp.Cd = "DCRD" 'Category purpose, as published in an external category purpose code list???

            'RequestedCollectionDate
            .PmtInf.ReqdColltnDt = Format(_RequestedCollectionDate, "yyyy-MM-dd") 'Date and time at which the creditor requests that the amount of money is to be collected from the debtor.

            'Creditor - Party to which an amount of money is due.
            .PmtInf.Cdtr = New PartyIdentification32
            .PmtInf.Cdtr.Nm = _CompanyName ''Name’ is mandatory, is limited to 70 characters in length.

            'CreditorAccount - Unambiguous identification of the account of the creditor to which a credit entry will be posted as a result of the payment transaction.
            .PmtInf.CdtrAcct = New CashAccount16
            .PmtInf.CdtrAcct.Id = New AccountIdentification4Choice
            .PmtInf.CdtrAcct.Id.IBAN = _AccountNumber '"NL38INGB0000027660" 

            'CreditorAgent - Financial institution servicing an account for the creditor.
            .PmtInf.CdtrAgt = New BranchAndFinancialInstitutionIdentification4
            .PmtInf.CdtrAgt.FinInstnId = New BranchAndFinancialInstitutionIdentification4.FinancialInstitutionIdentification7
            .PmtInf.CdtrAgt.FinInstnId.BIC = _CompanyBICcode '"INGBNL2A" 'Only BIC elelment is allowed  

            'ChargeBearer - Specifies which party/parties will bear the charges associated with the processing of the payment transaction.
            .PmtInf.ChrgBr = "SLEV" 'Only ‘SLEV’ is allowed.

            'CreditorSchemeIdentification - Credit party that signs the mandate.
            .PmtInf.CdtrSchmeId = New PartyIdentificationCdtrSchme
            '.PmtInf.CdtrSchmeId.Nm = "bedrijfsnaam incassant(op mandaat)"
            .PmtInf.CdtrSchmeId.Id = New Party6Choice
            .PmtInf.CdtrSchmeId.Id.PrvtId = New PersonIdentification5
            'Het IncassantID moet in het veld /PmtInf/CdtrSchmeId/Id/PrvtId/Othr/Id (batch-niveau)
            ' of in het veld /PmtInf/DrctDbtTxInf/DrctDbtTx/CdtrSchmeId/Id/PrvtId/Othr/Id (transactie-niveau) worden meegegeven. 
            .PmtInf.CdtrSchmeId.Id.PrvtId.Othr.Id = _IncassantId 'CLIPT22011 
            .PmtInf.CdtrSchmeId.Id.PrvtId.Othr.SchmeNm.Prtry = "SEPA"

            'DirectDebitTransactionInformation - Set of elements used to provide information on the individual transaction(s) included in the message.
            .PmtInf.DrctDbtTxInf = New List(Of DirectDebitTransactionInformation9)

            iCounter = 0
            iTotalCounter = _dtSEPA.Rows.Count

            .PmtInf.DrctDbtTxInf.AddRange(_DrctDbtTxInf)


            Dim formatTotalAmount As String = totalAmount
            If formatTotalAmount.Length > 2 Then
                formatTotalAmount = formatTotalAmount.Insert(formatTotalAmount.Length - 2, ".")
            End If

            .GrpHdr.NbOfTxs = _TransactieCount 'Number of individual transactions contained in the message.
            .GrpHdr.CtrlSum = formatTotalAmount 'Total of all individual amounts included in the message

            .PmtInf.NbOfTxs = _TransactieCount 'Number of individual transactions contained in the payment information group.
            .PmtInf.CtrlSum = formatTotalAmount 'Total of all individual amounts included in the group.

        End With

        NewSEPA.Save()

        Dim SEPAFileName As String = "\SEPANEW_X.xml"
        If Not NewSEPA Is Nothing Then
            SEPAFileName = SEPAFileName.Replace("X", NewSEPA.Version)
        End If

        Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(XMLPain))
        Dim myWriter As StreamWriter = New StreamWriter(MyDocuments & SEPAFileName)

        Dim NS As New XmlSerializerNamespaces
        NS.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance")

        mySerializer.Serialize(myWriter, cstDoc, NS)
        myWriter.Close()

        hashtotaal = 0
        TransactieCount = 0
        Value = ""
        totalAmount = 0
    End Sub
    'Public Sub run()

    '    Dim SepaVersionsList As New ClieopVersions
    '    NewSEPA = New tblSepa
    '    NewSEPA.Createdate = Today
    '    NewSEPA.Version = SepaVersionsList.Count + 1

    '    Dim cstDoc As XMLPain = New XMLPain
    '    'Dim MessageIdentification As CstmrDrctDbtInitn = New CstmrDrctDbtInitn
    '    With cstDoc.CstmrDrctDbtInitn

    '        '.GrpHdr.MsgId = _SenderIdentificatie   'message-id-001" 'Point to point reference, assigned by the instructing party and sent to the next party in the chain, to unambiguously identify the message.
    '        .GrpHdr.MsgId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10)
    '        .GrpHdr.NbOfTxs = "0" 'Number of individual transactions contained in the message.
    '        .GrpHdr.CtrlSum = "0" 'Total of all individual amounts included in the message
    '        .GrpHdr.InitgPty.Nm = _CompanyName 'cfg.CompanyName '‘Name’ is limited to 70 characters in length.

    '        'PaymentInformation
    '        'Het veld <PmtInfId></PmtInfId> moet een unieke identificatie bevatten voor de Payment Information block (= batch). 
    '        'Dit is vergelijkbaar met het veld Batchidentificatie in de ClieOp03 (alleen in Equens-variant aanwezig, voor Postbank-variant is dit veld afwezig).
    '        .PmtInf.PmtInfId = "20" 'Unique identification, as assigned by a sending party, to unambiguously identify the payment information group within the message.
    '        .PmtInf.PmtMtd = "DD" 'One of the following PaymentMethod2Code values must be used: DD -  DirectDebit
    '        .PmtInf.NbOfTxs = "0" 'Number of individual transactions contained in the payment information group.
    '        .PmtInf.CtrlSum = "0" 'Total of all individual amounts included in the group.

    '        'PaymentTypeInformation - ServiceLevel
    '        .PmtInf.PmtTpInf.SvcLvl = New CodeProprietary
    '        .PmtInf.PmtTpInf.SvcLvl.Cd = "SEPA" 'Only ‘SEPA’ is allowed.

    '        'PaymentTypeInformation - LocalInstrument
    '        .PmtInf.PmtTpInf.LclInstrm = New CodeProprietary
    '        .PmtInf.PmtTpInf.LclInstrm.Cd = "CORE" 'Only ‘CORE’, ‘COR1’ or ‘B2B’ are allowed.

    '        'PaymentTypeInformation - SequenceType
    '        .PmtInf.PmtTpInf.SeqTp = _SequenceType 'Allowed codes: FRST, RCUR, OOFF, FNAL

    '        'PaymentTypeInformation - CategoryPurpose
    '        .PmtInf.PmtTpInf.CtgyPurp = New CodeProprietary
    '        .PmtInf.PmtTpInf.CtgyPurp.Cd = "DCRD" 'Category purpose, as published in an external category purpose code list???

    '        'RequestedCollectionDate
    '        Dim SEPA_COLL As Integer = GetSysSettingOf("SEPA_COLLDT")
    '        Dim SEPA_COLLDT As Date = LastDayCurrentMonth.AddDays((SEPA_COLL * -1))
    '        .PmtInf.ReqdColltnDt = Format(SEPA_COLLDT, "yyyy-MM-dd") 'Date and time at which the creditor requests that the amount of money is to be collected from the debtor.

    '        'Creditor - Party to which an amount of money is due.
    '        .PmtInf.Cdtr = New PartyIdentification32
    '        .PmtInf.Cdtr.Nm = _CompanyName ''Name’ is mandatory, is limited to 70 characters in length.

    '        'CreditorAccount - Unambiguous identification of the account of the creditor to which a credit entry will be posted as a result of the payment transaction.
    '        .PmtInf.CdtrAcct = New CashAccount16
    '        .PmtInf.CdtrAcct.Id = New AccountIdentification4Choice
    '        .PmtInf.CdtrAcct.Id.IBAN = _AccountNumber '"NL38INGB0000027660" 

    '        'CreditorAgent - Financial institution servicing an account for the creditor.
    '        .PmtInf.CdtrAgt = New BranchAndFinancialInstitutionIdentification4
    '        .PmtInf.CdtrAgt.FinInstnId = New BranchAndFinancialInstitutionIdentification4.FinancialInstitutionIdentification7
    '        .PmtInf.CdtrAgt.FinInstnId.BIC = _CompanyBICcode '"INGBNL2A" 'Only BIC elelment is allowed  

    '        'UltimateCreditor - Ultimate party to which an amount of money is due.
    '        'UltimateCreditor may only be present if different from Creditor.
    '        '.PmtInf.UltmtCdtr = New PartyIdentificationCdtrSchme
    '        '.PmtInf.UltmtCdtr.Id = New Party6Choice
    '        '.PmtInf.UltmtCdtr.Id.PrvtId = New PersonIdentification5
    '        '.PmtInf.UltmtCdtr.Id.PrvtId.Othr.Id = "12345678"
    '        '.PmtInf.UltmtCdtr.Id.PrvtId.Othr.SchmeNm.Prtry = "KVK nummer"
    '        '.PmtInf.UltmtCdtr.Id.PrvtId.Othr.Issr = "KVK"

    '        'ChargeBearer - Specifies which party/parties will bear the charges associated with the processing of the payment transaction.
    '        .PmtInf.ChrgBr = "SLEV" 'Only ‘SLEV’ is allowed.

    '        'CreditorSchemeIdentification - Credit party that signs the mandate.
    '        .PmtInf.CdtrSchmeId = New PartyIdentificationCdtrSchme
    '        '.PmtInf.CdtrSchmeId.Nm = "bedrijfsnaam incassant(op mandaat)"
    '        .PmtInf.CdtrSchmeId.Id = New Party6Choice
    '        .PmtInf.CdtrSchmeId.Id.PrvtId = New PersonIdentification5
    '        'Het IncassantID moet in het veld /PmtInf/CdtrSchmeId/Id/PrvtId/Othr/Id (batch-niveau)
    '        ' of in het veld /PmtInf/DrctDbtTxInf/DrctDbtTx/CdtrSchmeId/Id/PrvtId/Othr/Id (transactie-niveau) worden meegegeven. 
    '        .PmtInf.CdtrSchmeId.Id.PrvtId.Othr.Id = _IncassantId 'CLIPT22011 
    '        .PmtInf.CdtrSchmeId.Id.PrvtId.Othr.SchmeNm.Prtry = "SEPA"

    '        'DirectDebitTransactionInformation - Set of elements used to provide information on the individual transaction(s) included in the message.
    '        .PmtInf.DrctDbtTxInf = New List(Of DirectDebitTransactionInformation9)

    '        Dim Contributie As Contributies
    '        iCounter = 0
    '        iTotalCounter = _dtSEPA.Rows.Count

    '        Dim newDebet As DirectDebitTransactionInformation9

    '        For Each row As DataRow In _dtSEPA.Rows

    '            If row("done") = "J" Then Continue For

    '            iCounter += 1
    '            RaiseEvent GenerateStatus("sepa record van " & iCounter & " van " & iTotalCounter)
    '            RaiseEvent GenerateCounter(iCounter)
    '            row("done") = "J"

    '            'Als er geen rekNr is dan overslaan.
    '            If String.IsNullOrEmpty(row("IBAN")) Then Continue For

    '            'contributie verwerken in database
    '            Contributie = New Contributies(row("lidid"), Contributies.Via.RELATIEID, _PeriodeYear)
    '            Contributie.AddPayment(CType(row("amount"), Decimal), CType(_PeriodeMonth, eMaand))
    '            Contributie.Save()

    '            newDebet = New DirectDebitTransactionInformation9

    '            With newDebet
    '                .PmtId = New PaymentIdentification1
    '                'Het veld <EndToEndId></EndToEndId> moet de unieke referentie van de SDD-transactie bevatten. 
    '                'Deze wordt in elke R-transactie (afkeuring, stornering) teruggemeld. Dit is vergelijkbaar met het veld Betalingskenmerk in de ClieOp03.
    '                .PmtId.EndToEndId = row("lidnr")

    '                Dim formatAmount As String = row("amount")
    '                If formatAmount.Length > 2 Then
    '                    formatAmount = formatAmount.Insert(formatAmount.Length - 2, ".")
    '                End If

    '                .InstdAmt = New DirectDebitTransactionInformation9.InstructedAmount("EUR", formatAmount)

    '                'Het IncassantID moet in het veld /PmtInf/CdtrSchmeId/Id/PrvtId/Othr/Id (batch-niveau)
    '                'of in het veld /PmtInf/DrctDbtTxInf/DrctDbtTx/CdtrSchmeId/Id/PrvtId/Othr/Id (transactie-niveau) worden meegegeven. 
    '                '.DrctDbtTx = New DirectDebitTransaction6
    '                '.DrctDbtTx.CdtrSchmeId = New PartyIdentificationCdtrSchme
    '                '.DrctDbtTx.CdtrSchmeId.Id = New Party6Choice
    '                '.DrctDbtTx.CdtrSchmeId.Id.PrvtId = New PersonIdentification5
    '                '.DrctDbtTx.CdtrSchmeId.Id.PrvtId.Othr = New GenericPersonIdentification1
    '                '.DrctDbtTx.CdtrSchmeId.Id.PrvtId.Othr.Id = "IncassantID"

    '                '.DrctDbtTx.MndtRltdInf = New MandateRelatedInformation6
    '                '.DrctDbtTx.MndtRltdInf.MndtId = "2806-000064"  'Het machtigingsID moet in het veld /PmtInf/DrctDbtTxInf/DrctDbtTx/MndtRltdInf/MndtId worden meegegeven.
    '                '.DrctDbtTx.MndtRltdInf.DtOfSgntr = "2009-11-01"

    '                'Wettelijk is vastgesteld dat voor binnenlandse SEPA-betalingen per 1 februari 2014 alleen nog de IBAN vereist is. 
    '                'De BIC verdwijnt dus per 1 februari 2014 voor binnenlandse betalingen. Per 1 februari 2016 verdwijnt de BIC tevens voor buitenlandse SEPA-betalingen.

    '                .DbtrAgt = New BranchAndFinancialInstitutionIdentification4
    '                .DbtrAgt.FinInstnId = New BranchAndFinancialInstitutionIdentification4.FinancialInstitutionIdentification7
    '                'Bug:1144 - Sepa BIC codes verwijderen 
    '                '.DbtrAgt.FinInstnId.BIC = row("BIC") 'BIC code BANK debiteur

    '                .Dbtr = New PartyIdentification32
    '                .Dbtr.Nm = row("name")

    '                .DbtrAcct = New CashAccount16
    '                .DbtrAcct.Id = New AccountIdentification4Choice
    '                .DbtrAcct.Id.IBAN = row("IBAN")

    '                .RmtInf = New RemittanceInformation5
    '                .RmtInf.Ustrd = row("lidnr")
    '            End With

    '            .PmtInf.DrctDbtTxInf.Add(newDebet)
    '            totalAmount += row("amount")
    '        Next

    '        Dim formatTotalAmount As String = totalAmount
    '        If formatTotalAmount.Length > 2 Then
    '            formatTotalAmount = formatTotalAmount.Insert(formatTotalAmount.Length - 2, ".")
    '        End If

    '        .GrpHdr.NbOfTxs = iCounter 'Number of individual transactions contained in the message.
    '        .GrpHdr.CtrlSum = formatTotalAmount 'Total of all individual amounts included in the message

    '        .PmtInf.NbOfTxs = iCounter 'Number of individual transactions contained in the payment information group.
    '        .PmtInf.CtrlSum = formatTotalAmount 'Total of all individual amounts included in the group.

    '    End With

    '    NewSEPA.Save()

    '    Dim SEPAFileName As String = "\SEPANEW_X.xml"
    '    If Not NewSEPA Is Nothing Then
    '        SEPAFileName = SEPAFileName.Replace("X", NewSEPA.Version)
    '    End If

    '    Dim mySerializer As XmlSerializer = New XmlSerializer(GetType(XMLPain))
    '    Dim myWriter As StreamWriter = New StreamWriter(MyDocuments & SEPAFileName)

    '    Dim NS As New XmlSerializerNamespaces
    '    NS.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance")

    '    mySerializer.Serialize(myWriter, cstDoc, NS)
    '    myWriter.Close()

    '    hashtotaal = 0
    '    TransactieCount = 0
    '    Value = ""
    '    totalAmount = 0

    '    'Process.Start("Explorer.exe", MyDocuments & "\SEPANEW.xml")


    'End Sub

    Private Sub WriteLastSepaRun()
        Try
            Dim newDate As New Date(_PeriodeYear, _PeriodeMonth, "01")
            'newDate = newDate.AddMonths(-1)
            Dim LastRun As New Systeeminstellingen("SEPAPERIODE", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            With LastRun
                If .Found = False Then
                    .Bond = 0
                    .Zoeknaam = "SEPAPERIODE"
                    .Omschijving = "Laatste periode SEPA"
                    .Waarde = newDate
                    .Save()
                Else
                    .Waarde = newDate
                    .Save()
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
