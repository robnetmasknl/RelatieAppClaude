Imports BusinessObjects

Public Class frmIBBDossierSearchSmall
    Private lstDossiernr As New List(Of String)
    Private DossierSource As New AutoCompleteStringCollection()

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim myDossier As New IBBDossier
            myDossier = New IBBDossier(tbDossierNr.Text, IBBDossier.VIA.DOSSIERNR)
            If myDossier.Found Then
                Dim ChildForm As New frmIBBDossier
                ChildForm.MdiParent = Main
                ChildForm.WindowState = FormWindowState.Maximized
                ChildForm.MyIBBDossier = New IBBDossier(myDossier.Id, IBBDossier.VIA.ID)
                ChildForm.Show()
            Else

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmIBBDossierSearchSmall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim da As New DataAccess
        lstDossiernr = da.GetListOfString("Select dossiernr from IBBDossiers")
        DossierSource.AddRange(lstDossiernr.ToArray)
        tbDossierNr.AutoCompleteCustomSource = DossierSource
        tbDossierNr.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        tbDossierNr.AutoCompleteSource = AutoCompleteSource.CustomSource

    End Sub
    'Private Sub tbDossierNr_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbDossierNr.KeyDown

    '    If e.KeyCode = Keys.Enter Then   ' On enter I planned to add it the list
    '        If Not lst.Contains(tbDossierNr.Text) Then  ' If item not present already
    '            ' Add to the source directly
    '            tbDossierNr.AutoCompleteCustomSource.Add(tbDossierNr.Text)
    '        End If
    '    ElseIf e.KeyCode = Keys.Delete Then 'On delete key, planned to remove entry

    '        ' declare a dummy source
    '        Dim coll As AutoCompleteStringCollection = tbDossierNr.AutoCompleteCustomSource

    '        ' remove item from new source
    '        coll.Remove(tbDossierNr.Text)

    '        ' Bind the updates
    '        tbDossierNr.AutoCompleteCustomSource = coll

    '        ' Clear textbox
    '        tbDossierNr.Clear()

    '    End If                   ' End of ‘KeyCode’ condition

    'End Sub
End Class