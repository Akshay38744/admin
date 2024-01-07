<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster5.master" AutoEventWireup="true" CodeFile="ApplyNow.aspx.cs" Inherits="English_ApplyNow" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/apply-now.css">
    <link rel="Stylesheet" type="text/css" href="css/common.css" />
<script src="../js/jquery.min.js"></script>
<script src="js/jquery.selectbox.js"></script>

    <link href="css/apply-now.css" rel="stylesheet" type="text/css" />
    <script src="js/apply-now.js" type="text/javascript"></script>
    <script src="js/menu.js" type="text/javascript"></script>
    <script src="js/jquery.min.js" type="text/javascript"></script>

<script async src="https://www.googletagmanager.com/gtag/js?id=AW-818150473"></script> 
<script>    window.dataLayer = window.dataLayer || []; function gtag() { dataLayer.push(arguments); } gtag('js', new Date()); gtag('config', 'AW-818150473'); </script> 

<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-66840886-1"></script>
<script>
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());

    gtag('config', 'UA-66840886-1');
</script>


<!-- Facebook Pixel Code -->
<script>
    !function (f, b, e, v, n, t, s) {
        if (f.fbq) return; n = f.fbq = function () {
            n.callMethod ?
  n.callMethod.apply(n, arguments) : n.queue.push(arguments)
        };
        if (!f._fbq) f._fbq = n; n.push = n; n.loaded = !0; n.version = '2.0';
        n.queue = []; t = b.createElement(e); t.async = !0;
        t.src = v; s = b.getElementsByTagName(e)[0];
        s.parentNode.insertBefore(t, s)
    } (window, document, 'script',
  'https://connect.facebook.net/en_US/fbevents.js');
    fbq('init', '164454367525488');
    fbq('track', 'PageView');
</script>
<noscript><img height="1" width="1" style="display:none"
  src="https://www.facebook.com/tr?id=164454367525488&ev=PageView&noscript=1"
/></noscript>
<!-- End Facebook Pixel Code -->

<script type="text/javascript">

    function validate_form() {

        //////////////////////***********************Category********************///////////////////

        if (document.getElementById('<%=dbcat.ClientID%>').selectedIndex == 0) {
            alert(' Please select a Category you wish to apply for')
            document.getElementById('<%=dbcat.ClientID%>').focus();
            return false;
        }

         /////////////////////*****************Name***********///////////////////

         if (document.getElementById('<%=txtName.ClientID%>').value == "") {
             alert('Please enter your name');
             document.getElementById('<%=txtName.ClientID%>').focus();
             return false;
         }
         if (document.getElementById('<%=txtName.ClientID%>').value != "") {
             var regex = /^[a-zA-Z ]*$/;
             if (!document.getElementById('<%=txtName.ClientID%>').value.match(regex)) {

                 alert('Please enter only alphabets in name');
                 document.getElementById('<%=txtName.ClientID%>').focus();
                 return false;
             }
         }
         if (document.getElementById('<%=txtName.ClientID%>').value != "") {
             str = document.getElementById('<%=txtName.ClientID%>').value
             if (str.length < 3) {
                 alert('Please enter your full name');
                 document.getElementById('<%=txtName.ClientID%>').focus();
                 return false;
             }
         }
         if (document.getElementById('<%=txtName.ClientID%>').value != "") {
             str = document.getElementById('<%=txtName.ClientID%>').value
             if (str.length > 50) {
                 alert('Name can contain maximum 50 characters')
                 document.getElementById('<%=txtName.ClientID%>').focus();
                 return false;
             }
         }

         ////////////////////////////************Email***********************////////////////////////////

         if (document.getElementById('<%=txtemail.ClientID%>').value == "") {
             alert('Email Id cannot be Blank')
             document.getElementById('<%=txtemail.ClientID%>').focus();
             return false;
         }

         email1 = document.getElementById('<%=txtemail.ClientID%>').value
         var regex1 = /^[a-zA-Z0-9@.]*$/;
         if (!email1.match(regex1)) {
             alert("Your email address is not in correct format!!!")
             document.getElementById('<%=txtemail.ClientID%>').focus();
             return false;
         }

         if (!email1.match(/^([a-zA-Z0-9])+([.a-zA-Z0-9_-])*@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-]+)+/)) {
             alert("Your email address is not in correct format")
             document.getElementById('<%=txtemail.ClientID%>').focus();
             return false;
         }

         if (document.getElementById('<%=txtemail.ClientID%>').value != "") {
             str = document.getElementById('<%=txtemail.ClientID%>').value
             if (str.length > 50) {
                 alert('Email contain maximum 50 character')
                 document.getElementById('<%=txtemail.ClientID%>').focus();
                 return false
             }
         }
         
         //////////////////////////////////////******************Check For Numeric*******************/////////////////////////

         if (document.getElementById('<%=txtMobileNo.ClientID%>').value != "") {
             var expr = /^[0-9]+$/;
             if (!document.getElementById('<%=txtMobileNo.ClientID%>').value.match(expr)) {

                 alert('Please enter only digits in Mobile Number');
                 document.getElementById('<%=txtMobileNo.ClientID%>').focus();
                 return false;
             }
         }

         ////////////////////////////////////*******************Contact*****************************///////////////////////////////////

         if (document.getElementById('<%=txtMobileNo.ClientID%>').value == "") {
             alert('Please enter your mobile number');
             document.getElementById('<%=txtMobileNo.ClientID%>').focus();
             return false;
         }

         if (document.getElementById('<%=txtMobileNo.ClientID%>').value != "") {
             str = document.getElementById('<%=txtMobileNo.ClientID%>').value
             if (str.length < 10) {
                 alert('Mobile Number should contain min 10 digits')
                 document.getElementById('<%=txtMobileNo.ClientID%>').focus();
                 return false
             }
         }
         if (document.getElementById('<%=txtMobileNo.ClientID%>').value != "") {
             str = document.getElementById('<%=txtMobileNo.ClientID%>').value
             if (str.length > 12) {
                 alert('Mobile Number should contain max 12 digits')
                 document.getElementById('<%=txtMobileNo.ClientID%>').focus();
                 return false
             }
         }
     }
    
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadCrumbs">
         <%-- <a href="#">Apply Now</a>--%>
        </div>
        <!-- breadCrumbs end -->
          <div id="Divthanks" class="productDetails" runat="server" visible="false">
         
           <p><b> Thank you for your interest in Bandhan Bank’s NRI Deposits. Our executive will get in touch with you</b></p>
        </div>

          <div id="Divthsnr" class="productDetails" runat="server" visible="false">
         
           <p style="font-size:25px;"><b> Thank you!</b></p>
           <p> We have got your details and our executive will contact you shortly.</p>
             <p><b> For any queries call us on our TOLL FREE NUMBER</b></p>
              <p style="font-size:30px;"><b> 1800-258-8181 </b></p>
               <p><b> Also, you can check our <a href="https://www.bandhanbank.com/FAQAccDepo.aspx" target="_blank">FAQs</a></b></p>
             

        </div>

        <div id="apply" class="productDetails" runat="server">
          <h2>Apply Now</h2>
         
          <p>Please fill in the following form to apply for our products and services. Our executives will get in touch with you to help you out.</p>
        </div>
        <br />
        <asp:Label ID="lblError" runat="server" CssClass="ErrLbl" ForeColor="Red"></asp:Label>
        <!-- about details end -->
