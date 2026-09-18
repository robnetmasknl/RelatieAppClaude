Imports System.Data.SqlClient

Public Class RelatiesSearch
    Enum eSearchOption
        LidId
        LidNr
        RegNr
        RekNr
        PCHnr
        Plaats
    End Enum
    Private status As Integer = 0

    Private da As New DataAccess
    Public Sub New(Optional ByVal _status As Integer = 0)
        status = _status
    End Sub
    Public ReadOnly Property LikeNr(ByVal _Nr As String, ByVal searchoption As eSearchOption) As DataTable
        Get
            If String.IsNullOrEmpty(_Nr) Then Throw New Exception("er is geen nummer opgegeven!")

            Dim dt As DataTable
            Dim paramlist As New ArrayList
            Dim sAndOr As String = ""
            Dim sql As String = "SELECT * FROM relaties WHERE "
            Dim sOrderBy As String = ""

            sql &= sAndOr & "status = @status "
            paramlist.Add("@status")
            paramlist.Add(status)
            sAndOr = "AND "

            If searchoption = eSearchOption.LidNr Then
                sql &= sAndOr & "lidnr LIKE @lidnr "
                paramlist.Add("@lidnr")
                paramlist.Add("%" & _Nr & "%")
                sAndOr = "AND "
            ElseIf searchoption = eSearchOption.RegNr Then
                sql &= sAndOr & "rnr LIKE @rnr "
                paramlist.Add("@rnr")
                paramlist.Add("%" & _Nr & "%")
                sAndOr = "AND "
            ElseIf searchoption = eSearchOption.RekNr Then
                'sql &= sAndOr & "bankrek LIKE @bankrek "
                'paramlist.Add("@bankrek")
                'paramlist.Add("%" & _Nr & "%")
                'sAndOr = "AND "
                sql &= sAndOr & "IBAN LIKE @IBAN "
                paramlist.Add("@IBAN")
                paramlist.Add("%" & _Nr & "%")
                sAndOr = "AND "
            ElseIf searchoption = eSearchOption.LidId Then
                sql &= sAndOr & "id = @LidId "
                paramlist.Add("@LidId")
                paramlist.Add(_Nr)
                sAndOr = "AND "
            ElseIf searchoption = eSearchOption.Plaats Then
                Dim arr As Array = _Nr.Split(";")
                Dim naam As String = arr(0)
                Dim plaats As String = arr(1)
                If naam.Length > 0 Then
                    sql &= sAndOr & "achternaam LIKE @achternaam "
                    paramlist.Add("@achternaam")
                    paramlist.Add(naam & "%")
                    sAndOr = "AND "

                End If

                sql &= sAndOr & "plaats = @plaats "
                paramlist.Add("@plaats")
                paramlist.Add(plaats)
                sAndOr = "AND "
                sOrderBy = " ORDER BY achternaam ,postcode"
            End If

            If Not String.IsNullOrEmpty(sOrderBy) Then
                sql &= sOrderBy
            End If

            dt = da.ExecuteDataTable(sql, paramlist.ToArray)

            Return dt
        End Get
    End Property
    'Private _ByLidId As DataTable
    'Public ReadOnly Property ByLidId(ByVal Lidid As String) As DataTable
    '    Get
    '        If String.IsNullOrEmpty(Lidid) Then Throw New Exception("lidid is niet ingevuld!")

    '        If _ByLidId Is Nothing Then
    '            Dim sql As String = "SELECT * FROM relaties WHERE status = @status AND Id = @Lidid"
    '            Dim param() As Object = {"@Lidid", Lidid, "@status", status}
    '            _ByLidId = da.ExecuteDataTable(sql, param)
    '        End If
    '        Return _ByLidId
    '    End Get
    'End Property

    Private _ByLidNr As DataTable
    Public ReadOnly Property ByLidNr(ByVal LidNr As String) As DataTable
        Get
            If String.IsNullOrEmpty(LidNr) Then Throw New Exception("lidnr is niet ingevuld!")

            If _ByLidNr Is Nothing Then
                Dim sql As String = "SELECT * FROM relaties WHERE status = @status AND lidnr = @lidnr"
                Dim param() As Object = {"@lidnr", LidNr, "@status", status}
                _ByLidNr = da.ExecuteDataTable(sql, param)
            End If
            Return _ByLidNr
        End Get
    End Property
    Private _ByNAME_PC As DataTable
    Public ReadOnly Property ByNAME_PC(ByVal SearchName As String, ByVal postcode As String) As DataTable
        Get
            'If String.IsNullOrEmpty(SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")
            If String.IsNullOrEmpty(postcode) Then Throw New Exception("postcode is niet ingevuld!")

            If _ByNAME_PC Is Nothing Then
                Dim paramlist As New ArrayList
                Dim sAndOr As String = ""
                Dim sql As String = "SELECT * FROM relaties WHERE "

                sql &= sAndOr & "status = @status "
                paramlist.Add("@status")
                paramlist.Add(status)
                sAndOr = "AND "


                If SearchName.Length > 0 Then
                    sql &= sAndOr & "achternaam LIKE @achternaam "
                    paramlist.Add("@achternaam")
                    paramlist.Add(SearchName & "%")
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

                _ByNAME_PC = da.ExecuteDataTable(sql, paramlist.ToArray)
            End If

            Return _ByNAME_PC
        End Get
    End Property
    Public ReadOnly Property ByNAME_PLAATS(ByVal SearchName As String, ByVal plaats As String) As DataTable
        Get
            'If String.IsNullOrEmpty(SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")
            If String.IsNullOrEmpty(plaats) Then Throw New Exception("postcode is niet ingevuld!")

            If _ByNAME_PC Is Nothing Then
                Dim paramlist As New ArrayList
                Dim sAndOr As String = ""
                Dim sql As String = "SELECT * FROM relaties WHERE "

                sql &= sAndOr & "status = @status "
                paramlist.Add("@status")
                paramlist.Add(status)
                sAndOr = "AND "


                If SearchName.Length > 0 Then
                    sql &= sAndOr & "achternaam LIKE @achternaam "
                    paramlist.Add("@achternaam")
                    paramlist.Add(SearchName & "%")
                    sAndOr = "AND "
                End If

                sql &= sAndOr & "plaats = @plaats "
                paramlist.Add("@plaats")
                paramlist.Add(plaats)
                sAndOr = "AND "


                sql &= "ORDER BY achternaam, postcode"

                _ByNAME_PC = da.ExecuteDataTable(sql, paramlist.ToArray)
            End If

            Return _ByNAME_PC
        End Get
    End Property
    Public ReadOnly Property ByHuisNr_PC(ByVal HuisNr As String, ByVal postcode As String) As DataTable
        Get
            'If String.IsNullOrEmpty(HuisNr) Then Throw New Exception("Huisnummer is niet ingevuld!")
            If String.IsNullOrEmpty(postcode) Then Throw New Exception("postcode is niet ingevuld!")

            Dim dt As New DataTable
            Dim paramlist As New ArrayList
            Dim sAndOr As String = ""
            Dim sql As String = "SELECT * FROM relaties WHERE "

            sql &= sAndOr & "status = @status "
            paramlist.Add("@status")
            paramlist.Add(status)
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

            dt = da.ExecuteDataTable(sql, paramlist.ToArray)


            Return dt
        End Get
    End Property
    Private _ByNAME As DataTable
    Public ReadOnly Property ByNAME(ByVal SearchName As String) As DataTable
        Get
            If String.IsNullOrEmpty(SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")
            If _ByNAME Is Nothing Then
                'Dim sql As String = "SELECT * FROM relaties WHERE  status = @status AND achternaam LIKE @naam  ORDER BY achternaam"
                Dim sql As String = "SELECT * FROM relaties WHERE  status = @status AND achternaam COLLATE Latin1_general_CI_AI Like @naam COLLATE Latin1_general_CI_AI ORDER BY achternaam"
                Dim param() As Object = {"@naam", SearchName & "%", "@status", status}
                _ByNAME = da.ExecuteDataTable(sql, param)
            End If

            Return _ByNAME
        End Get
    End Property

    Public _DOB As Date = Date.MinValue
    Public _SearchName As String = String.Empty
    Private _ByDOBNAME As DataTable
    Public ReadOnly Property ByDOBNAME() As DataTable
        Get
            If _DOB = Date.MinValue Then Throw New Exception("Geboortedatum is niet ingevuld!")
            If String.IsNullOrEmpty(_SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")

            If _ByDOBNAME Is Nothing Then
                Dim sql As String = "SELECT * FROM relaties WHERE status = @status AND geboortedatum = @DOB AND achternaam = @naam"
                Dim param() As Object = {"@DOB", _DOB, "@naam", _SearchName, "@status", status}
                _ByDOBNAME = da.ExecuteDataTable(sql, param)
            End If

            Return _ByDOBNAME
        End Get
    End Property


End Class
