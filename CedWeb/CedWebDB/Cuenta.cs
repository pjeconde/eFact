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
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote from Cuenta, TipoCuenta, EstadoCuenta ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Cuenta " + Cuenta.Id.ToString());
            }
            else
            {
                Copiar(dt.Rows[0], Cuenta);
            }
        }
        private void Copiar(DataRow Desde, CedWebEntidades.Cuenta Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.Telefono = Convert.ToString(Desde["Telefono"]);
            Hasta.Email = Convert.ToString(Desde["Email"]);
            Hasta.Password = Convert.ToString(Desde["Password"]);
            Hasta.Pregunta = Convert.ToString(Desde["Pregunta"]);
            Hasta.Respuesta = Convert.ToString(Desde["Respuesta"]);
            Hasta.TipoCuenta.Id = Convert.ToString(Desde["IdTipoCuenta"]);
            Hasta.TipoCuenta.Descr = Convert.ToString(Desde["DescrTipoCuenta"]);
            Hasta.EstadoCuenta.Id = Convert.ToString(Desde["IdEstadoCuenta"]);
            Hasta.EstadoCuenta.Descr = Convert.ToString(Desde["DescrEstadoCuenta"]);
            Hasta.UltimoNroLote = Convert.ToInt64(Desde["UltimoNroLote"]);
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
            a.Append("'"+Cuenta.EstadoCuenta.Id+"', ");
            a.Append("" + Cuenta.UltimoNroLote + ")");
            Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Confirmar(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set IdEstadoCuenta='Vigente' where IdCuenta='" + Cuenta.Id + "' and IdEstadoCuenta='PteConf' ");
            int cantReg = (int)Ejecutar(a.ToString(), TipoRetorno.CantReg, Transaccion.NoAcepta, sesion.CnnStr);
            if (cantReg != 1)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfUpdateErroneo();
            }
        }
        public void CambiarPassword(CedWebEntidades.Cuenta Cuenta, string PasswordNueva)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set Password='" + PasswordNueva + "' where IdCuenta='" + Cuenta.Id + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedWebEntidades.Cuenta> Lista(string Email)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote from Cuenta, TipoCuenta, EstadoCuenta ");
            a.Append("where Cuenta.Email='" + Email + "' and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.NoHayCuentasAsociadasAEmail();
            }
            else
            {
                List<CedWebEntidades.Cuenta> lista = new List<CedWebEntidades.Cuenta>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                    Copiar(dt.Rows[i], cuenta);
                    lista.Add(cuenta);
                }
                return lista;
            }
        }
        public List<CedWebEntidades.Cuenta> Lista(int IndicePagina, int TamañoPagina, string OrderBy)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote from Cuenta, TipoCuenta, EstadoCuenta ");
            a.Append("where Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), ModificarOrderBy(OrderBy), (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedWebEntidades.Cuenta> lista = new List<CedWebEntidades.Cuenta>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Cuenta cuenta = new CedWebEntidades.Cuenta();
                    Copiar(dt.Rows[i], cuenta);
                    lista.Add(cuenta);
                }
            }
            return lista;
        }
        private string ModificarOrderBy(string OrderBy)
        {
            switch (OrderBy.Trim())
            {
                case "DescrEstadoCuenta":
                    OrderBy = "EstadoCuenta." + OrderBy;
                    break;
                case "DescrTipoCuenta":
                    OrderBy = "TipoCuenta." + OrderBy;
                    break;
                case "Id":
                    OrderBy = "Cuenta.IdCuenta";
                    break;
                default:
                    OrderBy = "Cuenta." + OrderBy;
                    break;
            }
            return OrderBy;
        }
        public int CantidadDeFilas()
        {
            string commandText = "select count(*) from Cuenta ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public void ReservarNroLote(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("declare @UltimoNroLote numeric(14) ");
            a.Append("update Cuenta set @UltimoNroLote=Cuenta.UltimoNroLote=Cuenta.UltimoNroLote+1 from Cuenta where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            a.Append("select @UltimoNroLote as UltimoNroLote ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Cuenta " + Cuenta.Id.ToString());
            }
            else
            {
                Cuenta.UltimoNroLote=Convert.ToInt64(dt.Rows[0]["UltimoNroLote"]);
            }
        }
    }
}