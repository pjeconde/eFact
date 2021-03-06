﻿<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="FacturaElectronicaExcel.aspx.cs" Inherits="CedeiraAJAX.FacturaElectronicaExcel"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        text-align: left;">
        <tr>
            <td style="padding-left: 10px;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; height: 20px; padding-top: 10px">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="width: 750px; padding-left: 3px; padding-top: 10px">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" SkinID="TituloPagina" Text="Factura Electrónica (versión Excel)"></asp:Label>
                                    </td>
                                    <td rowspan="7" valign="top">
                                        <asp:Image ID="Image13" runat="server" ImageUrl="~/Imagenes/eFact-R-XL-vertical.jpg" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 10px">
                                        <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Emita Facturas Electrónicas, a través de la red Interfacturas y desde un front-end Excel, instalando su paquete <b>eFact residente versión Excel</b>."></asp:Label>
                                        <br />
                                        <asp:Label ID="Label16" runat="server" SkinID="TextoMediano" Text="Siga las siguientes instrucciones:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center">
                                        <asp:Panel ID="UsuarioNoLogueadoPanel" runat="server">
                                            <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-top: 20px" valign="top">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola1.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 20px; padding-left: 5px; width: 680px" valign="middle">
                                                        <asp:Label ID="Label8" runat="server" SkinID="TituloGrande" Text="Si ya dispone de una cuenta eFact,"></asp:Label>
                                                        &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkGrandeClaro"><b>identifíquese</b> en la página de Inicio.</asp:HyperLink>
                                                        <br />
                                                        <asp:Label ID="Label2" runat="server" SkinID="TituloGrande" Text="De lo contrario, siga los siguientes pasos."></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola2.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkGrandeClaro">Obtenga su <b>cuenta eFact</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Descarga.aspx?archivo=eFact-R-XL.zip"
                                                            SkinID="LinkGrandeClaro">Descargue su paquete <b>eFact residente versión Excel</b> 2000 o posterior</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px">
                                                        <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/Bola4.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/ActivacionClientePesado.aspx"
                                                            SkinID="LinkGrandeClaro">Active su paquete <b>eFact residente versión Excel</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="UsuarioLogueadoPanel" runat="server">
                                            <table id="Table2" runat="server" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-top: 20px">
                                                        <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/Bola1.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 20px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Descarga.aspx?archivo=eFact-R-XL.zip"
                                                            SkinID="LinkGrandeClaro">Descargue su paquete <b>eFact residente versión Excel</b> 2000 o posterior</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px">
                                                        <asp:Image ID="Image12" runat="server" ImageUrl="~/Imagenes/Bola2.png" />
                                                    </td>
                                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/ActivacionClientePesado.aspx"
                                                            SkinID="LinkGrandeClaro">Active su paquete <b>eFact residente versión Excel</b></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 20px">
                                        <asp:Label ID="Label4" runat="server" SkinID="TextoMediano" Text="Ya está listo para generar Facturas Electrónicas."></asp:Label>
                                        <br />
                                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/ActivacionClientePesadoConsulta.aspx"
                                            SkinID="LinkMedianoClaro">Consulte su clave de activación</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 20px">
                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Volver a Inicio</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" style="padding-top: 20px">
                                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/FacturaElectronicaActividadesAlcanzadas.aspx"
                                            SkinID="LinkMedianoClaro">Actividades alcanzadas por el<br />Régimen de Factura Electrónica</asp:HyperLink>
                                        <br />
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx"
                                            SkinID="LinkMedianoClaro">Preguntas frecuentes</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" style="padding-top: 10px">
                                        <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/Imagenes/InterfacturasInterbankingLogo.gif"
                                            NavigateUrl="http://www.interfacturas.com.ar/" Target="_blank"></asp:HyperLink>
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
