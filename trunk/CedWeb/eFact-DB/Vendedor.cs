using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace eFact_DB
{
    public class Vendedor : db
    {
        DateTime FechaMax = Convert.ToDateTime("31/12/9998");

        public Vendedor(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public void Leer(eFact_Entidades.Vendedor Vendedor)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Vendedores");
            commandText.Append(" where CuitVendedor='" + Vendedor.CuitVendedor + "'");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            Vendedor.CuitVendedor = dt.Rows[0]["CuitVendedor"].ToString();
            Vendedor.Nombre = dt.Rows[0]["Nombre"].ToString();
            Vendedor.NumeroSerieCertificado = dt.Rows[0]["NumeroSerieCertificado"].ToString();
            if (dt.Rows[0]["Logo"].GetType() != Type.GetType("System.DBNull"))
            {
                Vendedor.Logo = ((byte[])dt.Rows[0]["Logo"]);
            }
            Vendedor.Codigo = dt.Rows[0]["Codigo"].ToString();
            if (dt.Rows[0]["CondicionIVA"].GetType() != Type.GetType("System.DBNull"))
            {
                Vendedor.CondicionIVA = Convert.ToInt32(dt.Rows[0]["CondicionIVA"].ToString());
            }
            if (dt.Rows[0]["CondicionIB"].GetType() != Type.GetType("System.DBNull"))
            {
                Vendedor.CondicionIB = Convert.ToInt32(dt.Rows[0]["CondicionIB"].ToString());
            }
            Vendedor.NroIB =  dt.Rows[0]["NroIB"].ToString();
            if (dt.Rows[0]["InicioActividades"].GetType() != Type.GetType("System.DBNull"))
            {
                Vendedor.InicioActividades = Convert.ToDateTime(dt.Rows[0]["InicioActividades"].ToString());
            }
            else
            {
                Vendedor.InicioActividades = FechaMax;
            }
            Vendedor.Contacto = dt.Rows[0]["Contacto"].ToString();
            Vendedor.DomicilioCalle = dt.Rows[0]["DomicilioCalle"].ToString();
            Vendedor.DomicilioNumero = dt.Rows[0]["DomicilioNumero"].ToString();
            Vendedor.DomicilioPiso = dt.Rows[0]["DomicilioPiso"].ToString();
            Vendedor.DomicilioDepto = dt.Rows[0]["DomicilioDepto"].ToString();
            Vendedor.DomicilioSector = dt.Rows[0]["DomicilioSector"].ToString();
            Vendedor.DomicilioTorre = dt.Rows[0]["DomicilioTorre"].ToString();
            Vendedor.DomicilioManzana = dt.Rows[0]["DomicilioManzana"].ToString();
            Vendedor.Localidad = dt.Rows[0]["Localidad"].ToString();
            Vendedor.Provincia = dt.Rows[0]["Provincia"].ToString();
            Vendedor.CP = dt.Rows[0]["CP"].ToString();
            Vendedor.EMail = dt.Rows[0]["EMail"].ToString();
            Vendedor.Telefono = dt.Rows[0]["Telefono"].ToString();
        }
        public void Consultar(List<eFact_Entidades.Vendedor> Vendedores)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.Append("Select * from Vendedores");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.Acepta, sesion.CnnStr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                eFact_Entidades.Vendedor vendedor = new eFact_Entidades.Vendedor();
                vendedor.CuitVendedor = dt.Rows[i]["CuitVendedor"].ToString();
                vendedor.Nombre = dt.Rows[i]["Nombre"].ToString();
                vendedor.NumeroSerieCertificado = dt.Rows[i]["NumeroSerieCertificado"].ToString();
                if (dt.Rows[i]["Logo"].GetType() != Type.GetType("System.DBNull") && ((System.Byte[])dt.Rows[i]["Logo"]).Length != 0)
                {
                    vendedor.Logo = ((byte[])dt.Rows[i]["Logo"]);
                }
                vendedor.Codigo = dt.Rows[i]["Codigo"].ToString();
                if (dt.Rows[i]["CondicionIVA"].GetType() != Type.GetType("System.DBNull"))
                {
                    vendedor.CondicionIVA = Convert.ToInt32(dt.Rows[i]["CondicionIVA"].ToString());
                }
                if (dt.Rows[i]["CondicionIB"].GetType() != Type.GetType("System.DBNull"))
                {
                    vendedor.CondicionIB = Convert.ToInt32(dt.Rows[i]["CondicionIB"].ToString());
                }
                vendedor.NroIB = dt.Rows[i]["NroIB"].ToString();
                if (dt.Rows[i]["InicioActividades"].GetType() != Type.GetType("System.DBNull"))
                {
                    vendedor.InicioActividades = Convert.ToDateTime(dt.Rows[i]["InicioActividades"].ToString());
                }
                vendedor.Contacto = dt.Rows[i]["Contacto"].ToString();
                vendedor.DomicilioCalle = dt.Rows[i]["DomicilioCalle"].ToString();
                vendedor.DomicilioNumero = dt.Rows[i]["DomicilioNumero"].ToString();
                vendedor.DomicilioPiso = dt.Rows[i]["DomicilioPiso"].ToString();
                vendedor.DomicilioDepto = dt.Rows[i]["DomicilioDepto"].ToString();
                vendedor.DomicilioSector = dt.Rows[i]["DomicilioSector"].ToString();
                vendedor.DomicilioTorre = dt.Rows[i]["DomicilioTorre"].ToString();
                vendedor.DomicilioManzana = dt.Rows[i]["DomicilioManzana"].ToString();
                vendedor.Localidad = dt.Rows[i]["Localidad"].ToString();
                vendedor.Provincia = dt.Rows[i]["Provincia"].ToString();
                vendedor.CP = dt.Rows[i]["CP"].ToString();
                vendedor.EMail = dt.Rows[i]["EMail"].ToString();
                vendedor.Telefono = dt.Rows[i]["Telefono"].ToString();
                Vendedores.Add(vendedor);
            }
        }
        public void Modificar(eFact_Entidades.Vendedor Vendedor)
        {
            //Declaramos y abrimos la conexión con la base de datos donde la variable de conexión especifica el path de nuestro archivo sdf
            System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection(sesion.CnnStr);
            conexion.Open();

            //Creamos el comando SQL para insertar, atentos al parámetro @Imagen
            string comandoSQL = "UPDATE Vendedores set Nombre = '" + Vendedor.Nombre + "', NumeroSerieCertificado = '" + Vendedor.NumeroSerieCertificado + "' "; 
            //Asignamos el array de bytes al parametro @Imagen
            if (Vendedor.Logo != null)
            {
                comandoSQL += ", Logo = @Imagen ";
            }
            else
            {
                comandoSQL += ", Logo = null ";
            }
            comandoSQL += ", Codigo = '" + Vendedor.Codigo + "' ";
            comandoSQL += ", CondicionIVA = " + Vendedor.CondicionIVA + " ";
            comandoSQL += ", CondicionIB = " + Vendedor.CondicionIB + " ";
            comandoSQL += ", NroIB = '" + Vendedor.NroIB + "' ";
            if (Vendedor.InicioActividades.GetType() != Type.GetType("System.DBNull"))
            {
                comandoSQL += ", InicioActividades = '" + Vendedor.InicioActividades.ToString("yyyyMMdd") + "' ";
            }
            comandoSQL += ", Contacto = '" + Vendedor.Contacto + "' ";
            comandoSQL += ", DomicilioCalle = '" + Vendedor.DomicilioCalle + "' ";
            comandoSQL += ", DomicilioNumero = '" + Vendedor.DomicilioNumero + "' ";
            comandoSQL += ", DomicilioPiso = '" + Vendedor.DomicilioPiso + "' ";
            comandoSQL += ", DomicilioDepto = '" + Vendedor.DomicilioDepto + "' ";
            comandoSQL += ", DomicilioSector = '" + Vendedor.DomicilioSector + "' ";
            comandoSQL += ", DomicilioTorre = '" + Vendedor.DomicilioTorre + "' ";
            comandoSQL += ", DomicilioManzana = '" + Vendedor.DomicilioManzana + "' ";
            comandoSQL += ", Localidad = '" + Vendedor.Localidad + "' ";
            comandoSQL += ", Provincia = '" + Vendedor.Provincia + "' ";
            comandoSQL += ", CP = '" + Vendedor.CP + "' ";
            comandoSQL += ", EMail = '" + Vendedor.EMail + "' ";
            comandoSQL += ", Telefono = '" + Vendedor.Telefono + "' ";
            comandoSQL += "where CuitVendedor = '" + Vendedor.CuitVendedor + "'";
            System.Data.SqlClient.SqlCommand comando = new System.Data.SqlClient.SqlCommand(comandoSQL, conexion);
            if (Vendedor.Logo != null)
            {
                comando.Parameters.AddWithValue("@Imagen", Vendedor.Logo);
            }
            //Ejecutamos y grabamos
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
