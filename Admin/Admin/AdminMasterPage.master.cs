using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Convert.ToString(Session["log_name"])))
        {
            lblDate.Text = DateTime.Now.Date.ToString("dddd") + ", " + DateTime.Now.Date.ToString("dd MMM yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");
            lblUsr.Text = "Current Administrator : " + Convert.ToString(Session["log_name"]);
        }
        else
        {
            Response.Redirect("~/MSMELoanTrackerAdmin/AdminLogin.aspx");

        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session["usr_id"] = "";
        Session["log_name"] = "";
        Session["usr_dept"] = "";
        Session["usr_type"] = "";
        Session["current_mod"] = "";

        Session.Clear();
        Session.Abandon();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));

        Response.Redirect("~/MSMELoanTrackerAdmin/AdminLogin.aspx");
    }
    protected void lnkChngPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MSMELoanTrackerAdmin/ChangePassword.aspx");
    }
}
