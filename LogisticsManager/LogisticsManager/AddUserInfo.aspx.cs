using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class AddUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindddlRoleName();
        }
        public void BindddlRoleName()
        {
            ddlRoleName.DataSource = LogisticsManagerBLL.RoleInfoBLL.GetRoleInfo();
            ddlRoleName.DataTextField = "RoleName";
            ddlRoleName.DataValueField = "RoleID";
            ddlRoleName.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string UserName = txtName.Text;
            int SexId = Convert.ToInt32(rdlSex.SelectedValue);
            string Account = txtAccount.Text;
            string PassWord = txtPwd.Text;
            string ConPassWord = txtConpwd.Text;
            string Phone = txtPhone.Text;
            string Email = txtEmail.Text;
            int FK_RoleID = Convert.ToInt32(ddlRoleName.SelectedValue);
            if (string.IsNullOrWhiteSpace(UserName))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('请输入姓名！')",true);
                return;
            }
            if (string.IsNullOrWhiteSpace(Account))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入账号！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(PassWord)|| string.IsNullOrWhiteSpace(ConPassWord))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入密码！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入电话！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入邮箱！')", true);
                return;
            }           
            Users u = new Users() {
                UserName = txtName.Text,
                SexId = Convert.ToInt32(rdlSex.SelectedValue),
                Account = txtAccount.Text,
                PassWord = txtPwd.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                FK_RoleID = Convert.ToInt32(ddlRoleName.SelectedValue)
            };
            LogisticsManagerBLL.UserInfoBLL.AddUser(u);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtPwd.Text = "";
            txtEmail.Text = "";
            txtAccount.Text = "";
            txtConpwd.Text = "";
            ddlRoleName.SelectedIndex = 0;
            rdlSex.SelectedIndex = 0;
            rdlIsDelete.SelectedIndex = 0;
        }
    }
}