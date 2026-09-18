Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgIbbReports
    Private da As New DataAccess
    Public bAtEveryone As Boolean = False

    Private Sub dlgIbbReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not My.Settings.ReportsPath = "" Then
            tbSavePath.Text = My.Settings.ReportsPath
        End If

        Dim tblBehandelaren As DataTable = da.ExecuteDataTable("SELECT * FROM behandelaren ORDER BY naam")
        Dim tblRubrieken As DataTable = da.ExecuteDataTable("SELECT * FROM IBBRubrieken ORDER BY Rubriek")
        Dim tblIBBGroepen As DataTable = da.ExecuteDataTable("SELECT * FROM IBBGroepen ORDER BY Groep")

        Dim drRubriek As DataRow = tblRubrieken.NewRow
        drRubriek("id") = 0
        drRubriek("Rubriek") = "Allen"
        tblRubrieken.Rows.InsertAt(drRubriek, 0)

        cmbRubriek.DataSource = tblRubrieken
        cmbRubriek.DisplayMember = "rubriek"
        cmbRubriek.ValueMember = "id"

        Dim drIBBGroep As DataRow = tblIBBGroepen.NewRow
        drIBBGroep("id") = 0
        drIBBGroep("Groep") = "Zonder groep"
        tblIBBGroepen.Rows.InsertAt(drIBBGroep, 0)

        cmbIBBGroep.DataSource = tblIBBGroepen
        cmbIBBGroep.DisplayMember = "Groep"
        cmbIBBGroep.ValueMember = "id"

        If bAtEveryone Then
            Dim dr As DataRow = tblBehandelaren.NewRow
            dr("id") = 0
            dr("Naam") = "Iedereen"
            tblBehandelaren.Rows.InsertAt(dr, 0)
        End If

        cmbBehandelaar.DataSource = tblBehandelaren
        cmbBehandelaar.DisplayMember = "Naam"
        cmbBehandelaar.ValueMember = "id"

        ' dtpStart.Value = Today

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim LocationPath As String = ""
            fbdSave.Description = "Selecteer de opslag locatie..."

            If Not My.Settings.ReportsPath = "" Then
                fbdSave.SelectedPath = My.Settings.ReportsPath
                fbdSave.Description = "huidige opslag locatie..." & vbCrLf & vbCrLf & fbdSave.SelectedPath
            End If

            If fbdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                LocationPath = fbdSave.SelectedPath
                My.Settings.ReportsPath = fbdSave.SelectedPath
                My.Settings.Save()
                tbSavePath.Text = LocationPath
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


End Class
