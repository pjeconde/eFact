<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronicaPreguntasFrec.aspx.cs" Inherits="CedWeb.FacturaElectronicaPreguntasFrec"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="height:500px; width:800px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
            <td valign="top" style="padding-left:10px; padding-top:10px">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="width: 21px; height: 20px;">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                        </td>
                        <td style="height: 20px;">
                            <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Preguntas frecuentes" SkinID="TituloPagina"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="width: 21px">
                        </td>
                        <td style="width:780px">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:780px;padding-top:10px">
                                        <asp:Label ID="Label17" runat="server" SkinID="TituloColor1Mediano" Text="¿Qué es factura electrónica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td> 
                                        <asp:Label ID="Label3" runat="server" SkinID="TextoMediano" Text="Es un documento comercial en formato electrónico que reemplaza al documento físico tradicional (Papel). "></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label4" runat="server" SkinID="TituloColor1Mediano" Text="¿Cómo adquiere validez la factura electrónica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="">
                                        <asp:Label ID="Label5" runat="server" SkinID="TextoMediano" Text="El C.A.E. es el código de autorización electrónico, que otorga la AFIP a cada documento para darle validez. 
                                        Un documento con C.A.E. indica que fue autorizado por la AFIP.
                                        A través de InterFacturas no tiene que preocuparse por realizar la gestión de C.A.E. ya que se realiza de forma automática. ">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label6" runat="server" SkinID="TituloColor1Mediano" Text="¿Se podrá utilizar la factura tradicional (en papel) alternativamente a la factura electrónica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" SkinID="TextoMediano" Text="La resolución R.G. 2485/08, en su artículo 4 establece los comprobantes excluidos del régimen de factura electrónica."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label8" runat="server" SkinID="TituloColor1Mediano" Text="¿Cuáles son las características de los comprobantes electrónicos?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="* Poseen efectos fiscales frente a terceros si el documento electrónico contiene el Código de Autorización Electrónico “CAE”, asignado por la AFIP.
                                        * Son identificados con un punto de venta específico, distinto a los utilizados para la emisión de comprobantes manuales o a través de controlador fiscal.
                                        * Deben tener correlatividad numérica.">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label10" runat="server" SkinID="TituloColor1Mediano" Text="¿Cuáles son las características de los comprobantes electrónicos?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="Los sujetos que hubieran efectuado la comunicación con la fecha a partir de la cual comenzarán a emitir los comprobantes electrónicos originales, se encuentran obligados a cumplir, para todas las actividades, con lo dispuesto en: 1. El Título I de la Resolución General Nº 1361, sus modificatorias y complementarias, referido a la emisión y almacenamiento de duplicados electrónicos de comprobantes. 2. El Título II de la citada resolución general, respecto del almacenamiento electrónico de registraciones."></asp:Label>
                                        <asp:Label ID="Label14" runat="server" SkinID="TextoMediano" Text="Fuente: Art.9 RG 2485/08"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label12" runat="server" SkinID="TituloColor1Mediano" Text="¿En qué plazo debe ser puesta a disposición la factura electrónica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Dentro de los 10 días corridos contados desde la asignación del 'C.A.E.'<br>Fuente: Art.30 RG 2485/08"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label1" runat="server" SkinID="TituloColor1Mediano" Text="¿Cómo pongo, la factura electrónica, a disposición de mis clientes?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" SkinID="TextoMediano" Text="Interfacturas pone a su disposición el sitio Web para que sus clientes se registren y puedan visualizar sus facturas electrónicas.  Para mayor información consulte "></asp:Label>
                                        <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl="http://www.interfacturas.com.ar" SkinID="LinkMedianoClaro">aqui</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue" OnClick="VolverLinkButton_Click">Volver</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label16" runat="server" SkinID="TituloColor1Mediano" Text="Para más información visite: "></asp:Label>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="http://www.afip.gov.ar/efactura" SkinID="LinkMedianoClaro">AFIP-Factura Electrónica / Comprobantes en Línea</asp:HyperLink>
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