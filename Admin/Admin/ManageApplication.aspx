<%@ Page Title="" Language="C#" MasterPageFile="~/MSMELoanTrackerAdmin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="ManageApplication.aspx.cs" Inherits="MSME_ManageApplication" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Page.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        function allowOnlyNumber(evt) {

            alert('Please select date');
            return false;
            // var charCode = (evt.which) ? evt.which : event.keyCode
            // if (charCode > 31 && (charCode < 48 || charCode > 57))
            //  return false;
            // return true;
        }
        function isalphaKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode < 33 || charCode > 47 && charCode < 48 || charCode > 57) {
                return true;
            }
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <table id="tbl_main" runat="server" style="width: 970px;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr id="trSearch" runat="server">
            <td style="width: 10px; height: 20px;" valign="top" align="center">
            </td>
            <td style="width: 960px; height: 20px;" valign="top" align="center">
                <table id="tbl_MainDept" runat="server" style="width: 685px; border: Solid thin #cccccc"
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <%--<td style="WIDTH: 10px; " valign="top" align="left" bgcolor="#cccccc">
                    </td>--%>
                        <td valign="middle" align="left" colspan="7" class="GridHead" style="width: 350px;
                            height: 20px; font-weight: bold;" bgcolor="#002F55">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblAddMainHead" runat="server" Text="Search" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height:5px"></tr>
                    <tr>
                        <td valign="middle" align="left" colspan="3" style="width: 400px; height: 20px;"
                            bgcolor="#ffffff">
                            &nbsp;
                            <asp:Label ID="lblMainMsg" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 150px; height: 25px;" valign="top" align="left" class="label2">
                            Reference Number :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtRefNo" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="Reference Number"></asp:TextBox>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 150px; height: 25px;" valign="top" align="left" class="label2">
                            Status :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="txt1" Width="175px" Height="25px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            From Date:
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="From Date" placeholde="DD/MM/YYYY" AutoComplete="off" onkeypress="return allowOnlyNumber(event)"
                                oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server"
                                TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            To Date :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="To Date" placeholde="DD/MM/YYYY" AutoComplete="off" onkeypress="return allowOnlyNumber(event)"
                                oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server"
                                TargetControlID="txtToDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn7" Width="61px"
                                OnClick="BtnSearch_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="btn7" Width="60px"
                                OnClick="BtnReset_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnExport" runat="server" Text="Export To Excel" CssClass="btn7"
                                Width="120px" OnClick="BtnExport_Click1" />
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                      </table>
            </td>
            <td style="width: 10px; height: 20px;" valign="top" align="center">
            </td>
        </tr>
        <tr id="trUpdate" runat="server">
            <td style="width: 10px; height: 20px;" valign="top" align="center">
            </td>
            <td style="width: 960px; height: 20px;" valign="top" align="center">
                <table id="tblUpdate" runat="server" style="width: 685px; border: Solid thin #cccccc"
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <%--<td style="WIDTH: 10px; " valign="top" align="left" bgcolor="#cccccc">
                    </td>--%>
                        <td valign="middle" align="left" colspan="7" class="GridHead" style="width: 350px;
                            height: 20px; font-weight: bold;" bgcolor="#002F55">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Update MSME Loan Application Status"
                                ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                    <tr id="trEditErr" runat="server" visible="false">
                        <td valign="middle" align="left" colspan="3" style="width: 400px; height: 20px;"
                            bgcolor="#ffffff">
                            &nbsp;
                            <asp:Label ID="lblEditErr" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 150px; height: 25px;" valign="top" align="left" class="label2">
                            Reference Number :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtUpdRef" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="Reference Number" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 150px; height: 25px;" valign="top" align="left" class="label2">
                            Applicant Name :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtApplicantName" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="Applicant Name" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Email ID :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="Email" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Mobile :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="Mobile Number" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                    <tr>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Submission Date :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtSubmtDate" runat="server" CssClass="txt1" Width="175px" MaxLength="25"
                                ToolTip="Submission Date" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 5px">
                        </td>
                        <td style="width: 90px; height: 25px;" valign="top" align="left" class="label2">
                            Status :
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtStatus" runat="server" AutoPostBack="true" AutoComplete="off"
                                Width="175px"  CssClass="txt1" onkeypress=" return isalphaKey(event)"></asp:TextBox>
                        </td>
                        <td style="width: 5px">
                        </td>
                    </tr>
                    <tr style="height:5px"></tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn7" Width="61px"
                                OnClick="btnUpdate_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnUpReset" runat="server" Text="Cancel" CssClass="btn7" Width="60px"
                                OnClick="BtnUpReset_Click" />
                        </td>
                    </tr>
                     <tr style="height:5px"></tr>
                      </table>
            </td>
            <td style="width: 10px; height: 20px;" valign="top" align="center">
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 30px;" valign="middle" align="center" colspan="5">
                <asp:Label ID="lblerr" runat="server" CssClass="ErrLbl"></asp:Label>
            </td>
        </tr>
         <tr style="height:5px"></tr>
        <tr>
            <td style="width: 970px; height: 30px;" valign="middle" align="center" colspan="5">
                <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
            </td>
        </tr>
         <tr style="height:5px"></tr>
        <tr id="trTblData" runat="server">
            <td style="width: 970px; height: 25px;" valign="middle" align="center" colspan="5">
                <asp:DataGrid ID="dg_MSMEApp" Width="800px" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                    GridLines="both" CellSpacing="3" CellPadding="3" PageSize="10" OnPageIndexChanged="dg_MSMEApp_PageIndexChanged"
                    OnItemCommand="dg_MSMEApp_ItemCommand">
                    <HeaderStyle BackColor="#002F55" ForeColor="White" Height="25px" HorizontalAlign="Center"
                        CssClass="" VerticalAlign="Middle" />
                    <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                        CssClass="" />
                    <AlternatingItemStyle Height="20px" CssClass="" BackColor="#dddddd" HorizontalAlign="Left"
                        VerticalAlign="Top" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" />
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="ID" Visible="False"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Sr.No.">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                            <ItemTemplate>
                                <%#(dg_MSMEApp.PageSize * dg_MSMEApp.CurrentPageIndex) + Container.ItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Reference Number" HeaderText="Reference Number">
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Applicant name" HeaderText="Name of the Enterprise/ Borrower">
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Submission Date" HeaderText="Date Of Submission">
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Status" HeaderText="Status">
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Action">
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMainEdit" runat="server" CssClass="label2" CommandName="Edit">Update Status</asp:LinkButton>
                                |
                                <asp:LinkButton ID="lnkMainDelete" runat="server" CssClass="label2" CommandName="Delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Email-ID" HeaderText="Email" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Contact Number" HeaderText="Mobile" Visible="false"></asp:BoundColumn>
                       
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 8px;" valign="middle" align="center" colspan="5">
            </td>
        </tr>
    </table>
</asp:Content>
