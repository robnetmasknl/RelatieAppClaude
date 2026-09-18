<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Reservation.aspx.vb" Inherits="Reservation"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%--<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Globalization" %>

<script runat="server">
    Protected Overrides Sub InitializeCulture()
        Thread.CurrentThread.CurrentCulture = _
            CultureInfo.CreateSpecificCulture("nl-NL")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("nl-NL")
   
        MyBase.InitializeCulture()
    End Sub
</script>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">



<asp:Label ID="lblError" runat="server" ForeColor="Red" Width="776px" Font-Bold="True"></asp:Label>
<asp:MultiView id="MultiView1" runat="server">

<asp:View ID="ReservationView" runat="server">

    <h3 class="HdrTitle" >Boeken:</h3>
    
     <table id="Table2" class="inside" width="100%" border="0" align="center">
             <tr valign="top">
                 <td width="25%"></td>
                 <td width="15%">locatie:</td>
                 <td width="35%">
                    <asp:DropDownList ID="ddlLocations" runat="server" AutoPostBack="True">                    
                    </asp:DropDownList>         
                 </td>
                 <td width="25%"></td>
             </tr>
              <tr valign="top">
                 <td>Het aanvang tijdstip is het eerst beschikbare tijdstip. <br /><br />Klik op een datum om meer beschikbare tijdstippen te zien.<br> <input type="button" value="Ga terug..." onclick="window.history.back()" />&nbsp; </td>
                 <td colspan="3">
                     <asp:GridView ID="grdvBlokken" runat="server" CellPadding="4" 
                         ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                         PageSize="100" Width="60%">
                         <RowStyle BackColor="#EFF3FB" />
                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <EditRowStyle BackColor="#2461BF" />
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>    
                            <%--    
                            <asp:HyperLinkField DataTextField="id" HeaderText="Kies" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reservation.aspx?BlokId={0}"  />
                            <asp:BoundField DataField="LocatieNaam" HeaderText="locatie" />
                            <asp:BoundField DataField="BlokTypeTijdsduur" HeaderText="tijdsduur" ItemStyle-HorizontalAlign="center"/>
                            <asp:BoundField DataField="VanafOfTot" HeaderText="Vanaf/Tot" />
                            <asp:BoundField DataField="AantalBeschikbaar" HeaderText="Aantal Beschikbaar" ItemStyle-HorizontalAlign="center" />
                            <asp:BoundField DataField="AdviseurNaam" HeaderText="adviseur" />
                            <asp:BoundField DataField="Aantalboekingen" HeaderText="Aantal boekingen" />
                            <asp:BoundField DataField="datum" DataFormatString="{0:d}" HeaderText="datum" ItemStyle-HorizontalAlign="center"/>
                            <asp:HyperLinkField DataTextField="datum" HeaderText="datum" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/reservation.aspx?BlokId={0}" />
                          --%>
                            <asp:TemplateField>
                                 <ItemTemplate>
                                    <asp:hyperlink ID="hlDateId" HeaderText="datum" runat="server" text=""></asp:hyperlink>
                                 </ItemTemplate>                    
                             </asp:TemplateField>
                              <asp:BoundField DataField="VolgendeTijdstip" DataFormatString="{0:HH:mm}" HeaderText="aanvang" ItemStyle-HorizontalAlign="center"/>
                           

             
                       </Columns>
                     </asp:GridView>
                  </td>
             </tr>
             </table>
