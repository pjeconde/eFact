<%@ Page Language="C#" MasterPageFile="~/Autenticado/CedWebautenticado.master" AutoEventWireup="true"
    CodeFile="~/Autenticado/Bienvenida.aspx.cs" Inherits="CedWeb.Autenticado.Bienvenida" %>

<%@ Register Assembly="Janus.Web.GridEX.v3" Namespace="Janus.Web.GridEX" TagPrefix="jwg" %>
<asp:Content ID="ContentBienvenida" ContentPlaceHolderID="ContentPlaceHolderAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td valign="top">
                <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <asp:Label ID="TituloPaginaLabel" runat="server" Text="Bienvenido/a al Módulo Transaccional de Banca Privada"
                                SkinID="TituloPagina">
                            </asp:Label>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;" colspan="2">
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td align="center">
                            <table>
                                <tr>
                                    <td align="right" style="text-align: center; width: 350px">
                                        <asp:Label ID="TasasVigentesLabel" runat="server" Text="Tasas de Plazos Fijos Transferibles e Intransferibles"
                                            SkinID="TituloMediano"></asp:Label></td>
                                    <td style="width: 25px">
                                    </td>
                                    <td align="center" style="text-align: center; width: 150px">
                                        <asp:Label ID="TasaBadlarTituloLabel" runat="server" Text="Tasa Badlar" SkinID="TituloMediano"></asp:Label></td>
                                </tr>
                    <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td style="width:345px" align="right">
                            <jwg:GridEX ID="RangoTasasGridEX" runat="server" GridLineColor="PeachPuff" AllowColumnDrag="False"
                                AllowPaging="Never" AutomaticSort="False" BackColor="PeachPuff" BorderColor="Brown"
                                BorderStyle="Solid" BorderWidth="1px" ColumnAutoResize="True" Font-Size="Small"
                                GroupByBoxVisible="False" Height="100%" Width="345px" OperationMode="CallBack"
                                Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" TableSpacing="0px" >
<SelectedFormatStyle BorderColor="Brown" ForeColor="Black" Appearance="Flat" VerticalAlign="top" BorderStyle="Solid" BorderWidth="1px" BackColor="PeachPuff" Height="12px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></SelectedFormatStyle>

<PageNavigatorSettings><TopPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</TopPageNavigatorPanels>
<BottomPageNavigatorPanels>
<jwg:GridEXPageNavigatorItemCountPanel></jwg:GridEXPageNavigatorItemCountPanel>
<jwg:GridEXPageNavigatorEmptyPanel Width="100%"></jwg:GridEXPageNavigatorEmptyPanel>
<jwg:GridEXPageNavigatorPreviousBlockPanel Align="right"></jwg:GridEXPageNavigatorPreviousBlockPanel>
<jwg:GridEXPageNavigatorPreviousPagePanel Align="right"></jwg:GridEXPageNavigatorPreviousPagePanel>
<jwg:GridEXPageNavigatorPageSelectorDropDownPanel Align="right"></jwg:GridEXPageNavigatorPageSelectorDropDownPanel>
<jwg:GridEXPageNavigatorNextPagePanel Align="right"></jwg:GridEXPageNavigatorNextPagePanel>
<jwg:GridEXPageNavigatorNextBlockPanel Align="right"></jwg:GridEXPageNavigatorNextBlockPanel>
</BottomPageNavigatorPanels>
</PageNavigatorSettings>

<HeaderFormatStyle BorderColor="Brown" TextAlign="center" ForeColor="White" Appearance="Flat" BorderStyle="Solid" BorderWidth="1px" BackColor="Brown" Height="12px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></HeaderFormatStyle>

<FilterRowFormatStyle ForeColor="WindowText" BackColor="Window" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FilterRowFormatStyle>

<GroupRowIndentJunctionFormatStyle BackColor="Control" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></GroupRowIndentJunctionFormatStyle>

<AlternatingRowFormatStyle BorderStyle="Solid" BorderWidth="1px" BackColor="White" Height="12px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></AlternatingRowFormatStyle>

<NewRowFormatStyle ForeColor="WindowText" BackColor="Window" Height="20px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></NewRowFormatStyle>

<PageNavigatorFormatStyle Appearance="RaisedLight" BackColor="Control" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></PageNavigatorFormatStyle>

<GroupByBoxFormatStyle BackColor="ControlDark" Padding="5px 4px 5px 4px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></GroupByBoxFormatStyle>

<GroupTotalRowFormatStyle BackColor="Control" Height="20px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></GroupTotalRowFormatStyle>

<FocusCellFormatStyle BorderColor="Highlight" BorderStyle="Solid" BorderWidth="1px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FocusCellFormatStyle>

<RowFormatStyle TextAlign="left" ForeColor="Black" VerticalAlign="top" BorderStyle="None" BorderWidth="1px" BackColor="#AAAA99" Padding="0" Height="12px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></RowFormatStyle>
<StoredBuiltInTexts>
<jwg:GridEXStoredBuiltInText GridEXBuiltInText="EmptyGridInfo" Text="Tasas vigentes no disponibles"></jwg:GridEXStoredBuiltInText>
</StoredBuiltInTexts>

<EditorsFormatStyle BackColor="Control"></EditorsFormatStyle>

