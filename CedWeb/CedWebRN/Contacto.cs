using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
namespace CedWebRN
{
    public class Contacto
    {
        public static void Validar(CedWebEntidades.Contacto Contacto, string ClaveCatpcha, string Clave)
        {
            if (Contacto.Motivo == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Motivo");
            }
            else
            {
                if (Contacto.Nombre == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nombre");
                }
                else
                {
                    if (Contacto.Telefono == String.Empty)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Teléfono");
                    }
                    else
                    {
                        if (Contacto.Email == String.Empty)
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Email");
                        }
                        else
                        {
                            if (!Cedeira.SV.Fun.IsEmail(Contacto.Email))
                            {
                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Email");
                            }
                            else
                            {
                                if (Contacto.Mensaje == String.Empty)
                                {
                                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Mensaje");
                                }
                                else
                                {
                                    if (!ClaveCatpcha.Equals(Clave.ToLower()))
                                    {
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Clave");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Registrar(CedWebEntidades.Contacto Contacto)
        {
            StringBuilder a;
            string cuentaMailCedeira;
            if (Contacto.Motivo == "FactElectronica")
            {
                cuentaMailCedeira = "facturaelectronica@cedeira.com.ar";
            }
            else
            {
                cuentaMailCedeira = "info@cedeira.com.ar";
            }

            //Mail para Cedeira
            SmtpClient smtpClient2Cedeira = new SmtpClient("localhost");
            MailMessage mail2Cedeira = new MailMessage();
            mail2Cedeira.From = new MailAddress("contacto@cedeira.com.ar");
            mail2Cedeira.To.Add(new MailAddress(cuentaMailCedeira));
            mail2Cedeira.Subject = "Formulario electrónico (Contacto de cedeira.com.ar)";
            a = new StringBuilder();
            a.Append("Los siguientes son, los datos del nuevo contacto");
            if (Contacto.Motivo == "FactElectronica") a.Append(" (por el tema de FACTURA ELECTRONICA)");
            a.Append(":"); a.AppendLine();
            a.AppendLine();
            a.Append("Nombre: " + Contacto.Nombre); a.AppendLine();
            a.Append("Telefono: " + Contacto.Telefono); a.AppendLine();
            a.Append("Email: " + Contacto.Email); a.AppendLine();
            a.Append("Mensaje: "); a.AppendLine();
            a.Append("------------------------------------------------"); a.AppendLine();
            a.Append(Contacto.Mensaje); a.AppendLine();
            a.Append("------------------------------------------------"); a.AppendLine();
            mail2Cedeira.Body = a.ToString();
            smtpClient2Cedeira.Send(mail2Cedeira);

            //Mail para el Contacto
            SmtpClient smtpClient2Contacto = new SmtpClient("localhost");
            MailMessage mail2Contacto = new MailMessage();
            mail2Contacto.From = new MailAddress(cuentaMailCedeira);
            mail2Contacto.To.Add(new MailAddress(Contacto.Email));
            mail2Contacto.Subject = "Acuse de recibo de Formulario electrónico";
            a = new StringBuilder();
            a.Append("Estimado/a " + Contacto.Nombre.Trim() + ":"); a.AppendLine();
            a.AppendLine();
            a.Append("Gracias por comunicarse con nosotros."); a.AppendLine();
            if (Contacto.Motivo == "FactElectronica")
            {
                a.Append("Su consulta, sobre el tema de Factura Electrónica, será respondida a la brevedad."); a.AppendLine();
            }
            else
            {
                a.Append("Su consulta será respondida a la brevedad."); a.AppendLine();
            }
            a.Append("Saludos."); a.AppendLine();
            a.AppendLine();
            a.Append("Cedeira Software Factory");
            a.AppendLine();
            a.AppendLine();
            a.AppendLine("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden."); a.AppendLine();
            mail2Contacto.Body = a.ToString();
            smtpClient2Contacto.Send(mail2Contacto);
        }
    }
}