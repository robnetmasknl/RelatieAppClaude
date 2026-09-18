Public Class Adviseur
    Inherits tblAdviseurs

    Private da As New DataAccess

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub

    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM adviseurs where id = @id"
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
            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "adviseurs", "Id", True)
            Else
                da.UpdateString(Me, "adviseurs", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "adviseurs")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _AantalBoekingen As Integer = 0
    Public ReadOnly Property AantalBoekingen() As Integer
        Get
            Return _AantalBoekingen
        End Get
    End Property
    Private _AantalBeschikbaar As Integer
    Public ReadOnly Property AantalBeschikbaar() As Integer
        Get
 
            Return _AantalBeschikbaar
        End Get
    End Property
    Private _AantalBlokken As Integer
    Public ReadOnly Property AantalBlokken() As Integer
        Get
            If Not _Blokken Is Nothing Then
                Dim count As Integer = Blokken.Count
            End If

            Return _AantalBlokken
        End Get
    End Property

    Private _Blokken As List(Of Blok)
    Public ReadOnly Property Blokken() As List(Of Blok)
        Get
            If _Blokken Is Nothing Then
                _Blokken = New List(Of Blok)
                Dim _Blok As New Blok
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM Blokken WHERE adviseurId = @adviseurId ORDER BY datum"
                Dim param() As Object = {"@adviseurId", Id}

                _Blokken = ohelper.MapDataTableToList(Of Blok)(_Blok.GetList(sql, param))
                _AantalBoekingen = 0
                _AantalBeschikbaar = 0
                _AantalBlokken = 0
                For Each tmpBlok As Blok In _Blokken
                    _AantalBoekingen += tmpBlok.AantalBoekingen
                    _AantalBeschikbaar += tmpBlok.AantalBeschikbaar
                    _AantalBlokken += tmpBlok.Boekingen.Count
                    '_AantalBlokken += tmpBlok.BlokType.aantal
                Next

            End If

            Return _Blokken
        End Get
    End Property
End Class
