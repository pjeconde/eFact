<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaCambiarPassword.aspx.cs"
    Inherits="CedWeb.CuentaCambiarPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">

    <table style="height: 500px; width: 800px; text-align: left;" cellpadding="0" cellspacing="0"
        border="0" class="TextoComun">
        <tr>
            <td valign="top">
                <table style="width:100%; padding-top:10px" cellpadding="0" cellspacing="0" border="0">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td valign="top" style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" Text="Cambio de Contraseña de la cuenta " Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electrónica"/>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:21px"></td>
                                    <td style="padding-top:10px;" align="left">
                                        <asp:Label ID="Label8" runat="server" Text="Para realizar el cambio de la Contraseña de su cuenta eFact, ingrese los datos que se solicitan a continuación:" SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                            </table>  

                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-top:20px" align="center">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="right" style="padding-right:10px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" SetFocusOnError="True"
                                            ControlToValidate="PasswordTextBox" ErrorMessage="Contraseña actual"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="PasswordTextBox" ErrorMessage="Contraseña actual">
                                            <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label15" runat="server" Text="Contraseña actual"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:TextBox ID="PasswordTextBox" runat="server" Width="120px" TextMode="Password" TabIndex="1" OnTextChanged="TextBox_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right:10px; padding-top:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" SetFocusOnError="True"
                                            ControlToValidate="PasswordNuevaTextBox" ErrorMessage="Contraseña nueva"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="PasswordNuevaTextBox" ErrorMessage="Contraseña nueva">
                                            <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label1" runat="server" Text="Contraseña nueva"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-right:10px; padding-top:5px">
                                        <asp:TextBox ID="PasswordNuevaTextBox" runat="server" Width="120px" TextMode="Password" TabIndex="2" OnTextChanged="TextBox_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right:10px; padding-top:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" SetFocusOnError="True"
                                            ControlToValidate="ConfirmacionPasswordNuevaTextBox" ErrorMessage="Confirmación de Contraseña nueva"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="ConfirmacionPasswordNuevaTextBox" ErrorMessage="Confirmación de Contraseña nueva">
                                            <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label2" runat="server" Text="Confirmación de Contraseña nueva"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-right:10px; padding-top:5px">
                                        <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" Width="120px" TextMode="Password" TabIndex="3" OnTextChanged="TextBox_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="padding-top:5px">
                                        <asp:Button ID="AceptarButton" runat="server" Text="Aceptar" OnClick="AceptarButton_Click" TabIndex="4" />
                                    </td>
                                    <td align="left" style="padding-top:5px; padding-left:5px">
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" PostBackUrl="~/Inicio.aspx" CausesValidation="false" TabIndex="5"> </asp:Button>
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top:10px">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"/>
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
