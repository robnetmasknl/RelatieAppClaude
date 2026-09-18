Imports System.IO
Imports System.Windows.Forms

Public Class NSKFile
    Partial Class NSK

#Region "Members"
        Private _CodeVereniging As String = String.Empty
        Private _TussenVoegsel As String = String.Empty
        Private _Init As String = String.Empty
        Private _Achternaam As String = String.Empty

        Private _Lidnr As String = String.Empty
        Private _Plaatsing As String = String.Empty
        Private _Krijgsmachtsdeel As String = String.Empty
        Private _Rang As String = String.Empty

        Private _Straat As String = String.Empty
        Private _Huisnr As String = String.Empty
        Private _Huisnrtv As String = String.Empty

        Private _Locatie As String = String.Empty
        Private _LocatieAanduiding As String = String.Empty '= 2 'ww=woonwagen / ab=aan boord

        Private _Postcode As String = String.Empty
        Private _Plaats As String = String.Empty
        Private _Buitenland As String = String.Empty

        Private _PosNegAmount As String = String.Empty
        Private _BedragIngehouden As String = String.Empty
        Private _BedragVergoeding As String = String.Empty

        Private _CodeEinde As String = String.Empty
#End Region
#Region "Properties"
        Public Property CodeVereniging() As String
            Get
                Return _CodeVereniging
            End Get
            Set(ByVal value As String)
                _CodeVereniging = value
            End Set
        End Property
        Public Property TussenVoegsel() As String
            Get
                Return _TussenVoegsel
            End Get
            Set(ByVal value As String)
                value = StrConv(value, VbStrConv.Lowercase)
                _TussenVoegsel = value
            End Set
        End Property
        Public Property Init() As String
            Get
                Return _Init
            End Get
            Set(ByVal value As String)
                Dim iValueLength As Integer = value.Length
                For i = 0 To iValueLength
                    value = value.Insert(i + 1, ".")
                    i += 1
                Next
                If value.Length > 0 And Not value.EndsWith(".") Then
                    value = value & "."
                End If
                _Init = value
            End Set
        End Property
        Public Property Achternaam() As String
            Get
                Return _Achternaam
            End Get
            Set(ByVal value As String)
                value = StrConv(value, VbStrConv.ProperCase)
                _Achternaam = value
            End Set
        End Property
        Public Property Lidnr() As String
            Get
                Return _Lidnr
            End Get
            Set(ByVal value As String)
                _Lidnr = value
            End Set
        End Property
        Public Property Plaatsing() As String
            Get
                Return _Plaatsing
            End Get
            Set(ByVal value As String)
                _Plaatsing = value
            End Set
        End Property
        Public Property Krijgsmachtsdeel() As String
            Get
                Return _Krijgsmachtsdeel
            End Get
            Set(ByVal value As String)
                _Krijgsmachtsdeel = value
            End Set
        End Property
        Public Property Rang() As String
            Get
                Return _Rang
            End Get
            Set(ByVal value As String)
                _Rang = value
            End Set
        End Property
        Public Property Straat() As String
            Get
                Return _Straat
            End Get
            Set(ByVal value As String)
                value = StrConv(value, VbStrConv.ProperCase)
                _Straat = value
            End Set
        End Property
        Public Property Huisnr() As String
            Get
                Return _Huisnr
            End Get
            Set(ByVal value As String)
                If value = "" Then value = 0
                _Huisnr = value
            End Set
        End Property
        Public Property Huisnrtv() As String
            Get
                Return _Huisnrtv
            End Get
            Set(ByVal value As String)
                _Huisnrtv = value
            End Set
        End Property
        Public Property Locatie() As String
            Get
                Return _Locatie
            End Get
            Set(ByVal value As String)
                _Locatie = value
            End Set
        End Property
        Public Property LocatieAanduiding() As String
            Get
                Return _LocatieAanduiding
            End Get
            Set(ByVal value As String)
                _LocatieAanduiding = value
            End Set
        End Property
        Public Property Postcode() As String
            Get
                Return _Postcode
            End Get
            Set(ByVal value As String)
                _Postcode = value
            End Set
        End Property
        Public Property Plaats() As String
            Get
                Return _Plaats
            End Get
            Set(ByVal value As String)
                _Plaats = value
            End Set
        End Property
        Public Property Buitenland() As String
            Get
                Return _Buitenland
            End Get
            Set(ByVal value As String)
                _Buitenland = value
            End Set
        End Property
        Public Property PosNegAmount() As String
            Get
                Return _PosNegAmount
            End Get
            Set(ByVal value As String)
                _PosNegAmount = value
            End Set
        End Property
        Public Property BedragIngehouden() As String
            Get
                Return _BedragIngehouden
            End Get
            Set(ByVal value As String)
                _BedragIngehouden = value
            End Set
        End Property
        Public Property BedragVergoeding() As String
            Get
                Return _BedragVergoeding
            End Get
            Set(ByVal value As String)
                _BedragVergoeding = value
            End Set
        End Property
        Public Property CodeEinde() As String
            Get
                Return _CodeEinde
            End Get
            Set(ByVal value As String)
                _CodeEinde = value
            End Set
        End Property
#End Region
    End Class
