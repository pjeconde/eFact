using System;
using System.Collections.Generic;
using System.Text;
using Cedeira.SV;
using System.Data;

namespace FEAdb
{
	public class dbFeriado : dbBase
	{
		public dbFeriado(Idb_Sesion Sesion)
			: base(Sesion)
		{
		}
		public bool EsFeriado(DateTime Fecha)
		{
			StringBuilder a = new StringBuilder(String.Empty);
			a.Append("select IdFeriado, IdUN, DescrFeriado, IdEstadoFeriado from Feriado where IdFeriado='" + Fecha.ToString("yyyyMMdd") + "' and IdUN='' and IdEstadoFeriado='A' ");
			return (bool)(((DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, m_Sesion.CnnStr)).Rows.Count == 1);
		}
		public bool EsFeriado(DateTime Fecha, string IdUN)
		{
			StringBuilder a = new StringBuilder(String.Empty);
			a.Append("select IdFeriado, IdUN, DescrFeriado, IdEstadoFeriado from Feriado where IdFeriado='" + Fecha.ToString("yyyyMMdd") + "' and IdUN='" + IdUN + "' and IdEstadoFeriado='A' ");
			return (bool)(((DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, m_Sesion.CnnStr)).Rows.Count == 1);
		}
		public void Feriado_ins(DateTime IdFeriado, string IdUN, string DescrFeriado, EstadoEnum IdEstadoFeriado)
		{
			StringBuilder a = new StringBuilder(String.Empty);
			a.Append("insert Feriado values ('" + IdFeriado.ToString("yyyyMMdd") + "', '" + IdUN + "', '" + DescrFeriado + "', '" + Convert.ToString(Convert.ToChar(Convert.ToInt32(IdEstadoFeriado))) + "')");
			Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, m_Sesion.CnnStr);
		}
		public void Feriado_upd(DateTime IdFeriado, string IdUN, string DescrFeriado, EstadoEnum IdEstadoFeriado)
		{
			StringBuilder a = new StringBuilder(String.Empty);
			a.Append("update Feriado set DescrFeriado = '" + DescrFeriado + "', IdEstadoFeriado = '" + Convert.ToString(Convert.ToChar(Convert.ToInt32(IdEstadoFeriado))) + "' ");
			a.Append("where IdFeriado = '" + IdFeriado.ToString("yyyyMMdd") + "' and IdUN = '" + IdUN + "'");
			Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, m_Sesion.CnnStr);
		}
		public DataTable Feriado_get(DateTime IdFeriado, string IdUN)
		{
			StringBuilder a = new StringBuilder(String.Empty);
			a.Append("select IdFeriado, IdUN, DescrFeriado, IdEstadoFeriado from Feriado where IdFeriado='" + IdFeriado.ToString("yyyyMMdd") + "' and IdUN='" + IdUN + "' ");
			return (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, m_Sesion.CnnStr);
		}
		public DataTable Feriado_qry()
		{
			StringBuilder a = new StringBuilder(String.Empty);
			a.Append("select Feriado.IdFeriado, Feriado.IdUN, UN.DescrUN, Feriado.DescrFeriado, Estado.DescrEstado from Feriado, UN, Estado where UN.IdUN=Feriado.IdUN and Feriado.IdEstadoFeriado=Estado.IdEstado ");
			a.Append("union ");
			a.Append("select Feriado.IdFeriado, Feriado.IdUN, 'Todos' as DescrUN, Feriado.DescrFeriado, Estado.DescrEstado from Feriado, UN, Estado where Feriado.IdUN='' and Feriado.IdEstadoFeriado=Estado.IdEstado");
			return (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, m_Sesion.CnnStr);
		}
	}
}
