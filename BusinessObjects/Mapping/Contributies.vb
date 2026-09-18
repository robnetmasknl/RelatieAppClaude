
Public Class Contributies
    Inherits tblcontributies

    Private da As New DataAccess

    Enum Via
        ID
        RELATIEID
    End Enum

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "RELATIEID" Then
            ohelper.FillObject(Me, GetByRELATIEID(id))
        End If
    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via, ByVal contributieJaar As Integer)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "RELATIEID" Then
            ohelper.FillObject(Me, GetByRELATIEID_JAAR(id, contributieJaar))
        End If
    End Sub
    Public Function GetByRELATIEID_JAAR(ByVal _lidid As String, ByVal contributieJaar As Integer) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM contributies where lidid = @lidid AND jaar = @jaar"
            Dim param() As Object = {"@lidid", _lidid, "@jaar", contributieJaar}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                'Dim ohelper As New Helper
                'ohelper.FillObject(Me, oDr)
                Found = True
            Else
                'dan er 1tje maken
                Me.lidid = _lidid
                Me.jaar = contributieJaar
                Me.Save()
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM contributies where id = @id"
            Dim param() As Object = {"@id", GetId}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                'Dim ohelper As New Helper
                'ohelper.FillObject(Me, oDr)
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetByRELATIEID(ByVal lidid As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM contributies where lidid = @lidid"
            Dim param() As Object = {"@lidid", lidid}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                'Dim ohelper As New Helper
                'ohelper.FillObject(Me, oDr)
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
            If lidid = 0 Then Exit Sub

            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "contributies", "Id", True)
            Else

                If da.isChanged(Me, "contributies", "Id", Me.Id, Me.lidid) Then
                    'Me.mutatiedatum = Now
                    da.UpdateString(Me, "contributies", "Id")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public ReadOnly Property GetPaymentOfMonth(ByVal paymentMonth As eMaand) As Decimal
        Get
            Dim properties() As Reflection.PropertyInfo = Me.GetType().GetProperties()
            If (properties.Length > 0) Then
                For Each propertyObject As Reflection.PropertyInfo In properties
                    If propertyObject.Name = paymentMonth.ToString Then
                        Return propertyObject.GetValue(Me, Nothing)
                    End If
                Next
            End If
            Return 0
        End Get
    End Property

    Public Sub AddPayment(ByVal amount As Decimal, ByVal paymentMonth As eMaand)
        Try
            Dim properties() As Reflection.PropertyInfo = Me.GetType().GetProperties()
            If (properties.Length > 0) Then
                For Each propertyObject As Reflection.PropertyInfo In properties
                    If propertyObject.Name = paymentMonth.ToString Then
                        propertyObject.SetValue(Me, CType(amount, Decimal) + propertyObject.GetValue(Me, Nothing), Nothing)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ReplacePayment(ByVal amount As Decimal, ByVal paymentMonth As eMaand)
        Try
            Dim properties() As Reflection.PropertyInfo = Me.GetType().GetProperties()
            If (properties.Length > 0) Then
                For Each propertyObject As Reflection.PropertyInfo In properties
                    If propertyObject.Name = paymentMonth.ToString Then
                        propertyObject.SetValue(Me, CType(amount, Double) + 0, Nothing)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' Verminderd het betaalde contributie bedrag 
    ''' met het opgegeven bedrag van de opgegeven maand.
    ''' </summary>
    ''' <param name="amount"></param>
    ''' <param name="paymentMonth"></param>
    ''' <remarks></remarks>
    Public Sub SubtractPayment(ByVal amount As Decimal, ByVal paymentMonth As eMaand)
        Try
            Dim properties() As Reflection.PropertyInfo = Me.GetType().GetProperties()
            If (properties.Length > 0) Then
                For Each propertyObject As Reflection.PropertyInfo In properties
                    If propertyObject.Name = paymentMonth.ToString Then
                        propertyObject.SetValue(Me, propertyObject.GetValue(Me, Nothing) - CType(amount, Decimal), Nothing)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary></summary>
    ''' <param name="UntilMonth"></param>
    ''' <returns>
    ''' Het totale ingehouden contributie bedrag t/m opgegeven maand
    ''' </returns>
    ''' <remarks></remarks>
    Public Function TotalPaid(ByVal UntilMonth As Integer)
        Try
            Dim result As Decimal
            Dim properties() As Reflection.PropertyInfo = Me.GetType().GetProperties()
            If (properties.Length > 0) Then
                For i = 0 To UntilMonth
                    For Each propertyObject As Reflection.PropertyInfo In properties
                        If propertyObject.Name = CType(i, eMaand).ToString Then
                            result += propertyObject.GetValue(Me, Nothing)
                        End If
                    Next
                Next
            End If

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary></summary>
    ''' <param name="UntilMonth"></param>
    ''' <returns>
    ''' Het totale verwachte contributie bedrag t/m opgegeven maand
    ''' </returns>
    ''' <remarks></remarks>
    Public Function AmountDue(ByVal UntilMonth As Integer)
        Try
            Dim result As Decimal = 0
            Dim relatie As New Relaties(lidid, Relaties.Via.ID)
            For i = 1 To UntilMonth
                result += relatie.SelectedPeriode(New Date(jaar, i, "01")).myContributie.mbedrag
            Next

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary></summary>
    ''' <param name="ContributieMonth"></param>
    ''' <returns>
    ''' Het verwachte contributie bedrag van de opgegeven maand
    ''' </returns>
    ''' <remarks></remarks>
    Public Function ContributieAmount(ByVal ContributieMonth As Integer)
        Try
            Dim result As Decimal = 0
            Dim relatie As New Relaties(lidid, Relaties.Via.ID)
            If Not relatie.Found Then
                Throw New Exception("Relatie voor contributie amount niet kunnen vinden!")
            End If

            Dim periode As New LidSoortPeriode
            periode = relatie.SelectedPeriode(New Date(jaar, ContributieMonth, "01"))
            result += periode.myContributie.mbedrag
            Contributie_mDiscount = periode.myContributie.mkorting
            Contributie_oDiscount = periode.myContributie.okorting

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Contributie_mDiscount As Integer = 0
    Public Contributie_oDiscount As Integer = 0

    Public Sub Remove()
        Try
            'Dim da As New DataAccess
            da.DeleteString(Me, "Lid_contributie")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Class Amounts
    '    Public Sub New(ByVal ContributieMonth As Integer, ByVal lidid As Integer, ByVal jaar As String)
    '        Dim result As Decimal = 0
    '        Dim relatie As New Relaties(lidid, Relaties.Via.ID)
    '        Dim periode As New LidSoortPeriode
    '        Try
    '            periode = relatie.SelectedPeriode(New Date(jaar, ContributieMonth, "01"))
    '            result += periode.myContributie.mbedrag
    '            _MonthDiscount = periode.myContributie.mkorting
    '            _MonthAmount = result

    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub

    '    Private _MonthAmount As Integer = 0
    '    Public ReadOnly Property MonthAmount() As Integer
    '        Get
    '            Return _MonthAmount
    '        End Get
    '    End Property
    '    Private _MonthDiscount As Integer = 0
    '    Public ReadOnly Property MonthDiscount() As Integer
    '        Get
    '            Return _MonthDiscount
    '        End Get
    '    End Property
    'End Class
End Class


