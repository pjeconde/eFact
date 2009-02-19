<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CedST.aspx.cs" Inherits="CedWeb.CedST"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="height:500px; width:800px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top">
                <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
                   <tr>
                        <td style="text-align: center">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr><td style="height:5px"></td></tr>
                    <tr>
                        <td align="center">
                                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                                    <table border="0" cellpadding="0" cellspacing="0" width="800" style="padding-top:10px">
                                        <tr>
                                            <td colspan="2" align="left">
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"/>
                                                <asp:Label ID="CedSTtituloLabel" runat="server" Text="Sistema de Transferencias ( implementación MEP ) V2.4" Font-Size="Medium" ForeColor="Black" Font-Bold="True"> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-right:10px">
                                                <asp:Label ID="CedSTDescrLabel" runat="server" Text="Es un sistema diseñado para centralizar la administración de transferencias.  En línea con el BCRA, concentra el 100% de las operaciones, tanto enviadas como recibidas, en un único repositorio, para realizar un control eficiente y una óptima gestión operativa.  Facilita las tareas a través de la automatización de los procesos de: ingreso, envío, recepción, distribución y conciliación, entre otros. Contempla todas las operatorias, acorde a las normativas, y se encuentra integrado al Sistema de Medios de Pagos (Mep) del BCRA." SkinID="TextoInicioMediano"></asp:Label>
                                            </td>
                                            <td rowspan="2">
                                                <asp:Image ID="CedSTimage" runat="server" ImageUrl="Imagenes/CedST-Tablero_ch.jpg" Height="150px" ImageAlign="Right"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" style="padding-right:10px">
                                                <table>
                                                    <tr>
                                                        <td style="width: 5px">
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="red" Text="»" ></asp:Label>
                                                        <td style="width: 140px">
                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Descarga.aspx?archivo=CedST.pdf" SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
                                                        <td style="width: 5px">
                                                            <asp:Label ID="Label6" runat="server" Text=" / " SkinID="TituloColor1Mediano"></asp:Label>
                                                        <td style="width: 360px">
                                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Soluciones.aspx" SkinID="LinkMedianoClaro">Volver a Soluciones</asp:HyperLink>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" width="800" style="padding-top:10px">
                                        <tr>
                                            <td style="width:400px; height: 29px;" align="left">
                                                <asp:Label ID="Label1" runat="server" Text="Tecnología" Font-Size="Medium" ForeColor="Black" Font-Bold="True"> </asp:Label>
                                            </td>
                                            <td style="height: 29px" align="left">
                                                <asp:Label ID="Label4" runat="server" Text="Licencia" Font-Size="Medium" ForeColor="Black" Font-Bold="True"> </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-right:10px; padding-top:10px" valign="top">
                                                <asp:Label ID="Label3" runat="server" Text="• Cliente/Servidor en tres capas<br>• Workflow basado en datos<br>• Desarrollado en c# (WinForms) para el .Net Framework 2.0<br>• Instalador MSI con control de versión<br>• Motor de base de datos relacional"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-right:10px; padding-top:10px" valign="top">
                                                <asp:Label ID="Label5" runat="server" Text="Esta aplicación, como proyecto de Software Libre, está protegida bajo una Licencia Pública General de GNU"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width:30px">
            </td>
        </tr>
    </table>
</asp:Content>