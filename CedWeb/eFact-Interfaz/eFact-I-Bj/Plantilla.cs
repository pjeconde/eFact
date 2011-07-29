using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_I_Bj
{
    public partial class Plantilla : Form
    {
        private eFact_I_Bj.RN.Plantilla.Modo modo;

        public Plantilla(eFact_I_Bj.RN.Plantilla.Modo Modo)
        {
            InitializeComponent();
            modo = Modo;
            this.Text = "Plantilla (" + modo.ToString() + ")";
            EjecutarButton.Text = "Aceptar";
            if (eFact_I_Bj.RN.Plantilla.Modo.Alta == modo)
            {
                DescrPlantillaComboBox.Visible = false;
                EjecutarButton.Enabled = true;
            }
            else
            {
                DescrPlantillaComboBox.Visible = true;
                EjecutarButton.Enabled = false;
            }
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DescrPlantillaTextBox.Text = "";
            Leyenda1TextBox.Text = "";
            Leyenda2TextBox.Text = "";
            Leyenda3TextBox.Text = "";
            Leyenda4TextBox.Text = "";
            Leyenda5TextBox.Text = "";
            LeyendaMonedaTextBox = "";
            LeyendaMonedaTextBox = "";
        }

        private void EjecutarButton_Click(object sender, EventArgs e)
        {
            eFact_I_Bj.DB.Plantilla db = new eFact_I_Bj.DB.Plantilla(Aplicacion.Sesion);
            eFact_I_Bj.Entidades.Plantilla plantilla = new eFact_I_Bj.Entidades.Plantilla();
            plantilla.DescrPlantilla = DescrPlantillaTextBox.Text;
            plantilla.Leyenda1 = Leyenda1TextBox.Text;
            plantilla.Leyenda2 = Leyenda2TextBox.Text;
            plantilla.Leyenda3 = Leyenda3TextBox.Text;
            plantilla.Leyenda4 = Leyenda4TextBox.Text;
            plantilla.Leyenda5 = Leyenda5TextBox.Text;
            plantilla.LeyendaMoneda = LeyendaMonedaTextBox.Text;
            plantilla.LeyendaBanco = LeyendaBancoTextBox.Text;
            if (eFact_I_Bj.RN.Plantilla.Modo.Alta == modo)
            {
                db.Insertar(plantilla);
            }
            else
            {
                db.Modificar(plantilla);
            }
        }

        private void DescrPlantillaComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            eFact_I_Bj.DB.Plantilla db = new eFact_I_Bj.DB.Plantilla(Aplicacion.Sesion);
            eFact_I_Bj.Entidades.Plantilla plantilla = new eFact_I_Bj.Entidades.Plantilla();
            plantilla.IdPlantilla = DescrPlantillaComboBox.SelectedValue;
            db.Leer(plantilla);
            if (plantilla.DescrPlantilla != "")
            {
                EjecutarButton.Enabled = true;
                DescrPlantillaTextBox.Text = "";
                Leyenda1TextBox.Text = plantilla.Leyenda1;
                Leyenda2TextBox.Text = plantilla.Leyenda2;
                Leyenda3TextBox.Text = plantilla.Leyenda3;
                Leyenda4TextBox.Text = plantilla.Leyenda4;
                Leyenda5TextBox.Text = plantilla.Leyenda5;
                LeyendaMonedaTextBox.Text = plantilla.LeyendaMoneda;
                LeyendaBancoTextBox.Text = plantilla.LeyendaBanco;
                EjecutarButton.Enabled = true;
            }
        }
    }
}