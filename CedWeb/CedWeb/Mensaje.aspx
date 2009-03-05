<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mensaje.aspx.cs" Inherits="Mensaje" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="ROBOTS" content="NOINDEX"/>
    <title>Mensaje del Sitio Web</title>
    <meta http-equiv="Content-Type" content="text-html; charset=Windows-1252"/>
</head>

<script type="text/javascript"> 
function Homepage(){
// in real bits, urls get returned to our script like this:
// res://shdocvw.dll/http_404.htm#http://www.DocURL.com/bar.htm 

	//For testing use DocURL = "res://shdocvw.dll/http_404.htm#https://www.microsoft.com/bar.htm"
	DocURL=document.URL;
	
	//this is where the http or https will be, as found by searching for :// but skipping the res://
	protocolIndex=DocURL.indexOf("://",4);
	
	//this finds the ending slash for the domain server 
	serverIndex=DocURL.indexOf("/",protocolIndex + 3);

	//for the href, we need a valid URL to the domain. We search for the # symbol to find the begining 
	//of the true URL, and add 1 to skip it - this is the BeginURL value. We use serverIndex as the end marker.
	//urlresult=DocURL.substring(protocolIndex - 4,serverIndex);
	BeginURL=DocURL.indexOf("#",1) + 1;
	urlresult=DocURL.substring(BeginURL,serverIndex);
		
	//for display, we need to skip after http://, and go to the next slash
	displayresult=DocURL.substring(protocolIndex + 3 ,serverIndex);
	document.write( '<A HREF="' + escape(urlresult) + '">' + displayresult + "</a>");
}
</script>

<body style="background-color:#FFFFFF; text-align:left;" >
    <form id="form1" runat="server">
    <div>
        <table style="width:410px" border="0" cellpadding="3" cellspacing="5">
            <tr>
                <td align="left" valign="middle" style="width:360px" class="TextoMensajeTitulo">
                    <img src="Imagenes/CajaBrownPeru.ico" alt="Mensaje" /> En estos momentos no podemos acceder a la información solicitada.
                </td>
            </tr>
            <tr>
                <td style="width: 400px" colspan="2" class="TextoMensajeDetalle">
                    Vuelva a intentar mas tarde.
                    <hr style="color:#C0C0C0;">
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
