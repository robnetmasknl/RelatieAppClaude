Imports System.Text

Public Class AppointmentReminder

    'incl locatie gegevens
    'incl adviseur gegevens
    'incl lid gegevens

    Private _ByDate As Date
    Public Sub New(ByVal bydate As Date)
        _ByDate = bydate
    End Sub

    'haal de afspraken voor "morgen" op.
    Private _Appointments As List(Of Boeking)
    Public ReadOnly Property Appointments() As List(Of Boeking)
        Get
            If _Appointments Is Nothing Then
                Dim _BoekingLijst As New BoekingLijst(_ByDate)
                _Appointments = _BoekingLijst.ByDay
            End If
            Return _Appointments
        End Get
    End Property

    Private _SmsMessages As List(Of SmsMessage)
    Public ReadOnly Property SmsMessages() As List(Of SmsMessage)
        Get
            If _SmsMessages Is Nothing Then
                FillSmsMessages()
            End If
            Return _SmsMessages
        End Get
    End Property
    Private Sub FillSmsMessages()
        Try
            _SmsMessages = New List(Of SmsMessage)

            For Each Appointment As Boeking In Appointments
                Dim sms As New SmsMessage(Appointment.Id.ToString, SmsMessage.Via.BOEKINGID)
                If sms.Found Then
                    Continue For
                Else
                    Dim destination As String = "0651412245" 'Appointment.MyRelatie.mobiel
                    Dim textToSend As String = String.Empty
                    Dim sbBericht As New StringBuilder

                    sbBericht.Append("herinnering afspraak VBM:")
                    sbBericht.Append(" in " & Appointment.MyRelatie.CurrentBoeking.Blok.LocatieNaam)
                    sbBericht.Append(" om: " & Appointment.MyRelatie.CurrentBoeking.tijdstip)
                    sbBericht.Append(" bij  " & Appointment.MyRelatie.CurrentBoeking.Blok.AdviseurNaam)

                    Dim iMaxlength As Integer = 160  'max sms lengte 160
                    If sbBericht.Length >= iMaxlength Then
                        sbBericht.Remove(iMaxlength, sbBericht.Length - iMaxlength)
                    End If

                    textToSend = sbBericht.ToString

                    sms.LidId = Appointment.lidnr
                    sms.BoekingId = Appointment.Id
                    sms.Message = textToSend
                    sms.ValidateMobileNumber(destination)
                    sms.CreatedBy = "smsservice"

                    _SmsMessages.Add(sms)

                End If

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
