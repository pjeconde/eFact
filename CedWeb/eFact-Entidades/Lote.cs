using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Entidades
{
    [Serializable]
    public class Lote
    {
        public enum TipoConsulta
        {
            /// <comentarios/>
            FechaAlta,
            /// <comentarios/>
            FechaEnvio,
            /// <comentarios/>
            SinAplicarFechas,
        }

        private int idLote;
        private string cuitVendedor;
        private string numeroLote;
        private string puntoVenta;
        private int numeroEnvio;
        private int idOp;
        private DateTime fechaAlta;
        private DateTime fechaEnvio;
        private int cantidadRegistros;
        private string nombreArch;
        private string loteXml;
        private string loteXmlIF;
        private CedEntidades.WF wf;
        private List<eFact_Entidades.Comprobante> comprobantes;
        private List<eFact_Entidades.ComprobanteC> comprobantesC;
        private List<eFact_Entidades.ComprobanteD> comprobantesD;
        //private string idNaturalezaLote;
        public Lote()
        {
            comprobantes = new List<eFact_Entidades.Comprobante>();
            comprobantesC = new List<eFact_Entidades.ComprobanteC>();
            comprobantesD = new List<eFact_Entidades.ComprobanteD>();
        }
        public int IdLote
        {
            set
            {
                idLote = value;
            }
            get
            {
                return idLote;
            }
        }
        public string CuitVendedor
        {
            set
            {
                cuitVendedor = value;
            }
            get
            {
                return cuitVendedor;
            }
        }
        public string NumeroLote
        {
            set
            {
                numeroLote = value;
            }
            get
            {
                return numeroLote;
            }
        }
        public string PuntoVenta
        {
            set
            {
                puntoVenta = value;
            }
            get
            {
                return puntoVenta;
            }
        }
        public int NumeroEnvio
        {
            set
            {
                numeroEnvio = value;
            }
            get
            {
                return numeroEnvio;
            }
        }
        public int IdOp
        {
            set
            {
                idOp = value;
            }
            get
            {
                return idOp;
            }
        }
        public DateTime FechaAlta
        {
            set
            {
                fechaAlta = value;
            }
            get
            {
                return fechaAlta;
            }
        }
        public DateTime FechaEnvio
        {
            set
            {
                fechaEnvio = value;
            }
            get
            {
                return fechaEnvio;
            }
        }
        public int CantidadRegistros
        {
            set
            {
                cantidadRegistros = value;
            }
            get
            {
                return cantidadRegistros;
            }
        }
        public string NombreArch
        {
            set
            {
                nombreArch = value;
            }
            get
            {
                return nombreArch;
            }
        }
        public string LoteXml
        {
            set
            {
                loteXml = value;
            }
            get
            {
                return loteXml;
            }
        }
        public string LoteXmlIF
        {
            set
            {
                loteXmlIF = value;
            }
            get
            {
                return loteXmlIF;
            }
        }
        public List<eFact_Entidades.Comprobante> Comprobantes
        {
            get
            {
                return comprobantes;
            }
            set
            {
                comprobantes = value;
            }
        }
        public List<eFact_Entidades.ComprobanteC> ComprobantesC
        {
            get
            {
                return comprobantesC;
            }
            set
            {
                comprobantesC = value;
            }
        }
        public List<eFact_Entidades.ComprobanteD> ComprobantesD
        {
            get
            {
                return comprobantesD;
            }
            set
            {
                comprobantesD = value;
            }
        }
        public string IdEstado
        {
            get
            {
                return wf.IdEstado.ToString();
            }
        }
        public CedEntidades.WF WF
        {
            get
            {
                return wf;
            }
            set
            {
                wf = value;
            }
        }
        //public string IdNaturalezaLote
        //{
        //    set
        //    {
        //        idNaturalezaLote = value;
        //    }
        //    get
        //    {
        //        return idNaturalezaLote;
        //    }
        //}
    }
}
