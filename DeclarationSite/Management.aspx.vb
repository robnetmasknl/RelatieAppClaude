Imports BusinessObjects
Imports System.Data

Partial Class Managment
    Inherits System.Web.UI.Page

    Protected mylidid As Int32 = 0

    Private _dtRecruiters As DataTable
    Public Property dtRecruiters() As DataTable
        Get

            If _dtRecruiters Is Nothing Then
                'SearchRecruiters()
            End If
            Return _dtRecruiters
        End Get
        Set(ByVal value As DataTable)
            _dtRecruiters = value
        End Set
    End Property

    Private _myLogin As LoginDecl
    Public Property myLogin() As LoginDecl
        Get
            If _myLogin Is Nothing Then
                _myLogin = New LoginDecl
                If _myLogin.LoginManager((Session("nr4559")), Session("pw4559")) < 0 Then
                    Response.Redirect("management.aspx")
                Else

                End If
            End If
            Return _myLogin
        End Get
        Set(ByVal value As LoginDecl)
            _myLogin = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RegisterPostBackControl()
        Me.lbError.Text = ""

        VisiblePlaceHolders(Session("PhManagement"))
        If Session("PhManagement") = "phLoginSucces" Then
            FillRecruiters()
        End If

    End Sub

    Private Sub RegisterPostBackControl()
        ' Dim sm As ScriptManager = CType(Page.Master.FindControl("ScriptManager1"), ScriptManager)
        Dim sm As ScriptManager = ScriptManager.GetCurrent(Me.Page)
        sm.RegisterPostBackControl(gvPeriodes)


    End Sub
    Protected Sub VisiblePlaceHolders(ByVal ph As String)
        phLogin.Visible = False
        phLoginSucces.Visible = False

        Select Case ph
            Case Is = "phLogin"
                phLogin.Visible = True
                Session("PhManagement") = "phLogin"
            Case "phLoginSucces"
                phLoginSucces.Visible = True
                Session("PhManagement") = "phLoginSucces"
            Case Else
                VisiblePlaceHolders("phLogin")
        End Select


    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles btnSend.Click
        Try
            Dim NewIpBlocker As New IpBlocker
            NewIpBlocker = New IpBlocker(Request.UserHostAddress, IpBlocker.Via.IP)
            If NewIpBlocker.ToManyAttemps Then
                With NewIpBlocker
                    .SearchName = Me.tbLidNr.Text
                    .TimeStamp = Now
                    .SearchDOB = "" 'Me.tbPassword.Text
                    .Type = "ManagementLogin"
                    .Attempts = .Attempts + 1
                    .Save()
                    Me.Label1.Text = "Teveel pogingen vanaf dit IP adres! <br> Probeer het over " & .TimeBetweenFailures & " minuten nog eens!"
                End With
            Else
                FillRecruiters()
            End If


        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub

    Protected Sub FillRecruiters()
        Try
            VisiblePlaceHolders("niets")
            Dim myLogindecl As New LoginDecl

            If Not Session("nr4559") Is Nothing AndAlso Not Session("pw4559") Is Nothing Then
                mylidid = myLogindecl.LoginManager(Session("nr4559"), Session("pw4559"))
            Else
                mylidid = myLogindecl.LoginManager(Me.tbLidNr.Text, Me.tbPassword.Text)
                If mylidid > 0 Then
                    Session("nr4559") = Me.tbLidNr.Text
                    Session("pw4559") = Me.tbPassword.Text
                End If
            End If

                Me.tbhidid.Value = mylidid

            If mylidid > 0 Then
                VisiblePlaceHolders("phLoginSucces")

                Dim FunctieEindDagen As String = ConfigurationManager.AppSettings("EindeFunctieDagen")
                If chkHistory.Checked = True Then
                    FunctieEindDagen = "9999"
                End If
                dtRecruiters = myLogin.Recruiters("-" & FunctieEindDagen)
                gvRecruiters.DataSource = dtRecruiters
                gvRecruiters.DataBind()

            Else
                Dim NewIpBlocker As New IpBlocker
                NewIpBlocker = New IpBlocker(Request.UserHostAddress, IpBlocker.Via.IP)
                With NewIpBlocker
                    .SearchName = Me.tbLidNr.Text
                    .TimeStamp = Now
                    .SearchDOB = "" 'Me.tbPassword.Text
                    .Type = "ManagementLogin"
                    .Attempts = .Attempts + 1
                    .Save()
                End With

                VisiblePlaceHolders("phLogin")
                Label1.Text = "U bent NIET aangemeld. Controleer uw inloggegevens!"
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#Region "gvRecruiters"
    Protected Sub gvRecruiters_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Not Session("nr4559") Is Nothing AndAlso Not Session("pw4559") Is Nothing Then

                'lbLoading.Text = "bezig met laden"
                phSelectedRecruiter.Visible = True
             
                gvPeriodes.DataSource = myLogin.PeriodsByRecruiter(CType(gvRecruiters.SelectedValue, Integer))
                gvPeriodes.DataBind()

                Dim relatie As New Relaties(gvRecruiters.SelectedValue, Relaties.Via.ID)
                lbRecruiterName.Text = "declaratie periodes van  " & relatie.FullName
            Else
                VisiblePlaceHolders("phLogin")
                Label1.Text = "U bent NIET aangemeld. Controleer uw inloggegevens!"
            End If

        Catch ex As Exception
            ShowError(ex.Message)
        End Try

    End Sub
    Protected Sub gvRecruiters_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRecruiters.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.textDecoration='underline';this.style.color='#800080'"
            e.Row.Attributes("onmouseout") = "this.style.textDecoration='none';;this.style.color='#000000'"
            e.Row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me.gvRecruiters, "Select$" & Convert.ToString(e.Row.RowIndex))


        End If
    End Sub
    Protected Sub gvRecruiters_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRecruiters.PageIndexChanging
        Try
            gvRecruiters.PageIndex = e.NewPageIndex
            gvRecruiters.DataSource = dtRecruiters
            gvRecruiters.DataBind()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "gvPeriodes"
    Public Sub gvPeriodes_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gvPeriodes.ItemDataBound
        If (e.Item.ItemType = ListItemType.EditItem) Then
            Dim i As Integer
            For i = 1 To e.Item.Controls.Count - 1
                If (e.Item.Controls(i).Controls(0).GetType().ToString() = "System.Web.UI.WebControls.TextBox") Then
                    Dim tb As TextBox
                    tb = e.Item.Controls(i).Controls(0)
                    ' If i = 1 Then tb.Visible = False 'ID overslaan

                    Select Case i
                        Case 1, 2, 3, 4, 5
                            tb.ReadOnly = True
                        Case Else
                            If tb.ReadOnly Then
                                'overslaan
                            Else
                                tb.Text = Server.HtmlDecode(tb.Text)
                                tb.BorderStyle = BorderStyle.Groove
                                tb.Font.Italic = True
                            End If
                    End Select

                End If
            Next
        End If
    End Sub
    Public Sub gvPeriodes_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvPeriodes.EditCommand
        Try

            gvPeriodes.EditItemIndex = CInt(e.Item.ItemIndex)
            gvPeriodes.DataSource = myLogin.PeriodsByRecruiter(CType(gvRecruiters.SelectedValue, Integer))
            gvPeriodes.DataBind()

        Catch ex As Exception
            ShowError(ex.Message)
        End Try


    End Sub
    Private Sub gvPeriodes_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvPeriodes.CancelCommand
        gvPeriodes.EditItemIndex = -1
        gvPeriodes.DataSource = myLogin.PeriodsByRecruiter(CType(gvRecruiters.SelectedValue, Integer))
        gvPeriodes.DataBind()
    End Sub
    Public Sub gvPeriodes_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gvPeriodes.UpdateCommand
        Try
            Dim MyDeclaratiePeriode As New DeclaratiePeriodes
            If gvPeriodes.DataKeys(CInt(e.Item.ItemIndex)).ToString = "" Then
                'MyDeclaratiePeriode = New DeclaratiePeriodes
            Else
                MyDeclaratiePeriode = New DeclaratiePeriodes(gvPeriodes.DataKeys(CInt(e.Item.ItemIndex)))
            End If

            If MyDeclaratiePeriode.Found Then
                Dim CurrentControl As Control = e.Item.FindControl("chkSubmittedEdit")
                If TypeOf CurrentControl Is CheckBox Then
                    Dim CheckBox As CheckBox = CType(CurrentControl, CheckBox)
                    MyDeclaratiePeriode.Submitted = Server.HtmlEncode(Convert.ToByte(CheckBox.Checked))
                End If
                MyDeclaratiePeriode.Save()
                gvPeriodes.EditItemIndex = -1
                gvPeriodes.DataSource = myLogin.PeriodsByRecruiter(CType(gvRecruiters.SelectedValue, Integer))
                gvPeriodes.DataBind()
            End If


        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ShowError(ByVal message As String)
        Try
            Me.lbError.Text = message
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    Protected Sub chkHistory_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            FillRecruiters()
        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Sub
End Class
