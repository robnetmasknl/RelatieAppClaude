Public NotInheritable Class AboutBox

    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
          '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        ' Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)

        Dim myFileVersionInfoBO As FileVersionInfo = FileVersionInfo.GetVersionInfo("BusinessObjects.dll")
        Dim myFileVersionInfoOO As FileVersionInfo = FileVersionInfo.GetVersionInfo("OfficeObjects.dll")


        Me.LabelVersion.Text = String.Format("Version Leden App {0}", My.Application.Info.Version.ToString)
        Me.LabelVersionBO.Text = String.Format("Version BusinessObjects {0}", myFileVersionInfoBO.FileVersion.ToString)
        Me.LabelVersionOO.Text = String.Format("Version OfficeObjects {0}", myFileVersionInfoOO.FileVersion.ToString)

        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub lbUpdates_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbUpdates.LinkClicked
        Try
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath & "\updates.txt")
        Catch ex As Exception
        End Try
    End Sub
End Class
