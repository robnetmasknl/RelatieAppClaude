Imports BusinessObjects
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class frmJumbling
    Private da As New DataAccess
    Private jbl As New Jumbling

    Private Sub frmJumbling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblConnection.Text = da.MyConnectionString
            Me.cmbTables.DataSource = da.GetTableNames("")

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try

            ExecuteDataset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTables.SelectedIndexChanged
        Try
            lsbColums.DataSource = da.GetColumnsNames(Me.cmbTables.SelectedItem)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            UpdateAllNAW()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub UpdateAllNAW()
        Dim result As New DataSet
        Try
            'Using connection As SqlConnection = GetConnection()
            Using connection As SqlConnection = New SqlConnection(da.MyConnectionString)
                connection.Open()
                Dim sql As String = "SELECT * FROM relaties "
                Dim cmdBuilder As SqlCommandBuilder
                Dim command As New SqlCommand(sql, connection)
                Dim adapter As New SqlDataAdapter(command)
                cmdBuilder = New SqlCommandBuilder(adapter)
                adapter.Fill(result)
                Dim pre As String = PreText.Text & "_"
                Dim tmp As String = String.Empty
                For Each row As DataRow In result.Tables(0).Rows
                    tmp = CryptoService.Encrypt(row.Item("achternaam"))

                    Dim rn As New Random
                    row.Item("email") = "bert@netmask.nl"
                    row.Item("b_email") = "bert@netmask.nl"
                    row.Item("achternaam") = "naam_" & tmp.Substring(0, 10) 'GenerateRandomString(7, False)
                    row.Item("adres") = "adres_" & GenerateRandomString(5, True)
                    row.Item("postcode") = RandomNumber(1000, 9999) & "AA"
                    row.Item("huisnr") = "99"
                    row.Item("telefoonnummer") = ""
                    row.Item("mobiel") = ""
                    row.Item("bankrek") = 0
                    row.Item("IBAN") = ""
                    row.Item("b_telefoon") = ""
                    row.Item("b_mobiel") = ""
                    row.Item("telwerk") = ""
                    row.Item("emailwerk") = ""
                    row.Item("telefax") = ""

                Next
                adapter.Update(result)

                connection.Close()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ExecuteDataset()
        Dim result As New DataSet
        Try
            'Using connection As SqlConnection = GetConnection()
            Using connection As SqlConnection = New SqlConnection(da.MyConnectionString)
                connection.Open()
                Dim sql As String = "SELECT * FROM relaties "
                Dim cmdBuilder As SqlCommandBuilder
                Dim command As New SqlCommand(sql, connection)
                Dim adapter As New SqlDataAdapter(command)
                cmdBuilder = New SqlCommandBuilder(adapter)
                adapter.Fill(result)
                Dim pre As String = PreText.Text & "_"
                For Each row As DataRow In result.Tables(0).Rows
                    If Me.lsbColums.SelectedItem = "email" Then
                        row.Item(Me.lsbColums.SelectedItem) = "bert@netmask.nl"
                    Else
                        row.Item(Me.lsbColums.SelectedItem) = pre & GenerateRandomString(PreLenght.Text, False)
                    End If

                Next
                adapter.Update(result)

                connection.Close()
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function RandomNumber(min As Integer, max As Integer) As Integer
        Dim random As New Random()
        Return random.Next(min, max)
    End Function 'RandomNumber 

    Public Function GenerateRandomString(ByRef len As Integer, ByRef upper As Boolean) As String

        Dim rand As New Random()
        Dim allowableChars() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next

        Return IIf(upper, final.ToUpper(), final)
    End Function
    Public Function GetRandomString(ByVal iLength As Integer) As String
        Dim sResult As String = ""
        Dim rdm As New Random()

        For i As Integer = 1 To iLength
            sResult &= ChrW(rdm.Next(32, 60))
        Next

        Return sResult
    End Function


End Class
