<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Explorador.aspx.cs" Inherits="CedeiraAJAX.Comprador.Explorador" %>
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
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Confirguración de datos de Compradores"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Label ID="Label2" runat="server" Text="Configure los datos de Compradores para ahorrar tiempo al momento de ingresar las facturas."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 5px;">
                                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Haga clic en el comprador que desee seleccionar."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px; padding-top: 10px" valign="top">
                            <asp:Panel ID="Panel1" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                BorderWidth="1px" Height="400px" ScrollBars="Auto" Width="650px">
                                <cc1:PagingGridView ID="CompradorPagingGridView" runat="server" OnPageIndexChanging="CompradorPagingGridView_PageIndexChanging"
                                    OnRowDataBound="CompradorPagingGridView_RowDataBound" OnSelectedIndexChanged="CompradorPagingGridView_SelectedIndexChanged"
                                    OnSorting="CompradorPagingGridView_Sorting">
                                    <Columns>
                                        <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrTipoDoc" HeaderText="Tipo Doc." SortExpression="DescrTipoDoc">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NroDoc" HeaderText="Nro.Doc." SortExpression="NroDoc">
                                            <headerstyle horizontalalign="right" wrap="False" />
                                            <itemstyle horizontalalign="right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NombreContacto" HeaderText="Contacto" SortExpression="NombreContacto">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmailContacto" HeaderText="Email" SortExpression="EmailContacto">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TelefonoContacto" HeaderText="Telefono" SortExpression="TelefonoContacto">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Calle" HeaderText="Calle" SortExpression="Calle">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nro" HeaderText="Nro" SortExpression="Nro">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Piso" HeaderText="Piso" SortExpression="Piso">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Depto" HeaderText="Depto" SortExpression="Depto">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Torre" HeaderText="Torre" SortExpression="Torre">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Manzana" HeaderText="Manzana" SortExpression="Manzana">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrProvincia" HeaderText="Provincia" SortExpression="DescrProvincia">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodPost" HeaderText="CodPost" SortExpression="CodPost">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrCondIVA" HeaderText="Condicion I.V.A." SortExpression="DescrCondIVA">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NroIngBrutos" HeaderText="Nro.I.B." SortExpression="NroIngBrutos">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrCondIngBrutos" HeaderText="Condicion I.B." SortExpression="DescrCondIngBrutos">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GLN" HeaderText="GLN" SortExpression="GLN">
                                            <headerstyle horizontalalign="right" wrap="False" />
                                            <itemstyle horizontalalign="right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodigoInterno" HeaderText="Codigo Interno" SortExpression="DescrCondIngBrutos">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrCondIngBrutos" HeaderText="Condicion I.B." SortExpression="CodigoInterno">
                                            <headerstyle horizontalalign="right" wrap="False" />
                                            <itemstyle horizontalalign="right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaInicioActividades" HeaderText="Fec.inicio activ."
                                            SortExpression="FechaInicioActividades">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmailAvisoVisualizacion" HeaderText="Email aviso p/visualiz.de comprob." SortExpression="EmailAvisoVisualizacion">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PasswordAvisoVisualizacion" HeaderText="Contraseña" SortExpression="PasswordAvisoVisualizacion">
                                            <headerstyle horizontalalign="left" wrap="False" />
                                            <itemstyle horizontalalign="left" wrap="False" />
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
                                        <asp:Button ID="CrearButton" runat="server" OnClick="CrearButton_Click" Text="Nuevo"
                                            Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="EliminarButton" runat="server" Enabled="false" OnClick="EliminarButton_Click"
                                            Text="Eliminar" Width="100px" />
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
                                        <asp:Button ID="ConsultarButton" runat="server" Enabled="false" OnClick="ConsultarButton_Click"
                                            Text="Consultar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 20px">
                                        <asp:Button ID="SalirButton" runat="server" OnClick="SalirButton_Click" Text="Salir"
                                            Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 20px">
                                        <asp:Button ID="BackupButton" runat="server" BackColor="peachpuff" BorderColor="brown"
                                            BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" ForeColor="brown" Height="50px"
                                            OnClick="BackupButton_Click" Text="Descargar" ToolTip="Exclusivo SERVICIO PREMIUM"
                                            Width="100px" />
                                        <br />
                                        <asp:Label ID="BackupLabel" runat="server" Font-Size="X-Small" ForeColor="brown"
                                            Text="(copia de seguridad)" ToolTip="Exclusivo SERVICIO PREMIUM"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
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
