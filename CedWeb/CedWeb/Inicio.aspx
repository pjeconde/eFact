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
                                                <td style="height: 38px; background-image: url('Imagenes/Ingreso/Box/BoxTL.gif'); background-repeat:no-repeat; width: 110px;">
                                                </td>
                                                <td style="background-image: url('Imagenes/Ingreso/Box/BoxT.gif'); width: 568px;">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 15px" align="Left" valign="middle">
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
                                                <td style="height: 208px; width: 110px; background-image: url('Imagenes/Ingreso/Box/Box2DL-FEA.gif'); background-repeat:no-repeat;"
                                                    valign="top">
                                                </td>
                                                <td colspan="2" style="background-image: url('Imagenes/Ingreso/Box/Box2DC-Facturas-FEA.gif'); background-repeat: no-repeat;" class="IngresoBoxTexto" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td colspan="3;">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 200px; vertical-align: top; padding-top:10px;">
                                                                            <asp:Label ID="LabelFactElectronica" runat="server" SkinID="TextoInicioMediano" Text="<b>Genere GRATIS el archivo XML para Interfacturas.</b><br/>">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td style="width: 261px; vertical-align: top; padding-top:15px;">
                                                                            <asp:Label ID="LabelTitFactElectronica" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="brown" Text="Factura Electrónica"></asp:Label>
                                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/InterfacturasInterbankingLogo.jpg" ImageAlign="Middle"/>
                                                                        </td>
                                                                        <td style="width: 200px; padding-top:10px;">
                                                                            <asp:Label ID="Label4" runat="server" SkinID="TextoInicioMediano" Text="<b>Integramos su sistema de facturación con el régimen de facturación electrónica.<br/></b>">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td style="width: 10px">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:335px; vertical-align: text-top;">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td colspan="2" style="padding-top:5px; text-align:left;">
                                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 320px; padding-top: 5px;">
                                                                                        <asp:Label ID="Label11" runat="server" SkinID="TextoInicioMediano" Text="<b>Rápido, fácil, cargue su factura yá!</b><br/>">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align: left; padding-top: 5px;">
                                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="»" SkinID="BulletLinkChico"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;<asp:HyperLink SkinID="LinkMediano" ID="HyperLink3" NavigateUrl="~/FacturaElectronica.aspx"
                                                                                            runat="server"><b>ver Factura Electrónica</b></asp:HyperLink>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 115px">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 1px;">
                                                            </td>
                                                            <td style="width: 335px;">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td colspan="2" style="padding-top: 5px; text-align:left;">
                                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>
                                                                                    <td style="width: 105px">
                                                                                    </td>
                                                                                    <td style="width: 220px; padding-top: 5px;">
                                                                                        <asp:Label ID="Label12" runat="server" SkinID="TextoInicioMediano" Text="Si su proveedor de sistemas es costoso, perdió el contacto con su proveedor, o no le brinda una solución al nuevo régimen.<br/>">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: left; padding-top: 5px;">
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
                                                            <td style="width: 15px" align="Left" valign="middle">
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
                                                            <td style="padding-top:5px;">
                                                                <asp:Label ID="Label5" runat="server" SkinID="TextoInicioMediano" Text="<b>Le garantizamos las soluciones que usted y su negocio necesitan</b>, a través nuestro excelente equipo de profesionales y la amplia experincia en el mercado informático."
                                                                    Width="241px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="»" SkinID="BulletLinkChico"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;<asp:HyperLink SkinID="LinkMediano" ID="HyperLink2" NavigateUrl="~/Soluciones.aspx"
                                                                                runat="server"><b>ver Soluciones</b></asp:HyperLink>
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
                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/eFact.jpg" />
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
                                                    <asp:TextBox ID="UsuarioTextBox" runat="server" Width="120px" OnTextChanged="UsuarioTextBox_TextChanged" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td rowspan="2" align="left" style="width: 31px;">
                                                    <asp:Button ID="LoginButton" runat="server" Text="Acceder" OnClick="LoginButton_Click" TabIndex="3" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoInicioMediano" align="right" style="height: 20px; padding-left: 10px;
                                                    padding-right: 10px;">
                                                    Contraseña
                                                </td>
                                                <td align="left" style="width: 100px; padding-right: 10px;">
                                                    <asp:TextBox ID="PasswordTextBox" runat="server" Width="120px" OnTextChanged="PasswordTextBox_TextChanged" TextMode="Password" TabIndex="2"></asp:TextBox>
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
                                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/CuentaCrear.aspx" SkinID="LinkMediano">Crear una nueva cuenta</asp:HyperLink>
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
                                    <!--Caja de Diseño Web-->
                                    <td valign="top" style="" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" style="height: 142px;">
                                            <tr>
                                                <td style="height: 38px; background-image: url('Imagenes/Ingreso/Box/BoxTL.gif');
                                                    background-repeat: no-repeat; width: 110px;">
                                                </td>
                                                <td style="background-image: url('Imagenes/Ingreso/Box/BoxT.gif'); width: 258px;">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td style="width: 15px" align="Left" valign="middle">
                                                                <img src="Imagenes/Ingreso/Bullet/markerWhite.gif" width="5px" height="10" alt="" />
                                                            </td>
                                                            <td valign="middle">
                                                                <asp:Label ID="LabelTitDesarrolloWeb" runat="server" Font-Bold="True" SkinID="TituloPaginaClaro"
                                                                    Text="Diseño Web"></asp:Label>
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
                                                            <td style="width: 160px; padding-top:5px;" valign="top">
                                                                <asp:Label ID="LabelDesarrolloWeb" runat="server" SkinID="TextoInicioMediano" Text="Diseñamos, desarrollamos y mantenemos sitios web, dinámicos e inteligentes, con capacidades de Comercio electrónico."
                                                                    Width="160px"></asp:Label>
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="»" ForeColor="red"></asp:Label>
                                                                <asp:HyperLink SkinID="LinkMediano" ID="HyperLinkFactElectronica3" NavigateUrl="~/DesarrolloWeb.aspx"
                                                                    runat="server"><b>ver Diseño Web</b></asp:HyperLink>
                                                            </td>
                                                            <td style="width: 201px" valign="top">
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
                                                            <td style="width: 15px" align="Left" valign="middle">
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
                                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="»" SkinID="BulletLinkChico"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; text-align: left;">
                                                                            &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Clientes.aspx"
                                                                                SkinID="LinkMediano"><b>ver Clientes</b>
                                                                            </asp:HyperLink>
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
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <!--4to reglon de cajas-->
                                <tr>
                                    <td colspan="2" align="right" style="">
                                        <table cellpadding="0" cellspacing="0" border="0" style="">
                                            <tr>
                                                <td valign="middle" align="right" style="">
                                                    <asp:Label ID="Label1" runat="server" Text="Navegador<br/>recomendado" Font-Size="Smaller"
                                                        ForeColor="Navy" SkinID="TituloColor1Chico"></asp:Label>
                                                </td>
                                                <td valign="middle" align="right">
                                                    <asp:Image ID="Image3" runat="server" ImageUrl="Imagenes/NavegadorRecomendado.jpg"
                                                        Height="40px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="width:10px;" align="left">
                                    </td>
                                    <td align="center" valign="middle" style="width: 300px; font-size:smaller">
                                        <a href="javascript:window.external.AddFavorite('http://www.cedeira.com.ar/Inicio.aspx','Cedeira');">Agregar a favoritos</a>
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
