using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSOA.Model;
namespace JSOA.IDAL
{
    /// <summary>
    /// 接口层Sys_Department
    /// </summary>
    public interface ISys_Department
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string No);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(JSOA.Model.Sys_Department model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(JSOA.Model.Sys_Department model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string No);
        bool DeleteList(string Nolist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        JSOA.Model.Sys_Department GetModel(string No);
        JSOA.Model.Sys_Department DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    } 
}