#Region "veldlengtes"
    Private iCodeVereniging As Integer = 2
    Private iTussenVoegsel As Integer = 10
    Private iInit As Integer = 6
    Private iAchternaam As Integer = 25

    Private iLidnr As Integer = 9
    Private iPlaatsing As Integer = 4
    Private iKrijgsmachtsdeel As Integer = 1
    Private iRang As Integer = 3

    Private iStraat As Integer = 24
    Private iHuisnr As Integer = 5
    Private iHuisnrtv As Integer = 4

    Private iLocatie As Integer = 35
    Private iLocatieAanduiding As Integer = 2 'ww=woonwagen / ab=aan boord

    Private iPostcode As Integer = 8
    Private iPlaats As Integer = 35
    Private iBuitenland As Integer = 30

    Private iPosNegAmount As Integer = 1
    Private iBedragIngehouden As Integer = 9
    Private iBedragVergoeding As Integer = 5

    Private iCodeEinde As Integer = 2
    'Nr	Rubriek	                    Lengte	Karakter    'vorm	Startpos	Eindpos	Mogelijke waarden
    '1	Code-belangenvereniging	    2		N	1	2	Zie codelijst
    '2	Voorzetsels	                10		AN	3	12	
    '3	Voorletters	                6		AN	13	18	
    '4	Naam werknemer	            25		AN	19	43	
    '5	Werknemernummer 	        9		AN	44	52	Employee-id (7 posities) +  'Nr-arbeidsrelatie (2 posities)
    '6	Elconummer plaatsing	    4		N	53	56	
    '7	Code krijgsmachtsdeel	    1		N	57	57	Zie codelijst
    '8	Code rang	                3		N	58	60	Zie codelijst
    '9	Postadres werknemer	        142			61	203	
    '10	Straatnaam	                24		AN	61	84	
    '11	Huisnummer	                5		N	85	89	
    '12	Toevoeging huisnummer	    4		AN	90	93	
    '13	Omschrijving locatie	    35		AN	94	128	
    '14	Aanduiding ww=woonwagen
    '   / ab=aan boord	            2		AN	129	130	
    '15	Postcode	                8		AN	131	138	
    '16	Woonplaats	                35		AN	139	173	
    '17	(Buiten)land	            30		AN	174	203	
    '18	Teken	                    1		AN	204	204	“+”
    '19	Ingehouden bedrag	        9		N	205	213	
    '20	Bedrag vergoeding	        5		N	214	218	

    'kan het ionderstaande zijn
    'Private iCodeBlokkeringWerknemer As Integer = 3 “B”  of spaties 1)
    'Private iCodeBeeindigingCA As Integer = 3 “CA “ of spaties 2)
    'Private iCodeBeeindigingUDW As Integer = 3 “ A “ of spaties 3)
    '1)	“B” geeft aan dat de militair die maand geblokkeerd is en de delegatie niet uitgevoerd is.
    '2)	“CA” geeft aan dat de werknemer aan zijn administrateur verzocht heeft de delegatie te beëindigen.			   
    '3)	“A” geeft aan dat de militair met ontslag gegaan is en de delegatie automatisch beëindigd is.

#End Region

    'BM: voor testen wordt er niets opgeslagen. 
    'deze op false voor testen zonder op slaan
    Public bSave As Boolean = True 'False

