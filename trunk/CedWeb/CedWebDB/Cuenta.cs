using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class Cuenta : db
    {
        public Cuenta(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta from Cuenta, TipoCuenta, EstadoCuenta ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Cuenta " + Cuenta.Id.ToString());
            }
            else
            {
                Cuenta.Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                Cuenta.Telefono = Convert.ToString(dt.Rows[0]["Telefono"]);
                Cuenta.Email = Convert.ToString(dt.Rows[0]["Email"]);
                Cuenta.Password = Convert.ToString(dt.Rows[0]["Password"]);
                Cuenta.Pregunta = Convert.ToString(dt.Rows[0]["Pregunta"]);
                Cuenta.Respuesta = Convert.ToString(dt.Rows[0]["Respuesta"]);
                Cuenta.TipoCuenta.Id = Convert.ToString(dt.Rows[0]["IdTipoCuenta"]);
                Cuenta.TipoCuenta.Descr = Convert.ToString(dt.Rows[0]["DescrTipoCuenta"]);
                Cuenta.EstadoCuenta.Id = Convert.ToString(dt.Rows[0]["IdEstadoCuenta"]);
                Cuenta.EstadoCuenta.Descr = Convert.ToString(dt.Rows[0]["DescrEstadoCuenta"]);
            }
        }
        public void Crear(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("Insert Cuenta values (");
            a.Append("'"+Cuenta.Id+"', ");
            a.Append("'"+Cuenta.Nombre+"', ");
            a.Append("'"+Cuenta.Telefono+"', ");
            a.Append("'"+Cuenta.Email+"', ");
            a.Append("'"+Cuenta.Password+"', ");
            a.Append("'"+Cuenta.Pregunta+"', ");
            a.Append("'"+Cuenta.Respuesta+"', ");
            a.Append("'"+Cuenta.TipoCuenta.Id+"', ");
            a.Append("'"+Cuenta.EstadoCuenta.Id+"'");
            a.Append(")");
            Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Confirmar(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set IdEstadoCuenta='Vigente' where IdCuenta='" + Cuenta.Id + "' and IdEstadoCuenta='PteConf' ");
            int cantReg = (int) Ejecutar(a.ToString(), TipoRetorno.CantReg, Transaccion.NoAcepta, sesion.CnnStr);
            if (cantReg != 1)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfUpdateErroneo();
            }
        }
    }
}