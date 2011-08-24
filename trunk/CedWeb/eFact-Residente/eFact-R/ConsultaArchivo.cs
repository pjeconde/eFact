using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFact_R
{
    public partial class ConsultaArchivo : Form
    {
        private List<eFact_Entidades.Archivo> archivos;
        public ConsultaArchivo(List<eFact_Entidades.Archivo> Archivos)
        {
            InitializeComponent();
            archivos = Archivos;
        }
        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ConsultaArchivo_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
                ArchivosDataGridView.AutoGenerateColumns = false;
                ArchivosDataGridView.DataSource = new List<eFact_Entidades.Archivo>();
                ArchivosDataGridView.DataSource = archivos;
                ArchivosDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ArchivosDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (ArchivosDataGridView.SelectedRows.Count != 0)
            {
                int renglon = ArchivosDataGridView.SelectedRows[0].Index;
                string comentario = archivos[renglon].Comentario;
                Comentarios c = new Comentarios(comentario);
                c.ShowDialog();
                c.Dispose();
            }
        }
    }
}