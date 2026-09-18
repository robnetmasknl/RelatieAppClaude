<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="BSRegistration" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content id="Content1" ContentPlaceHolderid="phContent" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
 
</asp:ScriptManager>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="838px" Font-Bold="True"></asp:Label>
    
    <asp:MultiView id="MultiView1" runat="server">
    <asp:View id="SearchView" runat="server">
    
         <p class="auto-style2" >U kunt zich op deze site aanmelden voor een belastingadviesgesprek met één van 
             onze adviseurs die uw belastingformulier invullen.
             <br />
             Om in te kunnen loggen op onze belasting service website heeft u inloggegevens 
             nodig die u hier kunt aanmaken.
             <br />
             Om uw lidmaatschapnummer te vinden moet u hier uw achternaam en geboortedatum 
             invullen en op zoeken klikken.
             <br />
             <br />

			 </p>
         
              <h3 align="center" class="HdrTitle">
             Lidmaatschapnummer zoeken:</h3>
        <table id="TableSearch" border="0" class="inside" width="100%">
            <tr align="left" valign="top">
                <td width="23%">
                </td>
                <td>
                    Achternaam:</td>
                <td colspan="2">
                    <asp:TextBox ID="tbName" runat="server" BorderStyle="Ridge"></asp:TextBox> Geen voorvoegsels (de, van de)
                    <asp:RequiredFieldValidator ID="valrActivities" runat="server" 
                        ControlToValidate="tbName" ErrorMessage="Verplicht veld!" Font-Bold="True"></asp:RequiredFieldValidator> 
                </td>
             </tr>
            <tr align="left" valign="top">
                <td>
                </td>
                <td>
                    Geboortedatum:</td>
                <td colspan="2">
                    <asp:TextBox ID="tbDOB" runat="server" BorderStyle="Ridge"></asp:TextBox> (dd-MM-jjjj)
                    <asp:RequiredFieldValidator ID="ValDOB" runat="server" 
                        ControlToValidate="tbDOB" Display="Dynamic" ErrorMessage="Verplicht veld!" 
                        Font-Bold="True">
                         </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="tbDOB" Display="Dynamic" 
                        ErrorMessage="Datum formaat ongeldig. (dd-MM-jjjj)" Font-Bold="True" 
                        Height="8px" 
                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" 
                        Width="176px"></asp:RegularExpressionValidator>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                        Format="dd-MM-yyyy" PopupButtonID="TextBox2" PopupPosition="Right" 
                        TargetControlID="tbDOB">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr align="left" valign="top">
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Zoeken" />
                </td>
                <td>
                </td>
            </tr>
            <tr valign="top">
                <td>
                </td>
                <td>
                </td>
                <td align="left">
                    &nbsp;</td>
                <td>
                </td>
            </tr>
        </table>
    
  
    </asp:View>
    
     <asp:View id="ResultsView" runat="server">

       <h3 class="HdrTitle" >gevonden resultaten:</h3>
       
         <table id="Table1" class="inside" width="100%" border="0">
             <tr>
                 <td class="auto-style9"></td>
                 <td colspan="2" align="center">
                    
                    </td>
                 <td width="25%"></td>
                 </tr>
             <tr>
                 <td class="auto-style9" ></td>
                 <td colspan="2" align="left">
                        Op basis van de door u ingevulde gegevens hebben wij onderstaande gegevens gevonden. 
                        Controleer of deze gegevens correct zijn en klik dan op uw lidmaatschapnummer!
                 </td>
                 <td ></td>
              </tr>  
              <tr>
                 <td class="auto-style9"></td>
                 <td></td>
                 <td></td>
                 <td></td>
               </tr>
               <tr>
                    <td class="auto-style9"></td>
                    <td colspan="2">
                     <asp:GridView id="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Left" CaptionAlign="Left" EnableModelValidation="True">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="left" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>    
                            <asp:HyperLinkField DataTextField="lidnr" HeaderText="Lidnr" DataNavigateUrlFields="lidnr" DataNavigateUrlFormatString="~/login.aspx?lidnr={0}" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="FullName" HeaderText="Naam" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
<%--                            <asp:BoundField DataField="Init" HeaderText="Intialen" />
                            <asp:BoundField DataField="Postcode" HeaderText="Postcode" />--%>
                            <asp:BoundField DataField="geboortedatum" DataFormatString="{0:dd-MM-yyyy}" 
                                HeaderText="Geboortedatum" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                         </Columns>
                    </asp:GridView>
                    
                    </td>
                    <td></td>
                </tr>           
        </table>
        
        </asp:View>
    </asp:MultiView>   
</asp:Content>

