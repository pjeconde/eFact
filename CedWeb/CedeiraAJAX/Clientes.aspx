<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="CedeiraAJAX.Clientes"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" style="height: 500px; width: 800px">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 100%">
                    <tr>
                        <td align="justify" style="padding-left: 10px" valign="middle">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0" style="">
                                <tr>
                                    <td align="left">
                                        <asp:TreeView ID="Arbol" runat="server" SkinID="TextoMediano">
                                        </asp:TreeView>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
