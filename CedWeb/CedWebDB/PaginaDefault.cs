using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedWebDB
{
    public class PaginaDefault : db
    {
        public PaginaDefault(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public List<CedWebEntidades.PaginaDefault> Lista(CedWebEntidades.Cuenta Cuenta)
        {
            List<CedWebEntidades.PaginaDefault> lista = new List<CedWebEntidades.PaginaDefault>();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("PaginaDefault.IdPaginaDefault, PaginaDefault.DescrPaginaDefault, PaginaDefault.URL ");
            a.Append("from PaginaDefault, PaginaDefaultXTipoCuenta where PaginaDefault.IdPaginaDefault=PaginaDefaultXTipoCuenta.IdPaginaDefault and PaginaDefaultXTipoCuenta.IdTipoCuenta='" + Cuenta.TipoCuenta.Id + "' ");
            a.Append("order by PaginaDefault.DescrPaginaDefault ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedWebEntidades.PaginaDefault elemento = new CedWebEntidades.PaginaDefault();
                    elemento.Id = Convert.ToString(dt.Rows[i]["IdPaginaDefault"]);
                    elemento.Descr = Convert.ToString(dt.Rows[i]["DescrPaginaDefault"]);
                    elemento.URL = Convert.ToString(dt.Rows[i]["URL"]);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        public CedWebEntidades.PaginaDefault Predeterminada(CedWebEntidades.TipoCuenta TipoCuenta)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("PaginaDefault.IdPaginaDefault ");
            a.Append("from PaginaDefault, PaginaDefaultXTipoCuenta where PaginaDefault.IdPaginaDefault=PaginaDefaultXTipoCuenta.IdPaginaDefault and PaginaDefaultXTipoCuenta.IdTipoCuenta='" + TipoCuenta.Id + "' and PaginaDefaultXTipoCuenta.Predeterminada=1 ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            CedWebEntidades.PaginaDefault paginaDefault=new CedWebEntidades.PaginaDefault();
            paginaDefault.Id=Convert.ToString(dt.Rows[0]["IdPaginaDefault"]);
            return paginaDefault;
        }

    }
}