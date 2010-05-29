<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="CedeiraAJAX.Comprador.Modificar" %>

<%@ Register Src="~/DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl" TagPrefix="uc1" %>
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
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Modificación de datos de Comprador"></asp:Label>
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
                        <td align="center" colspan="2">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <!-- Razon Social -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 10px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="RazonSocialTextBox"
                                            ErrorMessage="Razon Social" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RazonSocialTextBox"
                                            ErrorMessage="Razon Social" SetFocusOnError="True">
                                            <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label1" runat="server" Text="Razón Social"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" ReadOnly="true"
                                            TabIndex="1" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Calle, Nro, Piso y Depto -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="CalleTextBox"
                                            ErrorMessage="Calle" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label25" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CalleTextBox"
                                            ErrorMessage="Calle" SetFocusOnError="True">
                                            <asp:Label ID="Label26" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label3" runat="server" Text="Calle"></asp:Label>
                                    </td>
                                    <td style="padding-top: 3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="CalleTextBox" runat="server" MaxLength="30" TabIndex="2" Width="150px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 5px;">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="NroTextBox"
                                                        ErrorMessage="Nro" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label27" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="NroTextBox"
                                                        ErrorMessage="Nro" SetFocusOnError="True">
                                                        <asp:Label ID="Label28" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label12" runat="server" Text="Nro"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-left: 5px;">
                                                    <asp:TextBox ID="NroTextBox" runat="server" MaxLength="6" TabIndex="3" Width="40px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 5px">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="PisoTextBox"
                                                        ErrorMessage="Piso" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label29" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label13" runat="server" Text="Piso"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-left: 5px">
                                                    <asp:TextBox ID="PisoTextBox" runat="server" MaxLength="5" TabIndex="4" Width="25px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 5px">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="DeptoTextBox"
                                                        ErrorMessage="Depto" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label31" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label14" runat="server" Text="Depto"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-left: 5px">
                                                    <asp:TextBox ID="DeptoTextBox" runat="server" MaxLength="5" TabIndex="5" Width="25px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Sector, Torre y Manzana -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="SectorTextBox"
                                            ErrorMessage="Sector" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label32" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label15" runat="server" Text="Sector"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="SectorTextBox" runat="server" MaxLength="5" TabIndex="6" Width="120px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 40px">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TorreTextBox"
                                                        ErrorMessage="Torre" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label33" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label16" runat="server" Text="Torre"></asp:Label>
                                                </td>
                                                <td style="padding-left: 5px">
                                                    <asp:TextBox ID="TorreTextBox" runat="server" MaxLength="5" TabIndex="7" Width="55px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 60px">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="ManzanaTextBox"
                                                        ErrorMessage="Manzana" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label34" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label17" runat="server" Text="Manzana"></asp:Label>
                                                </td>
                                                <td style="padding-left: 5px">
                                                    <asp:TextBox ID="ManzanaTextBox" runat="server" MaxLength="5" TabIndex="8" Width="67px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Localidad -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="LocalidadTextBox"
                                            ErrorMessage="Localidad" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label35" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="LocalidadTextBox"
                                            ErrorMessage="Localidad" SetFocusOnError="True">
                                            <asp:Label ID="Label36" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="LocalidadTextBox" runat="server" MaxLength="25" TabIndex="9" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Provincia y Código postal -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px; height: 25px;">
                                        <asp:Label ID="Label5" runat="server" Text="Provincia"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 3px">
                                                    <asp:DropDownList ID="ProvinciaDropDownList" runat="server" TabIndex="10" Width="183px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="padding-left: 14px; padding-right: 5px; padding-top: 3px">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                        ControlToValidate="CodPostTextBox" ErrorMessage="Codigo Postal" SetFocusOnError="True"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label37" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label6" runat="server" Text="Código Postal"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:TextBox ID="CodPostTextBox" runat="server" MaxLength="8" TabIndex="11" Width="80px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Nombre contacto -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                            ControlToValidate="NombreContactoTextBox" ErrorMessage="Nombre Contacto" SetFocusOnError="True"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label39" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label8" runat="server" Text="Nombre Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="NombreContactoTextBox" runat="server" MaxLength="25" TabIndex="12"
                                            Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Mail Contacto -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                            ControlToValidate="EmailContactoTextBox" ErrorMessage="Email Contacto" SetFocusOnError="True"
                                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label41" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label9" runat="server" Text="Email Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="EmailContactoTextBox" runat="server" MaxLength="60" TabIndex="13"
                                            ToolTip="Muy importante! Todos los archivos XML serán enviados a esta casilla de correo. Verifique su correcto ingreso."
                                            Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Teléfono contacto -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                            ControlToValidate="TelefonoContactoTextBox" ErrorMessage="Teléfono Contacto"
                                            SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label43" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label10" runat="server" Text="Teléfono Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="TelefonoContactoTextBox" runat="server" MaxLength="50" TabIndex="14"
                                            Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Comprador del extranjero -->
                                <tr>
                                    <td align="right" style="padding-right:5px; padding-top:3px">
                                        <asp:Label ID="Label19" runat="server" Text="Comprador del extranjero"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 3px">
                                                    <asp:CheckBox ID="CompradorDelExtranjeroCheckBox" runat="server" OnCheckedChanged="CompradorDelExtranjeroCheckBox_CheckedChanged" AutoPostBack="true"  />
                                                </td>
                                                <td style="padding-left:5px; padding-top: 3px">
                                                    <asp:Label ID="DestinosCuitLabel" runat="server" Text="Pais" Visible="false"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px; padding-top: 3px">
                                                    <asp:DropDownList ID="DestinosCuitDropDownList" runat="server" TabIndex="16" Width="351px" Visible="false">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Documento: Tipo y Nro -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px; height: 25px;">
                                        <asp:Label ID="Label30" runat="server" Text="Documento: Tipo"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 3px">
                                                    <asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="15" Width="183px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="padding-left: 14px; padding-right: 5px; padding-top: 3px">
                                                    <asp:Label ID="NroDocLabel" runat="server" Text="Nro."></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="16" ToolTip="Debe ingresar sólo números."
                                                        Width="80px" AutoPostBack="true" OnTextChanged="NroDocTextBox_TextChanged"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- CondIVA -->
                                <tr>
                                    <td style="padding-top: 3px">
                                    </td>
                                    <td align="right">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" style="padding-left: 10px; padding-right: 5px; padding-top: 3px">
                                                    <asp:Label ID="Label11" runat="server" Text="Cond.IVA"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:DropDownList ID="CondIVADropDownList" runat="server" TabIndex="17" Width="255px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- NroIngBrutos y CondIngBrutos -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                            ControlToValidate="NroIngBrutosTextBox" ErrorMessage="Nro.Ing.Brutos" SetFocusOnError="True"
                                            ValidationExpression="[0-9]{7}-[0-9]{2}|[0-9]{2}-[0-9]{8}-[0-9]{1}|[0-9]{3}-[0-9]{6}-[0-9]{1}">
                                            <asp:Label ID="Label47" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 3px">
                                                    <asp:TextBox ID="NroIngBrutosTextBox" runat="server" MaxLength="13" TabIndex="18"
                                                        ToolTip="Ingresar con el siguiente formato: 9999999-99" Width="80px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 10px; padding-right: 5px; padding-top: 3px">
                                                    <asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" TabIndex="19" Width="216px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- GLN y CodigoInterno-->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                            ControlToValidate="GLNTextBox" ErrorMessage="GLN" SetFocusOnError="True" ValidationExpression="[0-9]{13}">
                                            <asp:Label ID="Label49" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label7" runat="server" Text="GLN"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 3px">
                                                    <asp:TextBox ID="GLNTextBox" runat="server" MaxLength="13" TabIndex="20" ToolTip="(opcional) Código estándar para identificar locaciones o empresas (Global Location Number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."
                                                        Width="100px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 70px; padding-right: 5px; padding-top: 3px">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                        ControlToValidate="CodigoInternoTextBox" ErrorMessage="Codigo interno" SetFocusOnError="True"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label52" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label21" runat="server" Text="Código interno"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:TextBox ID="CodigoInternoTextBox" runat="server" MaxLength="20" TabIndex="21"
                                                        ToolTip="(opcional) Código utilizado para identificar al comprador dentro de la empresa / organización. (ej.: código de Cliente, Proveedor, etc.)"
                                                        Width="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- FechaInicioActividades -->
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" style="padding-top: 3px; width: 259px">
                                                    <asp:Label ID="Label22" runat="server" Text="Fecha de inicio de actividades (AAAAMMDD)"></asp:Label>
                                                </td>
                                                <td align="right" style="padding-left: 5px; padding-top: 3px">
                                                    <uc1:DatePickerWebUserControl ID="FechaInicioActividadesDatePickerWebUserControl"
                                                        runat="server" TabIndex="21" TextCssClass="DatePickerFecha" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Botones -->
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="padding-top: 10px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left" style="height: 24px">
                                                    <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="22"
                                                        Text="Modificar" Width="100px" />
                                                </td>
                                                <td align="right" style="width: 100%; height: 24px;">
                                                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" OnClick="CancelarButton_Click"
                                                        TabIndex="23" Text="Cancelar" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <!-- Mensaje -->
                    <tr>
                        <td align="center" colspan="2" style="padding-bottom: 30px; padding-top: 10px">
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
