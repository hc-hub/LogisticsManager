using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlRoleName();
                BindgvUser();
                
            }      
        }
        public void BindgvUser()
        {
            Users u = new Users();
            u.UserName = txtName.Text;
            u.Sex =rdlSex.SelectedValue.ToString();
            u.Account = txtAccount.Text;
            u.Phone = txtPhone.Text;
            u.Email = txtEmail.Text;
            u.FK_RoleID = Convert.ToInt16(ddlRoleName.SelectedValue);
            u.IsDelete = rdlYesNo.SelectedValue;
            u.BeginInTime = txtBeginTime.Value;
            u.EndInTime = txtEndTime.Value;
            u.UpdateBeginTime = txtUpdateBeginTime.Value;
            u.UpdateEndTime = txtUpdateEndTime.Value;
            int recordCount = 0;
            int pageSize = AspNetPager1.PageSize;
            int pageIndex = AspNetPager1.CurrentPageIndex;
            gvUser.DataSource = LogisticsManagerBLL.UserInfoBLL.BindgvUser(u,pageSize,pageIndex,out recordCount);
            AspNetPager1.RecordCount = recordCount;
            gvUser.DataBind();
        }
        public void BindddlRoleName()
        {
            ddlRoleName.DataSource = LogisticsManagerBLL.RoleInfoBLL.GetRoleInfo();
            ddlRoleName.DataTextField = "RoleName";
            ddlRoleName.DataValueField = "RoleID";
            ddlRoleName.DataBind();
            ddlRoleName.Items.Insert(0,new ListItem("不填","0"));
        }      
        public string ChangeSex(int sex)
        {
            if (sex==0)
            {
                return "男";
            }
            else
            {
                return "女";
            }
        }
        public string ChangeRoleName(int roleId)
        {
            return LogisticsManagerBLL.RoleInfoBLL.GetRoleNameByRoleID(roleId);
        }
        public string ChangeIsDelete(int isDelete)
        {
            if (isDelete==0)
            {
                return "否";
            }
            else
            {
                return "是";
            }
        }

        protected void rdlSex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BindgvUser();
        }

        protected void rdlYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUser.EditIndex = e.NewEditIndex;
            BindgvUser();            
        }

        protected void gvUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUser.EditIndex = -1;
            BindgvUser();
        }

        protected void gvUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Users user = new Users();
            user.UserID = Convert.ToInt32(gvUser.DataKeys[e.RowIndex].Value);
            user.UserName = ((TextBox)(gvUser.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
            user.Sex = ((DropDownList)(gvUser.Rows[e.RowIndex].Cells[1].FindControl("gvddlSex"))).SelectedValue;
            user.Account = ((TextBox)(gvUser.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            user.Phone = ((TextBox)(gvUser.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
            user.Email = ((TextBox)(gvUser.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            user.FK_RoleID = Convert.ToInt32(((DropDownList)(gvUser.Rows[e.RowIndex].Cells[5].FindControl("gvddlRole"))).SelectedValue);
            if (LogisticsManagerBLL.UserInfoBLL.UpdateUserInfoById(user)>0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!')", true);
                gvUser.EditIndex = -1;
                BindgvUser();
                return;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败!')", true);
                BindgvUser();
                return;
            }
            
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
            txtBeginTime.Value="";
            txtEmail.Text = "";
            txtEndTime.Value = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtUpdateBeginTime.Value = "";
            txtUpdateEndTime.Value = "";
            ddlRoleName.SelectedIndex = 0;
            rdlSex.SelectedIndex = 0;
            rdlYesNo.SelectedIndex = 0;
        }

        protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((DropDownList)e.Row.FindControl("gvddlRole") != null)
            {
                DropDownList ddlstdepartment = e.Row.FindControl("gvddlRole") as DropDownList;
                DataTable ds = LogisticsManagerBLL.RoleInfoBLL.GetRoleInfo();
                ddlstdepartment.DataSource = ds;
                ddlstdepartment.DataTextField = "RoleName";
                ddlstdepartment.DataValueField = "RoleID";
                ddlstdepartment.DataBind();
            }
            if ((DropDownList)e.Row.FindControl("gvddlSex") != null)
            {
                DropDownList ddlSex = e.Row.FindControl("gvddlSex") as DropDownList;
                ddlSex.Items.Insert(0,new ListItem("男","0"));
                ddlSex.Items.Insert(1, new ListItem("女", "1"));
            }
        }

        protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUser.DataKeys[e.RowIndex].Value);
            if (LogisticsManagerBLL.UserInfoBLL.DeleteUserById(userId)>0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功!')", true);
                BindgvUser();
                return;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败!')", true);
                BindgvUser();
                return;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindgvUser();
        }

    }
}