using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Flag
    {
        private bool modoDepuracion;

        public Flag()
        {
        }
        public bool ModoDepuracion
        {
            set
            {
                modoDepuracion = value;
            }
            get
            {
                return modoDepuracion;
            }
        }
    }
}