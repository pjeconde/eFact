﻿<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/EsquemaSolucioneseFact.aspx.cs" Inherits="CedWeb.EsquemaSolucioneseFact" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">

    <table style="height: 500px; width: 800px; text-align: left;" cellpadding="0" cellspacing="0"
        border="0" class="TextoComun">
        <tr>
            <td valign="top">
                <table style="width:100%; padding-top:10px" cellpadding="0" cellspacing="0" border="0">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td valign="top" style="padding-left: 10px">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width:21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height:20px;">
                                        <asp:Label ID="TituloLabel" runat="server" Text="Esquema de Soluciones " SkinID="TituloPagina"></asp:Label>
                                    </td>
                                    <td style="height:20px; padding-left:3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/eFact.jpg" AlternateText="Factura Electrónica"/>
                                    </td>
                                    <td style="height:20px; padding-left:3px">
                                        <asp:Label ID="Label1" runat="server" Text="( gráfico )" Font-Size="Medium" ForeColor="Black" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>  
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
        <tr>
            <td colspan="3" align="center" valign="top" style="padding-top:10px">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/EsquemaSolucioneseFact.jpg" Visible="true"  AlternateText="Soluciones Factura Electronica"/>
            </td>
        </tr>
        <!-- @@@ @@@-->
    </table>
</asp:Content>
