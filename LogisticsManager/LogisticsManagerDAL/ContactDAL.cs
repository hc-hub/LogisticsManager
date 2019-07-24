using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LogisticsManagerModel;

namespace LogisticsManagerDAL
{
    public class ContactDAL
    {
        public static int DeleteContactBytruckId(int truckId)
        {
            string sql = "delete from [Contact] where FK_TruckID=@FK_TruckID";
            SqlParameter[] para = { new SqlParameter("@FK_TruckID", truckId)};
            return DBHelper.ExcuteNonQuery(sql,para);
        }
        public static object GetContactBytruckId(int truckId)
        {
            string sql = "select FK_TruckID from [Contact] where FK_TruckID=@FK_TruckID";
            SqlParameter[] para = { new SqlParameter("@FK_TruckID", truckId) };
            return DBHelper.ExcuteScalar(sql, para);
        }
        public static int BindTruck(int truckId,int driverId)
        {
            string sql = "insert into [Contact] values(@FK_TruckID,@FK_DriverID)";
            SqlParameter[] para = 
                {
                new SqlParameter("@FK_TruckID",truckId),
                new SqlParameter("@FK_DriverID",driverId)
            };
            return DBHelper.ExcuteNonQuery(sql,para);
        }      
    }
}
