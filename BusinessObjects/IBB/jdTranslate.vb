Public Class jdTranslate
    Inherits tbljdTranslate
    Private da As New DataAccess
#Region "Basic"
    Enum Via
        JDTYPE
    End Enum
    Public Sub New()

    End Sub

    Public Sub New(ByVal jdTypeId As String, ByVal dbfield As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetByType(jdTypeId, dbfield))
    End Sub

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Public Function GetByType(ByVal jdTypeId As Int32, ByVal dbfield As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try

            Dim Sql As String = "SELECT * FROM jdTranslate WHERE JdTypeId = @JdTypeId AND DBCOLUMN = @DBCOLUMN"
            Dim param() As Object = {"@JdTypeId", jdTypeId, "@DBCOLUMN", dbfield}
            oDr = da.ExecuteDataRow(Sql, param)

            If Not oDr Is Nothing Then
                Found = True
            End If
            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Sub Save()
        Try
            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "jdTranslate", "Id", True)
            Else
                da.UpdateString(Me, "jdTranslate", "Id")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteCommand(Me, "jdTranslate", "Id")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class