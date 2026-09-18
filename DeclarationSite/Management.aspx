<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Management.aspx.vb" Inherits="Managment" EnableEventValidation="false" %>
<%--<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <% 
    Response.Expires = -1000
    Response.Buffer = True
 %>

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<%-- <ajaxToolKit:ModalPopupExtender ID="mpeProgress" runat="server" TargetControlID="pnlProgress" PopupControlID="pnlProgress" BackgroundCssClass="modalBackground" DropShadow="true" />
    <asp:Panel ID="pnlProgress" runat="server" style="background-color:#ffffff;display:none;width:400px">
            <div style="padding:8px">
                <table border="0" cellpadding="2" cellspacing="0" style="width:100%">
                    <tbody>
                        <tr>
                            <td style="width:50"></td>
                            <td style="text-align:right">
                                <img alt="" src="images/ajax-loader.gif" />
                            </td>
                            <td style="text-align:left;white-space:nowrap">
                                <span style="font-size:larger">
                                <asp:label ID="lbLoading" runat="server" Width="150" >Ogenblik, bezig met laden...</asp:label>
                                </span>
                            </td>
                            <td style="width:50"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
    </asp:Panel>
--%>
<asp:UpdatePanel runat="server" id="Panel" UpdateMode="Conditional">
<ContentTemplate>
 <asp:label ID="lbError" runat="server" ForeColor="red"></asp:label>
<asp:PlaceHolder ID="phLogin" runat="server" Visible="True"> 

<table id="tblLogin" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  >Hier kunt u zich aanmelden voor de declaratiemanagment.</td>
                 <td width="25%"></td>
             </tr>
             <tr><td colspan="4">&nbsp; &nbsp;</td></tr>
             <tr >
                 <td > <asp:label ID="Label1" runat="server" ForeColor="red"></asp:label></td>
                 <td  >Lidmaatschapnummer:</td>
                 <td align="left">
                     <asp:TextBox ID="tbLidNr" runat="server" Width="150px" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="tbLidNr" ErrorMessage="Verplicht veld." Font-Bold="True"></asp:RequiredFieldValidator>
                 </td>
                 <td ></td>
             </tr>
             <tr valign="top">
                 <td>
                 </td>
                 <td >Wachtwoord:</td>
                 <td align="left">
                     <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                         ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="Verplicht veld!" 
                         Font-Bold="True">
                    </asp:RequiredFieldValidator>
                </td>
                <td></td>
             </tr>
             <tr valign="top">
                 <td>
                 </td>
                 <td>
                 </td>
                 <td align="left">
                     <asp:Button ID="btnLogin" runat="server" Text="Inloggen" Width="150px" onclick="btnLogin_Click" />
                 </td>
                 <td></td>
             </tr>
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
             <tr valign="top">
                 <td>
                 </td>
                 <td colspan ="2" align="left">&nbsp; &nbsp;</td>
                 <td></td>
             </tr>             
             </table>
