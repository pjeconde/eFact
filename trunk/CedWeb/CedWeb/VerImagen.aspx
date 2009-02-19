<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/VerImagen.aspx.cs" Inherits="CedWeb.CedFCI"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="height:600px; width:800px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top">
                <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
                   <tr>
                        <td style="height: 20px">
                        </td>
                   </tr>
                </table>
                <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
                   <tr>
                        <td style="text-align: center">
                            <asp:Image ID="Image1" Width="640px" Height="400px" ImageUrl="~/Imagenes/CedFCI-Tablero.jpg" runat="server" />
                        </td>
                   </tr>
                   <tr>
                        <td>
                            <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                <ProgressTemplate>
                                    <img src="Imagenes/CedeiraSF-icono-animado.gif" alt="GaliciaAnimado" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>