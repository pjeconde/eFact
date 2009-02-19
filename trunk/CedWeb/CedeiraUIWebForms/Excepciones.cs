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
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(ex.Message);
			if(ex.InnerException != null)
			{
				sb.Append("(");
				sb.Append(ex.InnerException.Message);
				sb.Append(")");
			}
			urlWrapper["ex"] = sb.ToString();
			urlWrapper.PassParameters();
		}
	}
}
