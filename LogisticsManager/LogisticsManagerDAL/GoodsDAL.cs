using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagerModel;
using System.Data.SqlClient;

namespace LogisticsManagerDAL
{
    public class GoodsDAL
    {
        public static List<Goods> GetGoodsByCarriersId(int carriersId)
        {
            string procName = "P_Carriers_GetAllGoods";
            SqlParameter[] para = { new SqlParameter("@FK_CarriersID",carriersId) };
            SqlDataReader reader = DBHelper.ExecuteReaderProc(procName,para);
            List<Goods> goodslist = new List<Goods>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Goods goods = new Goods();
                    goods.GoodsID = Convert.ToInt32(reader["GoodsID"]);
                    goods.GoodsName = reader["GoodsName"].ToString();
                    goods.Amount = Convert.ToInt32(reader["Amount"]);
                    goods.Weight = Convert.ToDouble(reader["Weight"]);
                    goods.Volume = Convert.ToDouble(reader["Volume"]);
                    goods.FK_CarriersID = Convert.ToInt32(reader["FK_CarriersID"]);
                    goodslist.Add(goods);
                }               
            }
            return goodslist;
        }
        public static int AddGoods(Goods goods)
        {
            string procName = "P_Carriers_CreateGoods";
            SqlParameter[] para =
                {
                new SqlParameter("@GoodsName",goods.GoodsName),
                new SqlParameter("@Amount",goods.Amount),
                new SqlParameter("@Weight",goods.Weight),
                new SqlParameter("@Volume",goods.Volume),
                new SqlParameter("@FK_CarriersID",goods.FK_CarriersID)
            };
            return DBHelper.ExcuteNonQueryProc(procName,para);
        }
    }
}
