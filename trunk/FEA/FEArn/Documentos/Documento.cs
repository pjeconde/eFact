using System;
using System.Collections.Generic;
using System.Text;

namespace FEArn.Documentos
{
	public class Documento
	{
		public static List<FeaEntidades.Documentos.Documento> Lista()
		{
			List<FeaEntidades.Documentos.Documento> lista = new List<FeaEntidades.Documentos.Documento>();
			lista.Add(new FeaEntidades.Documentos.CUIT());
			lista.Add(new FeaEntidades.Documentos.CI.BsAsRNP());
			lista.Add(new FeaEntidades.Documentos.CI.Extranjera());
			lista.Add(new FeaEntidades.Documentos.CI.PoliciaFederal());
			lista.Add(new FeaEntidades.Documentos.CI.BuenosAires());
			lista.Add(new FeaEntidades.Documentos.CI.Mendoza());
			lista.Add(new FeaEntidades.Documentos.CI.LaRioja());
			lista.Add(new FeaEntidades.Documentos.CI.Salta());
			lista.Add(new FeaEntidades.Documentos.CI.SanJuan());
			lista.Add(new FeaEntidades.Documentos.CI.SanLuis());
			lista.Add(new FeaEntidades.Documentos.CI.SantaFe());
			lista.Add(new FeaEntidades.Documentos.CI.SantiagoDelEstero());
			lista.Add(new FeaEntidades.Documentos.CI.Tucuman());
			lista.Add(new FeaEntidades.Documentos.CI.Chaco());
			lista.Add(new FeaEntidades.Documentos.CI.Chubut());
			lista.Add(new FeaEntidades.Documentos.CI.Formosa());
			lista.Add(new FeaEntidades.Documentos.CI.Misiones());
			lista.Add(new FeaEntidades.Documentos.CI.Neuquen());
			lista.Add(new FeaEntidades.Documentos.ActaNacimiento());
			lista.Add(new FeaEntidades.Documentos.CDI());
			lista.Add(new FeaEntidades.Documentos.CUIL());
			lista.Add(new FeaEntidades.Documentos.DNI());
			lista.Add(new FeaEntidades.Documentos.EnTramite());
			lista.Add(new FeaEntidades.Documentos.LC());
			lista.Add(new FeaEntidades.Documentos.LE());
			lista.Add(new FeaEntidades.Documentos.Pasaporte());
			return lista;
		}

	}
}
