<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelOperation.aspx.cs" Inherits="JSOA.WebSite.Test.ExcelOperation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>


    
    </div>
    </form>
</body>
</html>