</asp:View>
<asp:View ID="BlokView" runat="server">

    <h3 class="HdrTitle" >Blok:</h3>
    
     <table id="Table1" class="inside" width="100%" border="0" align="left">
             <tr valign="top">
                 <td width="25%"></td>
                 <td>
                     <asp:HiddenField ID="hiddenBlokid" runat="server" />
                     <asp:HiddenField ID="hiddenVolgendeBoekingid" runat="server" />
                 </td>
                 <td> </td>
                 <td width="25%"></td>
             </tr>
             <tr valign="top">
                 <td></td>
                 <td>Lidnr:</td>
                 <td><asp:Label ID="lblLidnr" runat="server"></asp:Label> </td>
                 <td></td>
             </tr>
             <tr valign="top">
                 <td></td>
                 <td>Locatie:</td>
                 <td><asp:Label ID="lbllocatie" runat="server"></asp:Label> </td>
                 <td></td>
             </tr>
             <tr valign="top">
                 <td></td>
                 <td>Tijdstip:</td>
                 <td><asp:Label ID="lblTijdstip" runat="server"></asp:Label> </td>
                 <td></td>
             </tr>
                <%--             
               <tr valign="top">
                 <td></td>
                 <td>Adviseur:</td>
                 <td><asp:Label ID="lblAdviseur" runat="server"></asp:Label> </td>
                 <td></td>
             </tr>
              --%>
             <tr valign="top">
                 <td></td>
                 <td>klik op "Reserveer"</td>
                 <td align="left">
                    <asp:Button ID="btnConfrim" runat="server" Text="Reserveer"  />
                 </td>
                 <td></td>
             </tr>
              <tr valign="top">
                 <td></td>
                 <td colspan="2">
                     <asp:GridView ID="grdvBoekingen" runat="server" CellPadding="4" 
                         ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                         PageSize="100" Width="60%">
                         <RowStyle BackColor="#EFF3FB" />
                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <EditRowStyle BackColor="#2461BF" />
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>                         
                             <asp:TemplateField>
                                 <ItemTemplate>
                                    <asp:hyperlink ID="hlBlokId" runat="server" text="bezet"></asp:hyperlink>
                                 </ItemTemplate>                    
                             </asp:TemplateField>
                            <%--                            
                            <asp:BoundField DataField="id" HeaderText="id"  />
                            <asp:BoundField DataField="lidId" HeaderText="lidnr" />
                            --%>
                            <asp:BoundField DataField="tijdstip" DataFormatString="{0:d}" HeaderText="datum" />
                            <asp:BoundField DataField="tijdstip" DataFormatString="{0:HH:mm}" HeaderText="tijdstip" />
                            <%--<asp:CheckBoxField DataField="voorlopig" Text="voorlopig" />--%>
                         </Columns>
                     </asp:GridView>

                  </td>
                 <td>
                  </td>
             </tr>
             </table>
</asp:View>

<asp:View ID="BlokViewAdviseur_new" runat="server">
<h3 class="HdrTitle" >
<asp:Label ID="lbWelcome" runat="server"></asp:Label>
</h3>
<h3 class="HdrTitle" >Selecteer locatie en datum.</h3>
    
     <table id="tblAdviseurs" class="inside" width="100%" border="0" align="center">
             <tr valign="top">
                 <td width="25%"></td>
                 <td width="15%">locaties:</td>
                 <td width="35%">
                    <asp:DropDownList ID="ddlLocations_adviseurs" runat="server" AutoPostBack="True">                    
                    </asp:DropDownList>         
                 </td>
                 <td width="25%"></td>
             </tr>
              <tr valign="top">
                 <td></td>
                 <td colspan="3"></td>
             </tr>
                 <tr valign="top">
                 <td width="25%"></td>
                 <td width="15%">locatie data:</td>
                 <td width="35%">
                    <asp:DropDownList ID="ddlData" runat="server" AutoPostBack="True">                    
                    </asp:DropDownList>         
                 </td>
                 <td width="25%"><input type="button" value="Ga terug..." onclick="window.history.back()" />&nbsp;  </td>
             </tr>
             <tr valign="top">
                 <td colspan="4">
                   <h3 class="HdrTitle" ><asp:Label ID="lblSelected" runat="server"></asp:Label></h3>
                  </td>
             </tr>
                 <tr valign="top">
                   <td colspan="4">
                     <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                         ForeColor="#333333" GridLines="None" AutoGenerateColumns="True" 
                         PageSize="100" Width="100%">
                         <RowStyle BackColor="#EFF3FB" />
                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <EditRowStyle BackColor="#2461BF" />
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                         </Columns>
                     </asp:GridView>

                  </td>
             </tr>
             </table>
</asp:View>

    <asp:View ID="VolmachtView" runat="server">
       <h3 class="HdrTitle" >&nbsp;</h3>
        <table width="100%" align="left" class="inside" border="0">
            <tr>
                <td width="15%"></td>
                <td width="60%">Klik op <asp:Button ID="btnVMAkkoord" runat="server" Text="Bevestigen" OnClick="btnVMAkkoord_Click" /> als u wilt dat wij op afstand uw aangifte(n) doen voor 1 Mei 2026. 
                 </td>                 
                 <td width="25%">
                </td>
            </tr>
           <tr valign="top">
                 <td> </td>    

                 <td align="left">
                    
                  </td>
                 <td>&nbsp;</td>
             </tr>
           <tr valign="top">
                 <td> </td>    

                 <td align="left">&nbsp; </td>
                 <td>Zo niet klik op...<input type="button" value="Ga terug..." onclick="window.history.back()" />&nbsp; </td>
             </tr>
           <tr valign="top">
                 <td> </td>    

                 <td align="left">
                    
                  </td>
                 <td>&nbsp;</td>
             </tr>
    </table>
</asp:View>
</asp:MultiView>

</asp:Content>

