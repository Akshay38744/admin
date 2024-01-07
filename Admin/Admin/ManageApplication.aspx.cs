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
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
using ClosedXML.Excel;
using System.IO;

public partial class MSME_ManageApplication : System.Web.UI.Page
{
    private AdmChkClass chkclass = new AdmChkClass();
    //private Audit_trail audtclass = new Audit_trail();
    SqlDataAdapter da = new SqlDataAdapter();
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    public AdmPrpty adm = new AdmPrpty();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["bb_con"].ToString());
    Label lblpath1 = new Label();

    string today = DateTime.Now.ToString("dd/MM/yyyy");
    string strMessage;

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    string FromDate = "";
    string ToDate = "";
    string SubmitDate = "";
    DateTime dtFromDate;
    DateTime dtToDate;
    DateTime dtSubmitDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        lblpath1 = (Label)this.Form.Parent.FindControl("lblSmeModNm");


        if (!Page.IsPostBack)
        {
            lblpath1.Text = "Manage MSME Loan Application";
            if (chkclass.Chk_ModAuth(Convert.ToString(Session["usr_id"]), "Manage Application", "Manage Application", Convert.ToString(Session["usr_type"])) == true)
            {
                lblerr.Text = "";
                clear();
                lblAddMainHead.Text = "Search MSME Loan Application";
                trUpdate.Visible = false;
                FillStatus();
                trTblData.Visible = true;
                dg_MSMEApp.Visible = true;
                fill_grid();
            }
            else
            {
                Response.Redirect("~/MSMELoanTrackerAdmin/AdminLogin.aspx");
            }
        }
        
    }
    public void FillStatus()
    {
        try
        {

            con.Open();
            cmd = new SqlCommand("proc_msme", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", System.Data.SqlDbType.VarChar, 20));
            cmd.Parameters["@Mode"].Value = "getStatus";
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds, "tbl_Main2");
            con.Close();
            if (!(ds.Tables["tbl_Main2"].Rows.Count == 0))
            {
                ddlStatus.Items.Clear();
                ddlStatus.DataSource = ds.Tables["tbl_Main2"];
                ddlStatus.DataTextField = "Status";
                // ddlStatus.DataValueField = "StateId";
                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, "Select Status");
                ddlStatus.SelectedIndex = 0;

            }
            else
            {
                ddlStatus.Items.Clear();
                ddlStatus.Items.Insert(0, "Select Status");
                ddlStatus.SelectedIndex = 0;

            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public bool ChkData()
    {
        DateTime dt5 = DateTime.MinValue;
        DateTime dt3 = DateTime.MinValue;
        DateTime dt4 = DateTime.MinValue;
        string today = DateTime.Now.ToString("dd/MM/yyyy");
        DateTimeFormatInfo dateFormat = new DateTimeFormatInfo();
        dateFormat.DateSeparator = "/";

        if (txtFromDate.Text != "") 
        {
            //txtFromdt.Text = dt;

            DateTime.TryParseExact(txtFromDate.Text, "dd/MM/yyyy", dateFormat, DateTimeStyles.AllowWhiteSpaces, out dt5);

        }
        if (txtToDate.Text != "")
        {
            DateTime.TryParseExact(txtToDate.Text, "dd/MM/yyyy", dateFormat, DateTimeStyles.AllowWhiteSpaces, out dt3);

        }
        if (today != "")
        {
            DateTime.TryParseExact(today, "dd/MM/yyyy", dateFormat, DateTimeStyles.AllowWhiteSpaces, out dt4);
        }
        if (txtFromDate.Text == "")
        {
            lblmsg.Text = "Select From Date";
            txtFromDate.Focus();
            return false;
        }
        if (txtToDate.Text == "")
        {
            lblmsg.Text = "Select To Date";
            txtToDate.Focus();
            return false;
        }
        if (dt5 > dt3)
        {
            lblmsg.Text = "From date should not be greater than to date";
            //   sendmessage.Attributes.Add("class", "sendmessage show error");
            txtFromDate.Focus();
            return false;
        }
        else if (dt3 > dt4)
        {
            lblmsg.Text = "To date should not be greater than today's date";
            //   sendmessage.Attributes.Add("class", "sendmessage show error");
            txtToDate.Focus();
            return false;
        }

        else
        {
            return true;
        }

    }

    public void clear()
    {
        Session["DeptEdit"] = "";
        txtRefNo.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        FillStatus();
        fill_grid();
        lblMainMsg.Text = "";
    }

    public void fill_grid()
    
    {
        
        try
        {
            int cnt1 = 0;
            con.Open();
            cmd = new SqlCommand("SP_SrchMSMEApplication", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType","cntMSMEApp");
            
            cnt1 = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (cnt1 > 0)
            {
                con.Open();
                cmd = new SqlCommand("SP_SrchMSMEApplication", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ddlStatus.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedItem.Text);
                }
                if (txtRefNo.Text != "")
                {
                    cmd.Parameters.AddWithValue("@RefNo", txtRefNo.Text.ToString().Trim());
                }
                if (txtFromDate.Text != "")
                {
                    cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.ToString());
                }
                if (txtToDate.Text != "")
                {
                    cmd.Parameters.AddWithValue("@ToDate",txtToDate.Text.ToString());
                }
                cmd.Parameters.AddWithValue("@QueryType", "Search");
               

             
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "tbl_MSMELoan");
                con.Close();

                if (!(ds.Tables["tbl_MSMELoan"].Rows.Count == 0))
                {
                    lblmsg.Text = ds.Tables["tbl_MSMELoan"].Rows.Count + " Records found !!";
                    dg_MSMEApp.Visible = true;
                    try
                    {
                        dg_MSMEApp.DataSource = ds.Tables["tbl_MSMELoan"].DefaultView;
                        dg_MSMEApp.DataBind();
                    }
                    catch
                    {
                        try
                        {
                            this.dg_MSMEApp.CurrentPageIndex = 0;
                            this.dg_MSMEApp.DataBind();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.ToString());
                        }
                    }
                }
                else
                {
                    dg_MSMEApp.DataSource = null;
                    dg_MSMEApp.DataBind();
                    dg_MSMEApp.Visible = false;
                    lblmsg.Text = "No Record Found";
                }

            }
            else
            {
                dg_MSMEApp.DataSource = null;
                dg_MSMEApp.DataBind();
                dg_MSMEApp.Visible = false;
                lblmsg.Text = "No Record Found";
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
    }




    protected void dg_MSMEApp_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            string id = e.Item.Cells[0].Text;
            string Refno = e.Item.Cells[2].Text;
            string Name= e.Item.Cells[3].Text;
            string Date = e.Item.Cells[4].Text;
            string Status = e.Item.Cells[5].Text;
            string Email = e.Item.Cells[7].Text.Replace("&nbsp;","");
            string Mobile = e.Item.Cells[8].Text;
           
            

            if (e.CommandName == "Edit")
            {
                lblmsg.Visible = false;
                trTblData.Visible = false;
                dg_MSMEApp.Visible = false;
                lblEditErr.Text = "";
                Session["id"] = id;
                clear();
                trSearch.Visible = false;
                trUpdate.Visible = true;

                txtUpdRef.Text = Refno;
                txtApplicantName.Text = Name;
                txtEmail.Text = Email;
                txtMobile.Text = Mobile;
                txtSubmtDate.Text = Date;

                txtStatus.Text = Status;
              
                
             
            }
            else if (e.CommandName == "Delete")
            {
                Session["id"] = id;

                con.Open();
                cmd = new SqlCommand("SP_SrchMSMEApplication", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@QueryType", SqlDbType.VarChar, 20));
                cmd.Parameters.AddWithValue("@id",Session["id"]);
                cmd.Parameters["@QueryType"].Value = "DelMSMEApp";
                cmd.ExecuteNonQuery();
                con.Close();

                lblEditErr.Text = "Application deleted successfully.";                
               

                fill_grid();
            }
        }
    }


    protected void dg_MSMEApp_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {

        dg_MSMEApp.CurrentPageIndex = e.NewPageIndex;
        fill_grid();
    }



    protected void BtnReset_Click(object sender, EventArgs e)
    {
        clear();
    }
    public bool chkrefno(string data1)
    {
        string allowed1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789/";
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

    public bool Validate()
    {
        //if(txtRefNo.Text == "" && txtRefNo.Text == null)
        //{
        //    lblEditErr.Text ="Enter Reference Number";
        //    txtRefNo.Focus();
        //    return false;
        //}

        //if(txtRefNo.Text != "" &&  chkrefno(txtRefNo.Text) == false)
        //{
        //    lblEditErr.Text ="Reference Number you have entered is not in correct format !!";
        //    txtRefNo.Focus();
        //    return false;
        //}
        if(txtApplicantName.Text =="" && txtApplicantName.Text == null)
        {
            strMessage = "Enter Applicant name <br />";
            txtApplicantName.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtApplicantName.Text) && txtApplicantName.Text.Length <=5  && Regex.IsMatch(txtApplicantName.Text, "@^[A-Za-z ]+$" ))
        {
            strMessage += "Initials are not allowed in Applicant name <br />";
            txtApplicantName.Focus();
            return false;
        }
         if (!string.IsNullOrEmpty(txtApplicantName.Text) && txtApplicantName.Text.Length >=50  && Regex.IsMatch(txtApplicantName.Text, "@^[A-Za-z ]+$" ))
        {
            strMessage += "Full name should be of minimum 50 characters <br />";
            txtApplicantName.Focus();
            return false;
        }
        if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
        {
            strMessage += "Please Enter Email-ID";
            txtEmail.Focus();
            return false;
        }
        if (!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text.Trim(), "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
        {
            strMessage += "In-Valid Email-ID !!";
            txtEmail.Focus();
            return false;
        }
        if(txtMobile.Text == "" && txtMobile.Text == null)
        {
            strMessage += "Enter Mobile Number !!";
            txtMobile.Focus();
            return false;
        }
        if (!Regex.IsMatch(txtMobile.Text, @"^([7-9]{1})([0-9]{9})$"))
        {
            strMessage += "In-Valid Mobile Number !!";
            txtMobile.Focus();
            return false;
        }
        if(txtStatus.Text == "")
        {
            strMessage += "Enter Status to be update !!";
            txtStatus.Focus();
            return false;        
        }
       
        else
        {
            return true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int cnt = 0;
       

             try
             {
                 if (Validate() == true)
                 {

                     con.Open();
                     cmd = new SqlCommand("SP_SrchMSMEApplication", con);

                    
                         cmd.Parameters.AddWithValue("@RefNo", txtUpdRef.Text.ToString().Trim());                     
                     
                         cmd.Parameters.AddWithValue("@Name", txtApplicantName.Text.ToString().Trim());

                         cmd.Parameters.AddWithValue("@SubmitDate", txtSubmtDate.Text.ToString());                     
                   
                         cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.ToString().Trim());
                   
                         cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString().Trim());

                         cmd.Parameters.AddWithValue("@Status", txtStatus.Text.ToString().Trim());

                       
                     
                        
                     
                         cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Session["id"]));

                         cmd.Parameters.AddWithValue("@QueryType", "Update");

                     cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     cnt = Convert.ToInt32(cmd.ExecuteScalar());
                     con.Close();
                     if (cnt > 0)
                     {
                         trEditErr.Visible = true;
                         lblEditErr.Text = "Application Updated Successfully";
                         FillStatus();
                         txtApplicantName.Text = "";
                         txtEmail.Text = "";
                         txtMobile.Text = "";
                         txtSubmtDate.Text = "";
                         txtStatus.Text = "";
                       
                         trUpdate.Visible = true;
                         
                         txtUpdRef.Text = "";
                         fill_grid();
                     }
                     else
                     {
                         lblEditErr.Text = "Application Not Found";
                     }
                 }
                 else
                 {
                     trEditErr.Visible = true;
                     lblEditErr.Text = strMessage;
                 }
             }
             catch
             {

             }
             finally
             {
                 con.Close();
             }
               

    }

    public void Reset()
    {
       
        txtApplicantName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtSubmtDate.Text = "";
        txtStatus.Text = "";
        
        trUpdate.Visible = true;
        
        txtUpdRef.Text = "";
        trSearch.Visible = true;
        trUpdate.Visible = false;

        
    }
    protected void BtnUpReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        trTblData.Visible = true;
        fill_grid();
    }
    
    public void Excel()
    {  
                con.Open();
                cmd = new SqlCommand("SP_SrchMSMEApplication", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (ddlStatus.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
                }
                if (txtRefNo.Text != "")
                {
                    cmd.Parameters.AddWithValue("@RefNo", txtRefNo.Text.ToString().Trim());
                }
                if (txtFromDate.Text != "")
                {
                    cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.ToString());
                }
                if (txtToDate.Text != "")
                {
                    cmd.Parameters.AddWithValue("@ToDate",txtToDate.ToString());
                }
                cmd.Parameters.AddWithValue("@QueryType", "Search");
               

             
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds, "tbl_MSMELoan");
                DataTable dt= new DataTable();
                dt=ds.Tables["tbl_MSMELoan"];
                con.Close();
                XLWorkbook wb = new XLWorkbook();
                dt.Columns.Remove("id");

                DataColumnCollection columns = dt.Columns;
                dt.TableName = "Sheet1";
                var ws = wb.Worksheets.Add(dt);
                dt.Columns.RemoveAt(0);
                ws.Row(1).InsertRowsAbove(1);
                ws.Row(1).InsertRowsBelow(1);
        
         if (txtFromDate.Text != "" && txtToDate.Text != "")
         {

             ws.Cell(1, 1).Value = "MSME Loan Applications for Period " + txtFromDate.Text + " To " + txtToDate.Text.Trim();
             ws.Range("A1:H1").Row(1).Merge();
             ws.Range("A2:H2").Row(1).Merge();
             ws.Row(2).Height = 30;
             ws.Range("A1:H1").Row(1).Style.Fill.BackgroundColor = XLColor.AshGrey;
             ws.Row(2).Style.Font.FontSize = 14;
             ws.Row(2).Style.Font.Bold = true;
             ws.Row(1).Height = 30;
             ws.Range("A1:H1").Row(1).Style.Fill.BackgroundColor = XLColor.AshGrey;
             ws.Row(1).Style.Font.FontSize = 14;
             ws.Row(1).Style.Font.Bold = true;

         }
         else
         {

             ws.Cell(1, 1).Value = "All MSME Loan Applications";
             ws.Range("A1:H1").Row(1).Merge();
             ws.Range("A2:H2").Row(1).Merge();
             ws.Row(2).Height = 30;
             ws.Range("A1:H1").Row(1).Style.Fill.BackgroundColor = XLColor.AshGrey;
             ws.Row(2).Style.Font.FontSize = 14;
             ws.Row(2).Style.Font.Bold = true;
             ws.Row(1).Height = 30;
             ws.Range("A1:H1").Row(1).Style.Fill.BackgroundColor = XLColor.AshGrey;
             ws.Row(1).Style.Font.FontSize = 14;
             ws.Row(1).Style.Font.Bold = true;
         }




         Response.Clear();
         Response.Buffer = true;
         Response.Charset = "";
         Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
         Response.AddHeader("content-disposition", "attachment;filename=MSMELoanApplication.xlsx");
         MemoryStream MyMemoryStream = new MemoryStream();

         wb.SaveAs(MyMemoryStream);
         MyMemoryStream.WriteTo(Response.OutputStream);
         Response.Flush();
         Response.End();
     

    
    }
   
    protected void BtnExport_Click1(object sender, EventArgs e)
    {
        Excel();
    }
    
}