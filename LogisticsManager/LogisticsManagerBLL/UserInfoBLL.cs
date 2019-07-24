using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerBLL
{
    public class UserInfoBLL
    {
        public static List<Users> Login(Users u)
        {
            return LogisticsManagerDAL.UserInfoDAL.Login(u);
        }       
        public static List<Users> BindgvUser(Users u, int pageSize, int pageIndex, out int recordCount)
        {
            return LogisticsManagerDAL.UserInfoDAL.BindgvUser(u,pageSize,pageIndex,out recordCount);
        }
        public static int UpdateUserInfoById(Users u)
        {
            return LogisticsManagerDAL.UserInfoDAL.UpdateUserInfoById(u);
        }
        public static int AddUser(Users u)
        {
            return LogisticsManagerDAL.UserInfoDAL.AddUser(u);
        }
        public static object GetUserName(string name)
        {
            return LogisticsManagerDAL.UserInfoDAL.GetUserName(name);
        }
        public static int ChangePwd(Users u)
        {
            return LogisticsManagerDAL.UserInfoDAL.ChangePwd(u);
        }
        public static int DeleteUserById(int userId)
        {
            return LogisticsManagerDAL.UserInfoDAL.DeleteUserById(userId);
        }
        public static string GetUserNameById(int userId)
        {
            return LogisticsManagerDAL.UserInfoDAL.GetUserNameById(userId);
        }
    }
}
