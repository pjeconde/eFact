using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class Flag : db
    {
        public Flag(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedWebEntidades.Flag Flag)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Flag.IdFlag, Flag.Valor from Flag ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            for (int i=0; i<dt.Rows.Count; i++)
            {
                switch (Convert.ToString(dt.Rows[i]["IdFlag"]))
                {
                    case "ModoDepuracion":
                        Flag.ModoDepuracion=Convert.ToBoolean(dt.Rows[i]["Valor"]);
                        break;
                    case "PremiumSinCostoEnAltaCuenta":
                        Flag.PremiumSinCostoEnAltaCuenta = Convert.ToBoolean(dt.Rows[i]["Valor"]);
                        break;
                    case "CreacionCuentaHabilitada":
                        Flag.CreacionCuentaHabilitada = Convert.ToBoolean(dt.Rows[i]["Valor"]);
                        break;
                }
            }
        }
        public void SetearModoDepuracion(CedWebEntidades.Flag Flag)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Flag set Flag.Valor=" + Convert.ToInt32(Flag.ModoDepuracion) + " where Flag.IdFlag='ModoDepuracion' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void SetearPremiumSinCostoEnAltaCuenta(CedWebEntidades.Flag Flag)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Flag set Flag.Valor=" + Convert.ToInt32(Flag.PremiumSinCostoEnAltaCuenta) + " where Flag.IdFlag='PremiumSinCostoEnAltaCuenta' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void SetearCreacionCuentaHabilitada(CedWebEntidades.Flag Flag)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Flag set Flag.Valor=" + Convert.ToInt32(Flag.CreacionCuentaHabilitada) + " where Flag.IdFlag='CreacionCuentaHabilitada' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}