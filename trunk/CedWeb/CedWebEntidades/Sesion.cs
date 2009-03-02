using System;
using System.Collections.Generic;
using System.Text;

namespace CedWebEntidades
{
    [Serializable]
    public class Sesion : CedEntidades.Sesion
    {
        #region Atributos
        private CedWebEntidades.Cuenta cuenta;
        private string mensajeGeneral;
        #endregion

        #region Constructor
        public Sesion()
        {
            cuenta = new CedWebEntidades.Cuenta();
        }
        #endregion

        #region Propiedades
        public CedWebEntidades.Cuenta Cuenta
        {
            get
            {
                return cuenta;
            }
            set
            {
                cuenta = value;
            }
        }
        public string MensajeGeneral
        {
            get
            {
                return mensajeGeneral;
            }
            set
            {
                mensajeGeneral = value;
            }
        }
        #endregion
    }
}