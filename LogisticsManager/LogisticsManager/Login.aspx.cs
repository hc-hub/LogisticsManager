using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Value;
            string userpwd = txtPwd.Value;
            if (string.IsNullOrWhiteSpace(account))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入账号!')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(userpwd))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入密码!')", true);
                return;
            }
            Users u = new Users { Account = account, PassWord = userpwd };
            List<Users> User = new List<Users>();
            User = LogisticsManagerBLL.UserInfoBLL.Login(u);
            if (User.Count > 0)
            {
                Session["User"] = User;
                SysLog sys = new SysLog();
                sys.Behavior = User[0].UserName + ":登陆系统";
                sys.FK_TypeID = 1;
                sys.FK_UserID = User[0].UserID;
                sys.Parameters = $"{account},{userpwd}";
                sys.ProcName = "无存储过程";
                sys.Exception = "0";
                sys.IsException = 0;
                LogisticsManagerBLL.SysLogBLL.AddSysLog(sys);
                Response.Redirect("Index.aspx");

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('用户名或密码不存在!')", true);
                return;
            }


        }
    }
}