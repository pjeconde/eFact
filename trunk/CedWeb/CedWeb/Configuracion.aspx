<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Configuracion.aspx.cs" Inherits="CedWeb.Configuracion"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="width:800px; height:500px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
           <td valign="top" style="height: 10px;">
           </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 20px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o"/>
                                    </td>
                                    <td style="width:750px;">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Configuración" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label13" runat="server" Text="Tiene disponible las siguientes tareas de configuración:" SkinID="TextoMediano"></asp:Label>                                    
                                    </td>
                                </tr>                                
                                <tr>
                                    <td></td>
                                    <td align="center">
                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="padding-top:20px" valign="top">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Bola1.png"/>
                                                </td>
                                                <td style="padding-top:20px; padding-left:5px; width:680px" valign="middle" align="left">
                                                    &nbsp;<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/CuentaConfiguracion.aspx" SkinID="LinkGrandeClaro">Configure su Cuenta eFact</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Bola2.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left">
                                                    &nbsp;<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Vendedor.aspx" SkinID="LinkGrandeClaro">Configure los datos del Vendedor</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/Bola3.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left">
                                                    &nbsp;<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/CompradorExplorador.aspx" SkinID="LinkGrandeClaro">Configure los datos de los Compradores</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top:10px">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Bola4.png"/>
                                                </td>
                                                <td style="padding-top:10px; padding-left:5px" align="left">
                                                    &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CuentaCambiarPassword.aspx" SkinID="LinkGrandeClaro">Cambie su Contraseña</asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
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