using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JSOA.IDAL;
using JSOA.DBUtility;

namespace JSOA.SQLServerDAL
{
    // <summary>
    /// 数据访问类:Employee
    /// </summary>
    public partial class DalEmployee : IEmployee
    {
        public DalEmployee()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string No)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Employee");
            strSql.Append(" where No=@No ");
            SqlParameter[] parameters = {
					new SqlParameter("@No", SqlDbType.VarChar,20)			};
            parameters[0].Value = No;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(JSOA.Model.Employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Employee(");
            strSql.Append("No,Name,Pass,FK_Dept,FK_Unit,SID)");
            strSql.Append(" values (");
            strSql.Append("@No,@Name,@Pass,@FK_Dept,@FK_Unit,@SID)");
            SqlParameter[] parameters = {
					new SqlParameter("@No", SqlDbType.VarChar,20),
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Pass", SqlDbType.VarChar,100),
					new SqlParameter("@FK_Dept", SqlDbType.VarChar,100),
					new SqlParameter("@FK_Unit", SqlDbType.VarChar,100),
					new SqlParameter("@SID", SqlDbType.VarChar,20)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Pass;
            parameters[3].Value = model.FK_Dept;
            parameters[4].Value = model.FK_Unit;
            parameters[5].Value = model.SID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(JSOA.Model.Employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Employee set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Pass=@Pass,");
            strSql.Append("FK_Dept=@FK_Dept,");
            strSql.Append("FK_Unit=@FK_Unit,");
            strSql.Append("SID=@SID");
            strSql.Append(" where No=@No ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Pass", SqlDbType.VarChar,100),
					new SqlParameter("@FK_Dept", SqlDbType.VarChar,100),
					new SqlParameter("@FK_Unit", SqlDbType.VarChar,100),
					new SqlParameter("@SID", SqlDbType.VarChar,20),
					new SqlParameter("@No", SqlDbType.VarChar,20)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Pass;
            parameters[2].Value = model.FK_Dept;
            parameters[3].Value = model.FK_Unit;
            parameters[4].Value = model.SID;
            parameters[5].Value = model.No;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string No)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
            strSql.Append(" where No=@No ");
            SqlParameter[] parameters = {
					new SqlParameter("@No", SqlDbType.VarChar,20)			};
            parameters[0].Value = No;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Nolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
            strSql.Append(" where No in (" + Nolist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JSOA.Model.Employee GetModel(string No)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 No,Name,Pass,FK_Dept,FK_Unit,SID from Employee ");
            strSql.Append(" where No=@No ");
            SqlParameter[] parameters = {
					new SqlParameter("@No", SqlDbType.VarChar,20)			};
            parameters[0].Value = No;

            JSOA.Model.Employee model = new JSOA.Model.Employee();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JSOA.Model.Employee DataRowToModel(DataRow row)
        {
            JSOA.Model.Employee model = new JSOA.Model.Employee();
            if (row != null)
            {
                if (row["No"] != null)
                {
                    model.No = row["No"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Pass"] != null)
                {
                    model.Pass = row["Pass"].ToString();
                }
                if (row["FK_Dept"] != null)
                {
                    model.FK_Dept = row["FK_Dept"].ToString();
                }
                if (row["FK_Unit"] != null)
                {
                    model.FK_Unit = row["FK_Unit"].ToString();
                }
                if (row["SID"] != null)
                {
                    model.SID = row["SID"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select No,Name,Pass,FK_Dept,FK_Unit,SID ");
            strSql.Append(" FROM Employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" No,Name,Pass,FK_Dept,FK_Unit,SID ");
            strSql.Append(" FROM Employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.No desc");
            }
            strSql.Append(")AS Row, T.*  from Employee T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

      
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Employee";
            parameters[1].Value = "No";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }



        /// <summary>
        /// 分页存储过程
        /// </summary>
        /// <param name="tbName">查询表名</param>
        /// <param name="keyorder">查询排序</param>
        /// <param name="keymain">查询主键</param>
        /// <param name="columns">查询字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="PageSize">每页数量</param>
        /// <param name="PageIndex">当前页数</param>
        /// <param name="RowsCount">记录总数</param>
        /// <param name="PageCount">分页总数</param>
        /// <returns></returns>
        public  DataSet Proc_DataSet(string tbName, string keyorder, string keymain, string columns, string strWhere, int PageSize, int PageIndex, int RowsCount, int PageCount)
        {
            SqlParameter[] sp ={
                new SqlParameter("@tbName",tbName), // -- 查询表名
                new SqlParameter("@fldName",columns), // -- 查询字段
                new SqlParameter("@strWhere",strWhere), //-- 查询条件
                new SqlParameter("@PageSize",PageSize), //-- 页大小
                new SqlParameter("@PageIndex",PageIndex), //--当前页
                new SqlParameter("@RowsCount",RowsCount), //--记录总数
                new SqlParameter("@PageCount",PageCount) // ----页面总数
            };
           return DbHelperSQL.RunProcedure("Proc_Qubernet", sp,"ds");
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
