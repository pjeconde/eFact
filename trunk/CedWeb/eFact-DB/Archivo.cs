using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_DB
{
    public class Archivo: db
    {
        public Archivo(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public void Consultar(List<eFact_Entidades.Archivo> Archivos, eFact_Entidades.Archivo.TipoConsultaArchivos TipoConsultaArchivos, eFact_Entidades.Archivo.OtrosFiltros OtrosFiltros, DateTime FechaDsd, DateTime FechaHst)
        {
            StringBuilder commandText = new StringBuilder();
            //Query Lotes
            commandText.Append("select * from Archivos ");
            if (TipoConsultaArchivos == eFact_Entidades.Archivo.TipoConsultaArchivos.FechaCreacion)
            {
                commandText.Append("where FechaCreacion >= '" + FechaDsd.ToString("yyyyMMdd") + "' and FechaCreacion <= Dateadd(Day, 1, '" + FechaHst.ToString("yyyyMMdd") + "') ");
            }
            else
            {
                commandText.Append("where FechaProceso >= '" + FechaDsd.ToString("yyyyMMdd") + "' and FechaProceso <= Dateadd(Day, 1, '" + FechaHst.ToString("yyyyMMdd") + "') ");
            }
            if (OtrosFiltros != eFact_Entidades.Archivo.OtrosFiltros.SinAplicar)
            {
                if (OtrosFiltros == eFact_Entidades.Archivo.OtrosFiltros.OK)
                {
                    commandText.Append(" and IdLote is not null");
                }
                else
                {
                    commandText.Append(" and IdLote is null");
                }
            }
            commandText.Append(" order by IdArchivo Desc");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eFact_Entidades.Archivo archivo = new eFact_Entidades.Archivo();
                    Copiar(dt.Rows[i], archivo);
                    Archivos.Add(archivo);
                }
            }
        }
        public void Leer(eFact_Entidades.Archivo Archivo)
        {
            StringBuilder commandText = new StringBuilder();
            //Query Lotes
            commandText.Append("select * from Archivos ");
            if (Archivo.IdArchivo != 0)
            {
                commandText.Append("where IdArchivo=" + Archivo.IdArchivo + " ");
            }
            else
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("IdArchivo");
            }
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                Copiar(dt.Rows[0], Archivo);
            }
        }
        private void Copiar(DataRow Desde, eFact_Entidades.Archivo Hasta)
        {
            Hasta.IdArchivo = Convert.ToInt32(Desde["IdArchivo"]);
            Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.Path = Convert.ToString(Desde["Path"]);
            Hasta.Tipo = Convert.ToString(Desde["Tipo"]);
            Hasta.FechaCreacion = Convert.ToDateTime(Desde["FechaCreacion"]);
            Hasta.FechaModificacion = Convert.ToDateTime(Desde["FechaModificacion"]);
            Hasta.Tamaño = Convert.ToInt32(Desde["Tamaño"]);
            Hasta.TamañoUMedida = Convert.ToString(Desde["TamañoUMedida"]);
            Hasta.Comentario = Convert.ToString(Desde["Comentario"]);
            Hasta.FechaProceso = Convert.ToDateTime(Desde["FechaProceso"]);                
            Hasta.NombreProcesado = Convert.ToString(Desde["NombreProcesado"]);
            Hasta.IdUsuario = Convert.ToString(Desde["IdUsuario"]);
            if (!Desde["IdLote"].Equals(System.DBNull.Value))
            {
                Hasta.IdLote = Convert.ToInt32(Desde["IdLote"]);
            }
        }
        public string Insertar(eFact_Entidades.Archivo Archivo, bool Handler)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append(" insert Archivos values ('");
            commandText.Append(Archivo.Nombre + "', '");
            commandText.Append(Archivo.Tipo + "', '");
            commandText.Append(Archivo.Path + "', '");
            commandText.Append(Archivo.FechaCreacion.ToString("yyyyMMdd HH:mm:ss") + "', '");
            commandText.Append(Archivo.FechaModificacion.ToString("yyyyMMdd HH:mm:ss") + "', ");
            commandText.Append(Archivo.Tamaño + ", '");
            commandText.Append(Archivo.TamañoUMedida + "', ");
            if (Archivo.Comentario != null)
            {
                commandText.Append("'" + Archivo.Comentario.Replace(Convert.ToChar("'"), Convert.ToChar(" ")) + "', ");
            }
            else 
            {
                commandText.Append("null, ");
            }
            commandText.Append("'" + Archivo.FechaProceso.ToString("yyyyMMdd HH:mm:ss") + "', ");
            if (Archivo.NombreProcesado != null)
            {
                commandText.Append("'" + Archivo.NombreProcesado + "', ");
            }
            else
            {
                commandText.Append("null, ");
            }
            commandText.Append("'" + Archivo.IdUsuario + "', ");
            if (Handler)
            {
                commandText.Append("@IdLote) ");
                return commandText.ToString();
            }
            else
            {
                commandText.Append("null) ");
                Ejecutar(commandText.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
                return "";
            }
        }
    }
}

