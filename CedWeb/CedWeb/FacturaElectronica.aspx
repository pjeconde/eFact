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
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"/>
                                    </td>
                                    <td style="width:750px;">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 20px; height: 10px">
                                    </td>
                                    <td style="width:750px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label2" runat="server" SkinID="TituloColor1Mediano" Text="Conozca cómo realizar la emisión de Facturas Electrónicas a través de la red <b>Interfacturas</b> y de la <b>AFIP</b>."></asp:Label><br />
                                    </td>
                                </tr>    
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label1" runat="server" SkinID="TextoMediano" Text="En esta página, está disponible un formulario para cargar los datos de una factura electrónica y generar el archivo XML requerido por InterFacturas. <b>Esta primera versión será de uso libre y gratuito.</b>"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="">
                                    </td>
                                    <td style="height: 21px">
                                        <asp:Label ID="Label4" runat="server" SkinID="TituloColor1Mediano" Text="Desarrollamos componentes de servicios, avalados por Interfacturas.">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 750px; padding-top:20px" align="center">
                                        <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/Imagenes/InterfacturasInterbankingLogo.jpg" NavigateUrl="http://www.interfacturas.com.ar/" Target="_blank"></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:20px">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FacturaElectronicaXML.aspx" SkinID="LinkMedianoClaro">Ingreso de Factura Electrónica y generación de XML ( Comprobante Electrónico )</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label6" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Vendedor.aspx" SkinID="LinkMedianoClaro">Configuracion de Información del Vendedor</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="FEASYPHyperLink" runat="server"  NavigateUrl="~/FacturaElectronicaSYP.aspx" SkinID="LinkMedianoClaro">ver Detalle de servicios y productos eFact ( tabla comparativa )</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="FEAPreguntasFrecHyperLink" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx"
                                            SkinID="LinkMedianoClaro">Preguntas frecuentes
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width:20px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>
    </table>
</asp:Content>