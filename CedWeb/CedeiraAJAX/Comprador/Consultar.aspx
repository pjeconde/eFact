<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="CedeiraAJAX.Comprador.Consultar" %>
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
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Consulta de datos de Comprador"></asp:Label>
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
                                        <asp:Label ID="Label3" runat="server" Text="Calle"></asp:Label>
                                    </td>
                                    <td style="padding-top: 3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="CalleTextBox" runat="server" MaxLength="30" ReadOnly="true" TabIndex="2"
                                                        Width="150px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 5px;">
                                                    <asp:Label ID="Label12" runat="server" Text="Nro"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-left: 5px;">
                                                    <asp:TextBox ID="NroTextBox" runat="server" MaxLength="6" ReadOnly="true" TabIndex="3"
                                                        Width="40px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 5px">
                                                    <asp:Label ID="Label13" runat="server" Text="Piso"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-left: 5px">
                                                    <asp:TextBox ID="PisoTextBox" runat="server" MaxLength="5" ReadOnly="true" TabIndex="4"
                                                        Width="25px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 5px">
                                                    <asp:Label ID="Label14" runat="server" Text="Depto"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-left: 5px">
                                                    <asp:TextBox ID="DeptoTextBox" runat="server" MaxLength="5" ReadOnly="true" TabIndex="5"
                                                        Width="25px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Sector, Torre y Manzana -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="Label15" runat="server" Text="Sector"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="SectorTextBox" runat="server" MaxLength="5" ReadOnly="true" TabIndex="6"
                                                        Width="120px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 40px">
                                                    <asp:Label ID="Label16" runat="server" Text="Torre"></asp:Label>
                                                </td>
                                                <td style="padding-left: 5px">
                                                    <asp:TextBox ID="TorreTextBox" runat="server" MaxLength="5" ReadOnly="true" TabIndex="7"
                                                        Width="55px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="width: 60px">
                                                    <asp:Label ID="Label17" runat="server" Text="Manzana"></asp:Label>
                                                </td>
                                                <td style="padding-left: 5px">
                                                    <asp:TextBox ID="ManzanaTextBox" runat="server" MaxLength="5" ReadOnly="true" TabIndex="8"
                                                        Width="67px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Localidad -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="LocalidadTextBox" runat="server" MaxLength="25" ReadOnly="true"
                                            TabIndex="9" Width="400px"></asp:TextBox>
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
                                                    <asp:DropDownList ID="ProvinciaDropDownList" runat="server" Enabled="false" TabIndex="10"
                                                        Width="183px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="padding-left: 14px; padding-right: 5px; padding-top: 3px">
                                                    <asp:Label ID="Label6" runat="server" Text="Código Postal"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:TextBox ID="CodPostTextBox" runat="server" MaxLength="8" ReadOnly="true" TabIndex="11"
                                                        Width="80px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Nombre contacto -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="Label8" runat="server" Text="Nombre Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="NombreContactoTextBox" runat="server" MaxLength="25" ReadOnly="true"
                                            TabIndex="12" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Mail Contacto -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="Label9" runat="server" Text="Email Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="EmailContactoTextBox" runat="server" MaxLength="60" ReadOnly="true"
                                            TabIndex="13" ToolTip="Muy importante! Todos los archivos XML serán enviados a esta casilla de correo. Verifique su correcto ingreso."
                                            Width="400px"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Teléfono contacto -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="Label10" runat="server" Text="Teléfono Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top: 3px">
                                        <asp:TextBox ID="TelefonoContactoTextBox" runat="server" MaxLength="50" ReadOnly="true"
                                            TabIndex="14" Width="400px"></asp:TextBox>
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
                                                    <asp:CheckBox ID="CompradorDelExtranjeroCheckBox" runat="server" Enabled="false"/>
                                                </td>
                                                <td style="padding-left:5px; padding-top: 3px">
                                                    <asp:Label ID="DestinosCuitLabel" runat="server" Text="Pais" Visible="false"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px; padding-top: 3px">
                                                    <asp:DropDownList ID="DestinosCuitDropDownList" runat="server" TabIndex="16" Width="351px" Visible="false" Enabled="false">
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
                                                    <asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="15" Width="183px" Enabled="false">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" style="padding-left: 14px; padding-right: 5px; padding-top: 3px">
                                                    <asp:Label ID="NroDocLabel" runat="server" Text="Nro."></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="16" ReadOnly="true"
                                                        Width="80px"></asp:TextBox>
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
                                                    <asp:DropDownList ID="CondIVADropDownList" runat="server" Enabled="false" TabIndex="17"
                                                        Width="255px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- NroIngBrutos y CondIngBrutos -->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 3px">
                                                    <asp:TextBox ID="NroIngBrutosTextBox" runat="server" MaxLength="13" ReadOnly="true"
                                                        TabIndex="18" ToolTip="Ingresar con el siguiente formato: 9999999-99" Width="80px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 10px; padding-right: 5px; padding-top: 3px">
                                                    <asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" Enabled="false" TabIndex="19"
                                                        Width="216px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- GLN y CodigoInterno-->
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 3px">
                                        <asp:Label ID="Label7" runat="server" Text="GLN"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top: 3px">
                                                    <asp:TextBox ID="GLNTextBox" runat="server" MaxLength="13" ReadOnly="true" TabIndex="20"
                                                        ToolTip="(opcional) Código estándar para identificar locaciones o empresas (Global Location Number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."
                                                        Width="100px"></asp:TextBox>
                                                </td>
                                                <td align="right" style="padding-left: 70px; padding-right: 5px; padding-top: 3px">
                                                    <asp:Label ID="Label21" runat="server" Text="Código interno"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top: 3px">
                                                    <asp:TextBox ID="CodigoInternoTextBox" runat="server" MaxLength="20" ReadOnly="true"
                                                        TabIndex="21" ToolTip="(opcional) Código utilizado para identificar al comprador dentro de la empresa / organización. (ej.: código de Cliente, Proveedor, etc.)"
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
                                                        runat="server" TabIndex="21" TextCssClass="DatePickerFecha" ReadOnly="true" />
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
                                                <td align="right" colspan="2" style="width: 100%; height: 24px;">
                                                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" OnClick="CancelarButton_Click"
                                                        TabIndex="23" Text="Salir" Width="100px" />
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
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
