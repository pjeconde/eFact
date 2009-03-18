﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace CedWeb
{
    public partial class Descarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filename = Request.QueryString.Get("archivo");
            if (!String.IsNullOrEmpty(filename))
            {
                String dlDir = @"Descargas/";
                String path = Server.MapPath(dlDir + filename);
                System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                if (toDownload.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
                    Response.AddHeader("Content-Length", toDownload.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(dlDir + filename);
                    Response.End();
                }
            }
        }
    }
}