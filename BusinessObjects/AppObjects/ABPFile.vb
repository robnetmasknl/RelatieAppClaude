Imports System.IO
Public Class ABPFile
    Partial Class ABP
#Region "Members & Properties"
        Private _Code As String
        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property

        Private _Lidnr As String
        Public Property Lidnr() As String
            Get
                Return _Lidnr
            End Get
            Set(ByVal value As String)
                _Lidnr = value
            End Set
        End Property

        Private _Achternaam As String
        Public Property Achternaam() As String
            Get
                Return _Achternaam
            End Get
            Set(ByVal value As String)
                value = StrConv(value, VbStrConv.ProperCase)
                _Achternaam = value
            End Set
        End Property

        Private _Adres As String
        Public Property Adres() As String
            Get
                Return _Adres
            End Get
            Set(ByVal value As String)
                _Adres = value
            End Set
        End Property

        Private _Straat As String
        Public Property Straat() As String
            Get
                Return _Straat
            End Get
            Set(ByVal value As String)
                value = StrConv(value, VbStrConv.ProperCase)
                _Straat = value
            End Set
        End Property

        Private _Huisnr As String
        Public Property Huisnr() As String
            Get
                Return _Huisnr
            End Get
            Set(ByVal value As String)
                If value = "" Then value = 0
                _Huisnr = value
            End Set
        End Property

        Private _Huisnrtv As String
        Public Property Huisnrtv() As String
            Get
                Return _Huisnrtv
            End Get
            Set(ByVal value As String)
                _Huisnrtv = value
            End Set
        End Property

        Private _Postcode As String
        Public Property Postcode() As String
            Get
                Return _Postcode
            End Get
            Set(ByVal value As String)
                _Postcode = value
            End Set
        End Property

        Private _Plaats As String
        Public Property Plaats() As String
            Get
                Return _Plaats
            End Get
            Set(ByVal value As String)
                _Plaats = value
                If value.Length > 7 Then
                    Dim PostcodeTest4 As String = value.Substring(0, 4)
                    Dim PostcodeTestSpatie As String = value.Substring(4, 1)
                    Dim PostCodeTest2 As String = value.Substring(5, 2)

                    Dim bBuitenland As Boolean = False
                    If IsNumeric(PostcodeTest4) Then
                        If PostCodeTest2.Trim.Length = 2 And PostcodeTestSpatie = " " Then
                            ' dan is het zeer waarschijnlijk een nedelands postcode
                            Postcode = PostcodeTest4 & PostcodeTestSpatie & PostCodeTest2
                            _Plaats = value.Replace(Postcode, "").Trim
                            bBuitenland = True
                        End If
                    End If
                    If bBuitenland Then Buitenland = "JA"
                End If
            End Set
        End Property

        Private _BedragIngehouden As String
        Public Property BedragIngehouden() As String
            Get
                Return _BedragIngehouden
            End Get
            Set(ByVal value As String)
                _BedragIngehouden = value
            End Set
        End Property

        Private _Buitenland As String
        Public Property Buitenland() As String
            Get
                Return _Buitenland
            End Get
            Set(ByVal value As String)
                _Buitenland = value
            End Set
        End Property

#End Region


    End Class
#Region "veldlengtes"
    Private iCode As Integer = 2
    Private iLidnr As Integer = 11
    Private iAchternaam As Integer = 24
    Private iAdres As Integer = 40
    'Private iStraat As Integer = 40
    'Private iHuisnr As Integer = 0
    'Private iHuisnrtv As Integer = 0
    'Private iPostcode As Integer = 0
    Private iPlaats As Integer = 40
    Private iBedragIngehouden As Integer = 5

