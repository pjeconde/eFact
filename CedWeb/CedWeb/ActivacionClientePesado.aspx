<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/ActivacionClientePesado.aspx.cs" Inherits="CedWeb.ActivacionClientePesado"%>
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
                                        <asp:Label ID="TituloParte1Label" runat="server" Text="Activación del programa " SkinID="TituloPagina"></asp:Label>
                                        <asp:Label ID="TituloParte2Label" runat="server" Text="eFact-Residente" Font-Size="14px" ForeColor="#A52A2A" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td colspan="3" style="padding-top:20px; padding-left:5px" valign="middle">
                                                    Para obtener la <b>Clave de activación</b>, del programa eFact-Residente, ingrese la <b>Clave de solicitud</b>:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width:50%; padding-top:10px; padding-right:5px; vertical-align:middle">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  SetFocusOnError="True"
                                                        ControlToValidate="ClaveSolicitudTextBox" ErrorMessage="Clave de solicitud">
                                                        <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="ClaveSolicitudLabel" runat="server" Text="Clave de solicitud"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:10px">
                                                    <asp:TextBox ID="ClaveSolicitudTextBox" runat="server" Width="200px" TabIndex="9" MaxLength="20"></asp:TextBox>
                                                </td>                                                    
                                                <td style="width:50%; padding-top:10px"> 
                                                </td>                                                    
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding-top:10px; padding-left:5px" valign="middle">
                                                    Una vez ingresada la <b>Clave de solicitud</b>, haga click en el botón "Obtener Clave de activación".
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td align="center" style="padding-top:10px">
                                                    <asp:Button ID="SolicitarActivCPButton" runat="server" Text="Obtener Clave de activación" Width="200px" TabIndex="10" OnClick="SolicitarActivCPButton_Click">
                                                    </asp:Button>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-top:10px; padding-right:5px; vertical-align:middle">
                                                    <asp:Label ID="ClaveActivCPLabel" runat="server" Text="Clave de activación"></asp:Label>
                                                </td>
                                                <td colspan="2" align="left" style="padding-top:10px">
                                                    <asp:TextBox ID="ClaveActivCPTextBox" runat="server" Width="100%" TabIndex="9" MaxLength="20"></asp:TextBox>
                                                </td>                                                    
                                            </tr>                                            
                                            <tr>
                                                <td colspan="3" style="padding-top:10px; padding-left:5px" valign="middle">
                                                    Copie la <b>Clave de activación</b> obtenida en la ventana de activación del programa eFact-Residente
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding-top:5px; padding-left:5px" valign="middle">
                                                    para que quede completamente operativo.
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                            
                                <tr>
                                    <td></td>
                                    <td align="center" style="padding-bottom:30px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"/>
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