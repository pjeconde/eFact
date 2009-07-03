using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class Vendedor : db
    {
        public Vendedor(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedWebEntidades.Vendedor Vendedor)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Vendedor.IdCuenta, Cuenta.Nombre as NombreCuenta, Vendedor.RazonSocial, Vendedor.Calle, Vendedor.Nro, Vendedor.Piso, Vendedor.Depto, Vendedor.Sector, Vendedor.Torre, Vendedor.Manzana, Vendedor.Localidad, Vendedor.IdProvincia, Vendedor.DescrProvincia, Vendedor.CodPost, Vendedor.NombreContacto, Vendedor.EmailContacto, Vendedor.TelefonoContacto, Vendedor.CUIT, Vendedor.IdCondIVA, Vendedor.DescrCondIVA, Vendedor.NroIngBrutos, Vendedor.IdCondIngBrutos, Vendedor.DescrCondIngBrutos, Vendedor.GLN, Vendedor.CodigoInterno, Vendedor.FechaInicioActividades from Vendedor, Cuenta ");
            a.Append("where Vendedor.IdCuenta='" + Vendedor.IdCuenta + "' and Vendedor.IdCuenta=Cuenta.IdCuenta ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Vendedor asociado a la cuenta " + Vendedor.IdCuenta);
            }
            else
            {
                Copiar(dt.Rows[0], Vendedor);
                CedWebDB.BonoFiscal bonoFiscal = new BonoFiscal(sesion);
                bonoFiscal.Leer(Vendedor);
            }
        }
        private void Copiar(DataRow Desde, CedWebEntidades.Vendedor Hasta)
        {
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
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
            Hasta.CUIT = Convert.ToInt64(Desde["CUIT"]);
            Hasta.IdCondIVA = Convert.ToInt32(Desde["IdCondIVA"]);
            Hasta.DescrCondIVA = Convert.ToString(Desde["DescrCondIVA"]);
            Hasta.NroIngBrutos = Convert.ToString(Desde["NroIngBrutos"]);
            Hasta.IdCondIngBrutos = Convert.ToInt32(Desde["IdCondIngBrutos"]);
            Hasta.DescrCondIngBrutos = Convert.ToString(Desde["DescrCondIngBrutos"]);
            Hasta.GLN = Convert.ToInt64(Desde["GLN"]);
            Hasta.CodigoInterno = Convert.ToString(Desde["CodigoInterno"]);
            Hasta.FechaInicioActividades = Convert.ToDateTime(Desde["FechaInicioActividades"]);
        }
        public void Guardar(CedWebEntidades.Vendedor Vendedor)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("delete BonoFiscal where CUIT=" + Vendedor.CUIT.ToString() + " ");
            a.Append("if exists (select RazonSocial from Vendedor where IdCuenta='" + Vendedor.IdCuenta + "') ");
            a.Append("begin ");
            a.Append("delete BonoFiscal from Vendedor, BonoFiscal where Vendedor.CUIT=BonoFiscal.CUIT and Vendedor.IdCuenta='" + Vendedor.IdCuenta + "' ");
            a.Append("update Vendedor set ");
            a.Append("RazonSocial='" + Vendedor.RazonSocial + "', ");
            a.Append("Calle='" + Vendedor.Calle + "', ");
            a.Append("Nro='" + Vendedor.Nro + "', ");
            a.Append("Piso='" + Vendedor.Piso + "', ");
            a.Append("Depto='" + Vendedor.Depto + "', ");
            a.Append("Sector='" + Vendedor.Sector + "', ");
            a.Append("Torre='" + Vendedor.Torre + "', ");
            a.Append("Manzana='" + Vendedor.Manzana + "', ");
            a.Append("Localidad='" + Vendedor.Localidad + "', ");
            a.Append("IdProvincia='" + Vendedor.IdProvincia + "', ");
            a.Append("DescrProvincia='" + Vendedor.DescrProvincia + "', ");
            a.Append("CodPost='" + Vendedor.CodPost + "', ");
            a.Append("NombreContacto='" + Vendedor.NombreContacto + "', ");
            a.Append("EmailContacto='" + Vendedor.EmailContacto + "', ");
            a.Append("TelefonoContacto='" + Vendedor.TelefonoContacto + "', ");
            a.Append("CUIT=" + Vendedor.CUIT + ", ");
            a.Append("IdCondIVA=" + Vendedor.IdCondIVA + ", ");
            a.Append("DescrCondIVA='" + Vendedor.DescrCondIVA + "', ");
            a.Append("NroIngBrutos='" + Vendedor.NroIngBrutos + "', ");
            a.Append("IdCondIngBrutos=" + Vendedor.IdCondIngBrutos + ", ");
            a.Append("DescrCondIngBrutos='" + Vendedor.DescrCondIngBrutos + "', ");
            a.Append("GLN=" + Vendedor.GLN + ", ");
            a.Append("CodigoInterno='" + Vendedor.CodigoInterno + "', ");
            a.Append("FechaInicioActividades='" + Vendedor.FechaInicioActividades.ToString("yyyyMMdd") + "' ");
            a.Append("where IdCuenta='" + Vendedor.IdCuenta + "' ");
            a.Append("end ");

            a.Append("else ");

            a.Append("insert Vendedor values (");
            a.Append("'" + Vendedor.IdCuenta + "', ");
            a.Append("'" + Vendedor.RazonSocial + "', ");
            a.Append("'" + Vendedor.Calle + "', ");
            a.Append("'" + Vendedor.Nro + "', ");
            a.Append("'" + Vendedor.Piso + "', ");
            a.Append("'" + Vendedor.Depto + "', ");
            a.Append("'" + Vendedor.Sector + "', ");
            a.Append("'" + Vendedor.Torre + "', ");
            a.Append("'" + Vendedor.Manzana + "', ");
            a.Append("'" + Vendedor.Localidad + "', ");
            a.Append("'" + Vendedor.IdProvincia + "', ");
            a.Append("'" + Vendedor.DescrProvincia + "', ");
            a.Append("'" + Vendedor.CodPost + "', ");
            a.Append("'" + Vendedor.NombreContacto + "', ");
            a.Append("'" + Vendedor.EmailContacto + "', ");
            a.Append("'" + Vendedor.TelefonoContacto + "', ");
            a.Append(Vendedor.CUIT + ", ");
            a.Append(Vendedor.IdCondIVA + ", ");
            a.Append("'" + Vendedor.DescrCondIVA + "', ");
            a.Append("'" + Vendedor.NroIngBrutos + "', ");
            a.Append(Vendedor.IdCondIngBrutos + ", ");
            a.Append("'" + Vendedor.DescrCondIngBrutos + "', ");
            a.Append(Vendedor.GLN + ", ");
            a.Append("'" + Vendedor.CodigoInterno + "', ");
            a.Append("'" + Vendedor.FechaInicioActividades.ToString("yyyyMMdd") + "' ");
            a.Append(") ");

            for (int i = 0; i < Vendedor.BonoFiscal.PuntoDeVentaHabilitado.Count; i++)
            {
                a.Append("insert BonoFiscal values (" + Vendedor.CUIT.ToString() + ", " + Convert.ToString(Vendedor.BonoFiscal.PuntoDeVentaHabilitado[i]) + ") ");
            }
            Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedWebEntidades.Vendedor> ListaAdministracion(int IndicePagina, int TamañoPagina, string OrderBy)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Vendedor.IdCuenta, Cuenta.Nombre as NombreCuenta, Vendedor.RazonSocial, Vendedor.Calle, Vendedor.Nro, Vendedor.Piso, Vendedor.Depto, Vendedor.Sector, Vendedor.Torre, Vendedor.Manzana, Vendedor.Localidad, Vendedor.IdProvincia, Vendedor.DescrProvincia, Vendedor.CodPost, Vendedor.NombreContacto, Vendedor.EmailContacto, Vendedor.TelefonoContacto, Vendedor.CUIT, Vendedor.IdCondIVA, Vendedor.DescrCondIVA, Vendedor.NroIngBrutos, Vendedor.IdCondIngBrutos, Vendedor.DescrCondIngBrutos, Vendedor.GLN, Vendedor.CodigoInterno, Vendedor.FechaInicioActividades ");
            a.Append("from Vendedor, Cuenta ");
            a.Append("where Vendedor.IdCuenta=Cuenta.IdCuenta ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedWebEntidades.Vendedor> lista = new List<CedWebEntidades.Vendedor>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Vendedor Vendedor = new CedWebEntidades.Vendedor();
                    Copiar(dt.Rows[i], Vendedor);
                    lista.Add(Vendedor);
                }
            }
            return lista;
        }
        public int CantidadDeFilasAdministracion()
        {
            string commandText = "select count(*) from Vendedor ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}