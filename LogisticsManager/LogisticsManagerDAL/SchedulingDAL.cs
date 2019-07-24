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
    public class SchedulingDAL
    {
        public static string CommanddTruck(int carriersId, int truckId, int userId)
        {
            string procName = "P_Carriers_CommandTruck";
            SqlParameter[] para =
                {
                new SqlParameter("@FK_CarriersID",SqlDbType.Int),
                new SqlParameter("@FK_Truck",SqlDbType.Int),
                new SqlParameter("@FK_UesrID",SqlDbType.Int),
                new SqlParameter("@Result",SqlDbType.NVarChar,50)
            };
            para[0].Value = carriersId;
            para[1].Value = truckId;
            para[2].Value = userId;
            para[3].Direction = ParameterDirection.Output;
            SqlDataReader reader = DBHelper.ExecuteReaderProc(procName, para);
            string result = para[3].Value.ToString();
            return result;
        }
        public static Carriers GetFourCostById(int carriersId)
        {
            string procName = "P_Scheduling_GetFourCostById";
            SqlParameter[] para = { new SqlParameter("@FK_CarriersID", carriersId) };
            Carriers ca = new Carriers();
            SqlDataReader sdr = DBHelper.ExecuteReaderProc(procName, para);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    ca.Toll = Convert.ToDouble(sdr["Toll"]);
                    ca.Fine = Convert.ToDouble(sdr["Fine"]);
                    ca.OilCost = Convert.ToDouble(sdr["OilCost"]);
                    ca.OtherCost = Convert.ToDouble(sdr["OtherCost"]);
                }
            }
            return ca;
        }
        public static int UpdateFourCostById(Scheduling sche)
        {
            string procName = "P_Cost_CostCarriers";
            SqlParameter[] para =
                {
                new SqlParameter("@CarriersID",sche.FK_CarriersID),
                new SqlParameter("@Toll",sche.Toll),
                new SqlParameter("@OilCost",sche.OilCost),
                new SqlParameter("@Fine",sche.Fine),
                new SqlParameter("@OtherCost",sche.OtherCost)
            };
            return DBHelper.ExcuteNonQueryProc(procName,para);
        }
    }
}
