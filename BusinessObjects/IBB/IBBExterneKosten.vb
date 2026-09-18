Public Class IBBExterneKosten
    Inherits tblIBBExterneKosten
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess
#Region "Basic"
 
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))

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
    Public Function GetById(ByVal id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM  IBBExterneKosten where id = @id"
            Dim param() As Object = {"@id", id.ToString}
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
    Public Sub Save()
        Try
            If DossierId = 0 Then Throw New Exception("Het heeft nog geen dossier")

            If Me.Id = Nothing Then
                CreateDate = Now
                CreatedBy = URights.UserName
                Id = da.InsertString(Me, "IBBExterneKosten", "Id", True)
                da.UpdateMutDateDossier(DossierId)
                Dim myHistory As New History
                myHistory.LidId = DossierId
                myHistory.TableName = "IBBExterneKosten"
                myHistory.Veld = "Nieuw IBBExterneKosten"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "IBBExterneKosten:" & Me.Id
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                If da.isChanged(Me, "IBBExterneKosten", "Id", Me.Id, DossierId) Then
                    da.UpdateString(Me, "IBBExterneKosten", "Id")
                    da.UpdateMutDateDossier(DossierId)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "IBBExterneKosten")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
