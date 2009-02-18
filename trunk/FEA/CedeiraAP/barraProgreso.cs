using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace Cedeira.SV
{
	/// <summary>
	/// Descripci�n breve de barraProgreso.
	/// </summary>
	public class barraProgreso : Cedeira.UI.frmBarraDeProgreso
	{
		/// <summary>
		/// Variable del dise�ador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string nombreArchivo;
		private bool precios;
		private string cnnStr;
		private string idUsuario;
		private string fecha;
		private string path;
		private string planilla;
		private byte idEtapaCaptura;
/// <summary>
/// Este constructor se usa cuando se exporta a planilla
/// </summary>
		public barraProgreso(string Titulo, string FileName) : base(Titulo)
		{
			precios=false;
			InitializeComponent();
			nombreArchivo=FileName;
		}
/// <summary>
/// Este constructor se usa cuando se lee una planilla
/// </summary>
		public barraProgreso(string Titulo, string Cnnstr, string IdUser, string Fecha, string Path, string Planilla, byte IdEtapa) : base(Titulo)
		{
			precios=true;
			InitializeComponent();
			nombreArchivo=Path;
			cnnStr=Cnnstr;
			idUsuario=IdUser;
			fecha=Fecha;
			path=Path;
			planilla=Planilla;
			idEtapaCaptura=IdEtapa;
		}

		/// <summary>
		/// Limpiar los recursos que se est�n utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region C�digo generado por el Dise�ador de Windows Forms
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// FondoNicePanel
			// 
			this.FondoNicePanel.Name = "FondoNicePanel";
			this.FondoNicePanel.Size = new System.Drawing.Size(280, 60);
			// 
			// barraProgreso
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 60);
			this.Name = "barraProgreso";
			this.Text = "barraProgreso";
			this.ResumeLayout(false);

		}
		#endregion


	}
}
