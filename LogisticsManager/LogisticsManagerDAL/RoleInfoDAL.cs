using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerDAL
{
    public class RoleInfoDAL
    {
        public static DataTable GetRoleInfo()
        {
            string sql = "select * from Role";
            return DBHelper.ExecuteDataTable(sql);
        }
        public static string GetRoleNameByRoleID(int roleID)
        {
            string sql = "select RoleName from [Role] where RoleID=" + roleID;
            return DBHelper.ExcuteScalar(sql).ToString();
        }
    }
}
