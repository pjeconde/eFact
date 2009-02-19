<%@ Control  Language="C#" AutoEventWireup="true" CodeFile="~/Autenticado/Controles/DatePickerUserControl.ascx.cs" Inherits="CedWeb.Autenticado.Controles.DatePickerUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
        
    <asp:TextBox ID="DateTextBox" runat="server" Width="100"   MaxLength="10" ReadOnly="true"  BorderStyle="Groove" style="text-align:center" />
        <br />
        <asp:Panel ID="Panel1" runat="server" CssClass="popupControl" BorderStyle="solid" BackColor="AliceBlue" style="Z-INDEX: 102; LEFT: 20px; POSITION: absolute; TOP: 64px" 
            BorderWidth="1"><asp:UpdatePanel id="up1" runat="server"  EnableViewState="true"><ContentTemplate>
<CENTER><asp:DropDownList id="ddlMonth" Width="90" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                            <asp:ListItem Value="1">Enero</asp:ListItem>
                            <asp:ListItem Value="2">Febrero</asp:ListItem>
                            <asp:ListItem Value="3">Marzo</asp:ListItem>
                            <asp:ListItem Value="4">Abril</asp:ListItem>
                            <asp:ListItem Value="5">Mayo</asp:ListItem>
                            <asp:ListItem Value="6">Junio</asp:ListItem>
                            <asp:ListItem Value="7">Julio</asp:ListItem>
                            <asp:ListItem Value="8">Agosto</asp:ListItem>
                            <asp:ListItem Value="9">Septiembre</asp:ListItem>
                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                        </asp:DropDownList> <asp:DropDownList id="ddlYear" Width="60" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                        </asp:DropDownList> <asp:Calendar id="Calendar1" Width="150px" runat="server" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" SelectedDate="2007-08-08" Height="150px" FirstDayOfWeek="Sunday" ShowTitle="False" ShowNextPrevMonth="False" OnSelectionChanged="Calendar1_SelectionChanged" ForeColor="#003399" Font-Size="8pt" Font-Names="Verdana" CellPadding="0" DayNameFormat="Shortest">
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <WeekendDayStyle BackColor="#FF6600" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <DayHeaderStyle BackColor="#AAAA99" ForeColor="white" Height="1px" />
                            <TitleStyle BackColor="#AAAA99" Font-Size="10pt" BorderColor="#3366CC" Font-Bold="True"
                                BorderWidth="1px" ForeColor="#AAAA99" Height="25px" />
                        </asp:Calendar> <asp:LinkButton id="lbtnToday" Text=":: Today" runat="server"></asp:LinkButton>    <asp:LinkButton id="lbtnClearDate" Text="::Clear Date" runat="server"></asp:LinkButton> </CENTER>
</ContentTemplate>
</asp:UpdatePanel> </asp:Panel>
    <cc1:PopupControlExtender ID="PopupControlExtender1"  Position="Bottom" runat="server" TargetControlID="DateTextBox"   
            PopupControlID="Panel1"  />
        
        
