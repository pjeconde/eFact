<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Soluciones.aspx.cs"
    Inherits="CedWeb.Soluciones" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0" cellspacing="0" border="0"
        class="TextoComun">
        <tr>
            <td style="width: 780px; padding-left: 10px; padding-top: 10px" valign="top">
                <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="left" valign="top">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0" style="">
                                <tr>
                                    <td colspan="2" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 22px">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="CedFCItituloLabel" runat="server" Text="Sistema de Administración de Fondos Comunes de Inversión V3.0"
                                                        SkinID="TituloPagina"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-right: 20px; padding-left: 22px; padding-top: 10px">
                                        <asp:Label ID="CedFCIDescrLabel" runat="server" Text="El sistema de Administración de FCIs es una herramienta de administración de las carteras de inversión de los fondos y de cálculo de los valores de cuotaparte.  Lleva la contabilidad y facilita el cumplimiento de las normas establecidas por el organismo de fiscalización y de los reglamentos de gestión."
                                            SkinID="TextoMediano"></asp:Label>
                                    </td>
                                    <td rowspan="2" style="padding-top: 10px">
                                        <asp:Image ID="CedFCIimage" runat="server" ImageUrl="Imagenes/CedFCI-Tablero_ch.jpg"
                                            Width="220px" ImageAlign="Right" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 10px; vertical-align: bottom">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="CedFCIpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=Cedeira-SistAdminFCIs.pdf"
                                            SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
                                        <asp:Label ID="CedFCIbarraLabel" runat="server" Text=" / "></asp:Label>
                                        <asp:HyperLink ID="CedFCImasInfoHyperLink" runat="server" NavigateUrl="~/CedFCI.aspx"
                                            SkinID="LinkMedianoClaro">Ver más información</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 10px;">
                                <tr>
                                    <td colspan="2" align="left" style="height: 10px">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 22px; height: 20px;">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                </td>
                                                <td style="height: 20px">
                                                    <asp:Label ID="CedSTtituloLabel" runat="server" Text="Sistema de Transferencias ( implementación MEP ) V2.4"
                                                        SkinID="TituloPagina" Width="415px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-right: 20px; padding-left: 22px; padding-top: 10px">
                                        <asp:Label ID="CedSTDescrLabel" runat="server" SkinID="TextoMediano" Text="Es un sistema diseñado para centralizar la administración de transferencias.  En línea con el BCRA, concentra el 100% de las operaciones, tanto enviadas como recibidas, en un único repositorio, para realizar un control eficiente y una óptima gestión operativa.  Facilita las tareas a través de la automatización de los procesos de: ingreso, envío, recepción, distribución y conciliación, entre otros. Contempla todas las operatorias, acorde a las normativas, y se encuentra integrado al Sistema de Medios de Pagos (Mep) del BCRA."></asp:Label>
                                    </td>
                                    <td rowspan="2" style="padding-top: 10px">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="Imagenes/CedST-Tablero_ch.jpg" Width="220px"
                                            ImageAlign="Right" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" style="padding-right: 10px; vertical-align: bottom">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="CedSTpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=Cedeira-SistTransfMEP.pdf"
                                            SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
                                        <asp:Label ID="CedSTbarraLabel" runat="server" Text=" / "></asp:Label>
                                        <asp:HyperLink ID="CedSTmasInfoHyperLink" runat="server" NavigateUrl="~/CedST.aspx"
                                            SkinID="LinkMedianoClaro">Ver más información</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 10px">
                                <tr>
                                    <td colspan="2" align="left" style="height: 10px">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 22px; height: 20px;">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                </td>
                                                <td style="height: 20px">
                                                    <asp:Label ID="Label1" runat="server" Text="Factura Electrónica (solución de conectividad)"
                                                        SkinID="TituloPagina" Width="415px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-right: 20px; padding-left: 22px; padding-top: 10px">
                                        Es un producto que permite "subir", a la red Interfacturas, los comprobantes generados por su sistema de facturación.<br />
                                        Se trata de una herramienta que:<br />
                                        &nbsp &nbsp 1) "captura" sus comprobantes,<br /> 
                                        &nbsp &nbsp 2) los impacta en Interfacturas (quedando la factura electrónica a disposición de sus<br />
                                        &nbsp &nbsp &nbsp &nbsp clientes o lista para ser impresa) y<br /> 
                                        &nbsp &nbsp 3) registra el resultado de ese impacto, incluyendo la confirmación del CAE (código de<br />
                                        &nbsp &nbsp &nbsp &nbsp autorización electrónico).<br />
                                        La forma en la que nuestro sistema capturará sus comprobantes, será personalizada, por nosotros, en función de las posibilidades que nos de su sistema de facturación.<br />
                                        También estableceremos las equivalencias entre los códigos propios, de su sistema de facturación, y los códigos estandar de la operatoria de Factura Electrónica.<br />
                                        Por último, configuraremos, a su medida, la forma en la que nuestro sistema registrará la respuesta del impacto. 
                                    </td>
                                    <td style="padding-top: 10px; border-style:solid; border-width:1px; border-color:#A52A2A">
                                        <asp:Image ID="Image5" runat="server" ImageUrl="Imagenes/EsquemaSolucioneseFact2.jpg" Width="220px"
                                            ImageAlign="Right" />
                                    </td>
                                </tr>

                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 10px">
                                <tr>
                                    <td align="left" style="padding-bottom:20px">
                                        <asp:TreeView ID="Arbol" runat="server" SkinID="TextoMediano" RootNodeStyle-Font-Bold="true">
                                            <RootNodeStyle Font-Bold="True" />
                                        </asp:TreeView>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 20px;" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
