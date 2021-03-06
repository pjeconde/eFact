﻿<%@ Page AutoEventWireup="true" Buffer="true" Codebehind="Lote.aspx.cs" Culture="en-GB"
	Inherits="CedeiraAJAX.Facturacion.Electronica.Lote" Language="C#" MaintainScrollPositionOnPostback="true"
	MasterPageFile="~/CedeiraAJAX.Master" Title="Factura Electrónica Gratis(Interfacturas - AFIP)"
	UICulture="en-GB" EnableEventValidation="false" ValidateRequest="false" %>


<%@ Register Src="Detalle.ascx" TagName="Detalle" TagPrefix="uc4" %>

<%@ Register Src="Extensiones/Comerciales.ascx" TagName="Comerciales" TagPrefix="uc3" %>

<%@ Register Src="Permisos.ascx" TagName="Permisos" TagPrefix="uc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl"
	TagPrefix="uc1" %>
	
<%@ Register Src="~/Facturacion/Electronica/Impuestos.ascx" TagName="ImpuestosGlobales" TagPrefix="uc8" %>

<%@ Register Src="~/Facturacion/Electronica/Descuentos.ascx" TagName="DescuentosGlobales"
	TagPrefix="DescUC" %>
	
<asp:Content ID="XMLContent" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
	<asp:ScriptManager ID="loteScriptManager" runat="server">
	</asp:ScriptManager>
	<table border="0" cellpadding="0" cellspacing="0" class="TextComunSinPosicion" style="width: 800px;
		text-align: left;">
		<tr>
			<td style="height: 10px;" valign="top">
			</td>
		</tr>
		<tr>
			<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
					<tr>
						<td style="width: 9px;">
						</td>
						<td colspan="3"  valign="top">
							<!-- @@@ TITULO DE LA PAGINA @@@-->
							<table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
								<tr>
									<td>
										<table>
											<tr>
												<td valign="middle">
													<asp:Image ID="Image1" runat="server" AlternateText="+" ImageUrl="~/Imagenes/CajaBrownPeru.ico">
													</asp:Image>
												</td>
												<td valign="middle">
													<asp:Label ID="Label2" runat="server" SkinID="TituloPagina" Text="Factura Electrónica">
													</asp:Label>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td align="center" style="width: 782px; vertical-align: middle; text-align: center;"
										valign="top">
										<table border="0" cellpadding="0" cellspacing="0" style="width: 784px">
											<tr>
												<td rowspan="6" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="1" style="height: 1px; background-color: Gray;">
												</td>
												<td rowspan="6" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
											<tr>
												<td colspan="2" style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td class="TextoResaltado" style="text-align: center;">
													UTILIZAR COMPROBANTE PREEXISTENTE
												</td>
											</tr>
											<tr>
												<td>
													<table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
														<tr>
															<td style="padding-top:5px">
																<asp:FileUpload ID="XMLFileUpload" runat="server" Height="25px" ToolTip="Exclusivo SERVICIO PREMIUM">
																</asp:FileUpload>
															</td>
														</tr>
														<tr>
															<td style="padding-top: 5px">
																<asp:Button ID="FileUploadButton" runat="server" BackColor="peachpuff" BorderColor="brown"
																	BorderStyle="Solid" BorderWidth="1px" CausesValidation="false" Font-Bold="true"
																	ForeColor="brown" Height="25px" OnClick="FileUploadButton_Click" Text="Completar datos automáticamente desde archivo xml seleccionado"
																	ToolTip="Exclusivo SERVICIO PREMIUM" />
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td rowspan="6" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="1" style="height: 1px; background-color: Gray;">
												</td>
												<td rowspan="6" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
										</table>
										<br />
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="width: 9px;">
						</td>
						<td align="center" style="width: 782px; vertical-align: middle; text-align: center;"
							valign="top">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td >
										<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
											<tr>
												<td rowspan="3" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="1" style="height: 1px; background-color: Gray;">
												</td>
												<td rowspan="3" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
											<tr>
												<td align="left" valign="top">
													<table border="0" cellpadding="0" cellspacing="0" >
														<tr>
															<td style="width: 370px">
															</td>
															<td class="bgFEAC" style="width: 40px; height: 10px;">
															</td>
															<td style="width: 370px">
															</td>
														</tr>
													</table>
													<!-- TIPO DE COMPROBANTE -->
													<table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
														<tr>
															<td align="center" class="TextoResaltado" style="width: 240px">
																INFORMACIÓN VENDEDOR<br />
																<asp:HyperLink ID="ConfigurarVendedorHyperLink" runat="server" Font-Bold="false"
																	NavigateUrl="~/Vendedor/Default.aspx" SkinID="LinkMedianoClaro">Configurar</asp:HyperLink></td>
															<td style="width: 300px">
																<table border="0" cellpadding="0" cellspacing="0" style="width: 300px">
																	<tr>
																		<td rowspan="2" style="width: 1px; background-color: Gray;">
																		</td>
																		<td colspan="3" style="height: 1px; background-color: Gray;">
																		</td>
																		<td rowspan="2" style="width: 1px; background-color: Gray;">
																		</td>
																	</tr>
																	<tr>
																		<td style="width: 9px;">
																		</td>
																		<td style="width: 280px">
																			<table border="0" cellpadding="0" cellspacing="0" style="background-color: White;">
																				<tr>
																					<td class="TextoLabelFEAVendedor" style="text-align: center; width: 280px">
																						Tipo de comprobante
																					</td>
																				</tr>
																				<tr>
																					<td style="width: 280px">
																						<asp:UpdatePanel ID="Tipo_De_ComprobanteUpdatePanel" runat="server" ChildrenAsTriggers="true"
																							UpdateMode="Conditional">
																							<Triggers>
																								<asp:AsyncPostBackTrigger controlid="Punto_VentaTextBox" />
																							</Triggers>
																							<ContentTemplate>
																								<asp:DropDownList ID="Tipo_De_ComprobanteDropDownList" runat="server" SkinID="DropDownListCompradorGr" OnSelectedIndexChanged="Tipo_De_ComprobanteDropDownList_SelectedIndexChanged" AutoPostBack="true">
																								</asp:DropDownList>
																							</ContentTemplate>
																						</asp:UpdatePanel>
																					</td>
																				</tr>
																				<tr>
																					<td style="height: 5px">
																					</td>
																				</tr>
																			</table>
																		</td>
																		<td style="width: 9px;">
																		</td>
																	</tr>
																	<tr>
																		<td colspan="5" style="height: 1px; background-color: Gray;">
																		</td>
																	</tr>
																</table>
															</td>
															<td align="center" style="width: 240px; color: #A52A2A" valign="middle">
																Comprobante electrónico en
																<asp:UpdatePanel ID="monedaUpdatePanel" runat="server" ChildrenAsTriggers="true"
																	UpdateMode="Conditional">
																	<ContentTemplate>
																		<asp:DropDownList ID="MonedaComprobanteDropDownList" runat="server" AutoPostBack="True"
																			Enabled="false" OnSelectedIndexChanged="MonedaComprobanteDropDownList_SelectedIndexChanged"
																			SkinID="DropDownListPremium">
																		</asp:DropDownList>
																	</ContentTemplate>
																</asp:UpdatePanel>
																<asp:Label ID="MonedaComprobanteExclusivoPremiumLabel" runat="server" Font-Size="X-Small"
																	ForeColor="brown" Text="(exclusivo SERVICIO PREMIUM)"></asp:Label>
																<asp:UpdateProgress ID="monedaUpdateProgress" runat="server" AssociatedUpdatePanelID="monedaUpdatePanel"
																	DisplayAfter="0">
																	<ProgressTemplate>
																		<asp:Image ID="monedaImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
																		</asp:Image>
																	</ProgressTemplate>
																</asp:UpdateProgress>
															</td>
														</tr>
													</table>
													<!-- DATOS DEL VENDEDOR -->
													<table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
														<tr>
															<td style="width: 370px;">
															</td>
															<td class="bgFEAC" rowspan="15" style="width: 40px; background-repeat: repeat-y;">
															</td>
															<td style="width: 370px;">
															</td>
														</tr>
														<tr>
															<td colspan="3" style="height: 10px;">
															</td>
															<td colspan="3">
															</td>
														</tr>
														<!-- Datos del Vendedor: Razon Social / Comprobante -->
														<tr>
															<td>
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Razon_Social_VendedorTextBox"
																				ErrorMessage="razón social" SetFocusOnError="True">* </asp:RequiredFieldValidator>Razón
																			social:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="Razon_Social_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
															<td >
																<asp:UpdatePanel ID="ptoVentaUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
																	<ContentTemplate>
																		<table border="0" cellpadding="0" cellspacing="0" >
																			<tr>
																				<td style="position: relative; border: 0px; width: 40px; padding-top: 5px;">
																					<asp:RegularExpressionValidator ID="PtoVentaRegularExpressionValidator" runat="server"
																						ControlToValidate="Punto_VentaTextBox" ErrorMessage="error de formateo en punto de venta"
																						SetFocusOnError="True" ValidationExpression="[0-9]?[0-9]?[0-9]?[0-9]?">* </asp:RegularExpressionValidator>
																				</td>
																				<td style="position: relative; border: 0px; width: 40px; padding-top: 5px;">
																					<asp:RequiredFieldValidator ID="puntoVentaRequiredFieldValidator" runat="server"
																						ControlToValidate="Punto_VentaTextBox" ErrorMessage="punto de venta" SetFocusOnError="True">* </asp:RequiredFieldValidator>
																				</td>
																				<td class="TextoLabelFEAVendedor">
																					Punto de venta:
																				</td>
																				<td style="position: relative; border: 0px; text-align: right; color: #A52A2A; font-weight: normal;
																					font-size: 12px; font-family: Arial; font-style: normal; width: 50px; padding-top: 5px;">
																					<cc1:FilteredTextBoxExtender ID="PtoVentaFilteredTextExtender" runat="server" TargetControlID="Punto_VentaTextBox" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
																					<asp:TextBox ID="Punto_VentaTextBox" runat="server" AutoPostBack="true" OnTextChanged="Punto_VentaTextBox_TextChanged"
																						SkinID="TextoBoxFEAVendedorDetChCh" ToolTip="Muy importante! Si cambia el punto de venta a un tipo de punto de venta distinto, se eliminarán los datos de la grilla de detalle de artículos/servicios.">
																					</asp:TextBox>
																				</td>
																				<td class="TextoFEASYP_DetCol1">
																					<asp:Label ID="TipoPtoVentaLabel" runat="server" ></asp:Label>
																					<asp:RadioButton ID="Version0RadioButton"  runat="server" Visible="false" GroupName="Version"  Text="V.0" Checked="true" AutoPostBack="true" OnCheckedChanged="Version0RadioButton_CheckedChanged"></asp:RadioButton>
																					<asp:RadioButton ID="Version1RadioButton" runat="server" GroupName="Version" Text="V.1" AutoPostBack="true"
																						Visible="false" OnCheckedChanged="Version1RadioButton_CheckedChanged"></asp:RadioButton>
																				</td>
																				<td style="width:100px">
																					<asp:UpdateProgress ID="ptoVentaUpdateProgress" runat="server" AssociatedUpdatePanelID="ptoVentaUpdatePanel"
																						DisplayAfter="0">
																						<ProgressTemplate>
																							<asp:Image ID="ptoVentaImage" runat="server" Height="18px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
																							</asp:Image>
																						</ProgressTemplate>
																					</asp:UpdateProgress>
																				</td>
																			</tr>
																		</table>
																	</ContentTemplate>
																</asp:UpdatePanel>
															</td>
														</tr>
														<!-- Datos del Vendedor: Calle -->
														<tr>
															<td >
                                                                <asp:UpdatePanel ID="DomicilioCalleVendedorUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td class="TextoLabelFEAVendedor">
                                                                                    Calle:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDet">
                                                                                    <asp:TextBox ID="Domicilio_Calle_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor">
																			<asp:RegularExpressionValidator ID="Numero_comprobanteRegularExpressionValidator"
																				runat="server" ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="error de formateo en número de comprobante"
																				SetFocusOnError="True" ValidationExpression="[0-9]+">* </asp:RegularExpressionValidator>
																			<asp:RequiredFieldValidator ID="Numero_ComprobanteRequiredFieldValidator" runat="server"
																				ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="número de comprobante"
																				SetFocusOnError="True">* </asp:RequiredFieldValidator>Número de comprobante:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="Numero_ComprobanteTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																				ToolTip="Debe ser correlativo al último ingresado por Punto de Venta y Tipo de Comprobante. No es necesario ingresar ceros a la izquierda. Si su factura es p.ej.0002-00000005, puede ingresar 5.">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<!-- Datos del Vendedor: Nro.Calle, Piso y Dpto  / Fecha Emision -->
														<tr>
															<td>
                                                                <asp:UpdatePanel ID="NroPisoUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                    UpdateMode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <!-- 25 + 80 + 40 + 60 + 40 + 80 + 40 + 5 padding = 370px -->
                                                                                <td style="width: 25px;">
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorCh">
                                                                                    Nro.:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDetChCh">
                                                                                    <asp:TextBox ID="Domicilio_Numero_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorChCh">
                                                                                    Piso:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDetChCh">
                                                                                    <asp:TextBox ID="Domicilio_Piso_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorCh">
                                                                                    Depto:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDetChCh" style="padding-right: 5px">
                                                                                    <asp:TextBox ID="Domicilio_Depto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
															        </ContentTemplate>
                                                                </asp:UpdatePanel>
															</td>
															<td>
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor">
																			<asp:RequiredFieldValidator ID="FechaEmisionDatePickerRequiredFieldValidator" runat="server"
																				ControlToValidate="FechaEmisionDatePickerWebUserControl:txt_Date" ErrorMessage="fecha de emisión"
																				SetFocusOnError="True">* </asp:RequiredFieldValidator>Fecha de emisión:
																		</td>
																		<td style="padding-top: 3px;">
																			<uc1:DatePickerWebUserControl ID="FechaEmisionDatePickerWebUserControl" runat="server"
																				TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
																		</td>
																		<td align="left" style="width: 95px">
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<!-- Datos del Vendedor: Sector, Torre y Manzana -->
														<tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="SectorTorreUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                    UpdateMode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <!-- 25 + 80 + 40 + 60 + 40 + 80 + 40 + 5 padding = 370px -->
                                                                                <td style="width: 25px;">
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorCh">
                                                                                    Sector:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDetChCh">
                                                                                    <asp:TextBox ID="Domicilio_Sector_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorChCh">
                                                                                    Torre:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDetChCh">
                                                                                    <asp:TextBox ID="Domicilio_Torre_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorCh">
                                                                                    Manzana:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDetChCh" style="padding-right: 5px">
                                                                                    <asp:TextBox ID="Domicilio_Manzana_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
															<td>
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			Código interno:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="Codigo_Interno_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																				ToolTip="<Opcional> Código utilizado para identificar al vendedor dentro de una empresa/organización. (Ej. Cod. de cliente, Proveedor, etc.)">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<!-- Datos del Vendedor: Localidad -->
														<tr>
															<td>
                                                                <asp:UpdatePanel ID="LocalidadVendedorUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                    UpdateMode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td class="TextoLabelFEAVendedor">
                                                                                    <asp:RequiredFieldValidator ID="Localidad_VendedorRequiredFieldValidator" runat="server"
                                                                                        ControlToValidate="Localidad_VendedorTextBox" ErrorMessage="localidad" SetFocusOnError="True">* </asp:RequiredFieldValidator>Localidad:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDet">
                                                                                    <asp:TextBox ID="Localidad_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
															<td>
															<asp:UpdatePanel ID="TipoExpoUpdatePanel" runat="server" ChildrenAsTriggers="true"
																UpdateMode="Conditional">
																<Triggers>
																	<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
																</Triggers>
																<ContentTemplate>
																	<table border="0" cellpadding="0" cellspacing="0">
																		<tr>
																			<td class="TextoLabelFEAVendedor">
																				Tipo Exportación:
																			</td>
																			<td class="TextoLabelFEAVendedorDet">
																				<asp:DropDownList ID="TipoExpDropDownList" runat="server" SkinID="DropDownListVendedor">
																				</asp:DropDownList>
																			</td>
																		</tr>
																	</table>
																</ContentTemplate>
															</asp:UpdatePanel>
															</td>
														</tr>
														<!-- Datos del Vendedor: Provincia -->
														<tr>
															<td>
                                                                <asp:UpdatePanel ID="ProvinciaVendUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                    UpdateMode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td class="TextoLabelFEAVendedor">
                                                                                    Provincia:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDet">
                                                                                    <asp:DropDownList ID="Provincia_VendedorDropDownList" runat="server" SkinID="DropDownListVendedor">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
															<td>
															<asp:UpdatePanel ID="PaisDestinoExpUpdatePanel" runat="server"
																UpdateMode="Conditional">
																<ContentTemplate>
																	<table border="0" cellpadding="0" cellspacing="0">
																		<tr>
																			<td class="TextoLabelFEAVendedor">
																				País Destino Comprobante:
																			</td>
																			<td class="TextoLabelFEAVendedorDet">
																				<asp:DropDownList ID="PaisDestinoExpDropDownList" runat="server" OnSelectedIndexChanged="PaisDestinoExpDropDownList_SelectedIndexChanged"
																					SkinID="DropDownListVendedor" AutoPostBack="true">
																				</asp:DropDownList>
																				<asp:UpdateProgress ID="PaisDestinoUpdateProgress" runat="server" AssociatedUpdatePanelID="PaisDestinoExpUpdatePanel"
																					DisplayAfter="0">
																					<ProgressTemplate>
																						<asp:Image ID="PaisDestinoImage" runat="server" Height="18px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
																						</asp:Image>
																					</ProgressTemplate>
																				</asp:UpdateProgress>
																			</td>
																		</tr>
																	</table>
																</ContentTemplate>
																<Triggers>
																<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
																</Triggers>
															</asp:UpdatePanel>
															</td>
														</tr>
														<!-- Datos del Vendedor: Código Postal -->
														<tr>
															<td>
                                                                <asp:UpdatePanel ID="CPVendedorUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                    UpdateMode="Conditional">
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                    <ContentTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td class="TextoLabelFEAVendedor">
                                                                                    Código Postal:
                                                                                </td>
                                                                                <td class="TextoLabelFEAVendedorDet">
                                                                                    <asp:TextBox ID="Cp_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
															</td>
															<td>
															<asp:UpdatePanel ID="IdiomaUpdatePanel" runat="server" ChildrenAsTriggers="true"
																UpdateMode="Conditional">
																<Triggers>
																	<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
																</Triggers>
																<ContentTemplate>
																	<table border="0" cellpadding="0" cellspacing="0">
																		<tr>
																			<td class="TextoLabelFEAVendedor">
																				Idioma para exportación:
																			</td>
																			<td class="TextoLabelFEAVendedorDet">
																				<asp:DropDownList ID="IdiomaDropDownList" runat="server" SkinID="DropDownListVendedor">
																				</asp:DropDownList>
																			</td>
																		</tr>
																	</table>
																</ContentTemplate>
															</asp:UpdatePanel>
															</td>
														</tr>
														<!-- Datos del Vendedor: GLN -->
														<tr>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			<asp:RegularExpressionValidator ID="GLN_VendedorRegularExpressionValidator" runat="server"
																				ControlToValidate="GLN_VendedorTextBox" ErrorMessage="error de formateo en GLN del vendedor"
																				SetFocusOnError="True" ValidationExpression="[0-9]{13}">* </asp:RegularExpressionValidator>GLN:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="GLN_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																				ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
															<td >
															<asp:UpdatePanel ID="IncotermsUpdatePanel" runat="server" ChildrenAsTriggers="true"
																UpdateMode="Conditional">
																<Triggers>
																	<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
																</Triggers>
																<ContentTemplate>
																	<table border="0" cellpadding="0" cellspacing="0">
																		<tr>
																			<td class="TextoLabelFEAVendedor">
																				Incoterms para exportación:
																			</td>
																			<td class="TextoLabelFEAVendedorDet">
																				<asp:DropDownList ID="IncotermsDropDownList" runat="server" SkinID="DropDownListVendedor">
																				</asp:DropDownList>
																			</td>
																		</tr>
																	</table>
																</ContentTemplate>
															</asp:UpdatePanel>
															</td>
														</tr>
														<!-- Datos del Vendedor: Nombre contacto -->
														<tr>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			Nombre contacto:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="Contacto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			<asp:RegularExpressionValidator ID="CUITVendedorRegularExpressionValidator" runat="server"
																				ControlToValidate="Cuit_VendedorTextBox" ErrorMessage="error de formateo en CUIT del vendedor"
																				SetFocusOnError="True" ValidationExpression="[0-9]+">* </asp:RegularExpressionValidator>
																			<asp:RequiredFieldValidator ID="CUITVendedorRequiredFieldValidator" runat="server"
																				ControlToValidate="Cuit_VendedorTextBox" ErrorMessage="CUIT del vendedor" SetFocusOnError="True">* </asp:RequiredFieldValidator>
																			CUIT:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="Cuit_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<!-- Datos del Vendedor: Mail Contacto / CUIT -->
														<tr>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			<asp:RegularExpressionValidator ID="Email_VendedorRegularExpressionValidator" runat="server"
																				ControlToValidate="Email_VendedorTextBox" ErrorMessage="error de formateo en e-mail contacto vendedor"
																				SetFocusOnError="True" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
																				Width="11px">* </asp:RegularExpressionValidator>
																			<asp:RequiredFieldValidator ID="Email_VendedorRequiredFieldValidator" runat="server"
																				ControlToValidate="Email_VendedorTextBox" ErrorMessage="e-mail contacto del vendedor"
																				SetFocusOnError="True">* </asp:RequiredFieldValidator>e-mail Contacto:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="Email_VendedorTextBox" runat="server" AutoCompleteType="Email" SkinID="TextoBoxFEAVendedorDet">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor">
																			Condición IB:
																		</td>
																		<td class="TextoLabelFEAVendedorDet">
																			<asp:DropDownList ID="Condicion_Ingresos_Brutos_VendedorDropDownList" runat="server"
																				SkinID="DropDownListVendedor">
																			</asp:DropDownList>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<!-- Datos del Vendedor: Teléfono contacto -->
														<tr>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			Teléfono contacto:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:TextBox ID="Telefono_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			<asp:RegularExpressionValidator ID="NumeroIBVendedorRegularExpressionValidator" runat="server"
																				ControlToValidate="NroIBVendedorTextBox" ErrorMessage="error de formateo en nro IB del vendedor"
																				SetFocusOnError="True" ValidationExpression="[0-9]{7}-[0-9]{2}|[0-9]{2}-[0-9]{8}-[0-9]{1}|[0-9]{3}-[0-9]{6}-[0-9]{1}">* </asp:RegularExpressionValidator>Número
																			IB:
																		</td>
																		<td class="TextoLabelFEAVendedorDet">
																			<asp:TextBox ID="NroIBVendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																				ToolTip="Formatos válidos: XXXXXXX-XX o XX-XXXXXXXX-X o XXX-XXXXXX-X">
																			</asp:TextBox>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<!-- Datos del Vendedor: IVA / Inicio de actividades -->
														<tr>
															<td >
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor" >
																			IVA:
																		</td>
																		<td class="TextoLabelFEAVendedorDet" >
																			<asp:DropDownList ID="Condicion_IVA_VendedorDropDownList" runat="server" SkinID="DropDownListVendedor">
																			</asp:DropDownList>
																		</td>
																	</tr>
																</table>
															</td>
															<td align="left" valign="top">
																<table border="0" cellpadding="0" cellspacing="0" >
																	<tr>
																		<td class="TextoLabelFEAVendedor">
																			Inicio de actividades:
																		</td>
																		<td align="left" style="padding-top: 3px;" valign="top">
																			<uc1:DatePickerWebUserControl ID="InicioDeActividadesVendedorDatePickerWebUserControl"
																				runat="server" TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
																		</td>
																		<td align="left" style="width: 95px">
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td style="height: 10px;">
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td colspan="5" style="height: 1px; background-color: Gray;">
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br />
							<table border="0" cellpadding="0" cellspacing="0">
								<!-- DATOS DEL LOTE -->
								<tr>
									<td>
										<asp:UpdatePanel ID="LoteUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
											<Triggers>
												<asp:AsyncPostBackTrigger ControlID="Version0RadioButton" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
												<asp:AsyncPostBackTrigger ControlID="Version1RadioButton" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
												<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox" EventName="TextChanged"></asp:AsyncPostBackTrigger>
												<asp:PostBackTrigger ControlID="FileUploadButton"></asp:PostBackTrigger>
											</Triggers>
											<ContentTemplate>
												<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
													<tr>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
														<td colspan="1" style="height: 1px; background-color: Gray;">
														</td>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
													</tr>
													<tr>
														<td colspan="2" style="text-align: center; height: 10px;">
														</td>
													</tr>
													<tr>
														<td class="TextoResaltado" style="text-align: center;">
															LOTE
														</td>
													</tr>
													<tr>
														<td style="text-align: center; height: 10px;">
														</td>
													</tr>
													<tr>
														<td style="text-align: center">
															<table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		<asp:RegularExpressionValidator ID="NroLoteRegularExpressionValidator" runat="server"
																			ControlToValidate="Id_LoteTextbox" ErrorMessage="error de formateo en número de lote"
																			SetFocusOnError="True" ValidationExpression="[0-9]+">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="loteRequiredFieldValidator" runat="server" ControlToValidate="Id_LoteTextbox"
																			Display="Static" ErrorMessage="número de lote" SetFocusOnError="True">* </asp:RequiredFieldValidator>Nro.
																		de lote:
																	</td>
																	<td class="TextoLabelFEAVendedor" >
																		<asp:TextBox ID="Id_LoteTextbox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="Es un número correlativo y consecutivo que debe llevarse manualmente e identifica el número de envío del archivo xml que envía a Interfacturas (Upload). Este número NO SE PUEDE REPETIR.">
																		</asp:TextBox>
																	</td>
																	<td class="TextoLabelFEAVendedorMed">
																		Cuit canal:
																	</td>
																	<td class="TextoLabelFEAVendedorCh">
																		<asp:TextBox ID="Cuit_CanalTextBox" runat="server" ReadOnly="True" SkinID="TextoBoxFEAVendedorDetCh">30690783521</asp:TextBox>
																	</td>
																	<td class="TextoLabelFEAVendedor">
																		<asp:Label ID="Presta_ServLabel" Text="Presta servicios:" runat="server"></asp:Label>
																	</td>
																	<td class="TextoLabelFEAVendedorChCh" style="text-align: left;">
																		<asp:CheckBox ID="Presta_ServCheckBox" runat="server"></asp:CheckBox>
																	</td>
																	<td style="width: 5px;">
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td style="text-align: center; height: 10px;">
														</td>
													</tr>
													<tr>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
														<td colspan="1" style="height: 1px; background-color: Gray;">
														</td>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
													</tr>
												</table>
												<br />
											</ContentTemplate>
										</asp:UpdatePanel>
									</td>
								</tr>
								<!-- DATOS DEL COMPRADOR -->
								<tr>
									<td>
										<asp:UpdatePanel ID="compradorUpdatePanel" runat="server" ChildrenAsTriggers="true"
											UpdateMode="Conditional">
											<Triggers>
												<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
												<asp:AsyncPostBackTrigger ControlID="PaisDestinoExpDropDownList"></asp:AsyncPostBackTrigger>
											</Triggers>
											<ContentTemplate>
												<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
													<tr>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
														<td colspan="3" style="height: 1px; background-color: Gray;">
														</td>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
													</tr>
													<tr>
														<td colspan="3" style="text-align: center; height: 10px;">
														</td>
													</tr>
													<tr>
														<td class="TextoResaltado" colspan="3" style="text-align: center">
															INFORMACIÓN COMPRADOR
														</td>
													</tr>
													<tr>
														<td align="center" class="TextoLabelFEAVendedorDet" colspan="3" style="text-align: center;
															height: 10px; width: 740px">
															<table border="0" cellpadding="0" cellspacing="0" style="width: 740px">
																<tr>
																	<td class="TextoLabelFEAVendedorDet">
																	</td>
																	<td align="center" style="width: 100%">
																		<asp:DropDownList ID="CompradorDropDownList" runat="server" AutoPostBack="True" Enabled="false"
																			OnSelectedIndexChanged="CompradorDropDownList_SelectedIndexChanged" SkinID="DropDownListPremium"
																			Visible="false">
																		</asp:DropDownList>
																		<asp:UpdateProgress ID="compradorUpdateProgress" runat="server" AssociatedUpdatePanelID="compradorUpdatePanel"
																			DisplayAfter="0">
																			<ProgressTemplate>
																				<asp:Image ID="compradorImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
																				</asp:Image>
																			</ProgressTemplate>
																		</asp:UpdateProgress>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td align="right" valign="top">
															<table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		<asp:RegularExpressionValidator ID="GLN_CompradorRegularExpressionValidator" runat="server"
																			ControlToValidate="GLN_CompradorTextBox" ErrorMessage="error de formateo en GLN del comprador"
																			SetFocusOnError="True" ValidationExpression="[0-9]{13}">* </asp:RegularExpressionValidator>GLN:
																	</td>
																	<td class="TextoLabelFEAVendedorDet" >
																		<asp:TextBox ID="GLN_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		Código interno:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Codigo_Interno_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Opcional> Código utilizado para identificar al comprador dentro de una empresa/organización. (Ej. Cod. de cliente, Proveedor, etc.)">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		Tipo de documento:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:DropDownList ID="Codigo_Doc_Identificatorio_CompradorDropDownList" runat="server"
																			SkinID="DropDownListComprador">
																		</asp:DropDownList></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		<asp:RegularExpressionValidator ID="docCompradorRegularExpressionValidator" runat="server"
																			ControlToValidate="Nro_Doc_Identificatorio_CompradorTextBox" ErrorMessage="error de formateo en documento del comprador"
																			SetFocusOnError="True" ValidationExpression="[0-9]+">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="docCompradorRequiredFieldValidator" runat="server"
																			ControlToValidate="Nro_Doc_Identificatorio_CompradorTextBox" ErrorMessage="documento del comprador"
																			SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		<asp:RequiredFieldValidator ID="listaDocCompradorRequiredFieldValidator" runat="server"
																			ControlToValidate="Nro_Doc_Identificatorio_CompradorDropDownList" ErrorMessage="documento del comprador para exportación"
																			SetFocusOnError="True">* </asp:RequiredFieldValidator>
																			Nro. de documento:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Nro_Doc_Identificatorio_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																		</asp:TextBox>
																		<asp:DropDownList ID="Nro_Doc_Identificatorio_CompradorDropDownList" runat="server"
																			SkinID="DropDownListComprador" Visible="false" CausesValidation="false">
																		</asp:DropDownList></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		Denominación:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Denominacion_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="Razón Social y Nombre del comprador">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		Calle:
																	</td>
																	<td class="TextoLabelFEAVendedorDet" >
																		<asp:TextBox ID="Domicilio_Calle_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td colspan="2" style="padding-top: 5px; text-align: right;">
																		<table border="0" cellpadding="0" cellspacing="0" style="text-align: right;">
																			<tr>
																				<td class="TextoLabelFEAVendedorCh" >
																					Nro.:
																				</td>
																				<td class="TextoBoxFEAVendedorDetChCh" >
																					<asp:TextBox ID="Domicilio_Numero_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
																					</asp:TextBox>
																				</td>
																				<td class="TextoLabelFEAVendedorChCh" >
																					Piso:
																				</td>
																				<td class="TextoLabelFEADetVendedorChCh" >
																					<asp:TextBox ID="Domicilio_Piso_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
																					</asp:TextBox>
																				</td>
																				<td class="TextoLabelFEAVendedorCh" >
																					Depto:
																				</td>
																				<td class="TextoBoxFEAVendedorDetChCh" style="padding-right: 5px">
																					<asp:TextBox ID="Domicilio_Depto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
																					</asp:TextBox>
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td colspan="2" style="padding-top: 5px; text-align: right;">
																		<table border="0" cellpadding="0" cellspacing="0" style="text-align: right;">
																			<tr>
																				<td class="TextoLabelFEAVendedorCh" >
																					Sector:
																				</td>
																				<td class="TextoLabelFEAVendedorDetChCh" >
																					<asp:TextBox ID="Domicilio_Sector_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
																					</asp:TextBox>
																				</td>
																				<td class="TextoLabelFEAVendedorChCh" >
																					Torre:
																				</td>
																				<td class="TextoLabelFEAVendedorDetChCh" >
																					<asp:TextBox ID="Domicilio_Torre_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
																					</asp:TextBox></td>
																				<td class="TextoLabelFEAVendedorCh" >
																					Manzana:
																				</td>
																				<td class="TextoLabelFEAVendedorDetChCh" style="padding-right: 5px">
																					<asp:TextBox ID="Domicilio_Manzana_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
																					</asp:TextBox></td>
																			</tr>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		e-mail para aviso :
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="EmailAvisoVisualizacionTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="A esta dirección se enviará un email de aviso para que el destinatario pueda visualizar el comprobante">
																		</asp:TextBox>
																	</td>
																</tr>
															</table>
														</td>
														<td class="bgFEAC" rowspan="2" style="width: 40px; background-repeat: repeat-y;">
														</td>
														<td align="left" valign="top">
															<table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		Localidad:
																	</td>
																	<td class="TextoLabelFEAVendedorDet" >
																		<asp:TextBox ID="Localidad_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		Provincia:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:DropDownList ID="Provincia_CompradorDropDownList" runat="server" SkinID="DropDownListComprador">
																		</asp:DropDownList></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		Código Postal:
																	</td>
																	<td class="TextoLabelFEAVendedorDet" >
																		<asp:TextBox ID="Cp_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		Contacto:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Contacto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email_CompradorTextBox"
																			ErrorMessage="error de formateo en e-mail contacto comprador" SetFocusOnError="True"
																			ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$">* </asp:RegularExpressionValidator>e-mail
																		Contacto:
																	</td>
																	<td class="TextoLabelFEAVendedorDet" >
																		<asp:TextBox ID="Email_CompradorTextBox" runat="server" AutoCompleteType="Email"
																			SkinID="TextoBoxFEAVendedorDet">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		Teléfono contacto:
																	</td>
																	<td class="TextoLabelFEAVendedorDet" >
																		<asp:TextBox ID="Telefono_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		Inicio de actividades:
																	</td>
																	<td class="" style="padding-top: 3px;">
																		<uc1:DatePickerWebUserControl ID="InicioDeActividadesCompradorDatePickerWebUserControl"
																			runat="server" TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		IVA:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:DropDownList ID="Condicion_IVA_CompradorDropDownList" runat="server" SkinID="DropDownListComprador">
																		</asp:DropDownList></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		Contraseña para aviso:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="PasswordAvisoVisualizacionTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="Para poder acceder al contenido del comprobante, se solicitará al destinatario el ingreso de esta contraseña">
																		</asp:TextBox>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td align="left" colspan="3" valign="top">
															<table border="0" cellpadding="0" cellspacing="0">
																<tr>
																	<td style="height: 10px;">
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td colspan="4" style="height: 1px; background-color: Gray;">
														</td>
													</tr>
												</table>
											</ContentTemplate>
										</asp:UpdatePanel>
										<br />
									</td>
								</tr>
								<!-- DATOS DEL COMPROBANTE -->
								<tr>
									<td>
										<asp:UpdatePanel ID="InfoComproUpdatePanel" runat="server" ChildrenAsTriggers="true"
											UpdateMode="Conditional">
											<Triggers>
													<asp:AsyncPostBackTrigger ControlID="Version0RadioButton" EventName="CheckedChanged">
													</asp:AsyncPostBackTrigger>
													<asp:AsyncPostBackTrigger ControlID="Version1RadioButton" EventName="CheckedChanged">
													</asp:AsyncPostBackTrigger>
													<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox" EventName="TextChanged">
													</asp:AsyncPostBackTrigger>
													<asp:PostBackTrigger ControlID="FileUploadButton">
													</asp:PostBackTrigger>
													<asp:AsyncPostBackTrigger ControlID="Tipo_De_ComprobanteDropDownList" EventName="SelectedIndexChanged"/>
											</Triggers>
											<ContentTemplate>
												<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
													<tr>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
														<td colspan="3" style="height: 1px; background-color: Gray;">
														</td>
														<td rowspan="6" style="width: 1px; background-color: Gray;">
														</td>
													</tr>
													<tr>
														<td colspan="3" style="text-align: center; height: 10px;">
														</td>
													</tr>
													<tr>
														<td class="TextoResaltado" colspan="3" style="text-align: center;">
															INFORMACIÓN COMPROBANTE
														</td>
													</tr>
													<tr>
														<td class="TextoResaltado" colspan="3" style="text-align: center; height: 10px;">
														</td>
													</tr>
													<tr>
														<td align="left" valign="top">
															<table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		Fecha de vencimiento:
																	</td>
																	<td style="padding-top: 3px;">
																		<uc1:DatePickerWebUserControl ID="FechaVencimientoDatePickerWebUserControl" runat="server"
																			TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		IVA computable:
																	</td>
																	<td style="padding-top: 3px;">
																		<asp:DropDownList ID="IVAcomputableDropDownList" runat="server">
																		</asp:DropDownList>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																	    <asp:Label ID="CodigoOperacionLabel" runat="server" Text="Código de operación:" Visible="true"></asp:Label>
																	</td>
																	<td style="padding-top: 8px;">
																		<asp:DropDownList ID="CodigoOperacionDropDownList" runat="server">
																		</asp:DropDownList>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor">
																		<asp:Label ID="CodigoConceptoLabel" runat="server" Text="Código de concepto:" Visible="false"></asp:Label>
																	</td>
																	<td style="padding-top: 8px;">
																		<asp:DropDownList ID="CodigoConceptoDropDownList" runat="server" Visible="false">
																		</asp:DropDownList>
																	</td>
																</tr>
															</table>
														</td>
														<td class="bgFEAC" rowspan="5" style="width: 40px; background-repeat: repeat-y;">
														</td>
														<td align="left" valign="top">
															<table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		<asp:Label ID="FechaInicioServLabel" runat="server" Text="Fecha inicio servicio:"></asp:Label>
																	</td>
																	<td >
																		<uc1:DatePickerWebUserControl ID="FechaServDesdeDatePickerWebUserControl" runat="server"
																			TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		<asp:Label ID="FechaHstServLabel" runat="server" Text="Fecha finalización servicio:">
																		</asp:Label>
																	</td>
																	<td style="padding-top: 3px;">
																		<uc1:DatePickerWebUserControl ID="FechaServHastaDatePickerWebUserControl" runat="server"
																			TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" >
																		Condición de pago:
																	</td>
																	<td style="padding-top: 3px;">
																		<asp:TextBox ID="Condicion_De_PagoTextBox" runat="server" BorderStyle="NotSet" ForeColor="#071F70"
																			style="width: 175px" TextMode="MultiLine">
																		</asp:TextBox></td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td class="TextoResaltado" colspan="3" style="text-align: center; height: 10px;">
														</td>
													</tr>
													<tr>
														<td colspan="5" style="height: 1px; background-color: Gray;">
														</td>
													</tr>
												</table>
												<br />
											</ContentTemplate>
										</asp:UpdatePanel>
									</td>
								</tr>
								<!-- CODIGOS DE REFERENCIAS -->
								<tr>
									<td class="TextoResaltado" style="text-align: center">
										<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
											<tr>
												<td rowspan="8" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="1" style="height: 1px; background-color: Gray;">
												</td>
												<td rowspan="8" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
											<tr>
												<td style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td class="TextoResaltado" style="text-align: center;">
													REFERENCIAS
												</td>
											</tr>
											<tr>
												<td style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td style="text-align: center; padding: 3px; font-weight: normal;">
													<asp:UpdatePanel ID="referenciasUpdatePanel" runat="server" ChildrenAsTriggers="true"
														UpdateMode="Conditional">
														<ContentTemplate>
															<asp:GridView ID="referenciasGridView" runat="server" AutoGenerateColumns="False"
																BorderColor="gray" BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70"
																EmptyDataRowStyle-ForeColor="#071F70" EnableViewState="true" Font-Bold="false"
																ForeColor="#071F70" GridLines="Both" HeaderStyle-ForeColor="#A52A2A" OnRowCancelingEdit="referenciasGridView_RowCancelingEdit"
																OnRowCommand="referenciasGridView_RowCommand" OnRowDeleted="referenciasGridView_RowDeleted"
																OnRowDeleting="referenciasGridView_RowDeleting" OnRowEditing="referenciasGridView_RowEditing"
																OnRowUpdated="referenciasGridView_RowUpdated" OnRowUpdating="referenciasGridView_RowUpdating"
																PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
																ShowFooter="true" ShowHeader="True" ToolTip="El dato de referencia debe ser un número entero"
																Width="100%">
																<Columns>
																	<asp:TemplateField HeaderText="C&#243;digo de referencia">
																		<ItemTemplate>
																			<asp:Label ID="lblcodigo_de_referencia" runat="server" Text='<%# Eval("descripcioncodigo_de_referencia") %>'
																				Width="320px"></asp:Label>
																		</ItemTemplate>
																		<EditItemTemplate>
																			<asp:DropDownList ID="ddlcodigo_de_referenciaEdit" runat="server" Width="300px">
																			</asp:DropDownList><asp:RequiredFieldValidator ID="ddlcodigo_de_referenciaEditItemRequiredFieldValidator"
																				runat="server" ControlToValidate="ddlcodigo_de_referenciaEdit" ErrorMessage="Codigo de referencia en edición no informado"
																				SetFocusOnError="True" ValidationGroup="ReferenciasEditItem">*</asp:RequiredFieldValidator>
																		</EditItemTemplate>
																		<FooterTemplate>
																			<asp:DropDownList ID="ddlcodigo_de_referencia" runat="server" Width="300px">
																			</asp:DropDownList><asp:RequiredFieldValidator ID="ddldescripcionFooterRequiredFieldValidator"
																				runat="server" ControlToValidate="ddlcodigo_de_referencia" ErrorMessage="Codigo de referencia a agregar no informado"
																				SetFocusOnError="True" ValidationGroup="ReferenciasFooter">*</asp:RequiredFieldValidator>
																		</FooterTemplate>
																		<ItemStyle HorizontalAlign="Left" Width="320px" />
																		<FooterStyle HorizontalAlign="Left" Width="320px" />
																		<HeaderStyle Font-Bold="False" />
																	</asp:TemplateField>
																	<asp:TemplateField HeaderText="Número de referencia">
																		<ItemTemplate>
																			<asp:Label ID="lbldato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'></asp:Label>
																		</ItemTemplate>
																		<EditItemTemplate>
																			<asp:TextBox ID="txtdato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'
																				Width="75%"></asp:TextBox>
																			<cc1:MaskedEditExtender ID="txtdato_de_referenciaEditExpoMaskedEditExtender" runat="server"
																				ClearMaskOnLostFocus="false" Enabled="false" Mask="9999-99999999"
																				MaskType="Number" PromptCharacter="?" TargetControlID="txtdato_de_referencia"></cc1:MaskedEditExtender>
																			<cc1:FilteredTextBoxExtender ID="txtdato_de_referenciaEditExpoFilteredTextBoxExtender"
																				runat="server" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtdato_de_referencia"></cc1:FilteredTextBoxExtender>	
																			<asp:RequiredFieldValidator ID="txtdato_de_referenciaEditItemRequiredFieldValidator"
																				runat="server" ControlToValidate="txtdato_de_referencia" ErrorMessage="dato de referencia en edición no informado"
																				SetFocusOnError="True" ValidationGroup="ReferenciasEditItem">*</asp:RequiredFieldValidator>
																		</EditItemTemplate>
																		<FooterTemplate>
																			<asp:TextBox ID="txtdato_de_referencia" runat="server" Text='' Width="75%"></asp:TextBox>
																			<cc1:MaskedEditExtender ID="txtdato_de_referenciaFooterExpoMaskedEditExtender" runat="server"
																				ClearMaskOnLostFocus="false" Enabled="false" Mask="9999-99999999" MaskType="Number" PromptCharacter="?"
																				TargetControlID="txtdato_de_referencia">
																			</cc1:MaskedEditExtender>
																			<cc1:FilteredTextBoxExtender ID="txtdato_de_referenciaFooterExpoFilteredTextBoxExtender"
																				runat="server" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtdato_de_referencia">
																			</cc1:FilteredTextBoxExtender>
																			<asp:RequiredFieldValidator ID="txtdato_de_referenciaFooterRequiredFieldValidator"
																			runat="server" ControlToValidate="txtdato_de_referencia" ErrorMessage="Dato de referencia a agregar no informado"
																			SetFocusOnError="True" ValidationGroup="ReferenciasFooter">*</asp:RequiredFieldValidator>
																		</FooterTemplate>
																		<ItemStyle HorizontalAlign="Right" />
																		<HeaderStyle Font-Bold="False" />
																	</asp:TemplateField>
																	<asp:CommandField CancelText="Cancelar" EditText="Editar" HeaderText="Edici&#243;n"
																		ShowEditButton="True" UpdateText="Actualizar" ValidationGroup="ReferenciasEditItem">
																		<ItemStyle HorizontalAlign="Center" />
																		<HeaderStyle Font-Bold="False" />
																	</asp:CommandField>
																	<asp:TemplateField HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
																		<ItemTemplate>
																			<asp:LinkButton ID="linkDeletereferencias" runat="server" CausesValidation="false"
																				CommandName="Delete">Borrar</asp:LinkButton>
																		</ItemTemplate>
																		<FooterTemplate>
																			<asp:LinkButton ID="linkAddreferencias" runat="server" CausesValidation="true" CommandName="Addreferencias"
																				ValidationGroup="ReferenciasFooter">Agregar</asp:LinkButton>
																		</FooterTemplate>
																		<ItemStyle HorizontalAlign="Center" />
																		<HeaderStyle Font-Bold="False" />
																	</asp:TemplateField>
																</Columns>
																<EmptyDataRowStyle ForeColor="#071F70" />
																<RowStyle ForeColor="#071F70" />
																<EditRowStyle ForeColor="#071F70" />
																<SelectedRowStyle ForeColor="#071F70" />
																<PagerStyle ForeColor="#071F70" />
																<HeaderStyle ForeColor="Brown" />
															</asp:GridView>
														</ContentTemplate>
														<Triggers>
															<asp:AsyncPostBackTrigger ControlID="Punto_VentaTextBox"></asp:AsyncPostBackTrigger>
														</Triggers>
													</asp:UpdatePanel>
												</td>
											</tr>
											<tr>
												<td style="text-align: center; height: 10px;">
													<asp:UpdateProgress ID="referenciasUpdateProgress" runat="server" AssociatedUpdatePanelID="referenciasUpdatePanel"
														DisplayAfter="0">
														<ProgressTemplate>
															<asp:Image ID="referenciasImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
															</asp:Image>
														</ProgressTemplate>
													</asp:UpdateProgress>
												</td>
											</tr>
											<tr>
												<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
													<asp:ValidationSummary ID="ReferenciasEditValidationSummary" runat="server" BorderColor="Gray"
														BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
														ShowMessageBox="True" ValidationGroup="ReferenciasEditItem"></asp:ValidationSummary>
												</td>
											</tr>
											<tr>
												<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
													<asp:ValidationSummary ID="ReferenciasFooterValidationSummary" runat="server" BorderColor="Gray"
														BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
														ShowMessageBox="True" ValidationGroup="ReferenciasFooter"></asp:ValidationSummary>
												</td>
											</tr>
											<tr>
												<td rowspan="8" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="1" style="height: 1px; background-color: Gray;">
												</td>
												<td rowspan="8" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
										</table>
										<br />
									</td>
								</tr>
								<!-- PERMISOS EXPO-->
								<tr>
									<td class="TextoResaltado" style="height: 19px; text-align: center">
										<uc2:Permisos id="PermisosExpo" runat="server">
										</uc2:Permisos>
									</td>
								</tr>
								<!-- DATOS COMERCIALES-->
								<tr>
									<td class="TextoResaltado" style="height: 19px; text-align: center">
										<uc3:Comerciales ID="DatosComerciales" runat="server">
										</uc3:Comerciales>
									</td>
								</tr>
								<tr>
									<td style="text-align: center; height: 10px;">
									</td>
								</tr>
								<!-- DATOS DEL DETALLE -->
								<tr>
									<td class="TextoResaltado" style="text-align: center">
										<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
											<tr>
												<td rowspan="6" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="1" style="height: 1px; background-color: Gray;">
												</td>
												<td rowspan="6" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
											<tr>
												<td style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td class="TextoResaltado" style="text-align: center;">
													DETALLE DE ARTÍCULOS / SERVICIOS
												</td>
											</tr>
											<tr>
												<td style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td style="text-align: center">
													<table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
														<tr>
															<td class="TextoLabelFEAVendedor">
																Comentarios:
															</td>
															<td class="TextoLabelFEADescrLarga" style="padding: 5px;">
																<asp:TextBox ID="ComentariosTextBox" runat="server" Height="100px" SkinID="TextoBoxFEADescrGr"
																	TextMode="MultiLine">
																</asp:TextBox>
															</td>
														</tr>
														<tr>
															<td colspan="2" style="text-align: center; height: 10px;">
															</td>
														</tr>
														<uc4:Detalle ID="DetalleLinea" runat="server"></uc4:Detalle>
													</table>
												</td>
											</tr>
											<tr>
												<td style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td colspan="8" style="height: 1px; background-color: Gray;">
												</td>
											</tr>
										</table>
										<br />
									</td>
								</tr>
								<!-- DATOS DE DESCUENTOS GLOBALES -->
								<tr>
									<td class="TextoResaltado" style="text-align: center">
										<DescUC:DescuentosGlobales ID="DescuentosGlobales" runat="server"></DescUC:DescuentosGlobales>
										<br />
									</td>
								</tr>
								<!-- DATOS DE IMPUESTOS GLOBALES -->
								<tr>
									<td class="TextoResaltado" style="text-align: center">
										<uc8:ImpuestosGlobales ID="ImpuestosGlobales" runat="server"></uc8:ImpuestosGlobales>
									</td>
								</tr>
								<!-- DATOS DE RESUMEN FINAL -->
								<tr>
									<td style="text-align: center">
										<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
											<tr>
												<td rowspan="5" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="3" style="height: 1px; background-color: Gray;">
												</td>
												<td rowspan="5" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
											<tr>
												<td colspan="3" style="text-align: center; height: 10px;">
												</td>
											</tr>
											<tr>
												<td class="TextoResaltado" colspan="3" style="text-align: center">
													RESUMEN FINAL
												</td>
											</tr>
											<tr>
												<td class="TextoResaltado" colspan="2" style="text-align: right;">
												</td>
												<td align="right" class="TextoResaltado" style="padding-right: 5px">
													<asp:Button ID="CalcularTotalesButton" runat="server" BackColor="peachpuff" BorderColor="brown"
														BorderStyle="Solid" BorderWidth="1px" CausesValidation="false" Font-Bold="true"
														ForeColor="brown" Height="25px" OnClick="CalcularTotalesButton_Click" Text="Sugerir totales"
														ToolTip="Exclusivo SERVICIO PREMIUM" Width="184" />
												</td>
											</tr>
											<tr>
												<td align="center" style="padding-bottom: 35px; padding-left: 5px; width: 180px"
													valign="middle">
													<table border="0" cellpadding="0" cellspacing="0" style="border-color: Gray; border-width: 1px;
														border-style: solid" width="180px">
														<tr>
															<td class="TextoLabelFEAVendedorCh" style="padding: 5px; text-align: left; width: 180px">
																Si ya solicitó la CAE a la AFIP, ingrésela aqui:
															</td>
														</tr>
														<tr>
															<td class="TextoLabelFEAVendedorCh" style="padding-left: 5px; padding: 5px; text-align: left;
																width: 180px">
																CAE:<asp:TextBox ID="CAETextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Opcional> MUY IMPORTANTE! Solo si YA TIENE GENERADO EL C.A.E., debe ingresar este dato. Si omite esta información, se generará una nueva factura ante la AFIP o bien se retornará un error por comprobante ya ingresado."
																	Width="100px"></asp:TextBox>
															</td>
														</tr>
														<tr>
															<td class="TextoLabelFEAVendedorCh" style="padding: 5px; text-align: left; width: 180px">
																Fecha de vencimiento CAE:<uc1:DatePickerWebUserControl ID="FechaCAEVencimientoDatePickerWebUserControl"
																	runat="server" TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
															</td>
														</tr>
														<tr>
															<td class="TextoLabelFEAVendedorCh" style="padding: 5px; text-align: left; width: 180px">
																Fecha de obtención CAE:<uc1:DatePickerWebUserControl ID="FechaCAEObtencionDatePickerWebUserControl"
																	runat="server" TextCssClass="DatePickerFecha"></uc1:DatePickerWebUserControl>
															</td>
														</tr>
														<tr>
															<td class="TextoLabelFEAVendedorCh" style="padding: 5px; text-align: left; width: 180px">
																Resultado:<asp:TextBox ID="ResultadoTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																	Width="100px">
																</asp:TextBox></td>
														</tr>
														<tr>
															<td class="TextoLabelFEAVendedorCh" style="padding: 5px; text-align: left; width: 180px">
																Motivo:<asp:TextBox ID="MotivoTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																	Width="100px">
																</asp:TextBox></td>
														</tr>
													</table>
												</td>
												<td>
												</td>
												<td align="left" valign="top">
													<asp:UpdatePanel ID="tipoCambioUpdatePanel" runat="server" ChildrenAsTriggers="true"
														OnLoad="tipoCambioUpdatePanel_Load" UpdateMode="Conditional">
														<Triggers>
															<asp:AsyncPostBackTrigger ControlID="MonedaComprobanteDropDownList" ></asp:AsyncPostBackTrigger>
															<asp:AsyncPostBackTrigger ControlID="CalcularTotalesButton" ></asp:AsyncPostBackTrigger>
														</Triggers>
														<ContentTemplate>
															<table border="0" cellpadding="0" cellspacing="0">
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="ImporteTotalNetoGravadoRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Total_Neto_Gravado_ResumenTextBox"
																			ErrorMessage="error de formateo en importe total neto gravado" SetFocusOnError="True"
																			ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="Importe_Total_Neto_Gravado_ResumenRequiredFieldValidator"
																			runat="server" ControlToValidate="Importe_Total_Neto_Gravado_ResumenTextBox"
																			ErrorMessage="importe total neto gravado" SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		Importe total neto gravado:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Total_Neto_Gravado_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Importe_Total_Concepto_No_gravadoRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Total_Concepto_No_Gravado_ResumenTextBox"
																			ErrorMessage="error de formateo en importe total de conceptos que no integren el precio neto gravado"
																			SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="Importe_Total_Concepto_No_Gravado_ResumenRequiredFieldValidator"
																			runat="server" ControlToValidate="Importe_Total_Concepto_No_Gravado_ResumenTextBox"
																			ErrorMessage="importe total de conceptos que no integren el precio neto gravado"
																			SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		Importe total de conceptos que no integren el precio neto gravado:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Total_Concepto_No_Gravado_ResumenTextBox" runat="server"
																			SkinID="TextoBoxFEAVendedorDet" ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Importe_Operaciones_ExentasRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Operaciones_Exentas_ResumenTextBox"
																			ErrorMessage="error de formateo en importe de operaciones exentas" SetFocusOnError="True"
																			ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="Importe_Operaciones_Exentas_ResumenRequiredFieldValidator"
																			runat="server" ControlToValidate="Importe_Operaciones_Exentas_ResumenTextBox"
																			ErrorMessage="importe de operaciones exentas" SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		Importe de operaciones exentas:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Operaciones_Exentas_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Impuesto_LiqRegularExpressionValidator" runat="server"
																			ControlToValidate="Impuesto_Liq_ResumenTextBox" ErrorMessage="error de formateo en importe IVA Responsable inscripto"
																			SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="Impuesto_Liq_ResumenRequiredFieldValidator" runat="server"
																			ControlToValidate="Impuesto_Liq_ResumenTextBox" ErrorMessage="importe de IVA Responsable inscripto"
																			SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		IVA Responsable inscripto:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Impuesto_Liq_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Impuesto_Liq_RniRegularExpressionValidator" runat="server"
																			ControlToValidate="Impuesto_Liq_Rni_ResumenTextBox" ErrorMessage="error de formateo en impuesto liquidado a RNI o percepción a no categorizados(IVA R.G. 2126)"
																			SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="Impuesto_Liq_Rni_ResumenRequiredFieldValidator" runat="server"
																			ControlToValidate="Impuesto_Liq_Rni_ResumenTextBox" ErrorMessage="impuesto liquidado a RNI o percepción a no categorizados(IVA R.G. 2126)"
																			SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		Impuesto liquidado a RNI o percepción a no categorizados<br />
																		(IVA R.G. 2126):
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Impuesto_Liq_Rni_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
																		</asp:TextBox></td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Importe_Total_Impuestos_MunicipalesResumenRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Total_Impuestos_Municipales_ResumenTextBox"
																			ErrorMessage="error de formateo en importe total impuestos municipales" SetFocusOnError="True"
																			ValidationExpression="[0-9]+(\.[0-9]+)?">*</asp:RegularExpressionValidator>
																		Importe total impuestos municipales:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Total_Impuestos_Municipales_ResumenTextBox" runat="server"
																			SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Importe_Total_Impuestos_Nacionales_ResumenTextBoxResumenRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Total_Impuestos_Nacionales_ResumenTextBox"
																			ErrorMessage="error de formateo en importe total impuestos nacionales" SetFocusOnError="True"
																			ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		Importe total impuestos nacionales:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Total_Impuestos_Nacionales_ResumenTextBox" runat="server"
																			SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Importe_Total_Ingresos_Brutos_ResumenTextBoxResumenRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Total_Ingresos_Brutos_ResumenTextBox"
																			ErrorMessage="error de formateo en importe total ingresos brutos" SetFocusOnError="True"
																			ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		Importe total ingresos brutos:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Total_Ingresos_Brutos_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Importe_Total_Impuestos_Internos_ResumenTextBoxResumenRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Total_Impuestos_Internos_ResumenTextBox"
																			ErrorMessage="error de formateo en importe total impuestos internos" SetFocusOnError="True"
																			ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		Importe total impuestos internos:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Total_Impuestos_Internos_ResumenTextBox" runat="server"
																			SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Importe_Total_FacturaRegularExpressionValidator"
																			runat="server" ControlToValidate="Importe_Total_Factura_ResumenTextBox" ErrorMessage="error de formateo en importe total"
																			SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator><asp:RequiredFieldValidator
																				ID="Importe_Total_Factura_ResumenRequiredFieldValidator" runat="server" ControlToValidate="Importe_Total_Factura_ResumenTextBox"
																				ErrorMessage="importe total" SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		Importe total:
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Importe_Total_Factura_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
																		</asp:TextBox>
																	</td>
																</tr>
																<tr>
																	<td class="TextoLabelFEAVendedor" style="width: 390px">
																		<asp:RegularExpressionValidator ID="Tipo_de_cambioRegularExpressionValidator" runat="server"
																			ControlToValidate="Tipo_de_cambioTextBox" ErrorMessage="error de formateo en tipo de cambio"
																			SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
																		<asp:RequiredFieldValidator ID="Tipo_de_cambioRequiredFieldValidator" runat="server"
																			ControlToValidate="Tipo_de_cambioTextBox" ErrorMessage="tipo de cambio" SetFocusOnError="True">* </asp:RequiredFieldValidator>
																		<asp:Label ID="Tipo_de_cambioLabel" runat="server" Text="Tipo de cambio:" Visible="true">
																		</asp:Label>
																	</td>
																	<td class="TextoLabelFEAVendedorDet">
																		<asp:TextBox ID="Tipo_de_cambioTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
																			ToolTip="<Obligatorio para moneda extranjera> El separador de decimales a utilizar es el punto"
																			Visible="true">
																		</asp:TextBox>
																		<asp:UpdateProgress ID="tipoCambioUpdateProgress" runat="server" DisplayAfter="0">
																			<ProgressTemplate>
																				<asp:Image ID="tipoCambioImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
																				</asp:Image>
																			</ProgressTemplate>
																		</asp:UpdateProgress>
																	</td>
																</tr>
																<tr>
																	<td style="height: 46px">
																		<br />
																	</td>
																	<td style="height: 46px">
																	</td>
																</tr>
															</table>
														</ContentTemplate>
													</asp:UpdatePanel>
												</td>
											</tr>
											<tr>
												<td colspan="5" style="height: 1px; background-color: Gray;">
												</td>
											</tr>
											<tr>
												<td rowspan="3" style="width: 1px; background-color: Gray;">
												</td>
												<td colspan="3" style="height: 1px;">
												</td>
												<td rowspan="3" style="width: 1px; background-color: Gray;">
												</td>
											</tr>
											<tr>
												<td colspan="3">
													<table border="0" cellpadding="0" cellspacing="0" style="width: 780px; padding: 5px;">
														<tr>
															<td class="TextoLabelFEAVendedor">
																Observaciones:
															</td>
															<td class="TextoLabelFEADescrLarga">
																<asp:TextBox ID="Observaciones_ResumenTextBox" runat="server" Height="100px" SkinID="TextoBoxFEADescrGr"
																	TextMode="MultiLine">
																</asp:TextBox>
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td colspan="5" style="height: 1px; background-color: Gray;">
												</td>
											</tr>
										</table>
										<br />
									</td>
								</tr>
								<tr>
									<td style="text-align: center; width: 100%">
										<table border="0" cellpadding="2" cellspacing="2" style="width: 780px">
											<tr>
												<td colspan="3" style="width: 100%">
													<asp:Button ID="GenerarButton" runat="server" BorderColor="Gray" BorderStyle="NotSet"
														BorderWidth="1px" Height="60px" OnClick="GenerarButton_Click" Text="Enviar archivo XML al e-mail del vendedor"
														Width="100%" />
												</td>
											</tr>
											<tr>
												<td style="width: 34%; padding-right: 3px">
													<asp:Button ID="DescargarButton" runat="server" BackColor="peachpuff" BorderColor="brown"
														BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" ForeColor="brown" Height="60px"
														OnClick="GenerarButton_Click" Text="Descargar archivo XML" ToolTip="Exclusivo SERVICIO PREMIUM"
														Width="100%" />
												</td>
												<td style="width: 33%; padding-right: 3px">
													<asp:Button ID="EnviarIBKButton" runat="server" BackColor="peachpuff" BorderColor="brown"
														BorderStyle="Solid" BorderWidth="1px" Font-Bold="true" ForeColor="brown" Height="60px"
														OnClick="EnviarIBKButton_Click" Text="Enviar lote a Interfacturas" ToolTip="Impactar comprobante en Interfacturas - Exclusivo SERVICIO PREMIUM"
														Width="100%" />
												</td>
												<td style="width: 33%">
													<asp:Button ID="ConsultarLoteIBKButton" runat="server" BackColor="peachpuff" BorderColor="brown"
														BorderStyle="Solid" BorderWidth="1px" CausesValidation="false" Font-Bold="true"
														ForeColor="brown" Height="60px" OnClick="ConsultarLoteIBKButton_Click" Text="Consultar lote a Interfacturas"
														ToolTip="Ingrese previamente el numero de lote a consultar- Exclusivo SERVICIO PREMIUM"
														Width="100%" />
												</td>
											</tr>
											<tr>
												<td colspan="3" style="width: 100%; padding-right: 3px">
													<asp:Button ID="PDFButton" runat="server" BackColor="peachpuff" BorderColor="brown"
														BorderStyle="Solid" BorderWidth="1px" CausesValidation="true" Font-Bold="true"
														ForeColor="brown" Height="60px" OnClick="PDFButton_Click" Text="Previsualizar comprobante"
														ToolTip="Exclusivo SERVICIO PREMIUM" Width="100%" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style="text-align: center; height: 10px;">
										Agradeceríamos a los usuarios del sitio que nos informen sobre dudas, posibles omisiones
										y/o errores y que nos envíen las correcciones o sugerencias por correo electrónico
										a través de
										<asp:HyperLink ID="contactoHyperLink" runat="server" NavigateUrl="~/Contacto.aspx">este formulario</asp:HyperLink>.
										Es de suma importancia conocer su opinión. Muchas gracias.
									</td>
								</tr>
								<tr>
									<td align="left" style="text-align: center; width: 780px;">
										<asp:ValidationSummary ID="RequeridosValidationSummary" runat="server" BorderColor="Gray"
											BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
											ShowMessageBox="True"></asp:ValidationSummary>
									</td>
								</tr>
							</table>
							<br />
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>
