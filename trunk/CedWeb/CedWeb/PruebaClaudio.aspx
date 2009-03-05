<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebaClaudio.aspx.cs" Inherits="PruebaClaudio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página de prueba de Claudio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
                <tr>
                    <td style="padding-top:10px" align="right">
                        <asp:RegularExpressionValidator ID="NumeroRegularExpressionValidator" runat="server" SetFocusOnError="True"
                            ControlToValidate="NumeroTextBox" ErrorMessage="Numero"
                            ValidationExpression="[0-9]+(\.[0-9]+)?">
                            <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="NumeroRequiredFieldValidator" runat="server"  SetFocusOnError="True"
                            ControlToValidate="NumeroTextBox" ErrorMessage="Numero">
                            <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RequiredFieldValidator>
                        <asp:Label id="Label1" runat="server" Text="Numero"></asp:Label>
                    </td>
                    <td style="padding-top:10px" align="left">
                        <asp:TextBox ID="NumeroTextBox" runat="server" ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" SetFocusOnError="True"
                            ControlToValidate="AlfanumericoTextBox" ErrorMessage="Alfanumerico"
                            ValidationExpression="[A-Za-z\- ,.0-9]*">
                            <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  SetFocusOnError="True"
                            ControlToValidate="AlfanumericoTextBox" ErrorMessage="Alfanumerico">
                            <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RequiredFieldValidator>
                        <asp:Label id="Label2" runat="server" Text="Alfanumerico"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="AlfanumericoTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top:10px">
                        <asp:Button ID="Button1" runat="server" Text="PosBack" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-top:10px">
                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
