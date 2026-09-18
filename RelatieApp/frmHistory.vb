Imports BusinessObjects
Imports System.Data.SqlClient

Public Class frmHistory
    Private da As New DataAccess

    Private cmd As SqlCommand
    Private adp As SqlDataAdapter
    Private ds As New DataSet

    Public Sub New(ByVal relatieId As Integer, Optional ByRef fromIbb As Boolean = False)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CenterToParent()
        Try
            ProcessHistory(relatieId, fromIbb)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub ProcessHistory(ByVal relatieId As Integer, ByRef fromIbb As Boolean)
        Try
            Dim _HistoryList As List(Of History)
            Dim _History As New History
            Dim ohelper As New Helper
            Dim HistoryFilter As String = """IBB*"""
            Dim sql As String = ""
            If fromIbb Then
                sql = "SELECT * FROM History WHERE lidid =  @relatieId AND CONTAINS(TableName,  @Filter) ORDER BY MutDate DESC"
            Else
                sql = "SELECT * FROM History WHERE lidid =  @relatieId AND NOT CONTAINS(TableName,  @Filter) ORDER BY MutDate DESC"
            End If

            Dim param() As Object = {"@relatieId", relatieId, "@Filter", HistoryFilter}
            _HistoryList = ohelper.MapDataTableToList(Of History)(_History.GetList(Sql, param))

            With dgvHistory
                dgvHistory.EditMode = DataGridViewEditMode.EditProgrammatically
                .DataSource = _HistoryList
                .Columns("Found").Visible = False
                .Columns("id").Visible = False
                .Columns("LidId").Visible = False
                .Columns("MutDate").HeaderText = "gewijzigd op"
                .Columns("MutDoor").HeaderText = "gewijzigd door"
                .Columns("TableName").HeaderText = "tabelnaam"
                .Columns("Veld").HeaderText = "Veldnaam"
                .Columns("WaardeOud").HeaderText = "Oude_waarde"
                .Columns("WaardeNieuw").HeaderText = "Nieuwe_waarde"
            End With
            dgvHistory.AutoResizeColumns()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class