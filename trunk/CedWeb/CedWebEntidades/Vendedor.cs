using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Vendedor : Persona
    {
        private long cUIT;

        public Vendedor()
        {
        }

        public long CUIT
        {
            set
            {
                cUIT = value;
            }
            get
            {
                return cUIT;
            }
        }
    }
}