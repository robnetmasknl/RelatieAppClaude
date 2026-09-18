Public Class BoekingLijst

    Private _blokid As Integer
    Private _blokdate As Date = Date.MinValue


    Public Sub New(ByVal blokid As Integer)
        _blokid = blokid
    End Sub

    Public Sub New(ByVal blokdate As Date)
        _blokdate = blokdate
    End Sub



    Private _ByBlok As List(Of Boeking)
    Public Property ByBlok() As List(Of Boeking)
        Get
            If _blokid = 0 Then Throw New Exception("Er is nog geen locatie opgegeven")

            If _ByBlok Is Nothing Then
                _ByBlok = New List(Of Boeking)
                Dim _Boeking As New Boeking
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM boekingen WHERE blokId = @blokId ORDER BY tijdstip"
                Dim param() As Object = {"@blokId", _blokid}
                _ByBlok = ohelper.MapDataTableToList(Of Boeking)(_Boeking.GetList(sql, param))
            End If

            Return _ByBlok
        End Get
        Set(ByVal value As List(Of Boeking))
            _ByBlok = value
        End Set
    End Property
    Private _ByAvailable As List(Of Boeking)
    Public Property ByAvailable() As List(Of Boeking)
        Get
            If _blokid = 0 Then Throw New Exception("Er is nog geen locatie opgegeven")

            If _ByAvailable Is Nothing Then
                _ByAvailable = New List(Of Boeking)
                Dim _Boeking As New Boeking
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM boekingen WHERE blokId = @blokId AND relatieId = 0 ORDER BY tijdstip"
                Dim param() As Object = {"@blokId", _blokid}
                _ByAvailable = ohelper.MapDataTableToList(Of Boeking)(_Boeking.GetList(sql, param))
            End If

            Return _ByAvailable
        End Get
        Set(ByVal value As List(Of Boeking))
            _ByBlok = value
        End Set
    End Property
    Private _ByDay As List(Of Boeking)
    Public ReadOnly Property ByDay() As List(Of Boeking)
        Get
            If _blokdate = Date.MinValue Then Throw New Exception("Er is geen datum opgegeven")

            If _ByDay Is Nothing Then
                _ByDay = New List(Of Boeking)
                Dim _Boeking As New Boeking
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM boekingen WHERE DATEDIFF(dd,0,tijdstip) = DATEDIFF(dd,0,@blokdate) AND lidnr <> '0' ORDER BY tijdstip"
                'WHERE DATEDIFF(dd,0,tijdstip) = DATEDIFF(dd,0,@BeginningTicketDate)
                Dim param() As Object = {"@blokdate", _blokdate}
                _ByDay = ohelper.MapDataTableToList(Of Boeking)(_Boeking.GetList(sql, param))
            End If

            Return _ByDay
        End Get
    End Property

End Class
