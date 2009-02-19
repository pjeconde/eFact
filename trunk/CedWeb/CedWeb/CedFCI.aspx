<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CedFCI.aspx.cs" Inherits="CedWeb.CedFCI"%>
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
                                            <td align="left">
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"/>
                                                <asp:Label ID="CedFCItituloLabel" runat="server" Text="Sistema de Administración de Fondos Comunes de Inversión V3.0" Font-Size="Medium" ForeColor="Black" Font-Bold="True"> </asp:Label>
                                            </td>
                                            <td rowspan="4">
                                                <asp:Image ID="CedFCIimage" runat="server" ImageUrl="Imagenes/CedFCI-Tablero_ch.jpg" Height="150px" ImageAlign="Right"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-right:10px">
                                                <asp:Label ID="CedFCIDescrLabel" runat="server" Text="El sistema de Administración de FCIs es una herramienta de administración de las carteras de inversión de los fondos y de cálculo de los valores de cuotaparte.  Lleva la contabilidad y facilita el cumplimiento de las normas establecidas por el organismo de fiscalización y de los reglamentos de gestión." SkinID="TextoMediano"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-right: 10px; height: 31px" valign="top">
                                                <table>
                                                    <tr>
                                                        <td style="width: 5px">
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="»" SkinID="TituloColor2Mediano" ></asp:Label></td>
                                                        <td style="width: 135px">
                                                            <asp:HyperLink ID="CedFCIpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=CedFCI.pdf" SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink></td>
                                                        <td style="width: 5px">
                                                            <asp:Label ID="CedFCIbarraLabel" runat="server" Text="/" SkinID="TituloColor1Mediano"></asp:Label></td>
                                                        <td style="width: 360px">
                                                            <asp:HyperLink ID="CedFCImasInfoHyperLink" runat="server" NavigateUrl="~/Soluciones.aspx" SkinID="LinkMedianoClaro">Volver a Soluciones</asp:HyperLink></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" style="padding-right:10px">
                                                &nbsp; &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" width="800" style="padding-top:10px">
                                        <tr>
                                            <td style="width:400px" align="left">
                                                <asp:Label ID="Label1" runat="server" Text="Tecnología" Font-Size="Medium" ForeColor="Black" Font-Bold="True" SkinID="TituloColor1Grande"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label4" runat="server" Text="Licencia" Font-Size="Medium" ForeColor="Black" Font-Bold="True" SkinID="TituloColor1Grande"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-right:10px; padding-top:10px" valign="top">
                                                <asp:Label ID="Label2" runat="server" Text="• Cliente/Servidor en tres capas<br>• Workflow basado en datos<br>• Desarrollado en c# (WinForms) para el .Net Framework 2.0<br>• Instalador MSI con control de versión<br>• Motor de base de datos relacional" SkinID="TextoMediano"></asp:Label>
                                            </td>
                                            <td align="left" style="padding-right:10px; padding-top:10px" valign="top">
                                                <asp:Label ID="Label3" runat="server" Text="Esta aplicación, como proyecto de Software Libre, está protegida bajo una Licencia Pública General de GNU" SkinID="TextoMediano"></asp:Label>
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