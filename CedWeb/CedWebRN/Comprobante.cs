using System;
using System.Collections.Generic;
using System.Text;

namespace CedWebRN
{
    public class Comprobante
    {
        public IBK.consulta_lote_comprobantes_response ConsultarIBK(IBK.consulta_lote_comprobantes clc, string pathCertificado)
        {
            IBK.FacturaWebServiceConSchemaSoapBindingQSService objIBK;
            objIBK = new IBK.FacturaWebServiceConSchemaSoapBindingQSService();
            System.Security.Cryptography.X509Certificates.X509Certificate cert = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(pathCertificado);
            objIBK.ClientCertificates.Add(cert);
            IBK.consulta_lote_comprobantes_response clcr = objIBK.getLoteFacturasConSchema(clc);
            return clcr;
        }
        public IBK.lote_comprobantes_response EnviarIBK(FeaEntidades.InterFacturas.lote_comprobantes lc, string pathCertificado)
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
                IBK.comprobante cIBK = new IBK.comprobante();

                cIBK.cabecera = new IBK.cabecera();

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

                cIBK.cabecera.informacion_comprobante = new IBK.informacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lc.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lc.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lc.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
                cIBK.cabecera.informacion_comprobante.condicion_de_pagoSpecified = lc.comprobante[i].cabecera.informacion_comprobante.condicion_de_pagoSpecified;
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

                cIBK.cabecera.informacion_comprobante.referencias = new IBK.informacion_comprobanteReferencias[0];

                cIBK.cabecera.informacion_comprobante.resultado = lc.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;

                cIBK.cabecera.informacion_vendedor = new IBK.informacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lc.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
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


                cIBK.extensiones = new IBK.extensiones();


                IBK.detalle d = new IBK.detalle();
                d.linea = new IBK.linea[lc.comprobante[i].detalle.linea.Length];

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
                        if (lc.comprobante[i].detalle.linea[j].descuentos != null)
                        {
                            d.linea[j].descuentos = new IBK.lineaDescuentos[lc.comprobante[i].detalle.linea[j].descuentos.Length];
                            for (int k = 0; k < d.linea[j].descuentos.Length; k++)
                            {
                                d.linea[j].descuentos[k] = new IBK.lineaDescuentos();
                                d.linea[j].descuentos[k].descripcion_descuento = lc.comprobante[i].detalle.linea[j].descuentos[k].descripcion_descuento;
                                d.linea[j].descuentos[k].importe_descuento = lc.comprobante[i].detalle.linea[j].descuentos[k].importe_descuento;
                                d.linea[j].descuentos[k].importe_descuento_moneda_origen = lc.comprobante[i].detalle.linea[j].descuentos[k].importe_descuento_moneda_origen;
                                d.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified = lc.comprobante[i].detalle.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified;
                                d.linea[j].descuentos[k].porcentaje_descuento = lc.comprobante[i].detalle.linea[j].descuentos[k].porcentaje_descuento;
                                d.linea[j].descuentos[k].porcentaje_descuentoSpecified = lc.comprobante[i].detalle.linea[j].descuentos[k].porcentaje_descuentoSpecified;
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

            IBK.FacturaWebServiceConSchemaSoapBindingQSService objIBK;
            objIBK = new IBK.FacturaWebServiceConSchemaSoapBindingQSService();
            System.Security.Cryptography.X509Certificates.X509Certificate cert = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(pathCertificado);
            objIBK.ClientCertificates.Add(cert);

            IBK.lote_comprobantes_response lcr = objIBK.receiveFacturasConSchema(lcIBK);
            return lcr;
        }
    }
}
