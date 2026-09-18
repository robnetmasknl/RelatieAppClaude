Public Class BlokkenLijst

    Public _BlokDate As Date = Date.MinValue
    Public _SearchName As String = String.Empty
    Public _LocatieId As Integer = 0
    Public _AdviseurId As Integer = 0

    Private _ByLocatie As List(Of Blok)
    Public ReadOnly Property ByLocatie() As List(Of Blok)
        Get
            If _LocatieId = 0 Then Throw New Exception("Er is nog geen locatie opgegeven")

            If _ByLocatie Is Nothing Then
                _ByLocatie = New List(Of Blok)
                Dim _Blok As New Blok
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM blokken WHERE LocatieId = @LocatieId ORDER BY datum"
                Dim param() As Object = {"@LocatieId", _LocatieId}
                _ByLocatie = ohelper.MapDataTableToList(Of Blok)(_Blok.GetList(sql, param))
            End If

            Return _ByLocatie
        End Get

    End Property

    Private _ByAdviseur As List(Of Blok)
    Public ReadOnly Property ByAdviseur() As List(Of Blok)
        Get
            If _AdviseurId = 0 Then Throw New Exception("Er is nog geen adviseur opgegeven")

            If _ByAdviseur Is Nothing Then
                _ByAdviseur = New List(Of Blok)
                Dim _Blok As New Blok
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM blokken WHERE AdviseurId = @AdviseurId ORDER BY datum"
                Dim param() As Object = {"@AdviseurId", _AdviseurId}
                _ByAdviseur = ohelper.MapDataTableToList(Of Blok)(_Blok.GetList(sql, param))
            End If

            Return _ByAdviseur
        End Get
    End Property
    Private _DatumLijst As List(Of Blok)
    Public ReadOnly Property DatumLijstByLocatie(ByVal LocatieId) As List(Of Blok)
        Get
            If _DatumLijst Is Nothing Then
                _DatumLijst = New List(Of Blok)
                Dim _Blok As New Blok
                Dim ohelper As New Helper
                'Dim sql As String = "select distinct locatieid,locaties.Locatie,datum from Locaties " & _
                '                    "join Blokken on locaties.Id = blokken.locatieid " & _
                '                    "order by locatieid, datum"
                Dim sql As String = "select distinct locatieid,datum from Blokken where locatieid = @locatieid  "
                Dim param() As Object = {"@locatieid", LocatieId}
                _DatumLijst = ohelper.MapDataTableToList(Of Blok)(_Blok.GetList(sql, param))
            End If
            Return _DatumLijst
        End Get
    End Property
    Public Function GetBlokByLocationDate(ByVal BlokDate As DateTime, ByVal locatieid As String) As List(Of Blok)
        Try
            Dim sql As String = "SELECT * FROM blokken where datum = @datum AND locatieid = @locatieid ORDER BY datum"
            Dim param() As Object = {"@datum", BlokDate, "@locatieid", locatieid}
            Dim ohelper As New Helper
            Dim _Blok As New Blok
            Dim _Lijst As New List(Of Blok)
            _Lijst = ohelper.MapDataTableToList(Of Blok)(_Blok.GetList(sql, param))

            Return _Lijst
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
