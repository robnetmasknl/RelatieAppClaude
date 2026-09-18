Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgJdPhase
    Private da As New DataAccess
    Private FaseSeq As Integer = -1
    Private DossierId As Integer = -1
    Private Sort As String = String.Empty
    Public Sub New(ByVal bydossierid As Integer, Optional ByVal byFaseSeq As Integer = -1, Optional bySort As String = "K")

        InitializeComponent()
        FaseSeq = byFaseSeq
        DossierId = bydossierid
        Sort = bySort

    End Sub
    Private Sub Changelayout()
        Dim style As FontStyle = CInt(da.Settings.FontStyle)
        Dim newFont As Font = New System.Drawing.Font(da.Settings.FontFamily, da.Settings.FontSize, style)
        Me.Font = newFont
    End Sub
    Private Sub dlgJdPhase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Changelayout()
            Dim param() As Object = {"@nextSeq", FaseSeq, "@sort", Sort}
            Dim tblTypes As DataTable = da.ExecuteDataTable("SELECT * FROM jdTypes Where (seq > @nextSeq Or (seq = 0 OR seq > 20) ) And Sort = @sort Order By seq", param)

            cmbTypes.DataSource = tblTypes
            cmbTypes.DisplayMember = "Description"
            cmbTypes.ValueMember = "Type"
            'cmbTypes.SelectedValue = "Type"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Function FaseTypeId(FaseType As String) As Integer
        Try
            Dim result As Integer = -1
            Dim param() As Object = {"@Type", FaseType}
            result = da.ExecuteScalar("SELECT Id FROM jdTypes Where Type = @Type", param)
            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK

            If cmbTypes.SelectedValue = "VRZ" Then
                Dim dlgPetition As New dlgJdTypePetition(DossierId)
                dlgPetition.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgPetition.ShowDialog()
                Me.DialogResult = dlgPetition.DialogResult
            ElseIf cmbTypes.SelectedValue = "VN" Then
                Dim dlgJdTypeVnV As New dlgJdTypeVnV(DossierId)
                dlgJdTypeVnV.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgJdTypeVnV.ShowDialog()
                Me.DialogResult = dlgJdTypeVnV.DialogResult
            ElseIf cmbTypes.SelectedValue = "BF" Then
                Dim dlgObjection As New dlgJdTypeObjection(DossierId)
                dlgObjection.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgObjection.ShowDialog()
                Me.DialogResult = dlgObjection.DialogResult
            ElseIf cmbTypes.SelectedValue = "RB" Then
                Dim dlgCourt As New dlgJdTypeCourt(DossierId)
                dlgCourt.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgCourt.ShowDialog()
                Me.DialogResult = dlgCourt.DialogResult
            ElseIf cmbTypes.SelectedValue = "CRVB" Then
                Dim dlgCentralBoard As New dlgJdCentralBoard(DossierId)
                dlgCentralBoard.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgCentralBoard.ShowDialog()
                Me.DialogResult = dlgCentralBoard.DialogResult
            ElseIf cmbTypes.SelectedValue = "KL" Then
                Dim dlgTypeComplaint As New dlgJdTypeComplaint(DossierId)
                dlgTypeComplaint.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgTypeComplaint.ShowDialog()
                Me.DialogResult = dlgTypeComplaint.DialogResult
            ElseIf cmbTypes.SelectedValue = "NO" Then
                Dim dlgTypeOnbudsman As New dlgJdTypeOnbudsman(DossierId)
                dlgTypeOnbudsman.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgTypeOnbudsman.ShowDialog()
                Me.DialogResult = dlgTypeOnbudsman.DialogResult
            ElseIf cmbTypes.SelectedValue = "CLM" Then
                Dim dlgJdTypeClaim As New dlgJdTypeClaim(DossierId)
                dlgJdTypeClaim.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgJdTypeClaim.ShowDialog()
                Me.DialogResult = dlgJdTypeClaim.DialogResult
            Else
                Dim dlgPetition As New dlgJdTypePetition(DossierId)
                dlgPetition.FaseTypeId = FaseTypeId(cmbTypes.SelectedValue)
                dlgPetition.Text = cmbTypes.SelectedText
                dlgPetition.ShowDialog()
                Me.DialogResult = dlgPetition.DialogResult
            End If



            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try

    '        If String.IsNullOrEmpty(uctdDecisionDate.tb.Text) Then
    '            Throw New Exception("De besluitdatum is niet correct ingevuld!")
    '        End If
    '        If Not IsNumeric(tbObjectionPeriod.Text) Then
    '            Throw New Exception("De bezwaar periode is niet correct ingevuld!")
    '        End If

    '        Dim iObjectionPeriod As Integer = tbObjectionPeriod.Text
    '        Dim DecisionDate As Date = uctdDecisionDate.Value
    '        Dim ObjectionDate As Date = DecisionDate.AddDays(iObjectionPeriod * 7)
    '        uctdObjectionDate.Value = ObjectionDate

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


End Class
