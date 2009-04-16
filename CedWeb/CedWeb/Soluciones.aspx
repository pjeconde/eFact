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
                                                    <asp:Label ID="CedFCItituloLabel" runat="server" Text="Sistema de Administración de Fondos Comunes de Inversión" SkinID="TituloPagina"></asp:Label>
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
                                                    <asp:Label ID="CedSTtituloLabel" runat="server" Text="Sistema de Transferencias ( implementación MEP )" SkinID="TituloPagina" Width="415px"></asp:Label>
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
                                                    <asp:Image ID="Image10" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                </td>
                                                <td style="height: 20px">
                                                    <asp:Label ID="Label6" runat="server" Text="Sistema de Carga Centralizada de Tasas"
                                                        SkinID="TituloPagina" Width="415px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-right:20px; padding-left:22px; padding-top:10px">
                                        Esta aplicación permite la consulta y modificación, en línea, de todo tipo de Tasas Pasivas.<br />
                                        Presenta un Tablero de Control donde se pueden visualizar todas la tasas en una estructura jerárquica y sobre el que se pueden realizar cambios puntuales o masivos (actualizando las tasas en cadena, acordes a un índice o porcentaje definido, en más o en menos ).  Todos los cambios se impactan en los sistemas corporativos del banco.<br />
                                        Permite un control preciso de la autorización de las operaciones y registra un log detallado para documentar los cambios realizados.<br />
                                        Genera Reportes Operativos y Actas para el Directorio.<br />
                                        También permite exportar la información a planillas de cálculo.
                                    </td>
                                    <td valign="top">
                                        <asp:Image ID="Image11" runat="server" ImageUrl="Imagenes/CedCCT.jpg" Width="220px" ImageAlign="right" />
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 10px">
                                <tr>
                                    <td colspan="2" align="left" style="height: 10px">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 22px; height: 20px;">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                </td>
                                                <td style="height: 20px">
                                                    <asp:Label ID="Label4" runat="server" Text="Sistema de Inversiones y Pagos Judiciales"
                                                        SkinID="TituloPagina" Width="415px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-right:20px; padding-left:22px; padding-top:10px">
                                        Es una aplicación que contribuye a la automatización del servicio que los bancos prestan a los Juzgados Comerciales en los que se tramitan quiebras.  El sistema permite, por un lado, registrar las colocaciones temporarias, de los fondos surgidos de la liquidación de bienes, en <b>INVERSIONES</b> a plazo fijo o en cajas de ahorro.  Cada inversión se mantendrá siempre relacionada al Juzgado-Secretaría-Causa-Incidente en los que se originó.<br />Por otro lado, la aplicación permite, a partir de esas inversiones, realizar <B>PAGOS</B> a beneficiarios (acreedores) de acuerdo a las instrucciones emanadas de los Juzgados.  Existen dos instrumentos mediantes los cuáles los juzgados ordenan los pagos:<br />&nbsp &nbsp 1) Oficios judiciales y<br />&nbsp &nbsp 2) Libranzas judiciales.<br />En ambos casos, los pagos se liquidan en las sucursales del banco (esta aplicación le brinda, a la plataforma de sucursales del banco, un servicio para validar y registrar pagos judiciales).<br />También ofrece una amplia gama de reportes, tanto para los Juzgados (y la Corte Suprema) como para los sectores que administran las inversiones y los pagos.
                                    </td>
                                    <td style="padding-top:10px">
                                        <asp:Image ID="Image7" runat="server" ImageUrl="Imagenes/CedJU.jpg" Width="220px" ImageAlign="Right" />
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 10px">
                                <tr>
                                    <td colspan="2" align="left" style="height: 10px">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 22px; height: 20px;">
                                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                </td>
                                                <td style="height: 20px">
                                                    <asp:Label ID="Label5" runat="server" Text="Sistema de Administración y Presentación de Contenidos"
                                                        SkinID="TituloPagina" Width="415px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-right:20px; padding-left:22px; padding-top:10px">
                                        Es una herramienta, de propósitos generales, que permite automatizar procesos informáticos en los que:<br />
                                        &nbsp &nbsp 1) se recolecten de datos,<br />
                                        &nbsp &nbsp 2) se calculen resultados, a partir de esos datos, y<br />
                                        &nbsp &nbsp 3) se presenten esos resultados (contenidos)<br />
                                        Ofrece, a los administradores, un entorno amigable e intuitivo para la definición de datos básicos, fórmulas y templates de presentación (que serán usados para la generación de reportes o de interfaces de salida).<br />
                                        Luego, asiste a los usuarios en el proceso de captura de datos (manual, desde el front-end propio, o automática, desde interfaces con otras aplicaciones) y en el proceso de cálculo y de presentación de resultados.  Sólo exige una capacitación mínima.<br />
                                        El sistema contempla, y controla, el aporte de datos desde distintos sectores.  Implementa un repositorio histórico (de datos, de resultados y registra un log con la actividad de los usuarios).<br />
                                        Una experiencia exitosa, de implementación, lo constituye el cálculo de las exigencias de <b>Capitales Mínimos</b>, que tienen las entidades financieras, y su consiguiente presentación de reportes y generación de interfaces.
                                    </td>
                                    <td style="padding-top:10px">
                                        <asp:Image ID="Image9" runat="server" ImageUrl="Imagenes/CedAPC.jpg" Width="220px" ImageAlign="Right" />
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
                                        También estableceremos las equivalencias entre los códigos propios, de su sistema de facturación, y los códigos estándar de la operatoria de Factura Electrónica.<br />
                                        Por último, configuraremos, a su medida, la forma en la que nuestro sistema registrará la respuesta del impacto. 
                                    </td>
                                    <td rowspan="2" style="padding-top:10px">
                                        <asp:Image ID="Image5" runat="server" ImageUrl="Imagenes/EsquemaSolucioneseFact2.jpg" Width="220px"
                                            ImageAlign="Right" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 10px; vertical-align: bottom">
                                        <asp:Label ID="Label7" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Descarga.aspx?archivo=eFact-R-XL.exe"
                                            SkinID="LinkMedianoClaro">Descargar eFact-Residente versión Excel (eFact-R-XL.exe)</asp:HyperLink>
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
