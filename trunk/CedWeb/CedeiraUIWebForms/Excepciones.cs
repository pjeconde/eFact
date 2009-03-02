using System;
using System.Collections.Generic;
using System.Text;

namespace CedeiraUIWebForms
{
	public static class Excepciones
	{
        public static void Redireccionar(Exception ex, string url)
        {
            UrlParameterPasser urlWrapper = new UrlParameterPasser(url);
            urlWrapper["ex"] = Detalle(ex);
            urlWrapper.PassParameters();
        }
        public static void Redireccionar(string idParm, string valor, string url)
        {
            UrlParameterPasser urlWrapper = new UrlParameterPasser(url);
            urlWrapper[idParm] = valor;
            urlWrapper.PassParameters();
        }
        public static string Detalle(Exception ex)
        {
            System.Text.StringBuilder a = new System.Text.StringBuilder();
            a.Append(ex.Message);
            if (ex.InnerException != null)
            {
                a.Append(" (");
                a.Append(ex.InnerException.Message);
                a.Append(")");
            }
            return a.ToString();
        }
	}
}
