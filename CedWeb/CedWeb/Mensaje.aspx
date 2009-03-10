<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mensaje.aspx.cs" Inherits="Mensaje" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="ROBOTS" content="NOINDEX" />
    <title>Mensaje del Sitio Web</title>
    <meta http-equiv="Content-Type" content="text-html; charset=utf-8" />
</head>
<body style="background-color: #FFFFFF; text-align: left;">

    <form id="form1" runat="server">
        <div>
            <table style="width: 410px" border="0" cellpadding="3" cellspacing="5">
                <tr>
                    <td align="left" valign="middle" style="width: 360px" class="TextoMensajeTitulo">
                        <img src="Imagenes/CajaBrownPeru.ico" alt="Mensaje" />
                        En estos momentos no podemos acceder a la información solicitada.
                    </td>
                </tr>
                <tr>
                    <td style="width: 400px" colspan="2" class="TextoMensajeDetalle">
                        Vuelva a intentar más tarde.
                        <hr style="color: #C0C0C0;"/>
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
