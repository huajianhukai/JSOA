<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="JSOA.WebSite.Manager.Department.DepartmentList" %>

<%@ Register Src="~/Manager/ListPage.ascx" TagPrefix="uc1" TagName="ListPage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门管理列表</title>
    <link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../images/style.css" />
    <link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="navigation">首页 &gt; 组织机构 &gt; 部门管理</div>
        <div class="tools_box">
            <div class="tools_bar">
                <div class="search_box">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" OnClick="btnSearch_Click" />
                </div>
                <a href="DepartmentEdit.aspx?action=Add" class="tools_btn"><span><b class="add">添加部门</b></span></a>
                <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
                <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"
                    OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
            </div>
        </div>


        <!--列表展示.开始-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="6%">选择</th>
                        <th align="left">部门编号</th>
                        <th width="12%" align="left">部门名称</th>
                        <th width="12%" align="left">上级部门编号</th>

                        <th width="16%" align="left">备注</th>
                        <th width="6%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td   style="align-content:center">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("NO")%>' runat="server" />
                    </td>
                    <td><%#Eval("No")%></td>
                    <td><a href="DepartmentEdit.aspx?action=Edit&No=<%#Eval("No")%>"><%#Eval("Name")%></a></td>
                    <td><%#Eval("FName")%></td>
                    <td><%#Eval("Remarks")%></td>
                    <td style="align-content:center"><a href="DepartmentEdit.aspx?action=Edit&No=<%#Eval("No")%>"><%#Eval("Name")%>修改</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <uc1:ListPage runat="server" ID="ListPage" />

    </form>
    <script type="text/javascript">


    </script>
</body>
</html>
