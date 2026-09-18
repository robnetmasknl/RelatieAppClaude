Imports System.Text
Imports System.Windows.Forms
Imports System.Web
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock


Public Class Utilities


    Private _settings As Settings = Settings.Instance
    Private _CurrentSite As String = ""
    Public Property CurrentSite() As String
        Get
            If HttpContext.Current Is Nothing Then
                Return String.Empty
            Else
                Dim Site As String = HttpContext.Current.Request.Url.AbsoluteUri
                With HttpContext.Current.Request.Url
                    _CurrentSite = .Scheme
                    _CurrentSite &= "://" ' .SchemeDelimiter.ToString
                    _CurrentSite &= .Authority
                End With
                Return _CurrentSite
            End If
        End Get
        Set(ByVal value As String)
            _CurrentSite = value
        End Set
    End Property

    Public Sub WriteLog(ByVal sLog As String, ByVal succes As Boolean)
        '_settings = New Settings
        Dim di As New IO.DirectoryInfo(_settings.LogFilePath & "\Logs")
        If Not di.Exists Then di.Create()

        Dim fs As IO.FileStream = IO.File.Open(di.FullName & "\" & Format(Today, "yyyyMMdd") & succes.ToString & ".Log", IO.FileMode.Append, IO.FileAccess.Write)
        Dim sw As New IO.StreamWriter(fs)
        Try
            sw.WriteLine(Now & "; " & sLog)
        Catch ex As System.IO.IOException
            EventLog.WriteEntry("VBMNOV", "WriteLOG: " & ex.Message, EventLogEntryType.Error)
        Finally
            If Not (sw Is Nothing) Then sw.Close()
        End Try
    End Sub
    Public Function SignaleringList() As DataTable
        Try
            Dim da As New DataAccess
            Dim dt As DataTable = New DataTable
            Dim Connection As SqlConnection = New SqlConnection(da.MyConnectionString)

            Dim Command As SqlCommand = New SqlCommand()
            Command.Connection = Connection
            Command.CommandText = "stpSignalering"
            Command.CommandType = CommandType.StoredProcedure

            Dim Parameter As SqlParameter = New SqlParameter("@Veld", "plaatsing")
            Parameter.Direction = ParameterDirection.Input
            Parameter.DbType = DbType.String

            Command.Parameters.Add(Parameter)

            Dim Adapter As SqlDataAdapter = New SqlDataAdapter(Command)
            Dim DataSet As DataSet = New DataSet(Command.CommandText)
            Adapter.Fill(DataSet)
            dt = DataSet.Tables(0)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetWeekNumber(ByVal mydate As DateTime) As Integer
        Const JAN As Integer = 1
        Const DEC As Integer = 12
        Const LASTDAYOFDEC As Integer = 31
        Const FIRSTDAYOFJAN As Integer = 1
        Const THURSDAY As Integer = 4

        Dim ThursdayFlag As Boolean = False

        Dim DayOfYear As Integer = mydate.DayOfYear

        Dim StartWeekDayOfYear As Integer = CInt(New DateTime(mydate.Year, JAN, FIRSTDAYOFJAN).DayOfWeek)
        Dim EndWeekDayOfYear As Integer = CInt(New DateTime(mydate.Year, DEC, LASTDAYOFDEC).DayOfWeek)

        If StartWeekDayOfYear = 0 Then
            StartWeekDayOfYear = 7
        End If
        If EndWeekDayOfYear = 0 Then
            EndWeekDayOfYear = 7
        End If

        Dim DaysInFirstWeek As Integer = 8 - StartWeekDayOfYear

        If StartWeekDayOfYear = THURSDAY OrElse EndWeekDayOfYear = THURSDAY Then
            ThursdayFlag = True
        End If

        Dim FullWeeks As Integer = CInt(Math.Ceiling((DayOfYear - DaysInFirstWeek) / 7.0))
        Dim WeekNumber As Integer = FullWeeks

        If DaysInFirstWeek >= THURSDAY Then
            WeekNumber += 1
        End If

        If WeekNumber > 52 AndAlso Not ThursdayFlag Then
            WeekNumber = 1
        End If

        If WeekNumber = 0 Then
            WeekNumber = GetWeekNumber(New DateTime(mydate.Year - 1, DEC, LASTDAYOFDEC))
        End If

        Return WeekNumber
    End Function


    Public Shared Function ValidateDate(ByVal Value As String) As Boolean
        If String.IsNullOrEmpty(Value) Then Return ""
        Try
            Dim result As Boolean = False

            'Controleer formaat: 'dd/mm/jjjj' "
            'Dim regex As New RegularExpressions.Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](18|19|20)\d{2}")

            Dim regex As New RegularExpressions.Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](18|19|20)\d\d$") '](19|20)\d\d$
            If regex.IsMatch(Value) Then
                result = True  '"01-01-1900"
            Else
                ''Controleer of de datum niet in de toekomst ligt
                'Dim dt As Date = Value
                'Dim tsTimeSpan As TimeSpan = dt.Subtract(Now)
                'Dim iNumberOfDays As Integer = tsTimeSpan.Days

                'If tsTimeSpan.Days > 1 Then
                '    result = "01-01-1900"
                'Else
                '    result = Value
                'End If
            End If

            Return result
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub ValidNummeriek(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If TypeOf (sender) Is TextBox Then
            Dim textbox As TextBox = sender
            Dim errorMessage As String = "Alleen numerieke karakters'" ' & textbox.Name
            If Not IsNumeric(textbox.Text) And Not textbox.Text = "" Then
                textbox.BackColor = System.Drawing.Color.Red
                MessageBox.Show(textbox.Text & vbCrLf & errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                textbox.Focus()
                ' Throw New Exception(textbox.Text & vbCrLf & errorMessage)
            Else
                textbox.BackColor = System.Drawing.Color.White
            End If
        End If
    End Sub

    'Public Function GetWeekOfYear(ByVal mydate As DateTime) As Integer




    '    'public virtual int GetWeekOfYear (DateTime time, System.Globalization.CalendarWeekRule rule, DayOfWeek firstDayOfWeek);
    '    '    ' Seriously cheat.  If its Monday, Tuesday Or Wednesday, then it'll 
    '    '    ' be the same week# as whatever Thursday, Friday Or Saturday are,
    '    '    ' And we always get those right

    '    '    Dim Day As DayOfWeek = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(Of Date);

    '    '    If (Day >= DayOfWeek.Monday && Day <= DayOfWeek.Wednesday) Then
    '    '                {
    '    '        time = time.AddDays(3);
    '    '    }

    '    '    // Return the week of our adjusted day
    '    '    Return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    'End Function

    Public Shared Sub WriteDataTable(ByVal sourceTable As DataRow, ByVal writer As IO.TextWriter, ByVal includeHeaders As Boolean, ByVal separator As String)
        If (includeHeaders) Then
            Dim headerValues As List(Of String) = New List(Of String)()

            For Each column As DataColumn In sourceTable.Table.Columns
                headerValues.Add(QuoteValue(column.ColumnName))
            Next
            writer.WriteLine(String.Join(separator, headerValues.ToArray()))
        End If

        Dim items() As String = Nothing
        'For Each row As DataRow In sourceTable.Rows
        items = sourceTable.ItemArray.Select(Function(obj) QuoteValue(obj.ToString())).ToArray()
        writer.WriteLine(String.Join(separator, items))
        'Next

        writer.Flush()
    End Sub

    Private Shared Function QuoteValue(ByVal value As String) As String
        Return String.Concat("""", value.Replace("""", """"""), """")
    End Function
End Class
