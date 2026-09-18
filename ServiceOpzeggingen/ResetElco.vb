Imports BusinessObjects
Imports System.Text

Public Class ResetElco
    ' De service van de relatie-app dusdanig aanpassen dat elco nummers op 0 worden gezet voor alle leden 
    ' die vallen in de lidsoorten Militair postactief of Burger postactief of Nationale reserve met ingangsdatum <= vandaag 
    ' Dit moet ook gelogd worden. 

    '1) Haal de lidsoort ID's op uit de tabel lidsoorten waar resetplaatsing  = true
    '2) Haal alle records op uit tabel lidsoortperioden met lidsoortid uit stap 1 waar ingangsdatum <= vandaag
    '3) voor ieder record de relatie ophalen en controleren of dit de huidige lidsoort is.
    '4) zo ja dan plaatsing op 0 zetten
    '5) en in verslag zetten.

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
    Private _ResetIdList As List(Of Integer)
    Public ReadOnly Property ResetIdList() As List(Of Integer)
        Get
            If _ResetIdList Is Nothing Then
                _ResetIdList = GetResetIds()
            End If
            Return _ResetIdList
        End Get
    End Property

    Private Function GetResetIds() As List(Of Integer)
        Try
            Dim ResetIds As New List(Of Integer)
            Dim sql As String = "select Lidsoorten.Id from Lidsoorten where ResetPlaatsing = 1"
            Dim dt As Data.DataTable
            dt = da.ExecuteDataTable(sql)

            For Each dr As DataRow In dt.Rows
                ResetIds.Add(dr.Item("Id"))
            Next

            Return ResetIds
        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
            Return Nothing
        End Try
    End Function
    Private _LidSoortPeriods As DataTable
    Public ReadOnly Property LidSoortPeriods() As DataTable
        Get
            If _LidSoortPeriods Is Nothing Then
                _LidSoortPeriods = GetLidSoortPeriods()
            End If
            Return _LidSoortPeriods
        End Get
    End Property

    Private Function GetLidSoortPeriods() As DataTable
        Try
            Dim dt As Data.DataTable
            Dim params As New ArrayList
            Dim sb As New StringBuilder
            sb.Append("SELECT * FROM Lidsoortperioden WHERE lidsoortid IN (")


            For i As Integer = 0 To ResetIdList.Count - 1
                If 0 <> i Then
                    sb.Append(",")
                End If
                sb.Append("@in" & i)

                params.Add("@in" & i)
                params.Add(ResetIdList(i))
            Next

            sb.Append(") AND datumin <= @DateIn")
            params.Add("@DateIn")
            params.Add(Today)

            'Dim sql As String = "SELECT * FROM Lidsoortperioden " & _
            '                    "WHERE lidsoortid in (3,4,8) AND datumin <= GETDATE()"

            dt = da.ExecuteDataTable(sb.ToString, params.ToArray)

            Return dt
        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
            Return Nothing
        End Try
    End Function
    Public Sub Process()
        Dim result As Boolean = False
        Dim relatie As Relaties
        Dim sbLog As New StringBuilder
        Dim iCounter As Integer = 0
        Dim sPath As String = LogFilepath & "\logs"

        Try


            sbLog.Append("Verslag reset plaatsing Service:" & vbCrLf)
            sbLog.Append("Datum:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf)
            sbLog.Append("Databaserver:" & ServiceSettings.MyProperties.ServerIP & vbCrLf)
            sbLog.Append("Database:" & ServiceSettings.MyProperties.DataBase & vbCrLf)
            sbLog.Append("Service User:" & ServiceSettings.MyProperties.Account & vbCrLf)

            WriteFile(sPath & "\Verslag_Reset plaatsing_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbLog.ToString)

            sbLog = New StringBuilder

            For Each dr As DataRow In LidSoortPeriods.Rows
                relatie = New Relaties(dr.Item("lidid"), Relaties.Via.ID)
                If relatie.Found Then
                    If relatie.plaatsing > 0 Then
                        If relatie.CurrentPeriode.lidsoortid = dr.Item("lidsoortid") Then
                            relatie.plaatsing = 0
                            relatie.SaveByNSK()
                            sbLog.Append("lidNr: " & relatie.lidnr & vbCrLf)
                            iCounter += 1
                        End If
                    End If
                End If
            Next

            sbLog.Append("Aantal verwerkt:" & iCounter & vbCrLf & vbCrLf)
            sbLog.Append("Datum verwerkt:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf)

            WriteFile(sPath & "\Verslag_Reset plaatsing_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbLog.ToString, True)
            RaiseEvent GenerateComplete(True)

        Catch ex As Exception
            EventLog.WriteEntry("VBMservices", "reset Elco Process error:" & ex.Message, EventLogEntryType.Error)
            RaiseEvent GenerateExp(ex)
        End Try

    End Sub
End Class
