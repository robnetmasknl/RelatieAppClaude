Imports BusinessObjects

Public Class LoginDecl


    Public Function Login(ByVal lidnr As String, ByVal password As String) As Int32
        Try
            Dim dt As New DataTable
            Dim da As New DataAccess
            Dim sql As String = "SELECT R.Id, R.lidnr,R.wachtwoord FROM Relaties R " & _
                                "inner join Functies F on R.Id = F.lidid  " & _
                                "inner join fsoort S on F.functie = S.id " & _
                                "WHERE(F.functie = 7) " & _
                                "and R.lidnr = @lidnr " & _
                                "and R.wachtwoord = @password"

            Dim param() As Object = {"@lidnr", lidnr, "@password", password}
            dt = da.ExecuteDataTable(sql, param)

            For Each row As DataRow In dt.Rows
                If row.Item("lidnr") = lidnr And row.Item("wachtwoord") = password Then
                    Return row.Item("Id")
                End If
            Next

            Return -1

        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function LoginManager(ByVal lidnr As String, ByVal password As String) As Int32
        Try
            Dim dt As New DataTable
            Dim da As New DataAccess
            Dim sql As String = "SELECT R.Id, R.lidnr,R.wachtwoord FROM Relaties R " & _
                                "inner join Functies F on R.Id = F.lidid  " & _
                                "inner join fsoort S on F.functie = S.id " & _
                                "WHERE(F.functie = 19) " & _
                                "and R.lidnr = @lidnr " & _
                                "and R.wachtwoord = @password"

            Dim param() As Object = {"@lidnr", lidnr, "@password", password}
            dt = da.ExecuteDataTable(sql, param)

            For Each row As DataRow In dt.Rows
                If row.Item("lidnr") = lidnr And row.Item("wachtwoord") = password Then
                    Return row.Item("Id")
                End If
            Next

            Return -1

        Catch ex As Exception
            Return -1
        End Try
    End Function
    Private _PeriodsByRecruiter As DataTable
    Public ReadOnly Property PeriodsByRecruiter(ByVal id As Integer) As DataTable
        Get
            Dim da As New DataAccess
            Dim sql As String = "SELECT * FROM DeclaratiePeriodes " &
                                "WHERE LidId = @lidid " &
                                "Order by PeriodeJaar DESC, PeriodeMnd DESC"
            Dim param() As Object = {"@lidid", id}
            _PeriodsByRecruiter = da.ExecuteDataTable(sql, param)

            Dim col As New DataColumn
            col.ColumnName = "TotalDeclarations"
            _PeriodsByRecruiter.Columns.Add(col)

            For Each row As DataRow In _PeriodsByRecruiter.Rows
                Dim decl As DeclaratiePeriodes
                decl = New DeclaratiePeriodes(row.Item("id"))
                row.Item("TotalDeclarations") = decl.GetDeclarationTable.Rows.Count
            Next


            Return _PeriodsByRecruiter
        End Get
    End Property
    'Private _PeriodeListByRecruiter As List(Of DeclaratiePeriodes)
    'Public Property PeriodeListByRecruiter() As List(Of DeclaratiePeriodes)
    '    Get
    '        Return _PeriodeListByRecruiter
    '    End Get
    '    Set(ByVal value As List(Of DeclaratiePeriodes))
    '        _PeriodeListByRecruiter = value
    '    End Set
    'End Property

    Private _Recruiters As DataTable
    Public ReadOnly Property Recruiters(Optional ByVal iDays As Integer = 0) As DataTable
        Get
            If _Recruiters Is Nothing Then
                Dim da As New DataAccess
                Dim EndFunctionDate As Date = New DateTime(Now.Year, Now.Month, Now.Day).AddDays((iDays))

                Dim sql As String = "SELECT R.Id, R.lidnr,R.Init,R.achternaam FROM Relaties R " &
                                    "inner join Functies F on R.Id = F.lidid  " &
                                    "inner join fsoort S on F.functie = S.id " &
                                    "WHERE(F.functie = 7) And (f.datumuit Is NULL Or f.datumuit >= @EndDate)" &
                                    "and R.wachtwoord is not null"

                Dim param() As Object = {"@EndDate", EndFunctionDate}
                _Recruiters = da.ExecuteDataTable(sql, param)
            End If

            Return _Recruiters
        End Get
    End Property

End Class
