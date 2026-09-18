<MapperTable("Templates", "Id")> _
Public Class tblTemplates

#Region "members"
    Private _Id As Int32 = 0
    Private _Bond As Int32 = 0
    Private _Naam As String = String.Empty
    Private _Omschrijving As String = String.Empty
    Private _locatie As String = String.Empty
    Private _Afdeling As String = String.Empty

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
    <MapperColumn("Bond")> _
    Public Property Bond() As Int32
        Get
            Return _Bond
        End Get
        Set(ByVal value As Int32)
            _Bond = value
        End Set
    End Property
    <MapperColumn("Naam")> _
    Public Property Naam() As String
        Get
            Return _Naam
        End Get
        Set(ByVal value As String)
            _Naam = value
        End Set
    End Property
    <MapperColumn("Omschrijving")> _
    Public Property Omschrijving() As String
        Get
            Return _Omschrijving
        End Get
        Set(ByVal value As String)
            _Omschrijving = value
        End Set
    End Property
    <MapperColumn("locatie")> _
    Public Property locatie() As String
        Get
            Return _locatie
        End Get
        Set(ByVal value As String)
            If Not value.EndsWith("\") Then
                value &= "\"
            End If
            _locatie = value
        End Set
    End Property
    '
    <MapperColumn("Afdeling")> _
Public Property Afdeling() As String
        Get
            Return _Afdeling
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                If Not value.EndsWith("\") Then
                    value &= "\"
                End If
            End If
            _Afdeling = value
        End Set
    End Property
#End Region
    Private da As New DataAccess
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub
    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM templates where id = @id"
            Dim param() As Object = {"@id", GetId}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Private _DefaultLocation As String = String.Empty
    Public ReadOnly Property DefaultLocation() As String
        Get

            If String.IsNullOrEmpty(_DefaultLocation) Then
                Dim sys As New Systeeminstellingen("TemplatePath", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _DefaultLocation = sys.Waarde
                If Not _DefaultLocation.EndsWith("\") Then _DefaultLocation &= "\"
            End If
            Return _DefaultLocation
        End Get
    End Property
    Private _FullName As String = String.Empty
    Public ReadOnly Property FullName() As String
        Get

            Dim _path As String = locatie
            If Not _path.EndsWith("\") Then _path &= "\"


            If _path = "\" Then
                _path = DefaultLocation
                If Not _path.EndsWith("\") Then _path &= "\"
                _path &= Afdeling
            End If

       
            _FullName = _path & Naam
            Return _FullName
        End Get
    End Property
End Class