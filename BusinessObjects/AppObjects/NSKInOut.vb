Imports System.IO
Imports System.Text

Public Class NSKInOut
    Private da As New DataAccess
    'Private _NSK_ID As Integer = -1
    'Public ReadOnly Property NSK_ID() As Integer
    '    Get
    '        If _NSK_ID = -1 Then
    '            _NSK_ID = da.ExecuteScalar("select Id from Contr_instanties where naam = 'NSK'")
    '        End If
    '        Return _NSK_ID
    '    End Get
    'End Property
    Private _hashtotaal As Int64 = 0
    Public Property hashtotaal() As Int64
        Get
            Return _hashtotaal
        End Get
        Set(ByVal value As Int64)
            _hashtotaal = value
        End Set
    End Property
    Private _dtNSK As DataTable
    Public ReadOnly Property dtNSK() As DataTable
        Get
            If _dtNSK Is Nothing Then
                CreateNSKTable()
                FillNSKTable()
            End If
            Return _dtNSK
        End Get
    End Property
    Public Function RS(ByVal value As String, ByVal len As Int16) As String
        Return value.PadRight(len, " ")
    End Function
    Public Function LS(ByVal value As String, ByVal len As Int16) As String
        Return value.PadLeft(len, " ")
    End Function
    Public Function RI(ByVal value As String, ByVal len As Int16) As String
        Return value.PadRight(len, "0")
    End Function
    Public Function LI(ByVal value As String, ByVal len As Int16) As String
        Return value.PadLeft(len, "0")
    End Function
    Private Sub CreateNSKTable()
        Try
            _dtNSK = New DataTable
            'Code belangenvereniging    03 posities
            'Werknnum 6 posities        06 posities
            'Werknn 3                   03 posities
            'Vijfnaam                   05 posities
            'Datumingang                08 posities
            'Datumeinde                 08 posities
            'Mutatiecode                01 posities
            'Bedrag delegatie MSF       06 posities
            'Keuze berekeningsvariant   01 posities  1=bruto/netto maandelijks     2=netto/netto maandelijks
            'Filler                     03 posities  spaties/ nullen

            _dtNSK.Columns.Add("lidid", Type.GetType("System.Int32"))
            _dtNSK.Columns.Add("CodeVer", Type.GetType("System.String"))
            _dtNSK.Columns.Add("Werknn6", Type.GetType("System.String"))
            _dtNSK.Columns.Add("Werknn3", Type.GetType("System.String"))
            _dtNSK.Columns.Add("Vijfnaam", Type.GetType("System.String"))
            _dtNSK.Columns.Add("DatumIn", Type.GetType("System.String"))
            _dtNSK.Columns.Add("DatumUit", Type.GetType("System.String"))
            _dtNSK.Columns.Add("CodeMut", Type.GetType("System.String"))
            _dtNSK.Columns.Add("BedragMSF", Type.GetType("System.String"))
            _dtNSK.Columns.Add("berekening", Type.GetType("System.String"))
            _dtNSK.Columns.Add("Filler", Type.GetType("System.String"))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillNSKTable()
        Try
            Dim drNSK As DataRow
            drNSK = dtNSK.NewRow

            Dim dt As DataTable
            'Dim paramlist As New ArrayList
            Dim sAndOr As String = ""
            Dim sql As String = "SELECT id, lidnr, achternaam, init , tussenvoegsel, indatum, eindedatum, donatie_msf, NSKInOut, NSKDatum " & _
                                "FROM relaties " & _
                                "WHERE NSKInOut > 0"
            '"WHERE InstantieID = @InstantieID AND NSKInOut > 0"

            'paramlist.Add("@InstantieID")
            'paramlist.Add(NSK_ID)
            'dt = da.ExecuteDataTable(sql, paramlist.ToArray)
            dt = da.ExecuteDataTable(sql)
            'bereken de laatste dag vd huidige maand
            Dim LastDayCurrentMonth As Date = New DateTime(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1)
            Dim FirstDayCurrentMonth As Date = New DateTime(Today.Year, Today.Month, 1)
            Dim LastDayPrevMonth As Date = FirstDayCurrentMonth.AddDays(-1)

            For Each rw As DataRow In dt.Rows
                'NSKInOut: 1 = aanmelden
                'NSKInOut: 2 = afmelden
                'NSK afmeldingen moeten altijd worden verstuurd met de laatste dag van de maand. 
                'Dus 24-12-2012 mag niet (wordt niet geaccepteerd door NSK) Het systeem moet hier dus 31-12-2012 van maken. 

                drNSK = dtNSK.NewRow
                Dim lidnr As String = rw.Item("lidnr").ToString.PadLeft(9, "0")
                Dim naam As String = rw.Item("achternaam").ToString.ToUpper
                Dim MutCode As Integer = 1
                Dim msf As String = LI(rw.Item("donatie_msf").ToString.Replace(",", ""), 6)
                Dim DatumIn As String = ""
                Dim DatumUit As String = ""
                Dim NskDate As Date = Nothing

                If String.IsNullOrEmpty(rw.Item("NSKDatum").ToString) Then
                    NskDate = LastDayCurrentMonth
                Else
                    NskDate = rw.Item("NSKDatum")
                End If

                Dim LastDayNSKDate As Date = New DateTime(NskDate.Year, NskDate.Month, 1).AddMonths(1).AddDays(-1)

                'Dim iDays As Integer = DateDiff(DateInterval.Day, LastDayCurrentMonth, NskDate)
                Dim iMonths As Integer = DateDiff(DateInterval.Month, LastDayCurrentMonth, NskDate)

                If naam.Length > 5 Then naam = naam.Substring(0, 5)

                If rw.Item("NSKInOut") = 1 Then '= aanmelden
                    'alles wat in het verleden ligt en in huigige maand verwerken met 1e dag vd huidige maand
                    If LastDayNSKDate <= LastDayCurrentMonth Then
                        MutCode = 1
                        DatumIn = Format(FirstDayCurrentMonth, "yyyyMMdd") 'Format(NskDate, "yyyyMMdd")
                        DatumUit = Space(8)
                    Else
                        'anders het record overslaan en volgende x weer proberen, dus ook geen hashtotaal
                        Continue For
                    End If
                ElseIf rw.Item("NSKInOut") = 2 Then '= afmelden
                    If LastDayNSKDate < LastDayCurrentMonth Then
                        MutCode = 3
                        DatumIn = Space(8)
                        'dan wegschrijven met de laatste dag van de huidige maand
                        'DatumUit = Format(LastDayCurrentMonth, "yyyyMMdd")
                        'dan wegschrijven met de laatste dag van de vorige maand(bt508)
                        DatumUit = Format(LastDayPrevMonth, "yyyyMMdd")

                    Else
                        'anders het record overslaan, dus ook geen hashtotaal
                        Continue For
                    End If
                End If

                If msf = "000000" Then msf = Space(6)
                drNSK.Item("lidid") = rw.Item("id")
                drNSK.Item("CodeVer") = "011"
                drNSK.Item("Werknn6") = lidnr.Substring(0, 6)
                drNSK.Item("Werknn3") = lidnr.Substring(6, 3)
                drNSK.Item("Vijfnaam") = naam
                drNSK.Item("DatumIn") = DatumIn
                drNSK.Item("DatumUit") = DatumUit
                drNSK.Item("CodeMut") = MutCode
                drNSK.Item("BedragMSF") = msf
                drNSK.Item("berekening") = "1"
                drNSK.Item("Filler") = Space(3)
                dtNSK.Rows.Add(drNSK)

                'Tel de laatste 3 posities van alle werknemersnummers 
                hashtotaal += CInt(lidnr.Substring(6, 3))
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub reset()
        Try
            Dim i As Integer = dtNSK.Rows.Count
            Dim MyRelatie As Relaties = Nothing

            For Each drNSK As DataRow In dtNSK.Rows
                MyRelatie = New Relaties(drNSK.Item("lidid"), Relaties.Via.ID)
                If MyRelatie.Found Then
                    MyRelatie.NSKInOut = 0
                    MyRelatie.NSKDatum = ""
                    MyRelatie.SaveByNSK()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Process()
        Try
            Dim i As Integer = dtNSK.Rows.Count
            Dim h As Integer = hashtotaal
            CreateString()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CreateString()
        Try
            Dim sb As New StringBuilder
            If dtNSK.Rows.Count > 0 Then
                Dim FirstDayCurrentMonth As Date = New DateTime(Today.Year, Today.Month, 1)
                sb.AppendLine("010" & Format(FirstDayCurrentMonth, "yyyyMMdd") & LI(hashtotaal.ToString, 7))
                'sb.AppendLine("010" & dtNSK.Rows(0).Item("DatumIn") & LI(hashtotaal.ToString, 7))
                For Each drNSK As DataRow In dtNSK.Rows
                    sb.Append(drNSK.Item("CodeVer"))
                    sb.Append(drNSK.Item("Werknn6"))
                    sb.Append(drNSK.Item("Werknn3"))
                    sb.Append(RS(drNSK.Item("Vijfnaam"), 5))
                    sb.Append(RS(drNSK.Item("DatumIn"), 6))
                    sb.Append(RS(drNSK.Item("DatumUit"), 6))
                    sb.Append(drNSK.Item("CodeMut"))
                    sb.Append(drNSK.Item("BedragMSF"))
                    sb.Append(drNSK.Item("berekening"))
                    sb.Append(drNSK.Item("Filler"))
                    sb.AppendLine()
                Next
            End If
            WriteFile(MyDocuments & "\NSK\" & "vbm.txt", sb.ToString, False)
            System.Diagnostics.Process.Start(MyDocuments & "\NSK\" & "vbm.txt")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
