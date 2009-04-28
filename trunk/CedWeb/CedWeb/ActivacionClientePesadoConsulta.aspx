<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/ActivacionClientePesadoConsulta.aspx.cs" Inherits="CedWeb.ActivacionClientePesadoConsulta"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" Runat="Server">
    <table style="width:800px; height:500px; text-align: left;" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
        <tr>
           <td valign="top" style="height: 10px;">
           </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 20px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o"/>
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloParte1Label" runat="server" Text="Consulta de la <b>Clave de activación<b/> del programa " SkinID="TituloPagina"></asp:Label>
                                        <asp:Label ID="TituloParte2Label" runat="server" Text="eFact-Residente" Font-Size="14px" ForeColor="#A52A2A" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td align="left" style="padding-top:10px">
                                                    <asp:Label ID="ClaveActivCPLabel" runat="server" Text="Última Clave de activación generada"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding-top:10px">
                                                    <asp:TextBox ID="ClaveActivCPTextBox" runat="server" Width="600px" TextMode="MultiLine" Height="80px" ReadOnly="true"></asp:TextBox>
                                                </td>                                                    
                                            </tr>                                            
                                            <tr>
                                                <td align="center" style="padding-top:10px">
                                                    <asp:Button ID="SalirButton" runat="server" Text="Salir" Width="200px" TabIndex="1" OnClick="SalirButton_Click" CausesValidation="false">
                                                    </asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                            
                                <tr>
                                    <td></td>
                                    <td align="center" style="padding-top:10px; padding-bottom:30px">
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