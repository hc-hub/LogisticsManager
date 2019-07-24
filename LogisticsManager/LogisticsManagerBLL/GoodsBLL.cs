using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagerModel;

namespace LogisticsManagerBLL
{
    public class GoodsBLL
    {
        public static string AddGoods(Goods goods)
        {
            if (LogisticsManagerDAL.GoodsDAL.AddGoods(goods) > 0)
            {
                return "添加成功！";
            }
            else
            {
                return "添加失败！";
            }
        }
        public static List<Goods> GetGoodsByCarriersId(int carriersId)
        {
            return LogisticsManagerDAL.GoodsDAL.GetGoodsByCarriersId(carriersId);
        }
    }
}
