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
                                    <td style="width:20px; height:20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o"/>
                                    </td>
                                    <td>
                                        <asp:Label ID="TituloLabel" runat="server" Text="Administración" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td rowspan="7" style="color:#A52A2A; font-weight:bold; padding-left:20px" align="left" valign="bottom">
                                        Medio
                                        <br />
                                        <asp:ImageMap ID="MedioImageMap" runat="server" BorderStyle="Solid" BorderColor="brown" BorderWidth="1px"></asp:ImageMap>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:20px" valign="middle" align="left">
                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/AdministracionCuentaExplorador.aspx" SkinID="LinkGrandeClaro">Explorador de Cuentas</asp:HyperLink>
                                        <asp:Label ID="CuentasLabel" runat="server" Text="" SkinID="TextoGrande"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px" align="left">
                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/AdministracionVendedorExplorador.aspx" SkinID="LinkGrandeClaro">Explorador de Vendedores</asp:HyperLink>
                                        <asp:Label ID="VendedoresLabel" runat="server" Text="" SkinID="TextoGrande"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px" align="left">
                                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/AdministracionCompradorExplorador.aspx" SkinID="LinkGrandeClaro">Explorador de Compradores</asp:HyperLink>
                                        <asp:Label ID="CompradoresLabel" runat="server" Text="" SkinID="TextoGrande"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px" align="left">
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://ar62.toservers.com/awstats/awstats.pl?&inst=482&output=main&config=cedeira" SkinID="LinkGrandeClaro" Target="_blank">Estadísticas del sitio</asp:HyperLink>
                                        <asp:Label ID="Label2" runat="server" Text="" SkinID="TextoGrande"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px; padding-right:3px" align="right" valign="top">
                                        <asp:CheckBox ID="RecibeAvisoAltaCuentaCheckBox" runat="server" OnCheckedChanged="RecibeAvisoAltaCuentaCheckBox_CheckedChanged" AutoPostBack="true" />
                                    </td>
                                    <td style="padding-top:10px" align="left" valign="middle">
                                        Recibe aviso de alta de cuenta (SMS)
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        (en la Configuración de su Cuenta eFact podrá ingresar
                                        <br />
                                         el 'Email para SMSs')
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
