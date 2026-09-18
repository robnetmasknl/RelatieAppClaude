
<MapperTable("Lidsoorten", "Id")> _
Public Class tblLidsoorten
#Region "members"
    Private _Id As Int32 = 0
    Private _soort As String = String.Empty
    Private _omschrijving As String = String.Empty
    Private _Fase As Boolean = False
    Private _LeeftijdCheck As Int32 = 0
    Private _ResetPlaatsing As Boolean = False
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
    <MapperColumn("soort")> _
    Public Property soort() As String
        Get
            Return _soort
        End Get
        Set(ByVal value As String)
            _soort = value
        End Set
    End Property
    <MapperColumn("omschrijving")> _
    Public Property omschrijving() As String
        Get
            Return _omschrijving
        End Get
        Set(ByVal value As String)
            _omschrijving = value
        End Set
    End Property

    <MapperColumn("Fase")> _
    Public Property Fase() As Boolean
        Get
            Return _Fase
        End Get
        Set(ByVal value As Boolean)
            _Fase = value
        End Set
    End Property

    <MapperColumn("LeeftijdCheck")> _
Public Property LeeftijdCheck() As Int32
        Get
            Return _LeeftijdCheck
        End Get
        Set(ByVal value As Int32)
            _LeeftijdCheck = value
        End Set
    End Property
    <MapperColumn("ResetPlaatsing")> _
Public Property ResetPlaatsing() As Boolean
        Get
            Return _ResetPlaatsing
        End Get
        Set(ByVal value As Boolean)
            _ResetPlaatsing = value
        End Set
    End Property
#End Region

End Class