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

public partial class Track : System.Web.UI.Page
{

    SqlCommand cmd = new SqlCommand();
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["bb_con"]);
    SqlDataAdapter da = new SqlDataAdapter();
    System.Data.DataSet ds = new System.Data.DataSet();
    string Id;
    protected void Page_Load(object sender, EventArgs e)
    {


    }


    public void clear()
    {
        txtCaptcha.Text = "";
        txtpan.Text = "";
        RefNo.Text = "";
    }

    public bool checkData()
    {
        if (string.IsNullOrEmpty(RefNo.Text.Trim()))
        {
            lblerror.Text = "Reference no can not be blank";
            RefNo.Focus();
            return false;
        }
        else if (!string.IsNullOrEmpty(RefNo.Text) && chkrefno(RefNo.Text) == false)
        {
            lblerror.Text = "Reference no you have entered is not in correct format !!";
            RefNo.Focus();
            return false;
        }


        //else if (string.IsNullOrEmpty(txtCaptcha.Text.Trim()))
        //{
        //    lblerror.Text = "Captcha code field can not be blank !!";
        //    txtCaptcha.Focus();
        //    return false;
        //}
        //else if (!string.IsNullOrEmpty(txtCaptcha.Text.Trim()) && !Regex.IsMatch(txtCaptcha.Text, "^[a-zA-Z0-9]+$"))
        //{
        //    lblerror.Text = "Enter valid verification code as shown in the image !!";
        //    txtCaptcha.Focus();
        //    return false;
        //}
        return true;
    }
    public bool chkrefno(string data1)
    {
        string allowed1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789/";
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
                            //flag1 = 0
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
    protected void Button1_Click(object sender, EventArgs e)
    {



        Session["RefNo"] = "";
        Session["Name"] = "";
        Session["Email"] = "";
        Session["GrievStatus"] = "";
        //Session["ApplicationFlag"] = "";
        Session["Id"] = "";
        Session["CaptchaImageText"] = "";
        try
        {
            string tempString = Session["CaptchaImageText"].ToString();
            if (checkData() == true)
            {
                string capcha = txtCaptcha.Text;
                ccJoin.ValidateCaptcha(capcha);
                if (ccJoin.UserValidated == false)
                {
                    lblerror.Text = "The text you typed as shown in image is incorrect !!";
                }
                else
                {
                    cn.Open();
                    int count = 0;
                    lblerror.Text = "";
                    cmd = new SqlCommand("proc_msme", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));


                    if (!string.IsNullOrEmpty(RefNo.Text.Trim()))
                    {
                        cmd.Parameters.AddWithValue("@Refno", RefNo.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtpan.Text))
                    {
                        cmd.Parameters.AddWithValue("@PANCINno", txtpan.Text);
                    }

                    cmd.Parameters["@Mode"].Value = "CheckDet";
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    cn.Close();

                    if (count > 0)
                    {
                        cn.Open();
                        lblerror.Text = "";
                        cmd = new SqlCommand("proc_msme", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Mode", SqlDbType.VarChar, 50));
                        if (!string.IsNullOrEmpty(RefNo.Text.Trim()))
                        {
                            cmd.Parameters.AddWithValue("@Refno", RefNo.Text.Trim());
                        }
                        if (!string.IsNullOrEmpty(txtpan.Text.Trim()))
                        {
                            cmd.Parameters.AddWithValue("@PANCINno", txtpan.Text.Trim());
                        }


                        cmd.Parameters["@Mode"].Value = "CheckAppDet";
                        da.SelectCommand = cmd;
                        da.Fill(ds, "tbl_data");
                        cn.Close();
                        string RefNo1;
                        string status;
                        string PANCINno;
                        string Applicantname;
                        if (!(ds.Tables["tbl_data"].Rows.Count == 0))
                        {

                            if (Information.IsDBNull(ds.Tables["tbl_data"].Rows[0]["Refno"]) == false)
                            {
                                RefNo1 = ds.Tables["tbl_data"].Rows[0]["Refno"].ToString();
                            }
                            else
                            {
                                RefNo1 = "";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_data"].Rows[0]["Applicantname"]) == false)
                            {
                                Applicantname = ds.Tables["tbl_data"].Rows[0]["Applicantname"].ToString();
                            }
                            else
                            {
                                Applicantname = "";
                            }

                            if (Information.IsDBNull(ds.Tables["tbl_data"].Rows[0]["PANCINno"]) == false)
                            {
                                PANCINno = ds.Tables["tbl_data"].Rows[0]["PANCINno"].ToString();
                            }
                            else
                            {
                                PANCINno = "";
                            }
                            if (Information.IsDBNull(ds.Tables["tbl_data"].Rows[0]["Status"]) == false)
                            {
                                status = ds.Tables["tbl_data"].Rows[0]["Status"].ToString();
                            }
                            else
                            {
                                status = "";
                            }

                            Session["RefNo"] = RefNo1;
                            Session["PANCINno"] = PANCINno;

                            Session["status"] = status;
                            Session["Applicantname"] = Applicantname;
                            clear();
                            Response.Redirect("GrievanceStatus.aspx");
                        }
                        else
                        {
                            Session["RefNo"] = "";
                            Session["status"] = "";
                            Session["PANCINno"] = "";

                            Session["Id"] = "";
                            clear();
                            lblerror.Text = "No record found !!!";
                        }
                    }
                    else
                    {
                        Session["RefNo"] = "";
                        Session["status"] = "";

                        Session["Id"] = "";
                        clear();
                        lblerror.Text = "No record found !!!";
                    }
                }
            }
        }


        catch (Exception ex)
        {

        }
        finally
        {
            cn.Close();
        }

    }
}


    
