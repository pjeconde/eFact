using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Tester.Entidades
{
    public class Proxy
    {
        private string servidor;
        private string usuario;
        private string clave;
        private string dominio;
        /// <comentarios.../>
        public string Servidor
        {
            get
            {
                return servidor;
            }
            set
            {
                servidor = value;
            }
        }
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }
        public string Clave
        {
            get
            {
                return clave;
            }
            set
            {
                clave = value;
            }
        }
        public string Dominio
        {
            get
            {
                return dominio;
            }
            set
            {
                dominio = value;
            }
        }
    }
}
