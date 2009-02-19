<%@ Page Language="C#" MasterPageFile="~/Autenticado/CedWebautenticado.master" AutoEventWireup="true" CodeFile="~/Autenticado/Excepcion.aspx.cs" Inherits="CedWeb.Autenticado.Excepcion" %>
<%@ Register Assembly="Janus.Web.UI.v3" Namespace="Janus.Web.UI.Dock" TagPrefix="jwu" %>

<asp:Content ID="ExcepcionContent" ContentPlaceHolderID="ContentPlaceHolderAutenticado" Runat="Server">
    <jwu:UIPanelManager ID="ExceptionUiPanelManager" Style="height: 500px; width: 850px"
        runat="server">
	                <DefaultPanelSettings></DefaultPanelSettings>
	                <Panel Key="uiPanel0" InnerContainerType="UseTemplate" Text="Notificación de excepción" TextAlignment="Center" >
		                <InnerContainerTemplate>
                            <asp:Label ID="ExLabel" runat="server"></asp:Label>
		                </InnerContainerTemplate>
	                </Panel>
    </jwu:UIPanelManager>
</asp:Content>

