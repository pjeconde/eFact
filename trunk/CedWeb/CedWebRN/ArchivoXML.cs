using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedWebRN
{
    internal class CustomCompare : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return DateTime.Compare(x.CreationTime, y.CreationTime);
        }
    }
    public class ArchivoXML
    {
        public static void Leer(CedWebEntidades.Sesion Sesion)
        {
            FileInfo[] archivoXML = new DirectoryInfo("CedWeb//Temp").GetFiles(Convert.ToString(Sesion.Cuenta.Vendedor.CUIT) + "-*.xml");
            Array.Sort(archivoXML, new CustomCompare());
            for (int i = 0; i < archivoXML.Length; i++)
            {
                Console.WriteLine(archivoXML[archivoXML.Length - i - 1].Name + " " + archivoXML[archivoXML.Length - i - 1].CreationTime.ToString());
            }
        }
    }
}
