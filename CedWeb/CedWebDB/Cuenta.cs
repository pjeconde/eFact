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
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.ActivCP, Cuenta.NroSerieDisco, Cuenta.IdMedio, Medio.DescrMedio ");
            a.Append("from Cuenta, TipoCuenta, EstadoCuenta, Medio ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdMedio=Medio.IdMedio ");
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
            Hasta.FechaAlta = Convert.ToDateTime(Desde["FechaAlta"]);
            Hasta.CantidadEnviosMail = Convert.ToInt32(Desde["CantidadEnviosMail"]);
            Hasta.FechaUltimoReenvioMail = Convert.ToDateTime(Desde["FechaUltimoReenvioMail"]);
            Hasta.ActivCP = Convert.ToBoolean(Desde["ActivCP"]);
            Hasta.NroSerieDisco = Convert.ToString(Desde["NroSerieDisco"]);
            Hasta.Medio.Id = Convert.ToString(Desde["IdMedio"]);
            Hasta.Medio.Descr = Convert.ToString(Desde["DescrMedio"]);
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
            a.Append("'" + Cuenta.EstadoCuenta.Id + "', ");
            a.Append("" + Cuenta.UltimoNroLote + ", ");
            a.Append("getdate(), ");    //FechaAlta
            a.Append("1, ");            //CantidadEnviosMail
            a.Append("getdate(), ");    //FechaUltimoReenvioMail
            a.Append("0, ");            //ActivCP
            a.Append("'', ");            //NroSerieDisco
            a.Append("'" + Cuenta.Medio.Id + "' ");
            a.Append(")");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
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
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.ActivCP, Cuenta.NroSerieDisco, Cuenta.IdMedio, Medio.DescrMedio ");
            a.Append("from Cuenta, TipoCuenta, EstadoCuenta, Medio ");
            a.Append("where Cuenta.Email='" + Email + "' and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdMedio=Medio.IdMedio ");
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
            a.Append("Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.ActivCP, Cuenta.NroSerieDisco, Cuenta.IdMedio, Medio.DescrMedio ");
            a.Append("from Cuenta, TipoCuenta, EstadoCuenta, Medio ");
            a.Append("where Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdMedio=Medio.IdMedio ");
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
            return CantidadDeFilas(true);
        }
        public int CantidadDeFilas(bool IncluirAdministradores)
        {
            string commandText;
            if (IncluirAdministradores)
            {
                commandText = "select count(*) from Cuenta ";
            }
            else
            {
                commandText = "select count(*) from Cuenta where IdTipoCuenta<>'Admin' ";
            }
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
                Cuenta.UltimoNroLote = Convert.ToInt64(dt.Rows[0]["UltimoNroLote"]);
            }
        }
        public void Configurar(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set ");
            a.Append("Nombre='" + Cuenta.Nombre + "', ");
            a.Append("Telefono='" + Cuenta.Telefono + "', ");
            a.Append("UltimoNroLote=" + Cuenta.UltimoNroLote.ToString() + " ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void CambiarEstado(CedWebEntidades.Cuenta Cuenta, CedWebEntidades.EstadoCuenta NuevoEstadoCuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set ");
            a.Append("IdEstadoCuenta='" + NuevoEstadoCuenta.Id + "' ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void DepurarBajas()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("delete Comprador where IdCuenta in (select IdCuenta from Cuenta where IdEstadoCuenta='Baja') ");
            a.Append("delete Vendedor where IdCuenta in (select IdCuenta from Cuenta where IdEstadoCuenta='Baja') ");
            a.Append("delete Cuenta where IdEstadoCuenta='Baja' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void RegistrarReenvioMail(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set Cuenta.CantidadEnviosMail=Cuenta.CantidadEnviosMail+1, FechaUltimoReenvioMail=getdate() where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void CambiarActivCP(CedWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set Cuenta.ActivCP=1-Cuenta.ActivCP where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void ApagarActivCP(CedWebEntidades.Cuenta Cuenta, string NroSerieDisco)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set Cuenta.ActivCP=0, Cuenta.NroSerieDisco='" + NroSerieDisco + "' where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedWebEntidades.Estadistica> EstadisticaMedio()
        {
            List<CedWebEntidades.Estadistica> lista = new List<CedWebEntidades.Estadistica>();
            int cantidadCuentas = CantidadDeFilas();
            if (cantidadCuentas > 0)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.Append("select Medio.IdMedio, count(*) as Cantidad ");
                a.Append("from Cuenta, Medio ");
                a.Append("where Cuenta.IdMedio=Medio.IdMedio ");
                a.Append("group by Medio.IdMedio ");
                a.Append("order by count(*) desc ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Estadistica elemento = new CedWebEntidades.Estadistica();
                    elemento.Concepto = Convert.ToString(dt.Rows[i]["IdMedio"]);
                    elemento.Cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);
                    elemento.Porcentaje = elemento.Cantidad * 100 / cantidadCuentas;
                    lista.Add(elemento);
                }
            }
            return lista;
        }
    }
}