#Region "Process"
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


    Private _NSK_ID As Integer = -1
    Public ReadOnly Property NSK_ID() As Integer
        Get
            If _NSK_ID = -1 Then
                _NSK_ID = da.ExecuteScalar("select Id from Contr_instanties where naam = 'NSK'")
            End If

            Return _NSK_ID
        End Get
    End Property
    Private da As New DataAccess

    Private _NSKMembers As DataTable = Nothing
    Public ReadOnly Property NSKMembers() As DataTable
        Get
            If _NSKMembers Is Nothing Then
                Dim paramlist As New ArrayList
                Dim sAndOr As String = String.Empty
                Dim sql As String = "SELECT lidnr, achternaam, init , tussenvoegsel , status, geboortedatum FROM relaties WHERE InstantieID = @InstantieID ORDER BY lidnr"
                paramlist.Add("@InstantieID")
                paramlist.Add(NSK_ID)

                _NSKMembers = da.ExecuteDataTable(sql, paramlist.ToArray)
                'maak een extra column voor afvinken NSK bestand members
                Dim col As New DataColumn
                col.ColumnName = "Checked"
                col.DefaultValue = "VBM"
                col.DataType = Type.GetType("System.String")
                _NSKMembers.Columns.Add(col)

                'maak een extra column voor nsk bedrag verslag
                Dim colNskAmount As New DataColumn
                colNskAmount.ColumnName = "nskamount"
                colNskAmount.DefaultValue = "-1"
                colNskAmount.DataType = Type.GetType("System.Int64")
                _NSKMembers.Columns.Add(colNskAmount)

                'maak een extra column voor opzij (code A) verslag
                Dim colCodeEinde As New DataColumn
                colCodeEinde.ColumnName = "CodeEinde"
                colCodeEinde.DefaultValue = ""
                colCodeEinde.DataType = Type.GetType("System.String")
                _NSKMembers.Columns.Add(colCodeEinde)

            End If


            'For Each row As DataRow In _NSKMembers.Rows
            '    _TableDictionary.Add(row.Item("lidnr"), New CheckAmount(row.Item("Checked"), row.Item("nskamount")))
            'Next


            Return _NSKMembers
        End Get
    End Property
    Private _NskNoAmount As DataTable = Nothing
    Public ReadOnly Property NskNoAmount() As DataTable
        Get
            If _NskNoAmount Is Nothing Then
                _NskNoAmount = New DataTable
                _NskNoAmount = NSKMembers.Clone
                Dim colchkProcess As New DataColumn
                colchkProcess.ColumnName = "Wijzig"
                colchkProcess.DefaultValue = "1"
                colchkProcess.DataType = Type.GetType("System.Boolean")
                _NskNoAmount.Columns.Add(colchkProcess)
                colchkProcess.SetOrdinal(0)
            End If

            Return _NskNoAmount
        End Get
    End Property
    Private Sub ResetReminder()
        Try
            Dim sql As String = "UPDATE Relaties SET M_NSK = '0'"
            Dim b As Boolean = da.ExecuteScalar(sql)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ResetVoorportaal()
        Try
            If bSave = False Then Exit Sub

            'bugid: 1475.
            'soms zijn er twee regels in het NSK bestand voor 1 persoon, deze komen dan in de voorportaal terecht. door relnr te wijzigen naar een 9 op het eind worden deze verwijderd.
            Dim sqlA As String = "delete h from history h inner join relaties r on h.lidid = r.id  where r.lidnr Like '%9' and r.status=2 and r.id not in (select lidid from history h2 where h2.lidid = r.id And h2.tablename <> 'Relaties')"
            Dim bA As Boolean = da.ExecuteScalar(sqlA)

            Dim sqlB As String = "delete From relaties Where relaties.lidnr Like '%9' and relaties.status=2 and relaties.id not in (Select lidid From history h2 Where h2.lidid = Relaties.Id And h2.tablename <> 'Relaties') "
            Dim bB As Boolean = da.ExecuteScalar(sqlB)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckNSKMembers(ByVal _lidnr As String, ByVal nskamount As Integer, ByVal _CodeEinde As String)
        'bevat alle NSK uit databse en past veld Checked = NSK als deze door nskbestand is verwerkt
        'overige blijven Checked = VBM.
        'Wordt gebruikt voor raportage en leeftijd check. 
        For Each row As DataRow In NSKMembers.Rows
            If row.Item("lidnr") = _lidnr Then
                row.Item("Checked") = "NSK"
                row.Item("nskamount") = nskamount
                row.Item("CodeEinde") = _CodeEinde
                Exit For
            End If
        Next
    End Sub


    Private Sub WriteNotNSKMembers()
        'Filter alle records die door nskbestand zijn behandeld
        'en genereert rapport van de onbehandelden.
        Dim dv As New DataView(NSKMembers)
        dv.RowFilter = "Checked = 'VBM'"
        dv.Sort = "lidnr"

        'rapportage van de onbehandelde leden.
        For Each row As DataRowView In dv
            If row.Item("status").ToString <> "1" Then _
                    sbNotInNSK.Append("lidnr: " & row.Item("lidnr").ToString & " ; naam: " & row.Item("achternaam").ToString & ", " & row.Item("init").ToString & ", " & row.Item("tussenvoegsel").ToString & vbCrLf)
        Next



        dv.RowFilter = "nskamount = 0"
        dv.Sort = "lidnr"
        'rapportage van de behandelde NSKleden zonder bedrag.
        For Each row As DataRowView In dv
            If row.Item("status").ToString <> "1" Then
                'TODO hier zou een process kunnen komen voor de 0 meldingen.
                NskNoAmount.ImportRow(row.Row)
                sbInNSKNoAmount.Append("lidnr: " & row.Item("lidnr").ToString & " ; naam: " & row.Item("achternaam").ToString & ", " & row.Item("init").ToString & ", " & row.Item("tussenvoegsel").ToString & ",nskamount: " & row.Item("nskamount").ToString & vbCrLf)
            End If
        Next

        dv.RowFilter = "CodeEinde = 'A' and nskamount > 0"
        dv.Sort = "lidnr"
        'rapportage van de behandelde NSKleden bet code A (uitdienst)).
        For Each row As DataRowView In dv
            If row.Item("status").ToString <> "1" Then
                NskNoAmount.ImportRow(row.Row)
                sbInNSKNoAmount.Append("lidnr: " & row.Item("lidnr").ToString & " ; naam: " & row.Item("achternaam").ToString & ", " & row.Item("init").ToString & ", " & row.Item("tussenvoegsel").ToString & ",CODE EINDE: " & row.Item("CodeEinde").ToString & vbCrLf)
            End If
        Next

        dv.RowFilter = "nskamount = 0 or Checked = 'VBM'"
        dv.Sort = "lidnr"
        Dim irow As Integer = 0
        'controle van de onbehandelde NSKleden of zonder bedrag.
        'als de lidleeftijd groter is dan opgegeven leeftijd, moet mailing status "m_nsk" worden aangezet 
        For Each row As DataRowView In dv
            RaiseEvent GenerateStatus("Bezig met controleren van leeftijd nsk-leden die niet zijn behandeld in het nsk bestand of geen bedrag hebben. " & irow & " van " & dv.Count)
            If row.Item("status").ToString <> "1" Then
                Dim _relatie As New Relaties(row.Item("lidnr").ToString, Relaties.Via.LIDNR)
                If _relatie.Found And Not row.Item("geboortedatum") Is DBNull.Value Then
                    'Indien militair - of burger actief  > LeeftijdCheck
                    If _relatie.CurrentPeriode.myLidSoort.LeeftijdCheck > 0 Then
                        Dim _Age As Double = DateDiff(DateInterval.Year, row.Item("geboortedatum"), DateTime.Now)
                        If _Age > _relatie.CurrentPeriode.myLidSoort.LeeftijdCheck Then
                            _relatie.m_nsk = True
                            If bSave Then _relatie.SaveByNSK()
                        End If
                    End If
                End If
            End If
            irow += 1
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
    Public sbInNSKNoAmount As Text.StringBuilder
    Public sbNotInNSK As Text.StringBuilder
    Public sbWrongNSKID As Text.StringBuilder
    Public sbWrongLIDNR00 As Text.StringBuilder
    Public sbInHistory As Text.StringBuilder
    Public sbInPortal As Text.StringBuilder
    Public sbRetired As Text.StringBuilder
    Public sbNewAddressNotFound As Text.StringBuilder
    Public sbCodeA As Text.StringBuilder


    Private NSKLine As NSK
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
            sbNotInNSK = New Text.StringBuilder
            sbWrongNSKID = New Text.StringBuilder
            sbWrongLIDNR00 = New Text.StringBuilder
            sbInHistory = New Text.StringBuilder
            sbInPortal = New Text.StringBuilder
            sbInNSKNoAmount = New Text.StringBuilder
            sbRetired = New Text.StringBuilder
            sbNewAddressNotFound = New Text.StringBuilder

            RaiseEvent GenerateStatus("Reset NSK reminders...")
            ResetReminder()

            'BMO: BUGID1475: Remove %9 LEDEN
            RaiseEvent GenerateStatus("Reset %9 in voorportaal...")
            If bSave Then ResetVoorportaal()


            While True
                RaiseEvent GenerateStatus("Bezig met verwerken van regel " & iCounter & " van " & LineCount)
                sLine = oReader.ReadLine

                If sLine Is Nothing Then
                    Exit While
                ElseIf sLine.Length = 1 Then
                    Continue While
                ElseIf sLine.Length < 218 Then
                    RaiseEvent GenerateExp(New Exception("Regel " & iCounter & " komt niet overeen met de te verwachte NSK formaat."))
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

            WriteNotNSKMembers()

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
            NSKLine = New NSK
            With NSKLine
                Dim iposition As Integer = 0
                .CodeVereniging = IndexLine.Substring(iposition, iCodeVereniging).Trim
                iposition += iCodeVereniging
                .TussenVoegsel = IndexLine.Substring(iposition, iTussenVoegsel).Trim
                iposition += iTussenVoegsel
                .Init = IndexLine.Substring(iposition, iInit).Trim
                iposition += iInit
                .Achternaam = IndexLine.Substring(iposition, iAchternaam).Trim
                iposition += iAchternaam
                .Lidnr = IndexLine.Substring(iposition, iLidnr).Trim
                '.Lidnr = .Lidnr.TrimStart("0"c) 'TODO Moeten de leading zero's nu nog worden verwijderd. BM:06/03/2020: verwijderd
                iposition += iLidnr
                .Plaatsing = IndexLine.Substring(iposition, iPlaatsing).Trim
                iposition += iPlaatsing
                .Krijgsmachtsdeel = IndexLine.Substring(iposition, iKrijgsmachtsdeel).Trim
                iposition += iKrijgsmachtsdeel
                .Rang = IndexLine.Substring(iposition, iRang).Trim
                iposition += iRang
                .Straat = IndexLine.Substring(iposition, iStraat).Trim
                iposition += iStraat
                .Huisnr = IndexLine.Substring(iposition, iHuisnr).TrimStart("0"c).Trim
                iposition += iHuisnr
                .Huisnrtv = IndexLine.Substring(iposition, iHuisnrtv).Trim
                iposition += iHuisnrtv
                .Locatie = IndexLine.Substring(iposition, iLocatie).Trim
                iposition += iLocatie
                .LocatieAanduiding = IndexLine.Substring(iposition, iLocatieAanduiding).Trim
                iposition += iLocatieAanduiding
                .Postcode = IndexLine.Substring(iposition, iPostcode).Trim
                iposition += iPostcode
                .Plaats = IndexLine.Substring(iposition, iPlaats).Trim
                iposition += iPlaats
                .Buitenland = IndexLine.Substring(iposition, iBuitenland).Trim
                iposition += iBuitenland
                .PosNegAmount = IndexLine.Substring(iposition, iPosNegAmount).Trim
                iposition += iPosNegAmount
                .BedragIngehouden = IndexLine.Substring(iposition, iBedragIngehouden).Trim
                iposition += iBedragIngehouden
                .BedragVergoeding = IndexLine.Substring(iposition, iBedragVergoeding).Trim
                iposition += iBedragVergoeding

                If IndexLine.Length > iposition Then
                    .CodeEinde = IndexLine.Substring(iposition, IndexLine.Length - iposition).Trim
                Else
                    .CodeEinde = ""
                End If

            End With

            'If NSKLine.Achternaam.ToLower = "boere" Then
            '    Dim bstop As Boolean = True
            'End If


            Dim myRelatie As New Relaties(NSKLine.Lidnr, Relaties.Via.LIDNR)

            'If Decimal.Round(CDec(NSKLine.BedragIngehouden), 0) = 0 Then
            '    ' dan alleen afvinken en de verwerking overslaan
            '    Dim overslaan As String = NSKLine.Lidnr
            '    CheckNSKMembers(myRelatie.lidnr, Decimal.Round(CDec(NSKLine.BedragIngehouden), 0))
            'Else

            If Not myRelatie.Found Then
                'Niets gevonden? Blijf het dan proberen eerst zonder daarna met voorloop nullen tot 9 chr lang.
                Dim tmp0Lidnr As String = NSKLine.Lidnr.TrimStart("0"c)
                Do Until tmp0Lidnr.Length = 10
                    myRelatie = New Relaties(tmp0Lidnr, Relaties.Via.LIDNR)
                    If myRelatie.Found Then
                        Exit Do
                    End If
                    tmp0Lidnr = "0" & tmp0Lidnr
                Loop
            End If

            Dim i As Int16 = 0
            Do While myRelatie.Found = False AndAlso i < 10
                ' bmo:03-06-2020; bugid 1475
                ' Probeer het dan nog eens maar dan eindigend met een ander cijfer dan huidige 
                ' behalve als het ingehouden bedrag 0 is
                ' indien gevonden de updaten naar het nieuwe lidnr en het lid op NSK zetten en de contributie bijwerken.

                Dim tmpLidnr As String = NSKLine.Lidnr.Remove(NSKLine.Lidnr.Length - 1, 1)
                tmpLidnr = tmpLidnr & i
                myRelatie = New Relaties(tmpLidnr, Relaties.Via.LIDNR)
                If myRelatie.Found And myRelatie.Status = 0 Then
                    ' dan controleren of de orginele lidnr wel in de nskmembers staat en die verwijderen
                    ' dan lidnr aanpassen naar het NSK lidnummer, en in de tijdelijke nsk tabel aanpassen
                    myRelatie.lidnr = tmpLidnr
                    CheckNSKMembers(myRelatie.lidnr, Decimal.Round(CDec(NSKLine.BedragIngehouden), 0), NSKLine.CodeEinde)
                    If Decimal.Round(CDec(NSKLine.BedragIngehouden), 0) > 0 Then
                        ProcessLine(myRelatie, bSave)
                        sbWrongLIDNR00.Append("lidnr NIET gevonden:" & NSKLine.Lidnr & " ; lid wel gevonden en aangepast:" & tmpLidnr & " ; naam:" & myRelatie.achternaam & vbCrLf)
                    End If
                    Exit Sub
                End If
                i = i + 1
            Loop

            If myRelatie.Found Then
                Select Case myRelatie.Status
                    Case 0
                        CheckNSKMembers(myRelatie.lidnr, Decimal.Round(CDec(NSKLine.BedragIngehouden), 0), NSKLine.CodeEinde)
                        If Decimal.Round(CDec(NSKLine.BedragIngehouden), 0) > 0 Then
                            ' dan alleen afvinken en de verwerking overslaan
                            ProcessLine(myRelatie, bSave)
                        End If
                    Case 1
                        'gevonden in history dan alleen een melding wegschrijven - 
                        'niet meer alleen melden, dus ook gewoon behandelen maar nog wel met melding in verslag
                        CheckNSKMembers(myRelatie.lidnr, Decimal.Round(CDec(NSKLine.BedragIngehouden), 0), NSKLine.CodeEinde)
                        'behalve als het ingehouden bedrag 0 is dan weer niet
                        If Decimal.Round(CDec(NSKLine.BedragIngehouden), 0) > 0 Then
                            sbInHistory.Append("gevonden in HISTORY: lidnr: " & myRelatie.lidnr & " ; naam: " & myRelatie.achternaam & vbCrLf)
                            ProcessLine(myRelatie, bSave)
                        End If
                    Case 2
                        'gevonden in voorportaal dan alleen een melding wegschrijven
                        CheckNSKMembers(myRelatie.lidnr, Decimal.Round(CDec(NSKLine.BedragIngehouden), 0), NSKLine.CodeEinde)
                        sbInPortal.Append("gevonden in VOORPORTAAL: lidnr: " & myRelatie.lidnr & " ; naam: " & myRelatie.achternaam & vbCrLf)
                End Select

            Else
                'Nieuwe relatie maken , behalve als het een buitenlandse is dan niet.
                If String.IsNullOrEmpty(NSKLine.Buitenland) Then
                    myRelatie.lidnr = NSKLine.Lidnr
                    myRelatie.init = NSKLine.Init
                    myRelatie.tussenvoegsel = NSKLine.TussenVoegsel
                    myRelatie.achternaam = NSKLine.Achternaam
                    myRelatie.adres = NSKLine.Straat
                    myRelatie.postcode = NSKLine.Postcode
                    myRelatie.huisnr = NSKLine.Huisnr
                    myRelatie.huisnrtv = NSKLine.Huisnrtv
                    myRelatie.plaats = NSKLine.Plaats
                    myRelatie.indatum = Today
                    myRelatie.Status = 2
                    If bSave Then myRelatie.SaveByNSK()
                    sbNewRelations.Append("lidnr: " & myRelatie.lidnr & " ; bedrag: " & NSKLine.BedragIngehouden & " ; naam: " & myRelatie.FullName & " ; adres: " & myRelatie.FullAddress & vbCrLf)
                    'btid:520 Bij nieuwe relatie niet meer verder gaan met de verwerking maar naar het volgende record.
                    'ProcessLine(myRelatie, bSave)
                Else
                    sbNewAbroad.Append("BUITENLANDSE RELATIE: " & IndexLine & vbCrLf)
                End If
                iNew += 1
                RaiseEvent GenerateNewCounter(iNew)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Het verwerken van de ingelezen gegevens.
    ''' De leading zero's worden nu nog verwijderd.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessLine(ByVal myRelatie As Relaties, Optional ByVal bSave As Boolean = True)
        Try

            Dim myContributie As New Contributies(myRelatie.Id, Contributies.Via.RELATIEID, Me.ContributieJaar)
            If myContributie.Found = False Then myContributie.lidid = myRelatie.Id
            myContributie.jaar = Me.ContributieJaar
            Dim myHistory As New History
            Dim NSKAmount As Decimal = Decimal.Round(CDec(NSKLine.BedragIngehouden), 0)
            Dim bContributieChanged As Boolean = False

            'Controleer het verwachte bedrag tegen het opgegeven bedrag.
            Dim ContributieAmount As Decimal = Decimal.Round(CDec(myContributie.ContributieAmount(ContributieMaand)), 0)
            Dim DiscountAmount As Decimal = Decimal.Round(CDec(myContributie.Contributie_mDiscount), 0)

            If ContributieAmount = NSKAmount Then
                'Controleer het verwachte bedrag tegen het opgegeven bedrag.
                'ok, ga dan verder
            ElseIf (ContributieAmount - DiscountAmount) = NSKAmount Then
                'Controleer het verwachte bedrag - kortingbedrag tegen het opgegeven bedrag.
                'ok, ga dan verder
            Else
                'als geen van bovenstaande klopt dan ook een melding wegschrijven en ga ook verder
                If myRelatie.Age = 0 Or myRelatie.Age > 23 Then
                    sbAberrations.Append("lidnr: " & myRelatie.lidnr & " ;verwachtte bedrag: " & ContributieAmount & " ;NSK bedrag: " & NSKAmount & vbCrLf)
                End If
            End If

            ''Controleer rekening nummer
            'If String.IsNullOrEmpty(relatie.bankrek) Then
            '    sbAccountnumbers.Append("lidnr: " & relatie.lidnr & " ;rekeningnummer ontbreekt. " & vbCrLf)
            'End If

            Select Case Me.ContributieMaand
                Case 1
                    '' bug 544: nsk telt het bedrag niet op, maar overschrijft.
                    'Dim CurrentAmount As Decimal = myContributie.GetPaymentOfMonth(Me.ContributieMaand)
                    'bContributieChanged = CurrentAmount <> NSKAmount
                    'myHistory.Veld = CType(1, eMaand)
                    'myHistory.WaardeOud = CurrentAmount
                    'myContributie.AddPayment(NSKAmount, CType(1, eMaand))
                    'myHistory.WaardeNieuw = myContributie.GetPaymentOfMonth(Me.ContributieMaand)

                    bContributieChanged = myContributie.jan <> NSKAmount
                    myContributie.jan = NSKAmount
                    myHistory.Veld = "jan"
                    myHistory.WaardeOud = myContributie.jan
                Case 2
                    bContributieChanged = myContributie.feb <> NSKAmount
                    myContributie.feb = NSKAmount
                    myHistory.Veld = "feb"
                    myHistory.WaardeOud = myContributie.feb
                Case 3
                    bContributieChanged = myContributie.mar <> NSKAmount
                    myContributie.mar = NSKAmount
                    myHistory.Veld = "mar"
                    myHistory.WaardeOud = myContributie.mar
                Case 4
                    bContributieChanged = myContributie.apr <> NSKAmount
                    myContributie.apr = NSKAmount
                    myHistory.Veld = "apr"
                    myHistory.WaardeOud = myContributie.apr
                Case 5
                    bContributieChanged = myContributie.mei <> NSKAmount
                    myContributie.mei = NSKAmount
                    myHistory.Veld = "mei"
                    myHistory.WaardeOud = myContributie.mei
                Case 6
                    bContributieChanged = myContributie.jun <> NSKAmount
                    myContributie.jun = NSKAmount
                    myHistory.Veld = "jun"
                    myHistory.WaardeOud = myContributie.jun
                Case 7
                    bContributieChanged = myContributie.jul <> NSKAmount
                    myContributie.jul = NSKAmount
                    myHistory.Veld = "jul"
                    myHistory.WaardeOud = myContributie.jul
                Case 8
                    bContributieChanged = myContributie.aug <> NSKAmount
                    myContributie.aug = NSKAmount
                    myHistory.Veld = "aug"
                    myHistory.WaardeOud = myContributie.aug
                Case 9
                    bContributieChanged = myContributie.sep <> NSKAmount
                    myContributie.sep = NSKAmount
                    myHistory.Veld = "sep"
                    myHistory.WaardeOud = myContributie.sep
                Case 10
                    bContributieChanged = myContributie.okt <> NSKAmount
                    myContributie.okt = NSKAmount
                    myHistory.Veld = "okt"
                    myHistory.WaardeOud = myContributie.okt
                Case 11
                    bContributieChanged = myContributie.nov <> NSKAmount
                    myContributie.nov = NSKAmount
                    myHistory.Veld = "nov"
                    myHistory.WaardeOud = myContributie.nov
                Case 12
                    bContributieChanged = myContributie.dec <> NSKAmount
                    myContributie.dec = NSKAmount
                    myHistory.Veld = "dec"
                    myHistory.WaardeOud = myContributie.dec
            End Select

            If bSave Then
                If bContributieChanged Then myContributie.Save()
            End If


            Dim RelChanged As Boolean = False
            'controle adres indien:
            'NSK postcode huisnummer <> aan de vastgelegde postcode huisnummer 
            'Het geen NAPO adres binnenland is (adresregel positie 61 bevat het woord NAPO) 
            'Het geen NAPO adres buitenland is (adresregel positie 94 bevat het woord NAPO) 
            'De postcode in het postcode bestand voorkomt. (Anders op de uitzonderinglijst printen) 
            '       tenzij postcode leeg is (=buitenland), dan verwerken.
            'Het niet al een keer is aangepast in de laatste 6 mnd
            Dim tmpPostcode As String = myRelatie.postcode
            tmpPostcode = tmpPostcode.Replace(" ", vbNullString)
            Dim vmbPcHsCheck As String = tmpPostcode & myRelatie.huisnr.Trim & myRelatie.huisnrtv.Trim
            Dim nskPcHsCheck As String = NSKLine.Postcode & NSKLine.Huisnr.Trim & NSKLine.Huisnrtv.Trim
            If Not String.IsNullOrEmpty(NSKLine.Postcode.Trim) Then 'Dan gaat het om een buitenlands adres
                If vmbPcHsCheck <> nskPcHsCheck Then
                    With NSKLine
                        If .Straat.Trim = "NAPO" Or .Locatie.Trim = "NAPO" Then
                            'dan niets doen
                        ElseIf RecentlyChanged(myRelatie.Id) Then
                            'ook niets doen, dan is het al(waarschijnklijk handmatig)onlangs aangepast.
                        Else
                            Try
                                Dim pccheck As New PostCode(.Postcode.Trim, .Huisnr.Trim)
                                If Not String.IsNullOrEmpty(pccheck.Straat) Then
                                    Dim AddressHystory As New History
                                    With AddressHystory
                                        .LidId = myRelatie.Id
                                        .TableName = "Relaties"
                                        .Veld = "straat/huisnr"
                                        .WaardeOud = myRelatie.adres & "/" & myRelatie.huisnr & "/" & myRelatie.huisnrtv
                                        .WaardeNieuw = pccheck.Straat & pccheck.HuisNr
                                        .MutDate = Now
                                        .MutDoor = "NSK"
                                        If bSave Then .Save()
                                    End With
                                    AddressHystory = New History
                                    With AddressHystory
                                        .LidId = myRelatie.Id
                                        .TableName = "Relaties"
                                        .Veld = "postcode/plaats"
                                        .WaardeOud = myRelatie.postcode & "/" & myRelatie.plaats
                                        .WaardeNieuw = pccheck.Postcode & "/" & pccheck.Plaats
                                        .MutDate = Now
                                        .MutDoor = "NSK"
                                        If bSave Then .Save()
                                    End With

                                    myRelatie.adres = pccheck.Straat
                                    myRelatie.postcode = pccheck.Postcode.Substring(0, 4) & " " & pccheck.Postcode.Substring(4, 2)
                                    myRelatie.huisnr = .Huisnr
                                    myRelatie.huisnrtv = .Huisnrtv
                                    myRelatie.plaats = pccheck.Plaats

                                    AddressHystory = New History
                                    With AddressHystory
                                        .LidId = myRelatie.Id
                                        .TableName = "Relaties"
                                        .Veld = "land"
                                        .WaardeOud = myRelatie.land
                                        .WaardeNieuw = ""
                                        .MutDate = Now
                                        .MutDoor = "NSK"
                                        If bSave Then .Save()
                                    End With
                                    myRelatie.land = ""
                                    RelChanged = True
                                Else
                                    'als postcode niet gevonden is in postcode tabel
                                    'dan notitie in logfile
                                    'maar hier komt die niet omdat de postcode object een fout geeft als die niet wordt gevonden.
                                    sbNewAddressNotFound.Append("lidnr: " & myRelatie.lidnr & " ;postcode/huisnr niet gevonden: " & NSKLine.Straat.Trim & "/" & NSKLine.Huisnr.Trim & "/" & NSKLine.Postcode.Trim & "/" & vbCrLf)

                                End If
                            Catch ex As Exception
                                'als postcode niet gevonden is in postcode tabel
                                'dan notitie in logfile
                                sbNewAddressNotFound.Append("lidnr: " & myRelatie.lidnr & " ;postcode/huisnr niet gevonden: " & NSKLine.Straat.Trim & "/" & NSKLine.Huisnr.Trim & "/" & NSKLine.Postcode.Trim & "/" & vbCrLf)
                            End Try

                        End If
                    End With
                End If
            End If

            'Controle en update instantie
            If myRelatie.Instantieid <> NSK_ID Then
                sbWrongNSKID.Append("lidnr: " & myRelatie.lidnr & " ;afwijkende Instantie: " & myRelatie.Instantieid & vbCrLf)
                '    Dim InstantieHystorie As New History
                '    With InstantieHystorie
                '        .LidId = myRelatie.Id
                '        .TableName = "Relaties"
                '        .Veld = "Instantieid"
                '        .WaardeOud = myRelatie.Instantieid
                '        .WaardeNieuw = "2"
                '        .MutDate = Now
                '        .MutDoor = "NSK"
                '        If bSave Then .Save()
                '    End With
                '    myRelatie.Instantieid = NSK_ID
                '    RelChanged = True
            End If
            'Controle en update Krijgsmachtsdeel
            If myRelatie.kmond <> NSKLine.Krijgsmachtsdeel Then
                Dim kmHystorie As New History
                With kmHystorie
                    .LidId = myRelatie.Id
                    .TableName = "Relaties"
                    .Veld = "kmond"
                    .WaardeOud = myRelatie.kmond
                    .WaardeNieuw = NSKLine.Krijgsmachtsdeel
                    .MutDate = Now
                    .MutDoor = "NSK"
                    If bSave Then .Save()
                End With
                myRelatie.kmond = NSKLine.Krijgsmachtsdeel
                RelChanged = True
            End If
            'Controle en update rang
            If myRelatie.rang <> NSKLine.Rang.TrimStart("0"c) Then
                Dim RangHystorie As New History
                With RangHystorie
                    .LidId = myRelatie.Id
                    .TableName = "Relaties"
                    .Veld = "rang"
                    .WaardeOud = myRelatie.rang
                    .WaardeNieuw = NSKLine.Rang.TrimStart("0"c)
                    .MutDate = Now
                    .MutDoor = "NSK"
                    If bSave Then .Save()
                End With
                myRelatie.rang = NSKLine.Rang.TrimStart("0"c)
                RelChanged = True
            End If

            ''Controleer of het nummer al voorkomt in tabel plaatsing, zoniet toevoegen.
            'Dim plaatsing As plaatsingen = New plaatsingen(NSKLine.Plaatsing, plaatsingen.Via.BYCODE)
            'If Not plaatsing.Found Then
            '    ''dan nog een x proberen zonder 0
            '    'plaatsing = New plaatsingen(NSKLine.Plaatsing.TrimStart("0"c), plaatsingen.Via.BYCODE)
            '    'If Not plaatsing.Found Then
            '    '    plaatsing.plaatsing = "Toegevoegd via NSK "
            '    'End If
            '    plaatsing.plaatsing = "Toegevoegd via NSK "
            '    plaatsing.code = NSKLine.Plaatsing
            '    plaatsing.Save()
            'End If

            ''Controle en update Plaatsing
            'If myRelatie.plaatsing <> plaatsing.P_Id Then
            '    Dim plaatsingHystorie As New History
            '    With plaatsingHystorie
            '        .LidId = myRelatie.Id
            '        .TableName = "Relaties"
            '        .Veld = "plaatsing"
            '        .WaardeOud = myRelatie.plaatsing
            '        .WaardeNieuw = plaatsing.P_Id
            '        .MutDate = Now
            '        .MutDoor = "NSK"
            '        If bSave Then .Save()
            '    End With

            '    myRelatie.plaatsing = plaatsing.P_Id
            '    myRelatie.BOM = False
            '    RelChanged = True
            'End If

            'Als 1 van de bovenstaande is gewijzigd dan relatie updaten.
            If RelChanged = True Then
                If bSave Then myRelatie.SaveByNSK()
            End If

            If bContributieChanged Then
                myHistory.LidId = myRelatie.Id
                myHistory.TableName = "Contributies"
                myHistory.WaardeNieuw = NSKAmount
                myHistory.MutDate = Now
                myHistory.MutDoor = "NSK"
                If bSave Then myHistory.Save()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RecentlyChanged(ByVal lidId As Integer) As Boolean
        Try
            Dim result As Boolean = False
            Dim ohelper As New Helper
            Dim sql As String = "SELECT * FROM history where LidId = @LidId  AND TableName = 'Relaties' AND Veld like 'postcode%' ORDER BY mutdate"
            Dim param() As Object = {"@LidId", lidId}
            Dim _History As New History
            Dim _Historylist As New List(Of History)

            _Historylist = ohelper.MapDataTableToList(Of History)(_History.GetList(sql, param))

            Dim imaxmonths As Integer = 6
            Dim idiffmonths As Integer = -1

            For Each his In _Historylist
                idiffmonths = DateDiff(DateInterval.Month, his.MutDate, Today)
                If idiffmonths <imaxmonths Then Return True
            Next

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Private Sub btnPostcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostcode.Click
    '    Try
    '        Dim pctext As String = tbPostCode.Text
    '        pctext = pctext.Replace(" ", "")
    '        Dim huisnrtext As String = tbHuisNr.Text

    '        Dim pc As New PostCode(pctext, huisnrtext)
    '        MyRelatie.adres = pc.Straat
    '        MyRelatie.plaats = pc.Plaats

    '        tbAdres.Text = pc.Straat
    '        tbPlaats.Text = pc.Plaats

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Private _MyDocuments As String = ""
    'Public ReadOnly Property MyDocuments() As String
    '    Get
    '        If String.IsNullOrEmpty(_MyDocuments) Then
    '            _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    '        End If
    '        Return _MyDocuments
    '    End Get
    'End Property
#End Region
End Class
