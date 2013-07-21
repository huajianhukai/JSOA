using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JSOA.Common;
using JSOA.Model;
using JSOA.BLL;

namespace JSOA.WebSite
{
    public class ManagePage:System.Web.UI.Page
    {

        //protected internal Model.siteconfig siteConfig;

        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
           // siteConfig = new BLL.siteconfig().loadConfig(Utils.GetXmlMapPath("Configpath"));//Configpath
        }

        private void ManagePage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='Login.aspx'</script>");
                Response.End();
            }
        }

        #region 管理员============================================
        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session为Null
            if (Session[ConstKeys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string adminno = Utils.GetCookie("AdminNo", "jsoa"); //解密用户名
                string adminpwd = Utils.GetCookie("AdminPwd", "jsoa");

                
                if (adminno  != "" && adminpwd != "")
                {
                    BLL.BllEmployee bllemp = new BLL.BllEmployee();

                    Model.Employee model = bllemp.GetModel(adminno);
                   
                    if (model != null&&model.Pass==adminpwd)
                    {
                        Session[ConstKeys.SESSION_ADMIN_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得管理员信息
        /// </summary>
        public Model.Employee GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                Model.Employee model = Session[ConstKeys.SESSION_ADMIN_INFO] as Model.Employee;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 检查管理员权限
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="action_type">操作类型</param>
        public void ChkAdminLevel(int channel_id, string action_type)
        {
          
        }

        /// <summary>
        /// 检查管理员权限
        /// </summary>
        /// <param name="channel_name">栏目名称</param>
        /// <param name="action_type">操作类型</param>
        public void ChkAdminLevel(string channel_name, string action_type)
        {
            
        }

        /// <summary>
        /// 检查管理员权限
        /// </summary>
        /// <param name="channel_name">栏目名称</param>
        /// <param name="action_type">操作类型</param>
        /// <returns>bool</returns>
        public bool IsAdminLevel(string channel_name, string action_type)
        {
            return true;
        }

        #endregion

        #region JS提示============================================

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }

        /// <summary>
        /// 带回传函数的添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        /// <param name="callback">JS回调函数</param>
        protected void JscriptMsg(string msgtitle, string url, string msgcss, string callback)
        {
            string msbox = "parent.jsprint(\"" + msgtitle + "\", \"" + url + "\", \"" + msgcss + "\", " + callback + ")";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox, true);
        }
        #endregion

    }
}