<%@ Page Language="C#" MasterPageFile="CedWebautenticado.master" AutoEventWireup="true" CodeFile="~/Autenticado/Acerca.aspx.cs" Inherits="CedWeb.Autenticado.Acerca" %>
<asp:Content ID="ContentAcerca" ContentPlaceHolderID="ContentPlaceHolderAutenticado" runat="server">
    <table style="height: 500px; width: 850px">
        <tr>
            <td align="center" valign="top">
                <table>
                    <tr><td style="height: 10px"></td></tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="NombreAplicLabel" runat="server" SkinID="TituloPagina" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="de"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="PropietarioLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                        </td>
                    </tr>
                    <tr><td style="height: 10px"></td></tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="CodigoAplicLabel" runat="server" SkinID="TituloChico"></asp:Label>
                        </td>
                    </tr>
                    <tr><td style="height: 10px"></td></tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="VersionLabel" runat="server" SkinID="TituloMediano"></asp:Label>
                        </td>
                    </tr>
                    <tr><td style="height: 20px"></td></tr>
                    <tr>
                        <td style="padding-right:4px">
                            <asp:Label ID="Label2" runat="server" SkinID="TituloChico" Text="Desarrollado por:"></asp:Label>
                        </td>
                        <td>
                            <img src="../Imagenes/Acerca.gif" alt="Acerca"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
