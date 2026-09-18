Imports BusinessObjects

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public ButtonClick As EventHandler(Of CustomArgs)
    Public hiddenId As String = ""

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        lblValue.Text = Nothing
        If ButtonClick IsNot Nothing Then
            Dim args As New CustomArgs()
            ButtonClick(sender, args)
            If args.Cancel Then
                lblValue.Text = args.Message
            Else
                Response.Redirect(args.NavigateTo)
            End If
        End If
    End Sub

End Class

