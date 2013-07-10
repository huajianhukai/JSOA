<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JSOA.WebSite.Manager.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Scripts/lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <script src="Scripts/lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="Scripts/lib/ligerUI/js/ligerui.min.js" type="text/javascript"></script>
    <script src="Menu/MenuData.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;
        $(function () {

            //布局
            $("#layout1").ligerLayout({ leftWidth: 190, height: '100%', heightDiff: -34, space: 4, onHeightChanged: f_heightChanged });
            var height = $(".l-layout-center").height();
            //Tab
            $("#framecenter").ligerTab({ height: height, onAfterSelectTabItem: function (tabId) {
                if (tabId == "empworks" || tabId == "HungUp") {
                    tab.reload(tabId);
                }
            }, onAfterRemoveTabItem: function (tabId, index) {
                var item_list = tab.getTabidList();
                var preItem = item_list[item_list.length - 1];
                if (preItem == "empworks" || preItem == "HungUp") {
                    tab.reload(preItem);
                }
            }
            });
            //面板
            $("#accordion1").ligerAccordion({ height: height - 24, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });

            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#accordion1").ligerGetAccordionManager();

            var startUrl = $("#startFlow").val();
            if (startUrl != null && startUrl != "") {
                f_addTab("addstartflow", "发起流程", startUrl);
            }
            $("#pageloading").hide();
        });

        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }

        function f_addTab(tabid, text, url) {
            tab.addTabItem({ tabid: tabid, text: text, url: url });
        }
        function checktop() {
            if (top.location != window.location) {
                top.location = "Login.aspx";
            }
        }
    </script>
    <style type="text/css">
        body, html
        {
            height: 100%;
        }
        body
        {
            padding: 0px;
            margin: 0;
            overflow: hidden;
        }
        .l-link
        {
            display: block;
            height: 26px;
            line-height: 26px;
            padding-left: 10px;
            text-decoration: underline;
            color: #333;
        }
        .l-link2
        {
            text-decoration: underline;
            color: white;
            margin-left: 2px;
            margin-right: 2px;
        }
        .l-layout-top
        {
            background: #102A49;
            color: White;
        }
        .l-layout-bottom
        {
            background: #E5EDEF;
            text-align: center;
        }
        #pageloading
        {
            position: absolute;
            left: 0px;
            top: 0px;
            background: white url('Scripts/lib/images/loading.gif') no-repeat center;
            width: 100%;
            height: 100%;
            z-index: 99999;
        }
        .l-link
        {
            display: block;
            line-height: 40px;
            height: 40px;
            padding-left: 16px;
            text-decoration: none;
            border: 1px solid white;
            border-bottom: 1px #E5E5E5 solid;
            margin: 4px;
        }
        .l-link-over
        {
            background: #FFEEAC;
            border: 1px solid #DB9F00;
        }
        .l-winbar
        {
            background: #2B5A76;
            height: 30px;
            position: absolute;
            left: 0px;
            bottom: 0px;
            width: 100%;
            z-index: 99999;
        }
        .space
        {
            color: #E7E7E7;
        }
        .img-menu
        {
            height: 36px;
            width: 36px;
        }
        /* 顶部 */
        .l-topmenu
        {
            margin: 0;
            padding: 0;
            height: 31px;
            line-height: 31px;
            background: url('Scripts/lib/images/top.jpg') repeat-x bottom;
            position: relative;
            border-top: 1px solid #1D438B;
        }
        .l-topmenu-logo
        {
            color: #E7E7E7;
            padding-left: 5px;
            font-size: 16px;
            font-weight: bold;
            line-height: 26px;
            
        }
        .l-topmenu-welcome
        {
            position: absolute;
            height: 24px;
            line-height: 24px;
            right: 30px;
            top: 2px;
            color: #070A0C;
        }
        .l-topmenu-welcome a
        {
            color: #E7E7E7;
            text-decoration: underline;
        }
    </style>
</head>
<body style="padding: 0px; background: #EAEEF5;">
    <div id="pageloading">
    </div>
    <div id="topmenu" class="l-topmenu">
        <div class="l-topmenu-logo">
            JohnsonControls
        </div>
        <div class="l-topmenu-welcome">
            <span class="space">UserInfo</span>&nbsp;&nbsp;<span class="space">|</span>&nbsp;&nbsp;<a
                class="ce" href="../Default.aspx">LogOut</a> <span class="space"></span>
        </div>
    </div>
    <div id="layout1" style="width: 99.2%; margin: 0 auto; margin-top: 4px;">
        <div position="left" title="Menu" id="accordion1">
            <div title="FUNCTION LIST" class="l-scroll">
                <a class="l-link" href="javascript:f_addTab('startpage','部门','Dept.aspx')">
                    <img class="img-menu" align="middle" alt="" src="Img/Menu/Start.png" />部门</a>
              
            </div>
        </div>
        <div position="center" id="framecenter">
        </div>
    </div>
    <div style="height: 32px; line-height: 32px; color: #666; font-family: arial; text-align: center;">
    OA后台管理
    </div>
    <div style="display: none">
    </div>
    <input type="hidden" id="startFlow" value="" />
</body>
</html>
