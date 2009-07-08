using System;
using System.Collections.Generic;
using System.Text;
namespace CedWebEntidades
{
    [Serializable]
    public class Publicacion
    {
        private string id;
        private string descripcion;
        private string asunto;
        private string uRL;
        private List<string> destinatario;
        private string destinatarios;

        public Publicacion()
        {
            destinatario = new List<string>();
        }

        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Descripcion
        {
            set
            {
                descripcion = value;
            }
            get
            {
                return descripcion;
            }
        }
        public string Asunto
        {
            set
            {
                asunto = value;
            }
            get
            {
                return asunto;
            }
        }
        public string URL
        {
            set
            {
                uRL = value;
            }
            get
            {
                return uRL;
            }
        }
        public List<string> Detinatario
        {
            set
            {
                destinatario = value;
            }
            get
            {
                return destinatario;
            }
        }
        public string Detinatarios
        {
            set
            {
                destinatarios = value;
            }
            get
            {
                return destinatarios;
            }
        }
    }
}