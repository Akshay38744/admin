using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        {
            if (Session["refno"] != "")
            {
                if (!IsPostBack)
                {
                    lblref.Text = Session["refno"].ToString();

                }
                else
                {
                    Session["refno"] = "";
                    Session.Clear();
                }
            }
            else
            {
                Session["refno"] = "";
                Session.Clear();
            }


        }

    }

}

