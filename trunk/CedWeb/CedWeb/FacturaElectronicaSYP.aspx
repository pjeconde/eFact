<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="FacturaElectronicaSYP.aspx.cs" Inherits="FacturaElectronicaSYP"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="width: 800px; height: 500px; text-align: left;" cellpadding="0" cellspacing="0"
        border="0" class="TextoComun">
        <tr>
            <td valign="top" style="padding-left:10px; padding-top:10px">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td colspan="2" valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" Text="Gu�a de servicios y productos" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electr�nica"/>
                                    </td>
                                    <td style="height:20px; padding-left:3px">
                                        <asp:Label ID="Label1" runat="server" Text="( tabla comparativa )" Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>       
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px; padding-top:20px">
                        </td>
                        <td align="center" style="padding-top:20px">
                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; width: 750px; border-color: Gray; padding: 3px;">
                                <tr>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Servicio / Producto</td>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Libre</td>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Premium</td>
                                    <td class="TextoFEASYP_EncaRow1" style="color: maroon;">
                                        Profesional</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Objetivo</td>
                                    <td colspan="2" class="TextoFEASYP_DeteFactweb">
                                        Facilitar el ingreso de facturas electr�nicas poniendo a su disposici�n un archivo
                                        XML para el procesamiento en la red de Interfacturas.</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Realizar la emisi�n de Facturas Electr�nicas a trav�s de la red Interfacturas y/o AFIP.</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Canal
                                    </td>
                                    <td colspan="2" class="TextoFEASYP_DeteFactweb" style="vertical-align: top">
                                        <img src="Imagenes/InterfacturasInterbankingLogo_ch.gif" alt="Interfacturas" />
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/InterfacturasInterbankingLogo_ch.gif" alt="Interfacturas" />
                                        <img src="Imagenes/AFIPLogo.jpg" alt="AFIP" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Enlace con Canal</td>
                                    <td colspan="2" align="center" class="TextoFEASYP_DeteFactweb">
                                        Archivo XML Recomendado por la Camara Argentina de Comercio Electr�nico
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        � Archivo XML Recomendado por la Camara Argentina de Comercio Electr�nico<br/>
                                        � OnLine con la AFIP<br/>
                                        �  OnLine con Interfacturas</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Recomendado para bajos vol�menes de facturaci�n</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Indistinto</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Recomendado para quienes no cuenten con un Sistema de Facturaci�n</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                 <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Genera interfaz XML para Interfacturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Parametrizaci�n de datos del Vendedor?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Ingreso manual de facturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Soporte via mail sin costo</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Soporte telef�nico sin costo
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Opci�n de &quot;Clonado&quot; de Facturas ? ( Para agilizar la carga
                                            utilizando comprobantes ya ingresados )</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Backup de Facturas en CD ?<br>
                                        Obligatoriedad de resguardo de duplicados electr�nicos (RG 2485)
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Impresi�n de Facturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Repositorio hist�rico de Comprobantes ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Comunicaci�n OnLine con la AFIP ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Comunicaci�n OnLine con Interfacturas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>

                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Emisi�n de reporte para IVA Ventas ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Recomendado para quienes cuenten con un Sistema de Facturaci�n que NO se comunica
                                        con la AFIP o Interfacturas</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Captura de datos desde otros sistemas ? (Por medio de archivos de interfaz o accediendo
                                        directamente a la base de datos de su sistema de facturaci�n)</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Emisi�n de reporte para IVA Compras ? ( Solo para Interfacturas
                                            )</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        M�dulo de altas, bajas y modificacion de Clientes ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                   <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        M�dulo de altas, bajas y modificacion de Art�culos ?</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        M�dulo de altas, bajas y modificacion de Proveedores ? ( Solo para Interfacturas )
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        &nbsp;</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        <img src="Imagenes/Ok.gif" alt="Ok" /></td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1"">
                                        Precio</td>
                                    <td  class="TextoFEASYP_DeteFactweb">
                                        <b><span style="font-size: 11px;">Gratis !!!</span></b> (Esta caracter�stica no se aplica a los Servicios de Interfacturas. Para
                                        m�s informacion sobre dichos costos consultar en www.interfacturas.com.ar)</td>
                                    <td  class="TextoFEASYP_DeteFactweb">
                                        <b><span style="font-size: 11px;">Gratis en la etapa lanzamiento</span></b> (Esta caracter�stica no se aplica a los Servicios
                                        de Interfacturas. Para m�s informacion sobre estos costos consultar en www.interfacturas.com.ar)</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Consultar.</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Plataforma</td>
                                    <td colspan="2" class="TextoFEASYP_DeteFactweb">
                                        Web</td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Cliente Pesado</td>
                                </tr>
                                <tr>
                                    <td class="TextoFEASYP_DetCol1">
                                        Fecha de lanzamiento
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        Fines de Febrero de 2009
                                    </td>
                                    <td class="TextoFEASYP_DeteFactweb">
                                        Fines de Abril del 2009
                                    </td>
                                    <td class="TextoFEASYP_DeteFactcp">
                                        Disponible.
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px;">
                        </td>
                        <td style="height: 10px;">
                            <asp:LinkButton ID="VolverLinkButton" runat="server" CausesValidation="false" ForeColor="Blue" OnClick="VolverLinkButton_Click">Volver a la p�gina anterior</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width:20px">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

