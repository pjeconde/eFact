<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Contacto.aspx.cs"
    Inherits="CedWeb.Contacto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top">
                <table style="width: 100%; padding-top:10px" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
                    <tr>
                        <td align="left" valign="top" style="padding-left: 10px">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" Text="Contacto a través de:" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>                        
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr><td style="height:10px"></td></tr>
                    <tr>
                        <td align="left" style="padding-left:70px" colspan="2">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table id="ContactoTable" border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr>
                                    <td colspan="2" style="width: 230px" align="left">
                                        <asp:Label ID="CorreoElectronicoLabel" runat="server" Text="Correo electrónico" SkinID="TituloMediano"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:HyperLink ID="eMailInfoHyperLink" runat="server" NavigateUrl='mailto:info@cedeira.com.ar'>info@cedeira.com.ar</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-top:10px">
                                        <asp:Label ID="FormularioElectronicoLabel" runat="server" Text="Formulario electrónico"
                                            SkinID="TituloMediano" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td align="right" style="padding-top:10px; padding-right:5px">
                                        <asp:Label ID="MotivoLabel" runat="server" Text="Motivo"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:10px">
                                        <asp:RadioButton ID="FactElectronicaRadioButton" runat="server" Text="Factura electrónica"
                                            Checked="false" GroupName="Motivo" />
                                        <asp:RadioButton ID="OtrosRadioButton" runat="server" Text="Otro" Checked="true"
                                            GroupName="Motivo" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td  align="right" style="width:60px; padding-top:3px; padding-right:5px">
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" Width="360px" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:Label ID="TelefonoLabel" runat="server" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="TelefonoTextBox" runat="server" Width="360px" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" Width="360px" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="bottom" style="padding-top:3px">
                                        <asp:Image ID="CaptchaImage" runat="server" Height="60px" Width="150px" AlternateText="" />
                                    </td>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:Label ID="MensajeLabel" runat="server" Text="Mensaje"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="MensajeTextBox" runat="server" Width="360px" Height="100px" TextMode="MultiLine" TabIndex="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center" style="padding-top:3px">
                                        <asp:Button ID="NuevaClaveCaptchaButton" runat="server" Text="Nueva Clave" OnClick="NuevaClaveCaptchaButton_Click">
                                        </asp:Button>
                                    </td>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:Label ID="ClaveLabel" runat="server" Text="Clave"></asp:Label>
                                    </td>
                                    <td align="left" style="width:80px; padding-top:3px">
                                        <asp:TextBox ID="CaptchaTextBox" runat="server" Width="80px" TabIndex="5"></asp:TextBox>
                                    </td>
                                    <td align="left" style="padding-top:3px; padding-left:3px; width:280px">
                                        <asp:Label ID="CaseSensitiveLabel" runat="server" ForeColor="gray" Text="(no se distinguen mayúsculas de minúsculas)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top:10px">
                                        <asp:Button ID="EnviarButton" runat="server" Text="Enviar" OnClick="EnviarButton_Click" Width="80px" TabIndex="6">
                                        </asp:Button>
                                    </td>
                                    <td align="right" style="padding-top:10px; padding-right:2px">
                                        <asp:Button ID="BorrarDatosButton" runat="server" Text="Borrar Datos" OnClick="BorrarDatosButton_Click">
                                        </asp:Button>
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" Width="100px" PostBackUrl="~/Inicio.aspx">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width: 30px">
            </td>
        </tr>
    </table>
</asp:Content>
