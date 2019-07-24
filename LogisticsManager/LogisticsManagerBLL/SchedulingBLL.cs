using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerBLL
{
    public class SchedulingBLL
    {
        public static string CommanddTruck(int carriersId, int truckId, int userId)
        {
            return LogisticsManagerDAL.SchedulingDAL.CommanddTruck(carriersId,truckId,userId);
        }
        public static Carriers GetFourCostById(int carriersId)
        {
            return LogisticsManagerDAL.SchedulingDAL.GetFourCostById(carriersId);
        }
        public static int UpdateFourCostById(Scheduling sche)
        {
            return LogisticsManagerDAL.SchedulingDAL.UpdateFourCostById(sche);
        }
    }
}
