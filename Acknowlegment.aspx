<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster1.master" AutoEventWireup="true" CodeFile="Acknowlegment.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="../css/fonts.css">
<link rel="stylesheet" type="text/css" href="../css/common.css">
<link rel="stylesheet" type="text/css" href="../css/apply-now.css">
<link rel="icon" href="../images/logo.ico" type="image/icon">


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
        <div class="productDetails">
          <h2>&nbsp;&nbsp;Acknowledgement</h2>
          <p>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            <br />
                            <div>We have got your details and our person will contact you shortly.</div></br>

                            <div>Your application reference number is: <asp:Label ID="lblref" runat="server"></asp:Label></div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <div>Please note this number for future communication.</div>     
                                                    Thank you for contacting us.
                            <br /><br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           Our representative will contact you shortly.                         
                            <br /><br />
                           
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Regards,<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Webmaster<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Bandhan Bank.
          </p>
        </div>
</asp:Content>

