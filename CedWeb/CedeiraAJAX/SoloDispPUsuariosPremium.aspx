﻿<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="SoloDispPUsuariosPremium.aspx.cs" Inherits="CedeiraAJAX.SoloDispPUsuariosPremium"  %>

<asp:Content ID="ExContent" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 800px; text-align: left;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <tr>
                        <td style="padding-left: 10px" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 32px; padding-right: 32px">
                            <asp:Label ID="Label1" runat="server" SkinID="MensajePaginaSinWidth" Text="Esta opción esta disponible sólo para USUARIOS PREMIUM."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 32px; padding-right: 32px">
                            <asp:Label ID="Label6" runat="server" SkinID="MensajePaginaSinWidth" Text="Si ya ha creado su cuenta eFact, identifiquese en la página de "></asp:Label>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Inicio</asp:HyperLink>
                            <asp:Label ID="Label8" runat="server" SkinID="MensajePaginaSinWidth" Text="."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 32px; padding-right: 32px;">
                            <asp:Label ID="Label14" runat="server" SkinID="MensajePaginaSinWidth" Text="Si no ha creado su cuenta eFact, y desea hacerlo, haga clic "></asp:Label>
                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkMedianoClaro">aquí</asp:HyperLink>
                            <asp:Label ID="Label15" runat="server" SkinID="MensajePaginaSinWidth" Text="."></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
