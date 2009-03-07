﻿<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronica.aspx.cs" Inherits="CedWeb.FacturaElectronica"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
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
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"/>
                                    </td>
                                    <td style="width:750px;">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica (guia rápida)" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label13" runat="server" Text="Conozca cómo realizar la emisión de Facturas Electrónicas a través de la red <b>Interfacturas</b>." SkinID="TextoMediano"></asp:Label>                                    
                                    </td>
                                </tr>                                
                                <tr>
                                    <td></td>
                                    <td style="padding-top:5px">
                                        <asp:Label ID="Label16" runat="server" Text="Siga las siguientes instrucciones:" SkinID="TextoMediano"></asp:Label>                                    
                                    </td>
                                </tr>                                
                                <tr>
                                    <td></td>
                                    <td align="center">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="padding-top:20px">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                                </td>
                                                <td style="padding-top:20px; padding-left:5px; width:626px" valign="middle" align="left">
                                                    <asp:Label ID="Label8" runat="server" Text="Si ya dispone de una cuenta eFact, y ha configurado los datos del Vendedor, continue por el punto" SkinID="TituloGrande"></asp:Label>
                                                </td>
                                                <td style="padding-top:20px; padding-left:5px">
                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left">
                                                    <asp:Label ID="Label9" runat="server" Text="Obtenga su <b>cuenta eFact</b>, haciendo clic" SkinID="TituloGrande"></asp:Label>
                                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkGrandeClaro">aqui</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left"">
                                                    <asp:Label ID="Label10" runat="server" Text="Configure los <b>datos del Vendedor</b>, haciendo clic" SkinID="TituloGrande"></asp:Label>
                                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Vendedor.aspx" SkinID="LinkGrandeClaro">aqui</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                </td>
                                                <td colspan="2" style="padding-top:10px; padding-left:5px" align="left">
                                                    <asp:Label ID="Label11" runat="server" Text="<b>Genere una Factura Electrónica</b> y reciba su archivo XML (comprobante electrónico), haciendo clic" SkinID="TituloGrande"></asp:Label>
                                                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/FacturaElectronicaXML.aspx" SkinID="LinkGrandeClaro">aqui</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/Bola5.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left">
                                                    <asp:Label ID="Label12" runat="server" Text="Suba el comprobante electrónico a Interfacturas (la red de facturas electrónicas de Interbanking)" SkinID="TituloGrande"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                            
                            </table>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="padding-top:20px; width:50%" align="center">
                                        <asp:HyperLink ID="FEASYPHyperLink" runat="server"  NavigateUrl="~/FacturaElectronicaSYP.aspx" SkinID="LinkMedianoClaro">Detalle de servicios y productos eFact ( tabla comparativa )</asp:HyperLink>
                                        <asp:Label ID="Label1" runat="server" Text="-" SkinID="TituloGrande"></asp:Label>
                                        <asp:HyperLink ID="FEAPreguntasFrecHyperLink" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx" SkinID="LinkMedianoClaro">Preguntas frecuentes</asp:HyperLink>
                                    </td>
                                <tr>
                                <tr>
                                    <td style="width: 750px; padding-top:10px; padding-bottom:30px" align="center">
                                        <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/Imagenes/InterfacturasInterbankingLogo.gif" NavigateUrl="http://www.interfacturas.com.ar/" Target="_blank"></asp:HyperLink>
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