using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;

public partial class Admin_Manage_ProfileCapturing : System.Web.UI.Page
{
    private AdmChkClass chkclass = new AdmChkClass();
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["bb_con"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    SqlDataReader dr;
    Label lblpath1;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        lblpath1 = (Label)this.Form.Parent.FindControl("lblSmeModNm");


        if (!Page.IsPostBack)
        {
            lblpath1.Text = "Manage Other Loan Application";

            if (chkclass.Chk_ModAuth(Convert.ToString(Session["usr_id"]), "Call Back", "Manage Profiles", Convert.ToString(Session["usr_type"])) == true)
            {
                txtPageSize.Text = "25";
                txtPageIndex.Text = "1";
                clear_SrchData();
                fill_day();
                fill_year();
                fill_cat();
              

                lblmsg.Text = "";
                fill_grid();

            }
            else
            {
                Response.Redirect("~/MSMELoanTrackerAdmin/AdminLogin.aspx");
            }

        }
    }

    public void clear_SrchData()
    {
        txtName.Text = "";
        txtEmail.Text = "";
        txtmobile.Text = "";
        //txtphone.Text = "";

        cmbDD1.SelectedIndex = 0;
        cmbMM1.SelectedIndex = 0;
        cmbYY1.SelectedIndex = 0;

        cmbDD2.SelectedIndex = 0;
        cmbMM2.SelectedIndex = 0;
        cmbYY2.SelectedIndex = 0;

        dbcat.SelectedIndex = 0;
    }

    public void fill_day()
    {
        int day = 0;
        for (day = 1; day <= 31; day++)
        {
            cmbDD1.Items.Add(Convert.ToString(day));
            cmbDD2.Items.Add(Convert.ToString(day));
        }
        cmbDD1.Items.Insert(0, "DD");
        cmbDD2.Items.Insert(0, "DD");
    }

    public void fill_year()
    {
        int y1 = (DateTime.Now.Year) + 1;

        int y2 = 0;
        for (y2 = 2010; y2 <= y1; y2++)
        {
            cmbYY1.Items.Add(Convert.ToString(y2));
            cmbYY2.Items.Add(Convert.ToString(y2));

        }
        cmbYY1.Items.Insert(0, "YYYY");
        cmbYY2.Items.Insert(0, "YYYY");
    }

