<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebasPol.aspx.cs" Inherits="PruebasPol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="12px" Text="EMail Destinatario: "
            Width="128px"></asp:Label>
        <asp:TextBox ID="EMailTextBox" runat="server" Width="400px"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="12px" Text="Asunto:"
            Width="128px"></asp:Label>
        <asp:TextBox ID="AsuntoTextBox" runat="server" Width="400px"></asp:TextBox><br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar mail ( contadores )"
            Width="536px" />&nbsp;</div>
    </form>
</body>
</html>
