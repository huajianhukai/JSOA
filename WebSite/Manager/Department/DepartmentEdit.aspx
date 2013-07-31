<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentEdit.aspx.cs" Inherits="JSOA.WebSite.Manager.Department.DepartmentEdit" %>

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
        <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 组织机构 &gt; 部门管理</div>
        <div id="contentTab">
            <ul class="tab_nav">
                <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;"><%=strInformation%></a></li>
            </ul>
            <div class="tab_con" style="display: block;">
                <table class="form_table">
                    <col width="180px">
                    <col>
                    <tbody>
                        <tr>
                            <th>上级部门：</th>
                            <td>
                                <asp:DropDownList ID="ddlFatherDepartment" runat="server" CssClass="select2 required" /><label>*</label>
                            </td>
                        </tr>

                        <tr>
                            <th>部门NO：</th>
                            <td>
                                <asp:TextBox ID="txtDeptNo" runat="server" CssClass="txtInput normal required" minlength="1" MaxLength="3"></asp:TextBox><label>*</label></td>
                        </tr>
                        <tr>
                            <th>部门名称：</th>
                            <td>
                                <asp:TextBox ID="txtDeptName" runat="server" CssClass="txtInput normal required"
                                    minlength="2" MaxLength="20"></asp:TextBox><label>*</label></td>
                        </tr>

                        <tr>
                            <th>备注：</th>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtInput normal required" minlength="2" MaxLength="200"></asp:TextBox></td>
                        </tr>


                        <tr>
                            <th></th>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" /></td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>
    </form>
</body>
</html>
