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
    /// <summary>
    /// Sys_Department
    /// </summary>
    public partial class Sys_Department
    {
        private readonly ISys_Department dal = DataAccess.CreateSys_Department();

        public Sys_Department()
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
        public bool Add(JSOA.Model.Sys_Department model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(JSOA.Model.Sys_Department model)
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
        public JSOA.Model.Sys_Department GetModel(string No)
        {

            return dal.GetModel(No);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public JSOA.Model.Sys_Department GetModelByCache(string No)
        {

            string CacheKey = "Sys_DepartmentModel-" + No;
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
            return (JSOA.Model.Sys_Department)objModel;
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
        public List<JSOA.Model.Sys_Department> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<JSOA.Model.Sys_Department> DataTableToList(DataTable dt)
        {
            List<JSOA.Model.Sys_Department> modelList = new List<JSOA.Model.Sys_Department>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                JSOA.Model.Sys_Department model;
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



        

        #endregion
    }
}
