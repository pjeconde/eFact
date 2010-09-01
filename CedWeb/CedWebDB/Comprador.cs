using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class Comprador : db
    {
        public Comprador(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedWebEntidades.Comprador Comprador)
        {
			StringBuilder a = new StringBuilder(string.Empty);
			a.Append("select Comprador.IdCuenta, Cuenta.Nombre as NombreCuenta, Comprador.RazonSocial, Comprador.Calle, Comprador.Nro, Comprador.Piso, Comprador.Depto, Comprador.Sector, Comprador.Torre, Comprador.Manzana, Comprador.Localidad, Comprador.IdProvincia, Comprador.DescrProvincia, Comprador.CodPost, Comprador.NombreContacto, Comprador.EmailContacto, Comprador.TelefonoContacto, Comprador.IdTipoDoc, Comprador.DescrTipoDoc, Comprador.NroDoc, Comprador.IdCondIVA, Comprador.DescrCondIVA, Comprador.NroIngBrutos, Comprador.IdCondIngBrutos, Comprador.DescrCondIngBrutos, Comprador.GLN, Comprador.CodigoInterno, Comprador.FechaInicioActividades, Comprador.EmailAvisoVisualizacion, Comprador.PasswordAvisoVisualizacion ");
			a.Append("from Comprador, Cuenta where Comprador.IdCuenta='" + Comprador.IdCuenta + "' and Comprador.RazonSocial='" + Comprador.RazonSocial + "' and Comprador.IdCuenta=Cuenta.IdCuenta ");
			DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
			if (dt.Rows.Count == 0)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Comprador asociado a la cuenta " + Comprador.IdCuenta);
			}
			else
			{
				Copiar(dt.Rows[0], Comprador);
			}
		}
        private void Copiar(DataRow Desde, CedWebEntidades.Comprador Hasta)
        {
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
            Hasta.NombreCuenta = Convert.ToString(Desde["NombreCuenta"]);
            Hasta.RazonSocial = Convert.ToString(Desde["RazonSocial"]);
            Hasta.Domicilio.Calle = Convert.ToString(Desde["Calle"]);
            Hasta.Domicilio.Nro = Convert.ToString(Desde["Nro"]);
            Hasta.Domicilio.Piso = Convert.ToString(Desde["Piso"]);
            Hasta.Domicilio.Depto = Convert.ToString(Desde["Depto"]);
            Hasta.Domicilio.Sector = Convert.ToString(Desde["Sector"]);
            Hasta.Domicilio.Torre = Convert.ToString(Desde["Torre"]);
            Hasta.Domicilio.Manzana = Convert.ToString(Desde["Manzana"]);
            Hasta.Domicilio.Localidad = Convert.ToString(Desde["Localidad"]);
            Hasta.Domicilio.Provincia.Id = Convert.ToString(Desde["IdProvincia"]);
            Hasta.Domicilio.Provincia.Descr = Convert.ToString(Desde["DescrProvincia"]);
            Hasta.Domicilio.CodPost = Convert.ToString(Desde["CodPost"]);
            Hasta.NombreContacto = Convert.ToString(Desde["NombreContacto"]);
            Hasta.EmailContacto = Convert.ToString(Desde["EmailContacto"]);
            Hasta.TelefonoContacto = Convert.ToString(Desde["TelefonoContacto"]);
            Hasta.IdTipoDoc = Convert.ToInt32(Desde["IdTipoDoc"]);
            Hasta.DescrTipoDoc = Convert.ToString(Desde["DescrTipoDoc"]);
            Hasta.NroDoc = Convert.ToInt64(Desde["NroDoc"]);
            Hasta.IdCondIVA = Convert.ToInt32(Desde["IdCondIVA"]);
            Hasta.DescrCondIVA = Convert.ToString(Desde["DescrCondIVA"]);
            Hasta.NroIngBrutos = Convert.ToString(Desde["NroIngBrutos"]);
            Hasta.IdCondIngBrutos = Convert.ToInt32(Desde["IdCondIngBrutos"]);
            Hasta.DescrCondIngBrutos = Convert.ToString(Desde["DescrCondIngBrutos"]);
            Hasta.GLN = Convert.ToInt64(Desde["GLN"]);
            Hasta.CodigoInterno = Convert.ToString(Desde["CodigoInterno"]);
            Hasta.FechaInicioActividades = Convert.ToDateTime(Desde["FechaInicioActividades"]);
            Hasta.EmailAvisoVisualizacion = Convert.ToString(Desde["EmailAvisoVisualizacion"]);
            Hasta.PasswordAvisoVisualizacion = Convert.ToString(Desde["PasswordAvisoVisualizacion"]);
        }
        public void Crear(CedWebEntidades.Comprador Comprador)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("insert Comprador values (");
            a.Append("'" + Comprador.IdCuenta + "', ");
            a.Append("'" + Comprador.RazonSocial + "', ");
            a.Append("'" + Comprador.Domicilio.Calle + "', ");
            a.Append("'" + Comprador.Domicilio.Nro + "', ");
            a.Append("'" + Comprador.Domicilio.Piso + "', ");
            a.Append("'" + Comprador.Domicilio.Depto + "', ");
            a.Append("'" + Comprador.Domicilio.Sector + "', ");
            a.Append("'" + Comprador.Domicilio.Torre + "', ");
            a.Append("'" + Comprador.Domicilio.Manzana + "', ");
            a.Append("'" + Comprador.Domicilio.Localidad + "', ");
            a.Append("'" + Comprador.Domicilio.Provincia.Id + "', ");
            a.Append("'" + Comprador.Domicilio.Provincia.Descr + "', ");
            a.Append("'" + Comprador.Domicilio.CodPost + "', ");
            a.Append("'" + Comprador.NombreContacto + "', ");
            a.Append("'" + Comprador.EmailContacto + "', ");
            a.Append("'" + Comprador.TelefonoContacto + "', ");
            a.Append(Comprador.IdTipoDoc + ", ");
            a.Append("'" + Comprador.DescrTipoDoc + "', ");
            a.Append(Comprador.NroDoc + ", ");
            a.Append(Comprador.IdCondIVA + ", ");
            a.Append("'" + Comprador.DescrCondIVA + "', ");
            a.Append("'" + Comprador.NroIngBrutos + "', ");
            a.Append(Comprador.IdCondIngBrutos + ", ");
            a.Append("'" + Comprador.DescrCondIngBrutos + "', ");
            a.Append(Comprador.GLN + ", ");
            a.Append("'" + Comprador.CodigoInterno + "', ");
            a.Append("'" + Comprador.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append("'" + Comprador.EmailAvisoVisualizacion + "', ");
            a.Append("'" + Comprador.PasswordAvisoVisualizacion + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Modificar(CedWebEntidades.Comprador Comprador)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Comprador set ");
            a.Append("Calle='" + Comprador.Domicilio.Calle + "', ");
            a.Append("Nro='" + Comprador.Domicilio.Nro + "', ");
            a.Append("Piso='" + Comprador.Domicilio.Piso + "', ");
            a.Append("Depto='" + Comprador.Domicilio.Depto + "', ");
            a.Append("Sector='" + Comprador.Domicilio.Sector + "', ");
            a.Append("Torre='" + Comprador.Domicilio.Torre + "', ");
            a.Append("Manzana='" + Comprador.Domicilio.Manzana + "', ");
            a.Append("Localidad='" + Comprador.Domicilio.Localidad + "', ");
            a.Append("IdProvincia='" + Comprador.Domicilio.Provincia.Id + "', ");
            a.Append("DescrProvincia='" + Comprador.Domicilio.Provincia.Descr + "', ");
            a.Append("CodPost='" + Comprador.Domicilio.CodPost + "', ");
            a.Append("NombreContacto='" + Comprador.NombreContacto + "', ");
            a.Append("EmailContacto='" + Comprador.EmailContacto + "', ");
            a.Append("TelefonoContacto='" + Comprador.TelefonoContacto + "', ");
            a.Append("IdTipoDoc=" + Comprador.IdTipoDoc + ", ");
            a.Append("DescrTipoDoc='" + Comprador.DescrTipoDoc + "', ");
            a.Append("NroDoc=" + Comprador.NroDoc + ", ");
            a.Append("IdCondIVA=" + Comprador.IdCondIVA + ", ");
            a.Append("DescrCondIVA='" + Comprador.DescrCondIVA + "', ");
            a.Append("NroIngBrutos='" + Comprador.NroIngBrutos + "', ");
            a.Append("IdCondIngBrutos=" + Comprador.IdCondIngBrutos + ", ");
            a.Append("DescrCondIngBrutos='" + Comprador.DescrCondIngBrutos + "', ");
            a.Append("GLN=" + Comprador.GLN + ", ");
            a.Append("CodigoInterno='" + Comprador.CodigoInterno + "', ");
            a.Append("FechaInicioActividades='" + Comprador.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append("EmailAvisoVisualizacion='" + Comprador.EmailAvisoVisualizacion + "', ");
            a.Append("PasswordAvisoVisualizacion='" + Comprador.PasswordAvisoVisualizacion + "' ");
            a.Append("where IdCuenta='" + Comprador.IdCuenta + "' and RazonSocial='" + Comprador.RazonSocial + "' ");
            Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Eliminar(CedWebEntidades.Comprador Comprador)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("delete Comprador ");
            a.Append("where Comprador.IdCuenta='" + Comprador.IdCuenta + "' ");
            a.Append("and Comprador.RazonSocial='" + Comprador.RazonSocial + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedWebEntidades.Comprador> Lista(CedWebEntidades.Cuenta Cuenta, bool ConSeleccionarComprador)
        {
			List<CedWebEntidades.Comprador> lista = new List<CedWebEntidades.Comprador>();
			if (Cuenta.Id != null)
			{
                if (ConSeleccionarComprador)
                {
                    CedWebEntidades.Comprador seleccionar = new CedWebEntidades.Comprador();
                    seleccionar.RazonSocial = "Seleccionar comprador";
                    lista.Add(seleccionar);
                }
				System.Text.StringBuilder a = new StringBuilder();
				a.Append("select ");
                a.Append("Comprador.IdCuenta, Cuenta.Nombre as NombreCuenta, Comprador.RazonSocial, Comprador.Calle, Comprador.Nro, Comprador.Piso, Comprador.Depto, Comprador.Sector, Comprador.Torre, Comprador.Manzana, Comprador.Localidad, Comprador.IdProvincia, Comprador.DescrProvincia, Comprador.CodPost, Comprador.NombreContacto, Comprador.EmailContacto, Comprador.TelefonoContacto, Comprador.IdTipoDoc, Comprador.DescrTipoDoc, Comprador.NroDoc, Comprador.IdCondIVA, Comprador.DescrCondIVA, Comprador.NroIngBrutos, Comprador.IdCondIngBrutos, Comprador.DescrCondIngBrutos, Comprador.GLN, Comprador.CodigoInterno, Comprador.FechaInicioActividades, Comprador.EmailAvisoVisualizacion, Comprador.PasswordAvisoVisualizacion ");
				a.Append("from Comprador, Cuenta ");
				a.Append("where Comprador.IdCuenta='" + Cuenta.Id + "' and Comprador.IdCuenta=Cuenta.IdCuenta ");
				a.Append("order by Comprador.RazonSocial ");
				DataTable dt = new DataTable();
				dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
				if (dt.Rows.Count != 0)
				{
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						CedWebEntidades.Comprador comprador = new CedWebEntidades.Comprador();
						Copiar(dt.Rows[i], comprador);
						lista.Add(comprador);
					}
				}
			}
            return lista;
        }
        public List<CedWebEntidades.Comprador> Lista(CedWebEntidades.Cuenta Cuenta, int IndicePagina, int TamañoPagina, string OrderBy)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Comprador.IdCuenta, Cuenta.Nombre as NombreCuenta, Comprador.RazonSocial, Comprador.Calle, Comprador.Nro, Comprador.Piso, Comprador.Depto, Comprador.Sector, Comprador.Torre, Comprador.Manzana, Comprador.Localidad, Comprador.IdProvincia, Comprador.DescrProvincia, Comprador.CodPost, Comprador.NombreContacto, Comprador.EmailContacto, Comprador.TelefonoContacto, Comprador.IdTipoDoc, Comprador.DescrTipoDoc, Comprador.NroDoc, Comprador.IdCondIVA, Comprador.DescrCondIVA, Comprador.NroIngBrutos, Comprador.IdCondIngBrutos, Comprador.DescrCondIngBrutos, Comprador.GLN, Comprador.CodigoInterno, Comprador.FechaInicioActividades, Comprador.EmailAvisoVisualizacion, Comprador.PasswordAvisoVisualizacion ");
            a.Append("from Comprador, Cuenta ");
            a.Append("where Comprador.IdCuenta='" + Cuenta.Id + "' and Comprador.IdCuenta=Cuenta.IdCuenta ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedWebEntidades.Comprador> lista = new List<CedWebEntidades.Comprador>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Comprador comprador = new CedWebEntidades.Comprador();
                    Copiar(dt.Rows[i], comprador);
                    lista.Add(comprador);
                }
            }
            return lista;
        }
        public int CantidadDeFilas(CedWebEntidades.Cuenta Cuenta)
        {
            string commandText = "select count(*) from Comprador where IdCuenta='" + Cuenta.Id + "' ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public List<CedWebEntidades.Comprador> ListaAdministracion(int IndicePagina, int TamañoPagina, string OrderBy)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Comprador.IdCuenta, Cuenta.Nombre as NombreCuenta, Comprador.RazonSocial, Comprador.Calle, Comprador.Nro, Comprador.Piso, Comprador.Depto, Comprador.Sector, Comprador.Torre, Comprador.Manzana, Comprador.Localidad, Comprador.IdProvincia, Comprador.DescrProvincia, Comprador.CodPost, Comprador.NombreContacto, Comprador.EmailContacto, Comprador.TelefonoContacto, Comprador.IdTipoDoc, Comprador.DescrTipoDoc, Comprador.NroDoc, Comprador.IdCondIVA, Comprador.DescrCondIVA, Comprador.NroIngBrutos, Comprador.IdCondIngBrutos, Comprador.DescrCondIngBrutos, Comprador.GLN, Comprador.CodigoInterno, Comprador.FechaInicioActividades, Comprador.EmailAvisoVisualizacion, Comprador.PasswordAvisoVisualizacion ");
            a.Append("from Comprador, Cuenta ");
            a.Append("where Comprador.IdCuenta=Cuenta.IdCuenta ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedWebEntidades.Comprador> lista = new List<CedWebEntidades.Comprador>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Comprador comprador = new CedWebEntidades.Comprador();
                    Copiar(dt.Rows[i], comprador);
                    lista.Add(comprador);
                }
            }
            return lista;
        }
        public int CantidadDeFilasAdministracion()
        {
            string commandText = "select count(*) from Comprador ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}