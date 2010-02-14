using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace eFact_R.DB
{
	public class Tablero : db
	{
        private CedEntidades.Sesion sesion;

        public Tablero(CedEntidades.Sesion Sesion) : base(Sesion)
		{
            sesion = Sesion;
		}
		public DataTable GetClientes()
		{
			string commandText = string.Format("Select * from Clientes");
			DataTable dt = new DataTable();
			dt=(DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
			return dt;
		}
        public DataTable GetComprobantes()
        {
            string commandText = string.Format("Select * from CtaCli");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return dt;
        }
        public DataTable GetComprobantesDet()
        {
            string commandText = string.Format("Select * from CtaCli_Detalle");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return dt;
        }
	}
}
