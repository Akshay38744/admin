using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;
using ClosedXML.Excel;
using System.Net;
using System.Net.Mail;
using System.Collections;

public partial class MSMELoanTrackerAdmin_BulkUpload : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataSet ds = new DataSet();
    static DataProperties prop = new DataProperties();
    static DataFunctions func = new DataFunctions();
    Validation valid_obj = new Validation();
    AdmChkClass chkclass = new AdmChkClass();
    SqlDataAdapter sda;
    DataTable dt = new DataTable();
    DateTime mgdt1 = default(DateTime);
    DateTimeFormatInfo dtfi1 = new DateTimeFormatInfo();
    DateTime mgdt = default(DateTime);
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    string ipaddr = "";
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["bb_con"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (chkclass.Chk_ModAuth(Convert.ToString(Session["usr_id"]), "Bulk Upload", "Bulk Upload", Convert.ToString(Session["usr_type"])) == true)
        {
            ipaddr = HttpContext.Current.Request.UserHostAddress; 
        }
        else
        {
            Response.Redirect("~/MSMELoanTrackerAdmin/AdminLogin.aspx");
        
        }
        
    }
   
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Path.GetFileName(FileUpload1.PostedFile.FileName)))
            {
                lbldwnerr.Visible = true;
                lbldwnerr.Text = "Select File to upload.";
            }
            else if (checkRealFileattach(FileUpload1) == false)
            {
                lbldwnerr.Visible = true;
                lbldwnerr.Text = "Please select appropriate file having file extension like .txt ";
                FileUpload1.Focus();
            }
            else
            {
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
               
                if (extension == ".txt")
                {
                    prop.Procname = "SP_BulkUpload";
                    prop.key = "bb_con";
                    prop.ExeType = ExecuteType.ExecuteNonQuery;
                    string[] arrPara12 = new string[1];
                    string[] arrVal12 = new string[1];
                    prop.arrPara = arrPara12;
                    prop.arrParaValues = arrVal12;

                    arrPara12[0] = "@Mode";
                    arrVal12[0] = "TruncateTemptable";
                    func.Add_sqlPara(prop);

                    DateTime dt = DateTime.Now;
                    string Timeonly = dt.ToString("yyyyMMddhhmmssfff");

                    string csvPath = Server.MapPath("~/MSMELoanTrackerAdmin/StatusBulkUpload/") + Timeonly + extension;
                    FileUpload1.SaveAs(csvPath);
                    StreamReader objReader;
                    objReader = new StreamReader(csvPath);
                    string excelPath = Timeonly + extension;
                    string sLine = "";
                    ArrayList arrText = new ArrayList();
                    DataTable dtExcelData = new DataTable();
                    dtExcelData.Columns.AddRange(new DataColumn[2] { new DataColumn("arr1", typeof(string)),
                    new DataColumn("arr2", typeof(string))
                    });


                    objReader.ReadLine();
                    while (!objReader.EndOfStream)
                    {
                        arrText.Add(sLine);
                        string arr1, arr2;
                        string line = objReader.ReadLine();
                        //String value = new String();
                        string[] value = new string[2];
                        value = line.Split('|');
                        arr1 = value[0];
                        arr2 = value[1];
                       

                        SqlCommand cmd = new SqlCommand();


                        string conString = string.Empty;
                        conString = string.Format(excelPath);
                        dtExcelData.Rows.Add(value[0], value[1]);
                    }


                    string consString = (ConfigurationSettings.AppSettings["bb_con"].ToString());

                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {


                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "tbl_Store_Staging";
                        sqlBulkCopy.ColumnMappings.Add("arr1", "RefNo");                        
                        sqlBulkCopy.ColumnMappings.Add("arr2", "Status");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                        int dscnt;
                        using (SqlCommand cmd = new SqlCommand("select COUNT(*) as result from tbl_Store_Staging where RefNo Not IN (select RefNo from tbl_MSMEApplication_Master)", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            object o = cmd.ExecuteScalar();
                            dscnt = Convert.ToInt32(o);
                            con.Close();
                        }



                        prop.Procname = "SP_BulkUpload";
                        prop.key = "bb_con";
                        prop.ExeType = ExecuteType.ExecuteNonQuery;
                        string[] arrPara111 = new string[1];
                        string[] arrVal111 = new string[1];
                        prop.arrPara = arrPara111;
                        prop.arrParaValues = arrVal111;

                        arrPara111[0] = "@Mode";
                        arrVal111[0] = "InsertMaintable";
                        func.Add_sqlPara(prop);

                        prop.Procname = "SP_BulkUpload";
                        prop.key = "bb_con";
                        prop.ExeType = ExecuteType.ExecuteNonQuery;
                        string[] arrPara9 = new string[1];
                        string[] arrVal9 = new string[1];
                        prop.arrPara = arrPara9;
                        prop.arrParaValues = arrVal9;

                        arrPara9[0] = "@Mode";
                        arrVal9[0] = "UpdateMainTbl";
                        func.Add_sqlPara(prop);

                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                        int updtcnt = 0;
                        object abc = "";
                        using (SqlCommand cmd = new SqlCommand("select count(RefNo) as cnt from tbl_Msmeloan", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();

                            updtcnt = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }

                        if (updtcnt > 0)
                        {
                            lblupdtcnt.Text = "<br>Total " + updtcnt + " records Updated successfully.";
                        }
                        else
                        {
                            lblupdtcnt.Text = "<br>No records Updated.";
                        }
                        lbldwnerr.Text = dscnt + " records inserted successfully.";
                        //lnkfailedrecord.Visible = true;

                    }
                }
                else
                {
                    lbldwnerr.Text = "Please upload txt file";
                }

            }

        }
        catch (Exception ex)
        {
            Response.Write(ex);
            Response.End();
            lbldwnerr.Text = "There is some discrepancy in your data. Kindly rectify the some and upload again !!!";
        }
    }
    public bool checkRealFileattach(FileUpload passfile)
    {
        if (passfile.HasFile)
        {
            if (passfile.PostedFile.ContentType == "text/plain")
            {
                passfile.PostedFile.SaveAs(Server.MapPath("~\\MSMELoanTrackerAdmin\\StatusBulkUpload") + "\\" + passfile.FileName);
                if (HasMzSignatureattch(Server.MapPath("~\\MSMELoanTrackerAdmin\\StatusBulkUpload\\" + passfile.FileName)))
                {
                    FileInfo fd = new FileInfo(Server.MapPath("~\\MSMELoanTrackerAdmin\\StatusBulkUpload\\" + passfile.FileName));
                    fd.Delete();
                    return false;
                }
                else
                {
                    FileInfo fd = new FileInfo(Server.MapPath("~\\MSMELoanTrackerAdmin\\StatusBulkUpload\\" + passfile.FileName));
                    fd.Delete();
                    return true;
                }
            }
            else
            {
                FileInfo fd = new FileInfo(Server.MapPath("~\\MSMELoanTrackerAdmin\\StatusBulkUpload\\" + passfile.FileName));
                fd.Delete();
                return false;
            }
        }
        System.GC.Collect();
        return true;
    }
    public static bool HasMzSignatureattch(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    double mzSignature = reader.ReadInt16();
                    if (mzSignature == 0x5a4d)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        catch
        {

        }
        return false;
    }

    protected void DownloadButton_Click(object sender, EventArgs e)
    {
        var filePath = "~/MSMELoanTrackerAdmin/BulkUploadFiles/UpdateStatus.txt";
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "attachment; filename=UpdateStatus.txt");
        Response.TransmitFile(filePath);
        Response.End();
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MSMELoanTrackerAdmin/AmdMainpg.aspx");
    }
}