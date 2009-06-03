using System;
using System.Collections.Generic;
using System.Text;
using eFact_R_Bj;
using System.Management;
using System.Collections;

namespace eFact_R_Bj.RN
{
    class Disco
    {
        public static List<eFact_R_Bj.Entidades.Disco> Lista()
        {
            List<Entidades.Disco> discos = new List<Entidades.Disco>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                Entidades.Disco disco = new Entidades.Disco();
                disco.Modelo = wmi_HD["Model"].ToString();
                disco.Tipo = wmi_HD["InterfaceType"].ToString();
                discos.Add(disco);
            }
            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            int i = 0;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                if (i >= discos.Count) { break; }
                // get the hard drive from collection using index
                Entidades.Disco disco = (Entidades.Disco)discos[i];
                // get the hardware serial no.    //wmi_HD["Name"]

                if (wmi_HD["SerialNumber"] == null)
                {
                    disco.NroSerie = "None";
                }
                else
                {
                    disco.NroSerie = wmi_HD["SerialNumber"].ToString();
                }
                ++i;
            }
            return discos;
        }
        public static string ClaveSolicitud()
        {
            StringBuilder clave = new StringBuilder(String.Empty);
            List<Entidades.Disco> discos = Lista();
            for (int i = 0; i < discos.Count; i++)
            {
                if (discos[i].Tipo != "USB")
                {
                    if (discos[i].NroSerie != "None")
                    {
                        clave.Append(discos[i].NroSerie);
                    }
                    else
                    {
                        clave.Append(discos[i].Modelo);
                    }
                }
            }
            return clave.ToString().Replace(" ", String.Empty).Replace("-", String.Empty);
        }
    }
}