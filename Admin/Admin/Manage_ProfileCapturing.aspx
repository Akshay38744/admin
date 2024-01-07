<%@ Page Title="" Language="C#" MasterPageFile="~/MSMELoanTrackerAdmin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Manage_ProfileCapturing.aspx.cs" Inherits="Admin_Manage_ProfileCapturing"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tbl_main" runat="server" style="width: 970px;" cellspacing="0" cellpadding="0"
        align="center" border="0">
        <tr id="tr_first">
            <td style="width: 970px; height: 20px;" valign="top" align="center" colspan="2">
                <table id="tbl_Srch" runat="server" style="width: 60%; border: Solid thin #cccccc"
                    cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td valign="middle" align="left" colspan="6" class="MenuHead" style="width: 890px;
                            height: 20px; padding-left: 10px;" bgcolor="#002F55">
                            <strong>
                                <asp:Label ID="Label1" runat="server" Text="Search Other Loan Appliation" CssClass="GridHead"
                                    ForeColor="White"></asp:Label></strong>
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td style="width: 10px;" valign="top" align="left">
                        </td>
                        <td valign="middle" align="left" colspan="5" style="width: 890px; height: 20px;">
                            &nbsp;<asp:Label ID="lblSrchErr" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 80px; height: 25px;" valign="top" align="left" class="label2">
                            Name :
                        </td>
                        <td style="width: 200px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtName" runat="server" CssClass="txt1" EnableViewState="false"
                                Width="190px"></asp:TextBox>
                        </td>
                        <td style="width: 20px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 80px; height: 25px;" valign="top" align="right" class="label2">
                            Email :&nbsp;
                        </td>
                        <td style="width: 170px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt1" EnableViewState="false"
                                Width="175px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                            &nbsp;
                        </td>
                        <td style="width: 80px; height: 25px;" valign="top" align="left" class="label2">
                            
                            Mobile No. :</td>
                        <td style="width: 200px; height: 25px;" valign="top" align="left">
                            <asp:TextBox ID="txtmobile" runat="server" CssClass="txt1" EnableViewState="false"
                                Width="190px"></asp:TextBox>
                        </td>
                        <td style="width: 20px; height: 25px;" valign="top" align="left">
                            &nbsp;
                        </td>
                        <td style="width: 80px; height: 25px;" valign="top" align="right" class="label2">
                            
                            Category :
                            
                        </td>
                        <td style="width: 170px; height: 25px;" valign="top" align="left">
                            
                            <asp:DropDownList ID="dbcat" runat="server" Width="179px" CssClass="txt1" Height="25px">
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left" class="label2">
                            
                            From :&nbsp;</td>
                        <td style="width: 200px; height: 25px;" valign="top" align="left">
                            <asp:DropDownList ID="cmbDD1" runat="server" Width="50px" CssClass="txt1">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbMM1" runat="server" Width="55px" CssClass="txt1" EnableViewState="False">
                                <asp:ListItem Value="MM" Selected="True">MM</asp:ListItem>
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sept</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbYY1" runat="server" Width="65px" CssClass="txt1">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20px; height: 25px;" valign="top" align="left">
                        </td>
                        <td style="width: 80px; height: 25px;" valign="top" align="right" class="label2">
                            To :&nbsp;
                        </td>
                        <td style="width: 200px; height: 25px;" valign="top" align="left">
                            <asp:DropDownList ID="cmbDD2" runat="server" Width="50px" CssClass="txt1">
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbMM2" runat="server" Width="55px" CssClass="txt1" EnableViewState="false">
                                <asp:ListItem Value="MM" Selected="True">MM</asp:ListItem>
                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                <asp:ListItem Value="9">Sept</asp:ListItem>
                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                <asp:ListItem Value="12">Dec</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="cmbYY2" runat="server" Width="65px" CssClass="txt1">
                            </asp:DropDownList>
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                  <%--  <tr>
                        <td style="width: 10px; height: 25px;" valign="top" align="left">
                            &nbsp;
                        </td>
                        <td style="width: 180px; height: 25px;" valign="top" align="left" class="label2">
                            &nbsp;
                        </td>
                        <td style="width: 200px; height: 25px;" valign="top" align="left">
                            &nbsp;
                        </td>
                        <td style="width: 20px; height: 25px;" valign="top" align="left">
                            &nbsp;
                        </td>
                        <td style="width: 80px; height: 25px;" valign="top" align="right" class="label2">
                            &nbsp;
                        </td>
                        <td style="width: 200px; height: 25px;" valign="top" align="left">
                            &nbsp;
                        </td>
                    </tr>--%>
                    
                    <tr>
                        <td style="width: 900px; height: 25px;" valign="middle" align="center" colspan="6">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn7" Width="80px"
                                OnClick="btnSearch_Click" />&nbsp;&nbsp;<asp:Button ID="btnReset" runat="server"
                                    Text="Reset" CssClass="btn7" Width="60px" OnClick="btnReset_Click" />&nbsp;&nbsp;<asp:Button 
                                        ID="btnexcel" runat="server" onclick="btnexcel_Click" Text="Export To Excel" CssClass="btn7" />
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                   
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 970px; height: 8px;" valign="top" align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 970px; height: 8px;" valign="middle" align="center">
                            <asp:Label ID="lblmessage" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td style="width: 970px; height: 20px;" valign="top" align="center">
                            <asp:Label ID="lblmsg" runat="server" CssClass="ErrLbl"></asp:Label>
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td style="width: 970px; height: 25px;" valign="middle" align="center">
                            <asp:DataGrid ID="dg_Pro" Width="950px" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                GridLines="None" CellSpacing="3" PageSize="25" OnItemCommand="dg_Pro_ItemCommand"
                                OnItemDataBound="dg_Pro_ItemDataBound" OnPageIndexChanged="dg_Pro_PageIndexChanged">
                                <HeaderStyle BackColor="#002F55" ForeColor="White" Height="25px" HorizontalAlign="Center"
                                    CssClass="" VerticalAlign="Middle" />
                                <ItemStyle Height="20px" BackColor="#FFFFFF" HorizontalAlign="Left" VerticalAlign="Top"
                                    CssClass="" />
                                <AlternatingItemStyle Height="20px" CssClass="" BackColor="#dddddd" HorizontalAlign="Left"
                                    VerticalAlign="Top" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="center" VerticalAlign="middle" />
                                <Columns>
                                    <asp:BoundColumn DataField="Id" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Sr.No.">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemTemplate>
                                            <%#(dg_Pro.PageSize * dg_Pro.CurrentPageIndex) + Container.ItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>


                                      <asp:TemplateColumn HeaderText="Ref. No.">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblrefno" runat="server" Text="" CssClass="label2"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>



                                    <asp:TemplateColumn HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lnkname" runat="server" Text="" CssClass="label2"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                       <asp:TemplateColumn HeaderText="Details">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="LnkDetails" runat="server" Text="" CssClass="label2"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="Submission Date">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubDate" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Email_Id" HeaderText="Email"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="" HeaderText="Address" Visible="false"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Contact No">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblContact" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Category" HeaderText="Applied For" ></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Action">
                                        <HeaderStyle />
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CssClass="label2" CommandName="Delete">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="970px" align="left" height="5px" cellpadding="0" cellspacing="0" border="0"
                    bgcolor="#eeeeee" style="border: Solid 1px; border-color: #444444;">
                    <tr>
                        <td style="width: 970px; height: 4px;" valign="middle" align="center" colspan="2">
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td width="475px" align="left" valign="middle" height="40px">
                            &nbsp;
                            <asp:Label ID="Label5" runat="server" Text="Change record(s) per page" CssClass="lbl"
                                Height="20px">
                            </asp:Label>&nbsp;<asp:TextBox ID="txtPageSize" runat="server" CssClass="txt1" Height="21px"
                                Width="30px" MaxLength="3" AutoComplete="Off" onKeyPress="return checkIt(event)">
                            </asp:TextBox>&nbsp;<asp:Button ID="btnPageSize" runat="server" Text="Go" Width="35px"
                                onKeyPress="return checkIt(event)" CssClass="btn7" OnClick="btnPageSize_Click" />
                        </td>
                        <td width="475px" align="right" valign="middle" height="40px">
                            <asp:Label ID="lblPageIndex" runat="server" Text="Skip to page" CssClass="lbl" Height="20px">
                            </asp:Label>&nbsp;<asp:TextBox ID="txtPageIndex" runat="server" CssClass="txt1" Height="21px"
                                Width="30px" MaxLength="3" AutoComplete="Off" onKeyPress="return checkIt(event)">
                            </asp:TextBox>&nbsp;<asp:Button ID="btnPageIndex" runat="server" Text="Go" Width="35px"
                                OnClick="btnPageIndex_Click" CssClass="btn7" />&nbsp;&nbsp;
                        </td>
                    </tr>
                      <tr style="height: 5px">
                    </tr>
                    <tr>
                        <td valign="middle" align="center" colspan="2" class="style1">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_last">
            <td style="width: 970px; height: 8px;" valign="top" align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
