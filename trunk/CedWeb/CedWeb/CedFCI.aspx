<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CedFCI.aspx.cs"
    Inherits="CedWeb.CedFCI" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0" cellspacing="0" border="0"
        class="TextoComun">
        <tr>
            <td style="width: 780px; padding-left: 10px; padding-top: 10px" valign="top">
                <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="left" valign="top">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0" style="">
                                <tr>
                                    <td colspan="2" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 22px">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="CedFCItituloLabel" runat="server" Text="Sistema de Administración de Fondos Comunes de Inversión"
                                                        SkinID="TituloPagina"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="padding-right: 20px; padding-left: 22px; padding-top: 10px">
                                        <asp:Label ID="CedFCIDescrLabel" runat="server" Text="El sistema de Administración de FCIs es una herramienta de administración de las carteras de inversión de los fondos y de cálculo de los valores de cuotaparte.  Lleva la contabilidad y facilita el cumplimiento de las normas establecidas por el organismo de fiscalización y de los reglamentos de gestión."
                                            SkinID="TextoMediano"></asp:Label>
                                    </td>
                                    <td rowspan="2" style="height: 100%; padding-top: 10px">
                                        <asp:Image ID="CedFCIimage" runat="server" ImageUrl="Imagenes/CedFCI-Tablero_ch.jpg"
                                            Width="220px" ImageAlign="Right" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 10px; vertical-align: bottom">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                        <asp:HyperLink ID="CedFCIpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=Cedeira-SistAdminFCIs.pdf"
                                            SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
                                        <asp:Label ID="CedFCIbarraLabel" runat="server" Text=" / "></asp:Label>
                                        <asp:HyperLink ID="CedFCImasInfoHyperLink" runat="server" NavigateUrl="~/Soluciones.aspx"
                                            SkinID="LinkMedianoClaro">Volver a Soluciones</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 23px">
                                <tr>
                                    <td style="width: 700px" align="left">
                                        <asp:Label ID="Label1" runat="server" Text="Tecnología" Font-Size="Medium" ForeColor="Black"
                                            Font-Bold="True" SkinID="TituloColor1Grande"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-right: 10px; padding-top: 10px" valign="top">
                                        <asp:Label ID="Label3" runat="server" Text="• Cliente/Servidor en tres capas<br>• Workflow basado en datos<br>• Desarrollado en c# (WinForms) para el .Net Framework 2.0<br>• Instalador MSI con control de versión<br>• Motor de base de datos relacional"
                                            SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 20px;" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
