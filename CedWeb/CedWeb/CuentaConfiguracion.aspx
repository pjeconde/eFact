<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaConfiguracion.aspx.cs" Inherits="CedWeb.CuentaConfiguracion" MaintainScrollPositionOnPostback="true" %>

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
                                        <asp:Label ID="Label5" runat="server" Text="Configuración de cuenta " SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electrónica"/>
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
                            <asp:Label ID="Label2" runat="server" Text="Disponer de una cuenta eFact, le permitirá personalizar su perfil de usuario.   Esto le ahorrará trabajo, en el ingreso de facturas electrónicas, y disminuirá el riesgo de equivocarse en la carga de datos repetitivos."></asp:Label>
                            <table id="Table1" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-right:5px; padding-top:20px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" SetFocusOnError="True"
                                            ControlToValidate="NombreTextBox" ErrorMessage="Nombre y Apellido"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label7" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="NombreTextBox" ErrorMessage="Nombre y Apellido">
                                            <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre y Apellido" ></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:20px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" Width="360px" TabIndex="1" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" SetFocusOnError="True"
                                            ControlToValidate="TelefonoTextBox" ErrorMessage="Teléfono"
                                            ValidationExpression="[0-9\-]*">
                                            <asp:Label ID="Label9" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="TelefonoTextBox" ErrorMessage="Teléfono">
                                            <asp:Label ID="Label10" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="TelefonoLabel" runat="server" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="TelefonoTextBox" runat="server" Width="360px" TabIndex="2" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" SetFocusOnError="True"
                                            ControlToValidate="EmailTextBox" ErrorMessage="Email"
                                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="EmailTextBox" ErrorMessage="Email">
                                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" Width="360px" ReadOnly="true" MaxLength="128"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" SetFocusOnError="True"
                                            ControlToValidate="EmailTextBox" ErrorMessage="Email para SMSs"
                                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label13" runat="server" Text="Email para SMSs"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="EmailSMSTextBox" runat="server" Width="360px" MaxLength="128"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" SetFocusOnError="True"
                                            ControlToValidate="UltimoNroLoteTextBox" ErrorMessage="Último n° de Lote reservado"
                                            ValidationExpression="[0-9]{1,14}">
                                            <asp:Label ID="Label49" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="UltimoNroLoteTextBox" ErrorMessage="Último n° de Lote reservado">
                                            <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label4" runat="server" Text="Último n° de Lote reservado"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="UltimoNroLoteTextBox" runat="server" Width="100px" TabIndex="3" MaxLength="14"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">
                                        (el sistema administrará este número en forma automática.
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">
                                        Modifiquelo sólo en caso de resultar imprescindible.
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">
                                        Si tiene dudas, póngase en contacto con
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Contacto.aspx" SkinID="LinkMedianoClaro">Cedeira</asp:HyperLink>
                                        )
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="PaginaDefaultDropDownList" ErrorMessage="Página de inicio">
                                            <asp:Label ID="Label26" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label25" runat="server" Text="Página de inicio"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:DropDownList ID="PaginaDefaultDropDownList" Width="360px" runat="server" TabIndex="4"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="padding-top:10px">
                                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" Width="100px" OnClick="GuardarButton_Click" TabIndex="4">
                                        </asp:Button>
                                    </td>
                                    <td align="right" style="padding-top:10px">
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" Width="100px" PostBackUrl="~/Configuracion.aspx" CausesValidation="false" TabIndex="5">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2" align="center" style="padding-bottom:30px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"/>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width: 30px">
            </td>
        </tr>
    </table>
</asp:Content>