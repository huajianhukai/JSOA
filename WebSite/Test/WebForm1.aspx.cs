using System;
using System.Data;
using System.Data.SqlClient;

namespace JSOA.WebSite.Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public void BindData()
        {
            int nIndex = this.ListPage.PageIndex;     //第几个页面
            int currentPageCount = this.ListPage.PageSize;      //页面的显示容量大小

            DataTable dt = GetDataSourceByDAL(nIndex, currentPageCount, ref this.ListPage.TotalPageTemp);

            int n = dt.Rows.Count;
            for (int i = 0; i < n; i++) {
                Response.Write(dt.Rows[0]["ShipName"].ToString());
                Response.Write("<br/>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string test = JSOA.Common.Encrypt.MD5("pub", 32);
            Response.Write(test);

            if (!this.Page.IsPostBack)
            {
                // BindData();
            }
            this.ListPage.ChangePage += new ChangePageHandle(PaginationDemo_ChangePage);
        }

        private void PaginationDemo_ChangePage()
        {
            BindData();
        }

        #region codemaid测试

        /// <summary>
        /// 数据源，改数据源应从 DAL层获取，为了demo简单，写在一起
        /// </summary>
        /// <param name="nIndex">第几个页面</param>
        /// <param name="CurrentPageCount">页面的显示容量大小</param>
        /// <param name="PageCount">数据源总条数</param>
        /// <returns></returns>
        protected DataTable GetDataSourceByDAL(int nIndex, int CurrentPageCount, ref int Count)
        {
            string strConn = @"server=ZHANGZHI-PC;database=Northwind;user id=sa;password=qazwsx123;";
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_ListPage";
            cmd.Connection = conn;

            cmd.Parameters.Add("@tblName", System.Data.SqlDbType.NVarChar).Value = "[orders]  join [Order Details] on [orders].orderID=[Order Details].OrderID";
            //----要显示的字段列表
            cmd.Parameters.Add("@fldName", System.Data.SqlDbType.NVarChar).Value = "[orders].OrderDate,[orders].orderID,[orders].CustomerID,[orders].ShipName";
            //----每页显示的记录个数
            cmd.Parameters.Add("@pageSize", System.Data.SqlDbType.Int).Value = CurrentPageCount;
            // ----要显示那一页的记录
            cmd.Parameters.Add("@page", System.Data.SqlDbType.Int).Value = nIndex + 1;

            cmd.Parameters.Add("@pageCount", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            // ----查询到的记录数
            cmd.Parameters.Add("@Counts", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;//返回符合条件的总记录数
            // ----排序字段列表或条件
            cmd.Parameters.Add("@fldSort", System.Data.SqlDbType.NVarChar).Value = "OrderDate";
            //  ----排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')
            cmd.Parameters.Add("@Sort", System.Data.SqlDbType.Bit).Value = 0;
            // ----查询条件,不需where
            cmd.Parameters.Add("@strCondition", System.Data.SqlDbType.NVarChar).Value = "";
            // ----主表的主键
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar).Value = "[orders].orderID";
            //----是否添加查询字段的 DISTINCT 默认0不添加/1添加
            cmd.Parameters.Add("@Dist", System.Data.SqlDbType.Bit).Value = 0;

            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Count = Convert.ToInt32(cmd.Parameters["@Counts"].Value.ToString());
            conn.Close();

            return dt;
        }

        #endregion codemaid测试
    }
}