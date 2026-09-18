Imports System.IO
Imports Word = Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports BusinessObjects
Imports System.Text

Public Class BookingList
    Private oWord As New Word.Application
    'Private excelBook As Excel.Workbook
    Private _BoekingTable As DataTable

    'Private _oExcel As Excel.Application
    'Public ReadOnly Property oExcel() As Excel.Application
    '    Get
    '        If _oExcel Is Nothing Then _oExcel = New Excel.Application
    '        Return _oExcel
    '    End Get
    'End Property
    Private _MyDocuments As String = ""
    Public ReadOnly Property MyDocuments() As String
        Get
            If String.IsNullOrEmpty(_MyDocuments) Then
                _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            Return _MyDocuments
        End Get
    End Property
    Public ReadOnly Property BoekingTable() As DataTable
        Get
            If _BoekingTable Is Nothing Then
                _BoekingTable = New DataTable
                _BoekingTable.TableName = "boekingen"
                _BoekingTable.Columns.Add("locatie", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("datum", Type.GetType("System.DateTime"))
                _BoekingTable.Columns.Add("adviseur", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("tijdstip", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("lidnr", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("m\v\x", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("naam", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("telefoonnummer", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("mobiel", Type.GetType("System.String"))
                _BoekingTable.Columns.Add("verwerkt", Type.GetType("String"))

            End If
            Return _BoekingTable
        End Get
    End Property
    Private _locatiePath As String
    Public Property locatiePath() As String
        Get
            If Not _locatiePath.EndsWith("\") Then
                _locatiePath = _locatiePath & "\"
            End If
            Return _locatiePath
        End Get
        Set(ByVal value As String)
            'Als dir nog niet bestaat maak het dan
            Dim di As New IO.DirectoryInfo(value)
            If Not di.Exists Then di.Create()
            _locatiePath = value
        End Set
    End Property

    Public Sub PerLocatiePerDatumWord(ByVal path As String)
        Try
            locatiePath = path

            Dim MyLocaties As New Locaties
            Dim oDatumLijst As BlokkenLijst
            Dim MyDatumLijst As List(Of Blok) = Nothing
            Dim BloksByDate As List(Of Blok) = Nothing
            Dim newRow As DataRow
            newRow = BoekingTable.NewRow

            For Each locatie As Locaties In MyLocaties.Lijst
                Dim LocatieNaam As String = locatie.Locatie.ToUpper
                LocatieNaam = Mid(LocatieNaam, 1, 30)
                LocatieNaam = Replace(LocatieNaam, "[", " ")
                LocatieNaam = Replace(LocatieNaam, "]", " ")
                LocatieNaam = Replace(LocatieNaam, "\", " ")
                LocatieNaam = Replace(LocatieNaam, "/", " ")
                LocatieNaam = Replace(LocatieNaam, "?", " ")
                LocatieNaam = Replace(LocatieNaam, "*", " ")

                oDatumLijst = New BlokkenLijst
                MyDatumLijst = New List(Of Blok)
                MyDatumLijst = oDatumLijst.DatumLijstByLocatie(locatie.Id)

                For Each LocatieBlok In MyDatumLijst

                    BloksByDate = New List(Of Blok)
                    BloksByDate = oDatumLijst.GetBlokByLocationDate(LocatieBlok.datum, LocatieBlok.locatieid)

                    For Each CurrentBlok As Blok In BloksByDate
                        If CurrentBlok.AantalBoekingen > 0 Then
                            For Each CurrentBoeking As Boeking In CurrentBlok.Boekingen
                                If Not CurrentBoeking.lidnr = "0" Then
                                    Dim lid As New Lidmaat(CurrentBoeking.lidnr, Lidmaat.Via.LIDNR)
                                    newRow = BoekingTable.NewRow
                                    newRow.Item("locatie") = LocatieNaam
                                    newRow.Item("datum") = LocatieBlok.datum
                                    newRow.Item("adviseur") = CurrentBlok.AdviseurNaam
                                    newRow.Item("tijdstip") = Format(CurrentBoeking.tijdstip, "HH:mm")
                                    newRow.Item("lidnr") = CurrentBoeking.lidnr
                                    newRow.Item("m\v\x") = CurrentBoeking.LidNaam
                                    newRow.Item("naam") = CurrentBoeking.LidNaam
                                    If String.IsNullOrEmpty(lid.b_telefoon) Then
                                        newRow.Item("telefoonnummer") = lid.b_telefoon
                                    Else
                                        newRow.Item("telefoonnummer") = lid.telefoonnummer
                                    End If
                                    If String.IsNullOrEmpty(lid.b_mobiel) Then
                                        newRow.Item("mobiel") = lid.b_mobiel
                                    Else
                                        newRow.Item("mobiel") = lid.mobiel
                                    End If
                                    If CurrentBoeking.voorlopig Then
                                        newRow.Item("verwerkt") = "Ja"
                                    Else
                                        newRow.Item("verwerkt") = "Nee"
                                    End If

                                    BoekingTable.Rows.Add(newRow)
                                    End If
                            Next
                        End If
                    Next

                    If BoekingTable.Rows.Count > 0 Then
                        Dim dv As New DataView(BoekingTable)
                        dv.Sort = "tijdstip"
                        Dv2Word(dv)
                        'Dv2Excel(dv)
                    Else
                        Dim iCount As Integer = BoekingTable.Rows.Count
                    End If

                    _BoekingTable.Clear()
                    ' WriteFile(MyDocuments & "\Boekingen\" & LocatieNaam & "_" & Format(LocatieBlok.datum, "yyyy_MM_dd") & ".txt", sb.ToString)


                Next

            Next

            System.Diagnostics.Process.Start(locatiePath)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Dv2Word(ByVal dv As DataView)
        Try

            Dim oDoc As New Word.Document
            Dim oTable As Word.Table
            Dim oPara1 As Word.Paragraph

            'Dim DocName As String = MyDocuments & "D:\Boekingen\" & dv.Item(0).Row("locatie") & "_" & Format(dv.Item(0).Row("datum"), "yyyy_MM_dd") & ".doc"
            Dim DocName As String = locatiePath & dv.Item(0).Row("locatie") & "_" & Format(dv.Item(0).Row("datum"), "yyyy_MM_dd") '& ".doc"
            DocName = DocName.Replace(" ", "_")

            If oWord Is Nothing Then oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False

            oPara1 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara1.Range.Font.Bold = True
            oPara1.Range.Text = dv.Item(0).Row("locatie") & " datum: " & dv.Item(0).Row("datum") & _
                                vbCrLf & "Aantal boekingen:" & dv.Table.Rows.Count & vbCrLf
            oPara1.Format.SpaceAfter = 0
            oPara1.Range.InsertParagraphAfter()

            oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, dv.Count + 1, 5)
            oTable.Range.ParagraphFormat.SpaceAfter = 0

            Dim r As Integer = 1
            oTable.Cell(r, 1).Range.Text = "tijdstip"
            oTable.Cell(r, 2).Range.Text = "lidnr"
            oTable.Cell(r, 3).Range.Text = "naam"
            oTable.Cell(r, 4).Range.Text = "telefoonnummer"
            oTable.Cell(r, 5).Range.Text = "mobiel"
            oTable.Rows(r).Range.Bold = True

            r += 1
            For Each rv As DataRowView In dv
                oTable.Cell(r, 1).Range.Text = rv("tijdstip")
                oTable.Cell(r, 2).Range.Text = rv("lidnr")
                oTable.Cell(r, 3).Range.Text = rv("naam")
                oTable.Cell(r, 4).Range.Text = rv("telefoonnummer")
                oTable.Cell(r, 5).Range.Text = rv("mobiel")
                r += 1
            Next

            oTable.Columns(1).AutoFit()
            oTable.Columns(2).AutoFit()
            oTable.Columns(3).AutoFit()
            oTable.Columns(4).AutoFit()
            oTable.Columns(5).AutoFit()
            oDoc.Bookmarks.Item("\endofdoc").Range.InsertParagraphAfter()

            oDoc.SaveAs(DocName)
            'oDoc.SaveAs(DocName, Word.WdSaveFormat.wdFormatDocument)

            oDoc.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub PerLocatiePerDatumTXT(ByVal path As String)
        Try
            locatiePath = Path

            Dim sb As New StringBuilder

            Dim sbHeader As New StringBuilder
            Dim bHeader As Boolean = False

            Dim sbDatum As New StringBuilder
            Dim bDatum As Boolean = False

            Dim sbBlok As New StringBuilder
            Dim bBlok As Boolean = False

            Dim SeparationLine As String = ""

            Dim MyLocaties As New Locaties
            Dim oDatumLijst As BlokkenLijst
            Dim MyDatumLijst As List(Of Blok) = Nothing
            Dim BloksByDate As List(Of Blok) = Nothing

            For Each locatie As Locaties In MyLocaties.Lijst

                Dim LocatieNaam As String = locatie.Locatie.ToUpper
                LocatieNaam = Mid(LocatieNaam, 1, 30)
                LocatieNaam = Replace(LocatieNaam, "[", " ")
                LocatieNaam = Replace(LocatieNaam, "]", " ")
                LocatieNaam = Replace(LocatieNaam, "\", " ")
                LocatieNaam = Replace(LocatieNaam, "/", " ")
                LocatieNaam = Replace(LocatieNaam, "?", " ")
                LocatieNaam = Replace(LocatieNaam, "*", " ")

                oDatumLijst = New BlokkenLijst
                MyDatumLijst = New List(Of Blok)
                MyDatumLijst = oDatumLijst.DatumLijstByLocatie(locatie.Id)

                For Each LocatieBlok In MyDatumLijst
                    bDatum = False
                    sbHeader = New StringBuilder
                    sbHeader.Append(SeparationLine.PadRight(65, "=") & vbCrLf)
                    sbHeader.Append(locatie.Locatie.ToUpper & vbTab & "Datum:" & LocatieBlok.datum & vbCrLf)
                    sbHeader.Append(SeparationLine.PadRight(65, "=") & vbCrLf)

                    BloksByDate = New List(Of Blok)
                    BloksByDate = oDatumLijst.GetBlokByLocationDate(LocatieBlok.datum, LocatieBlok.locatieid)

                    sbBlok = New StringBuilder

                    For Each CurrentBlok As Blok In BloksByDate
                        If CurrentBlok.AantalBoekingen > 0 Then
                            bDatum = True
                            sbBlok.Append(SeparationLine.PadRight(35, "-") & vbCrLf)
                            sbBlok.Append("Adviseur: " & CurrentBlok.AdviseurNaam & vbCrLf)
                            sbBlok.Append("Aantal boekingen: " & CurrentBlok.AantalBoekingen & vbCrLf)
                            sbBlok.Append("Aantal totaal: " & CurrentBlok.AantalTotaal & vbCrLf)
                            sbBlok.Append(SeparationLine.PadRight(35, "-") & vbCrLf)
                            sbBlok.Append(vbCrLf)
                            For Each CurrentBoeking As Boeking In CurrentBlok.Boekingen
                                If Not CurrentBoeking.lidnr = "0" Then
                                    sbBlok.Append("tijdstip: " & CurrentBoeking.tijdstip.ToShortTimeString & vbCrLf)
                                    sbBlok.Append("Lidnr: " & CurrentBoeking.lidnr & vbCrLf)
                                    sbBlok.Append("Naam: " & CurrentBoeking.LidNaam & vbCrLf)
                                    Dim lid As New Lidmaat(CurrentBoeking.lidnr, Lidmaat.Via.LIDNR)
                                    Dim Tel As String = String.Empty
                                    IIf(String.IsNullOrEmpty(lid.b_telefoon), Tel = lid.telefoonnummer, Tel = lid.b_telefoon)
                                    sbBlok.Append("Tel.: " & Tel & vbCrLf)

                                    Dim Mob As String = String.Empty
                                    IIf(String.IsNullOrEmpty(lid.b_telefoon), Mob = lid.mobiel, Mob = lid.b_mobiel)
                                    sbBlok.Append("mobiel: " & Mob & vbCrLf)
                                    sbBlok.Append(vbCrLf)

                                End If
                            Next
                        End If
                    Next

                    sb.Append(vbCrLf & vbCrLf & sbHeader.ToString & vbCrLf)
                    sb.Append(sbBlok.ToString)
                    sb.Append(SeparationLine.PadRight(35, "+") & vbCrLf)



                    WriteFile(locatiePath & LocatieNaam & "_" & Format(LocatieBlok.datum, "yyyy_MM_dd") & ".txt", sb.ToString)

                    sbHeader = New StringBuilder
                    sbDatum = New StringBuilder
                    sbBlok = New StringBuilder
                    sb = New StringBuilder
                Next

            Next

            System.Diagnostics.Process.Start(MyDocuments & "\boekingen")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Bookings2Excel()
        Dim excelApp As New Excel.Application
        Dim excelBook As Excel.Workbook = excelApp.Workbooks.Add
        Dim excelWorksheet As Excel.Worksheet = excelBook.Worksheets(1)
        excelApp.ErrorCheckingOptions.BackgroundChecking = False

        Try
            Dim iSheet As Integer = 0
            Dim ExcelCol() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T"}
            Dim iExcelCol As Integer = 0

            Dim bHeader As Boolean = False
            Dim bDatum As Boolean = False
            Dim bBlok As Boolean = False
            Dim MyLocaties As New Locaties
            Dim oDatumLijst As BlokkenLijst
            Dim MyDatumLijst As List(Of Blok) = Nothing
            Dim BloksByDate As List(Of Blok) = Nothing

            For Each locatie As Locaties In MyLocaties.Lijst
                iExcelCol = 1
                iSheet += 1
                Dim LocatieNaam As String = locatie.Locatie.ToUpper
                LocatieNaam = Mid(LocatieNaam, 1, 30)
                LocatieNaam = Replace(LocatieNaam, "[", " ")
                LocatieNaam = Replace(LocatieNaam, "]", " ")
                LocatieNaam = Replace(LocatieNaam, "\", " ")
                LocatieNaam = Replace(LocatieNaam, "/", " ")
                LocatieNaam = Replace(LocatieNaam, "?", " ")
                LocatieNaam = Replace(LocatieNaam, "*", " ")

                excelWorksheet = excelBook.Worksheets(iSheet)
                excelBook.Sheets.Add(After:=excelBook.Worksheets(excelBook.Worksheets.Count))
                excelWorksheet.Name = LocatieNaam

                bHeader = False

                oDatumLijst = New BlokkenLijst
                MyDatumLijst = New List(Of Blok)
                MyDatumLijst = oDatumLijst.DatumLijstByLocatie(locatie.Id)
                For Each LocatieBlok In MyDatumLijst
                    bDatum = False
                    BloksByDate = New List(Of Blok)
                    BloksByDate = oDatumLijst.GetBlokByLocationDate(LocatieBlok.datum, LocatieBlok.locatieid)
                    '*** kolom headers maken ****
                    excelWorksheet.Range(ExcelCol(0) & "1").Value = "Locatie"
                    excelWorksheet.Range(ExcelCol(1) & "1").Value = "Datum"
                    excelWorksheet.Range(ExcelCol(2) & "1").Value = "tijdstip"
                    excelWorksheet.Range(ExcelCol(3) & "1").Value = "lidnr"
                    excelWorksheet.Range(ExcelCol(4) & "1").Value = "m\v\x"
                    excelWorksheet.Range(ExcelCol(5) & "1").Value = "Naam"
                    excelWorksheet.Range(ExcelCol(6) & "1").Value = "Adviseur"
                    excelWorksheet.Range(ExcelCol(7) & "1").Value = "Verwerkt"
                    excelWorksheet.Range("A1:F1").Font.Bold = True

                    For Each CurrentBlok As Blok In BloksByDate
                        If CurrentBlok.AantalBoekingen > 0 Then
                            bDatum = True
                            For Each CurrentBoeking As Boeking In CurrentBlok.Boekingen
                                If Not CurrentBoeking.lidnr = "0" Then
                                    iExcelCol += 1
                                    excelWorksheet.Range(ExcelCol(0) & iExcelCol).Value = locatie.Locatie.ToUpper
                                    excelWorksheet.Range(ExcelCol(1) & iExcelCol).Value = LocatieBlok.datum
                                    excelWorksheet.Range(ExcelCol(2) & iExcelCol).Value = CurrentBoeking.tijdstip.ToShortTimeString
                                    excelWorksheet.Range(ExcelCol(3) & iExcelCol).Value = CurrentBoeking.lidnr
                                    excelWorksheet.Range(ExcelCol(4) & iExcelCol).Value = CurrentBoeking.MyRelatie.geslacht
                                    Dim myNaam As String = CurrentBoeking.MyRelatie.achternaam
                                    If Not String.IsNullOrEmpty(CurrentBoeking.MyRelatie.init) Then myNaam = myNaam & ", " & CurrentBoeking.MyRelatie.init
                                    If Not String.IsNullOrEmpty(CurrentBoeking.MyRelatie.tussenvoegsel) Then myNaam = myNaam & " " & CurrentBoeking.MyRelatie.tussenvoegsel

                                    excelWorksheet.Range(ExcelCol(5) & iExcelCol).Value = myNaam 'CurrentBoeking.LidNaam
                                    excelWorksheet.Range(ExcelCol(6) & iExcelCol).Value = CurrentBoeking.Blok.AdviseurNaam
                                    excelWorksheet.Range(ExcelCol(7) & iExcelCol).Value = CurrentBoeking.voorlopig
                                End If
                            Next
                        End If
                    Next
                Next

                excelWorksheet.Sort.SortFields.Clear()
                'excelWorksheet.Sort.SortFields.Add(Key:=excelApp.Range("B2:B" & iExcelCol), SortOn:=Excel.XlSortOn.xlSortOnValues, Order:=Excel.XlSortOrder.xlAscending, DataOption:=Excel.XlSortDataOption.xlSortNormal)
                'excelWorksheet.Sort.SortFields.Add(Key:=excelApp.Range("C2:C" & iExcelCol), SortOn:=Excel.XlSortOn.xlSortOnValues, Order:=Excel.XlSortOrder.xlAscending, DataOption:=Excel.XlSortDataOption.xlSortNormal)
                With excelWorksheet.Sort
                    .SetRange(excelApp.Range("A1:F" & iExcelCol))
                    .Header = Excel.XlYesNoGuess.xlYes
                    .MatchCase = False
                    .Orientation = Excel.Constants.xlTopToBottom
                    .SortMethod = Excel.XlSortMethod.xlPinYin
                    .Apply()
                End With
                excelWorksheet.Columns.AutoFit()
                excelWorksheet.Columns.HorizontalAlignment = -4131
            Next

            excelApp.Visible = True
            excelApp.Range("A1").Select()
            excelApp.ActiveWindow.ScrollWorkbookTabs(Position:=Excel.Constants.xlFirst)
            excelApp.Sheets(1).Select()

            'WriteFile(MyDocuments & "\boekingen.txt", sb.ToString)
            'System.Diagnostics.Process.Start(MyDocuments & "\boekingen.txt")

        Catch ex As Exception
            excelApp.Visible = True
            Throw ex
        End Try
    End Sub
    Public Sub String2Word(ByVal FileName As String, ByVal value As String)
        Try

            Dim oDoc As New Word.Document
            Dim oPara1 As Word.Paragraph
            Dim DocName As String = FileName
            DocName = DocName.Replace(" ", "_")

            If oWord Is Nothing Then oWord = CreateObject("Word.Application")
            oWord.Visible = True
            oDoc = oWord.Documents.Add
            oDoc.SpellingChecked = False
            oPara1 = oDoc.Content.Paragraphs.Add(oDoc.Bookmarks.Item("\endofdoc").Range)
            oPara1.TabStops.ClearAll()

            'oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            'oPara1.TabStops.Add(oWord.CentimetersToPoints(12)).Alignment = Word.WdTabAlignment.wdAlignTabCenter
            'oPara1.Range.InsertParagraphAfter()

            oPara1.TabStops.Add(oWord.CentimetersToPoints(8)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal
            oPara1.TabStops.Add(oWord.CentimetersToPoints(12)).Alignment = Word.WdTabAlignment.wdAlignTabDecimal

            oPara1.Range.Font.Bold = True
            oPara1.Range.Text = value
            oPara1.Format.SpaceAfter = 0
            oPara1.Range.InsertParagraphAfter()


            oDoc.SaveAs(DocName)
            'oDoc.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub Dv2Excel(ByVal dv As DataView)
    '    If excelBook Is Nothing Then
    '        excelBook = oExcel.Workbooks.Add
    '    End If

    '    Dim excelWorksheet As Excel.Worksheet = excelBook.Worksheets(1)
    '    oExcel.ErrorCheckingOptions.BackgroundChecking = False
    '    Try
    '        Dim iSheet As Integer = 0
    '        Dim ExcelCol() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T"}
    '        Dim iExcelCol As Integer = 1
    '        Dim XlsName As String = locatiePath & dv.Item(0).Row("locatie") & "_" & Format(dv.Item(0).Row("datum"), "yyyy_MM_dd") & ".xls"
    '        XlsName = XlsName.Replace(" ", "_")

    '        excelWorksheet = excelBook.Worksheets(excelBook.Worksheets.Count)
    '        excelBook.Sheets.Add(After:=excelBook.Worksheets(excelBook.Worksheets.Count))
    '        excelWorksheet.Name = dv.Item(0).Row("locatie") & "_" & Format(dv.Item(0).Row("datum"), "yyyy_MM_dd")
    '        '*** kolom headers maken ****

    '        excelWorksheet.Range(ExcelCol(0) & "1").Value = "tijdstip"
    '        excelWorksheet.Range(ExcelCol(1) & "1").Value = "lidnr"
    '        excelWorksheet.Range(ExcelCol(2) & "1").Value = "naam"
    '        excelWorksheet.Range(ExcelCol(3) & "1").Value = "telefoonnummer"
    '        excelWorksheet.Range(ExcelCol(4) & "1").Value = "mobiel"


    '        excelWorksheet.Range("A1:F1").Font.Bold = True
    '        For Each rv As DataRowView In dv
    '            iExcelCol += 1
    '            excelWorksheet.Range(ExcelCol(0) & iExcelCol).Value = rv("tijdstip")
    '            excelWorksheet.Range(ExcelCol(1) & iExcelCol).Value = rv("lidnr")
    '            excelWorksheet.Range(ExcelCol(2) & iExcelCol).Value = rv("naam")
    '            excelWorksheet.Range(ExcelCol(3) & iExcelCol).Value = rv("telefoonnummer")
    '            excelWorksheet.Range(ExcelCol(4) & iExcelCol).Value = rv("mobiel")
    '        Next

    '        'excelWorksheet.Sort.SortFields.Clear()
    '        'excelWorksheet.Sort.SortFields.Add(Key:=oExcel.Range("B2:B" & iExcelCol), SortOn:=Excel.XlSortOn.xlSortOnValues, Order:=Excel.XlSortOrder.xlAscending, DataOption:=Excel.XlSortDataOption.xlSortNormal)
    '        'excelWorksheet.Sort.SortFields.Add(Key:=oExcel.Range("C2:C" & iExcelCol), SortOn:=Excel.XlSortOn.xlSortOnValues, Order:=Excel.XlSortOrder.xlAscending, DataOption:=Excel.XlSortDataOption.xlSortNormal)
    '        'With excelWorksheet.Sort
    '        '    .SetRange(oExcel.Range("A1:F" & iExcelCol))
    '        '    .Header = Excel.XlYesNoGuess.xlYes
    '        '    .MatchCase = False
    '        '    .Orientation = Excel.Constants.xlTopToBottom
    '        '    .SortMethod = Excel.XlSortMethod.xlPinYin
    '        '    .Apply()
    '        'End With
    '        excelWorksheet.Columns.AutoFit()
    '        excelWorksheet.Columns.HorizontalAlignment = -4131

    '        oExcel.Visible = True
    '        'oExcel.Range("A1").Select()
    '        'oExcel.ActiveWindow.ScrollWorkbookTabs(Position:=Excel.Constants.xlFirst)
    '        'oExcel.Sheets(1).Select()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

End Class
