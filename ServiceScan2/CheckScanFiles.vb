Imports BusinessObjects
Imports System.Text
Imports System.IO

Public Class CheckScanFiles
    Public Event GenerateComplete(ByVal ready As Boolean)
    Public Event GenerateExp(ByVal Exp As Exception)
    Public LogFilepath As String = "D:"

    Public da As DataAccess
    Public ServiceSettings As ServiceSettings

    Public Sub New(AlternativeConfig As String)
        Try
            da = New DataAccess(AlternativeConfig)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub
    Public Sub Process()
        Try

            Dim sbLog As New StringBuilder
            Dim sbErrorLog As New StringBuilder
            Dim sPath As String = LogFilepath & "\logs"
            Dim OpeningLog As New StringBuilder


            Dim FileListQueue As New List(Of IO.FileInfo)
            Dim diQueue As New IO.DirectoryInfo(ServiceSettings.MyProperties.ScanDir)

            Dim ExtensionsString As String = ServiceSettings.MyProperties.Extensions ' "*.pdf;*.docx"
            Dim ExtensionList As Array = ExtensionsString.Split(";")

            For Each ext As String In ExtensionList
                FileListQueue.AddRange(diQueue.GetFiles(ext, IO.SearchOption.AllDirectories))
            Next


            Dim _Document As IBBDocument
            Dim b2Succes As Boolean = False
            Dim b2Wissel As Boolean = False

            If FileListQueue.Count > 0 Then
                For Each _file As IO.FileInfo In FileListQueue
                    b2Succes = False
                    'controleer of er een setting.ini file aanwezig is.
                    Dim CheckIniFile As New FileInfo(_file.Directory.FullName & "\settings.ini")
                    ' indien niet het geval, dan dit bestand overslaan
                    If Not CheckIniFile.Exists Then Continue For
                    ' indien wel, dan gegevens uitlezen voor opslag en verwerking
                    Dim myIniFile As New IniFile(_file.Directory.FullName & "\settings.ini")
                    Dim bSendMail As Boolean = myIniFile.GetBoolean("scan", "SendMail2", False)
                    Dim IniDocumentMap As String = myIniFile.GetString("scan", "DocumentMap", "")
                    Dim bConcept As Boolean = myIniFile.GetBoolean("scan", "Concept", False)

                    b2Wissel = False
                    'Vervang eventuele spatie door streepje en pak hem opnieuw op
                    If _file.Name.Contains(" ") Then
                        _file.MoveTo(_file.FullName.Replace(" ", "_"))
                        Continue For
                    End If


                    Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                    If Not DocumentPathSetting.Found Then Throw New Exception("Geen Systeeminstellingen voor IBBFiles gevonden!")
                    Dim DocumentPath As String = DocumentPathSetting.Waarde & "\"

                    Dim selectedFase As Integer = 0
                    Dim newDocument As New IBBDocument
                    Dim GetFileInfo As New SplitFileName(_file)
                    Dim myDossierId As Integer = getDossierIdByNbr(GetFileInfo.DossierNr)

                    If myDossierId > 0 Then
                        Try
                            With newDocument
                                Dim newName As String = ProcessFileName(GetFileInfo)
                                .Template = _file.FullName
                                .jdTypeId = selectedFase
                                .DossierId = myDossierId
                                .Onderwerp = GetFileInfo.FileNameNoExtension
                                .CreateDate = Now
                                .CreatedBy = "scan"
                                .Concept = bConcept
                                .LocationType = "IBB"
                                _file.MoveTo(DocumentPath & GetFileInfo.DossierNr & "\" & newName & _file.Extension)
                                .Location = DocumentPath & GetFileInfo.DossierNr & "\" & newName & _file.Extension
                                .Save()
                                b2Succes = True
                            End With
                        Catch ex As Exception
                            EventLog.WriteEntry("VBMservices", "Scan2Ibb Process newDocument error:" & GetFileInfo.OriginalFileName & " - " & ex.Message, EventLogEntryType.Error)
                            'Throw ex
                            Continue For
                        End Try

                    Else

                    End If


                    'If b2Succes Then
                    '   If bSendMail Then .sendmail()
                    'End If

                    'Schrijf het resultaat weg in logfile
                    WriteLog(_file.CreationTime & ";" & _file.Name & ";" & GetFileInfo.DossierNr & ";" & b2Succes.ToString, b2Succes)

                    If Not b2Succes Then
                        'niet gelukt dan verplaatsen om een loop te voorkomen.
                        Dim di As New DirectoryInfo(ServiceSettings.MyProperties.ScanDir & "\False\")
                        If Not di.Exists Then di.Create()
                        Dim newName As String = _file.Name
                        Dim TestFile As New IO.FileInfo(di.FullName & newName)
                        Dim i As Integer = 1
                        Do Until TestFile.Exists = False
                            newName = i & "_" & _file.Name
                            TestFile = New IO.FileInfo(di.FullName & newName)
                            i += 1
                        Loop
                        _file.MoveTo(di.FullName & newName)
                    End If
                Next
            End If

            FileListQueue = Nothing
            _Document = Nothing

            RaiseEvent GenerateComplete(True)

        Catch ex As Exception
            EventLog.WriteEntry("VBMservices", "Scan2Ibb Process Catch error:" & ex.Message, EventLogEntryType.Error)
            RaiseEvent GenerateExp(ex)
            'RaiseEvent GenerateComplete(True)
        End Try
    End Sub

    Public Function ProcessFileName(ByVal myfile As SplitFileName) As String
        Try

            Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            If Not DocumentPathSetting.Found Then Throw New Exception("Geen Systeeminstellingen voor IBBFiles gevonden!")
            Dim DocumentPath As String = DocumentPathSetting.Waarde & "\"

            Dim bestandsNaam As String

            'controleer of dit bestand al bestaat en zoja voeg er _x (teller) aan toe
            Dim iCounter As Integer = 0
            Dim bExist As Boolean = True
            Dim fiTmp As IO.FileInfo
            bestandsNaam = myfile.FileNameNoExtension
            Dim Toevoeging As String = ""

            Dim di As New IO.DirectoryInfo(DocumentPath & myfile.DossierNr)
            If Not di.Exists Then di.Create()

            Do While bExist = True
                fiTmp = New IO.FileInfo(DocumentPath & myfile.DossierNr & "\" & bestandsNaam & Toevoeging & myfile.FileExtension)
                bExist = fiTmp.Exists
                If Not bExist Then Exit Do
                iCounter += 1
                Toevoeging = "_" & iCounter
            Loop

            Return bestandsNaam & Toevoeging

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function getDossierIdByNbr(DossierNr As String) As Int32
        Dim result As Int32 = -1
        Try
            Dim sql As String = "SELECT Id FROM IBBDossiers where dossiernr = @dossiernr"
            Dim param() As Object = {"@dossiernr", DossierNr}
            result = da.ExecuteScalar(sql, param)

            Return result

        Catch ex As Exception
            EventLog.WriteEntry("Scan2Ibb Service", "getDossierIdByNb: " & DossierNr & ", " & ex.Message, EventLogEntryType.Error)
            Return result
        End Try
    End Function

    Public Sub WriteLog(ByVal sLog As String, ByVal succes As Boolean)
        Dim di As New IO.DirectoryInfo(ServiceSettings.MyProperties.ScanDir & "\Logs")
        If Not di.Exists Then di.Create()

        Dim fs As IO.FileStream = IO.File.Open(di.FullName & "\" & Format(Today, "yyyyMMdd") & succes.ToString & ".Log", IO.FileMode.Append, IO.FileAccess.Write)
        Dim sw As New IO.StreamWriter(fs)
        Try
            sw.WriteLine(Now & "; " & sLog)
        Catch ex As System.IO.IOException
            EventLog.WriteEntry("Scan2Ibb Service", "WriteLOG: " & ex.Message, EventLogEntryType.Error)
        Finally
            If Not (sw Is Nothing) Then sw.Close()
        End Try
    End Sub
    Public Function ReadLog(ByVal succes As Boolean) As StreamReader
        Try
            Dim sr As StreamReader = Nothing
            Dim di As New DirectoryInfo(ServiceSettings.MyProperties.ScanDir & "\Logs")
            If Not di.Exists Then di.Create()

            Dim _fi As New FileInfo(di.FullName & "\" & Format(Today, "yyyyMMdd") & succes.ToString & ".Log")
            If Not _fi.Exists Then
                Dim sw As StreamWriter = _fi.CreateText()
                sw.WriteLine(";;;;;")
                sw.Flush()
                sw.Close()
                _fi = New FileInfo(di.FullName & "\" & Format(Today, "yyyyMMdd") & succes.ToString & ".Log")
                sr = _fi.OpenText()
            Else
                sr = _fi.OpenText()
            End If
            Return sr


        Catch ex As System.IO.IOException
            EventLog.WriteEntry("Scan2Ibb Service", "ReadLOG: " & ex.Message, EventLogEntryType.Error)
            Return Nothing
        End Try
    End Function
End Class
Public Class SplitFileName

    Public Sub New(ByVal filename As IO.FileInfo)
        Try
            OriginalFileName = filename.Name
            If OriginalFileName.Contains("_") Then
                DossierNr = OriginalFileName.Substring(0, OriginalFileName.IndexOf("_"))
                StriptFileName = OriginalFileName.Substring(OriginalFileName.IndexOf("_") + 1)
            Else
                DossierNr = (OriginalFileName.Length - filename.Extension.Length)
                StriptFileName = "geen_onderwerp"
            End If

            FileExtension = filename.Extension
            FileNameNoExtension = StriptFileName.Remove(StriptFileName.Length - filename.Extension.Length)

        Catch ex As Exception
            EventLog.WriteEntry("Scan2Ibb", "SplitFileName error:" & ex.Message, EventLogEntryType.Error)
            'Throw ex
        End Try

    End Sub

    Private _OriginalFileName As String = String.Empty
    Private _FileExtension As String = String.Empty
    Private _StriptFileName As String = String.Empty
    Private _DossierNr As String = String.Empty
    Private _FileNameNoExtension As String = String.Empty
    Public Property FileNameNoExtension() As String
        Get
            Return _FileNameNoExtension
        End Get
        Set(ByVal value As String)
            _FileNameNoExtension = value
        End Set
    End Property

    Public Property OriginalFileName() As String
        Get
            Return _OriginalFileName
        End Get
        Set(ByVal value As String)
            _OriginalFileName = value
        End Set
    End Property

    Public Property FileExtension() As String
        Get
            Return _FileExtension
        End Get
        Set(ByVal value As String)
            _FileExtension = value
        End Set
    End Property


    Public Property StriptFileName() As String
        Get
            Return _StriptFileName
        End Get
        Set(ByVal value As String)
            _StriptFileName = value
        End Set
    End Property

    Public Property DossierNr() As String
        Get
            Return _DossierNr
        End Get
        Set(ByVal value As String)
            _DossierNr = value
        End Set
    End Property
End Class