<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JSOA.WebSite.Manager.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台管理</title>
    <link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="images/style.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../scripts/ui/js/ligerBuild.min.js" type="text/javascript"></script>
    <script src="js/function.js" type="text/javascript"></script>


    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;
        $(function () {
            //页面布局
            $("#global_layout").ligerLayout({ leftWidth: 180, height: '100%', topHeight: 65, bottomHeight: 24, allowTopResize: false, allowBottomResize: false, allowLeftCollapse: true, onHeightChanged: f_heightChanged });

            var height = $(".l-layout-center").height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //左边导航面板
            $("#global_left_nav").ligerAccordion({ height: height - 25, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });

            //快捷菜单
            var menu = $.ligerMenu({
                width: 120, items:
            [
                { text: '管理首页', click: itemclick },
                { text: '修改密码', click: itemclick },
                { line: true },
                { text: '关闭菜单', click: itemclick }
            ]
            });
            $("#tab-tools-nav").bind("click", function () {
                var offset = $(this).offset(); //取得事件对象的位置
                menu.show({ top: offset.top + 27, left: offset.left - 120 });
                return false;
            });


            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#global_left_nav").ligerGetAccordionManager();

            //tree.expandAll(); //默认展开所有节点
            $("#pageloading_bg,#pageloading").hide();
        });

        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        //添加Tab，可传3个参数
        function f_addTab(tabid, text, url, iconcss) {
            if (arguments.length == 4) {
                tab.addTabItem({ tabid: tabid, text: text, url: url, iconcss: iconcss });
            } else {
                tab.addTabItem({ tabid: tabid, text: text, url: url });
            }
        }

        //快捷菜单回调函数
        function itemclick(item) {
            switch (item.text) {
                case "管理首页":
                    f_addTab('home', '管理中心', 'center.aspx');
                    break;
                case "快捷导航":
                    //调用函数
                    break;
                case "修改密码":
                    f_addTab('manager_pwd', '修改密码', 'manager/manager_pwd.aspx');
                    break;
                default:
                    //关闭窗口
                    break;
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="pageloading_bg" id="pageloading_bg"></div>
        <div id="pageloading">数据加载中，请稍等...</div>

        <div id="global_layout" class="layout" style="width: 100%;">
            <!--头部-->
            <div position="top" class="header">
                <div class="header_box">
                    <div class="header_right">
                        <span><b><%=admin_info.Name %></b>您好，欢迎光临</span>
                        <br />
                        <a href="javascript:f_addTab('home','管理中心','center.aspx')">管理中心</a> | <a target="_blank"
                            href="../Default.aspx">预览首页</a> |
                    <asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click">安全退出</asp:LinkButton>
                    </div>
                    <a class="logo">OA Logo</a>
                </div>
            </div>

            <!--左边-->
            <div position="left" title="管理菜单" id="global_left_nav">
                <div title="频道管理" iconcss="menu-icon-model">
                    <ul class="nlist">

                        <li><a href="">会员信息管理</a></li>
                        <li><a href="">会员信息管理</a></li>
                    </ul>
                </div>


                <div title="控制面板" iconcss="menu-icon-setting">

                    <ul class="nlist">

                        <li><a href="">会员信息管理</a></li>
                        <li><a href="">会员信息管理</a></li>

                    </ul>
                </div>
                <div title="组织机构" iconcss="menu-icon-member">
                    <ul class="nlist">
                        <li><a href="javascript:f_addTab('user_list','部门管理','Department.aspx')">部门管理</a></li>
                        <li><a href="javascript:f_addTab('user_list','会员信息管理','users/user_list.aspx')">岗位管理</a></li>
                        <li><a href="">人员管理</a></li>


                    </ul>
                </div>
            </div>

            <div position="center" id="framecenter" toolsid="tab-tools-nav">
                <div tabid="home" title="管理中心" iconcss="tab-icon-home" style="height: 300px">
                    <iframe frameborder="0" name="sysMain" src="center.aspx"></iframe>
                </div>
            </div>
            <div position="bottom" class="footer">
                <div class="copyright">
                    Copyright &copy; 2013 - 2099. All Rights Reserved.
                </div>
            </div>
        </div>
    </form>
</body>
</html>
