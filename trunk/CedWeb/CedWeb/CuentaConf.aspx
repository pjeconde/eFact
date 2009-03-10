<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaConf.aspx.cs" Inherits="CedWeb.CuentaConf" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" runat="Server">
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
                                        <asp:Label ID="Label5" runat="server" Text="Confirmación de creación de cuenta" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electrónica"/>
                                    </td>
                                </tr>
                            </table>
                        <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top:10px; padding-left:32px; padding-right:32px">
                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top:10px; padding-left:32px">
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="red" Text="»" ></asp:Label>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Ir a Inicio</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
