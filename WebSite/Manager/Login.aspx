<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JSOA.WebSite.Manager.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台登陆</title>
    <script type="text/javascript">
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtName" runat="server" ClientIDMode="Static"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPass" runat="server" ClientIDMode="Static"></asp:TextBox>
        <br />
        <asp:Button  ID="btnLogin" runat="server" ClientIDMode="Static" Text="登陆" OnClick="btnLogin_Click"/>
       
    </div>
    </form>
</body>
</html>
