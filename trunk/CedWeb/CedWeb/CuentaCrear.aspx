<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CuentaCrear.aspx.cs" Inherits="CedWeb.CuentaCrear" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function ContactoTable_onclick() {

}

// ]]>
</script>

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
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" Text="Creación de cuenta " Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
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
                            <asp:Label ID="Label2" runat="server" Text="Disponer de una cuenta eFact, le permiirá personalizar su perfil de usuario.   Esto le ahorrará trabajo, en el ingreso de facturas electrónicas, y disminuirá el riesgo de equivocarse en la carga de datos repetitivos."></asp:Label>
                            <table id="ContactoTable" border="0" cellpadding="0" cellspacing="0" width="600" onclick="return ContactoTable_onclick()">
                                <tr>
                                    <td colspan="2" style="width:300px; padding-right:5px; padding-top:10px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" SetFocusOnError="True"
                                            ControlToValidate="NombreTextBox" ErrorMessage="Nombre y Apellido"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label7" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="NombreTextBox" ErrorMessage="Nombre y Apellido">
                                            <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre y Apellido"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:10px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" Width="360px" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td style="width:200px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" SetFocusOnError="True"
                                            ControlToValidate="TelefonoTextBox" ErrorMessage="Teléfono"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label9" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="TelefonoTextBox" ErrorMessage="Teléfono">
                                            <asp:Label ID="Label10" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="TelefonoLabel" runat="server" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="TelefonoTextBox" runat="server" Width="360px" TabIndex="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" style="padding-top:3px; padding-right:5px">
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
                                        <asp:TextBox ID="EmailTextBox" runat="server" Width="360px" TabIndex="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" SetFocusOnError="True"
                                            ControlToValidate="IdUsuarioTextBox" ErrorMessage="Id.Usuario"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="IdUsuarioTextBox" ErrorMessage="Id.Usuario">
                                            <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="IdUsuarioLabel" runat="server" Text="Id.Usuario"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="IdUsuarioTextBox" runat="server" Width="100px" TabIndex="4"></asp:TextBox>
                                    </td>
                                    <td colspan="2" align="left" style="padding-left:5px; padding-top:3px" style="width:330px">
                                        <asp:Button ID="ComprobarDisponibilidadButton" runat="server" Text="Comprobar disp." ToolTip="Comprobar la disponibilidad del Id.Usuario ingresado" OnClick="ComprobarDisponibilidadButton_Click" Width="120px" CausesValidation="false"></asp:Button>
                                        <asp:Label ID="ResultadoComprobarDisponibilidadLabel" runat="server" Font-Size="12px" Font-Bold="True" Text="" Width="200px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" SetFocusOnError="True"
                                            ControlToValidate="PasswordTextBox" ErrorMessage="Contraseña"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="PasswordTextBox" ErrorMessage="Contraseña">
                                            <asp:Label ID="Label16" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="PasswordLabel" runat="server" Text="Contraseña"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="PasswordTextBox" runat="server" Width="100px" TextMode="Password" TabIndex="5"></asp:TextBox>
                                    </td>
                                    <td rowspan="2" style="padding-top:3px" align="center" valign="middle">
                                        <asp:Label ID="Label4" runat="server" Text="(si olvida su Contraseña, le preguntaremos la Respuesta a su Pregunta de seguridad)" ForeColor="gray"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" SetFocusOnError="True"
                                            ControlToValidate="ConfirmacionPasswordTextBox" ErrorMessage="Confirmacion de Contraseña"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label17" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="ConfirmacionPasswordTextBox" ErrorMessage="Confirmacion de Contraseña">
                                            <asp:Label ID="Label18" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="ConfirmacionPasswordLabel" runat="server" Text="Confirmacion de Contraseña"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="ConfirmacionPasswordTextBox" runat="server" Width="100px" TextMode="Password" TabIndex="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" SetFocusOnError="True"
                                            ControlToValidate="PreguntaTextBox" ErrorMessage="Pregunta de seguridad"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label19" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="PreguntaTextBox" ErrorMessage="Pregunta de seguridad">
                                            <asp:Label ID="Label20" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="PreguntaLabel" runat="server" Text="Pregunta de seguridad"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:Label ID="Label1" runat="server" Text="¿" Font-Bold="true"></asp:Label>
                                        <asp:TextBox ID="PreguntaTextBox" runat="server" Width="340px" TabIndex="7"></asp:TextBox>
                                        <asp:Label ID="Label6" runat="server" Text="?" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" SetFocusOnError="True"
                                            ControlToValidate="RespuestaTextBox" ErrorMessage="Respuesta"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="RespuestaTextBox" ErrorMessage="Respuesta">
                                            <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="RespuestaTextBox" runat="server" Width="360px" TabIndex="8"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="bottom" style="padding-top:3px; width:150px">
                                        <asp:Label ID="Label3" runat="server" Text="" Width="150px"></asp:Label>
                                        <asp:Image ID="CaptchaImage" runat="server" Height="60px" Width="150px" AlternateText="" />
                                    </td>
                                    <td align="right" style="padding-top:3px; padding-right:5px">
                                        <asp:Label ID="CondicionesLabel" runat="server" Text="Términos y Condiciones del servicio"></asp:Label>
                                    </td>
                                    <td colspan="2" align="left" style="padding-top:3px">
                                        <asp:TextBox ID="CondicionesTextBox" runat="server" Width="360px" Height="100px" TextMode="MultiLine" ReadOnly="true" Font-Size="XX-Small"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center" style="padding-top:3px">
                                        <asp:Button ID="NuevaClaveCaptchaButton" runat="server" Text="Nueva Clave" OnClick="NuevaClaveCaptchaButton_Click" CausesValidation="false">
                                        </asp:Button>
                                    </td>
                                    <td align="right" style="padding-top:3px; padding-right:5px; width:150px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" SetFocusOnError="True"
                                            ControlToValidate="CaptchaTextBox" ErrorMessage="Clave"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="CaptchaTextBox" ErrorMessage="Clave">
                                            <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="ClaveLabel" runat="server" Text="Clave"></asp:Label>
                                    </td>
                                    <td align="left" style="width:80px; padding-top:3px">
                                        <asp:TextBox ID="CaptchaTextBox" runat="server" Width="100px" TabIndex="9"></asp:TextBox>
                                    </td>
                                    <td align="left" style="padding-top:3px; padding-left:5px">
                                        <asp:Label ID="CaseSensitiveLabel" runat="server" Text="(no se distinguen mayúsculas de minúsculas)" ForeColor="gray"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="padding-top:10px" align="right">
                                        <asp:Label ID="CrearCuentaLabel" runat="server" Text="Al hacer clic en el botón 'Crear cuenta', estará aceptando los Términos y Condiciones del servicio."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="left" style="padding-top:10px">
                                        <asp:Button ID="CrearCuentaButton" runat="server" Text="Crear cuenta" Width="100px" OnClick="CrearCuentaButton_Click" TabIndex="10">
                                        </asp:Button>
                                    </td>
                                    <td align="right" style="padding-top:10px">
                                        <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" Width="100px" PostBackUrl="~/Inicio.aspx" CausesValidation="false">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
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