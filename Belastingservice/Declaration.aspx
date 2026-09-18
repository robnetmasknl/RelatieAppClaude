<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Declaration.aspx.vb" Inherits="Declaration" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
 
 <asp:PlaceHolder ID="phErrors" runat="server" Visible="false">
   <asp:label ID="lbError" runat="server" ForeColor="red"></asp:label>
</asp:PlaceHolder>

<asp:ScriptManager ID="ScriptManager1" runat="server" />

<ajaxToolKit:ModalPopupExtender ID="mpeProgress" runat="server" TargetControlID="pnlProgress" PopupControlID="pnlProgress" BackgroundCssClass="modalBackground" DropShadow="true" />
     <asp:Panel ID="pnlProgress" runat="server" style="background-color:#ffffff;display:none;width:400px">
            <div style="padding:8px">
                <table border="0" cellpadding="2" cellspacing="0" style="width:100%">
                    <tbody>
                        <tr>
                            <td style="width:50%"></td>
                            <td style="text-align:right">
                                <img alt="" src="images/ajax-loader.gif" />
                            </td>
                            <td style="text-align:left;white-space:nowrap">
                                <span style="font-size:larger">
                                <asp:label ID="lbLoading" runat="server" Width="150" >Loading, Please wait ...</asp:label>
                                </span>
                            </td>
                            <td style="width:50%"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
    </asp:Panel>
    
<asp:UpdatePanel runat="server" id="Panel" UpdateMode="Conditional">
<ContentTemplate>

<asp:PlaceHolder ID="phLogin" runat="server" Visible="True"> 

<table id="Table2" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  >Hier kunt u zich aanmelden voor de belastingservice.</td>
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
                     <asp:Button ID="btnGo" runat="server" Text="Inloggen" Width="150px" onclick="btnSend_Click" />
                 </td>
                 <td></td>
             </tr>
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
             <tr valign="top">
                 <td>
                 </td>
                 <td colspan ="2" align="left">
                     Bent u uw wachtwoord kwijt of heeft u nog geen wachtwoord? Klik dan <asp:HyperLink ID="hplPasswordReset" runat="server" NavigateUrl="password.aspx"> HIER </asp:HyperLink> om uw wachtwoord aan te maken of te resetten.<br />
                     U ontvangt dan een bericht via u opgegeven emailadres om het wachtwoord opnieuw op te geven.
                 </td>
                 <td></td>
             </tr>             
             </table>
     </asp:PlaceHolder>
<asp:PlaceHolder ID="phLoginSucces" runat="server" Visible="False">
     <asp:HiddenField ID="tbhidid" runat="server" ></asp:HiddenField>
             <table id="TableResults" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  >U bent aangemeld.</td>
                 <td width="5%"></td>
             </tr>
                 <tr valign="top">
                 <td >
                 <asp:DropDownList ID="YearList" runat="server"></asp:DropDownList> 
                 <asp:DropDownList ID="MonthList" runat="server"></asp:DropDownList>
                 <asp:Button ID="Searhperiod" runat="server" Text="Periode zoeken?" Width="150px" onclick="btnSearchPeriod_Click" />
                 </td>
                 <td colspan="2"  >
                 <%--<asp:Calendar id="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"  ></asp:Calendar>--%>
                <asp:button id="btAddDeclaration" runat="server" Text="Toevoegen" ></asp:button>
               
                <asp:datagrid ID="gvDeclarations" runat="server" CssClass="kop"
                    OnEditCommand="gvDeclarations_EditCommand" 
                    OnItemDataBound="gvDeclarations_ItemDataBound"
                    AutoGenerateColumns="False" DataKeyField="Id" Width="100%">
            	<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<EditItemStyle Font-Italic="True"></EditItemStyle>
                <Columns>
                	<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Opslaan" CancelText="annuleren" EditText="Bewerken">
						<ItemStyle > </ItemStyle>
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
              <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                     <asp:Label id="lbCalendar" runat="server"></asp:Label>
                 </td>
                 <td ></td>
             </table>
     </asp:PlaceHolder>
     <asp:PlaceHolder ID="phCreatePeriode" runat="server" Visible="False">
             <table id="Table1" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  >U bent aangemeld.</td>
                 <td width="25%"></td>
              </tr>
              <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                     <asp:Label id="lbCreatePeriode" runat="server"></asp:Label>
                 </td>
                 <td ></td>
              </tr>
              <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                    <asp:textbox ID="tbPerDescription" runat= "server"></asp:textbox>
                 </td>
                 <td ></td>
              </tr>
                 <tr valign="top">
                 <td ></td>
                 <td colspan="2"><asp:Button ID="btCreatePeriode" runat="server" Text="Periode maken?" Width="150px" onclick="btnCreate_Click" />
                 </td>
                 <td ></td>
             </tr>  
             </table>
     </asp:PlaceHolder>
          <asp:PlaceHolder ID="phSelectedPeriod" runat="server" Visible="False">
             <table id="Table3" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2" ><asp:Label id="lbPeriode" runat="server"></asp:Label> </td>
                 <td width="25%"></td>
              </tr>
              <tr valign="top">
                <td colspan="3"  >
 
                 </td>
                 <td ></td>
              </tr>
                 <tr valign="top">
                 <td ></td>
                 <td colspan="2"></td>
                 <td ></td>
             </tr>  
             </table>
     </asp:PlaceHolder>
  </ContentTemplate>
 </asp:UpdatePanel>
 
  <script type="text/javascript">
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

</script>
</asp:Content>

