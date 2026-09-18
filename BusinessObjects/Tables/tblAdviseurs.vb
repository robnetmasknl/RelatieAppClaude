<MapperTable("Adviseurs", "Id")> _
Public Class tblAdviseurs

    Private _Id As Int32 = 0
    Private _naam As String = ""

    <MapperColumn("Id")> _
    Public Property Id() As Int32
        Get
            Return _Id
        End Get
        Set(ByVal value As Int32)
            _Id = value
        End Set
    End Property
    <MapperColumn("naam")> _
    Public Property naam() As String
        Get
            Return _naam
        End Get
        Set(ByVal value As String)
            _naam = value
        End Set
    End Property

End Class
