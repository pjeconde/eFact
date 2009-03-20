<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="FacturaElectronicaXML.aspx.cs"
    Inherits="FacturaElectronicaXML" MaintainScrollPositionOnPostback="true" Buffer="true"
    UICulture="es" Title="Factura Electrónica Gratis(XML para Interfacturas)" %>

<%@ Register Src="DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl"
    TagPrefix="uc1" %>
<asp:Content ID="XMLContent" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">

    <script type="text/javascript">
    function expandcollapse(obj,row)
    {
        var div = document.getElementById(obj);
        var img = document.getElementById('img' + obj);
        if (div.style.display == "none")
        {
            div.style.display = "block";
            if (row == 'alt')
            {
                img.src = "minus.gif";
            }
            else
            {
                img.src = "minus.gif";
            }
            img.alt = "Cierre para ver otros artículos";
        }
        else
        {
            div.style.display = "none";
            if (row == 'alt')
            {
                img.src = "plus.gif";
            }
            else
            {
                img.src = "plus.gif";
            }
            img.alt = "Expanda para ver impuestos";
        }
    } 
    </script>

    <table style="width: 800px; text-align: left;" cellpadding="0" cellspacing="0" border="0"
        class="TextComunSinPosicion">
        <tr>
            <td valign="top" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table style="width: 800px;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="width: 9px;">
                        </td>
                        <td colspan="3" valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td valign="middle">
                                                    <asp:Image ID="Image1" runat="server" AlternateText="+" ImageUrl="~/Imagenes/CajaBrownPeru.ico">
                                                    </asp:Image>
                                                </td>
                                                <td valign="middle">
                                                    <asp:Label ID="Label2" runat="server" SkinID="TituloPagina" Text="Factura Electrónica"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 782px; vertical-align: middle; text-align: center;"
                                        valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoResaltado" style="text-align: center;">
                                                    UTILIZAR COMPROBANTE PREEXISTENTE
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="XMLFileUpload" runat="server" Height="25px" ></asp:FileUpload>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="FileUploadButton" runat="server" BorderColor="Gray" BorderStyle="NotSet"
                                                                    BorderWidth="1px" CausesValidation="false" Height="25px" OnClick="FileUploadButton_Click"
                                                                    Text="Completar datos automáticamente desde archivo xml seleccionado" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 9px;">
                        </td>
                        <td valign="top" align="center" style="width: 782px; vertical-align: middle; text-align: center;">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="">
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="">
                                                        <tr>
                                                            <td style="width: 370px">
                                                            </td>
                                                            <td style="width: 40px; height: 10px; background-image: url('Imagenes/bgFEA-C.jpg')">
                                                            </td>
                                                            <td style="width: 370px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <!-- TIPO DE COMPROBANTE -->
                                                    <table style="width: 780px" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="width: 240px" align="center" class="TextoResaltado">
                                                                INFORMACIÓN VENDEDOR<br />
                                                                <asp:HyperLink ID="ConfigurarVendedorHyperLink" runat="server" NavigateUrl="~/Vendedor.aspx"
                                                                    SkinID="LinkMedianoClaro" Font-Bold="false">Configurar</asp:HyperLink></td>
                                                            <td style="width: 300px">
                                                                <table style="width: 300px" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td rowspan="2" style="width: 1px; background-color: Gray;">
                                                                        </td>
                                                                        <td colspan="3" style="height: 1px; background-color: Gray;">
                                                                        </td>
                                                                        <td rowspan="2" style="width: 1px; background-color: Gray;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 9px;">
                                                                        </td>
                                                                        <td style="width: 280px">
                                                                            <table border="0" cellpadding="0" cellspacing="0" style="background-color: White;">
                                                                                <tr>
                                                                                    <td style="text-align: center; width: 280px" class="TextoLabelFEAVendedor">
                                                                                        Tipo de comprobante
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 280px">
                                                                                        <asp:DropDownList ID="Tipo_De_ComprobanteDropDownList" runat="server" SkinID="DropDownListCompradorGr">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 5px">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 9px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5" style="height: 1px; background-color: Gray;">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 240px" valign="middle" align="center">
                                                                COMPROBANTE ELECTRÓNICO
                                                                <br />
                                                                EN <asp:DropDownList ID="MonedaComprobanteDropDownList" runat="server" SkinID="DropDownListVendedor" AutoPostBack="True" OnSelectedIndexChanged="MonedaComprobanteDropDownList_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                    <!-- DATOS DEL VENDEDOR -->
                                                    <table style="width: 780px" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="width: 370px;">
                                                            </td>
                                                            <td rowspan="15" style="width: 40px; background-image: url('Imagenes/bgFEA-C.jpg');
                                                                background-repeat: repeat-y;">
                                                            </td>
                                                            <td style="width: 370px;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 10px;">
                                                            </td>
                                                            <td colspan="3">
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Razon Social / Comprobante -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Razon_Social_VendedorTextBox"
                                                                                ErrorMessage="razón social" SetFocusOnError="True">* </asp:RequiredFieldValidator>Razón
                                                                            social:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDet" style="">
                                                                            <asp:TextBox ID="Razon_Social_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td class="TextoLabelFEAVendedor" style="">
                                                                            <asp:RegularExpressionValidator ID="PtoVentaRegularExpressionValidator" runat="server"
                                                                                ControlToValidate="Punto_VentaTextBox" ErrorMessage="error de formateo en punto de venta"
                                                                                ValidationExpression="[0-9]+" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="puntoVentaRequiredFieldValidator" runat="server"
                                                                                ErrorMessage="punto de venta" ControlToValidate="Punto_VentaTextBox" SetFocusOnError="True">* </asp:RequiredFieldValidator>Punto
                                                                            de venta:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Punto_VentaTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Calle -->
                                                        <tr>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            Calle:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Domicilio_Calle_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td class="TextoLabelFEAVendedor">
                                                                            <asp:RegularExpressionValidator ID="Numero_comprobanteRegularExpressionValidator"
                                                                                runat="server" ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="error de formateo en número de comprobante"
                                                                                ValidationExpression="[0-9]+" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="Numero_ComprobanteRequiredFieldValidator" runat="server"
                                                                                ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="número de comprobante"
                                                                                SetFocusOnError="True">* </asp:RequiredFieldValidator>Número de comprobante:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Numero_ComprobanteTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="Debe ser correlativo al último ingresado por Punto de Venta y Tipo de Comprobante. No es necesario ingresar ceros a la izquierda. Si su factura es p.ej.0002-00000005, puede ingresar 5."></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Nro.Calle, Piso y Dpto  / Fecha Emision -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <!-- 25 + 80 + 40 + 60 + 40 + 80 + 40 + 5 padding = 370px -->
                                                                        <td style="width: 25px;">
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorCh">
                                                                            Nro.:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Numero_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorChCh">
                                                                            Piso:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Piso_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorCh">
                                                                            Depto:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDetChCh" style="padding-right: 5px">
                                                                            <asp:TextBox ID="Domicilio_Depto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td class="TextoLabelFEAVendedor">
                                                                            <asp:RequiredFieldValidator ID="FechaEmisionDatePickerRequiredFieldValidator" runat="server"
                                                                                ControlToValidate="FechaEmisionDatePickerWebUserControl:txt_Date" ErrorMessage="fecha de emisión"
                                                                                SetFocusOnError="True">* </asp:RequiredFieldValidator>Fecha de emisión:
                                                                        </td>
                                                                        <td style="padding-top: 3px;">
                                                                            <uc1:DatePickerWebUserControl ID="FechaEmisionDatePickerWebUserControl" runat="server"
                                                                                TextCssClass="DatePickerFecha" />
                                                                        </td>
                                                                        <td align="left" style="width: 95px">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Sector, Torre y Manzana -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <!-- 25 + 80 + 40 + 60 + 40 + 80 + 40 + 5 padding = 370px -->
                                                                        <td style="width: 25px;">
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorCh">
                                                                            Sector:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Sector_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorChCh">
                                                                            Torre:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Torre_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorCh">
                                                                            Manzana:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDetChCh" style="padding-right: 5px">
                                                                            <asp:TextBox ID="Domicilio_Manzana_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            Código interno:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Codigo_Interno_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="<Opcional> Código utilizado para identificar al vendedor dentro de una empresa/organización. (Ej. Cod. de cliente, Proveedor, etc.)">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Localidad -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            <asp:RequiredFieldValidator ID="Localidad_VendedorRequiredFieldValidator" runat="server"
                                                                                ControlToValidate="Localidad_VendedorTextBox" ErrorMessage="localidad" SetFocusOnError="True">* </asp:RequiredFieldValidator>Localidad:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Localidad_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Provincia -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td class="TextoLabelFEAVendedor">
                                                                            Provincia:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDet">
                                                                            <asp:DropDownList ID="Provincia_VendedorDropDownList" runat="server" SkinID="DropDownListVendedor">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Código Postal -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            Código Postal:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Cp_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: GLN -->
                                                        <tr>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            <asp:RegularExpressionValidator ID="GLN_VendedorRegularExpressionValidator" runat="server"
                                                                                ControlToValidate="GLN_VendedorTextBox" ErrorMessage="error de formateo en GLN del vendedor"
                                                                                SetFocusOnError="True" ValidationExpression="[0-9]{13}">* </asp:RegularExpressionValidator>GLN:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="GLN_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Nombre contacto -->
                                                        <tr>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            Nombre contacto:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Contacto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            <asp:RequiredFieldValidator ID="CUITVendedorRequiredFieldValidator" runat="server"
                                                                                ControlToValidate="Cuit_VendedorTextBox" ErrorMessage="CUIT del vendedor" SetFocusOnError="True">* </asp:RequiredFieldValidator>
                                                                            CUIT:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Cuit_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Mail Contacto / CUIT -->
                                                        <tr>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            <asp:RegularExpressionValidator ID="Email_VendedorRegularExpressionValidator" runat="server"
                                                                                ControlToValidate="Email_VendedorTextBox" ErrorMessage="error de formateo en mail contacto vendedor"
                                                                                SetFocusOnError="True" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                                                Width="11px">* </asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="Email_VendedorRequiredFieldValidator" runat="server"
                                                                                ControlToValidate="Email_VendedorTextBox" ErrorMessage="mail contacto del vendedor"
                                                                                SetFocusOnError="True">* </asp:RequiredFieldValidator>Mail Contacto:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Email_VendedorTextBox" runat="server" AutoCompleteType="Email" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td class="TextoLabelFEAVendedor">
                                                                            Condición IB:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDet">
                                                                            <asp:DropDownList ID="Condicion_Ingresos_Brutos_VendedorDropDownList" runat="server"
                                                                                SkinID="DropDownListVendedor">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Teléfono contacto -->
                                                        <tr>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            Teléfono contacto:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="Telefono_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            <asp:RegularExpressionValidator ID="NumeroIBVendedorRegularExpressionValidator" runat="server"
                                                                                ControlToValidate="NroIBVendedorTextBox" ErrorMessage="error de formateo en nro IB del vendedor"
                                                                                SetFocusOnError="True" ValidationExpression="[0-9]{7}-[0-9]{2}|[0-9]{2}-[0-9]{8}-[0-9]{1}|[0-9]{3}-[0-9]{6}-[0-9]{1}">* </asp:RegularExpressionValidator>Número
                                                                            IB:
                                                                        </td>
                                                                        <td class="TextoLabelFEAVendedorDet">
                                                                            <asp:TextBox ID="NroIBVendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="Formatos válidos: XXXXXXX-XX o XX-XXXXXXXX-X o XXX-XXXXXX-X"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: IVA / Inicio de actividades -->
                                                        <tr>
                                                            <td style="">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedor">
                                                                            IVA:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDet">
                                                                            <asp:DropDownList ID="Condicion_IVA_VendedorDropDownList" runat="server" SkinID="DropDownListVendedor">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" align="left">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="">
                                                                    <tr>
                                                                        <td class="TextoLabelFEAVendedor">
                                                                            Inicio de actividades:
                                                                        </td>
                                                                        <td valign="top" align="left" style="padding-top: 3px;">
                                                                            <uc1:DatePickerWebUserControl ID="InicioDeActividadesVendedorDatePickerWebUserControl"
                                                                                TextCssClass="DatePickerFecha" runat="server" />
                                                                        </td>
                                                                        <td align="left" style="width: 95px">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table cellpadding="0" cellspacing="0" border="0">
                                <!-- DATOS DEL LOTE -->
                                <tr>
                                    <td>
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" class="TextoResaltado">
                                                    LOTE
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="NroLoteRegularExpressionValidator" runat="server"
                                                                    ControlToValidate="Id_LoteTextbox" ErrorMessage="error de formateo en número de lote"
                                                                    ValidationExpression="[0-9]+" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="loteRequiredFieldValidator" runat="server" ErrorMessage="número de lote"
                                                                    ControlToValidate="Id_LoteTextbox" Display="Static" SetFocusOnError="True">* </asp:RequiredFieldValidator>Nro.
                                                                de lote:
                                                            </td>
                                                            <td style="" class="TextoLabelFEAVendedorCh">
                                                                <asp:TextBox ID="Id_LoteTextbox" runat="server" SkinID="TextoBoxFEAVendedorDetCh"
                                                                    ToolTip="Es un número correlativo y consecutivo que debe llevarse manualmente e identifica el número de envío del archivo xml que envía a Interfacturas (Upload). Este número NO SE PUEDE REPETIR.">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Cuit canal:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorCh">
                                                                <asp:TextBox ID="Cuit_CanalTextBox" runat="server" ReadOnly="True" SkinID="TextoBoxFEAVendedorDetCh">30690783521</asp:TextBox>
                                                            </td>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Presta servicios:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorChCh" style="text-align: left;">
                                                                <asp:CheckBox ID="Presta_ServCheckBox" runat="server"></asp:CheckBox>
                                                            </td>
                                                            <td style="width: 80px; padding-right: 5px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DEL COMPRADOR -->
                                <tr>
                                    <td>
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="3" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center" class="TextoResaltado">
                                                    INFORMACIÓN COMPRADOR
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="right">
                                                    <table style="width: 370px" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="GLN_CompradorRegularExpressionValidator" runat="server"
                                                                    ControlToValidate="GLN_VendedorTextBox" ErrorMessage="error de formateo en GLN del comprador"
                                                                    SetFocusOnError="True" ValidationExpression="[0-9]{13}">* </asp:RegularExpressionValidator>GLN:
                                                            </td>
                                                            <td style="" class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="GLN_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Código interno:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Codigo_Interno_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="<Opcional> Código utilizado para identificar al comprador dentro de una empresa/organización. (Ej. Cod. de cliente, Proveedor, etc.)"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Tipo de documento:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:DropDownList ID="Codigo_Doc_Identificatorio_CompradorDropDownList" runat="server"
                                                                    SkinID="DropDownListComprador">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RequiredFieldValidator ID="docCompradorRequiredFieldValidator" runat="server"
                                                                    ControlToValidate="Nro_Doc_Identificatorio_CompradorTextBox" ErrorMessage="documento del comprador"
                                                                    SetFocusOnError="True">* </asp:RequiredFieldValidator>Nro. de documento:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Nro_Doc_Identificatorio_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Denominación:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Denominacion_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="Razón Social y Nombre del comprador"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="" class="TextoLabelFEAVendedor">
                                                                Calle:
                                                            </td>
                                                            <td style="" class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Domicilio_Calle_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding-top: 5px; text-align: right;">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="text-align: right;">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedorCh">
                                                                            Nro.:
                                                                        </td>
                                                                        <td style="" class="TextoBoxFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Numero_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorChCh">
                                                                            Piso:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEADetVendedorChCh">
                                                                            <asp:TextBox ID="Domicilio_Piso_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorCh">
                                                                            Depto:
                                                                        </td>
                                                                        <td style="padding-right: 5px" class="TextoBoxFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Depto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding-top: 5px; text-align: right;">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="text-align: right;">
                                                                    <tr>
                                                                        <td style="" class="TextoLabelFEAVendedorCh">
                                                                            Sector:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Sector_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorChCh">
                                                                            Torre:
                                                                        </td>
                                                                        <td style="" class="TextoLabelFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Torre_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox></td>
                                                                        <td style="" class="TextoLabelFEAVendedorCh">
                                                                            Manzana:
                                                                        </td>
                                                                        <td style="padding-right: 5px" class="TextoLabelFEAVendedorDetChCh">
                                                                            <asp:TextBox ID="Domicilio_Manzana_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; height: 10px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td rowspan="20" style="width: 40px; background-image: url('Imagenes/bgFEA-C.jpg');
                                                    background-repeat: repeat-y;">
                                                </td>
                                                <td valign="top" align="left">
                                                    <table style="width: 370px" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="" class="TextoLabelFEAVendedor">
                                                                Localidad:
                                                            </td>
                                                            <td style="" class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Localidad_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Provincia:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:DropDownList ID="Provincia_CompradorDropDownList" runat="server" SkinID="DropDownListComprador">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="" class="TextoLabelFEAVendedor">
                                                                Código Postal:
                                                            </td>
                                                            <td style="" class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Cp_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Contacto:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Contacto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="" class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email_CompradorTextBox"
                                                                    ErrorMessage="error de formateo en mail contacto comprador" SetFocusOnError="True"
                                                                    ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$">* </asp:RegularExpressionValidator>Mail
                                                                Contacto:
                                                            </td>
                                                            <td style="" class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Email_CompradorTextBox" runat="server" AutoCompleteType="Email"
                                                                    SkinID="TextoBoxFEAVendedorDet"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="" class="TextoLabelFEAVendedor">
                                                                Teléfono contacto:
                                                            </td>
                                                            <td style="" class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Telefono_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="" class="TextoLabelFEAVendedor">
                                                                Inicio de actividades:
                                                            </td>
                                                            <td style="padding-top: 3px;" class="">
                                                                <uc1:DatePickerWebUserControl ID="InicioDeActividadesCompradorDatePickerWebUserControl"
                                                                    TextCssClass="DatePickerFecha" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                IVA:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:DropDownList ID="Condicion_IVA_CompradorDropDownList" runat="server" SkinID="DropDownListComprador">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DEL COMPROBANTE -->
                                <tr>
                                    <td>
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="3" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center;" class="TextoResaltado">
                                                    INFORMACIÓN COMPROBANTE
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;" class="TextoResaltado">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" align="left">
                                                    <table style="width: 370px" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RequiredFieldValidator ID="FechaVencimientoRequiredFieldValidator" runat="server"
                                                                    ControlToValidate="FechaVencimientoDatePickerWebUserControl:txt_Date" ErrorMessage="fecha de vencimiento"
                                                                    SetFocusOnError="True">* </asp:RequiredFieldValidator>Fecha de vencimiento:
                                                            </td>
                                                            <td style="padding-top: 3px;">
                                                                <uc1:DatePickerWebUserControl ID="FechaVencimientoDatePickerWebUserControl" runat="server"
                                                                    TextCssClass="DatePickerFecha" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                IVA computable:
                                                            </td>
                                                            <td style="padding-top: 3px;">
                                                                <asp:DropDownList runat="server" ID="IVAcomputableDropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Código de operación:
                                                            </td>
                                                            <td style="padding-top: 8px;">
                                                                <asp:DropDownList runat="server" ID="CodigoOperacionDropDownList">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td rowspan="5" style="width: 40px; background-image: url('Imagenes/bgFEA-C.jpg');
                                                    background-repeat: repeat-y;">
                                                </td>
                                                <td valign="top" align="left">
                                                    <table style="width: 370px" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor" style="">
                                                                Fecha inicio servicio:
                                                            </td>
                                                            <td style="">
                                                                <uc1:DatePickerWebUserControl ID="FechaServDesdeDatePickerWebUserControl" runat="server"
                                                                    TextCssClass="DatePickerFecha" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor" style="">
                                                                Fecha finalización servicio:
                                                            </td>
                                                            <td style="padding-top: 3px;">
                                                                <uc1:DatePickerWebUserControl ID="FechaServHastaDatePickerWebUserControl" runat="server"
                                                                    TextCssClass="DatePickerFecha" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor" style="">
                                                                <asp:RegularExpressionValidator ID="CondicionDePAgoRegularExpressionValidator" runat="server"
                                                                    ControlToValidate="Condicion_De_PagoTextBox" ErrorMessage="error de formateo en condición de pago"
                                                                    SetFocusOnError="True" ValidationExpression="[0-9]?[0-9]?[0-9]?">* </asp:RegularExpressionValidator>Condición
                                                                de pago(en días):</td>
                                                            <td style="padding-top: 3px;">
                                                                <asp:TextBox ID="Condicion_De_PagoTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;" class="TextoResaltado">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DEL DETALLE -->
                                <tr>
                                    <td style="text-align: center" class="TextoResaltado">
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" class="TextoResaltado">
                                                    DETALLE
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Comentarios:
                                                            </td>
                                                            <td class="TextoLabelFEADescrLarga" style="padding: 5px;">
                                                                <asp:TextBox ID="ComentariosTextBox" runat="server" SkinID="TextoBoxFEADescrGr"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; height: 10px;" colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
                                                                <asp:GridView ID="detalleGridView" runat="server" AutoGenerateColumns="False" GridLines="Both"
                                                                    EnableViewState="true" Font-Bold="false" Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                                    BorderColor="Gray" HeaderStyle-ForeColor="#A52A2A" ShowHeader="True" ShowFooter="true"
                                                                    ForeColor="#071F70" EditRowStyle-ForeColor="#071F70" EmptyDataRowStyle-ForeColor="#071F70"
                                                                    PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
                                                                    ToolTip="El separador de decimales a utilizar es el punto" OnRowCommand="detalleGridView_RowCommand"
                                                                    OnRowEditing="detalleGridView_RowEditing" OnRowUpdated="detalleGridView_RowUpdated"
                                                                    OnRowUpdating="detalleGridView_RowUpdating" OnRowCancelingEdit="detalleGridView_RowCancelingEdit"
                                                                    OnRowDeleted="detalleGridView_RowDeleted" OnRowDeleting="detalleGridView_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Descripci&#243;n del producto o servicio">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldescripcion" Text='<%# Eval("descripcion") %>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtdescripcion" runat="server" Text='<%# Eval("descripcion") %>'
                                                                                    TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="txtdescripcionRegularExpressionValidator" runat="server"
                                                                                    ControlToValidate="txtdescripcion" ErrorMessage="Descripción del producto o servicio en edición no informada"
                                                                                    SetFocusOnError="True" ValidationGroup="Grillas">*</asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtdescripcion" runat="server" Text='' TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="txtdescripcionFooterRegularExpressionValidator" runat="server"
                                                                                    ControlToValidate="txtdescripcion" ErrorMessage="Descripción del producto o servicio a agregar no informada"
                                                                                    SetFocusOnError="True" ValidationGroup="DetalleFooter">*</asp:RequiredFieldValidator>
                                                                            </FooterTemplate>
                                                                            <ItemStyle HorizontalAlign="left" />
                                                                            <FooterStyle HorizontalAlign="left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe total art&#237;culo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblimporte_total_articulo" Text='<%# Eval("importe_total_articulo") %>'
                                                                                    runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtimporte_total_articulo" Text='<%# Eval("importe_total_articulo") %>'
                                                                                    runat="server" Width="90%"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="txtimporte_total_articuloRegularExpressionValidator"
                                                                                    runat="server" ControlToValidate="txtimporte_total_articulo" ErrorMessage="Importe total artículo en edición mal formateado"
                                                                                    SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="Grillas">*</asp:RegularExpressionValidator>                                                                                    
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:TextBox ID="txtimporte_total_articulo" Text='' runat="server" Width="90%"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="txtimporte_total_articuloFooterRegularExpressionValidator"
                                                                                    runat="server" ControlToValidate="txtimporte_total_articulo" ErrorMessage="Importe total artículo a agregar mal formateado"
                                                                                    SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="DetalleFooter">*</asp:RegularExpressionValidator>
                                                                            </FooterTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField HeaderStyle-Font-Bold="false" HeaderText="Edici&#243;n" ShowEditButton="True"
                                                                            CancelText="Cancelar" UpdateText="Actualizar" EditText="Editar" CausesValidation="true" ValidationGroup="Grillas">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:CommandField>
                                                                        <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="linkDeleteDetalle" CommandName="Delete" runat="server" CausesValidation="false">Borrar</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:LinkButton ID="linkAddDetalle" runat="server" CausesValidation="true" CommandName="AddDetalle"
                                                                                    ValidationGroup="DetalleFooter">Agregar</asp:LinkButton>
                                                                            </FooterTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
                                                                <asp:ValidationSummary ID="GrillasValidationSummary" runat="server" BorderColor="Gray"
                                                                    BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                                                    ShowMessageBox="True" ValidationGroup="Grillas"></asp:ValidationSummary>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
                                                                <asp:ValidationSummary ID="FooterGrillasValidationSummary" runat="server" BorderColor="Gray"
                                                                    BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                                                    ShowMessageBox="True" ValidationGroup="DetalleFooter"></asp:ValidationSummary>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DE DESCUENTOS GLOBALES -->
                                <tr>
                                    <td style="text-align: center" class="TextoResaltado">
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" class="TextoResaltado">
                                                    DESCUENTOS GLOBALES
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; padding: 3px; font-weight: normal;">
                                                    <asp:GridView ID="descuentosGridView" runat="server" AutoGenerateColumns="False"
                                                        GridLines="Both" EnableViewState="true" Font-Bold="false" Width="100%" BorderStyle="Solid"
                                                        BorderWidth="1px" BorderColor="gray" HeaderStyle-ForeColor="#A52A2A" ShowHeader="True"
                                                        ShowFooter="true" ForeColor="#071F70" EditRowStyle-ForeColor="#071F70" EmptyDataRowStyle-ForeColor="#071F70"
                                                        PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
                                                        ToolTip="El separador de decimales a utilizar es el punto" OnRowCommand="descuentosGridView_RowCommand"
                                                        OnRowEditing="descuentosGridView_RowEditing" OnRowUpdated="descuentosGridView_RowUpdated"
                                                        OnRowUpdating="descuentosGridView_RowUpdating" OnRowCancelingEdit="descuentosGridView_RowCancelingEdit"
                                                        OnRowDeleted="descuentosGridView_RowDeleted" OnRowDeleting="descuentosGridView_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Descripci&#243;n del descuento">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldescripcion" Text='<%# Eval("descripcion_descuento") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtdescripcion" Text='<%# Eval("descripcion_descuento") %>' runat="server"
                                                                        Width="100%"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtdescripcion" Text='' runat="server" Width="100%"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <FooterStyle HorizontalAlign="left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe total descuento">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblimporte_descuento" Text='<%# Eval("importe_descuento") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtimporte_descuento" Text='<%# Eval("importe_descuento") %>' runat="server"
                                                                        Width="100%"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtimporte_descuento" Text='' runat="server" Width="100%"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderStyle-Font-Bold="false" HeaderText="Edici&#243;n" ShowEditButton="True"
                                                                CancelText="Cancelar" UpdateText="Actualizar" EditText="Editar" CausesValidation="false">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkDeletedescuentos" CommandName="Delete" runat="server" CausesValidation="false">Borrar</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:LinkButton ID="linkAdddescuentos" CommandName="Adddescuentos" runat="server"
                                                                        CausesValidation="false">Agregar</asp:LinkButton>
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DE IMPUESTOS GLOBALES -->
                                <tr>
                                    <td style="text-align: center" class="TextoResaltado">
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" class="TextoResaltado">
                                                    IMPUESTOS GLOBALES
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; padding: 3px; font-weight: normal;">
                                                    <asp:GridView ID="impuestosGridView" runat="server" AutoGenerateColumns="False" GridLines="Both"
                                                        EnableViewState="true" Font-Bold="false" Width="100%" BorderStyle="Solid" BorderWidth="1px"
                                                        BorderColor="gray" HeaderStyle-ForeColor="#A52A2A" ShowHeader="True" ShowFooter="true"
                                                        ForeColor="#071F70" EditRowStyle-ForeColor="#071F70" EmptyDataRowStyle-ForeColor="#071F70"
                                                        PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
                                                        ToolTip="El separador de decimales a utilizar es el punto" OnRowCommand="impuestosGridView_RowCommand"
                                                        OnRowEditing="impuestosGridView_RowEditing" OnRowUpdated="impuestosGridView_RowUpdated"
                                                        OnRowUpdating="impuestosGridView_RowUpdating" OnRowCancelingEdit="impuestosGridView_RowCancelingEdit"
                                                        OnRowDeleted="impuestosGridView_RowDeleted" OnRowDeleting="impuestosGridView_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Código del impuesto">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcodigo_impuesto" Text='<%# Eval("descripcion") %>' Width="360px"
                                                                        runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlcodigo_impuestoEdit" runat="server" Width="360px">
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:DropDownList ID="ddlcodigo_impuesto" runat="server" Width="360px">
                                                                    </asp:DropDownList>
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="left" Width="360px" />
                                                                <FooterStyle HorizontalAlign="left" Width="360px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe total impuesto">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblimporte_impuesto" Text='<%# Eval("importe_impuesto") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtimporte_impuesto" Text='<%# Eval("importe_impuesto") %>' runat="server"
                                                                        Width="100%"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox ID="txtimporte_impuesto" Text='' runat="server" Width="100%"></asp:TextBox>
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                            <asp:CommandField HeaderStyle-Font-Bold="false" HeaderText="Edici&#243;n" ShowEditButton="True"
                                                                CancelText="Cancelar" UpdateText="Actualizar" EditText="Editar" CausesValidation="false">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkDeleteImpuesto" CommandName="Delete" runat="server" CausesValidation="false">Borrar</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:LinkButton ID="linkAddImpuesto" CommandName="AddImpuestoGlobal" runat="server"
                                                                        CausesValidation="false">Agregar</asp:LinkButton>
                                                                </FooterTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DE RESUMEN FINAL -->
                                <tr>
                                    <td style="text-align: center">
                                        <table style="width: 782px" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="3" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center;" class="TextoResaltado">
                                                    RESUMEN FINAL
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
                                                        <tr>
                                                            <td style="width: 370px" align="center">
                                                                <table style="width: 335px" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td rowspan="2" style="width: 1px; background-color: Gray;">
                                                                        </td>
                                                                        <td colspan="3" style="height: 1px; background-color: Gray;">
                                                                        </td>
                                                                        <td rowspan="2" style="width: 1px; background-color: Gray;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 9px;">
                                                                        </td>
                                                                        <td style="width: 315px">
                                                                            <table border="0" cellpadding="0" cellspacing="0" style="background-color: White;">
                                                                                <tr>
                                                                                    <td style="width: 120px;" class="TextoLabelFEAVendedorCh">
                                                                                        CAE:
                                                                                    </td>
                                                                                    <td style="width: 10px;">
                                                                                    </td>
                                                                                    <td class="TextoLabelFEAVendedorDet">
                                                                                        <asp:TextBox ID="CAETextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Opcional> MUY IMPORTANTE! Solo si YA TIENE GENERADO EL CAE, debe ingresar este dato. Si omite esta información, se generará una nueva factura ante la AFIP o bien se retornará un error por comprobante ya ingresado."></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 120px;" class="TextoLabelFEAVendedorCh">
                                                                                        Fecha de vencimiento CAE:
                                                                                    </td>
                                                                                    <td style="width: 10px;">
                                                                                    </td>
                                                                                    <td style="padding-top: 3px; text-align: left;">
                                                                                        <uc1:DatePickerWebUserControl ID="FechaCAEVencimientoDatePickerWebUserControl" runat="server"
                                                                                            TextCssClass="DatePickerFecha" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 120px;" class="TextoLabelFEAVendedorCh">
                                                                                        Fecha de obtención CAE:
                                                                                    </td>
                                                                                    <td style="width: 10px;">
                                                                                    </td>
                                                                                    <td style="padding-top: 3px; text-align: left;">
                                                                                        <uc1:DatePickerWebUserControl ID="FechaCAEObtencionDatePickerWebUserControl" runat="server"
                                                                                            TextCssClass="DatePickerFecha" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 5px">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 9px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5" style="height: 1px; background-color: Gray;">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td rowspan="2" style="width: 40px; background-image: url('Imagenes/bgFEA-C.jpg');
                                                    background-repeat: repeat-y;">
                                                </td>
                                                <td valign="top" align="left">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="ImporteTotalNetoGravadoRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Neto_Gravado_ResumenTextBox"
                                                                    ErrorMessage="error de formateo en importe total neto gravado" ValidationExpression="[0-9]+(\.[0-9]+)?"
                                                                    SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="Importe_Total_Neto_Gravado_ResumenRequiredFieldValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Neto_Gravado_ResumenTextBox"
                                                                    ErrorMessage="importe total neto gravado" SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe
                                                                total neto gravado:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Total_Neto_Gravado_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Importe_Total_Concepto_No_gravadoRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Concepto_No_Gravado_ResumenTextBox"
                                                                    ErrorMessage="error de formateo en importe total de conceptos que no integren el precio neto gravado"
                                                                    ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="Importe_Total_Concepto_No_Gravado_ResumenRequiredFieldValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Concepto_No_Gravado_ResumenTextBox"
                                                                    ErrorMessage="importe total de conceptos que no integren el precio neto gravado"
                                                                    SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe total de conceptos
                                                                que no integren el precio neto gravado:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Total_Concepto_No_Gravado_ResumenTextBox" runat="server"
                                                                    SkinID="TextoBoxFEAVendedorDet" ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Importe_Operaciones_ExentasRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Operaciones_Exentas_ResumenTextBox"
                                                                    ErrorMessage="error de formateo en importe de operaciones exentas" ValidationExpression="[0-9]+(\.[0-9]+)?"
                                                                    SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="Importe_Operaciones_Exentas_ResumenRequiredFieldValidator"
                                                                    runat="server" ControlToValidate="Importe_Operaciones_Exentas_ResumenTextBox"
                                                                    ErrorMessage="importe de operaciones exentas" SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe
                                                                de operaciones exentas:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Operaciones_Exentas_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Impuesto_LiqRegularExpressionValidator" runat="server"
                                                                    ControlToValidate="Impuesto_Liq_ResumenTextBox" ErrorMessage="error de formateo en importe IVA Responsable inscripto"
                                                                    SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="Impuesto_Liq_ResumenRequiredFieldValidator" runat="server"
                                                                    ControlToValidate="Impuesto_Liq_ResumenTextBox" ErrorMessage="importe de IVA Responsable inscripto"
                                                                    SetFocusOnError="True">* </asp:RequiredFieldValidator>IVA Responsable inscripto:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Impuesto_Liq_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Impuesto_Liq_RniRegularExpressionValidator" runat="server"
                                                                    ControlToValidate="Impuesto_Liq_Rni_ResumenTextBox" ErrorMessage="error de formateo en impuesto liquidado a RNI o percepción a no categorizados(IVA R.G. 2126)"
                                                                    SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="Impuesto_Liq_Rni_ResumenRequiredFieldValidator" runat="server"
                                                                    ControlToValidate="Impuesto_Liq_Rni_ResumenTextBox" ErrorMessage="impuesto liquidado a RNI o percepción a no categorizados(IVA R.G. 2126)"
                                                                    SetFocusOnError="True">* </asp:RequiredFieldValidator>Impuesto liquidado a RNI
                                                                o percepción a no categorizados(IVA R.G. 2126):
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Impuesto_Liq_Rni_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Importe_Total_Impuestos_MunicipalesResumenRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Impuestos_Municipales_ResumenTextBox"
                                                                    ErrorMessage="error de formateo en importe total impuestos municipales" ValidationExpression="[0-9]+(\.[0-9]+)?"
                                                                    SetFocusOnError="True">*</asp:RegularExpressionValidator>Importe total impuestos
                                                                municipales:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Total_Impuestos_Municipales_ResumenTextBox" runat="server"
                                                                    SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Importe_Total_Impuestos_Nacionales_ResumenTextBoxResumenRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Impuestos_Nacionales_ResumenTextBox"
                                                                    ErrorMessage="error de formateo en importe total impuestos nacionales" ValidationExpression="[0-9]+(\.[0-9]+)?"
                                                                    SetFocusOnError="True">* </asp:RegularExpressionValidator>Importe total impuestos
                                                                nacionales:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Total_Impuestos_Nacionales_ResumenTextBox" runat="server"
                                                                    SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Importe_Total_Ingresos_Brutos_ResumenTextBoxResumenRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Ingresos_Brutos_ResumenTextBox"
                                                                    ErrorMessage="error de formateo en importe total ingresos brutos" ValidationExpression="[0-9]+(\.[0-9]+)?"
                                                                    SetFocusOnError="True">* </asp:RegularExpressionValidator>Importe total ingresos
                                                                brutos:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Total_Ingresos_Brutos_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Importe_Total_Impuestos_Internos_ResumenTextBoxResumenRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Impuestos_Internos_ResumenTextBox"
                                                                    ErrorMessage="error de formateo en importe total impuestos internos" ValidationExpression="[0-9]+(\.[0-9]+)?"
                                                                    SetFocusOnError="True">* </asp:RegularExpressionValidator>Importe total impuestos
                                                                internos:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Total_Impuestos_Internos_ResumenTextBox" runat="server"
                                                                    SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Importe_Total_FacturaRegularExpressionValidator"
                                                                    runat="server" ControlToValidate="Importe_Total_Factura_ResumenTextBox" ErrorMessage="error de formateo en importe total"
                                                                    ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                        ID="Importe_Total_Factura_ResumenRequiredFieldValidator" runat="server" ControlToValidate="Importe_Total_Factura_ResumenTextBox"
                                                                        ErrorMessage="importe total" SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe
                                                                total:
                                                            </td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Importe_Total_Factura_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                <asp:RegularExpressionValidator ID="Tipo_de_cambioRegularExpressionValidator" runat="server"
                                                                    ControlToValidate="Tipo_de_cambioTextBox" ErrorMessage="error de formateo en tipo de cambio"
                                                                    SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)?">* </asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="Tipo_de_cambioRequiredFieldValidator" runat="server"
                                                                    ControlToValidate="Tipo_de_cambioTextBox" ErrorMessage="tipo de cambio" SetFocusOnError="True">* </asp:RequiredFieldValidator>
                                                                <asp:Label ID="Tipo_de_cambioLabel" runat="server" Text="Tipo de cambio:" Visible="false"></asp:Label></td>
                                                            <td class="TextoLabelFEAVendedorDet">
                                                                <asp:TextBox ID="Tipo_de_cambioTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" Visible="false"
                                                                    ToolTip="<Obligatorio para moneda extranjera> El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <br />
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="3" style="height: 1px;">
                                                </td>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px; padding: 5px;">
                                                        <tr>
                                                            <td class="TextoLabelFEAVendedor">
                                                                Observaciones:
                                                            </td>
                                                            <td class="TextoLabelFEADescrLarga">
                                                                <asp:TextBox ID="Observaciones_ResumenTextBox" runat="server" SkinID="TextoBoxFEADescrGr">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <asp:Button ID="GenerarButton" runat="server" OnClick="GenerarButton_Click" Height="60px"
                                            Width="780px" Text="Enviar archivo XML al e-mail del vendedor" BorderColor="Gray"
                                            BorderWidth="1px" BorderStyle="NotSet" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; height: 10px;">
                                        Agradeceríamos a los usuarios del sitio que nos informen sobre dudas, posibles omisiones
                                        y/o errores y que nos envíen las correcciones o sugerencias por correo electrónico
                                        a través de
                                        <asp:HyperLink ID="contactoHyperLink" NavigateUrl="~/Contacto.aspx" runat="server">este formulario</asp:HyperLink>.
                                        Es de suma importancia conocer su opinión. Muchas gracias.
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; width: 780px;" align="left">
                                        <asp:ValidationSummary ID="RequeridosValidationSummary" BorderColor="Gray" BorderWidth="1px"
                                            runat="server" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                            ShowMessageBox="True" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
