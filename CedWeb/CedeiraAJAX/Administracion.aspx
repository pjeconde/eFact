<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="CedeiraAJAX.Administracion"  %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        height: 500px; text-align: left;">
        <tr>
            <td style="height: 10px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td>
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Administración"></asp:Label>
                                    </td>
                                    <td align="left" rowspan="9" style="color: #A52A2A; font-weight: bold; padding-left: 20px"
                                        valign="bottom">
                                        Medio
                                        <br />
                                        <asp:ImageMap ID="MedioImageMap" runat="server" BorderColor="brown" BorderStyle="Solid"
                                            BorderWidth="1px">
                                        </asp:ImageMap>
                                    </td>
                                    <td align="left" rowspan="9" style="color: #A52A2A; font-weight: bold; padding-left: 20px"
                                        valign="bottom">
                                        Provincia
                                        <br />
                                        <asp:ImageMap ID="ProvinciaImageMap" runat="server" BorderColor="brown" BorderStyle="Solid"
                                            BorderWidth="1px">
                                        </asp:ImageMap>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px" valign="middle">
                                        Explorador de:
                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/AdministracionCuentaExplorador.aspx"
                                            SkinID="LinkMedianoClaro">Cuentas</asp:HyperLink>
                                        <asp:Label ID="CuentasLabel" runat="server" SkinID="TextoMediano" Text=""></asp:Label>
                                        ,&nbsp;
                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/AdministracionVendedorExplorador.aspx"
                                            SkinID="LinkMedianoClaro">Vendedores</asp:HyperLink>
                                        <asp:Label ID="VendedoresLabel" runat="server" SkinID="TextoMediano" Text=""></asp:Label>
                                        ,&nbsp;
                                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/AdministracionCompradorExplorador.aspx"
                                            SkinID="LinkMedianoClaro">Compradores</asp:HyperLink>
                                        <asp:Label ID="CompradoresLabel" runat="server" SkinID="TextoMediano" Text=""></asp:Label>
                                        ,&nbsp;
                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/PublicacionExplorador.aspx"
                                            SkinID="LinkMedianoClaro">Publicaciones</asp:HyperLink>
                                        <asp:Label ID="PublicacionesLabel" runat="server" SkinID="TextoMediano" Text=""></asp:Label>
                                        ,
                                        <asp:HyperLink ID="CertificadosHyperLink" runat="server" NavigateUrl="~/AdministracionCertificadosExplorador.aspx"
                                            SkinID="LinkMedianoClaro">Certificados</asp:HyperLink>
                                        <asp:Label ID="CertificadosLabel" runat="server" SkinID="TextoMediano" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 5px; padding-right: 3px" valign="top">
                                        <asp:CheckBox ID="CreacionCuentaHabilitadaCheckBox" runat="server" AutoPostBack="true"
                                            OnCheckedChanged="CreacionCuentaHabilitadaCheckBox_CheckedChanged" />
                                    </td>
                                    <td align="left" style="padding-top: 5px" valign="middle">
                                        Creación de Cuentas disponible
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 3px" valign="top">
                                        <asp:CheckBox ID="PremiumSinCostoEnAltaCuentaCheckBox" runat="server" AutoPostBack="true"
                                            OnCheckedChanged="PremiumSinCostoEnAltaCuentaCheckBox_CheckedChanged" />
                                    </td>
                                    <td align="left" valign="middle">
                                        Servicio Premium sin costo en alta de Cuenta ( por
                                        <asp:Label ID="CantidadDiasPremiumSinCostoEnAltaCuenta" runat="server" SkinID="TextoMediano"></asp:Label>
                                        días )
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 3px" valign="top">
                                        <asp:CheckBox ID="ModoDepuracionCheckBox" runat="server" AutoPostBack="true" Enabled="false"
                                            OnCheckedChanged="ModoDepuracionCheckBox_CheckedChanged" />
                                    </td>
                                    <td align="left" valign="middle">
                                        Modo depuración (guarda los archivos xml enviados por mail)
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 3px" valign="top">
                                        <asp:CheckBox ID="RecibeAvisoAltaCuentaCheckBox" runat="server" AutoPostBack="true"
                                            OnCheckedChanged="RecibeAvisoAltaCuentaCheckBox_CheckedChanged" />
                                    </td>
                                    <td align="left" valign="middle">
                                        Recibe aviso de alta de cuenta (SMS)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        (en la Configuración de su Cuenta eFact podrá ingresar el 'Email
                                        <br />
                                        para SMSs')
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 5px">
                                        Probar envío mail de
                                        <asp:LinkButton ID="PruebaEmailBienvenidaPremiumLinkButton" runat="server" OnClick="PruebaEmailBienvenidaPremiumLinkButton_Click">bienvenida</asp:LinkButton>
                                        , o
                                        <asp:LinkButton ID="PruebaEmailSuspensionPremiumLinkButton" runat="server" OnClick="PruebaEmailSuspensionPremiumLinkButton_Click">suspensión</asp:LinkButton>
										al Servicio Premium, o
										<asp:LinkButton ID="PruebaSMSLinkButton" runat="server" OnClick="PruebaSMSLinkButton_Click">SMS</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 5px">
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://ar62.toservers.com/awstats/awstats.pl?&inst=482&output=main&config=cedeira"
                                            SkinID="LinkMedianoClaro" Target="_blank">Estadísticas del sitio</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="color: #A52A2A; font-weight: bold; padding-top: 10px" valign="top">
                                        Ultimas altas de Cuentas
                                        <br />
                                        <asp:Panel ID="Panel1" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                            BorderWidth="1px" Font-Bold="false" ForeColor="black" Height="159px" ScrollBars="Auto"
                                            Width="380px">
                                            <cc1:PagingGridView ID="UltimasAltasPagingGridView" runat="server" OnPageIndexChanging="UltimasAltasPagingGridView_PageIndexChanging"
                                                OnSorting="UltimasAltasPagingGridView_Sorting">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Fecha y hora"
                                                        HtmlEncode="false" SortExpression="FechaAlta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="IdCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" width="300px" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="Cuenta.IdTipoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="Cuenta.IdEstadoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdMedio" HeaderText="Medio" SortExpression="Cuenta.IdMedio">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </cc1:PagingGridView>
                                        </asp:Panel>
                                    </td>
                                    <td colspan="2" style="color: #A52A2A; font-weight: bold; padding-top: 10px; padding-left: 20px"
                                        valign="top">
                                        Ultimos Comprobantes generados
                                        <br />
                                        <asp:Panel ID="Panel" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                            BorderWidth="1px" Font-Bold="false" ForeColor="black" Height="159px" ScrollBars="Auto"
                                            Width="334px">
                                            <cc1:PagingGridView ID="UltimosComprobantesPagingGridView" runat="server" OnPageIndexChanging="UltimosComprobantesPagingGridView_PageIndexChanging"
                                                OnSorting="UltimosComprobantesPagingGridView_Sorting">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaUltimoComprobante" DataFormatString="{0:dd/MM/yyyy HH:mm}"
                                                        HeaderText="Fecha y hora" HtmlEncode="false" SortExpression="FechaUltimoComprobante">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CantidadComprobantes" HeaderText="qComprob." SortExpression="CantidadComprobantes">
                                                        <headerstyle horizontalalign="center" wrap="False" />
                                                        <itemstyle horizontalalign="center" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="Cuenta.IdTipoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="Cuenta.IdEstadoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="IdCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </cc1:PagingGridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 10px">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.cualesmiip.com/"
                                            SkinID="LinkMedianoClaro" Target="_blank">¿ Cuál es mi IP ?</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" colspan="3">
                                        (para acceder, en forma remota, al servidor de base de datos de Towebs se debe ingresar
                                        su IP en el Firewall del Haiti Control Module)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" colspan="3" style="padding-top: 10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
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
