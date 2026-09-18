Imports BusinessObjects


Partial Class BSRegistration
    Inherits System.Web.UI.Page

    Private _DOB As Date = Date.MinValue
    Private _Name As String = String.Empty

    Protected Sub btnSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Load
        MultiView1.SetActiveView(SearchView)
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            'ip, zoeknaam, geb datum , timestamp wegschrijven
            'controle of er binnen x aantal seconden via het zelfde IP een request is gedaan
            'zo ja afvangen.
            Dim NewIpBlocker As New IpBlocker
            NewIpBlocker = New IpBlocker(Request.UserHostAddress, IpBlocker.Via.IP)
            If NewIpBlocker.ToManyAttemps Then
                With NewIpBlocker
                    '.IPADDRESS = Request.UserHostAddress()
                    .SearchName = Me.tbName.Text
                    .TimeStamp = Now
                    .SearchDOB = Me.tbDOB.Text
                    .Type = "SearchRequest"
                    .Attempts = .Attempts + 1
                    .Save()
                    Me.lblError.Text = "Teveel pogingen vanaf dit IP adres! <br> Probeer het over " & .TimeBetweenFailures & " minuten nog eens!"
                End With
            Else
                With NewIpBlocker
                    .IPADDRESS = Request.UserHostAddress()
                    .SearchName = Me.tbName.Text
                    .TimeStamp = Now
                    .SearchDOB = Me.tbDOB.Text
                    .Type = "SearchRequest"
                    .Attempts = .Attempts + 1
                    .Save()
                End With


                Dim _Leden As New WebLedenLijst

                _Leden._DOB = Me.tbDOB.Text
                _Leden._SearchName = Me.tbName.Text

                If _Leden.ByDOBNAME.Count > 0 Then
                    MultiView1.SetActiveView(ResultsView)
                    Me.GridView1.DataSource = _Leden.ByDOBNAME
                    Me.GridView1.DataBind()
                Else
                    Me.lblError.Text = "Geen gegevens gevonden. Controleer uw ingevulde gegevens!"
                End If
            End If


        Catch ex As Exception
            Me.lblError.Text = ex.Message
        End Try
    End Sub


End Class
