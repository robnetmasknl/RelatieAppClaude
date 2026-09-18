Imports System.ComponentModel

Public Class LedenLijst

    Public _DOB As Date = Date.MinValue
    Public _SearchName As String = String.Empty

    Private _ByDOBNAME As List(Of Lidmaat)
    Public Property ByDOBNAME() As List(Of Lidmaat)
        Get
            If _DOB = Date.MinValue Then Throw New Exception("Geboortedatum is niet ingevuld!")
            If String.IsNullOrEmpty(_SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")

            If _ByDOBNAME Is Nothing Then
                _ByDOBNAME = New List(Of Lidmaat)
                Dim _lid As New Lidmaat
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND geboortedatum = @DOB AND achternaam = @naam"
                Dim param() As Object = {"@DOB", _DOB, "@naam", _SearchName}
                _ByDOBNAME = ohelper.MapDataTableToList(Of Lidmaat)(_lid.GetList(sql, param))
            End If

            Return _ByDOBNAME
        End Get
        Set(ByVal value As List(Of Lidmaat))
            _ByDOBNAME = value
        End Set
    End Property
    Private _ByNAME As List(Of Lidmaat)
    Public Property ByNAME(ByVal SearchName As String) As List(Of Lidmaat)
        Get
            If String.IsNullOrEmpty(SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")

            If _ByNAME Is Nothing Then
                _ByNAME = New List(Of Lidmaat)
                Dim _lid As New Lidmaat
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND achternaam LIKE @naam  ORDER BY achternaam"
                Dim param() As Object = {"@naam", SearchName & "%"}
                _ByNAME = ohelper.MapDataTableToList(Of Lidmaat)(_lid.GetList(sql, param))
            End If

            Return _ByNAME
        End Get
        Set(ByVal value As List(Of Lidmaat))
            _ByNAME = value
        End Set
    End Property
    Private _ByNAME_PC As List(Of Lidmaat)
    Public Property ByNAME_PC(ByVal SearchName As String, ByVal postcode As String) As List(Of Lidmaat)
        Get
            If String.IsNullOrEmpty(SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")
            If String.IsNullOrEmpty(postcode) Then Throw New Exception("postcode is niet ingevuld!")

            If _ByNAME Is Nothing Then
                _ByNAME = New List(Of Lidmaat)
                Dim _lid As New Lidmaat
                Dim ohelper As New Helper
                Dim sql As String = ""
                If postcode.Length >= 6 Then
                    postcode = postcode.Replace(" ", "")
                    postcode = postcode.Insert(4, " ")
                    sql = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND achternaam LIKE @naam AND postcode = @postcode ORDER BY achternaam ,postcode"
                Else
                    sql = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND achternaam LIKE @naam AND LEFT(postcode, " & postcode.Length & ") = @postcode ORDER BY achternaam ,postcode"
                End If

                Dim param() As Object = {"@naam", SearchName & "%", "@postcode", postcode}
                _ByNAME_PC = ohelper.MapDataTableToList(Of Lidmaat)(_lid.GetList(sql, param))
            End If

            Return _ByNAME_PC
        End Get
        Set(ByVal value As List(Of Lidmaat))
            _ByNAME_PC = value
        End Set
    End Property

    Private _ByNR_PC As List(Of Lidmaat)
    Public Property ByNR_PC(ByVal HuisNr As String, ByVal postcode As String) As List(Of Lidmaat)
        Get
            ' If String.IsNullOrEmpty(HuisNr) Then Throw New Exception("huisnr is niet ingevuld!")
            If String.IsNullOrEmpty(postcode) Then Throw New Exception("postcode is niet ingevuld!")

            If _ByNAME Is Nothing Then
                _ByNAME = New List(Of Lidmaat)
                Dim _lid As New Lidmaat
                Dim ohelper As New Helper
                Dim paramlist As New ArrayList
                Dim sAndOr As String = ""
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0)  "

                sAndOr = "AND "

                If HuisNr.Length > 0 Then
                    sql &= sAndOr & "Huisnr = @Huisnr "
                    paramlist.Add("@Huisnr")
                    paramlist.Add(HuisNr)
                    sAndOr = "AND "
                End If

                If postcode.Length >= 6 Then
                    postcode = postcode.Replace(" ", "")
                    postcode = postcode.Insert(4, " ")
                    sql &= sAndOr & "postcode = @postcode "
                    paramlist.Add("@postcode")
                    paramlist.Add(postcode)
                    sAndOr = "AND "
                Else
                    sql &= sAndOr & "LEFT(postcode, " & postcode.Length & ") = @postcode "
                    paramlist.Add("@postcode")
                    paramlist.Add(postcode)
                    sAndOr = "AND "
                End If

                sql &= "ORDER BY achternaam ,postcode"


                'If postcode.Length >= 6 Then
                '    postcode = postcode.Replace(" ", "")
                '    postcode = postcode.Insert(4, " ")
                '    sql = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND achternaam LIKE @naam AND postcode = @postcode ORDER BY achternaam ,postcode"
                'Else
                '    sql = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND achternaam LIKE @naam AND LEFT(postcode, " & postcode.Length & ") = @postcode ORDER BY achternaam ,postcode"
                'End If

                'Dim param() As Object = {"@naam", HuisNr & "%", "@postcode", postcode}
                _ByNR_PC = ohelper.MapDataTableToList(Of Lidmaat)(_lid.GetList(sql, paramlist.ToArray))
            End If

            Return _ByNR_PC
        End Get
        Set(ByVal value As List(Of Lidmaat))
            _ByNR_PC = value
        End Set
    End Property
    'Public ReadOnly Property ByHuisNr_PC(ByVal HuisNr As String, ByVal postcode As String) As DataTable
    '    Get
    '        'If String.IsNullOrEmpty(HuisNr) Then Throw New Exception("Huisnummer is niet ingevuld!")
    '        If String.IsNullOrEmpty(postcode) Then Throw New Exception("postcode is niet ingevuld!")

    '        Dim dt As New DataTable
    '        Dim paramlist As New ArrayList
    '        Dim sAndOr As String = ""
    '        Dim sql As String = "SELECT * FROM relaties WHERE "

    '        sql &= sAndOr & "status = @status "
    '        paramlist.Add("@status")
    '        paramlist.Add(status)
    '        sAndOr = "AND "


    '        If HuisNr.Length > 0 Then
    '            sql &= sAndOr & "Huisnr = @Huisnr "
    '            paramlist.Add("@Huisnr")
    '            paramlist.Add(HuisNr)
    '            sAndOr = "AND "
    '        End If


    '        If postcode.Length >= 6 Then
    '            postcode = postcode.Replace(" ", "")
    '            postcode = postcode.Insert(4, " ")
    '            sql &= sAndOr & "postcode = @postcode "
    '            paramlist.Add("@postcode")
    '            paramlist.Add(postcode)
    '            sAndOr = "AND "
    '        Else
    '            sql &= sAndOr & "LEFT(postcode, " & postcode.Length & ") = @postcode "
    '            paramlist.Add("@postcode")
    '            paramlist.Add(postcode)
    '            sAndOr = "AND "
    '        End If

    '        sql &= "ORDER BY achternaam ,postcode"

    '        dt = da.ExecuteDataTable(sql, paramlist.ToArray)


    '        Return dt
    '    End Get
    'End Property

    Private _ByLidNr As List(Of Lidmaat)
    Public Property ByLidNr(ByVal LidNr As String) As List(Of Lidmaat)
        Get
            If String.IsNullOrEmpty(LidNr) Then Throw New Exception("lidnr is niet ingevuld!")

            If _ByLidNr Is Nothing Then
                _ByLidNr = New List(Of Lidmaat)
                Dim _lid As New Lidmaat
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND lidnr = @lidnr"
                Dim param() As Object = {"@lidnr", LidNr}
                _ByLidNr = ohelper.MapDataTableToList(Of Lidmaat)(_lid.GetList(sql, param))
            End If

            Return _ByLidNr
        End Get
        Set(ByVal value As List(Of Lidmaat))
            _ByLidNr = value
        End Set
    End Property
    Private _ByLidNrlike As List(Of Lidmaat)
    Public Property ByLidNrlike(ByVal LidNr As String) As List(Of Lidmaat)
        Get
            If String.IsNullOrEmpty(LidNr) Then Throw New Exception("lidnr is niet ingevuld!")

            If _ByLidNr Is Nothing Then
                _ByLidNr = New List(Of Lidmaat)
                Dim _lid As New Lidmaat
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND lidnr LIKE @lidnr"
                Dim param() As Object = {"@lidnr", "%" & LidNr & "%"}
                _ByLidNr = ohelper.MapDataTableToList(Of Lidmaat)(_lid.GetList(sql, param))
            End If

            Return _ByLidNr
        End Get
        Set(ByVal value As List(Of Lidmaat))
            _ByLidNr = value
        End Set
    End Property
  
End Class
