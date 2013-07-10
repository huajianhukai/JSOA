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

        #region CreateSysManage
        public static JSOA.IDAL.ISysManage CreateSysManage()
        {
            //方式1			
            //return (Maticsoft.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //方式2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (JSOA.IDAL.ISysManage)objType;
        }
        #endregion



        /// <summary>
        /// 创建Department数据层接口。
        /// </summary>
        //public static JSOA.IDAL.IDepartment CreateDepartment()
        //{

        //    string ClassNamespace = AssemblyPath + ".Department";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (JSOA.IDAL.IDepartment)objType;
        //}


        /// <summary>
        /// 创建DeptStation数据层接口。
        /// </summary>
        //public static JSOA.IDAL.IDeptStation CreateDeptStation()
        //{

        //    string ClassNamespace = AssemblyPath + ".DeptStation";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (JSOA.IDAL.IDeptStation)objType;
        //}


        /// <summary>
        /// 创建EmpDept数据层接口。
        /// </summary>
        //public static JSOA.IDAL.IEmpDept CreateEmpDept()
        //{

        //    string ClassNamespace = AssemblyPath + ".EmpDept";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (JSOA.IDAL.IEmpDept)objType;
        //}


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
        /// 创建Port_EmpStation数据层接口。
        /// </summary>
        //public static JSOA.IDAL.IPort_EmpStation CreatePort_EmpStation()
        //{

        //    string ClassNamespace = AssemblyPath + ".Port_EmpStation";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IDAL.IPort_EmpStation)objType;
        //}


        /// <summary>
        /// 创建Station数据层接口。
        /// </summary>
        //public static IDAL.IStation CreateStation()
        //{

        //    string ClassNamespace = AssemblyPath + ".Station";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IDAL.IStation)objType;
        //}


        /// <summary>
        /// 创建Unit数据层接口。
        /// </summary>
        //public static IDAL.IUnit CreateUnit()
        //{

        //    string ClassNamespace = AssemblyPath + ".Unit";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IDAL.IUnit)objType;
        //}


        /// <summary>
        /// 创建WF_Emp数据层接口。
        /// </summary>
        //public static IDAL.IWF_Emp CreateWF_Emp()
        //{

        //    string ClassNamespace = AssemblyPath + ".WF_Emp";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IDAL.IWF_Emp)objType;
        //}

    }
}
