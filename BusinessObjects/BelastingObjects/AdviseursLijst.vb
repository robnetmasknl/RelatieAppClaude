Public Class AdviseursLijst

    Private _Lijst As List(Of Adviseur)
    Public Property Lijst() As List(Of Adviseur)
        Get

            If _Lijst Is Nothing Then
                _Lijst = New List(Of Adviseur)
                Dim _Adviseur As New Adviseur
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM Adviseurs"
                _Lijst = ohelper.MapDataTableToList(Of Adviseur)(_Adviseur.GetList(sql))
            End If

            Return _Lijst
        End Get
        Set(ByVal value As List(Of Adviseur))
            _Lijst = value
        End Set
    End Property


End Class
