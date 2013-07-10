using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSOA.Model;
using JSOA.BLL;

namespace JSOA.WebSite.Manager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.txtName.Text.Trim();
            string passWord = this.txtPass.Text.Trim();

            Employee emp = new Employee();
            BllEmployee bllemp=new BllEmployee ();

            emp = bllemp.GetModel(userName);
            if (emp != null)
            {
                if (emp.Pass == JSOA.Common.Encrypt.MD5(passWord, 32))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('密码不正确！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('用户不存在！');</script>");
            }


        }
    }
}