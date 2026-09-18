Public Class DeclaratiePeriodes
    Inherits tblDeclaratiePeriodes
    Private da As New DataAccess

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetById(id))
    End Sub
    Public Sub New(ByVal LidId As Int32, ByVal PerMonth As Integer, ByVal PerYear As Integer)
        Dim ohelper As New Helper
        ohelper.FillObject(Me, GetByPer(LidId, PerMonth, PerYear))
    End Sub
    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM DeclaratiePeriodes where id = @id"
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
    Public Function GetByPer(ByVal LidId As Int32, ByVal PerMonth As Integer, ByVal PerYear As Integer) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM DeclaratiePeriodes where LidId = @LidId And PeriodeMnd = @PeriodeMnd and PeriodeJaar = @PeriodeJaar"
            Dim param() As Object = {"@LidId", LidId, "@PeriodeMnd", PerMonth, "@PeriodeJaar", PerYear}
            oDr = da.ExecuteDataRow(sql, param)

            If Not oDr Is Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
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
                Id = da.InsertString(Me, "DeclaratiePeriodes", "Id", True)
            Else
                da.UpdateString(Me, "DeclaratiePeriodes", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "DeclaratiePeriodes")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetDeclarationTable() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String = "SELECT * FROM Declaraties where DeclPerId = @DeclPerId"
            Dim param() As Object = {"@DeclPerId", Id}
            dt = da.ExecuteDataTable(sql, param)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private _DeclarationList As List(Of Declaraties)
    Public ReadOnly Property DeclarationList() As List(Of Declaraties)
        Get
            If Id = 0 Then Throw New Exception("Er is nog geen periode opgegeven")

            If _DeclarationList Is Nothing Then
                _DeclarationList = New List(Of Declaraties)
                Dim _declaratie As New Declaraties
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM Declaraties where DeclPerId = @DeclPerId"
                Dim param() As Object = {"@DeclPerId", Id}
                _DeclarationList = ohelper.MapDataTableToList(Of Declaraties)(da.ExecuteDataTable(sql, param))
            End If


            Return _DeclarationList
        End Get
    End Property
    Public Function TotalHours() As Decimal
        Try
            Dim result As Decimal = 0.0
            For Each decl As Declaraties In DeclarationList
                result += decl.Uren
            Next
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TotalAmountHours() As Decimal
        Try
            Dim result As Decimal = 0.0
            result = Math.Round((TotalHours() * PeriodAmounts.AmountHour), 2)
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TotalKm() As Decimal
        Try
            Dim result As Decimal = 0.0
            For Each decl As Declaraties In DeclarationList
                result += decl.Kilometers
            Next
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TotalAmountKm() As Decimal
        Try
            Dim result As Decimal = 0.0
            result = Math.Round((TotalKm() * PeriodAmounts.AmountKm), 2)
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TotalExpense() As Decimal
        Try
            Dim result As Decimal = 0.0
            For Each decl As Declaraties In DeclarationList
                result += decl.Onkosten
            Next
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TotalPublicTransport() As Decimal
        Try
            Dim result As Decimal = 0.0
            For Each decl As Declaraties In DeclarationList
                result += decl.OnkOV
            Next
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TotalMeals() As Decimal
        Try
            Dim result As Decimal = 0.0
            For Each decl As Declaraties In DeclarationList
                result += decl.Maaltijden
            Next
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodTotalNetto() As Decimal
        Try
            Dim result As Decimal = 0.0
            result = TotalPublicTransport() + TotalExpense() + TotalAmountKm() + TotalMeals()
            Return Math.Round(result, 2)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodTotalBruto() As Decimal
        Try
            Dim result As Decimal = 0.0
            result = TotalAmountHours()
            Return Math.Round(result, 2)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodTotalCompensation() As Decimal
        Try
            Dim result As Decimal = 0.0
            result = TotalAmountHours() + PeriodTotalNetto()
            Return Math.Round(result, 2)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PeriodName() As String
        Try
            Dim strDate As New DateTime(1, PeriodeMnd, 1)
            Dim result As String = strDate.ToString("MMMM")
            result &= " " & PeriodeJaar
            Return result
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private _Relatie As Relaties
    Public ReadOnly Property Relatie() As Relaties
        Get
            If _Relatie Is Nothing Then
                _Relatie = New Relaties(Me.LidId, Relaties.Via.ID)
            End If

            Return _Relatie
        End Get
    End Property

    Private _PeriodAmounts As DeclaratieSettings
    Public ReadOnly Property PeriodAmounts() As DeclaratieSettings
        Get
            If _PeriodAmounts Is Nothing Then
                Dim CurrentPeriod As New Date(PeriodeJaar, PeriodeMnd, "1")
                _PeriodAmounts = New DeclaratieSettings(CurrentPeriod)
            End If
            Return _PeriodAmounts
        End Get
    End Property
    'Public Function UsedPromoMaterial() As List(Of String)
    '    Try
    '        Dim result As New List(Of String)
    '        For Each decl As Declaraties In DeclarationList
    '            If Not String.IsNullOrEmpty(decl.Promomateriaal) Then
    '                result.Add(decl.Promomateriaal)
    '            End If

    '        Next
    '        Return result

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
End Class
