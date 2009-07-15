using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CedWeb
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class WebForm1 : System.Web.UI.Page
	{
		//protected Tittle.Controls.CustomDataGrid dgTittle;
		//protected Tittle.Controls.CustomDataGrid dgTittle2;
		//protected Tittle.Controls.CustomDataGrid dgTittle3;
		//protected Tittle.Controls.CustomDataGrid dgTittle4;
        DataTable dt = new DataTable();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			if ( !Page.IsPostBack )
			{
				BindData(1); //first data grid.
				BindData(2); //second data grid.
				BindData(3); //iiird data grid.
				BindData(4); //ivth data grid.
			}
		}

		private void BindData(int gridno)
		{
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Age", typeof(System.Int32));
            dt.Columns.Add("Address", typeof(System.String));
            dt.Columns.Add("Codigo", typeof(System.String));					

			dt.Rows.Add(new object[] {"Peter",13,"1493 Meridan Drive", "Remito"});
            dt.Rows.Add(new object[] { "Paul", 47, "5/67 Vaishali", "Remito" });
            dt.Rows.Add(new object[] { "Abraham", 56, "10/104 New Delhi GT road", "Remito" });
            dt.Rows.Add(new object[] { "Andrew", 59, "1/16 Barakhamba road", "Remito" });
            dt.Rows.Add(new object[] { "Bernard", 35, "1462 Meridan Drive", "Remito" });
            dt.Rows.Add(new object[] { "Rozi", 19, "1/16 Barakhamba road", "Remito" });
            dt.Rows.Add(new object[] { "Ruby", 25, "5/67 Vaishali", "Remito" });
            dt.Rows.Add(new object[] { "Antony", 27, "10/107 New Delhi GT road", "Remito" });
            dt.Rows.Add(new object[] { "George", 27, "1493 Meridan Drive", "Remito" });
            dt.Rows.Add(new object[] { "Bobby", 17, "4/96 Vaishali", "Remito" });
            dt.Rows.Add(new object[] { "Barbara", 40, "1/16 Barakhamba road", "Remito" });
            dt.Rows.Add(new object[] { "Johnson", 35, "99 Meridan Drive", "Remito" });
            dt.Rows.Add(new object[] { "Mark", 30, "1/16 Barakhamba road", "Remito" });
            dt.Rows.Add(new object[] { "John", 31, "1493 Meridan Drive", "Remito" });
            dt.Rows.Add(new object[] { "Frank", 27, "10/104 New Delhi GT road", "Remito" });
            dt.Rows.Add(new object[] { "Alan", 40, "5/67 Vaishali", "Remito" });
            dt.Rows.Add(new object[] { "Tittle", 28, "1493 Meridan Drive", "Remito" });
            dt.Rows.Add(new object[] { "Joseph", 62, "1/16 Barakhamba road", "Remito" });			

			if ( gridno == 1 )
			{
				dgTittle.DataSource = dt.DefaultView;
				dgTittle.DataBind();
			}
			if ( gridno == 2 )
			{
				dt.DefaultView.Sort = "Age Desc";
				dgTittle2.DataSource = dt.DefaultView;
				dgTittle2.DataBind();
			}
			if ( gridno == 3 )
			{
				dt.DefaultView.Sort = "Name ASC, Age asc";
				dgTittle3.DataSource = dt.DefaultView;
				dgTittle3.DataBind();
                int count = dgTittle3.Controls[0].Controls.Count;
                DataGridItem item = (DataGridItem)dgTittle3.Controls[0].Controls[count - 1];
                ((DropDownList)item.FindControl("DropDownListReferencias")).DataValueField = "Codigo";
                ((DropDownList)item.FindControl("DropDownListReferencias")).DataTextField = "Descr";
                ((DropDownList)item.FindControl("DropDownListReferencias")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                ((DropDownList)item.FindControl("DropDownListReferencias")).DataBind();
			}
			if ( gridno == 4 )
			{
				dgTittle4.DataSource = dt.DefaultView;
				dgTittle4.DataBind();
			}
		}

		protected void dgTittle4_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			dgTittle4.CurrentPageIndex = e.NewPageIndex;
			BindData(4);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
        protected void dgTittle3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DataGrid)sender).Items[0].ItemType == ListItemType.Footer)
            {
            }

            ((DropDownList)dgTittle3.Controls[0].FindControl("DropDownListReferencias")).DataValueField = "Codigo";
            //((DropDownList)dgTittle3.Items[3].FindControl("LabelTipoDoc")).DataTextField = "Descr";
            //((DropDownList)dgTittle3.Items[3].FindControl("DropDownListReferencias")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
            //((DropDownList)dgTittle3.Items[3].Cells[.FindControl("DropDownListReferencias")).DataBind();
        }
        protected void dgTittle3_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            
            if (((DataGrid)source).Items[0].ItemType == ListItemType.Footer)
            {
            }

            //((DropDownList)dgTittle3.Controls[0].FindControl("DropDownListReferencias")).DataValueField = "Codigo";
            //((DropDownList)dgTittle3.Items[3].FindControl("LabelTipoDoc")).DataTextField = "Descr";
            //((DropDownList)dgTittle3.Items[3].FindControl("DropDownListReferencias")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
            //((DropDownList)dgTittle3.Items[3].Cells[.FindControl("DropDownListReferencias")).DataBind();
        }
}
}
