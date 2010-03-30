<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CedeiraAJAX.Vendedor.Default" %>

<%@ Register Src="~/DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl"
	TagPrefix="uc1" %>
	
<asp:Content ID="VendedorContent" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado" runat="server">
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
										<asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico">
										</asp:Image>
									</td>
									<td style="height: 20px;">
										<asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Configuración de datos del Vendedor"></asp:Label>
									</td>
								</tr>
								<tr>
									<td align="left" colspan="2" style="padding-left: 20px; padding-top: 10px">
										<asp:Label ID="Label2" runat="server" Text="Configure los datos del Vendedor para ahorrar tiempo al momento de ingresar las facturas."></asp:Label>
									</td>
								</tr>
							</table>
							<!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
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
										<asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="1" Width="400px"></asp:TextBox>
									</td>
									<td align="center" rowspan="3" style="padding-left: 10px; padding-top: 10px" valign="top">
										<asp:Button ID="BackupButton" runat="server" BackColor="peachpuff" BorderColor="brown"
											BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" ForeColor="brown" Height="50px"
											OnClick="BackupButton_Click" Text="Descargar" ToolTip="Exclusivo SERVICIO PREMIUM"
											Width="100px" />
										<br />
										<asp:Label ID="BackupLabel" runat="server" Font-Size="X-Small" ForeColor="brown"
											Text="(copia de seguridad)" ToolTip="Exclusivo SERVICIO PREMIUM"></asp:Label>
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
													<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CodPostTextBox"
														ErrorMessage="Codigo Postal" SetFocusOnError="True">
														<asp:Label ID="Label38" runat="server" SkinID="IndicadorValidacion"></asp:Label>
													</asp:RequiredFieldValidator>
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
										<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="NombreContactoTextBox"
											ErrorMessage="Nombre Contacto" SetFocusOnError="True">
											<asp:Label ID="Label40" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RequiredFieldValidator>
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
										<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="EmailContactoTextBox"
											ErrorMessage="Email Contacto" SetFocusOnError="True">
											<asp:Label ID="Label42" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RequiredFieldValidator>
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
										<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TelefonoContactoTextBox"
											ErrorMessage="Teléfono Contacto" SetFocusOnError="True">
											<asp:Label ID="Label44" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RequiredFieldValidator>
										<asp:Label ID="Label10" runat="server" Text="Teléfono Contacto"></asp:Label>
									</td>
									<td align="left" style="padding-top: 3px">
										<asp:TextBox ID="TelefonoContactoTextBox" runat="server" MaxLength="50" TabIndex="14"
											Width="400px"></asp:TextBox>
									</td>
								</tr>
								<!-- CUIT y CondIVA -->
								<tr>
									<td align="right" style="padding-right: 5px; padding-top: 3px">
										<asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
											ControlToValidate="CUITTextBox" ErrorMessage="CUIT" SetFocusOnError="True" ValidationExpression="[0-9]{11}">
											<asp:Label ID="Label45" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RegularExpressionValidator>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="CUITTextBox"
											ErrorMessage="CUIT" SetFocusOnError="True">
											<asp:Label ID="Label46" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RequiredFieldValidator>
										<asp:Label ID="Label19" runat="server" Text="CUIT"></asp:Label>
									</td>
									<td align="left">
										<table border="0" cellpadding="0" cellspacing="0">
											<tr>
												<td style="padding-top: 3px">
													<asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="15" ToolTip="Debe ingresar sólo números."
														Width="80px"></asp:TextBox>
												</td>
												<td align="right" style="padding-left: 10px; padding-right: 5px; padding-top: 3px">
													<asp:Label ID="Label11" runat="server" Text="Cond.IVA"></asp:Label>
												</td>
												<td align="left" style="padding-top: 3px">
													<asp:DropDownList ID="CondIVADropDownList" runat="server" TabIndex="16" Width="255px">
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
										<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="NroIngBrutosTextBox"
											ErrorMessage="Nro.Ing.Brutos" SetFocusOnError="True">
											<asp:Label ID="Label48" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RequiredFieldValidator>
										<asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
									</td>
									<td align="left">
										<table border="0" cellpadding="0" cellspacing="0">
											<tr>
												<td style="padding-top: 3px">
													<asp:TextBox ID="NroIngBrutosTextBox" runat="server" MaxLength="13" TabIndex="17"
														ToolTip="Ingresar con el siguiente formato: 9999999-99" Width="80px"></asp:TextBox>
												</td>
												<td align="right" style="padding-left: 10px; padding-right: 5px; padding-top: 3px">
													<asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
												</td>
												<td align="left" style="padding-top: 3px">
													<asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" TabIndex="18" Width="216px">
													</asp:DropDownList>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<!-- GLN -->
								<tr>
									<td align="right" style="padding-right: 5px; padding-top: 3px">
										<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
											ControlToValidate="GLNTextBox" ErrorMessage="GLN" SetFocusOnError="True" ValidationExpression="[0-9]{13}">
											<asp:Label ID="Label49" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RegularExpressionValidator>
										<asp:Label ID="Label7" runat="server" Text="GLN"></asp:Label>
									</td>
									<td rowspan="4">
										<table border="0" cellpadding="0" cellspacing="0">
											<tr>
												<td align="left" style="padding-top: 3px">
													<asp:TextBox ID="GLNTextBox" runat="server" MaxLength="13" TabIndex="19" ToolTip="(opcional) Código estándar para identificar locaciones o empresas (Global Location Number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."
														Width="100px"></asp:TextBox>
												</td>
												<td rowspan="4" style="padding-left: 84px">
													<asp:Panel ID="Panel1" runat="server" BackColor="cornsilk" BorderColor="peachpuff"
														BorderStyle="Solid" BorderWidth="1">
														<table border="0" cellpadding="0" cellspacing="0" style="padding-top: 3px; padding-bottom: 3px;
															padding-left: 5px; padding-right: 5px">
															<tr>
																<td align="center" style="padding-right: 5px">
																	BONO FISCAL
																</td>
																<td align="right" rowspan="3">
																	<asp:ListBox ID="PuntoDeVentaListBox" runat="server" Height="75px" SelectionMode="Single"
																		Width="56px"></asp:ListBox>
																</td>
																<td align="center" style="padding-left: 5px">
																	<asp:TextBox ID="NuevoPuntoDeVentaTextBox" runat="server" Width="32px"></asp:TextBox>
																</td>
															</tr>
															<tr>
																<td align="center" rowspan="2" style="padding-right: 5px" valign="middle">
																	punto(s)<br />
																	de venta<br />
																	habilitado(s)
																</td>
																<td align="left" style="padding-top: 3px; padding-left: 5px">
																	<asp:Button ID="AgregarPuntoDeVentaButtonButton" runat="server" CausesValidation="false"
																		OnClick="AgregarPuntoDeVentaButton_Click" Text="Agregar" ToolTip="Ingrese arriba el número de punto de venta que desea agregar"
																		Width="60px" />
																</td>
															</tr>
															<tr>
																<td align="left" style="padding-top: 3px; padding-left: 5px">
																	<asp:Button ID="QuitarPuntoDeVentaButton" runat="server" CausesValidation="false"
																		Enabled="false" OnClick="QuitarPuntoDeVentaButton_Click" Text="Quitar" ToolTip="Seleccione el punto de venta que desea quitar"
																		Width="60px" />
																</td>
															</tr>
														</table>
													</asp:Panel>
												</td>
											</tr>
											<tr>
												<td align="left" style="padding-top: 3px">
													<asp:TextBox ID="CodigoInternoTextBox" runat="server" MaxLength="20" TabIndex="20"
														ToolTip="(opcional) Código utilizado para identificar al vendedor dentro de la empresa / organización. (ej.: código de Cliente, Proveedor, etc.)"
														Width="100px"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td align="left">
													<uc1:DatePickerWebUserControl ID="FechaInicioActividadesDatePickerWebUserControl"
														runat="server" TabIndex="21" TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
												</td>
											</tr>
											<tr>
												<td align="left" style="padding-left: 6px">
													<asp:Label ID="Label53" runat="server" Text="AAAAMMDD"></asp:Label>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<!-- CodigoInterno -->
								<tr>
									<td align="right" style="padding-right: 5px; padding-top: 3px">
										<asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
											ControlToValidate="CodigoInternoTextBox" ErrorMessage="Codigo interno" SetFocusOnError="True"
											ValidationExpression="[A-Za-z\- ,.0-9]*">
											<asp:Label ID="Label52" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RegularExpressionValidator>
										<asp:Label ID="Label21" runat="server" Text="Código interno"></asp:Label>
									</td>
								</tr>
								<!-- FechaInicioActividades -->
								<tr>
									<td align="right" style="padding-right: 5px; padding-top: 9px">
										<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="FechaInicioActividadesDatePickerWebUserControl:txt_Date"
											ErrorMessage="Fecha de inicio de actividades" SetFocusOnError="True">
											<asp:Label ID="Label51" runat="server" SkinID="IndicadorValidacion"></asp:Label>
										</asp:RequiredFieldValidator>
										<asp:Label ID="Label22" runat="server" Text="Fecha de inicio de actividades"></asp:Label>
									</td>
								</tr>
								<tr>
									<td align="right" style="padding-right: 5px; padding-top: 5px">
										ingresar año, mes, día:
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
													<asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" TabIndex="22"
														Text="Guardar" Width="100px" />
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
							<asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary">
							</asp:ValidationSummary>
						</td>
					</tr>
				</table>
			</td>
			<td style="width: 30px" valign="top">
			</td>
		</tr>
	</table>
</asp:Content>
