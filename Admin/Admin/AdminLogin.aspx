<%@ Page Title="" Language="C#" MasterPageFile="~/MSMELoanTrackerAdmin/AdminLogPg.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Admin_AdminLogin" ValidateRequest="false"
    EnableEventValidation="false" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript" src="../Styles/AdminCss.css"></script>
    <script type="text/javascript">
        function checkForm() {
            document.getElementById('<%=txtpassword.ClientID%>').value = encrypt(document.getElementById('<%=txtpassword.ClientID%>').value);

        }
        function encrypt(data) {
            var tempChar;
            var tempAsc;
            var tempLen;
            var newData;
            var i;

            newData = '';

            for (i = 0; i < data.length; i++) {
                tempChar = data.substr(i, 1);
                tempAsc = tempChar.charCodeAt(0);
                tempLen = tempAsc.toString().length;

                if (tempLen == 1) {
                    tempAsc = "00" + tempAsc.toString();
                } else if (tempLen == 2) {
                    tempAsc = "0" + tempAsc.toString();
                }

                newData = newData + tempAsc.toString();
            }

            return newData;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <br />
    <table id="Table2" style="width: 350px; border: solid 1px #E6201F" cellspacing="0"
        cellpadding="2" align="center" border="0">
        <tr>
            <td width="310px" colspan="3" height="26" align="left" valign="middle" bgcolor="#002F56"
                class="AdmModHead" style="color: #FFFFFF">
                &nbsp;Administrator Login
            </td>
        </tr>
        <tr height="20px">
            <td>
            </td>
            <td colspan="2" align="left">
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" style="width: 10px; height: 26px;">
            </td>
            <td style="width: 110px; height: 26px;" align="left" class="label2">
                Username
            </td>
            <td style="width: 189px; height: 26px" align="left">
                :&nbsp;<asp:TextBox ID="txtlogin" runat="server" CssClass="txt1" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" style="width: 10px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;" align="left" class="label2">
                Password
            </td>
            <td align="left" style="width: 189px; height: 29px">
                :&nbsp;<asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="txt1"
                    MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" style="width: 10px; height: 29px;">
            </td>
            <td align="left" style="width: 110px; height: 29px" class="label2">
                Type the code as below.
            </td>
            <td align="left" style="width: 189px; height: 29px">
                :&nbsp;<asp:TextBox ID="txtcaptcha" runat="server" CssClass="txt1" MaxLength="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" style="width: 10px; height: 35px;">
            </td>
            <td align="left" style="width: 110px; height: 35px">
            </td>
            <td align="left" style="width: 189px; height: 35px; padding-left: 10px;">
                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="none" CaptchaLength="5"
                    CaptchaHeight="31" CaptchaWidth="170" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                    CaptchaMaxTimeout="240" Height="31px" Width="170px" BorderColor="#E6E9E8" BackColor="#E6E9E8"
                    BorderStyle="Solid" BorderWidth="1px" />
            </td>
        </tr>
        <tr>
            <td width="350px" align="center" colspan="3" height="30px" valign="middle" style="padding-bottom: 5px;">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn1" OnClick="btnLogin_Click"
                    Width="60px" Height="25px" OnClientClick="javascript:return checkForm();" />
            </td>
        </tr>
    </table>
</asp:Content>
