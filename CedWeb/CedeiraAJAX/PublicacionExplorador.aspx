<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="PublicacionExplorador.aspx.cs" Inherits="CedeiraAJAX.PublicacionExplorador"  %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 800px; text-align: left;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px; width: 500px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Publicaciones"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px;">
                                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Haga clic en la publicación que desee seleccionar."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px; padding-top: 10px" valign="top">
                            <asp:Panel ID="Panel1" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                BorderWidth="1px" Height="373px" ScrollBars="Auto" Width="650px">
                                <cc1:PagingGridView ID="PublicacionPagingGridView" runat="server" OnPageIndexChanging="PublicacionPagingGridView_PageIndexChanging"
                                    OnRowDataBound="PublicacionPagingGridView_RowDataBound" OnSelectedIndexChanged="PublicacionPagingGridView_SelectedIndexChanged"
                                    OnSorting="PublicacionPagingGridView_Sorting">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="IdPublicacion">
                                            <headerstyle horizontalalign="center" wrap="False" />
                                            <itemstyle horizontalalign="center" width="40px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="DescrPublicacion">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" width="200px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Asunto" HeaderText="Asunto" SortExpression="Asunto">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" width="200px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" width="200px" wrap="False" />
                                        </asp:BoundField>
                                    </Columns>
                                </cc1:PagingGridView>
                            </asp:Panel>
                        </td>
                        <td align="left" style="padding-left: 10px; padding-top: 6px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" class="TextoResaltado" style="padding-top: 5px">
                                        Acciones
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="AgregarButton" runat="server" Enabled="true" OnClick="AgregarButton_Click"
                                            Text="Agregar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="ClonarButton" runat="server" Enabled="false" OnClick="ClonarButton_Click"
                                            Text="Clonar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="ModificarButton" runat="server" Enabled="false" OnClick="ModificarButton_Click"
                                            Text="Modificar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="PublicarButton" runat="server" Enabled="false" OnClick="PublicarButton_Click"
                                            Text="Publicar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="CancelarButton" runat="server" Enabled="false" OnClick="CancelarButton_Click"
                                            Text="Cancelar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="SalirButton" runat="server" OnClick="SalirButton_Click" Text="Salir"
                                            Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ @@@-->
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