<GroupRowFormatStyle TextAlign="left" ForeColor="ControlText" VerticalAlign="middle" BackColor="Control" Height="20px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></GroupRowFormatStyle>

<TotalRowFormatStyle BackColor="Window" Height="20px" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></TotalRowFormatStyle>

<GroupByBoxInfoFormatStyle ForeColor="ControlDark" VerticalAlign="middle" BackColor="Control" Padding="4px 4px" Height="100%" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></GroupByBoxInfoFormatStyle>

<RootTable AllowEdit="False" ColumnHeaders="True" TableHeader="False"><FormatConditions>
<jwg:GridEXFormatCondition UseValue1="Pesos" Key="PesosFormatCondition" UseColumn="0">
<FormatStyle BackColor="#DADADA"></FormatStyle>
</jwg:GridEXFormatCondition>
</FormatConditions>
<ColumnSets>
<jwg:GridEXColumnSet Width="350px" Key="ColumnSet1" ColumnWidths="100|100">
<HeaderStyle BackColor="Brown" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></HeaderStyle>
</jwg:GridEXColumnSet>
</ColumnSets>

<HeaderFormatStyle TextAlign="left"></HeaderFormatStyle>
<Columns>
<jwg:GridEXColumn AllowSize="False" InvalidValueAction="DiscardChanges" Width="50px" Key="Moneda.Descr" DataTypeCode="Object" AllowDrag="False" AllowSort="False" Selectable="False" DataMember="Moneda.Descr" DefaultGroupPrefix="Moneda.Descr:" UseHeaderSelector="False" Caption="Moneda">
<CellStyle Width="50px" Padding="3px"></CellStyle>

<HeaderStyle TextAlign="left"></HeaderStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn AllowSize="False" InvalidValueAction="DiscardChanges" Width="115px" Key="Plazo" DataTypeCode="Object" AllowDrag="False" AllowSort="False" DataMember="Plazo" DefaultGroupPrefix="Plazo:" Caption="Plazo">
<CellStyle Width="115px"></CellStyle>

<HeaderStyle TextAlign="center"></HeaderStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn AllowSize="False" InvalidValueAction="DiscardChanges" Width="55px" Key="Minimo" DataTypeCode="Object" AllowDrag="False" AllowSort="False" DataMember="Minimo" FormatString="##0.0000;(-0.0000 );?" DefaultGroupPrefix="Minimo:" Alignment="right" Caption="M&#237;nimo">
<CellStyle TextAlign="right" Width="55px"></CellStyle>

<HeaderStyle TextAlign="center"></HeaderStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn AllowSize="False" InvalidValueAction="DiscardChanges" Width="55px" Key="Maximo" DataTypeCode="Object" AllowDrag="False" AllowSort="False" DataMember="Maximo" FormatString="##0.0000;(-##0.0000 );?" DefaultGroupPrefix="Maximo:" Alignment="right" Caption="M&#225;ximo">
<CellStyle TextAlign="right" Width="55px"></CellStyle>

<HeaderStyle TextAlign="center"></HeaderStyle>
</jwg:GridEXColumn>
<jwg:GridEXColumn AllowSize="False" InvalidValueAction="DiscardChanges" Width="60px" Key="Promedio" DataTypeCode="Object" AllowDrag="False" AllowSort="False" DataMember="Promedio" FormatString="##0.0000;(-##0.0000 );?" DefaultGroupPrefix="Promedio:" Alignment="right" Caption="Promedio">
<CellStyle TextAlign="right" Width="60px"></CellStyle>

<HeaderStyle TextAlign="center"></HeaderStyle>
</jwg:GridEXColumn>
</Columns>
</RootTable>

<ScrollBarFormatStyle ArrowColor="Brown" DarkShadowColor="Brown" BaseColor="PeachPuff"></ScrollBarFormatStyle>

<GroupIndentFormatStyle BackColor="Control" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></GroupIndentFormatStyle>

<PreviewRowFormatStyle ForeColor="Blue" Height="100%" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></PreviewRowFormatStyle>
</jwg:GridEX>                            
                        </td>
                        <td style="width:25px"></td>
                        <td align="left" style="width:150px" valign="top">
                            <table width="100%">
                                <tr valign="top" style="vertical-align:top">
                                    <td align="center" valign="top">
                                        <asp:Label ID="TasaBadlarLabel" runat="server" Width="80px" EnableTheming="False" EnableViewState="False" BackColor="#DADADA" BorderWidth="1px" BorderStyle="Solid" BorderColor="Brown"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:60px">
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                        <asp:HyperLink Text="BOLSAR" ForeColor="Black" ID="BOLSARHyperLink" runat="server"
                                            NavigateUrl="http://www.bolsar.com" Target="_blank" ImageUrl="~/Imagenes/LogoBCBA.gif"></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px">
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td align="left">
                                        <asp:HyperLink Text="Dolar" ForeColor="Black" ID="DolarHyperLink" runat="server"
                                            NavigateUrl="http://cotizadorsuc.bancogalicia.com.ar/?NroSucursal=999" Target="_blank" ImageUrl="~/Imagenes/dolar.GIF"></asp:HyperLink>
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
                <asp:UpdateProgress ID="UpdateProgress" runat="server">
                    <ProgressTemplate>
                        <img src="/Imagenes/GaliciaAnimado.gif" alt="GaliciaAnimado" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
</asp:Content>
