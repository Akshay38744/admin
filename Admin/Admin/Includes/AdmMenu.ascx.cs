using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;

public partial class Admin_Includes_AdmMenu : System.Web.UI.UserControl
{
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["bb_con"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            if (string.IsNullOrEmpty(Convert.ToString(Session["log_name"])))
            {
                Session["usr_id"] = "";
                Session["log_name"] = "";
                Session["usr_dept"] = "";
                Session["usr_type"] = "";
                Session["log_prevlg"] = "";
                Session["current_mod"] = "";
                Session.Clear();
                Response.Redirect("~/MSMELoanTrackerAdmin/AdminLogin.aspx");

            }


        }
    }
    protected void lnkManageApp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MSMELoanTrackerAdmin/ManageApplication.aspx");
    }
    protected void lnkManageBulkUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MSMELoanTrackerAdmin/BulkUpload.aspx");
    }
    //protected void lnkMngPrfCap_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/MSMELoanTrackerAdmin/Manage_ProfileCapturing.aspx");
    //}
}