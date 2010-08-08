using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace eFact_R.RN
{
    class Registro
    {
        public static void Leer(RegistryKey raiz, String nombreClave, String nombreValor, out Object valor)
        {
            RegistryKey clave;
            clave = raiz.OpenSubKey(nombreClave, true);
            if (clave == null) throw new Exception("La clave del Registro no existe");
            valor = clave.GetValue(nombreValor);
        }
        public static void Guardar(RegistryKey raiz, String nombreClave, String nombreValor, Object valor)
        {
            RegistryKey clave;
            clave = raiz.OpenSubKey(nombreClave, true);
            if (clave == null) clave = raiz.CreateSubKey(nombreClave);
            clave.SetValue(nombreValor, valor);
        }
        public static bool Existe(RegistryKey raiz, String nombreClave)
        {
            RegistryKey clave;
            clave = raiz.OpenSubKey(nombreClave, true);
            if (clave == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ExisteValor(RegistryKey raiz, String nombreClave, String nombreValor)
        {
            RegistryKey clave;
            clave = raiz.OpenSubKey(nombreClave, true);
            object valor = clave.GetValue(nombreValor);
            if (valor == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}