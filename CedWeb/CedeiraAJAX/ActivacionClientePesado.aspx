<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="ActivacionClientePesado.aspx.cs" Inherits="CedeiraAJAX.ActivacionClientePesado"  %>

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
                                        <asp:Label ID="TituloParte1Label" runat="server" SkinID="TituloPagina" Text="Activación del programa "></asp:Label>
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
                                                <td colspan="3" style="padding-top: 20px; padding-left: 5px" valign="middle">
                                                    Para obtener la <b>Clave de activación</b>, del programa eFact-Residente, ingrese
                                                    la <b>Clave de solicitud</b>:
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 50%; padding-top: 10px; padding-right: 5px; vertical-align: middle">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ClaveSolicitudTextBox"
                                                        ErrorMessage="Clave de solicitud" SetFocusOnError="True">
                                                        <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="ClaveSolicitudLabel" runat="server" Text="Clave de solicitud"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 10px">
                                                    <asp:TextBox ID="ClaveSolicitudTextBox" runat="server" Height="80px" TabIndex="1"
                                                        TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                </td>
                                                <td style="width: 50%; padding-top: 10px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Una vez ingresada la <b>Clave de solicitud</b>, haga click en el botón "Obtener
                                                    Clave de activación".
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="left" style="padding-top: 10px">
                                                    <asp:Button ID="SolicitarActivCPButton" runat="server" OnClick="SolicitarActivCPButton_Click"
                                                        TabIndex="2" Text="Obtener Clave de activación" Width="200px" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-top: 10px; padding-right: 5px; vertical-align: middle">
                                                    <asp:Label ID="ClaveActivCPLabel" runat="server" Text="Clave de activación"></asp:Label>
                                                </td>
                                                <td align="left" colspan="2" style="padding-top: 10px">
                                                    <asp:TextBox ID="ClaveActivCPTextBox" runat="server" Height="80px" ReadOnly="true"
                                                        TabIndex="3" TextMode="MultiLine" Width="600px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding-top: 10px; padding-left: 5px" valign="middle">
                                                    Copie la <b>Clave de activación</b> obtenida en la ventana de activación del programa
                                                    eFact-Residente para que quede
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="padding-top: 5px; padding-left: 5px" valign="middle">
                                                    completamente operativo.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="left" style="padding-top: 10px">
                                                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" OnClick="SalirButton_Click"
                                                        TabIndex="10" Text="Salir" Width="200px" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" style="padding-bottom: 30px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
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
