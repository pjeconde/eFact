using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Entidades
{
    [Serializable]
    public class Aplicacion
    {
        private string nombre;
        private string codigo;
        private string propietario;
        private string version;
		private string versionParaControl;
        private string codigoAplic;

        private string archPath;
        private string archPathHis;
        private string archPathItf;
        private string archPathItfAut;
        private string archPathPDF;

        private string visualizarArchivos;
        private string tipoItfAut;

        private string mailServidorSmtp;
        private string mailCredencialesUsr;
        private string mailCredencialesPsw;
        private string mailTest;

        private string otrosFiltrosCuit;

        private CedEntidades.Sesion sesion;
        private List<eFact_Entidades.Vendedor> vendedores;

        private string storeLocation;
        
        public Aplicacion()
        {
            sesion = new CedEntidades.Sesion();
            vendedores = new List<eFact_Entidades.Vendedor>();
        }
        public string Nombre
        {
			set
			{
				nombre = value;
			}
            get
            {
                return nombre;
            }
        }
        public string Codigo
        {
			set
			{
				codigo = value;
			}
            get
            {
                return codigo;
            }
        }
        public string Propietario
        {
			set
			{
				propietario = value;
			}
            get
            {
                return propietario;
            }
        }
        public string Version
        {
			set
			{
				version = value;
			}
            get
            {
                return version;
            }
        }
		public string VersionParaControl
		{
			set
			{
				versionParaControl = value;
			}
			get
			{
				return versionParaControl;
			}
		}
        public string CodigoAplic
        {
            set
            {
                codigoAplic = value;
            }
            get
            {
                return codigoAplic;
            }
        } 
        public string ArchPath
        {
            set
            {
                archPath = value;
            }
            get
            {
                return archPath;
            }
        }
        public string ArchPathHis
        {
            set
            {
                archPathHis = value;
            }
            get
            {
                return archPathHis;
            }
        }
        public string ArchPathItf
        {
            set
            {
                archPathItf = value;
            }
            get
            {
                return archPathItf;
            }
        }
        public string ArchPathItfAut
        {
            set
            {
                archPathItfAut = value;
            }
            get
            {
                return archPathItfAut;
            }
        }
        public string ArchPathPDF
        {
            set
            {
                archPathPDF = value;
            }
            get
            {
                return archPathPDF;
            }
        }
        public string VisualizarArchivos
        {
            set
            {
                visualizarArchivos = value;
            }
            get
            {
                return visualizarArchivos;
            }
        }
        public string TipoItfAut
        {
            set
            {
                tipoItfAut = value;
            }
            get
            {
                return tipoItfAut;
            }
        }

        public string MailServidorSmtp
        {
            set
            {
                mailServidorSmtp = value;
            }
            get
            {
                return mailServidorSmtp;
            }
        }
        public string MailCredencialesUsr
        {
            set
            {
                mailCredencialesUsr = value;
            }
            get
            {
                return mailCredencialesUsr;
            }
        }
        public string MailCredencialesPsw
        {
            set
            {
                mailCredencialesPsw = value;
            }
            get
            {
                return mailCredencialesPsw;
            }
        }
        public string MailTest
        {
            set
            {
                mailTest = value;
            }
            get
            {
                return mailTest;
            }
        }

        public string OtrosFiltrosCuit
        {
            set
            {
                otrosFiltrosCuit = value;
            }
            get
            {
                return otrosFiltrosCuit;
            }
        }

        public CedEntidades.Sesion Sesion
        {
            set
            {
                sesion = value;
            }
            get
            {
                return sesion;
            }
        }

        public List<eFact_Entidades.Vendedor> Vendedores
        {
            set
            {
                vendedores = value;
            }
            get
            {
                return vendedores;
            }
        }

        public string StoreLocation
        {
            set
            {
                storeLocation = value;
            }
            get
            {
                return storeLocation;
            }
        }
    }
}