'Imports Office
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop
Imports BusinessObjects
Imports System.Text

Public Class WordMerge
    Private URights As UserRights = UserRights.Instance

    Private m_WordApp As Microsoft.Office.Interop.Word.Application
    Private m_TemplatePath As String
    Private m_Template As String = ""
    Private m_CurrentDr As DataRow
    Private m_dtWord As New DataTable
    Private m_dsWord As New DataSet
    Private m_MailingtxtOnly As Boolean = False

    Private m_Result As String = ""

    Private Sub Datavalidate()
        Try
            If CurrentDr Is Nothing AndAlso dtWord Is Nothing Then
                Throw New Exception("Er is geen data beschikbaar.")
            End If
            If TemplatePath = "" Then
                Throw New Exception("Er is geen filepad opgegeven.")
            End If
            If Not MailingtxtOnly Then
                If Template = "" Then
                    Throw New Exception("Er is geen sjabloon opgegeven.")
                End If
                Dim slash As String = String.Empty
                If Not Template.StartsWith("\") AndAlso Not TemplatePath.EndsWith("\") Then
                    slash = "\"
                End If
                If Not File.Exists(TemplatePath & slash & Template & ".doc") Then
                    Throw New Exception(TemplatePath & slash & Template & ".doc" & " bestaat niet!")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub WordMergeBelasting(ByVal myMasterDocName As String)

        Dim DataStream As StringBuilder = New StringBuilder
        Dim ExportFileName As String
        Dim MasterDocName As String = myMasterDocName

        'Datavalidate()

        ExportFileName = DataSource ' TemplatePath & "\mailing.txt"

        Try '*** kijk of mailing.txt al bestaat, zoja gooi het weg ****
            If File.Exists(ExportFileName) Then
                File.Delete(ExportFileName)
            End If
        Catch ex As Exception
            Throw New Exception("Het verwijderen van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer de rechten" & vbCrLf & ex.Message)
        End Try


        '*** kijk of MasterDocName bestaat, zo niet geef error ****
        If Not MailingtxtOnly AndAlso File.Exists(MasterDocName) = False Then
            Throw New Exception(MasterDocName & " bestaat niet!")
        End If


        Try '*** uitlezen van source en schrijven naar string ****
            If Not CurrentDr Is Nothing Then 'Dan gaat het om een enkel document
                DataStream = DataRow2StringBuilder(DataStream, CurrentDr)
                CurrentDr = Nothing

            Else 'anders de selectie uitvoeren

                DataStream = DataTable2StringBuilder(DataStream, dtWord)

            End If

        Catch ex As Exception
            Throw New Exception("Probeem met maken van de mergebestand!")
        End Try


        '*** verwijder de laatste enter tervoorkoming van lege record ****
        'If strData.EndsWith(vbCrLf) Then strData = strData.Remove(strData.Length - 1)

        '*** schrijf de data weg naar mailing.txt voor merge ****
        Dim objStreamWriter As StreamWriter
        Try
            objStreamWriter = File.AppendText(ExportFileName)
            objStreamWriter.Write(DataStream.ToString.TrimEnd)
            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Het wegschrijven van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer uw schrijfrechten" & vbCrLf & ex.Message)
        End Try

        If Not MailingtxtOnly Then 'anders alleen verder met wordmerge 
            '*** Creer Word object en open de template ****
            Dim objWord As New Word.Application
            Dim objDoc As Word.Document
            Try
                objWord.Application.WindowState = 0 'wdWindowStateNormal = 0
                objDoc = objWord.Documents.Add(MasterDocName)
                Dim NameBeforeWordMerge As String = objWord.ActiveDocument.Name
                objWord.Visible = True

                '*** voer de mailmerge uit ****

                With objWord.ActiveDocument.MailMerge
                    .OpenDataSource(ExportFileName)
                    .SuppressBlankLines = True
                    .Execute(Pause:=True)
                End With

                Dim NameAfterWordMerge As String = objWord.ActiveDocument.Name
                objWord.Documents(NameBeforeWordMerge).Close(0)
                objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMinimize
                objWord.Documents(NameAfterWordMerge).Activate()
                objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMaximize

            Catch ex As Exception
                Throw New Exception("Het samenvoegen is mislukt!" & vbCrLf & ex.Message)
            End Try
        End If
        Result = "klaar"
    End Sub
    Private Function DataRow2StringBuilder(ByVal stringbuilder As StringBuilder, ByVal dr As DataRow) As StringBuilder
        Dim sb As StringBuilder = stringbuilder
        Dim lastColumn As Integer = dr.Table.Columns.Count
        Dim indexer As Integer = 1

        For Each col As DataColumn In dr.Table.Columns
            If indexer = lastColumn Then
                sb.Append(col.ColumnName)
            Else
                sb.Append(col.ColumnName & ";")
            End If
            indexer += 1
        Next

        sb.AppendLine()

        lastColumn = dr.Table.Columns.Count
        indexer = 1
        For Each col As DataColumn In dr.Table.Columns
            If indexer = lastColumn Then
                sb.Append(dr.Item(col).ToString())
            Else
                sb.Append(dr.Item(col).ToString() & ";")
            End If
            indexer += 1
        Next

        sb.AppendLine()

        Return sb
    End Function
    Private Function DataTable2StringBuilder(ByVal stringbuilder As StringBuilder, ByVal dt As DataTable) As StringBuilder
        Dim sb As StringBuilder = stringbuilder
        Dim lastColumn As Integer = dtWord.Columns.Count
        Dim indexer As Integer = 1

        For Each col As DataColumn In dtWord.Columns
            If indexer = lastColumn Then
                If Not col.ColumnName.ToLower = "notities" Then sb.Append(col.ColumnName)
            Else
                If Not col.ColumnName.ToLower = "notities" Then sb.Append(col.ColumnName & ";")
            End If
            indexer += 1
        Next

        sb.AppendLine()

        lastColumn = dtWord.Columns.Count
        indexer = 1
        For Each dr As DataRow In dtWord.Rows
            For Each col As DataColumn In dtWord.Columns
                If indexer = lastColumn Then
                    sb.Append(dr.Item(col).ToString())
                Else
                    sb.Append(dr.Item(col).ToString() & ";")
                End If
                indexer += 1
            Next
            sb.AppendLine()
        Next

        Return sb

    End Function
    Public Function MergeIBB(ByVal templateId As Integer, ByVal MyIBBDossier As IBBDossier, Optional ByVal bSave As Boolean = False, Optional ByVal bConcept As Boolean = False) As Boolean

        Dim bResult As Boolean = False
        Dim ExportFileName As String = ""
        Dim MasterDocName As String = ""
        Dim Mailing As Boolean = False
        Dim MyTemplate As New BusinessObjects.tblTemplates(templateId)
        Dim DataStream As StringBuilder = New StringBuilder


        If MyTemplate.Found Then
            MasterDocName = MyTemplate.DefaultLocation
            If Not MasterDocName.EndsWith("\") Then MasterDocName &= "\"
            MasterDocName &= MyTemplate.Afdeling & MyTemplate.Naam
        End If

        ExportFileName = DataSource

        If Not File.Exists(MasterDocName) Then
            Throw New Exception("Het sjabloon " & MasterDocName & " kan niet worden gevonden!")
        End If

        Try '*** kijk of mailing.txt al bestaat, zoja gooi het weg ****
            If File.Exists(ExportFileName) Then
                File.Delete(ExportFileName)
            End If
        Catch ex As Exception
            Throw New Exception("Het verwijderen van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer de rechten" & vbCrLf & ex.Message)
        End Try


        '*** kijk of MasterDocName bestaat, zo niet geef error ****
        If Not MailingtxtOnly AndAlso File.Exists(MasterDocName) = False Then
            Throw New Exception(MasterDocName & " bestaat niet!")
        End If

        Dim myFileSavePath As New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
        If Not myFileSavePath.Found Then Throw New Exception("Systeeminstellingen voor FileSave niet gevonden!")


        Dim DocNaam As String = MyIBBDossier.DossierNr & Format(Now, "HHmmss")

        Try '*** uitlezen van source en schrijven naar string ****
            If Not CurrentDr Is Nothing Then 'Dan gaat het om een enkel document
                CurrentDr.Item("DocNaam") = DocNaam
                Dim dt As DataTable = CurrentDr.Table

                Dim column As DataColumn
                column = New DataColumn()
                column.DataType = Type.GetType("System.String")
                column.ColumnName = "DossierNr"
                dt.Columns.Add(column)
                dt.Rows(0).Item("DossierNr") = MyIBBDossier.DossierNr

                column = New DataColumn()
                column.DataType = Type.GetType("System.String")
                column.ColumnName = "DossierOnderwerp"
                dt.Columns.Add(column)
                dt.Rows(0).Item("DossierOnderwerp") = MyIBBDossier.Onderwerp

                DataStream = DataRow2StringBuilder(DataStream, dt.Rows(0))


            Else 'anders de selectie uitvoeren                      
                Mailing = True
                DataStream = DataTable2StringBuilder(DataStream, dtWord)

            End If
        Catch ex As Exception
            Throw New Exception("Probeem met maken van het virtuele mergebestand!")
        End Try

        '*** schrijf de data weg naar mailing.txt voor merge ****
        Dim objStreamWriter As StreamWriter
        Try
            objStreamWriter = File.AppendText(ExportFileName)
            objStreamWriter.Write(DataStream.ToString.TrimEnd)
            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Het wegschrijven van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer schrijfrechten" & vbCrLf & ex.Message)
        End Try

        If Not MailingtxtOnly Then 'anders alleen verder met wordmerge 
            '*** Creer Word object en open de template ****
            Dim objWord As New Word.Application
            Dim objDoc As Word.Document
            Try
                objWord.Application.WindowState = 0 'wdWindowStateNormal = 0
                objDoc = objWord.Documents.Add(MasterDocName)
                Dim NameBeforeWordMerge As String = objWord.ActiveDocument.Name
                objWord.Visible = True

                '*** voer de mailmerge uit ****

                With objWord.ActiveDocument.MailMerge
                    .OpenDataSource(ExportFileName)
                    .SuppressBlankLines = True
                    .Execute(Pause:=True)
                End With

                Dim NameAfterWordMerge As String = objWord.ActiveDocument.Name
                objWord.Documents(NameBeforeWordMerge).Close(0)
                objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMinimize
                objWord.Documents(NameAfterWordMerge).Activate()
                objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMaximize
                objWord.ActiveDocument.Fields.Unlink()

                If Not Mailing Then
                    Dim myNewFilePath As String = myFileSavePath.Waarde & "\" & MyIBBDossier.DossierNr
                    CheckPathExists(myNewFilePath)
                    If bSave Then objWord.ActiveDocument.SaveAs(myNewFilePath & "\" & DocNaam) '& ".doc")
                End If

            Catch ex As Exception
                Throw New Exception("Het samenvoegen is mislukt!" & vbCrLf & ex.Message)
            End Try

            If Not Mailing Then
                'maak een record aan tbv documenten 
                If bSave Then
                    Dim NewDocument As New IBBDocument
                    With NewDocument
                        .Location = objWord.ActiveDocument.FullName
                        .LidId = MyIBBDossier.LidId
                        .jdTypeId = 0
                        .DossierId = MyIBBDossier.Id
                        .Onderwerp = MyTemplate.Omschrijving 'DocNaam & "_" & MyTemplate.Omschrijving
                        .Template = MyTemplate.Naam
                        .CreateDate = Now
                        .CreatedBy = URights.UserName
                        .Concept = bConcept
                        .Save()
                    End With
                End If
            End If

        End If

        bResult = True
        Return bResult

    End Function
    Public Function Merge(ByVal templateId As Integer, ByVal myRelatie As Relaties, _
                          Optional ByVal bSave As Boolean = False) As Boolean

        Dim bResult As Boolean = False
        Dim ExportFileName As String = ""
        Dim MasterDocName As String = ""
        Dim Mailing As Boolean = False
        Dim MyTemplate As New BusinessObjects.tblTemplates(templateId)
        Dim DataStream As StringBuilder = New StringBuilder

        If MyTemplate.Found Then
            MasterDocName = MyTemplate.DefaultLocation
            If Not MasterDocName.EndsWith("\") Then MasterDocName &= "\"
            MasterDocName &= MyTemplate.Afdeling & MyTemplate.Naam
        End If

        ExportFileName = DataSource

        If Not File.Exists(MasterDocName) Then
            Throw New Exception("Het sjabloon " & MasterDocName & " kan niet worden gevonden!")
        End If

        Try '*** kijk of mailing.txt al bestaat, zoja gooi het weg ****
            If File.Exists(ExportFileName) Then
                File.Delete(ExportFileName)
            End If
        Catch ex As Exception
            Throw New Exception("Het verwijderen van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer de rechten" & vbCrLf & ex.Message)
        End Try


        '*** kijk of MasterDocName bestaat, zo niet geef error ****
        If Not MailingtxtOnly AndAlso File.Exists(MasterDocName) = False Then
            Throw New Exception(MasterDocName & " bestaat niet!")
        End If

        Dim myFileSavePath As New Systeeminstellingen("FileSave", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
        If Not myFileSavePath.Found Then Throw New Exception("Systeeminstellingen voor FileSave niet gevonden!")

        Dim DocNaam As String = myRelatie.lidnr & Format(Now, "HHmm")

        Try '*** uitlezen van source en schrijven naar string ****
            If Not CurrentDr Is Nothing Then 'Dan gaat het om een enkel document
                CurrentDr.Item("DocNaam") = DocNaam
                DataStream = DataRow2StringBuilder(DataStream, CurrentDr)

            Else 'anders de selectie uitvoeren
                Mailing = True
                DataStream = DataTable2StringBuilder(DataStream, dtWord)

            End If
        Catch ex As Exception
            Throw New Exception("Probeem met maken van het virtuele mergebestand!")
        End Try

        '*** schrijf de data weg naar mailing.txt voor merge ****
        Dim objStreamWriter As StreamWriter
        Try
            objStreamWriter = File.AppendText(ExportFileName)
            objStreamWriter.Write(DataStream.ToString.TrimEnd)
            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Het wegschrijven van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer schrijfrechten" & vbCrLf & ex.Message)
        End Try

        If Not MailingtxtOnly Then 'anders alleen verder met wordmerge 
            '*** Creer Word object en open de template ****
            Dim objWord As New Word.Application
            Dim objDoc As Word.Document
            Try
                objWord.Application.WindowState = 0 'wdWindowStateNormal = 0
                objDoc = objWord.Documents.Add(MasterDocName)
                Dim NameBeforeWordMerge As String = objWord.ActiveDocument.Name
                objWord.Visible = True

                '*** voer de mailmerge uit ****

                With objWord.ActiveDocument.MailMerge
                    .OpenDataSource(ExportFileName)
                    .SuppressBlankLines = True
                    .Execute(Pause:=True)
                End With

                Dim NameAfterWordMerge As String = objWord.ActiveDocument.Name
                objWord.Documents(NameBeforeWordMerge).Close(0)
                objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMinimize
                objWord.Documents(NameAfterWordMerge).Activate()
                objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMaximize

                objWord.ActiveDocument.Fields.Unlink()

                If Not Mailing Then
                    Dim myNewFilePath As String = myFileSavePath.Waarde & "\" & myRelatie.Id
                    CheckPathExists(myNewFilePath)
                    If bSave Then objWord.ActiveDocument.SaveAs(myNewFilePath & "\" & DocNaam) '& ".doc")
                End If

            Catch ex As Exception
                Throw New Exception("Het samenvoegen is mislukt!" & vbCrLf & ex.Message)
            End Try

            If Not Mailing Then
                'maak een record aan tbv documenten geschiedenis
                If bSave Then
                    Dim NewDocument As New Documents
                    With NewDocument
                        .CreateDate = Now
                        .CreatedBy = URights.UserName
                        .Location = objWord.ActiveDocument.FullName
                        .RefID = ""
                        .LidId = myRelatie.Id
                        .Template = MyTemplate.Naam
                        .Save()
                    End With
                End If
            End If
        End If

        'If File.Exists(ExportFileName) Then
        '    File.Delete(ExportFileName)
        'End If

        bResult = True
        Return bResult

    End Function
    Public Function MergeSingle(ByVal templateId As Integer, ByVal myDr As DataRow) As String

        Dim bResult As Boolean = False
        Dim ExportFileName As String = ""
        Dim MasterDocName As String = ""
        Dim Mailing As Boolean = False
        Dim MyTemplate As New BusinessObjects.tblTemplates(templateId)
        Dim DataStream As StringBuilder = New StringBuilder
        Dim SavedAs As String = ""

        If MyTemplate.Found Then
            MasterDocName = MyTemplate.DefaultLocation
            If Not MasterDocName.EndsWith("\") Then MasterDocName &= "\"
            MasterDocName &= MyTemplate.Afdeling & MyTemplate.Naam
        End If

        DataStream = DataRow2StringBuilder(DataStream, myDr)
        ExportFileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\merge_" & myDr("lidnr") & ".txt"

        If Not File.Exists(MasterDocName) Then _
             Throw New Exception("Het sjabloon " & MasterDocName & " kan niet worden gevonden!")

        Try '*** kijk of ...txt al bestaat, zoja gooi het weg ****
            If File.Exists(ExportFileName) Then File.Delete(ExportFileName)
        Catch ex As Exception
            Throw New Exception("Het verwijderen van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer de rechten" & vbCrLf & ex.Message)
        End Try

        '*** kijk of MasterDocName bestaat, zo niet geef error ****
        If Not MailingtxtOnly AndAlso File.Exists(MasterDocName) = False Then _
                                    Throw New Exception(MasterDocName & " bestaat niet!")

        '*** schrijf de data weg naar mailing.txt voor merge ****
        Dim objStreamWriter As StreamWriter
        Try
            objStreamWriter = File.AppendText(ExportFileName)
            objStreamWriter.Write(DataStream.ToString.TrimEnd)
            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Het wegschrijven van " & ExportFileName & " is mislukt!" & vbCrLf & _
                                    "Controleer schrijfrechten" & vbCrLf & ex.Message)
        End Try

              '*** Creer Word object en open de template ****
        Dim objWord As New Word.Application
        Dim objDoc As Word.Document
        Dim DocNaam As String = myDr("lidnr") & Format(Now, "HHmm")

            Try
            objWord.Application.WindowState = 0
            objDoc = objWord.Documents.Add(MasterDocName)
            objWord.Visible = True

            Dim NameBeforeWordMerge As String = objWord.ActiveDocument.Name

                '*** voer de mailmerge uit ****
            ' With objWord.ActiveDocument.MailMerge
            With objDoc.MailMerge
                .OpenDataSource(ExportFileName)
                .MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters
                .Destination = Word.WdMailMergeDestination.wdSendToNewDocument
                .Execute()
            End With

            'Dim NameAfterWordMerge As String = objWord.ActiveDocument.Name
            'objWord.Documents(NameBeforeWordMerge).Close(0)
            'objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMinimize
            'objWord.Documents(NameAfterWordMerge).Activate()
            objWord.ActiveDocument.Fields.Unlink()
            'objWord.Application.WindowState = Word.WdWindowState.wdWindowStateMaximize
            objDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)

            objWord.ActiveDocument.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & DocNaam)
            objWord.ActiveDocument.Fields.Unlink()
            SavedAs = objWord.ActiveDocument.FullName

            objWord.ActiveDocument.Close(False)
            objWord.Quit()

        Catch ex As Exception
            Throw New Exception("Het samenvoegen is mislukt!" & vbCrLf & ex.Message)
        End Try

        Return SavedAs

    End Function
    Private Function FormatMergeText(ByVal value As String) As String
        Dim result As String = ""
        If Not String.IsNullOrEmpty(value) Then
            Dim strReader As New StringReader(value)
            Dim sLine As String = ""
            While True
                If strReader Is Nothing Then Exit While
                sLine = strReader.ReadLine()
                If sLine Is Nothing Then
                    Exit While
                ElseIf String.IsNullOrEmpty(sLine.Trim) Then
                    'Exit While
                Else
                    result &= sLine
                End If

            End While


        End If
        Return result

    End Function
#Region "Properties"
    Public Property dtWord() As DataTable
        Get
            Return m_dtWord
        End Get
        Set(ByVal value As DataTable)
            '*** ivm problemen van het notitieveld deze eerst verwijderen ****
            If value.Columns.Contains("Notities") Then
                value.Columns.Remove("Notities")
            End If
            m_dtWord = value
        End Set
    End Property
    Public Property dsWord() As DataSet
        Get
            Return m_dsWord
        End Get
        Set(ByVal value As DataSet)
            m_dsWord = value
        End Set
    End Property
    Public Property CurrentDr() As DataRow
        Get
            CurrentDr = m_CurrentDr
        End Get
        Set(ByVal value As DataRow)
            m_CurrentDr = value
        End Set
    End Property
    Public Property TemplatePath() As String
        Get
            TemplatePath = m_TemplatePath
        End Get
        Set(ByVal value As String)
            m_TemplatePath = value
        End Set
    End Property
    Public Property Template() As String
        Get
            Template = m_Template
        End Get
        Set(ByVal value As String)
            m_Template = value
        End Set
    End Property
    Private _DataSource As String
    Public Property DataSource() As String
        Get
            Return _DataSource
        End Get
        Set(ByVal value As String)
            _DataSource = value
        End Set
    End Property


    Public Property MailingtxtOnly() As Boolean
        Get
            Return m_MailingtxtOnly
        End Get
        Set(ByVal value As Boolean)
            m_MailingtxtOnly = value
        End Set
    End Property
    Public Property Result() As String
        Get
            Return m_Result
        End Get
        Set(ByVal value As String)
            m_Result = value
        End Set
    End Property
#End Region

End Class
