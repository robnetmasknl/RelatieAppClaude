Imports System.IO

Public Class ANPVFile
    Public Event GenerateComplete(ByVal ImageCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)
    Public Event GenerateNewCounter(ByVal iCounter As Integer)
    Public Event GenerateFaultCounter(ByVal iCounter As Integer)

    Public sbNewRelations As Text.StringBuilder
    Public sbAberrations As Text.StringBuilder
    Public sbErrors As Text.StringBuilder
    Public sbInHistory As Text.StringBuilder
    Public sbInPortal As Text.StringBuilder
    Public sbInCiNoAmount As Text.StringBuilder


    Public LineCount As Integer = 0
    Private iNew As Integer = 0

    Private _dtExcel As DataTable
    Public Property dtExcel() As DataTable
        Get
            Return _dtExcel
        End Get
        Set(ByVal value As DataTable)
            _dtExcel = value
        End Set
    End Property

    Private _ContributieCol As String
    Public Property ContributieCol() As String
        Get
            Return _ContributieCol
        End Get
        Set(ByVal value As String)
            _ContributieCol = value
        End Set
    End Property
    Private _ContributieMaand As Integer
    Public Property ContributieMaand() As Integer
        Get
            Return _ContributieMaand
        End Get
        Set(ByVal value As Integer)
            _ContributieMaand = value
        End Set
    End Property
    Private _ContributieJaar As Integer
    Public Property ContributieJaar() As Integer
        Get
            Return _ContributieJaar
        End Get
        Set(ByVal value As Integer)
            _ContributieJaar = value
        End Set
    End Property

    Private _TotalAmount As Decimal
    Public Property TotalAmount() As Decimal
        Get
            Return _TotalAmount
        End Get
        Set(ByVal value As Decimal)
            _TotalAmount = value
        End Set
    End Property

    Private _ProcessedAmount As Decimal
    Public Property ProcessedAmount() As Decimal
        Get
            Return _ProcessedAmount
        End Get
        Set(ByVal value As Decimal)
            _ProcessedAmount = value
        End Set
    End Property

    Private _MissedAmount As Decimal
    Public Property MissedAmount() As Decimal
        Get
            Return _MissedAmount
        End Get
        Set(ByVal value As Decimal)
            _MissedAmount = value
        End Set
    End Property
    Private ReadOnly da As New DataAccess

    Private _CIMembers As DataTable = Nothing
    Public ReadOnly Property CIMembers() As DataTable
        Get
            If _CIMembers Is Nothing Then
                Dim paramlist As New ArrayList
                Dim sAndOr As String = String.Empty
                Dim sql As String = "SELECT lidnr, achternaam, init , tussenvoegsel , status, geboortedatum FROM relaties WHERE InstantieID = @InstantieID ORDER BY lidnr"
                paramlist.Add("@InstantieID")
                paramlist.Add(2)

                _CIMembers = da.ExecuteDataTable(sql, paramlist.ToArray)
                'maak een extra column voor afvinken Centrale Inning bestand members
                Dim col As New DataColumn
                col.ColumnName = "Checked"
                col.DefaultValue = "ANPV"
                col.DataType = Type.GetType("System.String")
                _CIMembers.Columns.Add(col)

                'maak een extra column voor ci bedrag verslag
                Dim colNskAmount As New DataColumn
                colNskAmount.ColumnName = "ciamount"
                colNskAmount.DefaultValue = "-1"
                colNskAmount.DataType = Type.GetType("System.Int64")
                _CIMembers.Columns.Add(colNskAmount)

            End If


            Return _CIMembers
        End Get
    End Property
    Private _CiNoAmount As DataTable = Nothing
    Public ReadOnly Property CiNoAmount() As DataTable
        Get
            If _CiNoAmount Is Nothing Then
                _CiNoAmount = New DataTable
                _CiNoAmount = CIMembers.Clone
                Dim colchkProcess As New DataColumn
                colchkProcess.ColumnName = "Wijzig"
                colchkProcess.DefaultValue = "1"
                colchkProcess.DataType = Type.GetType("System.Boolean")
                _CiNoAmount.Columns.Add(colchkProcess)
                colchkProcess.SetOrdinal(0)
            End If

            Return _CiNoAmount
        End Get
    End Property

    Private Sub CheckCiMembers(ByVal _lidnr As String, ByVal ciamount As Integer)
        'bevat alle Centrale Innings uit database en past veld Checked = ANPV als deze door bestand is verwerkt
        'overige blijven Checked = ANPV.
        'Wordt gebruikt voor raportage en leeftijd check. 
        For Each row As DataRow In CIMembers.Rows
            If row.Item("lidnr") = _lidnr Then
                row.Item("Checked") = "CI"
                row.Item("ciamount") = ciamount
                Exit For
            End If
        Next
    End Sub


    Private Sub WriteNotCiMembers()
        'Filter alle records die door nskbestand zijn behandeld
        'en genereert rapport van de onbehandelden.
        Dim dv As New DataView(CIMembers)
        dv.RowFilter = "Checked = 'ANPV'"
        dv.Sort = "lidnr"

        'rapportage van de onbehandelde leden.
        For Each row As DataRowView In dv
            If row.Item("status").ToString <> "1" Then _
                    sbInCiNoAmount.Append("lidnr: " & row.Item("lidnr").ToString & " ; naam: " & row.Item("achternaam").ToString & ", " & row.Item("init").ToString & ", " & row.Item("tussenvoegsel").ToString & vbCrLf)
        Next

        dv.RowFilter = "ciamount = 0"
        dv.Sort = "lidnr"
        'rapportage van de behandelde ci leden zonder bedrag.
        For Each row As DataRowView In dv
            If row.Item("status").ToString <> "1" Then
                CiNoAmount.ImportRow(row.Row)
                sbInCiNoAmount.Append("lidnr: " & row.Item("lidnr").ToString & " ; naam: " & row.Item("achternaam").ToString & ", " & row.Item("init").ToString & ", " & row.Item("tussenvoegsel").ToString & ",zonder bedrag in NP lijst: " & row.Item("ciamount").ToString & vbCrLf)
            End If
        Next
    End Sub


    Public Sub Process()
        Try
            'zet op false voor testen, wijzigingen worden dan niet opgeslagen
            Dim bSave As Boolean = True

            'validate nodige benodigde gegevens
            If dtExcel Is Nothing Then RaiseEvent GenerateExp(New Exception("Er is geen datatable."))
            If dtExcel.Rows.Count = 0 Then RaiseEvent GenerateExp(New Exception("Er is geen data gevonden."))

            RaiseEvent GenerateStatus("Beginnen...")

            Dim iCounter As Int64 = 0
            Dim iFaultCounter As Int64 = 0
            Dim sLine As String = ""
            LineCount = dtExcel.Rows.Count
            TotalAmount = 0
            ProcessedAmount = 0

            sbNewRelations = New Text.StringBuilder
            sbAberrations = New Text.StringBuilder
            sbErrors = New Text.StringBuilder
            sbInHistory = New Text.StringBuilder
            sbInPortal = New Text.StringBuilder
            sbInCiNoAmount = New Text.StringBuilder

            Dim bContributieChanged As Boolean = False
            Dim myHistory As New History
            Dim CurrentRelation As ANPVRelatie

            For Each row As DataRow In dtExcel.Rows
                Try
                    RaiseEvent GenerateStatus("Bezig met verwerken van regel " & iCounter & " van " & LineCount)

                    bContributieChanged = False
                    myHistory = New History

                    'is het niet beter om eerst te bepalen of er een bedrag valt te verwerken en dan pas de relatie in gaan?
                    'niets dan overslaan, 
                    'Bug ID: 1531 niet meer overslaan ivm verwerken uitdienst
                    'nu een boolean zetten en alleen bedragen verwerken indien true
                    Dim bAmountProcess As Boolean = True
                    If IsDBNull(row(ContributieCol)) Then
                        bAmountProcess = False
                        'Continue For
                    End If

                    Dim amountCol As Decimal = 0
                    If bAmountProcess = True Then
                        amountCol = row(ContributieCol)
                        If amountCol = 0 Then
                            bAmountProcess = False
                            'Continue For
                        End If
                    End If


                    amountCol = Math.Abs(amountCol) * 100
                    Dim amount As Integer = amountCol

                    CurrentRelation = New ANPVRelatie(row("Persoonsnr"), row("Gebdat"))
                    If CurrentRelation.Found Then
                        'controleer geb. dd is al gedaan met ophalen
                        'controleer de status voor verslag, wel verwerken
                        If CurrentRelation.Status = 1 Then
                            sbInHistory.Append("lidnr: " & CurrentRelation.lidnr & " ;pernr: " & row("Persoonsnr") & " ;naam: " & CurrentRelation.FullName & vbCrLf)
                        End If
                        If CurrentRelation.Status = 2 Then
                            sbInPortal.Append("lidnr: " & CurrentRelation.lidnr & " ;pernr: " & row("Persoonsnr") & " ;naam: " & CurrentRelation.FullName & vbCrLf)
                        End If

                        CheckCiMembers(CurrentRelation.lidnr, Decimal.Round(CDec(amount), 0))


                        Dim EndDate As Date = Nothing
                        If Not IsDBNull(row("Uitdienst dat")) Then
                            If DateTime.TryParse(row("Uitdienst dat"), EndDate) Then
                                'np bestand heeft een Uitdienst datum, vergelijk dit met de ANPV data en maak verslag.
                                'bgid: 1454 CurrentRelation.eindedatum vervangen door veld zilver
                                If String.IsNullOrEmpty(CurrentRelation.zilver) Then
                                    sbInHistory.Append("lidnr: " & CurrentRelation.lidnr & " ;pernr: " & row("Persoonsnr") & " ;naam: " & CurrentRelation.FullName & " ;Geen einddatum in ANPV " & " ;NP einddatum: " & EndDate & vbCrLf)
                                ElseIf CurrentRelation.zilver <> EndDate Then
                                    'gooit eerst de vorige regel van history check weg om dubbele te voorkomen
                                    sbInHistory.Replace("lidnr: " & CurrentRelation.lidnr & " ;pernr: " & row("Persoonsnr") & " ;naam: " & CurrentRelation.FullName & vbCrLf, "")
                                    sbInHistory.Append("lidnr: " & CurrentRelation.lidnr & " ;pernr: " & row("Persoonsnr") & " ;naam: " & CurrentRelation.FullName & " ;afwijkende einddatum: " & CurrentRelation.zilver & " ;NP einddatum: " & EndDate & vbCrLf)
                                End If
                            End If
                        End If

                        If bAmountProcess = True Then

                            Dim myContributie As New Contributies(CurrentRelation.Id, Contributies.Via.RELATIEID, Me.ContributieJaar)
                            If myContributie.Found = False Then myContributie.lidid = CurrentRelation.Id

                            Select Case Me.ContributieMaand
                                Case 1
                                    bContributieChanged = myContributie.jan <> amount
                                    myHistory.Veld = "jan"
                                    myHistory.WaardeOud = myContributie.jan
                                    myContributie.jan = amount
                                Case 2
                                    bContributieChanged = myContributie.feb <> amount
                                    myHistory.Veld = "feb"
                                    myHistory.WaardeOud = myContributie.feb
                                    myContributie.feb = amount
                                Case 3
                                    bContributieChanged = myContributie.mar <> amount
                                    myHistory.Veld = "mar"
                                    myHistory.WaardeOud = myContributie.mar
                                    myContributie.mar = amount
                                Case 4
                                    bContributieChanged = myContributie.apr <> amount
                                    myHistory.Veld = "apr"
                                    myHistory.WaardeOud = myContributie.apr
                                    myContributie.apr = amount
                                Case 5
                                    bContributieChanged = myContributie.mei <> amount
                                    myHistory.Veld = "mei"
                                    myHistory.WaardeOud = myContributie.mei
                                    myContributie.mei = amount
                                Case 6
                                    bContributieChanged = myContributie.jun <> amount
                                    myHistory.Veld = "jun"
                                    myHistory.WaardeOud = myContributie.jun
                                    myContributie.jun = amount
                                Case 7
                                    bContributieChanged = myContributie.jul <> amount
                                    myHistory.Veld = "jul"
                                    myHistory.WaardeOud = myContributie.jul
                                    myContributie.jul = amount
                                Case 8
                                    bContributieChanged = myContributie.aug <> amount
                                    myHistory.Veld = "aug"
                                    myHistory.WaardeOud = myContributie.aug
                                    myContributie.aug = amount
                                Case 9
                                    bContributieChanged = myContributie.sep <> amount
                                    myHistory.Veld = "sep"
                                    myHistory.WaardeOud = myContributie.sep
                                    myContributie.sep = amount
                                Case 10
                                    bContributieChanged = myContributie.okt <> amount
                                    myHistory.Veld = "okt"
                                    myHistory.WaardeOud = myContributie.okt
                                    myContributie.okt = amount
                                Case 11
                                    bContributieChanged = myContributie.nov <> amount
                                    myHistory.Veld = "nov"
                                    myHistory.WaardeOud = myContributie.nov
                                    myContributie.nov = amount
                                Case 12
                                    bContributieChanged = myContributie.dec <> amount
                                    myHistory.Veld = "dec"
                                    myHistory.WaardeOud = myContributie.dec
                                    myContributie.dec = amount
                            End Select


                            TotalAmount = TotalAmount + amount

                            If bContributieChanged Then

                                If myHistory.WaardeOud.ToString > 0 Then
                                    sbAberrations.Append("lidnr: " & CurrentRelation.lidnr & " ;het oude bedrag: " & myHistory.WaardeOud & " ;is overschreven met: " & amount & vbCrLf)
                                End If

                                ProcessedAmount = ProcessedAmount + amount
                                If bSave Then
                                    myContributie.Save()
                                    CurrentRelation.flo_pen = Today
                                    CurrentRelation.Save()

                                End If
                            End If

                        End If
                    Else
                            'dan relatie niet gevonden
                            MissedAmount = MissedAmount + amount
                        sbNewRelations.Append("Persoonsnr: " & row("Persoonsnr") & ", Geb. datum: " & row("Gebdat") & " , niet verwerkt bedrag: " & amount & vbCrLf)
                    End If
                Catch ex As Exception
                    'RaiseEvent GenerateExp(ex) 'stoppen of doorgaan
                    sbErrors.Append("regelnr:" & iCounter)
                    sbErrors.Append("  regeltext:" & sLine & vbCrLf)
                    sbErrors.Append("Error:" & ex.Message & vbCrLf)
                    iFaultCounter += 1
                    RaiseEvent GenerateFaultCounter(iFaultCounter)
                End Try
                iCounter += 1
                RaiseEvent GenerateCounter(iCounter)
            Next

            WriteNotCiMembers()

            RaiseEvent GenerateStatus("Klaar met verwerken van regel " & iCounter & " van " & LineCount)
            RaiseEvent GenerateComplete(iCounter)

        Catch exp As Threading.ThreadAbortException
            RaiseEvent GenerateExp(New Exception("Opdracht afgebroken."))
        Catch ex As Exception
            'Throw ex
            RaiseEvent GenerateExp(ex)
        End Try

    End Sub
End Class
