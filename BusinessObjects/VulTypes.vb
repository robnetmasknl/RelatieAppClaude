Public Class VulTypes

    Public Sub New()


    End Sub


    Private _list As List(Of VulTypes)
    Public Property list() As List(Of VulTypes)
        Get
            If _list Is Nothing Then
                _list = New List(Of VulTypes)
                Dim tmp As New VulTypes
                tmp.id = 1
                tmp.Value = "vanaf"
                _list.Add(tmp)
                tmp = New VulTypes
                tmp.id = 2
                tmp.Value = "tot"
                _list.Add(tmp)
                tmp = New VulTypes
                tmp.id = 3
                tmp.Value = "rondom"
                _list.Add(tmp)
            End If

            Return _list
        End Get
        Set(ByVal value As List(Of VulTypes))
            _list = value
        End Set
    End Property

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _Value As String
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property


End Class
