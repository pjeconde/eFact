<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerImagenAmpliar.aspx.cs" Inherits="VerImagenAmpliar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CedWeb - Ver imagen ampliada</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 800px; height: 600px;" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <asp:Image ID="ImageVerImagen" Width="800px" Height="600px" ImageUrl="~/Imagenes/NoHayFoto.gif" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
