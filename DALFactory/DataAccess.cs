using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace JSOA.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

       
        


        /// <summary>
        /// 创建Employee数据层接口。
        /// </summary>
        public static JSOA.IDAL.IEmployee CreateEmployee()
        {

            string ClassNamespace = AssemblyPath + ".DalEmployee";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (JSOA.IDAL.IEmployee)objType;
        }


        /// <summary>
        /// 创建Sys_Department数据层接口。
        /// </summary>
        public static JSOA.IDAL.ISys_Department CreateSys_Department()
        {

            string ClassNamespace = AssemblyPath + ".Sys_Department";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (JSOA.IDAL.ISys_Department)objType;
        }

    }
}
