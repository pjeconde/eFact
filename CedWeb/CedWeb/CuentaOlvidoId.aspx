<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaOlvidoId.aspx.cs"
    Inherits="CedWeb.CuentaOlvidoId" %>

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
                                    <td style="width:21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height:20px;">
                                        <asp:Label ID="TituloLabel" runat="server" Text="¿Olvidó el Id.Usuario de su cuenta " SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td style="height:20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electrónica"/>
                                    </td>
                                    <td style="height:20px;">
                                        <asp:Label ID="Label7" runat="server" Text="?" Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>  
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:21px"></td>
                                    <td style="padding-top:10px;" align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Si no recuerda el Id.Usuario de su cuenta eFact, ingrese el eMail, que registró en el momento de creación de su cuenta." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:21px"></td>
                                    <td style="padding-top:5px;" align="left">
                                        <asp:Label ID="Label9" runat="server" Text="<b>Le enviaremos su Id.Cuenta por correo electrónico</b>, a esa dirección." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                            </table>  
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-top:20px" align="center">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="right" style="padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" SetFocusOnError="True"
                                            ControlToValidate="EmailTextBox" ErrorMessage="Email"
                                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="EmailTextBox" ErrorMessage="Email">
                                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:TextBox ID="EmailTextBox" runat="server" Width="360px" TabIndex="3" MaxLength="128"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="padding-top:10px">
                                        <asp:Button ID="AceptarButton" runat="server" Text="Solicitar Id.Usuario" OnClick="AceptarButton_Click" TabIndex="4" />
                                    </td>
                                    <td align="right" style="padding-top:10px">
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" PostBackUrl="~/Inicio.aspx" CausesValidation="false" TabIndex="5"> </asp:Button>
                                    </td>
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
