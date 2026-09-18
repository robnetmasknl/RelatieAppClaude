Public Class LidSoortPeriode
    Inherits tblLidsoortperioden
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance
    Private ContributieDate As Date = Date.MinValue

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
            Dim sql As String = "SELECT * FROM Lidsoortperioden where id = @id"
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
            Dim sql As String = "SELECT * FROM Lidsoortperioden where lidid = @lidid"
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
            Dim sql As String = "SELECT TOP 1 * FROM Lidsoortperioden where (lidid = @lidid AND datumin <= @DateIn) ORDER BY datumin DESC"
            Dim param() As Object = {"@lidid", id.ToString, "@DateIn", DateIn}
            oDr = da.ExecuteDataRow(sql, param)
            ContributieDate = DateIn
            If oDr IsNot Nothing Then
                Found = True
            Else
                Found = False
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
                Id = da.InsertString(Me, "Lidsoortperioden", "Id", True)
                Dim myHistory As New History
                myHistory.LidId = lidid
                myHistory.TableName = "Lidsoortperioden"
                myHistory.Veld = myLidSoort.omschrijving
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "per:" & datumin
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else

                If da.isChanged(Me, "Lidsoortperioden", "Id", Me.Id, Me.lidid) Then
                    da.UpdateString(Me, "Lidsoortperioden", "Id")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            'Dim da As New DataAccess
            da.DeleteString(Me, "Lidsoortperioden")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _myLidSoort As LidSoort = Nothing
    Public Property myLidSoort() As LidSoort
        Get
            If _myLidSoort Is Nothing Then
                _myLidSoort = New LidSoort(lidsoortid)
            End If
            Return _myLidSoort
        End Get
        Set(ByVal value As LidSoort)
            _myLidSoort = value
        End Set
    End Property

    Private _myContributie As Contributie = Nothing
    Public Property myContributie() As Contributie
        Get
            If _myContributie Is Nothing Then
                'TODO uitzoeken Contributiedatum. 
                'het nam (tot 04-01-2012)de periode datum mee en moet een specifieke datum hebben.
                If ContributieDate = Date.MinValue Then
                    ContributieDate = Today
                End If
                _myContributie = New Contributie(myLidSoort.Id, ContributieDate)

                '_myContributie = New Contributie(myLidSoort.Id, datumin)


            End If
            Return _myContributie
        End Get
        Set(ByVal value As Contributie)
            _myContributie = value
        End Set
    End Property
End Class
