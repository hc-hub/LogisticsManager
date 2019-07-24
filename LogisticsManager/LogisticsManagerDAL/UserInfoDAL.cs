using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LogisticsManagerModel;
using System.Data.SqlClient;

namespace LogisticsManagerDAL
{
    public class UserInfoDAL
    {
        public static List<Users> Login(Users u)
        {
            string sql = @"SELECT [UserID]
      ,[UserName]
      ,[Sex]
      , case [Sex]
        when 1 then '女' else '男' end as [SexName]
      ,[Account]
      ,[Password]
      ,[Phone]
      ,[Email]
      ,[FK_RoleID]
      ,[CheckInTime]
      ,[IsDelete]
      ,[AlterTime]
        FROM[User] where Account=@account and PassWord=@pwd and IsDelete=0";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@account", u.Account);
            paras[1] = new SqlParameter("@pwd", u.PassWord);
            DataTable dt = DBHelper.ExecuteDataTable(sql, paras);
            List<Users> Userlist = new List<Users>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Users user = new Users();
                    user.UserID = Convert.ToInt32(item["UserID"]);
                    user.UserName = item["UserName"].ToString();
                    user.SexId = Convert.ToInt32(item["Sex"]);
                    user.Sex = item["SexName"].ToString();
                    user.Account = item["Account"].ToString();
                    user.PassWord = item["Password"].ToString();
                    user.Phone = item["Phone"].ToString();
                    user.Email = item["Email"].ToString();
                    user.FK_RoleID = Convert.ToInt32(item["FK_RoleID"]);
                    user.CheckInTime = Convert.ToDateTime(item["CheckInTime"]);
                    user.IsDelete = item["IsDelete"].ToString();
                    user.AlterTime = Convert.ToDateTime(item["AlterTime"]);
                    Userlist.Add(user);
                } 
             }
            return Userlist;
        }
        public static object GetUserID(Users u)
        {
            string sql = "select [UserID] from [User] where Account=@account and PassWord=@pwd and IsDelete=0";
            SqlParameter[] paras = new SqlParameter[2];
            paras[0] = new SqlParameter("@account", u.Account);
            paras[1] = new SqlParameter("@pwd", u.PassWord);
            return DBHelper.ExcuteScalar(sql, paras);
        }
        public static List<Users> BindgvUser(Users u,int pageSize,int pageIndex,out int recordCount)
        {
            recordCount = 0;
            Paging page = new Paging();
            page.TableName = "[user] u inner join Role r on u.FK_RoleID = r.RoleID";
            page.PrimaryKey = "UserID";
            page.Fields = @"UserID,UserName,password,case Sex  when 1 then '女' else '男' end  as Sex,Account,phone,Email,RoleName,AlterTime,
               checkInTime,case IsDelete when 1 then '是' else '否' end as IsDelete";

            StringBuilder where = new StringBuilder("u.IsDelete=0");
            List<string> whereList = new List<string>();
            if (!string.IsNullOrWhiteSpace(u.UserName))
            {
                whereList.Add($" UserName like '{u.UserName}'");
                
            }
            if (u.Sex != "2")
            {
                whereList.Add($" Sex={u.Sex}");
               
            }
            if (!string.IsNullOrWhiteSpace(u.Account))
            {
                whereList.Add($" Account like '{u.Account}'");
                
            }
            if (!string.IsNullOrWhiteSpace(u.Phone))
            {
                whereList.Add($" Phone like '{u.Phone}'");
                
            }
            if (u.IsDelete != "2")
            {
                whereList.Add($" IsDelete={u.IsDelete}");
               
            }
            if (!string.IsNullOrWhiteSpace(u.Email))
            {
                whereList.Add($" Email like '{u.Email}'");
                
            }
            if (u.FK_RoleID != 0)
            {
                whereList.Add($"u.FK_RoleID={u.FK_RoleID}");
               
            }

            if (!string.IsNullOrWhiteSpace(u.BeginInTime))
            {
                DateTime Dt = Convert.ToDateTime(u.BeginInTime);
                whereList.Add($" checkInTime > '{Dt}'");
                

            }
            if (!string.IsNullOrWhiteSpace(u.EndInTime))
            {
                DateTime Dt = Convert.ToDateTime(u.EndInTime);
                whereList.Add($" checkInTime < '{Dt}'");
                

            }
            if (!string.IsNullOrWhiteSpace(u.UpdateBeginTime))
            {
                DateTime Dt = Convert.ToDateTime(u.UpdateBeginTime);
                whereList.Add($" AlterTime > '{Dt}'");
                

            }
            if (!string.IsNullOrWhiteSpace(u.UpdateEndTime))
            {
                DateTime Dt = Convert.ToDateTime(u.UpdateEndTime);
                whereList.Add($" AlterTime < {Dt}");
                

            }
            if (whereList.Count > 0)
            {
                where.Append("and"+string.Join(" and ", whereList.ToArray()));
            }
            page.Condition = where.ToString();
            page.PageSize = pageSize;
            page.PageIndex = pageIndex;
            DataTable dt = PublicPaging.ProcGetPageData(page,out recordCount);
            List<Users> Userlist = new List<Users>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Users user = new Users();
                    user.UserID = Convert.ToInt32(item["UserID"]);
                    user.UserName = item["UserName"].ToString();
                    user.Sex = item["Sex"].ToString();
                    user.Account = item["Account"].ToString();
                    user.PassWord = item["Password"].ToString();
                    user.Phone = item["Phone"].ToString();
                    user.Email = item["Email"].ToString();
                    user.RoleName = item["RoleName"].ToString();
                    user.CheckInTime = Convert.ToDateTime(item["CheckInTime"]);
                    user.IsDelete = item["IsDelete"].ToString();
                    user.AlterTime = Convert.ToDateTime(item["AlterTime"]);

                    Userlist.Add(user);
                }
            }
            return Userlist;
        }
        public static int UpdateUserInfoById(Users u)
        {
            string sql = "update [User] set [UserName]=@username,[Sex]=@sex,[Account]=@account,[Phone]=@phone,[Email]=@email,[FK_RoleID]=@roleID,[AlterTime]=GETDATE() where [UserID]=@userID";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@username",u.UserName),
                new SqlParameter("@sex",u.Sex),
                new SqlParameter("@account",u.Account),
                new SqlParameter("@phone",u.Phone),
                new SqlParameter("@email",u.Email),
                new SqlParameter("@roleID",u.FK_RoleID),
                new SqlParameter("@userID",u.UserID)
            };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static int AddUser(Users u)
        {
            string sql = "insert into [User] values(@Username,@Sex,@Account,@Password,@Phone,@Email,@FK_RoleID,getdate(),0,getdate())";
            SqlParameter[] para = {
                new SqlParameter("@Username",u.UserName),
                new SqlParameter("@Sex",u.SexId),
                new SqlParameter("@Account",u.Account),
                new SqlParameter("@Password",u.PassWord),
                new SqlParameter("@Phone",u.Phone),
                new SqlParameter("@Email",u.Email),
                new SqlParameter("@FK_RoleID",u.FK_RoleID)
            };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static int ChangePwd(Users u)
        {
            string sql = "update [User] set Password=@NewPwd where UserID=@UserID and Account=@Account and Password=@Password";
            SqlParameter[] para ={
                new SqlParameter("@Password",u.PassWord),
                new SqlParameter("@UserID",u.UserID),
                new SqlParameter("@Account",u.Account),
                new SqlParameter("@NewPwd",u.NewPwd)
            };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static int DeleteUserById(int userId)
        {
            string sql = "Update [User] set IsDelete=1 where [UserID]=@UserID";
            SqlParameter[] para =
                {
                new SqlParameter("@UserID",userId)
            };
            return DBHelper.ExcuteNonQuery(sql,para);
        }
        public static string GetUserNameById(int userId)
        {
            string sql = "select UserName from [User] where UserID=@UserID";
            SqlParameter[] para = { new SqlParameter("@UserID",SqlDbType.Int)};
            para[0].Value = userId;
            return DBHelper.ExcuteScalar(sql,para).ToString();
        }
        public static object GetUserName(string name)
        {
            string sql = "select Name from [Driver] where Name=@DriverName";
            SqlParameter[] para = { new SqlParameter("@DriverName", name)};
            return DBHelper.ExcuteScalar(sql,para);
        }
    }
}

