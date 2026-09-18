Imports BusinessObjects
Imports System.Text

Public Class CheckIBBCalendar

    Public Event GenerateComplete(ByVal ready As Boolean)
    Public Event GenerateExp(ByVal Exp As Exception)
    Public LogFilepath As String = "D:"

    Public MyConnectionString As String

    Public da As DataAccess

    Public Sub New()
        Try
            da = New DataAccess
        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Aanroepen indien er alternatieve settings moeten worden geladen ipv de file in de user appdata
    ''' </summary>
    ''' <param name="AlternativeConfig"></param>
    ''' <remarks></remarks>
    Public Sub New(AlternativeConfig As String)
        Try
            da = New DataAccess(AlternativeConfig)
        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub

    Private _ListIBBFases As List(Of IBBFase)
    Public ReadOnly Property ListIBBFases(Optional ByVal bRenew As Boolean = False) As List(Of IBBFase)
        Get
            If bRenew = True Then _ListIBBFases = Nothing
            If _ListIBBFases Is Nothing Then
                _ListIBBFases = New List(Of IBBFase)
                Dim ohelper As New Helper
                Dim sql As String = "Select * from IBBFases where besluit = @besluit"
                Dim param() As Object = {"@besluit", 0}
                _ListIBBFases = ohelper.MapDataTableToList(Of IBBFase)(da.ExecuteDataTable(sql, param))
            End If

            Return _ListIBBFases
        End Get
    End Property

    Private _jdTranslates As List(Of tbljdTranslate)
    Public ReadOnly Property jdTranslates(jdid As Integer) As List(Of tbljdTranslate)
        Get

            _jdTranslates = New List(Of tbljdTranslate)
            Dim ohelper As New Helper
            Dim sql As String = "SELECT * FROM jdTranslate WHERE JdTypeId = @JdTypeId"
            Dim param() As Object = {"@JdTypeId", jdid}
            _jdTranslates = ohelper.MapDataTableToList(Of tbljdTranslate)(da.ExecuteDataTable(sql, param))
            Return _jdTranslates
        End Get
    End Property

    Public Sub Process()
        Try

            'Haal alle "in afwachting" IBB fases op.
            'controleer via de translater of er agenda items kunnen zijn
            'controleer of er datum is
            'indien aanwezig of datum in de toekomst ligt
            'via Graph het agenda item ophalen en aanpassen als het al bestaat en nieuwe maken indien het niet bestaat
            'indien datum leeg is en entry niet, dan afspraak ophalen en verwijderen en entry verwijderen


            Dim sbLog As New StringBuilder
            Dim sbErrorLog As New StringBuilder
            Dim sPath As String = LogFilepath & "\logs"
            Dim OpeningLog As New StringBuilder

            OpeningLog.Append("****************************************************" & vbCrLf)
            OpeningLog.Append("Verslag IBB Agenda Service:" & vbCrLf)
            OpeningLog.Append("Datum:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf)
            OpeningLog.Append("Mailserver: Microsoft Graph (app-only)" & vbCrLf & vbCrLf)

            sbLog.Append(OpeningLog.ToString)
            sbErrorLog.Append(OpeningLog.ToString)

            Dim fs As IBBFase

            sbLog.Append("Aantal open fases:" & ListIBBFases.Count & vbCrLf & vbCrLf)

            For Each fs In ListIBBFases
                'Zou moeten werken maar nog niet getest
                fs.UpdateFutureAppointmentEWS(False)
                For Each msg In fs.AppointmentMsgList
                    sbLog.AppendLine(msg)
                Next
                For Each msg In fs.AppointmentErrorList
                    sbErrorLog.AppendLine(msg)
                Next

            Next

            sbLog.Append(vbCrLf & "Datum verwerkt:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf & "********************" & vbCrLf)
            WriteFile(sPath & "\Verslag_IBB_Agenda_items_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbLog.ToString, False)

            sbErrorLog.Append(vbCrLf & "Datum verwerkt:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf & "********************" & vbCrLf)
            WriteFile(sPath & "\Verslag_IBB_Agenda_Errors_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbErrorLog.ToString, True)

            RaiseEvent GenerateComplete(True)

        Catch ex As Exception
            EventLog.WriteEntry("VBMservices", "CheckIBBCalendar Process error:" & ex.Message, EventLogEntryType.Error)
            RaiseEvent GenerateExp(ex)
            'RaiseEvent GenerateComplete(True)
        End Try
    End Sub

End Class
