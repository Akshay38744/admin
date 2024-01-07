<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdmMenu.ascx.cs" Inherits="Admin_Includes_AdmMenu" %>
<link href="../../Styles/Page.css" type="text/css" rel="Stylesheet" />
<link href="../../Styles/Style.css" type="text/css" rel="Stylesheet" />
<div class="div_1234">
    <table width="995px" cellpadding="0" cellspacing="0" border="0" align="center">
        <tr>
            <td style="width: 960px; height: 24px; background-color: #002F55" valign="middle"
                align="left">
                <table width="500px" cellpadding="0" cellspacing="0" border="0" align="left">
                    <tr>
                        <td style="width: 300px; padding:5px; height: 24px;" valign="middle" align="left" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageApp" runat="server" CssClass="AdmMenutab2" 
                                onclick="lnkManageApp_Click">Manage MSME Loan Applications</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 150px; height: 45px;" valign="middle" align="left" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkManageBulkUpdate" runat="server" CssClass="AdmMenutab2" 
                                onclick="lnkManageBulkUpdate_Click">Bulk Upload</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <%-- <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>
                        <td style="width: 300px; height: 45px;" valign="middle" align="left" class="AdmMenutab2"
                            rowspan="3">
                            <asp:LinkButton ID="lnkMngPrfCap" runat="server" CssClass="AdmMenutab2" 
                                onclick="lnkMngPrfCap_Click" >Manager Other Loan Application</asp:LinkButton>
                        </td>
                        <td style="width: 1px; height: 7px;" valign="middle" align="center" class="AdmMenutab2">
                        </td>--%>
                        		
                    </tr>                   
                   
                </table>
            </td>
        </tr>
    </table>

</div>
