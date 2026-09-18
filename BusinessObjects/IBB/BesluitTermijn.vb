Public Class BesluitTermijn
    Private da As New DataAccess

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))

    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM jdBesluitTermijnen where Id = @Id"
            Dim param() As Object = {"@id", Id}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function

    Public Function GetList(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As Data.DataTable
        Dim oDS As Data.DataSet
        Try
            oDS = da.ExecuteDataset(sql, parameters)
            Return oDS.Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            oDS = Nothing
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
#Region "members"
    Private _Id As Int32 = 0
    Private _Termijn As String = String.Empty
    Private _TermijnDgn As Int32 = 0
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
    <MapperColumn("Termijn", SqlDbType.VarChar)> _
    Public Property Termijn() As String
        Get
            Return _Termijn
        End Get
        Set(ByVal value As String)
            _Termijn = value
        End Set
    End Property
    <MapperColumn("TermijnDgn", SqlDbType.Int)> _
    Public Property TermijnDgn() As Int32
        Get
            Return _TermijnDgn
        End Get
        Set(ByVal value As Int32)
            _TermijnDgn = value
        End Set
    End Property

#End Region
End Class