#End Region
    Private _IndexFilePath As String = ""
    Public Property IndexFilePath() As String
        Get
            Return _IndexFilePath
        End Get
        Set(ByVal value As String)
            _IndexFilePath = value
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
    Private da As New DataAccess
    Private _ABP_ID As Integer = -1
    Public ReadOnly Property ABP_ID() As Integer
        Get
            If _ABP_ID = -1 Then
                _ABP_ID = da.ExecuteScalar("select Id from Contr_instanties where naam = 'ABP'")
            End If

            Return _ABP_ID
        End Get
    End Property
    Private _ABPMembers As DataTable = Nothing
    Public ReadOnly Property GetABPMembers() As DataTable
        Get
            If _ABPMembers Is Nothing Then
                Dim dt As DataTable
                Dim paramlist As New ArrayList
                Dim sAndOr As String = String.Empty
                Dim sql As String = "SELECT lidnr, achternaam, init , tussenvoegsel , status, geboortedatum FROM relaties WHERE InstantieID = @InstantieID ORDER BY lidnr"
                paramlist.Add("@InstantieID")
                paramlist.Add(ABP_ID)

                dt = da.ExecuteDataTable(sql, paramlist.ToArray)
                _ABPMembers = dt
                'maak een extra column voor afvinken ABP bestand members
                Dim col As New DataColumn
                col.ColumnName = "Checked"
                col.DefaultValue = "VBM"
                col.DataType = Type.GetType("System.String")
                _ABPMembers.Columns.Add(col)

            End If
            Return _ABPMembers
        End Get
    End Property
    Private Sub CheckABPMembers(ByVal _lidnr As String)

        For Each row As DataRow In GetABPMembers.Rows
            If row.Item("lidnr") = _lidnr Then
                row.Item("Checked") = "ABP"
                Exit For
            End If
        Next
    End Sub
    Private Sub WriteNotABPMembers()
        'Filter alle records die NIET door ABPbestand zijn behandeld
        'en genereer rapport van de onbehandelden.
        Dim dv As New DataView(GetABPMembers)
        dv.RowFilter = "Checked = 'VBM'"

        For Each row As DataRowView In dv
            If row.Item("status").ToString <> "1" Then _
                    sbNotInABP.Append("lidnr: " & row.Item("lidnr").ToString & " ; naam: " & row.Item("achternaam").ToString & ", " & row.Item("init").ToString & ", " & row.Item("tussenvoegsel").ToString & vbCrLf)
        Next

    End Sub

    Public Event GenerateComplete(ByVal ImageCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)
    Public Event GenerateNewCounter(ByVal iCounter As Integer)
    Public Event GenerateFaultCounter(ByVal iCounter As Integer)

    'Public NewRelatieList As New List(Of Relaties)
    Public sbNewRelations As Text.StringBuilder
    Public sbNewAbroad As Text.StringBuilder
    Public sbAberrations As Text.StringBuilder
    Public sbErrors As Text.StringBuilder
    Public sbNotInABP As Text.StringBuilder
    Public sbWrongABPID As Text.StringBuilder
    Public sbWrongLIDNR00 As Text.StringBuilder
    Public sbInHistory As Text.StringBuilder
    Public sbInPortal As Text.StringBuilder

    Private ABPLine As ABP
    Public LineCount As Integer = 0
    Private iNew As Integer = 0

    Public Sub Process()
        Try
            'validate nodige benodigde gegevens
            If String.IsNullOrEmpty(IndexFilePath.Trim) Then RaiseEvent GenerateExp(New Exception("Er is geen file geselecteerd."))
            If Not IO.File.Exists(IndexFilePath) Then RaiseEvent GenerateExp(New Exception("file niet gevonden."))
            If ContributieMaand = 0 Then RaiseEvent GenerateExp(New Exception("Er is nog geen maand opgegeven."))
            If ContributieMaand > 12 Then RaiseEvent GenerateExp(New Exception("Opgegeven maand is ongeldig."))
            If ContributieJaar = 0 Then RaiseEvent GenerateExp(New Exception("Er is nog geen Jaar opgegeven."))
            If ContributieJaar > Now.Year Then RaiseEvent GenerateExp(New Exception("Opgegeven jaar mag niet in de toekomst zijn."))


            RaiseEvent GenerateStatus("Beginnen...")

            Dim iCounter As Int64 = 0
            Dim iFaultCounter As Int64 = 0
            Dim sLine As String = ""
            Dim oReader As New StreamReader(IndexFilePath, System.Text.Encoding.Default)

            sbErrors = New Text.StringBuilder
            sbNewRelations = New Text.StringBuilder
            sbNewAbroad = New Text.StringBuilder
            sbAberrations = New Text.StringBuilder
            sbNotInABP = New Text.StringBuilder
            sbWrongABPID = New Text.StringBuilder
            sbWrongLIDNR00 = New Text.StringBuilder
            sbInHistory = New Text.StringBuilder
            sbInPortal = New Text.StringBuilder

            While True
                RaiseEvent GenerateStatus("Bezig met verwerken van regel " & iCounter & " van " & LineCount)
                sLine = oReader.ReadLine

                If sLine Is Nothing Then
                    Exit While
                ElseIf sLine.Length = 1 Then
                    Continue While
                ElseIf sLine.Length = 68 Then
                    ' dan is het de voorlooprecord
                    Dim jaar As String = sLine.Substring(62, 4)
                    Dim maand As String = sLine.Substring(66, 2).TrimStart("0"c)
                    If jaar <> ContributieJaar Then _
                        RaiseEvent GenerateExp(New Exception("Opgegeven jaar komt niet overeen met de te verwachte ABP datum."))
                    'Continue While
                    If maand <> ContributieMaand Then _
                        RaiseEvent GenerateExp(New Exception("Opgegeven maand komt niet overeen met de te verwachte ABP datum."))
                    Continue While
                ElseIf sLine.Length = 18 Then
                    Continue While ' dan is het de sluitrecord
                ElseIf sLine.Length < 122 Then
                    RaiseEvent GenerateExp(New Exception("Regel " & iCounter & " komt niet overeen met de te verwachte ABP formaat."))

                End If

                Try
                    ReadLine(sLine)
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
            End While
            oReader.Close()

            WriteNotABPMembers()

            RaiseEvent GenerateStatus("Klaar met verwerken van regel " & iCounter & " van " & LineCount)
            RaiseEvent GenerateComplete(iCounter)

        Catch exp As Threading.ThreadAbortException
            RaiseEvent GenerateExp(New Exception("Opdracht afgebroken."))
        Catch ex As Exception
            'Throw ex
            RaiseEvent GenerateExp(ex)
        End Try

    End Sub
    Private Sub ReadLine(ByVal IndexLine As String)
        Try
            'controleer of het 220 of 218 chars heeft voor het lezen van de laatste chars
            ABPLine = New ABP
            With ABPLine
                Dim iposition As Integer = 0
                .Code = IndexLine.Substring(iposition, iCode).Trim
                iposition += iCode
                .Lidnr = IndexLine.Substring(iposition, iLidnr).Trim
                .Lidnr = .Lidnr.TrimStart("0"c) 'TODO Moeten de leading zero's nu nog worden verwijderd.
                iposition += iLidnr
                .Achternaam = IndexLine.Substring(iposition, iAchternaam).Trim
                iposition += iAchternaam
                .Adres = IndexLine.Substring(iposition, iAdres).Trim
                iposition += iAdres
                .Plaats = IndexLine.Substring(iposition, iPlaats).Trim
                iposition += iPlaats
                .BedragIngehouden = IndexLine.Substring(iposition, iBedragIngehouden).Trim
                .BedragIngehouden = .BedragIngehouden.TrimStart("0"c)
                iposition += iBedragIngehouden
            End With

            'BM: voor testen wordt er nog niets opgeslagen. 
            'deze op false voor testen zonder op slaan
            Dim bSave As Boolean = True

            If ABPLine.Code = "00" Or ABPLine.Code = "99" Then
                Exit Sub 'dan gaat het om de header of footer regel
            End If

            If Decimal.Round(CDec(ABPLine.BedragIngehouden), 0) = 0 Then
                ' dan overslaan
                Dim overslaan As String = ABPLine.Lidnr
            Else
                Dim myRelatie As New Relaties(ABPLine.Lidnr, Relaties.Via.LIDNR)

                If Not myRelatie.Found Then
                    'Probeer het dan nog eens maar dan met voorloop nullen tot 9 lang
                    Dim tmp00Lidnr As String = ABPLine.Lidnr.PadLeft(9, "0")
                    myRelatie = New Relaties(tmp00Lidnr, Relaties.Via.LIDNR)
                End If

                If myRelatie.Found And myRelatie.Status = 1 Then
                    'gevonden in history dan alleen een melding wegschrijven
                    sbInHistory.Append("gevonden in HISTORY: lidnr: " & myRelatie.lidnr & " ; naam: " & myRelatie.achternaam & vbCrLf)
                    Exit Sub
                ElseIf myRelatie.Found And myRelatie.Status = 2 Then
                    'gevonden in voorportaal dan alleen een melding wegschrijven
                    sbInPortal.Append("gevonden in VOORPORTAAL: lidnr: " & myRelatie.lidnr & " ; naam: " & myRelatie.achternaam & vbCrLf)
                    Exit Sub
                ElseIf Not myRelatie.Found Or myRelatie.Status <> 0 Then
                    'Probeer het dan nog eens maar dan eindigend met 00 ipv 01
                    'Als het dan wel gevonden wordt alleen een melding wegschrijven
                    If ABPLine.Lidnr.EndsWith("01") Then
                        Dim tmpLidnr As String = ABPLine.Lidnr.Remove(ABPLine.Lidnr.Length - 1, 1)
                        tmpLidnr = tmpLidnr & "0"
                        myRelatie = New Relaties(tmpLidnr, Relaties.Via.LIDNR)
                        If myRelatie.Found And myRelatie.Status = 0 Then
                            sbWrongLIDNR00.Append("lidnr NIET gevonden: " & ABPLine.Lidnr & "; lidnr gevonden: " & myRelatie.lidnr & " ; naam: " & myRelatie.achternaam & vbCrLf)
                            Exit Sub
                        End If
                    End If
                    'Nieuwe relatie maken , behalve als het een buitenlandse is dan gaat automatisch niet.
                    'If String.IsNullOrEmpty(ABPLine.Buitenland) Then
                    '    myRelatie.lidnr = ABPLine.Lidnr
                    '    'myRelatie.init = ABPLine.Init
                    '    ' myRelatie.tussenvoegsel = ABPLine.TussenVoegsel
                    '    myRelatie.achternaam = ABPLine.Achternaam
                    '    myRelatie.adres = ABPLine.Straat
                    '    myRelatie.postcode = ABPLine.Postcode
                    '    myRelatie.huisnr = ABPLine.Huisnr
                    '    myRelatie.huisnrtv = ABPLine.Huisnrtv
                    '    myRelatie.plaats = ABPLine.Plaats
                    '    myRelatie.indatum = Today
                    '    myRelatie.Status = 2
                    '    If bSave Then myRelatie.SaveByNSK("ABP")
                    '    sbNewRelations.Append("lidnr: " & myRelatie.lidnr & " ; naam: " & myRelatie.FullName & " ; adres: " & myRelatie.FullAddress & vbCrLf)

                    '    ProcessLine(myRelatie, bSave)
                    'Else
                    ''Nieuwe relatie alleen melden. er zijn te wijnig gegevens om aan te maken. 
                    sbNewAbroad.Append("NIEUWE RELATIE: " & IndexLine & vbCrLf)
                    'End If
                    iNew += 1
                    RaiseEvent GenerateNewCounter(iNew)
                Else
                    CheckABPMembers(myRelatie.lidnr)
                    ProcessLine(myRelatie, bSave)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessLine(ByVal myRelatie As Relaties, Optional ByVal bSave As Boolean = True)
        Try

            Dim myContributie As New Contributies(myRelatie.Id, Contributies.Via.RELATIEID, Me.ContributieJaar)
            If myContributie.Found = False Then myContributie.lidid = myRelatie.Id
            myContributie.jaar = Me.ContributieJaar
            Dim myHistory As New History
            Dim ABPamount As Decimal = Decimal.Round(CDec(ABPLine.BedragIngehouden), 0)
            Dim bContributieChanged As Boolean = False


            'Controleer het verwachte bedrag tegen het opgegeven bedrag.
            Dim ContributieAmount As Decimal = Decimal.Round(CDec(myContributie.ContributieAmount(ContributieMaand)), 0)
            Dim DiscountAmount As Decimal = Decimal.Round(CDec(myContributie.Contributie_mDiscount), 0)

            If ContributieAmount = ABPamount Then
                'Controleer het verwachte bedrag tegen het opgegeven bedrag.
                'ok, ga dan verder
            ElseIf (ContributieAmount - DiscountAmount) = ABPamount Then
                'Controleer het verwachte bedrag - kortingbedrag tegen het opgegeven bedrag.
                'ok, ga dan verder
            Else
                'als geen van bovenstaande klopt dan ook een melding wegschrijven en ga ook verder
                sbAberrations.Append("lidnr: " & myRelatie.lidnr & " ;verwachtte bedrag: " & ContributieAmount & " ;ABP bedrag: " & ABPamount & vbCrLf)
            End If

            ''Controleer rekening nummer
            'If String.IsNullOrEmpty(relatie.bankrek) Then
            '    sbAccountnumbers.Append("lidnr: " & relatie.lidnr & " ;rekeningnummer ontbreekt. " & vbCrLf)
            'End If

            Select Case Me.ContributieMaand
                Case 1
                    bContributieChanged = myContributie.jan <> ABPamount
                    myContributie.jan = ABPamount
                    myHistory.Veld = "jan"
                    myHistory.WaardeOud = myContributie.jan
                Case 2
                    bContributieChanged = myContributie.feb <> ABPamount
                    myContributie.feb = ABPamount
                    myHistory.Veld = "feb"
                    myHistory.WaardeOud = myContributie.feb
                Case 3
                    bContributieChanged = myContributie.mar <> ABPamount
                    myContributie.mar = ABPamount
                    myHistory.Veld = "mar"
                    myHistory.WaardeOud = myContributie.mar
                Case 4
                    bContributieChanged = myContributie.apr <> ABPamount
                    myContributie.apr = ABPamount
                    myHistory.Veld = "apr"
                    myHistory.WaardeOud = myContributie.apr
                Case 5
                    bContributieChanged = myContributie.mei <> ABPamount
                    myContributie.mei = ABPamount
                    myHistory.Veld = "mei"
                    myHistory.WaardeOud = myContributie.mei
                Case 6
                    bContributieChanged = myContributie.jun <> ABPamount
                    myContributie.jun = ABPamount
                    myHistory.Veld = "jun"
                    myHistory.WaardeOud = myContributie.jun
                Case 7
                    bContributieChanged = myContributie.jul <> ABPamount
                    myContributie.jul = ABPamount
                    myHistory.Veld = "jul"
                    myHistory.WaardeOud = myContributie.jul
                Case 8
                    bContributieChanged = myContributie.aug <> ABPamount
                    myContributie.aug = ABPamount
                    myHistory.Veld = "aug"
                    myHistory.WaardeOud = myContributie.aug
                Case 9
                    bContributieChanged = myContributie.sep <> ABPamount
                    myContributie.sep = ABPamount
                    myHistory.Veld = "sep"
                    myHistory.WaardeOud = myContributie.sep
                Case 10
                    bContributieChanged = myContributie.okt <> ABPamount
                    myContributie.okt = ABPamount
                    myHistory.Veld = "okt"
                    myHistory.WaardeOud = myContributie.okt
                Case 11
                    bContributieChanged = myContributie.nov <> ABPamount
                    myContributie.nov = ABPamount
                    myHistory.Veld = "nov"
                    myHistory.WaardeOud = myContributie.nov
                Case 12
                    bContributieChanged = myContributie.dec <> ABPamount
                    myContributie.dec = ABPamount
                    myHistory.Veld = "dec"
                    myHistory.WaardeOud = myContributie.dec
            End Select

            If bSave Then
                If bContributieChanged Then myContributie.Save()
            End If


            Dim RelChanged As Boolean = False
            'Controle en update instantie
            If myRelatie.Instantieid <> ABP_ID Then
                sbWrongABPID.Append("lidnr: " & myRelatie.lidnr & " ;afwijkende Instantie: " & myRelatie.Instantieid & vbCrLf)
            End If

            ''Als 1 van de bovenstaande is gewijzigd dan relatie updaten.
            'If RelChanged = True Then
            '    If bSave Then myRelatie.SaveByNSK("ABP")
            'End If

            If bContributieChanged Then
                myHistory.LidId = myRelatie.Id
                myHistory.TableName = "Contributies"
                myHistory.WaardeNieuw = ABPamount
                myHistory.MutDate = Now
                myHistory.MutDoor = "ABP"
                If bSave Then myHistory.Save()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
