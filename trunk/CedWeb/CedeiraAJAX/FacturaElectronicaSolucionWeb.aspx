<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="FacturaElectronicaSolucionWeb.aspx.cs" Inherits="CedeiraAJAX.FacturaElectronicaSolucionWeb"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        height: 500px; text-align: left;">
        <tr>
            <td style="padding-left: 10px; padding-top: 10px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="width: 750px;">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" SkinID="TituloPagina" Text="Solución Web (site) - Factura Electrónica"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20px">
                                    </td>
                                    <td align="left">
                                        <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2" style="width: 750px; padding-top: 15px">
                                                    En nuestro site podrá cargar una factura y obtener un comprobante electrónico (archivo
                                                    xml) para subirlo a la red de Interfacturas. Trabajará en un entorno asistido y
                                                    amigable.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top: 10px">
                                                    Si se registra como usuario, podrá acceder a las siguentes facilidades:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 23px; padding-top: 10px;" valign="top">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola1.png" />
                                                </td>
                                                <td align="left" style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Configurar sus datos de<br />
                                                    <br />
                                                    &nbsp &nbsp - Vendedor (emisor del comprobante)<br />
                                                    &nbsp &nbsp - Compradores (clientes)<br />
                                                    &nbsp &nbsp - Artículos<br />
                                                    &nbsp &nbsp - Contratos (para la emisión automática de la facturas electrónicas)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px" valign="top">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola2.png" />
                                                </td>
                                                <td align="left" style="padding-top: 5px; padding-left: 5px" valign="middle">
                                                    Tomar como modelo cualquier factura que ya haya ingresado.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px" valign="top">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png" />
                                                </td>
                                                <td align="left" style="padding-top: 5px; padding-left: 5px" valign="middle">
                                                    Emitir facturas en moneda extranjera (la conversión a moneda local se realiza en
                                                    forma automática)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding-top: 5px" valign="top">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola4.png" />
                                                </td>
                                                <td style="padding-top: 5px; padding-left: 5px" valign="middle">
                                                    Desentenderse del "número de lote" (la aplicación lo puede generar automáticamente).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2" style="padding-top: 10px">
                                                    Como es aplicación web no va a necesitar instalar nada en su PC. Y, tanto la aplicación,
                                                    como sus datos, estarán disponibles, las 24 hs, desde cualquier pc, o teléfono celular
                                                    3G, que tenga conexión a Internet.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top: 20px; height: 39px;">
                                                    <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue"
                                                        OnClick="VolverLinkButton_Click">Volver</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2" style="padding-top: 20px">
                                                    Advertencia: algunas de las funcionalidades mencionadas serán de uso libre y gratuito.
                                                    Otras, estarán reservadas al servicio Premium, de costo muy accesible. No todas
                                                    las funcionalidades están implementadas en la actualidad, algunas serán liberadas
                                                    en las próximas semanas.
                                                </td>
                                            </tr>
                                        </table>
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
