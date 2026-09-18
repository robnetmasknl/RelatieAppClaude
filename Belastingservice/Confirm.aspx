<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Confirm.aspx.vb" Inherits="Confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">

   <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="776px" Font-Bold="True"></asp:Label>
    
<asp:MultiView id="MultiView1" runat="server">

<asp:View ID="ConfirmView" runat="server">
       <h3 class="HdrTitle" ></h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td ></td>                 
                 <td>Er is een email naar uw opgegeven adres verzonden.<br/>
                 Bevestig de ontvangen mail dmv de link in het bericht.<br /><br />
                 Heeft u binnen 15 minuten geen bevestigings emailbericht ontvangen,<br />
                  Neem dan contact op met de vakbond.&nbsp;&nbsp;&nbsp;telefoon 070 3155111
                 </td>
                <td width="25%"></td>
            </tr>
          </table>
</asp:View>
<asp:View ID="ProcessedActivationView" runat="server">
       <h3 class="HdrTitle" >Bevestiging inschrijving.</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td ></td>                 
                 <td>
                 Dank u.<br/>
                 <asp:label ID="lblPA_Message" runat="server" ></asp:label><br /><br />
                 <br />           
                 </td>
                <td width="25%"></td>
            </tr>
          </table>
</asp:View>
<asp:View ID="ProcessedReservationView" runat="server">
       <h3 class="HdrTitle" >Bevestiging reservering.</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td ></td>                 
                 <td>
                 Dank u.<br/>
                 <asp:label ID="lblPR_Message" runat="server" ></asp:label><br /><br />
                 <br />
           
                 </td>
                <td width="25%"></td>
            </tr>
          </table>
</asp:View>
<asp:View ID="ProcessedPasswordView" runat="server">
       <h3 class="HdrTitle" >wachtwoord reset.</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td ></td>                 
                 <td>
                 Dank u.<br/>
                 <asp:label ID="lblPP_Message" runat="server" ></asp:label><br /><br />
                 <br />
           
                 </td>
                <td width="25%"></td>
            </tr>
          </table>
</asp:View>
<asp:View ID="ProcessedEmailView" runat="server">
       <h3 class="HdrTitle" >Email wijziging.</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td ></td>                 
                 <td>
                 Dank u.<br/>
                 <asp:label ID="lblEmail_Message" runat="server" ></asp:label><br /><br />
                 <br />
           
                 </td>
                <td width="25%"></td>
            </tr>
          </table>
</asp:View>
    <asp:View ID="ProcessedVolmachtView" runat="server">
       <h3 class="HdrTitle" >Bevestiging aanmelding.</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td ></td>                 
                 <td>
                <br/>
                 <asp:label ID="lblVolmacht_Message" runat="server" ></asp:label><br /><br />
                 <br />
           
                 </td>
                <td width="25%"></td>
            </tr>
          </table>
</asp:View>
</asp:MultiView>
</asp:Content>

