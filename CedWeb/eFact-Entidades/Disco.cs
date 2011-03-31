using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Entidades
{
    public class Disco
    {
        private string modelo = null;
        private string tipo = null;
        private string nroSerie = null;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string NroSerie
        {
            get { return nroSerie; }
            set { nroSerie = value; }
        }
    }
}