</asp:PlaceHolder>
<asp:PlaceHolder ID="phLoginSucces" runat="server" Visible="False">
     <asp:HiddenField ID="tbhidid" runat="server" ></asp:HiddenField>
     <asp:HiddenField ID="tbhidLock" runat="server" ></asp:HiddenField>
         <table id="TableResults" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="5%"></td>
                 <td colspan="2"  >U bent succesvol aangemeld. Selecteer een ledenwerver.
                    <%--<asp:Label id="lbPeriode" runat="server"></asp:Label>--%>
                 </td>
                 <td width="5%"></td>
             </tr>
             <tr valign="top">
                 <td></td>
                 <td colspan="2"><asp:CheckBox ID="chkHistory" runat="server"  OnCheckedChanged="chkHistory_CheckedChanged" AutoPostBack="true" /> Historie </td>
                 <td></td>
             </tr>
                 <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
               <asp:GridView ID="gvRecruiters" runat="server" CssClass="grid-view"
                             AutoGenerateColumns="False" DataKeyNames="Id" Width="100%"
                             allowpaging="True"               
                             PageSize="15" 
                             OnSelectedIndexChanged="gvRecruiters_SelectedIndexChanged">
                 <HeaderStyle CssClass="GridHeader" ></HeaderStyle>
                 <EmptyDataTemplate><i>geen resultaten</i></EmptyDataTemplate>
            	 <Columns>
            	    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:HyperLink ID="hlLidId" runat="server" Text='<%# Bind("Id") %>' />
                      </ItemTemplate>
                     </asp:TemplateField>
                    <asp:BoundField DataField="Init" HeaderText="Initialen" />
                    <asp:BoundField DataField="achternaam" HeaderText="Achternaam" />
                 </Columns>
                 <pagersettings mode="Numeric" position="Bottom" pagebuttoncount="10"/>
               </asp:GridView>
               </td>
               <td ></td>
             </tr>  
              <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                     <asp:Label id="lbCalendar" runat="server"></asp:Label>
                 </td>
                 <td ></td>
             </table>
</asp:PlaceHolder>
     
     <asp:PlaceHolder ID="phSelectedRecruiter" runat="server" Visible="true">
           <table id="tblRecruiter" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="5%"></td>
                 <td colspan="2">
                   <asp:Label id="lbRecruiterName" runat="server"></asp:Label>
                 </td>
                 <td width="5%"></td>
             </tr>
             <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                  <asp:datagrid ID="gvPeriodes" runat="server" 
                                CssClass="grid-view"
                                AutoGenerateColumns="False"  
                                DataKeyField="Id"
                                OnItemDataBound="gvPeriodes_ItemDataBound" 
                                OnEditCommand="gvPeriodes_EditCommand" 
                                OnUpdateCommand="gvPeriodes_UpdateCommand"
                                Width="100%" >
                    <HeaderStyle CssClass="GridHeader" ></HeaderStyle>
                    <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				    <EditItemStyle Font-Italic="True"></EditItemStyle>
                    <Columns>
