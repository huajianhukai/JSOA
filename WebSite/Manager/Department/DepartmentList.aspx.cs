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
using JSOA.Common;
namespace JSOA.WebSite.Manager.Department
{
    public partial class DepartmentList : JSOA.WebSite.ManagePage 
    {
        string strWhere = string.Empty;
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!this.Page.IsPostBack)
            {
                if (Request.QueryString["keywords"] != null)
                {
                    txtKeywords.Text = Request.QueryString["keywords"];
                    strWhere = "and d.Name like '%" + Common.Utils.FiltRiskChar(txtKeywords.Text.Trim()) + "%'";

                }
                 BindData();
            }
           
            this.ListPage.ChangePage += new ChangePageHandle(BindData);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtKeywords.Text.Trim()))
            {

                strWhere = "and d.Name like '%" + Common.Utils.FiltRiskChar(txtKeywords.Text.Trim()) + "%'";
                BindData();
            }
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.Sys_Department bll = new BLL.Sys_Department();

            string ids = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string  id = "'"+((HiddenField)rptList.Items[i].FindControl("hidId")).Value+"'";
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    ids += id + ",";
                }

            }

            try
            {
                bll.DeleteList(ids.TrimEnd(','));
               
               
                JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("DepartmentList.aspx", "keywords={0}", this.txtKeywords.Text), "Success");
        

            }
            catch (Exception ex)
            {
                JscriptMsg(ex.Message + "批量删除失败！", "", "Error");
            }

          
       
        }


        public void BindData()
        {
            int nIndex = this.ListPage.PageIndex;     //第几个页面
            int currentPageCount = this.ListPage.PageSize;      //页面的显示容量大小


            DataTable dt = Common.PageList.GetPageList("Sys_Department  as d left join Sys_Department  as f on d.ParentNo =f.No",
                "d.No,d.Name,f.Name As FName,d.Remarks",
                "No",
                1,
                strWhere,
                "d.No",
                0,
                 nIndex,
                 currentPageCount,
                 ref this.ListPage.TotalPageTemp);
             

            if (dt.Rows.Count > 0)
            {
                int n = dt.Rows.Count;
            }

            rptList.DataSource = dt;
            rptList.DataBind();
        }

    
    }
}