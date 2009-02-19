<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Clientes.aspx.cs" Inherits="CedWeb.ReferenciasComerciales"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="height:500px; width:800px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top">
                <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
                   <tr>
                        <td style="height: 10px;">
                        </td>
                   </tr>
                </table>
                <table style="width:100%" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
                    <tr>
                        <td align="justify" valign="middle" style="padding-left: 10px">
                                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                                    <table border="0" cellpadding="0" cellspacing="0" style="">
                                        <tr>
                                            <td align="left">
                                                <asp:TreeView SkinID="TextoMediano" ID="Arbol" runat="server"></asp:TreeView>
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