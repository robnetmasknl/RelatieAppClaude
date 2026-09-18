Public Class LidFunctie
    Inherits tblFuncties

    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    Enum Via
        ID
        LIDID
    End Enum

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LIDID" Then
            ohelper.FillObject(Me, GetByLIDID(id))
        End If
    End Sub

    Public Sub New(ByVal id As String, ByVal DateIn As DateTime)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetByCurrent(id, DateIn))
    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Functies where id = @id"
            Dim param() As Object = {"@id", Id}
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
    Public Function GetByLIDID(ByVal lidid As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Functies where lidid = @lidid"
            Dim param() As Object = {"@lidid", lidid.ToString}
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
    Public Function GetByCurrent(ByVal id As Int32, ByVal DateIn As DateTime) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Found = False
            Dim sql As String = "SELECT TOP 1 * FROM Functies where (lidid = @lidid AND datumin >= @DateIn AND datumuit <= @DateIn ) ORDER BY datumin DESC"
            Dim param() As Object = {"@lidid", id.ToString, "@DateIn", DateIn}
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
            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "Functies", "Id", True)
                Dim myHistory As New History
                myHistory.LidId = lidid
                myHistory.TableName = "Functies"
                myHistory.Veld = myFunctieSoort.soort
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "per:" & datumin
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else

                If da.isChanged(Me, "Functies", "Id", Me.Id, Me.lidid) Then
                    da.UpdateString(Me, "Functies", "Id")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            Dim param() As Object = {"@id", Id}
            Dim sql As String = "DELETE FROM functies WHERE id = @id"
            da.ExecuteScalar(sql, param)

            Dim myHistory As New History
            myHistory.LidId = lidid
            myHistory.TableName = "Functies"
            myHistory.Veld = myFunctieSoort.soort
            myHistory.WaardeOud = "per:" & datumin
            myHistory.WaardeNieuw = "verwijderd"
            myHistory.MutDate = Now
            myHistory.MutDoor = URights.UserName
            myHistory.Save()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _AdviesNaam As String = ""
    Public ReadOnly Property AdviesNaam() As String
        Get
            Return _AdviesNaam
        End Get
    End Property
    Private _OrgaanNaam As String = ""
    Public ReadOnly Property OrgaanNaam() As String
        Get
            Return _OrgaanNaam
        End Get
    End Property
    Private _AfdelingNaam As String = ""
    Public ReadOnly Property AfdelingNaam() As String
        Get
            Return _AfdelingNaam
        End Get
    End Property
    Private Sub FillNames()
        Try
            Dim connection As New SqlClient.SqlConnection(da.MyConnectionString)
            connection.Open()
            Dim sql As String = ""
            Dim command As New SqlClient.SqlCommand
            command.Connection = connection

            sql = "SELECT omschrijving FROM afdelingen where id = " & afdeling
            command.CommandText = sql
            _AfdelingNaam = command.ExecuteScalar()

            sql = "SELECT naam FROM fadvies where id = " & adviesgroep
            command.CommandText = sql
            _AdviesNaam = command.ExecuteScalar()

            sql = "SELECT orgaan FROM forgaan where id = " & orgaan
            command.CommandText = sql
            _OrgaanNaam = command.ExecuteScalar()

            connection.Close()
            connection.Dispose()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private _myFunctieSoort As FunctieSoort
    Public Property myFunctieSoort() As FunctieSoort
        Get
            If _myFunctieSoort Is Nothing Then
                FillNames()
                _myFunctieSoort = New FunctieSoort(Me.functie)
            End If
            Return _myFunctieSoort
        End Get
        Set(ByVal value As FunctieSoort)
            _myFunctieSoort = value
        End Set
    End Property
    Public Function IsCurrent() As Boolean
        Try
     
            If String.IsNullOrEmpty(datumin) Then
                If String.IsNullOrEmpty(datumuit) Then
                    Return True
                Else
                    Return datumuit >= Today
                End If
            End If

            If datumin <= Today Then
                If String.IsNullOrEmpty(datumuit) Then
                    Return True
                ElseIf datumuit >= Today Then
                    Return True
                End If
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
