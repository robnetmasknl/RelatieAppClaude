Imports System.IO
Imports System.Runtime.InteropServices
Public Class dlgDragDrop

    Private OL As Microsoft.Office.Interop.Outlook.Application
    Private Sub dlgDragDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AllowDrop = True
        OL = New Microsoft.Office.Interop.Outlook.Application
    End Sub

    'Private Sub dlgDragDrop_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
    '    Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
    '    Dim filestype() As String

    '    filestype = e.Data.GetData(DataFormats.FileDrop)
    '    Dim sReader As New StreamReader(filestype(0))

    '    'get the filename from the file without the path
    '    Dim file_name As String = Path.GetFileName(filestype(0))

    '    'check the extension of the file
    '    If Path.GetExtension(filestype(0)).ToLower() = ".xml" Then
    '        'Read the xml file
    '        For Each path In files
    '            'ReadXMLFile(path)
    '        Next
    '    Else

    '        'warning about the file type
    '        MessageBox.Show("Only XML files are supported!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    'End Sub
    ''Private MouseIsDown As Boolean = False

    ''Private Sub TextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.DragDrop
    ''    ' Set a flag to show that the mouse is down.
    ''    MouseIsDown = True
    ''End Sub

    ''Private Sub TextBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseMove
    ''    If MouseIsDown Then
    ''        ' Initiate dragging.
    ''        TextBox1.DoDragDrop(TextBox1.Text, DragDropEffects.Copy)
    ''    End If
    ''    MouseIsDown = False
    ''End Sub

    Public Function GetOutlookAttachment(ByVal e As System.Windows.Forms.DragEventArgs, DataTypeName As String) As String

        Try
            Dim theStream As IO.Stream = DirectCast(e.Data.GetData(DataTypeName), IO.Stream)
            Dim fileGroupDescriptor As Byte() = New Byte(511) {}
            theStream.Read(fileGroupDescriptor, 0, 512)
            ' used to build the filename from the FileGroupDescriptor block 
            Dim fileName As New System.Text.StringBuilder("")
            ' this trick gets the filename of the passed attached file 
            Dim i As Integer = 76
            While fileGroupDescriptor(i) <> 0
                fileName.Append(Convert.ToChar(fileGroupDescriptor(i)))
                i += 1
            End While

            theStream.Close()

            Dim path As String = IO.Path.GetTempPath()
            ' put the zip file into the temp directory 
            Dim theFile As String = path + fileName.ToString()

            Dim ms As IO.MemoryStream = DirectCast(e.Data.GetData("FileContents", True), IO.MemoryStream)

            ' allocate enough bytes to hold the raw data 

            Dim fileBytes As Byte() = New Byte(CInt(ms.Length) - 1) {}
            ' set starting position at first byte and read in the raw data 
            ms.Position = 0
            ms.Read(fileBytes, 0, CInt(ms.Length))
            ' create a file and save the raw zip file to it 
            Dim fs As New IO.FileStream(theFile, IO.FileMode.Create)
            fs.Write(fileBytes, 0, CInt(fileBytes.Length))
            fs.Close()
            ' close the file 
            Return theFile
        Catch ex As Exception
            'handle error here
            Return String.Empty
        End Try

    End Function
    Private Sub tbEmail_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles tbEmail.DragDrop
        Try
            Dim results As String = String.Empty
            If e.Data.GetDataPresent("FileGroupDescriptor") Then
                If e.Data.GetFormats(False)(1) = "FileGroupDescriptor" Then
                    'Dim FilePath As String = GetOutlookAttachment(e, "FileGroupDescriptor")
                    'Dim file As IO.FileInfo
                    'file = New FileInfo(FilePath)
                    'file.MoveTo("d:\tmp\" & file.Name)
                    Dim olItem As Microsoft.Office.Interop.Outlook.MailItem
                    For Each olItem In OL.ActiveExplorer.Selection
                        If olItem.Attachments.Count > 0 Then
                            Dim dlgAsk As New dlgAskIt
                            Dim LastY As Integer = 0
                            Dim iLabelPositionX As Integer = 0
                            Dim mylabel As New Label
                            dlgAsk.Name = "dlgAskJK"
                            dlgAsk.StartPosition = FormStartPosition.CenterScreen
                            mylabel.Name = "lblText"
                            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
                            mylabel.Text = "Welke bijlage's"
                            mylabel.AutoSize = True
                            dlgAsk.Controls.Add(mylabel)
                            Dim mylv As New ListView
                            mylv.Location = New Point(mylabel.Location.X + 20, LastY + 20)
                            'mylv.Size =
                            'mylv.Columns.Add("file", 100, HorizontalAlignment.Left)

                            Dim lstViewItem As ListViewItem = New ListViewItem()

                            For Each oAttach In olItem.Attachments
                                lstViewItem = New ListViewItem()
                                lstViewItem.Text = oAttach.FileName
                                mylv.Items.Add(lstViewItem)
                                oAttach.SaveAsFile("d:\tmp\" & oAttach.FileName)
                            Next
                            dlgAsk.Controls.Add(mylv)
                            dlgAsk.ShowDialog()
                            'For Each oAttach In olItem.Attachments
                            '    oAttach.SaveAsFile("d:\tmp\" & oAttach.FileName)
                            'Next

                        End If
                    Next
                Else
                    Dim olItem As Microsoft.Office.Interop.Outlook.MailItem
                    For Each olItem In OL.ActiveExplorer.Selection
                        'If olItem.Attachments.Count > 0 Then
                        '    For Each oAttach In olItem.Attachments
                        '        oAttach.SaveAsFile("d:\tmp\" & oAttach.FileName)
                        '    Next
                        'End If
                        olItem.SaveAs("d:\tmp\" & olItem.Subject.Replace(":", "") & ".msg", Microsoft.Office.Interop.Outlook.OlSaveAsType.olMSG)
                        results &= olItem.Subject.Replace(":", "") & ", " & vbCrLf
                    Next
                End If

            ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
                    Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
                    Dim file As IO.FileInfo
                    For Each path In files
                        file = New FileInfo(path)
                        file.CopyTo("d:\tmp\" & file.Name)
                        results &= file.Name & ", " & vbCrLf
                    Next

            Else
                    MsgBox("is geen email.")
            End If

            MsgBox(results & " zijn verwerkt.")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub tbEmail_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles tbEmail.DragEnter
        'If Not (e.Data.GetDataPresent(GetType(System.String))) Then
        '    e.Effect = DragDropEffects.None
        '    MsgBox("geen data.")
        '    Return
        'End If
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        ElseIf e.Data.GetDataPresent("DataFormats.Text") Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub tbFiles_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles tbFiles.DragDrop
        Try
            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
            Dim file As IO.FileInfo
            For Each path In files
                file = New FileInfo(path)
                file.CopyTo("d:\tmp\" & file.Name)
                MsgBox(file.Name)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub tbFiles_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles tbFiles.DragEnter
        If e.Data.GetDataPresent(DataFormats.MetafilePict) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
End Class