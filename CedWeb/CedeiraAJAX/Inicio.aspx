<%@ Page AutoEventWireup="true" Codebehind="Inicio.aspx.cs" Inherits="CedeiraAJAX.Inicio"
    Language="C#" MasterPageFile="~/CedeiraAJAX.Master" Title="Factura electrónica en Argentina (Interfacturas)" %>


<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" width="800px">
        <tr>
            <td rowspan="11">
                <asp:Image ID="Image3" runat="server" AlternateText="Factura Electrónica" ImageUrl="~/Imagenes/eFact-vertical.jpg" />
            </td>
            <td rowspan="11" style="width: 5px">
            </td>
            <td align="center" colspan="2">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="brown"
                    Text="Factura Electrónica"></asp:Label>
            </td>
            <td rowspan="11" style="width: 5px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Image ID="Image4" runat="server" AlternateText="Factura Electrónica" ImageUrl="~/Imagenes/eFact.jpg" />
            </td>
        </tr>
        <tr>
            <td style="width: 22px; height: 16px; padding-top: 5px" valign="top">
                <asp:Image ID="Image1" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
            </td>
            <td align="left" style="height: 22px; padding-top: 5px" valign="top">
                <asp:Label ID="Label10" runat="server" SkinID="TextoMediano" Text="Ingrese su Factura Electrónica y genere el archivo XML para Interfacturas (la red de facturas electrónicas de Interbanking)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 22px; height: 16px; padding-top: 3px" valign="top">
                <asp:Image ID="Image5" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
            </td>
            <td align="left" style="height: 16px; padding-top: 3px" valign="top">
                <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Es gratuito, rápido, fácil y seguro."></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 22px; height: 16px; padding-top: 3px" valign="top">
                <asp:Image ID="Image6" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
            </td>
            <td align="left" style="height: 16px; padding-top: 3px" valign="top">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/FacturaElectronica.aspx"
                    SkinID="LinkMedianoClaro">Cargue gratis su Factura Electrónica con nuestro Servicio Web</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 22px; height: 16px; padding-top: 3px" valign="top">
                <asp:Image ID="Image9" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
            </td>
            <td align="left" style="height: 16px; padding-top: 3px" valign="top">
                <asp:Label ID="Label12" runat="server" SkinID="TextoMediano" Text="Facilitamos el cumplimiento del régimen normativo de la AFIP"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 22px; height: 16px; padding-top: 3px" valign="top">
                <asp:Image ID="Image7" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
            </td>
            <td align="left" style="height: 16px; padding-top: 3px" valign="top">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/FacturaElectronicaSolucionDeConectividad.aspx"
                    SkinID="LinkMedianoClaro">Podemos integrar su sistema de facturación a la red de Interfacturas.</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="width: 22px; height: 16px; padding-top: 3px" valign="top">
                <asp:Image ID="Image8" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
            </td>
            <td align="left" style="height: 16px; padding-top: 3px" valign="top">
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/FacturaElectronicaExcel.aspx"
                    SkinID="LinkMedianoClaro">Usa una planilla Excel como herramienta de facturación.&nbsp;&nbsp;La podemos integrar a la red de Interfacturas</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" valign="middle">
                <asp:Panel ID="LoginPanel" runat="server" BackColor="cornsilk" BorderColor="peachpuff"
                    BorderStyle="Double" BorderWidth="3px" Width="300px">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 142px">
                        <tr>
                            <td align="center" colspan="3" style="height: 30px" valign="middle">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Font-Size="12px" Text="Acceda a mejores servicios con su cuenta "></asp:Label>
                                        </td>
                                        <td style="padding-left: 3px">
                                            <asp:Image ID="Image2" runat="server" AlternateText="Factura Electrónica" ImageUrl="~/Imagenes/eFact.jpg" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="TextoInicioMediano" style="height: 20px; padding-left: 10px;
                                padding-right: 10px;">
                                Id.Usuario
                            </td>
                            <td align="left" style="width: 100px;">
                                <asp:TextBox ID="UsuarioTextBox" runat="server" OnTextChanged="UsuarioTextBox_TextChanged"
                                    TabIndex="1" Width="114px"></asp:TextBox>
                            </td>
                            <td align="left" rowspan="2" style="padding-right: 10px">
                                <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" TabIndex="3"
                                    Text="Acceder" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="TextoInicioMediano" style="height: 20px; padding-left: 10px;
                                padding-right: 10px; padding-top: 5px">
                                Contraseña
                            </td>
                            <td align="left" style="width: 100px; padding-right: 10px; padding-top: 5px">
                                <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="PasswordTextBox_TextChanged"
                                    TabIndex="2" TextMode="Password" Width="114px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-top: 5px;">
                                <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text="&nbsp;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-top: 5px; color: Blue">
                                <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/CuentaCrear.aspx"
                                    SkinID="LinkMedianoClaro">Crear una nueva cuenta</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="color: Blue">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CuentaOlvidoId.aspx"
                                    SkinID="LinkMedianoClaro">¿Olvidó su Id.Usuario?</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/CuentaOlvidoPassword.aspx"
                                    SkinID="LinkMedianoClaro">¿Olvidó su Contraseña?</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-bottom: 8px">
                                <a href="javascript:window.external.AddFavorite('http://www.cedeira.com.ar/Inicio.aspx','Cedeira');"
                                    style="color: Blue">Agregar a favoritos</a>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Font-Size="Smaller" ForeColor="Navy" SkinID="TituloColor1Chico"
                                Text="Navegador<br/>recomendado"></asp:Label>
                        </td>
                        <td style="width: 31px; padding-left: 3px">
                            <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="Imagenes/NavegadorRecomendado.jpg"
                                NavigateUrl="http://www.mozilla-europe.org/es/firefox/" Target="_blank" Text="Logo de Firefox"></asp:HyperLink>
                        </td>
                        <td style="height: 31px; padding-left: 50px">
                            <a href="http://validator.w3.org/check?uri=referer">
                                <img alt="Valid XHTML 1.0 Transitional" src="http://www.w3.org/Icons/valid-xhtml10"
                                    style="border: 0; width: 88px" />
                            </a>
                        </td>
                        <td style="height: 31px; padding-left: 3px">
                            <a href="http://jigsaw.w3.org/css-validator/check/referer">
                                <img alt="¡CSS Válido!" src="http://jigsaw.w3.org/css-validator/images/vcss" style="border: 0;
                                    width: 88px" />
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-bottom: 10px">
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/FacturaElectronicaActividadesAlcanzadas.aspx"
                    SkinID="LinkChicoClaro">Actividades alcanzadas por el Régimen de Factura Electrónica</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/FacturaElectronicaPreguntasFrec.aspx"
                    SkinID="LinkChicoClaro">Preguntas frecuentes</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
