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
                                        <asp:Label ID="Label17" runat="server" SkinID="TituloColor1Mediano" Text="�Qu� es factura electr�nica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td> 
                                        <asp:Label ID="Label3" runat="server" SkinID="TextoMediano" Text="Es un documento comercial en formato electr�nico que reemplaza al documento f�sico tradicional (Papel). "></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label4" runat="server" SkinID="TituloColor1Mediano" Text="�C�mo adquiere validez la factura electr�nica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="">
                                        <asp:Label ID="Label5" runat="server" SkinID="TextoMediano" Text="El C.A.E. es el c�digo de autorizaci�n electr�nico, que otorga la AFIP a cada documento para darle validez. 
                                        Un documento con C.A.E. indica que fue autorizado por la AFIP.
                                        A trav�s de InterFacturas no tiene que preocuparse por realizar la gesti�n de C.A.E. ya que se realiza de forma autom�tica. ">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label6" runat="server" SkinID="TituloColor1Mediano" Text="�Se podr� utilizar la factura tradicional (en papel) alternativamente a la factura electr�nica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" SkinID="TextoMediano" Text="La resoluci�n R.G. 2485/08, en su art�culo 4 establece los comprobantes excluidos del r�gimen de factura electr�nica."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label8" runat="server" SkinID="TituloColor1Mediano" Text="�Cu�les son las caracter�sticas de los comprobantes electr�nicos?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="* Poseen efectos fiscales frente a terceros si el documento electr�nico contiene el C�digo de Autorizaci�n Electr�nico �CAE�, asignado por la AFIP.
                                        * Son identificados con un punto de venta espec�fico, distinto a los utilizados para la emisi�n de comprobantes manuales o a trav�s de controlador fiscal.
                                        * Deben tener correlatividad num�rica.">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label10" runat="server" SkinID="TituloColor1Mediano" Text="�Cu�les son las caracter�sticas de los comprobantes electr�nicos?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="Los sujetos que hubieran efectuado la comunicaci�n con la fecha a partir de la cual comenzar�n a emitir los comprobantes electr�nicos originales, se encuentran obligados a cumplir, para todas las actividades, con lo dispuesto en: 1. El T�tulo I de la Resoluci�n General N� 1361, sus modificatorias y complementarias, referido a la emisi�n y almacenamiento de duplicados electr�nicos de comprobantes. 2. El T�tulo II de la citada resoluci�n general, respecto del almacenamiento electr�nico de registraciones."></asp:Label>
                                        <asp:Label ID="Label14" runat="server" SkinID="TextoMediano" Text="Fuente: Art.9 RG 2485/08"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label12" runat="server" SkinID="TituloColor1Mediano" Text="�En qu� plazo debe ser puesta a disposici�n la factura electr�nica?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Dentro de los 10 d�as corridos contados desde la asignaci�n del 'C.A.E.'<br>Fuente: Art.30 RG 2485/08"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label1" runat="server" SkinID="TituloColor1Mediano" Text="�C�mo pongo, la factura electr�nica, a disposici�n de mis clientes?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" SkinID="TextoMediano" Text="Interfacturas pone a su disposici�n el sitio Web para que sus clientes se registren y puedan visualizar sus facturas electr�nicas.  Para mayor informaci�n consulte "></asp:Label>
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
                                        <asp:Label ID="Label16" runat="server" SkinID="TituloColor1Mediano" Text="Para m�s informaci�n visite: "></asp:Label>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="http://www.afip.gov.ar/efactura" SkinID="LinkMedianoClaro">AFIP-Factura Electr�nica / Comprobantes en L�nea</asp:HyperLink>
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