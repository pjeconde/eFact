<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatePickerWebUserControl.ascx.cs" Inherits="CedWeb.DatePickerWebUserControl" %>

<asp:Literal ID="litJS" runat="server"></asp:Literal>
<table cellspacing="0" cellpadding="0" border="0" style="border-style:none; border-width:0px; white-space: nowrap;">
	<tr>
		<td align="center" style="border-style:none; border-width:0px; height: 30px;"><asp:textbox id="txt_Date" runat="server" Width="70"></asp:textbox>&nbsp;</td>
		<td style="border-style:none; border-width:0px; height: 30px;"><asp:image id="imgCalendar" runat="server" ImageUrl="cal/calendar.gif"></asp:image></td>
	</tr>
</table>
