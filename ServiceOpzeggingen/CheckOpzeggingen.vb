Imports BusinessObjects
Imports System.Text


Public Class CheckOpzeggingen
    'haal alle relaties op met de volgende voorwaarde
    '1) datum opzegging = vandaag of ouder
    '2) status = 0 (is actief)

    'Zet bij die relaties de status op 1 (is historie)
    ' en als Het een NSK is dan ook de NSK afmeldatum vullen.

    'lastRunDate
    'lastRunTime
    'Hoeveelheid
    'verslag?
    Public Event GenerateComplete(ByVal ready As Boolean)
    Public Event GenerateExp(ByVal Exp As Exception)
    Public LogFilepath As String = ""
    Private ServiceSettings As ServiceSettings

    Private da As New DataAccess
    Public Sub New()
        ServiceSettings = New ServiceSettings(enServiceType.Opzeggingen)
        da = New DataAccess
        da.MyConnectionString = ServiceSettings.MyConnectionString
    End Sub


    Public Sub Process()
        Try

            Dim sb As StringBuilder
            Dim sbLog As New StringBuilder
            Dim paramDate As ArrayList
            Dim iCounter As Integer = 0
            Dim sPath As String = LogFilepath & "\logs"
            'System.Diagnostics.Debugger.Break()

            sbLog.Append("Verslag Opzegging Service:" & vbCrLf)
            sbLog.Append("Datum:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf)
            sbLog.Append("Databaserver:" & ServiceSettings.MyProperties.ServerIP & vbCrLf)
            sbLog.Append("Database:" & ServiceSettings.MyProperties.DataBase & vbCrLf)
            sbLog.Append("Service User:" & ServiceSettings.MyProperties.Account & vbCrLf)

            WriteFile(sPath & "\Verslag_Opzegging_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbLog.ToString)

            sbLog = New StringBuilder
            For Each row As DataRow In dtOpzeggingen.Rows
                sb = New StringBuilder
                paramDate = New ArrayList

                paramDate.Add("@id")
                paramDate.Add(row.Item("id"))
                paramDate.Add("@Dateout")
                paramDate.Add(Today)

                sb.Append("UPDATE relaties " & vbCrLf)
                sb.Append("SET status = 1  " & vbCrLf)
                'sb.Append(", NSKInOut = 1  " & vbCrLf)
                'sb.Append(", NSKDatum = @Dateout  " & vbCrLf)
                sb.Append("WHERE id = @id  " & vbCrLf & vbCrLf)
                da.ExecuteScalar(sb.ToString, paramDate.ToArray)
                iCounter += 1
                sbLog.Append("lidNr: " & row.Item("lidnr") & vbCrLf)
            Next
            sbLog.Append("Aantal verwerkt:" & iCounter & vbCrLf & vbCrLf)

            WriteFile(sPath & "\Verslag_Opzegging_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbLog.ToString, True)

            RaiseEvent GenerateComplete(True)
        Catch ex As Exception
            EventLog.WriteEntry("VBMservices", "CheckOpzeggingen Process error:" & ex.Message, EventLogEntryType.Error)
            RaiseEvent GenerateExp(ex)
            'RaiseEvent GenerateComplete(True)
        End Try
    End Sub

    Private _dtOpzeggingen As DataTable
    Public Property dtOpzeggingen() As DataTable
        Get
            If _dtOpzeggingen Is Nothing Then
                GetOpzeggingen()
            End If
            Return _dtOpzeggingen
        End Get
        Set(ByVal value As DataTable)
            _dtOpzeggingen = value
        End Set
    End Property

    Private Sub GetOpzeggingen()
        Try
            Dim dt As New DataTable
            Dim paramDate As New ArrayList

            paramDate.Add("@DateCheck")
            paramDate.Add(New Date(Today.Year, Today.Month, Today.Day))

            Dim sql As String = "SELECT relaties.id, lidnr, achternaam ,eindedatum " & _
                    "from  relaties " & _
                     "WHERE (eindedatum <= @DateCheck) AND Status = 0 "

            _dtOpzeggingen = da.ExecuteDataTable(sql, paramDate.ToArray)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GetResetLeden()
        Try
            Dim dt As New DataTable
            Dim paramDate As New ArrayList

            paramDate.Add("@DateCheck")
            paramDate.Add(New Date(Today.Year, Today.Month, Today.Day))

            Dim sql As String = "SELECT relaties.id, lidnr, achternaam ,eindedatum " & _
                    "from  relaties " & _
                     "WHERE (eindedatum <= @DateCheck) AND Status = 0 "

            _dtOpzeggingen = da.ExecuteDataTable(sql, paramDate.ToArray)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