<%--                	<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Opslaan" CancelText="Annuleren" EditText="Bewerken" >
						<HeaderStyle CssClass="GridHeader" ></HeaderStyle>
						<ItemStyle CssClass="GridItem"></ItemStyle>
					</asp:EditCommandColumn>--%>
					<asp:TemplateColumn >
                    	<HeaderStyle CssClass="GridHeader" ></HeaderStyle>
					    <ItemStyle CssClass="GridItem"></ItemStyle>
						<ItemTemplate>
                           <asp:ImageButton ID="ImgBtnEdit" runat="server" commandName="Edit" Text="Edit" ImageUrl="~/Images/Paper-pencil.png"  AlternateText="Bewerken" Height="25"/>
                        </ItemTemplate>
                        <EditItemTemplate>                        	
                            <asp:ImageButton ID="ImgBtnUpdate" runat="server" commandName="Update" Text="Update" ImageUrl="~/Images/Check.png"  AlternateText="Opslaan" Height="20"/>
                            <asp:ImageButton ID="ImgBtnCancel" runat="server" commandName="Cancel" Text="Cancel" ImageUrl="~/Images/Refresh.png"  AlternateText="Annuleren" Height="20"/>
                        </EditItemTemplate>
                     </asp:TemplateColumn>
                     <asp:BoundColumn DataField="LidId" HeaderText="#" Visible="false" />
                    <asp:BoundColumn DataField="PeriodeMnd" HeaderText="Maand" />
                    <asp:BoundColumn DataField="PeriodeJaar" HeaderText="Jaar" />
                    <asp:BoundColumn DataField="Omschrijving" HeaderText="Omschrijving" />
                    <asp:BoundColumn DataField="CreatedDate" HeaderText="CreatedDate" />
                    <asp:BoundColumn DataField="Id" Visible="false"  />
                     <asp:BoundColumn DataField="TotalDeclarations" HeaderText="Aantal" />
                    <asp:HyperLinkColumn Text="Declaraties" DataNavigateUrlField="Id" DataNavigateUrlFormatString="DeclarationPrint.aspx?id={0}"
						 Target="_search" HeaderText="Declaraties">
				    </asp:HyperLinkColumn>
                    <asp:TemplateColumn HeaderText="Submitted" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>                       
                          <asp:CheckBox ID="chkSubmitted" Runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container, "DataItem.Submitted") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
							<asp:CheckBox ID="chkSubmittedEdit" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Submitted") %>'>
							</asp:CheckBox>
						</EditItemTemplate>
                    </asp:TemplateColumn>
                 </Columns>
               </asp:datagrid>                  
                 </td>
                 <td ></td>
             </tr> 
          </table>
     </asp:PlaceHolder>
   <%--<asp:PlaceHolder ID="phSelectedperiod" runat="server" Visible="False">
           <table id="Table1" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="5%"></td>
                 <td colspan="2"  >
                   <asp:Label id="Label3" runat="server" Text="geselecteerde periode"></asp:Label>
                 </td>
                 <td width="5%"></td>
             </tr>
             <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                  <asp:datagrid ID="gvDeclarations" runat="server" 
                                CssClass="grid-view"
                                AutoGenerateColumns="False"  
                                DataKeyField="Id" 
                                Width="100%" >
                        <HeaderStyle CssClass="GridHeader" ></HeaderStyle>
                        <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				        <EditItemStyle Font-Italic="True"></EditItemStyle>
                    <Columns>
                	<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Opslaan" CancelText="annuleren" EditText="Bewerken" >
						<HeaderStyle CssClass="GridHeader" ></HeaderStyle>
						<ItemStyle CssClass="GridItem"></ItemStyle>
					</asp:EditCommandColumn>
                    <asp:BoundColumn DataField="DeclPerId" HeaderText="#" Visible="false" />
                    <asp:BoundColumn DataField="DeclaratieDate" HeaderText="Datum" />
                    <asp:BoundColumn DataField="Omschrijving" HeaderText="Omschrijving" />
                    <asp:BoundColumn DataField="Onkosten" HeaderText="Onkosten" />
                    <asp:BoundColumn DataField="OnkOmsc" HeaderText="Onk Omschrijving" />
                    <asp:BoundColumn DataField="Kilometers" HeaderText="Kilometers" />
                    <asp:BoundColumn DataField="OnkOV" HeaderText="Openbaar vervoer" />
                    <asp:BoundColumn DataField="KmOmsc" HeaderText="km Omschrijving" />
                    <asp:BoundColumn DataField="Id" Visible="false"  />
                    <asp:BoundColumn DataField="CreatedDate" Visible="false"  />
                 </Columns>
               </asp:datagrid>                  
                 </td>
                 <td ></td>
             </tr> 
          </table>
     </asp:PlaceHolder>
--%>
</ContentTemplate>
</asp:UpdatePanel>

<%--  <script type="text/javascript">
        Sys.Net.WebRequestManager.add_invokingRequest(onInvoke);
        Sys.Net.WebRequestManager.add_completedRequest(onComplete);

        function onInvoke(sender, args)
        {
            $find('<%= mpeProgress.ClientID %>').show();
        }

        function onComplete(sender, args)
        {
            $find('<%= mpeProgress.ClientID %>').hide();
        }

        function pageUnload()
        {
            Sys.Net.WebRequestManager.remove_invokingRequest(onInvoke);
            Sys.Net.WebRequestManager.remove_completedRequest(onComplete);
        }
 </script>
 <script type="text/javascript">

     function ShowConfirmation() 
         {
         if (confirm("Are you sure you want to submit ?")) 
         {
             return true;
         }
         else 
         {
             return false;
         }
         }

</script>--%>
</asp:Content>

