<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" 
CodeFile="FacturaElectronicaXML.aspx.cs" Inherits="FacturaElectronicaXML" MaintainScrollPositionOnPostback="true"
Buffer="true"%>

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
            <td valign="top" style="height: 10px; width: 556px;">
            </td>
        </tr>
        <tr>
            <td valign="top" style="padding-left: 10px;">
                <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top" style="">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="LabelTitFacturaElectronica" runat="server" Text="Factura Electrónica"
                                            SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left">
                            <table border="0" style="width: 100%; height: 100%;">
                                <tr>
                                    <td colspan="2" style="height: 47px">
                                        <h2 style="text-align: center">
                                            Lote</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; text-align: right">
                                        <asp:RegularExpressionValidator ID="NroLoteRegularExpressionValidator" runat="server"
                                            ControlToValidate="Id_LoteTextbox" ErrorMessage="error de formateo en número de lote"
                                            ValidationExpression="[0-9]+" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="loteRequiredFieldValidator" runat="server" ErrorMessage="número de lote"
                                            ControlToValidate="Id_LoteTextbox" Display="Static" SetFocusOnError="True">* </asp:RequiredFieldValidator>Número
                                        de lote
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="Id_LoteTextbox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        Cuit canal</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="Cuit_CanalTextBox" runat="server" Width="100%" ReadOnly="True">30690783521</asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        Presta servicios</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:CheckBox ID="Presta_ServCheckBox" runat="server" Width="100%"></asp:CheckBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right; height: 11px;">
                                        <asp:RegularExpressionValidator ID="PtoVentaRegularExpressionValidator" runat="server"
                                            ControlToValidate="Punto_VentaTextBox" ErrorMessage="error de formateo en punto de venta"
                                            ValidationExpression="[0-9]+" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="puntoVentaRequiredFieldValidator" runat="server"
                                            ErrorMessage="punto de venta" ControlToValidate="Punto_VentaTextBox" SetFocusOnError="True">* </asp:RequiredFieldValidator>Punto
                                        de venta</td>
                                    <td style="text-align: left; height: 11px; width: 739px;">
                                        <asp:TextBox ID="Punto_VentaTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <h2 style="text-align: center">
                                            Información vendedor</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        GLN</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="GLN_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Código interno</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="Codigo_Interno_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        <asp:RequiredFieldValidator ID="Razon_Social_VendedorRequiredFieldValidator" runat="server"
                                            ControlToValidate="Razon_Social_VendedorTextBox" ErrorMessage="razón social" SetFocusOnError="True">* </asp:RequiredFieldValidator>Razón
                                        social
                                    </td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="Razon_Social_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        <asp:RequiredFieldValidator ID="CUITVendedorRequiredFieldValidator" runat="server"
                                            ControlToValidate="Cuit_VendedorTextBox" ErrorMessage="CUIT del vendedor" SetFocusOnError="True">* </asp:RequiredFieldValidator>CUIT</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Cuit_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        IVA</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:DropDownList ID="Condicion_IVA_VendedorDropDownList" runat="server" Width="100%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Inicio de actividades</td>
                                    <td style="text-align: left; width: 739px;">
                                        <uc1:DatePickerWebUserControl ID="InicioDeActividadesVendedorDatePickerWebUserControl"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 21px; text-align: right; width: 610px;">
                                        Nombre del contacto</td>
                                    <td style="height: 21px; width: 739px;">
                                        <asp:TextBox ID="Contacto_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; height: 26px; width: 610px;">
                                        Calle</td>
                                    <td style="height: 26px; width: 739px;">
                                        <asp:TextBox ID="Domicilio_Calle_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Número</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Numero_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Piso</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Piso_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Depto</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Depto_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Sector</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Sector_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Torre</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Torre_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Manzana</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Manzana_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        <asp:RequiredFieldValidator ID="Localidad_VendedorRequiredFieldValidator" runat="server"
                                            ControlToValidate="Localidad_VendedorTextBox" ErrorMessage="localidad" SetFocusOnError="True">* </asp:RequiredFieldValidator>Localidad</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Localidad_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; height: 13px; width: 610px;">
                                        Provincia</td>
                                    <td style="height: 13px; width: 739px;">
                                        <asp:DropDownList ID="Provincia_VendedorDropDownList" runat="server" Width="100%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Código Postal</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Cp_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email_VendedorTextBox"
                                            ErrorMessage="error de formateo en mail contacto vendedor" SetFocusOnError="True"
                                            ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Email_VendedorRequiredFieldValidator" runat="server"
                                            ControlToValidate="Email_VendedorTextBox" ErrorMessage="mail contacto del vendedor" SetFocusOnError="True">* </asp:RequiredFieldValidator>Mail
                                        Contacto</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Email_VendedorTextBox" runat="server" Width="100%" AutoCompleteType="Email"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Teléfono contacto</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Telefono_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <h2 style="text-align: center">
                                            Información comprador</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        GLN</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="GLN_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Código interno</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="Codigo_Interno_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Tipo de documento</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:DropDownList ID="Codigo_Doc_Identificatorio_CompradorDropDownList" runat="server"
                                            Width="100%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        <asp:RequiredFieldValidator ID="docCompradorRequiredFieldValidator" runat="server"
                                            ControlToValidate="Nro_Doc_Identificatorio_CompradorTextBox" ErrorMessage="documento del comprador" SetFocusOnError="True">* </asp:RequiredFieldValidator>Nro.
                                        de documento</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="Nro_Doc_Identificatorio_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Denominación
                                    </td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="Denominacion_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        IVA</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:DropDownList ID="Condicion_IVA_CompradorDropDownList" runat="server" Width="100%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Inicio de actividades</td>
                                    <td style="text-align: left; width: 739px;">
                                        <uc1:DatePickerWebUserControl ID="InicioDeActividadesCompradorDatePickerWebUserControl"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 21px; text-align: right; width: 610px;">
                                        Contacto</td>
                                    <td style="height: 21px; width: 739px;">
                                        <asp:TextBox ID="Contacto_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Calle</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Calle_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Número</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Numero_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Piso</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Piso_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Depto</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Depto_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Sector</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Sector_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Torre</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Torre_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Manzana</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Domicilio_Manzana_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Localidad</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Localidad_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; height: 13px; width: 610px;">
                                        Provincia</td>
                                    <td style="height: 13px; width: 739px;">
                                        <asp:DropDownList ID="Provincia_CompradorDropDownList" runat="server" Width="100%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Código Postal</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Cp_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Email_CompradorTextBox"
                                            ErrorMessage="error de formateo en mail contacto comprador" SetFocusOnError="True"
                                            ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$">* </asp:RegularExpressionValidator>Mail Contacto</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Email_CompradorTextBox" runat="server" Width="100%" AutoCompleteType="Email"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 610px;">
                                        Teléfono contacto</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Telefono_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; height: 21px;" colspan="2">
                                        <h2>
                                            Información comprobante</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        Tipo de comprobante</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:DropDownList ID="Tipo_De_ComprobanteDropDownList" runat="server" Width="100%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RegularExpressionValidator ID="Numero_comprobanteRegularExpressionValidator"
                                            runat="server" ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="error de formateo en número de comprobante"
                                            ValidationExpression="[0-9]+" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Numero_ComprobanteRequiredFieldValidator" runat="server"
                                            ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="número de comprobante" SetFocusOnError="True">* </asp:RequiredFieldValidator>Número
                                        de comprobante</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="Numero_ComprobanteTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RequiredFieldValidator ID="FechaEmisionDatePickerRequiredFieldValidator" runat="server"
                                            ControlToValidate="FechaEmisionDatePickerWebUserControl:txt_Date"
                                            ErrorMessage="fecha de emisión" SetFocusOnError="True">* </asp:RequiredFieldValidator>Fecha de emisión</td>
                                    <td style="text-align: left; width: 739px;">
                                        <uc1:DatePickerWebUserControl ID="FechaEmisionDatePickerWebUserControl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RequiredFieldValidator ID="FechaVencimientoRequiredFieldValidator" runat="server"
                                            ControlToValidate="FechaVencimientoDatePickerWebUserControl:txt_Date"
                                            ErrorMessage="fecha de vencimiento" SetFocusOnError="True">* </asp:RequiredFieldValidator>Fecha de vencimiento</td>
                                    <td style="text-align: left; width: 739px;">
                                        <uc1:DatePickerWebUserControl ID="FechaVencimientoDatePickerWebUserControl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right; height: 24px;">
                                        Fecha inicio servicio</td>
                                    <td style="text-align: left; height: 24px; width: 739px;">
                                        <uc1:DatePickerWebUserControl ID="FechaServDesdeDatePickerWebUserControl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        Fecha finalización servicio</td>
                                    <td style="text-align: left; width: 739px;">
                                        <uc1:DatePickerWebUserControl ID="FechaServHastaDatePickerWebUserControl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        CAE</td>
                                    <td style="text-align: left; width: 739px;">
                                        <asp:TextBox ID="CAETextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        Fecha de vencimiento del CAE</td>
                                    <td style="text-align: left; width: 739px;">
                                        &nbsp;<uc1:DatePickerWebUserControl ID="FechaCAEVencimientoDatePickerWebUserControl"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        Fecha de obtención del CAE</td>
                                    <td style="text-align: left; width: 739px;">
                                        <uc1:DatePickerWebUserControl ID="FechaCAEObtencionDatePickerWebUserControl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="2">
                                        <h2>
                                            Detalle</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        Comentarios</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="ComentariosTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center; height: 100%; width: 100%">
                                        <asp:GridView ID="detalleGridView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                            GridLines="Both" BorderStyle="Ridge" OnRowCommand="detalleGridView_RowCommand"
                                            EnableViewState="true" OnRowEditing="detalleGridView_RowEditing" OnRowUpdated="detalleGridView_RowUpdated"
                                            OnRowUpdating="detalleGridView_RowUpdating" OnRowCancelingEdit="detalleGridView_RowCancelingEdit"
                                            OnRowDeleted="detalleGridView_RowDeleted" OnRowDeleting="detalleGridView_RowDeleting"
                                            Width="100%" BorderWidth="5px" ToolTip="El separador de decimales a utilizar es el punto">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Descripción del producto o servicio" ItemStyle-HorizontalAlign="Right"
                                                    FooterStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldescripcion" Text='<%# Eval("descripcion") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtdescripcion" Text='<%# Eval("descripcion") %>' runat="server" Width="100%"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtdescripcion" Text='' runat="server" Width="100%"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Importe total artículo" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblimporte_total_articulo" Text='<%# Eval("importe_total_articulo") %>'
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtimporte_total_articulo" Text='<%# Eval("importe_total_articulo") %>'
                                                            runat="server" Width="100%"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtimporte_total_articulo" Text='' runat="server" Width="100%"></asp:TextBox>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField HeaderText="Edición" ShowEditButton="True" ItemStyle-HorizontalAlign="Center"
                                                    CancelText="Cancelar" UpdateText="Actualizar" EditText="Editar" />
                                                <asp:TemplateField HeaderText="Eliminación / Incorporación" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="linkDeleteDetalle" CommandName="Delete" runat="server">Borrar</asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="linkAddDetalle" CommandName="AddDetalle" runat="server" OnClientClick="GetScollerPosition();">Agregar</asp:LinkButton>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="2">
                                        <h2>
                                            Descuentos Globales</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="2">
                                        En preparación</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="2">
                                        <h2>
                                            Impuestos Globales</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="2">
                                        En preparación</td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="2">
                                        <h2>
                                            Resumen Final</h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RegularExpressionValidator ID="ImporteTotalNetoGravadoRegularExpressionValidator"
                                            runat="server" ControlToValidate="Importe_Total_Neto_Gravado_ResumenTextBox" ErrorMessage="error de formateo en importe total neto gravado"
                                            ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Importe_Total_Neto_Gravado_ResumenRequiredFieldValidator"
                                            runat="server" ControlToValidate="Importe_Total_Neto_Gravado_ResumenTextBox" ErrorMessage="importe total neto gravado" SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe
                                        total neto gravado</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Importe_Total_Neto_Gravado_ResumenTextBox" runat="server" Width="100%"
                                            ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RegularExpressionValidator ID="Importe_Total_Concepto_No_gravadoRegularExpressionValidator"
                                            runat="server" ControlToValidate="Importe_Total_Concepto_No_Gravado_ResumenTextBox" ErrorMessage="error de formateo en importe total de conceptos que no integren el precio neto gravado"
                                            ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Importe_Total_Concepto_No_Gravado_ResumenRequiredFieldValidator"
                                            runat="server" ControlToValidate="Importe_Total_Concepto_No_Gravado_ResumenTextBox" ErrorMessage="importe total de conceptos que no integren el precio neto gravado" SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe
                                        total de conceptos que no integren el precio neto gravado</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Importe_Total_Concepto_No_Gravado_ResumenTextBox" runat="server"
                                            ToolTip="El separador de decimales a utilizar es el punto" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RegularExpressionValidator ID="Importe_Operaciones_ExentasRegularExpressionValidator"
                                            runat="server" ControlToValidate="Importe_Operaciones_Exentas_ResumenTextBox" ErrorMessage="error de formateo en importe de operaciones exentas"
                                            ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Importe_Operaciones_Exentas_ResumenRequiredFieldValidator"
                                            runat="server" ControlToValidate="Importe_Operaciones_Exentas_ResumenTextBox" ErrorMessage="importe de operaciones exentas" SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe
                                        de operaciones exentas</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Importe_Operaciones_Exentas_ResumenTextBox" runat="server" Width="100%"
                                            ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RegularExpressionValidator ID="Impuesto_LiqRegularExpressionValidator" runat="server"
                                            ControlToValidate="Impuesto_Liq_ResumenTextBox" ErrorMessage="error de formateo en impuesto liquidado"
                                            ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Impuesto_Liq_ResumenRequiredFieldValidator" runat="server"
                                            ControlToValidate="Impuesto_Liq_ResumenTextBox" ErrorMessage="impuesto liquidado" SetFocusOnError="True">* </asp:RequiredFieldValidator>Impuesto
                                        liquidado&nbsp;</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Impuesto_Liq_ResumenTextBox" runat="server" Width="100%" ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; text-align: right">
                                        <asp:RegularExpressionValidator ID="Impuesto_Liq_RniRegularExpressionValidator" runat="server"
                                            ControlToValidate="Impuesto_Liq_Rni_ResumenTextBox" ErrorMessage="error de formateo en impuesto liquidado a RNI o percepción a no categorizados"
                                            ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Impuesto_Liq_Rni_ResumenRequiredFieldValidator" runat="server"
                                            ControlToValidate="Impuesto_Liq_Rni_ResumenTextBox" ErrorMessage="impuesto liquidado a RNI o percepción a no categorizados" SetFocusOnError="True">* </asp:RequiredFieldValidator>Impuesto
                                        liquidado a RNI o percepción a no categorizados</td>
                                    <td style="width: 739px">
                                        <asp:TextBox ID="Impuesto_Liq_Rni_ResumenTextBox" runat="server" Width="100%" ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; height: 21px; text-align: right">
                                        <asp:RegularExpressionValidator ID="Importe_Total_FacturaRegularExpressionValidator"
                                            runat="server" ControlToValidate="Importe_Total_Factura_ResumenTextBox"
                                            ErrorMessage="error de formateo en importe total" ValidationExpression="[0-9]+(\.[0-9]+)?" SetFocusOnError="True">* </asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                ID="Importe_Total_Factura_ResumenRequiredFieldValidator" runat="server" ControlToValidate="Importe_Total_Factura_ResumenTextBox" ErrorMessage="importe total" SetFocusOnError="True">* </asp:RequiredFieldValidator>Importe
                                        total
                                    </td>
                                    <td style="height: 21px; width: 739px;">
                                        <asp:TextBox ID="Importe_Total_Factura_ResumenTextBox" runat="server" Width="100%"
                                            ToolTip="El separador de decimales a utilizar es el punto"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 610px; height: 21px; text-align: right">
                                        Observaciones</td>
                                    <td style="height: 21px; width: 739px;">
                                        <asp:TextBox ID="Observaciones_ResumenTextBox" runat="server" Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:ValidationSummary ID="RequeridosValidationSummary" runat="server" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                            ShowMessageBox="True" />
                                    </td>
                                    <td style="height: 100%; width: 100%; text-align: center">
                                        <asp:Button ID="GenerarButton" runat="server" OnClick="GenerarButton_Click" Height="100px"
                                            Width="400px" Text="Enviar archivo XML al e-mail del vendedor" />
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
