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
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
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
                                        <asp:Label ID="Label1" runat="server" Text="Razon Social"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:10px">
                                        <asp:TextBox ID="RazonSocialTextBox" runat="server" Width="360px" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>

                                <!-- Datos del Vendedor: Calle, Nro, Piso y Depto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label3" runat="server" Text="Calle"></asp:Label>
                                    </td>
                                    <td style="padding-top:3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:TextBox ID="CalleTextBox" runat="server" Width="150px" TabIndex="1"></asp:TextBox>
                                                </td>                                            
                                                <td style="padding-left:5px;" align="right">
                                                    <asp:Label ID="Label12" runat="server" Text="Nro"></asp:Label>
                                                </td>                                            
                                                <td style="padding-left:5px;" align="left">
                                                    <asp:TextBox ID="NroTextBox" runat="server" Width="40px" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:5px" align="right">
                                                    <asp:Label ID="Label13" runat="server" Text="Piso"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px" align="left">
                                                    <asp:TextBox ID="PisoTextBox" runat="server" Width="25px" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:5px" align="right">
                                                    <asp:Label ID="Label14" runat="server" Text="Depto"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px" align="left">
                                                    <asp:TextBox ID="DeptoTextBox" runat="server" Width="25px" TabIndex="1"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Sector, Torre y Manzana -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label15" runat="server" Text="Sector"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="SectorTextBox" runat="server" Width="120px" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="width:40px" align="right">
                                                    <asp:Label ID="Label16" runat="server" Text="Torre"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px">
                                                    <asp:TextBox ID="TorreTextBox" runat="server" Width="55px" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="width:60px" align="right">
                                                    <asp:Label ID="Label17" runat="server" Text="Manzana"></asp:Label>
                                                </td>
                                                <td style="padding-left:5px">
                                                    <asp:TextBox ID="ManzanaTextBox" runat="server" Width="67px" TabIndex="1"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Localidad -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="LocalidadTextBox" runat="server" Width="360px" TabIndex="1"></asp:TextBox>
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
                                                    <asp:DropDownList ID="ProvinciaDropDownList" Width="183px" runat="server"></asp:DropDownList>
                                                </td>
                                                <td style="padding-left:14px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:Label ID="Label6" runat="server" Text="Codigo Postal"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:TextBox ID="CodPostTextBox" runat="server" Width="80px" TabIndex="1"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Nombre contacto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label8" runat="server" Text="Nombre Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="NombreContactoTextBox" runat="server" Width="360px" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Mail Contacto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label9" runat="server" Text="Email Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="EmailContactoTextBox" runat="server" Width="360px" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: Teléfono contacto -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label10" runat="server" Text="Teléfono Contacto"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:3px">
                                        <asp:TextBox ID="TelefonoContactoTextBox" runat="server" Width="360px" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: CUIT y CondIVA -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label19" runat="server" Text="CUIT"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top:3px">
                                                    <asp:TextBox ID="CUITTextBox" runat="server" Width="80px" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:10px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:Label ID="Label11" runat="server" Text="Cond.IVA"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:DropDownList ID="CondIVADropDownList" runat="server" Width="215px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: NroIngBrutos y CondIngBrutos -->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top:3px">                                    
                                                    <asp:TextBox ID="NroIngBrutosTextBox" runat="server" Width="80px" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:10px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" Width="176px"></asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Datos del Vendedor: GLN y CodigoInterno-->
                                <tr>
                                    <td style="padding-right:5px; padding-top:3px" align="right">
                                        <asp:Label ID="Label7" runat="server" Text="GLN"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-top:3px">    
                                                    <asp:TextBox ID="GLNTextBox" runat="server" Width="100px" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="padding-left:70px; padding-right:5px; padding-top:3px" align="right">
                                                    <asp:Label ID="Label21" runat="server" Text="Codigo interno"></asp:Label>
                                                </td>
                                                <td align="left" style="padding-top:3px">
                                                    <asp:TextBox ID="CodigoInternoTextBox" runat="server" Width="100px" TabIndex="1"></asp:TextBox>
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
                                                <td align="right" style="padding-top:3px">
                                                    <asp:Label ID="Label22" runat="server" Text="Fecha de inicio de actividades" Width="259px"></asp:Label>
                                                </td>
                                                <td align="right" style="padding-left:5px; padding-top:3px">
                                                    <uc1:DatePickerWebUserControl ID="FechaInicioActividadesDatePickerWebUserControl" runat="server" TextCssClass="DatePickerFecha" />
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
                                                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" Width="100px" OnClick="GuardarButton_Click" TabIndex="10">
                                                    </asp:Button>
                                                </td>
                                                <td align="right" style="width:100%">
                                                    <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" Width="100px" PostBackUrl="~/FacturaElectronica.aspx">
                                                    </asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Mensaje -->
                                <tr>
                                    <td colspan="2" align="center" style="padding-bottom:30px; padding-top:10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
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
