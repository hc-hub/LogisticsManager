using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogisticsManagerBLL
{
    public class SysLogBLL
    {
        public static int AddSysLog(SysLog sys)
        {
            return LogisticsManagerDAL.SysLogDAL.AddSysLog(sys);
        }
        public static List<SysLog> GetAllSysLog(SysLog sys, int pageSize, int pageIndex, out int recordCount)
        {
            return LogisticsManagerDAL.SysLogDAL.GetAllSysLog(sys,pageSize,pageIndex,out recordCount);
        }
        public static DataTable GetTypeName()
        {
            return LogisticsManagerDAL.SysLogDAL.GetTypeName();
         }
    }
}
