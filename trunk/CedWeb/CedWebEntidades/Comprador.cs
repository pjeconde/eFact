using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Comprador : Persona
    {
        private int idTipoDoc;
        private string descrTipoDoc;
        private long nroDoc;
        private string emailAvisoVisualizacion;
        private string passwordAvisoVisualizacion;

        public Comprador()
        {
        }

        public int IdTipoDoc
        {
            set
            {
                idTipoDoc = value;
            }
            get
            {
                return idTipoDoc;
            }
        }
        public string DescrTipoDoc
        {
            set
            {
                descrTipoDoc = value;
            }
            get
            {
                return descrTipoDoc;
            }
        }
        public long NroDoc
        {
            set
            {
                nroDoc = value;
            }
            get
            {
                return nroDoc;
            }
        }
        public string EmailAvisoVisualizacion
        {
            set
            {
                emailAvisoVisualizacion = value;
            }
            get
            {
                return emailAvisoVisualizacion;
            }
        }
        public string PasswordAvisoVisualizacion
        {
            set
            {
                passwordAvisoVisualizacion = value;
            }
            get
            {
                return passwordAvisoVisualizacion;
            }
        }
    }
}