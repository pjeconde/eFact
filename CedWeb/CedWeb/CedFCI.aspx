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
                                                    Operaciones<br />
                                                    El sistema permite el ingreso de operaciones (aquellas que surgen de las decisiones tomadas por los administradores de las carteras de los fondos).  Todas las operaciones contienen tanto información operativa como contable.<br />
                                                    Hay un workflow parametrizable, mediante el cuál se establece el esquema de permisos (de usuarios) necesarios para la invocación de cada evento: alta, autorización, anulación, etc.  Asimismo se puede definir qué eventos exigen control por oposición. Este mismo esquema se aplica, cada uno con su propia configuración, a: Cierres de Cambio, Precios, Tasas y opciones de Proceso.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Cierres de cambio<br />
                                                    A los efectos de la conversión de importes entre distintas monedas (del fondo, de la cuenta, en moneda local, etc.), el sistema permite el ingreso de cierres de cambio de las monedas extranjeras que se consignen.  Registra un cierre por moneda y por día, que es el que usa para hacer los ajustes por diferencia de cambio.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Precios<br />
                                                    A los efectos de la valorización de las tenencias de títulos valores a precio de realización, el sistema permite el ingreso de precios de las especies que se consignen.  Registra un precio por especie y por día, que es el que usa para hacer el revalúo de estos activos.  También dispone de una opción para una captura automática de precios, desde un servicio de Reuters.  Esta captura se podrá realizar en distintas etapas (ver Etapas de captura) de acuerdo a la disponibilidad de precios a lo largo del día (Bolsa de Buenos Aires, Bolsa de New York, MAE, etc).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Tasas de cuentas remuneradas<br />
                                                    A los efectos del cálculo de los intereses devengados, sobre los saldos de las cuentas remuneradas, el sistema permite el ingreso de las distintas tasas de interés vigentes, para cada período, para cada cuenta remunerada.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Suscripciones y rescates de fondos<br />
                                                    Para registrar el impacto que las suscripciones y rescates, tienen sobre los patrimonios de los fondos, el sistema debe disponer del detalle de operaciones de SyR del día.  Esta información la obtiene, mediante una interfaz, desde el Sistema de Títulos (Sociedad Depositaria).<br />
                                                    Considerando el hecho de que esta información no está disponible, en todo momento, en su estado definitivo, el sistema admite la posibilidad de obtener datos provisorios y, por último, realizará una lectura definitiva.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="11" valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Consultas / Reportes, Gráficos
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Valores CPs<br />
                                                    El reporte de valores de cuotaparte, muestra los valores calculados para cada clase de cada fondo solicitado.  También permite obtener un detalle mayor, llamado “Determinación de valor de cuotaparte”.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Cartera (Posición)<br />
                                                    En el reporte de Cartera se muestra el saldo de cada cuenta, en moneda del fondo y en  moneda local, de cada fondo solicitado.  En algunos productos de inversión (plazos fijos, cauciones, tenencia de titulos valores, cuentas bancarias, vencimientos a pagar o cobrar) se incluye una apertura más detallada.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Tenencia de Titulos Valores<br />
                                                    En el reporte de Tenencia de Títulos Valores se muestran todas las especies que forman parte de la cartera de un fondo.  Se consignan: la cantidad de valores nominales, el precio, el importe total, el costo promedio ponderado y la participación de la especie, tanto en el total de los títulos valores como en el patrimonio completo del fondo.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Variación de ValorCPs<br />
                                                    Determina diariamente la variación porcentual del valor de cuotaparte respecto del día hábil anterior y del primer día hábil del mes.  Advierte cuando la variación está por encima del tope definido.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Detalle de Plazos Fijos y Cauciones<br />
                                                    Muestra el detalle específico de los plazos fijos y cauciones, vigentes a la fecha solicitada, en la cartera de los fondos.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Gráfico de Evolución de ValorCPs<br />
                                                    Permite percibir, de una manera mas rápida e intuitiva, la evolución, a lo largo del tiempo, del valor de cuotaparte de los fondos.  Se puede optar por graficar: a) los valores de cuotaparte, b) las variaciones porcentuales diarias de los valores de cuotaparte.  Y, en ambos casos, elegir uno o más fondos.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Gráfico de Evolución del Patrimonio Neto<br />
                                                    Permite percibir la evolución, a lo largo del tiempo, del Patrimonio Neto de uno o más fondos.  Se puede solicitar tanto en pesos como en dólares.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Gráfico de Composición de Cartera<br />
                                                    Muestra la composición de la cartera de un fondo a través de conceptos de agrupamiento definidos a tal efecto.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Cash Flow<br />
                                                    Permite establecer el flujo de caja, de cada fondo solicitado, en el período seleccionado.  Es la proyección financiera de ingresos y egresos del fondo, a lo largo del período solicitado.  Los conceptos de ingresos / egresos, no son fijos sino que se parametrizan, asi como también los rubros tributarios de dichos conceptos.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Contables (Balance de Saldos, Diario, Mayor)<br />
                                                    Permite la emisión de informes contables para cada fondo.  Conserva toda la información histórica, pero los datos del ejercicio actual se encuentran en una "partición" propia para permitir que la actividad operativa diaria sea más performante.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Auditoria (Log de actividad)<br />
                                                    Permite a los auditores acceder al Log de actividad de los usuarios.   Esta actividad es registrada, automáticamente por el sistema, cada vez que un usuario desencadena un evento relacionado a: Operaciones, Cierres de cambio, Precios, Proceso y Tasas de cuentas remuneradas.  El sistema registra, en cada uno de estos casos, la siguiente información: fecha y hora del evento, identificación del usuario, el comentario que se haya ingresado, la identificación del evento y del estado resultante de dicho evento.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="8" valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Configuración de datos básicos
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    FCIs<br />
                                                    Es la definición de cuáles son los fondos que se administran, qué clases de cuotapartes se han emitido para cada fondo, cuáles son los fees de administración (vigentes a cada momento) y cuáles son sus calificaciones de riesgo.  Tambien se consignan datos inherentes al proceso de cálculo de cuotapartes (etapa de cálculo, tipo de precio), a la generación de interfaces y a la contabilidad.<br />
                                                    En cualquier momento se pueden agregar nuevos fondos o dar de baja fondos vigentes.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Especies de Titulos Valores<br />
                                                    Es la definición de las especies que podrán invocarse a la hora de registrar operaciones de Titulos Valores.  Se consigna información de identificación y de clasificación, se especifica el mercado relevante y también datos inherentes a la generación de interfaces.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Etapas de cálculo<br />
                                                    En el proceso de revaluo de carteras y cálculo de valor de cuotaparte, algunos fondos pueden ser tratados antes que otros, de acuerdo a la disponibilidad de información.  A los efectos de organizar esta tarea repetitiva, se pueden establecer etapas de cálculo.  Cada fondo será tratado en la etapa que se haya definido (ver FCIs).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Etapas de captura de precios<br />
                                                    Se puede definir en qué momento el sistema estará en condiciones de capturar qué precios.  Esto se llama etapa de captura.  Ejemplo: 1) cierre de la Bolsa de Buenos Aires, 2) Cierre de la Bolsa de New York, 3) Cierre del Mercado Abierto Electrónico, etc.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Plan de cuentas<br />
                                                    Se define un plan de cuentas único, en el que habrá cuentas de uso general y otras de uso exclusivo para cada fondo.  Representa una definición de naturaleza contable y, más importante aún, en términos de instrumentos de inversión.<br />
                                                    Como el sistema no conoce el plan de cuentas, pero deberá estar en condiciones de generar operaciónes automáticas, será necesario establecer algunas relaciones (entre cuentas) y algunas referencias (a conceptos simbólicos que el sistema maneja).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Alícuotas<br />
                                                    Se pueden modificar todas las alícuotas que el sistema tendrá en cuenta a la hora de la generación de operaciones.  Ejemplos: 1) impuesto al valor agregado, 2) gastos por compra / venta de titulos valores.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Alarmas<br />
                                                    Se pueden fijar límites para que el sistema sepa cuándo emitir ciertos avisos.  Ejemplos: 1) tope de variación diaria de Valor de cuotaparte, 2) tope de vida promedio.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Entidades, Mercados, Monedas, etc.<br />
                                                    Todos los elementos accesorios que ayuden a describir/definir: fondos, cuentas, especies, cierres de cambio, precios, operaciones; tienen un front-end de ingreso para que el usuario pueda ingresarlos y mantenerlos.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Interfaces
                                                </td>
                                                <td colspan="2" style="border-style:solid; border-width:1px; border-color:#CD853F">
                                                    Genera las interfaces para la CAFCI (diaria, semanal y mensual), para la CNV y para el copiado de libros contables.
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
