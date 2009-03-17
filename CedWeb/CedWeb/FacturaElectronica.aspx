<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronica.aspx.cs" Inherits="CedWeb.FacturaElectronica"%>
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
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica (guía rápida)" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label13" runat="server" Text="Conozca cómo realizar la emisión de Facturas Electrónicas a través de la red <b>Interfacturas</b>." SkinID="TextoMediano"></asp:Label>                                    
                                    </td>
                                </tr>                                
                                <tr>
                                    <td></td>
                                    <td style="padding-top:5px">
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
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkGrandeClaro"><b>identifíquese</b> en la página de Inicio.</asp:HyperLink><br />
                                                        <asp:Label ID="Label2" runat="server" Text="De lo contrario, siga los siguientes pasos." SkinID="TituloGrande"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:10px">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                    </td>
                                                    <td style="padding-top:10px; padding-left:5px" align="left">
                                                        &nbsp;<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkGrandeClaro">Obtenga su <b>cuenta eFact</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:10px">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                    </td>
                                                    <td style="padding-top:10px; padding-left:5px" align="left">
                                                        &nbsp;<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Vendedor.aspx" SkinID="LinkGrandeClaro">Configure los <b>datos del Vendedor</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:10px">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                    </td>
                                                    <td style="padding-top:10px; padding-left:5px" align="left">
                                                        &nbsp;<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/FacturaElectronicaXML.aspx" SkinID="LinkGrandeClaro"><b>Genere una Factura Electrónica</b> y reciba su archivo XML (comprobante electrónico)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:10px">
                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/Bola5.png"/>
                                                    </td>
                                                    <td style="padding-top:10px; padding-left:5px" align="left">
                                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.interfacturas.com.ar/"
                                                            SkinID="LinkGrandeClaro" Target="_blank"><b>Suba el comprobante</b> electrónico a Interfacturas (la red de facturas electrónicas de Interbanking)</asp:HyperLink>&nbsp;
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
                                                        <asp:Label ID="Label3" runat="server" Text="Si ya ha configurado los datos del Vendedor, continúe por el punto 3." SkinID="TituloGrande"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:10px">
                                                        <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                    </td>
                                                    <td style="padding-top:10px; padding-left:5px" align="left">
                                                        &nbsp;<asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Vendedor.aspx"
                                                            SkinID="LinkGrandeClaro">Configure los <b>datos del Vendedor</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:10px">
                                                        <asp:Image ID="Image10" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                    </td>
                                                    <td style="padding-top:10px; padding-left:5px" align="left">
                                                        &nbsp;<asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/FacturaElectronicaXML.aspx"
                                                            SkinID="LinkGrandeClaro"><b>Genere una Factura Electrónica</b> y reciba su archivo XML (comprobante electrónico)</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top:10px">
                                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                    </td>
                                                    <td style="padding-top:10px; padding-left:5px" align="left">
                                                        &nbsp;<asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://www.interfacturas.com.ar/"
                                                            SkinID="LinkGrandeClaro" Target="_blank"><b>Suba el comprobante</b> electrónico a Interfacturas (la red de facturas electrónicas de Interbanking)</asp:HyperLink></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>                            
                            </table>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="padding-top:20px" align="center">
                                        <asp:HyperLink ID="FEASYPHyperLink" runat="server"  NavigateUrl="~/EsquemaSolucioneseFact.aspx" SkinID="LinkMedianoClaro">Esquema de soluciones eFact ( gráfico )</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:HyperLink ID="HyperLink11" runat="server"  NavigateUrl="~/FacturaElectronicaSYP.aspx" SkinID="LinkMedianoClaro">Guía de servicios y productos eFact ( tabla comparativa )</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx" SkinID="LinkMedianoClaro">Preguntas frecuentes</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 750px; padding-top:10px; padding-bottom:30px" align="center">
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