    public void fill_grid()
    {
        try
        {
            int cnt = 0;
            string frmdt = "";
            string todt = "";
            string phone = "";
            string mobile = "";
            string name = "";
            string Email = "";
            string cate = "";

            if (txtName.Text != "")
            {
                name = txtName.Text;
            }
            if (txtEmail.Text != "")
            {
                Email = txtEmail.Text;
            }
            if (txtmobile.Text != "")
            {
                mobile = txtmobile.Text;
            }
            //if (txtphone.Text != "")
            //{
            //    phone = txtphone.Text;
            //}

            if (!(cmbDD1.SelectedIndex == 0) & !(cmbMM1.SelectedIndex == 0) & !(cmbYY1.SelectedIndex == 0))
            {
                frmdt = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
            }

            if (!(cmbDD2.SelectedIndex == 0) & !(cmbMM2.SelectedIndex == 0) & !(cmbYY2.SelectedIndex == 0))
            {
                todt = cmbMM2.SelectedValue + "/" + cmbDD2.SelectedValue + "/" + cmbYY2.SelectedValue;
            }
            if (dbcat.SelectedIndex != 0)
            {
                cate = dbcat.SelectedValue;
            }

            con.Close();
            con.Open();
            cmd = new SqlCommand("Proc_ProfileForm",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@strproNm", name);
            cmd.Parameters.AddWithValue("@strproEmail", Email);
            cmd.Parameters.AddWithValue("@strproMob", mobile);
            cmd.Parameters.AddWithValue("@strPhone", phone);
            cmd.Parameters.AddWithValue("@strFrmDt", frmdt);
            cmd.Parameters.AddWithValue("@strToDt", todt);
            cmd.Parameters.AddWithValue("@strcate", cate);
            cmd.Parameters.AddWithValue("@Mode","cntPro");
            cnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (cnt > 0)
            {
                cmd = new SqlCommand("Proc_ProfileForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strproNm", name);
                cmd.Parameters.AddWithValue("@strproEmail", Email);
                cmd.Parameters.AddWithValue("@strproMob", mobile);
                cmd.Parameters.AddWithValue("@strPhone", phone);
                cmd.Parameters.AddWithValue("@strFrmDt", frmdt);
                cmd.Parameters.AddWithValue("@strToDt", todt);
                cmd.Parameters.AddWithValue("@strcate", cate);
                cmd.Parameters.AddWithValue("@Mode", "getPro");
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tbl_Pro");

                if (ds.Tables["tbl_Pro"].Rows.Count > 0)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = ds.Tables["tbl_Pro"].Rows.Count + " Records found !!";
                    dg_Pro.Visible = true;
                    try
                    {
                        dg_Pro.DataSource = ds.Tables["tbl_Pro"].DefaultView;
                        dg_Pro.DataBind();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    dg_Pro.DataSource = null;
                    dg_Pro.DataBind();
                    dg_Pro.Visible = false;
                    lblmsg.Text = "No records found";
                }
            }
            else 
            {
                dg_Pro.DataSource = null;
                dg_Pro.DataBind();
                dg_Pro.Visible = false;
                lblmsg.Text = "No records found";
            }
        }
        catch (Exception ex)
        {
 
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lblSrchErr.Text = "";

            if (!string.IsNullOrEmpty(txtName.Text) && chkNm(txtName.Text) == false)
            {
                lblSrchErr.Text = "Enter valid name !!";
                txtName.Focus();

            }
            else if (!string.IsNullOrEmpty(txtName.Text) && txtName.Text.Length < 3)
            {
                lblSrchErr.Text = "Name can contain minimum 3 characters !!";
                txtName.Focus();

            }
            else if (!string.IsNullOrEmpty(txtName.Text) && txtName.Text.Length > 50)
            {
                lblSrchErr.Text = "Name can contain maximum 50 characters !!";
                txtName.Focus();

            }
            else if (!string.IsNullOrEmpty(txtEmail.Text) & chk_val1(txtEmail.Text) == false)
            {
                lblSrchErr.Text = "Please enter valid Email Address !!";
                txtEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(txtEmail.Text) & !Regex.IsMatch(txtEmail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
            {
                lblSrchErr.Text = "Your email address is not in correct format !!";
                txtEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(txtEmail.Text) & txtEmail.Text.Length > 100)
            {
                lblSrchErr.Text = "Email contain maximum 100 character !!";
                txtEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(txtmobile.Text) & !Regex.IsMatch(txtmobile.Text, "^[0-9]+$"))
            {
                lblSrchErr.Text = "Please enter only digits in Mobile Number !!";
                txtmobile.Focus();
            }
            //else if (!string.IsNullOrEmpty(txtmobile.Text) & txtmobile.Text.Length < 10)
            //{
            //    lblSrchErr.Text = "Mobile Number should contain min 10 digits !!";
            //    txtmobile.Focus();
            //}
            else if (!string.IsNullOrEmpty(txtmobile.Text) & txtmobile.Text.Length > 12)
            {
                lblSrchErr.Text = "Mobile Number should contain max 12 digits !!";
                txtmobile.Focus();
            }

            //else if (!string.IsNullOrEmpty(txtphone.Text) & !Regex.IsMatch(txtphone.Text, "^[0-9]+$"))
            //{
            //    lblSrchErr.Text = "Please enter only digits in Phone Number !!";
            //    txtphone.Focus();
            //}
            //else if (!string.IsNullOrEmpty(txtphone.Text) & txtphone.Text.Length < 10)
            //{
            //    lblSrchErr.Text = "Phone Number should contain min 10 digits !!";
            //    txtphone.Focus();
            //}
            //else if (!string.IsNullOrEmpty(txtphone.Text) & txtphone.Text.Length > 14)
            //{
            //    lblSrchErr.Text = "Phone Number should contain max 12 digits !!";
            //    txtmobile.Focus();
            //}
            else if (chkDatesSrch() == false)
            {
                lblSrchErr.Text = lblSrchErr.Text;
            }
            else
            {
                lblSrchErr.Text = "";
                fill_grid();
            }

        }
        catch (Exception ex)
        {
            
        }
   }

    public bool chkDatesSrch()
    {


        if (!(cmbDD1.SelectedIndex == 0) & !(cmbMM1.SelectedIndex == 0) & !(cmbYY1.SelectedIndex == 0) & !(cmbDD2.SelectedIndex == 0) & !(cmbMM2.SelectedIndex == 0) & !(cmbYY2.SelectedIndex == 0))
        {
            if (Information.IsNumeric(cmbDD1.SelectedValue) == false)
            {
                lblSrchErr.Text = "Please select valid day for from date";
                cmbDD1.Focus();
                return false;

            }
            else if (Convert.ToInt32(cmbDD1.SelectedValue) > 31 || Convert.ToInt32(cmbDD1.SelectedValue) < 0)
            {
                lblSrchErr.Text = "Please select valid day for from date";
                cmbDD1.Focus();
                cmbDD1.SelectedIndex = 0;
                return false;

            }
            else if (Information.IsNumeric(cmbMM1.SelectedValue) == false)
            {
                lblSrchErr.Text = "Please select valid month for from date";
                cmbMM1.Focus();
                return false;

            }
            else if (Convert.ToInt32(cmbMM1.SelectedValue) > 12 | Convert.ToInt32(cmbMM1.SelectedValue) < 0)
            {
                lblSrchErr.Text = "Please select valid month for from date";
                cmbMM1.Focus();
                cmbMM1.SelectedIndex = 0;
                return false;

            }
            else if (Information.IsNumeric(cmbYY1.SelectedValue) == false)
            {
                lblSrchErr.Text = "Please select valid year for from date";
                cmbYY1.Focus();
                return false;

            }
            else if (Convert.ToInt32(cmbYY1.SelectedValue) > (DateAndTime.Now.Year + 1) | Convert.ToInt32(cmbYY1.SelectedValue) < 2010)
            {
                lblSrchErr.Text = "Please select valid year for from date";
                cmbYY1.Focus();
                cmbYY1.SelectedIndex = 0;
                return false;

            }
            else if (Information.IsNumeric(cmbDD2.SelectedValue) == false)
            {
                lblSrchErr.Text = "Please select valid day for to date";
                cmbDD2.Focus();
                return false;

            }
            else if (Convert.ToInt32(cmbDD2.SelectedValue) > 31 | Convert.ToInt32(cmbDD2.SelectedValue) < 0)
            {
                lblSrchErr.Text = "Please select valid day for to date";
                cmbDD2.Focus();
                cmbDD2.SelectedIndex = 0;
                return false;

            }
            else if (Information.IsNumeric(cmbMM2.SelectedValue) == false)
            {
                lblSrchErr.Text = "Please select valid month for to date";
                cmbMM2.Focus();
                return false;

            }
            else if (Convert.ToInt32(cmbMM2.SelectedValue) > 12 | Convert.ToInt32(cmbMM2.SelectedValue) < 0)
            {
                lblSrchErr.Text = "Please select valid month for to date";
                cmbMM2.Focus();
                cmbMM2.SelectedIndex = 0;
                return false;

            }
            else if (Information.IsNumeric(cmbYY2.SelectedValue) == false)
            {
                lblSrchErr.Text = "Please select valid year for to date";
                cmbYY2.Focus();
                return false;

            }
            else if (Convert.ToInt32(cmbYY2.SelectedValue) > (DateAndTime.Now.Year + 1) | Convert.ToInt32(cmbYY2.SelectedValue) < 2010)
            {
                lblSrchErr.Text = "Please select valid year for to date";
                cmbYY2.Focus();
                cmbYY2.SelectedIndex = 0;
                return false;

            }
            else if (check_datesSrch() == false)
            {
                lblSrchErr.Text = lblSrchErr.Text;
                cmbYY2.Focus();
                return false;

            }
            else if (compare_datesSrch() == false)
            {
                lblSrchErr.Text = lblSrchErr.Text;
                cmbYY2.Focus();
                return false;

            }
            else
            {
                lblSrchErr.Text = "";
                return true;
            }

        }
        else if (cmbDD1.SelectedIndex == 0 & cmbMM1.SelectedIndex == 0 & cmbYY1.SelectedIndex == 0 & cmbDD2.SelectedIndex == 0 & cmbMM2.SelectedIndex == 0 & cmbYY2.SelectedIndex == 0)
        {
            lblSrchErr.Text = "";
            return true;

        }
        else
        {
            if (string.IsNullOrEmpty(lblSrchErr.Text))
            {
                lblSrchErr.Text = "Please select proper from & to dates";
            }
            else
            {
                lblSrchErr.Text = lblSrchErr.Text;
            }
            return false;
        }

    }

    public bool check_datesSrch()
    {

        lblSrchErr.Text = "";
        int flag1 = 0;

        if (Convert.ToInt32(cmbMM1.SelectedValue) == 4 | Convert.ToInt32(cmbMM1.SelectedValue) == 6 | Convert.ToInt32(cmbMM1.SelectedValue) == 9 | Convert.ToInt32(cmbMM1.SelectedValue) == 11)
        {
            if (Convert.ToInt32(cmbDD1.SelectedValue) == 31)
            {
                lblSrchErr.Text = cmbMM1.SelectedItem.Text + " " + "can't have" + " " + cmbDD1.SelectedValue + " " + "days";
                flag1 = 0;
            }
            else
            {
                flag1 = flag1 + 1;
                lblSrchErr.Text = "";
            }
        }
        else
        {
            flag1 = flag1 + 1;
            lblSrchErr.Text = "";
        }

        if (flag1 >= 1)
        {
            if (Convert.ToInt32(cmbMM1.SelectedValue) == 2 & (System.DateTime.IsLeapYear(Convert.ToInt32(cmbYY1.SelectedValue))))
            {
                if (Convert.ToInt32(cmbDD1.SelectedValue) > 29)
                {
                    lblSrchErr.Text = "February" + " " + cmbYY1.SelectedValue + " " + "dosen't have" + " " + cmbDD1.SelectedValue + " " + "days";
                    flag1 = 0;
                }
                else
                {
                    flag1 = flag1 + 1;
                    lblSrchErr.Text = "";
                }

            }
            else
            {
                flag1 = flag1 + 1;
                lblSrchErr.Text = "";
            }
        }


        if (flag1 >= 2)
        {
            if (Convert.ToInt32(cmbMM1.SelectedValue) == 2 & !(System.DateTime.IsLeapYear(Convert.ToInt32(cmbYY1.SelectedValue))))
            {
                if (Convert.ToInt32(cmbDD1.SelectedValue) > 28)
                {
                    lblSrchErr.Text = "February" + " " + cmbYY1.SelectedValue + " " + "dosen't have" + " " + cmbDD1.SelectedValue + " " + "days";
                    flag1 = 0;
                }
                else
                {
                    flag1 = flag1 + 1;
                    lblSrchErr.Text = "";
                }

            }
            else
            {
                flag1 = flag1 + 1;
                lblSrchErr.Text = "";
            }
        }


        if (flag1 >= 3)
        {
            if (Convert.ToInt32(cmbMM2.SelectedValue) == 4 | Convert.ToInt32(cmbMM2.SelectedValue) == 6 | Convert.ToInt32(cmbMM2.SelectedValue) == 9 | Convert.ToInt32(cmbMM2.SelectedValue) == 11)
            {
                if (Convert.ToInt32(cmbDD2.SelectedValue) == 31)
                {
                    lblSrchErr.Text = cmbMM2.SelectedItem.Text + " " + "can't have" + " " + cmbDD2.SelectedValue + " " + "days";
                    flag1 = 0;
                }
                else
                {
                    flag1 = flag1 + 1;
                    lblSrchErr.Text = "";
                }
            }
            else
            {
                flag1 = flag1 + 1;
                lblSrchErr.Text = "";
            }
        }


        if (flag1 >= 4)
        {
            if (Convert.ToInt32(cmbMM2.SelectedValue) == 2 & (System.DateTime.IsLeapYear(Convert.ToInt32(cmbYY2.SelectedValue))))
            {
                if (Convert.ToInt32(cmbDD2.SelectedValue) > 29)
                {
                    lblSrchErr.Text = "February" + " " + cmbYY2.SelectedValue + " " + "dosen't have" + " " + cmbDD2.SelectedValue + " " + "days";
                    flag1 = 0;
                }
                else
                {
                    flag1 = flag1 + 1;
                    lblSrchErr.Text = "";
                }

            }
            else
            {
                flag1 = flag1 + 1;
                lblSrchErr.Text = "";
            }
        }


        if (flag1 >= 5)
        {
            if (Convert.ToInt32(cmbMM2.SelectedValue) == 2 & !(System.DateTime.IsLeapYear(Convert.ToInt32(cmbYY2.SelectedValue))))
            {
                if (Convert.ToInt32(cmbDD2.SelectedValue) > 28)
                {
                    lblSrchErr.Text = "February" + " " + cmbYY2.SelectedValue + " " + "dosen't have" + " " + cmbDD2.SelectedValue + " " + "days";
                    flag1 = 0;
                }
                else
                {
                    flag1 = flag1 + 1;
                    lblSrchErr.Text = "";
                }

            }
            else
            {
                flag1 = flag1 + 1;
                lblSrchErr.Text = "";
            }
        }


        if (flag1 == 0)
        {
            if (string.IsNullOrEmpty(lblSrchErr.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (flag1 >= 6)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool compare_datesSrch()
    {

        string frmDt = "";
        string toDt = "";

        DateTime frmDt1 = default(DateTime);
        DateTime toDt1 = default(DateTime);

        DateTimeFormatInfo dtfi1 = new DateTimeFormatInfo();
        dtfi1.ShortDatePattern = "MM/dd/yyyy";
        dtfi1.DateSeparator = "/";

        frmDt = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
        toDt = cmbMM2.SelectedValue + "/" + cmbDD2.SelectedValue + "/" + cmbYY2.SelectedValue;

        frmDt1 = Convert.ToDateTime(frmDt, dtfi1);
        toDt1 = Convert.ToDateTime(toDt, dtfi1);

        if (frmDt1 > toDt1)
        {
            lblSrchErr.Text = "From date must be less than to date";
            return false;
        }
        else
        {
            lblSrchErr.Text = "";
            return true;
        }

    }

    public bool chkNm(string data1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_. ";
        int ALLOW_FLAG = 0;

        string txtchar = "";
        string allchar = "";

        int i = 0;
        int j = 0;
        int next1 = 0;

        int flag1 = 0;
        int flag2 = 0;
        int charfound = 0;

        for (i = 0; i <= data1.Length - 1; i++)
        {
            txtchar = Convert.ToString(data1[i]);
            charfound = 0;
            if (flag1 == i)
            {
                for (j = 0; j <= allowed1.Length - 1; j++)
                {
                    allchar = Convert.ToString(allowed1[j]);
                    flag2 = j + 1;
                    if (charfound == 0)
                    {
                        if (txtchar == allchar)
                        {
                            flag1 = flag1 + 1;
                            charfound = 1;
                        }
                        else
                        {
                            charfound = 0;
                        }
                    }
                }
            }
        }

        if (flag1 == data1.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        clear_SrchData();
        fill_grid();
    }

    protected void dg_Pro_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.SelectedItem | e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.EditItem)
        {
            string Date = "";
            string MobileNo = "";
            string PhoneNo = "";
            string name = "";
            string title = "";
            string City = "";
            string Pincode = "";
            string refno = "";
            System.DateTime submit_dt = default(System.DateTime);
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "submitDt")) == false)
            {
                submit_dt = (DateTime)DataBinder.Eval(e.Item.DataItem, "submitDt");
                Date = submit_dt.ToString("dd/MM/yyyy");
            }
            else
            {
                Date = "";
            }
            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Contact_No")) == false)
            {
                MobileNo = (string)DataBinder.Eval(e.Item.DataItem, "Contact_No");
            }
            else
            {
                MobileNo = "";
            }
            //if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PhoneNo")) == false)
            //{
            //    PhoneNo = (string)DataBinder.Eval(e.Item.DataItem, "PhoneNo");
            //}
            //else
            //{
            //    PhoneNo = "";
            //}

            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "Name")) == false)
            {
                name = (string)DataBinder.Eval(e.Item.DataItem, "Name");
            }
            else
            {
                name = "";
            }



            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "City")) == false)
            {
                City = (string)DataBinder.Eval(e.Item.DataItem, "City");
            }
            else
            {
                City = "";
            }

            if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "PinCode")) == false)
            {
                Pincode = (string)DataBinder.Eval(e.Item.DataItem, "PinCode");
            }
            else
            {
                Pincode = "";
            }

              if (Information.IsDBNull(DataBinder.Eval(e.Item.DataItem, "RefferenceNo")) == false)
              {
                refno = (string)DataBinder.Eval(e.Item.DataItem, "RefferenceNo");
              }
            else
            {
                refno = "--";
            }



              ((Label)e.Item.Cells[2].FindControl("lblrefno")).Text = refno;
              ((Label)e.Item.Cells[2].FindControl("lnkname")).Text = name;
            ((Label)e.Item.Cells[2].FindControl("LnkDetails")).Text ="City:"+ City +"</br>" +"Pincode:"+Pincode;
            ((Label)e.Item.Cells[2].FindControl("lblSubDate")).Text = "Sub date - " + Date;
            ((Label)e.Item.Cells[2].FindControl("lblContact")).Text = "Mobile No.- " + MobileNo;
            ((LinkButton)e.Item.Cells[4].FindControl("lnkDelete")).Attributes.Add("onclick", "javascript: return confirm('Are you sure you want to delete this Profile?')");
        }
    }

    protected void dg_Pro_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                string Id=e.Item.Cells[0].Text;
                int cnt=0;

                if (e.CommandName == "Delete")
                {
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("Proc_ProfileForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strID", Id);
                    cmd.Parameters.AddWithValue("@Mode","delPro");
                    cnt = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (cnt > 0)
                    {
                        lblmessage.Text = "Profile deleted successfully.";
                        fill_grid();
                    }
                    con.Close();
                }
            }
        }
        catch(Exception ex)
        {
        
        }
    }

    protected void dg_Pro_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text))
            {
                if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
                {
                    dg_Pro.PageSize = Convert.ToInt32(txtPageSize.Text);
                }
            }

            int pg_index = 0;
            if (!string.IsNullOrEmpty(txtPageIndex.Text))
            {
                if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
                {
                    pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;
                }
            }

            dg_Pro.CurrentPageIndex = e.NewPageIndex;
            fill_grid();

            string x1 = Convert.ToString(dg_Pro.CurrentPageIndex);
            int currPage = Convert.ToInt32(x1) + 1;
            string x2 = Convert.ToString(dg_Pro.PageCount);

            txtPageIndex.Text = Convert.ToString(currPage);
            lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";
            if (string.IsNullOrEmpty(txtPageSize.Text))
            {
                int n = dg_Pro.Items.Count;
                txtPageSize.Text = Convert.ToString(n);
            }

        }
        catch (Exception ex)
        {
        }
    }

    protected void btnPageSize_Click(object sender, EventArgs e)
    {
        if (txtPageSize.Text != "" && !Regex.IsMatch(txtPageSize.Text, "^[0-9]+$"))
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Enter only digits";
            txtPageSize.Focus();
        }


        else if (txtPageSize.Text != "" && (!(Convert.ToInt32(txtPageSize.Text) < 0) & Convert.ToInt32(txtPageSize.Text) > 0))
        {
            dg_page_indexSize();
        }
        else
        {
            txtPageSize.Text = "";
        }
    }

    protected void btnPageIndex_Click(object sender, EventArgs e)
    {
        if (txtPageIndex.Text != "" && !Regex.IsMatch(txtPageIndex.Text, "^[0-9]+$"))
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Enter only digits";
            txtPageIndex.Focus();
        }
        else if (txtPageIndex.Text != "" && !(Convert.ToInt32(txtPageIndex.Text) < 0))
        {
            dg_page_indexSize();
        }
        else
        {
            txtPageIndex.Text = "";
        }
    }

    public void dg_page_indexSize()
    {
        if (!string.IsNullOrEmpty(txtPageSize.Text))
        {
            if (!string.IsNullOrEmpty(txtPageSize.Text) & Information.IsNumeric(txtPageSize.Text) == true)
            {
                dg_Pro.PageSize = Convert.ToInt32(txtPageSize.Text);
            }
        }

        int pg_index = 0;
        if (!string.IsNullOrEmpty(txtPageIndex.Text))
        {
            if (!string.IsNullOrEmpty(txtPageIndex.Text) & Information.IsNumeric(txtPageIndex.Text) == true)
            {
                if (Convert.ToInt32(txtPageIndex.Text) != 0)
                {
                    pg_index = Convert.ToInt32(txtPageIndex.Text) - 1;
                    dg_Pro.CurrentPageIndex = pg_index;
                }
            }
        }

        fill_grid();

        string x1 = Convert.ToString(dg_Pro.CurrentPageIndex);
        int currPage = Convert.ToInt32(x1) + 1;
        string x2 = Convert.ToString(dg_Pro.PageCount);
        txtPageIndex.Text = Convert.ToString(currPage);
        lblPageIndex.Text = "Page" + " " + currPage + " " + "of" + " " + x2 + " " + ". Skip to page";

        if (string.IsNullOrEmpty(txtPageSize.Text))
        {
            int n = dg_Pro.Items.Count;
            txtPageSize.Text = Convert.ToString(n);
        }

    }

    public void fill_cat()
    {
        try
        {
            int cnt = 0;
            con.Open();
            cmd = new SqlCommand("Proc_ProfileForm", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "cntcat");
            cnt = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (cnt > 0)
            {
                con.Open();
                cmd = new SqlCommand("Proc_ProfileForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", "getcatForMSMEProfCap");
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tbl_desi");
                con.Close();
                if (ds.Tables["tbl_desi"].Rows.Count > 0)
                {
                    dbcat.Items.Clear();
                    dbcat.DataSource = ds.Tables["tbl_desi"].DefaultView;
                    dbcat.DataTextField = "Category";
                    dbcat.DataValueField = "Category";
                    dbcat.DataBind();
                    dbcat.Items.Insert(0, "All");
                    dbcat.SelectedIndex = 0;
                }
                else
                {
                    dbcat.Items.Clear();
                    dbcat.Items.Insert(0, "All");
                    dbcat.SelectedIndex = 0;
                }
            }
            else
            {
                dbcat.Items.Clear();
                dbcat.Items.Insert(0, "All");
                dbcat.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        try
        {
            lblSrchErr.Text = "";

            if (!string.IsNullOrEmpty(txtName.Text) && chkNm(txtName.Text) == false)
            {
                lblSrchErr.Text = "Enter valid name !!";
                txtName.Focus();

            }
            else if (!string.IsNullOrEmpty(txtName.Text) && txtName.Text.Length < 3)
            {
                lblSrchErr.Text = "Name can contain maximum 50 characters !!";
                txtName.Focus();

            }
            else if (!string.IsNullOrEmpty(txtName.Text) && txtName.Text.Length > 50)
            {
                lblSrchErr.Text = "Name can contain maximum 50 characters !!";
                txtName.Focus();

            }
            else if (!string.IsNullOrEmpty(txtEmail.Text) & chk_val1(txtEmail.Text) == false)
            {
                lblSrchErr.Text = "Please enter valid Email Address !!";
                txtEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(txtEmail.Text) & !Regex.IsMatch(txtEmail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
            {
                lblSrchErr.Text = "Your email address is not in correct format !!";
                txtEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(txtEmail.Text) & txtEmail.Text.Length > 100)
            {
                lblSrchErr.Text = "Email contain maximum 100 character !!";
                txtEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(txtmobile.Text) & !Regex.IsMatch(txtmobile.Text, "^[0-9]+$"))
            {
                lblSrchErr.Text = "Please enter only digits in Mobile Number !!";
                txtmobile.Focus();
            }
            else if (!string.IsNullOrEmpty(txtmobile.Text) & txtmobile.Text.Length > 12)
            {
                lblSrchErr.Text = "Mobile Number should contain max 12 digits !!";
                txtmobile.Focus();
            }
            else if (chkDatesSrch() == false)
            {
                lblSrchErr.Text = lblSrchErr.Text;
            }
            else
            {
                lblSrchErr.Text = "";

                string frmdt = "";
                string todt = "";
                string name = "";
                string email = "";
                string mobi = "";
                string cate = "";

                if (!(cmbDD1.SelectedIndex == 0) & !(cmbMM1.SelectedIndex == 0) & !(cmbYY1.SelectedIndex == 0))
                {
                    frmdt = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
                }

                if (!(cmbDD2.SelectedIndex == 0) & !(cmbMM2.SelectedIndex == 0) & !(cmbYY2.SelectedIndex == 0))
                {
                    todt = cmbMM2.SelectedValue + "/" + cmbDD2.SelectedValue + "/" + cmbYY2.SelectedValue;
                }

                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    name = Regex.Replace(txtName.Text, "'", "''");

                }
                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    email = Regex.Replace(txtEmail.Text, "'", "''");

                }
                if (!string.IsNullOrEmpty(txtmobile.Text))
                {
                    mobi = Regex.Replace(txtmobile.Text, "'", "''");

                }
                if (dbcat.SelectedIndex != 0)
                {
                    cate = Regex.Replace(dbcat.SelectedValue, "'", "''");
                }
                int cnt1 = 0;
                con.Open();
                cmd = new SqlCommand("Proc_ProfileForm", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@strproNm", name);
                cmd.Parameters.AddWithValue("@strproEmail", email);
                cmd.Parameters.AddWithValue("@strproMob", mobi);
                cmd.Parameters.AddWithValue("@strFrmDt", frmdt);
                cmd.Parameters.AddWithValue("@strToDt", todt);
                cmd.Parameters.AddWithValue("@strcate", cate);
                cmd.Parameters["@Mode"].Value = "cntPro";
                cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (cnt1 > 0)
                {
                    con.Open();
                    cmd = new SqlCommand("Proc_ProfileForm", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
                    cmd.Parameters.AddWithValue("@strproNm", name);
                    cmd.Parameters.AddWithValue("@strproEmail", email);
                    cmd.Parameters.AddWithValue("@strproMob", mobi);
                    cmd.Parameters.AddWithValue("@strFrmDt", frmdt);
                    cmd.Parameters.AddWithValue("@strToDt", todt);
                    cmd.Parameters.AddWithValue("@strcate", cate);
                    cmd.Parameters["@Mode"].Value = "getPro";
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds, "tbl_ApplicationExcel");
                    con.Close();

                    if (ds.Tables["tbl_ApplicationExcel"].Rows.Count != 0)
                    {
                        /////////////////////////// generate excel

                        ////-------------------------------------------------------------
                        ////-------------------- Generate Excel File---------------------
                        ////-------------------------------------------------------------

                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.Charset = "";

                        //HttpContext.Current.Response.ContentType = "application/msexcel"

                        //int day1 = Day(DateTime.Now);
                        //int mon11 = Day(Now.Date);
                        //string year1 As Integer = Day(Now.Date);

                        string FileNm1 = "ApplicationDetails_" + DateTime.Now.ToString("dd-MMM-yyyy");
                        string strFileName = FileNm1 + ".xls";

                        string selected_period = "";

                        string frmDt1 = "";
                        string toDt1 = "";

                        if (!(cmbDD1.SelectedIndex == 0) & !(cmbMM1.SelectedIndex == 0) & !(cmbYY1.SelectedIndex == 0))
                        {
                            frmDt1 = cmbMM1.SelectedValue + "/" + cmbDD1.SelectedValue + "/" + cmbYY1.SelectedValue;
                        }

                        if (!(cmbDD2.SelectedIndex == 0) & !(cmbMM2.SelectedIndex == 0) & !(cmbYY2.SelectedIndex == 0))
                        {
                            toDt1 = cmbMM2.SelectedValue + "/" + cmbDD2.SelectedValue + "/" + cmbYY2.SelectedValue;
                        }

                        if (frmDt1 != "" && toDt1 != "")
                        {

                            selected_period = "Period Selected :- " + frmDt1 + " " + "-" + " " + toDt1;
                        }
                        else
                        {
                            selected_period = "";
                        }


                        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName);
                        StringBuilder strHTMLContent = new StringBuilder();

                        strHTMLContent.Append("<table align='Center' border='1' cellpadding='2' cellspacing='0'>".ToString());

                        string imgurl = ConfigurationManager.AppSettings["imgurl"];

                        strHTMLContent.Append("<tr><td style='height:86px' colspan='9' align='left' bgcolor='#002F55'><img src=" + imgurl + " border='0' /></td></tr>".ToString());

                        strHTMLContent.Append("<tr><td style='width:500px; height:10px;' colspan='9' align='center' bgcolor='#ffffff'></td></tr>".ToString());

                        if (selected_period != "")
                        {
                            strHTMLContent.Append("<tr><td style='width:500px; height:30px; font-family:Verdana; font-size:14pt; color:#ffffff;' valign='middle' colspan='9' align='left' bgcolor='#002F55'><b>Applications Submitted [ " + selected_period + " ]</b></td></tr>".ToString());
                        }
                        else
                        {
                            strHTMLContent.Append("<tr><td style='width:500px; height:30px; font-family:Verdana; font-size:14pt; color:#ffffff;' valign='middle' colspan='9' align='left' bgcolor='#002F55'><b>Applications Submitted</b></td></tr>".ToString());
                        }

                        strHTMLContent.Append("<tr><td style='width:500px; height:10px;' colspan='9' align='center' bgcolor='#ffffff'></td></tr>".ToString());

                        strHTMLContent.Append("<tr style= align='center'>".ToString());
                        strHTMLContent.Append("<td style='width:50px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Sr.No.</td>".ToString());
                        strHTMLContent.Append("<td style='width:60px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Ref. No.</td>".ToString());
                        strHTMLContent.Append("<td style='width:60px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Name</td>".ToString());
                        strHTMLContent.Append("<td style='width:60px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>City</td>".ToString());
                        strHTMLContent.Append("<td style='width:60px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Pin Code</td>".ToString());
                        
                        strHTMLContent.Append("<td style='width:100px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Applied For</td>".ToString());
                        strHTMLContent.Append("<td style='width:150px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Submission Date</td>".ToString());
                        strHTMLContent.Append("<td style='width:200px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Contact No</td>".ToString());
                        strHTMLContent.Append("<td style='width:200px; height:20px; font-family:Verdana; font-size:9pt; color:#FFFFFF;' bgcolor='#002F55' align='center' valign='middle'><b>Email</td>".ToString());
                        strHTMLContent.Append("</tr>".ToString());

                        for (int i = 0; i <= ds.Tables["tbl_ApplicationExcel"].Rows.Count - 1; i++)
                        {

                            string id1 = "";
                            string nm1 = "";
                            string FullName1 = "";
                            string mob1 = "";
                            string email1 = "";
                            string submitdt = "";
                            string GrievReDt = "";
                            string GrievT = "";
                            string pincode = "";
                            string city = "";
                            string refno = "";

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["id"]) == false)
                            {
                                id1 = ds.Tables["tbl_ApplicationExcel"].Rows[i]["id"].ToString();

                            }
                            else
                            {
                                id1 = "";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["Name"]) == false)
                            {
                                nm1 = ds.Tables["tbl_ApplicationExcel"].Rows[i]["Name"].ToString();
                            }
                            else
                            {
                                nm1 = "";
                            }

                            if (nm1 != "")
                            {
                                FullName1 = nm1;
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["Category"]) == false)
                            {
                                GrievT = ds.Tables["tbl_ApplicationExcel"].Rows[i]["Category"].ToString();
                            }
                            else
                            {
                                GrievT = "";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["Contact_No"]) == false)
                            {
                                mob1 = ds.Tables["tbl_ApplicationExcel"].Rows[i]["Contact_No"].ToString();
                            }
                            else
                            {
                                mob1 = "--";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["Email_Id"]) == false)
                            {
                                email1 = ds.Tables["tbl_ApplicationExcel"].Rows[i]["Email_Id"].ToString();
                            }
                            else
                            {
                                email1 = "--";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["City"]) == false)
                            {
                                city = ds.Tables["tbl_ApplicationExcel"].Rows[i]["City"].ToString();
                            }
                            else
                            {
                                city = "--";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["PinCode"]) == false)
                            {
                                pincode = ds.Tables["tbl_ApplicationExcel"].Rows[i]["PinCode"].ToString();
                            }
                            else
                            {
                                pincode = "--";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["RefferenceNo"]) == false)
                            {
                                refno = ds.Tables["tbl_ApplicationExcel"].Rows[i]["RefferenceNo"].ToString();
                            }
                            else
                            {
                                refno = "--";
                            }
                         

                         

                            System.DateTime SubDt1 = default(System.DateTime);
                            if (Information.IsDBNull(ds.Tables["tbl_ApplicationExcel"].Rows[i]["submitDt"]) == false)
                            {
                                SubDt1 = Convert.ToDateTime(ds.Tables["tbl_ApplicationExcel"].Rows[i]["submitDt"]);
                                submitdt = SubDt1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                submitdt = "";
                            }

                          
                            int count = i + 1;

                            strHTMLContent.Append("<tr bgcolor='#ffffff'>".ToString());
                            strHTMLContent.Append("<td style='width:50px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='center' valign='top'>" + count + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:150px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='left' valign='top'>" + refno + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:150px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='left' valign='top'>" + FullName1 + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:150px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='left' valign='top'>" + city + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:150px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='left' valign='top'>" + pincode + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:250px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='center' valign='top'>" + GrievT + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:100px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='center' valign='top'>" + submitdt + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:200px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='left' valign='top'>" + mob1 + "</td>".ToString());
                            strHTMLContent.Append("<td style='width:80px; height:20px; font-family:Verdana; font-size:9pt; color:#000000;' align='left' valign='top'>" + email1 + "</td>".ToString());
                            strHTMLContent.Append("</tr>".ToString());

                        }

                        strHTMLContent.Append("<tr> ".ToString());
                        strHTMLContent.Append("<td style='width:500px' colspan='6' align='center' bgcolor='#FFFFFF'></td>".ToString());
                        strHTMLContent.Append("</tr>".ToString());

                        strHTMLContent.Append("</table>".ToString());

                        strHTMLContent.Append("<br><br>".ToString());
                        strHTMLContent.Append("<p align='Center'> Note : This is a dynamically generated Excel document".ToString());
                        HttpContext.Current.Response.Write(strHTMLContent);

                        HttpContext.Current.Response.End();
                        HttpContext.Current.Response.Flush();

                        ////////////////////////////// generate excel
                    }

                    ////////////////////////////// end of count of data
                }
                ////////////////////////////////// end of data validation
            }
        }
        catch (Exception ex)
        {

        }
    }

}