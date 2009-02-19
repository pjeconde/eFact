<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Excepcion.aspx.cs"
    Inherits="CedWeb.Excepcion" %>

<%@ Register Assembly="Janus.Web.UI.v3" Namespace="Janus.Web.UI.Dock" TagPrefix="jwu" %>
<asp:Content ID="ExContent" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <jwu:UIPanelManager ID="ExceptionUiPanelManager" Style="height: 500px; width: 850px"
        runat="server">
	                <DefaultPanelSettings></DefaultPanelSettings>
	                <Panel Key="uiPanel0" InnerContainerType="UseTemplate" Text="Notificación de excepción" TextAlignment="Center">
		                <InnerContainerTemplate>
                            <asp:Label ID="ExLabel" runat="server"></asp:Label>
		                </InnerContainerTemplate>
	                </Panel>
    </jwu:UIPanelManager>
</asp:Content>
