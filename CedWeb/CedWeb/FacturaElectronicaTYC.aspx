<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/FacturaElectronicaTYC.aspx.cs" Inherits="CedWeb.FacturaElectronicaPreguntasFrec"
 MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="height:500px; width:800px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
           <td valign="top" style="height: 10px">
           </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px; width: 700px">
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
                        <td>
                            <asp:Label ID="Label2" runat="server" SkinID="TituloColor1Mediano" Text="Terminos y Condiciones"></asp:Label>
                            <br/>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label1" runat="server" SkinID="TextoMediano" Text='Los siguientes t�rminos y condiciones generales regular�n expresamente las relaciones surgidas entre este Portal www.cedeira.com.ar de Cedeira Software Factory S.R.L ( en adelante "NUESTRA EMPRESA" ) y Usted (en adelante el "USUARIO o USUARIOS") en virtud de las cuales NUESTRA EMPRESA le brinda servicios de gratuito de generaci�n de comprobantes electr�nicos en un archivo de formato XML, ya sea que se trate de nuevos USUARIOS o aquellos vinculados a trav�s de cualquier acuerdo previo que pudiera existir entre las partes. Este acuerdo sustituye cualquier otra comunicaci�n previa oral o de otro tipo, que haya habido entre las partes. '></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="height: 5px">
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label4" runat="server" SkinID="TextoMediano" Text="La utilizaci�n del Portal www.cedeira.com.ar atribuye la condici�n de USUARIO del Portal, sea persona f�sica o jur�dica, e implica la aceptaci�n plena y sin reservas de todas y cada una de las disposiciones incluidas en estos terminos y condiciones que se detallan a contituaci�n."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="">
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label6" runat="server" SkinID="TituloColor1Mediano" Text="NUESTRA EMPRESA:"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label3" runat="server" SkinID="TituloColor1Mediano" Text="1."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="No asume ninguna responsabilidad por la utilizaci�n de los presentes modelos de carga de comprobantes, ya que s�lo los ofrece en forma gratuita a modo de simplificar las tareas en la carga de la informaci�n del comprobante electr�nico que solicita InterFacturas. "></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label5" runat="server" SkinID="TituloColor1Mediano" Text="2."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="No asume responsabilidad alguna sobre los datos de los comprobantes que usted env�e a Interfacturas. La informaci�n generada desde este sitio web, puede ser modificada por usted."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label7" runat="server" SkinID="TituloColor1Mediano" Text="3."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Se reserva el derecho unilateral de suspender temporalmente o de terminar definitivamente la prestaci�n del servicios a trav�s del Portal. "></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label10" runat="server" SkinID="TituloColor1Mediano" Text="4."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Se reserva el derecho de modificar unilateralmente y en cualquier momento el sistema de acceso al servicio."></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label12" runat="server" SkinID="TituloColor1Mediano" Text="5."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label16" runat="server" SkinID="TextoMediano" Text="No garantiza que el sitio web vaya a funcionar en forma constante, fiable y correctamente, sin retrasos o interrupciones, por lo que no se hace responsable de los da�os y prejuicios que puedan derivarse de los posibles fallos en disponibilidad y continuidad t�cnica del sitio web."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>

                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label14" runat="server" SkinID="TituloColor1Mediano" Text="6."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label15" runat="server" SkinID="TextoMediano" Text="No presenta ninguna garant�a, explicita o impl�citamente, acerca de la utilizaci�n de este servicio gratuito."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label17" runat="server" SkinID="TituloColor1Mediano" Text="7."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label18" runat="server" SkinID="TextoMediano" Text="No ser� responsable por cualquier da�o y/o perjuicio y/o beneficio dejado de obtener por el usuario o cualquier otro tercero causados directa o indirectamente por la conexi�n y/o utilizaci�n y/o acceso al sitio web www.cedeira.com.ar o a p�ginas enlazadas a �l."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>    
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                        </td>
                                    <td style="">
                                        <asp:Label ID="Label20" runat="server" SkinID="TituloColor1Mediano" Text="Ley aplicable y jurisdicci�n competente"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="height: 5px">
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                        </td>
                                    <td style="">
                                        <asp:Label ID="Label22" runat="server" SkinID="TextoMediano" Text="El USUARIO acepta que la legislaci�n aplicable al funcionamiento de este servicio es la Argentina y se somete a la jurisdicci�n de los juzgados y tribunales de la Ciudad Aut�noma de Buenos Aires para la resoluci�n de las devergencias que se deriven de la interpretaci�n o aplicaci�n de este clausulado."></asp:Label>
                                    </td>
                                </tr>
                            </table><table style="">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="WIDTH: 2px">
                                    </td>
                                </tr>
                            </table>
                            <table style="WIDTH: 715px">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="WIDTH: 700px">
                                        <asp:Panel ID="PanelAceptaTYC" runat="server" Height="50px" Width="700px">
                                            <table style="">
                                                <tr>
                                                    <td style="height: 21px; width: 15px;">
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxAceptarTYC" runat="server" Font-Bold="True" ForeColor="Green" Text="Acepta los terminos y condiciones" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="">    
                                                <tr>
                                                    <td style="width: 15px; height: 20px">
                                                    </td>
                                                    <td style="">
                                                        <table cellpadding="0" cellspacing="0" border="0" style="">
                                                            <tr>
                                                                <td style="width:80px; height: 24px;">
                                                                    <asp:Button ID="ButtonAceptar" runat="server" Text="Confirmar" OnClick="ButtonAceptar_Click" />
                                                                </td>
                                                                <td style="HEIGHT: 24px">
                                                                    <asp:Button ID="ButtonRechazar" runat="server" Text="Rechazar" PostBackUrl="~/FacturaElectronica.aspx" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <table style="">    
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="width: 258px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="WIDTH: 258px">
                                        <table style="">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Font-Bold="true" ForeColor="red" Text="�"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="HyperLinkVolverPagAnt" runat="server" NavigateUrl="~/FacturaElectronicaTYC.aspx" SkinID="LinkMedianoClaro">Volver a la pagina anterior</asp:HyperLink>
                                            </td>
                                        </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table><table style="">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="">
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