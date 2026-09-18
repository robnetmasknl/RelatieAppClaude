Imports System.IO
Imports System.Text
Imports BusinessObjects
Imports Word = Microsoft.Office.Interop.Word
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading

Public Class SegmentationReport
    Public DateIn As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Public DateOut As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private da As New DataAccess
    Private Status As Integer = 0


#Region "Events"
    Public Event GenerateComplete(ByVal iCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer, ByVal iCounterTotal As Integer)
    Private _IsTerminating As Boolean = False
    Public Property IsTerminating() As Boolean
        Get
            Return _IsTerminating
        End Get
        Set(ByVal value As Boolean)
            _IsTerminating = value
        End Set
    End Property
#End Region
    Private _LocationPath As String
    Public Property LocationPath() As String
        Get
            If Not _LocationPath.EndsWith("\") Then
                _LocationPath = _LocationPath & "\"
            End If
            Return _LocationPath
        End Get
        Set(ByVal value As String)
            'Als dir nog niet bestaat maak het dan
            Dim di As New IO.DirectoryInfo(value)
            If Not di.Exists Then di.Create()
            _LocationPath = value
        End Set
    End Property
    Private _MyRelatie As Relaties
    Public Property MyRelatie() As Relaties
        Get
            Return _MyRelatie
        End Get
        Set(ByVal value As Relaties)
            _MyRelatie = value
        End Set
    End Property

    Private _LidSoorten As List(Of LidSoort)
    Public ReadOnly Property LidSoorten() As List(Of LidSoort)
        Get
            If _LidSoorten Is Nothing Then
                _LidSoorten = New List(Of LidSoort)
                Dim _LidSoort As New LidSoort
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM LidSoorten"
                '_LidSoorten = ohelper.MapDataTableToList(Of LidSoort)(_LidSoort.GetList(sql))
                _LidSoorten = ohelper.MapDataTableToList(Of LidSoort)(da.ExecuteDataTable(sql))

                Dim EmptyLidSoort As New LidSoort
                EmptyLidSoort.soort = "Z"
                EmptyLidSoort.omschrijving = "Zonder lidsoort"
                _LidSoorten.Add(EmptyLidSoort)
            End If

            Return _LidSoorten
        End Get
    End Property

    Private _KMSoorten As DataTable
    Public ReadOnly Property KMSoorten() As DataTable
        Get
            If _KMSoorten Is Nothing Then
                Dim sql As String = "SELECT * FROM kmonderdelen"
                Dim da As New DataAccess
                _KMSoorten = da.ExecuteDataTable(sql)
            End If

            Return _KMSoorten
        End Get
    End Property

    Private _opzeggingen As DataTable
    Public ReadOnly Property Opzeggingen() As DataTable
        Get
            If _opzeggingen Is Nothing Then
                Dim sql As String = "SELECT * FROM opzeggingen"
                Dim da As New DataAccess
                _opzeggingen = da.ExecuteDataTable(sql)
            End If

            Return _opzeggingen
        End Get
    End Property

    Private _dvLidSoort As DataView
    Public ReadOnly Property dvLidSoort() As DataView
        Get
            If _dvLidSoort Is Nothing Then
                FillDataviews()
            End If
            Return _dvLidSoort
        End Get
    End Property

    Private _dvKmond As DataView
    Public ReadOnly Property dvKmond() As DataView
        Get
            If _dvKmond Is Nothing Then
                FillDataviews()
            End If
            Return _dvKmond
        End Get
    End Property

    Private _dvOpzeggingen As DataView
    Public ReadOnly Property dvOpzeggingen() As DataView
        Get
            If _dvOpzeggingen Is Nothing Then
                FillDataviews()
            End If
            Return _dvOpzeggingen
        End Get
    End Property

    'Private _jdTranslates As List(Of tbljdTranslate)
    'Public ReadOnly Property jdTranslates() As List(Of tbljdTranslate)
    '    Get
    '        _jdTranslates = New List(Of tbljdTranslate)
    '        Dim ohelper As New Helper
    '        Dim sql As String = "SELECT * FROM jdTranslate WHERE CalEntryField is Not Null"
    '        _jdTranslates = ohelper.MapDataTableToList(Of tbljdTranslate)(da.ExecuteDataTable(sql, Nothing))
    '        Return _jdTranslates
    '    End Get
    'End Property

    'Private _jdTable As DataTable
    'Public ReadOnly Property jdTable() As DataTable
    '    Get
    '        _jdTable = New DataTable
    '        'Dim sql As String = "SELECT distinct DBColumn FROM jdTranslate" ' WHERE CalEntryField is Not Null"
    '        _jdTable = da.ExecuteDataTable("SELECT distinct DBColumn FROM jdTranslate", Nothing)
    '        Return _jdTable
    '    End Get
    'End Property
    Private Function CreateSqlString() As String
        Dim sql As String = String.Empty
        Dim sbSql As New StringBuilder
        Dim union As String = "UNION "
        Dim jdTable As New DataTable
        jdTable = da.ExecuteDataTable("SELECT distinct DBColumn FROM jdTranslate", Nothing)

        For Each jdtr As DataRow In jdTable.Rows
            Dim colname As String = jdtr("DBColumn").ToString
            sbSql.Append("select F.Id , '" & colname & "' as DateType, [" & colname & "] as Datefield, BehandelaarId ")
            sbSql.Append("from IBBFases F ")
            sbSql.Append("INNER JOIN IBBDossiers D on D.Id = F.DossierId ")
            sbSql.Append("where [" & colname & "] >= @DateFrom ")
            sbSql.Append(union)
        Next

        sql = sbSql.ToString
        If sql.EndsWith("UNION ") Then sql = sql.Substring(0, sql.Length - union.Length)

        Return sql
    End Function


    Private _ComingTerms As DataTable
    Public ReadOnly Property CommingTerms() As DataTable
        Get
            If _ComingTerms Is Nothing Then

                Dim param() As Object = {"@DateFrom", Today}
                _ComingTerms = da.ExecuteDataTable(CreateSqlString, param)
                _ComingTerms.DefaultView.Sort = "BehandelaarId, Datefield" & " ASC"

            End If

            Return _ComingTerms
        End Get
    End Property

    Public Function ClosedIbbDossiers()
        Try

            Dim param() As Object = {"@Jurist", Juristid, "@DateFrom", QueryDate}
            Dim sql As String = "SELECT * " &
                                "FROM IBBDossiers " &
                                "WHERE BehandelaarId = @Jurist and EndDate >= @DateFrom"

            If DossierStatus > -1 Then
                sql &= " AND Afgehandeld = " & DossierStatus
            End If

            _IbbDossiers = da.ExecuteDataTable(sql, param)
            _IbbDossiers.DefaultView.Sort = "EndDate" & " ASC"

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private _IbbDossiers As DataTable
    Public Property IbbDossiers() As DataTable
        Get
            If _IbbDossiers Is Nothing Then
                Dim sqlPart As String = "BehandelaarId = @Jurist and "
                If Juristid = 0 Then
                    sqlPart = ""
                End If

                If RubriekId > 0 Then
                    sqlPart &= "RubriekId = @RubriekId and "
                End If

                If IBBGroepId > 0 Then
                    sqlPart = "IBBGroep = @IBBGroep and "
                End If


                Dim param() As Object = {"@Jurist", Juristid, "@DateFrom", QueryDate, "@RubriekId", RubriekId, "@IBBGroep", IBBGroepId}
                Dim sql As String = "SELECT * " &
                                    "FROM IBBDossiers " &
                                    "WHERE " & sqlPart & "CreateDate >= @DateFrom"

                If DossierStatus > -1 Then
                    sql &= " AND Afgehandeld = " & DossierStatus
                End If

                _IbbDossiers = da.ExecuteDataTable(sql, param)
                _IbbDossiers.DefaultView.Sort = "BehandelaarId Asc, CreateDate ASC"
                _IbbDossiers = _IbbDossiers.DefaultView.ToTable

                'ldv1.Sort = tbl1.Columns(0).ColumnName + " Asc, " + tbl1.Columns(1).ColumnName + " Asc"
            End If

            Return _IbbDossiers
        End Get
        Set(ByVal value As DataTable)
            _IbbDossiers = value
        End Set
    End Property
    Public Function IbbDossiersPerGroep(GroepId As Integer) As DataTable

        _IbbDossiers = Nothing

        Dim sqlPart As String = "BehandelaarId = @Jurist and "

        If Juristid = 0 Then
            sqlPart = ""
        End If

        If RubriekId > 0 Then
            sqlPart &= "RubriekId = @RubriekId and "
        End If

        If IBBGroepId > 0 Then
            sqlPart = "IBBGroep = @IBBGroepId and "
        End If


        Dim param() As Object = {"@Jurist", Juristid, "@DateFrom", QueryDate, "@RubriekId", RubriekId, "@IBBGroep", IBBGroepId}
        Dim sql As String = "SELECT * " &
                                    "FROM IBBDossiers " &
                                    "WHERE " & sqlPart & "CreateDate >= @DateFrom"

        If DossierStatus > -1 Then
            sql &= " AND Afgehandeld = " & DossierStatus
        End If

        _IbbDossiers = da.ExecuteDataTable(sql, param)
        _IbbDossiers.DefaultView.Sort = "BehandelaarId Asc, CreateDate ASC"
        _IbbDossiers = _IbbDossiers.DefaultView.ToTable



        Return _IbbDossiers


    End Function
    Private Sub FillDataviews()
        Try
            Dim dtLidSoort As New DataTable
            Dim rwLidSoort As DataRow
            dtLidSoort.Columns.Add("lidsoortnaam", Type.GetType("System.String")) '
            dtLidSoort.Columns.Add("lidsoortId", Type.GetType("System.String"))
            dtLidSoort.Columns.Add("lidid", Type.GetType("System.Int32"))

            Dim dtKM As New DataTable
            Dim rwKM As DataRow
            dtKM.Columns.Add("kmd", Type.GetType("System.String")) '
            dtKM.Columns.Add("lidsoortId", Type.GetType("System.String"))
            dtKM.Columns.Add("lidid", Type.GetType("System.Int32"))

            Dim dtOpzeggingen As New DataTable
            Dim rwOpzeggingen As DataRow
            dtOpzeggingen.Columns.Add("eindereden", Type.GetType("System.String")) '
            dtOpzeggingen.Columns.Add("lidsoortId", Type.GetType("System.String"))
            dtOpzeggingen.Columns.Add("lidid", Type.GetType("System.Int32"))

            Dim iCounter As Integer = 1
            Dim iTotalRelaties As Integer = RelatiesList.Count

            For Each rel As Relaties In RelatiesList
                rwLidSoort = dtLidSoort.NewRow
                rwKM = dtKM.NewRow
                rwOpzeggingen = dtOpzeggingen.NewRow

                Dim sSoort As String = rel.CurrentPeriode.myLidSoort.soort
                If String.IsNullOrEmpty(sSoort) Then sSoort = "Z"

                RaiseEvent GenerateCounter(iCounter, iTotalRelaties)

                If rel.LidSoortPerioden.Count = 0 Then
                    rwLidSoort.Item("lidsoortnaam") = ""
                    rwLidSoort.Item("lidsoortId") = sSoort

                    rwKM.Item("lidsoortId") = sSoort
                Else
                    rwLidSoort.Item("lidsoortnaam") = rel.CurrentPeriode.myLidSoort.omschrijving
                    rwLidSoort.Item("lidsoortId") = sSoort

                    rwKM.Item("lidsoortId") = sSoort
                End If

                If rel.kmond < 0 Then
                    rwKM.Item("kmd") = 0
                Else
                    rwKM.Item("kmd") = rel.kmond
                End If


                rwLidSoort.Item("lidid") = rel.Id
                rwKM.Item("lidid") = rel.Id
                dtKM.Rows.Add(rwKM)

                rwOpzeggingen.Item("eindereden") = rel.eindereden
                rwOpzeggingen.Item("lidsoortId") = sSoort
                rwOpzeggingen.Item("lidid") = rel.Id
                dtOpzeggingen.Rows.Add(rwOpzeggingen)

                dtLidSoort.Rows.Add(rwLidSoort)
                iCounter += 1
            Next

            _dvLidSoort = New DataView(dtLidSoort)
            _dvKmond = New DataView(dtKM)
            _dvOpzeggingen = New DataView(dtOpzeggingen)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private _RelatiesList As List(Of Relaties)
    Private ReadOnly Property RelatiesList() As List(Of Relaties)
        Get
            If _RelatiesList Is Nothing Then
                _dvLidSoort = Nothing
                _dvKmond = Nothing
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties"
                Dim paramlist As New ArrayList

                If DateIn <> SqlTypes.SqlDateTime.MinValue Then
                    paramlist = New ArrayList
                    paramlist.Add("@DateIn")
                    paramlist.Add(DateIn)
                    paramlist.Add("@DateOut")
                    paramlist.Add(DateOut)
                    paramlist.Add("@status")
                    paramlist.Add(Status)
                    Select Case Status
                        Case 1
                            sql &= " WHERE (eindedatum >= @DateIn AND eindedatum <= @DateOut) AND (status = @status OR status = 0)"
                        Case 0, 2
                            sql &= " WHERE ((indatum >= @DateIn AND indatum <= @DateOut)OR indatum IS NULL OR (InstroomDatum >= @DateIn AND InstroomDatum <= @DateOut))AND (eindedatum is NULL OR eindedatum >= @DateOut) AND status = @status"
                        Case Else ', 3
                            RaiseEvent GenerateExp(New Exception("RelatiesList - Status: " & Status & "onbekend"))
                    End Select

                End If
                _RelatiesList = New List(Of Relaties)
                _RelatiesList = ohelper.MapDataTableToList(Of Relaties)(da.ExecuteDataTable(sql, paramlist.ToArray))

            End If

            Return _RelatiesList
        End Get
    End Property
    Enum eCountType
        TotalActive
        TotalCanceled
    End Enum
    Private ReadOnly Property RelatieCount(ByVal _type As eCountType) As Integer
        Get

            Dim sql As String = "SELECT count(*) FROM relaties"
            Dim paramlist As New ArrayList
            ' Dim dt As New DataTable
            Dim iCount As Integer = 0
            If DateIn <> SqlTypes.SqlDateTime.MinValue Then
                paramlist = New ArrayList
                paramlist.Add("@DateYear")
                paramlist.Add(DateOut.Year)
                paramlist.Add("@DateOut")
                paramlist.Add(DateOut)

                If _type = eCountType.TotalActive Then
                    'sql &= " WHERE (eindedatum is NULL OR eindedatum >= @DateOut) AND (status = 0)"
                    sql &= " WHERE ((eindedatum is NULL AND (status = 0)) OR (eindedatum >= @DateOut AND Status in (0,1)))AND indatum < @DateOut"
                ElseIf _type = eCountType.TotalCanceled Then
                    sql &= " WHERE (year(eindedatum) = @DateYear)"
                Else
                    Return 0
                End If
                iCount = DirectCast(da.ExecuteScalar(sql, paramlist.ToArray), Integer)
            End If

            Dim result As Integer = iCount
            'dt = Nothing

            Return result
        End Get
    End Property

    Private _AfterCare As List(Of Relaties)
    Public ReadOnly Property AfterCare() As List(Of Relaties)
        Get
            If _AfterCare Is Nothing Then
                Dim ohelper As New Helper
                Dim da As New DataAccess
                Dim paramlist As New ArrayList

                'Dim sql As String = "SELECT * FROM relaties " & _
                '                    "WHERE " & _
                '                    "EXISTS (select * from nazorg where nazorg.lidid = relaties.id)AND " & _
                '                    "eindereden = 5 " & _
                '                    "AND (eindedatum >= @DateIn AND eindedatum <= @DateOut) " & _
                '                    "order by eindedatum ASC"

                Dim sql As String = "SELECT * FROM relaties r " &
                                    "INNER JOIN nazorg n on n.lidid = r.id " &
                                    "WHERE " &
                                    "n.TrivMelding = 1 " &
                                    "AND eindereden = 5 " &
                                    "AND (eindedatum >= @DateIn AND eindedatum <= @DateOut) " &
                                    "order by eindedatum ASC"

                paramlist = New ArrayList
                paramlist.Add("@DateIn")
                paramlist.Add(DateIn)
                paramlist.Add("@DateOut")
                paramlist.Add(DateOut)

                '_Deceased = da.ExecuteDataTable(sql, paramlist.ToArray)
                _AfterCare = New List(Of Relaties)
                _AfterCare = ohelper.MapDataTableToList(Of Relaties)(da.ExecuteDataTable(sql, paramlist.ToArray))

            End If

            Return _AfterCare
        End Get
    End Property

    Public Sub ReportInOut()
        Dim result As String = ""
        Try
            If DateIn = SqlTypes.SqlDateTime.MinValue Then
                RaiseEvent GenerateExp(New Exception("datum ''VAN'' is niet opgegeven!"))
            End If
            If DateOut = SqlTypes.SqlDateTime.MinValue Then
                RaiseEvent GenerateExp(New Exception("datum ''TOT'' is niet opgegeven!"))
            End If

            RaiseEvent GenerateStatus("Bezig met ophalen van alle nieuwe relaties.")

            Dim iTotalRelaties As Integer = RelatiesList.Count
            Dim totaalinstroom As Integer = dvLidSoort.Count
            Dim Percentage As Double = 0.0

            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")

            Dim sb As New StringBuilder
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            Dim oPara1 As Word.Paragraph
            Dim DocName As String = ""
            Dim iLineWidth As Integer = 160

            DocName = LocationPath & "LEDEN_IN_UITSTROOM_" & Format(DateIn, "yyyyMMdd") & "_" & Format(DateOut, "yyyyMMdd") '& ".doc"
            'DocName = DocName.Replace(" ", "_")
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape


            oPara1 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)

            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Bold = False
            oPara1.Range.Font.Size = 8
            oPara1.Range.Text = ""
            oPara1.Format.SpaceAfter = 0
            oPara1.Range.InsertParagraphAfter()
            oPara1.TabStops.ClearAll()

            RaiseEvent GenerateStatus("Bezig met maken verslag In- en Uitstroom.")

            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            sb.Append("Instroom ledenbestand vanaf " & Format(DateIn, "dd-MM-yyyy") & " t/m " & Format(DateOut, "dd-MM-yyyy") & vbCrLf)
            sb.Append("Totale instroom " & iTotalRelaties & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf & vbCrLf)

            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Size = 8
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder


            '*** Begin van de table versie ***
            Dim oTable As Word.Table
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, KMSoorten.Rows.Count + 4)
            oTable.Range.ParagraphFormat.SpaceAfter = 0

            Dim r As Integer = 1
            Dim c As Integer = 5
            'oTable.Rows.Add()
            'oTable.Rows.Add()
            oTable.Rows(r).Range.Bold = True
            oTable.Cell(r, 1).Range.Text = "soort"
            oTable.Cell(r, 1).SetWidth(oWord.CentimetersToPoints(1), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, 2).Range.Text = "omschrijving"
            oTable.Cell(r, 2).SetWidth(oWord.CentimetersToPoints(2.5), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, 3).Range.Text = "aantal"
            oTable.Cell(r, 3).SetWidth(oWord.CentimetersToPoints(1), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oTable.Cell(r, 4).Range.Text = "%"
            oTable.Cell(r, 4).SetWidth(oWord.CentimetersToPoints(1), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter

            For Each row In KMSoorten.Rows
                oTable.Cell(r, c).Range.Text = row.item("kmonderdeel")
                c += 1
            Next

            RaiseEvent GenerateStatus("Bezig met verwerken van alle nieuwe relaties.")



            For Each lidsoort In LidSoorten
                dvLidSoort.RowFilter = "lidsoortId = '" & lidsoort.soort & "'"
                'als er geen zijn dan overslaan.
                If dvLidSoort.Count = 0 Then Continue For
                'bereken percentage
                Percentage = (dvLidSoort.Count / totaalinstroom) * 100
                r += 1
                oTable.Rows.Add()
                oTable.Rows(r).Range.Bold = False
                oTable.Cell(r, 1).Range.Text = lidsoort.soort
                oTable.Cell(r, 2).Range.Text = lidsoort.omschrijving
                oTable.Cell(r, 3).Range.Text = dvLidSoort.Count
                oTable.Cell(r, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                oTable.Cell(r, 4).Range.Text = Math.Round(Percentage, 1)
                oTable.Cell(r, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                'Maak kmonderdelen tellingen
                c = 5
                For Each row In KMSoorten.Rows
                    dvKmond.RowFilter = "lidsoortId = '" & lidsoort.soort & "' AND kmd = " & row.item("id")
                    If dvKmond.Count = 0 Then
                        oTable.Cell(r, c).Range.Text = ""
                    Else
                        oTable.Cell(r, c).Range.Text = dvKmond.Count
                    End If
                    oTable.Cell(r, c).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                    c += 1
                Next
            Next


            r += 1
            oTable.Rows.Add()
            oTable.Rows(r).Range.Bold = False
            oTable.Cell(r, 1).Range.Text = "Totale"
            oTable.Cell(r, 2).Range.Text = "instroom"
            oTable.Cell(r, 3).Range.Text = iTotalRelaties
            oTable.Cell(r, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oTable.Cell(r, 4).Range.Text = "100"
            oTable.Cell(r, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            Dim iBorderCollumnInstroom As Integer = 4

            c = 5
            For Each row In KMSoorten.Rows
                dvKmond.RowFilter = "kmd = " & row.item("id")
                oTable.Cell(r, c).Range.Text = dvKmond.Count
                oTable.Cell(r, c).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                c += 1
            Next


            oDoc.Tables(1).Rows(1).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderBottom)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderTop)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With

            oDoc.Tables(1).Rows(oDoc.Tables(1).Rows.Count).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderTop)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With


            oDoc.Tables(1).Columns(iBorderCollumnInstroom).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderRight)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With
            'oTable.Cell(1, 1).Merge(MergeTo:=oTable.Cell(1 + KMSoorten.Rows.Count + 4, 1))

            oDoc.Bookmarks.Item("\endofdoc").Range.InsertParagraphAfter()

            '*** verwerken Uitstroom ***
            _RelatiesList = Nothing
            Status = 1

            RaiseEvent GenerateStatus("Bezig met ophalen van alle beeindigde relaties.")
            iTotalRelaties = RelatiesList.Count
            Dim TotaalUitstroom As Integer = dvLidSoort.Count

            sb = New StringBuilder

            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            sb.Append("Uitstroom ledenbestand vanaf " & Format(DateIn, "dd-MM-yyyy") & " t/m " & Format(DateOut, "dd-MM-yyyy") & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf & vbCrLf)

            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Size = 8
            oPara1.Range.InsertAfter(sb.ToString)

            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 3 + Opzeggingen.Rows.Count + KMSoorten.Rows.Count)
            oTable.Range.ParagraphFormat.SpaceAfter = 0

            r = 1
            c = 4

            'oTable.Rows.Add()
            'oTable.Rows(1).Cells(1).Merge(oTable.Rows(1).Cells(3))
            'oTable.Cell(r, 1).Range.Text = "soort"

            'r += 1
            oTable.Rows(r).Range.Bold = True
            oTable.Cell(r, 1).Range.Text = "soort"
            oTable.Cell(r, 1).SetWidth(oWord.CentimetersToPoints(1), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, 2).Range.Text = "aantal"
            oTable.Cell(r, 2).SetWidth(oWord.CentimetersToPoints(1), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oTable.Cell(r, 3).Range.Text = "%"
            oTable.Cell(r, 3).SetWidth(oWord.CentimetersToPoints(1), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            Dim iBorderCollumnUitstroom As Integer = 3 'aanpassen als hier boven nog wat bijkomt

            For Each row In Opzeggingen.Rows
                oTable.Cell(r, c).Range.Text = row.item("code")
                c += 1
            Next

            For Each row In KMSoorten.Rows
                oTable.Cell(r, c).Range.Text = row.item("kmonderdeel")
                c += 1
            Next

            RaiseEvent GenerateStatus("Bezig met verwerken van alle beeindigde relaties.")
            For Each lidsoort In LidSoorten
                dvLidSoort.RowFilter = "lidsoortId = '" & lidsoort.soort & "'"
                'als er geen zijn dan overslaan.
                If dvLidSoort.Count = 0 Then Continue For
                'bereken percentage
                Percentage = (dvLidSoort.Count / TotaalUitstroom) * 100
                r += 1
                oTable.Rows.Add()
                oTable.Rows(r).Range.Bold = False
                oTable.Cell(r, 1).Range.Text = lidsoort.soort
                oTable.Cell(r, 2).Range.Text = dvLidSoort.Count
                oTable.Cell(r, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                oTable.Cell(r, 3).Range.Text = Math.Round(Percentage, 0)
                oTable.Cell(r, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter

                c = 4
                For Each row In Opzeggingen.Rows
                    dvOpzeggingen.RowFilter = "lidsoortId = '" & lidsoort.soort & "' AND eindereden = " & row.item("id")
                    If dvOpzeggingen.Count = 0 Then
                        oTable.Cell(r, c).Range.Text = ""
                    Else
                        oTable.Cell(r, c).Range.Text = dvOpzeggingen.Count
                    End If
                    oTable.Cell(r, c).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                    c += 1
                Next
                For Each row In KMSoorten.Rows
                    dvKmond.RowFilter = "lidsoortId = '" & lidsoort.soort & "' AND kmd = " & row.item("id")
                    If dvKmond.Count = 0 Then
                        oTable.Cell(r, c).Range.Text = ""
                    Else
                        oTable.Cell(r, c).Range.Text = dvKmond.Count
                    End If
                    oTable.Cell(r, c).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                    c += 1
                Next
            Next


            r += 1
            oTable.Rows.Add()
            oTable.Rows(r).Range.Bold = False
            oTable.Cell(r, 1).Range.Text = ""
            oTable.Cell(r, 2).Range.Text = iTotalRelaties
            oTable.Cell(r, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            oTable.Cell(r, 3).Range.Text = "100"
            oTable.Cell(r, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            c = 4
            For Each row In Opzeggingen.Rows
                dvOpzeggingen.RowFilter = "eindereden = " & row.item("id")
                oTable.Cell(r, c).Range.Text = dvOpzeggingen.Count
                oTable.Cell(r, c).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                c += 1
            Next
            For Each row In KMSoorten.Rows
                dvKmond.RowFilter = "kmd = " & row.item("id")
                oTable.Cell(r, c).Range.Text = dvKmond.Count
                oTable.Cell(r, c).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
                c += 1
            Next

            oDoc.Tables(2).Rows(1).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderBottom)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderTop)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With

            oDoc.Tables(2).Rows(oDoc.Tables(2).Rows.Count).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderTop)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With


            oDoc.Tables(2).Columns(iBorderCollumnUitstroom).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderRight)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With

            oDoc.Tables(2).Columns(3 + Opzeggingen.Rows.Count).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderRight)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With

            oDoc.Bookmarks.Item("\endofdoc").Range.InsertParagraphAfter()

            sb = New StringBuilder
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            sb.Append("Totale aantal leden op " & Format(DateOut, "dd-MM-yyyy") & ": " & RelatieCount(eCountType.TotalActive) & vbCrLf)
            sb.Append("Totale aantal opzeggingen in jaar " & Format(DateOut, "yyyy") & ": " & RelatieCount(eCountType.TotalCanceled) & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)

            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Size = 8
            oPara1.Range.InsertAfter(sb.ToString)





            oDoc.SaveAs(DocName, Word.WdSaveFormat.wdFormatDocument)

            RaiseEvent GenerateStatus(DocName.ToLower & " is klaar!")
            RaiseEvent GenerateComplete(iTotalRelaties)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub
    Public Sub ReportDeceased()

        Try
            If DateIn = SqlTypes.SqlDateTime.MinValue Then
                RaiseEvent GenerateExp(New Exception("datum ''VAN'' is niet opgegeven!"))
            End If

            RaiseEvent GenerateStatus("Bezig met ophalen van alle relaties.")

            Dim iDeceased As Integer = AfterCare.Count

            Dim sb As New StringBuilder
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            Dim DocName As String = ""
            Dim iLineWidth As Integer = 85

            DocName = LocationPath & "OVERLEDEN_" & Format(Now, "yyyyMMdd") '& ".doc"
            'DocName = DocName.Replace(" ", "_")

            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False

            'haal relatie objecten op
            'hier in staat leeftijd en rang
            'sorteren op eindedatum
            'iedere maand beginnen met maand jaar als header.
            'voor ieder record geld de volgende opmaak:
            'CxR1 = dd-mm   CxR1 = init + naam (leeftijd jaar)
            '               CxR2 = rang
            '               CxR3 = adres
            '               CxR4 = pc + plaats

            '*** Begin van de table versie ***
            Dim oTable As Word.Table
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 2, Nothing, Word.WdAutoFitBehavior.wdAutoFitContent)

            Dim r As Integer = 0
            Dim c As Integer = 2
            Dim tmpmonth As Integer = -1
            Dim aList As New ArrayList
            RaiseEvent GenerateStatus("Bezig met verwerken relaties ")
            For Each rel As Relaties In AfterCare
                If IsTerminating Then
                    RaiseEvent GenerateStatus("Annuleren")
                    RaiseEvent GenerateComplete(0)
                    Exit Sub
                End If

                Dim Eind As Date = CDate(rel.eindedatum)
                If Eind.Month <> tmpmonth Then
                    r += 1
                    oTable.Rows.Add()
                    oTable.Rows(r).Range.Font.Color = Word.WdColor.wdColorDarkRed
                    oTable.Cell(r, c).Range.Text = GetMonthName(Eind.Month) & " " & Eind.Year
                    'onthouden om later te mergen
                    aList.Add(r)
                End If
                tmpmonth = Eind.Month

                r += 1
                oTable.Rows.Add()
                oTable.Cell(r, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed
                oTable.Cell(r, 1).Range.Text = Eind.Day.ToString.PadLeft(2, "0") & "-" & Eind.Month.ToString.PadLeft(2, "0")
                oTable.Cell(r, c).Range.Text = rel.InitName & " (" & rel.Age & " jaar)"

                If Not String.IsNullOrEmpty(rel.RangNaamOnly) Then
                    r += 1
                    oTable.Rows.Add()
                    Dim Dienstvak As String = String.Empty
                    If rel.dienstvak > 0 Then Dienstvak = "- " & rel.DienstVakNaamKort
                    oTable.Cell(r, c).Range.Text = rel.myNazorg.LaatsteRang & Dienstvak
                End If
                r += 1
                oTable.Rows.Add()
                oTable.Cell(r, c).Range.Text = rel.FullAddress
                r += 1
                oTable.Rows.Add()
                oTable.Cell(r, c).Range.Text = rel.postcode & " " & rel.plaats
                r += 1
                oTable.Rows.Add()
                oTable.Cell(r, c).Range.Text = ""
            Next

            oTable.Columns(1).AutoFit()
            oTable.Columns(2).AutoFit()

            'nog ff de maandcellen mergen
            For i = 0 To aList.Count - 1
                Dim ar As Integer = aList.Item(i)
                oTable.Cell(ar, 1).Merge(oTable.Cell(ar, c))
            Next

            oWord.Selection.PageSetup.TextColumns.SetCount(NumColumns:=2)

            oDoc.SaveAs(DocName, Word.WdSaveFormat.wdFormatDocument)

            RaiseEvent GenerateStatus(DocName.ToLower & " is klaar!")
            RaiseEvent GenerateComplete(iDeceased)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub
    Private Function GetMonthName(ByVal monthNum As Integer) As String
        Try
            Dim strDate As New DateTime(1, monthNum, 1)
            Return strDate.ToString("MMMM")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub Report()

        Dim result As String = String.Empty
        Try

            Dim sb As New StringBuilder
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            Dim oPara1 As Word.Paragraph
            Dim DocName As String = ""
            Dim iLineWidth As Integer = 85

            DocName = LocationPath & "LEDEN_VERSLAG_" & Format(Now, "yyyyMMdd") '& ".doc"
            'DocName = DocName.Replace(" ", "_")

            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False
            oPara1 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara1.TabStops.ClearAll()
            oDoc.SaveAs(DocName)

            Dim dtLidSoort As New DataTable
            Dim rwLidSoort As DataRow

            dtLidSoort.Columns.Add("lidsoortnaam", Type.GetType("System.String")) '
            dtLidSoort.Columns.Add("lidsoortId", Type.GetType("System.String"))
            dtLidSoort.Columns.Add("lidid", Type.GetType("System.Int32"))

            Dim dtAM As New DataTable
            dtAM.Columns.Add("kmd", Type.GetType("System.String")) '
            dtAM.Columns.Add("rng", Type.GetType("System.String"))
            dtAM.Columns.Add("lidid", Type.GetType("System.Int32"))

            RaiseEvent GenerateStatus("Bezig met ophalen van alle relaties.")

            Status = 0
            DateIn = New Date(1900, 1, 1)
            'DateOut = New Date(2100, 12, 31)
            Dim iTotalRelaties As Integer = RelatiesList.Count

            RaiseEvent GenerateStatus("Bezig met maken van telling per lidsoort.")
            'Dim ActieveMilitairen As New List(Of Relaties)
            Dim iCounter As Integer = 1

            'Bug ID: 1644 voortaan standaard meenemen in het verslag
            'debug: voor overzicht van de Z leden.
            Dim bDebugZ As Boolean = True
            Dim sbZ As New StringBuilder
            sbZ.Append("overzicht van de leden zonder lidsoort:" & vbCrLf)


            For Each rel As Relaties In RelatiesList
                If IsTerminating Then
                    RaiseEvent GenerateStatus("IsTerminating")
                    RaiseEvent GenerateComplete(0)
                    Exit Sub
                End If

                ' If iCounter Mod 10 = 0 Then
                RaiseEvent GenerateCounter(iCounter, iTotalRelaties)
                'End If


                Dim sSoort As String = rel.CurrentPeriode.myLidSoort.soort
                If String.IsNullOrEmpty(sSoort) Then
                    sSoort = "Z"
                    If bDebugZ Then sbZ.AppendLine("lidid:" & rel.Id & " ; lidnr " & rel.lidnr)

                End If



                rwLidSoort = dtLidSoort.NewRow
                If rel.LidSoortPerioden.Count = 0 Then
                    rwLidSoort.Item("lidsoortnaam") = ""
                    rwLidSoort.Item("lidsoortId") = sSoort
                    rwLidSoort.Item("lidid") = rel.Id
                Else
                    rwLidSoort.Item("lidsoortnaam") = rel.CurrentPeriode.myLidSoort.omschrijving
                    rwLidSoort.Item("lidsoortId") = sSoort
                    rwLidSoort.Item("lidid") = rel.Id
                End If
                dtLidSoort.Rows.Add(rwLidSoort)
                iCounter += 1

                'If rel.CurrentPeriode.myLidSoort.soort = "N" Or rel.CurrentPeriode.myLidSoort.soort = "1" Then
                'ActieveMilitairen.Add(rel)
                'TODO moet een stukje hoger komen onder voorwaarde dat er een lidsoort is,
                'maar in de testDB staan er niet zoveel gevuld.
                'rwAM = dtAM.NewRow
                'rwAM.Item("kmd") = rel.kmond
                'rwAM.Item("rng") = rel.rang
                'rwAM.Item("lidid") = rel.Id
                'dtAM.Rows.Add(rwAM)
                ''End If

            Next
            'converteer table naar dataview om later te filteren en tellen.
            Dim dvLidSoort As New DataView(dtLidSoort)
            'Dim dvAM As New DataView(dtAM)


            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")


            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Bold = False
            oPara1.Range.Font.Size = 10
            oPara1.Range.Text = ""
            oPara1.Format.SpaceAfter = 0
            oPara1.Range.InsertParagraphAfter()
            oPara1.TabStops.ClearAll()
            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(3)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabCenter

            Dim totaal As Integer = dvLidSoort.Count
            Dim totaalZonderLidSoort As Integer = 0
            Dim totaal079 As Integer = 0
            Dim Percentage As Double = 0.0

            Dim actieve_militairen As Int32 = 0
            Dim postactieve_militairen As Int32 = 0
            Dim totaal_militairen As Int32 = 0
            Dim actieve_burgers As Int32 = 0
            Dim totaal_burgers As Int32 = 0

            RaiseEvent GenerateStatus("Bezig met maken verslag lidsoorttellingen")

            sb.Append("Verdeling ledenbestand op " & Format(Now, "dd-MM-yyyy") & vbCrLf & vbCrLf)
            sb.Append("Verdeling per LIDSOORT:" & vbCrLf & vbCrLf)
            sb.Append("Lidsoort" & vbTab & "omschrijving" & vbTab & "aantal" & vbTab & "Percentage" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)

            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Size = 10
            oPara1.Range.InsertAfter(sb.ToString)


            sb = New StringBuilder

            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Size = 10
            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabLeft
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
            oPara1.TabStops.Add(oWord.CentimetersToPoints(9)).Alignment = Word.WdTabAlignment.wdAlignTabCenter

            'Dim EmptyLidSoort As New LidSoort
            'EmptyLidSoort.soort = "0"
            'EmptyLidSoort.omschrijving = "Zonder lidsoort"
            'LidSoorten.Add(EmptyLidSoort)

            For Each lidsoort In LidSoorten
                dvLidSoort.RowFilter = "lidsoortId = '" & lidsoort.soort & "'"
                Select Case lidsoort.soort
                    Case "0", "Z"
                        totaalZonderLidSoort += dvLidSoort.Count
                        totaal079 += dvLidSoort.Count
                    Case "1"
                        actieve_militairen += dvLidSoort.Count
                        totaal_militairen += dvLidSoort.Count
                    Case "2"

                    Case "3"
                        actieve_burgers += dvLidSoort.Count
                        totaal_burgers += dvLidSoort.Count
                    Case "4"

                    Case "5"
                        totaal_militairen += dvLidSoort.Count
                        postactieve_militairen += dvLidSoort.Count
                    Case "6"
                        totaal_burgers += dvLidSoort.Count
                    Case "7"
                        totaal079 += dvLidSoort.Count
                    Case "8"

                    Case "9"
                        totaal079 += dvLidSoort.Count
                    Case "N"
                        actieve_militairen += dvLidSoort.Count
                        totaal_militairen += dvLidSoort.Count
                End Select
                Percentage = (dvLidSoort.Count / totaal) * 100
                sb.Append(lidsoort.soort & vbTab & lidsoort.omschrijving.PadRight(25, " ") & vbTab & dvLidSoort.Count & vbTab & Math.Round(Percentage, 2) & vbTab & " %" & vbTab & vbCrLf)
                oPara1.Range.InsertAfter(sb.ToString)
                sb = New StringBuilder
            Next

            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            sb.Append(vbTab & "Totaaltelling" & Space(15) & vbTab & totaal & vbTab & "100,00" & vbTab & "%" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            sb.Append(vbTab & "Minus lidsoort 0,7,9  " & vbTab & totaal079 & vbTab & Math.Round((totaal079 / totaal) * 100, 2) & vbTab & "%" & vbCrLf)
            sb.Append(vbTab & "Totaal betalende leden" & vbTab & (totaal - totaal079) & vbTab & Math.Round(((totaal - totaal079) / totaal) * 100, 2) & vbTab & " %" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder

            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(3)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            sb.Append(vbCrLf & "Totaal aantal MILITAIREN:" & vbCrLf)
            sb.Append("omschrijving" & vbTab & vbTab & "aantal" & vbTab & "Percentage" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder
            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabLeft
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
            oPara1.TabStops.Add(oWord.CentimetersToPoints(9)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            sb.Append(vbTab & "totaal_militairen " & vbTab & totaal_militairen & vbTab & Math.Round((totaal_militairen / totaal) * 100, 2) & vbTab & "%" & vbCrLf)
            sb.Append(vbTab & "actieve_militairen" & vbTab & actieve_militairen & vbTab & Math.Round((actieve_militairen / totaal) * 100, 2) & vbTab & "%" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder


            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(3)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            sb.Append(vbCrLf & "Totaal aantal BURGERS:" & vbCrLf)
            sb.Append("omschrijving" & vbTab & vbTab & "aantal" & vbTab & "Percentage" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder
            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabLeft
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
            oPara1.TabStops.Add(oWord.CentimetersToPoints(9)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            sb.Append(vbTab & "totaal burgers" & vbTab & totaal_burgers & vbTab & Math.Round((totaal_burgers / totaal) * 100, 2) & vbTab & "%" & vbCrLf)
            sb.Append(vbTab & "actieve burgers" & vbTab & actieve_burgers & vbTab & Math.Round((actieve_burgers / totaal) * 100, 2) & vbTab & "%" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder


            RaiseEvent GenerateStatus("Rangverdeling ACTIEVE MILITAIREN PER KRIJGSMACHTDEEL")

            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(3)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            sb.Append(vbCrLf & vbCrLf & "Rangverdeling ACTIEVE MILITAIREN PER KRIJGSMACHTDEEL" & vbCrLf & vbCrLf)
            sb.Append("Totaal aantal ACTIEVE MILITAIREN:" & vbTab & actieve_militairen & vbCrLf)
            sb.Append("KMD" & Space(15) & vbTab & "RANG" & vbTab & "aantal" & vbTab & "Percentage" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder
            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabLeft
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
            oPara1.TabStops.Add(oWord.CentimetersToPoints(9)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            Dim dt As DataTable = Nothing
            For Each row In KMSoorten.Rows
                Dim sqlExists As String = "SELECT TOP 1 * FROM Lidsoortperioden WHERE ((lidid = Relaties.id AND datumin <= @DateIn) AND (lidsoortid = 1 OR lidsoortid = 9)) ORDER BY datumin DESC"
                Dim sql As String = "select distinct COUNT(Relaties.id)as aantal ,rang  from Relaties " &
                                    "WHERE EXISTS( " & sqlExists & " ) and kmond = @kmond  group by rang order by rang"

                Dim param() As Object = {"@kmond", row.item("Id"), "@DateIn", Today}
                dt = da.ExecuteDataTable(sql, param)

                For Each rowAm In dt.Rows
                    Percentage = (rowAm.Item("aantal") / actieve_militairen) * 100
                    sb.Append(row.item("kmonderdeel").ToString.PadRight(25, " ") & vbTab & rowAm.Item("rang") & vbTab & rowAm.Item("aantal") & vbTab & Math.Round(Percentage, 2) & vbTab & " %" & vbTab & vbCrLf)
                    oPara1.Range.InsertAfter(sb.ToString)
                    sb = New StringBuilder
                Next
            Next

            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder


            RaiseEvent GenerateStatus("Rangverdeling POSTACTIEVE MILITAIREN PER KRIJGSMACHTDEEL")
            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(3)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            sb.Append(vbCrLf & vbCrLf & "Rangverdeling POSTACTIEVE MILITAIREN PER KRIJGSMACHTDEEL" & vbCrLf & vbCrLf)
            sb.Append("Totaal aantal POSTACTIEVE MILITAIREN:" & vbTab & postactieve_militairen & vbCrLf)
            sb.Append("KMD" & Space(15) & vbTab & "RANG" & vbTab & "aantal" & vbTab & "Percentage" & vbCrLf)
            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)
            sb = New StringBuilder
            oPara1.TabStops.Add(oWord.CentimetersToPoints(1)).Alignment = Word.WdTabAlignment.wdAlignTabLeft
            oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
            oPara1.TabStops.Add(oWord.CentimetersToPoints(9)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            'dt As DataTable = Nothing
            For Each row In KMSoorten.Rows
                Dim sqlExists As String = "SELECT TOP 1 * FROM Lidsoortperioden WHERE ((lidid = Relaties.id AND datumin <= @DateIn) AND (lidsoortid = 5)) ORDER BY datumin DESC"
                Dim sql As String = "select distinct COUNT(Relaties.id)as aantal ,rang  from Relaties " &
                                    "WHERE EXISTS( " & sqlExists & " ) and kmond = @kmond  group by rang order by rang"

                Dim param() As Object = {"@kmond", row.item("Id"), "@DateIn", Today}
                dt = da.ExecuteDataTable(sql, param)

                For Each rowAm In dt.Rows
                    Percentage = (rowAm.Item("aantal") / postactieve_militairen) * 100
                    sb.Append(row.item("kmonderdeel").ToString.PadRight(25, " ") & vbTab & rowAm.Item("rang") & vbTab & rowAm.Item("aantal") & vbTab & Math.Round(Percentage, 2) & vbTab & " %" & vbTab & vbCrLf)
                    oPara1.Range.InsertAfter(sb.ToString)
                    sb = New StringBuilder
                Next
            Next

            sb.Append("-", iLineWidth)
            sb.Append(vbCrLf)
            oPara1.Range.InsertAfter(sb.ToString)

            If bDebugZ Then
                'overzicht van de Z leden
                oPara1.Range.InsertAfter(sbZ.ToString)
            End If

            sb = New StringBuilder


            oDoc.SaveAs(DocName)

            RaiseEvent GenerateStatus(DocName.ToLower & vbCrLf & " is klaar!")
            RaiseEvent GenerateComplete(iTotalRelaties)


        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub
    Public Sub ReportRelation()
        Try
            RaiseEvent GenerateStatus("Bezig met ophalen van relatie gegevens.")
            Status = 0


            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")
            Dim sb As New StringBuilder
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            ' Dim oPara1 As Word.Paragraph
            Dim DocName As String = ""
            Dim iLineWidth As Integer = 85

            'DocName = LocationPath & "rapport_" & Format(Now, "yyyyMMdd") & ".doc"
            'DocName = DocName.Replace(" ", "_")

            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False

            Dim oTable As Word.Table
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 3)
            oTable.Range.ParagraphFormat.SpaceAfter = 0

            Dim r As Integer = 1
            Dim c As Integer = 1

            oTable.Cell(r, c).Range.Text = "Werknemernr."
            oTable.Cell(r, c).SetWidth(oWord.CentimetersToPoints(3.5), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.lidnr
            oTable.Cell(r, c + 1).SetWidth(oWord.CentimetersToPoints(5), RulerStyle:=Word.WdRulerStyle.wdAdjustNone)
            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Geboortedatum"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.geboortedatum

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Naam"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.FullName
            oTable.Cell(r, c + 2).Range.Text = MyRelatie.telefoonnummer

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "adres"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.FullAddress
            oTable.Cell(r, c + 2).Range.Text = MyRelatie.mobiel

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = ""
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.postcode & " " & MyRelatie.plaats

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "email"
            If String.IsNullOrEmpty(MyRelatie.email) Then
                oTable.Cell(r, c + 1).Range.Text = "onbekend"
            Else
                oTable.Cell(r, c + 1).Range.Text = MyRelatie.email
            End If


            r += 1
            oTable.Rows.Add()

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Afdeling"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.AfdelingNaam

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Krijgsmacht"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.KrijgsmachtNaam

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Dienstvak"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.DienstVakNaam

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Plaatsing"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.PlaatsingNaam

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Rang"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.RangNaam

            r += 1
            oTable.Rows.Add()

            r += 1
            oTable.Rows.Add()
            oTable.Cell(r, c).Range.Text = "Huidig lidsoort"
            oTable.Cell(r, c + 1).Range.Text = MyRelatie.CurrentPeriode.myLidSoort.omschrijving


            If MyRelatie.LidFuncties.Count > 0 Then
                r += 1
                oTable.Rows.Add()
                r += 1
                oTable.Rows.Add()
                oTable.Rows(r).Range.Bold = True
                oTable.Cell(r, c).Range.Text = "Signalering Functie"
                oTable.Cell(r, c + 1).Range.Text = ""

            End If


            If Not String.IsNullOrEmpty(MyRelatie.eindedatum) Then
                r += 1
                oTable.Rows.Add()
                r += 1
                oTable.Rows.Add()
                oTable.Cell(r, c).Range.Text = "Eindedatum"
                oTable.Cell(r, c + 1).Range.Text = MyRelatie.eindedatum
                r += 1
                oTable.Rows.Add()
                oTable.Cell(r, c).Range.Text = "Einde reden"
                Dim param() As Object = {"@Id", MyRelatie.eindereden}
                oTable.Cell(r, c + 1).Range.Text = da.ExecuteScalar("SELECT omschrijving FROM opzeggingen where id = @id", param)

            End If

            'oDoc.SaveAs(DocName)

            RaiseEvent GenerateStatus(DocName.ToLower & vbCrLf & " is klaar!")
            RaiseEvent GenerateComplete(0)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub
    Public ReportBehandelaarId As Integer = -1
    Public Sub ReportIBBTermijnen()
        Try
            RaiseEvent GenerateStatus("Bezig met ophalen van gegevens.")

            Dim iTerms As Integer = CommingTerms.Rows.Count
            RaiseEvent GenerateCounter(0, iTerms)
            Dim sb As New StringBuilder
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            Dim DocName As String = ""
            Dim iLineWidth As Integer = 85

            DocName = LocationPath & "IBB termijnen" & Format(Now, "yyyyMMdd") '& ".doc"
            'DocName = DocName.Replace(" ", "_")

            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape

            Dim oTable As Word.Table
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 7, Nothing, Word.WdAutoFitBehavior.wdAutoFitContent)

            Dim r As Integer = 1
            Dim c As Integer = 2

            oTable.Rows.Add()
            oTable.Rows(r).Range.Bold = True
            oTable.Cell(r, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed
            oTable.Cell(r, 1).Range.Text = "DossierNr"
            oTable.Cell(r, c).Range.Text = "cliënt"
            c += 1
            oTable.Cell(r, c).Range.Text = "Datum"
            c += 1
            oTable.Cell(r, c).Range.Text = "Activiteit"
            c += 1
            oTable.Cell(r, c).Range.Text = "Fase"
            c += 1
            oTable.Cell(r, c).Range.Text = "Behandelaar"
            c += 1
            oTable.Cell(r, c).Range.Text = "Onderwerp"


            RaiseEvent GenerateStatus("Bezig met verwerken gegevens ")
            Dim MyFase As IBBFase

            'nu nog jurist onderverdelen
            '
            Dim icounter As Integer = 0
            Dim checkJuristId As String = String.Empty
            Dim dvCommingTerms As DataView = CommingTerms.DefaultView

            If ReportBehandelaarId > 0 Then
                dvCommingTerms.RowFilter = "BehandelaarId = " & ReportBehandelaarId & ""
            End If

            For Each dr As DataRowView In dvCommingTerms
                icounter += 1
                If checkJuristId <> dr("BehandelaarId").ToString And Not String.IsNullOrEmpty(checkJuristId) Then
                    oTable.Rows.Add()
                    r += 1
                    RaiseEvent GenerateCounter(icounter, iTerms)
                End If
                checkJuristId = dr("BehandelaarId").ToString

                MyFase = New IBBFase(dr("Id"), IBBFase.Via.ID)

                If IsTerminating Then
                    RaiseEvent GenerateStatus("Annuleren")
                    RaiseEvent GenerateComplete(0)
                    Exit Sub
                End If

                r += 1

                oTable.Rows.Add()
                oTable.Cell(r, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed
                oTable.Cell(r, 1).Range.Text = MyFase.DossierNr
                c = 2
                oTable.Cell(r, c).Range.Text = MyFase.IBBDossier.MyRelatie.FullName
                c += 1
                oTable.Cell(r, c).Range.Text = dr("Datefield") 'MyFase.Beslisdatum
                c += 1
                oTable.Cell(r, c).Range.Text = MyFase.DateFieldTranslate(dr("DateType"))
                c += 1
                oTable.Cell(r, c).Range.Text = MyFase.Fase.Type
                c += 1
                oTable.Cell(r, c).Range.Text = MyFase.IBBDossier.Behandelaar
                c += 1
                oTable.Cell(r, c).Range.Text = MyFase.IBBDossier.Onderwerp

            Next



            'oTable.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightExactly
            'oTable.Rows.Height = oWord.CentimetersToPoints(0.5)

            oTable.Columns.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            oTable.Columns(1).SetWidth(oWord.CentimetersToPoints(3), Word.WdRulerStyle.wdAdjustSameWidth)
            'oTable.Columns(2).SetWidth(oWord.CentimetersToPoints(3), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(2).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            oTable.Columns(3).SetWidth(oWord.CentimetersToPoints(3), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(5).SetWidth(oWord.CentimetersToPoints(1.5), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(c).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            ' oTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent)

            oDoc.Tables(1).Rows(1).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderBottom)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With


            'oWord.Selection.PageSetup.TextColumns.SetCount(NumColumns:=2)

            oDoc.SaveAs(DocName, Word.WdSaveFormat.wdFormatDocument)

            RaiseEvent GenerateStatus(DocName.ToLower & " is klaar!")
            RaiseEvent GenerateComplete(iTerms)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)

        End Try
    End Sub
    Public Sub ReportHTMLIBBTermijnen()
        Try
            RaiseEvent GenerateStatus("Bezig met ophalen van gegevens.")

            Dim iTerms As Integer = CommingTerms.Rows.Count
            RaiseEvent GenerateCounter(0, iTerms)
            Dim sb As New StringBuilder

            Dim DocName As String = ""
            Dim iLineWidth As Integer = 85



            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")

            Dim oTable As New DataTable
            Dim defaultRow As DataRow
            oTable.Columns.Add("DossierNr", Type.GetType("System.String")) '
            oTable.Columns.Add("cliënt", Type.GetType("System.String"))
            oTable.Columns.Add("Datum", Type.GetType("System.String"))
            oTable.Columns.Add("Activiteit", Type.GetType("System.String"))
            oTable.Columns.Add("Fase", Type.GetType("System.String"))
            'oTable.Columns.Add("Behandelaar", Type.GetType("System.String"))
            oTable.Columns.Add("Onderwerp", Type.GetType("System.String"))


            Dim r As Integer = 1
            Dim c As Integer = 2


            RaiseEvent GenerateStatus("Bezig met verwerken gegevens ")
            Dim MyFase As IBBFase

            ''nu nog jurist onderverdel
            ''
            Dim icounter As Integer = 0
            Dim checkJuristId As String = String.Empty
            Dim dvCommingTerms As DataView = CommingTerms.DefaultView

            If ReportBehandelaarId > 0 Then
                dvCommingTerms.RowFilter = "BehandelaarId = " & ReportBehandelaarId & ""
            End If

            If Not dvCommingTerms.Count > 0 Then
                RaiseEvent GenerateStatus("gekozen behandelaar heeft geen komende termijnen")
                RaiseEvent GenerateComplete(iTerms)
                Exit Sub

            End If
            For Each dr As DataRowView In dvCommingTerms
                icounter += 1
                'If checkJuristId <> dr("BehandelaarId").ToString And Not String.IsNullOrEmpty(checkJuristId) Then
                '    oTable.Rows.Add()
                '    r += 1
                '    RaiseEvent GenerateCounter(icounter, iTerms)
                'End If
                'checkJuristId = dr("BehandelaarId").ToString

                MyFase = New IBBFase(dr("Id"), IBBFase.Via.ID)

                If IsTerminating Then
                    RaiseEvent GenerateStatus("Annuleren")
                    RaiseEvent GenerateComplete(0)
                    Exit Sub
                End If

                r += 1
                defaultRow = oTable.NewRow

                defaultRow.Item("DossierNr") = MyFase.DossierNr
                defaultRow.Item("cliënt") = MyFase.IBBDossier.MyRelatie.FullName
                defaultRow.Item("Datum") = dr("Datefield")
                defaultRow.Item("Activiteit") = MyFase.DateFieldTranslate(dr("DateType"))
                defaultRow.Item("Fase") = MyFase.Fase.Type
                'defaultRow.Item("Behandelaar") = MyFase.IBBDossier.Behandelaar
                defaultRow.Item("Onderwerp") = MyFase.IBBDossier.Onderwerp

                oTable.Rows.Add(defaultRow)

            Next


            'WriteFile(ConvertToHtmlFile(oTable, _RTM), "_RTM")
            Dim sHtml As String = ConvertToHtmlFile(oTable, MyFase.IBBDossier.Behandelaar)


            Dim oEmail As New Email
            oEmail.Address = MyFase.IBBDossier.myBehandelaar.Email
            oEmail.Name = MyFase.IBBDossier.Behandelaar

            Dim oMailer As New Mailer
            oMailer.MailSubject = "Overzicht behandelaar " & MyFase.IBBDossier.Behandelaar

            oMailer.MailBody = sHtml
            oMailer.SendEmbeddedImages(oEmail)


            RaiseEvent GenerateStatus(DocName.ToLower & " is klaar!")
            RaiseEvent GenerateComplete(iTerms)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)

        End Try
    End Sub
    Private Function ConvertToHtmlFile(ByVal myTable As DataTable, ByVal behandelaar As String) As String
        Dim myHtmlFile As String = ""
        Try


            If (myTable Is Nothing) Then
                Throw New System.ArgumentNullException("targetTable")
            Else
                'Continue.
                'dt.DefaultView.Sort = "SEQ"
                'myTable = dt.DefaultView.Table

            End If

            Dim myBuilder As New System.Text.StringBuilder
            myBuilder.Append("<html xmlns='http://www.w3.org/1999/xhtml'>" & vbCrLf)
            myBuilder.Append("<head>" & vbCrLf)
            myBuilder.Append("<title>")
            myBuilder.Append(behandelaar)
            myBuilder.Append("</title>" & vbCrLf)
            myBuilder.Append("</head>" & vbCrLf)
            myBuilder.Append("<body>" & vbCrLf)
            myBuilder.Append("<style type='text/css'>" &
                            "table { " &
                            "border: 1;" &
                            "border-color: Black;" &
                            "line-height : 80%;}" &
                            "tr.head {	background-color: Black;	font-weight : bold;	text-align: left;}" &
                            "tr.a {background-color: #FFFFF8;} " &
                            "tr.b {background-color: #ccffff;} " &
                            "</style>")
            myBuilder.Append("<table width='100%'>")
            myBuilder.Append("<tr align='left' valign='top'><td class='heading' height='15' colspan=5 valign='bottom' > behandelaar " & behandelaar & "</td></tr>" & vbCrLf)
            myBuilder.Append("<tr align='left' valign='top'><td colspan=5>&nbsp;</td></tr>" & vbCrLf)
            myBuilder.Append("<tr align='left' valign='top' class='tussenboven'><td colspan='5'  valign='bottom'></td></tr>" & vbCrLf)

            myBuilder.Append("<tr class='head'>" & vbCrLf)

            For Each myColumn As DataColumn In myTable.Columns
                myBuilder.Append("<th>")
                myBuilder.Append(myColumn.ColumnName.ToUpper)
                myBuilder.Append("</th>" & vbCrLf)
            Next myColumn

            myBuilder.Append("</tr>" & vbCrLf)

            Dim classStyle As String = "a"
            For Each Row As DataRow In myTable.Rows
                myBuilder.Append("<tr class='" & classStyle & "'>" & vbCrLf)
                For Each myColumn As DataColumn In myTable.Columns
                    myBuilder.Append("<td align='left' valign='top'>")
                    Dim value As String = Row(myColumn.ColumnName).ToString()
                    If String.IsNullOrEmpty(value) Then value = "&nbsp;"
                    myBuilder.Append(value)
                    myBuilder.Append("</td>" & vbCrLf)
                Next myColumn
                myBuilder.Append("</tr>" & vbCrLf)
                If classStyle = "a" Then
                    classStyle = "b"
                ElseIf classStyle = "b" Then
                    classStyle = "a"
                End If
            Next Row


            Dim lastUpdate As DateTime = Now
            'myBuilder.Append("<br><br><br>laatste update was op: " & lastUpdate.ToLongDateString & "&nbsp;&nbsp;" & lastUpdate.ToLongTimeString & "<br>" & vbCrLf)
            'myBuilder.Append("laatste update NET CONTROL: " & _DataPageUpdate & "<br>" & vbCrLf)

            myBuilder.Append("<tr align='left' valign='top' class='tussen'>" & vbCrLf)
            myBuilder.Append("<td colspan='5' height='40' valign='bottom'></td></tr>" & vbCrLf)
            myBuilder.Append("<tr align='left' valign='top' class='update'>" & vbCrLf)
            myBuilder.Append("<td colspan='5' valign='bottom' class='update'><span style='color:#FFF; font-size:10px;'></span></td></tr>" & vbCrLf)
            myBuilder.Append("<tr align='left' valign='top' class='update'>" & vbCrLf)
            myBuilder.Append("<td colspan='5' valign='bottom' class='update'><span style='color:#FFF; font-size:10px;'></span></td></tr>" & vbCrLf)

            myBuilder.Append("</table>" & vbCrLf)

            myBuilder.Append("</body>")
            myBuilder.Append("</html>")

            myHtmlFile = myBuilder.ToString()

            Return myHtmlFile
        Catch ex As Exception
            EventLog.WriteEntry("ConvertToHtmlFile error", ex.Message)
            Throw ex
        End Try

    End Function


    Public Juristid As Integer
    Public QueryDate As Date
    Public DossierStatus As Integer = -1
    Public ReportTitel As String = String.Empty
    Public RubriekId As Integer = 0
    Public IBBGroepId As Integer = 0

    Public Sub ReportIBBDossiers()
        Try
            RaiseEvent GenerateStatus("Bezig met ophalen van gegevens.")

            Dim iDossiers As Integer = IbbDossiers.Rows.Count
            If iDossiers = 0 Then
                RaiseEvent GenerateStatus("Geen dossiers in huidige selectie")
                RaiseEvent GenerateComplete(iDossiers)
                Exit Try
            End If

            RaiseEvent GenerateCounter(0, iDossiers)
            Dim sb As New StringBuilder
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            Dim DocName As String = ""
            Dim iLineWidth As Integer = 85

            DocName = LocationPath & "IBB Dossiers" & Format(Now, "yyyyMMdd") '& ".doc"
            'DocName = DocName.Replace(" ", "_")

            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape

            Dim oPara1 As Word.Paragraph
            oPara1 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Bold = True
            oPara1.Range.Font.Size = 14
            oPara1.Range.Text = ReportTitel
            oPara1.Format.SpaceAfter = 0
            oPara1.Range.InsertParagraphAfter()

            Dim oTable As Word.Table
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 7, Nothing, Word.WdAutoFitBehavior.wdAutoFitContent)

            Dim r As Integer = 1
            Dim c As Integer = 2

            oTable.Rows.Add()
            oTable.Rows(r).Range.Bold = True
            oTable.Cell(r, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed
            oTable.Cell(r, 1).Range.Text = "DossierNr"
            oTable.Cell(r, c).Range.Text = "Cliënt"
            c += 1
            oTable.Cell(r, c).Range.Text = "Datum aanmaak"
            c += 1
            oTable.Cell(r, c).Range.Text = "Onderwerp"
            c += 1
            oTable.Cell(r, c).Range.Text = "Behandelaar"
            c += 1
            oTable.Cell(r, c).Range.Text = "Mutatie"
            c += 1
            oTable.Cell(r, c).Range.Text = "Sluiting"

            RaiseEvent GenerateStatus("Bezig met verwerken gegevens ")
            Dim MyIBBDossier As IBBDossier

            'nu nog jurist onderverdelen
            '
            Dim icounter As Integer = 0
            Dim checkJuristId As String = String.Empty
            Dim dvIbbDossiers As DataView = IbbDossiers.DefaultView

            'Thread.CurrentThread.CurrentCulture = New CultureInfo("nl-NL")

            For Each dr As DataRowView In dvIbbDossiers
                icounter += 1
                If checkJuristId <> dr("BehandelaarId").ToString And Not String.IsNullOrEmpty(checkJuristId) Then
                    oTable.Rows.Add()
                    r += 1
                    RaiseEvent GenerateCounter(icounter, iDossiers)
                End If

                checkJuristId = dr("BehandelaarId").ToString
                MyIBBDossier = New IBBDossier(dr("Id"), IBBDossier.VIA.ID)

                If IsTerminating Then
                    RaiseEvent GenerateStatus("Annuleren")
                    RaiseEvent GenerateComplete(0)
                    Exit Sub
                End If

                r += 1

                oTable.Rows.Add()
                oTable.Cell(r, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed
                oTable.Cell(r, 1).Range.Text = MyIBBDossier.DossierNr
                c = 2
                oTable.Cell(r, c).Range.Text = MyIBBDossier.MyRelatie.FullName
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.CreateDate.ToShortDateString
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.Onderwerp
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.myBehandelaar.Naam
                c += 1
                If Not IsNothing(MyIBBDossier.GetMutDate) Then
                    Dim diff As TimeSpan = Today - MyIBBDossier.GetMutDate
                    Dim MutDate As Date = MyIBBDossier.GetMutDate
                    oTable.Cell(r, c).Range.Text = MutDate.ToShortDateString & "(" & diff.Days & " dgn.)"
                Else
                    oTable.Cell(r, c).Range.Text = MyIBBDossier.GetMutDate.ToString
                End If
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.EndDate.ToString
            Next

            'oTable.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightExactly
            'oTable.Rows.Height = oWord.CentimetersToPoints(0.5)

            oTable.Columns.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            oTable.Columns(1).SetWidth(oWord.CentimetersToPoints(3), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(2).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            oTable.Columns(3).SetWidth(oWord.CentimetersToPoints(3), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(4).SetWidth(oWord.CentimetersToPoints(7), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(6).SetWidth(oWord.CentimetersToPoints(4), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(c).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            ' oTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent)

            oDoc.Tables(1).Rows(1).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderBottom)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With


            'oWord.Selection.PageSetup.TextColumns.SetCount(NumColumns:=2)

            oDoc.SaveAs(DocName, Word.WdSaveFormat.wdFormatDocument)

            RaiseEvent GenerateStatus(DocName.ToLower & " is klaar!")
            RaiseEvent GenerateComplete(iDossiers)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)

        End Try
    End Sub
    Public Sub ReportIBBDossiersTrefwoord()
        Try
            RaiseEvent GenerateStatus("Bezig met ophalen van gegevens.")

            Dim iDossiers As Integer = IbbDossiers.Rows.Count
            If iDossiers = 0 Then
                RaiseEvent GenerateStatus("Geen dossiers in huidige selectie")
                RaiseEvent GenerateComplete(iDossiers)
                Exit Try
            End If

            RaiseEvent GenerateCounter(0, iDossiers)
            Dim sb As New StringBuilder
            Dim oWord As Word.Application
            Dim oDoc As Word.Document
            Dim DocName As String = ""
            Dim iLineWidth As Integer = 85

            DocName = LocationPath & "IBB Dossiers" & Format(Now, "yyyyMMdd") '& ".doc"
            'DocName = DocName.Replace(" ", "_")

            RaiseEvent GenerateStatus("Bezig met openen nieuw document.")
            oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape

            Dim oPara1 As Word.Paragraph
            oPara1 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara1.Range.Font.Name = "Calibri"
            oPara1.Range.Font.Bold = True
            oPara1.Range.Font.Size = 14
            oPara1.Range.Text = ReportTitel
            oPara1.Format.SpaceAfter = 0
            oPara1.Range.InsertParagraphAfter()

            Dim oTable As Word.Table
            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 1, 8, Nothing, Word.WdAutoFitBehavior.wdAutoFitContent)

            Dim r As Integer = 1
            Dim c As Integer = 2

            oTable.Rows.Add()
            oTable.Rows(r).Range.Bold = True
            oTable.Cell(r, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed
            oTable.Cell(r, 1).Range.Text = "DossierNr"
            oTable.Cell(r, c).Range.Text = "Cliënt"
            c += 1
            oTable.Cell(r, c).Range.Text = "Geb. Datum"
            c += 1
            oTable.Cell(r, c).Range.Text = "Datum aanmaak"
            c += 1
            oTable.Cell(r, c).Range.Text = "Onderwerp"
            c += 1
            oTable.Cell(r, c).Range.Text = "Behandelaar"
            c += 1
            oTable.Cell(r, c).Range.Text = "Mutatie"
            c += 1
            oTable.Cell(r, c).Range.Text = "Sluiting"

            RaiseEvent GenerateStatus("Bezig met verwerken gegevens ")
            Dim MyIBBDossier As IBBDossier

            'nu nog jurist onderverdelen
            '
            Dim icounter As Integer = 0
            Dim checkJuristId As String = String.Empty
            Dim dvIbbDossiers As DataView = IbbDossiers.DefaultView
            For Each dr As DataRowView In dvIbbDossiers
                icounter += 1
                If checkJuristId <> dr("BehandelaarId").ToString And Not String.IsNullOrEmpty(checkJuristId) Then
                    oTable.Rows.Add()
                    r += 1
                    RaiseEvent GenerateCounter(icounter, iDossiers)
                End If
                checkJuristId = dr("BehandelaarId").ToString

                MyIBBDossier = New IBBDossier(dr("Id"), IBBDossier.VIA.ID)

                If IsTerminating Then
                    RaiseEvent GenerateStatus("Annuleren")
                    RaiseEvent GenerateComplete(0)
                    Exit Sub
                End If

                r += 1

                oTable.Rows.Add()
                oTable.Cell(r, 1).Range.Font.Color = Word.WdColor.wdColorDarkRed
                oTable.Cell(r, 1).Range.Text = MyIBBDossier.DossierNr
                c = 2
                oTable.Cell(r, c).Range.Text = MyIBBDossier.MyRelatie.FullName
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.MyRelatie.geboortedatum
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.CreateDate.ToShortDateString
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.Onderwerp
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.myBehandelaar.Naam
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.GetMutDate.ToString
                c += 1
                oTable.Cell(r, c).Range.Text = MyIBBDossier.EndDate.ToString
            Next

            'oTable.Rows.HeightRule = Word.WdRowHeightRule.wdRowHeightExactly
            'oTable.Rows.Height = oWord.CentimetersToPoints(0.5)

            oTable.Columns.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            oTable.Columns(1).SetWidth(oWord.CentimetersToPoints(2), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(2).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            oTable.Columns(3).SetWidth(oWord.CentimetersToPoints(3), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(4).SetWidth(oWord.CentimetersToPoints(3), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(5).SetWidth(oWord.CentimetersToPoints(8), Word.WdRulerStyle.wdAdjustSameWidth)
            oTable.Columns(c).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            ' oTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent)

            oDoc.Tables(1).Rows(1).Select()
            With oWord.Selection.Borders(Word.WdBorderType.wdBorderBottom)
                .LineStyle = oWord.Options.DefaultBorderLineStyle
                .LineWidth = oWord.Options.DefaultBorderLineWidth
                .Color = oWord.Options.DefaultBorderColor
            End With


            'oWord.Selection.PageSetup.TextColumns.SetCount(NumColumns:=2)

            oDoc.SaveAs(DocName, Word.WdSaveFormat.wdFormatDocument)

            RaiseEvent GenerateStatus(DocName.ToLower & " is klaar!")
            RaiseEvent GenerateComplete(iDossiers)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)

        End Try
    End Sub
    'Private Sub textversie()

    'oPara1.TabStops.Add(oWord.CentimetersToPoints(4)).Alignment = Word.WdTabAlignment.wdAlignTabRight
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(4.5)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(4.7)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(5)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(7)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(9)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(10)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(11)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(12)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(13)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(14)).Alignment = Word.WdTabAlignment.wdAlignTabCenter

    ''Maak de headers
    'sb.Append("soort" & vbTab & "aantal" & vbTab & "%" & vbTab & vbTab)
    'For Each row In KMSoorten.Rows
    '    If row.item("id") = 0 Then
    '        sb.Append("?" & vbTab)
    '    Else
    '        sb.Append(row.item("kmonderdeel") & vbTab)
    '    End If
    'Next
    'sb.Append(vbCrLf)
    'sb.Append("-", iLineWidth)
    'oPara1.Range.InsertAfter(sb.ToString & vbCrLf)
    'sb = New StringBuilder

    'oPara1.TabStops.ClearAll()
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(0.5)).Alignment = Word.WdTabAlignment.wdAlignTabLeft
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(4)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(4.5)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(5)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(6)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(7)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(9)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(10)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(11)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(12)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(13)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
    'oPara1.TabStops.Add(oWord.CentimetersToPoints(14)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal

    'RaiseEvent GenerateStatus("Bezig met verwerken van alle nieuwe relaties.")

    'For Each lidsoort In LidSoorten
    '    dvLidSoort.RowFilter = "lidsoortId = '" & lidsoort.soort & "'"
    '    'als er geen zijn dan overslaan.
    '    If dvLidSoort.Count = 0 Then Continue For
    '    'bereken percentage
    '    Percentage = (dvLidSoort.Count / totaalinstroom) * 100
    '    sb.Append(lidsoort.soort & vbTab & lidsoort.omschrijving.PadRight(25, " ") & vbTab & dvLidSoort.Count & vbTab & Math.Round(Percentage, 0) & "|" & vbTab)
    '    'Maak kmonderdelen tellingen
    '    Dim kmstring As String = ""
    '    For Each row In KMSoorten.Rows
    '        dvKmond.RowFilter = "lidsoortId = '" & lidsoort.soort & "' AND kmd = " & row.item("id")
    '        If dvKmond.Count = 0 Then
    '            kmstring &= Space(2) & vbTab
    '        Else
    '            kmstring &= dvKmond.Count & vbTab
    '        End If
    '    Next
    '    sb.Append(kmstring & vbCrLf)
    '    oPara1.Range.InsertAfter(sb.ToString)
    '    sb = New StringBuilder
    'Next
    'sb.Append("-", iLineWidth)
    'sb.Append(vbCrLf)

    ''Maak een totaaltelling per kmond
    'Dim kmtotalstring As String = "Totale instroom " & vbTab & iTotalRelaties & "|" & vbTab & "100|" & vbTab
    'For Each row In KMSoorten.Rows
    '    dvKmond.RowFilter = "kmd = " & row.item("id")
    '    kmtotalstring &= dvKmond.Count & vbTab
    'Next
    'sb.Append(kmtotalstring & vbCrLf)
    'sb.Append("-", iLineWidth)
    'sb.Append(vbCrLf & vbCrLf & vbCrLf)
    'oPara1.Range.InsertAfter(sb.ToString)

    ' End Sub
    'Public Sub GetLidSoortSegm()
    '    Try
    '        Dim dt As New DataTable
    '        Dim row As DataRow
    '        dt.Columns.Add("lidsoortnaam", Type.GetType("System.String"))
    '        dt.Columns.Add("lidid", Type.GetType("System.Int32"))


    '        For Each soort As LidSoort In LidSoorten
    '            For Each per As LidSoortPeriode In soort.LidSoortPeriodes
    '                row = dt.NewRow
    '                row.Item("lidsoortnaam") = soort.omschrijving
    '                row.Item("lidsoortId") = soort.omschrijving
    '                row.Item("lidid") = per.lidid
    '                dt.Rows.Add(row)
    '            Next
    '        Next

    '        Dim i As Integer = dt.Rows.Count

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private _RelatieTable As DataTable
    'Public ReadOnly Property RelatieTable() As DataTable
    '    Get
    '        If _RelatieTable Is Nothing Then
    '            Dim sql As String = "SELECT id FROM relaties"
    '            Dim da As New DataAccess
    '            _RelatieTable = da.ExecuteDataTable(sql)
    '        End If

    '        Return _RelatieTable
    '    End Get
    'End Property

    Public Sub New()

    End Sub
End Class
