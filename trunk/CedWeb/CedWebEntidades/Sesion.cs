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
        private CedWebEntidades.Flag flag;
        #endregion

        #region Constructor
        public Sesion()
        {
            cuenta = new CedWebEntidades.Cuenta();
            flag = new CedWebEntidades.Flag();
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
        public CedWebEntidades.Flag Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
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