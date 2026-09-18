Public Class IBBDossierList

    Private _Lijst As List(Of IBBDossier)
    Public Property Lijst() As List(Of IBBDossier)
        Get

            If _Lijst Is Nothing Then
                _Lijst = New List(Of IBBDossier)
                Dim _dossier As New IBBDossier
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBDossiers"
                _Lijst = ohelper.MapDataTableToList(Of IBBDossier)(_dossier.GetList(sql))
            End If

            Return _Lijst
        End Get
        Set(ByVal value As List(Of IBBDossier))
            _Lijst = value
        End Set
    End Property

    Private _MoerderDossiers As List(Of IBBDossier)
    Public Property MoerderDossiers() As List(Of IBBDossier)
        Get
            'WHERE IBB.Afgehandeld = 'False' "
            If _MoerderDossiers Is Nothing Then
                _MoerderDossiers = New List(Of IBBDossier)
                Dim _dossier As New IBBDossier
                Dim ohelper As New Helper
                Dim sql As String = "Select *  from IBBDossiers M " & _
                    "where m.DossierNr in " & _
                    "(SELECT distinct MoederDossier FROM IBBDossiers  " & _
                    "where MoederDossier <> 0 ) AND M.Afgehandeld = 'False'"
                _MoerderDossiers = ohelper.MapDataTableToList(Of IBBDossier)(_dossier.GetList(Sql))
            End If

            Return _MoerderDossiers
        End Get
        Set(ByVal value As List(Of IBBDossier))
            _MoerderDossiers = value
        End Set
    End Property
    'Private _DossiersNummers As List(Of String)
    'Public Property DossiersNummers() As List(Of String)
    '    Get

    '        If _DossiersNummers Is Nothing Then
    '            Dim da As New DataAccess
    '            _DossiersNummers = New List(Of String)
    '            Dim ohelper As New Helper
    '            Dim sql As String = "Select dossiernr from IBBDossiers "
    '            Dim dt As DataTable
    '            dt = da.ExecuteDataTable(sql)
    '            For Each dr As DataRow In dt.Rows
    '                _DossiersNummers.Add(dr.Item(0))
    '            Next

    '        End If

    '        Return _DossiersNummers
    '    End Get
    '    Set(ByVal value As List(Of String))
    '        _DossiersNummers = value
    '    End Set
    'End Property
    Private _IBBRelatieLijst As List(Of Relaties)
    Public Property IBBRelatieLijst(Optional BehandelaarId As Integer = -1) As List(Of Relaties)
        Get

            If _IBBRelatieLijst Is Nothing Then
                _IBBRelatieLijst = New List(Of Relaties)
                Dim _relatie As New Relaties
                Dim ohelper As New Helper

                Dim params As New ArrayList
                Dim sqlBehandelaar As String = ""
                If BehandelaarId > 0 Then
                    params.Add("@BehandelaarId")
                    params.Add(BehandelaarId)
                    sqlBehandelaar = " WHERE IBB.BehandelaarId = @BehandelaarId "
                End If


                Dim sql As String = "SELECT distinct rel.* FROM IBBDossiers  IBB " & _
                                    "INNER JOIN Relaties REL on IBB.lidid = REL.Id " & sqlBehandelaar & _
                                    "ORDER BY REL.achternaam"
                _IBBRelatieLijst = ohelper.MapDataTableToList(Of Relaties)(_relatie.GetList(sql, params.ToArray))
            End If

            Return _IBBRelatieLijst
        End Get
        Set(ByVal value As List(Of Relaties))
            _IBBRelatieLijst = value
        End Set
    End Property
    Private _OpenIBBRelatieLijst As List(Of Relaties)
    Public Property OpenIBBRelatieLijst(Optional BehandelaarId As Integer = -1) As List(Of Relaties)
        Get

            If _OpenIBBRelatieLijst Is Nothing Then
                _OpenIBBRelatieLijst = New List(Of Relaties)
                Dim _relatie As New Relaties

                Dim params As New ArrayList
                Dim sqlBehandelaar As String = ""
                If BehandelaarId > 0 Then
                    params.Add("@BehandelaarId")
                    params.Add(BehandelaarId)
                    sqlBehandelaar = " AND IBB.BehandelaarId = @BehandelaarId "
                End If

                Dim ohelper As New Helper
                Dim sql As String = "SELECT distinct rel.* FROM IBBDossiers  IBB " & _
                                    "INNER JOIN Relaties REL on IBB.lidid = REL.Id " & _
                                    "WHERE IBB.Afgehandeld = 'False' " & sqlBehandelaar & _
                                    "ORDER BY REL.achternaam"
                _OpenIBBRelatieLijst = ohelper.MapDataTableToList(Of Relaties)(_relatie.GetList(sql, params.ToArray))
            End If

            Return _OpenIBBRelatieLijst
        End Get
        Set(ByVal value As List(Of Relaties))
            _OpenIBBRelatieLijst = value
        End Set
    End Property
    Private _OpenIBBMetFaseRelatieLijst As List(Of Relaties)
    Public Property OpenIBBMetFaseRelatieLijst(Optional BehandelaarId As Integer = -1) As List(Of Relaties)
        Get

            If _OpenIBBMetFaseRelatieLijst Is Nothing Then
                _OpenIBBMetFaseRelatieLijst = New List(Of Relaties)
                Dim params As New ArrayList
                Dim sqlBehandelaar As String = ""
                If BehandelaarId > 0 Then
                    params.Add("@BehandelaarId")
                    params.Add(BehandelaarId)
                    sqlBehandelaar = " AND IBBDossiers.BehandelaarId = @BehandelaarId "
                End If
                Dim _relatie As New Relaties
                Dim ohelper As New Helper
                Dim sql As String = "Select distinct REL.* from IBBDossiers " & _
                                    "right join(Select DossierId from IBBFases group by DossierId having Count(DossierId) > 1) as aantal on IBBDossiers.id = aantal.DossierId " & _
                                    "INNER JOIN Relaties REL on IBBDossiers.lidid = REL.Id " & _
                                    "WHERE IBBDossiers.Afgehandeld = 'False'  " & sqlBehandelaar & _
                                    "ORDER BY REL.achternaam"
                _OpenIBBMetFaseRelatieLijst = ohelper.MapDataTableToList(Of Relaties)(_relatie.GetList(sql, params.ToArray))
            End If

            Return _OpenIBBMetFaseRelatieLijst
        End Get
        Set(ByVal value As List(Of Relaties))
            _OpenIBBMetFaseRelatieLijst = value
        End Set
    End Property
    Private _LijstByLidId As List(Of IBBDossier)
    Public ReadOnly Property LijstByLidId(ByVal LidId As Integer) As List(Of IBBDossier)
        Get

            If _LijstByLidId Is Nothing Then
                _LijstByLidId = New List(Of IBBDossier)
                Dim _dossier As New IBBDossier
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBDossiers where LidId = @lidId"
                Dim params As New ArrayList
                params.Add("@lidId")
                params.Add(LidId)
                _LijstByLidId = ohelper.MapDataTableToList(Of IBBDossier)(_dossier.GetList(sql, params.ToArray))
            End If

            Return _LijstByLidId
        End Get
    End Property
    Private _LijstByKenmerk As List(Of IBBDossier)
    Public ReadOnly Property LijstByKenmerk(ByVal Kenmerk As String) As List(Of IBBDossier)
        Get

            If _LijstByKenmerk Is Nothing Then
                _LijstByKenmerk = New List(Of IBBDossier)
                Dim _dossier As New IBBDossier
                Dim ohelper As New Helper
                Dim sql As String = "SELECT DISTINCT dos.* FROM IBBDossiers dos " & _
                                    "inner join ibbfases fs on fs.DossierId = dos.Id " & _
                                    "where Kenmerk = @Kenmerk"
                Dim params As New ArrayList
                params.Add("@Kenmerk")
                params.Add(Kenmerk)
                _LijstByKenmerk = ohelper.MapDataTableToList(Of IBBDossier)(_dossier.GetList(sql, params.ToArray))
            End If

            Return _LijstByKenmerk
        End Get
    End Property
    'Inherits List(Of IBBDossier)
    'Private da As DataAccess

    'Public Sub New()

    'End Sub
    'Public Sub New(ByVal id As Integer)
    '    Dim ohelper As New Helper
    '    ohelper.FillObject(Me, GetById(id))
    'End Sub

    'Public Function GetById(ByVal Id As Int32) As Data.DataRow
    '    Dim oDr As Data.DataRow
    '    Try
    '        Dim sql As String = "SELECT * FROM IBBDossiers where id = @id"
    '        Dim param() As Object = {"@id", Id}
    '        oDr = da.ExecuteDataRow(sql, param)

    '        If oDr IsNot Nothing Then
    '            Found = True
    '        End If

    '        Return oDr
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        oDr = Nothing
    '    End Try
    'End Function
    'Public Function GetList(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As Data.DataTable
    '    Dim oDS As Data.DataSet
    '    Try
    '        oDS = da.ExecuteDataset(sql, parameters)
    '        Return oDS.Tables(0)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        oDS = Nothing
    '    End Try
    'End Function
    'Private _Found As Boolean = False
    'Public Property Found() As Boolean
    '    Get
    '        Return _Found
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _Found = value
    '    End Set
    'End Property

End Class
