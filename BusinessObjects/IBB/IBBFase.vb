Imports MapiObjects
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq

Public Class IBBFase
    Inherits tblIBBFases
    Implements INotifyPropertyChanged
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess

    Enum Via
        ID
        DOSSIERID
    End Enum


    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Public Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
            NotifyPropertyChanged("VovoDat")
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32, ByVal via As Via)
        Dim ohelper As New Helper
        If via = IBBFase.Via.ID Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf via = IBBFase.Via.DOSSIERID Then
            ohelper.FillObject(Me, GetByDossierId(id))
        End If

    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM IBBFases where id = @id"
            Dim param() As Object = {"@id", Id}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function

    Public Function GetByDossierId(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM IBBFases where dossierId = @dossierId"
            Dim param() As Object = {"@dossierId", Id}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetList(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As Data.DataTable
        Dim oDS As Data.DataSet
        Try
            oDS = da.ExecuteDataset(sql, parameters)
            Return oDS.Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            oDS = Nothing
        End Try
    End Function
    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Private _bMakeAppointment As Boolean = False
    Public Property bMakeAppointment() As Boolean
        Get
            Return _bMakeAppointment
        End Get
        Set(ByVal value As Boolean)
            _bMakeAppointment = value
        End Set
    End Property

    Private _DossierNr As String = String.Empty
    Public ReadOnly Property DossierNr() As String
        Get
            If String.IsNullOrEmpty(_DossierNr) And DossierId > 0 Then
                Dim Sql As String = "SELECT DossierNr FROM IBBDossiers WHERE Id = @Id"
                Dim param() As Object = {"@Id", DossierId}
                _DossierNr = da.ExecuteScalar(Sql, param).ToString
            End If
            Return _DossierNr
        End Get
    End Property
    Private _IBBDossier As IBBDossier
    Public ReadOnly Property IBBDossier() As IBBDossier
        Get
            If _IBBDossier Is Nothing Then
                _IBBDossier = New IBBDossier(DossierId, BusinessObjects.IBBDossier.VIA.ID)
            End If
            Return _IBBDossier
        End Get
    End Property

    Public Function AllPhasesClosed() As Boolean
        Try
            Dim AllClosed As Boolean = True

            Dim dt As DataTable
            Dim paramlist As New ArrayList
            Dim sql As String = "SELECT * FROM IBBFases where DossierId = @DossierId AND Besluit = @Besluit And id <> @FaseId"
            paramlist.Add("@DossierId")
            paramlist.Add(DossierId)
            paramlist.Add("@Besluit")
            paramlist.Add(0)
            paramlist.Add("@FaseId")
            paramlist.Add(Id)
            dt = da.ExecuteDataTable(sql, paramlist.ToArray)
            AllClosed = dt.Rows.Count = 0

            Return AllClosed

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub Save()
        Try
            If DossierId = 0 Then Throw New Exception("Er is nog geen dossier nummer")
            If TypeId < 1 Then Throw New Exception("FaseId " & TypeId & " is onbekend!")

            If Besluit = 0 Then
                'If Not AllPhasesClosed() And Not Me.Fase.Seq = 0 Then Throw New Exception("Er kunnen niet meer dan 1 open fases zijn, bezwaarfase uitgezonderd!")
            End If


            If Me.Id = Nothing Then
                CreateDate = Now
                CreatedBy = URights.UserName
                da.UpdateMutDateDossier(DossierId)

                Id = da.InsertString(Me, "IBBFases", "Id", True)
                Dim myHistory As New History
                myHistory.LidId = DossierId
                myHistory.TableName = "IBBFases"
                myHistory.Veld = "Nieuw IBBFase"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "IBBFase:" & Me.Id
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
                bMakeAppointment = True

            Else
                If da.isChanged(Me, "IBBFases", "Id", Me.Id, DossierId) Then
                    da.UpdateMutDateDossier(DossierId)
                    da.UpdateString(Me, "IBBFases", "Id")
                    bMakeAppointment = True
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Public Sub Close()
    '    Try
    '        'moeten toekomstige reminders worden verwijderd.

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Public Sub Remove()
        Try
            Dim myHistory As New History
            myHistory.LidId = DossierId
            myHistory.TableName = "IBBFases"
            myHistory.Veld = "verwijderd IBBFase"
            myHistory.WaardeOud = Me.Id & " - " & Me.Fase.Description
            myHistory.WaardeNieuw = ""
            myHistory.MutDate = Now
            myHistory.MutDoor = URights.UserName
            myHistory.Save()

            da.DeleteCommand(Me, "IBBFases", "Id")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function DateFieldTranslate(_field As String) As String
        Try
            Dim result As String = String.Empty

            Dim Sql As String = "SELECT description FROM jdTranslate WHERE JdTypeId = @JdTypeId AND DBCOLUMN = @DBCOLUMN"
            Dim param() As Object = {"@JdTypeId", Fase.Id, "@DBCOLUMN", _field}
            result = da.ExecuteScalar(Sql, param)

            If String.IsNullOrEmpty(result) Then
                result = "!" & _field
            End If

            Return result
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private _jdTranslates As List(Of tbljdTranslate)
    Public ReadOnly Property jdTranslates() As List(Of tbljdTranslate)
        Get
            If _jdTranslates Is Nothing Then
                _jdTranslates = New List(Of tbljdTranslate)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM jdTranslate WHERE JdTypeId = @JdTypeId"
                Dim param() As Object = {"@JdTypeId", Fase.Id}
                _jdTranslates = ohelper.MapDataTableToList(Of tbljdTranslate)(da.ExecuteDataTable(sql, param))

            End If
            Return _jdTranslates
        End Get
    End Property
    'Public Function HasAppoinments() As Boolean
    '    Try
    '        For Each jdtr In jdTranslates
    '            'controleer of er een algemene agenda item kan zijn
    '            If Not String.IsNullOrEmpty(jdtr.CalEntryField) Then
    '                Dim pi As System.Reflection.PropertyInfo = Nothing
    '                pi = Me.GetType().GetProperty(jdtr.CalEntryField)
    '                If Not String.IsNullOrEmpty(pi.GetValue(Me, Nothing)) Then Return True
    '                pi = Me.GetType().GetProperty(jdtr.CalEntryFieldHandler)
    '                If Not String.IsNullOrEmpty(pi.GetValue(Me, Nothing)) Then Return True
    '            End If

    '        Next
    '        Return False

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    'Private Function SetAppointmentSettings() As AppointmentSettings
    '    Try
    '        Dim myAppointment As New AppointmentSettings
    '        With myAppointment

    '        End With

    '        Return myAppointment

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Function HasFutureAppointments() As Boolean
        Try
            For Each jdtr In jdTranslates
                'controleer of er een algemene agenda item KAN zijn
                If Not String.IsNullOrEmpty(jdtr.CalEntryField) Then

                    Dim pi As System.Reflection.PropertyInfo = Nothing
                    pi = Me.GetType().GetProperty(jdtr.DBColumn)

                    Dim startstring As String = pi.GetValue(Me, Nothing)

                    If Not String.IsNullOrEmpty(startstring) Then
                        Dim StartTime As Date = startstring
                        'controleer datum en geen true indien in de toekomst
                        If StartTime > Now Then
                            Return True
                        End If

                    End If 'IsNullOrEmpty(startstring)
                End If 'IsNullOrEmpty(jdtr.CalEntryField)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' Public AppointmentErrorList As List(Of String)
    ' Public AppointmentMsgList As List(Of String)
    Private _AppointmentErrorList As List(Of String)
    Public Property AppointmentErrorList() As List(Of String)
        Get
            If _AppointmentErrorList Is Nothing Then
                _AppointmentErrorList = New List(Of String)
            End If
            Return _AppointmentErrorList
        End Get
        Set(ByVal value As List(Of String))
            _AppointmentErrorList = value
        End Set
    End Property

    Private _AppointmentMsgList As List(Of String)
    Public Property AppointmentMsgList() As List(Of String)
        Get
            If _AppointmentMsgList Is Nothing Then
                _AppointmentMsgList = New List(Of String)
            End If
            Return _AppointmentMsgList
        End Get
        Set(ByVal value As List(Of String))
            _AppointmentMsgList = value
        End Set
    End Property

    Public Sub ClearDBCalEntries()
        Try
            For Each jdtr In jdTranslates
                'controleer of er een algemene agenda item kan zijn
                If Not String.IsNullOrEmpty(jdtr.CalEntryField) Then

                    Dim pi As System.Reflection.PropertyInfo = Nothing
                    pi = Me.GetType().GetProperty(jdtr.CalEntryField)
                    pi.SetValue(Me, "", Nothing)

                    pi = Me.GetType().GetProperty(jdtr.CalEntryFieldHandler)
                    pi.SetValue(Me, "", Nothing)

                End If '
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateFutureAppointmentEWS(Optional ByVal AksQuestions As Boolean = True)
        Try
            AppointmentErrorList = New List(Of String)
            AppointmentMsgList = New List(Of String)
            For Each jdtr In jdTranslates
                'controleer of er een algemene agenda item kan zijn
                If Not String.IsNullOrEmpty(jdtr.CalEntryField) Then

                    Dim pi As System.Reflection.PropertyInfo = Nothing
                    pi = Me.GetType().GetProperty(jdtr.DBColumn)

                    Dim startstring As String = pi.GetValue(Me, Nothing)

                    If Not String.IsNullOrEmpty(startstring) Then
                        Dim StartTime As Date = startstring
                        'controleer datum en alleen doorgaan als de datum in de toekomst ligt
                        If StartTime > Now Then
                            UpdateAppointmentEWS(jdtr.DBColumn, AksQuestions)
                        End If

                    End If 'IsNullOrEmpty(startstring)
                End If 'IsNullOrEmpty(jdtr.CalEntryField)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateAppointmentEWS(ByVal dbcolumn As String, Optional ByVal AksQuestions As Boolean = True)
        Try

            Dim jdtr As jdTranslate = New jdTranslate(Me.TypeId, dbcolumn)

            If jdtr.Found Then
                If Not String.IsNullOrEmpty(jdtr.CalEntryField) Then
                    If jdtr.JdTypeId = 10 And dbcolumn.ToLower = "ingebreke" Then
                        If Me.AanhBezw = True Then jdtr.Description = "Stuiting"
                    End If

                    Dim pi As System.Reflection.PropertyInfo = Nothing

                    pi = Me.GetType().GetProperty(jdtr.DBColumn)
                    Dim startstring As String = pi.GetValue(Me, Nothing)

                    Dim sCalEntryField As String = String.Empty
                    pi = Me.GetType().GetProperty(jdtr.CalEntryField)
                    sCalEntryField = pi.GetValue(Me, Nothing)

                    Dim sCalEntryFieldHandler As String = String.Empty
                    pi = Me.GetType().GetProperty(jdtr.CalEntryFieldHandler)
                    sCalEntryFieldHandler = pi.GetValue(Me, Nothing)

                    Dim myAppointment As AppointmentSettings = Nothing
                    'bmo: bug1154: 
                    'Het aantal dagen van de reminder moet variable worden en wordt nu gekeken of er een afwijkende getal in de jdrTranslate tabel staat
                    Dim iReminderIndays As Integer = 7
                    If Not jdtr.ReminderInDays = 0 Then
                        iReminderIndays = jdtr.ReminderInDays
                    End If
                    Dim ReminderMinutes As Integer = (60 * 24 * iReminderIndays) '10080 ' = 60 *24 * 7 = is 7dgn

                    If Not String.IsNullOrEmpty(startstring) Then
                        myAppointment = New AppointmentSettings
                        myAppointment.Subject = Me.Fase.Description & " " & jdtr.Description & " " & Me.IBBDossier.MyRelatie.FullName & " - Dossiernr: " & Me.DossierNr & "- Jurist: " & Me.IBBDossier.Behandelaar
                        myAppointment.AppStartTime = startstring
                        myAppointment.Duration = 0
                        myAppointment.Location = String.Empty

                        If dbcolumn.ToLower = "hoorzittingdatum" And AksQuestions = True Then
                            Dim dlgAsk As New dlgAskIt
                            Dim LastY As Integer = 20
                            Dim iLabelPositionX As Integer = 0

                            dlgAsk.StartPosition = FormStartPosition.CenterScreen
                            iLabelPositionX = dlgAsk.Location.X + 20

                            Dim tbLocation As New TextBox

                            If Me.TypeId = 2 Then
                                Dim lblLocation As New Label
                                lblLocation.Location = New Point(iLabelPositionX, 30)
                                lblLocation.Text = "Geef de locatie van de hoorzitting op voor het verwerken in de agenda's!"
                                lblLocation.AutoSize = True
                                dlgAsk.Controls.Add(lblLocation)

                                LastY = lblLocation.Location.Y

                                tbLocation.Location = New Point(iLabelPositionX, LastY + 30)
                                tbLocation.Name = "tb1"
                                tbLocation.Text = Me.Hoorzittinglocatie
                                tbLocation.Size = New Size(dlgAsk.Size.Width - 50, 35)
                                dlgAsk.Controls.Add(tbLocation)
                                LastY = tbLocation.Location.Y

                            End If

                            Dim lblTime As New Label
                            lblTime.Location = New Point(iLabelPositionX, LastY + 30)
                            lblTime.Text = "Geef het tijdstip van de " & jdtr.Description & " op voor het verwerken in de agenda's!"
                            lblTime.AutoSize = True
                            dlgAsk.Controls.Add(lblTime)
                            LastY = lblTime.Location.Y

                            Dim uZitting As New uZittingDetails
                            uZitting.Location = New Point(iLabelPositionX, LastY + 30)
                            uZitting.Name = "uZitting"
                            uZitting.dtpStart.Value = AddTimeToDate(startstring, Me.ZittingStart)
                            uZitting.dtpEnd.Value = AddTimeToDate(startstring, Me.ZittingEnd)
                            dlgAsk.Controls.Add(uZitting)

                            LastY = uZitting.Location.Y


                            Dim lblTip As New Label
                            lblTip.Location = New Point(iLabelPositionX, LastY + 30)
                            lblTip.AutoSize = True
                            lblTip.Text = "geef 08:00 - 08:00 op als het tijdstip onbekend is."
                            dlgAsk.Controls.Add(lblTip)

                            LastY = lblTip.Location.Y

                            Dim durationSpan As TimeSpan

                            dlgAsk.ShowDialog()
                            If dlgAsk.DialogResult <> DialogResult.OK Then
                                Exit Sub
                            Else
                                Me.Hoorzittinglocatie = tbLocation.Text
                                Me.ZittingStart = uZitting.dtpStart.Value.ToShortTimeString
                                Me.ZittingEnd = uZitting.dtpEnd.Value.ToShortTimeString
                                durationSpan = uZitting.dtpEnd.Value - uZitting.dtpStart.Value
                                myAppointment.AppStartTime = AddTimeToDate(startstring, Me.ZittingStart)
                                myAppointment.Location = tbLocation.Text
                                myAppointment.Duration = durationSpan.TotalMinutes
                            End If
                        Else
                            ' And AksQuestions = False
                        End If

                        If myAppointment.Duration = 0 Then
                            myAppointment.AppStartTime = AddTimeToDate(startstring, "08:00")
                            myAppointment.AppEndTime = AddTimeToDate(startstring, "09:00")
                            'myAppointment.AppEndTime = myAppointment.AppStartTime.AddDays(1)
                            'myAppointment.IsAllDayEvent = True
                        Else
                            myAppointment.AppEndTime = myAppointment.AppStartTime.AddMinutes(myAppointment.Duration)
                        End If
                        myAppointment.ReminderMinutes = ReminderMinutes
                    End If

                    Dim myMailboxUpn As String = GetSysSettingOf("ESDefaultAgenda")
                    Dim HandlerMailboxUpn As String = String.Empty
                    Dim HandlerEnabled As Boolean = False

                    Try
                        HandlerMailboxUpn = Me.IBBDossier.myBehandelaar.Email
                        HandlerEnabled = GraphSync(Function() ValidateCalendarAsync(HandlerMailboxUpn))
                    Catch ex As Exception
                        AppointmentErrorList.Add("mailbox van behandelaar " & Me.IBBDossier.myBehandelaar.Naam & " kan niet worden gevonden. dossiernr: " & Me.IBBDossier.DossierNr)
                    End Try

                    If Not String.IsNullOrEmpty(startstring) Then

                        pi = Me.GetType().GetProperty(jdtr.CalEntryField)
                        Dim wasCreated As Boolean
                        Dim newEventId As String = CreateOrUpdateGraphAppointment(myMailboxUpn, sCalEntryField, myAppointment, wasCreated)
                        pi.SetValue(Me, newEventId, Nothing)
                        Me.Save()
                        AppointmentMsgList.Add(If(wasCreated, "Toegevoegd: ", "Updated: ") & myAppointment.Subject)

                        'Doe hetzelfde voor de Jurist
                        If Not HandlerEnabled Then
                            AppointmentErrorList.Add("mailbox van behandelaar " & Me.IBBDossier.myBehandelaar.Naam & " kan niet worden gevonden. dossiernr: " & Me.IBBDossier.DossierNr)
                            AppointmentErrorList.Add(myAppointment.Subject & vbCrLf)
                        Else
                            pi = Me.GetType().GetProperty(jdtr.CalEntryFieldHandler)
                            Dim wasCreatedHandler As Boolean
                            Dim newHandlerEventId As String = CreateOrUpdateGraphAppointment(HandlerMailboxUpn, sCalEntryFieldHandler, myAppointment, wasCreatedHandler)
                            pi.SetValue(Me, newHandlerEventId, Nothing)
                            Me.Save()
                        End If
                    Else
                        'als er wel een entry was en nu geen datum meer dan verwijderen uit agenda en entry leegmaken.
                        pi = Me.GetType().GetProperty(jdtr.CalEntryField)
                        If Not String.IsNullOrEmpty(sCalEntryField) Then
                            DeleteGraphAppointment(myMailboxUpn, sCalEntryField)
                            pi.SetValue(Me, String.Empty, Nothing)
                            Me.Save()
                        End If

                        pi = Me.GetType().GetProperty(jdtr.CalEntryFieldHandler)
                        If Not String.IsNullOrEmpty(sCalEntryFieldHandler) Then
                            DeleteGraphAppointment(HandlerMailboxUpn, sCalEntryFieldHandler)
                            pi.SetValue(Me, String.Empty, Nothing)
                            Me.Save()
                        End If

                    End If 'String.IsNullOrEmpty(startstring)

                End If 'String.IsNullOrEmpty(jdtr.CalEntryField)

            End If 'jdtr.Found
        Catch ex As Exception
            AppointmentErrorList.Add(ex.Message)
            Throw ex
        End Try
    End Sub
    Public Sub DeleteFutureAppointmentsEWS(Optional ByVal AksQuestions As Boolean = True)
        Try
            For Each jdtr In jdTranslates
                'controleer of er een algemene agenda item kan zijn
                If Not String.IsNullOrEmpty(jdtr.CalEntryField) Then

                    Dim pi As System.Reflection.PropertyInfo = Nothing
                    pi = Me.GetType().GetProperty(jdtr.DBColumn)

                    Dim startstring As String = pi.GetValue(Me, Nothing)

                    If Not String.IsNullOrEmpty(startstring) Then
                        Dim StartTime As Date = startstring
                        'controleer datum en alleen doorgaan als de datum in de toekomst ligt
                        If StartTime > Now Then
                            DeleteAppointmentEWS(jdtr.DBColumn, AksQuestions)
                        End If

                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteAppointmentEWS(ByVal dbcolumn As String, Optional ByVal AksQuestions As Boolean = True)
        Try
            Dim jdtr As jdTranslate = New jdTranslate(Me.TypeId, dbcolumn)

            If jdtr.Found Then
                If Not String.IsNullOrEmpty(jdtr.CalEntryField) Then

                    Dim pi As System.Reflection.PropertyInfo = Nothing

                    Dim sCalEntryField As String = String.Empty
                    pi = Me.GetType().GetProperty(jdtr.CalEntryField)
                    sCalEntryField = pi.GetValue(Me, Nothing)

                    Dim sCalEntryFieldHandler As String = String.Empty
                    pi = Me.GetType().GetProperty(jdtr.CalEntryFieldHandler)
                    sCalEntryFieldHandler = pi.GetValue(Me, Nothing)

                    Dim myMailboxUpn As String = GetSysSettingOf("ESDefaultAgenda")
                    Dim HandlerMailboxUpn As String = String.Empty

                    Try
                        HandlerMailboxUpn = Me.IBBDossier.myBehandelaar.Email
                    Catch ex As Exception
                        'sbErrorLog.Append("mailbox van behandelaar " & fs.IBBDossier.myBehandelaar.Naam & " kan niet worden gevonden. dossiernr: " & fs.IBBDossier.DossierNr & vbCrLf)
                    End Try

                    pi = Me.GetType().GetProperty(jdtr.CalEntryField)
                    If Not String.IsNullOrEmpty(sCalEntryField) Then
                        DeleteGraphAppointment(myMailboxUpn, sCalEntryField)
                        pi.SetValue(Me, String.Empty, Nothing)
                        Me.Save()
                    End If

                    pi = Me.GetType().GetProperty(jdtr.CalEntryFieldHandler)
                    If Not String.IsNullOrEmpty(sCalEntryFieldHandler) AndAlso Not String.IsNullOrEmpty(HandlerMailboxUpn) Then
                        DeleteGraphAppointment(HandlerMailboxUpn, sCalEntryFieldHandler)
                        pi.SetValue(Me, String.Empty, Nothing)
                        Me.Save()
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Maakt een Graph-agenda-item aan of update het bestaande item (PATCH). Als het bestaande id
    ''' een 404 geeft - bv. een oude EWS-hex-EntryId die Graph niet kan herkennen, of handmatig
    ''' verwijderd - wordt net als voorheen bij EWS gewoon een nieuw item aangemaakt.
    ''' </summary>
    Private Function CreateOrUpdateGraphAppointment(mailboxUpn As String, existingEventId As String, appt As AppointmentSettings, ByRef wasCreated As Boolean) As String
        Dim upn = Uri.EscapeDataString(mailboxUpn)
        Dim body = BuildCalendarEventJson(appt)

        If String.IsNullOrEmpty(existingEventId) Then
            wasCreated = True
            Dim created = GraphSync(Function() GraphPostAsync($"users/{upn}/events", body))
            Return CStr(created("id"))
        End If

        Try
            GraphSync(Function() GraphPatchAsync($"users/{upn}/events/{existingEventId}", body))
            wasCreated = False
            Return existingEventId
        Catch ex As GraphNotFoundException
            wasCreated = True
            Dim created = GraphSync(Function() GraphPostAsync($"users/{upn}/events", body))
            Return CStr(created("id"))
        End Try
    End Function

    Private Sub DeleteGraphAppointment(mailboxUpn As String, eventId As String)
        Try
            GraphSync(Function() GraphDeleteAsync($"users/{Uri.EscapeDataString(mailboxUpn)}/events/{eventId}"))
        Catch ex As GraphNotFoundException
            'al verwijderd of nooit resolvebaar (bv. oude EWS-id) - net als voorheen bij een EWS bind-fout negeren
        End Try
    End Sub

    Private Function BuildCalendarEventJson(appt As AppointmentSettings) As JObject
        Dim json As New JObject()
        json("subject") = appt.Subject

        Dim location As New JObject()
        location("displayName") = If(appt.Location, String.Empty)
        json("location") = location

        Dim startTime As New JObject()
        startTime("dateTime") = appt.AppStartTime.ToString("s")
        startTime("timeZone") = "Europe/Amsterdam"
        json("start") = startTime

        Dim endTime As New JObject()
        endTime("dateTime") = appt.AppEndTime.ToString("s")
        endTime("timeZone") = "Europe/Amsterdam"
        json("end") = endTime

        json("isAllDay") = appt.IsAllDayEvent
        json("isReminderOn") = True
        json("reminderMinutesBeforeStart") = appt.ReminderMinutes

        Return json
    End Function
    'Public Sub DeleteFutureAppointments()
    '    Try
    '        Dim checkcalendar As New CheckIBBCalendar
    '        checkcalendar.DeleteFutureAppointmentsSinglePhase(Me)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private _NextJFaseExpected As Integer = -1
    Public ReadOnly Property NextJFaseExpected() As Integer
        Get
            Dim param() As Object = {"@Seq", Fase.Seq, "@sort", IBBDossier.DossierSort}
            Dim NextFaseId As Object = da.ExecuteScalar("SELECT TOP 1 seq FROM jdTypes Where (seq > @Seq AND seq >= 20) And Sort = @sort Order By seq", param)

            If IsNumeric(NextFaseId) Then
                _NextJFaseExpected = NextFaseId
            End If

            Return _NextJFaseExpected
        End Get
    End Property

    Public Function NextJFaseExist() As Boolean
        Try
            Dim ExpectedNextFase As Integer = NextJFaseExpected
            NextJFaseExist = False

            If IBBDossier.ListIBBFases(True).Count > 0 Then
                For Each _fase As IBBFase In IBBDossier.ListIBBFases()
                    If _fase.Fase.Seq > ExpectedNextFase Then
                        NextJFaseExist = True
                        Exit For
                    End If
                Next
            End If

            Return NextJFaseExist
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private _PreviousFase As IBBFase = Nothing
    Public ReadOnly Property PreviousFase() As IBBFase
        Get
            If IBBDossier.ListIBBFases(True).Count > 0 Then
                _PreviousFase = IBBDossier.ListIBBFases.First
            End If
            Return _PreviousFase
        End Get
    End Property

    'Private _PreviousJFaseExpected As Integer = -1
    'Public ReadOnly Property PreviousJFaseExpected() As Integer
    '    Get
    '        Dim param() As Object = {"@Seq", Fase.Seq, "@sort", IBBDossier.DossierSort}
    '        Dim PreviousFaseId As Object = da.ExecuteScalar("SELECT TOP 1 id FROM jdTypes Where (seq < @Seq AND seq >= 20) And Sort = @sort Order By seq DESC", param)

    '        If IsNumeric(PreviousFaseId) Then
    '            _PreviousJFaseExpected = PreviousFaseId
    '        End If

    '        Return _PreviousJFaseExpected
    '    End Get
    'End Property

    Private _Fase As FaseTypes
    Public ReadOnly Property Fase() As FaseTypes
        Get
            If _Fase Is Nothing Then
                _Fase = New FaseTypes(Me.TypeId)
            End If
            Return _Fase
        End Get
    End Property

End Class
