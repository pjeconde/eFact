<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="FacturaElectronica.aspx.cs" Inherits="CedeiraAJAX.FacturaElectronica"  %>


<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        text-align: left;">
        <tr>
            <td style="padding-left: 10px;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; height: 20px; padding-top: 10px">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="width: 750px; padding-left: 3px; padding-top: 10px">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" SkinID="TituloPagina" Text="Factura Electrónica (servicio web)"></asp:Label>
                                    </td>
                                    <td rowspan="10" valign="top">
                                        <asp:ImageMap ID="eFactWverticalImageMap" runat="server" HotSpotMode="Navigate" ImageUrl="~/Imagenes/eFact-W-vertical.jpg">
                                            <asp:RectangleHotSpot Bottom="220" Left="81" NavigateUrl="http://www.interfacturas.com.ar/"
                                                Right="219" Target="_blank" Top="185" />
                                        </asp:ImageMap>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 10px">
                                        <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Emita Facturas Electrónicas, a través de la red Interfacturas, desde nuestro <b>Servicio Web</b>."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" SkinID="TextoMediano" Text="Siga las siguientes instrucciones:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center">
                                        <asp:Panel ID="UsuarioNoLogueadoPanel" runat="server">
                                            <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-top: 10px" valign="top">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola1.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 10px; padding-left: 5px; width: 680px" valign="middle">
                                                        <asp:Label ID="Label8" runat="server" SkinID="TituloGrande" Text="Si ya dispone de una cuenta eFact, por favor, "></asp:Label>
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkGrandeClaro"><b>identifíquese</b> en la página de Inicio.</asp:HyperLink>
                                                        &nbsp;
                                                        <asp:Label ID="Label2" runat="server" SkinID="TituloGrande" Text="De lo contrario, siga los siguientes pasos."></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola2.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkGrandeClaro">Obtenga su <b>cuenta eFact</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Vendedor/Default.aspx" SkinID="LinkGrandeClaro">Configure los <b>datos del Vendedor</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/Bola4.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/CompradorExplorador.aspx"
                                                            SkinID="LinkGrandeClaro">Configure los <b>datos de Compradores (clientes)</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola5.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Facturacion/Electronica/Lote.aspx"
                                                            SkinID="LinkGrandeClaro"><b>Genere una Factura Electrónica</b> y reciba su archivo XML (comprobante electrónico)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/Bola6.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.interfacturas.com.ar/"
                                                            SkinID="LinkGrandeClaro" Target="_blank"><b>Suba el comprobante</b> electrónico a Interfacturas (la red de facturas electrónicas de Interbanking)</asp:HyperLink>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="UsuarioLogueadoPanel" runat="server">
                                            <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-top: 10px" valign="top">
                                                        <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/Bola1.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 10px; padding-left: 5px; width: 680px" valign="middle">
                                                        <asp:Label ID="Label3" runat="server" SkinID="TituloGrande" Text="Si no necesita configurar los datos (Vendedor y Compradores), continúe por el punto 4."></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/Bola2.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Vendedor/Default.aspx"
															SkinID="LinkGrandeClaro">Configure los <b>datos del Vendedor</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image12" runat="server" ImageUrl="~/Imagenes/Bola3.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/CompradorExplorador.aspx"
                                                            SkinID="LinkGrandeClaro">Configure los <b>datos de Compradores (clientes)</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image10" runat="server" ImageUrl="~/Imagenes/Bola4.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Facturacion/Electronica/Lote.aspx"
                                                            SkinID="LinkGrandeClaro"><b>Genere una Factura Electrónica</b> y reciba su archivo XML (comprobante electrónico)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px" valign="top">
                                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/Imagenes/Bola5.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://www.interfacturas.com.ar/"
                                                            SkinID="LinkGrandeClaro" Target="_blank"><b>Suba el comprobante</b> electrónico a Interfacturas (la red de facturas electrónicas de Interbanking)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2" style="padding-top: 10px">
                                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Volver a Inicio</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="width: 750px; padding-top: 20px; padding-bottom: 10px; padding-left: 7px">
                                        <asp:ImageMap ID="TarifasServicioPremiumImageMap" runat="server" HotSpotMode="Navigate"
                                            ImageUrl="~/Imagenes/TarifasServicioPremium.jpg">
                                            <asp:RectangleHotSpot Bottom="78" Left="0" NavigateUrl="~/FacturaElectronicaServicioPremium.aspx"
                                                Right="95" Top="37" />
                                        </asp:ImageMap>
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
