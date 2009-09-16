<%@ Page Language="C#" MasterPageFile="~/Facturacion/Electronica/FacturaElectronica.Master"
	AutoEventWireup="true" Codebehind="FacturaWebForm.aspx.cs" Inherits="CedeiraAJAX.Facturacion.Electronica.FacturaWebForm" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
	Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="FacturaContent" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
	runat="server">
	<table border="0" cellpadding="0" cellspacing="0" class="TextComunSinPosicion" style="width: 800px;">
		<tr>
			<td style="vertical-align: top; height: 500px; max-height: 500px; width: 100%;">
				<CR:CrystalReportViewer ID="FacturaCrystalReportViewer" runat="server" CssFilename="../../aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
				 BestFitPage="True"	ToolbarImagesFolderUrl="../../aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar">
				</CR:CrystalReportViewer>
			</td>
		</tr>
	</table>
</asp:Content>
