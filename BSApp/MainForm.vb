Imports System.Windows.Forms
Imports BusinessObjects

Public Class MainForm
    Private da As New DataAccess
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ChildForm As New frmAdviseurs
        Changelayout()
        ChildForm.MdiParent = Me
        ChildForm.WindowState = FormWindowState.Maximized
        m_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripButton.Click
        '' Create a new instance of the child form.
        'Dim ChildForm As New frmStart
        '' Make it a child of this MDI form before showing it.
        'ChildForm.MdiParent = Me

        'm_ChildFormNumber += 1
        'ChildForm.Text = "Window " & m_ChildFormNumber

        'ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName

        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName

        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    Public Function FindChild(ByVal Name As String) As Form
        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name = Name Then
                ChildForm.Activate()
                Return ChildForm
            End If
        Next
        Return Nothing
    End Function



    Private Sub locatiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles locatiesToolStripMenuItem.Click
        Try
            If FindChild("frmlocaties") Is Nothing Then
                Dim ChildForm As New frmlocaties
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AdviseursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdviseursToolStripMenuItem.Click
        Try
            If FindChild("frmAdviseurs") Is Nothing Then
                Dim ChildForm As New frmAdviseurs
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LedenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedenToolStripMenuItem.Click
        Try
            If FindChild("frmLeden") Is Nothing Then
                Dim ChildForm As New frmLeden
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Try
            Dim dlgSettings As New dlgSettings
            dlgSettings.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAbout As New AboutBox
        frmAbout.ShowDialog(Me)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseMenu.Click
        Me.Close()
    End Sub
    Private Sub tsmBookingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmBookingLiisten.Click

    End Sub

    Private Sub NaarTextbestandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NaarTextbestandToolStripMenuItem.Click
        Try
            'If MessageBox.Show("Er wordt een volledig overzicht gemaakt van alle afspraken op alle locaties." _
            '                    & vbCrLf & "Dit kan enkele minuten duren." _
            '                    & vbCrLf & "Weet u zeker dat u wilt doorgaan?", "Maak overzicht?", MessageBoxButtons.YesNo, _
            '                    MessageBoxIcon.Question) = DialogResult.Yes Then
            '    Cursor = Cursors.WaitCursor
            '    Dim Booking2Excel As New OfficeObjects.BookingList
            '    Booking2Excel.PerLocatiePerDatumTXT()
            'End If

            Dim LocationPath As String = ""
            fbdSave.Description = "Selecteer de opslag locatie..."

            If Not My.Settings.LastSavePath = "" Then
                fbdSave.SelectedPath = My.Settings.LastSavePath
                fbdSave.Description = "huidige opslag locatie..." & vbCrLf & vbCrLf & fbdSave.SelectedPath
            End If

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = fbdSave.SelectedPath
                My.Settings.LastSavePath = fbdSave.SelectedPath
                My.Settings.Save()
                Dim MyBookingList As New OfficeObjects.BookingList
                MyBookingList.PerLocatiePerDatumTXT(LocationPath)
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub NaarWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NaarWordToolStripMenuItem.Click
        Try

            Dim LocationPath As String = ""
            fbdSave.Description = "Selecteer de opslag locatie..."

            If Not My.Settings.LastSavePath = "" Then
                fbdSave.SelectedPath = My.Settings.LastSavePath
                fbdSave.Description = "huidige opslag locatie..." & vbCrLf & vbCrLf & fbdSave.SelectedPath
            End If

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = fbdSave.SelectedPath
                My.Settings.LastSavePath = fbdSave.SelectedPath
                My.Settings.Save()
                Dim MyBookingList As New OfficeObjects.BookingList
                MyBookingList.PerLocatiePerDatumWord(LocationPath)
            End If


        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub NaarExcel2007ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NaarExcel2007ToolStripMenuItem.Click
        Try
            If MessageBox.Show("Er wordt een volledig overzicht gemaakt van alle afspraken op alle locaties." _
                                & vbCrLf & "Dit kan enkele minuten duren." _
                                & vbCrLf & "Weet u zeker dat u wilt doorgaan?", "Maak overzicht?", MessageBoxButtons.YesNo, _
                                MessageBoxIcon.Question) = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim Booking2Excel As New OfficeObjects.BookingList
                Booking2Excel.Bookings2Excel()
            End If
            'Dim LocationPath As String = ""
            ''fbdSave.RootFolder = Environment.SpecialFolder.MyDocuments
            'fbdSave.Description = "Selecteer de opslag locatie..."
            'If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    Cursor = Cursors.WaitCursor
            '    LocationPath = fbdSave.SelectedPath
            '    Dim Booking2Excel As New OfficeObjects.BookingList
            '    Booking2Excel.PerLocatiePerDatumWord(LocationPath)
            'End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LettertypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LettertypeToolStripMenuItem.Click
        Dim frm As New FontDialog
        frm.Font = Me.Font
        frm.ShowDialog()
        da.Settings.FontSize = frm.Font.Size
        da.Settings.FontFamily = frm.Font.FontFamily.Name
        da.Settings.FontStyle = frm.Font.Style
        da.Settings.Save()
        Changelayout()
    End Sub
    Private Sub Changelayout()
        Dim style As FontStyle = CInt(da.Settings.FontStyle)
        Dim newFont As Font = New System.Drawing.Font(da.Settings.FontFamily, da.Settings.FontSize, style)
        Me.Font = newFont
        'Me.ParentForm.Font = newFont
        If da.Settings.FontSize >= 9 Then
            Me.WindowState = FormWindowState.Maximized
        End If

    End Sub
End Class
