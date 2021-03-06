using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace eFact_C
{
    public class Comprobante
    {
        public FeaEntidades.InterFacturas.lote_comprobantes ConsultarIBK(out List<FeaEntidades.InterFacturas.error> RespErroresLote, out List<FeaEntidades.InterFacturas.error> RespErroresComprobantes, eFact_C.IBK.consulta_lote_comprobantes clc, string url, eFact_C.Entidades.Certificado Certificado, eFact_C.Entidades.Proxy Proxy)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            lc.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lc.comprobante = new FeaEntidades.InterFacturas.comprobante[1];
            IBK.error[] respErroresLote = new IBK.error[0];
            IBK.error[] respErroresComprobantes = new IBK.error[0];
			IBK.FacturaWebServiceConSchema objIBK;
			objIBK = new IBK.FacturaWebServiceConSchema();
            objIBK.Url = url;
            if (Proxy != null)
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(Proxy.Servidor, false);
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(Proxy.Usuario, Proxy.Clave, Proxy.Dominio);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            X509Store store;
            if (Certificado.LugarDeAlmacenamiento == eFact_C.Entidades.Certificado.Almacenamiento.CurrentUser)
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, Certificado.Numero, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                IBK.consulta_lote_comprobantes_response clcr = objIBK.getLoteFacturasConSchema(clc);
                IBK.consulta_lote_response clr;
                try
                {
                    clr = (IBK.consulta_lote_response)clcr.Item;
                    IBK.lote_comprobantes lcIBK = (IBK.lote_comprobantes)clr.Item;
                    lc = Ibk2Fea(lcIBK);
                }
                catch (InvalidCastException)
                {
                    StringBuilder errorText = new StringBuilder();
                    if (clcr.Item != null)
                    {
                        errorText.Append("Nro. de Lote: [" + clc.id_lote + "] \r\n");
                        if (clcr.Item.GetType() == typeof(IBK.consulta_lote_response))
                        {
                            clr = (IBK.consulta_lote_response)clcr.Item;
                            IBK.consulta_lote_responseErrores_consulta errores = (IBK.consulta_lote_responseErrores_consulta)clr.Item;
                            foreach (IBK.error elote in errores.error)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + " \r\n");
                            }
                            RespErroresLote = Ibk2Fea(errores.error);
                        }
                        else
                        {
                            IBK.consulta_lote_comprobantes_responseErrores_response clcrEr;
                            clcrEr = (IBK.consulta_lote_comprobantes_responseErrores_response)clcr.Item;
                            foreach (IBK.error elote in clcrEr.error)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + " \r\n");
                            }
                            RespErroresComprobantes = Ibk2Fea(clcrEr.error);
                        }
                    }
                    throw new Exception(errorText.ToString());
                }
                RespErroresLote = new List<FeaEntidades.InterFacturas.error>();
                RespErroresComprobantes = new List<FeaEntidades.InterFacturas.error>();
                return lc;
            }
            else
            {
                throw new Exception("Su certificado no est� disponible en nuestro repositorio");
            }
        }
        public FeaEntidades.InterFacturas.lote_response EnviarIBK(out List<FeaEntidades.InterFacturas.error> RespErroresLote, out List<FeaEntidades.InterFacturas.error> RespErroresComprobantes, FeaEntidades.InterFacturas.lote_comprobantes lc, string url, eFact_C.Entidades.Certificado Certificado, eFact_C.Entidades.Proxy Proxy)
        {
            FeaEntidades.InterFacturas.lote_response Lr = new FeaEntidades.InterFacturas.lote_response();
            IBK.lote_comprobantes lcIBK = new IBK.lote_comprobantes();
            lcIBK = Fea2Ibk(lc);
            IBK.error[] respErroresLote = new IBK.error[0];
            IBK.error[] respErroresComprobantes = new IBK.error[0];
            IBK.FacturaWebServiceConSchema objIBK;
            objIBK = new IBK.FacturaWebServiceConSchema();
            objIBK.Url = url;
            if (Proxy != null)
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(Proxy.Servidor, false);
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(Proxy.Usuario, Proxy.Clave, Proxy.Dominio);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            X509Store store;
            if (Certificado.LugarDeAlmacenamiento == eFact_C.Entidades.Certificado.Almacenamiento.CurrentUser)
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, Certificado.Numero, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                IBK.lote_comprobantes_response lcr = objIBK.receiveFacturasConSchema(lcIBK);
                IBK.lote_response lr = new IBK.lote_response();
                RespErroresLote = new List<FeaEntidades.InterFacturas.error>();
                RespErroresComprobantes = new List<FeaEntidades.InterFacturas.error>();
                try
                {
                    lr = ((IBK.lote_response)lcr.Item);
                    if (lr.estado == "OK")
                    {
                        Lr = Ibk2Fea(lr);
                    }
                    else
                    {
                        Lr = Ibk2Fea(lr);
                        StringBuilder errorText = new StringBuilder();
                        if (lr.errores_lote != null)
                        {
                            errorText.Append("Nro. de Lote: [" + Lr.id_lote + "] \r\n");
                            foreach (IBK.error elote in lr.errores_lote)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + " \r\n");
                            }
                            RespErroresLote.AddRange(Ibk2Fea(lr.errores_lote));
                        }
                        if (lr.comprobante_response != null)
                        {
                            foreach (IBK.comprobante_response comprobante in lr.comprobante_response)
                            {
                                if (comprobante.errores_comprobante != null)
                                {
                                    if (lr.errores_lote != null)
                                    {
                                        errorText.Append("\r\n");
                                    }
                                    errorText.Append("Punto de Venta: [" + comprobante.punto_de_venta + "]  Tipo de Comprobante: [" + comprobante.tipo_de_comprobante + "]  Nro. de Comprobante: [" + comprobante.numero_comprobante + "] \r\n");
                                    foreach (IBK.error ecomprobante in comprobante.errores_comprobante)
                                    {
                                        errorText.Append(ecomprobante.codigo_error + " - " + ecomprobante.descripcion_error + " \r\n");
                                    }
                                    RespErroresComprobantes.AddRange(Ibk2Fea(comprobante.errores_comprobante));
                                }
                            }
                        }
                        throw new Exception(errorText.ToString());
                    }
                    return Lr;
                }
                catch (InvalidCastException)
                {
                    StringBuilder errorText = new StringBuilder();
                    if (lcr.Item != null)
                    {
                        if (lcr.Item.GetType() == typeof(IBK.lote_comprobantes_responseErrores_response))
                        {
                            IBK.lote_comprobantes_responseErrores_response lcrEr = new IBK.lote_comprobantes_responseErrores_response();
                            errorText.Append("Nro. de Lote: [" + lc.cabecera_lote.id_lote + "] \r\n");
                            lcrEr = (IBK.lote_comprobantes_responseErrores_response)lcr.Item;
                            foreach (IBK.error error in lcrEr.error)
                            {
                                errorText.Append(error.codigo_error + " - " + error.descripcion_error + " \r\n");
                            }
                            RespErroresLote = Ibk2Fea(lcrEr.error);
                        }
                    }
                    throw new Exception(errorText.ToString());
                }
            }
            else
            {
                throw new Exception("Su certificado no est� disponible en nuestro repositorio");
            }
        }
        private FeaEntidades.InterFacturas.lote_comprobantes Ibk2Fea(IBK.lote_comprobantes lcIBK)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lcFEA = new FeaEntidades.InterFacturas.lote_comprobantes();

            lcFEA.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lcFEA.cabecera_lote.cantidad_reg = lcIBK.cabecera_lote.cantidad_reg;
            lcFEA.cabecera_lote.cod_interno_canal = lcIBK.cabecera_lote.cod_interno_canal;
            lcFEA.cabecera_lote.cuit_canal = lcIBK.cabecera_lote.cuit_canal;
            lcFEA.cabecera_lote.cuit_vendedor = lcIBK.cabecera_lote.cuit_vendedor;
            lcFEA.cabecera_lote.fecha_envio_lote = lcIBK.cabecera_lote.fecha_envio_lote;
            lcFEA.cabecera_lote.id_lote = lcIBK.cabecera_lote.id_lote;
            lcFEA.cabecera_lote.motivo = lcIBK.cabecera_lote.motivo;
            lcFEA.cabecera_lote.presta_serv = lcIBK.cabecera_lote.presta_serv;
            lcFEA.cabecera_lote.presta_servSpecified = lcIBK.cabecera_lote.presta_servSpecified;
            lcFEA.cabecera_lote.punto_de_venta = lcIBK.cabecera_lote.punto_de_venta;
            lcFEA.cabecera_lote.resultado = lcIBK.cabecera_lote.resultado;

            lcFEA.comprobante = new FeaEntidades.InterFacturas.comprobante[lcIBK.comprobante.Length];

            for (int i = 0; i < lcIBK.comprobante.Length; i++)
            {
                FeaEntidades.InterFacturas.comprobante cIBK = new FeaEntidades.InterFacturas.comprobante();

                cIBK.cabecera = new FeaEntidades.InterFacturas.cabecera();

                //Comprador
                cIBK.cabecera.informacion_comprador = new FeaEntidades.InterFacturas.informacion_comprador();
                cIBK.cabecera.informacion_comprador.codigo_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_interno;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_comprador.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVA;
                cIBK.cabecera.informacion_comprador.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVASpecified;
                cIBK.cabecera.informacion_comprador.contacto = lcIBK.comprobante[i].cabecera.informacion_comprador.contacto;
                cIBK.cabecera.informacion_comprador.cp = lcIBK.comprobante[i].cabecera.informacion_comprador.cp;
                cIBK.cabecera.informacion_comprador.denominacion = lcIBK.comprobante[i].cabecera.informacion_comprador.denominacion;
                cIBK.cabecera.informacion_comprador.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_calle;
                cIBK.cabecera.informacion_comprador.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_depto;
                cIBK.cabecera.informacion_comprador.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_manzana;
                cIBK.cabecera.informacion_comprador.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_numero;
                cIBK.cabecera.informacion_comprador.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_piso;
                cIBK.cabecera.informacion_comprador.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_sector;
                cIBK.cabecera.informacion_comprador.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_torre;
                cIBK.cabecera.informacion_comprador.email = lcIBK.comprobante[i].cabecera.informacion_comprador.email;
                cIBK.cabecera.informacion_comprador.GLN = lcIBK.comprobante[i].cabecera.informacion_comprador.GLN;
                cIBK.cabecera.informacion_comprador.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.GLNSpecified;
                cIBK.cabecera.informacion_comprador.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades;
                cIBK.cabecera.informacion_comprador.localidad = lcIBK.comprobante[i].cabecera.informacion_comprador.localidad;
                cIBK.cabecera.informacion_comprador.nro_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.provincia = lcIBK.comprobante[i].cabecera.informacion_comprador.provincia;
                cIBK.cabecera.informacion_comprador.telefono = lcIBK.comprobante[i].cabecera.informacion_comprador.telefono;
                
                //Info Comprobante
                cIBK.cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lcIBK.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
                cIBK.cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;
                cIBK.cabecera.informacion_comprobante.es_detalle_encriptado = lcIBK.comprobante[i].cabecera.informacion_comprobante.es_detalle_encriptado;
                cIBK.cabecera.informacion_comprobante.fecha_emision = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_emision;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.fecha_serv_desde = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_desde;
                cIBK.cabecera.informacion_comprobante.fecha_serv_hasta = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_hasta;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.iva_computable = lcIBK.comprobante[i].cabecera.informacion_comprobante.iva_computable;
                cIBK.cabecera.informacion_comprobante.motivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.motivo;
                cIBK.cabecera.informacion_comprobante.numero_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
                cIBK.cabecera.informacion_comprobante.punto_de_venta = lcIBK.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
                cIBK.cabecera.informacion_comprobante.resultado = lcIBK.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;

                //Info Vendedor
                cIBK.cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
                cIBK.cabecera.informacion_vendedor.razon_social = lcIBK.comprobante[i].cabecera.informacion_vendedor.razon_social;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_vendedor.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVA;
                cIBK.cabecera.informacion_vendedor.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified;
                cIBK.cabecera.informacion_vendedor.contacto = lcIBK.comprobante[i].cabecera.informacion_vendedor.contacto;
                cIBK.cabecera.informacion_vendedor.cp = lcIBK.comprobante[i].cabecera.informacion_vendedor.cp;
                cIBK.cabecera.informacion_vendedor.cuit = lcIBK.comprobante[i].cabecera.informacion_vendedor.cuit;
                cIBK.cabecera.informacion_vendedor.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_calle;
                cIBK.cabecera.informacion_vendedor.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_depto;
                cIBK.cabecera.informacion_vendedor.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana;
                cIBK.cabecera.informacion_vendedor.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_numero;
                cIBK.cabecera.informacion_vendedor.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_piso;
                cIBK.cabecera.informacion_vendedor.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_sector;
                cIBK.cabecera.informacion_vendedor.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_torre;
                cIBK.cabecera.informacion_vendedor.email = lcIBK.comprobante[i].cabecera.informacion_vendedor.email;
                cIBK.cabecera.informacion_vendedor.GLN = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLN;
                cIBK.cabecera.informacion_vendedor.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLNSpecified;
                cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades;
                cIBK.cabecera.informacion_vendedor.localidad = lcIBK.comprobante[i].cabecera.informacion_vendedor.localidad;
                cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.provincia = lcIBK.comprobante[i].cabecera.informacion_vendedor.provincia;
                cIBK.cabecera.informacion_vendedor.telefono = lcIBK.comprobante[i].cabecera.informacion_vendedor.telefono;

                //Info Comprobantes de Referencia
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    cIBK.cabecera.informacion_comprobante.referencias = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias[lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length];

                    for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length; j++)
                    {
                        if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.referencias[j] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                            cIBK.cabecera.informacion_comprobante.referencias[j].codigo_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                            cIBK.cabecera.informacion_comprobante.referencias[j].dato_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].dato_de_referencia;
                        }
                    }
                }

                //Info Exportaci�n
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion = new FeaEntidades.InterFacturas.informacion_exportacion();
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.id_impositivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms;
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != null && lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente;
                    }
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos = new FeaEntidades.InterFacturas.permisos[lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length];
                        for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length; j++)
                        {
                            if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j] != null)
                            {
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j] = new FeaEntidades.InterFacturas.permisos();
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso;
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia;
                            }
                        }
                    }
                }

                //Detalle y Lineas
                FeaEntidades.InterFacturas.detalle d = new FeaEntidades.InterFacturas.detalle();
                IBK.detalle detalle = (IBK.detalle)lcIBK.comprobante[i].Item;
                d.linea = new FeaEntidades.InterFacturas.linea[detalle.linea.Length];
                d.comentarios = detalle.comentarios;
                for (int j = 0; j < detalle.linea.Length; j++)
                {
                    if (detalle.linea[j] != null)
                    {
                        d.linea[j] = new FeaEntidades.InterFacturas.linea();
                        d.linea[j].alicuota_iva = detalle.linea[j].alicuota_iva;
                        d.linea[j].alicuota_ivaSpecified = detalle.linea[j].alicuota_ivaSpecified;
                        d.linea[j].cantidad = detalle.linea[j].cantidad;
                        d.linea[j].cantidadSpecified = detalle.linea[j].cantidadSpecified;
                        d.linea[j].codigo_producto_comprador = detalle.linea[j].codigo_producto_comprador;
                        d.linea[j].codigo_producto_vendedor = detalle.linea[j].codigo_producto_vendedor;
                        d.linea[j].descripcion = detalle.linea[j].descripcion;

                        d.linea[j].GTIN = detalle.linea[j].GTIN;
                        d.linea[j].GTINSpecified = detalle.linea[j].GTINSpecified;
                        d.linea[j].importe_iva = detalle.linea[j].importe_iva;
                        d.linea[j].importe_ivaSpecified = detalle.linea[j].importe_ivaSpecified;
                        d.linea[j].importe_total_articulo = detalle.linea[j].importe_total_articulo;
                        d.linea[j].importe_total_descuentos = detalle.linea[j].importe_total_descuentos;
                        d.linea[j].importe_total_descuentosSpecified = detalle.linea[j].importe_total_descuentosSpecified;
                        d.linea[j].importe_total_impuestos = detalle.linea[j].importe_total_impuestos;
                        d.linea[j].importe_total_impuestosSpecified = detalle.linea[j].importe_total_impuestosSpecified;

                        if (detalle.linea[j].importes_moneda_origen != null)
                        {
                            d.linea[j].importes_moneda_origen = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                            d.linea[j].importes_moneda_origen.importe_iva = detalle.linea[j].importes_moneda_origen.importe_iva;
                            d.linea[j].importes_moneda_origen.importe_ivaSpecified = detalle.linea[j].importes_moneda_origen.importe_ivaSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_articulo = detalle.linea[j].importes_moneda_origen.importe_total_articulo;
                            d.linea[j].importes_moneda_origen.importe_total_articuloSpecified = detalle.linea[j].importes_moneda_origen.importe_total_articuloSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_descuentos = detalle.linea[j].importes_moneda_origen.importe_total_descuentos;
                            d.linea[j].importes_moneda_origen.importe_total_descuentosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_descuentosSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_impuestos = detalle.linea[j].importes_moneda_origen.importe_total_impuestos;
                            d.linea[j].importes_moneda_origen.importe_total_impuestosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_impuestosSpecified;
                            d.linea[j].importes_moneda_origen.precio_unitario = detalle.linea[j].importes_moneda_origen.precio_unitario;
                            d.linea[j].importes_moneda_origen.precio_unitarioSpecified = detalle.linea[j].importes_moneda_origen.precio_unitarioSpecified;
                        }

                        if (detalle.linea[j].impuestos != null)
                        {
                            d.linea[j].impuestos = new FeaEntidades.InterFacturas.lineaImpuestos[detalle.linea[j].impuestos.Length];
                            for (int k = 0; k < d.linea[j].impuestos.Length; k++)
                            {
                                d.linea[j].impuestos[k] = new FeaEntidades.InterFacturas.lineaImpuestos();
                                d.linea[j].impuestos[k].codigo_impuesto = detalle.linea[j].impuestos[k].codigo_impuesto;
                                d.linea[j].impuestos[k].descripcion_impuesto = detalle.linea[j].impuestos[k].descripcion_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto = detalle.linea[j].impuestos[k].importe_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origen = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origen;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified;
                                d.linea[j].impuestos[k].porcentaje_impuesto = detalle.linea[j].impuestos[k].porcentaje_impuesto;
                                d.linea[j].impuestos[k].porcentaje_impuestoSpecified = detalle.linea[j].impuestos[k].porcentaje_impuestoSpecified;
                            }
                        }
                        if (detalle.linea[j].descuentos != null)
                        {
                            d.linea[j].lineaDescuentos = new FeaEntidades.InterFacturas.lineaDescuentos[detalle.linea[j].descuentos.Length];
                            for (int k = 0; k < d.linea[j].lineaDescuentos.Length; k++)
                            {
                                d.linea[j].lineaDescuentos[k] = new FeaEntidades.InterFacturas.lineaDescuentos();
                                d.linea[j].lineaDescuentos[k].descripcion_descuento = detalle.linea[j].descuentos[k].descripcion_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento = detalle.linea[j].descuentos[k].importe_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origen = detalle.linea[j].descuentos[k].importe_descuento_moneda_origen;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origenSpecified = detalle.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuento = detalle.linea[j].descuentos[k].porcentaje_descuento;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuentoSpecified = detalle.linea[j].descuentos[k].porcentaje_descuentoSpecified;
                            }
                        }
                        if (detalle.linea[j].informacion_adicional != null)
                        {
                            d.linea[j].informacion_adicional = new FeaEntidades.InterFacturas.lineaInformacion_adicional[detalle.linea[j].informacion_adicional.Length];
                            for (int k = 0; k < d.linea[j].informacion_adicional.Length; k++)
                            {
                                d.linea[j].informacion_adicional[k] = new FeaEntidades.InterFacturas.lineaInformacion_adicional();
                                d.linea[j].informacion_adicional[k].tipo = detalle.linea[j].informacion_adicional[k].tipo;
                                d.linea[j].informacion_adicional[k].valor = detalle.linea[j].informacion_adicional[k].valor;
                            }
                        }
                        d.linea[j].indicacion_exento_gravado = detalle.linea[j].indicacion_exento_gravado;
                        d.linea[j].numeroLinea = detalle.linea[j].numeroLinea;
                        d.linea[j].precio_unitario = detalle.linea[j].precio_unitario;
                        d.linea[j].precio_unitarioSpecified = detalle.linea[j].precio_unitarioSpecified;
                        d.linea[j].unidad = detalle.linea[j].unidad;
                    }
                    else
                    {
                        break;
                    }
                }
                cIBK.detalle = d;

                //Info Extensiones
                cIBK.extensiones = new FeaEntidades.InterFacturas.extensiones();
                if (lcIBK.comprobante[i].extensiones != null)
                {
                    cIBK.extensionesSpecified = true;
                }
                if (lcIBK.comprobante[i].extensiones.extensiones_camara_facturas != null)
                {
                    cIBK.extensiones.extensiones_camara_facturasSpecified = true;
                    cIBK.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
                    cIBK.extensiones.extensiones_camara_facturas.clave_de_vinculacion = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion;
                    cIBK.extensiones.extensiones_camara_facturas.id_idioma = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma;
                    cIBK.extensiones.extensiones_camara_facturas.id_template = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_template;
                }
                if (lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales != null)
                {
                    cIBK.extensiones.extensiones_datos_comerciales = lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales.ToString();
                }
                if (lcIBK.comprobante[i].extensiones.extensiones_datos_marketing != null)
                {
                    cIBK.extensiones.extensiones_datos_marketing = lcIBK.comprobante[i].extensiones.extensiones_datos_marketing;
                }
                if (lcIBK.comprobante[i].extensiones.extensiones_destinatarios != null)
                {
                    cIBK.extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
                    cIBK.extensiones.extensiones_destinatarios.email = lcIBK.comprobante[i].extensiones.extensiones_destinatarios.email;
                }

                cIBK.resumen = new FeaEntidades.InterFacturas.resumen();
                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[0];

                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importe_operaciones_exentas;
                cIBK.resumen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importe_total_concepto_no_gravado;
                cIBK.resumen.importe_total_factura = lcIBK.comprobante[i].resumen.importe_total_factura;
                cIBK.resumen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importe_total_impuestos_internos;
                cIBK.resumen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_internosSpecified;
                cIBK.resumen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipales;
                cIBK.resumen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipalesSpecified;
                cIBK.resumen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionales;
                cIBK.resumen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionalesSpecified;
                cIBK.resumen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutos;
                cIBK.resumen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutosSpecified;
                cIBK.resumen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importe_total_neto_gravado;

                if (lcIBK.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    cIBK.resumen.importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
                    cIBK.resumen.importes_moneda_origen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_operaciones_exentas;
                    cIBK.resumen.importes_moneda_origen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                    cIBK.resumen.importes_moneda_origen.importe_total_factura = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_factura;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internos;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_neto_gravado;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq_rni;
                }

                cIBK.resumen.impuesto_liq = lcIBK.comprobante[i].resumen.impuesto_liq;
                cIBK.resumen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.impuesto_liq_rni;

                if (lcIBK.comprobante[i].resumen.descuentos != null)
                {
                    cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[lcIBK.comprobante[i].resumen.descuentos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.descuentos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.descuentos[l] != null)
                        {
                            cIBK.resumen.descuentos[l] = new FeaEntidades.InterFacturas.resumenDescuentos();
                            cIBK.resumen.descuentos[l].alicuota_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuento;
                            cIBK.resumen.descuentos[l].alicuota_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].descripcion_descuento = lcIBK.comprobante[i].resumen.descuentos[l].descripcion_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].porcentaje_descuento = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuento;
                            cIBK.resumen.descuentos[l].porcentaje_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuentoSpecified;
                        }
                    }
                }

                if (lcIBK.comprobante[i].resumen.impuestos != null)
                {
                    cIBK.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[lcIBK.comprobante[i].resumen.impuestos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.impuestos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.impuestos[l] != null)
                        {
                            cIBK.resumen.impuestos[l] = new FeaEntidades.InterFacturas.resumenImpuestos();
                            cIBK.resumen.impuestos[l].codigo_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].codigo_impuesto;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccion = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccion;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccionSpecified = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccionSpecified;
                            cIBK.resumen.impuestos[l].descripcion = lcIBK.comprobante[i].resumen.impuestos[l].descripcion;
                            cIBK.resumen.impuestos[l].importe_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origen = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origen;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origenSpecified = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origenSpecified;
                            cIBK.resumen.impuestos[l].jurisdiccion_municipal = lcIBK.comprobante[i].resumen.impuestos[l].jurisdiccion_municipal;
                            cIBK.resumen.impuestos[l].porcentaje_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuesto;
                            cIBK.resumen.impuestos[l].porcentaje_impuestoSpecified = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuestoSpecified;
                        }
                    }
                }
                cIBK.resumen.observaciones = lcIBK.comprobante[i].resumen.observaciones;
                cIBK.resumen.tipo_de_cambio = lcIBK.comprobante[i].resumen.tipo_de_cambio;

                lcFEA.comprobante[i] = cIBK;
            }
            return lcFEA;
        }
        private List<FeaEntidades.InterFacturas.error> Ibk2Fea(IBK.error[] errorIBK)
        {
            List<FeaEntidades.InterFacturas.error> errorFEAlista = new List<FeaEntidades.InterFacturas.error>();
            for (int i = 0; i < errorIBK.Length; i++)
            {
                FeaEntidades.InterFacturas.error errorFEA = new FeaEntidades.InterFacturas.error();
                errorFEA.codigo_error = errorIBK[i].codigo_error;
                errorFEA.descripcion_error = errorIBK[i].descripcion_error;
                errorFEAlista.Add(errorFEA);
            }
            return errorFEAlista;
        }
        private FeaEntidades.InterFacturas.lote_response Ibk2Fea(IBK.lote_response lrIBK)
        {
            FeaEntidades.InterFacturas.lote_response lr = new FeaEntidades.InterFacturas.lote_response();
            lr.cuit_canal = lrIBK.cuit_canal;
            lr.cuit_vendedor = lrIBK.cuit_vendedor;
            lr.punto_de_venta = lrIBK.punto_de_venta;
            lr.id_lote = lrIBK.id_lote;
            return lr;
        }
        private IBK.lote_comprobantes Fea2Ibk(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            IBK.lote_comprobantes lcIBK = new IBK.lote_comprobantes();

            lcIBK.cabecera_lote = new IBK.cabecera_lote();
            lcIBK.cabecera_lote.cantidad_reg = lc.cabecera_lote.cantidad_reg;
            lcIBK.cabecera_lote.cod_interno_canal = lc.cabecera_lote.cod_interno_canal;
            lcIBK.cabecera_lote.cuit_canal = lc.cabecera_lote.cuit_canal;
            lcIBK.cabecera_lote.cuit_vendedor = lc.cabecera_lote.cuit_vendedor;
            lcIBK.cabecera_lote.fecha_envio_lote = lc.cabecera_lote.fecha_envio_lote;
            lcIBK.cabecera_lote.id_lote = lc.cabecera_lote.id_lote;
            lcIBK.cabecera_lote.motivo = lc.cabecera_lote.motivo;
            lcIBK.cabecera_lote.presta_serv = lc.cabecera_lote.presta_serv;
            lcIBK.cabecera_lote.presta_servSpecified = lc.cabecera_lote.presta_servSpecified;
            lcIBK.cabecera_lote.punto_de_venta = lc.cabecera_lote.punto_de_venta;
            lcIBK.cabecera_lote.resultado = lc.cabecera_lote.resultado;

            lcIBK.comprobante = new IBK.comprobante[lc.comprobante.Length];

            for (int i = 0; i < lc.comprobante.Length; i++)
            {
                if (lc.comprobante[i] == null)
                {
                    break;
                }
                IBK.comprobante cIBK = new IBK.comprobante();

                cIBK.cabecera = new IBK.cabecera();

                //Comprador
                cIBK.cabecera.informacion_comprador = new IBK.informacion_comprador();
                cIBK.cabecera.informacion_comprador.codigo_doc_identificatorio = lc.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.codigo_interno = lc.comprobante[i].cabecera.informacion_comprador.codigo_interno;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutos = lc.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = lc.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_comprador.condicion_IVA = lc.comprobante[i].cabecera.informacion_comprador.condicion_IVA;
                cIBK.cabecera.informacion_comprador.condicion_IVASpecified = lc.comprobante[i].cabecera.informacion_comprador.condicion_IVASpecified;
                cIBK.cabecera.informacion_comprador.contacto = lc.comprobante[i].cabecera.informacion_comprador.contacto;
                cIBK.cabecera.informacion_comprador.cp = lc.comprobante[i].cabecera.informacion_comprador.cp;
                cIBK.cabecera.informacion_comprador.denominacion = lc.comprobante[i].cabecera.informacion_comprador.denominacion;
                cIBK.cabecera.informacion_comprador.domicilio_calle = lc.comprobante[i].cabecera.informacion_comprador.domicilio_calle;
                cIBK.cabecera.informacion_comprador.domicilio_depto = lc.comprobante[i].cabecera.informacion_comprador.domicilio_depto;
                cIBK.cabecera.informacion_comprador.domicilio_manzana = lc.comprobante[i].cabecera.informacion_comprador.domicilio_manzana;
                cIBK.cabecera.informacion_comprador.domicilio_numero = lc.comprobante[i].cabecera.informacion_comprador.domicilio_numero;
                cIBK.cabecera.informacion_comprador.domicilio_piso = lc.comprobante[i].cabecera.informacion_comprador.domicilio_piso;
                cIBK.cabecera.informacion_comprador.domicilio_sector = lc.comprobante[i].cabecera.informacion_comprador.domicilio_sector;
                cIBK.cabecera.informacion_comprador.domicilio_torre = lc.comprobante[i].cabecera.informacion_comprador.domicilio_torre;
                cIBK.cabecera.informacion_comprador.email = lc.comprobante[i].cabecera.informacion_comprador.email;
                cIBK.cabecera.informacion_comprador.GLN = lc.comprobante[i].cabecera.informacion_comprador.GLN;
                cIBK.cabecera.informacion_comprador.GLNSpecified = lc.comprobante[i].cabecera.informacion_comprador.GLNSpecified;
                cIBK.cabecera.informacion_comprador.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades;
                cIBK.cabecera.informacion_comprador.localidad = lc.comprobante[i].cabecera.informacion_comprador.localidad;
                cIBK.cabecera.informacion_comprador.nro_doc_identificatorio = lc.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.provincia = lc.comprobante[i].cabecera.informacion_comprador.provincia;
                cIBK.cabecera.informacion_comprador.telefono = lc.comprobante[i].cabecera.informacion_comprador.telefono;

                //Info Comprobante
                cIBK.cabecera.informacion_comprobante = new IBK.informacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lc.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lc.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lc.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
                //cIBK.cabecera.informacion_comprobante.condicion_de_pagoSpecified = lc.comprobante[i].cabecera.informacion_comprobante.condicion_de_pagoSpecified;
                cIBK.cabecera.informacion_comprobante.es_detalle_encriptado = lc.comprobante[i].cabecera.informacion_comprobante.es_detalle_encriptado;
                cIBK.cabecera.informacion_comprobante.fecha_emision = lc.comprobante[i].cabecera.informacion_comprobante.fecha_emision;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae = lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae;
                cIBK.cabecera.informacion_comprobante.fecha_serv_desde = lc.comprobante[i].cabecera.informacion_comprobante.fecha_serv_desde;
                cIBK.cabecera.informacion_comprobante.fecha_serv_hasta = lc.comprobante[i].cabecera.informacion_comprobante.fecha_serv_hasta;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento = lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae = lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae;
                cIBK.cabecera.informacion_comprobante.iva_computable = lc.comprobante[i].cabecera.informacion_comprobante.iva_computable;
                cIBK.cabecera.informacion_comprobante.motivo = lc.comprobante[i].cabecera.informacion_comprobante.motivo;
                cIBK.cabecera.informacion_comprobante.numero_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
                cIBK.cabecera.informacion_comprobante.punto_de_venta = lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
                cIBK.cabecera.informacion_comprobante.resultado = lc.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;

                //Info Vendedor
                cIBK.cabecera.informacion_vendedor = new IBK.informacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lc.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
                cIBK.cabecera.informacion_vendedor.razon_social = lc.comprobante[i].cabecera.informacion_vendedor.razon_social;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutos = lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_vendedor.condicion_IVA = lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVA;
                cIBK.cabecera.informacion_vendedor.condicion_IVASpecified = lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified;
                cIBK.cabecera.informacion_vendedor.contacto = lc.comprobante[i].cabecera.informacion_vendedor.contacto;
                cIBK.cabecera.informacion_vendedor.cp = lc.comprobante[i].cabecera.informacion_vendedor.cp;
                cIBK.cabecera.informacion_vendedor.cuit = lc.comprobante[i].cabecera.informacion_vendedor.cuit;
                cIBK.cabecera.informacion_vendedor.domicilio_calle = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_calle;
                cIBK.cabecera.informacion_vendedor.domicilio_depto = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_depto;
                cIBK.cabecera.informacion_vendedor.domicilio_manzana = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana;
                cIBK.cabecera.informacion_vendedor.domicilio_numero = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_numero;
                cIBK.cabecera.informacion_vendedor.domicilio_piso = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_piso;
                cIBK.cabecera.informacion_vendedor.domicilio_sector = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_sector;
                cIBK.cabecera.informacion_vendedor.domicilio_torre = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_torre;
                cIBK.cabecera.informacion_vendedor.email = lc.comprobante[i].cabecera.informacion_vendedor.email;
                cIBK.cabecera.informacion_vendedor.GLN = lc.comprobante[i].cabecera.informacion_vendedor.GLN;
                cIBK.cabecera.informacion_vendedor.GLNSpecified = lc.comprobante[i].cabecera.informacion_vendedor.GLNSpecified;
                cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades;
                cIBK.cabecera.informacion_vendedor.localidad = lc.comprobante[i].cabecera.informacion_vendedor.localidad;
                cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.provincia = lc.comprobante[i].cabecera.informacion_vendedor.provincia;
                cIBK.cabecera.informacion_vendedor.telefono = lc.comprobante[i].cabecera.informacion_vendedor.telefono;

                //Info Comprobantes de Referencia
                if (lc.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    cIBK.cabecera.informacion_comprobante.referencias = new IBK.informacion_comprobanteReferencias[lc.comprobante[i].cabecera.informacion_comprobante.referencias.Length];
                    for (int j = 0; j < lc.comprobante[i].cabecera.informacion_comprobante.referencias.Length; j++)
                    {
                        if (lc.comprobante[i].cabecera.informacion_comprobante.referencias[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.referencias[j] = new IBK.informacion_comprobanteReferencias();
                            cIBK.cabecera.informacion_comprobante.referencias[j].codigo_de_referencia = lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                            cIBK.cabecera.informacion_comprobante.referencias[j].dato_de_referencia = lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].dato_de_referencia;
                        }
                    }
                }

                //Info Exportaci�n
                if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion = new IBK.informacion_comprobanteInformacion_exportacion();
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.id_impositivo = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo;
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms != null && lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.incoterms = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms;
                    }
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms != null && lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms;
                    }
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != null)
                    {
                        if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != "")
                        {
                            cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente;
                        }
                        else
                        {
                            cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = null;
                        }
                    }
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos = new IBK.informacion_comprobanteInformacion_exportacionPermisos[lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length];
                        for (int j = 0; j < lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length; j++)
                        {
                            if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j] != null)
                            {
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j] = new IBK.informacion_comprobanteInformacion_exportacionPermisos();
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso;
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia;
                            }
                        }
                    }
                }

                //Detalle y Lineas
                IBK.detalle d = new IBK.detalle();
                d.linea = new IBK.linea[lc.comprobante[i].detalle.linea.Length];
                d.comentarios = lc.comprobante[i].detalle.comentarios;
                for (int j = 0; j < lc.comprobante[i].detalle.linea.Length; j++)
                {
                    if (lc.comprobante[i].detalle.linea[j] != null)
                    {
                        d.linea[j] = new IBK.linea();
                        d.linea[j].alicuota_iva = lc.comprobante[i].detalle.linea[j].alicuota_iva;
                        d.linea[j].alicuota_ivaSpecified = lc.comprobante[i].detalle.linea[j].alicuota_ivaSpecified;
                        d.linea[j].cantidad = lc.comprobante[i].detalle.linea[j].cantidad;
                        d.linea[j].cantidadSpecified = lc.comprobante[i].detalle.linea[j].cantidadSpecified;
                        d.linea[j].codigo_producto_comprador = lc.comprobante[i].detalle.linea[j].codigo_producto_comprador;
                        d.linea[j].codigo_producto_vendedor = lc.comprobante[i].detalle.linea[j].codigo_producto_vendedor;
                        d.linea[j].descripcion = lc.comprobante[i].detalle.linea[j].descripcion;

                        d.linea[j].GTIN = lc.comprobante[i].detalle.linea[j].GTIN;
                        d.linea[j].GTINSpecified = lc.comprobante[i].detalle.linea[j].GTINSpecified;
                        d.linea[j].importe_iva = lc.comprobante[i].detalle.linea[j].importe_iva;
                        d.linea[j].importe_ivaSpecified = lc.comprobante[i].detalle.linea[j].importe_ivaSpecified;
                        d.linea[j].importe_total_articulo = lc.comprobante[i].detalle.linea[j].importe_total_articulo;
                        d.linea[j].importe_total_descuentos = lc.comprobante[i].detalle.linea[j].importe_total_descuentos;
                        d.linea[j].importe_total_descuentosSpecified = lc.comprobante[i].detalle.linea[j].importe_total_descuentosSpecified;
                        d.linea[j].importe_total_impuestos = lc.comprobante[i].detalle.linea[j].importe_total_impuestos;
                        d.linea[j].importe_total_impuestosSpecified = lc.comprobante[i].detalle.linea[j].importe_total_impuestosSpecified;

                        if (lc.comprobante[i].detalle.linea[j].importes_moneda_origen != null)
                        {
                            d.linea[j].importes_moneda_origen = new IBK.lineaImportes_moneda_origen();
                            d.linea[j].importes_moneda_origen.importe_iva = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_iva;
                            d.linea[j].importes_moneda_origen.importe_ivaSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_ivaSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_articulo = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_articulo;
                            d.linea[j].importes_moneda_origen.importe_total_articuloSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_articuloSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_descuentos = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_descuentos;
                            d.linea[j].importes_moneda_origen.importe_total_descuentosSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_descuentosSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_impuestos = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_impuestos;
                            d.linea[j].importes_moneda_origen.importe_total_impuestosSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_impuestosSpecified;
                            d.linea[j].importes_moneda_origen.precio_unitario = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.precio_unitario;
                            d.linea[j].importes_moneda_origen.precio_unitarioSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.precio_unitarioSpecified;
                        }

                        if (lc.comprobante[i].detalle.linea[j].impuestos != null)
                        {
                            d.linea[j].impuestos = new IBK.lineaImpuestos[lc.comprobante[i].detalle.linea[j].impuestos.Length];
                            for (int k = 0; k < d.linea[j].impuestos.Length; k++)
                            {
                                if (lc.comprobante[i].detalle.linea[j].impuestos[k] != null)
                                {
                                    d.linea[j].impuestos[k] = new IBK.lineaImpuestos();
                                    d.linea[j].impuestos[k].codigo_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].codigo_impuesto;
                                    d.linea[j].impuestos[k].descripcion_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].descripcion_impuesto;
                                    d.linea[j].impuestos[k].importe_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].importe_impuesto;
                                    d.linea[j].impuestos[k].importe_impuesto_moneda_origen = lc.comprobante[i].detalle.linea[j].impuestos[k].importe_impuesto_moneda_origen;
                                    d.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified = lc.comprobante[i].detalle.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified;
                                    d.linea[j].impuestos[k].porcentaje_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].porcentaje_impuesto;
                                    d.linea[j].impuestos[k].porcentaje_impuestoSpecified = lc.comprobante[i].detalle.linea[j].impuestos[k].porcentaje_impuestoSpecified;
                                }
                            }
                        }
                        if (lc.comprobante[i].detalle.linea[j].lineaDescuentos != null)
                        {
                            d.linea[j].descuentos = new IBK.lineaDescuentos[lc.comprobante[i].detalle.linea[j].lineaDescuentos.Length];
                            for (int k = 0; k < d.linea[j].descuentos.Length; k++)
                            {
                                if (lc.comprobante[i].detalle.linea[j].lineaDescuentos[k] != null)
                                {
                                    d.linea[j].descuentos[k] = new IBK.lineaDescuentos();
                                    d.linea[j].descuentos[k].descripcion_descuento = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].descripcion_descuento;
                                    d.linea[j].descuentos[k].importe_descuento = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].importe_descuento;
                                    d.linea[j].descuentos[k].importe_descuento_moneda_origen = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].importe_descuento_moneda_origen;
                                    d.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].importe_descuento_moneda_origenSpecified;
                                    d.linea[j].descuentos[k].porcentaje_descuento = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].porcentaje_descuento;
                                    d.linea[j].descuentos[k].porcentaje_descuentoSpecified = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].porcentaje_descuentoSpecified;
                                }
                            }
                        }
                        if (lc.comprobante[i].detalle.linea[j].informacion_adicional != null)
                        {
                            d.linea[j].informacion_adicional = new IBK.lineaInformacion_adicional[lc.comprobante[i].detalle.linea[j].informacion_adicional.Length];
                            for (int k = 0; k < d.linea[j].informacion_adicional.Length; k++)
                            {
                                if (lc.comprobante[i].detalle.linea[j].informacion_adicional[k] != null)
                                {
                                    d.linea[j].informacion_adicional[k] = new IBK.lineaInformacion_adicional();
                                    d.linea[j].informacion_adicional[k].tipo = lc.comprobante[i].detalle.linea[j].informacion_adicional[k].tipo;
                                    d.linea[j].informacion_adicional[k].valor = lc.comprobante[i].detalle.linea[j].informacion_adicional[k].valor;
                                }
                            }
                        }
                        d.linea[j].indicacion_exento_gravado = lc.comprobante[i].detalle.linea[j].indicacion_exento_gravado;
                        d.linea[j].numeroLinea = lc.comprobante[i].detalle.linea[j].numeroLinea;
                        d.linea[j].precio_unitario = lc.comprobante[i].detalle.linea[j].precio_unitario;
                        d.linea[j].precio_unitarioSpecified = lc.comprobante[i].detalle.linea[j].precio_unitarioSpecified;
                        d.linea[j].unidad = lc.comprobante[i].detalle.linea[j].unidad;
                    }
                    else
                    {
                        break;
                    }
                }
                cIBK.Item = d;

                //Info Extensiones
                if (lc.comprobante[i].extensiones != null)
                {
                    cIBK.extensiones = new IBK.extensiones();
                    if (lc.comprobante[i].extensiones.extensiones_camara_facturas != null)
                    {
                        cIBK.extensiones.extensiones_camara_facturas = new IBK.extensionesExtensiones_camara_facturas();
                        cIBK.extensiones.extensiones_camara_facturas.clave_de_vinculacion = lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion;
                        cIBK.extensiones.extensiones_camara_facturas.id_idioma = lc.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma;
                        cIBK.extensiones.extensiones_camara_facturas.id_template = lc.comprobante[i].extensiones.extensiones_camara_facturas.id_template;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_datos_comerciales != null && lc.comprobante[i].extensiones.extensiones_datos_comerciales != "")
                    {
                        //object o = lc.comprobante[i].extensiones.extensiones_datos_comerciales;
                        //string aux = ConvertToHex(((System.Xml.XmlNode[])o)[0].OuterXml.ToString());
                        //cIBK.extensiones.extensiones_datos_comerciales = aux;
                        cIBK.extensiones.extensiones_datos_comerciales = lc.comprobante[i].extensiones.extensiones_datos_comerciales;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_datos_marketing != null && lc.comprobante[i].extensiones.extensiones_datos_marketing != "")
                    {
                        string aux = ConvertToHex(lc.comprobante[i].extensiones.extensiones_datos_marketing.ToString());
                        cIBK.extensiones.extensiones_datos_marketing = aux;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_signatures != null && lc.comprobante[i].extensiones.extensiones_signatures != "")
                    {
                        cIBK.extensiones.extensiones_signatures = lc.comprobante[i].extensiones.extensiones_signatures;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_destinatarios != null && lc.comprobante[i].extensiones.extensiones_destinatarios.email != "")
                    {
                        cIBK.extensiones.extensiones_destinatarios = new IBK.extensionesExtensiones_destinatarios();
                        cIBK.extensiones.extensiones_destinatarios.email = lc.comprobante[i].extensiones.extensiones_destinatarios.email;
                        //if (lc.comprobante[i].extensiones.extensiones_destinatarios.destinatario != null)
                        //{
                        //    for (int j = 0; j < lc.comprobante[i].extensiones.extensiones_destinatarios.destinatario.Length; j++)
                        //    {
                        //        cIBK.extensiones.extensiones_destinatarios.destinatario[j] = new eFact_RN.IBK.extensionesExtensiones_destinatariosDestinatario();
                        //        cIBK.extensiones.extensiones_destinatarios.destinatario[j].cuit = lc.comprobante[i].extensiones.extensiones_destinatarios.destinatario[j].cuit;
                        //    }
                        //}
                    }
                }

                cIBK.resumen = new IBK.resumen();
                cIBK.resumen.cant_alicuotas_iva = lc.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lc.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lc.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.descuentos = new IBK.resumenDescuentos[0];

                cIBK.resumen.cant_alicuotas_iva = lc.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lc.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lc.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.importe_operaciones_exentas = lc.comprobante[i].resumen.importe_operaciones_exentas;
                cIBK.resumen.importe_total_concepto_no_gravado = lc.comprobante[i].resumen.importe_total_concepto_no_gravado;
                cIBK.resumen.importe_total_factura = lc.comprobante[i].resumen.importe_total_factura;
                cIBK.resumen.importe_total_impuestos_internos = lc.comprobante[i].resumen.importe_total_impuestos_internos;
                cIBK.resumen.importe_total_impuestos_internosSpecified = lc.comprobante[i].resumen.importe_total_impuestos_internosSpecified;
                cIBK.resumen.importe_total_impuestos_municipales = lc.comprobante[i].resumen.importe_total_impuestos_municipales;
                cIBK.resumen.importe_total_impuestos_municipalesSpecified = lc.comprobante[i].resumen.importe_total_impuestos_municipalesSpecified;
                cIBK.resumen.importe_total_impuestos_nacionales = lc.comprobante[i].resumen.importe_total_impuestos_nacionales;
                cIBK.resumen.importe_total_impuestos_nacionalesSpecified = lc.comprobante[i].resumen.importe_total_impuestos_nacionalesSpecified;
                cIBK.resumen.importe_total_ingresos_brutos = lc.comprobante[i].resumen.importe_total_ingresos_brutos;
                cIBK.resumen.importe_total_ingresos_brutosSpecified = lc.comprobante[i].resumen.importe_total_ingresos_brutosSpecified;
                cIBK.resumen.importe_total_neto_gravado = lc.comprobante[i].resumen.importe_total_neto_gravado;

                if (lc.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    cIBK.resumen.importes_moneda_origen = new IBK.resumenImportes_moneda_origen();
                    cIBK.resumen.importes_moneda_origen.importe_operaciones_exentas = lc.comprobante[i].resumen.importes_moneda_origen.importe_operaciones_exentas;
                    cIBK.resumen.importes_moneda_origen.importe_total_concepto_no_gravado = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                    cIBK.resumen.importes_moneda_origen.importe_total_factura = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_factura;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internos = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internos;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipales = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionales = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutos = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_neto_gravado = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_neto_gravado;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq = lc.comprobante[i].resumen.importes_moneda_origen.impuesto_liq;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq_rni = lc.comprobante[i].resumen.importes_moneda_origen.impuesto_liq_rni;
                }

                cIBK.resumen.impuesto_liq = lc.comprobante[i].resumen.impuesto_liq;
                cIBK.resumen.impuesto_liq_rni = lc.comprobante[i].resumen.impuesto_liq_rni;

                if (lc.comprobante[i].resumen.descuentos != null)
                {
                    cIBK.resumen.descuentos = new IBK.resumenDescuentos[lc.comprobante[i].resumen.descuentos.Length];
                    for (int l = 0; l < lc.comprobante[i].resumen.descuentos.Length; l++)
                    {
                        if (lc.comprobante[i].resumen.descuentos[l] != null)
                        {
                            cIBK.resumen.descuentos[l] = new IBK.resumenDescuentos();
                            cIBK.resumen.descuentos[l].alicuota_iva_descuento = lc.comprobante[i].resumen.descuentos[l].alicuota_iva_descuento;
                            cIBK.resumen.descuentos[l].alicuota_iva_descuentoSpecified = lc.comprobante[i].resumen.descuentos[l].alicuota_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].descripcion_descuento = lc.comprobante[i].resumen.descuentos[l].descripcion_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento = lc.comprobante[i].resumen.descuentos[l].importe_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origen = lc.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origenSpecified = lc.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuento = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuento;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origen = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuentoSpecified = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].porcentaje_descuento = lc.comprobante[i].resumen.descuentos[l].porcentaje_descuento;
                            cIBK.resumen.descuentos[l].porcentaje_descuentoSpecified = lc.comprobante[i].resumen.descuentos[l].porcentaje_descuentoSpecified;
                        }
                    }
                }

                if (lc.comprobante[i].resumen.impuestos != null)
                {
                    cIBK.resumen.impuestos = new IBK.resumenImpuestos[lc.comprobante[i].resumen.impuestos.Length];
                    for (int l = 0; l < lc.comprobante[i].resumen.impuestos.Length; l++)
                    {
                        if (lc.comprobante[i].resumen.impuestos[l] != null)
                        {
                            cIBK.resumen.impuestos[l] = new IBK.resumenImpuestos();
                            cIBK.resumen.impuestos[l].codigo_impuesto = lc.comprobante[i].resumen.impuestos[l].codigo_impuesto;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccion = lc.comprobante[i].resumen.impuestos[l].codigo_jurisdiccion;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccionSpecified = lc.comprobante[i].resumen.impuestos[l].codigo_jurisdiccionSpecified;
                            cIBK.resumen.impuestos[l].descripcion = lc.comprobante[i].resumen.impuestos[l].descripcion;
                            cIBK.resumen.impuestos[l].importe_impuesto = lc.comprobante[i].resumen.impuestos[l].importe_impuesto;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origen = lc.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origen;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origenSpecified = lc.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origenSpecified;
                            cIBK.resumen.impuestos[l].jurisdiccion_municipal = lc.comprobante[i].resumen.impuestos[l].jurisdiccion_municipal;
                            cIBK.resumen.impuestos[l].porcentaje_impuesto = lc.comprobante[i].resumen.impuestos[l].porcentaje_impuesto;
                            cIBK.resumen.impuestos[l].porcentaje_impuestoSpecified = lc.comprobante[i].resumen.impuestos[l].porcentaje_impuestoSpecified;
                        }
                    }
                }
                cIBK.resumen.observaciones = lc.comprobante[i].resumen.observaciones;
                cIBK.resumen.tipo_de_cambio = lc.comprobante[i].resumen.tipo_de_cambio;

                lcIBK.comprobante[i] = cIBK;
            }
            return lcIBK;
        }
        public string ConvertToHex(string asciiString)
        {
            asciiString = PonerEntityName(asciiString);
            byte[] b = Encoding.ASCII.GetBytes(asciiString);
            string salida = "";
            for (int i = 0; i < b.Length; i++)
            {
                string ascii = b[i].ToString();
                int n = Convert.ToInt32(ascii);
                string r = n.ToString("x");
                salida += "%" + r;
            }
            return salida;
        }
        private string PonerEntityName(string texto)
        {
            texto = texto.Replace("�", "&aacute;");
            texto = texto.Replace("�", "&eacute;");
            texto = texto.Replace("�", "&iacute;");
            texto = texto.Replace("�", "&oacute;");
            texto = texto.Replace("�", "&uacute;");
            texto = texto.Replace("�", "&ordm;");
			texto = texto.Replace("�", "&agrave;");
			texto = texto.Replace("�", "&egrave;");
			texto = texto.Replace("�", "&igrave;");
			texto = texto.Replace("�", "&ograve;");
			texto = texto.Replace("�", "&ugrave;");
			//May�sculas
			texto = texto.Replace("�", "&Aacute;");
			texto = texto.Replace("�", "&Eacute;");
			texto = texto.Replace("�", "&Iacute;");
			texto = texto.Replace("�", "&Oacute;");
			texto = texto.Replace("�", "&Uacute;");
			texto = texto.Replace("�", "&Agrave;");
			texto = texto.Replace("�", "&Egrave;");
			texto = texto.Replace("�", "&Igrave;");
			texto = texto.Replace("�", "&Ograve;");
			texto = texto.Replace("�", "&Ugrave;");
			return texto;
        }
        public string HexToString(string Hex)
        {
            byte[] Bytes;
            int ByteLength;
            string HexValue = "\x0\x1\x2\x3\x4\x5\x6\x7\x8\x9|||||||\xA\xB\xC\xD\xE\xF";
            Hex = Hex.Replace("%", "");
            ByteLength = Hex.Length / 2;
            Bytes = new byte[ByteLength];
            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4);
                Bytes[x] |= (byte)(HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string str = enc.GetString(Bytes);
            str = SacarEntityName(str);
            return str;
        }
        private string SacarEntityName(string texto)
        {
            texto = texto.Replace("&aacute;", "�");
            texto = texto.Replace("&eacute;", "�");
            texto = texto.Replace("&iacute;", "�");
            texto = texto.Replace("&oacute;", "�");
            texto = texto.Replace("&uacute;", "�");
            texto = texto.Replace("&ordm;", "�");
			texto = texto.Replace("&agrave;", "�");
			texto = texto.Replace("&egrave;", "�");
			texto = texto.Replace("&igrave;", "�");
			texto = texto.Replace("&ograve;", "�");
			texto = texto.Replace("&ugrave;", "�");
			//May�sculas
			texto = texto.Replace("&Aacute;", "�");
			texto = texto.Replace("&Eacute;", "�");
			texto = texto.Replace("&Iacute;", "�");
			texto = texto.Replace("&Oacute;", "�");
			texto = texto.Replace("&Uacute;", "�");
			texto = texto.Replace("&Agrave;", "�");
			texto = texto.Replace("&Egrave;", "�");
			texto = texto.Replace("&Igrave;", "�");
			texto = texto.Replace("&Ograve;", "�");
			texto = texto.Replace("&Ugrave;", "�");
            return texto;
        }
    }
}
