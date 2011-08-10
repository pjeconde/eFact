using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_I_Bj.DB
{
    public class Plantilla : db
    {
        public Plantilla(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public void Leer(eFact_I_Bj.Entidades.Plantilla Plantilla)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Plantillas where Plantillas.IdPlantilla = ");
            commandText.Append("where Plantillas.IdPlantilla = " + Plantilla.IdPlantilla);
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt, 0, Plantilla);
            }
        }
        public void Lista(List<eFact_I_Bj.Entidades.Plantilla> Plantilla)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Plantillas");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eFact_I_Bj.Entidades.Plantilla p = new eFact_I_Bj.Entidades.Plantilla();
                    Copiar(dt, i, p);
                    Plantilla.Add(p);
                }
            }
        }
        public void Insertar(eFact_I_Bj.Entidades.Plantilla Plantilla)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("insert Plantillas values ('" + Plantilla.DescrPlantilla + "', ");
            commandText.Append("'" + Plantilla.Leyenda1 + "', ");
            commandText.Append("'" + Plantilla.Leyenda2 + "', ");
            commandText.Append("'" + Plantilla.Leyenda3 + "', ");
            commandText.Append("'" + Plantilla.Leyenda4 + "', ");
            commandText.Append("'" + Plantilla.Leyenda5 + "', ");
            commandText.Append("'" + Plantilla.LeyendaMoneda + "', ");
            commandText.Append("'" + Plantilla.LeyendaBanco + "') ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
        }
        public void Modificar(eFact_I_Bj.Entidades.Plantilla Plantilla)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("update Plantillas set DescrPlantilla = '" + Plantilla.DescrPlantilla + "', ");
            commandText.Append("Leyenda1 = '" + Plantilla.Leyenda1 + "', ");
            commandText.Append("Leyenda2 = '" + Plantilla.Leyenda2 + "', ");
            commandText.Append("Leyenda3 = '" + Plantilla.Leyenda3 + "', ");
            commandText.Append("Leyenda4 = '" + Plantilla.Leyenda4 + "', ");
            commandText.Append("Leyenda5 = '" + Plantilla.Leyenda5 + "', ");
            commandText.Append("LeyendaMoneda = '" + Plantilla.LeyendaMoneda + "', ");
            commandText.Append("LeyendaBanco = '" + Plantilla.LeyendaBanco + "' ");
            commandText.Append("where Plantillas.IdPlantilla = " + Plantilla.IdPlantilla);
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
        }
        private void Copiar(DataTable dt, int Row ,eFact_I_Bj.Entidades.Plantilla Hasta)
        {
            Hasta.IdPlantilla = Convert.ToInt32(dt.Rows[Row]["IdPlantilla"].ToString());
            Hasta.DescrPlantilla = dt.Rows[Row]["DescrPlantilla"].ToString();
            Hasta.Leyenda1 = dt.Rows[Row]["Leyenda1"].ToString();
            Hasta.Leyenda2 = dt.Rows[Row]["Leyenda2"].ToString();
            Hasta.Leyenda3 = dt.Rows[Row]["Leyenda3"].ToString();
            Hasta.Leyenda4 = dt.Rows[Row]["Leyenda4"].ToString();
            Hasta.Leyenda5 = dt.Rows[Row]["Leyenda5"].ToString();
            Hasta.LeyendaMoneda = dt.Rows[Row]["LeyendaMoneda"].ToString();
            Hasta.LeyendaBanco = dt.Rows[Row]["LeyendaBanco"].ToString();
        }
    }
}
