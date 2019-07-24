using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LogisticsManagerModel;

namespace LogisticsManagerBLL
{
    public class TruckBLL
    {
        public static DataTable GetTruck_Type()
        {
            return LogisticsManagerDAL.TruckDAL.GetTruck_Type();
        }
        public static DataTable GetTruck_State()
        {
            return LogisticsManagerDAL.TruckDAL.GetTruck_State();
        }
        public static List<Truck> GetTruck(Truck tk, int pageSize, int pageIndex, out int recordCount)
        {
            return LogisticsManagerDAL.TruckDAL.GetTruck(tk,pageSize,pageIndex,out recordCount);
        }
        public static int AddTruck(Truck tk)
        {
            return LogisticsManagerDAL.TruckDAL.AddTruck(tk);
        }
        public static DataSet GetTruckByDriverId(int driverId)
        {
            return LogisticsManagerDAL.TruckDAL.GetTruckByDriverId(driverId);
        }
        public static Truck GetTruckById(int truckId)
        {
            return LogisticsManagerDAL.TruckDAL.GetTruckById(truckId);
        }
        public static int UpdateTruckInfo(Truck tk)
        {
            return LogisticsManagerDAL.TruckDAL.UpdateTruckInfo(tk);
        }
        public static string DeleteTruck(int truckId)
        {
            if (LogisticsManagerDAL.TruckDAL.GetTruckID(truckId)!=null)
            {
                if (LogisticsManagerDAL.TruckDAL.GetTruckByContact(truckId)==null)
                {
                    if (LogisticsManagerDAL.TruckDAL.GetTruckByScheduling(truckId)==null)
                    {
                        if (LogisticsManagerDAL.TruckDAL.DeleteTruck(truckId)>0)
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
                        return "该车辆正在执行任务，无法删除！";
                    }
                }
                else
                {
                    return "该车辆已绑定驾驶员，无法删除！";
                }
            
            
            }
            else
            {
                return "车辆ID不存在！";
            }
        }
        public static int BindState(int truckId)
        {
            return LogisticsManagerDAL.TruckDAL.BindState(truckId);
        }
        public static int CancelBindState(int truckId)
        {
            return LogisticsManagerDAL.TruckDAL.CancelBindState(truckId);
        }
        public static List<Truck> GetNotCommandTruck()
        {
            return LogisticsManagerDAL.TruckDAL.GetNotCommandTruck();
        }
        
        
    }
}
