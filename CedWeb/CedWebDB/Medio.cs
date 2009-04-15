using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class Medio : db
    {
        public Medio(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<CedWebEntidades.Medio> Lista()
        {
            List<CedWebEntidades.Medio> lista = new List<CedWebEntidades.Medio>();
            CedWebEntidades.Medio seleccionar = new CedWebEntidades.Medio();
            seleccionar.Id = String.Empty;
            seleccionar.Descr = String.Empty; //"Seleccionar medio";
            lista.Add(seleccionar);
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("Medio.IdMedio, Medio.DescrMedio ");
            a.Append("from Medio ");
            a.Append("order by Medio.DescrMedio ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.Medio elemento = new CedWebEntidades.Medio();
                    elemento.Id = Convert.ToString(dt.Rows[i]["IdMedio"]);
                    elemento.Descr = Convert.ToString(dt.Rows[i]["DescrMedio"]);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
    }
}