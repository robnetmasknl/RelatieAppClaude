Imports System
Imports Microsoft.Office.Interop
Imports System.Globalization
Imports System.Text


Public Class MapiObject
    Public AccountJurist As String = String.Empty
    Private AccountIbb As String = String.Empty
    Private fromNew2 As Boolean = False

    Public Sub New(sysIbbAccount As String)
        Try
            AccountIbb = sysIbbAccount

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New(sysIbbAccount As String, ByVal juristaccount As String)
        Try
            If String.IsNullOrEmpty(sysIbbAccount) Then
                Throw New Exception("system IbbAccount is niet opgegeven!")
            End If
            If String.IsNullOrEmpty(juristaccount) Then
                Throw New Exception("juristaccount is niet opgegeven!")
            End If
            fromNew2 = True

            AccountIbb = sysIbbAccount
            AccountJurist = juristaccount


            If Not calfolder Is Nothing AndAlso Not calJurist Is Nothing Then
                'dan is het goed
            End If
            ' End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetMyProfile()
        Try
            Dim MyOutlook As New Outlook.Application
            Dim MyNameSpace As Outlook.NameSpace
            MyNameSpace = MyOutlook.GetNamespace("MAPI")

            'Dim MyAccount As Outlook.Account
            Dim oOlAccount As Outlook.Account

            For Each oOlAccount In MyOutlook.Session.Accounts
                If oOlAccount.AccountType = Outlook.OlAccountType.olExchange Then
                    _MyOutlookAccount = oOlAccount
                    _MyDisplayName = MyOutlookAccount.DisplayName 'voor weergave vanuit de outlook config naam
                    '_MyDisplayName = MyAccount.CurrentUser.Name 'voor weergave vanuit de AD naam
                    _myEmailAddress = MyOutlookAccount.SmtpAddress
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private _MyOutlookAccount As Outlook.Account
    Public ReadOnly Property MyOutlookAccount() As Outlook.Account
        Get
            If _MyOutlookAccount Is Nothing Then
                GetMyProfile()
            End If
            Return _MyOutlookAccount
        End Get
    End Property

    Private _MyDisplayName As String
    Public ReadOnly Property MyDisplayName() As String
        Get
            If String.IsNullOrEmpty(_MyDisplayName) Then
                GetMyProfile()
            End If
            Return _MyDisplayName
        End Get
    End Property
    Private _myEmailAddress As String
    Public ReadOnly Property myEmailAddress() As String
        Get
            If String.IsNullOrEmpty(_myEmailAddress) Then
                GetMyProfile()
            End If
            Return _myEmailAddress
        End Get
    End Property


    Private oOutlook As New Outlook.Application

    Private _oNs As Outlook.NameSpace
    Public ReadOnly Property oNs() As Outlook.NameSpace
        Get
            If _oNs Is Nothing Then
                _oNs = oOutlook.GetNamespace("MAPI")
            End If
            Return _oNs
        End Get
    End Property
    Sub OpenMailFile(ByVal _mailFile As String)
        Dim oApp As New Outlook.Application
        Dim mItem As Outlook.MailItem
        Try
            Dim currentExplorer As Outlook.Explorer = Nothing
            currentExplorer = oApp.ActiveExplorer
            Dim itemMessage As String = "Item is unknown."

            'If currentExplorer.Selection.Count > 0 Then
            '    Dim selObject As Object = currentExplorer.Selection.Item(1)
            '    If (TypeOf selObject Is Outlook.MailItem) Then
            '        Dim mailItem As Outlook.MailItem = _
            '            TryCast(selObject, Outlook.MailItem)
            '        itemMessage = "The item is an e-mail message." & " The subject is " & mailItem.Subject & "."
            '        mailItem.Display(False)
            '        '
            '    End If
            'End If

            mItem = oApp.Session.OpenSharedItem(_mailFile)

            'mItem = oApp.CreateItemFromTemplate(_mailFile)
            'mItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
            'mItem.To = mItem.Sender.Address

            'Dim _returnChar As String = String.Empty
            'If mItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML Then
            '    _returnChar = "<BR>"
            'Else
            '    _returnChar = vbCrLf
            'End If
            'mItem.Body = "verzonden op: " & mItem.SentOn & _returnChar & "ontvangen op: " & mItem.ReceivedTime & _returnChar & _returnChar & mItem.Body
            mItem.Display(False)
            Runtime.InteropServices.Marshal.ReleaseComObject(mItem)

            'oApp.Quit()
            'Runtime.InteropServices.Marshal.FinalReleaseComObject(mItem)
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private IsExchangeUserChecked As Boolean = False
    Private _IsExchangeUser As Boolean = False
    Public ReadOnly Property IsExchangeUser() As Boolean
        Get
            If Not IsExchangeUserChecked Then
                IsExchangeUserChecked = True
                If Not calfolder Is Nothing Then
                    'dan is het goed
                    _IsExchangeUser = True
                End If
            End If
            Return _IsExchangeUser
        End Get
    End Property

    Private MyAccount As Outlook.Account
    Private _calfolder As Outlook.MAPIFolder = Nothing
    Public ReadOnly Property calfolder() As Outlook.MAPIFolder
        Get
            If _calfolder Is Nothing Then
                Try
                    Dim oOlAccount As Outlook.Account
                    Dim oIBBRecipient As Outlook.Recipient

                    'check eerst of gebruiker een exchange heeft
                    'controleer dan of het de IBBCalAccount kan worden gevonden
                    'controleer dan of de gevonden account een exchange account is.

                    For Each oOlAccount In oOutlook.Session.Accounts
                        If oOlAccount.AccountType = Outlook.OlAccountType.olExchange Then
                            MyAccount = oOlAccount

                            oIBBRecipient = oNs.CreateRecipient(AccountIbb)
                            oIBBRecipient.Resolve()

                            If Not oIBBRecipient.Resolved Then
                                Throw New Exception("Sytem IBB Exchange account" & AccountIbb & " kon niet worden gevonden... ")
                            End If

                            If Not oIBBRecipient.AddressEntry.AddressEntryUserType = Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry Then
                                Dim message As String = AccountIbb & " is geen exchange account! maar een " & oIBBRecipient.AddressEntry.Type
                                EventLog.WriteEntry("calfolder", message)
                                Throw New Exception(message)
                            End If

                            _calfolder = oNs.GetSharedDefaultFolder(oIBBRecipient, Outlook.OlDefaultFolders.olFolderCalendar)
                            If _calfolder.Name Is Nothing Then
                                Dim message As String = "Agenda van " & AccountIbb & " kan niet worden gevonden."
                                EventLog.WriteEntry("calfolder", message)
                                Throw New Exception(message)
                            End If
                            _IsExchangeUser = True
                        Else
                            'dan blijft bExchangeUser = false
                        End If
                    Next

                    If IsExchangeUser = False Then Throw New Exception("U heeft momenteel geen exchangeaccount in de huidige Outlook profiel!" & vbCrLf & _
                                                                        "U kunt GEEN afspraken maken en/of wijzigen in IBB Outlook Agenda.")

                Catch ex As Exception
                    Throw New calfolderNotFoundException(ex.Message)
                End Try

            End If

            Return _calfolder
        End Get
    End Property

    Private IsExchangeJuristChecked As Boolean = False
    Private _IsExchangeJurist As Boolean = False
    Public ReadOnly Property IsExchangeJurist() As Boolean
        Get
            If Not IsExchangeJuristChecked Then
                IsExchangeJuristChecked = True
                If Not calJurist Is Nothing Then
                    'dan is het goed
                    _IsExchangeJurist = True
                End If
            End If

            Return _IsExchangeJurist
        End Get
    End Property
    Public Sub ResetCalJurist()
        Try
            _calJurist = Nothing
            IsExchangeJuristChecked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private _calJurist As Outlook.MAPIFolder
    Public ReadOnly Property calJurist() As Outlook.MAPIFolder
        Get
            If _calJurist Is Nothing Then
                Try

                    If String.IsNullOrEmpty(AccountJurist) Then
                        Throw New Exception("Account Jurist is niet opgegeven")
                    End If

                    Dim oIBBRecipient As Outlook.Recipient

                    If Not IsExchangeUser = False Then
                        oIBBRecipient = oNs.CreateRecipient(AccountJurist)
                        oIBBRecipient.Resolve()

                        If Not oIBBRecipient.Resolved Then
                            Throw New Exception("Account van Jurist " & AccountJurist & " kon niet worden gevonden... " & vbCrLf & "Neem contact met uw systeembeheerder indien u vermoedt dat dit niet correct is.")
                        End If

                        If Not oIBBRecipient.AddressEntry.AddressEntryUserType = Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry Then
                            Throw New Exception(AccountJurist & " is geen exchange account! maar een " & oIBBRecipient.AddressEntry.Type)
                        End If

                        _calJurist = oNs.GetSharedDefaultFolder(oIBBRecipient, Outlook.OlDefaultFolders.olFolderCalendar)
                        Try
                            Dim TestName As String = _calJurist.Name
                            _IsExchangeJurist = True
                        Catch ex As Exception
                            Dim message As String = "Agenda van jurist " & AccountJurist & " kan niet worden gevonden of u heeft niet voldoende rechten."
                            EventLog.WriteEntry("calJurist", message)
                            Throw New Exception(message)
                        End Try

                    Else
                        'dan blijft _IsExchangeJurist = false
                    End If

                    If IsExchangeUser = False Then Throw New Exception("U heeft momenteel geen exchangeaccount of geen rechten in de huidige Outlook profiel!" & vbCrLf & _
                                                                        "U kunt GEEN afspraken maken en/of wijzigen in IBB Outlook Agenda.")

                Catch ex As Exception
                    Throw New calfolderNotFoundException(ex.Message)
                End Try

            End If


            Return _calJurist
        End Get
    End Property
    Public Function MakeAppointment(ByVal cal As AppointmentSettings) As String

        Try
            Dim MyAppEntryId As String = String.Empty

            'If InStr(oOutlook.Application.Version, "14") Then
            If Not calfolder Is Nothing Then
                Dim olApp As Outlook.AppointmentItem
                olApp = calfolder.Items.Add(Outlook.OlItemType.olAppointmentItem)

                With olApp
                    .Subject = cal.Subject
                    If Not String.IsNullOrEmpty(.Location) Then .Location = cal.Location
                    .Body = cal.Body
                    .Start = cal.AppStartTime
                    If .Duration >= 0 Then
                        .Duration = cal.Duration
                    Else
                        .End = cal.AppEndTime()
                    End If
                    .Location = cal.Location
                    .ReminderMinutesBeforeStart = 10080 'is 1 week
                    .ReminderSet = True
                    .Save()

                    MyAppEntryId = .EntryID
                    cal.AppGlobalAppointmentID = .GlobalAppointmentID
                End With
            End If
            'End If

            Return MyAppEntryId

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function MakeAppointmentJurist(ByVal cal As AppointmentSettings) As String

        Try
            Dim MyAppEntryId As String = String.Empty

            ' If InStr(oOutlook.Application.Version, "14") Then

            If Not calJurist Is Nothing Then
                Dim olApp As Outlook.AppointmentItem
                olApp = calJurist.Items.Add(Outlook.OlItemType.olAppointmentItem)

                With olApp
                    .Subject = cal.Subject
                    If Not String.IsNullOrEmpty(.Location) Then .Location = cal.Location
                    .Body = cal.Body
                    .Start = cal.AppStartTime
                    If .Duration >= 0 Then
                        .Duration = cal.Duration
                    Else
                        .End = cal.AppEndTime()
                    End If
                    .Location = cal.Location
                    .ReminderMinutesBeforeStart = 10080 'is 1 week
                    .ReminderSet = True
                    .Save()

                    MyAppEntryId = .EntryID
                End With
            End If
            'End If

            Return MyAppEntryId

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function FindAppointmentsBySubject(subject As String, ByVal eAgenda As eCalendar) As List(Of AppointmentSettings)
        Try
            Dim GevondenItems As New List(Of AppointmentSettings)
            Dim AllItems As Outlook.Items = Nothing

            If eAgenda = eCalendar.JuristeCalendar AndAlso calJurist IsNot Nothing Then
                AllItems = calJurist.Items.Restrict("[Subject] = '" & subject & "'")
            ElseIf eAgenda = eCalendar.OwnCalendar AndAlso calfolder IsNot Nothing Then
                AllItems = calfolder.Items.Restrict("[Subject] = '" & subject & "'")
            End If

            If AllItems IsNot Nothing Then
                'zoek op onderwerp
                'GevondenItems = AllItems.Restrict("[Subject] = '" & subject & "'")

                For Each item As Outlook.AppointmentItem In AllItems
                    Dim newapp As New AppointmentSettings
                    newapp.Subject = item.Subject
                    newapp.AppStartTime = item.Start
                    newapp.AppEntryId = item.EntryID
                    newapp.Body = item.Body
                    GevondenItems.Add(newapp)
                Next
            End If

            Return GevondenItems
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateAppointmentJurist(ByVal cal As AppointmentSettings) As String
        Try
            Dim MyAppEntryId As String = String.Empty

            ' If InStr(oOutlook.Application.Version, "14") Then

            If Not calJurist Is Nothing Then
                Dim olApp As Outlook.AppointmentItem
                Try
                    olApp = DirectCast(oNs.GetItemFromID(cal.AppEntryId, calJurist.StoreID), Outlook.AppointmentItem)

                Catch exfind As Exception
                    Try
                        'zoek dan op onderwerp
                        olApp = Nothing
                        Dim AppointmentList As List(Of AppointmentSettings) = FindAppointmentsBySubject(cal.Subject, eCalendar.JuristeCalendar)
                        If AppointmentList.Count = 1 Then
                            'Er 1 items gevonden in de agenda met het zelfde onderwerp!.gebruik deze)
                            olApp = DirectCast(oNs.GetItemFromID(AppointmentList(0).AppEntryId, calJurist.StoreID), Outlook.AppointmentItem)
                        ElseIf AppointmentList.Count > 1 Then
                            'Er zijn meerdere items gevonden in de agenda met het zelfde onderwerp!. gooi weg en maak nieuwe)
                            For Each app In AppointmentList
                                olApp = DirectCast(oNs.GetItemFromID(app.AppEntryId, calJurist.StoreID), Outlook.AppointmentItem)
                                olApp.Delete()
                                olApp = Nothing
                            Next
                        End If

                        If olApp Is Nothing Then
                            olApp = calJurist.Items.Add(Outlook.OlItemType.olAppointmentItem)
                            olApp.ReminderMinutesBeforeStart = 10080
                            olApp.ReminderSet = True
                        End If

                    Catch ex As Exception
                        olApp = calJurist.Items.Add(Outlook.OlItemType.olAppointmentItem)
                        olApp.ReminderMinutesBeforeStart = 10080
                        olApp.ReminderSet = True
                        'Throw New Exception("Afspraak kon niet worden gevonden. Oude referentie is verwijderd uit de tabel en een nieuwe gemaakt!")
                    End Try
                End Try

                With olApp
                    .Start = cal.AppStartTime
                    If .Duration >= 0 Then
                        .Duration = cal.Duration
                    Else
                        .End = cal.AppEndTime()
                    End If
                    .Subject = cal.Subject
                    'If Not String.IsNullOrEmpty(.Location) Then .Location = cal.Location
                    .Location = cal.Location
                    If Not String.IsNullOrEmpty(.Body) Then
                        .Body = cal.Body & vbCrLf & .Body
                    End If
                    .Save()
                    MyAppEntryId = .EntryID
                End With

            End If
            'End If

            Return MyAppEntryId

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateAppointment(ByVal cal As AppointmentSettings) As String
        Try
            Dim MyAppEntryId As String = String.Empty

            'If InStr(oOutlook.Application.Version, "14") Then

            If Not calfolder Is Nothing Then
                Dim olApp As Outlook.AppointmentItem
                Try
                    olApp = DirectCast(oNs.GetItemFromID(cal.AppEntryId, calfolder.StoreID), Outlook.AppointmentItem)

                Catch exfind As Exception
                    Try
                        'zoek dan op onderwerp
                        olApp = Nothing
                        Dim AppointmentList As List(Of AppointmentSettings) = FindAppointmentsBySubject(cal.Subject, eCalendar.OwnCalendar)

                        If AppointmentList.Count = 1 Then
                            'Er 1 items gevonden in de agenda met het zelfde onderwerp!.gebruik deze)
                            olApp = DirectCast(oNs.GetItemFromID(AppointmentList(0).AppEntryId, calfolder.StoreID), Outlook.AppointmentItem)
                        ElseIf AppointmentList.Count > 1 Then
                            'Er zijn meerdere items gevonden in de agenda met het zelfde onderwerp!. gooi weg en maak nieuwe)
                            For Each app In AppointmentList
                                olApp = DirectCast(oNs.GetItemFromID(app.AppEntryId, calfolder.StoreID), Outlook.AppointmentItem)
                                olApp.Delete()
                                olApp = Nothing
                            Next
                        End If
                        'nog steeds niets, maak dan een nieuwe
                        If olApp Is Nothing Then
                            olApp = calfolder.Items.Add(Outlook.OlItemType.olAppointmentItem)
                            olApp.ReminderMinutesBeforeStart = 10080
                            olApp.ReminderSet = True
                        End If

                    Catch ex As Exception
                        olApp = calfolder.Items.Add(Outlook.OlItemType.olAppointmentItem)
                        olApp.ReminderMinutesBeforeStart = 10080
                        olApp.ReminderSet = True
                        'Throw New Exception("Afspraak kon niet worden gevonden. Oude referentie is verwijderd uit de tabel en een nieuwe gemaakt!")
                    End Try
                End Try

                With olApp
                    .Start = cal.AppStartTime
                    If .Duration >= 0 Then
                        .Duration = cal.Duration
                    Else
                        .End = cal.AppEndTime()
                    End If
                    .Subject = cal.Subject
                    'If Not String.IsNullOrEmpty(.Location) Then .Location = cal.Location
                    .Location = cal.Location
                    If Not String.IsNullOrEmpty(.Body) Then
                        .Body = cal.Body & vbCrLf & .Body
                    End If
                    .Save()
                    MyAppEntryId = .EntryID
                End With

            End If
            '  End If

            Return MyAppEntryId

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function OpenAppointment(ByVal cal As AppointmentSettings) As Outlook.AppointmentItem
        Try
            Dim olApp As Outlook.AppointmentItem = Nothing
            ' If InStr(oOutlook.Application.Version, "14") Then
            If Not calfolder Is Nothing Then
                olApp = oNs.GetItemFromID(cal.AppEntryId, calfolder.StoreID)
                olApp.Display(True)
            End If
            ' End If
            Return olApp
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Enum eCalendar
        OwnCalendar
        JuristeCalendar
    End Enum

    Public Function DeleteAppointment(ByVal AppEntryId As String, KiesAgenda As eCalendar) As Boolean
        Try
            Dim olApp As Outlook.AppointmentItem = Nothing
            If Not calfolder Is Nothing Then
                If KiesAgenda = eCalendar.OwnCalendar Then
                    Try
                        olApp = oNs.GetItemFromID(AppEntryId, calfolder.StoreID)
                        olApp.Delete()
                    Catch ex As Exception
                        Throw ex
                    End Try
                Else
                    Try
                        olApp = oNs.GetItemFromID(AppEntryId, calJurist.StoreID)
                        olApp.Delete()
                    Catch ex As Exception
                        Throw ex
                    End Try
                End If
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Private Sub FindAppointmentItemByGlobalAppointmentID(appointmentID As String)
    '    Dim outlookNameSpace As Outlook.NameSpace = Me.Application.GetNamespace("MAPI")
    '    Dim calendarFolder As Outlook.MAPIFolder = outlookNameSpace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar)

    '    Dim appointmentItems As Outlook.Items = calendarFolder.Items

    '    Try
    '        Dim appointmentItem As Outlook.AppointmentItem = DirectCast(appointmentItems.Find([String].Format("[GlobalAppointmentID] = '{0}'", appointmentID)), Outlook.AppointmentItem)
    '        If appointmentItem IsNot Nothing Then
    '            appointmentItem.Display(True)
    '        Else
    '            MessageBox.Show("The appointment was not found.")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub
End Class


Public Class calfolderNotFoundException
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class

