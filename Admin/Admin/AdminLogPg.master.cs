using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminLogPg : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDate.Text = DateTime.Now.Date.ToString("dddd") + ", " + DateTime.Now.Date.ToString("dd-MMM-yyyy");
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");
    }
}
