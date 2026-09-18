Public Class SmsMessage
    Inherits tblSmsMessages

    Enum Via
        ID
        BOEKINGID
    End Enum

    Private da As New DataAccess
    Private _Found As Boolean = False

    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)

        Dim ohelper As New Helper

        Select Case Via
            Case SmsMessage.Via.ID
                ohelper.FillObject(Me, GetById(id))
            Case SmsMessage.Via.BOEKINGID
                ohelper.FillObject(Me, GetByBoekingId(id))
            Case Else
                'doe nix
        End Select

    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM SmsMessages where id = @id"
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
    Public Function GetByBoekingId(ByVal BoekingId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM SmsMessages where BoekingId = @BoekingId"
            Dim param() As Object = {"@BoekingId", BoekingId}
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

    Public Sub ValidateMobileNumber(ByVal number As String)
        'mobile nummer controleren
        '- + vervangen door 00
        '- alleen nummers (geen (),-,+ enz)
        Dim MobileNumber As String = number
         If MobileNumber.StartsWith("+") Then MobileNumber = MobileNumber.Replace("+", "00")
        If MobileNumber.Contains("-") Then MobileNumber = MobileNumber.Replace("-", "")
        If MobileNumber.Contains("(0") Then
            MobileNumber = MobileNumber.Replace("(0", "")
            MobileNumber = MobileNumber.Replace(")", "")
        End If

        Mobile = MobileNumber

    End Sub

    Public Sub Save()
        Try
            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "SmsMessages", "Id", True)
            Else
                If da.isChanged(Me, "SmsMessages", "Id", Me.Id, Me.LidId) Then
                    da.UpdateString(Me, "SmsMessages", "Id")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Remove()
        Try
            da.DeleteString(Me, "SmsMessages")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
