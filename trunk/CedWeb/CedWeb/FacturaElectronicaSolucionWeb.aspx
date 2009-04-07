<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronicaSolucionWeb.aspx.cs" Inherits="CedWeb.FacturaElectronicaSolucionWeb"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="width:800px; height:500px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
            <td valign="top" style="padding-left:10px; padding-top:10px">
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
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Solución Web (site) - Factura Electrónica" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:20px"></td>
                                    <td align="left">
                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td colspan="2" style="width:750px; padding-top:15px">
                                                    En nuestro site podrá cargar una factura y obtener un comprobante electrónico (archivo xml) para subirlo a la red de Interfacturas.  Trabajará en un entorno asistido y amigable.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:10px">
                                                    Si se registra como usuario, podrá acceder a las siguentes facilidades:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:23px; padding-top:10px;" valign="top">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                                </td>
                                                <td style="width:727px; padding-top:10px;" valign="middle" align="left">
                                                    Configurar sus datos de<br />
                                                    &nbsp &nbsp - Vendedor (emisor del comprobante)<br />
                                                    &nbsp &nbsp - Clientes<br />
                                                    &nbsp &nbsp - Artículos<br />
                                                    &nbsp &nbsp - Contratos (para la emisión automática de la facturas electrónicas)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:5px" valign="top">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                </td>
                                                <td style="padding-top:5px" valign="middle">
                                                    Tomar como modelo cualquier factura que ya haya ingresado.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:5px" valign="top">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                </td>
                                                <td style="padding-top:5px" valign="middle" align="left">
                                                    Emitir facturas en moneda extranjera (la conversión a moneda local se realiza en forma automática)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:5px" valign="top" align="left">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                </td>
                                                <td style="padding-top:5px" valign="middle">
                                                    Podrá desentenderse del "número de lote" (la aplicación lo puede generar automáticamente).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:10px" align="left">
                                                    Como es aplicación web no va a necesitar instalar nada en su PC.  Y, tanto la aplicación, como sus datos, estarán disponibles, las 24 hs, desde cualquier pc, o teléfono celular 3G, que tenga conexión a Internet.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:20px">
                                                    <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue" OnClick="VolverLinkButton_Click">Volver a la página anterior</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:20px" align="left">
                                                    Advertencia: algunas de las funcionalidades mencionadas serán de uso libre y gratuito.  Otras, estarán reservadas al servicio Premium, de costo muy accesible.  No todas las funcionalidades están implementadas en la actualidad, algunas serán liberadas en las próximas semanas.                                                   
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
