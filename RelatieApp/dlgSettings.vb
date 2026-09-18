Imports System.Windows.Forms
Imports BusinessObjects
Imports System.Xml
Imports System.IO

Public Class dlgSettings
    Private Settings As Settings = Settings.Instance
    Private URights As UserRights = UserRights.Instance

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try

            SaveSettings()

            MessageBox.Show("Wijzigingen zijn opgeslagen", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not URights.IsInGroup("rel_admins") Then
                OK_Button.Enabled = False
                MessageBox.Show("U heeft onvoldoende rechten!" & vbCrLf & "U moet lid zijn van de groep ''rel_admins''", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Text = Text & "U heeft NIET de voldoende rechten!"
            Else
                Settings = New Settings
                tbServer.Text = Settings.ServerIP
                tbDatabase.Text = Settings.DataBase
                tbAccount.Text = Settings.Account
                If String.IsNullOrEmpty(Settings.password) Then
                    tbPassword.Text = "default"
                Else
                    tbPassword.Text = CryptoService.Decrypt(Settings.password)
                End If

                tbMailServer.Text = Settings.Mailserver
                tbMailSenderName.Text = Settings.MailSenderName
                tbMailSenderEmail.Text = Settings.MailSenderEmail
                tbMailAccount.Text = Settings.MailAccount
                If String.IsNullOrEmpty(Settings.MailAccountPassword) Then
                    tbMailAccountPassword.Text = "default"
                Else
                    tbMailAccountPassword.Text = CryptoService.Decrypt(Settings.MailAccountPassword)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
   


    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            With Me.fbdQueue
                .Reset()
                If String.IsNullOrEmpty(Me.tbMailServer.Text) Then
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                Else
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    .SelectedPath = Me.tbMailServer.Text
                End If

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.tbMailServer.Text = .SelectedPath
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveSettings()
        Try
            Settings.ServerIP = tbServer.Text
            Settings.DataBase = tbDatabase.Text
            Settings.Account = tbAccount.Text
            If String.IsNullOrEmpty(tbPassword.Text) Then
                Settings.password = CryptoService.Encrypt("default")
            Else
                Settings.password = CryptoService.Encrypt(tbPassword.Text)
            End If

            Settings.Mailserver = tbMailServer.Text
            Settings.MailSenderName = tbMailSenderName.Text
            Settings.MailSenderEmail = tbMailSenderEmail.Text
            Settings.MailAccount = tbMailAccount.Text
            If String.IsNullOrEmpty(tbMailAccountPassword.Text) Then
                Settings.MailAccountPassword = CryptoService.Encrypt("default")
            Else
                Settings.MailAccountPassword = CryptoService.Encrypt(tbMailAccountPassword.Text)
            End If

            Settings.Save()
            Settings._Instance = Nothing

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub btnTestConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConn.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            SaveSettings()
            Dim db As New DataAccess
            If db.TestConnection Then

            End If
            Me.Cursor = Cursors.Default
            MessageBox.Show("Connectie succesvol", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lnkAbout_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAbout.LinkClicked
        Dim frmAbout As New AboutBox
        frmAbout.ShowDialog(Me)
    End Sub
  
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
