Public Class Helpdesk
    Inherits tblHelpdesk

    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    Enum VIA
        ID
        LIDID
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal via As VIA)
        Dim ohelper As New Helper
        If via = Helpdesk.VIA.ID Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf via = Helpdesk.VIA.LIDID Then
            ohelper.FillObject(Me, GetByLidId(id))
        End If

    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Helpdesk where id = @id"
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

    Public Function GetByLidId(ByVal Id As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Helpdesk where LidId = @LidId"
            Dim param() As Object = {"@LidId", Id}
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

    Public Sub Save()
        Try
            If Me.LidId = 0 Then Throw New Exception("Kan niet opslaan zonder relatieId.")

            If Me.Id = Nothing Then
                CreateDate = Now
                CreateBy = URights.UserName
                Id = da.InsertString(Me, "Helpdesk", "Id", True)
                Dim myHistory As New History
                myHistory.LidId = Me.LidId
                myHistory.TableName = "Helpdesk"
                myHistory.Veld = "Helpdesk toegevoegd"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "Nieuw"
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                If da.isChanged(Me, "Helpdesk", "Id", Me.Id, Me.LidId) Then
                    da.UpdateString(Me, "Helpdesk", "Id")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            da.DeleteString(Me, "Helpdesk")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
