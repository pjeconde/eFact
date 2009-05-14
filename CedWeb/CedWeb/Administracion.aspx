<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Administracion.aspx.cs" Inherits="CedWeb.Administracion"%>
<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
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
                                    <td rowspan="7" style="color:#A52A2A; font-weight:bold; padding-left:20px" align="left" valign="bottom">
                                        Provincia
                                        <br />
                                        <asp:ImageMap ID="ProvinciaImageMap" runat="server" BorderStyle="Solid" BorderColor="brown" BorderWidth="1px"></asp:ImageMap>
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
                                <tr>
                                    <td></td>
                                    <td style="color:#A52A2A; font-weight:bold; padding-top:10px" valign="top">
                                        Ultimas altas de Cuentas
                                        <br />
                                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="380px" Height="159px" BorderColor="brown" BorderStyle="Solid" BorderWidth="1px" BackColor="peachpuff" Font-Bold="false" ForeColor="black">
                                            <cc1:PagingGridView ID="UltimasAltasPagingGridView" runat="server"
                                                                OnSorting="UltimasAltasPagingGridView_Sorting"
                                                                OnPageIndexChanging="UltimasAltasPagingGridView_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="false" HeaderText="Fecha y hora" SortExpression="FechaAlta">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left" Width="300px"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="IdTipoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="IdEstadoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdMedio" HeaderText="Medio" SortExpression="IdMedio">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                </Columns>
                                            </cc1:PagingGridView>
                                        </asp:Panel>
                                    </td>
                                    <td colspan="2" style="color:#A52A2A; font-weight:bold; padding-top:10px; padding-left:20px" valign="top">
                                        Ultimos Comprobantes generados
                                        <br />
                                        <asp:Panel ID="Panel" runat="server" ScrollBars="Auto" Width="334px" Height="159px" BorderColor="brown" BorderStyle="Solid" BorderWidth="1px" BackColor="peachpuff" Font-Bold="false" ForeColor="black">
                                            <cc1:PagingGridView ID="UltimosComprobantesPagingGridView" runat="server"
                                                                OnSorting="UltimosComprobantesPagingGridView_Sorting"
                                                                OnPageIndexChanging="UltimosComprobantesPagingGridView_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaUltimoComprobante" DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="false" HeaderText="Fecha y hora" SortExpression="FechaUltimoComprobante">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CantidadComprobantes" HeaderText="qComprob." SortExpression="CantidadComprobantes">
                                                        <headerstyle horizontalalign="center" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="center"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="IdTipoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="IdEstadoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                                        <headerstyle horizontalalign="left" wrap="False"/>
                                                        <itemstyle wrap="False" horizontalalign="left" Width="300px"/>
                                                    </asp:BoundField>
                                                </Columns>
                                            </cc1:PagingGridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2" style="padding-top:10px" align="left">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.cualesmiip.com/" SkinID="LinkGrandeClaro" Target="_blank">¿ Cuál es mi IP ?</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="3" align="left">
                                        (para acceder, en forma remota, al servidor de base de datos de Towebs se debe ingresar su IP en el Firewall del Haiti Control Module)
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
