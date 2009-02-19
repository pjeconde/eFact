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
            MailMessage mail2InfoCedeira = new MailMessage();
            mail2InfoCedeira.From = new MailAddress("info@cedeira.com.ar");
            if (Contacto.Motivo == "FactElectronica")
            {
                mail2InfoCedeira.To.Add(new MailAddress("facturaelectronica@cedeira.com.ar"));
            }
            else
            {
                mail2InfoCedeira.To.Add(new MailAddress("info@cedeira.com.ar"));
            }
            mail2InfoCedeira.Subject = "Formulario electrónico (Contacto de cedeira.com.ar)";

            StringBuilder a = new StringBuilder();
            a.Append("Motivo: " + Contacto.Motivo); a.AppendLine();
            a.Append("Nombre: " + Contacto.Nombre); a.AppendLine();
            a.Append("Telefono: " + Contacto.Telefono); a.AppendLine();
            a.Append("Email: " + Contacto.Email); a.AppendLine();
            a.Append("Mensaje: " + Contacto.Mensaje); a.AppendLine();
            mail2InfoCedeira.Body = a.ToString();

            MailMessage mail2Remitente = new MailMessage();
            mail2Remitente.From = new MailAddress("info@cedeira.com.ar");
            mail2Remitente.To.Add(new MailAddress(Contacto.Email));
            mail2Remitente.Subject = "Acuse de recibo de Formulario electrónico";
            a = new StringBuilder();
            a.Append("Gracias por comunicarse con Cedeira Software Factory."); a.AppendLine();
            a.Append("Su consulta será respondida a la brevedad."); a.AppendLine();
            a.Append("Saludos."); a.AppendLine();
            mail2Remitente.Body = a.ToString();

            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
			smtpClient.Credentials = new NetworkCredential("info@cedeira.com.ar", "cedeira123");
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Send(mail2InfoCedeira);
			smtpClient.Send(mail2Remitente);
        }
    }
}