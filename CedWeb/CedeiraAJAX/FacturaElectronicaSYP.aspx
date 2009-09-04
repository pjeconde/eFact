<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="FacturaElectronicaSYP.aspx.cs" Inherits="CedeiraAJAX.FacturaElectronicaSYP"  %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        height: 500px; text-align: left;">
        <tr>
            <td style="padding-left: 10px; padding-top: 10px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" style="" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Guía de servicios y productos"></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left: 3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" AlternateText="Factura Electrónica" ImageUrl="~/Imagenes/eFact.jpg" />
                                    </td>
                                    <td style="height: 20px; padding-left: 3px">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                                            Text="( tabla comparativa )"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; padding-top: 20px">
                        </td>
                        <td align="center" style="padding-top: 20px">
                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
                                width: 750px; border-color: Gray; padding: 3px;">
                                <tr>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Servicio / Producto</td>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Libre</td>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Premium</td>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Profesional</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Objetivo</td>
                                    <td class="TextoFEASYP_DeteFactweb" colspan="2">
                                        Facilitar el ingreso de facturas electrónicas poniendo a su disposición un archivo
                                        XML para el procesamiento en la red de Interfacturas.</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Realizar la emisión de Facturas Electrónicas a través de la red Interfacturas y/o
                                        AFIP.</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Canal
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb" colspan="2" style="vertical-align: top">
                                        <img alt="Interfacturas" src="Imagenes/InterfacturasInterbankingLogo_ch.gif" />
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Interfacturas" src="Imagenes/InterfacturasInterbankingLogo_ch.gif" />
                                        <img alt="AFIP" src="Imagenes/AFIPLogo.jpg" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Enlace con Canal</td>
                                    <td align="center" class="TextoFEASYP_DeteFactweb" colspan="2">
                                        Archivo XML Recomendado por la Camara Argentina de Comercio Electrónico
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        • Archivo XML Recomendado por la Camara Argentina de Comercio Electrónico<br />
                                        • OnLine con la AFIP<br />
                                        • OnLine con Interfacturas</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Recomendado para bajos volúmenes de facturación</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Indistinto</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Recomendado para quienes no cuenten con un Sistema de Facturación</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Genera interfaz XML para Interfacturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Parametrización de datos del Vendedor?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Ingreso manual de facturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Soporte via mail sin costo</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Soporte telefónico sin costo
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Opción de &quot;Clonado&quot; de Facturas ? ( Para agilizar la carga utilizando
                                        comprobantes ya ingresados )</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Backup de Facturas en CD ?<br>
                                        Obligatoriedad de resguardo de duplicados electrónicos (RG 2485)
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Impresión de Facturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Repositorio histórico de Comprobantes ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Comunicación OnLine con la AFIP ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Comunicación OnLine con Interfacturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Emisión de reporte para IVA Ventas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Recomendado para quienes cuenten con un Sistema de Facturación que NO se comunica
                                        con la AFIP o Interfacturas</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Captura de datos desde otros sistemas ? (Por medio de archivos de interfaz o accediendo
                                        directamente a la base de datos de su sistema de facturación)</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Emisión de reporte para IVA Compras ? ( Solo para Interfacturas )</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Módulo de altas, bajas y modificacion de Clientes ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Módulo de altas, bajas y modificacion de Artículos ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Módulo de altas, bajas y modificacion de Proveedores ? ( Solo para Interfacturas
                                        )
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img alt="Ok" src="Imagenes/Ok.gif" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1"">
                                        Precio</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <b><span style="font-size: 11px;">Gratis !!!</span></b> (Esta característica no
                                        se aplica a los Servicios de Interfacturas. Para más informacion sobre dichos costos
                                        consultar en www.interfacturas.com.ar)</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <b><span style="font-size: 11px;">Gratis en la etapa lanzamiento</span></b> (Esta
                                        característica no se aplica a los Servicios de Interfacturas. Para más informacion
                                        sobre estos costos consultar en www.interfacturas.com.ar)</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Consultar.</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Plataforma</td>
                                    <td class="TextoFEASYP_DeteFactweb" colspan="2">
                                        Web</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Cliente Pesado</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Fecha de lanzamiento
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        Fines de Febrero de 2009
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        Fines de Abril del 2009
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Disponible.
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px;">
                        </td>
                        <td style="height: 10px;">
                            <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue"
                                OnClick="VolverLinkButton_Click">Volver</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 20px" valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
