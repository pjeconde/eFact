<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Inicio.aspx.cs"
    Inherits="CedWeb.Inicio" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0px" cellspacing="0" border="0">
        <tr>
            <td valign="top" style="width: 800px; padding-top:10px">
                <table style="width: 100%" cellpadding="0px" cellspacing="0" border="0">
                    <tr>
                        <td align="center">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellspacing="0" cellpadding="0" width="800px" style="">
                                <!-- Novedades -->
                                <tr>
                                    <td valign="top" style="height: 142px; padding-left:10px">
                                        <table cellpadding="0" cellspacing="0" border="0" style="height: 142px;">
                                            <tr>
                                                <td style="height: 38px; background-image: url('Imagenes/Ingreso/Box/BoxTL.gif');
                                                    background-repeat: no-repeat; width: 110px;">
                                                </td>
                                                <td style="background-image: url('Imagenes/Ingreso/Box/BoxT.gif'); width: 568px;">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 15px" align="left" valign="middle">
                                                                <img src="Imagenes/Ingreso/Bullet/markerWhite.gif" width="5px" height="10" alt="" />
                                                            </td>
                                                            <td valign="middle">
                                                                <asp:Label ID="LabelNovedades" runat="server" Font-Bold="True" SkinID="TituloPaginaClaro"
                                                                    Text="Novedades"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 103px; background-image: url('Imagenes/Ingreso/Box/BoxTR.gif');">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 208px; width: 110px; background-image: url('Imagenes/Ingreso/Box/Box2DL-FEA.gif');
                                                    background-repeat: no-repeat;" valign="top">
                                                </td>
                                                <td colspan="2" style="background-image: url('Imagenes/Ingreso/Box/Box2DC-Facturas-FEA.gif');
                                                    background-repeat: no-repeat;" class="IngresoBoxTexto" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td colspan="3">
                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td style="width:190px; padding-top:20px; padding-left:90px" align="left">
                                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electr�nica" /><br />
                                                                    </td>
                                                                    <td rowspan="4" style="width:400px" align="left">
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width:22px; padding-top:5px" valign="top">
                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                                                </td>
                                                                                <td style="padding-top:5px">
                                                                                    <asp:Label ID="Label10" runat="server" Text="Ingrese su Factura Electr�nica y genere el archivo XML para Interfacturas (la red de facturas electr�nicas de Interbanking)" SkinID="TituloPagina"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:22px; padding-top:5px" valign="top">
                                                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                                                </td>
                                                                                <td style="padding-top:5px">
                                                                                    <asp:Label ID="Label13" runat="server" Text="Es gratuito, r�pido, f�cil y seguro." SkinID="TituloPagina"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:22px; padding-top:5px" valign="top">
                                                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                                                </td>
                                                                                <td style="padding-top:5px">
                                                                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/FacturaElectronica.aspx" SkinID="LinkGrandeClaro"><b>Cargue gratis su Factura Electr�nica</b></asp:HyperLink>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:22px; padding-top:5px" valign="top">
                                                                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                                                </td>
                                                                                <td style="padding-top:5px">
                                                                                    <asp:Label ID="Label12" runat="server" SkinID="TituloPagina" Text="Facilitamos el cumplimiento del r�gimen normativo de la AFIP"> </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width:22px; padding-top:5px" valign="top">
                                                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                                                                </td>
                                                                                <td style="padding-top:5px">
                                                                                    <asp:Label ID="Label4" runat="server" SkinID="TituloPagina" Text="Integramos la Factura Electr�nica a su sistema de facturaci�n, o contable, a trav�s de un formato est�ndar."></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-top: 5px" align="left">
                                                                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="brown" Text="Factura Electr�nica"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-top: 5px" align="left">
                                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/InterfacturasInterbankingLogo.gif" AlternateText="Logo de interfacturas" /><br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="bottom" align="left" style="padding-left:20px; padding-top:20px">
                                                                        <asp:Label ID="Label1" runat="server" Font-Size="18px" ForeColor="#A52A2A" Font-Bold="True" Text="Nuestras Soluciones"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <!-- Gr�fico y Login -->
                                <tr>
                                    <td valign="top" style=" padding-left:10px; padding-right:10px; padding-bottom:10px">
                                        <table cellpadding="0" cellspacing="0" border="0" style="background-image: url('Imagenes/EsquemaSolucioneseFact3.jpg'); background-repeat:no-repeat; height:322px">
                                            <tr>
                                                <td colspan="4" style="height:125px; width:100%">
                                                </td>
                                                <td rowspan="2" valign="top" style="padding-right:10px">
                                                    <asp:Panel ID="LoginPanel" runat="server">
                                                        <table cellpadding="0" cellspacing="0" border="0" style="height: 142px;">
                                                            <tr>
                                                                <td colspan="3" align="center" style="height: 30px;" valign="middle">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label6" runat="server" Font-Size="12px" Text="Acceda a mejores servicios con su cuenta "></asp:Label>
                                                                            </td>
                                                                            <td style="padding-left: 3px">
                                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electr�nica" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TextoInicioMediano" align="right" style="height:20px; padding-left:10px; padding-right:10px;">
                                                                    Id.Usuario
                                                                </td>
                                                                <td align="left" style="width: 100px;">
                                                                    <asp:TextBox ID="UsuarioTextBox" runat="server" Width="120px" OnTextChanged="UsuarioTextBox_TextChanged" TabIndex="1"></asp:TextBox>
                                                                </td>
                                                                <td rowspan="2" align="left" style="width:31px;">
                                                                    <asp:Button ID="LoginButton" runat="server" Text="Acceder" OnClick="LoginButton_Click" TabIndex="3" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TextoInicioMediano" align="right" style="height:20px; padding-left:10px; padding-right:10px; padding-top:5px">
                                                                    Contrase�a
                                                                </td>
                                                                <td align="left" style="width:100px; padding-right:10px; padding-top:5px">
                                                                    <asp:TextBox ID="PasswordTextBox" runat="server" Width="120px" OnTextChanged="PasswordTextBox_TextChanged" TextMode="Password" TabIndex="2"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center" style="padding-top:5px;">
                                                                    <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=" "></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center" style="padding-top:5px; color: Blue">
                                                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkMedianoClaro">Crear una nueva cuenta</asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center" style="color: Blue">
                                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CuentaOlvidoId.aspx"
                                                                        SkinID="LinkMedianoClaro">�Olvid� su Id.Usuario?</asp:HyperLink>
                                                                    <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/CuentaOlvidoPassword.aspx"
                                                                        SkinID="LinkMedianoClaro">�Olvid� su Contrase�a?</asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" align="center">
                                                                    <a href="javascript:window.external.AddFavorite('http://www.cedeira.com.ar/Inicio.aspx','Cedeira');" style="color:Blue">Agregar a favoritos</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="NevegadorRecomendadoPanel" runat="server" Height="100%" Width="100%" HorizontalAlign="Right" >
                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td colspan="2" style="height:100%">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width:100%">
                                                                    <asp:Label ID="Label2" runat="server" Text="Navegador<br/>recomendado" Font-Size="Smaller" ForeColor="Navy" SkinID="TituloColor1Chico"></asp:Label>
                                                                </td>
                                                                <td style="width:31px">
                                                                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="Imagenes/NavegadorRecomendado.jpg" NavigateUrl="http://www.mozilla-europe.org/es/firefox/" Target="_blank" Text="Logo de Firefox"></asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel1" runat="server" Height="83px" Width="170px">
                                                    </asp:Panel>    
                                                </td>
                                                <td>
                                                    <asp:Panel ID="Panel2" runat="server" Height="83px" Width="102px">
                                                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/FacturaElectronicaSolucionWeb.aspx" SkinID="LinkGrandeClaro" Height="100%" Width="100%"></asp:HyperLink>
                                                    </asp:Panel>    
                                                </td>
                                                <td>
                                                    <asp:Panel ID="Panel3" runat="server" Height="83px" Width="99px">
                                                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/FacturaElectronicaSolucionDeConectividad.aspx" SkinID="LinkGrandeClaro" Height="100%" Width="100%"></asp:HyperLink>
                                                    </asp:Panel>    
                                                </td>
                                                <td style="height:83px; width:100%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom" align="right" colspan="5">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="height:100%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="height:31px">
                                                                <a href="http://validator.w3.org/check?uri=referer">
                                                                    <img alt="Valid XHTML 1.0 Transitional" src="http://www.w3.org/Icons/valid-xhtml10-blue" style="border: 0; width: 88px" />
                                                                </a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="height:31px">
                                                                <a href="http://jigsaw.w3.org/css-validator/check/referer">
                                                                    <img alt="�CSS V�lido!" src="http://jigsaw.w3.org/css-validator/images/vcss-blue" style="border: 0; width: 88px" />
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>                                
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>