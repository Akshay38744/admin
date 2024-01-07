<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MSMELoanTrackerAdmin/AdminMasterPage.master"  CodeFile="BulkUpload.aspx.cs" Inherits="MSMELoanTrackerAdmin_BulkUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Page.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <table id="tbl_main" runat="server" style="width: 970px;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr id="tr_first">
            <td style="width: 970px; height: 20px;" valign="top" align="center" colspan="2">
                <table id="tbl_Srch" runat="server" style="width: 60%; border: Solid thin #cccccc"
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="left" colspan="4" class="MenuHead" style="width: 890px;
                            height: 20px; padding-left: 10px;" bgcolor="#002F55">
                            <strong>
                                <asp:Label ID="lblheading" runat="server" Font-Bold="true" ForeColor="White">Bulk Upload for update status</asp:Label>
                            </strong>
                        </td>
                        <%-- <td align="right">
                            <asp:ImageButton ID="imgclose" runat="server" ImageUrl="~/Images/close.jpg" Width="20px"
                                Style="vertical-align: top;" OnClick="imgclose_Click" />
                        </td>--%>
                    </tr>
                      <tr style="height:5px"></tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 100px; height: 25px;" valign="top" align="left" class="label2">
                            Upload Document :
                        </td>
                        <td style="width: 10px;">
                        </td>
                        <td style="width: 200px; height: 25px;" valign="top" align="left">
                            <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                            <em style="font-size: 11px;">Only (.txt ) file allowed </em>
                        </td>
                    </tr>
                      <tr style="height:5px"></tr>
                    <tr>
                      <td align="center" colspan="4">
                            <asp:Button ID="btnupload" Text="Upload" runat="server" CssClass="btn1" Width="80px"
                                OnClientClick="return confirm('Are you sure you want to upload this file?')"
                                OnClick="btnupload_Click" CommandName="getrefno" />&nbsp;
                                <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="btn7" 
                                Width="60px" onclick="BtnReset_Click" />
                        </td>
                    </tr>
                      <tr style="height:5px"></tr>
                    <tr>
                    
                        <td height="12px" colspan="4" style="text-align: center;">
                            <asp:Label ID="lbldwnerr" runat="server" CssClass="ErrLbl"></asp:Label>
                            <asp:Label ID="lblupdtcnt" runat="server" CssClass="ErrLbl"><br /></asp:Label>
                        </td>
                    </tr>
                      <tr style="height:5px"></tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 100px; height: 25px;" valign="top" align="left">
                            <asp:Label ID="label12" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="#002F55">
                                        Steps of Uploding Master :</asp:Label><br />
                            <asp:Label ID="label13" runat="server" Font-Size="11px">
                                        
                                        1.Download master in txt file format<br />
                                        2.Edit or modify file<br /> 
                                        3.Upload                                              
                                        
                            </asp:Label>
                        </td>
                    </tr>
                      <tr style="height:5px"></tr>
                     </table>
            </td>
        </tr>
          <tr style="height:5px"></tr>
        <tr align="center">
            <td>
                <asp:LinkButton ID="Link" Text="Click here to download .txt file Format" OnClick="DownloadButton_Click"
                    runat="server" Style="font-size: 14px;color: 002F55;"  />
            </td>
        </tr>
        
        <tr>
            <td style="height: 5px;">
            </td>
        </tr>
    </table>
</asp:Content>
