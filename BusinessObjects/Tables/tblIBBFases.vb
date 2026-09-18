Public Class tblIBBFases
    ' Implements IComparable(Of tblIBBFases)
    ' Private strName As String

    Public Function Clone() As IBBFase
        Return DirectCast(Me.MemberwiseClone, IBBFase)
    End Function

    'Public Function CompareTo(ByVal other As tblIBBFases) As Integer Implements System.IComparable(Of tblIBBFases).CompareTo
    '    If Not String.IsNullOrEmpty(Me.strname) Then
    '        If Not String.IsNullOrEmpty(other.strname) Then
    '            Return Me.strname.CompareTo(other.strname)
    '        Else
    '            Return 1
    '        End If
    '    Else
    '        If Not String.IsNullOrEmpty(other.strname) Then
    '            Return -1
    '        Else
    '            Return 0
    '        End If
    '    End If
    'End Function
    'Public Overrides Function Equals(ByVal obj As Object) As Boolean
    '    If obj.GetType Is GetType(tblIBBFases) Then
    '        If CType(obj, tblIBBFases).strname = Me.strname Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End If
    '    Return False
    'End Function
#Region "members"
    Private _Id As Int32 = 0
    Private _DossierId As Int32 = 0
    Private _TypeId As Int32 = 0
    Private _CalEntryBesluitId As String = String.Empty
    Private _CalEntryHerstelId As String = String.Empty
    Private _CalEntryObjectionId As String = String.Empty
    Private _CalEntryBesluitIdHandler As String = String.Empty
    Private _CalEntryHerstelIdHandler As String = String.Empty
    Private _CalEntryObjectionIdHandler As String = String.Empty
    Private _CalEntryHoorzittingId As String = String.Empty
    Private _CalEntryHoorzittingIdHandler As String = String.Empty
    Private _CalEntry8 As String = String.Empty
    Private _CalEntryHandler8 As String = String.Empty
    Private _CalEntryTempObjection As String = String.Empty
    Private _CalEntryTempObjectionHandler As String = String.Empty
    Private _Indiendatum As String = String.Empty
    Private _Ingebreke As String = String.Empty
    Private _Besluit As Int32 = 0
    Private _Beslisdatum As String = String.Empty
    Private _Herstelverzuimtermijn As String = String.Empty
    Private _VovoCB As Boolean
    Private _VovoDat As String = String.Empty
    Private _VovoDatuit As String = String.Empty
    Private _VovoUitsp As Int32 = 0
    Private _VovoToev As String = String.Empty
    Private _AanhBezw As Boolean
    Private _Opmerkingen As String = String.Empty
    Private _Opmerkingen2 As String = String.Empty
    Private _Zitting As String = String.Empty
    Private _CreateDate As String = String.Empty
    Private _CreatedBy As String = String.Empty
    Private _RepaidClientdate As String = String.Empty
    Private _RepaidGriffieDate As String = String.Empty
    Private _IngebrekeBeslissingDatum As String = String.Empty
    Private _IngebrekeStelling As Boolean
    Private _IngebrekeOpmerkingen As String = String.Empty
    Private _VnVChoice As Int32 = 0
    Private _InhoudelijkBeroep As Boolean
    Private _Intrekking As Boolean
    Private _Bezwaarschrift As String = String.Empty
    'Private _Extra6Weken As Boolean
    Private _ExtraWeken As Int32 = 0
    Private _VoorloopigBezwaar As String = String.Empty
    Private _Hoorzittingdatum As String = String.Empty
    Private _BeslissingBezwaar As String = String.Empty
    Private _DateField8 As String = String.Empty
    Private _Hoorzittinglocatie As String = String.Empty
    Private _DateField9 As String = String.Empty
    Private _CalEntry9 As String = String.Empty
    Private _CalEntryHandler9 As String = String.Empty
    Private _DateField10 As String = String.Empty
    Private _CalEntry10 As String = String.Empty
    Private _CalEntryHandler10 As String = String.Empty
    Private _DateField11 As String = String.Empty
    Private _CalEntry11 As String = String.Empty
    Private _CalEntryHandler11 As String = String.Empty
    Private _HoorzittingText As String = String.Empty
    Private _Instantie As String = String.Empty
    Private _Indiener As String = String.Empty
    Private _Advies As String = String.Empty
    Private _CalEntryVoVoId As String = String.Empty
    Private _CalEntryVoVoHandler As String = String.Empty
    Private _ZittingStart As String = "08:00"
    Private _ZittingEnd As String = "08:00"
    Private _Kenmerk As String = String.Empty
    Private _DateTempObjection As String = String.Empty
    Private _VoVoRecall As Boolean

