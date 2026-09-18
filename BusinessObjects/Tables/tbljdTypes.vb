Public Class tbljdTypes

#Region "members"
    Private _id As Int32 = 0
    Private _Type As String = String.Empty
    Private _Description As String = String.Empty
    Private _Seq As Int32 = 0
    Private _Sort As String = String.Empty

#End Region

#Region "Properties"

    <MapperColumn("Id", SqlDbType.Int)> _
    Public Property Id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    <MapperColumn("Type", SqlDbType.VarChar)> _
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    <MapperColumn("Description", SqlDbType.VarChar)> _
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = Value
        End Set
    End Property

    <MapperColumn("Seq", SqlDbType.Int)> _
Public Property Seq() As Int32
        Get
            Return _Seq
        End Get
        Set(ByVal value As Int32)
            _Seq = value
        End Set
    End Property
    <MapperColumn("Sort", SqlDbType.VarChar)> _
    Public Property Sort() As String
        Get
            Return _Sort
        End Get
        Set(ByVal value As String)
            _Sort = value
        End Set
    End Property
#End Region
End Class
