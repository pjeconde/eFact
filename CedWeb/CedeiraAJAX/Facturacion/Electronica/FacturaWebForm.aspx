<%@ Page Language="C#" MasterPageFile="~/Facturacion/Electronica/FacturaElectronica.Master"
	AutoEventWireup="true" Codebehind="FacturaWebForm.aspx.cs" Inherits="CedeiraAJAX.Facturacion.Electronica.FacturaWebForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
	Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
	
<asp:Content ID="FacturaContent" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
	runat="server">
	<table>
		<tr>
			<td>
				<CR:CrystalReportViewer ID="FacturaCrystalReportViewer" runat="server" CssFilename="../../aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
					HasCrystalLogo="false" HasGotoPageButton="false" HasRefreshButton="false" HasToggleGroupTreeButton="false"
					ToolbarImagesFolderUrl="../../aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar">
				</CR:CrystalReportViewer>
			</td>
		</tr>
	</table>
</asp:Content>
