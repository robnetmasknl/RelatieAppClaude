Imports System.Windows.Forms
Imports BusinessObjects

Public Class dlgDocumentUpload
    Enum Via
        RELATIE
        IBB
        IBBEXT
    End Enum
    Private URights As UserRights = UserRights.Instance
    Private da As New DataAccess
    Private UploadType As String = String.Empty
    Private FaseTypeId As Integer = -1
    Private MySearchId As Integer = -1
    Private DossierPath As IO.DirectoryInfo
    Private _MyFase As IBBFase
    Public Property MyFase() As IBBFase
        Get
            If IsNothing(_MyFase) Then
                _MyFase = New IBBFase(FaseTypeId, IBBFase.Via.ID)
            End If

            Return _MyFase
        End Get
        Set(ByVal value As IBBFase)
            _MyFase = value
        End Set
    End Property
    Private _MyRelatie As Relaties
    Public Property MyRelatie() As Relaties
        Get
            If _MyRelatie Is Nothing Then
                _MyRelatie = New Relaties(MySearchId, Relaties.Via.ID)
            End If

            Return _MyRelatie
        End Get
        Set(ByVal value As Relaties)
            _MyRelatie = value
        End Set
    End Property
    Private _MyIBBDossier As IBBDossier
    Public ReadOnly Property MyIBBDossier() As IBBDossier
        Get
            If IsNothing(_MyIBBDossier) Then
                _MyIBBDossier = New IBBDossier(MySearchId, IBBDossier.VIA.ID)
            End If
            Return _MyIBBDossier
        End Get
    End Property

    Public Sub New(ByVal id As String, ByVal Via As Via, Optional ByVal byfasetypeid As Integer = -1)
        InitializeComponent()
        If Via = dlgDocumentUpload.Via.RELATIE Then
            UploadType = "RELATIE"
            cmbFases.Visible = False
            chkConcept.Visible = False
            lblFase.Visible = False
            MySearchId = id
        ElseIf Via = dlgDocumentUpload.Via.IBB Then
            UploadType = "IBB"
            FaseTypeId = byfasetypeid
            MySearchId = id
            chkConcept.Visible = True
            cmbFases.Visible = True
            lblFase.Visible = True

            'Dim sql As String = "SELECT fs.Id, jd.Description + '; '+ convert(VARCHAR,fs.Indiendatum ,111 ) as omschrijving, jd.Type, fs.DossierId, jd.Seq FROM IBBFases fs " & _
            '          "inner join jdTypes jd on fs.TypeId = jd.Id " & _
            '          "where DossierId = @DossierId " & _
            '          "order by jd.seq "
            Dim sql As String = "SELECT distinct jd.Description, fs.TypeId ,jd.seq FROM IBBFases fs " & _
                      "inner join jdTypes jd on fs.TypeId = jd.Id " & _
                      "where DossierId = @DossierId " & _
                      "order by jd.seq "
            Dim param() As Object = {"@DossierId", MyIBBDossier.Id}
            Dim tblTypes As DataTable = da.ExecuteDataTable(sql, param)

            Dim dr2 As DataRow = tblTypes.NewRow
            dr2("TypeId") = 0
            dr2("Description") = "geen"
            tblTypes.Rows.InsertAt(dr2, 0)

            cmbFases.DataSource = tblTypes
            cmbFases.DisplayMember = "Description"
            cmbFases.ValueMember = "TypeId"


            'Dim sql As String = "select * " & _
            '                    "from ibbfases ibb " & _
            '                    "right join jdTypes t on ibb.TypeId = t.Id " & _
            '                    "where dossierid = @dossierid"

            'Dim param() As Object = {"@dossierid", MySearchId}
            'Dim tblFases As DataTable = da.ExecuteDataTable(sql, param)
            'cmbFases.DataSource = tblFases
            'cmbFases.DisplayMember = "Description"
            'cmbFases.ValueMember = "TypeId"
            'cmbFases.SelectedValue = MyFase.TypeId


        ElseIf Via = dlgDocumentUpload.Via.IBBEXT Then
            UploadType = "IBBEXT"
            FaseTypeId = byfasetypeid
            MySearchId = id
            cmbFases.Visible = False
            chkConcept.Visible = False
            lblFase.Visible = False

        End If
    End Sub

    Private Sub dlgDocumentUpload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not My.Settings.ReportsPath = "" Then
            Me.tbSelectedFile.Text = My.Settings.ReportsPath
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Process()
            ' tbSelectedFile.Text
            If ofFile.FileName.Length > 0 Then
                My.Settings.ReportsPath = tbSelectedFile.Text.Substring(0, tbSelectedFile.Text.Length - ofFile.SafeFileName.Length)
            End If

            My.Settings.Save()

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Process()
        Try

            If UploadType = "RELATIE" Then
                ProcessRelatie()
            ElseIf UploadType = "IBB" Then
                ProcessIBB()
            ElseIf UploadType = "IBBEXT" Then
                ProcessIBBEXT()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ProcessRelatie()
        Try
            Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("FileSave", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            If Not DocumentPathSetting.Found Then Throw New Exception("Geen Systeeminstellingen FileSave gevonden!")
            Dim DocumentPath As String = DocumentPathSetting.Waarde & "\"

            Dim File2Copy As New IO.FileInfo(tbSelectedFile.Text)
            DossierPath = New IO.DirectoryInfo(DocumentPath & MyRelatie.Id)
            If Not DossierPath.Exists Then
                DossierPath.Create()
            End If
            File2Copy.CopyTo(DossierPath.FullName & "\" & File2Copy.Name)
            Dim NewDocument As New Documents
            With NewDocument
                .CreateDate = Now
                .CreatedBy = URights.UserName
                .Location = DossierPath.FullName & "\" & File2Copy.Name
                .RefID = tbOnderwerp.Text
                .LidId = MyRelatie.Id
                '.Template = ofFile.FileName
                .Save()
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ProcessIBB(Optional bMove As Boolean = False)
        Try
            Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            If Not DocumentPathSetting.Found Then Throw New Exception("Geen Systeeminstellingen voor IBBFiles gevonden!")
            Dim DocumentPath As String = DocumentPathSetting.Waarde & "\"

            Dim selectedFase As Integer = cmbFases.SelectedValue
            Dim File2Copy As New IO.FileInfo(tbSelectedFile.Text)
            DossierPath = New IO.DirectoryInfo(DocumentPath & MyIBBDossier.DossierNr)
            If Not DossierPath.Exists Then
                DossierPath.Create()
            End If
            If bMove Then
                File2Copy.MoveTo(DossierPath.FullName & "\" & File2Copy.Name)
            Else
                File2Copy.CopyTo(DossierPath.FullName & "\" & File2Copy.Name)
            End If
            's
            Dim newDocument As New IBBDocument
            With newDocument
                .Location = DossierPath.FullName & "\" & File2Copy.Name
                .jdTypeId = selectedFase
                .DossierId = MySearchId
                .Onderwerp = tbOnderwerp.Text
                .CreateDate = Now
                .CreatedBy = URights.UserName
                .Concept = chkConcept.Checked
                .LocationType = "IBB"
                .Save()
                'FillDocuments(.jdTypeId)

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ProcessIBBEXT()
        Try
            Dim DocumentPathSetting As Systeeminstellingen = New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
            If Not DocumentPathSetting.Found Then Throw New Exception("Geen Systeeminstellingen voor IBBFiles gevonden!")
            Dim DocumentPath As String = DocumentPathSetting.Waarde & "\"

            Dim selectedFase As Integer = cmbFases.SelectedValue
            Dim File2Copy As New IO.FileInfo(tbSelectedFile.Text)
            Dim DossierPath As New IO.DirectoryInfo(DocumentPath & MyIBBDossier.DossierNr & "\Extern")
            If Not DossierPath.Exists Then
                DossierPath.Create()
            End If
            File2Copy.CopyTo(DossierPath.FullName & "\" & File2Copy.Name)
            Dim newDocument As New IBBDocument
            With newDocument
                .Location = DossierPath.FullName & "\" & File2Copy.Name
                .jdTypeId = selectedFase
                .DossierId = MySearchId
                .Onderwerp = tbOnderwerp.Text
                .CreateDate = Now
                .CreatedBy = URights.UserName
                .Concept = chkConcept.Checked
                .LocationType = "Extern"
                .Save()
                'FillDocuments(.jdTypeId)

            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        Try
            If Not My.Settings.ReportsPath = "" Then
                ofFile.InitialDirectory = My.Settings.ReportsPath
            End If

            If ofFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.tbSelectedFile.Text = ofFile.FileName
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Dim ModuleName As String = Me.Name
        Try
            OpenHelpUrl(ModuleName)
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
