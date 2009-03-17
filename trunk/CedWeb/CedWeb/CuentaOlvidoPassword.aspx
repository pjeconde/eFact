<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaOlvidoPassword.aspx.cs"
    Inherits="CedWeb.CuentaOlvidoPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">

    <table style="height: 500px; width: 800px; text-align: left;" cellpadding="0" cellspacing="0"
        border="0" class="TextoComun">
        <tr>
            <td valign="top">
                <table style="width:100%; padding-top:10px" cellpadding="0" cellspacing="0" border="0">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td valign="top" style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" Text="¿Olvidó la Contraseña de su cuenta " SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electrónica"/>
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label7" runat="server" Text="?" Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:21px"></td>
                                    <td style="padding-top:10px;" align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Para establecer una nueva Contraseña para su cuenta eFact, siga las siguientes instrucciones:" SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                            </table> 
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="padding-top:5px; padding-right:5px" valign="top" align="right">
                                        <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                    </td>
                                    <td colspan="3" style="padding-top:5px" valign="middle" align="left">
                                        <asp:Label ID="Label9" runat="server" Text="Ingrese Id.Usuario e Email (luego haga clic en el botón 'Solicitar Pregunta de seguridad')." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" SetFocusOnError="True"
                                            ControlToValidate="IdUsuarioTextBox" ErrorMessage="Id.Usuario"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="IdUsuarioTextBox" ErrorMessage="Id.Usuario">
                                            <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="IdUsuarioLabel" runat="server" Text="Id.Usuario"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="IdUsuarioTextBox" runat="server" Width="100px" TabIndex="1" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right:5px; padding-top:3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" SetFocusOnError="True"
                                            ControlToValidate="EmailTextBox" ErrorMessage="Email"
                                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="EmailTextBox" ErrorMessage="Email">
                                            <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" Width="360px" TabIndex="2" MaxLength="128"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:Button ID="SolicitarPreguntaButton" runat="server" Text="Solicitar Pregunta de seguridad" Width="360px" CausesValidation="false" TabIndex="3" OnClick="SolicitarPreguntaButton_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px; padding-right:5px" valign="top" align="right">
                                        <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                    </td>
                                    <td colspan="3" style="padding-top:5px" align="left">
                                        <asp:Label ID="Label10" runat="server" Text="Responda la Pregunta de Seguridad (luego haga clic en el botón 'Solicitar nuevo ingreso de Contraseña')." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2" style="padding-top:3px;" align="left">
                                        <asp:Label ID="PreguntaLabel" runat="server" Text="Pregunta de seguridad" SkinID="TituloMediano" Enabled="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" SetFocusOnError="True"
                                            ControlToValidate="RespuestaTextBox" ErrorMessage="Respuesta"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="RespuestaTextBox" ErrorMessage="Respuesta">
                                            <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="RespuestaTextBox" runat="server" Width="360px" TabIndex="4" Enabled="false" MaxLength="256"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:Button ID="SolicitarNuevaPasswordButton" runat="server" Text="Solicitar nuevo ingreso de Contraseña" Width="360px" Enabled="false" CausesValidation="false" TabIndex="5" OnClick="SolicitarNuevaPasswordButton_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px; padding-right:5px" valign="top" align="right">
                                        <asp:Image ID="Image10" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                    </td>
                                    <td colspan="3" style="padding-top:5px" align="left">
                                        <asp:Label ID="Label11" runat="server" Text="Ingrese, y confirme, su nueva Contraseña (luego haga click en el botón 'Aceptar')." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right:10px; padding-top:3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" SetFocusOnError="True"
                                            ControlToValidate="PasswordNuevaTextBox" ErrorMessage="Contraseña nueva"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="PasswordNuevaTextBox" ErrorMessage="Contraseña nueva">
                                            <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label1" runat="server" Text="Contraseña nueva"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-right:10px; padding-top:3px">
                                        <asp:TextBox ID="PasswordNuevaTextBox" runat="server" Width="120px" TextMode="Password" TabIndex="6" Enabled="false" OnTextChanged="TextBox_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right:10px; padding-top:3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" SetFocusOnError="True"
                                            ControlToValidate="ConfirmacionPasswordNuevaTextBox" ErrorMessage="Confirmación de Contraseña nueva"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="ConfirmacionPasswordNuevaTextBox" ErrorMessage="Confirmación de Contraseña nueva">
                                            <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label2" runat="server" Text="Confirmación"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-right:10px; padding-top:3px">
                                        <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" Width="120px" TextMode="Password" TabIndex="7" Enabled="false" OnTextChanged="TextBox_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="padding-top:5px; width:160px">
                                        <asp:Button ID="AceptarButton" runat="server" Text="Aceptar" OnClick="AceptarButton_Click" Enabled="false" TabIndex="8" />
                                    </td>
                                    <td align="right" style="padding-top:5px; width:200px">
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" PostBackUrl="~/Inicio.aspx" CausesValidation="false" TabIndex="9"> </asp:Button>
                                    </td>
                                    <td style="width:250px"></td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top:10px">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"/>
                        </td>
                    </tr>
                    <!-- @@@ @@@-->
                </table>
            </td>
            <td valign="top" style="width: 30px">
            </td>
        </tr>
    </table>
</asp:Content>
