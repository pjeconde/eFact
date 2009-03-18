<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebaClaudio.aspx.cs" Inherits="PruebaClaudio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página de prueba de Claudio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="vertical-align:middle">
            <asp:Button ID="Button1" runat="server" Text="Envia mail" OnClick="Button1_Click" />
            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
