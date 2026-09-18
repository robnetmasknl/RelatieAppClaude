Imports System.Reflection

Public Class WebLid
    Inherits tblWebLid
    Private da As New DataAccess
    'Public List As LedenLijst

    Enum Via
        ID
        LIDNR
        LOGIN
    End Enum
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LIDNR" Then
            ohelper.FillObject(Me, GetByLidNr(id))
        End If

    End Sub
    Public Sub New(ByVal id As String, ByVal password As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "LOGIN" Then
            ohelper.FillObject(Me, GetByLogin(id, password))
        End If

    End Sub
    Public Function ShallowCopy() As Lidmaat
        Return DirectCast(Me.MemberwiseClone(), Lidmaat)
    End Function
    Public Function IsChanged(ByVal obj As Object) As Boolean
        IsChanged = False
        Dim props() As PropertyInfo = Me.GetType().GetProperties()
        Dim pi As System.Reflection.PropertyInfo = Nothing
        For Each prop As PropertyInfo In props
            If prop.CanRead Then
                For Each attributeObject As Object In prop.GetCustomAttributes(False)
                    If attributeObject.GetType() Is GetType(MapperColumn) Then
                        pi = obj.GetType().GetProperty(prop.Name)
                        If (prop.GetValue(Me, Nothing)) = pi.GetValue(obj, Nothing) Then
                            ' Dim s As String = prop.GetValue(Me, Nothing) & "  - " & pi.GetValue(obj, Nothing)
                        Else
                            Return True
                            ' Dim s As String = prop.Name & "gewijzigd: " & prop.GetValue(Me, Nothing) & "  in  " & pi.GetValue(obj, Nothing)
                            ' Throw New Exception(s)
                        End If
                    End If
                Next
            End If
        Next

        Return IsChanged

    End Function
    Public Function TimeStampChanged() As Boolean
        Dim lastTimeStamp As DateTime
        Dim param() As Object = {"@id", Id}
        If Not IsDBNull(da.ExecuteScalar("SELECT LastChangeDate FROM Relaties where Id = @id", param)) Then
            lastTimeStamp = da.ExecuteScalar("SELECT LastChangeDate FROM Relaties where Id = @id", param)
        End If
        If Me.LastChangeDate.ToString("yyyyMMddHHmmss") = lastTimeStamp.ToString("yyyyMMddHHmmss") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function GetByLogin(ByVal id As String, ByVal password As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM relaties where lidnr = @lidnr AND wachtwoord = @wachtwoord"
            Dim param() As Object = {"@lidnr", id, "@wachtwoord", password}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetById(ByVal id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM relaties where id = '" & id & "'"
            oDr = da.ExecuteDataRow(sql)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetByLidNr(ByVal lidnr As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM relaties where lidnr = @lidnr"
            Dim param() As Object = {"@lidnr", lidnr}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
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
    Public Sub Save()
        Try
            Dim da As New DataAccess

            If Me.Id = Nothing Then
                'Me.LastChangeDate = Now
                'If String.IsNullOrEmpty(lidnr) Or lidnr = "0" Then
                '    lidnr = da.MaxLidNr()
                'End If
                'Id = da.InsertString(Me, "relaties", "Id", True)
                Throw New Exception("Sorry, kan onbekend lidnummer niet opslaan!")
            Else
                If da.isChanged(Me, "Relaties", "Id", Id, Id) Then
                    Me.LastChangeDate = Now
                    da.UpdateString(Me, "Relaties", "Id")
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Private _EmailMasker As String
    Public ReadOnly Property EmailMasker() As String
        Get
            Dim BasicMail As String = b_email
            Dim mailDomain As String = BasicMail.Remove(0, BasicMail.IndexOf("@"))
            Dim mailName As String = BasicMail.Substring(0, BasicMail.IndexOf("@"))
            Dim LastChars As String = ""
            Dim FirstChars As String = ""
            Dim sChar As String = ""

            Select Case mailName.Length
                Case Is < 7
                    LastChars = mailName.Remove(0, mailName.Length - 2)
                    'For i = 1 To (mailName.Length - LastChars.Length)
                    '    sChar = "*" & sChar
                    'Next
                    _EmailMasker = "*****" & LastChars & mailDomain
                Case Else
                    LastChars = mailName.Remove(0, mailName.Length - 2)
                    FirstChars = mailName.Substring(0, 1)
                    For i = 1 To (mailName.Length - LastChars.Length - 1)
                        sChar = "*" & sChar
                    Next
                    _EmailMasker = FirstChars & sChar & LastChars & mailDomain
            End Select
            Return _EmailMasker
        End Get
    End Property


    Private _FullName As String = ""
    <MapperExport("FullName")>
    Public Property FullName() As String
        Get
            _FullName = achternaam
            If Not String.IsNullOrEmpty(tussenvoegsel) Then _FullName = tussenvoegsel & " " & _FullName
            If Not String.IsNullOrEmpty(init) Then _FullName = init & " " & _FullName

            Select Case geslacht.ToUpper
                Case "MAN"
                    _FullName = "Dhr. " & _FullName
                Case "VROUW"
                    _FullName = "Mvr. " & _FullName
                Case "ONBEKEND"
                    '_FullName = _FullName
            End Select

            Return _FullName
        End Get
        Set(ByVal value As String)
            _FullName = value
        End Set
    End Property

    Private _CurrentBoeking As Boeking
    Public ReadOnly Property CurrentBoeking() As Boeking
        Get
            If _CurrentBoeking Is Nothing Then
                _CurrentBoeking = New Boeking(Id, Boeking.Via.RELID)
            End If
            Return _CurrentBoeking
        End Get
    End Property
    Private _Boeking_Message As String = ""
    Public ReadOnly Property Boeking_Message() As String
        Get
            If CurrentBoeking.Found Then
                Dim MyLocatie As New Locaties(CurrentBoeking.Blok.locatieid)
                Dim LocationAdres123 As String = ""
                Dim LocationAdres As String = ""
                Dim LocationNew As String = ""
                If MyLocatie.Found Then

                    With MyLocatie
                        If .LocatieNieuw Then LocationNew &= "<font color='red'><b> LET OP: NIEUWE LOCATIE,</b> </font>" & vbCrLf
                        If Not String.IsNullOrEmpty(.Address1) Then LocationAdres123 &= .Address1 & ", "
                        If Not String.IsNullOrEmpty(.Address2) Then LocationAdres123 &= .Address2 & ", "
                        If Not String.IsNullOrEmpty(.Address3) Then LocationAdres123 &= .Address3 & ", "
                        If Not String.IsNullOrEmpty(.Street) Then LocationAdres &= .Street & ", "
                        If Not String.IsNullOrEmpty(.Postcode) Then LocationAdres &= .Postcode & ", "
                        If Not String.IsNullOrEmpty(.Plaats) Then LocationAdres &= .Plaats & ", "
                    End With

                    If LocationAdres123.EndsWith(", ") Then LocationAdres123 = LocationAdres123.Remove(LocationAdres123.LastIndexOf(", "), 2)
                    If LocationAdres.EndsWith(", ") Then LocationAdres = LocationAdres.Remove(LocationAdres.LastIndexOf(", "), 2)

                    If Not String.IsNullOrEmpty(LocationAdres123) Then LocationAdres123 = "Adres: " & LocationAdres123 & vbCrLf
                    If Not String.IsNullOrEmpty(LocationAdres) Then LocationAdres = "Adres: " & LocationAdres & vbCrLf

                End If


                If MyLocatie.Offline = True Then
                    _Boeking_Message = FullName & " heeft al aangegeven vbm de aangifte te laten verzorgen. "
                Else
                    _Boeking_Message = FullName & " heeft het volgende blok gereserveerd. " & vbCrLf &
                        " " & vbCrLf & LocationNew &
                        "locatie: " & CurrentBoeking.Blok.LocatieNaam & vbCrLf &
                        LocationAdres123 & LocationAdres &
                        "Datum: " & CurrentBoeking.tijdstip.ToLongDateString & vbCrLf &
                        "Tijdstip: " & CurrentBoeking.tijdstip.ToShortTimeString
                End If
            End If

            Return _Boeking_Message
        End Get
    End Property

End Class
