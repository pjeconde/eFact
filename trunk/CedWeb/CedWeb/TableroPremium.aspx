﻿<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/TableroPremium.aspx.cs" Inherits="CedWeb.TableroPremium" MaintainScrollPositionOnPostback="true"%>
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
                                        <asp:Label ID="TituloLabel" runat="server" Text="Confirguración de datos de Compradores" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px" align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Configure los datos de Compradores para ahorrar tiempo al momento de ingresar las facturas."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:5px;" align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Haga clic en el comprador que desee seleccionar." SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                            </table>  
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td valign="top" style="padding-left:10px; padding-top:10px">
                            <asp:Panel ID="Panel1" runat="server" Height="400px" Width="650px" ScrollBars="Auto" BorderColor="brown" BorderStyle="Solid" BorderWidth="1px" BackColor="peachpuff">
                                <cc1:PagingGridView ID="CompradorPagingGridView" runat="server"
                                                    OnSorting="CompradorPagingGridView_Sorting" OnSelectedIndexChanged="CompradorPagingGridView_SelectedIndexChanged" OnPageIndexChanging="CompradorPagingGridView_PageIndexChanging"
                                                    OnRowDataBound="CompradorPagingGridView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrTipoDoc" HeaderText="Tipo Doc." SortExpression="DescrTipoDoc">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NroDoc" HeaderText="Nro.Doc." SortExpression="NroDoc">
                                            <headerstyle horizontalalign="right" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="right"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NombreContacto" HeaderText="Contacto" SortExpression="NombreContacto">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmailContacto" HeaderText="Email" SortExpression="EmailContacto">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TelefonoContacto" HeaderText="Telefono" SortExpression="TelefonoContacto">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Calle" HeaderText="Calle" SortExpression="Calle">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nro" HeaderText="Nro" SortExpression="Nro">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Piso" HeaderText="Piso" SortExpression="Piso">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Depto" HeaderText="Depto" SortExpression="Depto">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Torre" HeaderText="Torre" SortExpression="Torre">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Manzana" HeaderText="Manzana" SortExpression="Manzana">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrProvincia" HeaderText="Provincia" SortExpression="DescrProvincia">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodPost" HeaderText="CodPost" SortExpression="CodPost">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrCondIVA" HeaderText="Condicion I.V.A." SortExpression="DescrCondIVA">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NroIngBrutos" HeaderText="Nro.I.B." SortExpression="NroIngBrutos">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrCondIngBrutos" HeaderText="Condicion I.B." SortExpression="DescrCondIngBrutos">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GLN" HeaderText="GLN" SortExpression="GLN">
                                            <headerstyle horizontalalign="right" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="right"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodigoInterno" HeaderText="Codigo Interno" SortExpression="DescrCondIngBrutos">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrCondIngBrutos" HeaderText="Condicion I.B." SortExpression="CodigoInterno">
                                            <headerstyle horizontalalign="right" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="right"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaInicioActividades" HeaderText="Fec.inicio activ." SortExpression="FechaInicioActividades">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
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
                                        <asp:Button ID="CrearButton" runat="server" Text="Nuevo" Width="100px" OnClick="CrearButton_Click"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" Width="100px" OnClick="EliminarButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="ModificarButton" runat="server" Text="Modificar" Width="100px" OnClick="ModificarButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:5px">
                                        <asp:Button ID="ConsultarButton" runat="server" Text="Consultar" Width="100px" OnClick="ConsultarButton_Click" Enabled="false"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:20px">
                                        <asp:Button ID="SalirButton" runat="server" Text="Salir" Width="100px" OnClick="SalirButton_Click"> </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top:20px" align="center">
                                        <asp:Button ID="BackupButton" runat="server" Text="Descargar" Height="50px" Width="100px" OnClick="BackupButton_Click" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid" BorderWidth="1px" ForeColor="brown" Font-Bold="true" ToolTip="Exclusivo SERVICIO PREMIUM"> </asp:Button>
                                        <br />
                                        <asp:Label ID="BackupLabel" runat="server" Font-Size="X-Small" Text="(copia de seguridad)" ForeColor="brown" ToolTip="Exclusivo SERVICIO PREMIUM"></asp:Label>
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

