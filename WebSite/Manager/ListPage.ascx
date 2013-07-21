<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPage.ascx.cs" Inherits="JSOA.WebSite.Manager.ListPage" %>
<div>
    <table id="TableFoot" style="width: 100%; border: 0px;">
        <tr>
            <td align="right">
                <table id="TablePager" border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="LabelPager" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtFirstPage" runat="server" CommandName="FirstPage" OnClick="lbtPage_Click">首页</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtPrePage" runat="server" CommandName="PrePage" OnClick="lbtPage_Click">上页</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtNextPage" runat="server" CommandName="NextPage" OnClick="lbtPage_Click">下页</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtLastPage" runat="server" CommandName="LastPage" OnClick="lbtPage_Click">末页</asp:LinkButton>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left: 0px; padding-right: 0px;">
                            条记录/页&nbsp;&nbsp;转到第
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPager" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPager_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            页&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>