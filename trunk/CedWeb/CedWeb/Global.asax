﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse la aplicación
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta cuando se cierra la aplicación
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta al producirse un error no controlado
        try
        {
            string strFile = Server.MapPath("Log.txt");
            System.IO.StreamWriter log = new System.IO.StreamWriter(strFile, true);

            System.Exception exc = Server.GetLastError();

            log.WriteLine(exc.ToString());
            log.Close();
        }
        catch (System.Exception ex)
        {
        }
        finally
        {
            //Response.Redirect("Mensaje.aspx");
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando se inicia una nueva sesión
        CedWebEntidades.Sesion s = new CedWebEntidades.Sesion();
        s.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"];
        s.MensajeGeneral = System.Configuration.ConfigurationManager.AppSettings["MensajeGeneral"];
        Session["Sesion"] = s;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera.

    }
       
</script>