Public Class DeclaratieSettings
    Inherits tblDeclaratieSettings
    Private da As New DataAccess

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub
    Public Sub New(ByVal StartDate As Date)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetByDate(StartDate))
    End Sub
    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM DeclaratieSettings where Id = @id"
            Dim param() As Object = {"@id", GetId}
            oDr = da.ExecuteDataRow(sql, param)

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
    Public Function GetByDate(ByVal StartDate As Date) As Data.DataRow
        Dim oDr As Data.DataRow = Nothing
        Try
            Dim sql As String = "SELECT * FROM DeclaratieSettings where StartDate <= @StartDate order by startdate"
            Dim param() As Object = {"@StartDate", StartDate}
            Dim dt As DataTable = da.ExecuteDataTable(sql, param)

            Dim rememberdate As Date
            For Each row In dt.Rows
                rememberdate = row.item("StartDate")
                If StartDate < rememberdate Then
                    oDr = row
                    Continue For
                Else
                    oDr = row
                End If
            Next

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
                Id = da.InsertString(Me, "DeclaratieSettings", "Id", True)
            Else
                da.UpdateString(Me, "DeclaratieSettings", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "DeclaratieSettings")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
