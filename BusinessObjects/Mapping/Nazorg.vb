Public Class Nazorg
    Inherits tblNazorg
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    Enum Via
        ID
        LIDID
    End Enum

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Integer, ByVal Via As Via)

        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LIDID" Then
            ohelper.FillObject(Me, GetByLidNr(id))
        End If

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
            Dim sql As String = "SELECT * FROM nazorg where id = @id"
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
    Public Function GetByLidNr(ByVal lidid As Integer) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM nazorg where lidid = @lidid"
            Dim param() As Object = {"@lidid", lidid}
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
            If Uitvaart = 0 Then
                UitvaartAdres1 = ""
                UitvaartAdres2 = ""
                UitvaartAdres3 = ""
                UitvaartAdres4 = ""
            End If

            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "Nazorg", "Id", True)
                Dim myHistory As New History
                myHistory.LidId = Lidid
                myHistory.TableName = "Nazorg"
                myHistory.Veld = "Nieuw Nazorg"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "lidid:" & Lidid
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                If da.isChanged(Me, "Nazorg", "Id", Id, Lidid) Then
                    da.UpdateString(Me, "Nazorg", "Id")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
