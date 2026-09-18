Public Class IBBDossierFaseList

    'Private _FasesByDossier As List(Of IBBFase)
    'Public ReadOnly Property FasesByDossier(ByVal DossierId As Integer) As List(Of IBBFase)
    '    Get
    '        If _FasesByDossier Is Nothing Then
    '            _FasesByDossier = New List(Of IBBFase)
    '            Dim _IBBFase As New IBBFase
    '            Dim ohelper As New Helper
    '            Dim sql As String = "SELECT * FROM IBBFases where DossierId = @DossierId"
    '            Dim params As New ArrayList
    '            params.Add("@DossierId")
    '            params.Add(DossierId)
    '            _FasesByDossier = ohelper.MapDataTableToList(Of IBBFase)(_IBBFase.GetList(sql, params.ToArray))
    '        End If

    '        Return _FasesByDossier
    '    End Get
    'End Property



    'Private _ComingTerms As List(Of IBBFase)
    'Public ReadOnly Property ComingTerms() As List(Of IBBFase)
    '    Get
    '        If _ComingTerms Is Nothing Then
    '            _ComingTerms = New List(Of IBBFase)
    '            Dim _IBBFase As New IBBFase
    '            Dim ohelper As New Helper
    '            Dim DateFrom As DateTime = New DateTime(Today.Year - 1, Today.Month, Today.Day)
    '            Dim sql As String = "SELECT * FROM IBBFases where Beslisdatum >= @DateFrom Order by Beslisdatum asc"
    '            Dim params As New ArrayList
    '            params.Add("@DateFrom")
    '            params.Add(DateFrom)
    '            _ComingTerms = ohelper.MapDataTableToList(Of IBBFase)(_IBBFase.GetList(sql, params.ToArray))
    '        End If

    '        Return _ComingTerms
    '    End Get
    'End Property
    'Private _LijstByDossier As List(Of IBBFase)
    'Public ReadOnly Property LijstByDossier(ByVal DossierId As Integer) As List(Of IBBFase)
    '    Get
    '        If _LijstByDossier Is Nothing Then
    '            _LijstByDossier = New List(Of IBBFase)
    '            Dim _IBBFase As New IBBFase
    '            Dim ohelper As New Helper
    '            Dim sql As String = "SELECT * FROM IBBFases where DossierId = @DossierId"
    '            Dim params As New ArrayList
    '            params.Add("@DossierId")
    '            params.Add(DossierId)
    '            _LijstByDossier = ohelper.MapDataTableToList(Of IBBFase)(_IBBFase.GetList(sql, params.ToArray))
    '        End If

    '        Return _LijstByDossier
    '    End Get
    'End Property

    'Private _LijstByDossier As List(Of IBBDossierFase)
    'Public ReadOnly Property LijstByDossier(ByVal DossierId As Integer) As List(Of IBBDossierFase)
    '    Get
    '        If _LijstByDossier Is Nothing Then
    '            _LijstByDossier = New List(Of IBBDossierFase)
    '            Dim _IBBDossierFase As New IBBDossierFase
    '            Dim ohelper As New Helper
    '            Dim sql As String = "SELECT * FROM IBBDossierFases where DossierId = @DossierId"
    '            Dim params As New ArrayList
    '            params.Add("@DossierId")
    '            params.Add(DossierId)
    '            _LijstByDossier = ohelper.MapDataTableToList(Of IBBDossierFase)(_IBBDossierFase.GetList(sql, params.ToArray))
    '        End If

    '        Return _LijstByDossier
    '    End Get
    'End Property
End Class
