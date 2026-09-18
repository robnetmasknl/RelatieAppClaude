<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DeclarationPrint.aspx.vb" Inherits="DeclarationPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
   

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Declaratie.css" rel="stylesheet" type="text/css" />
    <title>Declaratie formulier</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:label ID="lbError" runat="server" ForeColor="red"></asp:label>
    <table id="TableResults" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="5%"></td>
                 <td colspan="2"  >
                 <asp:Label cssclass="contentheading"  id="lbRecruiterName" runat="server"></asp:Label><br />
                 <asp:Label cssclass="contentheading" id="lbPeriode" runat="server"></asp:Label>
                 </td>
                 <td width="5%"></td>
             </tr>
             <tr valign="top">
                 <td></td>
                 <td colspan="2"  ></td>
                 <td></td>
             </tr>
                 <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                <asp:gridview ID="gvDeclarations" runat="server" CssClass="grid-view"
                              AutoGenerateColumns="False" DataKeyField="Id" Width="100%" >
                <HeaderStyle CssClass="GridHeader" ></HeaderStyle>
                <Columns>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="DeclPerId" HeaderText="#" Visible="false" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="DeclaratieDate" HeaderText="Datum" DataFormatString="{0:d}" ItemStyle-Width="100" />
                    <asp:BoundField ItemStyle-HorizontalAlign="left"  DataField="Omschrijving" HeaderText="Omschrijving" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="Uren" HeaderText="Uren" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="Maaltijden" HeaderText="Maaltijden" DataFormatString="{0:C}" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="Onkosten" HeaderText="Onkosten" DataFormatString="{0:C}" />
                    <asp:BoundField ItemStyle-HorizontalAlign="left" DataField="OnkOmsc" HeaderText="Onk Omschrijving" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="Kilometers" HeaderText="Kilometers" />
                    <%-- %><asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="OnkOV" HeaderText="Reiskosten ov" DataFormatString="{0:C}" />--%>
                    <asp:BoundField ItemStyle-HorizontalAlign="left"  DataField="KmOmsc" HeaderText="km Omschrijving" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="Id" Visible="false"  />
                    <asp:BoundField ItemStyle-HorizontalAlign="center"  DataField="CreatedDate" Visible="false"  />
                 </Columns>
                </asp:gridview> 
                 
                 </td>
                 <td ></td>
             </tr>  
             <tr><td colspan="4">&nbsp; &nbsp;</td></tr>  
             <tr valign="top">
                 <td ></td>
                 <td colspan="2">
                 <asp:Label id="lbTotals" CssClass="GridHeader" runat="server">Totalen:</asp:Label>       
                <asp:gridview ID="gvTotals" runat="server" CssClass="grid-view"
                              HorizontalAlign="left"
                              AutoGenerateColumns="False"
                              Width="75%"  >
                <HeaderStyle CssClass="GridHeader" ></HeaderStyle>
                <Columns>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="Uren" HeaderText="Uren" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TotalAmountHours" HeaderText="Bedrag Uren" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TotalMeals" HeaderText="Maaltijden" DataFormatString="{0:C}"/>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="Onkosten" HeaderText="Onkosten" DataFormatString="{0:C}"/>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="Kilometers" HeaderText="Kilometers" />
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TotalAmountKm" HeaderText="Bedrag Kilometers" />
                    <%-- %><asp:BoundField ItemStyle-HorizontalAlign="center" DataField="OnkOV" HeaderText="Openbaar vervoer" DataFormatString="{0:C}" />--%>
                    <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="PeriodTotalBruto" HeaderText="Totale vergoeding" />
                  </Columns>
                </asp:gridview>                 
                 </td>
                 <td ></td>
             </tr>  
              <tr valign="top">
                 <td colspan="2" >&nbsp;<br/></td>
                 <td ></td>
              </tr>
<%--               <tr valign="top">
                 <td >&nbsp;<br/></td>
                 <td colspan="2"  >
                    <asp:Label cssclass="contentheading"  id="lblPromohead" runat="server">Gebruikte Promomaterialen</asp:Label><br />
                     <asp:Label id="lblPromo" runat="server"></asp:Label>
                 </td>
                 <td ></td>
              </tr>
--%>
              <tr valign="top">
                 <td ></td>
                 <td colspan="2"  >
                     <asp:Label id="lbCalendar" runat="server"></asp:Label>
                 </td>
                 <td ></td>
              </tr>
                <tr valign="top">
                 <td ></td>
                 <td colspan="2">
                     <br/>
                     <asp:Label id="lbLegenda" runat="server" Text="Legenda:" CssClass="GridHeader"></asp:Label><br/>
                     <asp:Label id="lbPeriodAmountPKm" runat="server" CssClass="GridHeader"></asp:Label><br/>
                     <asp:Label id="lbPeriodAmountPHour" runat="server" CssClass="GridHeader"></asp:Label><br/>
                 </td>
                 <td ></td>
              </tr> 
             </table>
    </div>
    </form>
</body>
</html>

