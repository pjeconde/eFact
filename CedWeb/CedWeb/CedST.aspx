<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CedST.aspx.cs"
    Inherits="CedWeb.CedST" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
            <td style="width: 780px; padding-left:10px; padding-top:10px" valign="top">
                <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="left" valign="top">
                            <contenttemplate>
                                <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2" align="left" style="height: 10px">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="width: 22px; height: 20px;">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"/>
                                                    </td>
                                                    <td style="height: 20px">
                                                        <asp:Label ID="CedSTtituloLabel" runat="server" Text="Sistema de Transferencias ( implementación MEP ) V2.4" SkinID="TituloPagina" Width="415px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="padding-right:20px; padding-left:22px; padding-top:10px">
                                            <asp:Label ID="CedSTDescrLabel" runat="server" SkinID="TextoMediano" Text="Es un sistema diseñado para centralizar la administración de transferencias.  En línea con el BCRA, concentra el 100% de las operaciones, tanto enviadas como recibidas, en un único repositorio, para realizar un control eficiente y una óptima gestión operativa.  Facilita las tareas a través de la automatización de los procesos de: ingreso, envío, recepción, distribución y conciliación, entre otros. Contempla todas las operatorias, acorde a las normativas, y se encuentra integrado al Sistema de Medios de Pagos (Mep) del BCRA."></asp:Label>
                                        </td>
                                        <td rowspan="2" style="padding-top:10px">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="Imagenes/CedST-Tablero_ch.jpg" Width="220px" ImageAlign="Right"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" style="padding-right:10px; vertical-align:bottom">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="red" Text="»" ></asp:Label>
                                            <asp:HyperLink ID="CedSTpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=Cedeira-SistTransfMEP.pdf" SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
                                            <asp:Label ID="CedSTbarraLabel" runat="server" Text=" / "></asp:Label>
                                            <asp:HyperLink ID="CedSTmasInfoHyperLink" runat="server" NavigateUrl="~/Soluciones.aspx" SkinID="LinkMedianoClaro">Volver a Soluciones</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0" style="padding-left:23px">
                                    <tr>
                                        <td style="width:700px" align="left">
                                            <asp:Label ID="Label1" runat="server" Text="Tecnología" Font-Size="Medium" ForeColor="Black" Font-Bold="True" SkinID="TituloColor1Grande"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding-right:10px; padding-top:10px" valign="top">
                                            <asp:Label ID="Label3" runat="server" Text="• Cliente/Servidor en tres capas<br>• Workflow basado en datos<br>• Desarrollado en c# (WinForms) para el .Net Framework 2.0<br>• Instalador MSI con control de versión<br>• Motor de base de datos relacional" SkinID="TextoMediano"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:200px; padding-top:10px" align="left">
                                            <asp:Label ID="Label4" runat="server" Text="Precio de la Licencia" Font-Size="Medium" ForeColor="Black" Font-Bold="True" SkinID="TituloColor1Grande"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="padding-right:10px; padding-top:10px">
                                            <asp:Label ID="Label5" runat="server" Text="El precio de la licencia, durante el primer semestre del año 2009, se encuentra "></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text="bonificado " Font-Bold="true" Font-Size="Large" ForeColor="brown"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text="en un "></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text="100%" Font-Bold="true" Font-Size="Large" ForeColor="brown"></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text="."></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                            </contenttemplate>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 20px;" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>