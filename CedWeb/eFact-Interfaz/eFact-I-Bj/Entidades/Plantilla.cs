using System;
using System.Collections.Generic;
using System.Text;

namespace eFact_I_Bj.Entidades
{
    [Serializable]
    public class Plantilla
    {
        private int idPlantilla;
        private string descrPlantilla;
        private string leyenda1;
        private string leyenda2;
        private string leyenda3;
        private string leyenda4;
        private string leyenda5;
        private string leyendaMoneda;
        private string leyendaBanco;
        public Plantilla()
        {
        }
        public int IdPlantilla
        {
            set
            {
                idPlantilla = value;
            }
            get
            {
                return idPlantilla;
            }
        }
        public string DescrPlantilla
        {
            set
            {
                descrPlantilla = value;
            }
            get
            {
                return descrPlantilla;
            }
        }
        public string Leyenda1
        {
            set
            {
                leyenda1 = value;
            }
            get
            {
                return leyenda1;
            }
        }
        public string Leyenda2
        {
            set
            {
                leyenda2 = value;
            }
            get
            {
                return leyenda2;
            }
        }
        public string Leyenda3
        {
            set
            {
                leyenda3 = value;
            }
            get
            {
                return leyenda3;
            }
        }
        public string Leyenda4
        {
            set
            {
                leyenda4 = value;
            }
            get
            {
                return leyenda4;
            }
        }
        public string Leyenda5
        {
            set
            {
                leyenda5 = value;
            }
            get
            {
                return leyenda5;
            }
        }
        public string LeyendaMoneda
        {
            set
            {
                leyendaMoneda = value;
            }
            get
            {
                return leyendaMoneda;
            }
        }
        public string LeyendaBanco
        {
            set
            {
                leyendaBanco = value;
            }
            get
            {
                return leyendaBanco;
            }
        }
    }
}

