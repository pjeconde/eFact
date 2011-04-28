using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_Tester.Entidades
{
    public class Certificado
    {
        private string numero;
        private eFact_Tester.Entidades.Certificado.Almacenamiento lugarDeAlmacenamiento;
        /// <comentarios.../>
        public string Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }
        public Almacenamiento LugarDeAlmacenamiento
        {
            get
            {
                return lugarDeAlmacenamiento;
            }
            set
            {
                lugarDeAlmacenamiento = value;
            }
        }
        public enum Almacenamiento
        {
            /// <comentarios/>
            CurrentUser,
            /// <comentarios/>
            LocalMachine,
        }
    }

}
