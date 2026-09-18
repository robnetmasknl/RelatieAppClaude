Public Class Email

    Private _Address As String = ""
    Private _Name As String = ""
    Private _Actief As Boolean
    Private _Salutation As String = ""

    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Public Property Name() As String
        Get
            If _Name.Trim.Length = 0 Then
                Return _Address
            Else
                Return _Name
            End If

        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Public Property Actief() As Boolean
        Get
            Return _Actief
        End Get
        Set(ByVal value As Boolean)
            _Actief = value
        End Set
    End Property

    Public Property Salutation() As String
        Get
            If _Salutation.Trim.Length = 0 Then
                Return "Geachte heer/mevrouw"
            Else
                Return _Salutation
            End If
        End Get
        Set(ByVal value As String)
            _Salutation = value
        End Set
    End Property


End Class
