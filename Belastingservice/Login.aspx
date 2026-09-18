<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="logincls" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="phContent" Runat="Server">
     <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="776px" Font-Bold="True"></asp:Label>

<asp:MultiView ID="MultiView1" runat="server">

<asp:View ID="LoginView" runat="server" >
   
    <h3 class="HdrTitle" >Aanmelden:</h3>
    
     <table id="Table2" class="inside" width="100%" border="0" align="left">
              <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2"  >Hier kunt u zich aanmelden voor de belastingservice.</td>
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
                     <asp:Button ID="btnGo" runat="server" Text="Inloggen" Width="150px" />
                 </td>
                 <td></td>
             </tr>
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
             <tr valign="top">
                 <td>
                 </td>
                 <td colspan ="3" align="left">
                     Bent u uw wachtwoord kwijt? Klik dan <asp:HyperLink ID="hplPasswordReset" runat="server" NavigateUrl="password.aspx"> HIER </asp:HyperLink> om uw wachtwoord te resetten.<br />
                     U ontvangt dan een bericht via u opgegeven emailadres om het wachtwoord opnieuw op te geven.
                 </td>
             </tr>
              <tr valign="top">
                 <td>
                 </td>
                 <td colspan ="3" align="left">
                     Heeft u nog geen wachtwoord? Klik dan <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Search.aspx"> HIER </asp:HyperLink> om uw wachtwoord aan te maken <br />
                  </td>
             </tr>      
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
                     <asp:Button ID="btnYes" runat="server" Text="Ja" Width="150px" />
                      <asp:Button ID="BtnNo" runat="server" Text="Nee" Width="150px" />
                 </td>
                 <td></td>
             </tr>
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
          
             </table>
  </asp:View>
<asp:View ID="ChangeMailView" runat="server">
    <h3 class="HdrTitle" ></h3>
         <table id="VerifyTableMail" class="inside" width="100%" border="0" align="left">
             <tr valign="top">
                 <td width="25%"></td>
                 <td colspan="2" ><asp:Label  ID="Label10" runat="server" Text="Vul het juiste emailadres en mobielenummer in en klik op opslaan."></asp:Label></td>
                 <td width="25%"></td>
             </tr>
             <tr>
                 <td></td>
                 <td width="25%"><asp:Label ID="Label17" runat="server" Text="Email:"></asp:Label></td>
                 <td  >                    
                     <asp:TextBox ID="tbChangeEmail" runat="server"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                         ControlToValidate="tbEmail" ErrorMessage="ongeldig emailadres" Font-Bold="True" 
                         ValidationExpression="[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEmail" 
                            ErrorMessage="verplicht veld" Font-Bold="true" />
                 </td>
                 <td width="25%"></td>
             </tr>
             <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label15" runat="server" Text="telefoonnummer:"></asp:Label>
                 </td>                 
                <td>
                    <asp:TextBox ID="tbChangePhone" runat="server" ></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label21" runat="server" Text="Mobiel:"></asp:Label>
                 </td>                 
                 <td>
                   <asp:TextBox ID="tbChangeMobile" runat="server" ></asp:TextBox>
                </td>
                <td></td>
            </tr>
             <tr><td colspan="4">&nbsp; &nbsp;</td></tr>
             <tr valign="top">
                 <td>
                 </td>
                 <td>
                 </td>
                 <td align="left">
                     <asp:Button ID="btnSaveMail" runat="server" Text="Opslaan" Width="150px" />
                 </td>
                 <td></td>
             </tr>
              <tr><td colspan="4">&nbsp; &nbsp;</td></tr>             
          
             </table>
  </asp:View>
<asp:View ID="LoginResult" runat="server">
       <h3 class="HdrTitle" >NAW Gegevens</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td >
                    <asp:Label ID="Label3" runat="server" Text="Lidmaatschapnummer:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="LblLidNr" runat="server"></asp:Label>
                </td>
                <td width="25%"></td>
            </tr>
            <tr>
            <td></td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Naam:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
             <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label20" runat="server" Text="Adres:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblAdres" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Postcode:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblPostcode" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>       
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Woonplaats:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblWoonplaats" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr> 
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label101" runat="server" Text="Geboortedatum:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblDateOfBirth" runat="server" ></asp:Label>
                </td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>    
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Wachtwoord:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblWachtwoord" runat="server"  ></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="bevestigd:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblConfirmd" runat="server" ></asp:Label>
                </td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label11" runat="server" Text="telefoonnummer:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblTelephone" runat="server" ></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label23" runat="server" Text="Mobiel:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblMobile" runat="server" ></asp:Label>
                </td>
                <td></td>
            </tr>
    </table>

