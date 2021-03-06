﻿<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="FacturaElectronicaActividadesAlcanzadas.aspx.cs" Inherits="CedeiraAJAX.FacturaElectronicaActividadesAlcanzadas"  %>

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
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" SkinID="TituloPagina" Text="Actividades alcanzadas por el Régimen de Factura Electrónica"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Servicios profesionales (abogados, contadores, escribanos, arquitectos, licenciados
                                                    en sistemas, en administración, entre otros) con montos anuales de operaciones iguales
                                                    o mayores a 600.000,- $).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Servicios de Informática y desarrolladores de software.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Planes de salud con abono de cuota mensual
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Transmisión de televisión por cable y/o satelital
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Acceso a Internet con abono mensual
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Servicios de telefonía móvil
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Transporte de caudales y/o otros objetos de valor
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Seguridad (incluye instalación de alarmas, monitoreo vigilancia etc.)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Limpieza
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Prestación de servicios de publicidad y conexos
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Servicios de construcción, infraestructura del transporte y telepeaje, ámbito de
                                                    la Pcia. de Bs. As. y Ciudad Autónoma de Bs. As.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px;" valign="top">
                                                    -
                                                </td>
                                                <td style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Fabricantes de bienes de capital que sean beneficiarios del Bono Fiscal.
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
