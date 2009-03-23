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
            a.Append("select Comprador.IdCuenta, Cuenta.Nombre as NombreCuenta, Comprador.RazonSocial, Comprador.Calle, Comprador.Nro, Comprador.Piso, Comprador.Depto, Comprador.Sector, Comprador.Torre, Comprador.Manzana, Comprador.Localidad, Comprador.IdProvincia, Comprador.DescrProvincia, Comprador.CodPost, Comprador.NombreContacto, Comprador.EmailContacto, Comprador.TelefonoContacto, Comprador.IdTipoDoc, Comprador.DescrTipoDoc, Comprador.NroDoc, Comprador.IdCondIVA, Comprador.DescrCondIVA, Comprador.NroIngBrutos, Comprador.IdCondIngBrutos, Comprador.DescrCondIngBrutos, Comprador.GLN, Comprador.CodigoInterno, Comprador.FechaInicioActividades from Comprador, Cuenta ");
            a.Append("where Comprador.IdCuenta='" + Comprador.IdCuenta + "' and Comprador.RazonSocial='" + Comprador.RazonSocial + "' and Comprador.IdCuenta=Cuenta.IdCuenta ");
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
            Hasta.NombreCuenta = Convert.ToString(Desde["NombreCuenta"]);
            Hasta.RazonSocial = Convert.ToString(Desde["RazonSocial"]);
            Hasta.Calle = Convert.ToString(Desde["Calle"]);
            Hasta.Nro = Convert.ToString(Desde["Nro"]);
            Hasta.Piso = Convert.ToString(Desde["Piso"]);
            Hasta.Depto = Convert.ToString(Desde["Depto"]);
            Hasta.Sector = Convert.ToString(Desde["Sector"]);
            Hasta.Torre = Convert.ToString(Desde["Torre"]);
            Hasta.Manzana = Convert.ToString(Desde["Manzana"]);
            Hasta.Localidad = Convert.ToString(Desde["Localidad"]);
            Hasta.IdProvincia = Convert.ToString(Desde["IdProvincia"]);
            Hasta.DescrProvincia = Convert.ToString(Desde["DescrProvincia"]);
            Hasta.CodPost = Convert.ToString(Desde["CodPost"]);
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
        }
        public void Crear(CedWebEntidades.Comprador Comprador)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("insert Comprador values (");
            a.Append("'" + Comprador.IdCuenta + "', ");
            a.Append("'" + Comprador.RazonSocial + "', ");
            a.Append("'" + Comprador.Calle + "', ");
            a.Append("'" + Comprador.Nro + "', ");
            a.Append("'" + Comprador.Piso + "', ");
            a.Append("'" + Comprador.Depto + "', ");
            a.Append("'" + Comprador.Sector + "', ");
            a.Append("'" + Comprador.Torre + "', ");
            a.Append("'" + Comprador.Manzana + "', ");
            a.Append("'" + Comprador.Localidad + "', ");
            a.Append("'" + Comprador.IdProvincia + "', ");
            a.Append("'" + Comprador.DescrProvincia + "', ");
            a.Append("'" + Comprador.CodPost + "', ");
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
            a.Append("'" + Comprador.FechaInicioActividades.ToString("yyyyMMdd") + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Modificar(CedWebEntidades.Comprador Comprador)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Comprador set ");
            a.Append("Calle='" + Comprador.Calle + "', ");
            a.Append("Nro='" + Comprador.Nro + "', ");
            a.Append("Piso='" + Comprador.Piso + "', ");
            a.Append("Depto='" + Comprador.Depto + "', ");
            a.Append("Sector='" + Comprador.Sector + "', ");
            a.Append("Torre='" + Comprador.Torre + "', ");
            a.Append("Manzana='" + Comprador.Manzana + "', ");
            a.Append("Localidad='" + Comprador.Localidad + "', ");
            a.Append("IdProvincia='" + Comprador.IdProvincia + "', ");
            a.Append("DescrProvincia='" + Comprador.DescrProvincia + "', ");
            a.Append("CodPost='" + Comprador.CodPost + "', ");
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
            a.Append("FechaInicioActividades='" + Comprador.FechaInicioActividades.ToString("yyyyMMdd") + "' ");
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
        public List<CedWebEntidades.Comprador> Lista(CedWebEntidades.Cuenta Cuenta)
        {
			List<CedWebEntidades.Comprador> lista = new List<CedWebEntidades.Comprador>();
			if (Cuenta.Id != null)
			{
				CedWebEntidades.Comprador seleccionar = new CedWebEntidades.Comprador();
				seleccionar.RazonSocial = "Seleccionar comprador";
				lista.Add(seleccionar);
				System.Text.StringBuilder a = new StringBuilder();
				a.Append("select ");
				a.Append("Comprador.IdCuenta, Cuenta.Nombre as NombreCuenta, Comprador.RazonSocial, Comprador.Calle, Comprador.Nro, Comprador.Piso, Comprador.Depto, Comprador.Sector, Comprador.Torre, Comprador.Manzana, Comprador.Localidad, Comprador.IdProvincia, Comprador.DescrProvincia, Comprador.CodPost, Comprador.NombreContacto, Comprador.EmailContacto, Comprador.TelefonoContacto, Comprador.IdTipoDoc, Comprador.DescrTipoDoc, Comprador.NroDoc, Comprador.IdCondIVA, Comprador.DescrCondIVA, Comprador.NroIngBrutos, Comprador.IdCondIngBrutos, Comprador.DescrCondIngBrutos, Comprador.GLN, Comprador.CodigoInterno, Comprador.FechaInicioActividades ");
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
            a.Append("Comprador.IdCuenta, Cuenta.Nombre as NombreCuenta, Comprador.RazonSocial, Comprador.Calle, Comprador.Nro, Comprador.Piso, Comprador.Depto, Comprador.Sector, Comprador.Torre, Comprador.Manzana, Comprador.Localidad, Comprador.IdProvincia, Comprador.DescrProvincia, Comprador.CodPost, Comprador.NombreContacto, Comprador.EmailContacto, Comprador.TelefonoContacto, Comprador.IdTipoDoc, Comprador.DescrTipoDoc, Comprador.NroDoc, Comprador.IdCondIVA, Comprador.DescrCondIVA, Comprador.NroIngBrutos, Comprador.IdCondIngBrutos, Comprador.DescrCondIngBrutos, Comprador.GLN, Comprador.CodigoInterno, Comprador.FechaInicioActividades ");
            a.Append("from Comprador, Cuenta ");
            a.Append("where Comprador.IdCuenta='" + Cuenta.Id + "' and Comprador.IdCuenta=Cuenta.IdCuenta ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), ModificarOrderBy(OrderBy), (IndicePagina * TamañoPagina));
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
        private string ModificarOrderBy(string OrderBy)
        {
            switch (OrderBy.Trim())
            {
                case "NombreCuenta":
                    OrderBy = "Cuenta." + OrderBy;
                    break;
                default:
                    OrderBy = "Comprador." + OrderBy;
                    break;
            }
            return OrderBy;
        }
        public int CantidadDeFilas(CedWebEntidades.Cuenta Cuenta)
        {
            string commandText = "select count(*) from Comprador where IdCuenta='" + Cuenta.Id + "' ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}