</asp:View>
<asp:View ID="RegistrationView" runat="server">
           			 <style type="text/css">
			 .auto-style2 {
				 text-align: left;
				 margin-left: 40px;
			 }
			 </style>

			 <p class="auto-style2">Wij hebben een email adres nodig om een bevestiging email naar u te kunnen sturen. In deze bevestiging mail staat een link die u moet klikken om de aanmelding te voltooien. 
             De belastingservice is beveiligd met een wachtwoord dat u hier zelf kunt aanmaken.
             U ontvangt uw aanmeldgegevens ook in deze email. 
             Graag krijgen wij ook uw telefoonnummer of mobiele nummer.Om in te kunnen loggen op onze belasting service website heeft u inloggegevens &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nodig die u hier kunt aanmaken.
             <br />

			 </p>

       
       
       <h3 class="HdrTitle" >
           Aanmelding.</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td > <asp:Label ID="Label1" runat="server" Text="Lidmaatschapnummer:"></asp:Label>     </td>                 
                <td> <asp:Label ID="lblLidnrReg" runat="server"></asp:Label>     </td>
                <td width="15%"></td>
            </tr>
            <tr>
            <td></td>
                <td> <asp:Label ID="Label12" runat="server" Text="Naam:"></asp:Label>                 </td>                 
                <td> <asp:Label ID="lblNameReg" runat="server"></asp:Label>                </td>
                <td></td>
            </tr>

           <tr>
                <td></td>
                <td> <asp:Label ID="Label18" runat="server" Text="Geboortedatum:"></asp:Label>                 </td>                 
                <td> <asp:Label ID="lblDateOfBirthReg" runat="server" ></asp:Label>                </td>
                <td></td>
            </tr>
             <tr>
                <td></td>
                <td> <asp:Label ID="Label14" runat="server" Text="Lid sinds:"></asp:Label>                 </td>                 
                <td> <asp:Label ID="lblLidsindsReg" runat="server" ></asp:Label>                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td> <asp:Label ID="Label13" runat="server" Text="Email:"></asp:Label>                 </td>                 
                <td> <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="regxEmail" runat="server" 
                         ControlToValidate="tbEmail" ErrorMessage="ongeldig emailadres" Font-Bold="True" 
                         ValidationExpression="[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" 
                            ErrorMessage="verplicht veld" Font-Bold="true" />
                </td>
                <td></td>
            </tr>   
            <tr>
                <td></td>
                <td> <asp:Label ID="Label16" runat="server" Text="Wachtwoord:" ></asp:Label>
                </td>                 
                <td>
                    <asp:TextBox ID="tbWachtwoord" runat="server"  TextMode="Password" 
                         CausesValidation="True"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvWachtwoord" runat="server" ControlToValidate="tbWachtwoord" 
                            ErrorMessage="verplicht veld" Font-Bold="true" />
                 </td>
                <td></td>
            </tr>
           <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Bevestig Wachtwoord:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:TextBox ID="tbWachtwoordConfirm" runat="server"   TextMode="Password"></asp:TextBox>
                      <asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Wachtwoorden komen niet overeen!" 
             ControlToValidate="tbWachtwoord"  ControlToCompare="tbWachtwoordConfirm" ></asp:CompareValidator>
                 </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label19" runat="server" Text="telefoonnummer:"></asp:Label>
                 </td>                 
                <td>
                    <asp:TextBox ID="tbTelephoneReg" runat="server" ></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label22" runat="server" Text="Mobiel:"></asp:Label>
                 </td>                 
                 <td>
                   <asp:TextBox ID="tbMobileReg" runat="server" ></asp:TextBox>
                </td>
                <td></td>
            </tr>
             <tr valign="top">
                 <td>
                 </td>
                 <td>
                 </td>
                 <td align="left" colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Aanmelden" OnClick="btnRegister_Click"/>
                  </td>
             </tr>
    </table>
