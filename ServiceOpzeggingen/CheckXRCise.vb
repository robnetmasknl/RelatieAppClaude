
Imports BusinessObjects
    Imports System.Text

Public Class CheckXRCise

    ' Per einde jaar Of periodiek uitvoeren bij de VBM 
    'insert into History (Lidid, Mutdate , mutdoor, tablename, veld, WaardeOud, WaardeNieuw ) 
    'Select Case id, Getdate(), 'rko', 'Relaties', 'Aantal_xr', '1', 0 from relaties where aantal_xr > 0 and geboortedatum < getdate() - 12800 and Status =0 

    'update relaties Set aantal_xr=0 where aantal_xr > 0 And geboortedatum < getdate() - 12800 And status=0 


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

    Private _dtNoXRCise As DataTable
    Public ReadOnly Property dtNoXRCise() As DataTable
        Get
            If _dtNoXRCise Is Nothing Then
                Dim iLeeftijd As Integer = 35
                Dim sql As String = "select lidnr, geboortedatum, aantal_xr " &
                                                "FROM Relaties " &
                                                "WHERE aantal_xr > 0 and (DATEDIFF(YEAR, geboortedatum, @todayDate) >= @Age) and Status = 0"
                Dim paramlist As New ArrayList
                paramlist.Add("@todayDate")
                paramlist.Add(DateTime.Now)
                paramlist.Add("@Age")
                paramlist.Add(iLeeftijd)

                Dim dt As New DataTable
                dt = da.ExecuteDataTable(sql, paramlist.ToArray)
                dt.TableName = "Leeftijd"

                _dtNoXRCise = dt

            End If
            Return _dtNoXRCise
        End Get
    End Property

    Public Sub Process()

        Dim result As Boolean = False
        Dim relatie As Relaties
        Dim sbLog As New StringBuilder
        Dim iCounter As Integer = 0
        Dim sPath As String = LogFilepath & "\logs"

        Try

            sbLog.Append("Verslag XRCise Service:" & vbCrLf)
            sbLog.Append("Datum:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf)
            sbLog.Append("Databaserver:" & ServiceSettings.MyProperties.ServerIP & vbCrLf)
            sbLog.Append("Database:" & ServiceSettings.MyProperties.DataBase & vbCrLf)
            sbLog.Append("Service User:" & ServiceSettings.MyProperties.Account & vbCrLf)

            WriteFile(sPath & "\Verslag_XRCise_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbLog.ToString)

            sbLog = New StringBuilder

            For Each dr As DataRow In dtNoXRCise.Rows
                relatie = New Relaties(dr.Item(0), Relaties.Via.LIDNR)
                If relatie.Found Then
                    If relatie.aantal_xr > 0 Then
                        relatie.aantal_xr = 0
                        relatie.SaveByNSK("XRCise")
                        sbLog.Append("lidNr: " & relatie.lidnr & vbCrLf)
                        iCounter += 1
                    End If
                End If
            Next

            sbLog.Append("Aantal verwerkt:" & iCounter & vbCrLf & vbCrLf)
            sbLog.Append("Datum verwerkt:" & Today.ToLongDateString & " tijd:" & Now.ToLongTimeString & vbCrLf)

            WriteFile(sPath & "\Verslag_XRCise_" & Today.Year & "_" & Today.Month & "_" & Today.Day & ".txt", sbLog.ToString, True)

            RaiseEvent GenerateComplete(True)

        Catch ex As Exception
            EventLog.WriteEntry("VBMservices", "XRCise Process error:" & ex.Message, EventLogEntryType.Error)
            RaiseEvent GenerateExp(ex)
        End Try

    End Sub

End Class
