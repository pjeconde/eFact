<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prueba.aspx.cs" Inherits="Prueba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pagina de pruebas</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="border:none;">
    <table cellpadding="0" cellspacing="0" border="0px" style="height: 38px; background-color: Silver">
    <tr>
    <td>
        <table cellpadding="0" cellspacing="0" border="0px" style="height: 38px; text-align:left">
            <tr>
                <td style="height: 38px; width: 110px; background-image: url('Imagenes/Ingreso/Box/BoxTL.gif'); border-left: 0px;">
                </td>
                <td style="background-image: url('Imagenes/Ingreso/Box/BoxT.gif'); width:258px; height:38px;">
                    <img src="Imagenes/Ingreso/Bullet/markerWhite.gif" width="5px" height="10px" alt="" />&nbsp;
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" SkinID="TituloPaginaClaro" Text="Pruebas"></asp:Label>
                </td>
                <td style="height:38px; width:103px; background-image:url('Imagenes/Ingreso/Box/BoxTR.gif')">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="2">
                    <asp:HyperLink ID="VolverAFEAHyperLink" runat="server" NavigateUrl="~/FacturaElectronica8.aspx" SkinID="LinkMedianoClaro">
                    Factura Electrónica - prueba de un error</asp:HyperLink>
                </td>
            </tr>

        </table>
    </td>
    </tr>
    </table>    
    </div>
    </form>
</body>
</html>
