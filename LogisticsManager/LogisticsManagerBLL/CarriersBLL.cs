using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerBLL
{
    public class CarriersBLL
    {
        public static List<Carriers> GetCarriers()
        {
            return LogisticsManagerDAL.CarriersDAL.GetCarriers();
        }
        public static List<Carriers> GetCarriersWhere(Carriers carr)
        {
            return LogisticsManagerDAL.CarriersDAL.GetCarriersWhere(carr);
        }
        public static string AddCarriers(Carriers carr)
        {
            if (LogisticsManagerDAL.CarriersDAL.AddCarriers(carr)>0)
            {
                return "添加成功！";
            }
            else
            {
                return "添加失败！";
            }
        }
        public static string DeleteCarriers(int Id)
        {
            if (LogisticsManagerDAL.CarriersDAL.DeleteCarriers(Id)>0)
            {
                return "删除成功！";
            }
            else
            {
                return "删除失败！";
            }
        }
        public static Carriers GetOneCarriers(int carriersID)
        {
            return LogisticsManagerDAL.CarriersDAL.GetOneCarriers(carriersID);
        }
        public static List<Carriers> GetCarriersByUserID(int userId)
        {
            return LogisticsManagerDAL.CarriersDAL.GetCarriersByUserID(userId);
        }
        public static string ReceiveCarriers(int carriersId)
        {
            if (LogisticsManagerDAL.CarriersDAL.ReceiveCarriers(carriersId)>0)
            {
                return "接收成功！";
            }
            else
            {
                return "接受失败！";
            }
        }
        public static List<Carriers> GetCostByUserId(int userId, Carriers carr, int pageSize, int pageIndex, out int recordCount)
        {
            return LogisticsManagerDAL.CarriersDAL.GetCostByUserId(userId,carr,pageSize,pageIndex,out recordCount);
        }
        public static Carriers GetCarriersDetils(int carriersId)
        {
            return LogisticsManagerDAL.CarriersDAL.GetCarriersDetils(carriersId);
        }
        public static string UpdateCarriersByCarriers(Carriers carr)
        {
            if (LogisticsManagerDAL.CarriersDAL.UpdateCarriersByCarriers(carr)>0)
            {
                return "修改成功！";
            }
            else
            {
                return "修改成功！";
            }
        }
        public static List<Carriers> GetCarriersH(Carriers carr, int pageSize, int pageIndex, out int recordCount)
        {
            return LogisticsManagerDAL.CarriersDAL.GetCarriersH(carr,pageSize,pageIndex, out recordCount);
        }
    }
}
