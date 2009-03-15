<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/SoloDispPUsuariosAdministradores.aspx.cs" Inherits="CedWeb.SoloDispPUsuariosAdministradores" %>
<asp:Content ID="ExContent" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" runat="Server">
    <table style="height: 500px; width: 800px; text-align: left;" cellpadding="0" cellspacing="0"
        border="0" class="TextoComun">
        <tr>
            <td valign="top">
                <table style="width:100%; padding-top:10px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="padding-left: 10px">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top:10px; padding-left:32px; padding-right:32px">
                            <asp:Label ID="Label1" runat="server" SkinID="MensajePaginaSinWidth" Text="Esta opción esta disponible sólo para USUARIOS ADMINISTRADORES."></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>