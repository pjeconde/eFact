<%@ Page AutoEventWireup="true" Codebehind="Explorador.aspx.cs" Inherits="CedeiraAJAX.Admin.Cuenta.Explorador"
	Language="C#" MasterPageFile="~/Admin/Administracion.Master" %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
<asp:Content ID="AdminCuentaContent" runat="Server" ContentPlaceHolderID="AdministracionContentPlaceHolder">
	<asp:ScriptManager ID="CuentasScriptManager" runat="server">
	</asp:ScriptManager>
	<table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
		width: 800px; text-align: left;">
		<tr>
			<td valign="top">
				<asp:UpdatePanel id="CuentasUpdatePanel" runat="server">
					<contenttemplate>
						<table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
							<!-- @@@ TITULO DE LA PAGINA @@@-->
							<tr>
								<td style="padding-left: 10px; width: 500px" valign="top">
									<table border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td style="width: 21px; height: 20px;">
												<asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico">
												</asp:Image>
											</td>
											<td style="height: 20px;">
												<asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Cuentas"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
											</td>
											<td align="left" style="padding-top: 10px;">
												<asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Haga clic en la cuenta que desee seleccionar.">
												</asp:Label>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
							<tr>
								<td style="padding-left: 10px; padding-top: 10px" valign="top">
									<asp:Panel ID="PanelCuentas" runat="server" BackColor="peachpuff" BorderColor="brown"
										BorderStyle="Solid" BorderWidth="1px" Height="373px" ScrollBars="Auto" Width="650px">
										<cc1:PagingGridView ID="CuentaPagingGridView" runat="server" OnPageIndexChanging="CuentaPagingGridView_PageIndexChanging"
											OnRowDataBound="CuentaPagingGridView_RowDataBound" OnSelectedIndexChanged="CuentaPagingGridView_SelectedIndexChanged"
											OnSorting="CuentaPagingGridView_Sorting" ShowHeader="true" OnPreRender="CuentaPagingGridView_PreRender">
											<Columns>
												<asp:TemplateField HeaderText="Id" SortExpression="IdCuenta">
													<itemtemplate>
														<asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'
															Width="200px"></asp:Label>
													</itemtemplate>
													<headerstyle horizontalalign="left" wrap="False" width="200px"/>
													<itemstyle horizontalalign="left" width="200px" wrap="False" />
													<headertemplate>
														<asp:TextBox runat="server" ID="IdFilterTextBox" width="100px" EnableViewState="true" ></asp:TextBox>
														<asp:Button ID="IdFilterButton" runat="server" text="Filtrar" OnClick="IdFilterButton_Click"/>
													</headertemplate>
												</asp:TemplateField>
												<asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="CantidadComprobantes" HeaderText="qComprob." SortExpression="CantidadComprobantes">
													<headerstyle horizontalalign="center" wrap="False" />
													<itemstyle horizontalalign="center" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="Cuenta.IdTipoCuenta">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="Cuenta.IdEstadoCuenta">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="CantidadActivacionesCPs" HeaderText="CantActivCP" SortExpression="Cuenta.CantidadActivacionesCPs">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="right" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy H:mm}" HeaderText="Fecha alta"
													HtmlEncode="false" SortExpression="FechaAlta">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="FechaUltimoComprobante" DataFormatString="{0:dd/MM/yyyy H:mm}"
													HeaderText="Fecha ult.comprob." HtmlEncode="false" SortExpression="FechaUltimoComprobante">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="FechaVtoPremium" DataFormatString="{0:dd/MM/yyyy H:mm}"
													HeaderText="Fecha vto.Prem." HtmlEncode="false" SortExpression="FechaVtoPremium">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="CantidadEnviosMail" HeaderText="qEnv.mail" SortExpression="CantidadEnviosMail">
													<headerstyle horizontalalign="center" wrap="False" />
													<itemstyle horizontalalign="center" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="FechaUltimoReenvioMail" DataFormatString="{0:dd/MM/yyyy H:mm}"
													HeaderText="Fecha ult.env.mail" HtmlEncode="false" SortExpression="FechaUltimoReenvioMail">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="IdMedio" HeaderText="Medio" SortExpression="IdMedio">
													<headerstyle horizontalalign="left" wrap="False" />
													<itemstyle horizontalalign="left" wrap="False" />
												</asp:BoundField>
												<asp:BoundField DataField="UltimoNroLote" HeaderText="Ult.N°Lote" SortExpression="UltimoNroLote">
													<headerstyle horizontalalign="center" wrap="False" />
													<itemstyle horizontalalign="center" wrap="False" />
												</asp:BoundField>
											</Columns>
										</cc1:PagingGridView>
									</asp:Panel>
								</td>
								<td align="left" style="padding-left: 10px; padding-top: 6px" valign="top">
									<table border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td align="center" class="TextoResaltado" style="padding-top: 5px">
												Acciones
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="BajaButton" runat="server" Enabled="false" OnClick="BajaButton_Click"
													Text="Dar de baja" Width="100px" />
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="AnularBajaButton" runat="server" Enabled="false" OnClick="AnularBajaButton_Click"
													Text="Anular la baja" Width="100px" />
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="ReenviarMailButton" runat="server" Enabled="false" OnClick="ReenviarMailButton_Click"
													Text="Reenviar mail" Width="100px" />
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="ActivCPButton" runat="server" Enabled="false" OnClick="ActivCPButton_Click"
													Text="Activ.CP" Width="70px" />
                                                <asp:TextBox ID="CantidadActivacionesCPsTextBox" runat="server" Width="20px" Text="1"></asp:TextBox></td>
										</tr>
										<tr>
											<td align="center" class="TextoResaltado" style="padding-top: 10px">
												Servicio Premium
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="ActivarPremiumButton" runat="server" Enabled="false" OnClick="ActivarPremiumButton_Click"
													Text="Activar" Width="100px" />
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="SuspenderPremiumButton" runat="server" Enabled="false" OnClick="SuspenderPremiumButton_Click"
													Text="Suspender" Width="100px" />
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="DesactivarPremiumButton" runat="server" Enabled="false" OnClick="DesactivarPremiumButton_Click"
													Text="Desactivar" Width="100px" />
											</td>
										</tr>
										<tr>
											<td align="center" class="TextoResaltado" style="padding-top: 10px">
												Proceso
											</td>
										</tr>
										<tr>
											<td style="padding-top: 5px">
												<asp:Button ID="DepurarButton" runat="server" OnClick="DepurarButton_Click" Text="Depurar"
													ToolTip="Depura las bajas y suspende las cuentas Premium vencidas" Width="100px" />
											</td>
										</tr>
										<tr>
											<td style="padding-top: 20px">
												<asp:Button ID="SalirButton" runat="server" OnClick="SalirButton_Click" Text="Salir"
													Width="100px" />
											</td>
										</tr>
										<tr>
											<td align="center" style="padding-top: 10px">
												<asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<!-- @@@ @@@-->
						</table>
					</contenttemplate>
				</asp:UpdatePanel>
			</td>
			<td style="width: 30px" valign="top">
			</td>
		</tr>
	</table>
	<asp:UpdateProgress ID="IdUpdateProgress" runat="server" AssociatedUpdatePanelID="CuentasUpdatePanel"
		DisplayAfter="0">
		<progresstemplate>
			<div id="progressBackgroundFilter">
			</div>
			<div id="processMessage">
				<asp:Image ID="cuentasImage" runat="server" Height="100%"  ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
	</asp:Image>
			</div>
		</progresstemplate>
	</asp:UpdateProgress>
	
	
</asp:Content>
