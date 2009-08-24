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
                                <cc1:PagingGridView ID="CertPagingGridView" runat="server" 
									OnSorting="CertPagingGridView_Sorting" Width="650px" AutoGenerateColumns="False" OnRowCancelingEdit="CertPagingGridView_RowCancelingEdit" OnRowCommand="CertPagingGridView_RowCommand" OnRowEditing="CertPagingGridView_RowEditing" OnRowUpdating="CertPagingGridView_RowUpdating">
                                    <Columns>
										<asp:TemplateField HeaderText="Id Cuenta" SortExpression="IdCuenta">
											<itemtemplate>
                                                <asp:Label ID="lblIdCuenta" runat="server" Text='<%# Eval("Id") %>'
                                                    Width="100%"></asp:Label>
                                            </itemtemplate>
											<itemstyle horizontalalign="Center" wrap="false" />
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Nombre Cuenta" SortExpression="Nombre">
											<itemtemplate>
                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'
                                                    Width="100%"></asp:Label>
                                            </itemtemplate>
											<itemstyle horizontalalign="Center" wrap="false"/>
										</asp:TemplateField>
										<asp:TemplateField HeaderText="Número de serie del certificado" SortExpression="NroSerieCertificado">
											<itemtemplate>
                                                <asp:Label ID="lblNroSerieCertificado" runat="server" Text='<%# Eval("NroSerieCertificado") %>'
                                                    Width="40%"></asp:Label>
                                            </itemtemplate>
											<edititemtemplate>
                                                <asp:TextBox ID="txtNroSerieCertificado" runat="server" Text='<%# Eval("NroSerieCertificado") %>'
                                                    Width="100%"></asp:TextBox>
                                            </edititemtemplate>
											<itemstyle horizontalalign="Center" wrap="true" />
										</asp:TemplateField>
										<asp:CommandField
											HeaderText="Edición" ShowEditButton="True">
											<headerstyle font-bold="False" horizontalalign="Center" width="150px" />
											<itemstyle horizontalalign="Center" width="10%" />
										</asp:CommandField>
									</Columns>
									<PagerSettings Mode="NumericFirstLast"></PagerSettings>
                                </cc1:PagingGridView>
                            </asp:Panel>
                        </td>
                        <td align="left" style="padding-left: 10px; padding-top: 6px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="SalirButton" runat="server" Text="Salir"
                                            Width="100px" OnClick="SalirButton_Click" />
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

