using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerBLL
{
    public class ContactBLL
    {
        public static string DeleteContrctBytruckId(int truckId)
        {
            if (Convert.ToInt32(LogisticsManagerDAL.ContactDAL.GetContactBytruckId(truckId)) > 0)
            {

                if (LogisticsManagerDAL.ContactDAL.DeleteContactBytruckId(truckId) > 0)
                {


                    return "解除绑定成功！";
                }
                else
                {
                    return "解除绑定失败！";
                }
            }
            else
            {
                return "解除绑定失败!";
            }

        }
        public static string BindTruck(int truckId, int driverId)
        {
            if (LogisticsManagerDAL.ContactDAL.BindTruck(truckId, driverId) > 0)
            {

                return "绑定成功！";
            }
            else
            {
                return "绑定失败！";
            }

        }
        public static bool ChangeBind(int truckId)
        {
            if (LogisticsManagerDAL.ContactDAL.GetContactBytruckId(truckId)==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CancelBind(int truckId)
        {
            if (LogisticsManagerDAL.ContactDAL.GetContactBytruckId(truckId) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


