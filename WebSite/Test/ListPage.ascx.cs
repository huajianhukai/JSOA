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

namespace JSOA.WebSite.Test
{
    public delegate void ChangePageHandle();
    public partial class ListPage : System.Web.UI.UserControl
    {
        public event ChangePageHandle ChangePage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.PageTotal = TotalPageTemp;
                BindControl();
            }
        }

        #region 定义属性：分页大小、当前分页索引、总页数
        public int PageSize
        {
            get { return int.Parse(ddlPageSize.Text); }
        }

        public int PageIndex
        {
            get
            {
                if (ViewState["PageIndex"] != null)
                    return (int)ViewState["PageIndex"];
                else
                    return 0;
            }
            set { ViewState["PageIndex"] = value; }
        }
        public int PageTotal
        {
            get
            {
                if (ViewState["PageTotal"] != null)
                    return Convert.ToInt32(ViewState["PageTotal"]);
                else
                    return 0;
            }
            set { ViewState["PageTotal"] = value; }
        }

        public int TotalPageTemp = 0;//临时用的，用于显示最后一页时
        #endregion

        public void BindControl()
        {
            lbtFirstPage.Enabled = PageIndex != 0;
            lbtPrePage.Enabled = PageIndex != 0;

            int totalCount = PageTotal;
            int pageCount = Convert.ToInt32(Math.Ceiling(totalCount * 1.0 / PageSize));

            lbtNextPage.Enabled = PageIndex < (pageCount - 1);
            lbtLastPage.Enabled = PageIndex < (pageCount - 1);

            ddlPager.Items.Clear();
            for (int i = 1; i <= pageCount; i++)
            {
                ddlPager.Items.Add(i.ToString());
            }

            try
            {
                ddlPager.SelectedIndex = PageIndex;
            }
            catch { }
            LabelPager.Text = string.Format("共<font style='color:red;'>{0}</font>条记录&nbsp;共<font style='color:red;'>{1}</font>页&nbsp;当前第<font style='color:red;'>{2}</font>页&nbsp;", totalCount, pageCount, PageIndex + 1);
        }

        /// <summary>
        /// 分页的几个按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtPage_Click(object sender, EventArgs e)
        {
            switch (((LinkButton)sender).CommandName)
            {
                case "FirstPage":
                    PageIndex = 0;
                    break;
                case "PrePage":
                    PageIndex -= 1;
                    break;
                case "NextPage":
                    PageIndex += 1;
                    break;
                case "LastPage":
                    int totalCount = this.PageTotal;
                    PageIndex = (totalCount == 0 ? 1 : ((totalCount + PageSize) - 1) / PageSize) - 1;
                    break;
            }
            this.ChangePage();
            BindControl();
        }

        protected void ddlPager_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageIndex = this.ddlPager.SelectedIndex;
            this.ChangePage();
            BindControl();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageIndex = 0;
            this.ChangePage();
            BindControl();
        }
    }
}