Imports System.IO
Imports System.Text

Public Class AddressFile
    Enum eType
        NONE
        TRIVIZIER
        XRCISE
    End Enum

    Private da As New DataAccess
    Public Event GenerateComplete(ByVal iCounter As Integer)
    Public Event GenerateExp(ByVal exp As Exception)
    Public Event GenerateStatus(ByVal Message As String)
    Public Event GenerateCounter(ByVal iCounter As Integer)

    Public SendType As eType
    Private iCounter As Integer = 0
    Private iTotalCounter As Integer = 0

    Private status As Integer = 0

    Public Function RS(ByVal value As String, ByVal len As Int16) As String
        Return value.PadRight(len, " ")
    End Function
    Public Function LS(ByVal value As String, ByVal len As Int16) As String
        Return value.PadLeft(len, " ")
    End Function
    Public Function RI(ByVal value As String, ByVal len As Int16) As String
        Return value.PadRight(len, "0")
    End Function
    Public Function LI(ByVal value As String, ByVal len As Int16) As String
        Return value.PadLeft(len, "0")
    End Function

    Private _LocationPath As String
    Public Property LocationPath() As String
        Get
            If Not _LocationPath.EndsWith("\") Then
                _LocationPath = _LocationPath & "\"
            End If
            Return _LocationPath
        End Get
        Set(ByVal value As String)
            'Als dir nog niet bestaat maak het dan
            Dim di As New IO.DirectoryInfo(value)
            If Not di.Exists Then di.Create()
            _LocationPath = value
        End Set
    End Property
    Private _TrivizierLeden As DataTable
    Public Property TrivizierLeden() As DataTable
        Get
            If _TrivizierLeden Is Nothing Then
                _TrivizierLeden = GetRelaties()
            End If
            Return _TrivizierLeden
        End Get
        Set(ByVal value As DataTable)
            _TrivizierLeden = value
        End Set
    End Property

    Private Function GetRelaties() As DataTable
        Try
            Dim dt As New DataTable
            Dim da As New DataAccess
            Dim paramDate As New ArrayList
            Dim Aantal_wat As String = ""
            paramDate.Add("@Status")
            paramDate.Add(status)

            If SendType = eType.TRIVIZIER Then
                Aantal_wat = "aantal_triv "
            ElseIf SendType = eType.XRCISE Then
                Aantal_wat = "aantal_xr "
            End If

            RaiseEvent GenerateStatus("Bezig met ophalen van leden")
            Dim sql As String = "SELECT id, lidnr, achternaam, init , tussenvoegsel, adres, huisnr, huisnrtv, postcode, ZipCode, plaats, land, " & Aantal_wat & " as aantal " & _
                    "FROM relaties " & _
                    "WHERE Status = @Status AND " & Aantal_wat
            dt = da.ExecuteDataTable(sql & " > 0", paramDate.ToArray)

            iTotalCounter = dt.Rows.Count
            RaiseEvent GenerateStatus(iTotalCounter & " leden gevonden")

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private sbTrivizierLeden As StringBuilder
    Public Sub Process()
        Try
            If SendType = eType.NONE Then
                RaiseEvent GenerateExp(New Exception("Er is nog geen keuze gemaakt tussen Trivizier of Xrcise!"))
                Exit Sub
            End If

            Dim NewLine As String = ""
            Dim FullName As String = ""
            Dim Address As String = ""
            Dim postcode As String = ""

            iCounter = 0
            sbTrivizierLeden = New StringBuilder
            For Each row As DataRow In TrivizierLeden.Rows
                RaiseEvent GenerateStatus("Bezig met verwerken ")
                NewLine = ""
                FullName = ""
                Address = ""

                If Not row.Item("init").ToString.Trim = "" Then FullName &= row.Item("init")
                If Not row.Item("tussenvoegsel").ToString.Trim = "" Then FullName &= " " & row.Item("tussenvoegsel")
                If Not row.Item("achternaam").ToString.Trim = "" Then FullName &= " " & row.Item("achternaam")

                Address = row.Item("adres")
                If Not row.Item("huisnr").ToString.Trim = "" And Not row.Item("huisnr").ToString.Trim = "0" Then Address &= " " & row.Item("huisnr")
                If Not row.Item("huisnrtv").ToString.Trim = "" And Not row.Item("huisnrtv").ToString.Trim = "0" Then Address &= " " & row.Item("huisnrtv")

                PostCode = ""
                If row.Item("postcode").ToString.Trim = "" Then postcode = row.Item("ZipCode").ToString.Trim
                If row.Item("land").ToString.Trim = "" Then postcode = row.Item("postcode").ToString.Trim

                'BMO:2020-11-10 Bug ID: 1614 'lidmaatschapnummer niet langer meesturen, wel de commasep.
                'NewLine &= row.Item("lidnr") & ";"
                NewLine &= ";"
                NewLine &= FullName.Trim & ";"
                NewLine &= Address.Trim & ";"
                'NewLine &= row.Item("postcode") & ";"
                NewLine &= postcode & ";"
                NewLine &= row.Item("plaats") & ";"
                'If row.Item("postcode").ToString.Trim = "" Then
                NewLine &= row.Item("land") & ";"
                'End If

                Dim iAantal As Integer = row.Item("Aantal")
                For i As Integer = 0 To iAantal - 1
                    sbTrivizierLeden.Append(NewLine & vbCrLf)
                    iCounter += 1
                Next
                RaiseEvent GenerateStatus("Bezig met verwerken " & FullName)
            Next

            Dim fileName As String = LocationPath & SendType.ToString & ".txt"
            WriteFile(fileName, sbTrivizierLeden.ToString, False)
            System.Diagnostics.Process.Start(fileName)

            RaiseEvent GenerateStatus(fileName & " is klaar!")
            RaiseEvent GenerateComplete(iCounter)

        Catch ex As Exception
            RaiseEvent GenerateExp(ex)
        End Try
    End Sub

End Class
