Imports System.Windows.Forms
Imports System.IO
Imports System.Text

Public Module mUtils
    Enum eCategory
        'geel = 1, groen = 2, blauw = 3, oranje = 4, paars = 5, rood = 6 , roze = 7,bruin = 8, olijf = 9
        '  = CType(i, eCategory).ToString
        '  = DirectCast([Enum].Parse(GetType(eCategory), level), eCategory)
        geen
        geel
        groen
        blauw
        oranje
        paars
        rood
        roze
        bruin
        olijf
    End Enum
    Enum eMaand
        geen
        jan
        feb
        mar
        apr
        mei
        jun
        jul
        aug
        sep
        okt
        nov
        dec
    End Enum

    Enum eMaandFull
        onbekend
        Januari
        Februari
        Maart
        April
        Mei
        Juni
        Juli
        Augustus
        September
        Oktober
        November
        December
    End Enum
    Public Function GetSysSettingOf(ByVal SearchValue As String, Optional ReturnError As Boolean = True) As String
        Dim sys As Systeeminstellingen = New Systeeminstellingen(SearchValue, Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
        If Not sys.Found And ReturnError = True Then
            Throw New Exception(SearchValue & " kon niet worden gevonden in de systeeminstellingen tabel! " & vbCrLf & "Controleer de systeeminstellingen!")
        Else
            Return sys.Waarde
        End If
    End Function

    Private _DummyValue As String
    Public ReadOnly Property DummyValue() As String
        Get
            If _DummyValue Is Nothing Then
                Dim sys As New Systeeminstellingen("DummyNr", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _DummyValue = sys.Waarde
            End If

            Return _DummyValue
        End Get
    End Property


    Public Sub OpenHelpUrl(ByVal ModuleName As String)
        Try
            Dim locationURL As String = GetSysSettingOf("HelpUrl")
            If Not locationURL.EndsWith("\") Then locationURL &= "\"

            ModuleName = ModuleName.ToLower
            If ModuleName.StartsWith("frm") Then ModuleName = ModuleName.Replace("frm", "")
            If ModuleName.StartsWith("dlg") Then ModuleName = ModuleName.Replace("dlg", "")

            Process.Start(locationURL & ModuleName & ".htm")

        Catch ex1 As FileNotFoundException
            Throw New Exception("Help bestand ''" & ModuleName & ".htm'' is niet gevonden")
        Catch ex2 As System.ComponentModel.Win32Exception
            Throw New Exception("Help bestand ''" & ModuleName & ".htm'' is niet gevonden")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub GetMyMonthListWeb(ByVal MyddlMonthList As Web.UI.WebControls.DropDownList, ByVal SetCurruntMonth As Boolean)
        Dim month As DateTime = Convert.ToDateTime("1/1/2000")
        For i As Integer = 0 To 11

            Dim NextMont As DateTime = month.AddMonths(i)
            Dim list As New Web.UI.WebControls.ListItem()
            list.Text = NextMont.ToString("MMMM")
            list.Value = NextMont.Month.ToString()
            MyddlMonthList.Items.Add(list)
        Next
        If SetCurruntMonth = True Then
            MyddlMonthList.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = True
        End If
    End Sub

    Public Sub GetMyYearListWeb(ByVal MyddlYearList As Web.UI.WebControls.DropDownList, ByVal YearPre As Integer, ByVal YearSuf As Integer, ByVal SetCurruntYear As Boolean)
        Dim iYear As Integer = Today.Year
        Dim FisrtYear As Integer = iYear - YearPre
        Dim LastYear As Integer = iYear + YearSuf

        For i As Integer = FisrtYear To LastYear
            Dim list As New Web.UI.WebControls.ListItem()
            list.Text = i
            list.Value = i
            MyddlYearList.Items.Add(list)
        Next
        If SetCurruntYear = True Then
            MyddlYearList.Items.FindByValue(iYear).Selected = True
        End If
    End Sub
    Public Function ExtractPageName(ByVal path As String) As String
        Dim pagename As String() = path.Split(New Char() {"/"c})
        Return pagename((pagename.Length - 1))
    End Function
    Public Sub Auto_CompleteCombo(ByVal cbo As Windows.Forms.ComboBox)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String
        Try
            'Get the Typed Text and Find it in the list
            sTypedText = cbo.Text.Trim
            iFoundIndex = cbo.FindString(sTypedText)

            'If we found the Typed Text in the list then Autocomplete
            If iFoundIndex >= 0 Then

                'Get the Item from the list (Return Type depends if Datasource was bound or List Created)
                oFoundItem = cbo.Items(iFoundIndex)

                'Use the ListControl.GetItemText to resolve the Name in case the Combo was Data bound
                sFoundText = cbo.GetItemText(oFoundItem)

                'Append then found text to the typed text to preserve case
                sAppendText = sFoundText.Substring(sTypedText.Length)
                cbo.Text = sTypedText & sAppendText

                'Select the Appended Text
                cbo.SelectionStart = sTypedText.Length
                cbo.SelectionLength = sAppendText.Length
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EnabledDisabledRelatieFormControls(ByVal frm As Control, ByVal chgmod As Boolean)
        For Each ctl As Control In frm.Controls
            If ctl.GetType().ToString = "System.Windows.Forms.Button" Then
                If TypeOf (ctl) Is Button Then
                    Dim control As Button = ctl
                    control.Enabled = chgmod
                End If
            End If
            If ctl.GetType().ToString = "System.Windows.Forms.TabControl" Or _
                ctl.GetType().ToString = "System.Windows.Forms.TabPage" Or _
                ctl.GetType().ToString = "System.Windows.Forms.GroupBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.Panel" Then
                Call EnabledDisabledRelatieFormControls(ctl, chgmod)
            End If
        Next
    End Sub
    Public Sub DisabledFormControls(ByVal frm As Control, ByVal chgmod As Boolean)

        If frm.GetType().ToString = "System.Windows.Forms.ToolStrip" Then
            For Each itm As Object In DirectCast(frm, System.Windows.Forms.ToolStrip).Items
                If itm.GetType().ToString = "System.Windows.Forms.ToolStripMenuItem" Or _
                    itm.GetType().ToString = "System.Windows.Forms.ToolStripButton" Then
                    itm.Enabled = Not chgmod
                End If
            Next
        End If

        For Each ctl As Control In frm.Controls
            If ctl.GetType().ToString = "System.Windows.Forms.RadioButton" Or _
                ctl.GetType().ToString = "System.Windows.Forms.DataGridView" Or _
                ctl.GetType().ToString = "System.Windows.Forms.TextBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.DateTimePicker" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ComboBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.Button" Or _
                ctl.GetType().ToString = "System.Windows.Forms.CheckBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ListView" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ToolStripMenuItem" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ToolStripButton" Or _
                ctl.GetType().ToString = "VBMRelaties.ucTextDate" Then
                ctl.Enabled = Not chgmod
                'ctl.GetType().ToString = "System.Windows.Forms.ToolStrip" Or _
                If chgmod Then
                    If ctl.GetType().ToString = "System.Windows.Forms.CheckBox" Or _
                        ctl.GetType().ToString = "System.Windows.Forms.RadioButton" Or _
                        ctl.GetType().ToString = "System.Windows.Forms.ComboBox" Or _
                        ctl.GetType().ToString = "VBMRelaties.ucTextDate" Then
                    Else
                        ctl.BackColor = Drawing.Color.White
                        ctl.ForeColor = Drawing.SystemColors.ControlText
                    End If
                End If


            End If
            If ctl.GetType().ToString = "System.Windows.Forms.TabControl" Or _
                ctl.GetType().ToString = "System.Windows.Forms.TabPage" Or _
                ctl.GetType().ToString = "System.Windows.Forms.GroupBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ToolStrip" Or _
                ctl.GetType().ToString = "System.Windows.Forms.Panel" Then

                Call DisabledFormControls(ctl, chgmod)

            End If
        Next
    End Sub
    Public Sub Hide_FormControls(ByVal frm As Control, ByVal chgmod As Boolean)
        For Each ctl As Control In frm.Controls
            If ctl.GetType().ToString = "System.Windows.Forms.RadioButton" Or _
                ctl.GetType().ToString = "System.Windows.Forms.DataGridView" Or _
                ctl.GetType().ToString = "System.Windows.Forms.TextBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.DateTimePicker" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ComboBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.Button" Or _
                ctl.GetType().ToString = "System.Windows.Forms.CheckBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ListView" Or _
                ctl.GetType().ToString = "VBMRelaties.ucTextDate" Then
                ctl.Visible = Not chgmod
            End If
            If ctl.GetType().ToString = "System.Windows.Forms.TabControl" Or _
                ctl.GetType().ToString = "System.Windows.Forms.TabPage" Or _
                ctl.GetType().ToString = "System.Windows.Forms.GroupBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.Panel" Then
                Call Hide_FormControls(ctl, chgmod)
            End If
        Next
    End Sub
    Public Sub RemoveTabpages(ByVal MainTab As TabControl, ByVal chgmod As Boolean)
        For Each tab As TabPage In MainTab.TabPages
            If tab.Name = "Tabtmp" Then Continue For
            If chgmod = True Then
                MainTab.TabPages.Remove(tab)
            End If
        Next
    End Sub
    Public Function FindFormControl(ByVal frm As Control, ByVal ControlName As String, Optional ByVal FoundControl As Control = Nothing) As Control
        'Dim FoundControl As Control = Nothing
        If Not FoundControl Is Nothing Then Return FoundControl

        For Each ctl As Control In frm.Controls
            If ctl.GetType().ToString = "System.Windows.Forms.RadioButton" Or _
                ctl.GetType().ToString = "System.Windows.Forms.DataGridView" Or _
                ctl.GetType().ToString = "System.Windows.Forms.TextBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.DateTimePicker" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ComboBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.ComboBox" Or _
                ctl.GetType().ToString = "VBMRelaties.ucTextDate" Then
                If ctl.Name = ControlName Then
                    FoundControl = ctl
                    Return FoundControl
                    Exit For
                End If

            End If

            If ctl.GetType().ToString = "System.Windows.Forms.TabControl" Or _
                ctl.GetType().ToString = "System.Windows.Forms.TabPage" Or _
                ctl.GetType().ToString = "System.Windows.Forms.GroupBox" Or _
                ctl.GetType().ToString = "System.Windows.Forms.Panel" Then
                FoundControl = FindFormControl(ctl, ControlName, FoundControl)
            End If
        Next
        Return FoundControl
    End Function
    Private _MyDocuments As String = ""
    Public ReadOnly Property MyDocuments() As String
        Get
            If String.IsNullOrEmpty(_MyDocuments) Then
                _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            Return _MyDocuments
        End Get
    End Property
    Public Sub WriteFile(ByVal FullName As String, ByVal Value As String, Optional ByVal bAppend As Boolean = True)
        Dim myWriter As IO.StreamWriter = Nothing
        Try
            Dim oFileInfo As System.IO.FileInfo = New System.IO.FileInfo(FullName)

            'Als file of dir nog niet bestaat maak het dan
            Dim di As New IO.DirectoryInfo(oFileInfo.DirectoryName)
            If Not di.Exists Then di.Create()
            myWriter = New IO.StreamWriter(FullName, bAppend, System.Text.Encoding.GetEncoding("ISO8859-1"))
            myWriter.Write(Value)

        Catch ex As System.IO.IOException
            EventLog.WriteEntry("VBMNOV", "Writefile: " & ex.Message, EventLogEntryType.Error)
        Finally
            If Not (myWriter Is Nothing) Then myWriter.Close()
        End Try
    End Sub
    Public Sub CheckPathExists(path As String)
        Try

            'Als dir nog niet bestaat maak het dan
            Dim di As New IO.DirectoryInfo(path)
            If Not di.Exists Then di.Create()


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Enum eElfCheckType
        Account
        SoFi
    End Enum
    Function RemoveAccentMarks(ByVal sValue As String) As String

        Dim normalizedString As String = sValue.Normalize(NormalizationForm.FormD)
        Dim stringBuilder As New StringBuilder()

        Dim c As Char
        For i = 0 To normalizedString.Length - 1
            c = normalizedString(i)
            If System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) <> System.Globalization.UnicodeCategory.NonSpacingMark Then
                stringBuilder.Append(c)
            End If
        Next
        Return stringBuilder.ToString

    End Function
    Public Function ValidEmail(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) As Boolean
        ValidEmail = True
        Dim errorMessage As String = "Het E-mailadres heeft een ongeldig formaat."
        Dim textbox As TextBox = sender
        If textbox.Text.Length = 0 Then textbox.BackColor = System.Drawing.Color.White : Exit Function
        textbox.Text = textbox.Text.Trim

        textbox.Text = RemoveAccentMarks(textbox.Text)

        'Dim regex As New Text.RegularExpressions.Regex("^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegularExpressions.RegexOptions.IgnoreCase)
        'Dim regex As New Text.RegularExpressions.Regex("^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegularExpressions.RegexOptions.IgnoreCase)
        'Dim regex As New Text.RegularExpressions.Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", RegularExpressions.RegexOptions.IgnoreCase)
        Dim regex As New Text.RegularExpressions.Regex("^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$", RegularExpressions.RegexOptions.IgnoreCase)


        If Not regex.IsMatch(textbox.Text) Then
            textbox.ForeColor = Drawing.Color.Red
            MsgBox(textbox.Text & vbCrLf & errorMessage)
            ValidEmail = False
        Else
            textbox.ForeColor = Drawing.Color.Black
        End If

    End Function
    Public Function ValidEmail(ByVal Value As String) As Boolean
        ValidEmail = True
        'Dim errorMessage As String = "Het E-mailadres heeft een ongeldig formaat." + ControlChars.Cr + "voorbeeld 'naam@domein.nl' "

        If String.IsNullOrEmpty(Value) Then Return False
        Value = RemoveAccentMarks(Value)
        'Dim regex As New Text.RegularExpressions.Regex("^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegularExpressions.RegexOptions.IgnoreCase)
        'Dim regex As New Text.RegularExpressions.Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", RegularExpressions.RegexOptions.IgnoreCase)
        'Dim regex As New Text.RegularExpressions.Regex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", RegularExpressions.RegexOptions.IgnoreCase)
        Dim regex As New Text.RegularExpressions.Regex("^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$", RegularExpressions.RegexOptions.IgnoreCase)

        If Not regex.IsMatch(Value) Then
            ValidEmail = False
        End If

        Return ValidEmail
    End Function
    Public Function Elfproef(ByVal number As String, ByVal elftype As eElfCheckType) As Boolean
        Try
            Dim valid As Boolean = True

            ' controleer of het numeriek is. 
            If Not IsNumeric(number) Then
                Return False
            End If

            ' controleer of de lengte 9 of 10 is 
            If number.Length < 9 Or number.Length > 10 Then
                Return False
            End If

            ' doe de elf-proef 
            Dim sum As Integer = 0
            For i As Integer = 0 To number.Length - 2
                sum += CType(number.Substring(i, 1), Integer) * (number.Length - i)
            Next

            If elftype = eElfCheckType.Account Then
                sum += CType(number.Substring(number.Length - 1), Integer)
            ElseIf elftype = eElfCheckType.SoFi Then
                sum -= CType(number.Substring(number.Length - 1), Integer)
            End If


            If sum = 0 Then
                Return False
            End If

            ' De elfproef is geslaagd als de deling van de basis door 11 geen restwaarde oplevert.
            Return sum Mod 11 = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CheckIfAlphaNumeric(Str As String) As Boolean
        Dim IsAlpha As Boolean = True
        Dim c As Char

        Try
            For i As Integer = 0 To Str.Count - 1
                c = Str.Chars(i)
                If Not IsNumeric(c) And Not IsAlphabet(c) Then
                    IsAlpha = False
                    Exit For
                End If
            Next
        Catch ex As Exception
            IsAlpha = False
        End Try

        Return IsAlpha
    End Function


    Public Function IsAlphabet(alpha As String) As Boolean

        Dim IsA As Boolean = False
        Try
            IsA = (Asc(alpha) >= 65 And Asc(alpha) <= 90) Or (Asc(alpha) >= 97 And Asc(alpha) <= 122)

        Catch ex As Exception
            IsA = False
        End Try
        Return IsA

    End Function
    Public Function validate_iban(ibanstring As String) As Boolean
        Try
            If Not ValidateOnSpaces(ibanstring) Then Return False

            validate_iban = False
            Dim tempinteger As Long
            Dim tempstr As String
            Dim divstr As String
            tempstr = Convert_to_iban_numbers(ibanstring)
            '4.Bereken dan het getal modulo 97.
            Do Until Len(tempstr) <= 5
                divstr = Left(tempstr, 5)
                If Len(tempstr) > 5 Then
                    tempstr = Right(tempstr, Len(tempstr) - 5)
                End If
                tempinteger = Format(divstr)
                tempstr = Str(tempinteger Mod 97) + tempstr
            Loop
            tempinteger = Format(tempstr)

            ' 5.Als de restwaarde 1 is, dan klopt het nummer op basis van de check digit en kan de IBAN valide zijn.
            If (tempinteger Mod 97) = 1 Then
                validate_iban = True
            Else
                validate_iban = False
            End If
            Return validate_iban
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function Convert_to_iban_numbers(mystring As String) As String
        Try
            Dim tempstr As String
            Dim i As Integer
            Dim character As String
            tempstr = mystring
            REM Step  2.Verplaats de eerste 4 karakters naar het einde
            If Len(mystring) > 4 Then
                tempstr = Right(mystring, Len(mystring) - 4) + Left(mystring, 4)
            End If
            REM step 3.Vervang elke letter door 2 cijfers, waarbij A = 10, B = 11, ..., Z = 35
            i = 1
            Do Until i > Len(tempstr)
                character = Mid(tempstr, i, 1)
                Select Case character
                    Case "A"
                        tempstr = Left(tempstr, i - 1) + "10" + Right(tempstr, Len(tempstr) - i)
                    Case "B"
                        tempstr = Left(tempstr, i - 1) + "11" + Right(tempstr, Len(tempstr) - i)
                    Case "C"
                        tempstr = Left(tempstr, i - 1) + "12" + Right(tempstr, Len(tempstr) - i)
                    Case "D"
                        tempstr = Left(tempstr, i - 1) + "13" + Right(tempstr, Len(tempstr) - i)
                    Case "E"
                        tempstr = Left(tempstr, i - 1) + "14" + Right(tempstr, Len(tempstr) - i)
                    Case "F"
                        tempstr = Left(tempstr, i - 1) + "15" + Right(tempstr, Len(tempstr) - i)
                    Case "G"
                        tempstr = Left(tempstr, i - 1) + "16" + Right(tempstr, Len(tempstr) - i)
                    Case "H"
                        tempstr = Left(tempstr, i - 1) + "17" + Right(tempstr, Len(tempstr) - i)
                    Case "I"
                        tempstr = Left(tempstr, i - 1) + "18" + Right(tempstr, Len(tempstr) - i)
                    Case "J"
                        tempstr = Left(tempstr, i - 1) + "19" + Right(tempstr, Len(tempstr) - i)
                    Case "K"
                        tempstr = Left(tempstr, i - 1) + "20" + Right(tempstr, Len(tempstr) - i)
                    Case "L"
                        tempstr = Left(tempstr, i - 1) + "21" + Right(tempstr, Len(tempstr) - i)
                    Case "M"
                        tempstr = Left(tempstr, i - 1) + "22" + Right(tempstr, Len(tempstr) - i)
                    Case "N"
                        tempstr = Left(tempstr, i - 1) + "23" + Right(tempstr, Len(tempstr) - i)
                    Case "O"
                        tempstr = Left(tempstr, i - 1) + "24" + Right(tempstr, Len(tempstr) - i)
                    Case "P"
                        tempstr = Left(tempstr, i - 1) + "25" + Right(tempstr, Len(tempstr) - i)
                    Case "Q"
                        tempstr = Left(tempstr, i - 1) + "26" + Right(tempstr, Len(tempstr) - i)
                    Case "R"
                        tempstr = Left(tempstr, i - 1) + "27" + Right(tempstr, Len(tempstr) - i)
                    Case "S"
                        tempstr = Left(tempstr, i - 1) + "28" + Right(tempstr, Len(tempstr) - i)
                    Case "T"
                        tempstr = Left(tempstr, i - 1) + "29" + Right(tempstr, Len(tempstr) - i)
                    Case "U"
                        tempstr = Left(tempstr, i - 1) + "30" + Right(tempstr, Len(tempstr) - i)
                    Case "V"
                        tempstr = Left(tempstr, i - 1) + "31" + Right(tempstr, Len(tempstr) - i)
                    Case "W"
                        tempstr = Left(tempstr, i - 1) + "32" + Right(tempstr, Len(tempstr) - i)
                    Case "X"
                        tempstr = Left(tempstr, i - 1) + "33" + Right(tempstr, Len(tempstr) - i)
                    Case "Y"
                        tempstr = Left(tempstr, i - 1) + "34" + Right(tempstr, Len(tempstr) - i)
                    Case "Z"
                        tempstr = Left(tempstr, i - 1) + "35" + Right(tempstr, Len(tempstr) - i)
                End Select
                i = i + 1
            Loop
            Convert_to_iban_numbers = tempstr
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function validate_biccode(bicstring As String) As Boolean
        Dim result As Boolean = False

        If String.IsNullOrEmpty(bicstring) Then Return False
        If bicstring.Length <> 8 Then Return False
        If Not ValidAlphaNummeric(bicstring) Then Return False

        Return True

    End Function


    Public Function ValidAlphaNummeric(ByVal str As String) As Boolean
        Dim pattern As String = "^[a-zA-Z0-9]+$"
        Dim reg As New RegularExpressions.Regex(pattern)
        Return reg.IsMatch(str)

    End Function
    Public Sub ValidAlphaNummeric(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If TypeOf (sender) Is TextBox Then
            Dim textbox As TextBox = sender

            If textbox.Text = "" Then
                textbox.BackColor = System.Drawing.Color.White
                Exit Sub
            End If

            Dim errorMessage As String = "Alleen alfanumerieke karakters'" ' & textbox.Name
            If Not ValidAlphaNummeric(textbox.Text) Then
                textbox.BackColor = System.Drawing.Color.Red
                MessageBox.Show(textbox.Text & vbCrLf & errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                textbox.Focus()
            Else
                textbox.BackColor = System.Drawing.Color.White
            End If
        End If
    End Sub

    Public Function NoWhiteSpace(ByVal strText As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(strText, " ", String.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
    Public Function ValidateOnSpaces(ByVal str As String) As Boolean
        Dim pattern As String = "^[a-zA-Z0-9]+$"
        Dim reg As New RegularExpressions.Regex(pattern)
        Return reg.IsMatch(str)
    End Function
    Public Function FindFirstAlpha(ByVal value As String) As Integer
        Dim i As Long, j As Long
        For i = 1 To Len(value)
            If Not IsNumeric(Mid(value, i, 1)) Then
                Return i
            End If
        Next i

        Return 0
    End Function
    'Public Function IsValidIBAN(ByVal IBAN As String) As Boolean
    '    IBAN = UCase(Replace(IBAN, " ", ""))
    '    IsValidIBAN = False
    '    If Len(IBAN) < 6 Or Len(IBAN) > 34 Then Exit Function
    '    If Not Left(IBAN, 4) Like "[A-Z][A-Z]##" Then Exit Function

    '    If Not Mid(IBAN, 5) Like GetBBANFormat(Left(IBAN, 2)) Then Exit Function
    '    IBAN = Mid(IBAN, 5) & Left(IBAN, 4)
    '    IsValidIBAN = (GetMod97(IBAN) = 1)
    'End Function

    'Public Sub PrintFileProcess(Files As List(Of String))
    Public Sub PrintFileProcess(FileName As String)
        Try
            'For Each FileName In Files
            If String.IsNullOrEmpty(FileName) Then Throw New Exception("Bestandsnaam mag niet leeg zijn!")
            Dim fi As IO.FileInfo = New IO.FileInfo(FileName)
            If Not fi.Exists Then Throw New Exception("Bestand kan niet worden gevonden.")
            fi = Nothing


            Dim psi As New ProcessStartInfo(FileName)


            'If psi.Verbs.Contains("Print") Then
            psi.Verb = "Print"
            psi.UseShellExecute = True
            psi.WindowStyle = ProcessWindowStyle.Hidden
            psi.CreateNoWindow = True
            psi.ErrorDialog = True
            Process.Start(psi).WaitForExit(500)

            'Dim ready As Boolean = False
            'While ready = False
            '    ready = Process.Start(psi).HasExited
            'End While


            ' Else
            'MessageBox.Show("No 'print' verb associated with file extension " & IO.Path.GetExtension(FileName))
            '
            ' End If
            'Next



        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Function LastDayCurrentMonth() As Date
        Return New DateTime(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1)
    End Function

    Public Function FirstDayCurrentMonth() As Date
        Return New DateTime(Today.Year, Today.Month, 1)
    End Function
    Public Function AddTimeToDate(mydate As String, mytime As String) As DateTime
        Try
            Dim dd As DateTime = mydate
            If Not String.IsNullOrEmpty(mytime) Then
                Dim HrsMin() As String = mytime.Split(":"c)
                dd = dd.AddHours(HrsMin(0))
                dd = dd.AddMinutes(HrsMin(1))
            End If

            Return dd
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConvertAccent(ByVal Value As String) As String
        Dim AccChars As String = "ŠŽšžŸÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖÙÚÛÜÝàáâãäåçèéêëìíîïðñòóôõöùúûüýÿßþ&@#$%^*"
        Dim RegChars As String = "SZszYAAAAAACEEEEIIIIDNOOOOOUUUUYaaaaaaceeeeiiiidnooooouuuuyy----hsp--"

        Dim nI As Long
        Dim tempString As String
        Dim currentCharacter As String
        Dim found As Boolean
        Dim foundPosition As Long

        tempString = Value
        Select Case True
            Case Len(AccChars) <= Len(Value)
                For nI = 0 To AccChars.Length - 1
                    currentCharacter = AccChars.Substring(nI, 1)
                    If InStr(tempString, currentCharacter) > 0 Then
                        tempString = Replace(tempString, currentCharacter, RegChars.Substring(nI, 1))
                    End If
                Next
            Case Len(AccChars) > Len(Value)
                For nI = 0 To Len(Value) - 1
                    currentCharacter = Value.Substring(nI, 1)
                    found = (InStr(AccChars, currentCharacter) > 0)
                    If found Then
                        foundPosition = InStr(AccChars, currentCharacter)
                        tempString = Replace(tempString, currentCharacter, RegChars.Substring(foundPosition, 1))
                    End If
                Next
        End Select

        Return tempString
    End Function

    Public Function IsWordRunning() As Boolean
        Dim oApp As Object
        On Error Resume Next
        oApp = GetObject(, "Word.Application")
        If Not oApp Is Nothing Then
            oApp = Nothing
            IsWordRunning = True
        End If
        Return IsWordRunning

    End Function

End Module
