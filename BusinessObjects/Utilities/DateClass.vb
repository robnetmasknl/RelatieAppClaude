Public Class DateClass

    Public Sub New(ByVal OriginalDate As String, ByVal OriginalDateFormat As String)
        Try
            Dim _date As New Date
            If Not OriginalDate Is Nothing Then
                _date = Date.ParseExact(OriginalDate, "yyyy-M-d", Nothing)
                Jaar = _date.Year
                Maand = _date.Month
                Dag = _date.Day
            End If

            Select Case OriginalDateFormat
                Case "yyyymmdd"

            End Select


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Enum FormatType
        ddmmyyyy
        yyyymmdd
    End Enum


    Public Function FormatDate(ByVal _Format As FormatType) As String
        Try

            If Dag = "" Or Maand = "" Then Return ""

            Dim result As String = ""
            Select Case _Format
                Case FormatType.ddmmyyyy
                    result = (Dag & "/" & Maand & "/" & Jaar)
                Case FormatType.yyyymmdd
                    result = (Jaar & "/" & Maand & "/" & Dag)
            End Select

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub Split(ByVal value As String)
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private _Dag As String = ""
    Public Property Dag() As String
        Get
            If _Dag = "" Then
                Return _Dag
            Else
                Return _Dag.PadLeft(2, "0")
            End If
        End Get
        Set(ByVal value As String)
            _Dag = value
        End Set
    End Property
    Private _Maand As String = ""
    Public Property Maand() As String
        Get
            If _Maand = "" Then
                Return _Maand
            Else
                Return _Maand.PadLeft(2, "0")
            End If

        End Get
        Set(ByVal value As String)
            _Maand = value
        End Set
    End Property
    Private _Jaar As String = ""
    Public Property Jaar() As String
        Get
            Return _Jaar
        End Get
        Set(ByVal value As String)
            _Jaar = value
        End Set
    End Property

End Class
