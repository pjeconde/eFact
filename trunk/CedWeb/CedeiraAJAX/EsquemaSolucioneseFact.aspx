<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="EsquemaSolucioneseFact.aspx.cs" Inherits="CedeiraAJAX.EsquemaSolucioneseFact"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 800px; text-align: left">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 10px">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Esquema de Soluciones "></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left: 3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" AlternateText="Factura Electrónica" ImageUrl="~/Imagenes/eFact.jpg" />
                                    </td>
                                    <td style="height: 20px; padding-left: 3px">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                            Text="( gráfico )"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
        <tr>
            <td align="center" style="padding-top: 30px" valign="top">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/EsquemaSolucioneseFact.jpg" />
                <asp:ImageMap ID="ImageMap1" runat="server">
                </asp:ImageMap>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 31px; padding-top: 20px">
                <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue"
                    OnClick="VolverLinkButton_Click">Volver</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 100%">
            </td>
        </tr>
        <!-- @@@ @@@-->
    </table>
</asp:Content>
