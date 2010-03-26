using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_R.Entidades
{
    [Serializable]
    public class Lote
    {
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
        private List<eFact_R.Entidades.Comprobante> comprobantes;
        public Lote()
        {
            comprobantes = new List<eFact_R.Entidades.Comprobante>();
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
        public List<eFact_R.Entidades.Comprobante> Comprobantes
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
    }
}
