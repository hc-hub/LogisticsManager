using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LogisticsManagerBLL
{
    public class DriverBLL
    {
        public static List<Driver> GetDriverInfo()
        {
            return LogisticsManagerDAL.DriverDAL.GetDriverInfo();
        }
        public static List<Driver> GetDriverInfo(Driver dri, int pageSize, int pageIndex, out int recordCount)
        {
            return LogisticsManagerDAL.DriverDAL.GetDriverInfo(dri, pageSize, pageIndex, out recordCount);
        }
        public static string DeleteDriver(int driverId)
        {
            if (LogisticsManagerDAL.DriverDAL.GetDriverID(driverId) != null)
            {
                if (LogisticsManagerDAL.DriverDAL.GetDriverIDByContact(driverId) == null)
                {

                    if (LogisticsManagerDAL.DriverDAL.DeleteDriver(driverId) > 0)
                    {
                        return "删除成功！";
                    }
                    else
                    {
                        return "删除失败！";
                    }


                }
                else
                {
                    return "该驾驶员已绑定车辆，无法删除！";
                }
            }
            else
            {
                return "该驾驶员不存在!";
            }
        }
        public static string GetDriverNameById(int driverId)
        {
            return LogisticsManagerDAL.DriverDAL.GetDriverNameById(driverId).ToString();
        }
        public static string AddDriver(Driver driver)
        {
            if (LogisticsManagerDAL.DriverDAL.AddDriver(driver) > 0)
            {
                return "添加成功！";
            }
            else
            {
                return "添加失败！";
            }
        }
        public static string UpdateDriver(Driver driver)
        {
            if (LogisticsManagerDAL.DriverDAL.UpdateDriver(driver) > 0)
            {
                return "修改成功！";
            }
            else
            {
                return "修改失败！";
            }
        }
        public static Driver GetDriverDetils(int driverId)
        {
            return LogisticsManagerDAL.DriverDAL.GetDriverDetils(driverId);
        }
    }
}
