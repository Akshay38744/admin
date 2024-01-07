<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster1.master" AutoEventWireup="true" CodeFile="Track.aspx.cs" Inherits="Track" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="../css/fonts.css">
<link rel="stylesheet" type="text/css" href="../css/common.css">
<link rel="stylesheet" type="text/css" href="../css/apply-now.css">
<link rel="icon" href="../images/logo.ico" type="image/icon">
    <link href="css/apply-now.css" rel="stylesheet" type="text/css" />


    <link href="css/apply-now.css" rel="stylesheet" type="text/css" />

<link rel="shortcut icon" href="http://www.exemple.com/favicon.ico" type="image/icon">

<script type = "text/javascript" >
    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="breadCrumbs">
         <%-- <a href="#">Apply Now</a>--%>
        </div>
        <!-- breadCrumbs end -->
        <div>
        </div>

        <form id="form1">
    <div>
    <div> <h1 class="inner-page-title center-page-title" align="center">
                       Track Status</h1>
                   
    </div>

    </div>

    <div>
      <div class="innerform">
      <p><asp:Label ID="lblerror" 
                                    runat="server" CssClass="ErrLbl"></asp:Label></p>
            <p align="right">
                (*) Marked fields are mandatory</p>
            <ul class="formList">
                <li>
                    <label>
                       Reference No.:</label>
                    <asp:TextBox ID="RefNo" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter your reference number"></asp:TextBox>
                </li>
                <li>
                    <label>
                        PAN/CIN no.</label>
                    <asp:TextBox ID="txtpan" runat="server" EnableViewState="False" MaxLength="50"
                        title="Email" autocomplete="off" 
                        placeholder="Please Enter your PAN/CIN no."></asp:TextBox>
                </li>
                <li>
                    <label>
                        Type the code as shown :</label>
                    <asp:TextBox ID="txtCaptcha" runat="server" EnableViewState="False" MaxLength="50"
                        title="Email" autocomplete="off" placeholder="Please Enter Your Captcha"></asp:TextBox>
                </li>

                <li>
                <div class="capchaTab">
                  <div class="capchaImg">
                  <cc1:captchacontrol ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6" CaptchaHeight="31" CaptchaWidth="120"
               CaptchaLineNoise="None" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" Height="31px" BorderColor="#E7E4D3"
               BackColor="#E7E4D3"  BorderStyle="Solid" BorderWidth="1px" Font-Italic="true" ForeColor="#7A6802" class="capchaImg"/>
                  </div>
                 
                </div>
              </li>
            
                 </ul>
                        <div class="submitRow">
                           
                            
                            <br />
                        </div>


                        <div style="margin-left: 40px">

                        <asp:Button ID="Button1" runat="server" class="btn" Text="Track Status" 
                                onclick="Button1_Click" />
                               
                                
                        </div>
              
               
                       
                        

                       
                                
                 
               
            </ul>
           
            <br />

            
        </div>
    </div>
    </form>
        </div>
</asp:Content>

