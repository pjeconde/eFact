<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="CedeiraAJAX.Mensaje"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="NOINDEX" name="ROBOTS" />
    <title>Mensaje del Sitio Web</title>
    <meta content="text-html; charset=utf-8" http-equiv="Content-Type" />
</head>
<body style="background-color: #FFFFFF; text-align: left;">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="3" cellspacing="5" style="width: 410px">
                <tr>
                    <td align="left" class="TextoMensajeTitulo" style="width: 360px" valign="middle">
                        <img alt="Mensaje" src="Imagenes/CajaBrownPeru.ico" />
                        En estos momentos no podemos acceder a la información solicitada.
                    </td>
                </tr>
                <tr>
                    <td class="TextoMensajeDetalle" colspan="2" style="width: 400px">
                        Vuelva a intentar más tarde.
                        <hr style="color: #C0C0C0;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                        <a href="javascript:history.back(1)"><span class="linkOpcion1">Volver a la página anterior</span></a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
