using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace LogisticsManager
{
    /// <summary>
    /// Login1 的摘要说明
    /// </summary>
    public class Login1 : IHttpHandler, IReadOnlySessionState

    {

        public void ProcessRequest(HttpContext context)
        {
            string Account = context.Request["Account"];
            string Pwd = context.Request["Password"].ToString();
            string getMsg = "";
            if (string.IsNullOrWhiteSpace(Account))
            {
                getMsg = "请输入用户名";
                context.Response.Write(getMsg);
                return;
            }

            if (string.IsNullOrWhiteSpace(Pwd))
            {
                getMsg = "请输入密码";
                context.Response.Write(getMsg);
                return;
            }

            Users user = new Users();
            user.Account = Account;
            user.PassWord = Pwd;
           List<Users> result = LogisticsManagerBLL.UserInfoBLL.Login(user);

            context.Session["User"] = result;

            if (result != null)
            {
                getMsg = "登陆成功";
                context.Response.Write(getMsg);

                SysLog sy = new SysLog();
                sy.Behavior = $"用户" + result[0].UserName + "：登录";
                sy.FK_TypeID = 1;
                sy.Parameters = $"{Account},{Pwd}";
                sy.ProcName = "无存储过程";
                sy.Exception = "0";
                sy.IsException = 0;

                sy.FK_UserID = result[0].UserID;

                LogisticsManagerBLL.SysLogBLL.AddSysLog(sy);
               


            }
            else
            {
                getMsg = "登陆失败";
                context.Response.Write(getMsg);
            }

        }
    

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}