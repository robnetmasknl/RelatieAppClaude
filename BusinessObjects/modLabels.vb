Imports System.Windows.Forms
Imports System.Xml

Public Module modLabels
    Dim LabelPathName As String = System.Windows.Forms.Application.StartupPath & "\Labels.xml"

    Private _label_XmlDocument As XmlDocument
    Public Property label_XmlDocument() As XmlDocument
        Get
            Return _label_XmlDocument
        End Get
        Set(ByVal value As XmlDocument)
            _label_XmlDocument = value
        End Set
    End Property

    Private _CreateDefaultLabelsSet As Boolean = False
    Private _CreateDefaultLabels As Boolean = False
    Public ReadOnly Property CreateDefaultLabels() As Boolean
        Get
            Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(LabelPathName)
            'Als Labels niet bestaat dan overslaan
            If Not FileInfo.Exists Then Return False

            If _CreateDefaultLabelsSet = False Then
                Dim result As String = GetXmlValue("Create", "false", "CreateDefaultLabels")
                _CreateDefaultLabelsSet = True
                If result.ToString.ToLower = "true" Then
                    _CreateDefaultLabels = True
                Else

                End If
            End If
            Return _CreateDefaultLabels
        End Get
    End Property
    Public Sub GetLabelText(ByVal myControl As Control, ByVal frmname As String)

        Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(LabelPathName)
        'Als Labels niet bestaat dan overslaan
        If Not FileInfo.Exists Then Exit Sub

        For Each ctl As Control In myControl.Controls
            If TypeOf ctl Is Label Then
                ctl.Text = GetXmlValue(ctl.Name, ctl.Text, frmname)
            ElseIf TypeOf ctl Is CheckBox Then
                ctl.Text = GetXmlValue(ctl.Name, ctl.Text, frmname)
            ElseIf TypeOf ctl Is RadioButton Then
                ctl.Text = GetXmlValue(ctl.Name, ctl.Text, frmname)
            End If

            If ctl.GetType().ToString = "System.Windows.Forms.TabControl" Or
                ctl.GetType().ToString = "System.Windows.Forms.SplitContainer" Or
                ctl.GetType().ToString = "System.Windows.Forms.SplitterPanel" Or
                ctl.GetType().ToString = "System.Windows.Forms.TabPage" Or
                ctl.GetType().ToString = "System.Windows.Forms.GroupBox" Or
                ctl.GetType().ToString = "System.Windows.Forms.Panel" Or
                ctl.GetType().ToString.Contains("ucTextDate") Then
                Call GetLabelText(ctl, frmname)
            End If
        Next
    End Sub
    Public Sub GetHeaderText(ByVal myGrid As DataGridView, ByVal frmname As String)

        Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(LabelPathName)
        'Als Labels niet bestaat dan overslaan
        If Not FileInfo.Exists Then Exit Sub

        For Each col In myGrid.Columns
            col.HeaderText = GetXmlValue("col_" & col.Name, col.HeaderText, frmname)
        Next

    End Sub
    Public Sub GetMenuText(ByVal myItems As ToolStripDropDownItem, ByVal frmname As String)

        Dim FileInfo As System.IO.FileInfo = New System.IO.FileInfo(LabelPathName)
        'Als Labels niet bestaat dan overslaan
        If Not FileInfo.Exists Then Exit Sub

        For Each item As ToolStripDropDownItem In myItems.DropDownItems
            item.Text = GetXmlValue("mnuItem_" & item.Name, item.Text, frmname)
        Next

    End Sub
    Public Function GetXmlValue(ByVal Key As String, ByVal defaultvalue As String, ByVal parentvalue As String) As String
        If label_XmlDocument Is Nothing Then
            label_XmlDocument = New XmlDocument
            Dim oReader As IO.StreamReader = New IO.StreamReader(LabelPathName, System.Text.Encoding.GetEncoding("ISO-8859-1"))
            label_XmlDocument.Load(oReader)
        End If

        Dim sReturn As String = defaultvalue

        Dim labelnode As XmlNode
        labelnode = label_XmlDocument.SelectSingleNode("//Forms/" & parentvalue)
        If Not labelnode Is Nothing Then
            Dim labelnodekey As XmlNode = labelnode.SelectSingleNode(Key)

            If Not labelnodekey Is Nothing Then
                Return labelnodekey.InnerText
            End If
        End If

        Return sReturn
    End Function

    Dim LabelDoc As XmlDocument
    Dim DocRoot As XmlNode
    Dim FrmNameNode As XmlNode
    Public Sub CreateRootXml(ByVal frmname As String)
        LabelDoc = New XmlDocument
        Dim root As XmlNode = LabelDoc.DocumentElement
        DocRoot = LabelDoc.CreateElement("Forms")
        FrmNameNode = LabelDoc.CreateElement(frmname)
        DocRoot.AppendChild(FrmNameNode)
    End Sub
    Public Sub CreateLabelXml(ByVal myControl As Control, ByVal frmname As String, bNewDoc As Boolean)
        If LabelDoc Is Nothing Or bNewDoc = True Then
            CreateRootXml(frmname)
        End If

        If TypeOf myControl Is DataGridView Then
            CreateColumnXmlnodes(myControl, frmname)
        Else
            CreateLabelXmlnodes(myControl, frmname)
        End If

        LabelDoc.AppendChild(DocRoot)

        Dim DefaultLabelsPathName As String = System.Windows.Forms.Application.StartupPath & "\_DefaultLabels_" & frmname & ".xml"
        LabelDoc.Save(DefaultLabelsPathName)

    End Sub
    Public Sub CreateMenulXml(ByVal myControl As ToolStripDropDownItem, ByVal frmname As String, bNewDoc As Boolean)
        If LabelDoc Is Nothing Or bNewDoc = True Then
            CreateRootXml(frmname)
        End If

        CreateMenuXmlnodes(myControl, frmname)

        LabelDoc.AppendChild(DocRoot)

        Dim DefaultLabelsPathName As String = System.Windows.Forms.Application.StartupPath & "\_DefaultLabels_" & frmname & ".xml"
        LabelDoc.Save(DefaultLabelsPathName)

    End Sub
    Public Sub CreateLabelXmlnodes(ByVal myControl As Control, ByVal frmname As String)


        For Each ctl As Control In myControl.Controls
            'If String.IsNullOrEmpty(ctl.Text) Then Continue For

            If TypeOf ctl Is Label Then
                FrmNameNode.AppendChild(CreateNode(LabelDoc, ctl.Name, ctl.Text))
            ElseIf TypeOf ctl Is CheckBox Then
                FrmNameNode.AppendChild(CreateNode(LabelDoc, ctl.Name, ctl.Text))
            ElseIf TypeOf ctl Is RadioButton Then
                FrmNameNode.AppendChild(CreateNode(LabelDoc, ctl.Name, ctl.Text))
            End If

            If ctl.GetType().ToString = "System.Windows.Forms.TabControl" Or
                ctl.GetType().ToString = "System.Windows.Forms.SplitContainer" Or
                ctl.GetType().ToString = "System.Windows.Forms.SplitterPanel" Or
                ctl.GetType().ToString = "System.Windows.Forms.TabPage" Or
                ctl.GetType().ToString = "System.Windows.Forms.GroupBox" Or
                ctl.GetType().ToString = "System.Windows.Forms.Panel" Or
                ctl.GetType().ToString = "System.Windows.Forms.MdiClient" Or
                ctl.GetType().ToString.Contains("ucTextDate") Then
                Call CreateLabelXmlnodes(ctl, frmname)
            End If
        Next
    End Sub
    Public Sub CreateColumnXmlnodes(ByVal myControl As Control, ByVal frmname As String)
        Dim myGrid As DataGridView = myControl

        For Each col In myGrid.Columns
            FrmNameNode.AppendChild(CreateNode(LabelDoc, "col_" & col.Name, col.HeaderText))
        Next

    End Sub
    Public Sub CreateMenuXmlnodes(ByVal myControl As ToolStripDropDownItem, ByVal frmname As String)

        Dim myItems As ToolStripDropDownItem = myControl

        For Each item As ToolStripDropDownItem In myItems.DropDownItems
            FrmNameNode.AppendChild(CreateNode(LabelDoc, "mnuItem_" & item.Name, item.Text))
        Next

    End Sub
    Private Function CreateNode(LabelDoc As XmlDocument, ByVal Key As String, ByVal defaultvalue As String) As XmlNode
        Dim node As XmlNode
        node = LabelDoc.CreateElement(Key)
        node.InnerText = defaultvalue
        Return node
    End Function
End Module
