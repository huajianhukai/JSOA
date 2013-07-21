using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace JSOA.Common
{
   public  class PageList
    {

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tblName">表名称</param>
        /// <param name="fldName">显示字段</param>
        /// <param name="fldSort">排序</param>
        /// <param name="strwhere">条件</param>
        /// <param name="ID">主键</param>
        /// <param name="nIndex">页</param>
        /// <param name="CurrentPageCount">每页显示的记录个数</param>
        /// <param name="Count">总数</param>
        /// <returns></returns>
        public static  DataTable GetPageList(string tblName, string fldName, string fldSort, string strwhere, string ID, int nIndex, int CurrentPageCount, ref int Count)
        {
            string connectionString = ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "proc_ListPage";
            cmd.Connection = conn;

            cmd.Parameters.Add("@tblName", System.Data.SqlDbType.NVarChar).Value = tblName;
            //----要显示的字段列表
            cmd.Parameters.Add("@fldName", System.Data.SqlDbType.NVarChar).Value = fldName;
            //----每页显示的记录个数
            cmd.Parameters.Add("@pageSize", System.Data.SqlDbType.Int).Value = CurrentPageCount;
            // ----要显示那一页的记录
            cmd.Parameters.Add("@page", System.Data.SqlDbType.Int).Value = nIndex + 1;

            cmd.Parameters.Add("@pageCount", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            // ----查询到的记录数
            cmd.Parameters.Add("@Counts", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;//返回符合条件的总记录数
            // ----排序字段列表或条件
            cmd.Parameters.Add("@fldSort", System.Data.SqlDbType.NVarChar).Value = fldSort;
            //  ----排序方法，0为升序，1为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')
            cmd.Parameters.Add("@Sort", System.Data.SqlDbType.Bit).Value = 0;
            // ----查询条件,不需where
            cmd.Parameters.Add("@strCondition", System.Data.SqlDbType.NVarChar).Value = strwhere;
            // ----主表的主键
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.NVarChar).Value = ID;
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




        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
    
    }
}
