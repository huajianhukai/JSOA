<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dept.aspx.cs" Inherits="JSOA.WebSite.Manager.Dept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dept</title>
    <link href="Style/Table0.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/JScript.js" type="text/javascript"></script>
    <script src="Scripts/Menu.js" type="text/javascript"></script>
    <script src="Scripts/ShortKey.js" type="text/javascript"></script>
    <script  type="text/javascript">
      
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <table id="Table1" align="left" cellspacing="1" cellpadding="1" border="0" width="100%">
        <tr>
            <td>
                <caption style="background: url('Img/BG_Title.png') repeat-x; height: 30px; line-height: 30px">
                    <asp:Literal ID="Literal1" runat="server"  >Dept</asp:Literal>
                </caption>
            </td>
        </tr>
        <tr>
            <td class="ToolBar">
                <span id="ToolBar1_Lab_Key">关键字:&nbsp;</span><input name="TBKeyWord" type="text"
                    runat="server" clientidmode="Static" size="13" id="TBKeyWord" />&nbsp;
                    
                     
                <asp:Button ID="BtnSelect"  CssClass="Btn" runat="server" Text="Select" 
                    onclick="BtnSelect_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnNew" runat="server" CssClass="Btn" Text="New" 
                    onclick="BtnNew_Click" />
                    
                     
            </td>
        </tr>
        <tr align="justify" height="0px" valign="top">
            <td width='100%'>
            </td>
        </tr>
        <tr>
            <td class="Toolbar">
                <font face="宋体" size="2"></font>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>