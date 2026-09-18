Public Class Blok
    Inherits tblBlokken
    Private da As New DataAccess

    Enum Via
        ID
        LOCATIE
        'DATUM
    End Enum

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LOCATIE" Then
            ohelper.FillObject(Me, GetByLOCATIE(id))
            'ElseIf Via.ToString = "DATUM" Then
            '    ohelper.FillObject(Me, GetByDATUM(id))
        End If

    End Sub


    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM blokken where id = @id ORDER BY datum"
            Dim param() As Object = {"@id", GetId}
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
    Public Function GetByLOCATIE(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM blokken where LocatieId = @LocatieId ORDER BY datum"
            Dim param() As Object = {"@LocatieId", GetId}
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
    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Public Sub Save()
        Try
            'Controleer of de adviseur al ergens op die datum aanwezig is.
            Dim ValidateBlokLijst As New BlokkenLijst
            ValidateBlokLijst._AdviseurId = adviseurid
            For Each blokje As Blok In ValidateBlokLijst.ByAdviseur
                If blokje.datum = datum Then Throw New Exception(AdviseurNaam & " kan niet op 2 plekken tegelijk zijn!")
            Next

            If Me.Id = Nothing Then

                Id = da.InsertString(Me, "blokken", "Id", True)
                'Maak de standaard lege boeking regels aan op basis van gekozen template
                Dim DefaultBoekingen As New List(Of Boeking)
                Dim NewBoeking As Boeking = Nothing
                For i = 0 To BlokTypeAantal - 1
                    NewBoeking = New Boeking
                    NewBoeking.blokId = Me.Id
                    NewBoeking.relatieId = 0
                    NewBoeking.tijdstip = Me.CreateTimeStamp
                    NewBoeking.voorlopig = True
                    NewBoeking.Save()
                    _Boekingen = Nothing
                Next
            Else
                da.UpdateString(Me, "blokken", "Id")
            End If

        Catch ex As Exception
            Remove()
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            For Each boekregel In Me.Boekingen
                If boekregel.relatieId > 0 Then Throw New Exception("Kan blok niet verwijderen." & vbCrLf & "Er zijn al boekingen op gemaakt.")
            Next
            For Each boekregel In Me.Boekingen
                boekregel.Remove()
            Next
            da.DeleteString(Me, "blokken")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _LocatieNaam As String = ""
    Public ReadOnly Property LocatieNaam() As String
        Get
            If String.IsNullOrEmpty(_LocatieNaam) Then
                Dim _BlokLocatie As New Locaties(locatieId)
                _LocatieNaam = _BlokLocatie.Locatie
                _BlokLocatie = Nothing
            End If
            Return _LocatieNaam
        End Get
    End Property

    Private _AdviseurNaam As String
    Public ReadOnly Property AdviseurNaam() As String
        Get
            If String.IsNullOrEmpty(_AdviseurNaam) Then
                Dim _Adviseur As New Adviseur(adviseurId)
                _AdviseurNaam = _Adviseur.naam
                _Adviseur = Nothing
            End If
            Return _AdviseurNaam
        End Get
    End Property

    'Public iDummies As Integer = 0
    'Private _HaveDummies As Boolean = False
    'Public ReadOnly Property HaveDummies As Boolean
    '    Get
    '        For Each Boeking As Boeking In Boekingen
    '            If Boeking.relatieId > 0 Then
    '                'alleen zolang er geen dummies gevonden zijn controleren,modat dait een zware belasting is op de snelheid
    '                'If _HaveDummies = False Then
    '                If Boeking.lidnr = DummyValue Then
    '                    _HaveDummies = True
    '                    iDummies = +1
    '                End If
    '                'End If
    '            End If
    '        Next
    '        Return _HaveDummies
    '    End Get
    'End Property

    Private _AantalDummies As Integer = 0
    Public ReadOnly Property AantalDummies As Integer
        Get
            _AantalDummies = 0
            For Each Boeking As Boeking In Boekingen
                If Boeking.relatieId > 0 Then
                    If Boeking.lidnr = DummyValue Then
                        _AantalDummies = _AantalDummies + 1
                    End If
                End If
            Next
            Return _AantalDummies
        End Get
    End Property

    Private _AantalBoekingen As Integer = 0
    Public ReadOnly Property AantalBoekingen() As Integer
        Get
            _AantalBoekingen = 0
            For Each Boeking As Boeking In Boekingen
                If Boeking.relatieId > 0 Then
                    _AantalBoekingen += 1
                End If
            Next

            Return _AantalBoekingen
        End Get
    End Property
    Private _AantalBeschikbaar As Integer
    Public ReadOnly Property AantalBeschikbaar() As Integer
        Get
            _AantalBeschikbaar = AantalTotaal - AantalBoekingen
            Return _AantalBeschikbaar
        End Get
    End Property
    Private _AantalTotaal As Integer
    Public ReadOnly Property AantalTotaal() As Integer
        Get
            _AantalTotaal = Boekingen.Count
            Return _AantalTotaal
        End Get
    End Property
    Public ReadOnly Property Vol() As Boolean
        Get
            Dim result As Boolean = False
            result = AantalTotaal = AantalBoekingen
            Return result
        End Get
    End Property

    Private _Boekingen As List(Of Boeking)
    Public ReadOnly Property Boekingen() As List(Of Boeking)
        Get
            If _Boekingen Is Nothing Then
                _Boekingen = New List(Of Boeking)
                Dim _Boeking As New Boeking
                Dim ohelper As New Helper
                Dim sql As String = _
                    "SELECT * FROM boekingen WHERE blokId = @blokId AND (tijdstip >= @StartDate AND tijdstip < @EndDate) ORDER BY tijdstip ASC"

                Dim param() As Object = {"@blokId", Me.Id, "@StartDate", datum, "@EndDate", datum.AddDays(1)}
                _Boekingen = ohelper.MapDataTableToList(Of Boeking)(_Boeking.GetList(sql, param))
            End If
            Return _Boekingen
        End Get
    End Property

    Private _CreateTimeStamp As DateTime
    Public Property CreateTimeStamp() As DateTime
        Get
            Dim CalcTijdsduur As Integer = BlokType.tijdsduur
            If Boekingen.Count = 0 Then
                _CreateTimeStamp = FormatDateTime(datum.ToShortDateString & " " & BlokType.aanvang.ToShortTimeString)
            Else
                Boekingen.OrderBy(Function(Boeking) Boeking.tijdstip)

                'Dim query As IEnumerable(Of Boeking) = Boekingen.OrderBy(Function(Boeking) Boeking.tijdstip)


                If Boekingen.Count = BlokType.pauze Then
                    CalcTijdsduur += 30
                End If
                _CreateTimeStamp = Boekingen(Boekingen.Count - 1).tijdstip.AddMinutes(CalcTijdsduur)
            End If

            Return _CreateTimeStamp
        End Get
        Set(ByVal value As DateTime)
            _CreateTimeStamp = value
        End Set
    End Property


    Public Function EerstVolgendeBoeking() As Boeking

        Dim query As IEnumerable(Of Boeking) = Nothing
        If vultype = 1 Then
            query = Boekingen.OrderBy(Function(Boeking) Boeking.tijdstip)
        ElseIf vultype = 2 Then
            query = Boekingen.OrderByDescending(Function(Boeking) Boeking.tijdstip)
        ElseIf vultype = 3 Then
            query = Boekingen.OrderBy(Function(Boeking) Boeking.tijdstip)
        End If

        For Each boekingregel As Boeking In query
            If boekingregel.relatieId = 0 Then
                Return boekingregel
            End If
        Next

        Return query(0)
    End Function

    Private _VolgendeTijdstip As DateTime
    Public Property VolgendeTijdstip() As DateTime
        Get
            If Boekingen.Count = 0 Then Return DateTime.MinValue

            Dim query As IEnumerable(Of Boeking) = Nothing
            If vultype = 1 Then
                query = Boekingen.OrderBy(Function(Boeking) Boeking.tijdstip)
            ElseIf vultype = 2 Then
                query = Boekingen.OrderByDescending(Function(Boeking) Boeking.tijdstip)
            ElseIf vultype = 3 Then
                query = Boekingen.OrderBy(Function(Boeking) Boeking.tijdstip)
            End If

            For Each boekingregel As Boeking In query
                If boekingregel.relatieId = 0 Then
                    Return boekingregel.tijdstip
                End If
            Next

            Return Boekingen(0).tijdstip

            Return _VolgendeTijdstip
        End Get
        Set(ByVal value As DateTime)
            _VolgendeTijdstip = value
        End Set
    End Property

    Private _VanafOfTot As String
    Public ReadOnly Property VanafOfTot() As String
        Get
            If vultype = 1 Then
                _VanafOfTot = "van begin naar eind"
            ElseIf vultype = 2 Then
                _VanafOfTot = "van eind naar begin "
            ElseIf vultype = 3 Then
                _VanafOfTot = "rondom "
            End If
            Return _VanafOfTot
        End Get
    End Property

#Region "Bloktype"
    Private _BlokType As BlokTypes
    Private _BlokTypeTijdsDuur As Integer
    Private _BlokTypeAantal As Integer
    Private _BlokTypeAanvang As DateTime = Data.SqlTypes.SqlDateTime.MinValue

    Public ReadOnly Property BlokType() As BlokTypes
        Get
            If _BlokType Is Nothing Then
                If bloktypeid > 0 Then
                    _BlokType = New BlokTypes(bloktypeid, BlokTypes.Via.ID)
                End If
            End If
            Return _BlokType
        End Get
    End Property
    Public ReadOnly Property BlokTypeTijdsDuur() As Integer
        Get
            If _BlokTypeTijdsDuur = 0 Then _
                    _BlokTypeTijdsDuur = BlokType.tijdsduur

            Return _BlokTypeTijdsDuur
        End Get
    End Property
    Public ReadOnly Property BlokTypeAantal() As Integer
        Get
            If _BlokTypeAantal = 0 Then _
                    _BlokTypeAantal = BlokType.aantal

            Return _BlokTypeAantal
        End Get
    End Property
    Public ReadOnly Property BlokTypeAanvang() As DateTime
        Get
            If _BlokTypeAanvang = Data.SqlTypes.SqlDateTime.MinValue Then _
                    _BlokTypeAanvang = BlokType.aanvang

            Return _BlokTypeAanvang
        End Get
    End Property
#End Region

End Class