<div id="frm" class="formTab" runat="server">
  <div class="innerform">
    <%-- <select name="" id="selectCategory">
              <option value="0">Select a Category you wish to apply for!</option>
              <option value="1">Category 1</option>
              <option value="2">Category 2</option>
              <option value="3">Category 3</option>
              <option value="4">Category 4</option>
            </select>--%>
    <asp:DropDownList ID="dbcat" runat="server" title="Category" 
          style="Width:100%; font-size:15px; color:#002F56;" 
          onselectedindexchanged="dbcat_SelectedIndexChanged1" AutoPostBack="True">
        <asp:ListItem Value="0">Select a category you wish to apply for</asp:ListItem>
               <%--<asp:ListItem>Savings account</asp:ListItem>--%>
              <%-- <asp:ListItem>Current account</asp:ListItem>--%>
              <%-- <asp:ListItem>Fixed Deposit</asp:ListItem>--%>
               <asp:ListItem>Retail Loans</asp:ListItem>
               <asp:ListItem>Micro Loans</asp:ListItem>
               <asp:ListItem>Home Loan</asp:ListItem>
               <asp:ListItem>Loan Against Property</asp:ListItem>
               <asp:ListItem>Two Wheeler Loan</asp:ListItem>
               <asp:ListItem>Loan Against Term Deposit</asp:ListItem>
               <asp:ListItem>Personal Loan</asp:ListItem>
               <asp:ListItem>Samriddhi Business Loan</asp:ListItem>
               <asp:ListItem>Equipment Loan</asp:ListItem>
               <asp:ListItem>Commercial Vehicle Loan</asp:ListItem>
               <asp:ListItem>Working Capital Loan</asp:ListItem>
               <asp:ListItem>Term Loan</asp:ListItem>
               <asp:ListItem>Small Enterprise Loan</asp:ListItem>
               <asp:ListItem>Kisan Credit Card Loan</asp:ListItem>
               <asp:ListItem>Equipment Loan</asp:ListItem>
               <asp:ListItem>Agri Allied Loan</asp:ListItem>
                <%--<asp:ListItem>NRI</asp:ListItem>--%>
               <asp:ListItem>Fixed Deposit-Premium</asp:ListItem>
                <asp:ListItem>Fixed Deposit-Advantage</asp:ListItem>
                <asp:ListItem>MSME Loan</asp:ListItem>
                 <asp:ListItem>Fixed Deposit-Standard</asp:ListItem>
                  <asp:ListItem>Fixed Deposit-Dhan Samriddhi</asp:ListItem>
                  <asp:ListItem>Fixed Deposit-Tax Saver</asp:ListItem>
                   <asp:ListItem>Recurring Deposit</asp:ListItem>
                   <asp:ListItem>Saving account-Premium</asp:ListItem>
                     <asp:ListItem>Saving account-Advantage</asp:ListItem>
                       <asp:ListItem>Saving account-Standard</asp:ListItem>
                        <asp:ListItem>Saving account-Sanchay</asp:ListItem>
                         <asp:ListItem>Saving account-Special</asp:ListItem>
                         <asp:ListItem>Saving account-GOS</asp:ListItem>
                          <asp:ListItem>Saving account-TASC</asp:ListItem>
                          <asp:ListItem>Saving account-BSBDA</asp:ListItem>
                          <asp:ListItem>Saving account-BSBDA-Small</asp:ListItem>
                           <asp:ListItem>Current account-Premium</asp:ListItem>
                             <asp:ListItem>Current account-Advantage</asp:ListItem>
                              <asp:ListItem>Current account-Standard</asp:ListItem>
                               <asp:ListItem>Current account-Samruddhi</asp:ListItem>
                                <asp:ListItem>Current account-TASC</asp:ListItem>
                                <asp:ListItem>Current account-GOS</asp:ListItem>
                                <asp:ListItem>NRI Deposits</asp:ListItem>
                                   <asp:ListItem>Term Deposit for Senior Citizens</asp:ListItem>
    </asp:DropDownList>
  </div>
  <div id="form1" runat="server">
  <div class="innerform">
  <p align="right">(*) Marked fields are mandatory</p>
    <ul class="formList">
      <li>
        <label>Name*</label>
        <asp:TextBox ID="txtName" runat="server" title="Name" MaxLength="50" autocomplete="off" placeholder="Please Enter Your Name"></asp:TextBox>
      </li>
      <li>
        <label>Email ID*</label>
        <asp:TextBox ID="txtemail" runat="server" EnableViewState="False" MaxLength="50" title="Email" autocomplete="off" placeholder="Please Enter Your Email-ID"></asp:TextBox>
      </li>
      <li>
        <label>Mobile no.*</label>
        <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="12" title="Mobile" EnableViewState="false" autocomplete="off" placeholder="Please Enter Your Mobile Number"></asp:TextBox>
      </li>


          <li>
            <label>City*</label>&nbsp;&nbsp;&nbsp;&nbsp;
            <span>
            <asp:DropDownList ID="dbCity" runat="server" title="City" style="Width:70%; font-size:15px; color:#002F56;"></asp:DropDownList>
            </span> </li>

               <li><label>Pin Code*</label><asp:TextBox ID="txtpincode" runat="server" MaxLength="6" title="Pin Code" EnableViewState="false" autocomplete="off" placeholder="Please Enter Pin Code"></asp:TextBox></li>


    </ul>

     <br />
    
      <asp:Label ID="Label1" runat="server" Font-Size="14px" Text="“I accept that I have read, understood & agree to the terms and conditions and I authorize Bandhan Bank & its representatives to call or SMS me with reference to my application. This consent will override any registration by me for DNC/NDNC.”"></asp:Label>
  </div>
  <div class="submitRow">
    <!--<p>(*) Marked fields are mandatory</p>-->
    <asp:Button ID="btnSubmit" runat="server" class="btn" Text="Submit" OnClientClick="return validate_form();" OnClick="btnSubmit_Click" />
  </div>
