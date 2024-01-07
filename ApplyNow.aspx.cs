using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Text;

public partial class English_ApplyNow : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["bb_con"]);
    SqlDataAdapter da = new SqlDataAdapter();
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["bb_con"]);
    string today = DateTime.Now.Date.ToString("dd/MM/yyyy");
    string ackid;
    protected void Page_Load(object sender, EventArgs e)
    {
        
         msme.Visible = false;
        //form1.Visible = false;
        if (!Page.IsPostBack)
        {

            dbcat.DataBind();
            LoadCity();
           
        }


        //    if (Request.QueryString["val"].ToString() != "All")
        //    {
        //        dbcat.SelectedValue = Request.QueryString["val"].ToString();
        //        dbcat.Enabled = false;
        //    }

        //    if (Request.QueryString["val"].ToString() == "Nri" || Request.QueryString["val"].ToString() == "nri")
        //    {
        //        dbcat.SelectedValue = Request.QueryString["val"].ToString();
        //        dbcat.Enabled = true;
        //        Response.Redirect("apply-for-banking-products-and-services.aspx?val=All");
        //    }

        //    if (Request.QueryString["val"].ToString() == "RetailLoan")
        //    {
        //        dbcat.SelectedValue = "Retail Loans";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Retail Loans";
        //    }

        //    if (Request.QueryString["val"].ToString() == "MicroLoan")
        //    {
        //        dbcat.SelectedValue = "Micro Loans";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Micro Loans";
        //    }

        //    if (Request.QueryString["val"].ToString() == "HomeLoan")
        //    {
        //        dbcat.SelectedValue = "Home Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Home Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "LoanAgainstProperty")
        //    {
        //        dbcat.SelectedValue = "Loan Against Property";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Loan Against Property";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "TwoWheelerLoan")
        //    {
        //        dbcat.SelectedValue = "Two Wheeler Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Two Wheeler Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "LoanAgainstTermDeposit")
        //    {
        //        dbcat.SelectedValue = "Loan Against Term Deposit";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Loan Against Term Deposit";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "PersonalLoan")
        //    {
        //        dbcat.SelectedValue = "Personal Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Personal Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "SamriddhiBusinessLoan")
        //    {
        //        dbcat.SelectedValue = "Samriddhi Business Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Samriddhi Business Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "EquipmentLoan")
        //    {
        //        dbcat.SelectedValue = "Equipment Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Equipment Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "CommercialVehicleLoan")
        //    {
        //        dbcat.SelectedValue = "Commercial Vehicle Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Commercial Vehicle Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "WorkingCapitalLoan")
        //    {
        //        dbcat.SelectedValue = "Working Capital Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Working Capital Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "TermLoan")
        //    {
        //        dbcat.SelectedValue = "Term Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Term Loan";
        //    } 
        //    if (Request.QueryString["val"].ToString() == "SmallEnterpriseLoan")
        //    {
        //        dbcat.SelectedValue = "Small Enterprise Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Small Enterprise Loan";
        //    } 

        //    if (Request.QueryString["val"].ToString() == "KisanCreditCardLoan")
        //    {
        //        dbcat.SelectedValue = "Kisan Credit Card Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Kisan Credit Card Loan";
        //    }
        //    if (Request.QueryString["val"].ToString() == "EquipmentLoan")
        //    {
        //        dbcat.SelectedValue = "Equipment Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Equipment Loan";
        //    }
        //    if (Request.QueryString["val"].ToString() == "AgriAlliedLoan")
        //    {
        //        dbcat.SelectedValue = "Agri Allied Loan";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Agri Allied Loan";
        //    }

        //    if (Request.QueryString["val"].ToString() == "NRI")
        //    {
        //        dbcat.SelectedValue = "NRI";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "NRI";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-Premium")
        //    {
        //        dbcat.SelectedValue = "Saving account-Premium";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-Premium";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-Advantage")
        //    {
        //        dbcat.SelectedValue = "Saving account-Advantage";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-Advantage";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-Standard")
        //    {
        //        dbcat.SelectedValue = "Saving account-Standard";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-Standard";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-Sanchay")
        //    {
        //        dbcat.SelectedValue = "Saving account-Sanchay";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-Sanchay";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-Special")
        //    {
        //        dbcat.SelectedValue = "Saving account-Special";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-Special";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-GOS")
        //    {
        //        dbcat.SelectedValue = "Saving account-GOS";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-GOS";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-TASC")
        //    {
        //        dbcat.SelectedValue = "Saving account-TASC";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-TASC";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-BSBDA")
        //    {
        //        dbcat.SelectedValue = "Saving account-BSBDA";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-BSBDA";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Savingsaccount-BSBDA-Small")
        //    {
        //        dbcat.SelectedValue = "Saving account-BSBDA-Small";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Saving account-BSBDA-Small";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Currentaccount-Premium")
        //    {
        //        dbcat.SelectedValue = "Current account-Premium";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Current account-Premium";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Currentaccount-Advantage")
        //    {
        //        dbcat.SelectedValue = "Current account-Advantage";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Current account-Advantage";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Currentaccount-Standard")
        //    {
        //        dbcat.SelectedValue = "Current account-Standard";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Current account-Standard";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Currentaccount-Samruddhi")
        //    {
        //        dbcat.SelectedValue = "Current account-Samruddhi";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Current account-Samruddhi";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Currentaccount-TASC")
        //    {
        //        dbcat.SelectedValue = "Current account-TASC";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Current account-TASC";
        //    }

        //    if (Request.QueryString["val"].ToString() == "Currentaccount-GOS")
        //    {
        //        dbcat.SelectedValue = "Current account-GOS";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Current account-GOS";
        //    }

        //    if (Request.QueryString["val"].ToString() == "FixedDepositPremium")
        //    {
        //        dbcat.SelectedValue = "Fixed Deposit-Premium";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Fixed Deposit-Premium";
        //    }

        //    if (Request.QueryString["val"].ToString() == "FixedDepositAdvantage")
        //    {
        //        dbcat.SelectedValue = "Fixed Deposit-Advantage";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Fixed Deposit-Advantage";
        //    }

        //    if (Request.QueryString["val"].ToString() == "FixedDepositStandard")
        //    {
        //        dbcat.SelectedValue = "Fixed Deposit-Standard";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Fixed Deposit-Standard";
        //    }

        //    if (Request.QueryString["val"].ToString() == "FixedDepositDhanSamriddhi")
        //    {
        //        dbcat.SelectedValue = "Fixed Deposit-Dhan Samriddhi";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Fixed Deposit-Dhan Samriddhi";
        //    }

        //    if (Request.QueryString["val"].ToString() == "FixedDepositTaxSaver")
        //    {
        //        dbcat.SelectedValue = "Fixed Deposit-Tax Saver";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Fixed Deposit-Tax Saver";
        //    }

        //    if (Request.QueryString["val"].ToString() == "RecurringDeposit")
        //    {
        //        dbcat.SelectedValue = "Recurring Deposit";
        //        dbcat.Enabled = false;
        //        Session["Loan"] = "Recurring Deposit";
        //    }

        //    if (Request.QueryString["val"].ToString() == "NriDeposits")
        //    {
        //        dbcat.SelectedValue = "NRI Deposits";
        //        dbcat.Enabled = false;
        //        Session["visible"] = "visible thaks";
        //    }

        //    if (Request.QueryString["val"].ToString() == "seniorcitizenfd")
        //    {
        //        dbcat.SelectedValue = "Term Deposit for Senior Citizens";
        //        dbcat.Enabled = false;
        //        Session["visibleSinior"] = "visible thaks Senior";
        //    }

        //    //if (Request.QueryString["val"].ToString() == "NRI")
        //    //{
        //    //    dbcat.SelectedValue = "NRI";
        //    //    dbcat.Enabled = false;
        //    //}

        //}
    }

    private void LoadCity()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand("Proc_ApplyNow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "Getdata");
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbl_city");
            con.Close();
            dbCity.Items.Clear();
            dbCity.DataSource = ds.Tables["tbl_city"].DefaultView;
            dbCity.DataTextField = "CityName";
            dbCity.DataValueField = "cityId";
            dbCity.DataBind();
            dbCity.Items.Insert(0, "Select City");
            dbCity.SelectedIndex = 0;
        }

        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    public void clear_data()
    {
        dbcat.SelectedIndex = 0;
        lblError.Text = "";
        txtName.Text = "";
        txtMobileNo.Text = "";
        txtemail.Text = "";
        dbCity.SelectedIndex = 0;
        txtpincode.Text = "";
        txtName.Focus();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkdata() == true)
        {
            lblError.Text = "";

            try
            {

                int cnt = 0;
                lblError.Text = "";
                con.Open();
                cmd = new SqlCommand("Proc_ApplyNow", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));

                if (txtName.Text != "")
                {
                    cmd.Parameters.AddWithValue("@strproNm", txtName.Text);

                    Session["Name"] = txtName.Text;
                }
                if (dbcat.SelectedIndex != 0)
                {
                    cmd.Parameters.AddWithValue("@strProAct", dbcat.SelectedValue);
                }

                if (txtMobileNo.Text != "")
                {
                    cmd.Parameters.AddWithValue("@strproMob", txtMobileNo.Text);

                    Session["Mobile"] = txtMobileNo.Text;
                }

                if (txtemail.Text != "")
                {
                    cmd.Parameters.AddWithValue("@strproEmail", txtemail.Text);
                    Session["Email"] = txtemail.Text;
                }

                cmd.Parameters.AddWithValue("@CityId", dbCity.SelectedValue);
                cmd.Parameters.AddWithValue("@City", dbCity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@PinCode", txtpincode.Text);



                cmd.Parameters.AddWithValue("@strproAddDt", DateTime.Now);
                cmd.Parameters["@mode"].Value = "Addpro";

                cnt = Convert.ToInt32(cmd.ExecuteNonQuery());
                con.Close();
                if (cnt > 0)
                {
                    clear_data();
                    lblError.Text = "";
                    if (string.IsNullOrEmpty(Convert.ToString(Session["visible"])) & string.IsNullOrEmpty(Convert.ToString(Session["visibleSinior"])))
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "validatin", "<script language='javascript'>alert('We have got your details and our person will contact you shortly.')</script>");
                    }
                    //string filename = Session["AppFile"].ToString();
                    //string folderName = Session["AppType"].ToString();
                    //string[] strArray = filename.Split('.');
                    //string filetype = strArray[1];

                    //string filePath = "~/UploadFiles/" + folderName + "/" + filename;

                    //Response.ContentType = "application/" + filetype;
                    //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                    //Response.WriteFile(filePath);
                    //Response.End();
                }
                // string abc = Session["visible"].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Retail Loans")
                    {
                        dbcat.SelectedValue = "Retail Loans";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Micro Loans")
                    {
                        dbcat.SelectedValue = "Micro Loans";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Home Loan")
                    {
                        dbcat.SelectedValue = "Home Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Loan Against Property")
                    {
                        dbcat.SelectedValue = "Loan Against Property";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Two Wheeler Loan")
                    {
                        dbcat.SelectedValue = "Two Wheeler Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Loan Against Term Deposit")
                    {
                        dbcat.SelectedValue = "Loan Against Term Deposit";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Personal Loan")
                    {
                        dbcat.SelectedValue = "Personal Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Samriddhi Business Loan")
                    {
                        dbcat.SelectedValue = "Samriddhi Business Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Equipment Loan")
                    {
                        dbcat.SelectedValue = "Equipment Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Commercial Vehicle Loan")
                    {
                        dbcat.SelectedValue = "Commercial Vehicle Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Working Capital Loan")
                    {
                        dbcat.SelectedValue = "Working Capital Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Term Loan")
                    {
                        dbcat.SelectedValue = "Term Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Small Enterprise Loan")
                    {
                        dbcat.SelectedValue = "Small Enterprise Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Kisan Credit Card Loan")
                    {
                        dbcat.SelectedValue = "Kisan Credit Card Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Equipment Loan")
                    {
                        dbcat.SelectedValue = "Equipment Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Agri Allied Loan")
                    {
                        dbcat.SelectedValue = "Agri Allied Loan";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "NRI")
                    {
                        dbcat.SelectedValue = "NRI";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-Premium")
                    {
                        dbcat.SelectedValue = "Saving account-Premium";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-Advantage")
                    {
                        dbcat.SelectedValue = "Saving account-Advantage";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-Standard")
                    {
                        dbcat.SelectedValue = "Saving account-Standard";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-Sanchay")
                    {
                        dbcat.SelectedValue = "Saving account-Sanchay";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-Special")
                    {
                        dbcat.SelectedValue = "Saving account-Special";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-GOS")
                    {
                        dbcat.SelectedValue = "Saving account-GOS";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-TASC")
                    {
                        dbcat.SelectedValue = "Saving account-TASC";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-BSBDA")
                    {
                        dbcat.SelectedValue = "Saving account-BSBDA";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Saving account-BSBDA-Small")
                    {
                        dbcat.SelectedValue = "Saving account-BSBDA-Small";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Current account-Premium")
                    {
                        dbcat.SelectedValue = "Current account-Premium";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Current account-Advantage")
                    {
                        dbcat.SelectedValue = "Current account-Advantage";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Current account-Standard")
                    {
                        dbcat.SelectedValue = "Current account-Standard";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Current account-Samruddhi")
                    {
                        dbcat.SelectedValue = "Current account-Samruddhi";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Current account-TASC")
                    {
                        dbcat.SelectedValue = "Current account-TASC";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Current account-GOS")
                    {
                        dbcat.SelectedValue = "Current account-GOS";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Fixed Deposit-Premium")
                    {
                        dbcat.SelectedValue = "Fixed Deposit-Premium";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Fixed Deposit-Advantage")
                    {
                        dbcat.SelectedValue = "Fixed Deposit-Advantage";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Fixed Deposit-Standard")
                    {
                        dbcat.SelectedValue = "Fixed Deposit-Standard";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Fixed Deposit-Dhan Samriddhi")
                    {
                        dbcat.SelectedValue = "Fixed Deposit-Dhan Samriddhi";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Senior Citizen FD")
                    {
                        dbcat.SelectedValue = "Term Deposit for Senior Citizens";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Fixed Deposit-Tax Saver")
                    {
                        dbcat.SelectedValue = "Fixed Deposit-Tax Saver";

                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["Loan"])))
                {
                    if (Session["Loan"] == "Recurring Deposit")
                    {
                        dbcat.SelectedValue = "Recurring Deposit";

                    }
                }




                if (!string.IsNullOrEmpty(Convert.ToString(Session["visible"])))
                {
                    if (Session["visible"] == "visible thaks")
                    {
                        mail_appl("");
                        apply.Visible = false;
                        frm.Visible = false;
                        botm.Visible = false;
                        Divthanks.Visible = true;
                        Session.Clear();
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(Session["visibleSinior"])))
                {
                    if (Session["visibleSinior"] == "visible thaks Senior")
                    {
                        mail_applsenior("");
                        //apply.Visible = false;
                        //frm.Visible = false;
                        //botm.Visible = false;
                        //Divthsnr.Visible = true;
                        Response.Redirect("Thanks.aspx");
                        Session.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }

    //public void mail_appl(string AppNo)
    //{
    //    try
    //    {

    //        string mailid = null;
    //        string mailid1 = null;
    //        MailAddress ma = new MailAddress("noreply@bandhanbank.com");

    //        //CCD Department Email ID
    //        mailid = "shashwatbharti@gmail.com,sumona.chatterjee@gmail.com";
    //        //mailid1 = "sumona.chatterjee@bandhanbank.com";

    //        int x = 0;

    //        string blank1 = "";
    //        string strbody1 = "";
    //        string ImgUrl = ConfigurationManager.AppSettings.Get("imgurl");

    //        strbody1 = "<html><head></head><body><table align=center border=0 cellpadding=4 cellspacing=4 style='width:700px; border:solid 1px; #DA251C;' >";

    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; height:91px' ><img src=" + ImgUrl + ">";
    //        strbody1 = strbody1 + "</td></tr>";



    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' >Subject: A new application is submitted for – NRI Deposits, dated – " + DateTime.Now.ToString("dd/MM/yyyy") + "</td></tr>";

    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' ></td></tr>";

    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' >Following are the details:</td></tr>";




    //        strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Name:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Name"].ToString();
    //        strbody1 = strbody1 + "</td></tr>";


    //        strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Email Id:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Email"].ToString();
    //        strbody1 = strbody1 + "</td></tr>";



    //        strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Mobile No.:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Mobile"].ToString();
    //        strbody1 = strbody1 + "</td></tr>";

    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff></td>";

    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanks & Regards</td>";

    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster</td>";

    //        strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Bandhan Bank</td>";

    //        strbody1 = strbody1 + "<tr><td colspan='5' style='width:700px; height:5px;' bgcolor=#ffffff></td>";

    //        strbody1 = strbody1 + "</table></body></html>";


    //        ///''''''''''''''''''''''' mail to bank
    //        MailMessage Mail_br = new MailMessage();
    //        Mail_br.From = ma;
    //        //Mail_br.To.Add(mailid);
    //        //Mail_br.To.Add(mailid1);

    //        string[] multi = mailid.Split(',');
    //        foreach (string maltimailId in multi)
    //        {
    //            Mail_br.To.Add(new MailAddress(maltimailId));
    //        }

    //        //Mail_br.CC.Add("bhupendra@chicinfotech.com");
    //        Mail_br.Subject = " BandhanBank : NRI";
    //        Mail_br.IsBodyHtml = true;
    //        Mail_br.Body = strbody1;

    //        SmtpClient smtpMailObj1 = new SmtpClient();
    //        smtpMailObj1.Host = "127.0.0.1";
    //        smtpMailObj1.Port = 25;
    //        smtpMailObj1.Send(Mail_br);

    //    }


    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.ToString());
    //    }

    //}


    public void mail_applsenior(string AppNo)
    {
        try
        {

            string mailid = null;
            string mailid1 = null;
            string mailidcc = null;
            MailAddress ma = new MailAddress("noreply@bandhanbank.com");

            //CCD Department Email ID
            mailid = "sumona.chatterjee@gmail.com,shimul555@gmail.com";
            mailidcc = "sumona.chatterjee@bandhanbank.com,Shimul.aich@bandhanbank.com,bhupendra@chicinfotech.com";
            //mailid1 = "sumona.chatterjee@bandhanbank.com";

            int x = 0;

            string blank1 = "";
            string strbody1 = "";
            string ImgUrl = ConfigurationManager.AppSettings.Get("imgurl");

            strbody1 = "<html><head></head><body><table align=center border=0 cellpadding=4 cellspacing=4 style='width:700px; border:solid 1px; #DA251C;' >";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; height:91px' ><img src=" + ImgUrl + ">";
            strbody1 = strbody1 + "</td></tr>";



            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' >Subject: A new application is submitted for – Term Deposit for Senior Citizens, dated – " + DateTime.Now.ToString("dd/MM/yyyy") + "</td></tr>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' ></td></tr>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' >Following are the details:</td></tr>";




            strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Name:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Name"].ToString();
            strbody1 = strbody1 + "</td></tr>";


            strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Email Id:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Email"].ToString();
            strbody1 = strbody1 + "</td></tr>";



            strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Mobile No.:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Mobile"].ToString();
            strbody1 = strbody1 + "</td></tr>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff></td>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanks & Regards</td>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster</td>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Bandhan Bank</td>";

            strbody1 = strbody1 + "<tr><td colspan='5' style='width:700px; height:5px;' bgcolor=#ffffff></td>";

            strbody1 = strbody1 + "</table></body></html>";


            ///''''''''''''''''''''''' mail to bank
            MailMessage Mail_br = new MailMessage();
            Mail_br.From = ma;
            //Mail_br.To.Add(mailid);
            //Mail_br.To.Add(mailid1);

            string[] multi = mailid.Split(',');
            foreach (string maltimailId in multi)
            {
                Mail_br.To.Add(new MailAddress(maltimailId));
            }

            string[] multicc = mailidcc.Split(',');
            foreach (string maltimailIdcc in multicc)
            {
                Mail_br.CC.Add(new MailAddress(maltimailIdcc));
            }


            Mail_br.Subject = " BandhanBank : Term Deposit for Senior Citizens";
            Mail_br.IsBodyHtml = true;
            Mail_br.Body = strbody1;

            SmtpClient smtpMailObj1 = new SmtpClient();
            smtpMailObj1.Host = "127.0.0.1";
            smtpMailObj1.Port = 25;
            smtpMailObj1.Send(Mail_br);

        }


        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }

    public bool checkmail()
    {
        int cnt = 0;
        cn.Open();
        SqlCommand cmd = new SqlCommand("proc_msme", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
        if (txtemailid.Text != "")
        {
            cmd.Parameters.Add("@Emailaddress", txtemailid.Text);

        }
        cmd.Parameters["@mode"].Value = "checkmail";
        cnt = Convert.ToInt32(cmd.ExecuteScalar());
        cn.Close();
        if (cnt > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool checkPAN()
    {

        int cnt = 0;
        cn.Open();
        SqlCommand cmd = new SqlCommand("proc_msme", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 50));
        if (txtpan.Text != "")
        {
            cmd.Parameters.Add("@PANCINno", txtpan.Text);

        }
        cmd.Parameters["@mode"].Value = "checkpan";
        cnt = Convert.ToInt32(cmd.ExecuteScalar());
        cn.Close();
        if (cnt > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool checkdata()
    {
        if (string.IsNullOrEmpty(txtName.Text))
        {
            lblError.Text = "Please enter your name !!";
            txtName.Text = "";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtName.Text) & txtName.Text.Length < 3)
        {
            lblError.Text = "Please enter your full name !!";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtName.Text) & txtName.Text.Length > 50)
        {
            lblError.Text = "Name can contain maximum 50 characters !!";
            txtName.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtName.Text) & !Regex.IsMatch(txtName.Text, "^[a-z.A-Z ]+$"))
        {
            lblError.Text = "Please enter only alphabets in name !!";
            txtName.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtemail.Text))
        {
            lblError.Text = "Email Id cannot be Blank !!";
            txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtemail.Text) & chk_val1(txtemail.Text) == false)
        {
            lblError.Text = "Please enter valid Email Address !!";
            txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtemail.Text) & !Regex.IsMatch(txtemail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            lblError.Text = "Your email address is not in correct format !!";
            txtemail.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtemail.Text) & txtemail.Text.Length > 100)
        {
            lblError.Text = "Email contain maximum 100 character !!";
            txtemail.Focus();
            return false;
        }

        else if (string.IsNullOrEmpty(txtMobileNo.Text))
        {
            lblError.Text = "Please enter your mobile number !!";
            txtMobileNo.Text = "";
            txtMobileNo.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMobileNo.Text) & !Regex.IsMatch(txtMobileNo.Text, "^[0-9]+$"))
        {
            lblError.Text = "Please enter only digits in Mobile Number !!";
            txtMobileNo.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMobileNo.Text) & txtMobileNo.Text.Length < 10)
        {
            lblError.Text = "Mobile Number should contain min 10 digits !!";
            txtMobileNo.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtMobileNo.Text) & txtMobileNo.Text.Length > 12)
        {
            lblError.Text = "Mobile Number should contain max 12 digits !!";
            txtMobileNo.Focus();
            return false;
        }

        else if (dbCity.SelectedIndex == 0)
        {
            lblError.Text = "Please select city !!";
            dbCity.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtpincode.Text.Trim()))
        {
            lblError.Text = "Please Enter Pin Code !!";
            txtpincode.Focus();
            return false;
        }
        else if (!Regex.IsMatch(txtpincode.Text, "^[0-9]+$"))
        {
            lblError.Text = "Please enter only digits in pin code !!";
            txtpincode.Focus();
            return false;
        }
        else
        {
            lblError.Text = "";
            return true;
        }
    }
       

    public bool chkdata()
    {
        if (string.IsNullOrEmpty(txtapplicantname.Text.Trim()))
        {
            Error.Text = "Please Enter a name";
            txtapplicantname.Focus();
            txtapplicantname.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtapplicantname.Text.Trim()) && !Regex.IsMatch(txtapplicantname.Text, "^[a-z.A-Z ]+$"))
        {
            Error.Text = "Invalid Name, should contains the alphabets and space !!";
            txtapplicantname.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtapplicantname.Text.Trim()) && txtapplicantname.Text.Length < 6)
        {
            Error.Text = "Name should have at least 6 charactors !!";
            txtapplicantname.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtapplicantname.Text.Trim()) && txtapplicantname.Text.Length > 100)
        {
            Error.Text = "Name should be lesser than the 100 charactors !!";
            txtapplicantname.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtcontact.Text.Trim()))
        {
            Error.Text = "Mobile no should not be blank !!";
            txtcontact.Focus();
            txtcontact.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtcontact.Text) && !Regex.IsMatch(txtcontact.Text, "^[0-9]+$"))
        {
            Error.Text = "Invalid Mobile no, should be digits !!";
            txtcontact.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtcontact.Text) && txtcontact.Text.Trim().Length < 10)
        {
            Error.Text = "Mobile number should contain 10 digits !!";
            txtcontact.Focus();
            return false;
        }

        else if (!string.IsNullOrEmpty(txtcontact.Text) && txtcontact.Text.Trim().Length > 10)
        {
            Error.Text = "Mobile number should contain 10 digits !!";
            txtcontact.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtcontact.Text) && !Regex.IsMatch(txtcontact.Text, "^[7-9]{1}[0-9]{9}"))
        {
            Error.Text = "Invalid Mobile no, should start with 7, 8 or 9 !!";
            txtcontact.Focus();
            return false;
        }

        else if (string.IsNullOrEmpty(txtbusinessentity.Text.Trim()))
        {
            Error.Text = "Please Enter a name";
            txtbusinessentity.Focus();
            txtbusinessentity.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtbusinessentity.Text.Trim()) && !Regex.IsMatch(txtbusinessentity.Text, "^[a-z.A-Z ]+$"))
        {
            Error.Text = "Invalid Name, should contains the alphabets and space !!";
            txtbusinessentity.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtbusinessentity.Text.Trim()) && txtbusinessentity.Text.Length < 2)
        {
            Error.Text = "Name should be greater than the 2 charactors !!";
            txtbusinessentity.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtbusinessentity.Text.Trim()) && txtbusinessentity.Text.Length > 100)
        {
            Error.Text = "Name should be lesser than the 100 charactors !!";
            txtbusinessentity.Focus();
            return false;
        }



        else if (string.IsNullOrEmpty(txtpan.Text.Trim()))
        {
            Error.Text = "Please Enter a PAN no.";
            txtpan.Focus();
            txtpan.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtpan.Text.Trim()) && !Regex.IsMatch(txtpan.Text, "^[A-Z0-9]{10}$"))
        {
            Error.Text = "Invalid PAN no. should contains the alphabets and space !!";
            txtpan.Focus();
            return false;
        }
        //else if (!string.IsNullOrEmpty(txtpan.Text.Trim()) && txtpan.Text.Length < 2)
        //{
        //    Error.Text = "PAN no. should be greater than the 2 charactors !!";
        //    txtpan.Focus();
        //    return false;
        //}
        //else if (!string.IsNullOrEmpty(txtpan.Text.Trim()) && txtpan.Text.Length > 100)
        //{
        //    Error.Text = "PAN no. should be lesser than the 100 charactors !!";
        //    txtpan.Focus();
        //    return false;
        //}


           
        // pan card validation
        else if (string.IsNullOrEmpty(txtlastaudited.Text.Trim()))
        {
            Error.Text = "Please Enter a name";
            txtlastaudited.Focus();
            txtlastaudited.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtlastaudited.Text.Trim()) && !Regex.IsMatch(txtlastaudited.Text, "^[a-z.A-Z ]+$"))
        {
            Error.Text = "Invalid Name, should contains the alphabets and space !!";
            txtlastaudited.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtlastaudited.Text.Trim()) && txtlastaudited.Text.Length < 2)
        {
            Error.Text = "Name should be greater than the 2 charactors !!";
            txtlastaudited.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtlastaudited.Text.Trim()) && txtlastaudited.Text.Length > 100)
        {
            Error.Text = "Name should be lesser than the 100 charactors !!";
            txtlastaudited.Focus();
            return false;
        }
        else if (string.IsNullOrEmpty(txtbranch.Text.Trim()))
        {
            Error.Text = "Please Enter a name";
            txtbranch.Focus();
            txtbranch.Text = "";
            return false;
        }
        else if (!string.IsNullOrEmpty(txtbranch.Text.Trim()) && !Regex.IsMatch(txtbranch.Text, "^[a-z.A-Z ]+$"))
        {
            Error.Text = "Invalid Name, should contains the alphabets and space !!";
            txtbranch.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtbranch.Text.Trim()) && txtbranch.Text.Length < 2)
        {
            Error.Text = "Name should be greater than the 2 charactors !!";
            txtbranch.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(txtbranch.Text.Trim()) && txtbranch.Text.Length > 100)
        {
            Error.Text = "Name should be lesser than the 100 charactors !!";
            txtbranch.Focus();
            return false;
        }
        else if (checkmail() == false)
        {
            Error.Text = "Please enter valid email";
            return false;
        }
        else if (checkPAN() == false)
        {
            Error.Text = ("<script>alert('The loan Application reference number " + ackid + " with the same PAN/TAN is already in progress. Please use different PAN/TAN number')</script>");
            return false;
        }
        else if (dbcat.SelectedIndex == 0)
        {
            lblError.Text = "Select a Category you wish to apply for !";
            dbcat.Focus();
            return false;
        }
        else
        {
            lblError.Text = "";
            return true;
        }
    }


    public void mail_appl(string AppNo)
    {
        try
        {

            string mailid = null;
            string mailid1 = null;
            MailAddress ma = new MailAddress("noreply@bandhanbank.com");

            //CCD Department Email ID
            mailid = txtemailid.Text;
            //mailid1 = "sumona.chatterjee@bandhanbank.com";

            int x = 0;

            string blank1 = "";
            string strbody1 = "";
            string ImgUrl = ConfigurationManager.AppSettings.Get("imgurl");

            strbody1 = "<html><head></head><body><table align=center border=0 cellpadding=4 cellspacing=4 style='width:700px; border:solid 1px; #DA251C;' >";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; height:91px' ><img src=" + ImgUrl + ">";
            strbody1 = strbody1 + "</td></tr>";



            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' >Subject: A new application is submitted for – NRI Deposits, dated – " + DateTime.Now.ToString("dd/MM/yyyy") + "</td></tr>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' ></td></tr>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=middle ' >Following are the details:</td></tr>";




            strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Name:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Name"].ToString();
            strbody1 = strbody1 + "</td></tr>";


            strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Email Id:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Email"].ToString();
            strbody1 = strbody1 + "</td></tr>";



            strbody1 = strbody1 + "<tr><td align=left valign=top style='width:100px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#eeeeee>Mobile No.:</td><td align=left valign=top style='width:250px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>" + Session["Mobile"].ToString();
            strbody1 = strbody1 + "</td></tr>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff></td>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanks & Regards</td>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster</td>";

            strbody1 = strbody1 + "<tr><td colspan='5' align=left valign=top style='width:700px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Bandhan Bank</td>";

            strbody1 = strbody1 + "<tr><td colspan='5' style='width:700px; height:5px;' bgcolor=#ffffff></td>";

            strbody1 = strbody1 + "</table></body></html>";


            ///''''''''''''''''''''''' mail to bank
            MailMessage Mail_br = new MailMessage();
            Mail_br.From = ma;
            //Mail_br.To.Add(mailid);
            //Mail_br.To.Add(mailid1);

            string[] multi = mailid.Split(',');
            foreach (string maltimailId in multi)
            {
                Mail_br.To.Add(new MailAddress(maltimailId));
            }

            //Mail_br.CC.Add("bhupendra@chicinfotech.com");
            Mail_br.Subject = " BandhanBank : NRI";
            Mail_br.IsBodyHtml = true;
            Mail_br.Body = strbody1;

            SmtpClient smtpMailObj1 = new SmtpClient();
            smtpMailObj1.Host = "127.0.0.1";
            smtpMailObj1.Port = 25;
            smtpMailObj1.Send(Mail_br);

        }


        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }

    }


   

    //public void sendmail()
    //{
    //    string strbody3 = "";
    //    //string imgurl = ConfigurationManager.AppSettings.Get("imgurl");

    //    strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:80%; border:solid 1px; #DA251C;' >";

    //    strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='https://www.canfinhomes.com/Images/logo-ack.png'>";
    //    strbody3 = strbody3 + "</td></tr><br/>";


    //    strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:80%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#0282cd>Bandhan Acknowledgement</td></tr>";

    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


    //    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Dear " + " ,";
    //    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

    //    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Bandhan Bank";
    //    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

    //    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Your Reference No. is:<strong> " + ackid + "<strong>";
    //    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";





    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

    //    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanking You,";
    //    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

    //    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster";
    //    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

    //    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

    //    strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Can Fin Homes Ltd.";
    //    strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

    //    strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

    //    strbody3 = strbody3 + "</table></body></html>";







    //    MailMessage mailMessage = new MailMessage();
    //    mailMessage.From = new MailAddress("noreply@bandhanbank.com");
    //    mailMessage.To.Add(new MailAddress(txtemailid.Text));
    //    mailMessage.Subject = "Bandhan Bank";
    //    mailMessage.IsBodyHtml = true;
    //    mailMessage.Body = strbody3;
    //    SmtpClient client = new SmtpClient();
    //    client.Credentials = new System.Net.NetworkCredential("email1@somewebsite.com", "password");
    //    client.Host = "smtpout.asia.secureserver.net";
    //    client.Send(mailMessage);
    //}

 

    public bool chk_val1(string add1)
    {

        string not_allowed1 = "";

        not_allowed1 = "~`^'<>";
        string txtchar = "";
        string allchar = "";

        int i = 0;
        int j = 0;
        int flag1 = 0;
        int flag2 = 0;
        int charfound = 0;

        for (i = 0; i <= add1.Length - 1; i++)
        {
            txtchar = add1[i].ToString();
            charfound = 0;


            if (flag1 == 0)
            {
                for (j = 0; j <= not_allowed1.Length - 1; j++)
                {
                    allchar = not_allowed1[j].ToString();
                    flag2 = j + 1;
                    if (charfound == 0)
                    {
                        if (txtchar == allchar)
                        {
                            flag1 = flag1 + 1;
                            charfound = 1;
                        }
                    }
                }
            }
        }

        if (flag1 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    




    public void SendMail()
    {
        try
        {

            //string id = Session["refno"].ToString();
            //string mailid = null;
            //string FROM = "";
            //string HOST = "";
            //string PORT = "";
            //string USRNM = "";
            //string pswd = "";
             string ImgUrl = ConfigurationManager.AppSettings.Get("imgurl");
             string Feeback = ConfigurationManager.AppSettings.Get("feedback");
             MailAddress ma = new MailAddress("webmaster@UCObank.in", "Webmaster");

            string activationCode = Guid.NewGuid().ToString();

            //SqlCommand cmd = new SqlCommand("SP_ClosedComplaints");
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter sda = new SqlDataAdapter();

            //cmd.Parameters.AddWithValue("@RefNo", id);
            //cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
            //cmd.Parameters.AddWithValue("@Mode", "Insert");
            //cmd.Connection = con;
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            int x = 0;
            //bool(MR = False)
            string blank1 = "";
            string strbody1 = "";
            //string ImgUrl = "../Images/logo.PNG";

            //if (!string.IsNullOrEmpty(txtemailid.Text))
            //{

            //    string frmId = ConfigurationManager.AppSettings.Get("FromGrvMail");
            //    MailAddress ma = new MailAddress(frmId, "No Reply");

            //    ///'''''''''''''''''''''''''''''' mail to super admin
            //    string Imgurl = ConfigurationManager.AppSettings.Get("imgurl");

                string strbody3 = "";

                strbody3 = "<html><head></head><body><table align=center border=0 cellpadding=0 cellspacing=0 style='width:80%; border:solid 1px; #DA251C;' >";

                strbody3 = strbody3 + "<tr><td colspan='3' align=left valign=top><img src='http://localhost:59525/Bandhan Bank/Images/bandhanlogo.jpg'>";
                strbody3 = strbody3 + "</td></tr><br/>";


                strbody3 = strbody3 + "<tr><td colspan='3' align=center valign=middle style='width:80%; height:30px; font-family:Verdana; font-size:10pt; font-weight:bold; color:#ffffff;' bgcolor=#0282cd>Bandha Acknowledgement</td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";
                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";


                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Dear "+ Session["name"]+",";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Greetings from Bandhan Bank";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Your Reference No. is:<strong> " + ackid + "<strong>";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";





                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Thanking You,";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Webmaster";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:3px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td align=left valign=top style='width:10px;'></td><td align=left valign=top style='width:430px; height:20px; font-family:Verdana; font-size:9pt; font-weight:normal; color:#000000;' bgcolor=#ffffff>Bandhan Bank Ltd.";
                strbody3 = strbody3 + "</td><td align=left valign=top style='width:10px;'></td></tr>";

                strbody3 = strbody3 + "<tr><td colspan='3' style='width:450px; height:5px;' bgcolor=#ffffff></td></tr>";

                strbody3 = strbody3 + "</table></body></html>";

                MailMessage Mail_br1 = new MailMessage();
                Mail_br1.From = ma;
                if (!string.IsNullOrEmpty(txtemailid.Text))
                {
                    Mail_br1.To.Add(txtemailid.Text);
                }
                Mail_br1.Subject = "Bandhan Bank - Reply by Acknowlegment";
                Mail_br1.IsBodyHtml = true;
                Mail_br1.Body = strbody3;



                string fromemail = ConfigurationManager.AppSettings.Get("fromemail");
                string password1 = ConfigurationManager.AppSettings.Get("password");
                string host1 = ConfigurationManager.AppSettings.Get("host");
                int port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("port"));
                SmtpClient smtpMailObj1 = new SmtpClient();
                smtpMailObj1.Host = host1;
                smtpMailObj1.EnableSsl = true;
                smtpMailObj1.Credentials = new System.Net.NetworkCredential(fromemail, password1);
                smtpMailObj1.Port = port;
                smtpMailObj1.Send(Mail_br1);


            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
       // Response.Write("<script type='text/javascript'>detailedresults=window.close();</script>");

    }


       
    public string randgen()
    {

        string name = txtapplicantname.Text.Substring(0, 3);

        //string today = DateTime.Now.Date.ToShortDateString().Replace("-", "").Replace("/", "");
        StringBuilder sb = new StringBuilder();
        Random generator = new Random();
        String r = generator.Next(0, 99999999).ToString("D5");

        ackid = name + r;
        int cnt = 0;
        cn.Open();
        SqlCommand cmd = new SqlCommand("proc_msme", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
        if (ackid != "")
        {
            cmd.Parameters.AddWithValue("@refno", ackid);
        }
        cmd.Parameters["@mode"].Value = "CheckRefNo";
        cnt = Convert.ToInt32(cmd.ExecuteScalar());
        cn.Close();
        if (string.IsNullOrEmpty(ackid))
        {
            randgen();

        }
        return sb.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        {
            randgen();
            if (chkdata() == true)
            {
                    SqlCommand cmd = new SqlCommand("proc_msme", cn);
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@mode", SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@Loantype", ddlloantype.Text);
                    cmd.Parameters.AddWithValue("@LoanAmount", ddlloanamount.Text);
                    cmd.Parameters.AddWithValue("@Applicantname", txtapplicantname.Text);
                    cmd.Parameters.AddWithValue("@contactnumber", txtcontact.Text);
                    cmd.Parameters.AddWithValue("@Emailaddress", txtemailid.Text);
                    cmd.Parameters.AddWithValue("@NameofbusinessEntity", txtbusinessentity.Text);
                    cmd.Parameters.AddWithValue("@BusinessLineofActivity", ddllineofactivity.Text);
                    cmd.Parameters.AddWithValue("@TypeofFirm", ddltypeoffirm.Text);
                    cmd.Parameters.AddWithValue("@PANCINno", txtpan.Text);
                    cmd.Parameters.AddWithValue("@SalesTurnoverasperlastaudited", txtlastaudited.Text);
                    cmd.Parameters.AddWithValue("@Enternearestbranch", txtbranch.Text);
                    cmd.Parameters.AddWithValue("@Refno", ackid);
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                    cmd.Parameters["@mode"].Value = "insert";
                    cmd.ExecuteNonQuery();
                    Session["name"] = txtapplicantname.Text;
                   
                    SendMail();
                    cn.Close();
                    Session["refno"] = ackid;
                    Session["email"] = txtemailid.Text;
                    Session["mobile"] = txtcontact.Text;
                    Response.Write("data saved sucefully");
                    Response.Redirect("Acknowlegment.aspx");

                }
            
        }
    }
    protected void dbcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        }
    protected void dbcat_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (dbcat.SelectedIndex == 19)
        {

            form1.Visible = false;
            msme.Visible = true;
        }
   

    }
}

   