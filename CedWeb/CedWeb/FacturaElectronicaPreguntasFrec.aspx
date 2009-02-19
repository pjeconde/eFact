<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronicaPreguntasFrec.aspx.cs" Inherits="CedWeb.FacturaElectronicaPreguntasFrec"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="height:500px; width:800px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
           <td valign="top" style="height: 10px">
           </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px">
                <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td style="width: 21px; height: 20px;">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"/>
                    </td>
                    <td style="height: 20px;">
                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electr�nica" SkinID="TituloPagina"></asp:Label>
                    </td>
                </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 15px; height: 10px">
                        </td>
                        <td style="">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15px; height: 21px">
                        </td>
                        <td style="height: 21px;">
                            <asp:Label ID="Label2" runat="server" SkinID="TituloColor1Mediano" Text="Preguntas Frecuentes. Normativa Afip">
                            </asp:Label>
                            <br/>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label1" runat="server" SkinID="TituloColor1Mediano" Text="�Qu� es factura electr�nica?">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label3" runat="server" SkinID="TextoMediano" Text="Es un documento comercial en formato electr�nico que reemplaza al documento f�sico tradicional (Papel). ">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label4" runat="server" SkinID="TituloColor1Mediano" Text="�C�mo adquiere validez la factura electr�nica?">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label5" runat="server" SkinID="TextoMediano" Text="El C.A.E. es el c�digo de autorizaci�n electr�nico, que otorga la AFIP a cada documento para darle validez. 
                                        Un documento con C.A.E. indica que fue autorizado por la AFIP.
                                        A trav�s de InterFacturas no tiene que preocuparse por realizar la gesti�n de C.A.E. ya que se realiza de forma autom�tica. ">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label6" runat="server" SkinID="TituloColor1Mediano" Text="�Se podr� utilizar la factura tradicional (en papel) alternativamente a la factura electr�nica?">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label7" runat="server" SkinID="TextoMediano" Text="La resoluci�n R.G. 2485/08, en su art�culo 4 establece los comprobantes excluidos del r�gimen de factura electr�nica.">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label8" runat="server" SkinID="TituloColor1Mediano" Text="�Cu�les son las caracter�sticas de los comprobantes electr�nicos?">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="* Poseen efectos fiscales frente a terceros si el documento electr�nico contiene el C�digo de Autorizaci�n Electr�nico �CAE�, asignado por la AFIP.
                                        * Son identificados con un punto de venta espec�fico, distinto a los utilizados para la emisi�n de comprobantes manuales o a trav�s de controlador fiscal.
                                        * Deben tener correlatividad num�rica.">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label10" runat="server" SkinID="TituloColor1Mediano" Text="�Cu�les son las caracter�sticas de los comprobantes electr�nicos?">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="Los sujetos que hubieran efectuado la comunicaci�n con la fecha a partir de la cual comenzar�n a emitir los comprobantes electr�nicos originales, se encuentran obligados a cumplir, para todas las actividades, con lo dispuesto en: 1. El T�tulo I de la Resoluci�n General N� 1361, sus modificatorias y complementarias, referido a la emisi�n y almacenamiento de duplicados electr�nicos de comprobantes. 2. El T�tulo II de la citada resoluci�n general, respecto del almacenamiento electr�nico de registraciones.">
                                        </asp:Label>
                                        <asp:Label ID="Label14" runat="server" SkinID="TextoMediano" Text="Fuente: Art.9 RG 2485/08">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label12" runat="server" SkinID="TituloColor1Mediano" Text="�En qu� plazo debe ser puesta a disposici�n la factura electr�nica?">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="WIDTH: 441px">
                                        <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Dentro de los 10 d�as corridos contados desde la asignaci�n del 'C.A.E.'<br>Fuente: Art.30 RG 2485/08">
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="WIDTH: 494px">
                                        &nbsp;<asp:Label ID="Label15" runat="server" Font-Bold="true" ForeColor="red" Text="�"></asp:Label>
                                        <asp:HyperLink ID="CedFCImasInfoHyperLink" runat="server" NavigateUrl="~/FacturaElectronica.aspx"
                                            SkinID="LinkMedianoClaro">Factura Electr�nica</asp:HyperLink></td>
                                </tr>
                            </table>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label16" runat="server" SkinID="TituloColor1Mediano" Text="Para m�s informaci�n visite: "></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15px; height: 20px">
                                    </td>
                                    <td style="">
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.afip.gov.ar/efactura"
                                            SkinID="LinkMedianoClaro">http://www.afip.gov.ar/efactura</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15px; height: 20px">
                                    </td>
                                    <td style="">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.interfacturas.com.ar/PF.html#nov"
                                            SkinID="LinkMedianoClaro">http://www.interfacturas.com.ar</asp:HyperLink></td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>    
                </table>
            </td>
        </tr>
    </table>
</asp:Content>