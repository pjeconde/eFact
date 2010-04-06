using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class PuntoDeVenta : db
    {
        public PuntoDeVenta(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedWebEntidades.Vendedor Vendedor)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select PuntoDeVenta.IdPuntoDeVenta, PuntoDeVenta.IdTipoPuntoDeVenta, PuntoDeVenta.Calle, PuntoDeVenta.Nro, PuntoDeVenta.Piso, PuntoDeVenta.Depto, PuntoDeVenta.Sector, PuntoDeVenta.Torre, PuntoDeVenta.Manzana, PuntoDeVenta.Localidad, PuntoDeVenta.IdProvincia, PuntoDeVenta.DescrProvincia, PuntoDeVenta.CodPost, TipoPuntoDeVenta.DescrTipoPuntoDeVenta ");
            a.Append("from PuntoDeVenta, TipoPuntoDeVenta ");
            a.Append("where PuntoDeVenta.IdTipoPuntoDeVenta=TipoPuntoDeVenta.IdTipoPuntoDeVenta and PuntoDeVenta.CUIT=" + Convert.ToString(Vendedor.CUIT) + " ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count > 0)
            {
                if (Vendedor.PuntosDeVenta.Count != 0)
                {
                    Vendedor.PuntosDeVenta.Clear();
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.PuntoDeVenta puntoDeVenta = new CedWebEntidades.PuntoDeVenta();
                    puntoDeVenta.Id = Convert.ToInt32(dt.Rows[i]["IdPuntoDeVenta"]);
                    puntoDeVenta.Tipo.Id = Convert.ToString(dt.Rows[i]["IdTipoPuntoDeVenta"]);
                    puntoDeVenta.Tipo.Descr = Convert.ToString(dt.Rows[i]["DescrTipoPuntoDeVenta"]);
                    puntoDeVenta.Domicilio.Calle = Convert.ToString(dt.Rows[i]["Calle"]);
                    puntoDeVenta.Domicilio.Nro = Convert.ToString(dt.Rows[i]["Nro"]);
                    puntoDeVenta.Domicilio.Piso = Convert.ToString(dt.Rows[i]["Piso"]);
                    puntoDeVenta.Domicilio.Depto = Convert.ToString(dt.Rows[i]["Depto"]);
                    puntoDeVenta.Domicilio.Sector = Convert.ToString(dt.Rows[i]["Sector"]);
                    puntoDeVenta.Domicilio.Torre = Convert.ToString(dt.Rows[i]["Torre"]);
                    puntoDeVenta.Domicilio.Manzana = Convert.ToString(dt.Rows[i]["Manzana"]);
                    puntoDeVenta.Domicilio.Localidad = Convert.ToString(dt.Rows[i]["Localidad"]);
                    puntoDeVenta.Domicilio.IdProvincia = Convert.ToString(dt.Rows[i]["IdProvincia"]);
                    puntoDeVenta.Domicilio.DescrProvincia = Convert.ToString(dt.Rows[i]["DescrProvincia"]);
                    puntoDeVenta.Domicilio.CodPost = Convert.ToString(dt.Rows[i]["CodPost"]);
                    Vendedor.PuntosDeVenta.Add(puntoDeVenta);
                }
            }
        }
    }
}