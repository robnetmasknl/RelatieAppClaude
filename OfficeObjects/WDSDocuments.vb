Imports System.Data
Imports System.Data.OleDb

Public Class WDSDocuments
    Private Shared conn As OleDbConnection
    Public Shared MyIndex As String = "NERTMDC01."
    Public Shared MyScope As String = "'file://NERTMDC01/documents'"

    Shared Sub New()
        Try
            conn = New OleDbConnection("Provider=Search.CollatorDSO;Extended Properties='Application=Windows';")
            conn.Open()
        Catch
            conn = Nothing
        End Try
    End Sub
    Private Shared _FoundDocuments As DataTable
    Public Shared ReadOnly Property FoundDocuments() As DataTable
        Get
            If _FoundDocuments Is Nothing Then
                _FoundDocuments = New DataTable
                _FoundDocuments.TableName = "Documents"
                _FoundDocuments.Columns.Add("name", Type.GetType("System.String"))
                _FoundDocuments.Columns.Add("location", Type.GetType("System.String"))
                _FoundDocuments.Columns.Add("datum", Type.GetType("System.DateTime"))
            End If
            Return _FoundDocuments
        End Get
    End Property

    ''' <summary>
    ''' Indicates if WDS 3.0 is installed based on initial connection succeeding or not
    ''' </summary>
    Public Shared ReadOnly Property IsDesktopSearchInstalled() As Boolean
        Get
            Return (Not conn Is Nothing)
        End Get
    End Property


    Public Shared Function PerformSearch(ByVal data As String) As DataTable
        If MyIndex = "." Then
            MyIndex = String.Empty
        ElseIf MyScope.Contains(":\") Then
            'MyIndex = String.Empty
        End If


        Dim query As String = String.Format("SELECT System.ItemNameDisplay,""System.ItemPathDisplay"",""System.DateCreated"" FROM {1}systemindex WHERE (scope={2}) AND CONTAINS('""*{0}*""')", data, MyIndex, MyScope)
        Dim cmd As OleDbCommand = New OleDbCommand
        cmd.Connection = conn
        cmd.CommandText = query

        Dim results As OleDbDataReader = cmd.ExecuteReader
        FoundDocuments.Clear()

        Dim newRow As DataRow

        While results.Read
            newRow = FoundDocuments.NewRow
            newRow.Item("name") = results.GetString(0)
            newRow.Item("location") = results.GetString(1)
            newRow.Item("datum") = System.DateTime.Parse(results(2)).ToLocalTime
            FoundDocuments.Rows.Add(newRow)
        End While

        results.Close()

        Return FoundDocuments
    End Function
    '''' <summary>
    '''' Returns values from the search index for the given filename based on the supplied list of columns/properties
    '''' </summary>
    '''' <param name="columns">Comma-separated list of columns/properties (http://msdn2.microsoft.com/en-us/library/ms788673.aspx)</param>
    '''' <param name="filename">Filename about which to retrieve data</param>
    '''' <returns>Key/value pairs for all requested columns/properties</returns>
    '''' <remarks></remarks>
    'Public Shared Function ObtainProperties(ByVal columns As String, ByVal filename As String) As Dictionary(Of String, String)
    '    Dim items As Dictionary(Of String, String) = New Dictionary(Of String, String)

    '    ' The search provider does not support SQL parameters
    '    filename = filename.Replace("'", "''")

    '    Dim GENERAL_COLUMNS As String = """System.Kind"", ""System.Title"", ""System.ItemUrl"", ""System.ItemPathDisplay"", ""System.DateCreated"", ""System.Author"", ""System.Keywords"""
    '    columns = GENERAL_COLUMNS

    '    Dim cmd As OleDbCommand = New OleDbCommand
    '    cmd.Connection = conn
    '    cmd.CommandText = String.Format("SELECT {0} from systemindex WHERE System.ItemNameDisplay = '{1}'", columns, filename)

    '    Dim results As OleDbDataReader = cmd.ExecuteReader
    '    Dim value As String
    '    Dim key As String

    '    If results.Read Then
    '        Dim i As Integer = 0
    '        Do While (i < results.FieldCount)
    '            If Not results.IsDBNull(i) Then
    '                key = results.GetName(i)
    '                If (TypeOf (results.GetValue(i)) Is String()) Then
    '                    Dim arrayValue() As String = CType(results.GetValue(i), String())
    '                    If (arrayValue.GetLength(0) = 1) Then
    '                        value = arrayValue(0)
    '                    Else
    '                        value = String.Join(", ", arrayValue)
    '                    End If
    '                Else
    '                    value = results.GetValue(i).ToString
    '                End If
    '                If key.StartsWith("System.") Then
    '                    key = key.Substring(7)
    '                End If
    '                items.Add(key, value)
    '            End If
    '            i = (i + 1)
    '        Loop
    '    End If

    '    results.Close()

    '    Return items
    'End Function
End Class
