<%@ Page Language="C#" MasterPageFile="~/CedeiraAJAX.Master" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="CedeiraAJAX.Empresa"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 800px; text-align: left;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <tr>
                        <td style="padding-left: 10px" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="width: 100px; height: 20px;">
                                        <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Empresa"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 10px">
                                <tr>
                                    <td style="padding-left: 22px">
                                        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                                        <asp:Label ID="Label1" runat="server" SkinID="TextoMediano" Text="Nuestra empresa fue fundada en el año 1980 por un grupo de profesionales 
                                            con el objetivo de cubrir las necesidades informáticas que el mercado requería en ese momento. 
                                            Hoy en día, con más de 25 años de experiencia, estamos en condiciones de brindarle a Ud. una solución integrada 
                                            para la gestión, control y desarrollo de negocios."></asp:Label>
                                        <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 22px; padding-top: 10px">
                                        <asp:Label ID="Label3" runat="server" SkinID="TextoMediano" Text="Contamos no solo con personal altamente capacitado, 
                                        sino con el know how necesario adquirido a través de cientos de 
                                        implantaciones en las diversas áreas empresariales. 
                                        Esta conjunción de elementos nos permite satisfacer a nuestros clientes 
                                        en tiempo y forma, permitiendo que obtengan la mejor tasa de retorno de la inversión."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 22px; padding-top: 10px">
                                        <table border="0" cellpadding="0" cellspacing="0" style="">
                                            <tr>
                                                <td style="width: 10px;">
                                                    <asp:Label ID="LabelBulletDesa" runat="server" CssClass="TextoResaltadoSuave" SkinID="TituloColor1Mediano"
                                                        Text="»"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="Label7" runat="server" CssClass="TextoResaltadoSuave" SkinID="TituloColor1Mediano"
                                                            Text="Desarrollos de sistemas a medida: "></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px">
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Productos desarrollados acordes a las necesidades del cliente, para empresas que se ven limitadas por las capacidades del software enlatado."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 22px; padding-top: 10px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 10px;">
                                                    <asp:Label ID="LabelBulletServiciosSF" runat="server" CssClass="TextoResaltadoSuave"
                                                        SkinID="TituloColor1Mediano" Text="»"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="Label9" runat="server" CssClass="TextoResaltadoSuave" SkinID="TituloColor1Mediano"
                                                            Text="Servicio de Software Factory: "></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" SkinID="TextoMediano" Text="Nos permite brindar a nuestros clientes, equipos de desarrollo especializados en la construcción de determinados tipos de aplicaciones."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 22px; padding-top: 10px">
                                        <table border="0" cellpadding="0" cellspacing="0" style="">
                                            <tr>
                                                <td style="width: 10px;">
                                                    <asp:Label ID="LabelBulletSoluciones" runat="server" CssClass="TextoResaltadoSuave"
                                                        SkinID="TituloColor1Mediano" Text="»"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="Label2" runat="server" CssClass="TextoResaltadoSuave" SkinID="TituloColor1Mediano"
                                                            Text="Soluciones llave en mano: "></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" SkinID="TextoMediano" Text="Soluciones probadas, creadas especialmente para el área comercial y financiera."></asp:Label>
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
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
