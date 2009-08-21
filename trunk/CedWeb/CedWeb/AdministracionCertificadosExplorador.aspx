<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="AdministracionCertificadosExplorador.aspx.cs" Inherits="AdministracionCertificadosExplorador" %>
<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
<asp:Content ID="AdministracionCertificadosExploradorContent" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
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
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico"></asp:Image>
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Certificados"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px; padding-top: 10px" valign="top">
                            <asp:Panel ID="CertificadosPanel" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                BorderWidth="1px" Height="400px" ScrollBars="Auto" Width="650px">
                                <cc1:PagingGridView ID="CertPagingGridView" runat="server" OnSorting="CertPagingGridView_Sorting">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id Cuenta"  SortExpression="IdCuenta">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Cuenta" SortExpression="Nombre">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle  wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NroSerieCertificado" HeaderText="Número de serie del certificado"
                                            SortExpression="NroSerieCertificado">
                                            <headerstyle horizontalalign="left" wrap="False"/>
                                            <itemstyle wrap="False" horizontalalign="left"/>
                                        </asp:BoundField>
                                    </Columns>
                                </cc1:paginggridview>
                            </asp:Panel>
                        </td>
                        <td align="left" style="padding-left: 10px; padding-top: 6px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="SalirButton" runat="server" Text="Salir"
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

