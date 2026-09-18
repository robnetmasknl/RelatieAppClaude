<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="password.aspx.vb" Inherits="password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="776px" Font-Bold="True"></asp:Label>
<asp:MultiView id="MultiView1" runat="server">

<asp:View ID="ResetView" runat="server">

    <h3 class="HdrTitle" ></h3>
         <table id="Table1" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  class="contentheading_artikelen">Vul hieronder uw lidmaatschapnummer in.</td>
                 <td width="25%"></td>
             </tr>

             <tr><td colspan="4">&nbsp; &nbsp;</td></tr>
             <tr >
                 <td ></td>
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
                 <td>
                 </td>
                 <td align="left">
                     <asp:Button ID="btnGo" runat="server" Text="volgende" Width="150px" UseSubmitBehavior="true" />
                 </td>
                 <td></td>
             </tr>
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
          
             </table>
  </asp:View>
    <asp:View ID="VerifyView" runat="server">
    <h3 class="HdrTitle" ></h3>
         <table id="VerifyTable" class="inside" width="100%" border="0" align="left">
             <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2" ><asp:Label  ID="lblVerifyEmail" runat="server" Text="emailvraag"></asp:Label></td>
                 <td width="25%"></td>
             </tr>
             <tr><td colspan="4">&nbsp; &nbsp;</td></tr>
             <tr valign="top">
                 <td>
                 </td>
                 <td>
                 </td>
                 <td align="left">
                     <asp:Button ID="btnReset" runat="server" Text="Reset wachtwoord" Width="150px" />
                 </td>
                 <td></td>
             </tr>
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
          
             </table>
  </asp:View>
  <asp:View ID="ResetDoneView" runat="server">  
     <table id="Table2" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  class="contentheading_artikelen">Wachtwoord reset.</td>
                 <td width="25%"></td>
             </tr>
             <tr><td colspan="4">&nbsp; &nbsp;</td></tr>
             <tr >
                 <td></td>
                 <td></td>
                 <td>
                     <asp:hiddenfield ID="hdnLidNr" runat="server" ></asp:hiddenfield>
                  </td>
                 <td ></td>
             </tr>
 
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
             <tr valign="top">
                 <td>
                 </td>
                 <td colspan ="2" align="left">
                        U ontvangt een bericht via u opgegeven emailadres om het wachtwoord opnieuw op te geven.
                        <br /> Uw wachtwoord wordt gereset nadat u deze heeft bevestigd.
                 </td>
                 <td></td>
             </tr>             
             </table>
  </asp:View>
 </asp:MultiView>
</asp:Content>

