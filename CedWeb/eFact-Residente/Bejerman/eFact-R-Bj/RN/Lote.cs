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
            for (int i = 0; i < Lc.comprobante.Length; i++)
            {
                eFact_R.Entidades.Comprobante c = Lote.Comprobantes.Find((delegate(eFact_R.Entidades.Comprobante e1) { return e1.IdTipoComprobante == Lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante.ToString() &&  e1.NumeroComprobante == Lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante.ToString(); }));
                c.NumeroCAE = Lc.comprobante[i].cabecera.informacion_comprobante.cae.ToString();
                string sFecha = Lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae.ToString();
                c.FechaCAE = Convert.ToDateTime(sFecha.Substring(0, 4) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(6, 2));
                sFecha = Lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae.ToString();
                c.FechaVtoCAE = Convert.ToDateTime(sFecha.Substring(0, 4) + "/" + sFecha.Substring(4, 2) + "/" + sFecha.Substring(6, 2));
            }
        }
        public static void Ejecutar(eFact_R.Entidades.Lote Lote, CedEntidades.Evento Evento, string Handler, CedEntidades.Sesion Sesion)
        {
            string handlerEvento = "";
            //VerificarAssemblyVersion();
            eFact_R.DB.Lote lote = new eFact_R.DB.Lote(Sesion);
            switch (Lote.WF.IdFlow)
            {
                case "eFact":
                    switch (Evento.Id)
                    {
                        case "EnvBandSalida":
                            {
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
                            }
                        case "EnviarAIF":
                            {
                                handlerEvento += Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                                lote.ActualizarFechaEnvio(Lote, handlerEvento);
                                break;
                            }
                        case "RegAceptAFIP":
                            {
                                handlerEvento = Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, true);
                                lote.ActualizarDatosCAE(Lote, handlerEvento);
                                string archivoProcesado = "";
                                if (eFact_R.Aplicacion.TipoItfAut == "XML")
                                {
                                    GuardarItfXML(out archivoProcesado, Lote, eFact_R.Aplicacion.ArchPathItfAut, true);
                                }
                                else if (eFact_R.Aplicacion.TipoItfAut == "TXT")
                                {
                                    GuardarItfTXT(out archivoProcesado, Lote, eFact_R.Aplicacion.ArchPathItfAut, true);
                                }
                                break;
                            }
                        default:
                            Cedeira.SV.WF.EjecutarEvento(Lote.WF, Evento, false);
                            break;
                    }
                    break;
            }
        }
        public static void DeserializarLc(out FeaEntidades.InterFacturas.lote_comprobantes Lc, eFact_R.Entidades.Lote Lote, bool IF)
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
        public static void GuardarItfTXT(out string NombreProcesado, eFact_R.Entidades.Lote Lote, string Ruta, bool IF)
        {
            //Deserializar ( pasar de XML a FeaEntidades.InterFacturas.lote_comprobantes )
            FeaEntidades.InterFacturas.lote_comprobantes Lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            eFact_R.RN.Lote.DeserializarLc(out Lc, Lote, IF);

            //Evento de escritura de txt
            List<FeaEntidades.InterFacturas.cabecera_lote> clote = new List<FeaEntidades.InterFacturas.cabecera_lote>();
            clote.Add(Lc.cabecera_lote);
            FileHelperEngine e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.cabecera_lote));
            string nombreProcesado = "";
            GenerarNombreArch(out nombreProcesado, Ruta, "Itf", Lote, "txt");
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

                if (Lc.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.informacion_comprobanteReferencias));
                    e.AppendToFile(NombreProcesado, Lc.comprobante[i].cabecera.informacion_comprobante.referencias);
                }

                List<FeaEntidades.InterFacturas.informacion_vendedor> ivendedor = new List<FeaEntidades.InterFacturas.informacion_vendedor>();
                ivendedor.Add(Lc.comprobante[i].cabecera.informacion_vendedor);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.informacion_vendedor));
                e.AppendToFile(NombreProcesado, ivendedor);

                List<FeaEntidades.InterFacturas.detalle> idetalle = new List<FeaEntidades.InterFacturas.detalle>();
                idetalle.Add(Lc.comprobante[i].detalle);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.detalle));
                e.AppendToFile(NombreProcesado, idetalle);

                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.linea));
                e.AppendToFile(NombreProcesado, Lc.comprobante[i].detalle.linea);

                List<FeaEntidades.InterFacturas.resumen> iresumen = new List<FeaEntidades.InterFacturas.resumen>();
                iresumen.Add(Lc.comprobante[i].resumen);
                e = new FileHelperEngine(typeof(FeaEntidades.InterFacturas.resumen));
                e.AppendToFile(NombreProcesado, iresumen);
            }
        }
        public static void GuardarItfXML(out string NombreProcesado, eFact_R.Entidades.Lote Lote, string Ruta, bool IF)
        {
            System.Text.Encoding codificador;
            codificador = System.Text.Encoding.GetEncoding("iso-8859-1");
            string cadena = "";
            if (IF)
            {
                cadena = Lote.LoteXmlIF;
            }
            else
            {
                cadena = Lote.LoteXml;
            }
            byte[] a = new byte[cadena.Length];
            a = codificador.GetBytes(cadena);
            GenerarNombreArch(out NombreProcesado, Ruta, "Itf", Lote, "xml");
            FileStream fs = File.Create(NombreProcesado);
            fs.Write(a, 0, a.Length);
            fs.Close();
        }
        private static void GenerarNombreArch(out string NombreArch, string Ruta, string Prefijo, eFact_R.Entidades.Lote Lote, string Extension)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(Ruta);
            sb.Append(Prefijo);
            sb.Append("-");
            sb.Append(Lote.CuitVendedor);
            sb.Append("-");
            sb.Append(Lote.PuntoVenta);
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
            try
            {
                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                eFact_R.RN.Lote.DeserializarLc(out lc, Lote, false);

                CedWebRN.Comprobante CedWebRNComprobante = new CedWebRN.Comprobante();
                CedWebRN.IBK.consulta_lote_comprobantes clc = new CedWebRN.IBK.consulta_lote_comprobantes();
                clc.cod_interno_canal = lc.cabecera_lote.cod_interno_canal;
                clc.cuit_canal = lc.cabecera_lote.cuit_canal;
                clc.cuit_vendedor = lc.cabecera_lote.cuit_vendedor;
                clc.punto_de_venta = lc.cabecera_lote.punto_de_venta;
                clc.punto_de_ventaSpecified = true;
                clc.id_lote = lc.cabecera_lote.id_lote;
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
    }
}
