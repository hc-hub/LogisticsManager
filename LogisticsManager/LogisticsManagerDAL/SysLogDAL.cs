using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagerModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;


namespace LogisticsManagerDAL
{
	public class SysLogDAL
	{
		public static DataTable GetTypeName()
		{
			string sql = "select * from [LogDic]";
			return DBHelper.ExecuteDataTable(sql);
		}
		public static List<SysLog> GetAllSysLog(SysLog sys,int pageSize,int pageIndex,out int recordCount)
		{
			recordCount = 0;
			Paging page = new Paging();
			page.TableName = "dbo.SysLog a INNER JOIN dbo.LogDic b  ON a.FK_TypeID=b.TypeID INNER JOIN dbo.[User] c ON a.FK_UserID=c.UserID";
			page.PrimaryKey = "LogID";
			page.Fields = @" [LogID]
	  ,[Behavior]
	  ,[Account]
	  ,b.TypeName
	  ,[Parameters]
	  ,[ProcName]
	  ,[IP]
	  ,a.[CheckInTime]
	  ,[IsException]";
			List<string> wherelist = new List<string>();
			StringBuilder where = new StringBuilder();
			if (sys.FK_TypeID!=-1)
			{
				wherelist.Add($"FK_TypeID={sys.FK_TypeID}");
			}
			if (sys.IsException!=2)
			{
				wherelist.Add($"IsException={sys.IsException}");
			}
			if (!string.IsNullOrWhiteSpace(sys.Account))
			{
				wherelist.Add($" Account LIKE '%{sys.Account}%'");
			}
			if (!string.IsNullOrWhiteSpace(sys.CheckInTimeS))
			{
				wherelist.Add($"a.CheckInTime>'{sys.CheckInTimeS}'");
			}
			if (!string.IsNullOrWhiteSpace(sys.CheckInTimeE))
			{
				wherelist.Add($"a.CheckInTime<'{sys.CheckInTimeE}'");
			}
			if (!string.IsNullOrWhiteSpace(sys.ProcName))
			{
				wherelist.Add($"ProcName like '%{sys.ProcName}%'");
			}
			if (wherelist.Count > 0)
			{
				where.Append(string.Join($" and ", wherelist));
			}
			page.Condition = where.ToString();
			page.PageIndex = pageIndex;
			page.PageSize = pageSize;
			DataTable dt = PublicPaging.ProcGetPageData(page,out recordCount);
			List<SysLog> syslist = new List<SysLog>();
			if (dt.Rows.Count>0)
			{
				foreach (DataRow item in dt.Rows)
				{
					SysLog sy = new SysLog();
					sy.LogID = Convert.ToInt32(item["LogID"]);
					sy.Behavior = item["Behavior"].ToString();
					sy.TypeName = item["TypeName"].ToString();
					sy.Account = item["Account"].ToString();
					sy.Parameters = item["Parameters"].ToString();
					sy.ProcName = item["ProcName"].ToString();
					sy.IP = Convert.ToString(item["IP"]);
					sy.CheckInTime = Convert.ToDateTime(item["CheckInTime"]);
					sy.IsException = Convert.ToByte(item["IsException"]);
					syslist.Add(sy);
				}
			}
			return syslist;
		}

		public static string GetLocalIP()
		{

			string HostName = Dns.GetHostName(); //得到主机名
			IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
			for (int i = 0; i < IpEntry.AddressList.Length; i++)
			{
				//从IP地址列表中筛选出IPv4类型的IP地址
				//AddressFamily.InterNetwork表示此IP为IPv4,
				//AddressFamily.InterNetworkV6表示此地址为IPv6类型
				if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
				{
					return IpEntry.AddressList[i].ToString();
				}
			}
			return "";


		}
		public static int AddSysLog(SysLog sys)
		{
			string procName = "P_SysLog_WriteLog";
			SqlParameter[] para =
				{
				new SqlParameter("@Behavior",sys.Behavior),
				new SqlParameter("@FK_TypeID",sys.FK_TypeID),
				new SqlParameter("@FK_UserID",sys.FK_UserID),
				new SqlParameter("@Parameters",sys.Parameters),
				new SqlParameter("@ProcName",sys.ProcName),
				new SqlParameter("@IP",GetLocalIP()),
				new SqlParameter("@Exception",sys.Exception),
				new SqlParameter("@IsException",sys.IsException)
			};
			return DBHelper.ExcuteNonQueryProc(procName,para);
		}
	}
}
