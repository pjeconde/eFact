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
                Vendedor.NombreCuenta = Convert.ToString(dt.Rows[0]["NombreCuenta"]);
                Vendedor.RazonSocial = Convert.ToString(dt.Rows[0]["RazonSocial"]);
                Vendedor.Calle = Convert.ToString(dt.Rows[0]["Calle"]);
                Vendedor.Nro = Convert.ToString(dt.Rows[0]["Nro"]);
                Vendedor.Piso = Convert.ToString(dt.Rows[0]["Piso"]);
                Vendedor.Depto = Convert.ToString(dt.Rows[0]["Depto"]);
                Vendedor.Sector = Convert.ToString(dt.Rows[0]["Sector"]);
                Vendedor.Torre = Convert.ToString(dt.Rows[0]["Torre"]);
                Vendedor.Manzana = Convert.ToString(dt.Rows[0]["Manzana"]);
                Vendedor.Localidad = Convert.ToString(dt.Rows[0]["Localidad"]);
                Vendedor.IdProvincia = Convert.ToString(dt.Rows[0]["IdProvincia"]);
                Vendedor.DescrProvincia = Convert.ToString(dt.Rows[0]["DescrProvincia"]);
                Vendedor.CodPost = Convert.ToString(dt.Rows[0]["CodPost"]);
                Vendedor.NombreContacto = Convert.ToString(dt.Rows[0]["NombreContacto"]);
                Vendedor.EmailContacto = Convert.ToString(dt.Rows[0]["EmailContacto"]);
                Vendedor.TelefonoContacto = Convert.ToInt64(dt.Rows[0]["TelefonoContacto"]);
                Vendedor.CUIT = Convert.ToInt64(dt.Rows[0]["CUIT"]);
                Vendedor.IdCondIVA = Convert.ToInt32(dt.Rows[0]["IdCondIVA"]);
                Vendedor.DescrCondIVA = Convert.ToString(dt.Rows[0]["DescrCondIVA"]);
                Vendedor.NroIngBrutos = Convert.ToString(dt.Rows[0]["NroIngBrutos"]);
                Vendedor.IdCondIngBrutos = Convert.ToInt32(dt.Rows[0]["IdCondIngBrutos"]);
                Vendedor.DescrCondIngBrutos = Convert.ToString(dt.Rows[0]["DescrCondIngBrutos"]);
                Vendedor.GLN = Convert.ToInt64(dt.Rows[0]["GLN"]);
                Vendedor.CodigoInterno = Convert.ToString(dt.Rows[0]["CodigoInterno"]);
                Vendedor.FechaInicioActividades = Convert.ToDateTime(dt.Rows[0]["FechaInicioActividades"]);
            }
        }
        public void Guardar(CedWebEntidades.Vendedor Vendedor)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("if exists (select RazonSocial from Vendedor where IdCuenta='" + Vendedor.IdCuenta + "') ");

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
            a.Append("TelefonoContacto=" + Vendedor.TelefonoContacto + ", ");
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
            a.Append(Vendedor.TelefonoContacto + ", ");
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
            Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}