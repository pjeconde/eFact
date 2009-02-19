using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedWeb.Autenticado.Controles
{
	public partial class DatePickerUserControl : System.Web.UI.UserControl
	{

		private string mCulture = "en-GB";
		private string mSelectedDateFormat = "dd/MM/yyyy";
		private int mYearMinimum = 1970;
		private int mYearMaximum = 2029;
		private bool mNullable = true;

		public bool Nullable
		{
			get
			{
				return mNullable;
			}
			set
			{
				mNullable = value;
			}
		}

		public string Culture
		{
			get
			{
				return mCulture;
			}
			set
			{
				mCulture = value;
			}
		}

		public string SelectedDateFormat
		{
			get
			{
				return mSelectedDateFormat;
			}
			set
			{
				mSelectedDateFormat = value;
			}
		}
		public int YearMinimum
		{
			set
			{
				mYearMinimum = value;
			}
		}

		public int YearMaximum
		{
			set
			{
				mYearMaximum = value;
			}
		}

		public DateTime SelectedDate
		{
			get
			{
				//if (DateTextBox.Text != "")
				//{
				//    return DateTime.Parse(DateTextBox.Text, new System.Globalization.CultureInfo(mCulture));
				//}
				//else
				//{
				//    return DateTime.Now;
				//}
				return Calendar1.SelectedDate;
			}
			set
			{
				DateTextBox.ReadOnly = false;
				DateTextBox.Text = value.ToString(mSelectedDateFormat, new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"]));
				DateTextBox.ReadOnly = true;
				Calendar1.SelectedDate = value;
			}
		}



		protected void Calendar1_SelectionChanged(object sender, EventArgs e)
		{
			PopupControlExtender1.Commit(Calendar1.SelectedDate.ToString(mSelectedDateFormat, new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"])));
		}

		private void SelectCalendar()
		{
			if (ddlYear.SelectedValue != "")
			{
				Calendar1.VisibleDate = DateTime.Parse("01" + "/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue, new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"]));
			}

		}

		protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectCalendar();
			Page_Init(sender, e);
		}

		protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectCalendar();
			Page_Init(sender, e);
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				for (int i = mYearMinimum; i < mYearMaximum; i++)
				{
					ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
				}
				ddlYear.SelectedValue = (DateTime.Now).Year.ToString();
				ddlMonth.SelectedValue = (DateTime.Now).Month.ToString();
				lbtnClearDate.Visible = mNullable;
			}
		}

		protected void lbtnClearDate_Click(object sender, EventArgs e)
		{
			DateTextBox.ReadOnly = false;
			DateTextBox.Text = "";
			DateTextBox.ReadOnly = true;
			PopupControlExtender1.Commit("");
		}

		protected void lbtnToday_Click(object sender, EventArgs e)
		{
			ddlYear.SelectedValue = (DateTime.Now).Year.ToString();
			ddlMonth.SelectedValue = (DateTime.Now).Month.ToString();
			SelectCalendar();
			Calendar1.SelectedDate = DateTime.Now;
			PopupControlExtender1.Commit(Calendar1.SelectedDate.ToString(mSelectedDateFormat, new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"])));
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DateTextBox.Text = "dd/MM/aaaa";
			}
		}
	}
}