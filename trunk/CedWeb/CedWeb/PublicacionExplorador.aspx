<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/PublicacionExplorador.aspx.cs" Inherits="CedWeb.PublicacionExplorador" MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" runat="Server">
    <table style="height: 500px; width: 800px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
            <td valign="top">
                <table style="width:100%; padding-top:10px" cellpadding="0" cellspacing="0" border="0">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td valign="top" style="padding-left:10px; width:500px">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:21px; height:20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height:20px;">
                                        <asp:Label ID="TituloLabel" runat="server" Text="Publicaciones" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px;" align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Haga clic en la publicación que desee seleccionar." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                            </table>  
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td valign="top" style="padding-left:10px; padding-top:10px">
                            <asp:Panel ID="Panel1" runat="server" Height="373px" Width="650px" ScrollBars="Auto" BorderColor="brown" BorderStyle="Solid" BorderWidth="1px" BackColor="peachpuff">
                                <cc1:PagingGridView ID="PublicacionPagingGridView" runat="server"
                                                    OnSorting="PublicacionPagingGridView_Sorting" OnSelectedIndexChanged="PublicacionPagingGridView_SelectedIndexChanged" OnPageIndexChanging="PublicacionPagingGridView_PageIndexChanging"
                                                    OnRowDataBound="PublicacionPagingGridView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="IdPublicacion">
                                            <headerstyle horizontalalign="center" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="center" width="40px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="DescrPublicacion">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left" width="200px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Asunto" HeaderText="Asunto" SortExpression="Asunto">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left" width="200px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left" width="200px"/>
                                        </asp:BoundField>
                                    </Columns>
                                </cc1:PagingGridView>
                            </asp:Panel>
                        </td>
                        <td valign="top" align="left" style="padding-left:10px; padding-top:6px">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="padding-top:5px" class="TextoResaltado" align="center">
                                        Acciones
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="AgregarButton" runat="server" Text="Agregar" Width="100px" OnClick="AgregarButton_Click" Enabled="true"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="ClonarButton" runat="server" Text="Clonar" Width="100px" OnClick="ClonarButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="ModificarButton" runat="server" Text="Modificar" Width="100px" OnClick="ModificarButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="PublicarButton" runat="server" Text="Publicar" Width="100px" OnClick="PublicarButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" Width="100px" OnClick="CancelarButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="SalirButton" runat="server" Text="Salir" Width="100px" OnClick="SalirButton_Click"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top:10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ @@@-->
                </table>
            </td>
            <td valign="top" style="width: 30px">
            </td>
        </tr>
    </table>
</asp:Content>