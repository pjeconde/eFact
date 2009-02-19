<%@ Control AutoEventWireup="true" CodeFile="~/Autenticado/Controles/LogUserControl.ascx.cs"
	Inherits="CedWeb.Autenticado.Controles.LogUserControl" Language="C#" %>
<%@ Register Assembly="Janus.Web.GridEX.v3" Namespace="Janus.Web.GridEX" TagPrefix="jwg" %>

<table style="text-align: right; vertical-align: middle">
	<tr>
		<td align="center">
			<jwg:gridex id="LogGridEX" runat="server" allowcolumndrag="False" allowpaging="Never" 
				automaticsort="False" emptygridtext="No hay elementos para mostrar"
				font-bold="False" font-italic="False" font-overline="False" font-strikeout="False"
				font-underline="False" gridlinecolor="ScrollBar"  groupbyboxvisible="False" height="100%"
				selectionmode="NoSelection" width="100%">
<SelectedFormatStyle ForeColor="HighlightText" VerticalAlign="top" BackColor="Highlight" Height="20px"></SelectedFormatStyle>

<PageNavigatorSettings><TopPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</TopPageNavigatorPanels>
<BottomPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</BottomPageNavigatorPanels>
</PageNavigatorSettings>

<HeaderFormatStyle BorderColor="GrayText" ForeColor="ControlText" Appearance="RaisedLight" BorderStyle="Solid" BorderWidth="1px" BackColor="Control" Height="20px"></HeaderFormatStyle>

<FilterRowFormatStyle ForeColor="WindowText" BackColor="Window"></FilterRowFormatStyle>

<GroupRowIndentJunctionFormatStyle BackColor="Control"></GroupRowIndentJunctionFormatStyle>

<AlternatingRowFormatStyle BorderStyle="Solid" BorderWidth="1px" BackColor="Control" Height="20px"></AlternatingRowFormatStyle>

<NewRowFormatStyle ForeColor="WindowText" BackColor="Window" Height="20px"></NewRowFormatStyle>

<PageNavigatorFormatStyle Appearance="RaisedLight" BackColor="Control"></PageNavigatorFormatStyle>

<GroupByBoxFormatStyle BackColor="ControlDark" Padding="5px 4px 5px 4px"></GroupByBoxFormatStyle>

<GroupTotalRowFormatStyle BackColor="Control" Height="20px"></GroupTotalRowFormatStyle>

<FocusCellFormatStyle BorderColor="Highlight" BorderStyle="Solid" BorderWidth="1px"></FocusCellFormatStyle>

<RowFormatStyle TextAlign="left" ForeColor="WindowText" VerticalAlign="top" BorderStyle="Solid" BorderWidth="1px" BackColor="Window" Height="20px"></RowFormatStyle>
<StoredBuiltInTexts>
<jwg:GridEXStoredBuiltInText GridEXBuiltInText="EmptyGridInfo" Text="No hay elementos para mostrar"></jwg:GridEXStoredBuiltInText>
</StoredBuiltInTexts>

<EditorsFormatStyle BackColor="Control"></EditorsFormatStyle>

<GroupRowFormatStyle TextAlign="left" ForeColor="ControlText" VerticalAlign="middle" BackColor="Control" Height="20px"></GroupRowFormatStyle>

<TotalRowFormatStyle BackColor="Window" Height="20px"></TotalRowFormatStyle>

<GroupByBoxInfoFormatStyle ForeColor="ControlDark" VerticalAlign="middle" BackColor="Control" Padding="4px 4px" Height="100%"></GroupByBoxInfoFormatStyle>

<RootTable AllowAddNew="False" AllowEdit="False" Caption="Log" AllowDelete="False" TableHeader="False"><Columns>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="70px" Key="Fecha" DataTypeCode="Object" EditType="NoEdit" DataMember="Fecha" FormatString="dd/MM/yyyy" DefaultGroupPrefix="Fecha:" Caption="Fecha">
<CellStyle Width="70px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="130px" Key="Usuario.Nombre" DataTypeCode="Object" EditType="NoEdit" DataMember="Usuario.Nombre" DefaultGroupPrefix="Nombre:" Caption="Nombre">
<CellStyle Width="130px" TextAlign="Center"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="80px" Key="Evento.Descr" DataTypeCode="Object" EditType="NoEdit" DataMember="Evento.Descr" DefaultGroupPrefix="Evento:" Caption="Evento">
<CellStyle Width="80px" TextAlign="Center" ></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="140px" Key="Estado" DataTypeCode="Object" EditType="NoEdit" DataMember="Estado" DefaultGroupPrefix="Estado:" Caption="Estado">
<CellStyle Width="140px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="218px" Key="Comentario" DataTypeCode="Object" EditType="NoEdit" DataMember="Comentario" DefaultGroupPrefix="Comentario:" Caption="Comentario">
<CellStyle Width="218px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="40px" Key="IdLog" DataTypeCode="Object" EditType="NoEdit" DataMember="IdLog" DefaultGroupPrefix="IdLog:" Caption="IdLog">
<CellStyle Width="40px" TextAlign="Center"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="70px" Key="Grupo.Descr" DataTypeCode="Object" EditType="NoEdit" DataMember="Grupo.Descr" DefaultGroupPrefix="Grupo:" Caption="Grupo">
<CellStyle Width="70px"></CellStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn InvalidValueAction="DiscardChanges" Width="70px" Key="Usuario.IdUsuario" DataTypeCode="Object" EditType="NoEdit" DataMember="Usuario.IdUsuario" DefaultGroupPrefix="Nombre:" Caption="Legajo">
<CellStyle Width="70px" TextAlign="Center"></CellStyle>
</jwg:GridEXColumn>
</Columns>
</RootTable>

<GroupIndentFormatStyle BackColor="Control"></GroupIndentFormatStyle>

<PreviewRowFormatStyle ForeColor="Blue" Height="100%"></PreviewRowFormatStyle>
</jwg:gridex>
		</td>
	</tr>
</table>
