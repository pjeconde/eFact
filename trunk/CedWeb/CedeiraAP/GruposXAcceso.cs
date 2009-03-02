using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cedeira.SV
{
    public static class GruposXAcceso
    {
        public static List<CedEntidades.Grupo> Leer(string IdAcceso, CedEntidades.Sesion Sesion)
        {
            List<CedEntidades.Grupo> gruposXAcceso = new List<CedEntidades.Grupo>();
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            DataView dv = db.WF_GruposXAcceso_qry(IdAcceso);
            string[] GruposConAccPermitido = new string[dv.Table.Rows.Count];
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                CedEntidades.Grupo grupo = new CedEntidades.Grupo();
                grupo.IdGrupo = dv.Table.Rows[i]["IdGrupo"].ToString();
                grupo.DescrGrupo = dv.Table.Rows[i]["Descr"].ToString();
                grupo.IdTGrupo = dv.Table.Rows[i]["IdTGrupo"].ToString();
                gruposXAcceso.Add(grupo);
            }
            return gruposXAcceso;
        }
    }
}
