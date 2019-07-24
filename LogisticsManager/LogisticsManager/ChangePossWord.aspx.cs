using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogisticsManagerModel;

namespace LogisticsManager
{
    public partial class ChangePossWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            string account = txtAccount.Text;
            string oldPwd = txtPwd.Text;
            string newPwd = txtNewPwd.Text;
            string newconPwd = txtNewConPwd.Text;
            if (string.IsNullOrWhiteSpace(account))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入账号！')", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(oldPwd)|| string.IsNullOrWhiteSpace(newPwd) || string.IsNullOrWhiteSpace(newconPwd))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入密码！')", true);
                return;
            }
            if (oldPwd==newPwd||oldPwd==newconPwd)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('新密码不能与旧密码一样！')", true);
                return;
            }
            if (newPwd!= newconPwd)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('两次密码输入不一致！')", true);
                return;
            }
            else
            {
                int userid = (Session["User"] as List<Users>)[0].UserID;
                Users u = new Users()
                {
                    Account = account,
                    PassWord = oldPwd,
                    UserID = userid,
                    NewPwd =newPwd                    
                };
                int result = LogisticsManagerBLL.UserInfoBLL.ChangePwd(u);
                if (result>0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功！')", true);
                    return;
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入正确的用户名和密码！')", true);
                    return;
                }
            }
                  
        }
    }
}