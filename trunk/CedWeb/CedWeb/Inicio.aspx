<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Inicio.aspx.cs"
    Inherits="CedWeb.Iniciar"  MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0px" cellspacing="0" border="0">
        <tr>
            <td valign="top" style="width: 800px">
                <table style="width: 100%" cellpadding="0px" cellspacing="0" border="0">
                    <tr>
                        <td style="text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border: 0px">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellspacing="0" cellpadding="0" width="800px" style="">
                                <!--1er reglon de cajas-->
                                <tr>
                                    <td valign="top" style="width: 10px;" align="left">
                                    </td>
                                    <!--Caja de Factura Electronica-->
                                    <td colspan="3" valign="top" style="height: 142px;" align="left">
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
                                                                    <td rowspan="3" style="width: 400px" align="left">
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 22px" valign="top">
                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Label10" runat="server" Text="Ingrese su Factura Electr�nica y genere el archivo XML para Interfacturas (la red de facturas electr�nicas de Interbanking)" SkinID="TituloPagina"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 22px; padding-top: 15px">
                                                                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                                                                </td>
                                                                                <td style="padding-top: 15px">
                                                                                    <asp:Label ID="Label13" runat="server" Text="Es gratuito, r�pido, f�cil y seguro." SkinID="TituloPagina"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 22px; padding-top: 15px">
                                                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                                                                </td>
                                                                                <td style="padding-top: 15px">
                                                                                    <asp:Label ID="Label11" runat="server" Text="Cargue su factura haciendo clic " Font-Bold="true" SkinID="TituloGrande"></asp:Label>
                                                                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/FacturaElectronica.aspx" Font-Bold="true" SkinID="LinkGrandeClaro">aqu�</asp:HyperLink>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-top: 5px" align="left">
                                                                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="brown"
                                                                            Text="Factura Electr�nica"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding-top: 5px" align="left">
                                                                        <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/InterfacturasInterbankingLogo.gif"
                                                                            ImageAlign="Middle" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="bottom">
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 22px" valign="top">
                                                                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                                                                </td>
                                                                                <td valign="top" style="width:250px">
                                                                                    <asp:Label ID="Label12" runat="server" SkinID="TituloPagina" Text="Facilitamos el cumplimiento del r�gimen normativo de la AFIP"> </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 22px" valign="top">
                                                                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <asp:Label ID="Label4" runat="server" SkinID="TituloPagina" Text="Integramos la Factura Electr�nica a su sistema de facturaci�n, o contable, a trav�s de un formato est�ndar."></asp:Label>
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
                                <tr>
                                    <td valign="top" style="height: 10px;" align="left">
                                    </td>
                                </tr>
                                <!--2do reglon de cajas-->
                                <tr>
                                    <td valign="top" style="width: 10px;" align="left">
                                    </td>
                                    <!--Caja de Soluciones de negocio-->
                                    <td valign="top" style="height: 142px;" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 471px; height: 142px;">
                                            <tr>
                                                <td style="height: 38px; background-image: url('Imagenes/Ingreso/Box/BoxTL.gif');
                                                    width: 110px;">
                                                </td>
                                                <td style="background-image: url('Imagenes/Ingreso/Box/BoxT.gif'); width: 258px;">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 15px" align="left" valign="middle">
                                                                <img src="Imagenes/Ingreso/Bullet/markerWhite.gif" width="5px" height="10" alt="" />
                                                            </td>
                                                            <td valign="middle">
                                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" SkinID="TituloPaginaClaro"
                                                                    Text="Soluciones de Negocio"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 103px; background-image: url('Imagenes/Ingreso/Box/BoxTR.gif');">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 104px; width: 110px; background-image: url('Imagenes/Ingreso/Box/Box2DL.gif')"
                                                    valign="top">
                                                </td>
                                                <td colspan="1" style="width: 258px; background-image: url('Imagenes/Ingreso/Box/Box2DC.gif');"
                                                    class="IngresoBoxTexto" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="padding-top: 5px;">
                                                                <asp:Label ID="Label5" runat="server" SkinID="TextoInicioMediano" Text="<b>Le garantizamos las soluciones que usted y su negocio necesitan</b>, a trav�s nuestro excelente equipo de profesionales y la amplia experincia en el mercado inform�tico."
                                                                    Width="241px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="�" SkinID="BulletLinkChico"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:HyperLink SkinID="LinkMedianoClaro" ID="HyperLink2" NavigateUrl="~/Soluciones.aspx"
                                                                                runat="server">ver Soluciones</asp:HyperLink>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="height: 104px; width: 103px; background-image: url('Imagenes/Ingreso/Box/Box2DR.gif')"
                                                    valign="top">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="width: 10px;" align="left">
                                    </td>
                                    <!--Caja de Login-->
                                    <td align="left" valign="top" style="width: 300px; height: 142px;">
                                        <table cellpadding="0" cellspacing="0" border="0" style="height: 142px; width: 300px;">
                                            <tr>
                                                <td colspan="3" align="center" style="height: 30px;" valign="middle">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Font-Size="12px" ForeColor="#404040" Font-Bold="False"
                                                                    Text="Acceda a mejores servicios con su cuenta "></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 3px">
                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electr�nica" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoInicioMediano" align="right" style="height: 20px; padding-left: 10px;
                                                    padding-right: 10px;">
                                                    Usuario
                                                </td>
                                                <td align="left" style="width: 100px;">
                                                    <asp:TextBox ID="UsuarioTextBox" runat="server" Width="120px" OnTextChanged="UsuarioTextBox_TextChanged"
                                                        TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td rowspan="2" align="left" style="width: 31px;">
                                                    <asp:Button ID="LoginButton" runat="server" Text="Acceder" OnClick="LoginButton_Click"
                                                        TabIndex="3" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoInicioMediano" align="right" style="height: 20px; padding-left: 10px;
                                                    padding-right: 10px;">
                                                    Contrase�a
                                                </td>
                                                <td align="left" style="width: 100px; padding-right: 10px;">
                                                    <asp:TextBox ID="PasswordTextBox" runat="server" Width="120px" OnTextChanged="PasswordTextBox_TextChanged"
                                                        TextMode="Password" TabIndex="2"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center" style="height: 10px;">
                                                    <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text="">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center" style="height: 20px;">
                                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkMedianoClaro">Crear una nueva cuenta</asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="width: 9px;" align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <!--3er reglon de cajas-->
                                <tr>
                                    <td valign="top" style="width: 10px;" align="left">
                                    </td>
                                    <!--Caja de Dise�o Web-->
                                    <td valign="top" style="" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" style="height: 142px;">
                                            <tr>
                                                <td style="height: 38px; background-image: url('Imagenes/Ingreso/Box/BoxTL.gif');
                                                    background-repeat: no-repeat; width: 110px;">
                                                </td>
                                                <td style="background-image: url('Imagenes/Ingreso/Box/BoxT.gif'); width: 258px;">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 15px" align="left" valign="middle">
                                                                <img src="Imagenes/Ingreso/Bullet/markerWhite.gif" width="5px" height="10" alt="" />
                                                            </td>
                                                            <td valign="middle">
                                                                <asp:Label ID="LabelTitDesarrolloWeb" runat="server" Font-Bold="True" SkinID="TituloPaginaClaro"
                                                                    Text="Dise�o Web"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 103px; background-image: url('Imagenes/Ingreso/Box/BoxTR.gif');
                                                    background-repeat: no-repeat;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 104px; width: 110px; background-image: url('Imagenes/Ingreso/Box/Box2DL.gif');
                                                    background-repeat: no-repeat;" valign="top">
                                                </td>
                                                <td colspan="2" style="width: 361px; background-image: url('Imagenes/Ingreso/Box/Box2DC-Clientes.gif');
                                                    background-repeat: no-repeat;" class="IngresoBoxTexto" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0" style="background-image: url('Imagenes/Ingreso/Box/DisWeb.gif');
                                                        background-repeat: no-repeat; width: 361px;">
                                                        <tr>
                                                            <td style="width: 160px; padding-top: 5px; height: 119px;" valign="top">
                                                                <asp:Label ID="LabelDesarrolloWeb" runat="server" SkinID="TextoInicioMediano" Text="Dise�amos, desarrollamos y mantenemos sitios web, din�micos e inteligentes, con capacidades de Comercio electr�nico."
                                                                    Width="160px"></asp:Label>
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="�" ForeColor="red"></asp:Label>
                                                                <asp:HyperLink SkinID="LinkMedianoClaro" ID="HyperLinkFactElectronica3" NavigateUrl="~/DesarrolloWeb.aspx"
                                                                    runat="server">ver Dise�o Web</asp:HyperLink>
                                                            </td>
                                                            <td style="width: 201px; height: 119px;" valign="top">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="width: 10px;" align="left">
                                    </td>
                                    <!--Caja de Clientes-->
                                    <td align="left" valign="top" style="width: 300px; height: 142px">
                                        <table cellpadding="0" cellspacing="0" border="0" style="height: 142px; width: 300px">
                                            <tr>
                                                <td style="height: 38px; width: 47px; background-image: url('Imagenes/Ingreso/Box/Box2TL.gif');">
                                                </td>
                                                <td align="left" valign="middle" style="width: 150px; background-image: url('Imagenes/Ingreso/Box/Box2T.gif');">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 15px" align="left" valign="middle">
                                                                <img src="Imagenes/Ingreso/Bullet/markerWhite.gif" width="5px" height="10" alt="" />
                                                            </td>
                                                            <td valign="middle">
                                                                <asp:Label ID="LabelTitClientes" runat="server" Font-Bold="True" SkinID="TituloPaginaClaro"
                                                                    Text="Clientes"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="height: 38px; width: 103px; background-image: url(Imagenes/Ingreso/Box/Box2TR.gif);">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="left" valign="top" style="background-image: url('Imagenes/Ingreso/Box/BoxD-LCR.gif');
                                                    height: 104px;">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 47px">
                                                            </td>
                                                            <td style="width: 200px; text-align: left; padding-top: 5px;">
                                                                <asp:Label ID="LabelClientes" runat="server" SkinID="TextoInicioMediano" Text="<b>Clientes conformes</b> con los productos adquiridos y los servicios prestados por nuestra empresa."></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 47px;">
                                                            </td>
                                                            <td style="text-align: left;">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="�" SkinID="BulletLinkChico"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; text-align: left;">
                                                                            &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Clientes.aspx"
                                                                                SkinID="LinkMedianoClaro">ver Clientes                                                                    </asp:HyperLink>
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
                                    <td valign="top" style="width: 9px;" align="left">
                                    </td>
                                </tr>
                                <!--4to reglon de cajas-->
                                <tr>
                                    <td colspan="2" align="right">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td valign="middle" align="right">
                                                    <asp:Label ID="Label1" runat="server" Text="Navegador<br/>recomendado" Font-Size="Smaller"
                                                        ForeColor="Navy" SkinID="TituloColor1Chico"></asp:Label>
                                                </td>
                                                <td valign="middle" align="right">
                                                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="Imagenes/NavegadorRecomendado.jpg" NavigateUrl="http://www.mozilla-europe.org/es/firefox/" Target="_blank"></asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="width: 10px;" align="left">
                                    </td>
                                    <td align="center" valign="middle" style="width:300px; font-size:smaller">
                                        <a href="javascript:window.external.AddFavorite('http://www.cedeira.com.ar/Inicio.aspx','Cedeira');" style="color:Blue">Agregar a favoritos</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="width: 30px">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
