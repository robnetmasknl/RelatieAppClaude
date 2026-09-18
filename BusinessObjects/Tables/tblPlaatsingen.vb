Public Class tblPlaatsingen
#Region "members"
    Private _P_Id As Int32 = 0
    Private _code As String = String.Empty
    Private _plaatsing As String = String.Empty
#End Region

#Region "Properties"

    <MapperColumn("P_Id", SqlDbType.Int)> _
    Public Property P_Id() As Int32
        Get
            Return _P_Id
        End Get
        Set(ByVal value As Int32)
            _P_Id = value
        End Set
    End Property
    <MapperColumn("code", SqlDbType.VarChar)> _
    Public Property code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property
    <MapperColumn("plaatsing", SqlDbType.varchar)> _
    Public Property plaatsing() As String
        Get
            Return _plaatsing
        End Get
        Set(ByVal value As String)
            _plaatsing = Value
        End Set
    End Property

#End Region

End Class