<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Declaration.aspx.vb" Inherits="Declaration" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
 
 <asp:PlaceHolder ID="phErrors" runat="server" Visible="True">
  
</asp:PlaceHolder>

 
<asp:ScriptManager ID="ScriptManager1" runat="server" />

<%--<ajaxToolKit:ModalPopupExtender ID="mpeProgress" runat="server" TargetControlID="pnlProgress" PopupControlID="pnlProgress" BackgroundCssClass="modalBackground" DropShadow="true" />
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
    </asp:Panel>--%>
    
<asp:UpdatePanel runat="server" id="Panel" UpdateMode="Conditional">
<ContentTemplate>
 <asp:label ID="lbError" runat="server" ForeColor="red"></asp:label>
<asp:PlaceHolder ID="phLogin" runat="server" Visible="True"> 

<table id="Table2" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  >Hier kunt u zich aanmelden voor de declaratieservice.</td>
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
                 <td colspan ="2" align="left">
                 </td>
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
                 <td colspan="2"></td>
                 <td width="5%"></td>
             </tr>
             <tr valign="top" align="center">
               <td colspan="4"  >
                    <asp:Label id="lbWelcomelogin" runat="server"></asp:Label>
                    <br/>
                    <asp:Label id="lbPeriode" runat="server"></asp:Label>
                 </td>
             </tr>
             <tr valign="middle">
                 <td></td>
                 <td colspan="2" >    
               <%--  <asp:Button ID="btnPrevPeriod" runat="server" Text="<" Width="50px" onclick="btnPrevPeriod_Click" />  --%>
                 <asp:ImageButton ID="btnPrevPeriodimg"  ImageAlign="Bottom" runat="server" OnClick="btnPrevPeriod_Click" Text="Vorige" ImageUrl="~/Images/back.png"  AlternateText="Vorige" Height="20"/>
                                 
                 <asp:DropDownList ID="YearList" runat="server"></asp:DropDownList> 
                 <asp:DropDownList ID="MonthList" runat="server"></asp:DropDownList>
                 <%--<asp:Button ID="btnNextPeriod" runat="server" Text=">" Width="50px" onclick="btnNextPeriod_Click" />--%>
                 <asp:ImageButton ID="btnNextPeriodimg"  ImageAlign="Bottom" runat="server" OnClick="btnNextPeriod_Click" Text="Volgend" ImageUrl="~/Images/forward.png"  AlternateText="Volgende" Height="20"/>
                   
                 <asp:Button ID="Searhperiod" runat="server" Text="Periode zoeken?" Width="150px" onclick="btnSearchPeriod_Click" />
                 <br/><br/>
              </td>
                 <td></td>
             </tr>
                 <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                <asp:button id="btAddDeclaration" runat="server" Text="Toevoegen"></asp:button>
               
                <asp:datagrid ID="gvDeclarations" runat="server" CssClass="grid-view"
                    OnEditCommand="gvDeclarations_EditCommand" 
                    OnUpdateCommand="gvDeclarations_UpdateCommand"
                    OnItemDataBound="gvDeclarations_ItemDataBound"
                    AutoGenerateColumns="False" DataKeyField="Id" Width="100%" >
                <HeaderStyle CssClass="GridHeader" ></HeaderStyle>
            	<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<EditItemStyle Font-Italic="True" Width="100%"></EditItemStyle>
                <Columns>
                    <asp:TemplateColumn >
                    	<HeaderStyle CssClass="GridHeader" ></HeaderStyle>
					    <ItemStyle CssClass="GridItem"></ItemStyle>
						<ItemTemplate>
                           <asp:ImageButton ID="ImgBtnEdit" runat="server" commandName="Edit" ImageUrl="~/Images/Paper-pencil.png"  AlternateText="Bewerken" Height="25"/>
                        </ItemTemplate>
                        <EditItemTemplate>                        	
                            <asp:ImageButton ID="ImgBtnUpdate" runat="server" commandName="Update" ImageUrl="~/Images/Check.png"  AlternateText="Opslaan" Height="20"/>
                            <asp:ImageButton ID="ImgBtnCancel" runat="server" commandName="Cancel" ImageUrl="~/Images/Refresh.png"  AlternateText="Annuleren" Height="20"/>
                        </EditItemTemplate>
                     </asp:TemplateColumn>
					
                    <asp:BoundColumn DataField="DeclPerId" HeaderText="#" Visible="false" />
                    <asp:BoundColumn DataField="DeclaratieDate" HeaderText="Datum" DataFormatString="{0:d}"/>
                    <asp:BoundColumn DataField="Omschrijving" HeaderText="Omschrijving" />
                    <%--  <asp:BoundColumn DataField="Promomateriaal" HeaderText="Promomateriaal" ItemStyle-Width="160px" />--%>
                    <asp:BoundColumn DataField="Uren" HeaderText="Uren" ItemStyle-HorizontalAlign="center" />
                     <asp:BoundColumn DataField="Maaltijden" HeaderText="Maaltijden" ItemStyle-HorizontalAlign="center" DataFormatString="{0:C}" />
                    <asp:BoundColumn DataField="Onkosten" HeaderText="Overige onk." ItemStyle-HorizontalAlign="center" DataFormatString="{0:C}" />
                    <asp:BoundColumn DataField="OnkOmsc" HeaderText="Onk. Omschrijving" />
                    <asp:BoundColumn DataField="Kilometers" HeaderText="Kilometers" ItemStyle-HorizontalAlign="center"  />
                    <%-- <asp:BoundColumn DataField="OnkOV" HeaderText="Reiskosten ov" ItemStyle-HorizontalAlign="center" DataFormatString="{0:C}" />--%>
                    <asp:BoundColumn DataField="KmOmsc" HeaderText="km Omschrijving" />
                    <asp:BoundColumn DataField="Id" Visible="false"  />
                    <asp:BoundColumn DataField="CreatedDate" Visible="false"  />
                    <asp:TemplateColumn HeaderText="verwijder" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                          <asp:ImageButton ID="ImgBtnDelete" Height="15" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Images/cancel.png" />
                          </ItemTemplate>
                    </asp:TemplateColumn>
                 </Columns>
            </asp:datagrid> 
                 
                 </td>
                 <td ></td>
             </tr>  
             <tr><td colspan="4">&nbsp; &nbsp;</td></tr>  
             <tr valign="top">
                 <td ></td>
                 <td colspan="2">
                 <asp:Label id="lbTotals" CssClass="GridHeader" runat="server" Text="Totalen:"></asp:Label>       
                <asp:gridview ID="gvTotals" runat="server" CssClass="grid-view"
                              HorizontalAlign="left"
                              AutoGenerateColumns="False"
                              Width="75%"  >
                <HeaderStyle CssClass="GridHeader" ></HeaderStyle>
                <Columns>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="Uren" HeaderText="Uren" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TotalAmountHours" HeaderText="Bedrag Uren" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TotalMeals" HeaderText="Maaltijden" DataFormatString="{0:C}"/>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="Onkosten" HeaderText="Overige onk." DataFormatString="{0:C}"/>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="Kilometers" HeaderText="Kilometers" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TotalAmountKm" HeaderText="Bedrag Kilometers" />
                     <%--<asp:BoundField ItemStyle-HorizontalAlign="center" DataField="OnkOV" HeaderText="Openbaar vervoer" DataFormatString="{0:C}" />--%>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="PeriodTotalCompensation" HeaderText="Totale vergoeding" />
                    
                 </Columns>
            </asp:gridview> 
                 
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
                 <td colspan="2">
                    <asp:Label id="lbWelcome" runat="server"></asp:Label>
                 </td>
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
                 <td colspan="4" >&nbsp;</td>
              </tr>
              <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >                  
                  <asp:Label id="lbDescription" runat="server">Omschrijving:</asp:Label>          
                 <asp:textbox ID="tbPerDescription" runat= "server"></asp:textbox>
                 </td>
                 <td ></td>
              </tr>
                 <tr valign="top">
                 <td ></td>
                 <td colspan="2">
                     <asp:Button ID="btCreatePeriode" runat="server" Text="Periode aanmaken?" Width="150px" onclick="btnCreate_Click" />
                     <asp:Button ID="btCreateCancel" runat="server" Text="Annuleren" Width="150px" onclick="btnCreateCancel_Click" />
                 </td>
                 <td ></td>
             </tr>  
             </table>
     </asp:PlaceHolder>
          <asp:PlaceHolder ID="phSelectedPeriod" runat="server" Visible="False">
             <table id="Table3" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2" > </td>
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

