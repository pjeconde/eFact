<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Vendedor.aspx.cs" Inherits="CedWeb.Vendedor" MaintainScrollPositionOnPostback="true" %>
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
                                        <asp:Label ID="TituloLabel" runat="server" Text="Configuración de Información del Vendedor" Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left:20px; padding-top:10px" align="left" colspan="2">
                                        <asp:Label ID="Label2" runat="server" Text="Configure los datos del Vendedor para ahorrar tiempo al momento de ingresar las facturas."></asp:Label>
                                    </td>
                                </tr>
                            </table>                        
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr><td style="height:10px"></td></tr>
                    <tr>
                        <td align="center" colspan="2">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <!-- Datos del Vendedor: Razon Social -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:10px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" SetFocusOnError="True"
                                            ControlToValidate="RazonSocialTextBox" ErrorMessage="Razon Social"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="RazonSocialTextBox" ErrorMessage="Razon Social">
                                            <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label1" runat="server" Text="Razón Social"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:10px">
                                        <asp:TextBox ID="RazonSocialTextBox" runat="server" Width="400px" TabIndex="1" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Calle, Nro, Piso y Depto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" SetFocusOnError="True"
                                            ControlToValidate="CalleTextBox" ErrorMessage="Calle"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label25" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="CalleTextBox" ErrorMessage="Calle">
                                            <asp:Label ID="Label26" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label3" runat="server" Text="Calle"></asp:Label>
                                    </td>
                                    <td style="padding-top:3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="CalleTextBox" runat="server" Width="150px" TabIndex="2" MaxLength="30"></asp:TextBox>
                                                </td>                                            
                                                <td style="padding-left:5px;" align="right">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" SetFocusOnError="True"
                                                        ControlToValidate="NroTextBox" ErrorMessage="Nro"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label27" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  SetFocusOnError="True"
                                                        ControlToValidate="NroTextBox" ErrorMessage="Nro">
                                                        <asp:Label ID="Label28" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label12" runat="server" Text="Nro"></asp:Label>
                                                </td>                                            
                                                <td style="padding-left:5px;" align="left">
                                                    <asp:TextBox ID="NroTextBox" runat="server" Width="40px" TabIndex="3" MaxLength="6"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:5px" align="right">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" SetFocusOnError="True"
                                                        ControlToValidate="PisoTextBox" ErrorMessage="Piso"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label29" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label13" runat="server" Text="Piso"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px" align="left">
                                                    <asp:TextBox ID="PisoTextBox" runat="server" Width="25px" TabIndex="4" MaxLength="5"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:5px" align="right">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" SetFocusOnError="True"
                                                        ControlToValidate="DeptoTextBox" ErrorMessage="Depto"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label31" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label14" runat="server" Text="Depto"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px" align="left">
                                                    <asp:TextBox ID="DeptoTextBox" runat="server" Width="25px" TabIndex="5" MaxLength="5"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Sector, Torre y Manzana -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" SetFocusOnError="True"
                                            ControlToValidate="SectorTextBox" ErrorMessage="Sector"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label32" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label15" runat="server" Text="Sector"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="SectorTextBox" runat="server" Width="120px" TabIndex="6" MaxLength="5"></asp:TextBox>
                                                </td>
                                                <td style="width:40px" align="right">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" SetFocusOnError="True"
                                                        ControlToValidate="TorreTextBox" ErrorMessage="Torre"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label33" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label16" runat="server" Text="Torre"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px">
                                                    <asp:TextBox ID="TorreTextBox" runat="server" Width="55px" TabIndex="7" MaxLength="5"></asp:TextBox>
                                                </td>
                                                <td style="width:60px" align="right">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" SetFocusOnError="True"
                                                        ControlToValidate="ManzanaTextBox" ErrorMessage="Manzana"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label34" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label17" runat="server" Text="Manzana"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px">
                                                    <asp:TextBox ID="ManzanaTextBox" runat="server" Width="67px" TabIndex="8" MaxLength="5"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Localidad -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" SetFocusOnError="True"
                                            ControlToValidate="LocalidadTextBox" ErrorMessage="Localidad"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label35" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="LocalidadTextBox" ErrorMessage="Localidad">
                                            <asp:Label ID="Label36" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="LocalidadTextBox" runat="server" Width="400px" TabIndex="9" MaxLength="25"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Provincia y Código postal -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px; height: 25px;" align="right">
                                        <asp:Label ID="Label5" runat="server" Text="Provincia"></asp:Label>
                                    </td>
                                    <td align="left" style="height:25px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top:3px">
                                                    <asp:DropDownList ID="ProvinciaDropDownList" Width="183px" runat="server" TabIndex="10"></asp:DropDownList>
                                                </td>
                                                <td style="padding-left:14px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" SetFocusOnError="True"
                                                        ControlToValidate="CodPostTextBox" ErrorMessage="Codigo Postal"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label37" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  SetFocusOnError="True"
                                                        ControlToValidate="CodPostTextBox" ErrorMessage="Codigo Postal">
                                                        <asp:Label ID="Label38" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label6" runat="server" Text="Código Postal"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:TextBox ID="CodPostTextBox" runat="server" Width="80px" TabIndex="11" MaxLength="8"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Nombre contacto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" SetFocusOnError="True"
                                            ControlToValidate="NombreContactoTextBox" ErrorMessage="Nombre Contacto"
                                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label39" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="NombreContactoTextBox" ErrorMessage="Nombre Contacto">
                                            <asp:Label ID="Label40" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label8" runat="server" Text="Nombre Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="NombreContactoTextBox" runat="server" Width="400px" TabIndex="12" MaxLength="25"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Mail Contacto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" SetFocusOnError="True"
                                            ControlToValidate="EmailContactoTextBox" ErrorMessage="Email Contacto"
                                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label41" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="EmailContactoTextBox" ErrorMessage="Email Contacto">
                                            <asp:Label ID="Label42" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label9" runat="server" Text="Email Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="EmailContactoTextBox" runat="server" Width="400px" TabIndex="13" MaxLength="60" ToolTip="Muy importante! Todos los archivos XML serán enviados a esta casilla de correo. Verifique su correcto ingreso."></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Teléfono contacto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" SetFocusOnError="True"
                                        ControlToValidate="TelefonoContactoTextBox" ErrorMessage="Teléfono Contacto"
                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                        <asp:Label ID="Label43" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  SetFocusOnError="True"
                                        ControlToValidate="TelefonoContactoTextBox" ErrorMessage="Teléfono Contacto">
                                        <asp:Label ID="Label44" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                    </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label10" runat="server" Text="Teléfono Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="TelefonoContactoTextBox" runat="server" Width="400px" TabIndex="14" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: CUIT y CondIVA -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" SetFocusOnError="True"
                                            ControlToValidate="CUITTextBox" ErrorMessage="CUIT"
                                            ValidationExpression="[0-9]{11}">
                                            <asp:Label ID="Label45" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="CUITTextBox" ErrorMessage="CUIT">
                                            <asp:Label ID="Label46" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label19" runat="server" Text="CUIT"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top:3px">
                                                    <asp:TextBox ID="CUITTextBox" runat="server" Width="80px" TabIndex="15" MaxLength="11" ToolTip="Debe ingresar sólo números."></asp:TextBox>
                                                </td>
                                                <td style="padding-left:10px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:Label ID="Label11" runat="server" Text="Cond.IVA"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:DropDownList ID="CondIVADropDownList" runat="server" Width="255px" TabIndex="16"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: NroIngBrutos y CondIngBrutos -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" SetFocusOnError="True"
                                            ControlToValidate="NroIngBrutosTextBox" ErrorMessage="Nro.Ing.Brutos"
                                            ValidationExpression="[0-9]{7}-[0-9]{2}|[0-9]{2}-[0-9]{8}-[0-9]{1}|[0-9]{3}-[0-9]{6}-[0-9]{1}">
                                            <asp:Label ID="Label47" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"  SetFocusOnError="True"
                                            ControlToValidate="NroIngBrutosTextBox" ErrorMessage="Nro.Ing.Brutos">
                                            <asp:Label ID="Label48" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top:3px">                                    
                                                    <asp:TextBox ID="NroIngBrutosTextBox" runat="server" Width="80px" TabIndex="17" MaxLength="13" ToolTip="Ingresar con el siguiente formato: 9999999-99"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:10px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" Width="216px" TabIndex="18"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: GLN y CodigoInterno-->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" SetFocusOnError="True"
                                            ControlToValidate="GLNTextBox" ErrorMessage="GLN"
                                            ValidationExpression="[0-9]{13}">
                                            <asp:Label ID="Label49" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label7" runat="server" Text="GLN"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top:3px">    
                                                    <asp:TextBox ID="GLNTextBox" runat="server" Width="100px" TabIndex="19" MaxLength="13" ToolTip="(opcional) Código estándar para identificar locaciones o empresas (Global Location Number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."></asp:TextBox>
                                                </td>
                                                <td style="padding-left:70px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" SetFocusOnError="True"
                                                        ControlToValidate="CodigoInternoTextBox" ErrorMessage="Codigo interno"
                                                        ValidationExpression="[A-Za-z\- ,.0-9]*">
                                                        <asp:Label ID="Label52" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Label ID="Label21" runat="server" Text="Código interno"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:TextBox ID="CodigoInternoTextBox" runat="server" Width="100px" TabIndex="20" MaxLength="20" ToolTip="(opcional) Código utilizado para identificar al vendedor dentro de la empresa / organización. (ej.: código de Cliente, Proveedor, etc.)"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: FechaInicioActividades -->
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" style="padding-top:3px; width:259px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"  SetFocusOnError="True"
                                                        ControlToValidate="FechaInicioActividadesDatePickerWebUserControl:txt_Date" ErrorMessage="Fecha de inicio de actividades">
                                                        <asp:Label ID="Label51" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                                    </asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label22" runat="server" Text="Fecha de inicio de actividades (AAAAMMDD)"></asp:Label>
                                                </td>
                                                <td align="right" style="padding-left:5px; padding-top:3px">
                                                    <uc1:DatePickerWebUserControl ID="FechaInicioActividadesDatePickerWebUserControl" runat="server" TextCssClass="DatePickerFecha" TabIndex="21" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Botones -->
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="padding-top:10px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" Width="100px" OnClick="GuardarButton_Click" TabIndex="22">
                                                    </asp:Button>
                                                </td>
                                                <td align="right" style="width:100%">
                                                    <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" Width="100px" PostBackUrl="~/FacturaElectronica.aspx" CausesValidation="false" TabIndex="23">
                                                    </asp:Button>
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
                        <td colspan="2" align="center" style="padding-bottom:30px; padding-top:10px">
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
