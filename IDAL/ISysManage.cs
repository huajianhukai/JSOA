using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JSOA.Model;

namespace JSOA.IDAL
{
    /// <summary>
    /// 接口层-系统管理。
    /// </summary>
    public interface ISysManage
    {
        int AddTreeNode(SysNode node);
        void UpdateNode(SysNode node);
        void DelTreeNode(int nodeid);
        DataSet GetTreeList(string strWhere);
        SysNode GetNode(int NodeID);
        void AddLog(string time, string loginfo, string Particular);
        void DeleteLog(int ID);
        void DelOverdueLog(int days);
        void DeleteLog(string strWhere);
        DataSet GetLogs(string strWhere);
        DataRow GetLog(string ID);


    }
}
