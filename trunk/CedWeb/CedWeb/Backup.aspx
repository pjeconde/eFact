<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Backup.aspx.cs" Inherits="CedWeb.Backup"%>
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
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Descargas" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px">
                                        <asp:Label ID="Label13" runat="server" Text="Tiene disponible las siguientes descargas:" SkinID="TextoMediano"></asp:Label>                                    
                                    </td>
                                </tr>                                
                                <tr>
                                    <td style="height: 39px"></td>
                                    <td style="padding-top:20px; height: 39px;" valign="middle" align="left">
                                        <asp:LinkButton ID="BackupVendedorLinkButton" runat="server" CausesValidation="false" ForeColor="blue" Font-Size="14px" OnClick="BackupVendedorLinkButton_Click">Datos del Vendedor</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px" align="left">
                                        <asp:LinkButton ID="BackupCompradoresLinkButton" runat="server" CausesValidation="false" ForeColor="blue" Font-Size="14px" OnClick="BackupCompradoresLinkButton_Click">Datos de Compradores</asp:LinkButton>
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
