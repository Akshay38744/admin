<%@ Page Title="" Language="C#" MasterPageFile="~/MSMELoanTrackerAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="MSMELoanTrackerAdmin_ChangePassword" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../Styles/Page.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="797px" align="center" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="797px" height="250px" valign="middle" align="center" class="label3">
                <br />
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
                <br />
                <br />
                <table id="Table2" style="width: 410px; border: solid thin #cccccc;" cellspacing="0"
                    cellpadding="2" align="center" border="0">
                    <tr>
                        <td align="left" valign="top" style="width: 10px; height: 26px;">
                        </td>
                        <td style="width: 110px; height: 26px;" align="left" class="label2">
                            Username :
                        </td>
                        <td style="width: 189px; height: 26px" align="left">
                            <span style="font-weight: bold"></span>
                            <asp:Label ID="txtlogin" runat="server" CssClass="label2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 10px; height: 29px;"  class ="ErrLbl">
                            *</td>
                        <td style="width: 110px; height: 29px;" align="left" class="label2">
                            Old Password :
                        </td>
                        <td align="left" style="width: 189px; height: 29px">
                            <asp:TextBox ID="txtOldpassword" runat="server" TextMode="Password" CssClass="txt1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 10px; height: 29px;"  class ="ErrLbl">
                            *</td>
                        <td align="left" style="width: 110px; height: 29px" class="label2">
                            New Password :
                        </td>
                        <td align="left" style="width: 189px; height: 29px">
                            <asp:TextBox ID="txtNewpassword" runat="server" TextMode="Password" CssClass="txt1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 10px; height: 29px;"  class ="ErrLbl">
                            *</td>
                        <td align="left" style="width: 110px; height: 29px" class="label2">
                            Confirm Password :
                        </td>
                        <td align="left" style="width: 189px; height: 29px">
                            <asp:TextBox ID="txtConfpassword" runat="server" TextMode="Password" CssClass="txt1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="width: 10px; height: 29px;" class ="ErrLbl">
                            *</td>
                        <td align="left" style="width: 110px; height: 29px" class="label2">
                            Enter the code as
                            <br />
                            shown below :
                        </td>
                        <td align="left" style="width: 189px; height: 29px">
                            <asp:TextBox ID="txtcaptcha" runat="server" CssClass="txt1" MaxLength="6"></asp:TextBox><br /><br />
                                   <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="6"
                            CaptchaHeight="31" CaptchaWidth="120" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                            CaptchaMaxTimeout="240" Height="31px" Width="120px" BorderColor="#E7E4D3" BackColor="#E7E4D3"
                            BorderStyle="Solid" BorderWidth="1px" Font-Italic="true" ForeColor="#7A6802" />
                        </td>
                    </tr>
                    <tr>
                        <td width="410px" align="center" colspan="3" height="40px" valign="middle">
                            <asp:Button ID="btnChngPwd" runat="server" Text="Change Password" CssClass="btn1"
                                Width="140px" onclick="btnChngPwd_Click" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Reset" CssClass="btn1" Width="55px" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

