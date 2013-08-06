using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JSOA.BLL;

namespace JSOA.WebSite
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Button1_Click(object sender, EventArgs e)
        {
            var v = "销售1在2013-07-15 15:10提出申请,单号[350].";
            Response.Write(v.Substring(0, 20));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}