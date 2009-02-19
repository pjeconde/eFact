<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronica.aspx.cs" Inherits="CedWeb.FacturaElectronica"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="height:500px; width:800px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
           <td valign="top" style="height: 10px; width: 556px;">
           </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <table style="width:100%; height:490px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"/>
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td style="width: 15px; height: 10px">
                                    </td>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="height: 21px">
                                        <asp:Label ID="Label2" runat="server" SkinID="TituloColor1Mediano" Text="Conozca cómo realizar la emisión de Facturas Electrónicas a través de la red <b>Interfacturas</b> y de la <b>AFIP</b>."></asp:Label><br />
                                    </td>
                                </tr>    
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="height: 21px">
                                        <asp:Label ID="Label1" runat="server" SkinID="TextoMediano" 
                                        Text="Próximamente, en esta página, estará disponible un formulario para cargar los datos de una factura electrónica y generar el archivo XML que solicita InterFacturas. <b>Esta primera versión será de uso libre y gratuito.</b>"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td style="width: 15px">
                                    </td>
                                    <td style="width: 417px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15px">
                                    </td>
                                    <td style="width: 417px">
                                        <asp:Label ID="Label4" runat="server" SkinID="TituloColor1Mediano" Text="Desarrollamos componentes de servicios avalados por Interfacturas.">
                                        </asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 15px">
                                    </td>
                                    <td style="width: 417px">
                                        <img src="Imagenes/Logo-Interfacturas.gif" alt="Interfacturas"/>&nbsp;<br />
                                        <asp:Label ID="Label5" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label><asp:HyperLink
                                            ID="HyperLink1" runat="server" NavigateUrl="~/FacturaElectronicaXML.aspx" SkinID="LinkMedianoClaro">Generación de XML ( Comprobante Electrónico )
                                        </asp:HyperLink>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15px">
                                    </td>
                                    <td style="WIDTH: 417px">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="CedFCImasInfoHyperLink" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx"
                                            SkinID="LinkMedianoClaro">Preguntas frecuentes
                                        </asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width:30px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>