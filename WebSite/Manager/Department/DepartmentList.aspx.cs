using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

using JSOA.Model;
using JSOA.BLL;
namespace JSOA.WebSite.Manager.Department
{
    public partial class DepartmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                 BindData();
            }
            this.ListPage.ChangePage += new ChangePageHandle(BindData);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }


        public void BindData()
        {
            int nIndex = this.ListPage.PageIndex;     //第几个页面
            int currentPageCount = this.ListPage.PageSize;      //页面的显示容量大小

            DataTable dt = Common.PageList.GetPageList("[Sys_Department]",
                "[Sys_Department].No,[Sys_Department].Name,[Sys_Department].ParentNo,[Sys_Department].Remarks",
                "No",
                "",
                "No",
                 nIndex,
                 currentPageCount,
                 ref this.ListPage.TotalPageTemp
                );

            int n = dt.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                Response.Write(dt.Rows[0]["No"].ToString());
                Response.Write("<br/>");
            }

        }
    }
}