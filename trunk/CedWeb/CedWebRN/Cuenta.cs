using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedWebRN
{
    public class Cuenta
    {
        public static void Validar(CedWebEntidades.Cuenta Cuenta, string ClaveCatpcha, string Clave, CedEntidades.Sesion Sesion)
        {
            if (Cuenta.Nombre == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nombre y Apellido");
            }
            else
            {
                if (Cuenta.Telefono == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Teléfono");
                }
                else
                {
                    if (Cuenta.Email == String.Empty)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Email");
                    }
                    else
                    {
                        if (!Cedeira.SV.Fun.IsEmail(Cuenta.Email))
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Email");
                        }
                        else
                        {
                            if (Cuenta.Id == String.Empty)
                            {
                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id.Usuario");
                            }
                            else
                            {
                                if (!IdCuentaDisponible(Cuenta, Sesion))
                                {
                                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.IdUsuarioNoDisponible();
                                }
                                else
                                {
                                    if (Cuenta.Password == String.Empty)
                                    {
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña");
                                    }
                                    else
                                    {
                                        if (Cuenta.ConfirmacionPassword == String.Empty)
                                        {
                                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Confirmación de Contraseña");
                                        }
                                        else
                                        {
                                            if (Cuenta.Password != Cuenta.ConfirmacionPassword)
                                            {
                                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordYConfirmacionNoCoincidente();
                                            }
                                            else
                                            {
                                                if (Cuenta.Pregunta == String.Empty)
                                                {
                                                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Pregunta");
                                                }
                                                else
                                                {
                                                    if (Cuenta.Respuesta == String.Empty)
                                                    {
                                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Respuesta");
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
                        }
                    }
                }
            }
        }
        public static void Registrar(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            //Alta en la base de datos
            Cuenta.TipoCuenta.Id = "Free";
            Cuenta.EstadoCuenta.Id = "PteConf";
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            cuenta.Crear(Cuenta);

            //Mail para confirmación
            SmtpClient smtpClient = new SmtpClient("localhost");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Cuenta.Email));
            mail.Subject = "Ahora dispone de una nueva cuenta eFact";
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a " + Cuenta.Nombre.Trim() + ":"); a.AppendLine();
            a.AppendLine();
            a.Append("Gracias por crear su cuenta eFact."); a.AppendLine();
            a.Append("Para confirmar el alta, haga clic en el enlace que aparece a continuación:"); a.AppendLine();
            a.AppendLine();
            a.Append("http://www.cedeira.com.ar/CuentaConfirmacion.aspx?Id=" + Encryptor.Encrypt(Cuenta.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"))); a.AppendLine();
            a.AppendLine();
            a.Append("Si no puede acceder a la página, copie la URL y péguela en una ventana nueva del navegador."); a.AppendLine();
            a.Append("Si ha recibido este correo electrónico y no ha solicitado la creación de una cuenta eFact, es probable que otro usuario haya introducido su dirección por error al intentar llevar a cabo este proceso. Si no ha solicitado la creación de una cuenta eFact, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad."); a.AppendLine();
            a.Append("Saludos."); a.AppendLine();
            a.AppendLine();
            a.Append("Cedeira Software Factory"); a.AppendLine();
            a.AppendLine();
            a.AppendLine();
            a.AppendLine("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden."); a.AppendLine();
            mail.Body = a.ToString();
            smtpClient.Send(mail);
        }
        public static void Leer(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            cuenta.Leer(Cuenta);
            Cuenta.Vendedor.IdCuenta = Cuenta.Id;
            Cuenta.Vendedor.NombreCuenta = Cuenta.Nombre;
            try
            {
                CedWebRN.Vendedor.Leer(Cuenta.Vendedor, Sesion);
            }
            catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
            {
                CedWebRN.Vendedor.Limpiar(Cuenta.Vendedor);
            }
        }
        public static void Limpiar(CedWebEntidades.Cuenta Cuenta)
        {
            Cuenta.Id = null;
            Cuenta.Nombre = null;
            Cuenta.Telefono = null;
            Cuenta.Email = null;
            Cuenta.Password = null;
            Cuenta.ConfirmacionPassword = null;
            Cuenta.Pregunta = null;
            Cuenta.Respuesta = null;
            Cuenta.TipoCuenta.Id = null;
            Cuenta.TipoCuenta.Descr = null;
            Cuenta.EstadoCuenta.Id = null;
            Cuenta.EstadoCuenta.Descr = null;
            CedWebRN.Vendedor.Limpiar(Cuenta.Vendedor);
        }
        public static void Login(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            if (Cuenta.Id == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id.Usuario");
            }
            else
            {
                if (Cuenta.Password == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña");
                }
                else
                {
                    string passwordIngresada = Cuenta.Password;
                    Leer(Cuenta, Sesion);
                    if (passwordIngresada != Cuenta.Password)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.LoginRechazadoXPasswordInvalida();
                    }
                    //Se impide el login a cuenta pendientes de confirmacion o dadas de baja
                    //(las cuentas "Prem" suspendidas se comportan como cuentas "Free")
                    if (Cuenta.EstadoCuenta.Id != "Vigente" && Cuenta.EstadoCuenta.Id != "Suspend")
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.LoginRechazadoXEstadoCuenta();
                    }
                }
            }
        }
        public static void Confirmar(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            Cuenta.Id = Encryptor.Decrypt(Cuenta.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Leer(Cuenta, Sesion);
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            cuenta.Confirmar(Cuenta);
        }
        public static bool IdCuentaDisponible(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            if (Cuenta.Id == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id.Usuario");
            }
            else
            {
                try
                {
                    CedWebEntidades.Cuenta cuentaExistente = new CedWebEntidades.Cuenta();
                    cuentaExistente.Id = Cuenta.Id;
                    Leer(cuentaExistente, Sesion);
                    return false;
                }
                catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
                {
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void CambiarPassword(CedWebEntidades.Cuenta Cuenta, string PasswordActual, string PasswordNueva, string ConfirmacionPasswordNueva, CedEntidades.Sesion Sesion)
        {
            if (PasswordActual == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña actual");
            }
            else
            {
                if (PasswordNueva == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña nueva");
                }
                else
                {
                    if (ConfirmacionPasswordNueva == String.Empty)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Confirmación de Contraseña nueva");
                    }
                    else
                    {
                        if (Cuenta.Password != PasswordActual)
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Login.PasswordNoMatch();
                        }
                        else
                        {
                            if (PasswordNueva != ConfirmacionPasswordNueva)
                            {
                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordYConfirmacionNoCoincidente();
                            }
                            else
                            {
                                if (Cuenta.Password == PasswordNueva)
                                {
                                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordNuevaIgualAActual();
                                }
                                else
                                {
                                    CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
                                    cuenta.CambiarPassword(Cuenta, PasswordNueva);
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ReportarIdCuentas(string Email, CedEntidades.Sesion Sesion)
        {
            //Alta en la base de datos
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            List<CedWebEntidades.Cuenta> cuentas = cuenta.Lista(Email);
            //Mail para confirmación
            SmtpClient smtpClient = new SmtpClient("localhost");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Email));
            mail.Subject = "Información de cuenta(s) eFact";
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a " + cuentas[0].Nombre.Trim() + ":"); a.AppendLine();
            a.AppendLine();
            a.Append("Cumplimos en informarle cuáles son las cuentas eFact vinculadas a esta cuenta de correo electrónico:"); a.AppendLine();
            a.AppendLine();
            for (int i = 0; i < cuentas.Count; i++)
            {
                a.Append("Cuenta '" + cuentas[i].Nombre + "' (Id.Usuario='" + cuentas[i].Id + "')"); a.AppendLine();
            }
            a.AppendLine();
            a.Append("Si ha recibido este correo electrónico y no ha solicitado información sobre su(s) cuenta(s) eFact, es probable que otro usuario haya introducido su dirección por error. Si no ha solicitado esta información, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad."); a.AppendLine();
            a.Append("Saludos."); a.AppendLine();
            a.AppendLine();
            a.Append("Cedeira Software Factory"); a.AppendLine();
            a.AppendLine();
            a.AppendLine();
            a.AppendLine("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden."); a.AppendLine();
            mail.Body = a.ToString();
            smtpClient.Send(mail);
        }
        public static List<CedWebEntidades.Cuenta> Lista(int IndicePagina, int TamañoPagina, string OrderBy, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdCuenta";
            }
            return cuenta.Lista(IndicePagina, TamañoPagina, OrderBy);
        }
        public static int CantidadDeFilas(CedEntidades.Sesion Sesion)
        {
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            return cuenta.CantidadDeFilas();
        }
        public static void ReservarNroLote(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            cuenta.ReservarNroLote(Cuenta);
        }
        public static void Configurar(CedWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedWebDB.Cuenta cuenta = new CedWebDB.Cuenta(Sesion);
            cuenta.Configurar(Cuenta);
        }
    }
}