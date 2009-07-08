using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class Publicacion : db
    {
        public Publicacion(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<CedWebEntidades.Publicacion> Lista(int IndicePagina, int TamañoPagina, string OrderBy)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Publicacion.IdPublicacion, Publicacion.DescrPublicacion, Publicacion.Asunto, Publicacion.URL ");
            a.Append("from Publicacion ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedWebEntidades.Publicacion> lista = new List<CedWebEntidades.Publicacion>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Publicacion publicacion = new CedWebEntidades.Publicacion();
                    Copiar(dt.Rows[i], publicacion);
                    lista.Add(publicacion);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedWebEntidades.Publicacion Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdPublicacion"]);
            Hasta.Descripcion = Convert.ToString(Desde["DescrPublicacion"]);
            Hasta.Asunto = Convert.ToString(Desde["Asunto"]);
            Hasta.URL = Convert.ToString(Desde["URL"]);
        }
        public int CantidadDeFilas()
        {
            string commandText;
            commandText = "select count(*) from Publicacion ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}
