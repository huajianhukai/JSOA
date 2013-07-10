using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSOA.Model;
using JSOA.DALFactory;
using JSOA.IDAL;
using JSOA.Common;

namespace JSOA.BLL
{
    // <summary>
    /// Employee
    /// </summary>
    public partial class BllEmployee
    {
        private readonly IEmployee dal = DataAccess.CreateEmployee();
        public BllEmployee()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string No)
        {
            return dal.Exists(No);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(JSOA.Model.Employee model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(JSOA.Model.Employee model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string No)
        {

            return dal.Delete(No);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Nolist)
        {
            return dal.DeleteList(Nolist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JSOA.Model.Employee GetModel(string No)
        {

            return dal.GetModel(No);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public JSOA.Model.Employee GetModelByCache(string No)
        {

            string CacheKey = "EmployeeModel-" + No;
            object objModel = JSOA.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(No);
                    if (objModel != null)
                    {
                        int ModelCache = JSOA.Common.ConfigHelper.GetConfigInt("ModelCache");
                        JSOA.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (JSOA.Model.Employee)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<JSOA.Model.Employee> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<JSOA.Model.Employee> DataTableToList(DataTable dt)
        {
            List<JSOA.Model.Employee> modelList = new List<JSOA.Model.Employee>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                JSOA.Model.Employee model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
