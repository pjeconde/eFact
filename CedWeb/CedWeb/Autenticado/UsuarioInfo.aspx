<%@ Page Language="C#" MasterPageFile="~/Autenticado/CedWebautenticado.master" AutoEventWireup="true" CodeFile="~/Autenticado/UsuarioInfo.aspx.cs" Inherits="CedWeb.Autenticado.UsuarioInfo"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAutenticado" Runat="Server">
    <table style="height:500px; width:850px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top">
                <table style="width:100%" cellpadding="0" cellspacing="0" border="0">
                   <tr>
                        <td style="text-align: center">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina">
                            </asp:Label>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr><td style="height:5px"></td></tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <ContentTemplate>
<!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@--><TABLE cellPadding=10><TBODY><TR><TD><IMG alt="Foto" src="../Imagenes/NoHayFoto.gif" /> </TD><TD><TABLE cellPadding=10><TBODY><TR><TD style="TEXT-ALIGN: left"><asp:Label id="Label1" runat="server" Text="Legajo:" SkinID="TituloMediano"></asp:Label> </TD><TD style="TEXT-ALIGN: justify"><asp:Label id="LegajoLabel" runat="server" SkinID="TituloMediano"></asp:Label> </TD></TR><TR><TD style="WIDTH: 100px; BACKGROUND-COLOR: #fff8dc; TEXT-ALIGN: left"><asp:Label id="Label2" runat="server" Text="Perfil(es):" SkinID="TituloMediano"></asp:Label> </TD><TD style="BACKGROUND-COLOR: #fff8dc; TEXT-ALIGN: left"><asp:GridView id="PerteneceAGridView" runat="server" SkinID="GrillaEspecialSinTitulo">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Descr" InsertVisible="False" ReadOnly="True"
                                                                        SortExpression="Descr">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView> </TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="Label3" runat="server" Text="Info login:" SkinID="TituloMediano"></asp:Label> </TD><TD style="TEXT-ALIGN: justify"><asp:Label id="LoginFechaUltimoAccesoLabel" runat="server" SkinID="TituloMediano"></asp:Label> <asp:Label id="LoginDiasRestantesPasswordLabel" runat="server" SkinID="TituloMediano"></asp:Label> </TD></TR><TR><TD style="WIDTH: 100px; BACKGROUND-COLOR: #fff8dc; TEXT-ALIGN: left"><asp:Label id="RolLabel" runat="server" Text="Rol :" SkinID="TituloMediano" __designer:wfdid="w1"></asp:Label></TD><TD style="WIDTH: 100px; BACKGROUND-COLOR: #fff8dc; TEXT-ALIGN: left"><asp:Label id="DescrRolLabel" runat="server" SkinID="TituloMediano" __designer:wfdid="w2"></asp:Label></TD></TR><TR><TD style="TEXT-ALIGN: left"><asp:Label id="Label4" runat="server" Text="Teams a los que pertece:" SkinID="TituloMediano" __designer:wfdid="w3"></asp:Label></TD><TD style="TEXT-ALIGN: justify">
                                                            <asp:GridView id="TeamsGridView" runat="server" SkinID="GrillaEspecialSinTitulo" __designer:wfdid="w4"><Columns>
                                                            <asp:BoundField DataField="DescrTeam" InsertVisible="False" ReadOnly="True"
                                                                        SortExpression="DescrTeam">
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DescrTeamRol" InsertVisible="False" ReadOnly="True"
                                                                        SortExpression="DescrTeamRol">
                                                                        <ItemStyle Wrap="False" HorizontalAlign="right" />
                                                                    </asp:BoundField>
</Columns>
</asp:GridView></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
</ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width:30px">
                <asp:UpdateProgress ID="UpdateProgress" runat="server">
                    <ProgressTemplate>
                        <img src="/Imagenes/GaliciaAnimado.gif" alt="GaliciaAnimado" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
</asp:Content>