</div>     
</div>
   <!-- form tab end -->

        <div id="msme" runat="server">
         <div class="Innerform">
         <asp:Label ID="Error" runat="server" Text="Label"></asp:Label>
            <p align="right">
                (*) Marked fields are mandatory</p>
            <ul class="formList">
                <li>
                    <label>
                        Loan Type*</label>&nbsp;&nbsp;&nbsp;&nbsp; <span>
                            <asp:DropDownList ID="ddlloantype" runat="server" title="City" Style="width: 70%; font-size: 15px;
                                color: #002F56;">
                                <asp:ListItem Value="0">Please select Loan type</asp:ListItem>
                                <asp:ListItem>Working Capital</asp:ListItem>
                                <asp:ListItem>Term Loan</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </span></li>
                <li>
                    <label>
                        Loan Amount*</label>&nbsp;&nbsp;&nbsp;&nbsp; <span>
                            <asp:DropDownList ID="ddlloanamount" runat="server" title="City" Style="width: 70%; font-size: 15px;
                                color: #002F56;">
                                <asp:ListItem Value="0">Please select Loan Amount</asp:ListItem>
                                <asp:ListItem>10-49</asp:ListItem>
                                <asp:ListItem>50-100</asp:ListItem>
                                <asp:ListItem>&gt;100</asp:ListItem>
                            </asp:DropDownList>
                        </span></li>

                        <li>
                    <label>
                        Name*</label>
                    <asp:TextBox ID="txtapplicantname" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter Your Name"></asp:TextBox>
                </li>


                <li>
                    <label>
                        Contact No.</label>
                    <asp:TextBox ID="txtcontact" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter Your Name"></asp:TextBox>
                </li>

                <li>
                    <label>
                        Email*</label>
                    <asp:TextBox ID="txtemailid" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter Your Name"></asp:TextBox>
                </li>

                <li>
                    <label>
                        Business Entity</label>
                    <asp:TextBox ID="txtbusinessentity" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter Your Name"></asp:TextBox>
                </li>

                <li>
                    <label>
                       Line of Activity</label>&nbsp;&nbsp;&nbsp;&nbsp; <span>
                            <asp:DropDownList ID="ddllineofactivity" runat="server" title="City" Style="width: 70%; font-size: 15px;
                                color: #002F56;">
                                <asp:ListItem Value="0">Please select Manufacturing type</asp:ListItem>
                                <asp:ListItem>Manufacturing </asp:ListItem>
                                <asp:ListItem>Trading</asp:ListItem>
                                <asp:ListItem>Services</asp:ListItem>
                            </asp:DropDownList>
                        </span></li>

                <li>
                    <label>
                        Firm Type</label>&nbsp;&nbsp;&nbsp;&nbsp; <span>
                            <asp:DropDownList ID="ddltypeoffirm" runat="server" title="City" Style="width: 70%; font-size: 15px;
                                color: #002F56;">
                                <asp:ListItem Value="0">Please select a firm type </asp:ListItem>
                                <asp:ListItem>Proprietorship</asp:ListItem>
                                <asp:ListItem>Company</asp:ListItem>
                                <asp:ListItem>Partnership</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </span></li>


                         <li>
                    <label>
                       PAN/CIN no.</label>
                    <asp:TextBox ID="txtpan" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter Your Name"></asp:TextBox>
                </li>


                 <li>
                    <label>
                        Sales as per last audited</label>
                    <asp:TextBox ID="txtlastaudited" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter Your Name"></asp:TextBox>
                </li>

                 <li>
                    <label>
                        Enter nearest branch</label>
                    <asp:TextBox ID="txtbranch" runat="server" title="Name" MaxLength="50" autocomplete="off"
                        placeholder="Please Enter Your Name"></asp:TextBox>
                </li>



                 <asp:Button ID="Button1" runat="server" class="btn" Text="Submit" 
                         onclick="Button1_Click" />
                         

            </ul>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="14px" Text="“I give Consent to share the entered details with bandhan bank and contact to me”"></asp:Label>
        </div>
        <div class="submitRow">
            <!--<p>(*) Marked fields are mandatory</p>-->
           
        </div>
    </div>
    </div>

        <div id="botm" class="productDetails" runat="server">
          <h2>Pre-Fill Your Application & Save Your Time.</h2>
          <p>Download all the necessary application forms below and fill them at leisure before beginning the print outs to the closest Bandhan Bank branch.</p>
          
         <%-- <div class="listPoints">
            <a href="#" class="select"><span>Category 1</span></a>
            <a href="#"><span>Category 2</span></a>
            <a href="#"><span>Category 3</span></a>
            <a href="#"><span>Category 4</span></a>
            <a href="#"><span>Category 5</span></a>
            <a href="#"><span>Category 6</span></a>
          </div>--%>
          <ul class="pointList">
            <li>
              <h3>Account Opening Form For Non Individual Entities.</h3>
              <a href="../pdf/account-opening-nonindividual.pdf" target="_blank">Download</a>
            </li>
            <li>
              <h3>Account Opening Form For Resident Depositor-Individuals.</h3>
              <a href="../pdf/account-opening-residentdeposit-individuals.pdf" target="_blank">Download</a>
            </li>
            <li>
              <h3>Account Opening Form-II</h3>
              <a href="../pdf/account-opening-II.pdf" target="_blank">Download</a>
            </li>
          </ul>
          <p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.</p>
        </div>
        <!-- about details end -->
        
        
        <!-- apply now end -->
        <div class="backtotop">
          <a href="">Back to top</a>
        </div>
</asp:Content>

