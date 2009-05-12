using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CedBPrn
{
    public static class Grafico
    {

        public static void Generar(int Alto, int Ancho, decimal[] Valores, string[] Textos)
        {
            System.Drawing.PieChart.PieChartControl GraficoDeTorta;
            float AnguloGiro;
            GraficoDeTorta = new System.Drawing.PieChart.PieChartControl();
            GraficoDeTorta.BackColor = System.Drawing.Color.Cornsilk;
            GraficoDeTorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            GraficoDeTorta.ForeColor = System.Drawing.Color.White;
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
            colores[0] = Color.FromArgb(122, Color.DarkGoldenrod);
            colores[1] = Color.FromArgb(122, Color.OrangeRed);
            colores[2] = Color.FromArgb(122, Color.Firebrick);
            colores[3] = Color.FromArgb(122, Color.Purple);
            colores[4] = Color.FromArgb(122, Color.DarkGreen);
            colores[5] = Color.FromArgb(122, Color.Navy);
            GraficoDeTorta.Values = Valores;
            GraficoDeTorta.Texts = Textos;
            GraficoDeTorta.SliceRelativeDisplacements = desplazamiento;
            GraficoDeTorta.Colors = colores;
            // Inicializo grafico
            AnguloGiro = 0;
            GraficoDeTorta.InitialAngle = AnguloGiro;
            GraficoDeTorta.EdgeColorType = System.Drawing.PieChart.EdgeColorType.SurfaceColor;
            GraficoDeTorta.ShadowStyle = System.Drawing.PieChart.ShadowStyle.GradualShadow;
            GraficoDeTorta.LeftMargin = 10;
            GraficoDeTorta.RightMargin = 10;
            GraficoDeTorta.TopMargin = 10;
            GraficoDeTorta.BottomMargin = 10;
            GraficoDeTorta.EdgeLineWidth = 1;
            GraficoDeTorta.SliceRelativeHeight = 0.25F;
            Size s = new Size(Ancho, Alto);
            Bitmap memoryImage = new Bitmap(Ancho, Alto);
            Rectangle j = new Rectangle(0, 0, Ancho, Alto);
            GraficoDeTorta.DrawToBitmap(memoryImage, j);
            string ruta = string.Empty;
            ruta = System.Web.HttpContext.Current.Server.MapPath("Imagenes\\temp.bmp");
            memoryImage.Save(ruta);
        }
    }
}
