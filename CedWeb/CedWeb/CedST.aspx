<%@ Page Language="C#" MasterPageFile="~/CedWeb.master" AutoEventWireup="true" CodeFile="~/CedST.aspx.cs"
    Inherits="CedWeb.CedST" %>

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
                                        <asp:Label ID="CedSTtituloLabel" runat="server" Text="Sistema de Transferencias ( implementación MEP )"
                                            SkinID="TituloPagina" Width="415px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" valign="top" style="padding-top:10px">
                                        Es un sistema diseñado para <b>centralizar la administración</b> de transferencias.
                                        <br />
                                        En línea con el BCRA, concentra el 100% de las operaciones, tanto enviadas como recibidas, en un único repositorio, para realizar un <b>control eficiente</b> y una <b>óptima gestión operativa</b>.
                                        <br />
                                        Facilita las tareas a través de la <b>automatización de los procesos</b> de: ingreso, envío, recepción, distribución y conciliación, entre otros. Contempla todas las operatorias, acorde a las normativas, y se encuentra <b>integrado al Sistema de Medios de Pagos (Mep)</b> del BCRA.
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="center" style="padding-top:20px">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="Imagenes/CedST-EsquemaMEP.jpg"/>
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
                                    <td style="padding-top:15px">
                                        Con la puesta en marcha del Sistema de Transferencias, la entidad se beneficia en los siguientes aspectos:
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:5px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Se dispone de toda la <b>información histórica</b> (Mep elimina las operaciones durante el proceso de cierre diario).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Se incorporan las Transferencias Recibidas</b> (Mep no procesa transferencias recibidas).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Incluye un <b>esquema de autorización de operaciones flexible</b>, en el que se puede personalizar: cantidad y jerarquía de funcionarios intervinientes por sector, autorización por escala de montos y control por oposición (Mep no contempla un tercer nivel de supervisión para las operaciones de riesgo y no controla montos).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Conectividad con otras aplicaciones</b>: se incluyen servicios y componentes para interactuar, en línea, con otros sistemas (Mep carece de estas prestaciones).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Reducción de la carga operativa</b> del sector que administra las transferencias:
                                                    <table>
                                                        <tr>
                                                            <td style="width:90px; padding-left:10px" valign="top">
                                                                Mep enviadas
                                                            </td>
                                                            <td>
                                                                Las operaciones se ingresan y autorizan, en los sectores de origen.  Acotando la intervención del sector administrador, a aspectos de tesorería; se eliminan los controles manuales (de firmas, del origen e integridad de la información en faxes, mails, cartas, entre otros).
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-left:10px">
                                                                Mep recibidas
                                                            </td>
                                                            <td>
                                                                Mediante la automatización del proceso de distribución a los sectores de destino.
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Sistematización de la <b>notificación de recepción o envío de transferencias</b>.  Los sectores perciben estas novedades en tiempo real a través de la aplicación.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Uniformidad en el tratamiento de la información</b>: todos los sectores hablan el mismo idioma.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Logs de auditoría</b>: se registra toda la actividad de los usuarios y de los administradores de seguridad.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    Se preserva la <b>seguridad, integridad y confidencialidad</b> de todas las transferencias.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Seguimiento de transferencias</b>: cada sector puede realizar el seguimiento permanente de una transferencia en particular o tener una visión global a través de indicadores generales del estado de las operaciones. 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">•</td>
                                                <td style="padding-left:5px">
                                                    <b>Actualización automática de operatorias</b>: el sistema actualiza, en forma automática, la estructura de datos de cada operatoria, sincronizando las novedades que se incorporen a MepTransaccional. De esta manera se evita la modificación del sistema ante los cambios que incorpore el BCRA. 
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
                                                    Tableros de control
                                                </td>
                                                <td valign="top" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Los tableros de control permiten visualizar, en qué sector, y en qué estado, se encuentran todas las transferencias del día y pendientes de días anteriores.  Cada sector puede identificar rápidamente las operaciones pendientes de intervención.
                                                    <br />
                                                    También es posible visualizar los totales expresados en importes, discriminados por moneda. 
                                                    <br />
                                                    Hay un Tablero independiente para cada tipo de transferencia (enviadas, recibidas y esperadas).
                                                </td>
                                                <td style="border-style:solid; border-width:1px; border-color:#CD853F; width:260px">
                                                    <asp:Image ID="Image5" runat="server" ImageUrl="Imagenes/CedST-Tablero_ch.jpg" Width="260px" ImageAlign="Right" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Tipos de Transferencias
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    La aplicación soporta transferencias enviadas y recibidas. Además, incluye un nuevo concepto: las transferencias <b>Esperadas</b>, que permite, a los distintos sectores, declarar las transferencias pendientes de recepción, para automatizar su distribución.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="3" valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Circuito de<br />Transferencias<br /><b>Recibidas</b>
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Captura y Conciliación:<br />
                                                    Se realiza la captura mediante el procesamiento del archivo de interfaz, solicitado al BCRA vía X400.<br />
                                                    Considerando que la desencripción, por motivos técnicos, es manual, el sistema ofrece un procedimiento de conciliación para identificar posibles adulteraciones.<br />
                                                    Se dispone de un Visor de Captura para monitorear la correcta incorporación de las transferencias.<br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Distribución:<br />
                                                    La asignación de las transferencias, a los sectores, se puede realizar en forma manual. También se puede automatizar aplicando criterios como los detallados a continuación:
                                                    Operatorias exclusivas:  aplicadas a tipos de operatorias utilizadas únicamente por un sector.
                                                    Transferencias esperadas: declaradas previamente. 
                                                    Aplicando reglas específicas: por ejemplo: asignar a un sector las transferencias referidas a CBUs de determinadas sucursales.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Gestión:<br /> 
                                                    Liquidación:  el sistema permite registrar el detalle de la liquidación de una transferencia.
                                                    Rechazo al BCRA: genera automáticamente una Mep Enviada, evitando la transcripción.
                                                    Devolución al administrador de Meps Recibidas: para su reasignación a otro sector.
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
                                                            <td style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                                Se realiza en forma intuitiva. En una sola pantalla encontramos toda la información relacionada a la operación.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                                Automático
                                                            </td>
                                                            <td style="border-style:solid; border-width:1px; border-color:#CD853F">
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
                                                    Un ágil buscador de operaciones permite consultar, listar o exportar transferencias, a través de diversos filtros de selección (rango de fechas, tipos de operatoria, Entidad, Sector Destino, Moneda, Importe, texto dentro de la instrucción, etc).
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
                                                    Los usuarios solo podran visualizar las operaciones de los sectores a los que pertenezcan.
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
                                        <asp:HyperLink ID="CedSTpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=Cedeira-SistTransfMEP.pdf"
                                            SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="padding-top:10px; padding-bottom:20px">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Soluciones.aspx"
                                            SkinID="LinkMedianoClaro">Volver a Soluciones</asp:HyperLink>
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
