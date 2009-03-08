<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/NoHabilitadoParaUsuariosNoRegistrados.aspx.cs" Inherits="CedWeb.NoHabilitadoParaUsuariosNoRegistrados" %>
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
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
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
                            <asp:Label ID="Label1" runat="server" SkinID="MensajePaginaSinWidth" Text="Esta opción esta disponible sólo para USUARIOS REGISTRADOS."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top:10px; padding-left:32px; padding-right:32px">
                            <asp:Label ID="Label6" runat="server" SkinID="MensajePaginaSinWidth" Text="Si ya ha creado su cuenta eFact, identifiquese en la página de "></asp:Label>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Inicio</asp:HyperLink>
                            <asp:Label ID="Label8" runat="server" SkinID="MensajePaginaSinWidth" Text="."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top:10px; padding-left:32px; padding-right:32px;">
                            <asp:Label ID="Label14" runat="server" SkinID="MensajePaginaSinWidth" Text="Si no ha creado su cuenta eFact, y desea hacerlo, haga clic "></asp:Label>
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkMedianoClaro">aqui</asp:HyperLink>
                            <asp:Label ID="Label15" runat="server" SkinID="MensajePaginaSinWidth" Text="."></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>