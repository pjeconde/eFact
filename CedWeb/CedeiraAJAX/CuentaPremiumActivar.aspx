<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="CuentaPremiumActivar.aspx.cs" Inherits="CedeiraAJAX.CuentaPremiumActivar"  %>

<%@ Register Src="DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" style="height: 500px; width: 800px">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 100%;
                    padding-top: 10px">
                    <tr>
                        <td align="left" style="padding-left: 10px" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Activación de Servicio Premium"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-left: 32px">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <asp:Label ID="Label2" runat="server" Text="Mediante esta opción se habilita temporariamente el Servicio Premium."></asp:Label>
                            <table id="Table1" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 20px">
                                        <asp:Label ID="Label6" runat="server" Text="Id.Usuario"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 20px">
                                        <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" ReadOnly="true"
                                            TabIndex="1" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre y Apellido"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" ReadOnly="true" TabIndex="1"
                                            Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" ReadOnly="true" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FechaVtoPremiumDatePickerWebUserControl:txt_Date"
                                            ErrorMessage="Fecha de vto. del servicio" SetFocusOnError="True">
                                            <asp:Label ID="Label51" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label22" runat="server" Text="Fecha de vto. del servicio (AAAAMMDD)"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <uc1:DatePickerWebUserControl ID="FechaVtoPremiumDatePickerWebUserControl" runat="server"
                                            TabIndex="21" TextCssClass="DatePickerFecha" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2">
                                        El vencimiento del Servicio Premium operará a las 12 de la noche<br />
                                        del día ingresado. A partir de entonces, la cuenta premium quedará
                                        <br />
                                        "Suspendida" hasta que el servicio se "Restablezca".
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2">
                                        La activación se puede anular mediante la acción de "Desactivar",<br />
                                        que devuelve la Cuenta al Servicio Gratuito.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" TabIndex="4"
                                            Text="Activar" Width="100px" />
                                    </td>
                                    <td align="right" style="padding-top: 10px">
                                        <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Admin/Cuenta/Explorador.aspx"
                                            TabIndex="5" Text="Cancelar" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="padding-top: 10px; padding-bottom: 30px">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
