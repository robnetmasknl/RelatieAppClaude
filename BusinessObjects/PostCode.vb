
Public Class PostCode
    Private da As New DataAccess


    Public Sub New(ByVal SearchPostcode As String, ByVal SearchHuisNr As String)
        If String.IsNullOrEmpty(SearchPostcode) And String.IsNullOrEmpty(SearchHuisNr) Then Exit Sub

        _Postcode = NoWhiteSpace(SearchPostcode)
        _HuisNr = SearchHuisNr

        If Not String.IsNullOrEmpty(SearchHuisNr) Then
            If Not IsNumeric(_HuisNr) Then
                _HuisNr = _HuisNr.Substring(0, FindFirstAlpha(_HuisNr) - 1)
            End If
        End If

        If String.IsNullOrEmpty(_HuisNr) Or _HuisNr = "0" Then
            OnlyPostCode()
        Else
            Search()
        End If

    End Sub
    Private Sub Search()
        Try
            Dim myreader As SqlClient.SqlDataReader
            Dim sql As String = ""

            sql = "SELECT * FROM  postcode_NL " &
                "WHERE (postcode = @Postcode AND minnumber <= @HuisNr and maxnumber >= @HuisNr)"

            Dim param() As Object = {"@Postcode", Postcode, "@HuisNr", HuisNr}

            myreader = da.ExecuteReader(sql, param)
            myreader.Read()

            If myreader.HasRows Then
                Found = True
                _Straat = myreader.Item("street")
                _Plaats = myreader.Item("city")
                _Gemeente = myreader.Item("municipality")
                _Provincie = myreader.Item("province")
            Else
                Throw New Exception("Er is geen adres in het postcodeboek gevonden!")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OnlyPostCode()
        Try
            Dim myreader As SqlClient.SqlDataReader
            Dim sql As String = "SELECT * FROM  postcode_NL " &
                "WHERE (postcode = @Postcode)"

            Dim param() As Object = {"@Postcode", Postcode}

            myreader = da.ExecuteReader(sql, param)
            myreader.Read()

            If myreader.HasRows Then
                Found = True
                _Straat = myreader.Item("street")
                _Plaats = myreader.Item("city")
                _Gemeente = myreader.Item("municipality")
                _Provincie = myreader.Item("province")
                _MinVanVan = myreader.Item("minnumber")
                _MaxVanTem = myreader.Item("maxnumber")
                Dim sb As New Text.StringBuilder
                sb.Append("Er is geen huisnr ingevuld." & vbCrLf & vbCrLf)
                sb.Append("Gevonden resultaat: " & vbCrLf)
                sb.Append("straat: " & Straat & vbCrLf)
                sb.Append("mogelijke huisnr tussen: " & MinVanVan & " en " & MaxVanTem & vbCrLf)
                sb.Append("plaats: " & Plaats & vbCrLf)
                sb.Append("gemeente: " & Gemeente & vbCrLf)
                Throw New Exception(sb.ToString)
            Else
                Throw New Exception("Er is geen adres in het postcodeboek gevonden!")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Sub Search()
    '    Try
    '        Dim myreader As SqlClient.SqlDataReader
    '        Dim sql As String = ""

    '        sql = "SELECT Straat, Plaats, Gemeente, Provincie, Postcode " & _
    '                            "FROM (pc_Plaats INNER JOIN pc_Straat ON pc_Plaats.PlaatsID = pc_Straat.PlaatsID) " & _
    '                            "INNER JOIN pc_Postcodes ON pc_Straat.StraatID = pc_Postcodes.StraatID " & _
    '                            "WHERE (Postcode = @Postcode AND Van <= @HuisNr and Tem >= @HuisNr and (Soort = @Soort OR Soort = @Soort))"
    '        Dim param() As Object = {"@Postcode", Postcode, "@HuisNr", HuisNr, "@Soort", Soort}

    '        myreader = da.ExecuteReader(sql, param)
    '        myreader.Read()

    '        If myreader.HasRows Then
    '            Found = True
    '            _Straat = myreader.Item("Straat")
    '            _Plaats = myreader.Item("Plaats")
    '            _Gemeente = myreader.Item("Gemeente")
    '            _Provincie = myreader.Item("Provincie")
    '        Else
    '            Throw New Exception("Er is geen adres in het postcodeboek gevonden!")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub OnlyPostCode()
    '    Try
    '        Dim myreader As SqlClient.SqlDataReader
    '        Dim sql As String = "SELECT pc_Straat.Straat, pc_Plaats.Plaats, pc_Plaats.Gemeente, pc_Plaats.Provincie,  pc_Postcodes.Postcode, pc_Postcodes.Soort, Min(pc_Postcodes.Van) AS MinVanVan, Max(pc_Postcodes.Tem) AS MaxVanTem " & _
    '                            "FROM (pc_Plaats INNER JOIN pc_Straat ON pc_Plaats.PlaatsID = pc_Straat.PlaatsID) INNER JOIN pc_Postcodes ON pc_Straat.StraatID = pc_Postcodes.StraatID " & _
    '                            "GROUP BY pc_Plaats.Plaats, pc_Plaats.Gemeente, pc_Plaats.Provincie, pc_Straat.Straat, pc_Postcodes.Postcode, pc_Postcodes.Soort " & _
    '                            "HAVING (((pc_Postcodes.Postcode)= @Postcode))"

    '        Dim param() As Object = {"@Postcode", Postcode}

    '        myreader = da.ExecuteReader(sql, param)
    '        myreader.Read()

    '        If myreader.HasRows Then
    '            Found = True
    '            _Straat = myreader.Item("Straat")
    '            _Plaats = myreader.Item("Plaats")
    '            _Gemeente = myreader.Item("Gemeente")
    '            _Provincie = myreader.Item("Provincie")
    '            _MinVanVan = myreader.Item("MinVanVan")
    '            _MaxVanTem = myreader.Item("MaxVanTem")
    '            Dim sb As New Text.StringBuilder
    '            sb.Append("Er is geen huisnr ingevuld." & vbCrLf & vbCrLf)
    '            sb.Append("Gevonden resultaat: " & vbCrLf)
    '            sb.Append("straat: " & Straat & vbCrLf)
    '            sb.Append("mogelijke huisnr tussen: " & MinVanVan & " en " & MaxVanTem & vbCrLf)
    '            sb.Append("plaats: " & Plaats & vbCrLf)
    '            sb.Append("gemeente: " & Gemeente & vbCrLf)
    '            Throw New Exception(sb.ToString)
    '        Else
    '            Throw New Exception("Er is geen adres in het postcodeboek gevonden!")
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Private _Straat As String
    Public ReadOnly Property Straat() As String
        Get
            Return _Straat
        End Get
    End Property
    Private _Plaats As String
    Public ReadOnly Property Plaats() As String
        Get
            Return _Plaats
        End Get
    End Property
    Private _Gemeente As String
    Public ReadOnly Property Gemeente() As String
        Get
            Return _Gemeente
        End Get
    End Property
    Private _Provincie As String
    Public ReadOnly Property Provincie() As String
        Get
            Return _Provincie
        End Get
    End Property

    Private _Postcode As String
    Public Property Postcode() As String
        Get
            Return _Postcode
        End Get
        Set(ByVal value As String)
            _Postcode = value
        End Set
    End Property
    Private _HuisNr As String
    Public Property HuisNr() As String
        Get
            Return _HuisNr
        End Get
        Set(ByVal value As String)
            _HuisNr = value
        End Set
    End Property
    Private _Soort As Integer
    Public ReadOnly Property Soort() As Integer
        Get
            If HuisNr Mod 2 = 0 Then
                _Soort = 1
            Else
                _Soort = 0
            End If
            Return _Soort
        End Get
    End Property
    Private _MinVanVan As String
    Public ReadOnly Property MinVanVan() As String
        Get
            Return _MinVanVan
        End Get
    End Property
    Private _MaxVanTem As String
    Public ReadOnly Property MaxVanTem() As String
        Get
            Return _MaxVanTem
        End Get
    End Property

End Class
