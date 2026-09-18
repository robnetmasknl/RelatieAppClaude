Imports BusinessObjects
Imports System.Data.SqlClient


Public Class frmMaintenanceTemplates
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess
    Private cmd As SqlCommand
    Private adp As SqlDataAdapter
    Private ds As DataSet
    Public Maintain As String = String.Empty


    Private _DefaultLocation As String = String.Empty
    Public ReadOnly Property DefaultLocation() As String
        Get

            If String.IsNullOrEmpty(_DefaultLocation) Then
                Dim sys As New Systeeminstellingen("TemplatePath", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _DefaultLocation = sys.Waarde
            End If
            Return _DefaultLocation
        End Get
    End Property

    Private Sub frmMaintenanceTemplates_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ds.HasChanges Then

            If MessageBox.Show("Er zijn nog niet opgeslagen gegevens. Als u doorgaat gaan deze verloren." _
                               & vbCrLf & "Weet u zeker dat u wilt sluiten?", "Exit", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Question) = DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmMaintenanceTemplates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If URights.IsInGroup("rel_admins") Then
                'ga dan door
                'ElseIf URights.IsInGroup("rel_users") Then
                'ga dan door
                'ElseIf URights.IsInGroup("rel_readers") Then
                '    'dan alleen lezen
                '    EnabledDisabledFormControls(Me, False)
            Else
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''rel_admins''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            End If

            ProcessTemplates()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub New()

        InitializeComponent()
        Me.CenterToParent()
        Maintain = "Templates"
        Me.Text = "Onderhoud " & Maintain

    End Sub

    Private Sub ProcessTemplates()
        Try

            Dim sql As String = "SELECT * FROM Templates ORDER BY Naam"
            cmd = New SqlCommand(sql, da.GetConnection)
            adp = New SqlDataAdapter(cmd)
            ds = New DataSet
            adp.Fill(ds, Maintain)
  

            dgvTemplates.DataSource = ds
            dgvTemplates.DataMember = Maintain

            dgvTemplates.Columns("id").Visible = True
            dgvTemplates.Columns("id").ReadOnly = True
            dgvTemplates.Columns("Naam").ReadOnly = True
            dgvTemplates.Columns("Omschrijving").ReadOnly = True
            dgvTemplates.Columns("locatie").ReadOnly = True
            dgvTemplates.Columns("Afdeling").ReadOnly = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvTemplates_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemplates.CellClick
        Try
            Dim gr As New DataGridView
            gr = sender

            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                If TypeOf (gr.Rows(e.RowIndex).Cells(e.ColumnIndex)).OwningColumn Is DataGridViewButtonColumn Then
                    With Me.OpenFileDialog1
                        .Reset()
                        'If String.IsNullOrEmpty(gr.Rows(e.RowIndex).Cells("locatie").Value.ToString) Then
                        '    .InitialDirectory = Application.StartupPath
                        'Else
                        .InitialDirectory = DefaultLocation
                        'gr.Rows(e.RowIndex).Cells("locatie").Value.ToString()
                        'End If

                        .AddExtension = True
                        .CheckFileExists = True
                        .CheckPathExists = True
                        .DefaultExt = "dot"
                        .Filter = "sjablonen (*.dot)|*.dot|" & "documenten|*.doc|" & "documenten|*.docx|" & "sjablonen|*.dotx|" & "email|*.html"
                        .Multiselect = False
                        .Title = "Select a file"
                        .ValidateNames = True
                        If .ShowDialog() = DialogResult.OK Then
                            'probeer de afdeling te achterhalen.
                            Dim location As String = .FileName.Substring(0, .FileName.LastIndexOf("\") + 1)
                            If location.Length < DefaultLocation.Length Then
                                Throw New Exception("standaard template folder komt niet overeen met uw gekozen loatie!")
                            End If
                            If location.Substring(0, DefaultLocation.Length).ToLower <> DefaultLocation.ToLower Then
                                Throw New Exception("standaard template folder komt niet overeen met uw gekozen locatie!")
                            End If
                            Dim department As String = location.Substring(DefaultLocation.Length, location.Length - DefaultLocation.Length)
                            If department.EndsWith("\") Then
                                department = department.Substring(0, department.LastIndexOf("\"))
                            End If
                            gr.Rows(e.RowIndex).Cells("locatie").Value = location
                            gr.Rows(e.RowIndex).Cells("Naam").Value = .SafeFileName
                            gr.Rows(e.RowIndex).Cells("Omschrijving").Value = InputBox("Geef een korte omschrijving", .SafeFileName, .SafeFileName)
                            gr.Rows(e.RowIndex).Cells("Bond").Value = "0"
                            gr.Rows(e.RowIndex).Cells("Afdeling").Value = department

                            SelectNextRow(e.RowIndex)
                            btnSave_Click(sender, New EventArgs)
                        End If
                    End With
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SelectNextRow(ByVal idx As Integer)
        Try
            'dgvTemplates.CurrentCell = dgvTemplates.Rows(idx + 1).Cells(1)
            'dgvTemplates.Rows(idx + 1).Cells(1).Selected = True
            If idx + 1 >= dgvTemplates.Rows.Count Then
                dgvTemplates.CurrentCell = dgvTemplates.Rows(0).Cells(3)
            Else
                dgvTemplates.CurrentCell = dgvTemplates.Rows(idx + 1).Cells(3)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim cmdbuilder As New SqlCommandBuilder(adp)
            Dim i As Integer
            i = adp.Update(ds, Maintain)
            MessageBox.Show("Aantal geupdate: " & i, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProcessTemplates()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class