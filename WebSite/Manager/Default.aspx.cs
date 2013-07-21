using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSOA.Model;
using JSOA.Common;
namespace JSOA.WebSite.Manager
{
    public partial class Default : System.Web.UI.Page//
    {
        protected Employee admin_info;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // admin_info = GetAdminInfo();
            }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[ConstKeys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "jsoa", -14400);
            Utils.WriteCookie("AdminPwd", "jsoa", -14400);
            Utils.WriteCookie("AdminNo", "jsoa", -14400);
          
            Response.Redirect("Login.aspx");
        }
    }
}