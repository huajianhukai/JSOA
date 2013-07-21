using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSOA.Model
{
   
        /// <summary>
        /// Sys_Department:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
        [Serializable]
        public partial class Sys_Department
        {
            public Sys_Department()
            { }
            #region Model
            private string _no;
            private string _name;
            private string _parentno;
            private string _remarks;
            /// <summary>
            /// 
            /// </summary>
            public string No
            {
                set { _no = value; }
                get { return _no; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Name
            {
                set { _name = value; }
                get { return _name; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ParentNo
            {
                set { _parentno = value; }
                get { return _parentno; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Remarks
            {
                set { _remarks = value; }
                get { return _remarks; }
            }
            #endregion Model

        }
    
}
