<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="FacturaElectronicaServicioPremium.aspx.cs" Inherits="CedeiraAJAX.FacturaElectronicaServicioPremium"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        height: 500px; text-align: left;">
        <tr>
            <td style="height: 10px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;" valign="top">
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
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" SkinID="TituloPagina" Text="Factura Electrónica - Sevicio Premium"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2" style="padding-top: 20px; padding-left: 5px" valign="middle">
                                                    Estas son algunas de sus características principales:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 20px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 20px; padding-left: 5px" valign="middle">
                                                    Podrá tomar como <b>FACTURA MODELO</b> cualquier comprobante ingresado con anterioridad.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Dispondrá de una opción para la <b>DESCARGA DIRECTA</b> del archivo XML (comprobante
                                                    electrónico), además del envio por Email.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    <b>SIN LÍMITE</b> de comprobantes.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Podrá generar facturas en <b>MONEDA EXTRANJERA</b>.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Podrá administrar su propio <b>MAESTRO DE CLIENTES</b> (Compradores).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Podrá hacer <b>COPIAS DE SEGURIDAD</b> (tanto de datos del Vendedor como de Compradores).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Tendrá <b>SOPORTE TELEFÓNICO</b> exclusivo.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-top: 20px">
                                                    <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue"
                                                        OnClick="VolverLinkButton_Click">Volver</asp:LinkButton>
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
