Imports System.IO

Public Class Documents
    Inherits tblDocuments
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    Enum Via
        DocumentId
        BerichtenId
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via)

        Dim ohelper As New Helper
        If Via.DocumentId Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.BerichtenId Then
            ohelper.FillObject(Me, GetByBerichtenId(id))
        End If

    End Sub
    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Documents where id = @id"
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

    Public Function GetByBerichtenId(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Documents where BerichtenId = @id"
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
    Public Sub Save()

        Try
            If Me.id = Nothing Then
                CreateDate = Now
                CreatedBy = URights.UserName
                id = da.InsertString(Me, "Documents", "id", True)
                Dim myHistory As New History
                myHistory.LidId = Me.LidId
                myHistory.TableName = "Documents"
                myHistory.Veld = "document toegevoegd"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "Id:" & Me.id & ":" & DocumentName
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                da.UpdateString(Me, "Documents", "id")
            End If



            'If Me.id = Nothing Then
            '    id = da.InsertString(Me, "Documents", "id", True)
            'Else
            '    da.UpdateString(Me, "Documents", "id")
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Public Sub Remove()
    '    Try
    '        Dim da As New DataAccess

    '        da.DeleteString(Me, "Documents")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
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


            Dim param() As Object = {"@id", id}
            Dim sql As String = "DELETE FROM Documents WHERE Id = @id"
            da.ExecuteScalar(sql, param)

            Dim myHistory As New History
            myHistory.LidId = LidId
            myHistory.TableName = "Documents"
            myHistory.Veld = "document verwijderd"
            myHistory.WaardeOud = "Id:" & Me.id & ":" & DocumentName
            myHistory.WaardeNieuw = ""
            myHistory.MutDate = Now
            myHistory.MutDoor = URights.UserName
            myHistory.Save()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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
End Class

<MapperTable("Documents", "Id")> _
Public Class tblDocuments
#Region "members"
    Private _id As Int32 = 0
    Private _Location As String = ""
    Private _RefID As String = ""
    Private _LidId As String = ""
    Private _Template As String = ""
    Private _CreateDate As DateTime
    Private _CreatedBy As String = ""
    Private _BerichtenId As Int32 = 0
#End Region

#Region "Properties"

    <MapperColumn("id")> _
    Public Property id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    <MapperColumn("Location")> _
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property
    <MapperColumn("RefID")> _
    Public Property RefID() As String
        Get
            Return _RefID
        End Get
        Set(ByVal value As String)
            _RefID = value
        End Set
    End Property
    <MapperColumn("LidId")> _
    Public Property LidId() As String
        Get
            Return _LidId
        End Get
        Set(ByVal value As String)
            _LidId = value
        End Set
    End Property
    <MapperColumn("Template")> _
    Public Property Template() As String
        Get
            Return _Template
        End Get
        Set(ByVal value As String)
            _Template = value
        End Set
    End Property
    <MapperColumn("CreateDate")> _
    Public Property CreateDate() As DateTime
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As DateTime)
            _CreateDate = value
        End Set
    End Property
    <MapperColumn("CreatedBy")> _
    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property
    <MapperColumn("BerichtenId")> _
    Public Property BerichtenId() As Int32
        Get
            Return _BerichtenId
        End Get
        Set(ByVal value As Int32)
            _BerichtenId = value
        End Set
    End Property
#End Region

End Class