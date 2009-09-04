<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="CedeiraAJAX.Contacto"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" style="height: 500px; width: 800px">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 100%;
                    padding-top: 10px">
                    <tr>
                        <td align="left" style="padding-left: 10px" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Contacto a través de:"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-left: 70px">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table id="ContactoTable" border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr>
                                    <td align="left" colspan="2" style="width: 230px">
                                        <asp:Label ID="CorreoElectronicoLabel" runat="server" Font-Bold="true" SkinID="TituloMediano"
                                            Text="Correo electrónico"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:HyperLink ID="eMailInfoHyperLink" runat="server" NavigateUrl='mailto:info@cedeira.com.ar'>info@cedeira.com.ar</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Label ID="FormularioElectronicoLabel" runat="server" Font-Bold="true" SkinID="TituloMediano"
                                            Text="Formulario electrónico"></asp:Label>
                                    </td>
                                    <td align="right" style="padding-top: 10px; padding-right: 5px">
                                        <asp:Label ID="MotivoLabel" runat="server" Text="Motivo"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 10px">
                                        <asp:RadioButton ID="FactElectronicaRadioButton" runat="server" Checked="false" GroupName="Motivo"
                                            Text="Factura electrónica" />
                                        <asp:RadioButton ID="OtrosRadioButton" runat="server" Checked="true" GroupName="Motivo"
                                            Text="Otro" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="width: 60px; padding-top: 3px; padding-right: 5px">
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" TabIndex="1" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:Label ID="TelefonoLabel" runat="server" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="TelefonoTextBox" runat="server" TabIndex="2" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" TabIndex="3" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 3px" valign="bottom">
                                        <asp:Image ID="CaptchaImage" runat="server" AlternateText="" Height="60px" Width="150px" />
                                    </td>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:Label ID="MensajeLabel" runat="server" Text="Mensaje"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="MensajeTextBox" runat="server" Height="100px" TabIndex="4" TextMode="MultiLine"
                                            Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 3px" valign="top">
                                        <asp:Button ID="NuevaClaveCaptchaButton" runat="server" OnClick="NuevaClaveCaptchaButton_Click"
                                            Text="Nueva Clave" />
                                    </td>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:Label ID="ClaveLabel" runat="server" Text="Clave"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 80px; padding-top: 3px">
                                        <asp:TextBox ID="CaptchaTextBox" runat="server" TabIndex="5" Width="80px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="padding-top: 3px; padding-left: 3px; width: 280px">
                                        <asp:Label ID="CaseSensitiveLabel" runat="server" ForeColor="gray" Text="(no se distinguen mayúsculas de minúsculas)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Button ID="EnviarButton" runat="server" OnClick="EnviarButton_Click" TabIndex="6"
                                            Text="Enviar" Width="80px" />
                                    </td>
                                    <td align="right" style="padding-top: 10px; padding-right: 2px">
                                        <asp:Button ID="BorrarDatosButton" runat="server" OnClick="BorrarDatosButton_Click"
                                            Text="Borrar Datos" />
                                        <asp:Button ID="CancelarButton" runat="server" PostBackUrl="~/Inicio.aspx" Text="Cancelar"
                                            Width="100px" />
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
                                    <td align="center" colspan="2">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
