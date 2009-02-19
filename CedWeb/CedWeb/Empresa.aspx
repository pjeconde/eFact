<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/Empresa.aspx.cs"
    Inherits="CedWeb.Empresa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">

    <table style="height: 500px; width: 800px; text-align: left;" cellpadding="0" cellspacing="0"
        border="0" class="TextoComun">
        <tr>
            <td valign="top">
                <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                </table>
                <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="padding-left: 10px">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="width: 100px; height: 20px;">
                                        <asp:Label ID="Label5" runat="server" Text="Empresa" Font-Size="Medium" ForeColor="Black"
                                            Font-Bold="True" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="padding-left: 10px" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                                        <asp:Label ID="Label1" runat="server" Text="Nuestra empresa fue fundada en el año 1980 por un grupo de profesionales 
                                            con el objetivo de cubrir las necesidades informáticas que el mercado requería en ese momento. 
                                            Hoy en día, con más de 25 años de experiencia, estamos en condiciones de brindarle a Ud. una solución integrada 
                                            para la gestión, control y desarrollo de negocios." SkinID="TextoMediano"></asp:Label>
                                        <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Contamos no solo con personal altamente capacitado, 
                                        sino con el know how necesario adquirido a través de cientos de 
                                        implantaciones en las diversas áreas empresariales. 
                                        Esta conjunción de elementos nos permite satisfacer a nuestros clientes 
                                        en tiempo y forma, permitiendo que obtengan la mejor tasa de retorno de la inversión."
                                            SkinID="TextoMediano"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 10px;">
                                                    <asp:Label ID="LabelBulletDesa" runat="server" CssClass="TextoResaltadoSuave" Text="»"
                                                        SkinID="TituloColor1Mediano"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="Label7" runat="server" CssClass="TextoResaltadoSuave" Text="Desarrollos de sistemas a medida: "
                                                            SkinID="TituloColor1Mediano"></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10px">
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Productos desarrollados acordes a las necesidades del cliente, para empresas que se ven limitadas por las capacidades del software enlatado."
                                                        SkinID="TextoMediano"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 10px;">
                                                    <asp:Label ID="LabelBulletServiciosSF" runat="server" CssClass="TextoResaltadoSuave"
                                                        Text="»" SkinID="TituloColor1Mediano"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="Label9" runat="server" CssClass="TextoResaltadoSuave" Text="Servicio de Software Factory: "
                                                            SkinID="TituloColor1Mediano"></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Nos permite brindar a nuestros clientes, equipos de desarrollo especializados en la construcción de determinados tipos de aplicaciones."
                                                        SkinID="TextoMediano"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td style="width: 10px;">
                                                    <asp:Label ID="LabelBulletSoluciones" runat="server" CssClass="TextoResaltadoSuave"
                                                        Text="»" SkinID="TituloColor1Mediano"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>
                                                        <asp:Label ID="Label2" runat="server" CssClass="TextoResaltadoSuave" Text="Soluciones llave en mano: "
                                                            SkinID="TituloColor1Mediano"></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Soluciones probadas, creadas especialmente para el área comercial y financiera."
                                                        SkinID="TextoMediano"></asp:Label>
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
            <td valign="top" style="width: 30px">
            </td>
        </tr>
    </table>

</asp:Content>
