using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CedBPrn
{
    public static class Grafico
    {

        public static void Generar(int Alto, int Ancho, float Grosor, float AnguloGiro, decimal[] Valores, string[] Textos, string Path, System.Drawing.Color ForeColor)
        {
            System.Drawing.PieChart.PieChartControl GraficoDeTorta;
            GraficoDeTorta = new System.Drawing.PieChart.PieChartControl();
            GraficoDeTorta.BackColor = System.Drawing.Color.Cornsilk;
            GraficoDeTorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            GraficoDeTorta.ForeColor = ForeColor;
            GraficoDeTorta.Location = new System.Drawing.Point(32, 56);
            GraficoDeTorta.Name = "GraficoDeTorta";
            GraficoDeTorta.Size = new System.Drawing.Size(Ancho, Alto);
            GraficoDeTorta.TabIndex = 9025;
            GraficoDeTorta.ToolTips = null;
            float[] desplazamiento = new float[Valores.Length];
            Color[] colores = new Color[6];
            for(int i = 0; i< Valores.Length; i++)
            {
                desplazamiento[i] = 0.00F;
            }
            //Colores oscuros
            //colores[0] = Color.FromArgb(122, Color.DarkGoldenrod);
            //colores[1] = Color.FromArgb(122, Color.OrangeRed);
            //colores[2] = Color.FromArgb(122, Color.Firebrick);
            //colores[3] = Color.FromArgb(122, Color.Purple);
            //colores[4] = Color.FromArgb(122, Color.DarkGreen);
            //colores[5] = Color.FromArgb(122, Color.Navy);
            //Colores claros
            colores[0] = Color.FromArgb(122, Color.LightBlue);
            colores[1] = Color.FromArgb(122, Color.PaleGreen);
            colores[2] = Color.FromArgb(122, Color.Khaki);
            colores[3] = Color.FromArgb(122, Color.Thistle);
            colores[4] = Color.FromArgb(122, Color.DarkSalmon);
            colores[5] = Color.FromArgb(122, Color.White);
            GraficoDeTorta.Values = Valores;
            GraficoDeTorta.Texts = Textos;
            GraficoDeTorta.SliceRelativeDisplacements = desplazamiento;
            GraficoDeTorta.Colors = colores;
            // Inicializo grafico
            GraficoDeTorta.InitialAngle = AnguloGiro;
            GraficoDeTorta.EdgeColorType = System.Drawing.PieChart.EdgeColorType.SurfaceColor;
            GraficoDeTorta.ShadowStyle = System.Drawing.PieChart.ShadowStyle.GradualShadow;
            GraficoDeTorta.LeftMargin = 10;
            GraficoDeTorta.RightMargin = 10;
            GraficoDeTorta.TopMargin = 10;
            GraficoDeTorta.BottomMargin = 10;
            GraficoDeTorta.EdgeLineWidth = 1;
            GraficoDeTorta.SliceRelativeHeight = Grosor;
            Size s = new Size(Ancho, Alto);
            Bitmap memoryImage = new Bitmap(Ancho, Alto);
            Rectangle j = new Rectangle(0, 0, Ancho, Alto);
            GraficoDeTorta.DrawToBitmap(memoryImage, j);
            string ruta = string.Empty;
            ruta = System.Web.HttpContext.Current.Server.MapPath(Path);
            memoryImage.Save(ruta);
        }
    }
}
