Public Class IBBDocumentList



    Private _LijstByDossierType As List(Of IBBDocument)
    Public ReadOnly Property LijstByDossierType(ByVal DossierId As Integer, Optional ByVal jdTypeId As Integer = 0) As List(Of IBBDocument)
        Get
            If _LijstByDossierType Is Nothing Then
                _LijstByDossierType = New List(Of IBBDocument)
                Dim _ibbdocument As New IBBDocument
                Dim ohelper As New Helper
                'Dim sql As String = "SELECT * FROM IBBDocuments " & _
                '                    "inner join jdTypes on jdTypeId = jdtypes.id " & _
                '                    "where DossierId = @DossierId "
                Dim sql As String = "SELECT * FROM IBBDocuments where DossierId = @DossierId "
                Dim params As New ArrayList
                params.Add("@DossierId")
                params.Add(DossierId)
                If jdTypeId > 0 Then
                    sql &= "AND jdTypeId = @jdTypeId"
                    params.Add("@jdTypeId")
                    params.Add(jdTypeId)
                End If

                _LijstByDossierType = ohelper.MapDataTableToList(Of IBBDocument)(_ibbdocument.GetList(sql, params.ToArray))
            End If

            Return _LijstByDossierType
        End Get
    End Property
End Class
