Imports System.ComponentModel
Imports System.Windows.Forms
Imports BusinessObjects
Imports OfficeObjects
Imports System.IO
'Imports MapiObjects

Public Class Main
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            Changelayout()
            Me.StartPosition = FormStartPosition.CenterScreen

            If CreateDefaultLabels Then CreateMenulXml(OnderhoudToolStripMenuItem, Me.Name, True)
            GetMenuText(OnderhoudToolStripMenuItem, Me.Name)

            Dim SetAnpvMenu As String = GetSysSettingOf("SetAnpvMenu", False)
            If SetAnpvMenu.ToLower <> "true" Then
                ImportExportNPToolStripMenuItem.Visible = False
            End If


            If URights.IsValidADLogin() Then 'My.User.Name
                Dim ChildForm As New frmRelatieSearch
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
                If TypeName(Me.MenuStrip.Items(0)) = "SystemMenuItem" Then
                    Dim t As Long
                    t = Me.MenuStrip.Height
                    Me.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                    Me.MenuStrip.Height = t
                End If
            Else
                MessageBox.Show("U bent geen lid van een Relatie groep!" & vbCrLf &
                                    "Neem contact op met uw systeembeheerder!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\smsapp.exe") Then
                mGeneral.HaveSMSApplication = True
            End If



            'If URights.getDomainName = "netmask" Then

            'ElseIf URights.getDomainName = "VBM" Then

            'ElseIf URights.getDomainName = "ANPV" Then
                'VerwerkenMenuItem.Visible = False
            'End If


            If URights.IsInGroup("rel_ibb_users") Or URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_ibb_admins") Then
                IBBToolStripMenuItem.Visible = True
            Else
                IBBToolStripMenuItem.Visible = False
            End If

            If URights.UserName = "bert" Then
                Me.Text = "sql: " & da.Settings.ServerIP.ToUpper
            End If
            TestToolStripMenuItem.Visible = URights.UserName = "bert"
            EwstestToolStripMenuItem.Visible = URights.UserName = "bert"
            PermissionTestToolStripMenuItem.Visible = URights.UserName = "bert"
            DDTestToolStripMenuItem.Visible = URights.UserName = "bert"

            System.Threading.Thread.CurrentThread.CurrentCulture = NLCulture '"dd-MM-yyyy"


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private m_ChildFormNumber As Integer
    Public Function FindChild(ByVal Name As String) As Form
        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name = Name Then

                Return ChildForm
            End If
        Next
        Return Nothing
    End Function
    Public Function FindRelatieform(ByVal findlidid As String) As Form
        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name = "frmRelatie" Then
                Dim frm As frmRelatie = ChildForm
                If frm.MyRelatie.Id = findlidid Then
                    Return ChildForm
                End If
            End If
        Next
        Return Nothing
    End Function
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseToolStripMenuItem.Click

        Try
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
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
        'Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    'Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
    '    Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    'End Sub

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

    Private Sub LidsoortenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LidsoortenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("lidsoorten", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ContributieSoortenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContributieSoortenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("Contributie", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DienstvakkenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DienstvakkenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("dienstvakken", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub KMOnderdelenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KMOnderdelenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("kmonderdelen", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PlaatsingenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaatsingenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("plaatsingen", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RangenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RangenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("rangen", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InstantiescontributieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstantiescontributieToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("contr_instanties", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LedenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedenToolStripMenuItem.Click
        Try
            'BMO aangepast bug 1325
            Dim ChildForm As frmRelatieSearch
            For Each ChildForm In Me.MdiChildren
                If ChildForm.Name = "frmRelatieSearch" And ChildForm.status = 0 Then
                    ChildForm.Activate()
                    Exit Sub
                End If
            Next

            ChildForm = New frmRelatieSearch
            ChildForm.MdiParent = Me
            ChildForm.WindowState = FormWindowState.Maximized
            m_ChildFormNumber += 1
            ChildForm.Show()
            If TypeName(Me.MenuStrip.Items(0)) = "SystemMenuItem" Then
                Dim t As Long
                t = Me.MenuStrip.Height
                Me.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                Me.MenuStrip.Height = t    'otherwise it goes too big.
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LedenVoorportaalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedenVoorportaalToolStripMenuItem.Click
        Try
            Dim ChildForm As New frmRelatieSearch(2)
            ChildForm.MdiParent = Me
            ChildForm.WindowState = FormWindowState.Maximized
            m_ChildFormNumber += 1
            ChildForm.Show()
            If TypeName(Me.MenuStrip.Items(0)) = "SystemMenuItem" Then
                Dim t As Long
                t = Me.MenuStrip.Height
                Me.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                Me.MenuStrip.Height = t    'otherwise it goes too big.
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LedenNonActiefToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedenNonActiefToolStripMenuItem.Click
        Try
            Dim ChildForm As New frmRelatieSearch(1)
            ChildForm.MdiParent = Me
            ChildForm.WindowState = FormWindowState.Maximized
            m_ChildFormNumber += 1
            ChildForm.Show()
            If TypeName(Me.MenuStrip.Items(0)) = "SystemMenuItem" Then
                Dim t As Long
                t = Me.MenuStrip.Height
                Me.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                Me.MenuStrip.Height = t    'otherwise it goes too big.
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NSKMutatiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NSKMutatiesToolStripMenuItem.Click
        Try
            Dim ChildForm As frmNSKProcess = FindChild("frmNSKProcess")
            If ChildForm Is Nothing Then
                ChildForm = New frmNSKProcess
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub TemplatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TemplatesToolStripMenuItem.Click
        Try
            Dim frm As New frmMaintenanceTemplates
            frm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MailingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MailingToolStripMenuItem.Click
        Try
            Dim ChildForm As frmMailing = FindChild("frmMailing")
            If ChildForm Is Nothing Then
                ChildForm = New frmMailing
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClieopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClieopToolStripMenuItem.Click
        Try
            Dim ChildForm As frmSEPA = FindChild("frmSEPA")
            If ChildForm Is Nothing Then
                ChildForm = New frmSEPA
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InstellingenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstellingenToolStripMenuItem.Click
        Try
            Dim ChildForm As New dlgSettings
            ChildForm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private WithEvents _thSegmentationReport As SegmentationReport
    Private Status As String = ""
    Private Ready As Boolean = False
    Private iCounter As Integer = 0
    Private iCounterTotal As Integer = 0

    Public Sub GenerateCompleteHandler(ByVal _iCounter As Integer) Handles _thSegmentationReport.GenerateComplete
        Ready = True
        iCounter = _iCounter
    End Sub
    Public Sub GenerateStatusHandler(ByVal _message As String) Handles _thSegmentationReport.GenerateStatus
        Status = _message
    End Sub
    Public Sub GenerateExpHandler(ByVal exp As Exception) Handles _thSegmentationReport.GenerateExp
        Status = "ERROR:" & exp.Message
    End Sub
    Public Sub GenerateCounter(ByVal _iCounter As Integer, ByVal _iCounterTotal As Integer) Handles _thSegmentationReport.GenerateCounter
        iCounter = _iCounter
        iCounterTotal = _iCounterTotal
    End Sub
    Private Sub VerslagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerslagenToolStripMenuItem.Click
        Try

            Dim LocationPath As String = ""
            fbdSave.Description = "Selecteer de opslag locatie..."

            If Not My.Settings.ReportsPath = "" Then
                fbdSave.SelectedPath = My.Settings.ReportsPath
                fbdSave.Description = "huidige opslag locatie..." & vbCrLf & vbCrLf & fbdSave.SelectedPath
            End If

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = fbdSave.SelectedPath
                My.Settings.ReportsPath = fbdSave.SelectedPath
                My.Settings.Save()

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.Report)
                _thSegmentationReport.DateOut = New Date(Now.Year, Now.Month, Now.Day)
                _thSegmentationReport.LocationPath = LocationPath
                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met verslag van leden......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub RelatiePrint()
        Try
            Dim ChildForm As frmRelatie = FindChild("frmRelatie")
            If ChildForm Is Nothing Then
                Exit Sub
            Else
                ChildForm.Activate()
            End If

            Dim LocationPath As String = ""

            Ready = False
            Me.Cursor = Cursors.WaitCursor

            _thSegmentationReport = New SegmentationReport
            Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportRelation)
            '_thSegmentationReport.LocationPath = LocationPath
            _thSegmentationReport.MyRelatie = ChildForm.MyRelatie
            thGenerate.Start()

            Dim frm As New frmWait
            frm.lbMessage.Text = "Bezig met verslag van leden......"
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowInTaskbar = False
            frm.TopMost = True
            frm.pbTaskProgress.Maximum = 1000
            frm.Show()
            My.Application.DoEvents()

            Dim iPadright As Integer = 1
            Dim sPadRight As String = ""
            While Ready = False
                iPadright += 1
                If iPadright = 25 Then
                    frm.Tmr_Tick()
                    iPadright = 1
                End If
                frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                frm.Refresh()
                If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    thGenerate.Abort()
                    Me.Cursor = Cursors.Default
                    Exit While
                End If
                My.Application.DoEvents()
            End While

            frm.pbTaskProgress.Value = 1000
            frm.btnOk.Visible = True
            frm.btnCancel.Visible = False
            frm.lbMessage.Text = Status
            frm.Refresh()

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LedenInUitstroomVerslag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedenInUitstroomVerslag.Click
        Try
            Dim ChildForm As frmInOuFlow = FindChild("frmInOuFlow")
            If ChildForm Is Nothing Then
                ChildForm = New frmInOuFlow
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            'If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_Users") Then
            '    ga dan door
            If Me.ActiveMdiChild.Name = "frmRelatie" Then
                Dim frm As frmRelatie = Me.ActiveMdiChild
                frm.Save()
            ElseIf Me.ActiveMdiChild.Name = "frmIBBDossier" Then
                Dim frm As frmIBBDossier = Me.ActiveMdiChild
                frm.Save()
            End If
            'Else
            '    MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Try
            Dim frmAbout As New AboutBox
            frmAbout.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FunctiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FunctiesToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("functies", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AdviesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdviesToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("fadvies", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeClientAreaOnly)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        'PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
        'PrintForm1.PrintAction = Printing.PrintAction.PrintToPrinter
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeClientAreaOnly)
        Try
            If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_Users") Then
                RelatiePrint()
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub NSKInUitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NSKInUitToolStripMenuItem.Click
        Try
            ' If URights.IsInGroup("rel_admins") Or URights.IsInGroup("rel_Users") Then
            ' Bug ID: 2772 - de functie NSK IN/Out, zit denk ik nu onder User recht, nu alleen met admin recht ? 
            If URights.IsInGroup("rel_admins") Then
                Dim NSKInUit As New NSKInOut
                NSKInUit.Process()
                If MessageBox.Show("NSK verslag is klaar." _
                       & vbCrLf & "Wilt u alle aan-/afmeldingen resetten?", "Reset", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then
                    NSKInUit.reset()
                End If
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Try
            'If Me.ActiveMdiChild.Name = "frmRelatie" Then
            Dim ChildForm As New frmRelatie
            ChildForm.MdiParent = Me
            ChildForm.WindowState = FormWindowState.Maximized
            m_ChildFormNumber += 1
            ChildForm.Show()

            'ElseIf Me.ActiveMdiChild.Name = "frmIBBDossier" Then
            '    Dim frm As frmIBBDossier = Me.ActiveMdiChild
            '    frm.Save()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VerzendbestandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerzendbestandToolStripMenuItem.Click
        Try

            Dim ChildForm As frmAddressFile = FindChild("frmAddresFile")
            If ChildForm Is Nothing Then
                ChildForm = New frmAddressFile
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub SysteemInstellingenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SysteemInstellingenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("systeeminstellingen", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ABPMutatiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ABPMutatiesToolStripMenuItem.Click
        Try
            Dim ChildForm As frmABPProcess = FindChild("frmABPProcess")
            If ChildForm Is Nothing Then
                ChildForm = New frmABPProcess
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub OverledenbestandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverledenbestandToolStripMenuItem.Click
        Try

            Dim ChildForm As frmOverleden = FindChild("frmOverleden")
            If ChildForm Is Nothing Then
                ChildForm = New frmOverleden
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuItemXrcizeAge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemXrcizeAge.Click
        'DECLARE @EndingDate DATETIME
        'SET @EndingDate = GETDATE() 
        Try
            Dim dlgAskAge As New dlgAskIt
            dlgAskAge.StartPosition = FormStartPosition.CenterScreen

            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAskAge.Location.X + 20, 20)
            mylabel.Name = "lbAge"
            mylabel.Text = "Geef de leeftijd voor de rapport selectie op."
            mylabel.AutoSize = True
            dlgAskAge.Controls.Add(mylabel)

            Dim lbAge As New Label
            lbAge.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
            lbAge.Text = "leeftijd gelijk of ouder dan"
            lbAge.AutoSize = True
            dlgAskAge.Controls.Add(lbAge)

            Dim tbAge As New TextBox
            tbAge.Location = New Point(lbAge.Size.Width + 30, lbAge.Location.Y - 5)
            tbAge.Name = "tbAge"
            tbAge.Text = 40
            dlgAskAge.Controls.Add(tbAge)


            dlgAskAge.ShowDialog()

            If dlgAskAge.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim _tbAge As New TextBox
                _tbAge = dlgAskAge.Controls.Item("tbAge")
                Dim iAgeCeiling As Integer = CInt(_tbAge.Text)
                Dim sql As String = "select *,DATEDIFF(YEAR, geboortedatum, @EndingDate) as Leeftijd " &
                                    "FROM Relaties " &
                                    "WHERE aantal_xr > 0 and (DATEDIFF(YEAR, geboortedatum, @EndingDate) >= @Age)"
                Dim paramlist As New ArrayList
                paramlist.Add("@EndingDate")
                paramlist.Add(DateTime.Now)
                paramlist.Add("@Age")
                paramlist.Add(iAgeCeiling)

                Dim dt As New DataTable
                dt = da.ExecuteDataTable(sql, paramlist.ToArray)
                dt.TableName = "Leeftijd"

                Dim ChildForm As frmMailing = FindChild("frmMailing")
                If ChildForm Is Nothing Then
                    ChildForm = New frmMailing
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized
                    m_ChildFormNumber += 1
                    ChildForm.lblStatus.Text = "Xrcize leden van " & iAgeCeiling & " jaar en ouder."
                    ChildForm.Show()
                    ChildForm.FillFromQuickMail(dt)
                Else
                    ChildForm.FillFromQuickMail(dt)
                    ChildForm.lblStatus.Text = "Xrcize leden van " & iAgeCeiling & " jaar en ouder."
                    ChildForm.Activate()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuItemDeceased_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemDeceased.Click
        Try
            Dim dlgAsk As New dlgAskIt
            dlgAsk.StartPosition = FormStartPosition.CenterScreen

            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
            mylabel.Text = "Geef de periode voor de rapport selectie op."
            mylabel.AutoSize = True
            dlgAsk.Controls.Add(mylabel)

            Dim lbStart As New Label
            lbStart.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
            lbStart.Text = "Van.."
            lbStart.AutoSize = True
            dlgAsk.Controls.Add(lbStart)

            Dim dtpStart As New DateTimePicker
            dtpStart.Location = New Point(lbStart.Size.Width + 30, lbStart.Location.Y - 5)
            dtpStart.Name = "dtpStart"
            dlgAsk.Controls.Add(dtpStart)

            Dim lbEnd As New Label
            lbEnd.Location = New Point(dlgAsk.Location.X + 20, (lbStart.Location.Y + lbStart.Size.Height + 30))
            lbEnd.Text = "Tot.."
            lbEnd.AutoSize = True
            dlgAsk.Controls.Add(lbEnd)

            Dim dtpEnd As New DateTimePicker
            dtpEnd.Location = New Point(lbEnd.Size.Width + 30, lbEnd.Location.Y - 5)
            dtpEnd.Name = "dtpEnd"
            'dtpStart.Text = Today
            dlgAsk.Controls.Add(dtpEnd)

            dlgAsk.ShowDialog()

            If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim dtp As New DateTimePicker
                dtp = dlgAsk.Controls.Item("dtpStart")
                Dim dStartDate As Date = dtp.Value

                dtp = dlgAsk.Controls.Item("dtpEnd")
                Dim dEndDate As Date = dtp.Value

                Dim sql As String = "SELECT * FROM relaties " &
                               "WHERE " &
                               " eindereden = 5 " &
                               "AND (eindedatum >= @StartDate AND eindedatum <= @EndDate) " &
                               "order by eindedatum ASC"
                Dim paramlist As New ArrayList

                paramlist.Add("@StartDate")
                paramlist.Add(dStartDate)
                paramlist.Add("@EndDate")
                paramlist.Add(dEndDate)

                Dim dt As New DataTable
                dt = da.ExecuteDataTable(sql, paramlist.ToArray)

                Dim ChildForm As frmMailing = FindChild("frmMailing")
                If ChildForm Is Nothing Then
                    ChildForm = New frmMailing
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized
                    m_ChildFormNumber += 1
                    ChildForm.lblStatus.Text = "overzicht leden overleden tussen " & dStartDate.ToShortDateString & " en " & dEndDate.ToShortDateString
                    ChildForm.Show()
                    ChildForm.FillFromQuickMail(dt)
                Else
                    ChildForm.FillFromQuickMail(dt)
                    ChildForm.lblStatus.Text = "overzicht leden overleden tussen " & dStartDate.ToShortDateString & " en " & dEndDate.ToShortDateString
                    ChildForm.Activate()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuItemFreeMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemFreeMembers.Click
        Try
            Dim dlgAsk As New dlgAskIt
            dlgAsk.StartPosition = FormStartPosition.CenterScreen

            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
            mylabel.Text = "Geef de selectie voor het rapport op."
            mylabel.AutoSize = True
            dlgAsk.Controls.Add(mylabel)

            Dim lbMonths As New Label
            lbMonths.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
            lbMonths.Text = "Aantal maanden"
            lbMonths.AutoSize = True
            dlgAsk.Controls.Add(lbMonths)

            Dim tbMonths As New TextBox
            tbMonths.Location = New Point(lbMonths.Size.Width + 30, lbMonths.Location.Y - 5)
            tbMonths.Name = "tbMonths"
            tbMonths.Text = 12
            dlgAsk.Controls.Add(tbMonths)

            Dim lblidsoort As New Label
            lblidsoort.Location = New Point(dlgAsk.Location.X + 20, (lbMonths.Location.Y + lbMonths.Size.Height + 30))
            lblidsoort.Text = "lidsoort"
            lblidsoort.AutoSize = True
            dlgAsk.Controls.Add(lblidsoort)

            Dim lidsoorten As DataTable = da.ExecuteDataTable("SELECT * FROM lidsoorten ORDER BY sequence")
            Dim cmbLidSoorten As New ComboBox
            cmbLidSoorten.Name = "cmbLidSoorten"
            cmbLidSoorten.DataSource = lidsoorten
            cmbLidSoorten.DisplayMember = "Omschrijving"
            cmbLidSoorten.ValueMember = "Id"
            cmbLidSoorten.Location = New Point(tbMonths.Location.X, lblidsoort.Location.Y - 5)

            dlgAsk.Controls.Add(cmbLidSoorten)
            cmbLidSoorten.SelectedValue = "2"

            dlgAsk.ShowDialog()

            If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim tbMonth As New TextBox
                tbMonth = dlgAsk.Controls.Item("tbMonths")
                Dim iMonth As Integer = CInt(tbMonth.Text)
                Dim StartDate As Date = DateAdd(DateInterval.Month, -iMonth, DateTime.Now)

                Dim cmb As New ComboBox
                cmb = dlgAsk.Controls.Item("cmbLidSoorten")
                Dim iLidsoort As Integer = cmb.SelectedValue

                Dim sql As String = "SELECT * " &
                                    "FROM relaties r where id in(  " &
                                    "Select lidid   " &
                                    "from Lidsoortperioden l   " &
                                    "WHERE lidsoortid =  @iLidsoort  " &
                                    "and datumin < @StartDate " &
                                    "and datumin = (select MAX(datumin) from Lidsoortperioden where lidid = l.lidid and datumin < @StartDate )) " &
                                    "and indatum < @StartDate " &
                                    "and status = 0"

                Dim paramlist As New ArrayList
                paramlist.Add("@StartDate")
                paramlist.Add(StartDate)
                paramlist.Add("@iLidsoort")
                paramlist.Add(iLidsoort)

                Dim dt As DataTable = da.ExecuteDataTable(sql, paramlist.ToArray)

                Dim ChildForm As frmMailing = FindChild("frmMailing")
                If ChildForm Is Nothing Then
                    ChildForm = New frmMailing
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized
                    m_ChildFormNumber += 1
                    ChildForm.lblStatus.Text = "overzicht lidsoort ''" & cmb.Text & "'' langer lid dan " & iMonth & " maanden "
                    ChildForm.Show()
                    ChildForm.FillFromQuickMail(dt)
                Else
                    ChildForm.FillFromQuickMail(dt)
                    ChildForm.lblStatus.Text = "overzicht lidsoort ''" & cmb.Text & "'' langer lid dan " & iMonth & " maanden "
                    ChildForm.Activate()
                End If
                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuItemPinCarriers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemPinCarriers.Click
        Try
            Dim dlgAsk As New dlgAskIt
            dlgAsk.StartPosition = FormStartPosition.CenterScreen

            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
            mylabel.Text = "Geef de selectie voor het rapport op."
            mylabel.AutoSize = True
            dlgAsk.Controls.Add(mylabel)

            Dim rdZilver As New RadioButton
            rdZilver.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
            rdZilver.Name = "rdZilver"
            rdZilver.Text = "Zilver"
            rdZilver.AutoSize = True
            rdZilver.Checked = True
            dlgAsk.Controls.Add(rdZilver)

            Dim rdGoud As New RadioButton
            rdGoud.Location = New Point(rdZilver.Location.X + rdZilver.Size.Width + 10, mylabel.Location.Y + mylabel.Size.Height + 20)
            rdGoud.Name = "rdGoud"
            rdGoud.Text = "Goud"
            rdGoud.AutoSize = True
            dlgAsk.Controls.Add(rdGoud)


            Dim lbYear As New Label
            lbYear.Location = New Point(mylabel.Location.X, rdZilver.Location.Y + rdZilver.Size.Height + 20)
            lbYear.Text = "Jaar"
            lbYear.AutoSize = True
            dlgAsk.Controls.Add(lbYear)

            Dim tbYear As New TextBox
            tbYear.Location = New Point(dlgAsk.Location.X + 80, lbYear.Location.Y + 2)
            tbYear.Name = "tbYear"
            tbYear.Text = DateTime.Now.Year
            dlgAsk.Controls.Add(tbYear)


            Dim lbMonths As New Label
            lbMonths.Location = New Point(mylabel.Location.X, lbYear.Location.Y + lbYear.Size.Height + 20)
            lbMonths.Text = "Maand"
            lbMonths.AutoSize = True
            dlgAsk.Controls.Add(lbMonths)

            Dim tbMonths As New TextBox
            tbMonths.Location = New Point(dlgAsk.Location.X + 80, lbMonths.Location.Y - 5)
            tbMonths.Name = "tbMonths"
            tbMonths.Text = 12
            tbMonths.MaxLength = 2
            dlgAsk.Controls.Add(tbMonths)

            Dim lbReceived As New Label
            lbReceived.Location = New Point(dlgAsk.Location.X + 80, lbMonths.Location.Y + lbMonths.Size.Height + 20)
            lbReceived.Text = "Ontvangen in gekozen maand"
            lbReceived.AutoSize = True
            dlgAsk.Controls.Add(lbReceived)

            Dim chkReceived As New CheckBox
            chkReceived.Location = New Point(mylabel.Location.X + 10, lbReceived.Location.Y - 5)
            chkReceived.Name = "chkReceived"
            'chkReceived.Text = "Ontvangen"
            dlgAsk.Controls.Add(chkReceived)

            'Dim lblidsoort As New Label
            'lblidsoort.Location = New Point(dlgAsk.Location.X + 20, (lbMonths.Location.Y + lbMonths.Size.Height + 30))
            'lblidsoort.Text = "lidsoort"
            'lblidsoort.AutoSize = True
            'dlgAsk.Controls.Add(lblidsoort)

            dlgAsk.ShowDialog()

            If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then

                Dim _tbYear As New TextBox
                _tbYear = dlgAsk.Controls.Item("tbYear")
                Dim _rdSpeld As New RadioButton
                _rdSpeld = dlgAsk.Controls.Item("rdGoud")
                Dim _tbMonth As New TextBox
                _tbMonth = dlgAsk.Controls.Item("tbMonths")
                Dim _status As String = "overzicht spelddragers "
                'zilver is 25 jaar lid
                'goud is 50 jaar lid

                Dim iYears As Integer = 25
                If _rdSpeld.Checked Then
                    iYears = 50
                    _status &= "goud "
                Else
                    _status &= "zilver "
                End If

                Dim iYear As Integer = CInt(_tbYear.Text)
                Dim iMonth As Integer = CInt(_tbMonth.Text)
                Dim _chkReveived As New CheckBox
                _chkReveived = dlgAsk.Controls.Item("chkReceived")
                Dim sql As String = String.Empty
                Dim sqlReveived As String = String.Empty
                Dim sqlAdd As String = String.Empty

                If _chkReveived.Checked Then
                    iYear = CInt(_tbYear.Text)
                Else
                    iYear -= iYears
                End If

                Dim paramlist As New ArrayList
                paramlist.Add("@Year")
                paramlist.Add(iYear)

                If iMonth > 12 Then
                    MessageBox.Show("maand " & iMonth & " niet geldig", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If iMonth > 0 And iMonth <= 12 Then
                    sqlAdd &= " AND month(indatum) = @Month "
                    paramlist.Add("@Month")
                    paramlist.Add(iMonth)
                    _status &= "in " & CType(iMonth, eMaand).ToString() & " " & _tbYear.Text & " -"
                End If

                If iYears = 25 Then
                    If Not _chkReveived.Checked Then
                        sqlAdd &= " AND(zilver Is NULL)"
                        _status &= " - nog niet ontvangen "
                    Else
                        '_status &= " incl al ontvangen "
                        sqlReveived = "Select * from Relaties Where((year(zilver) = @Year) AND status = 0  AND month(zilver) = @Month)"
                        _status = "zilveren speld ontvangen In " & CType(iMonth, eMaand).ToString() & " " & _tbYear.Text & " -"
                    End If

                    '_status &= _tbYear.Text
                ElseIf iYears = 50 Then
                    If Not _chkReveived.Checked Then
                        sqlAdd &= " And(goud Is NULL)"
                        _status &= " - nog niet ontvangen "
                    Else
                        '_status &= " incl al ontvangen "
                        sqlReveived = "Select * from Relaties Where((year(goud) = @Year) And status = 0  And month(goud) = @Month)"
                        _status = "gouden speld ontvangen in " & CType(iMonth, eMaand).ToString() & " " & _tbYear.Text & " -"
                    End If
                    ' _status &= " In " & _tbYear.Text
                End If


                If _chkReveived.Checked Then
                    sql = sqlReveived
                Else
                    sql = "Select * from Relaties Where(year(indatum) = @Year) And status = 0 " & sqlAdd
                End If

                'Dim RapportDate As Date = New Date(iYear, iMonth, 31)
                'Dim PinDate As Date = DateAdd(DateInterval.Year, -iYears, RapportDate)
                'paramlist.Add("@PinDate")
                'paramlist.Add(PinDate)

                Dim dt As New DataTable
                dt = da.ExecuteDataTable(sql, paramlist.ToArray)

                '_status &= " In " & RapportDate.ToShortDateString

                Dim ChildForm As frmMailing = FindChild("frmMailing")
                If ChildForm Is Nothing Then
                    ChildForm = New frmMailing
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized
                    m_ChildFormNumber += 1
                    ChildForm.lblStatus.Text = _status
                    ChildForm.Show()
                    ChildForm.FillFromQuickMail(dt)
                Else
                    ChildForm.FillFromQuickMail(dt)
                    ChildForm.lblStatus.Text = _status
                    ChildForm.Activate()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuItemInstance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItemInstance.Click
        Try
            Dim dlgAsk As New dlgAskIt
            dlgAsk.StartPosition = FormStartPosition.CenterScreen

            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
            mylabel.Text = "Geef de selectie voor het rapport op."
            mylabel.AutoSize = True
            dlgAsk.Controls.Add(mylabel)

            Dim lbMonths As New Label
            lbMonths.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
            lbMonths.Text = "Instantie"
            lbMonths.AutoSize = True
            dlgAsk.Controls.Add(lbMonths)

            Dim ContributieInstanties As DataTable = da.ExecuteDataTable("Select *, left(CAST(id As varchar) + SPACE(5),5) + ' | ' + Naam as id_omsch FROM Contr_instanties ORDER BY Id")

            Dim cmbInstanties As New ComboBox
            cmbInstanties.Name = "cmbInstanties"
            cmbInstanties.DataSource = ContributieInstanties
            cmbInstanties.DisplayMember = "Naam"
            cmbInstanties.ValueMember = "Id"
            cmbInstanties.Location = New Point(lbMonths.Size.Width + 30, lbMonths.Location.Y - 5)

            dlgAsk.Controls.Add(cmbInstanties)
            cmbInstanties.SelectedValue = "2"

            dlgAsk.ShowDialog()

            If dlgAsk.DialogResult = Windows.Forms.DialogResult.OK Then

                Me.Cursor = Cursors.WaitCursor

                Dim cmb As New ComboBox
                cmb = dlgAsk.Controls.Item("cmbInstanties")
                Dim iInstantie As Integer = cmb.SelectedValue

                Dim sql As String = "Select * " &
                          "from Relaties " &
                          "Where(InstantieId = @InstantieId) AND status = 0 "

                Dim paramlist As New ArrayList
                paramlist.Add("@InstantieId")
                paramlist.Add(iInstantie)

                Dim dt As New DataTable
                dt = da.ExecuteDataTable(sql, paramlist.ToArray)

                Dim _status As String = "overzicht Instantie " & cmb.Text
                Dim ChildForm As frmMailing = FindChild("frmMailing")
                If ChildForm Is Nothing Then
                    ChildForm = New frmMailing
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized
                    m_ChildFormNumber += 1
                    ChildForm.lblStatus.Text = _status
                    ChildForm.Show()
                    ChildForm.FillFromQuickMail(dt)
                Else
                    ChildForm.FillFromQuickMail(dt)
                    ChildForm.lblStatus.Text = _status
                    ChildForm.Activate()
                End If
                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub BondenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BondenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("bonden", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HoofdschermToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HoofdschermToolStripMenuItem.Click
        Try

            Dim ChildForm As frmIBBMain = FindChild("frmIBBMain")
            If ChildForm Is Nothing Then
                ChildForm = New frmIBBMain
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ZoekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoekToolStripMenuItem.Click
        Try
            Dim AllowGroups() As Object = Nothing
            AllowGroups = {"rel_admins", "rel_ibb_admins"}

            If URights.IsMemberOfOne(AllowGroups) Then

                Dim ChildForm As frmSearchDocuments = FindChild("frmSearchDocuments")
                If ChildForm Is Nothing Then
                    ChildForm = New frmSearchDocuments
                    ChildForm.MdiParent = Me
                    ChildForm.WindowState = FormWindowState.Maximized
                    m_ChildFormNumber += 1
                    ChildForm.Show()
                Else
                    ChildForm.Activate()
                End If
            Else
                MessageBox.Show("U heeft onvoldoende rechten!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private ReportBehandelaarId As Integer = -1
    Private Sub TermijnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermijnenToolStripMenuItem.Click
        Try

            Dim LocationPath As String = ""
            fbdSave.Description = "Selecteer de opslag locatie..."

            If Not My.Settings.ReportsPath = "" Then
                fbdSave.SelectedPath = My.Settings.ReportsPath
                fbdSave.Description = "huidige opslag locatie..." & vbCrLf & vbCrLf & fbdSave.SelectedPath
            End If

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = fbdSave.SelectedPath
                My.Settings.ReportsPath = fbdSave.SelectedPath
                My.Settings.Save()

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportIBBTermijnen)
                '_thSegmentationReport.DateOut = New Date(Now.Year, Now.Month, Now.Day)

                'If ReportBehandelaarId > 0 Then
                '    _thSegmentationReport.ReportBehandelaarId = ReportBehandelaarId
                'End If

                _thSegmentationReport.LocationPath = LocationPath
                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met overzicht......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub NieuweDossiersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NieuweDossiersToolStripMenuItem.Click
        Try

            Dim dlg As New dlgIbbReports

            Dim LocationPath As String = ""
            dlg.Text = "Selecteer de opslag locatie..."
            dlg.dtpStart.Value = Today.AddMonths(-6)

            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = dlg.tbSavePath.Text

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportIBBDossiers)
                _thSegmentationReport.LocationPath = LocationPath
                _thSegmentationReport.Juristid = dlg.cmbBehandelaar.SelectedValue
                ' _thSegmentationReport.Juristid = 0
                _thSegmentationReport.QueryDate = dlg.dtpStart.Value
                _thSegmentationReport.ReportTitel = "Overzicht nieuwe dossiers vanaf " & dlg.dtpStart.Value.ToShortDateString
                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met overzicht......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub InBehandelingPJuristToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InBehandelingPJuristToolStripMenuItem.Click
        Try

            Dim dlg As New dlgIbbReports

            Dim LocationPath As String = ""
            dlg.Text = "Selecteer de opslag locatie..."
            dlg.dtpStart.Visible = False
            dlg.lblVan.Visible = False
            dlg.bAtEveryone = True

            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = dlg.tbSavePath.Text

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportIBBDossiers)

                _thSegmentationReport.LocationPath = LocationPath
                _thSegmentationReport.Juristid = dlg.cmbBehandelaar.SelectedValue
                _thSegmentationReport.RubriekId = dlg.cmbRubriek.SelectedValue
                _thSegmentationReport.QueryDate = New Date(2000, 1, 1)
                _thSegmentationReport.DossierStatus = 0
                _thSegmentationReport.ReportTitel = "Overzicht dossiers in behandeling "

                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met overzicht......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AfgeslotenPJuristToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfgeslotenPJuristToolStripMenuItem.Click
        Try

            Dim dlg As New dlgIbbReports

            Dim LocationPath As String = ""
            dlg.lblVanToevoeging.Text = "(dossiers vanaf deze ''afhandel datum'')"
            dlg.lblVanToevoeging.Visible = True
            dlg.Text = "Selecteer de opslag locatie..."
            dlg.dtpStart.Value = Today.AddMonths(-6)

            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = dlg.tbSavePath.Text

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportIBBDossiers)


                _thSegmentationReport.LocationPath = LocationPath
                _thSegmentationReport.Juristid = dlg.cmbBehandelaar.SelectedValue
                _thSegmentationReport.QueryDate = dlg.dtpStart.Value
                _thSegmentationReport.DossierStatus = 1
                _thSegmentationReport.ReportTitel = "Overzicht gesloten dossiers vanaf " & dlg.dtpStart.Value.ToShortDateString
                _thSegmentationReport.ClosedIbbDossiers()
                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met overzicht......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BehandelarenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BehandelarenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("behandelaren", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DossiersPerIBBGroepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DossiersPerIBBGroepToolStripMenuItem.Click
        Try

            Dim dlg As New dlgIbbReports

            Dim LocationPath As String = ""
            dlg.Text = "Selecteer de opslag locatie..."
            dlg.cmbBehandelaar.Visible = False
            dlg.cmbRubriek.Visible = False
            dlg.cmbIBBGroep.Visible = True
            dlg.lblIBBGroep.Visible = True
            dlg.dtpStart.Visible = False
            dlg.lblVan.Visible = False
            dlg.bAtEveryone = True

            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = dlg.tbSavePath.Text

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportIBBDossiers)

                _thSegmentationReport.LocationPath = LocationPath
                _thSegmentationReport.IBBGroepId = dlg.cmbIBBGroep.SelectedValue
                ' _thSegmentationReport.Juristid = dlg.cmbBehandelaar.SelectedValue
                '_thSegmentationReport.RubriekId = dlg.cmbRubriek.SelectedValue
                _thSegmentationReport.QueryDate = New Date(2000, 1, 1)
                '_thSegmentationReport.DossierStatus = 0
                _thSegmentationReport.ReportTitel = "Overzicht dossiers IBB groep " & dlg.cmbIBBGroep.[Text]

                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met overzicht......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub IBBGroepenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IBBGroepenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("ibbgroepen", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        Dim check As New CheckIBBCalendar
        check.Process()

    End Sub

    Private Sub EwstestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EwstestToolStripMenuItem.Click
        Try
            Dim ChildForm As frmEWS = FindChild("frmEWS")
            If ChildForm Is Nothing Then
                ChildForm = New frmEWS
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
                If TypeName(Me.MenuStrip.Items(0)) = "SystemMenuItem" Then
                    Dim t As Long
                    t = Me.MenuStrip.Height
                    Me.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                    Me.MenuStrip.Height = t    'otherwise it goes too big.
                End If

            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OpTrefwoordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpTrefwoordToolStripMenuItem.Click
        Try

            Dim dlg As New dlgIbbReports

            Dim LocationPath As String = ""

            dlg.dtpStart.Value = Today.AddMonths(-12)
            dlg.Text = "Selecteer de opslag locatie..."
            dlg.dtpStart.Visible = True
            dlg.lblVan.Visible = False
            dlg.lblHandler.Text = "Zoekwoord"
            dlg.cmbBehandelaar.Visible = False
            dlg.tbSearchText.Location = dlg.cmbBehandelaar.Location ' 113; 61
            dlg.tbSearchText.Visible = True
            dlg.tbSearchText.BringToFront()


            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = dlg.tbSavePath.Text

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportIBBDossiersTrefwoord)

                _thSegmentationReport.QueryDate = dlg.dtpStart.Value

                Dim SearchText As String = dlg.tbSearchText.Text
                Dim myIbbDossiers As DataTable
                Dim param() As Object = {"@Subject", "%" & SearchText & "%", "@DateFrom", _thSegmentationReport.QueryDate}
                Dim sql As String = "SELECT * " &
                                    "FROM IBBDossiers " &
                                    "WHERE onderwerp LIKE @Subject AND CreateDate >= @DateFrom"

                myIbbDossiers = da.ExecuteDataTable(sql, param)
                myIbbDossiers.DefaultView.Sort = "CreateDate" & " ASC"
                _thSegmentationReport.IbbDossiers = myIbbDossiers
                _thSegmentationReport.LocationPath = LocationPath
                _thSegmentationReport.DossierStatus = 0
                _thSegmentationReport.ReportTitel = "Overzicht dossiers met ''" & SearchText & "'' in het onderwerp vanaf " & dlg.dtpStart.Value.ToShortDateString


                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met overzicht......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub MutatieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MutatieToolStripMenuItem.Click
        Try

            Dim dlg As New dlgIbbReports

            Dim LocationPath As String = ""
            dlg.Text = "Geef het aantal dagen voor de rapport selectie op."
            dlg.dtpStart.Visible = False
            dlg.lblVan.Visible = False
            dlg.lblHandler.Text = "Behandelaar"
            dlg.cmbBehandelaar.Visible = True
            dlg.bAtEveryone = True

            dlg.tbSearchText.Location = New Point(dlg.cmbBehandelaar.Location.X, dlg.lblHandler.Location.Y + dlg.lblHandler.Size.Height + 15)
            dlg.tbSearchText.Visible = True
            dlg.tbSearchText.Width = 50
            dlg.tbSearchText.Text = 90
            dlg.tbSearchText.BringToFront()

            Dim lbAantal As New Label
            lbAantal.Location = New Point(dlg.lblHandler.Location.X, dlg.lblHandler.Location.Y + dlg.lblHandler.Size.Height + 20)
            lbAantal.Text = "Ouder dan.."
            lbAantal.AutoSize = True
            dlg.Controls.Add(lbAantal)


            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                LocationPath = dlg.tbSavePath.Text

                Dim Aantal As Integer
                Aantal = dlg.tbSearchText.Text

                Dim paramlist As New ArrayList

                ' Dim sql As String = "SELECT * FROM IBBDossiers Where Mutdate < @MutDdate "
                Dim sql As String = "SELECT DossierNr, b.Naam as behandelaar, Onderwerp, CreateDate, EndDate, MutDate as [laatste mutatie]  " &
                                    "FROM [dbo].[IBBDossiers] " &
                                    "left JOIN Behandelaren B on B.Id = [BehandelaarId] " &
                                    "Where Mutdate < @MutDdate AND Afgehandeld <> 1"

                If dlg.cmbBehandelaar.SelectedIndex > 0 Then
                    paramlist.Add("@behandelaarId")
                    paramlist.Add(dlg.cmbBehandelaar.SelectedValue)
                    sql = sql & "AND behandelaarId = @behandelaarId "
                End If
                sql = sql & "ORDER BY mutdate"

                Dim myexcel As New MyExcel
                paramlist.Add("@MutDdate")
                paramlist.Add(Now.AddDays(-Aantal))

                Dim dt As DataTable = da.ExecuteDataTable(sql, paramlist.ToArray)

                myexcel.ExcelWrite(LocationPath & "\IBB Mutaties_" & dlg.cmbBehandelaar.SelectedValue & "_" & Format(Now, "yyyyMMdd") & ".xlsx", dt, True)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub TermijnenPerMailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermijnenPerMailToolStripMenuItem.Click
        Try

            Dim dlgAsk As New dlgAskIt
            dlgAsk.StartPosition = FormStartPosition.CenterScreen
            dlgAsk.Height = 150

            Dim mylabel As New Label
            mylabel.Location = New Point(dlgAsk.Location.X + 20, 20)
            mylabel.Text = "email sturen naar:"
            mylabel.AutoSize = True
            dlgAsk.Controls.Add(mylabel)

            Dim lbl As New Label
            lbl.Location = New Point(mylabel.Location.X, mylabel.Location.Y + mylabel.Size.Height + 20)
            lbl.Text = "Behandelaar"
            lbl.AutoSize = True
            dlgAsk.Controls.Add(lbl)

            Dim tblBehandelaren As DataTable = da.ExecuteDataTable("SELECT * FROM behandelaren ORDER BY naam")

            Dim cmbBehandelaar As New ComboBox
            cmbBehandelaar.Name = "cmbBehandelaar"
            cmbBehandelaar.DataSource = tblBehandelaren
            cmbBehandelaar.DisplayMember = "Naam"
            cmbBehandelaar.ValueMember = "Id"
            cmbBehandelaar.Location = New Point(lbl.Size.Width + 30, lbl.Location.Y - 5)
            cmbBehandelaar.Width = 100
            dlgAsk.Controls.Add(cmbBehandelaar)

            If dlgAsk.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim cmbBehandelaar1 As New ComboBox
                cmbBehandelaar1 = dlgAsk.Controls.Item("cmbBehandelaar")

                My.Settings.ReportsPath = fbdSave.SelectedPath
                My.Settings.Save()

                Ready = False
                Me.Cursor = Cursors.WaitCursor

                _thSegmentationReport = New SegmentationReport
                Dim thGenerate As New System.Threading.Thread(AddressOf _thSegmentationReport.ReportHTMLIBBTermijnen)
                '_thSegmentationReport.DateOut = New Date(Now.Year, Now.Month, Now.Day)

                If cmbBehandelaar1.SelectedValue > 0 Then
                    _thSegmentationReport.ReportBehandelaarId = cmbBehandelaar1.SelectedValue
                End If

                '_thSegmentationReport.LocationPath = LocationPath
                thGenerate.Start()

                Dim frm As New frmWait
                frm.lbMessage.Text = "Bezig met overzicht......"
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowInTaskbar = False
                frm.TopMost = True
                frm.pbTaskProgress.Maximum = 1000
                frm.Show()
                My.Application.DoEvents()

                Dim iPadright As Integer = 1
                Dim sPadRight As String = String.Empty
                While Ready = False
                    iPadright += 1
                    If iPadright = 25 Then
                        frm.Tmr_Tick()
                        iPadright = 1

                    End If
                    frm.lbMessage.Text = Status & iCounter & " van " & iCounterTotal
                    frm.Refresh()
                    If Status.Contains("ERROR") Then frm.DialogResult = Windows.Forms.DialogResult.Cancel
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        _thSegmentationReport.IsTerminating = True
                        thGenerate.Join()
                        Me.Cursor = Cursors.Default
                        Exit While
                    End If
                    My.Application.DoEvents()
                End While

                frm.pbTaskProgress.Value = 1000
                frm.btnOk.Visible = True
                frm.btnCancel.Visible = False
                frm.lbMessage.Text = Status
                frm.Refresh()

                Me.Cursor = Cursors.Default

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FontSizeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles FontSizeToolStripMenuItem.Click

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

    Private Sub PermissionTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermissionTestToolStripMenuItem.Click
        Dim rechten As New clsPermission
        rechten.setIBBPermissions("20170000")
    End Sub

    Private Sub DDTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DDTestToolStripMenuItem.Click
        Try
            Dim ChildForm As dlgDragDrop = FindChild("dlgDragDrop")
            If ChildForm Is Nothing Then
                ChildForm = New dlgDragDrop
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
                If TypeName(Me.MenuStrip.Items(0)) = "SystemMenuItem" Then
                    Dim t As Long
                    t = Me.MenuStrip.Height
                    Me.MenuStrip.Items(0).Image = ChildForm.Icon.ToBitmap
                    Me.MenuStrip.Height = t    'otherwise it goes too big.
                End If

            Else
                ChildForm.Activate()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            If File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\merge.txt") Then File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\merge.txt")

            If File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\mailing.txt") Then File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\mailing.txt")

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ImportExportNPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportExportNPToolStripMenuItem.Click
        Try
            Dim ChildForm As frmAnpvProcess = FindChild("frmAnpvProcess")
            If ChildForm Is Nothing Then
                ChildForm = New frmAnpvProcess
                ChildForm.MdiParent = Me
                ChildForm.WindowState = FormWindowState.Maximized
                m_ChildFormNumber += 1
                ChildForm.Show()
            Else
                ChildForm.Activate()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RubriekenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubriekenToolStripMenuItem.Click
        Try
            Dim frm As New MaintenanceStd("rubrieken", sender.text)
            frm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
