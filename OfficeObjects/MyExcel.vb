Imports Excel = Microsoft.Office.Interop.Excel

Public Class MyExcel
    Private _MyDocuments As String = ""
    Public ReadOnly Property MyDocuments() As String
        Get
            If String.IsNullOrEmpty(_MyDocuments) Then
                _MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            Return _MyDocuments
        End Get
    End Property

    Public Sub ExcelWrite(ByVal myfile As String, ByVal dt As DataTable, includeHeaders As Boolean)

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer = 1
        Dim j As Integer = 0

        Dim FilePath As String
        Dim FileName As String
        Dim FileNameNew As String

        Dim fi As New IO.FileInfo(myfile)
        FilePath = fi.DirectoryName 'MyDocuments

        Try
            If Not FilePath.EndsWith("\") Then FilePath = FilePath & "\"

            FileName = fi.Name.Replace(fi.Extension, "")
            FileNameNew = FilePath & FileName & fi.Extension

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets(1)
            xlApp.Visible = True

            If (includeHeaders) Then
                Dim icol As Int16 = 1
                For Each column As DataColumn In dt.Columns
                    xlWorkSheet.Cells(1, icol) = column.ColumnName
                    icol += 1
                Next
                'writer.WriteLine(String.Join(separator, headerValues.ToArray()))
            End If

            Dim iRow As Integer = 2
            For Each row As DataRow In dt.Rows
                For j = 0 To dt.Columns.Count - 1
                    If (TypeOf row.Item(j) Is DateTime) And Not String.IsNullOrEmpty(row.Item(j).ToString) Then
                        'aangepast. sinds excel 2016 blijkt de datum als mm-dd worden getoond.
                        xlWorkSheet.Cells(iRow, j + 1) = Convert.ToDateTime(row.Item(j)).GetDateTimeFormats(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                        ' xlWorkSheet.Cells(iRow, j + 1) = Format(row.Item(j), "dd-MM-yyyy")
                    Else
                        xlWorkSheet.Cells(iRow, j + 1) = row.Item(j).ToString()
                    End If

                Next
                iRow += 1
            Next

            xlWorkSheet.Columns.AutoFit()
            xlWorkSheet.SaveAs(FileNameNew)
            'xlWorkBook.Close()
            'xlApp.Quit()


        Catch ex As Exception
            Throw ex
        Finally
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        End Try




        'MsgBox("You can find the file " & FileNameNew)


    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Function Excelds(ByVal myfile As String) As DataSet
        'Dim MyConnection As System.Data.OleDb.OleDbConnection = Nothing
        Try
            Using MyConnection As New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & myfile & "';Extended Properties=Excel 8.0;")
                Using MyCommand As New System.Data.OleDb.OleDbDataAdapter("select * from  [" & GetSheetNames(myfile)(0) & "$]", MyConnection)
                    Using DtSet As New DataSet
                        MyCommand.TableMappings.Add("Table", "NewDataTableName")
                        MyCommand.Fill(DtSet, GetSheetNames(myfile)(0) & "$]")
                        'dtExcel = DtSet.Tables(0) 'get the DataTable from the DataSet
                        Return DtSet
                    End Using
                End Using
            End Using


            'Dim DtSet As System.Data.DataSet
            'Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            'MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & myfile & "';Extended Properties=Excel 12.0;")
            'MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from  [" & GetSheetNames(myfile)(0) & "$]", MyConnection)
            'DtSet = New System.Data.DataSet
            'MyCommand.Fill(DtSet, GetSheetNames(myfile)(0) & "$]")
            ''dt = DtSet.Tables(0)
            'MyConnection.Close()


        Catch ex As Exception
            Throw ex
        Finally
            'MyConnection.Close()
        End Try
    End Function
    Private Function GetSheetNames(ByVal path As String)

        Dim lst As New List(Of String)

        If IO.File.Exists(path) Then
            If IO.Path.GetExtension(path) = ".xls" Or IO.Path.GetExtension(path) = ".xlsx" Then

                Dim app As New Excel.Application
                Dim WB As Excel.Workbook

                Try
                    WB = app.Workbooks.Open(Filename:=path)
                    If WB IsNot Nothing Then
                        For Each ws As Excel.Worksheet In WB.Sheets
                            lst.Add(ws.Name)
                        Next
                        WB.Close()
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(WB)
                        WB = Nothing
                    End If

                Catch ex As Exception
                    Throw ex
                Finally
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
                    app = Nothing
                End Try

            End If
        End If

        Return lst

    End Function
End Class
