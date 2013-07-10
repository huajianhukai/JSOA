using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSOA.Model
{
    /// <summary>
    /// 员工实体类
    /// </summary>
    [Serializable]
    public partial class Employee
    {
        public Employee()
        { }
        #region Model
        private string _no;
        private string _name;
        private string _pass;
        private string _fk_dept;
        private string _fk_unit;
        private string _sid;
        /// <summary>
        /// emp number
        /// </summary>
        public string No
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// emp name
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        ///  pass word 
        /// </summary>
        public string Pass
        {
            set { _pass = value; }
            get { return _pass; }
        }
        /// <summary>
        /// emp department
        /// </summary>
        public string FK_Dept
        {
            set { _fk_dept = value; }
            get { return _fk_dept; }
        }
        /// <summary>
        ///  emp  unit
        /// </summary>
        public string FK_Unit
        {
            set { _fk_unit = value; }
            get { return _fk_unit; }
        }
        /// <summary>
        /// nothing
        /// </summary>
        public string SID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        #endregion Model

    }
}
