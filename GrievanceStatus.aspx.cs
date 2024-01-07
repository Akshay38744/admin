using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedaback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        {
            if (Session["refno"] != "" && Session["PANCINno"] != "" && Session["status"] != "" && Session["Applicantname"] != "")
            {
                if (!IsPostBack)
                {
                    lblref.Text = Session["refno"].ToString();
                    lblname.Text = Session["Applicantname"].ToString();
                    lblstatus.Text = Session["status"].ToString();

                }
                else
                {
                    Session["refno"] = "";
                    Session["refno"] = "";
                    Session["Applicantname"] = "";
                    Session["status"] = "";
                    Session.Clear();
                }
            }
            else
            {
                Session["refno"] = "";
                Session["refno"] = "";
                Session["Applicantname"] = "";
                Session["status"] = "";
                Session.Clear();
            }


        }

    }

}

 
