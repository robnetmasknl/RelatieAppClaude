<MapperTable("History", "Id")> _
Public Class tblHistory
#Region "members"
    Private _Id As Int32 = 0
    Private _LidId As String = String.Empty
    Private _MutDate As DateTime = Data.SqlTypes.SqlDateTime.MinValue
    Private _MutDoor As String = String.Empty
    Private _TableName As String = String.Empty
    Private _Veld As String = String.Empty
    Private _WaardeOud As String = String.Empty
    Private _WaardeNieuw As String = String.Empty
#End Region

#Region "Properties"

    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("LidId")> _
    Public Property LidId() As String
        Get
            Return _LidId
        End Get
        Set(ByVal value As String)
            _LidId = value
        End Set
    End Property
    <MapperColumn("MutDate")> _
    Public Property MutDate() As DateTime
        Get
            Return _MutDate
        End Get
        Set(ByVal value As DateTime)
            _MutDate = value
        End Set
    End Property
    <MapperColumn("MutDoor")> _
    Public Property MutDoor() As String
        Get
            Return _MutDoor
        End Get
        Set(ByVal value As String)
            _MutDoor = value
        End Set
    End Property
    <MapperColumn("TableName")> _
    Public Property TableName() As String
        Get
            Return _TableName
        End Get
        Set(ByVal value As String)
            _TableName = value
        End Set
    End Property
    <MapperColumn("Veld")> _
    Public Property Veld() As String
        Get
            Return _Veld
        End Get
        Set(ByVal value As String)
            _Veld = value
        End Set
    End Property
    <MapperColumn("WaardeOud")> _
    Public Property WaardeOud() As String
        Get
            If Not String.IsNullOrEmpty(Veld) Then
                If Veld.ToUpper = "WACHTWOORD" Then
                    Return "******"
                End If
            End If
            Return _WaardeOud
        End Get
        Set(ByVal value As String)
            If value.Length >= 100 Then
                value = value.Substring(value.Length - 100, 100)
            End If
            _WaardeOud = value
        End Set
    End Property
    <MapperColumn("WaardeNieuw")> _
    Public Property WaardeNieuw() As String
        Get
            If Not String.IsNullOrEmpty(Veld) Then
                If Veld.ToUpper = "WACHTWOORD" Then
                    Return "******"
                End If
            End If
            Return _WaardeNieuw
        End Get
        Set(ByVal value As String)
            If value.Length >= 100 Then
                value = value.Substring(value.Length - 100, 100)
            End If
            _WaardeNieuw = value
        End Set
    End Property

#End Region

End Class