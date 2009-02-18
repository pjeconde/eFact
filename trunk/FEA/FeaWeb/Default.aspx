<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="FeaWeb.Default"
    MasterPageFile="~/FEA.Master" %>

<%@ Register Src="DatePickerWebUserControl.ascx" TagName="DatePickerWebUserControl"
    TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="FEAContentPlaceHolder">

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

    <div>
        <table border="0" style="width: 100%; height: 100%;">
            <tr>
                <td colspan="2" style="height: 47px">
                    <h2 style="text-align: center">
                        Lote</h2>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:RequiredFieldValidator ID="loteRequiredFieldValidator" runat="server" ErrorMessage="número de lote"
                        ControlToValidate="Id_LoteTextbox" Display="None"></asp:RequiredFieldValidator>Número de lote
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
                    <asp:RequiredFieldValidator ID="puntoVentaRequiredFieldValidator" runat="server" ErrorMessage="punto de venta"
                        ControlToValidate="Punto_VentaTextBox" Display="None"></asp:RequiredFieldValidator>Punto de
                    venta</td>
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
                        ControlToValidate="Razon_Social_VendedorTextBox" Display="None" ErrorMessage="razón social"></asp:RequiredFieldValidator>Razón social
                </td>
                <td style="text-align: left; width: 739px;">
                    <asp:TextBox ID="Razon_Social_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 610px;">
                    <asp:RequiredFieldValidator ID="CUITVendedorRequiredFieldValidator" runat="server"
                        ControlToValidate="Cuit_VendedorTextBox" Display="None" ErrorMessage="CUIT del vendedor"></asp:RequiredFieldValidator>CUIT</td>
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
                        ControlToValidate="Localidad_VendedorTextBox" Display="None" ErrorMessage="localidad"></asp:RequiredFieldValidator>Localidad</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Localidad_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; height: 13px; width: 610px;">
                    Provincia</td>
                <td style="height: 13px; width: 739px;">
                    <asp:TextBox ID="Provincia_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 610px;">
                    Código Postal</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Cp_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 610px;">
                    <asp:RequiredFieldValidator ID="Email_VendedorRequiredFieldValidator" runat="server"
                        ControlToValidate="Email_VendedorTextBox" Display="None" ErrorMessage="mail contacto del vendedor"></asp:RequiredFieldValidator>Mail Contacto</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Email_VendedorTextBox" runat="server" Width="100%"></asp:TextBox></td>
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
                        ControlToValidate="Nro_Doc_Identificatorio_CompradorTextBox" Display="None" ErrorMessage="documento del comprador"></asp:RequiredFieldValidator>Nro. de documento</td>
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
                    <asp:TextBox ID="Provincia_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 610px;">
                    Código Postal</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Cp_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 610px;">
                    Mail Contacto</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Email_CompradorTextBox" runat="server" Width="100%"></asp:TextBox></td>
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
                    <asp:RequiredFieldValidator ID="Numero_ComprobanteRequiredFieldValidator" runat="server"
                        ControlToValidate="Numero_ComprobanteTextBox" Display="None" ErrorMessage="número de comprobante"></asp:RequiredFieldValidator>Número de comprobante</td>
                <td style="text-align: left; width: 739px;">
                    <asp:TextBox ID="Numero_ComprobanteTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 610px; text-align: right">
                    <asp:RequiredFieldValidator ID="FechaEmisionDatePickerRequiredFieldValidator" runat="server"
                        ControlToValidate="FechaEmisionDatePickerWebUserControl:txt_Date" Display="None"
                        ErrorMessage="fecha de emisión"></asp:RequiredFieldValidator>Fecha de emisión</td>
                <td style="text-align: left; width: 739px;">
                    <uc1:DatePickerWebUserControl ID="FechaEmisionDatePickerWebUserControl" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 610px; text-align: right">
                    Fecha de vencimiento</td>
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
                <td colspan="2" style="text-align: center; height: 198px;">
                    <asp:GridView ID="detalleGridView" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                        GridLines="Horizontal" BorderStyle="Double" OnRowCommand="detalleGridView_RowCommand"
                        EnableViewState="true" OnRowEditing="detalleGridView_RowEditing" OnRowUpdated="detalleGridView_RowUpdated"
                        OnRowUpdating="detalleGridView_RowUpdating" OnRowCancelingEdit="detalleGridView_RowCancelingEdit"
                        OnRowDeleted="detalleGridView_RowDeleted" OnRowDeleting="detalleGridView_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Descripción del producto o servicio" ItemStyle-HorizontalAlign="Right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lbldescripcion" Text='<%# Eval("descripcion") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtdescripcion" Text='<%# Eval("descripcion") %>' runat="server"></asp:TextBox>
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
                                        runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtimporte_total_articulo" Text='' runat="server" Width="100%"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Editar" ShowEditButton="True" />
                            <asp:TemplateField HeaderText="Borrar">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkDeleteDetalle" CommandName="Delete" runat="server">Borrar</asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="linkAddDetalle" CommandName="AddDetalle" runat="server">Agregar</asp:LinkButton>
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
                    <asp:RequiredFieldValidator ID="Importe_Total_Neto_Gravado_ResumenRequiredFieldValidator"
                        runat="server" ControlToValidate="Importe_Total_Neto_Gravado_ResumenTextBox"
                        Display="None" ErrorMessage="importe total neto gravado"></asp:RequiredFieldValidator>Importe total neto gravado</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Importe_Total_Neto_Gravado_ResumenTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 610px; text-align: right">
                    <asp:RequiredFieldValidator ID="Importe_Total_Concepto_No_Gravado_ResumenRequiredFieldValidator"
                        runat="server" ControlToValidate="Importe_Total_Concepto_No_Gravado_ResumenTextBox"
                        Display="None" ErrorMessage="importe total de conceptos que no integren el precio neto gravado"></asp:RequiredFieldValidator>Importe total de conceptos que no integren el precio neto gravado</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Importe_Total_Concepto_No_Gravado_ResumenTextBox" runat="server"
                        Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 610px; text-align: right">
                    <asp:RequiredFieldValidator ID="Importe_Operaciones_Exentas_ResumenRequiredFieldValidator"
                        runat="server" ControlToValidate="Importe_Operaciones_Exentas_ResumenTextBox"
                        Display="None" ErrorMessage="importe de operaciones exentas"></asp:RequiredFieldValidator>Importe de operaciones exentas</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Importe_Operaciones_Exentas_ResumenTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 610px; text-align: right">
                    <asp:RequiredFieldValidator ID="Impuesto_Liq_ResumenRequiredFieldValidator" runat="server"
                        ControlToValidate="Impuesto_Liq_ResumenTextBox" Display="None" ErrorMessage="impuesto liquidado"></asp:RequiredFieldValidator>Impuesto liquidado&nbsp;</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Impuesto_Liq_ResumenTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 610px; text-align: right">
                    Impuesto liquidado a RNI o 
                    <asp:RequiredFieldValidator ID="Impuesto_Liq_Rni_ResumenRequiredFieldValidator" runat="server"
                        ControlToValidate="Impuesto_Liq_Rni_ResumenTextBox" Display="None" ErrorMessage="impuesto liquidado a RNI o percepción a no categorizados"></asp:RequiredFieldValidator>percepción a no categorizados</td>
                <td style="width: 739px">
                    <asp:TextBox ID="Impuesto_Liq_Rni_ResumenTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 610px; height: 21px; text-align: right">
                    <asp:RequiredFieldValidator ID="Importe_Total_Factura_ResumenRequiredFieldValidator"
                        runat="server" ControlToValidate="Importe_Total_Factura_ResumenTextBox" Display="None"
                        ErrorMessage="importe total"></asp:RequiredFieldValidator>Importe total
                </td>
                <td style="height: 21px; width: 739px;">
                    <asp:TextBox ID="Importe_Total_Factura_ResumenTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 610px; height: 21px; text-align: right">
                    Observaciones</td>
                <td style="height: 21px; width: 739px;">
                    <asp:TextBox ID="Observaciones_ResumenTextBox" runat="server" Width="100%"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 610px; height: 21px; text-align: right">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Faltan los siguientes campos obligatorios:" ShowMessageBox="True" />
                </td>
                <td colspan="2" style="height: 21px; width: 100%; text-align: right">
                    &nbsp;<asp:Button ID="GenerarButton" runat="server" OnClick="GenerarButton_Click"
                        Text="Enviar archivo XML por correo" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
