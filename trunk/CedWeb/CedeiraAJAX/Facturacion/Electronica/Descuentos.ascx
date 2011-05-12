<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Descuentos.ascx.cs" Inherits="CedeiraAJAX.Facturacion.Electronica.Descuentos" %>

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
			DESCUENTOS GLOBALES
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:UpdatePanel ID="descuentosUpdatePanel" runat="server" ChildrenAsTriggers="true"
				UpdateMode="Conditional">
				<ContentTemplate>
					<asp:GridView ID="descuentosGridView" runat="server" AutoGenerateColumns="False"
						BorderColor="gray" BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70"
						EmptyDataRowStyle-ForeColor="#071F70" EnableViewState="true" Font-Bold="false"
						ForeColor="#071F70" GridLines="Both" HeaderStyle-ForeColor="#A52A2A" OnRowCancelingEdit="descuentosGridView_RowCancelingEdit"
						OnRowCommand="descuentosGridView_RowCommand" OnRowDeleted="descuentosGridView_RowDeleted"
						OnRowDeleting="descuentosGridView_RowDeleting" OnRowEditing="descuentosGridView_RowEditing"
						OnRowUpdated="descuentosGridView_RowUpdated" OnRowUpdating="descuentosGridView_RowUpdating"
						PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
						ShowFooter="true" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto"
						Width="100%">
						<Columns>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Descripci&#243;n del descuento">
								<ItemTemplate>
									<asp:Label ID="lbldescripcion" runat="server" Text='<%# Eval("descripcion_descuento") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtdescripcion" runat="server" Text='<%# Eval("descripcion_descuento") %>'
										Width="90%"></asp:TextBox>
									<asp:RequiredFieldValidator ID="txtdescripcionEditItemRequiredFieldValidator" runat="server"
										ControlToValidate="txtdescripcion" ErrorMessage="Descripción del descuento global en edición no informada"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesEditItem">*</asp:RequiredFieldValidator>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtdescripcion" runat="server" Text='' Width="90%"></asp:TextBox>
									<asp:RequiredFieldValidator ID="txtdescripcionFooterRequiredFieldValidator" runat="server"
										ControlToValidate="txtdescripcion" ErrorMessage="Descripción del descuento global a agregar no informada"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="left" />
								<FooterStyle HorizontalAlign="left" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe total">
								<ItemTemplate>
									<asp:Label ID="lblimporte_descuento" runat="server" Text='<%# Eval("importe_descuento") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtimporte_descuento" runat="server" Text='<%# Eval("importe_descuento") %>'
										Width="80%"></asp:TextBox>
									<asp:RequiredFieldValidator ID="txtimporte_descuentoEditItemRequiredFieldValidator"
										runat="server" ControlToValidate="txtimporte_descuento" ErrorMessage="Importe del descuento global en edición no informado"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesEditItem">*</asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator ID="txtimporte_descuentoEditItemRegularExpressionValidator"
										runat="server" ControlToValidate="txtimporte_descuento" ErrorMessage="Importe total descuento global en edición mal formateado"
										SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DescuentosGlobalesEditItem">*</asp:RegularExpressionValidator>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtimporte_descuento" runat="server" Text='' Width="80%"></asp:TextBox>
									<asp:RegularExpressionValidator ID="txtimporte_descuentoFooterRegularExpressionValidator"
										runat="server" ControlToValidate="txtimporte_descuento" ErrorMessage="Importe total descuento global a agregar mal formateado"
										SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DescuentosGlobalesFooter">*</asp:RegularExpressionValidator>
									<asp:RequiredFieldValidator ID="txtimporte_descuentoFooterRequiredFieldValidator"
										runat="server" ControlToValidate="txtimporte_descuento" ErrorMessage="Importe total descuento global a agregar no informado"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:CommandField CancelText="Cancelar" CausesValidation="true" EditText="Editar"
								HeaderStyle-Font-Bold="false" HeaderText="Edici&#243;n" ShowEditButton="True"
								UpdateText="Actualizar" ValidationGroup="DescuentosGlobalesEditItem">
								<ItemStyle HorizontalAlign="Center" />
							</asp:CommandField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
								<ItemTemplate>
									<asp:LinkButton ID="linkDeletedescuentos" runat="server" CausesValidation="false"
										CommandName="Delete">Borrar</asp:LinkButton>
								</ItemTemplate>
								<FooterTemplate>
									<asp:LinkButton ID="linkAdddescuentos" runat="server" CausesValidation="true" CommandName="Adddescuentos"
										ValidationGroup="DescuentosGlobalesFooter">Agregar</asp:LinkButton>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Center" />
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</ContentTemplate>
			</asp:UpdatePanel>
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
			<asp:UpdateProgress ID="descuentosUpdateProgress" runat="server" AssociatedUpdatePanelID="descuentosUpdatePanel"
				DisplayAfter="0">
				<ProgressTemplate>
					<asp:Image ID="descuentosImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
					</asp:Image>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="DescuentosGlobalesEditValidationSummary" runat="server"
				BorderColor="Gray" BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="DescuentosGlobalesEditItem"></asp:ValidationSummary>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="DescuentosGlobalesFooterValidationSummary" runat="server"
				BorderColor="Gray" BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="DescuentosGlobalesFooter"></asp:ValidationSummary>
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