#End Region

#Region "Properties"

    <MapperColumn("Id", SqlDbType.Int)> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("DossierId", SqlDbType.Int)> _
    Public Property DossierId() As Int32
        Get
            Return _DossierId
        End Get
        Set(ByVal value As Int32)
            _DossierId = value
        End Set
    End Property
    <MapperColumn("TypeId", SqlDbType.Int)> _
    Public Property TypeId() As Int32
        Get
            Return _TypeId
        End Get
        Set(ByVal value As Int32)
            _TypeId = value
        End Set
    End Property
    <MapperColumn("CalEntryBesluitId", SqlDbType.VarChar)> _
    Public Property CalEntryBesluitId() As String
        Get
            Return _CalEntryBesluitId
        End Get
        Set(ByVal value As String)
            _CalEntryBesluitId = value
        End Set
    End Property
    <MapperColumn("CalEntryHerstelId", SqlDbType.VarChar)> _
    Public Property CalEntryHerstelId() As String
        Get
            Return _CalEntryHerstelId
        End Get
        Set(ByVal value As String)
            _CalEntryHerstelId = value
        End Set
    End Property
    <MapperColumn("CalEntryObjectionId", SqlDbType.VarChar)> _
    Public Property CalEntryObjectionId() As String
        Get
            Return _CalEntryObjectionId
        End Get
        Set(ByVal value As String)
            _CalEntryObjectionId = value
        End Set
    End Property
    <MapperColumn("CalEntryBesluitIdHandler", SqlDbType.VarChar)> _
    Public Property CalEntryBesluitIdHandler() As String
        Get
            Return _CalEntryBesluitIdHandler
        End Get
        Set(ByVal value As String)
            _CalEntryBesluitIdHandler = value
        End Set
    End Property
    <MapperColumn("CalEntryHerstelIdHandler", SqlDbType.VarChar)> _
    Public Property CalEntryHerstelIdHandler() As String
        Get
            Return _CalEntryHerstelIdHandler
        End Get
        Set(ByVal value As String)
            _CalEntryHerstelIdHandler = value
        End Set
    End Property
    <MapperColumn("CalEntryObjectionIdHandler", SqlDbType.VarChar)> _
    Public Property CalEntryObjectionIdHandler() As String
        Get
            Return _CalEntryObjectionIdHandler
        End Get
        Set(ByVal value As String)
            _CalEntryObjectionIdHandler = value
        End Set
    End Property
    <MapperColumn("CalEntryHoorzittingId", SqlDbType.VarChar)> _
    Public Property CalEntryHoorzittingId() As String
        Get
            Return _CalEntryHoorzittingId
        End Get
        Set(ByVal value As String)
            _CalEntryHoorzittingId = value
        End Set
    End Property
    <MapperColumn("CalEntryHoorzittingIdHandler", SqlDbType.VarChar)> _
    Public Property CalEntryHoorzittingIdHandler() As String
        Get
            Return _CalEntryHoorzittingIdHandler
        End Get
        Set(ByVal value As String)
            _CalEntryHoorzittingIdHandler = value
        End Set
    End Property
    <MapperColumn("CalEntry8", SqlDbType.VarChar)> _
    Public Property CalEntry8() As String
        Get
            Return _CalEntry8
        End Get
        Set(ByVal value As String)
            _CalEntry8 = value
        End Set
    End Property
    <MapperColumn("CalEntryHandler8", SqlDbType.VarChar)> _
    Public Property CalEntryHandler8() As String
        Get
            Return _CalEntryHandler8
        End Get
        Set(ByVal value As String)
            _CalEntryHandler8 = value
        End Set
    End Property
    <MapperColumn("CalEntryTempObjection", SqlDbType.VarChar)> _
        Public Property CalEntryTempObjection() As String
        Get
            Return _CalEntryTempObjection
        End Get
        Set(ByVal value As String)
            _CalEntryTempObjection = value
        End Set
    End Property
    <MapperColumn("CalEntryTempObjectionHandler", SqlDbType.VarChar)> _
    Public Property CalEntryTempObjectionHandler() As String
        Get
            Return _CalEntryTempObjectionHandler
        End Get
        Set(ByVal value As String)
            _CalEntryTempObjectionHandler = value
        End Set
    End Property

    <MapperColumn("Indiendatum", SqlDbType.DateTime)> _
    Public Property Indiendatum() As String
        Get
            Return _Indiendatum
        End Get
        Set(ByVal value As String)
            _Indiendatum = value
        End Set
    End Property
    <MapperColumn("Ingebreke", SqlDbType.DateTime)> _
    Public Property Ingebreke() As String
        Get
            Return _Ingebreke
        End Get
        Set(ByVal value As String)
            _Ingebreke = value
        End Set
    End Property
    <MapperColumn("Besluit", SqlDbType.Int)> _
    Public Property Besluit() As Int32
        Get
            Return _Besluit
        End Get
        Set(ByVal value As Int32)
            _Besluit = value
        End Set
    End Property
    <MapperColumn("Beslisdatum", SqlDbType.DateTime)> _
    Public Property Beslisdatum() As String
        Get
            Return _Beslisdatum
        End Get
        Set(ByVal value As String)
            _Beslisdatum = value
        End Set
    End Property
    <MapperColumn("Herstelverzuimtermijn", SqlDbType.DateTime)> _
    Public Property Herstelverzuimtermijn() As String
        Get
            Return _Herstelverzuimtermijn
        End Get
        Set(ByVal value As String)
            _Herstelverzuimtermijn = value
        End Set
    End Property
    <MapperColumn("VovoCB", SqlDbType.Bit)> _
    Public Property VovoCB() As Boolean
        Get
            Return _VovoCB
        End Get
        Set(ByVal value As Boolean)
            _VovoCB = value
        End Set
    End Property
    <MapperColumn("VovoDat", SqlDbType.DateTime)> _
    Public Property VovoDat() As String
        Get
            Return _VovoDat
        End Get
        Set(ByVal value As String)
            _VovoDat = value
        End Set
    End Property
    <MapperColumn("VovoDatuit", SqlDbType.DateTime)> _
    Public Property VovoDatuit() As String
        Get
            Return _VovoDatuit
        End Get
        Set(ByVal value As String)
            _VovoDatuit = value
        End Set
    End Property
    <MapperColumn("VovoUitsp", SqlDbType.Int)> _
    Public Property VovoUitsp() As Int32
        Get
            Return _VovoUitsp
        End Get
        Set(ByVal value As Int32)
            _VovoUitsp = value
        End Set
    End Property
    <MapperColumn("VovoToev", SqlDbType.VarChar)> _
    Public Property VovoToev() As String
        Get
            Return _VovoToev
        End Get
        Set(ByVal value As String)
            _VovoToev = value
        End Set
    End Property
    <MapperColumn("AanhBezw", SqlDbType.Bit)> _
    Public Property AanhBezw() As Boolean
        Get
            Return _AanhBezw
        End Get
        Set(ByVal value As Boolean)
            _AanhBezw = value
        End Set
    End Property
    <MapperColumn("Opmerkingen", SqlDbType.VarChar)> _
    Public Property Opmerkingen() As String
        Get
            Return _Opmerkingen
        End Get
        Set(ByVal value As String)
            _Opmerkingen = value
        End Set
    End Property
    <MapperColumn("Opmerkingen2", SqlDbType.VarChar)> _
    Public Property Opmerkingen2() As String
        Get
            Return _Opmerkingen2
        End Get
        Set(ByVal value As String)
            _Opmerkingen2 = value
        End Set
    End Property
    <MapperColumn("Zitting", SqlDbType.DateTime)> _
    Public Property Zitting() As String
        Get
            Return _Zitting
        End Get
        Set(ByVal value As String)
            _Zitting = value
        End Set
    End Property
    <MapperColumn("CreateDate", SqlDbType.DateTime)> _
    Public Property CreateDate() As String
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As String)
            _CreateDate = value
        End Set
    End Property
    <MapperColumn("CreatedBy", SqlDbType.VarChar)> _
    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property
    <MapperColumn("RepaidClientdate", SqlDbType.DateTime)> _
    Public Property RepaidClientdate() As String
        Get
            Return _RepaidClientdate
        End Get
        Set(ByVal value As String)
            _RepaidClientdate = value
        End Set
    End Property
    <MapperColumn("RepaidGriffieDate", SqlDbType.DateTime)> _
    Public Property RepaidGriffieDate() As String
        Get
            Return _RepaidGriffieDate
        End Get
        Set(ByVal value As String)
            _RepaidGriffieDate = value
        End Set
    End Property
    <MapperColumn("IngebrekeBeslissingDatum", SqlDbType.DateTime)> _
    Public Property IngebrekeBeslissingDatum() As String
        Get
            Return _IngebrekeBeslissingDatum
        End Get
        Set(ByVal value As String)
            _IngebrekeBeslissingDatum = value
        End Set
    End Property
    <MapperColumn("IngebrekeStelling", SqlDbType.Bit)> _
    Public Property IngebrekeStelling() As Boolean
        Get
            Return _IngebrekeStelling
        End Get
        Set(ByVal value As Boolean)
            _IngebrekeStelling = value
        End Set
    End Property
    <MapperColumn("IngebrekeOpmerkingen", SqlDbType.VarChar)> _
    Public Property IngebrekeOpmerkingen() As String
        Get
            Return _IngebrekeOpmerkingen
        End Get
        Set(ByVal value As String)
            _IngebrekeOpmerkingen = value
        End Set
    End Property
    <MapperColumn("VnVChoice", SqlDbType.Int)> _
    Public Property VnVChoice() As Int32
        Get
            Return _VnVChoice
        End Get
        Set(ByVal value As Int32)
            _VnVChoice = value
        End Set
    End Property
    <MapperColumn("InhoudelijkBeroep", SqlDbType.Bit)> _
    Public Property InhoudelijkBeroep() As Boolean
        Get
            Return _InhoudelijkBeroep
        End Get
        Set(ByVal value As Boolean)
            _InhoudelijkBeroep = value
        End Set
    End Property
    <MapperColumn("Intrekking", SqlDbType.Bit)> _
    Public Property Intrekking() As Boolean
        Get
            Return _Intrekking
        End Get
        Set(ByVal value As Boolean)
            _Intrekking = value
        End Set
    End Property
    <MapperColumn("Bezwaarschrift", SqlDbType.DateTime)> _
    Public Property Bezwaarschrift() As String
        Get
            Return _Bezwaarschrift
        End Get
        Set(ByVal value As String)
            _Bezwaarschrift = value
        End Set
    End Property
    '<MapperColumn("Extra6Weken", SqlDbType.Bit)> _
    'Public Property Extra6Weken() As Boolean
    '    Get
    '        Return _Extra6Weken
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _Extra6Weken = value
    '    End Set
    'End Property
    <MapperColumn("ExtraWeken", SqlDbType.Int)> _
    Public Property ExtraWeken() As Int32
        Get
            Return _ExtraWeken
        End Get
        Set(ByVal value As Int32)
            _ExtraWeken = value
        End Set
    End Property


    <MapperColumn("VoorloopigBezwaar", SqlDbType.DateTime)> _
    Public Property VoorloopigBezwaar() As String
        Get
            Return _VoorloopigBezwaar
        End Get
        Set(ByVal value As String)
            _VoorloopigBezwaar = value
        End Set
    End Property
    <MapperColumn("Hoorzittingdatum", SqlDbType.DateTime)> _
    Public Property Hoorzittingdatum() As String
        Get
            Return _Hoorzittingdatum
        End Get
        Set(ByVal value As String)
            _Hoorzittingdatum = value
        End Set
    End Property

    <MapperColumn("Hoorzittinglocatie", SqlDbType.VarChar)> _
    Public Property Hoorzittinglocatie() As String
        Get
            Return _Hoorzittinglocatie
        End Get
        Set(ByVal value As String)
            _Hoorzittinglocatie = value
        End Set
    End Property
    <MapperColumn("BeslissingBezwaar", SqlDbType.DateTime)> _
    Public Property BeslissingBezwaar() As String
        Get
            Return _BeslissingBezwaar
        End Get
        Set(ByVal value As String)
            _BeslissingBezwaar = value
        End Set
    End Property
    <MapperColumn("DateField8", SqlDbType.DateTime)> _
    Public Property DateField8() As String
        Get
            Return _DateField8
        End Get
        Set(ByVal value As String)
            _DateField8 = value
        End Set
    End Property
    <MapperColumn("DateField9", SqlDbType.DateTime)> _
    Public Property DateField9() As String
        Get
            Return _DateField9
        End Get
        Set(ByVal value As String)
            _DateField9 = value
        End Set
    End Property
    <MapperColumn("CalEntry9", SqlDbType.VarChar)> _
    Public Property CalEntry9() As String
        Get
            Return _CalEntry9
        End Get
        Set(ByVal value As String)
            _CalEntry9 = value
        End Set
    End Property
    <MapperColumn("CalEntryHandler9", SqlDbType.VarChar)> _
    Public Property CalEntryHandler9() As String
        Get
            Return _CalEntryHandler9
        End Get
        Set(ByVal value As String)
            _CalEntryHandler9 = value
        End Set
    End Property
    <MapperColumn("DateField10", SqlDbType.DateTime)> _
    Public Property DateField10() As String
        Get
            Return _DateField10
        End Get
        Set(ByVal value As String)
            _DateField10 = value
        End Set
    End Property
    <MapperColumn("CalEntry10", SqlDbType.VarChar)> _
    Public Property CalEntry10() As String
        Get
            Return _CalEntry10
        End Get
        Set(ByVal value As String)
            _CalEntry10 = value
        End Set
    End Property
    <MapperColumn("CalEntryHandler10", SqlDbType.VarChar)> _
    Public Property CalEntryHandler10() As String
        Get
            Return _CalEntryHandler10
        End Get
        Set(ByVal value As String)
            _CalEntryHandler10 = value
        End Set
    End Property
    <MapperColumn("DateField11", SqlDbType.DateTime)> _
    Public Property DateField11() As String
        Get
            Return _DateField11
        End Get
        Set(ByVal value As String)
            _DateField11 = value
        End Set
    End Property
    <MapperColumn("CalEntry11", SqlDbType.VarChar)> _
    Public Property CalEntry11() As String
        Get
            Return _CalEntry11
        End Get
        Set(ByVal value As String)
            _CalEntry11 = value
        End Set
    End Property
    <MapperColumn("CalEntryHandler11", SqlDbType.VarChar)> _
    Public Property CalEntryHandler11() As String
        Get
            Return _CalEntryHandler11
        End Get
        Set(ByVal value As String)
            _CalEntryHandler11 = value
        End Set
    End Property
    <MapperColumn("HoorzittingText", SqlDbType.VarChar)> _
    Public Property HoorzittingText() As String
        Get
            Return _HoorzittingText
        End Get
        Set(ByVal value As String)
            _HoorzittingText = Value
        End Set
    End Property
    <MapperColumn("Instantie", SqlDbType.VarChar)> _
    Public Property Instantie() As String
        Get
            Return _Instantie
        End Get
        Set(ByVal value As String)
            _Instantie = Value
        End Set
    End Property
    <MapperColumn("Indiener", SqlDbType.VarChar)> _
    Public Property Indiener() As String
        Get
            Return _Indiener
        End Get
        Set(ByVal value As String)
            _Indiener = Value
        End Set
    End Property
    <MapperColumn("Advies", SqlDbType.VarChar)> _
    Public Property Advies() As String
        Get
            Return _Advies
        End Get
        Set(ByVal value As String)
            _Advies = Value
        End Set
    End Property
    <MapperColumn("CalEntryVoVoId", SqlDbType.VarChar)> _
    Public Property CalEntryVoVoId() As String
        Get
            Return _CalEntryVoVoId
        End Get
        Set(ByVal value As String)
            _CalEntryVoVoId = value
        End Set
    End Property
    <MapperColumn("CalEntryVoVoHandler", SqlDbType.VarChar)> _
    Public Property CalEntryVoVoHandler() As String
        Get
            Return _CalEntryVoVoHandler
        End Get
        Set(ByVal value As String)
            _CalEntryVoVoHandler = value
        End Set
    End Property
    <MapperColumn("ZittingStart", SqlDbType.VarChar)> _
    Public Property ZittingStart() As String
        Get
            Return _ZittingStart
        End Get
        Set(ByVal value As String)
            _ZittingStart = value
        End Set
    End Property
    <MapperColumn("ZittingEnd", SqlDbType.VarChar)> _
    Public Property ZittingEnd() As String
        Get
            Return _ZittingEnd
        End Get
        Set(ByVal value As String)
            _ZittingEnd = value
        End Set
    End Property
    <MapperColumn("Kenmerk", SqlDbType.VarChar)> _
    Public Property Kenmerk() As String
        Get
            Return _Kenmerk
        End Get
        Set(ByVal value As String)
            _Kenmerk = value
        End Set
    End Property
    <MapperColumn("DateTempObjection", SqlDbType.DateTime)> _
    Public Property DateTempObjection() As String
        Get
            Return _DateTempObjection
        End Get
        Set(ByVal value As String)
            _DateTempObjection = value
        End Set
    End Property
    <MapperColumn("VoVoRecall", SqlDbType.Bit)> _
    Public Property VoVoRecall() As Boolean
        Get
            Return _VoVoRecall
        End Get
        Set(ByVal value As Boolean)
            _VoVoRecall = value
        End Set
    End Property
#End Region

End Class