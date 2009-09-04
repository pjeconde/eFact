<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="ActivacionClientePesadoConsulta.aspx.cs" Inherits="CedeiraAJAX.ActivacionClientePesadoConsulta"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 800px;
        height: 500px; text-align: left;">
        <tr>
            <td style="height: 10px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloParte1Label" runat="server" SkinID="TituloPagina" Text="Consulta de la <b>Clave de activación<b/> del programa "></asp:Label>
                                        <asp:Label ID="TituloParte2Label" runat="server" Font-Bold="True" Font-Size="14px"
                                            ForeColor="#A52A2A" Text="eFact-Residente"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left" style="padding-top: 10px">
                                                    <asp:Label ID="ClaveActivCPLabel" runat="server" Text="Última Clave de activación generada"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding-top: 10px">
                                                    <asp:TextBox ID="ClaveActivCPTextBox" runat="server" Height="80px" ReadOnly="true"
                                                        TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-top: 10px">
                                                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" OnClick="SalirButton_Click"
                                                        TabIndex="1" Text="Salir" Width="200px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" style="padding-top: 10px; padding-bottom: 30px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
