Imports System.IO
Imports Microsoft.Office.Interop
Imports BusinessObjects
Imports System.Text

Public Class MailingThread
    Private URights As UserRights = UserRights.Instance
    Public Event GenerateComplete(ByVal iCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)

    Public bAbort As Boolean = False
    Public bWrite2Correspondetie As Boolean = False
    Public CorrespondentieList As List(Of Documents)
    Private Counter As Integer = 0
    Private _MailingTable As DataTable = Nothing
    Public Property MailingTable() As DataTable
        Get
            Return _MailingTable
        End Get
        Set(ByVal value As DataTable)
            '*** ivm problemen van het notitieveld deze eerst verwijderen ****
            If value.Columns.Contains("Notities") Then
                value.Columns.Remove("Notities")
            End If
            _MailingTable = value
        End Set
    End Property
    Private _TemplateId As Integer = 0
    Public Property TemplateId() As Integer
        Get
            Return _TemplateId
        End Get
        Set(ByVal value As Integer)
            _TemplateId = value
        End Set
    End Property

    Private _IsTerminating As Boolean = False
    Public Property IsTerminating() As Boolean
        Get
            Return _IsTerminating
        End Get
        Set(ByVal value As Boolean)
            _IsTerminating = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub Process()
        Try
            If MailingTable Is Nothing Then
                RaiseEvent GenerateExp(New Exception("Er is nog geen data opgegeven!"))
            End If
            If MailingTable.Rows.Count = 0 Then
                RaiseEvent GenerateExp(New Exception("De opgegeven data bevat geen records!"))
            End If
            If TemplateId = 0 Then
                RaiseEvent GenerateExp(New Exception("Er is nog geen sjabloon opgegeven!"))
            End If

            CorrespondentieList = New List(Of Documents)
            Dim MyTemplate As New BusinessObjects.tblTemplates(TemplateId)
            Dim ExportFile As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\merge.txt"
            Dim MasterFile As String = String.Empty
            Dim DataStream As StringBuilder = New StringBuilder

            If MyTemplate.Found Then
                Dim TemplatePath As String = String.Empty

                If Not String.IsNullOrEmpty(MyTemplate.locatie) And Not String.Equals(MyTemplate.locatie, "\") Then
                    TemplatePath = MyTemplate.locatie
                Else
                    TemplatePath = MyTemplate.DefaultLocation & MyTemplate.Afdeling
                    'TemplatePath = MyTemplate.DefaultLocation
                End If
                If String.IsNullOrEmpty(MyTemplate.DefaultLocation) Then
                    RaiseEvent GenerateExp(New Exception("Er is nog geen locatie van sjabloon " & MyTemplate.Naam & " opgegeven!"))
                End If
                MasterFile = TemplatePath & MyTemplate.Naam
            End If

            If Not File.Exists(MasterFile) Then
                RaiseEvent GenerateExp(New Exception("Het sjabloon " & MasterFile & " kan niet worden gevonden!"))
                Throw New Exception("Het sjabloon " & MasterFile & " kan niet worden gevonden!")
            End If


            Try '*** kijk of ExportFile al bestaat, zoja gooi het weg ****
                RaiseEvent GenerateStatus("Bezig met verwijderen van oude mergefile")
                If File.Exists(ExportFile) Then File.Delete(ExportFile)
            Catch ex As Exception
                RaiseEvent GenerateExp(New Exception("Het verwijderen van " & ExportFile & " is mislukt!" & vbCrLf & _
                                         "Controleer de rechten" & vbCrLf & ex.Message))
            End Try


            Try '*** uitlezen van source en schrijven naar string ****
                RaiseEvent GenerateStatus("Bezig met schrijven van headers mergefile")

                Dim lastColumn As Integer = MailingTable.Columns.Count
                Dim indexer As Integer = 1

                For Each col As DataColumn In MailingTable.Columns
                    If indexer = lastColumn Then
                        DataStream.Append(col.ColumnName)
                    Else
                        DataStream.Append(col.ColumnName & ";")
                    End If

                    indexer += 1
                Next
                DataStream.AppendLine()

                'RaiseEvent GenerateStatus("Bezig met schrijven van data mergefile")
                For Each dr As DataRow In MailingTable.Rows
                    If IsTerminating Then
                        RaiseEvent GenerateStatus("IsTerminating")
                        RaiseEvent GenerateComplete(0)
                        Exit Sub
                    End If
                    Counter += 1

                    If Counter Mod 10 = 0 Then
                        RaiseEvent GenerateStatus("Bezig met schrijven van record " & Counter & " naar mergefile")
                        RaiseEvent GenerateCounter(Counter)
                    End If

                    lastColumn = MailingTable.Columns.Count
                    indexer = 1
                    For Each col As DataColumn In MailingTable.Columns
                        If indexer = lastColumn Then
                            DataStream.Append(dr.Item(col).ToString())
                        Else
                            DataStream.Append(dr.Item(col).ToString() & ";")
                        End If

                        indexer += 1
                    Next
                    DataStream.AppendLine()
                    'Als True dan regel wegschrijven naar de relatiekaart
                    If bWrite2Correspondetie Then
                        Dim NewDocument As New Documents
                        With NewDocument
                            .CreateDate = Now
                            .CreatedBy = URights.UserName
                            .Location = ""
                            .RefID = "mailing"
                            .LidId = dr.Item("Id").ToString
                            .Template = MyTemplate.Naam
                        End With
                        CorrespondentieList.Add(NewDocument)
                    End If
                Next
            Catch ex As Exception
                If Not bAbort Then RaiseEvent GenerateExp(New Exception("Probeem met maken van de mergebestand!"))
            End Try

            '*** verwijder de laatste enter tervoorkoming van lege record ****
            'If DataStream.EndsWith(vbCrLf) Then DataStream = DataStream.Remove(DataStream.Length - 1)

            '*** schrijf de data weg naar ExportFile voor merge ****
            Dim oStreamWriter As StreamWriter
            Try
                RaiseEvent GenerateStatus("Bezig met schrijven naar " & ExportFile)
                oStreamWriter = File.AppendText(ExportFile)
                oStreamWriter.Write(DataStream.ToString.TrimEnd)
                oStreamWriter.Close()
            Catch ex As Exception
                RaiseEvent GenerateExp(New Exception("Het wegschrijven van " & ExportFile & " is mislukt!" & vbCrLf & _
                                        "Controleer schrijfrechten" & vbCrLf & ex.Message))
            End Try

            '*** Creer Word object en open de template ****
            Dim oWord As New Word.Application
            Threading.Thread.Sleep(5)
            Dim oDoc As Word.Document = Nothing
            Try
                RaiseEvent GenerateStatus("Bezig openen template")
                oDoc = oWord.Documents.Open(MasterFile)
                oWord.Visible = True
            Catch ex As Exception
                RaiseEvent GenerateExp(New Exception("Het openen van Word is mislukt!" & vbCrLf & ex.Message))
                If Not oDoc Is Nothing Then oDoc.Close()
                If Not oWord Is Nothing Then oWord = Nothing

            End Try

            '*** voer de mailmerge uit ****
            Try
                RaiseEvent GenerateStatus("Bezig samenvoegen")
                With oWord.ActiveDocument.MailMerge
                    .OpenDataSource(ExportFile)
                    .SuppressBlankLines = True
                    .Execute()
                End With
                oWord.Activate()
                oDoc.Close(False)

                RaiseEvent GenerateStatus("Bezig met loggen naar relatiekaart")
                For Each doc As Documents In CorrespondentieList
                    doc.Save()
                Next


            Catch ex As Exception
                RaiseEvent GenerateExp(New Exception("Het samenvoegen is mislukt!" & vbCrLf & ex.Message))
            End Try

            RaiseEvent GenerateStatus("Klaar")
            RaiseEvent GenerateComplete(0)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub
   
End Class
