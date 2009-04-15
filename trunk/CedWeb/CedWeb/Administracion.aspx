<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Administracion.aspx.cs" Inherits="CedWeb.Administracion"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="width:800px; height:500px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
           <td valign="top" style="height: 10px;">
           </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 20px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o"/>
                                    </td>
                                    <td style="width:750px;">
                                        <asp:Label ID="TituloLabel" runat="server" Text="Administración" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label13" runat="server" Text="Tiene disponible las siguientes tareas de administración:" SkinID="TextoMediano"></asp:Label>                                    
                                    </td>
                                </tr>                                
                                <tr>
                                    <td></td>
                                    <td align="center">
                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="padding-top:20px" valign="top">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                                </td>
                                                <td style="padding-top:20px; padding-left:5px; width:680px" valign="middle" align="left">
                                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/AdministracionCuentaExplorador.aspx" SkinID="LinkGrandeClaro">Explorador de Cuentas</asp:HyperLink>
                                                    <asp:Label ID="CuentasLabel" runat="server" Text="" SkinID="TextoGrande"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left">
                                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/AdministracionVendedorExplorador.aspx" SkinID="LinkGrandeClaro">Explorador de Vendedores</asp:HyperLink>
                                                    <asp:Label ID="VendedoresLabel" runat="server" Text="" SkinID="TextoGrande"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left">
                                                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/AdministracionCompradorExplorador.aspx" SkinID="LinkGrandeClaro">Explorador de Compradores</asp:HyperLink>
                                                    <asp:Label ID="CompradoresLabel" runat="server" Text="" SkinID="TextoGrande"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" valign="middle" style="padding-top:20px">
                                        <asp:Label ID="Label1" runat="server" Text="Medio" SkinID="TituloColor1Grande"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" valign="middle">
                                        <asp:ImageMap ID="MedioImageMap" runat="server" BorderStyle="Solid" BorderColor="brown" BorderWidth="1px"></asp:ImageMap>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
