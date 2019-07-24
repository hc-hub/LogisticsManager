using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerBLL
{
    public class RoleInfoBLL
    {
        public static DataTable GetRoleInfo()
        {
            return LogisticsManagerDAL.RoleInfoDAL.GetRoleInfo();
        }
        public static string GetRoleNameByRoleID(int roleID)
        {
            return LogisticsManagerDAL.RoleInfoDAL.GetRoleNameByRoleID(roleID);
        }
    }
}
