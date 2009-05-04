<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaPremiumActivar.aspx.cs" Inherits="CedWeb.CuentaPremiumActivar" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top">
                <table style="width: 100%; padding-top:10px" cellpadding="0" cellspacing="0" border="0" class="TextoComun">
                    <tr>
                        <td align="left" valign="top" style="padding-left: 10px">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" Text="Activación de Servicio Premium" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>                        
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr><td style="height:10px"></td></tr>
                    <tr>
                        <td align="left" style="padding-left:32px" colspan="2">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <asp:Label ID="Label2" runat="server" Text="Mediante esta opción se habilita temporariamente el Servicio Premium."></asp:Label>
                            <table id="Table1" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-right:5px; padding-top:20px" align="right">
                                        <asp:Label ID="Label6" runat="server" Text="Id.Usuario" ></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:20px">
                                        <asp:TextBox ID="IdUsuarioTextBox" runat="server" Width="360px" TabIndex="1" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre y Apellido" ></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" Width="360px" TabIndex="1" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" Width="360px" ReadOnly="true" MaxLength="128"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="FechaVtoPremiumDatePickerWebUserControl:txt_Date" ErrorMessage="Fecha de vto. del servicio">
                                            <asp:Label ID="Label51" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label22" runat="server" Text="Fecha de vto. del servicio (AAAAMMDD)"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <uc1:DatePickerWebUserControl ID="FechaVtoPremiumDatePickerWebUserControl" runat="server" TextCssClass="DatePickerFecha" TabIndex="21" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">
                                        El vencimiento del Servicio Premium operará a las 12 de la noche<br />del día ingresado.  A partir de entonces, la cuenta premium quedará <br />"Suspendida" hasta que el servicio se "Restablezca".
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">
                                        La activación se puede anular mediante la acción de "Desactivar",<br />que devuelve la Cuenta al Servicio Gratuito.
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="padding-top:10px">
                                        <asp:Button ID="GuardarButton" runat="server" Text="Activar" Width="100px" OnClick="GuardarButton_Click" TabIndex="4">
                                        </asp:Button>
                                    </td>
                                    <td align="right" style="padding-top:10px">
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" Width="100px" PostBackUrl="~/AdministracionCuentaExplorador.aspx" CausesValidation="false" TabIndex="5">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding-top:10px; padding-bottom:30px">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"/>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width: 30px">
            </td>
        </tr>
    </table>
</asp:Content>