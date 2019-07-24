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
    public class PublicPaging
    {
        public static DataTable ProcGetPageData(Paging page,out int recordCount)
        {
            recordCount = 0;
            string procName = "ProcGetPageData";
            SqlParameter[] para =
                {
                new SqlParameter("@TableName",SqlDbType.VarChar,1000),
                new SqlParameter("@PrimaryKey",SqlDbType.NVarChar,100),
                new SqlParameter("@Fields",SqlDbType.NVarChar,2000),
                new SqlParameter("@Condition",SqlDbType.NVarChar,3000),
                new SqlParameter("@PageIndex",SqlDbType.Int),
                new SqlParameter("@PageSize",SqlDbType.Int),
                new SqlParameter("@Sort",SqlDbType.NVarChar,200),
                new SqlParameter("@RecordCount",SqlDbType.Int)
            };
            para[0].Value =page.TableName;
            para[1].Value =page.PrimaryKey;
            para[2].Value =page.Fields;
            para[3].Value =page.Condition;
            para[4].Value =page.PageIndex;
            para[5].Value =page.PageSize;
            para[6].Value =page.Sort;
            para[7].Direction =ParameterDirection.Output;
            DataTable dt=DBHelper.ExecuteDataTableProc(procName,para);          
            recordCount=Convert.ToInt32(para[7].Value);
           
            return dt;
        }
        
    }
}
