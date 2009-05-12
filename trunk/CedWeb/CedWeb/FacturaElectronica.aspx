<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronica.aspx.cs" Inherits="CedWeb.FacturaElectronica"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="width:800px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:20px; height:20px; padding-top:10px">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o"/>
                                    </td>
                                    <td style="width:750px; padding-left:3px; padding-top:10px">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica (servicio web)" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td rowspan="10" valign="top">
                                        <asp:Image ID="Image13" runat="server" ImageUrl="~/Imagenes/eFact-W-vertical.jpg"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label13" runat="server" Text="Emita Facturas Electrónicas, a través de la red Interfacturas, desde nuestro <b>Servicio Web</b>." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" Text="Siga las siguientes instrucciones:" SkinID="TextoMediano"></asp:Label>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="center">
                                        <asp:Panel ID="UsuarioNoLogueadoPanel" runat="server">
                                            <table runat="server" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="padding-top:20px" valign="top">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                                    </td>
                                                    <td style="padding-top:20px; padding-left:5px; width:680px" valign="middle" align="left">
                                                        <asp:Label ID="Label8" runat="server" Text="Si ya dispone de una cuenta eFact, por favor, " SkinID="TituloGrande"></asp:Label>
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkGrandeClaro"><b>identifíquese</b> en la página de Inicio.</asp:HyperLink>
                                                        &nbsp;
                                                        <asp:Label ID="Label2" runat="server" Text="De lo contrario, siga los siguientes pasos." SkinID="TituloGrande"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkGrandeClaro">Obtenga su <b>cuenta eFact</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Vendedor.aspx" SkinID="LinkGrandeClaro">Configure los <b>datos del Vendedor</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/CompradorExplorador.aspx" SkinID="LinkGrandeClaro">Configure los <b>datos de Compradores (clientes)</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola5.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/FacturaElectronicaXML.aspx" SkinID="LinkGrandeClaro"><b>Genere una Factura Electrónica</b> y reciba su archivo XML (comprobante electrónico)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/Bola6.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.interfacturas.com.ar/" SkinID="LinkGrandeClaro" Target="_blank"><b>Suba el comprobante</b> electrónico a Interfacturas (la red de facturas electrónicas de Interbanking)</asp:HyperLink>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="UsuarioLogueadoPanel" runat="server">
                                            <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="padding-top:20px" valign="top">
                                                        <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                                    </td>
                                                    <td style="padding-top:20px; padding-left:5px; width:680px" valign="middle" align="left">
                                                        <asp:Label ID="Label3" runat="server" Text="Si no necesita configurar los datos (Vendedor y Compradores), continúe por el punto 4." SkinID="TituloGrande"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Vendedor.aspx" SkinID="LinkGrandeClaro">Configure los <b>datos del Vendedor</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image12" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/CompradorExplorador.aspx" SkinID="LinkGrandeClaro">Configure los <b>datos de Compradores (clientes)</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image10" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/FacturaElectronicaXML.aspx" SkinID="LinkGrandeClaro"><b>Genere una Factura Electrónica</b> y reciba su archivo XML (comprobante electrónico)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:5px">
                                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/Imagenes/Bola5.png"/>
                                                    </td>
                                                    <td style="padding-top:5px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://www.interfacturas.com.ar/" SkinID="LinkGrandeClaro" Target="_blank"><b>Suba el comprobante</b> electrónico a Interfacturas (la red de facturas electrónicas de Interbanking)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>                            
                                <tr>
                                    <td></td>
                                    <td colspan="2" style="padding-top:20px">
                                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Volver a Inicio</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px" align="center">
                                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/FacturaElectronicaActividadesAlcanzadas.aspx" SkinID="LinkMedianoClaro">Actividades alcanzadas por el<br />Régimen de Factura Electrónica</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="center">
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx" SkinID="LinkMedianoClaro">Preguntas frecuentes</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="width: 750px; padding-top:10px; padding-bottom:10px" align="center">
                                        <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/Imagenes/InterfacturasInterbankingLogo.gif" NavigateUrl="http://www.interfacturas.com.ar/" Target="_blank"></asp:HyperLink>
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