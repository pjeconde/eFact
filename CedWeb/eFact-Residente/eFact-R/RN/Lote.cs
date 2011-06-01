using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using FileHelpers;
using FileHelpers.RunTime;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eFact_R.RN
{
    public class Lote
    {
        public static void Consultar(out List<eFact_R.Entidades.Lote> Lotes, Tablero.TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, string CuitVendedor, string NumeroLote, string PuntoVenta, bool VerPendientes, CedEntidades.Sesion Sesion)
        {
            List<eFact_R.Entidades.Lote> lotes = new List<eFact_R.Entidades.Lote>();
            eFact_R.DB.Lote l = new eFact_R.DB.Lote(Sesion);
            l.Consultar(out lotes, TipoConsulta, FechaDsd, FechaHst, CuitVendedor, NumeroLote, PuntoVenta, VerPendientes);
            Lotes = lotes;
        }
        public static void VerificarEnviosPosteriores(bool LoteNuevo, string CuitVendedor, string NumeroLote, string PuntoVenta, int NumeroEnvio, CedEntidades.Sesion Sesion)
        {
            List<eFact_R.Entidades.Lote> lotes = new List<eFact_R.Entidades.Lote>();
            eFact_R.DB.Lote l = new eFact_R.DB.Lote(Sesion);
            l.Consultar(out lotes, eFact_R.RN.Tablero.TipoConsulta.SinAplicarFechas, DateTime.Today, DateTime.Today, CuitVendedor, NumeroLote, PuntoVenta, false);
            if (lotes.Count != 0)
            {
                //Verificar si hay envios posteriores del lote. 
                if (lotes[0].NumeroEnvio > NumeroEnvio)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Lote.HayEnviosPosteriores("");
                }
                //Verifico el estado de la ultimo lote enviado.
                if (LoteNuevo && (lotes[0].WF.IdEstado != "RechazadoIF" && lotes[0].WF.IdEstado != "Cancelado"))
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Lote.Existente("Ya existe el lote " + NumeroLote + " en el estado: " + lotes[0].WF.DescrEstado);
                }
            }
        }
        public static void ObtenerNumeroEnvioDisponible(out int NumeroEnvioDisponible, string CuitVendedor, string NumeroLote, string PuntoVenta, CedEntidades.Sesion Sesion)
        {
            List<eFact_R.Entidades.Lote> lotes = new List<eFact_R.Entidades.Lote>();
            eFact_R.DB.Lote l = new eFact_R.DB.Lote(Sesion);
            l.Consultar(out lotes, eFact_R.RN.Tablero.TipoConsulta.SinAplicarFechas, DateTime.Today, DateTime.Today, CuitVendedor, NumeroLote, PuntoVenta, false);
            if (lotes.Count != 0)
            {
                //Verificar que el ultimo envio del lote este un estado final ( cancelado o rechzado por interfactureas ) para generar un nuevo numero de envio.
                if (lotes[0].WF.IdEstado == "RechazadoIF" || lotes[0].WF.IdEstado == "Cancelado")
                {
                    NumeroEnvioDisponible = lotes.Count + 1;
                }
                else
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Lote.ImposibleAsignarNuevoNroEnvio("Ya existe el lote " + NumeroLote + " en el estado: " + lotes[0].WF.DescrEstado);
                }
            }
            else
            {
                //Si el lote NO existe, es el primer envio.
                NumeroEnvioDisponible = 1;
            }
        }
        public static void Leer(eFact_R.Entidades.Lote Lote, CedEntidades.Sesion Sesion)
        {
            eFact_R.DB.Lote l = new eFact_R.DB.Lote(Sesion);
            l.Leer(Lote);
        }
        public static void ActualizarDatosCAE(eFact_R.Entidades.Lote Lote, FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            MemoryStream ms;
            System.Xml.XmlTextWriter writer;
            System.Xml.Serialization.XmlSerializer x;
            String XmlizedString;
            
            //Actualizar lote
            ms = new MemoryStream();
            XmlizedString = null;
            writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
            x.Serialize(writer, Lc);
            ms = (MemoryStream)writer.BaseStream;
            XmlizedString = RN.Tablero.ByteArrayToString(ms.ToArray());
            ms.Close();
            Lote.LoteXmlIF = XmlizedString;

            eFact_R.Entidades.Comprobante comprobante =new eFact_R.Entidades.Comprobante();
            string sFecha = "";
            for (int i = 0; i < Lc.comprobante.Length; i++)
            {
                eFact_R.Entidades.Comprobante c = Lote.Comprobantes.Find((delegate(eFact_R.Entidades.Comprobante e1) { return e1.IdTipoComprobante == Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante.ToString()) &&  e1.NumeroComprobante == Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante.ToString(); }));
                if (Lc.comprobante[i].cabecera.informacion_comprobante.cae != null)
                {
                    c.NumeroCAE = Lc.comprobante[i].cabecera.informacion_comprobante.cae.ToString();
                }
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae != null)
                {
                    sFecha = Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString();
                    c.FechaCAE = Convert.ToDateTime(sFecha.Substring(0, 4) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(6, 2));
                }
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae != null)
                {
                    sFecha = Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString();
                    c.FechaVtoCAE = Convert.ToDateTime(sFecha.Substring(0, 4) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(6, 2));
                }
                c.EstadoIFoAFIP = Lc.comprobante[i].cabecera.informacion_comprobante.resultado;
                c.ComentarioIFoAFIP = Lc.comprobante[i].cabecera.informacion_comprobante.motivo;
            }
        }
        public static void ActualizarDatos(eFact_R.Entidades.Lote Lote, FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            MemoryStream ms;
            System.Xml.XmlTextWriter writer;
            System.Xml.Serialization.XmlSerializer x;
            String XmlizedString;

            //Actualizar lote
            ms = new MemoryStream();
            XmlizedString = null;
            writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
            x.Serialize(writer, Lc);
            ms = (MemoryStream)writer.BaseStream;
            XmlizedString = RN.Tablero.ByteArrayToString(ms.ToArray());
            ms.Close();
            Lote.LoteXmlIF = XmlizedString;
        }
        public static void ActualizarDatosError(eFact_R.Entidades.Lote Lote, CedWebRN.IBK.lote_response Lr)
        {
            MemoryStream ms;
            System.Xml.XmlTextWriter writer;
            System.Xml.Serialization.XmlSerializer x;
            String XmlizedString;

            //Actualizar lote
            ms = new MemoryStream();
            XmlizedString = null;
            writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            x = new System.Xml.Serialization.XmlSerializer(Lr.GetType());
            x.Serialize(writer, Lr);
            ms = (MemoryStream)writer.BaseStream;
            XmlizedString = RN.Tablero.ByteArrayToString(ms.ToArray());
            ms.Close();
            Lote.LoteXmlIF = XmlizedString;
        }
        public static void Ejecutar(eFact_R.Entidades.Lote Lote, CedEntidades.Evento Evento, string Handler, CedEntidades.Sesion Sesion)
        {
            string handlerEvento = "";
            //VerificarAssemblyVersion();
            eFact_R.DB.Lote lote = new eFact_R.DB.Lote(Sesion);
            string nombreArchivoProcesado = "";
            switch (Lote.WF.IdFlow)
            {
                case "eFact":
                    switch (Evento.Id)
                    {
                        case "EnvBandSalida":
                            if (Lote.NumeroEnvio > 1)
                            { 
                                eFact_R.Entidades.Lote l = new eFact_R.Entidades.Lote();
                                l.CuitVendedor = Lote.CuitVendedor;
                                l.PuntoVenta = Lote.PuntoVenta;
                                l.NumeroLote = Lote.NumeroLote;
                                l.NumeroEnvio = Lote.NumeroEnvio - 1;
                                eFact_R.RN.Lote.Leer(l, Sesion);
                                //Busca el evento automático, para anular el envio anterior.
                                CedEntidades.Evento evento = l.WF.EventosPosibles.Find((delegate(CedEntidades.Evento e1) { return e1.Automatico == true && (e1.Id == "AnularRechIF" || e1.Id == "AnularCancel"); }));
                                handlerEvento = Cedeira.SV.WF.EjecutarEvento(l.WF, evento, true);
                                handlerEvento += " end ";
                            }
                            handlerEvento += Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            lote.Insertar(Lote, handlerEvento, Handler);
                            break;
                        case "EnviarAIF":
                            handlerEvento += Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            lote.ActualizarFechaEnvio(Lote, handlerEvento);
                            break;
                        case "RegAceptAFIP":
                        case "RegActAFIP":
                            handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            lote.ActualizarDatosCAE(Lote, handlerEvento);
                            if (eFact_R.Aplicacion.TipoItfAut == "XML")
                            {
                                GuardarItfXML(out nombreArchivoProcesado, Lote, "ROK", eFact_R.Aplicacion.ArchPathItfAut, true, false);
                            }
                            else if (eFact_R.Aplicacion.TipoItfAut == "TXT")
                            {
                                GuardarItfTXT(out nombreArchivoProcesado, Lote, "ROK", eFact_R.Aplicacion.ArchPathItfAut, true);
                            }
                            break;
                        case "RegAceptAFIPO":
                        case "RegActAFIPO":
                            handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            lote.ActualizarDatosCAE(Lote, handlerEvento);
                            if (eFact_R.Aplicacion.TipoItfAut == "XML")
                            {
                                GuardarItfXML(out nombreArchivoProcesado, Lote, "ROO", eFact_R.Aplicacion.ArchPathItfAut, true, false);
                            }
                            else if (eFact_R.Aplicacion.TipoItfAut == "TXT")
                            {
                                GuardarItfTXT(out nombreArchivoProcesado, Lote, "ROO", eFact_R.Aplicacion.ArchPathItfAut, true);
                            }
                            break;
                        case "RegAceptAFIPP":
                        case "RegActAFIPP":
                            handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            lote.ActualizarDatosCAE(Lote, handlerEvento);
                            if (eFact_R.Aplicacion.TipoItfAut == "XML")
                            {
                                GuardarItfXML(out nombreArchivoProcesado, Lote, "ROP", eFact_R.Aplicacion.ArchPathItfAut, true, false);
                            }
                            else if (eFact_R.Aplicacion.TipoItfAut == "TXT")
                            {
                                GuardarItfTXT(out nombreArchivoProcesado, Lote, "ROP", eFact_R.Aplicacion.ArchPathItfAut, true);
                            }
                            break;
                        case "RegContAFIP":
                        case "RegContAFIPO":
                        case "RegContAFIPP":
                            handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            DataTable dt = lote.Insertar(Lote, handlerEvento, "");
                            Lote.IdLote = Convert.ToInt32(dt.Rows[0][0].ToString());
                            Leer(Lote, Sesion);
                            CedEntidades.Evento eventoAct = new CedEntidades.Evento();
                            eventoAct = Lote.WF.EventosPosibles[0];
                            handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, eventoAct, true);
                            lote.ActualizarDatosCAE(Lote, handlerEvento);
                            if (eFact_R.Aplicacion.TipoItfAut == "XML")
                            {
                                GuardarItfXML(out nombreArchivoProcesado, Lote, "ROK", eFact_R.Aplicacion.ArchPathItfAut, true, false);
                            }
                            else if (eFact_R.Aplicacion.TipoItfAut == "TXT")
                            {
                                GuardarItfTXT(out nombreArchivoProcesado, Lote, "ROK", eFact_R.Aplicacion.ArchPathItfAut, true);
                            }
                            break;
                        case "RegRechAFIP":
                            handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            lote.ActualizarDatosError(Lote, handlerEvento);
                            if (eFact_R.Aplicacion.TipoItfAut == "XML")
                            {
                                GuardarItfXML(out nombreArchivoProcesado, Lote, "RAF", eFact_R.Aplicacion.ArchPathItfAut, true, false);
                            }
                            else if (eFact_R.Aplicacion.TipoItfAut == "TXT")
                            {
                                GuardarItfTXTlr(out nombreArchivoProcesado, Lote, "RAF", eFact_R.Aplicacion.ArchPathItfAut, true);
                            }
                            break;
                        case "RegRechIF":
                            handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                            lote.ActualizarDatosError(Lote, handlerEvento);
                            if (eFact_R.Aplicacion.TipoItfAut == "XML")
                            {
                                GuardarItfXML(out nombreArchivoProcesado, Lote, "RIF", eFact_R.Aplicacion.ArchPathItfAut, true, false);
                            }
                            else if (eFact_R.Aplicacion.TipoItfAut == "TXT")
                            {
                                GuardarItfTXTlr(out nombreArchivoProcesado, Lote, "RIF", eFact_R.Aplicacion.ArchPathItfAut, true);
                            }
                            break;
                        default:
                            Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, false);
                            break;
                    }
                    break;
            }
        }
        public static void DeserializarLc(out FeaEntidades.InterFacturas.lote_comprobantes Lc, eFact_R.Entidades.Lote Lote, bool IF)
        {
            string cadena = Cadena(Lote, IF);
            DeserializarLc(out Lc, cadena);
        }
        public static void DeserializarLc(out FeaEntidades.InterFacturas.lote_comprobantes Lc, string Cadena)
        {
            //Deserializar ( pasar de string XML a FeaEntidades.InterFacturas.lote_comprobantes )
            System.Text.Encoding codificador;
            codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
            byte[] a = new byte[Cadena.Length];
            a = codificador.GetBytes(Cadena);
            MemoryStream ms = new MemoryStream(a);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lc.GetType());
            lc = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
            Lc = lc;
        }
        public static void DeserializarLc(out FeaEntidades.Reporte.lote_comprobantes Lc, eFact_R.Entidades.Lote Lote)
        {
            string cadena = Cadena(Lote, true);
            //Deserializar ( pasar de string XML a FeaEntidades.Reporte.lote_comprobantes )
            System.Text.Encoding codificador;
            codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
            byte[] a = new byte[cadena.Length];
            a = codificador.GetBytes(cadena);
            MemoryStream ms = new MemoryStream(a);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            FeaEntidades.Reporte.lote_comprobantes lc = new FeaEntidades.Reporte.lote_comprobantes();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lc.GetType());
            lc = (FeaEntidades.Reporte.lote_comprobantes)x.Deserialize(ms);
            Lc = lc;
        }
        public static void DeserializarLr(out FeaEntidades.InterFacturas.lote_response Lr, string Cadena)
        {
            //Deserializar ( pasar de string XML a CedWebRN.IBK.lote_response )
            System.Text.Encoding codificador;
            codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
            byte[] a = new byte[Cadena.Length];
            a = codificador.GetBytes(Cadena);
            MemoryStream ms = new MemoryStream(a);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            FeaEntidades.InterFacturas.lote_response lr = new FeaEntidades.InterFacturas.lote_response();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lr.GetType());
            lr = (FeaEntidades.InterFacturas.lote_response)x.Deserialize(ms);
            Lr = lr;
        }
        public static void SerializarLc(out string LoteXML, FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            //Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
            x.Serialize(writer, Lc);
            ms = (MemoryStream)writer.BaseStream;
            LoteXML = RN.Tablero.ByteArrayToString(ms.ToArray());
            ms.Close();
        }
        public static void SerializarLr(out string LoteXMLIF, CedWebRN.IBK.lote_response Lr)
        {
            //Deserializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Lr.GetType());
            x.Serialize(writer, Lr);
            ms = (MemoryStream)writer.BaseStream;
            LoteXMLIF = RN.Tablero.ByteArrayToString(ms.ToArray());
            ms.Close();
        }
        public static void GuardarItfTXT(out string NombreProcesado, eFact_R.Entidades.Lote Lote, string PreFijo, string Ruta, bool IF)
        {
            //Deserializar ( pasar de XML a FeaEntidades.InterFacturas.lote_comprobantes )
            FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            eFact_R.RN.Lote.DeserializarLc(out Lc, Lote, IF);

            //Evento de escritura de txt
            List<FeaEntidades.InterFacturas.cabecera_lote> clote = new List<FeaEntidades.InterFacturas.cabecera_lote>();
            clote.Add(Lc.cabecera_lote);
            FileHelperEngine e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.cabecera_lote));
            string nombreProcesado = "";
            GenerarNombreArch(out nombreProcesado, Ruta, PreFijo, Lote, "txt");
            NombreProcesado = nombreProcesado;
            e.WriteFile(NombreProcesado, clote);
            for (int i = 0; i < Lc.cabecera_lote.cantidad_reg; i++)
            {
                List<FeaEntidades.InterFacturas.informacion_comprador> icomprador = new List<FeaEntidades.InterFacturas.informacion_comprador>();
                icomprador.Add(Lc.comprobante[i].cabecera.informacion_comprador);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.informacion_comprador));
                e.AppendToFile(NombreProcesado, icomprador);
                
                List<FeaEntidades.InterFacturas.informacion_comprobante> icomprobante = new List<FeaEntidades.InterFacturas.informacion_comprobante>();
                icomprobante.Add(Lc.comprobante[i].cabecera.informacion_comprobante);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.informacion_comprobante));
                e.AppendToFile(NombreProcesado, icomprobante);

                List<FeaEntidades.InterFacturas.informacion_vendedor> ivendedor = new List<FeaEntidades.InterFacturas.informacion_vendedor>();
                ivendedor.Add(Lc.comprobante[i].cabecera.informacion_vendedor);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.informacion_vendedor));
                e.AppendToFile(NombreProcesado, ivendedor);

                if (Lc.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias));
                    e.AppendToFile(NombreProcesado, Lc.comprobante[i].cabecera.informacion_comprobante.referencias);
                }

                List<FeaEntidades.InterFacturas.detalle> idetalle = new List<FeaEntidades.InterFacturas.detalle>();
                idetalle.Add(Lc.comprobante[i].detalle);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.detalle));
                e.AppendToFile(NombreProcesado, idetalle);

                foreach (FeaEntidades.InterFacturas.linea linea in Lc.comprobante[i].detalle.linea)
                {
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.linea));
                    List<FeaEntidades.InterFacturas.linea> ilinea = new List<FeaEntidades.InterFacturas.linea>();
                    ilinea.Add(linea);
                    e.AppendToFile(NombreProcesado, ilinea);
                    if (linea.importes_moneda_origen != null)
                    {
                        List<FeaEntidades.InterFacturas.lineaImportes_moneda_origen> ilineaImportesMonedaOrigen = new List<FeaEntidades.InterFacturas.lineaImportes_moneda_origen>();
                        ilineaImportesMonedaOrigen.Add(linea.importes_moneda_origen);
                        e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.lineaImportes_moneda_origen));
                        e.AppendToFile(NombreProcesado, ilineaImportesMonedaOrigen);
                    }
                    if (linea.informacion_adicional != null)
                    {
                        e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.lineaInformacion_adicional));
                        e.AppendToFile(NombreProcesado, linea.informacion_adicional);
                    }
                }

                if (Lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion != null)
                {
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.informacion_exportacion));
                    e.AppendToFile(NombreProcesado, Lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion);
                    if (Lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
                    {
                        e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.permisos));
                        e.AppendToFile(NombreProcesado, Lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos);
                    }
                }
                
                if (Lc.comprobante[i].extensiones != null)
                {
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.extensiones));
                    e.AppendToFile(NombreProcesado, Lc.comprobante[i].extensiones);
                    if (Lc.comprobante[i].extensiones.extensiones_camara_facturas != null)
                    {
                        e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas));
                        e.AppendToFile(NombreProcesado, Lc.comprobante[i].extensiones.extensiones_camara_facturas);
                    }
                    if (Lc.comprobante[i].extensiones.extensiones_destinatarios != null)
                    {
                        e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios));
                        e.AppendToFile(NombreProcesado, Lc.comprobante[i].extensiones.extensiones_destinatarios);
                    }
                }

                
                if (Lc.comprobante[i].resumen.descuentos != null)
                {
                    foreach (FeaEntidades.InterFacturas.resumenDescuentos descuento in Lc.comprobante[i].resumen.descuentos)
                    {
                        List<FeaEntidades.InterFacturas.resumenDescuentos> iresumenDescuentos = new List<FeaEntidades.InterFacturas.resumenDescuentos>();
                        iresumenDescuentos.Add(descuento);
                        e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.resumenDescuentos));
                        e.AppendToFile(NombreProcesado, iresumenDescuentos);
                    }
                }

                if (Lc.comprobante[i].resumen.impuestos != null)
                {
                    foreach (FeaEntidades.InterFacturas.resumenImpuestos impuesto in Lc.comprobante[i].resumen.impuestos)
                    {
                        List<FeaEntidades.InterFacturas.resumenImpuestos> iresumenImpuestos = new List<FeaEntidades.InterFacturas.resumenImpuestos>();
                        iresumenImpuestos.Add(impuesto);
                        e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.resumenImpuestos));
                        e.AppendToFile(NombreProcesado, iresumenImpuestos);
                    }
                }

                if (Lc.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    List<FeaEntidades.InterFacturas.resumenImportes_moneda_origen> iresumenImportesMonedaOrigen = new List<FeaEntidades.InterFacturas.resumenImportes_moneda_origen>();
                    iresumenImportesMonedaOrigen.Add(Lc.comprobante[i].resumen.importes_moneda_origen);
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.resumenImportes_moneda_origen));
                    e.AppendToFile(NombreProcesado, iresumenImportesMonedaOrigen);
                }

                List<FeaEntidades.InterFacturas.resumen> iresumen = new List<FeaEntidades.InterFacturas.resumen>();
                iresumen.Add(Lc.comprobante[i].resumen);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.resumen));
                e.AppendToFile(NombreProcesado, iresumen);
            }
        }
        public static void GuardarItfTXTlr(out string NombreProcesado, eFact_R.Entidades.Lote Lote, string PreFijo, string Ruta, bool IF)
        {
            //Deserializar ( pasar de XML a FeaEntidades.InterFacturas.lote_comprobantes )
            List<FeaEntidades.InterFacturas.lote_response> lLr = new List<FeaEntidades.InterFacturas.lote_response>();
            FeaEntidades.InterFacturas.lote_response Lr = new FeaEntidades.InterFacturas.lote_response();
            eFact_R.RN.Lote.DeserializarLr(out Lr, Lote.LoteXmlIF);
            lLr.Add(Lr);

            //Evento de escritura de txt
            FileHelperEngine e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.lote_response));
            string nombreProcesado = "";
            GenerarNombreArch(out nombreProcesado, Ruta, PreFijo, Lote, "txt");
            NombreProcesado = nombreProcesado;
            e.WriteFile(NombreProcesado, lLr);

            foreach (FeaEntidades.InterFacturas.error elote in Lr.errores_lote)
            {
                if (elote != null)
                {
                    List<FeaEntidades.InterFacturas.error> ierrores_lote = new List<FeaEntidades.InterFacturas.error>();
                    ierrores_lote.Add(elote);
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.error));
                    e.AppendToFile(NombreProcesado, ierrores_lote);
                }
            }
            if (Lr.comprobante_response != null)
            {
                foreach (FeaEntidades.InterFacturas.comprobante_response comprobante in Lr.comprobante_response)
                {
                    List<FeaEntidades.InterFacturas.comprobante_response> icr = new List<FeaEntidades.InterFacturas.comprobante_response>();
                    icr.Add(comprobante);
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.comprobante_response));
                    e.AppendToFile(NombreProcesado, icr);
                    if (comprobante.errores_comprobante != null)
                    {
                        foreach (FeaEntidades.InterFacturas.error ecomprobante in comprobante.errores_comprobante)
                        {
                            if (ecomprobante != null)
                            {
                                List<FeaEntidades.InterFacturas.error> ierrores_comprobante = new List<FeaEntidades.InterFacturas.error>();
                                ierrores_comprobante.Add(ecomprobante);
                                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.error));
                                e.AppendToFile(NombreProcesado, ierrores_comprobante);
                            }
                        }
                    }
                }
            }
        }
        public static void GuardarItfXML(out string NombreProcesado, eFact_R.Entidades.Lote Lote, string PreFijo, string Ruta, bool IF, bool ParaSubirAIF)
        {
            System.Text.Encoding codificador;
            codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
            string cadena = Cadena(Lote, IF);
            if (ParaSubirAIF)
            {
                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                DeserializarLc(out lc, cadena);
                for (int i = 0; i < lc.comprobante.Length; i++)
                {
                    Engine engine = new Engine(); 
                    if (lc.comprobante[i].extensiones != null && (lc.comprobante[i].extensiones.extensiones_datos_comerciales != null && lc.comprobante[i].extensiones.extensiones_datos_comerciales != ""))
                    {
                        lc.comprobante[i].extensiones.extensiones_datos_comerciales = engine.ConvertToHex(lc.comprobante[i].extensiones.extensiones_datos_comerciales);
                    }
                    if (lc.comprobante[i].extensiones != null && (lc.comprobante[i].extensiones.extensiones_datos_marketing != null && lc.comprobante[i].extensiones.extensiones_datos_marketing != ""))
                    {
                        lc.comprobante[i].extensiones.extensiones_datos_marketing = engine.ConvertToHex(lc.comprobante[i].extensiones.extensiones_datos_marketing);
                    }
                }
                SerializarLc(out cadena, lc);
            }
            byte[] a = new byte[cadena.Length];
            a = codificador.GetBytes(cadena);
            GenerarNombreArch(out NombreProcesado, Ruta, PreFijo, Lote, "xml");
            FileStream fs = File.Create(NombreProcesado);
            fs.Write(a, 0, a.Length);
            fs.Close();
        }
        private static string Cadena(eFact_R.Entidades.Lote Lote, bool IF)  
        {
            string cadena = "";
            if (IF)
            {
                cadena = Lote.LoteXmlIF;
            }
            else
            {
                cadena = Lote.LoteXml;
            }
            return cadena;
        }
        private static void GenerarNombreArch(out string NombreArch, string Ruta, string Prefijo, eFact_R.Entidades.Lote Lote, string Extension)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(Ruta);
            sb.Append(Prefijo);
            sb.Append("-");
            sb.Append(Lote.CuitVendedor);
            sb.Append("-");
            sb.Append(Convert.ToInt32(Lote.PuntoVenta).ToString("0000"));
            sb.Append("-");
            sb.Append(Lote.NumeroLote);
            sb.Append("-");
            sb.Append(Lote.NumeroEnvio.ToString());
            sb.Append("-");
            sb.Append(DateTime.Now.ToString("yyyyMMdd-hhmmss"));
            sb.Append("." + Extension);
            NombreArch = sb.ToString();
        }
        public static void ConsultarLoteIF(out FeaEntidades.InterFacturas.lote_comprobantes Lc, out CedWebRN.IBK.error[] RespErroresLote, out CedWebRN.IBK.error[] RespErroresComprobantes, eFact_R.Entidades.Lote Lote, string WSCertificado)
        {
            CedWebRN.IBK.error[] respErroresLote = new CedWebRN.IBK.error[0];
            CedWebRN.IBK.error[] respErroresComprobantes = new CedWebRN.IBK.error[0];
            FeaEntidades.InterFacturas.lote_comprobantes lcIBK = new FeaEntidades.InterFacturas.lote_comprobantes();
            CedWebRN.IBK.consulta_lote_comprobantes clc = new CedWebRN.IBK.consulta_lote_comprobantes();
            try
            {
                CedWebRN.Comprobante CedWebRNComprobante = new CedWebRN.Comprobante();
                if (Lote.LoteXml != null || Lote.LoteXmlIF != null)
                {
                    FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                    if (Lote.LoteXmlIF != null && Lote.LoteXmlIF != "")
                    {
                        eFact_R.RN.Lote.DeserializarLc(out lc, Lote, true);
                    }
                    else
                    {
                        eFact_R.RN.Lote.DeserializarLc(out lc, Lote, false);
                    }
                    clc.cod_interno_canal = lc.cabecera_lote.cod_interno_canal;
                    clc.cuit_canal = lc.cabecera_lote.cuit_canal;
                    clc.cuit_vendedor = lc.cabecera_lote.cuit_vendedor;
                    clc.punto_de_venta = lc.cabecera_lote.punto_de_venta;
                    clc.punto_de_ventaSpecified = true;
                    clc.id_lote = lc.cabecera_lote.id_lote;
                }
                else
                {
                    clc.cuit_canal = Convert.ToInt64(@System.Configuration.ConfigurationManager.AppSettings["CuitCanal"]);
                    clc.id_lote = Convert.ToInt64(Lote.NumeroLote);
                    clc.cuit_vendedor = Convert.ToInt64(Lote.CuitVendedor);
                    clc.punto_de_venta = Convert.ToInt32(Lote.PuntoVenta);
                    clc.punto_de_ventaSpecified = true;
                }
                lcIBK = CedWebRNComprobante.ConsultarIBK(out respErroresLote, out respErroresComprobantes, clc, WSCertificado);
                RespErroresLote = respErroresLote;
                RespErroresComprobantes = respErroresComprobantes;
            }
            catch (Exception ex)
            {
                RespErroresLote = respErroresLote;
                RespErroresComprobantes = respErroresComprobantes;
                throw new Exception(ex.Message);
            }
            Lc = lcIBK;
        }
        public static void MuestroEsquemaSegEventosPosibles(System.Windows.Forms.TreeView tvw, eFact_R.Entidades.Lote lote) 
        {
            List<CedEntidades.EsqSegEvenPos> dvEventoSeg;
            List<CedEntidades.Evento> dvEvento;
            dvEventoSeg = lote.WF.EsquemaSegEventosPosibles;
            dvEvento = lote.WF.EventosPosibles;
            if (dvEvento == null)
            {
                return;
            }
            TreeNodeCollection nds = tvw.Nodes;
            TreeNode ndNuevo;
            List<CedEntidades.EsqSegEvenPos> dr;
            nds.Clear();
            ndNuevo = new TreeNode("Esquema de seguridad de los eventos posibles");
            ndNuevo.Tag = "";
            nds.Add(ndNuevo);
            for (int i = 0; i < dvEvento.Count; i++)
            {
                ndNuevo = new TreeNode(dvEvento[i].Descr);
                ndNuevo.Tag = dvEvento[i].Id;
                nds[0].Nodes.Add(ndNuevo);
                dr = dvEventoSeg.FindAll((delegate(CedEntidades.EsqSegEvenPos e1) { return e1.Evento.Id == dvEvento[i].Id; }));
                for (int j = 0; j < dr.Count; j++)
                {
                    ndNuevo = new TreeNode("Grupo: " + dr[j].Grupo.Descr);
                    ndNuevo.Tag = dvEvento[i].Id;
                    nds[0].Nodes[nds[0].Nodes.Count - 1].Nodes.Add(ndNuevo);
                    TreeNode nd = nds[0].Nodes[nds[0].Nodes.Count - 1].Nodes[nds[0].Nodes[nds[0].Nodes.Count - 1].Nodes.Count - 1];
                    string a = "(";
                    switch (dr[j].CantInterv)
                    {
                        case 0:
                            a = a + "n intervenciones";
                            break;
                        case 1:
                            a = a + "1 intervencion";
                            break;
                        default:
                            a = a + dr[j].CantInterv.ToString() + " intervenciones";
                            break;
                    }
                    switch (dr[j].DebeSerSP)
                    {
                        case "S":
                            a = a + " SP";
                            break;
                        case "N":
                            a = a + " no SP";
                            break;
                        case "NA":
                            break;
                    }
                    if (dr[j].SupervisorNivelDsd != 0 ||
                        dr[j].SupervisorNivelHst != 255)
                    {
                        a = a + ", niv: " + dr[j].SupervisorNivelDsd.ToString() + " a " + dr[j].SupervisorNivelHst.ToString();
                    }
                    a = a + ")";
                    if (dr[j].Evento.Automatico)
                    {
                        a = a + " AUTOMATICO";
                    }
                    ndNuevo = new TreeNode(a);
                    ndNuevo.Tag = dvEvento[i].Id;
                    nd.Nodes.Add(ndNuevo);
                    nd.Expand();
                }
                nds[0].Nodes[nds[0].Nodes.Count - 1].Expand();
            }
            nds[0].Expand();
            nds = null;
        }

        public static void Lc2Lote(out eFact_R.Entidades.Lote Lote, FeaEntidades.InterFacturas.lote_comprobantes Lc, CedEntidades.Sesion Sesion)
        {
            if (Lc.cabecera_lote.cuit_vendedor.ToString().Trim() != eFact_R.Aplicacion.OtrosFiltrosCuit.Trim() && eFact_R.Aplicacion.OtrosFiltrosCuit.Trim() != "")
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Archivo.CUITNoHabilitadoParaElUsuario(Lc.cabecera_lote.cuit_vendedor.ToString());
            }
            eFact_R.Entidades.Lote lote = new eFact_R.Entidades.Lote();
            lote.CuitVendedor = Lc.cabecera_lote.cuit_vendedor.ToString();
            lote.PuntoVenta = Lc.cabecera_lote.punto_de_venta.ToString();
            lote.NumeroLote = Lc.cabecera_lote.id_lote.ToString();
            lote.FechaAlta = DateTime.Now;
            if (Lc.cabecera_lote.fecha_envio_lote != null)
            {
                lote.FechaEnvio = ConvertirStringToDateTime(Lc.cabecera_lote.fecha_envio_lote.ToString());
            }
            else
            {
                lote.FechaEnvio = Convert.ToDateTime("31/12/9998");
            }
            lote.CantidadRegistros = Convert.ToInt32(Lc.cabecera_lote.cantidad_reg.ToString());
            
            //Verificar bandeja de salida.
            //int numeroEnvioDisponible = 0;
            //eFact_R.RN.Lote.ObtenerNumeroEnvioDisponible(out numeroEnvioDisponible, lote.CuitVendedor, lote.NumeroLote, lote.PuntoVenta, eFact_R.Aplicacion.Sesion);
            
            string loteXml = "";
            eFact_R.RN.Lote.SerializarLc(out loteXml, Lc);
            lote.LoteXmlIF = loteXml;
            lote.NumeroEnvio = 0;
            lote.NombreArch = "";
            lote.WF = Cedeira.SV.WF.Nueva("eFact", "Fact", 0, "Facturacion Electrónica", Sesion);
            for (int i = 0; i < Lc.cabecera_lote.cantidad_reg; i++)
            {
                eFact_R.Entidades.Comprobante c = new eFact_R.Entidades.Comprobante();
                c.IdTipoComprobante = Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante.ToString());
                c.NumeroComprobante = Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante.ToString();
                c.TipoDocComprador = Convert.ToInt16(Lc.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString());
                c.NroDocComprador = Lc.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio.ToString();
                c.NombreComprador = Lc.comprobante[i].cabecera.informacion_comprador.denominacion;
                c.Fecha = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_emision.ToString());
                c.NumeroCAE = Convert.ToString(Lc.comprobante[i].cabecera.informacion_comprobante.cae);
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae != null && Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString() != "")
                {
                    c.FechaCAE = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString());
                }
                if (Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae != null && Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString() != "")
                {
                    c.FechaVtoCAE = ConvertirStringToDateTime(Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString());
                }
                c.IdMoneda = Convert.ToString(Lc.comprobante[i].resumen.codigo_moneda);
                c.Importe = Convert.ToDecimal(Lc.comprobante[i].resumen.importe_total_factura);
                if (Lc.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    c.ImporteMonedaOrigen = Convert.ToDecimal(Lc.comprobante[i].resumen.importes_moneda_origen.importe_total_factura);
                }
                if (Lc.comprobante[i].cabecera.informacion_comprobante.resultado != null)
                {
                    c.EstadoIFoAFIP = Convert.ToString(Lc.comprobante[i].cabecera.informacion_comprobante.resultado);
                }
                if (Lc.comprobante[i].cabecera.informacion_comprobante.motivo != null)
                {
                    c.ComentarioIFoAFIP = Convert.ToString(Lc.comprobante[i].cabecera.informacion_comprobante.motivo);
                }
                c.TipoCambio = Convert.ToDecimal(Lc.comprobante[i].resumen.tipo_de_cambio);
                lote.Comprobantes.Add(c);
            }
            Lote = lote;
        }
        private static DateTime ConvertirStringToDateTime(String sFecha)
        {
            return Convert.ToDateTime(sFecha.Substring(0, 4) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(6, 2));
        }
    }
}
