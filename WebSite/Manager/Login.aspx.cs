using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSOA.Model;
using JSOA.BLL;
using JSOA.Common;

namespace JSOA.WebSite.Manager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Text = Utils.GetCookie("RememberName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userNo = txtUserName.Text.Trim();
            string userPwd = txtUserPwd.Text.Trim();
            string code = txtCode.Text.Trim();

            if (userNo.Equals("") || userPwd.Equals(""))
            {
                lblTip.Visible = true;
                lblTip.Text = "请输入用户名或密码";
                return;
            }

            if (code.Equals(""))
            {
                lblTip.Visible = true;
                lblTip.Text = "请输入验证码";
                return;
            }

            if (Session[ConstKeys.SESSION_CODE] == null)
            {
                lblTip.Visible = true;
                lblTip.Text = "系统找不到验证码";
                return;
            }

            if (code.ToLower() != Session[ConstKeys.SESSION_CODE].ToString().ToLower())
            {
                lblTip.Visible = true;
                lblTip.Text = "验证码输入不正确";
                return;
            }

            Employee modelemp = new Employee();
            BllEmployee bllemp=new BllEmployee ();

            modelemp = bllemp.GetModel(userNo);
            if (modelemp != null)
            {
                if (modelemp.Pass == JSOA.Common.Encrypt.MD5(userPwd, 32))
                {
                    Session[ConstKeys.SESSION_ADMIN_INFO] = modelemp;
                    Session.Timeout = 45;

                    //登陆日志



                    //写入Cookies
                    if (cbRememberId.Checked)
                    {
                        Utils.WriteCookie("RememberName", modelemp.No, 14400);
                    }
                    else
                    {
                        Utils.WriteCookie("RememberName", modelemp.No, -14400);
                    }
                    Utils.WriteCookie("AdminName", "jsoa", modelemp.Name);
                    Utils.WriteCookie("AdminPwd", "jsoa", modelemp.Pass);
                    Response.Redirect("Default.aspx");
                    return;



                }
                else
                {
                    lblTip.Visible = true;
                    lblTip.Text = "密码有误";
                    return;
                }
            }
            else
            {
                lblTip.Visible = true;
                lblTip.Text = "用户名不存在";
                return;
            }


        }

       

       
    }
}