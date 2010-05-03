using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TestWSConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //CedWebRN.Comprobante c = new CedWebRN.Comprobante();
                //CedWebRN.IBK.consulta_lote_comprobantes clc = new CedWebRN.IBK.consulta_lote_comprobantes();
                //clc.punto_de_venta = 1;
                //clc.punto_de_ventaSpecified = true;
                //clc.cod_interno_canal = string.Empty;
                //clc.cuit_canal = 30690783521;
                //clc.cuit_vendedor = 30710015062;
                //clc.id_lote = 1;
                //string certificado = "011f66c68d70";

                //CedWebRN.IBK.consulta_lote_comprobantes_response clcr = c.ConsultarIBK(clc, certificado);

                //Ir por WS
                org.dyndns.cedweb.ConsultaIBK clcdyndns = new org.dyndns.cedweb.ConsultaIBK();
                try
                {
                    CedWebRN.Cripto cripto = new CedWebRN.Cripto();
                    string certificado = cripto.EncryptData("011f66c68d70", "CedWeb.pubpriv.rsa", "CedWebWS.pub.rsa");

                    org.dyndns.cedweb.ConsultarResult clcrdyndns = new org.dyndns.cedweb.ConsultarResult();
                    clcrdyndns = clcdyndns.Consultar(30710015062, 105, 1, certificado);


                    try
                    {
                        //org.dyndns.cedweb.ConsultaIBK.ConsultarResponseConsultarResultConsulta_lote_responseLote_comprobantes lcIBKdyndns = new org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_responseLote_comprobantes();
                        //lcIBKdyndns = ((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_responseLote_comprobantes)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_response)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResult)clcrdyndns).Item)).Item));
                        //if (lcIBKdyndns.cabecera_lote.resultado == null || lcIBKdyndns.cabecera_lote.resultado.Equals("A"))
                        //{
                        //    Conversor conv = new Conversor();
                        //    FeaEntidades.InterFacturas.lote_comprobantes lcFEA = conv.dyndns2Entidad(lcIBKdyndns);
                        //    CompletarUI(lcFEA, e);

                        //}
                        //else
                        //{
                        //    string resultado = ((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_responseLote_comprobantes)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_response)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResult)clcrdyndns).Item)).Item)).cabecera_lote.resultado;
                        //    string motivo = ((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_responseLote_comprobantes)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_response)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResult)clcrdyndns).Item)).Item)).cabecera_lote.motivo;
                        //    ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Resultado:" + resultado + ":" + motivo.Replace("\"", "").Replace("\n", "") + "');</script>");
                        //}
                    }
                    catch (InvalidCastException)
                    {
                        //string errorConsultaLote = ((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_responseErrores_consulta)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResultConsulta_lote_response)(((org.dyndns.cedweb.consulta.ConsultarResponseConsultarResult)clcrdyndns).Item)).Item)).error[0].descripcion_error;
                        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + errorConsultaLote + "');</script>");
                    }
                }
                catch (System.Web.Services.Protocols.SoapException soapEx)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(soapEx.Detail.OuterXml);
                        XmlNamespaceManager nsManager = new
                            XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("errorNS",
                            "http://www.cedeira.com.ar/webservices");
                        XmlNode Node =
                            doc.DocumentElement.SelectSingleNode("errorNS:Error", nsManager);
                        string errorNumber =
                            Node.SelectSingleNode("errorNS:ErrorNumber",
                            nsManager).InnerText;
                        string errorMessage =
                            Node.SelectSingleNode("errorNS:ErrorMessage",
                            nsManager).InnerText;
                        string errorSource =
                            Node.SelectSingleNode("errorNS:ErrorSource",
                            nsManager).InnerText;
                        //ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + soapEx.Actor + " : " + errorMessage.Replace("\r", "").Replace("\n", "") + "');</script>");
                    }
                    catch (Exception)
                    {
                        throw soapEx;
                    }
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
