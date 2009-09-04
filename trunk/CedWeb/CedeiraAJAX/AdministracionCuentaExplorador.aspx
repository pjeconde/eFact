<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="AdministracionCuentaExplorador.aspx.cs" Inherits="CedeiraAJAX.AdministracionCuentaExplorador"  %>

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
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Cuentas"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px;">
                                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Haga clic en la cuenta que desee seleccionar."></asp:Label>
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
                                <cc1:PagingGridView ID="CuentaPagingGridView" runat="server" OnPageIndexChanging="CuentaPagingGridView_PageIndexChanging"
                                    OnRowDataBound="CuentaPagingGridView_RowDataBound" OnSelectedIndexChanged="CuentaPagingGridView_SelectedIndexChanged"
                                    OnSorting="CuentaPagingGridView_Sorting">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="IdCuenta">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" width="300px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CantidadComprobantes" HeaderText="qComprob." SortExpression="CantidadComprobantes">
                                            <headerstyle horizontalalign="center" wrap="False" />
                                            <itemstyle horizontalalign="center" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="Cuenta.IdTipoCuenta">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="Cuenta.IdEstadoCuenta">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:CheckBoxField DataField="ActivCP" HeaderText="ActivCP" SortExpression="ActivCP">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="center" wrap="False" />
                                        </asp:CheckBoxField>
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy H:mm}" HeaderText="Fecha alta"
                                            HtmlEncode="false" SortExpression="FechaAlta">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaUltimoComprobante" DataFormatString="{0:dd/MM/yyyy H:mm}"
                                            HeaderText="Fecha ult.comprob." HtmlEncode="false" SortExpression="FechaUltimoComprobante">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaVtoPremium" DataFormatString="{0:dd/MM/yyyy H:mm}"
                                            HeaderText="Fecha vto.Prem." HtmlEncode="false" SortExpression="FechaVtoPremium">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CantidadEnviosMail" HeaderText="qEnv.mail" SortExpression="CantidadEnviosMail">
                                            <headerstyle horizontalalign="center" wrap="False" />
                                            <itemstyle horizontalalign="center" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaUltimoReenvioMail" DataFormatString="{0:dd/MM/yyyy H:mm}"
                                            HeaderText="Fecha ult.env.mail" HtmlEncode="false" SortExpression="FechaUltimoReenvioMail">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NroSerieDisco" HeaderText="Clave solic.ActivCP" SortExpression="NroSerieDisco">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdMedio" HeaderText="Medio" SortExpression="IdMedio">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UltimoNroLote" HeaderText="Ult.N°Lote" SortExpression="UltimoNroLote">
                                            <headerstyle horizontalalign="center" wrap="False" />
                                            <itemstyle horizontalalign="center" wrap="False" />
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
                                        <asp:Button ID="BajaButton" runat="server" Enabled="false" OnClick="BajaButton_Click"
                                            Text="Dar de baja" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="AnularBajaButton" runat="server" Enabled="false" OnClick="AnularBajaButton_Click"
                                            Text="Anular la baja" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="ReenviarMailButton" runat="server" Enabled="false" OnClick="ReenviarMailButton_Click"
                                            Text="Reenviar mail" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="ActivCPButton" runat="server" Enabled="false" OnClick="ActivCPButton_Click"
                                            Text="± Activ.CP" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="TextoResaltado" style="padding-top: 10px">
                                        Servicio Premium
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="ActivarPremiumButton" runat="server" Enabled="false" OnClick="ActivarPremiumButton_Click"
                                            Text="Activar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="SuspenderPremiumButton" runat="server" Enabled="false" OnClick="SuspenderPremiumButton_Click"
                                            Text="Suspender" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="DesactivarPremiumButton" runat="server" Enabled="false" OnClick="DesactivarPremiumButton_Click"
                                            Text="Desactivar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="TextoResaltado" style="padding-top: 10px">
                                        Proceso
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="DepurarButton" runat="server" OnClick="DepurarButton_Click" Text="Depurar"
                                            ToolTip="Depura las bajas y suspende las cuentas Premium vencidas" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 20px">
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
