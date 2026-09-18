Imports System.IO

Public Class IBBDocument
    Inherits tblIBBDocuments

    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    Enum VIA
        ID
        DOSSIERID
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal via As VIA)
        Dim ohelper As New Helper
        If via = IBBDocument.VIA.ID Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf via = IBBDocument.VIA.DOSSIERID Then
            ohelper.FillObject(Me, GetByDossierId(id))
        End If

    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM IBBDocuments where id = @id"
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

    Public Function GetByDossierId(ByVal Id As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM IBBDocuments where dossierid = @dossierid"
            Dim param() As Object = {"@dossierid", Id}
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
            'If LidId = 0 Then Throw New Exception("Het dossier heeft nog geen lidnummer")
            'If String.IsNullOrEmpty(DossierNr) Then Throw New Exception("Het dossier heeft nog geen dossiernummer")

            If Me.Id = Nothing Then
                CreateDate = Now
                CreatedBy = URights.UserName
                Id = da.InsertString(Me, "IBBDocuments", "Id", True)
                da.UpdateMutDateDossier(DossierId)
                Dim myHistory As New History
                myHistory.LidId = Me.DossierId
                myHistory.TableName = "IBBDocuments"
                myHistory.Veld = "document toegevoegd"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "Id:" & Me.Id & ":" & DocumentName
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                If da.isChanged(Me, "IBBDocuments", "Id", Me.Id, Me.DossierId) Then
                    da.UpdateString(Me, "IBBDocuments", "Id")
                    da.UpdateMutDateDossier(DossierId)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove(Optional InclFile As Boolean = False)
        Try

            If InclFile Then
                Dim fi As FileInfo = New FileInfo(Me.Location)
                If fi.Exists Then
                    fi.IsReadOnly = False
                    fi.Delete()
                End If
                If Me.BerichtenId > 0 Then
                    Dim bericht As Berichten = New Berichten(BerichtenId)
                    If bericht.Found Then bericht.Remove()
                End If
            End If

            Dim param() As Object = {"@id", Id}
            Dim sql As String = "DELETE FROM IBBDocuments WHERE Id = @id"
            da.ExecuteScalar(sql, param)

            Dim myHistory As New History
            myHistory.LidId = Me.DossierId
            myHistory.TableName = "IBBDocuments"
            myHistory.Veld = "document verwijderd"
            myHistory.WaardeOud = "Id:" & Me.Id & ":" & DocumentName
            myHistory.WaardeNieuw = ""
            myHistory.MutDate = Now
            myHistory.MutDoor = URights.UserName
            myHistory.Save()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private _Fase As IBBFase
    'Public ReadOnly Property Fase() As IBBFase
    '    Get
    '        If _Fase Is Nothing Then
    '            _Fase = New IBBFase(Me.jdTypeId, IBBFase.Via.ID)
    '        End If
    '        Return _Fase
    '    End Get
    'End Property
    Private _Fase As FaseTypes
    Public ReadOnly Property Fase() As FaseTypes
        Get
            If _Fase Is Nothing Then
                _Fase = New FaseTypes(Me.jdTypeId)
            End If
            Return _Fase
        End Get
    End Property
    Private _DocumentName As String
    Public ReadOnly Property DocumentName() As String
        Get
            If String.IsNullOrEmpty(_DocumentName) Then
                Dim iStart As Integer = Location.LastIndexOf("\") + 1
                Dim iEnd As Integer = Location.Length - iStart
                _DocumentName = Location.Substring(iStart, iEnd)
            End If
            Return _DocumentName
        End Get
    End Property
    Private _Bericht As Berichten
    Public ReadOnly Property Bericht() As Berichten
        Get
            If _Bericht Is Nothing Then
                _Bericht = New Berichten(BerichtenId)
            End If
            Return _Bericht
        End Get
    End Property
    Private _EmailId As String = String.Empty
    Public Property EmailId() As String
        Get
            Return _EmailId
        End Get
        Set(ByVal value As String)
            _EmailId = value
        End Set
    End Property
    Private _EmailFolderId As String = String.Empty
    Public Property EmailFolderId() As String
        Get
            Return _EmailFolderId
        End Get
        Set(ByVal value As String)
            _EmailFolderId = value
        End Set
    End Property
End Class

