<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/EsquemaSolucioneseFact.aspx.cs" Inherits="CedWeb.EsquemaSolucioneseFact" %>
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
                                        <asp:Label ID="TituloLabel" runat="server" Text="Esquema de Soluciones " SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td style="height:20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electrónica"/>
                                    </td>
                                    <td style="height:20px; padding-left:3px">
                                        <asp:Label ID="Label1" runat="server" Text="( gráfico )" Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
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
            <td colspan="3" align="center" valign="top" style="padding-top:20px">
                <table cellpadding="0" cellspacing="0" border="0" style="background-image: url('Imagenes/EsquemaSolucioneseFact.jpg'); width:584px; height:322px">
                    <tr>
                        <td colspan="4" style="height:125px; width:100%">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" Height="83px" Width="170px">
                            </asp:Panel>    
                        </td>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" Height="83px" Width="102px">
                                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/FacturaElectronicaSolucionWeb.aspx" SkinID="LinkGrandeClaro" Height="100%" Width="100%"></asp:HyperLink>
                            </asp:Panel>    
                        </td>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" Height="83px" Width="99px">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FacturaElectronicaSolucionDeConectividad.aspx" SkinID="LinkGrandeClaro" Height="100%" Width="100%"></asp:HyperLink>
                            </asp:Panel>    
                        </td>
                        <td style="height:83px; width:100%">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height:100%; width:100%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="width:21px; height: 20px;">
                        </td>
                        <td style="height:20px;" align="top" style="padding-bottom:20px">
                            <asp:HyperLink ID="HyperLinkVolverPagAnt" runat="server" NavigateUrl="~/FacturaElectronica.aspx" SkinID="LinkMedianoClaro">Volver a la pagina anterior</asp:HyperLink>
                        </td>
                    </tr>
                </table>  
            </td>
        </tr>

        <!-- @@@ @@@-->
    </table>
</asp:Content>