</asp:View>
    <asp:View ID="ANPVView" runat="server">
                   			 <style type="text/css">
			 .auto-style2 {
				 text-align: left;
				 margin-left: 40px;
			 }
			 </style>

			 <p class="auto-style2">Wij hebben een email adres nodig om een bevestiging email naar u te kunnen sturen. In deze bevestiging mail staat een link die u moet klikken om de aanmelding te voltooien. 
             De belastingservice is beveiligd met een wachtwoord dat u hier zelf kunt aanmaken.
             U ontvangt uw aanmeldgegevens ook in deze email. 
             Graag krijgen wij ook uw telefoonnummer of mobiele nummer.Om in te kunnen loggen op onze belasting service website heeft u inloggegevens &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; nodig die u hier kunt aanmaken.
             <br />

			 </p>

       
       
       <h3 class="HdrTitle" >
           Aanmelding.</h3>
        <table width="100%" align="left" class="inside">
            <tr>
                <td width="25%"></td>
                <td >
                    <asp:Label ID="Label24" runat="server" Text="Lidmaatschapnummer:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:Label ID="lblLidnrRegTA" runat="server"></asp:Label>
                </td>
                <td width="15%"></td>
            </tr>
            <tr>
            <td></td>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Naam \ Initialen:"></asp:Label>
                 </td>                 
                 <td>
                     <asp:TextBox ID="tbNameRegTA" runat="server" ></asp:TextBox><asp:TextBox ID="tbInitTA" runat="server" Width="100" ></asp:TextBox>
                </td>
                <td></td>
            </tr>

           <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="Geboortedatum:"></asp:Label>
                 </td>                 
                 <td>
                     <asp:TextBox ID="DateOfBirthRegTA" runat="server" ></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="Label28" runat="server" Text="Email:"></asp:Label>
                 </td>                 
                 <td>
                    <asp:TextBox ID="tbEmailTA" runat="server"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                         ControlToValidate="tbEmailTA" ErrorMessage="ongeldig emailadres" Font-Bold="True" 
                         ValidationExpression="[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbEmailTA" 
                            ErrorMessage="verplicht veld" Font-Bold="true" />
                 </td>
                <td></td>
            </tr>   
            <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label29" runat="server" Text="telefoonnummer:"></asp:Label>
                 </td>                 
                <td>
                    <asp:TextBox ID="tbTelephoneRegTA" runat="server" ></asp:TextBox>
                    </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                 <td>
                    <asp:Label ID="Label30" runat="server" Text="Mobiel:"></asp:Label>
                 </td>                 
                 <td>
                   <asp:TextBox ID="tbMobileRegTA" runat="server" ></asp:TextBox>
                </td>
                <td></td>
            </tr>
             <tr valign="top">
                 <td>
                 </td>
                 <td>
                 </td>
                 <td align="left" colspan="2">
                    <asp:Button ID="btnRegisterA" runat="server" Text="Aanmelden" OnClick="btnRegisterA_Click"/>
                  </td>
             </tr>
    </table>
</asp:View>

    <asp:View ID="VolmachtView" runat="server">
           			 <style type="text/css">
			 .auto-style2 {
				 text-align: left;
				 margin-left: 40px;
			 }
			 </style>
           
       
     <h3 class="HdrTitle" > Machtiging.</h3>

    <table width="100%" align="left" class="inside" border="0">
            <tr valign="top">
              <td width="10%"></td>
                <td colspan="2"  >Heeft u een machtiging gegeven (en indien van toepassing ook voor uw fiscale partner), 
                 wijkt uw aangifte niet veel af van vorig jaar en <b>wenst u dat wij uw aangifte op afstand verzorgen</b> zodat u niet naar een locatie hoeft te komen?<br> Klik dan op MACHTIGING.</td>
            <td width="10%"></td>
            </tr>
            <tr>
                <td colspan="4">  &nbsp; &nbsp;
                </td>
            </tr>

            <tr>
              <td width="10%"></td>
                <td colspan="2"  >Heeft u geen machtiging gegeven? Klik dan op OP LOCATIE.</td>
            <td width="10%"></td>
            </tr>
            <tr>
                <td colspan="4">  &nbsp; &nbsp;
                </td>
            </tr>

            <tr>
               <td colspan="4">  &nbsp; &nbsp;
               </td>

            </tr>
            <tr valign="top">
              <td>  &nbsp; &nbsp; </td>
                 <td align="center" >
                    <asp:Button ID="btnVMJa" width="120px" runat="server" Text="MACHTIGING" OnClick="btnVMJa_Click"/> &nbsp;   </td>                                   
                 <td align="left" >
                    <asp:Button ID="btnVMnee" width="120px" runat="server" Text="OP LOCATIE" OnClick="btnVMNee_Click"/>
                  </td>
              <td>  &nbsp;        </td>
           </tr>
           <tr>
              <td colspan="4">  &nbsp; &nbsp;
              </td>

           </tr>

    </table>
</asp:View>

</asp:MultiView>
</asp:Content>

