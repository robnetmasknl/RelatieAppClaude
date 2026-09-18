Public Class IpBlocker
    Inherits tblIpBlocker
    Enum Via
        ID
        IP
        NAAM
        LIDNR
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal GetBy As Via)

        Dim ohelper As New Helper
        If GetBy = Via.ID Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf GetBy = Via.IP Then
            ohelper.FillObject(Me, GetByIPInTime(id))
            'ElseIf GetBy = Via.NAAM Then
            '    ohelper.FillObject(Me, GetByNAAM(id))
        End If

    End Sub
    Private _TimeBetweenFailures As Integer = -1
    Public ReadOnly Property TimeBetweenFailures() As Integer
        Get
            If _TimeBetweenFailures = -1 Then
                Dim sys As New Systeeminstellingen("TimeBetweenFailures", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _TimeBetweenFailures = CInt(sys.Waarde)
            End If
            Return _TimeBetweenFailures
        End Get
    End Property
    Private _AttemptsFailures As Integer = -1
    Public ReadOnly Property AttemptsFailures() As Integer
        Get
            If _AttemptsFailures = -1 Then
                Dim sys As New Systeeminstellingen("AttemptsFailures", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _AttemptsFailures = CInt(sys.Waarde)
            End If

            Return _AttemptsFailures
        End Get
    End Property

    Public Function GetById(ByVal id As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim da As New DataAccess

            Dim sql As String = "SELECT * FROM IpBlocker where RequestGUID = @RequestGUID"
            Dim param() As Object = {"@RequestGUID", New Guid(CType(id, String))}
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
    Public Function GetByIPInTime(ByVal ip As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            ' Dim sysMin As New Systeeminstellingen("TimeBetweenFailures", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            Dim iMin As Integer = TimeBetweenFailures
            iMin = iMin * -1

            Dim da As New DataAccess
            Dim sql As String = "SELECT * FROM IpBlocker where IPADDRESS = @IPADDRESS AND (TimeStamp >= @TimeStampBegin AND TimeStamp <= @TimeStampEnd)"
            Dim TimeStampBegin As DateTime = DateAdd(DateInterval.Minute, iMin, Now)
            Dim TimeStampEnd As DateTime = Now

            Dim param() As Object = {"@IPADDRESS", ip, "@TimeStampBegin", TimeStampBegin, "@TimeStampEnd", TimeStampEnd}
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
    Public Function GetByIP(ByVal ip As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim da As New DataAccess

            Dim sql As String = "SELECT * FROM IpBlocker where IPADDRESS = @IPADDRESS"
            Dim param() As Object = {"@IPADDRESS", ip}
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
            Dim da As New DataAccess

            If Me.Id = 0 Then
                Me.RequestGUID = Guid.NewGuid
                Id = da.InsertString(Me, "IpBlocker", "Id", True)
            Else
                da.UpdateString(Me, "IpBlocker", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "IpBlocker")
        Catch ex As Exception
            Throw ex
        End Try
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
    Public Function ToManyAttemps() As Boolean
        Try
            If Found Then
                If Attempts >= AttemptsFailures Then
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
