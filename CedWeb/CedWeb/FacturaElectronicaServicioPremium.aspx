<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronicaServicioPremium.aspx.cs" Inherits="CedWeb.FacturaElectronicaServicioPremium"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" runat="Server">
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
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica - Sevicio Premium" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td colspan="2" style="padding-top:20px; padding-left:5px" valign="middle">
                                                    Estas son algunas de sus características principales:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:20px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top:20px; padding-left:5px" valign="middle">
                                                    Podrá tomar como <b>FACTURA MODELO</b> cualquier comprobante ingresado con anterioridad.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" valign="middle">
                                                    Dispondrá de una opción para la <b>DESCARGA DIRECTA</b> del archivo XML (comprobante electrónico), además del envio por Email.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" valign="middle">
                                                    <b>SIN LÍMITE</b> de comprobantes.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" valign="middle">
                                                    Podrá generar facturas en <b>MONEDA EXTRANJERA</b>.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" valign="middle">
                                                    Podrá administrar su propio <b>MAESTRO DE CLIENTES</b> (Compradores).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" valign="middle">
                                                    Podrá hacer <b>COPIAS DE SEGURIDAD</b> (tanto de datos del Vendedor como de Compradores).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" valign="middle">
                                                    Tendrá <b>SOPORTE TELEFÓNICO</b> exclusivo.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top:20px">
                                                    <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue" OnClick="VolverLinkButton_Click">Volver a la página anterior</asp:LinkButton>
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