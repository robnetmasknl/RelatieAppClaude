Public Class IBBGriffieKosten
    Inherits tblIBBGriffieKosten
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess


    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32)
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
    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM IBBGriffieKosten where id = @id"
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
    Public Sub Save()
        Try
            If DossierId = 0 Then Throw New Exception("Het heeft nog geen dossier")


            If Me.Id = Nothing Then
                CreateDate = Now
                CreatedBy = URights.UserName
                Id = da.InsertString(Me, "IBBGriffieKosten", "Id", True)
                da.UpdateMutDateDossier(DossierId)
                Dim myHistory As New History
                myHistory.LidId = DossierId
                myHistory.TableName = "IBBGriffieKosten"
                myHistory.Veld = "Nieuw IBBGriffieKosten"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "IBBGriffieKosten:" & Me.Id
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                If da.isChanged(Me, "IBBGriffieKosten", "Id", Me.Id, DossierId) Then
                    da.UpdateString(Me, "IBBGriffieKosten", "Id")
                    da.UpdateMutDateDossier(DossierId)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            da.DeleteCommand(Me, "IBBGriffieKosten", "Id")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _FaseType As FaseTypes
    Public ReadOnly Property FaseType() As FaseTypes
        Get
            If _FaseType Is Nothing Then
                _FaseType = New FaseTypes(MyFase.TypeId)
            End If
            Return _FaseType
        End Get
    End Property

    Private _MyFase As IBBFase
    Public ReadOnly Property MyFase() As IBBFase
        Get
            If _MyFase Is Nothing Then
                _MyFase = New IBBFase(Me.IBBFaseId, IBBFase.Via.ID)
            End If
            Return _MyFase
        End Get
    End Property

    Private _DossierNr As String = String.Empty
    Public ReadOnly Property DossierNr() As String
        Get
            If String.IsNullOrEmpty(_DossierNr) And DossierId > 0 Then
                Dim Sql As String = "SELECT DossierNr FROM IBBDossiers WHERE Id = @Id"
                Dim param() As Object = {"@Id", DossierId}
                _DossierNr = da.ExecuteScalar(Sql, param ).ToString
            End If
            Return _DossierNr
        End Get
    End Property
End Class
