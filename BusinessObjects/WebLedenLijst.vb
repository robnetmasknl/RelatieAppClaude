Imports System.ComponentModel

Public Class WebLedenLijst

    Public _DOB As Date = Date.MinValue
    Public _SearchName As String = String.Empty

    Private _ByDOBNAME As List(Of WebLid)
    Public Property ByDOBNAME() As List(Of WebLid)
        Get
            If _DOB = Date.MinValue Then Throw New Exception("Geboortedatum is niet ingevuld!")
            If String.IsNullOrEmpty(_SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")

            If _ByDOBNAME Is Nothing Then
                _ByDOBNAME = New List(Of WebLid)
                Dim _lid As New WebLid
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND geboortedatum = @DOB AND achternaam = @naam"
                Dim param() As Object = {"@DOB", _DOB, "@naam", _SearchName}
                _ByDOBNAME = ohelper.MapDataTableToList(Of WebLid)(_lid.GetList(sql, param))
            End If

            Return _ByDOBNAME
        End Get
        Set(ByVal value As List(Of WebLid))
            _ByDOBNAME = value
        End Set
    End Property
    Private _ByNAME As List(Of WebLid)
    Public Property ByNAME(ByVal SearchName As String) As List(Of WebLid)
        Get
            If String.IsNullOrEmpty(SearchName) Then Throw New Exception("Zoeknaam is niet ingevuld!")

            If _ByNAME Is Nothing Then
                _ByNAME = New List(Of WebLid)
                Dim _lid As New WebLid
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND achternaam LIKE @naam  ORDER BY achternaam"
                Dim param() As Object = {"@naam", SearchName & "%"}
                _ByNAME = ohelper.MapDataTableToList(Of WebLid)(_lid.GetList(sql, param))
            End If

            Return _ByNAME
        End Get
        Set(ByVal value As List(Of WebLid))
            _ByNAME = value
        End Set
    End Property

    Private _ByLidNr As List(Of WebLid)
    Public Property ByLidNr(ByVal LidNr As String) As List(Of WebLid)
        Get
            If String.IsNullOrEmpty(LidNr) Then Throw New Exception("lidnr is niet ingevuld!")

            If _ByLidNr Is Nothing Then
                _ByLidNr = New List(Of WebLid)
                Dim _lid As New WebLid
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND lidnr = @lidnr"
                Dim param() As Object = {"@lidnr", LidNr}
                _ByLidNr = ohelper.MapDataTableToList(Of WebLid)(_lid.GetList(sql, param))
            End If

            Return _ByLidNr
        End Get
        Set(ByVal value As List(Of WebLid))
            _ByLidNr = value
        End Set
    End Property
    Private _ByLidNrlike As List(Of WebLid)
    Public Property ByLidNrlike(ByVal LidNr As String) As List(Of WebLid)
        Get
            If String.IsNullOrEmpty(LidNr) Then Throw New Exception("lidnr is niet ingevuld!")

            If _ByLidNr Is Nothing Then
                _ByLidNr = New List(Of WebLid)
                Dim _lid As New WebLid
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM relaties WHERE (Status = 3 OR Status = 0) AND lidnr LIKE @lidnr"
                Dim param() As Object = {"@lidnr", "%" & LidNr & "%"}
                _ByLidNr = ohelper.MapDataTableToList(Of WebLid)(_lid.GetList(sql, param))
            End If

            Return _ByLidNr
        End Get
        Set(ByVal value As List(Of WebLid))
            _ByLidNr = value
        End Set
    End Property

End Class
