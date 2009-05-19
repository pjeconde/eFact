<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CedFCI.aspx.cs"
    Inherits="CedWeb.CedFCI" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado"
    runat="Server">
    <table style="height: 500px; width: 800px" cellpadding="0" cellspacing="0" border="0"
        class="TextoComun">
        <tr>
            <td style="width: 780px; padding-left: 10px; padding-top: 10px" valign="top">
                <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="left" valign="top">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 22px; height: 20px;">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/CajaBrownPeru.ico" AlternateText="o" />
                                    </td>
                                    <td style="height: 20px">
                                        <asp:Label ID="CedSTtituloLabel" runat="server" Text="Sistema de Administración de Fondos Comunes de Inversión"
                                            SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="padding-top:10px">
                                        El sistema de Administración de FCIs es una herramienta de <b>administración</b> de las carteras de inversión de los fondos y de <b>cálculo</b> de los valores de cuotaparte.
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left">
                                        Lleva la <b>contabilidad</b> y facilita el cumplimiento de las <b>normas</b> establecidas por el <b>organismo de fiscalización</b> y de los <b>reglamentos de gestión</b>.
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="center" style="padding-top:20px">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="Imagenes/CedFCI-Tablero.jpg" Width="692px"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:20px; font-size:14px; font-weight:bold">
                                        Beneficios de la solución
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:5px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Calcula los valores de cuotaparte</b> de las clases emitidas para todos los fondos, en forma automática.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Facilita el ingreso de novedades</b> (operaciones, cierres de cambio, precios, tasas de cuentas remuneradas, suscripciones y rescates, etc).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Facilita la configuración de datos básicos</b> (fondos, clases, fees de administración, plan de cuentas, especies, entidades, monedas, etc).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Provee un repositorio único, para facilitar la <b>administración centralizada</b>, pero, manteniendo la <b>independencia de cada fondo</b>.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Confiere una mayor <b>uniformidad</b> en el tratamiento de la información de todos los fondos.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Guarda un <b>registro respaldatorio</b>, absolutamente pormenorizado, <b>de cada ValorCP</b> calculado.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Reduce la carga operativa</b>, y el riesgo de cometer errores de transcripción, al disponer de opciones automáticas de
                                                    <table>
                                                        <tr>
                                                            <td style="padding-left:10px" valign="top">
                                                                captura de precios de especies de TVs  y de SyRs, y de
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left:10px">
                                                                publicación de ValorCPs, en el Sistema de Títulos.
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Mantiene toda la <b>información histórica</b>, sin descuidar la performance de acceso a datos operativos.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Registra toda la actividad de los usuarios y de los administradores de seguridad en <b>Logs de auditoria</b>.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Workflow parametrizable</b>: que soporta todas las acciones sobre el proceso, operaciones, precios, cierres de cambio, etc.; en el que se define la cantidad y jerarquía de funcionarios intervinientes y si exige control por oposición.
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:20px; font-size:14px; font-weight:bold">
                                        Características principales
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:15px">
                                        <table border="0" cellpadding="5px" cellspacing="0" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                            <tr>
                                                <td valign="middle" align="center" style="width:150px; border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Tablero de control
                                                </td>
                                                <td valign="top" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    El Tablero de control es el front-end principal de la aplicación.&nbsp;&nbsp;&nbsp;En él se destacan tres paneles.&nbsp;&nbsp;&nbsp;El panel de <b>Proceso</b> diario sirve para guiar al usuario en el trabajo diario (permite saber rapidamente en qué estado está el proceso, cuál es el próximo paso que debe darse y cuáles son las tareas pendientes, en términos de cálculo de valores de cuotaparte).&nbsp;&nbsp;&nbsp;El panel de <b>Opciones</b> permite acceder a todas las funcionalidades del sistema (ver detalle más abajo).&nbsp;&nbsp;&nbsp;El panel de <b>Notificaciones</b> sirve para desplegar avisos del sistema (se hace visible sólo cuando es imprescindible).
                                                </td>
                                                <td style="border-style:solid; border-width:1px; border-color:#CD853F; width:260px">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="Imagenes/CedFCI-Tablero_ch.jpg" Width="260px" ImageAlign="Right" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Proceso diario
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Representa una guía para la actividad diaria, en términos de:
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                Incorporación de novedades (operaciones, cierres de cambio, precios, tasas de cuentas remuneradas, suscripciones y rescates de cuotapartes).
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                Revalúo de carteras (devengado de intereses de colocaciones a plazo y sobre saldos de cuentas remuneradas, revalúo de titulos valores, ajustes por diferencia de cambio).
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                Cálculo / liquidación de honorarios administrativos de las sociedades Gerente y Depositaria.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                Cálculo de los valores de cuotaparte de la(s) clase(s) emitida(s) para cada fondo.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                Incorporación de Suscripciones y Rescates valorizados.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                Confirmación y publicación de los valores de cuotapartes calculados.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                Cierre diario (que desencadena también el proceso de Apertura del siguiente día hábil y, cuando corresponde, los procesos de Cierre de Ejercicio y Depuración).
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">•</td>
                                                            <td style="padding-left:5px">
                                                                En el proceso de Apertura, con el que arranca cada nuevo día, se liquidan los vencimientos pendientes, de pago o cobro, en forma automática (Ej.: rescates a pagar, compra de acciones a pagar, venta de acciones a cobrar).
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="5" valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Incorporación de novedades
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="4" valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Circuito de<br />Transferencias<br /><b>Enviadas</b>
                                                </td>
                                                <td colspan="2" style="padding:0px">
                                                    <table border="0" cellpadding="5px" cellspacing="0">
                                                        <tr>
                                                            <td rowspan="2" valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                                Ingreso:
                                                            </td>
                                                            <td valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                                Manual
                                                            </td>
                                                            <td style="border-style:solid; border-width:1px; border-color:#CD853F; width:100%">
                                                                Se realiza en forma intuitiva. En una sola pantalla encontramos toda la información relacionada a la operación.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                                Automático
                                                            </td>
                                                            <td style="border-style:solid; border-width:1px; border-color:#CD853F; width:100%">
                                                                Generado desde otra aplicación.
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Autorización del sector:<br />
                                                    Cada sector, deberá autorizar las operaciones, cumpliendo los controles definidos en  el worflow.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Verificación de fondos:<br />
                                                    Es la intervención de Tesorería.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Envío al BCRA:<br />
                                                    Para todas las operaciones enviadas al BCRA, la aplicación registra la respuesta del mismo y concilia los datos enviados contra la consulta de extracto del BCRA, para asegurarse que los datos de cada transferencia enviada sean idénticos en ambos lados.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Buscador de Transferencias
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Un ágil buscador de operaciones permite consultar, listar o exportar transferencias, a través de diversos filtros de selección (rango de fechas, tipos de operatoria, entidad, sector destino, moneda, importe, texto dentro de la instrucción, etc).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Seguridad<br />y<br />confidencialidad
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Dentro de los aspectos de seguridad, podemos destacar los siguientes:<br /> 
                                                    • el esquema de autorización por montos,<br />
                                                    • el control por oposición de usuarios,<br />
                                                    • la captura y distribución automáticas de operaciones,<br />
                                                    • la verificación en línea con el extracto del BCRA.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Los usuarios sólo podrán visualizar las operaciones de los sectores a los que pertenezcan.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Tecnología
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    • Cliente/Servidor en tres capas<br />
                                                    • Workflow basado en datos<br />
                                                    • Desarrollado en c# (WinForms)<br />
                                                    • Instalador MSI con control de versión<br />
                                                    • Motor de base de datos relacional
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px">
                                        <asp:HyperLink ID="CedSTpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=Cedeira-SistAdminFCIs.pdf" SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px; padding-bottom:20px">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Soluciones.aspx" SkinID="LinkMedianoClaro">Volver a Soluciones</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 20px;" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
