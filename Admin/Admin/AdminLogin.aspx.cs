using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_AdminLogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["bb_con"]);
    SqlDataAdapter da = new SqlDataAdapter();
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        txtlogin.Focus();

        if (!Page.IsPostBack)
        {
            clear_data();
            lblmsg.Text = "";
            Session["uid"] = "";
            Session["log_name"] = "";
            Session["usr_type"] = "";
            Session["usr_dept"] = "";
            Session["log_prevlg"] = "";
            Session["current_mod"] = "";
            Session.Clear();
            Session["CaptchaImageText"] = GenerateRandomCode().ToString();

        }

    }

    private string DecryptData(string StrData)
    {
        //' FUNCTION HAS BEEN ADDED  ON 20th March, 2011
        string StrNewData = string.Empty;
        int IntAsc = 0;
        string StrChar = string.Empty;

        for (int IntCounter = 0; IntCounter <= StrData.Length - 1; IntCounter++)
        {
            IntAsc = Convert.ToInt32(StrData.Substring(IntCounter, 3));
            StrChar = Strings.Chr(IntAsc).ToString();

            StrNewData = StrNewData + StrChar;

            IntCounter = IntCounter + 2;
        }

        return StrNewData;
    }


    public void clear_data()
    {
        txtlogin.Text = "";
        string blank1 = "";
        txtpassword.Attributes.Add("value", blank1);
        txtcaptcha.Text = "";
        Session["CaptchaImageText"] = GenerateRandomCode().ToString();
    }



    public bool chk_data()
    {

        if (string.IsNullOrEmpty(txtlogin.Text))
        {
            lblmsg.Text = "Username cannot be blank !";
            txtlogin.Focus();
            return false;

        }
        else if (chk_unm(txtlogin.Text) == false)
        {
            lblmsg.Text = "Enter valid username !";
            txtlogin.Focus();
            return false;

        }
        else if (txtlogin.Text.Length < 6)
        {
            lblmsg.Text = "Username should be minimum 6 characters. !";
            txtlogin.Focus();
            return false;

        }
        else if (!string.IsNullOrEmpty(txtlogin.Text) & txtlogin.Text.Length > 20)
        {
            txtlogin.Text = txtlogin.Text.Substring(0, 20);
            lblmsg.Text = "Username can contain maximum 20 characters. !";
            txtlogin.Focus();
            return false;

        }

        else if (string.IsNullOrEmpty(txtpassword.Text))
        {
            lblmsg.Text = "Password cannot be blank !";
            txtpassword.Focus();
            return false;

        }
        else if (chk_unm(txtpassword.Text) == false)
        {
            lblmsg.Text = "Enter valid password !";
            txtpassword.Focus();
            return false;

        }
        else if (txtpassword.Text.Length < 8)
        {
            lblmsg.Text = "Password should be minimum 8 characters. !";
            txtpassword.Focus();
            return false;

        }
        else if (txtlogin.Text == txtpassword.Text)
        {
            lblmsg.Text = "Username and password can not be same !";
            txtlogin.Focus();
            return false;

        }
        else if (!string.IsNullOrEmpty(txtcaptcha.Text) & !Regex.IsMatch(txtcaptcha.Text, "^[a-z0-9A-Z]+$"))
        {
            lblmsg.Text = "Enter valid text as shown in below image";
            txtcaptcha.Text = "";
            txtcaptcha.Focus();
            return false;

        }
        else
        {
            lblmsg.Text = "";
            return true;
        }

    }



    public bool chk_unm(string add1)
    {

        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$&()";
        //Dim allowed1 As String = "ab12 "
        int ALLOW_FLAG = 0;

        string txtchar = "";
        string allchar = "";

        int i = 0;
        int j = 0;
        int next1 = 0;

        int flag1 = 0;
        int flag2 = 0;
        int charfound = 0;

        for (i = 0; i <= add1.Length - 1; i++)
        {
            txtchar = add1[i].ToString();

            charfound = 0;


            if (flag1 == i)
            {
                for (j = 0; j <= allowed1.Length - 1; j++)
                {
                    allchar = allowed1[j].ToString();
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

        if (flag1 == add1.Length)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private string GenerateRandomCode()
    {
        Random random1 = new Random();
        string s = "";
        for (int i = 0; i <= 5; i++)
        {
            s = s + random1.Next(10).ToString();
        }
        Session["CaptchaImageText"] = s;
        return s;

    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string EncryptPassword = this.DecryptData(this.txtpassword.Text);

            if (chk_data() == true)
            {

                lblmsg.Text = "";

                string capcha = txtcaptcha.Text;
                ccJoin.ValidateCaptcha(capcha);

                if (ccJoin.UserValidated == false)
                {
                    lblmsg.Text = "The text you typed as shown in the below image is incorrect !!";
                }
                else
                {
                    lblmsg.Text = "";
                    string encrypPwd = Encryptn.GetMD5HashData(EncryptPassword);
                    int cnt1 = 0;

                    con.Open();
                    cmd = new SqlCommand("Proc_AdmLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@strLogNm", txtlogin.Text.Replace("'", "''").Replace("<", ""));
                    cmd.Parameters.AddWithValue("@strPassword", encrypPwd.Replace("'", "''").Replace("<", ""));
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                    cmd.Parameters["@Mode"].Value = "LogMSMECnt";
                    cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();


                    if (cnt1 > 0)
                    {
                        lblmsg.Text = "";

                        string LogAct1 = "";

                        con.Open();
                        cmd = new SqlCommand("Proc_AdmLog", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@strLogNm", txtlogin.Text.Replace("'", "''").Replace("<", ""));
                        cmd.Parameters.AddWithValue("@strPassword", encrypPwd.Replace("'", "''").Replace("<", ""));
                        cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                        cmd.Parameters["@Mode"].Value = "LogMSMEChkAct";
                        if (Information.IsDBNull(cmd.ExecuteScalar()) == false)
                        {
                            LogAct1 = Convert.ToString(cmd.ExecuteScalar());
                        }
                        else
                        {
                            LogAct1 = "N";
                        }
                        con.Close();

                        if (LogAct1 == "Y")
                        {

                            lblmsg.Text = "";
                            con.Open();
                            cmd = new SqlCommand("Proc_AdmLog", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@strLogNm", txtlogin.Text.Replace("'", "''").Replace("<", ""));
                            cmd.Parameters.AddWithValue("@strPassword", encrypPwd.Replace("'", "''").Replace("<", ""));
                            cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 20));
                            cmd.Parameters["@Mode"].Value = "LogMSMEChk";
                            da.SelectCommand = cmd;
                            da.Fill(ds, "tbl_chklogin");

                            string logpwd = ds.Tables["tbl_chklogin"].Rows[0]["log_pwd"].ToString();

                            if (logpwd == encrypPwd)
                            {
                                if (!(ds.Tables["tbl_chklogin"].Rows.Count == 0))
                                {
                                    string logname = null;

                                    if (Convert.IsDBNull(ds.Tables["tbl_chklogin"].Rows[0]["log_name"]) == false)
                                    {
                                        logname = ds.Tables["tbl_chklogin"].Rows[0]["log_name"].ToString();


                                        if (Convert.IsDBNull(ds.Tables["tbl_chklogin"].Rows[0]["log_name"]) == false)
                                        {
                                            Session["log_name"] = logname.Trim();
                                            string newguid = null;
                                            newguid = Guid.NewGuid().ToString();
                                            Session["AuthToken"] = newguid;
                                            Response.Cookies.Add(new HttpCookie("AuthToken", newguid));
                                        }
                                        else
                                        {
                                            Session["log_name"] = "";
                                            Session["AuthToken"] = "";
                                        }

                                        if (Convert.IsDBNull(ds.Tables["tbl_chklogin"].Rows[0]["log_id"]) == false)
                                        {
                                            Session["usr_id"] = ds.Tables["tbl_chklogin"].Rows[0]["log_id"];
                                        }
                                        else
                                        {
                                            Session["usr_id"] = "";
                                        }

                                        if (Convert.IsDBNull(ds.Tables["tbl_chklogin"].Rows[0]["usr_type"]) == false)
                                        {
                                            Session["usr_type"] = ds.Tables["tbl_chklogin"].Rows[0]["usr_type"];
                                        }
                                        else
                                        {
                                            Session["usr_type"] = "";
                                        }

                                        string Dept = "";
                                        if (Convert.IsDBNull(ds.Tables["tbl_chklogin"].Rows[0]["usr_dept"]) == false)
                                        {
                                            Dept = ds.Tables["tbl_chklogin"].Rows[0]["usr_dept"].ToString();
                                            Session["usr_dept"] = Dept;
                                        }
                                        else
                                        {
                                            Dept = "";
                                        }
                                        Response.Redirect("~/MSMELoanTrackerAdmin/AmdMainPg.aspx");
                                    }
                                    else
                                    {
                                        lblmsg.Text = "";
                                        lblmsg.Text = "Please Enter Password";
                                        clear_data();
                                        Session["usr_id"] = "";
                                        Session["log_name"] = "";
                                        Session["usr_dept"] = "";
                                        Session["usr_type"] = "";
                                        Session["current_mod"] = "";
                                        Session.Clear();
                                        txtlogin.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    lblmsg.Text = "Please enter valid Login name and password !!";
                                    clear_data();
                                    Session["usr_id"] = "";
                                    Session["log_name"] = "";
                                    Session["current_mod"] = "";
                                    Session.Clear();
                                    txtlogin.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                lblmsg.Text = "Your login authority is inactive !!";
                                clear_data();
                                Session["usr_id"] = "";
                                Session["log_name"] = "";
                                Session["current_mod"] = "";
                                Session.Clear();
                                txtlogin.Focus();
                                return;
                            }
                        }
                        else
                        {
                            lblmsg.Text = "Your login authority is inactive !!";
                            clear_data();
                            Session["usr_id"] = "";
                            Session["log_name"] = "";
                            Session["usr_dept"] = "";
                            Session["usr_type"] = "";
                            Session["current_mod"] = "";
                            Session.Clear();
                            GenerateRandomCode();
                        }
                    }
                    else
                    {

                        lblmsg.Text = "Please enter valid username and password !!";
                        clear_data();
                        Session["usr_id"] = "";
                        Session["log_name"] = "";
                        Session["usr_dept"] = "";
                        Session["usr_type"] = "";
                        Session["current_mod"] = "";
                        Session.Clear();
                        GenerateRandomCode();
                    }
                }
            }
        }

        catch (Exception ex)
        {
            //Response.Write(ex.ToString())
            string ma1 = "";
            ma1 = ex.ToString();

            if (!ma1.Contains("Thread was being aborted"))
            {
                try
                {
                    con.Close();
                    string ErrorPath = System.Configuration.ConfigurationManager.AppSettings["ErrorLogPath"];
                    StreamWriter sw = new StreamWriter(ErrorPath + "ErrorLog" + DateAndTime.Now.ToString("yyyyddmm") + ".txt", true);
                    sw.WriteLine(ex.Message);
                    sw.Write(ex.StackTrace);
                    sw.Close();
                    Response.Redirect("ErrorPg.aspx");
                }
                catch
                {
                }
            }
        }
    }
}