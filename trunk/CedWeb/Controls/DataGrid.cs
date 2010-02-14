using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Reflection;

[assembly: TagPrefix ("Tittle.Controls" , "Tittle") ]
namespace Tittle.Controls
{	
	/// <summary>
	/// A Custom DataGrid which Allow freezing of Headers/Rwos/Columns
	/// http://www.codeproject.com/script/articles/list_articles.asp?userid=1654009
	/// </summary>
	[Editor("System.Web.UI.Design.WebControls.DataGridComponentEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(ComponentEditor)), Designer("System.Web.UI.Design.WebControls.DataGridDesigner, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]		
	public class CustomDataGrid : DataGrid
	{	
		#region Private Variables
		private bool freezeHeader = false;
		private int addEmptyHeaders = 0;
		private int freezeRows = 0;
		private string emptyHeaderClass = "";
		private int freezeColumns = 0;
		private Unit gridHeight = Unit.Empty;
		private Unit gridWidth = Unit.Empty;
		#endregion
		
		#region Constructors
		/// <summary>
		/// default initialization with datagrid properties
		/// </summary>
		public CustomDataGrid(): base() 
		{
			//set default appearence style
			this.HeaderStyle.CssClass = "GridHeader";
			this.FooterStyle.CssClass = "GridHeader";
			this.ItemStyle.CssClass = "GridNormal";
			this.AlternatingItemStyle.CssClass = "GridAlternate";
			this.CssClass = "Grid";
			this.BorderColor =  System.Drawing.Color.FromArgb(47, 33, 98); //"#2f2162"
			this.BorderWidth = Unit.Parse("1");
			this.GridLines = GridLines.Both; 
			this.CellPadding = 2; 
			this.CellSpacing = 0;		
			//paging
			this.PagerStyle.Mode = PagerMode.NumericPages;
			this.PagerStyle.Position = PagerPosition.Bottom; 
			this.PagerStyle.HorizontalAlign = HorizontalAlign.Center; 
				
			this.PagerStyle.ForeColor = System.Drawing.Color.FromArgb(0, 0, 255); //"#2f2162"
				
			this.PageSize = 10;
		}
		#endregion

		#region Exposed Attributes
		/// <summary>
		/// Freeze Header : True/False
		/// 
		/// Default: False
		/// </summary>
		[Browsable(true),
		Category("Freeze"),
		DefaultValue("false"),
		Description ("Freeze Header.") ] 
		public bool FreezeHeader
		{
			get { return freezeHeader; }
			set 
			{ 				
				freezeHeader = value;
				if ( freezeHeader == true )
				{
					//this attribute requires .Net Framework 1.1 service pack 1 installed
					//on system, it generates headers in <th> tags instead of <td> tags.
					this.UseAccessibleHeader = true;
					//If user hasnt set height property set a default here.
					if ( this.gridHeight == Unit.Empty )
						this.gridHeight = 800;
				}
			}
		}

		/// <summary>
		/// Freeze Data Rows : Specify No. of Rows to Freeze from top excluding the header.
		/// 
		/// Default: 0
		/// </summary>
		[Browsable(true),
		Category("Freeze"),
		DefaultValue("0"),
		Description ("Freeze Data Rows.") ] 
		public int FreezeRows
		{
			get { return freezeRows; }
			set 
			{ 				
				freezeRows = value;	
				if ( freezeRows >= 1 )
				{
					this.FreezeHeader = true;
				}
			}
		}

		/// <summary>
		/// Specify here how many columns you want to freeze in the grid, 
		/// freeze columns from the left.
		/// 
		/// Default: 0
		/// </summary>
		[Browsable(true),
		Category("Freeze"),
		DefaultValue("0"),
		Description ("Specify no. of columns to freeze in the grid, it freeze columns from the left.") ]
		public int FreezeColumns
		{
			get { return freezeColumns; }
			set { freezeColumns = value; }
		}		

		/// <summary>
		/// this will add empty <tr><th></th>..</tr> rows
		/// the benefit of it is that later we can through client side add/modify any text to individual cell 
		/// it is done since through client side we can not add more than one row with <th> tags to table.
		/// 
		/// It is used when you set FreezeHeader to "true" and wants to have more than one such headers 
		/// to be freezed but data of all such headers is decided on client side.
		/// 
		/// This is useful you want to keep a static row in all of the pages of a datagrid. 
		/// </summary>
		[Browsable(true),
		Category("Freeze"),
		DefaultValue("0"),
		Description ("It will add empty rows.") ] 
		public int AddEmptyHeaders
		{
			get { return addEmptyHeaders; }
			set { addEmptyHeaders = value;	}
		}				

		/// <summary>
		/// Class of Empty rows <tr><th></th>.. </tr>
		/// </summary>
		[Browsable(true),
		Category("Freeze"),
		Description ("Class of empty rows.") ]
		public string EmptyHeaderClass
		{
			get { return emptyHeaderClass; }
			set { emptyHeaderClass = value; }
		}		

		/// <summary>
		/// Grid height, this is actually height of <DIV> tag not of <table> which can be set through "Height"
		/// </summary>
		[Browsable(true),
		Category("Freeze"),
		Description ("Grid height, this is actually height of <DIV> tag not of <table> which can be set through Height.") ]
		public Unit GridHeight
		{
			get { return gridHeight; }
			set { gridHeight = value; }
		}

		/// <summary>
		/// Grid width, this is actually width of <DIV> tag not of <table> which can be set through "Width"
		/// </summary>
		[Browsable(true),
		Category("Freeze"),
		Description ("Grid width, this is actually width of <DIV> tag not of <table> which can be set through Width.") ]
		public Unit GridWidth
		{
			get { return gridWidth; }
			set { gridWidth = value; }
		}
		#endregion

		#region Overriden events like OnPreRender / Render
		/// <summary>
		/// Before rendering to screen, check if freezing of column/header/row is required.
		/// Add <div> tag before <table> tag then
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{			
			#region DataGrid freezing script
			//DataGrid functions/styles etc.
			if (!Page.IsClientScriptBlockRegistered("FreezeGridScript") )
			{
				string freezeGridScript = @"				
					 function FreezeGridColumns(dgTbl, colNo) 
					 {								
					 	var tbl = document.getElementById(dgTbl);
					 	for ( var i=0; i<tbl.rows.length; i++)
					 	{
					 		for ( var j=0; j<colNo; j++) 
					 		{ 
					 			tbl.rows[i].cells[j].className = 'locked'; 
					 		} 
					 	} 				
					 } 
				";
				Page.RegisterClientScriptBlock("FreezeGridScript","<script language=javascript>\n" + freezeGridScript + "\n</script>");
			}

			if ( !Page.IsClientScriptBlockRegistered("GridStyle") )
			{
				string gridStyle = "";
				gridStyle = @"
					  <style TYPE='text/css'> 
					/* Locks table header */
					th 
					{ 					
						/* border-right: 1px solid silver; */ 
						position:relative;
						cursor: default;
						/*IE5+ only*/ 
						top: expression(this.parentElement.parentElement.parentElement.parentElement.scrollTop -2);
						z-index: 10;	
					}
					TR.GridNormal TH, TR.GridAlternate TH
					{
						text-align:left;
					}
					TR.GridHeader TH
					{
						text-align:center;
					}					
						
					/* Locks the left column */ 
					td.locked, th.locked 
					{ 					
						/* border-right: 1px solid silver; */ 
						position:relative; 
						cursor: default; 
						/*IE5+ only*/	
						left: expression(this.parentElement.parentElement.parentElement.parentElement.scrollLeft-2);	
					} 
					
					/* Keeps the header as the top most item. Important for top left item*/ 
					th.locked {z-index: 99;} 
					</style> 
					<style>
					/*Overriding Grid Styles*/
					.Grid
					{
						border:0;
						background-color: #808080;	
					}
					.GridHeader
					{
						background-color: #547095;
						color:White;
						font-weight:bold;
						font-family:Tahoma;
						text-align:center;	
						padding : 1px 0px 1px 0px;
						font-size:8pt;		
					}
					.GridHeader TD A, TH A
					{
						text-decoration:none;
						color:White;
					}
					.GridNormal
					{
						background-color: #FFFFFF;
						font-weight: normal;
						font: x-small Verdana;
					}
					.GridAlternate
					{
						background-color: #EFF8FC;
						font-weight: normal;
						font: x-small Verdana;
					}
					.GridSelected
					{
						background-color: #FFC082;
						font-weight: normal;
						font: x-small Verdana;
					}
					.GridPager
					{
						background-color : White;
						font-size : x-small;
					}
					</style>
					"; 
				Page.RegisterClientScriptBlock("GridStyle",gridStyle);
			}

			//Trim space from the div and datagrid table.
			string gridOnLoad = "";
			gridOnLoad = @"
				// trims the height of the div surrounding the results table
				// so that if a not a lot of results are returned,
				// you dont have a lot of blank space between the results and
				// the last buttons on the page
				var divTbl = document.getElementById('div_"+this.ID + @"');
				var resultsTable = divTbl.children[0];
				if ( typeof(resultsTable) != 'undefined' )
				{
				//alert( 'div ' + divTbl.offsetHeight + ' results: ' +  resultsTable.offsetHeight );
				if( divTbl.offsetHeight + 3 > resultsTable.offsetHeight ) 
					divTbl.style.height = resultsTable.offsetHeight + 50;
				}
				";
			//If <div> generated then only
			if (freezeColumns >= 1 || freezeHeader == true) 
				Page.RegisterStartupScript("GridOnLoad","<script language=javascript>\n" + gridOnLoad + "\n</script>");
			#endregion

			base.OnPreRender(e);
		}

		/// <summary>
		/// Render datagridservercontrol
		/// </summary>
		/// <param name="output"></param>
		protected override void Render(HtmlTextWriter output)
		{						
			if ( freezeRows >= 1 || addEmptyHeaders >= 1 || freezeColumns >= 1 || freezeHeader == true ) 
			{
				#region Only execute when need to any of this: Freeze Header, Freeze Row, Add Empty Header, Freeze Columns  
				//Get the output string rendered.
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				HtmlTextWriter writer = new HtmlTextWriter(new System.IO.StringWriter(sb));
				base.Render(writer);

				//the output has been retrieved in the stringbuilder AND do the modification here      
				string datgridString = sb.ToString();

				//FREEZE MORE ROWS OTHER THAN JUST HEADER
				if ( freezeRows >= 1 )
				{			
					int cnt = 0;				
					for ( int i=0; i<=freezeRows; i++)
					{
						cnt = datgridString.IndexOf("</tr>",cnt);
						if ( i < freezeRows)
							cnt++;
					}
					if ( cnt != -1 )
					{				
						string firstpart,secondpart;
						firstpart = datgridString.Substring(0,cnt);
						secondpart = datgridString.Substring(cnt);
				
						firstpart = Regex.Replace(firstpart, @"<td", @"<th class='innerBorder' " );
						firstpart = Regex.Replace(firstpart, @"</td>", @"</th>");

						datgridString = firstpart + secondpart;
					}
				}
			
				//ADD EMPTY HEADERS. <TH>
				//This all done as through client side JAVASCRIPT you can not add more than one row TH 
				//tag to existing TABLE.
				if ( addEmptyHeaders >= 1 )
				{
					string rowData="";
					for ( int i=1; i<=addEmptyHeaders; i++)
					{
						rowData +="<TR class='" + EmptyHeaderClass + "' >";
							
						for ( int j=0; j<this.Columns.Count; j++)
						{
							string clsname = "";
							if ( j == 0 )
								clsname="leftBorder";
							if ( j == this.Columns.Count-1 )
								clsname="rightBorder";
							if ( j > 0  && j < this.Columns.Count )
								clsname="innerBorder";

							rowData += "<TH class='" + clsname +"' >&nbsp;</TH>";
						}
						rowData += "</TR>";
					}
					if ( addEmptyHeaders >= 1)
					{
						int headerEnd = datgridString.IndexOf("</tr>",0);
						string prePart = datgridString.Substring(0,headerEnd+5);
						string postPart = datgridString.Substring(headerEnd+5);
						datgridString = prePart + rowData + postPart;
					}
				}

				if ( freezeColumns >= 1 )
				{
					if ( this.gridWidth == Unit.Empty )
						this.gridWidth = 800;
				
					string freezeGridColumn="FreezeGridColumns('" + this.ID + "',"+freezeColumns.ToString()+");";
					Page.RegisterStartupScript("freezeGridColumn","<script language=javascript>\n" + freezeGridColumn + "\n</script>" );
				}

				if ( freezeColumns >= 1 || freezeHeader == true )
				{
					string divstring;
					divstring = "<div id='div_" + this.ID + "' style='";			
					if ( freezeHeader == true )
						divstring += " HEIGHT:"+this.gridHeight+"; ";
					if ( freezeColumns >= 1 )
						divstring += " WIDTH:"+this.gridWidth+"; ";

					datgridString = divstring + " OVERFLOW:auto; ' >" + datgridString + "</div>";
				}

				output.Write(datgridString.ToString());    
				#endregion
			}
			else
			{
				base.Render(output);
			}
		}
		#endregion
	}
}