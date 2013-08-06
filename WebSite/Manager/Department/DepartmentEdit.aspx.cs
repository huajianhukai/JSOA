using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSOA.WebSite.Manager.Department
{
    public partial class DepartmentEdit : JSOA.WebSite.ManagePage
    {
        protected string strInformation = "添加部门信息";

        public string Action
        {
            get
            {
                if (Request.QueryString["action"] != null)
                {
                    return Request.QueryString["action"];
                }
                else
                {
                    return "add";
                }
            }
        }

        public string No
        {
            get
            {
                if (Request.QueryString["No"] != null)
                {
                    return Request.QueryString["No"];
                }
                else
                {
                    return "";
                }
            }
        }

        protected void Add()
        {
            try
            {
                BLL.Sys_Department bll = new BLL.Sys_Department();
                Model.Sys_Department model = new Model.Sys_Department();
                model.ParentNo = ddlFatherDepartment.SelectedItem.Value;
                model.No = txtDeptNo.Text.ToString().Trim();
                model.Name = txtDeptName.Text.ToString().Trim();
                model.Remarks = txtRemarks.Text.ToString();
                bll.Add(model);

                JscriptMsg("添加部门成功啦！", "DepartmentList.aspx", "Success");
            }
            catch (Exception ex)
            {
                JscriptMsg(ex.Message + "添加部门失败！", "", "Error");
            }
        }

        protected void AddOrEdit()
        {
            if (Action.ToLower() == "add")
            {
                Add();
            }
            else
            {
                Edit();
            }
        }

        /// <summary>
        /// 下拉框绑定所有部门
        /// </summary>
        protected void BindDepartmentList()
        {
            BLL.Sys_Department sysDt = new BLL.Sys_Department();
            DataTable dtList = sysDt.GetAllList().Tables[0];

            for (int i = 0; i < dtList.Rows.Count; i++)
            {
                ddlFatherDepartment.Items.Add(new ListItem(dtList.Rows[i]["Name"].ToString() + "(" + dtList.Rows[i]["No"].ToString() + ")", dtList.Rows[i]["No"].ToString()));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddOrEdit();
        }

        protected void Edit()
        {
            try
            {
                BLL.Sys_Department bll = new BLL.Sys_Department();
                Model.Sys_Department model = new Model.Sys_Department();
                model.ParentNo = ddlFatherDepartment.SelectedItem.Value;
                model.No = txtDeptNo.Text.ToString().Trim();
                model.Name = txtDeptName.Text.ToString().Trim();
                model.Remarks = txtRemarks.Text.ToString();

                bll.Update(model);

                JscriptMsg("修改部门成功啦！", "DepartmentList.aspx", "Success");
            }
            catch (Exception ex)
            {
                JscriptMsg(ex.Message + "修改部门失败！", "", "Error");
            }
        }

        protected void GetDepartment()
        {
            Model.Sys_Department model = new Model.Sys_Department();
            BLL.Sys_Department bll = new BLL.Sys_Department();
            if (!string.IsNullOrWhiteSpace(No))
            {
                model = bll.GetModel(No);
                if (model != null)
                {
                    ddlFatherDepartment.SelectedValue = model.ParentNo;
                    txtDeptName.Text = model.Name;
                    txtDeptNo.Text = model.No;
                    txtRemarks.Text = model.Remarks;
                    txtDeptNo.Enabled = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDepartmentList();
                if (Action.ToLower() == "add")
                {
                    strInformation = "添加部门信息";
                }
                else
                {
                    strInformation = "修改部门信息";
                    GetDepartment();
                }
            }
        }
    }
}