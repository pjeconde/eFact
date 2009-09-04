<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="CedeiraAJAX.Backup"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        height: 500px; text-align: left;">
        <tr>
            <td style="height: 10px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="width: 750px;" valign="middle">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" SkinID="TituloPagina" Text="Descargas"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="Label1" runat="server" Font-Size="X-Small" ForeColor="brown" Text="(exclusivo SERVICIO PREMIUM)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 10px">
                                        <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Tiene disponible las siguientes descargas:"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 39px">
                                    </td>
                                    <td align="left" style="padding-top: 20px; height: 39px;" valign="middle">
                                        <asp:LinkButton ID="BackupVendedorLinkButton" runat="server" CausesValidation="false"
                                            Font-Size="14px" ForeColor="blue" OnClick="BackupVendedorLinkButton_Click">Datos del Vendedor</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:LinkButton ID="BackupCompradoresLinkButton" runat="server" CausesValidation="false"
                                            Font-Size="14px" ForeColor="blue" OnClick="BackupCompradoresLinkButton_Click">Datos de Compradores</asp:LinkButton>
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
