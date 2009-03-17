<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaExplorador.aspx.cs" Inherits="CedWeb.CuentaExplorador" %>
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
                                        <asp:Label ID="TituloLabel" runat="server" Text="Cuentas" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px;" align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Haga clic en la cuenta que desee seleccionar." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                            </table>  
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td valign="top" style="padding-left:10px; padding-top:10px">
                            <asp:Panel ID="Panel1" runat="server" Height="400px" Width="650px" ScrollBars="Auto" BorderColor="brown" BorderStyle="Solid" BorderWidth="1px" BackColor="peachpuff">
                                <cc1:PagingGridView ID="CuentaPagingGridView" runat="server"
                                                    OnSorting="CuentaPagingGridView_Sorting" OnSelectedIndexChanged="CuentaPagingGridView_SelectedIndexChanged" OnPageIndexChanging="CuentaPagingGridView_PageIndexChanging"
                                                    OnRowDataBound="CuentaPagingGridView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                            <headerstyle horizontalalign="left"/>
                                            <itemstyle wrap="False" horizontalalign="left" Width="300px"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <headerstyle horizontalalign="left"/>
                                            <itemstyle  wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono">
                                            <headerstyle horizontalalign="left"/>
                                            <itemstyle  wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                            <headerstyle horizontalalign="left"/>
                                            <itemstyle  wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrTipoCuenta" HeaderText="Tipo" SortExpression="DescrTipoCuenta">
                                            <headerstyle horizontalalign="left"/>
                                            <itemstyle  wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrEstadoCuenta" HeaderText="Estado" SortExpression="DescrEstadoCuenta">
                                            <headerstyle horizontalalign="left"/>
                                            <itemstyle  wrap="False" horizontalalign="left"/>
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
                                        <asp:Button ID="BajaButton" runat="server" Text="Dar de baja" Width="100%" OnClick="BajaButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="AnularBajaButton" runat="server" Text="Anular la baja" Width="100%" OnClick="AnularBajaButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:10px" class="TextoResaltado" align="center">
                                        Servicio Premium
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="SuspenderPremiumButton" runat="server" Text="Suspender" Width="100%" OnClick="SuspenderPremiumButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="RestablecerPremiumButton" runat="server" Text="Restablecer" Width="100%" OnClick="RestablecerPremiumButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top:10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"/>
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
