using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_DB
{
    public class Lote: db
    {
        public Lote(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(eFact_Entidades.Lote Lote)
        {
            StringBuilder commandText = new StringBuilder();
            //Query Lotes
            commandText.Append("select ");
            commandText.Append("Lotes.*, WF_Op.IdFlow ,WF_Op.IdCircuito, WF_Op.IdNivSeg, WF_Op.IdEstado, WF_Op.DescrOp, WF_Op.UltActualiz, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito , WF_NivSeg.DescrNivSeg, WF_Estado.DescrEstado ");
            commandText.Append("INTO #Lotes ");
            commandText.Append("from Lotes ");
            commandText.Append("inner join WF_Op on Lotes.IdOp = WF_Op.IdOp ");
            commandText.Append("inner join WF_Flow on WF_Op.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("inner join WF_Circuito on WF_Op.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("inner join WF_NivSeg on WF_Op.IdNivSeg=WF_NivSeg.IdNivSeg ");
            commandText.Append("inner join WF_Estado on WF_Op.IdEstado=WF_Estado.IdEstado ");
            if (Lote.IdLote != 0)
            {
                commandText.Append("where IdLote=" + Lote.IdLote + " ");
            }
            else if(Lote.CuitVendedor != "" && Lote.PuntoVenta != "" && Lote.NumeroLote != "" && Lote.NumeroEnvio != 0)
            {
                commandText.Append("where CuitVendedor = '" + Lote.CuitVendedor + "' ");
                commandText.Append("and PuntoVenta = '" + Lote.PuntoVenta + "' ");
                commandText.Append("and NumeroLote = '" + Lote.NumeroLote + "' ");
                commandText.Append("and NumeroEnvio = " + Lote.NumeroEnvio + " ");
            }
            else
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("IdLote");
            }
            commandText.Append("select * from #Lotes ");
            //Select Comprobantes
            commandText.Append("select Comprobantes.* from #Lotes ");
            commandText.Append("inner join Comprobantes on Comprobantes.IdLote = #Lotes.IdLote ");
            //Select WF_LOG
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Log.Fecha, WF_Evento.DescrEvento as Evento, WF_Estado.DescrEstado as Estado, WCUsuarios.Nombre+' ('+WF_Log.IdUsuario+')' as Responsable, WCUsuarios.Nombre as Nombre, ");
            commandText.Append("WF_Log.Comentario, WF_Log.IdLog, WF_Log.IdFlow, WF_Log.IdCircuito, WF_Log.IdNivSeg, WF_Log.IdGrupo, WF_Log.Supervisor, WF_Log.IdUsuario, ");
            commandText.Append("WF_Log.SupervisorNivel, WF_Log.IdEvento, WF_Log.IdEstado, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WCTbGrupos.Descr as DescrGrupo ");
            commandText.Append("from #Lotes, WF_Log, WCUsuarios, WF_Evento, WF_Estado, WF_Flow, WF_Circuito, WCTbGrupos ");
            commandText.Append("where WF_Log.IdOp = #Lotes.idOp "); 
            commandText.Append("and WF_Log.IdUsuario=WCUsuarios.IdUsuario ");
            commandText.Append("and WF_Log.IdFlow=WF_Evento.IdFlow ");
            commandText.Append("and WF_Log.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("and WF_Log.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("and WF_Log.IdGrupo=WCTbGrupos.IdGrupo ");
            commandText.Append("and WF_Log.IdEvento=WF_Evento.IdEvento ");
            commandText.Append("and WF_Log.IdEstado=WF_Estado.IdEstado ");
            //Select Eventos Posibles del WF    
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            //Select Eventos Posibles por lote
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow and WF_Evento.XLote=1 ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            //commandText.Append("drop table #Lotes ");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Usa, sesion.CnnStr);
            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                Copiar(ds, 0, Lote);
                Lote.WF.EsquemaSegEventosPosibles = WF_EsquemaSegEventosPosibles_qry(Lote.WF);
            }
        }
        private void Copiar(DataSet ds, int NroRowPpal, eFact_Entidades.Lote Hasta)
        {
            DataRow Desde;
            Desde = ds.Tables[0].Rows[NroRowPpal];
            Hasta.IdLote = Convert.ToInt32(Desde["IdLote"]);
            Hasta.CuitVendedor = Convert.ToString(Desde["CuitVendedor"]);
            Hasta.PuntoVenta = Convert.ToString(Desde["PuntoVenta"]);
            Hasta.NumeroLote = Convert.ToString(Desde["NumeroLote"]);
            Hasta.NumeroEnvio = Convert.ToInt32(Desde["NumeroEnvio"]);
            Hasta.IdOp = Convert.ToInt32(Desde["IdOp"]);
            Hasta.FechaAlta = Convert.ToDateTime(Desde["FechaAlta"]);
            if (Desde["FechaEnvio"].ToString() == "")
            {
                Desde["FechaEnvio"] = "31/12/9998";
            }
            Hasta.FechaEnvio = Convert.ToDateTime(Desde["FechaEnvio"]);
            Hasta.NombreArch = Convert.ToString(Desde["NombreArch"]);
            Hasta.CantidadRegistros = Convert.ToInt32(Desde["CantidadRegistros"]);
            Hasta.LoteXml = Convert.ToString(Desde["LoteXml"]);
            Hasta.LoteXmlIF = Convert.ToString(Desde["LoteXmlIF"]);
            Hasta.WF = new CedEntidades.WF();
            Hasta.WF.IdOp = Convert.ToInt32(Desde["IdOp"]);
            Hasta.WF.IdFlow = Convert.ToString(Desde["IdFlow"]);
            Hasta.WF.DescrFlow = Convert.ToString(Desde["DescrFlow"]);
            Hasta.WF.IdCircuito = Convert.ToString(Desde["IdCircuito"]);
            Hasta.WF.IdCircuitoOrig = Hasta.WF.IdCircuito;
            Hasta.WF.DescrCircuito = Convert.ToString(Desde["DescrCircuito"]);
            Hasta.WF.IdNivSeg = Convert.ToInt32(Desde["IdNivSeg"]);
            Hasta.WF.DescrNivSeg = Convert.ToString(Desde["DescrNivSeg"]);
            Hasta.WF.DescrOp = Convert.ToString(Desde["DescrOp"]);
            Hasta.WF.IdEstado = Convert.ToString(Desde["IdEstado"]);
            Hasta.WF.UltActualiz = Cedeira.SV.db.ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
            Hasta.WF.DescrEstado = Convert.ToString(Desde["DescrEstado"]);
            Hasta.WF.Sesion = sesion;
            //Comprobantes
            DataRow[] dr = ds.Tables[1].Select("IdLote = " + Convert.ToInt32(Hasta.IdLote));
            Hasta.Comprobantes = new List<eFact_Entidades.Comprobante>();
            for (int i = 0; i < dr.Length; i++)
            {
                eFact_Entidades.Comprobante c = new eFact_Entidades.Comprobante();
                c.IdLote = Convert.ToInt32(dr[i]["IdLote"]);
                c.IdTipoComprobante = Convert.ToInt16(dr[i]["IdTipoComprobante"]);
                c.NumeroComprobante = Convert.ToString(dr[i]["NumeroComprobante"]);
                c.IdMoneda = Convert.ToString(dr[i]["IdMoneda"]);
                c.Importe = Convert.ToDecimal(dr[i]["Importe"]);
                c.NroDocComprador = Convert.ToString(dr[i]["NroDocComprador"]);
                c.TipoDocComprador = Convert.ToInt16(dr[i]["TipoDocComprador"]);
                c.NombreComprador = Convert.ToString(dr[i]["NombreComprador"]);
                c.Fecha= Convert.ToDateTime(dr[i]["Fecha"]);
                c.NumeroCAE = Convert.ToString(dr[i]["NumeroCAE"]);
                if (dr[i]["FechaCAE"].ToString() == "")
                {
                    dr[i]["FechaCAE"] = "31/12/9998";
                }
                c.FechaCAE = Convert.ToDateTime(dr[i]["FechaCAE"]);
                if (dr[i]["FechaVtoCAE"].ToString() == "")
                {
                    dr[i]["FechaVtoCAE"] = "31/12/9998";
                }
                c.FechaVtoCAE = Convert.ToDateTime(dr[i]["FechaVtoCAE"]);
                if (dr[i]["ImporteMonedaOrigen"].ToString() != "")
                {
                    c.ImporteMonedaOrigen = Convert.ToDecimal(dr[i]["ImporteMonedaOrigen"]);
                }
                if (dr[i]["ImporteMonedaOrigen"].ToString() != "")
                {
                    c.TipoCambio = Convert.ToDecimal(dr[i]["TipoCambio"]);
                }
                if (dr[i]["EstadoIFoAFIP"].ToString() != "")
                {
                    c.EstadoIFoAFIP = Convert.ToString(dr[i]["EstadoIFoAFIP"]);
                }
                if (dr[i]["ComentarioIFoAFIP"].ToString() != "")
                {
                    c.ComentarioIFoAFIP = Convert.ToString(dr[i]["ComentarioIFoAFIP"]);
                }
                Hasta.Comprobantes.Add(c);
            }
            //WF
            dr = ds.Tables[2].Select("IdLote = " + Convert.ToInt32(Hasta.IdLote));
            Hasta.WF.Log = new List<CedEntidades.Log>();
            for (int i = 0; i < dr.Length; i++)
            {
                CedEntidades.Log l = new CedEntidades.Log();
                l.Circuito.IdCircuito = Convert.ToString(dr[i]["IdCircuito"]);
                l.Comentario = Convert.ToString(dr[i]["Comentario"]);
                l.Estado = Convert.ToString(dr[i]["Estado"]);
                l.Evento.Id = Convert.ToString(dr[i]["IdEvento"]);
                l.Evento.Descr = Convert.ToString(dr[i]["Evento"]);
                l.Fecha = Convert.ToDateTime(dr[i]["Fecha"]);
                l.Flow.IdFlow = Convert.ToString(dr[i]["IdFlow"]);
                l.Grupo.Id = Convert.ToString(dr[i]["IdGrupo"]);
                l.Grupo.Descr = Convert.ToString(dr[i]["DescrGrupo"]);
                l.IdLog = Convert.ToInt32(dr[i]["IdLog"]);
                l.IdNivSeg = Convert.ToInt32(dr[i]["IdNivSeg"]);
                l.Responsable = Convert.ToString(dr[i]["Responsable"]);
                l.Supervisor = Convert.ToBoolean(dr[i]["Supervisor"]);
                l.SupervisorNivel = Convert.ToByte(dr[i]["SupervisorNivel"]);
                l.Usuario.IdUsuario = Convert.ToString(dr[i]["IdUsuario"]);
                l.Usuario.Nombre = Convert.ToString(dr[i]["Nombre"]);
                Hasta.WF.Log.Add(l);
            }
            dr = ds.Tables[3].Select("IdLote = " + Convert.ToInt32(Hasta.IdLote));
            Hasta.WF.EventosPosibles = new List<CedEntidades.Evento>();
            for (int i = 0; i < dr.Length; i++)
            {
                CedEntidades.Evento evento = new CedEntidades.Evento();
                evento.Flow.IdFlow = Convert.ToString(dr[i]["IdFlow"]);
                evento.Id = Convert.ToString(dr[i]["IdEvento"]);
                evento.Descr = Convert.ToString(dr[i]["DescrEvento"]);
                evento.TextoAccion = Convert.ToString(dr[i]["TextoAccion"]);
                evento.IdEstadoDsd.IdEstado = Convert.ToString(dr[i]["IdEstadoDsd"]);
                evento.IdEstadoHst.IdEstado = Convert.ToString(dr[i]["IdEstadoHst"]);
                evento.Automatico = Convert.ToBoolean(dr[i]["Automatico"]);
                evento.CXO = Convert.ToBoolean(dr[i]["CXO"]);
                evento.XLote = Convert.ToBoolean(dr[i]["XLote"]);
                evento.Flow.DescrFlow = Convert.ToString(dr[i]["DescrFlow"]);
                evento.IdEstadoDsd.DescrEstado = Convert.ToString(dr[i]["DescrEstadoDsd"]);
                evento.IdEstadoHst.DescrEstado = Convert.ToString(dr[i]["DescrEstadoHst"]);
                Hasta.WF.EventosPosibles.Add(evento);
            }
            dr = ds.Tables[4].Select("IdLote = " + Convert.ToInt32(Hasta.IdLote));
            Hasta.WF.EventosXLotePosibles = new List<CedEntidades.Evento>();
            for (int i = 0; i < dr.Length; i++)
            {
                CedEntidades.Evento evento = new CedEntidades.Evento();
                evento.Flow.IdFlow = Convert.ToString(dr[i]["IdFlow"]);
                evento.Id = Convert.ToString(dr[i]["IdEvento"]);
                evento.Descr = Convert.ToString(dr[i]["DescrEvento"]);
                evento.TextoAccion = Convert.ToString(dr[i]["TextoAccion"]);
                evento.IdEstadoDsd.IdEstado = Convert.ToString(dr[i]["IdEstadoDsd"]);
                evento.IdEstadoHst.IdEstado = Convert.ToString(dr[i]["IdEstadoHst"]);
                evento.Automatico = Convert.ToBoolean(dr[i]["Automatico"]);
                evento.CXO = Convert.ToBoolean(dr[i]["CXO"]);
                evento.XLote = Convert.ToBoolean(dr[i]["XLote"]);
                evento.Flow.DescrFlow = Convert.ToString(dr[i]["DescrFlow"]);
                evento.IdEstadoDsd.DescrEstado = Convert.ToString(dr[i]["DescrEstadoDsd"]);
                evento.IdEstadoHst.DescrEstado = Convert.ToString(dr[i]["DescrEstadoHst"]);
                Hasta.WF.EventosXLotePosibles.Add(evento);
            }
        }

        public void Consultar(out List<eFact_Entidades.Lote> Lotes, eFact_Entidades.Lote.TipoConsulta TipoConsulta, DateTime FechaDsd, DateTime FechaHst, string CuitVendedor, string NumeroLote, string PuntoVenta, bool VerPendientes)
        {
            StringBuilder commandText = new StringBuilder();
            //Query PF
            commandText.Append("select ");
            commandText.Append("Lotes.*, WF_Op.IdFlow ,WF_Op.IdCircuito, WF_Op.IdNivSeg, WF_Op.IdEstado, WF_Op.DescrOp, WF_Op.UltActualiz, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito , WF_NivSeg.DescrNivSeg, WF_Estado.DescrEstado ");
            commandText.Append("INTO #Lotes ");
            commandText.Append("from Lotes ");
            commandText.Append("inner join WF_Op on Lotes.IdOp = WF_Op.IdOp ");
            commandText.Append("inner join WF_Flow on WF_Op.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("inner join WF_Circuito on WF_Op.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("inner join WF_NivSeg on WF_Op.IdNivSeg=WF_NivSeg.IdNivSeg ");
            commandText.Append("inner join WF_Estado on WF_Op.IdEstado=WF_Estado.IdEstado ");
            if (TipoConsulta == eFact_Entidades.Lote.TipoConsulta.FechaAlta)
            {
                commandText.Append("where (Lotes.FechaAlta >= '" + FechaDsd.ToString("yyyyMMdd") + "' and Lotes.FechaAlta < Dateadd ( Day, 1, '" + FechaHst.ToString("yyyyMMdd") + "') ");
            }
            else if (TipoConsulta == eFact_Entidades.Lote.TipoConsulta.FechaEnvio)
            {
                commandText.Append("where (Lotes.FechaEnvio >= '" + FechaDsd.ToString("yyyyMMdd") + "' and Lotes.FechaEnvio <= Dateadd ( Day, 1, '" + FechaHst.ToString("yyyyMMdd") + "') ");
            }
            else
            {
                commandText.Append("where (1=1 ");
            }
            //Otros Filtros
            string queryOtrosFiltros = ""; 
            if (CuitVendedor != "")
            {
                queryOtrosFiltros += "and Lotes.CuitVendedor = '" + CuitVendedor + "' ";
                commandText.Append(queryOtrosFiltros);
            }
            if (NumeroLote != "")
            {
                queryOtrosFiltros += "and Lotes.NumeroLote = '" + NumeroLote + "' ";
                commandText.Append(queryOtrosFiltros);
            }
            if (PuntoVenta != "")
            {
                queryOtrosFiltros += "and Lotes.PuntoVenta = '" + PuntoVenta + "' ";
                commandText.Append(queryOtrosFiltros);
            }
            commandText.Append(") ");
            if (VerPendientes)
            {
                commandText.Append(" or (WF_Op.IdEstado in ('PteEnvio', 'PteRespIF', 'PteRespAFIP') " + queryOtrosFiltros + ") ");
            }
            commandText.Append("select * from #Lotes order by IdLote Desc ");
            commandText.Append("IF @@ROWCOUNT > 0 ");
            commandText.Append("BEGIN ");
            //Select Comprobantes
            commandText.Append("select Comprobantes.* from #Lotes ");
            commandText.Append("inner join Comprobantes on Comprobantes.IdLote = #Lotes.IdLote ");
            //Select WF_LOG
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Log.Fecha, WF_Evento.DescrEvento as Evento, WF_Estado.DescrEstado as Estado, WCUsuarios.Nombre+' ('+WF_Log.IdUsuario+')' as Responsable, WCUsuarios.Nombre as Nombre, ");
            commandText.Append("WF_Log.Comentario, WF_Log.IdLog, WF_Log.IdFlow, WF_Log.IdCircuito, WF_Log.IdNivSeg, WF_Log.IdGrupo, WF_Log.Supervisor, WF_Log.IdUsuario, ");
            commandText.Append("WF_Log.SupervisorNivel, WF_Log.IdEvento, WF_Log.IdEstado, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WCTbGrupos.Descr as DescrGrupo ");
            commandText.Append("from #Lotes, WF_Log, WCUsuarios, WF_Evento, WF_Estado, WF_Flow, WF_Circuito, WCTbGrupos ");
            commandText.Append("where WF_Log.IdOp = #Lotes.IdOp ");
            commandText.Append("and WF_Log.IdUsuario=WCUsuarios.IdUsuario ");
            commandText.Append("and WF_Log.IdFlow=WF_Evento.IdFlow ");
            commandText.Append("and WF_Log.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("and WF_Log.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("and WF_Log.IdGrupo=WCTbGrupos.IdGrupo ");
            commandText.Append("and WF_Log.IdEvento=WF_Evento.IdEvento ");
            commandText.Append("and WF_Log.IdEstado=WF_Estado.IdEstado ");
            //Select Eventos Posibles del WF    
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            //Select Eventos Posibles por lote
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow and WF_Evento.XLote=1 ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            commandText.Append("END ");
            commandText.Append("DROP TABLE #Lotes ");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Usa, sesion.CnnStr);
            List<eFact_Entidades.Lote> lotes = new List<eFact_Entidades.Lote>();
            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    eFact_Entidades.Lote Lote = new eFact_Entidades.Lote();
                    Copiar(ds, i, Lote);
                    Lote.WF.EsquemaSegEventosPosibles = WF_EsquemaSegEventosPosibles_qry(Lote.WF);
                    lotes.Add(Lote);
                }
            }
            Lotes = lotes;
        }

        public DataTable Insertar(eFact_Entidades.Lote Lote, string HandlerEvento, string HandlerArchivo)
        {
            StringBuilder commandText = new StringBuilder();
            string loteXml = "";
            string loteXmlIF = "";
            if (Lote.LoteXml != null && Lote.LoteXml != "")
            {
                loteXml = Lote.LoteXml.Replace("'", "''");
            }
            if (Lote.LoteXmlIF != null && Lote.LoteXmlIF != "")
            {
                loteXmlIF = Lote.LoteXmlIF.Replace("'", "''");
            }
            commandText.Append(HandlerEvento);
            commandText.Append(" insert Lotes values ('");
            commandText.Append(Lote.CuitVendedor + "', '");
            commandText.Append(Lote.NumeroLote + "', '");
            commandText.Append(Lote.PuntoVenta + "', ");
            commandText.Append(Lote.NumeroEnvio + ", ");
            commandText.Append("@IdOp, ");
            commandText.Append("GetDate(), ");
            commandText.Append("null, ");
            commandText.Append(Lote.CantidadRegistros + ", '");
            commandText.Append(Lote.NombreArch + "', '");
            commandText.Append(loteXml + "', '");
            commandText.Append(loteXmlIF + "') ");
            commandText.Append("declare @IdLote int select @IdLote=@@Identity");
            string nombreComprador = "";
            for (int i = 0; i < Lote.Comprobantes.Count; i++)
            {
                nombreComprador = "";
                if (Lote.Comprobantes[i].NombreComprador != null && Lote.Comprobantes[i].NombreComprador != "")
                {
                    nombreComprador = Lote.Comprobantes[i].NombreComprador.Replace("'", "''");
                }
                commandText.Append(" insert Comprobantes values (@IdLote, '");
                commandText.Append(Lote.Comprobantes[i].IdTipoComprobante + "', '");
                commandText.Append(Lote.Comprobantes[i].NumeroComprobante + "', '");
                commandText.Append(Lote.Comprobantes[i].TipoDocComprador + "', '");
                commandText.Append(Lote.Comprobantes[i].NroDocComprador + "', '");
                commandText.Append(nombreComprador + "', '");
                commandText.Append(Lote.Comprobantes[i].Fecha.ToString("yyyyMMdd") + "', '");
                commandText.Append(Lote.Comprobantes[i].IdMoneda + "', ");
                commandText.Append(Lote.Comprobantes[i].Importe + ", ");
                if (Lote.Comprobantes[i].NumeroCAE == null)
                {
                    commandText.Append("null, ");
                }
                else
                {
                    commandText.Append("'" + Lote.Comprobantes[i].NumeroCAE + "', ");
                }
                if (Lote.Comprobantes[i].FechaCAE == null || Convert.ToInt32(Lote.Comprobantes[i].FechaCAE.ToString("yyyyMMdd")) <= 20010101)
                {
                    commandText.Append("null, ");
                }
                else
                {
                    commandText.Append("'" + Lote.Comprobantes[i].FechaCAE.ToString("yyyyMMdd") + "', ");
                }
                if (Lote.Comprobantes[i].FechaVtoCAE == null || Convert.ToInt32(Lote.Comprobantes[i].FechaVtoCAE.ToString("yyyyMMdd")) <= 20010101)
                {
                    commandText.Append("null, ");
                }
                else
                {
                    commandText.Append("'" + Lote.Comprobantes[i].FechaVtoCAE.ToString("yyyyMMdd") + "', ");
                }
                commandText.Append(Lote.Comprobantes[i].ImporteMonedaOrigen + ", ");
                commandText.Append(Lote.Comprobantes[i].TipoCambio + ", ");
                if (Lote.Comprobantes[i].EstadoIFoAFIP == null)
                {
                    commandText.Append("null, ");
                }
                else
                {
                    commandText.Append("'" + Lote.Comprobantes[i].EstadoIFoAFIP + "', ");
                }
                if (Lote.Comprobantes[i].ComentarioIFoAFIP == null)
                {
                    commandText.Append("null) ");
                }
                else
                {
                    commandText.Append("'" + Lote.Comprobantes[i].ComentarioIFoAFIP + "') ");
                }
            }
            commandText.Append(HandlerArchivo);
            commandText.Append(" Select @IdLote ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            return dt;
        }

        public void ActualizarDatosCAE(eFact_Entidades.Lote Lote, string HandlerEvento)
        {
            StringBuilder commandText = new StringBuilder();
            string loteXmlIF = "";
            if (Lote.LoteXmlIF != null && Lote.LoteXmlIF != "")
            {
                loteXmlIF = Lote.LoteXmlIF.Replace("'", "''");
            }
            commandText.Append(HandlerEvento);
            commandText.Append(" Update Lotes set LoteXMLIF = '");
            commandText.Append(loteXmlIF + "'");
            commandText.Append(" where IdLote = " + Lote.IdLote);
            commandText.Append(" declare @IdLote int select @IdLote=@@Identity");
            for (int i = 0; i < Lote.Comprobantes.Count; i++)
            {
                commandText.Append(" Update Comprobantes set NumeroCAE = '");
                commandText.Append(Lote.Comprobantes[i].NumeroCAE + "', FechaCAE = '");
                commandText.Append(Lote.Comprobantes[i].FechaCAE.ToString("yyyyMMdd") + "', FechaVtoCAE = '");
                commandText.Append(Lote.Comprobantes[i].FechaVtoCAE.ToString("yyyyMMdd") + "' ");
                if (Lote.Comprobantes[i].EstadoIFoAFIP != null)
                {
                    commandText.Append(", EstadoIFoAFIP = '" + Lote.Comprobantes[i].EstadoIFoAFIP + "' ");
                }
                else
                {
                    commandText.Append(", EstadoIFoAFIP = NULL ");
                }
                if (Lote.Comprobantes[i].ComentarioIFoAFIP != null)
                {
                    commandText.Append(", ComentarioIFoAFIP = '" + Lote.Comprobantes[i].ComentarioIFoAFIP + "' ");
                }
                else
                {
                    commandText.Append(", ComentarioIFoAFIP = NULL ");
                }
                commandText.Append("where IdLote = " + Lote.IdLote + " and IdTipoComprobante = '" + Lote.Comprobantes[i].IdTipoComprobante + "' ");
                commandText.Append("and NumeroComprobante = '" + Lote.Comprobantes[i].NumeroComprobante + "' "); 
            }
            if (HandlerEvento != "")
            {
                commandText.Append(" end");
            }
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
        }
        public void ActualizarDatosError(eFact_Entidades.Lote Lote, string HandlerEvento)
        {
            StringBuilder commandText = new StringBuilder();
            string loteXmlIF = "";
            if (Lote.LoteXmlIF != null && Lote.LoteXmlIF != "")
            {
                loteXmlIF = Lote.LoteXmlIF.Replace("'", "''");
            }
            commandText.Append(HandlerEvento);
            commandText.Append(" Update Lotes set LoteXMLIF = '");
            commandText.Append(loteXmlIF + "'");
            commandText.Append(" where IdLote = " + Lote.IdLote);
            commandText.Append(" declare @IdLote int select @IdLote=@@Identity");
            for (int i = 0; i < Lote.Comprobantes.Count; i++)
            {
                string estado = "";
                if (Lote.Comprobantes[i].EstadoIFoAFIP != null)
                {
                    estado = Lote.Comprobantes[i].EstadoIFoAFIP;
                }
                string comentario = "";
                if (Lote.Comprobantes[i].ComentarioIFoAFIP != null)
                {
                    comentario = Lote.Comprobantes[i].ComentarioIFoAFIP;
                }
                commandText.Append(" Update Comprobantes set EstadoIFoAFIP = '" + estado + "', ");
                commandText.Append("ComentarioIFoAFIP = '" + comentario + "' ");
                commandText.Append("where IdLote = " + Lote.IdLote + " and IdTipoComprobante = '" + Lote.Comprobantes[i].IdTipoComprobante + "' ");
                commandText.Append("and NumeroComprobante = '" + Lote.Comprobantes[i].NumeroComprobante + "' ");
            }
            if (HandlerEvento != "")
            {
                commandText.Append(" end");
            }
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
        }

        public void ActualizarFechaEnvio(eFact_Entidades.Lote Lote, string HandlerEvento)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append(HandlerEvento);
            commandText.Append(" Update Lotes set FechaEnvio = GetDate()");
            commandText.Append(" where IdLote = " + Lote.IdLote);
            commandText.Append(" declare @IdLote int select @IdLote=@@Identity");
            commandText.Append(" end");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
        }

        public void ConsultarXEstado(out List<eFact_Entidades.Lote> Lotes, string ListaEstados)
        {
            StringBuilder commandText = new StringBuilder();
            //Query PF
            commandText.Append("select ");
            commandText.Append("Lotes.*, WF_Op.IdFlow ,WF_Op.IdCircuito, WF_Op.IdNivSeg, WF_Op.IdEstado, WF_Op.DescrOp, WF_Op.UltActualiz, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito , WF_NivSeg.DescrNivSeg, WF_Estado.DescrEstado ");
            commandText.Append("INTO #Lotes ");
            commandText.Append("from Lotes ");
            commandText.Append("inner join WF_Op on Lotes.IdOp = WF_Op.IdOp ");
            commandText.Append("inner join WF_Flow on WF_Op.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("inner join WF_Circuito on WF_Op.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("inner join WF_NivSeg on WF_Op.IdNivSeg=WF_NivSeg.IdNivSeg ");
            commandText.Append("inner join WF_Estado on WF_Op.IdEstado=WF_Estado.IdEstado ");
            commandText.Append("where WF_Op.IdEstado in (" + ListaEstados + ") ");
            commandText.Append("select * from #Lotes order by IdLote Desc ");
            commandText.Append("IF @@ROWCOUNT > 0 ");
            commandText.Append("BEGIN ");
            //Select Comprobantes
            commandText.Append("select Comprobantes.* from #Lotes ");
            commandText.Append("inner join Comprobantes on Comprobantes.IdLote = #Lotes.IdLote ");
            //Select WF_LOG
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Log.Fecha, WF_Evento.DescrEvento as Evento, WF_Estado.DescrEstado as Estado, WCUsuarios.Nombre+' ('+WF_Log.IdUsuario+')' as Responsable, WCUsuarios.Nombre as Nombre, ");
            commandText.Append("WF_Log.Comentario, WF_Log.IdLog, WF_Log.IdFlow, WF_Log.IdCircuito, WF_Log.IdNivSeg, WF_Log.IdGrupo, WF_Log.Supervisor, WF_Log.IdUsuario, ");
            commandText.Append("WF_Log.SupervisorNivel, WF_Log.IdEvento, WF_Log.IdEstado, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WCTbGrupos.Descr as DescrGrupo ");
            commandText.Append("from #Lotes, WF_Log, WCUsuarios, WF_Evento, WF_Estado, WF_Flow, WF_Circuito, WCTbGrupos ");
            commandText.Append("where WF_Log.IdOp = #Lotes.IdOp ");
            commandText.Append("and WF_Log.IdUsuario=WCUsuarios.IdUsuario ");
            commandText.Append("and WF_Log.IdFlow=WF_Evento.IdFlow ");
            commandText.Append("and WF_Log.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("and WF_Log.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("and WF_Log.IdGrupo=WCTbGrupos.IdGrupo ");
            commandText.Append("and WF_Log.IdEvento=WF_Evento.IdEvento ");
            commandText.Append("and WF_Log.IdEstado=WF_Estado.IdEstado ");
            //Select Eventos Posibles del WF    
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            //Select Eventos Posibles por lote
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow and WF_Evento.XLote=1 ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            commandText.Append("END ");
            commandText.Append("DROP TABLE #Lotes ");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Usa, sesion.CnnStr);
            List<eFact_Entidades.Lote> lotes = new List<eFact_Entidades.Lote>();
            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    eFact_Entidades.Lote Lote = new eFact_Entidades.Lote();
                    Copiar(ds, i, Lote);
                    Lote.WF.EsquemaSegEventosPosibles = WF_EsquemaSegEventosPosibles_qry(Lote.WF);
                    lotes.Add(Lote);
                }
            }
            Lotes = lotes;
        }

        public void ConsultarNovedades(out List<eFact_Entidades.Lote> Lotes)
        {
            StringBuilder commandText = new StringBuilder();
            //Query PF
            commandText.Append("select Lotes.*, WF_Op.IdFlow ,WF_Op.IdCircuito, WF_Op.IdNivSeg, WF_Op.IdEstado, WF_Op.DescrOp, WF_Op.UltActualiz, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito , WF_NivSeg.DescrNivSeg, WF_Estado.DescrEstado ");
            commandText.Append("INTO #Lotes ");
            commandText.Append("from Lotes ");
            commandText.Append("inner join WF_Op on Lotes.IdOp = WF_Op.IdOp ");
            commandText.Append("inner join WF_Flow on WF_Op.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("inner join WF_Circuito on WF_Op.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("inner join WF_NivSeg on WF_Op.IdNivSeg=WF_NivSeg.IdNivSeg ");
            commandText.Append("inner join WF_Estado on WF_Op.IdEstado=WF_Estado.IdEstado ");
            commandText.Append("inner join WF_Log l on WF_Op.IdOp=l.IdOp ");
            commandText.Append("where l.IdLog in (select max(IdLog) from WF_Log where IdOp = l.IdOp group by IdOp) ");
            commandText.Append("and l.IdLog not in (select IdLog from Novedades where WF_Op.IdOp=Novedades.IdOp) ");
            commandText.Append("and WF_OP.IdEstado in ('AceptadoAFIP', 'AceptadoAFIPO', 'AceptadoAFIPP', 'RechazadoIF', 'RechazadoAFIP') ");
            commandText.Append("select * from #Lotes order by IdLote Desc ");
            commandText.Append("IF @@ROWCOUNT > 0 ");
            commandText.Append("BEGIN ");
            //Select Comprobantes
            commandText.Append("select Comprobantes.* from #Lotes ");
            commandText.Append("inner join Comprobantes on Comprobantes.IdLote = #Lotes.IdLote ");
            //Select WF_LOG
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Log.Fecha, WF_Evento.DescrEvento as Evento, WF_Estado.DescrEstado as Estado, WCUsuarios.Nombre+' ('+WF_Log.IdUsuario+')' as Responsable, WCUsuarios.Nombre as Nombre, ");
            commandText.Append("WF_Log.Comentario, WF_Log.IdLog, WF_Log.IdFlow, WF_Log.IdCircuito, WF_Log.IdNivSeg, WF_Log.IdGrupo, WF_Log.Supervisor, WF_Log.IdUsuario, ");
            commandText.Append("WF_Log.SupervisorNivel, WF_Log.IdEvento, WF_Log.IdEstado, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WCTbGrupos.Descr as DescrGrupo ");
            commandText.Append("from #Lotes, WF_Log, WCUsuarios, WF_Evento, WF_Estado, WF_Flow, WF_Circuito, WCTbGrupos ");
            commandText.Append("where WF_Log.IdOp = #Lotes.IdOp ");
            commandText.Append("and WF_Log.IdUsuario=WCUsuarios.IdUsuario ");
            commandText.Append("and WF_Log.IdFlow=WF_Evento.IdFlow ");
            commandText.Append("and WF_Log.IdFlow=WF_Flow.IdFlow ");
            commandText.Append("and WF_Log.IdCircuito=WF_Circuito.IdCircuito ");
            commandText.Append("and WF_Log.IdGrupo=WCTbGrupos.IdGrupo ");
            commandText.Append("and WF_Log.IdEvento=WF_Evento.IdEvento ");
            commandText.Append("and WF_Log.IdEstado=WF_Estado.IdEstado ");
            commandText.Append("order by WF_Log.IdLog ");
            //Select Eventos Posibles del WF    
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            //Select Eventos Posibles por lote
            commandText.Append("Select #Lotes.IdLote, ");
            commandText.Append("WF_Evento.IdFlow, IdEvento, DescrEvento, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst ");
            commandText.Append("from #Lotes ");
            commandText.Append("inner join WF_Evento on WF_Evento.IdFlow = #Lotes.IdFlow and WF_Evento.XLote=1 ");
            commandText.Append("inner join WF_Flow on WF_Flow.IdFlow = #Lotes.IdFlow ");
            commandText.Append("inner join WF_Estado EstadoDsd on EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd ");
            commandText.Append("inner join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            commandText.Append("where WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito = #Lotes.IdCircuito and IdFlow = #Lotes.IdFlow ) ");
            commandText.Append("and WF_Evento.IdEstadoDsd = #Lotes.IdEstado or WF_Evento.IdEstadoDsd = '<EstadoNoFinal>' ");
            commandText.Append("END ");
            commandText.Append("DROP TABLE #Lotes ");
            DataSet ds = new DataSet();
            ds = (DataSet)Ejecutar(commandText.ToString(), TipoRetorno.DS, Transaccion.Usa, sesion.CnnStr);
            List<eFact_Entidades.Lote> lotes = new List<eFact_Entidades.Lote>();
            if (ds.Tables.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.NoHayDatos();
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    eFact_Entidades.Lote Lote = new eFact_Entidades.Lote();
                    Copiar(ds, i, Lote);
                    Lote.WF.EsquemaSegEventosPosibles = WF_EsquemaSegEventosPosibles_qry(Lote.WF);
                    lotes.Add(Lote);
                }
            }
            Lotes = lotes;
        }

        public void GuardarNovedades(eFact_Entidades.Novedades novedad)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("insert Novedades values ('");
            commandText.Append(novedad.CuitVendedor + "', " + novedad.IdLote + ", " + novedad.NumeroEnvio + ", " + novedad.PuntoVenta + ", " + novedad.IdLog + ", " + novedad.IdOp + ", '" + novedad.NumeroLote + "', '" + novedad.IdEstado + "', '" + novedad.Comentario.Replace("'", " ") + "', '" + novedad.FechaAlta.ToString("yyyyMMdd HH:mm:ss") + "', " + novedad.CantidadRegistros + ")");
            Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
        }
    }
}
