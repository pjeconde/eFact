<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronicaSolucionDeConectividad.aspx.cs" Inherits="CedWeb.FacturaElectronicaSolucionDeConectividad"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="width:800px; text-align:left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:20px; height:20px; padding-top:10px">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o"/>
                                    </td>
                                    <td style="width:750px; padding-top:10px">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica (solución de conectividad)" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td rowspan="4" valign="top">
                                        <asp:Image ID="Image13" runat="server" ImageUrl="~/Imagenes/eFact-R-vertical.jpg"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td colspan="2" style="padding-top:15px">
                                                    Es un producto que permite "subir", a la red Interfacturas, los comprobantes generados por su sistema de facturación.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:10px">
                                                    Se trata de una herramienta que:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px;" valign="top">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                                </td>
                                                <td style="padding-top:10px" valign="middle">
                                                    "captura" sus comprobantes,
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:5px" valign="top">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                </td>
                                                <td style="padding-top:5px" valign="middle">
                                                    los impacta en Interfacturas (quedando la factura electrónica a disposición de sus clientes o lista para ser impresa) y
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:5px" valign="top">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                </td>
                                                <td style="padding-top:5px" valign="middle">
                                                    registra el resultado de ese impacto, incluyendo la confirmación del CAE (código de autorización electrónico).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:10px">
                                                    La forma en la que nuestro sistema capturará sus comprobantes, será personalizada, por nosotros, en función de las posibilidades que nos de su sistema de facturación.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:10px">
                                                    También estableceremos las equivalencias entre los códigos propios, de su sistema de facturación, y los códigos estándar de la operatoria de Factura Electrónica.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:10px">
                                                    Por último, configuraremos, a su medida, la forma en la que nuestro sistema registrará la respuesta del impacto.                                         
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:20px">
                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Volver a Inicio</asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-bottom:20px; padding-top:30px" align="center">
                                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/FacturaElectronicaActividadesAlcanzadas.aspx" SkinID="LinkMedianoClaro">Actividades alcanzadas por el Régimen de Factura Electrónica</asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="HyperLink11" runat="server"  NavigateUrl="~/FacturaElectronicaSYP.aspx" SkinID="LinkMedianoClaro">Guía de servicios y productos eFact ( tabla comparativa )</asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="FEASYPHyperLink" runat="server"  NavigateUrl="~/EsquemaSolucioneseFact.aspx" SkinID="LinkMedianoClaro">Esquema de soluciones eFact ( gráfico )</asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx" SkinID="LinkMedianoClaro">Preguntas frecuentes</asp:HyperLink>
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