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
	public class DriverDAL
	{

		public static List<Driver> GetDriverInfo()
		{
			StringBuilder sql = new StringBuilder(@"SELECT [DriverID]
	  ,[Name]
	  ,[Sex]
	  ,case [Sex]  when 1 then '女' else '男' end as SexName
	  ,[Birth]
	  ,[Phone]
	  ,d.[State]
	  ,[IDCard]
	  ,[Number]
	  ,d.[FK_TeamID]
	  ,[TruckID]
	  ,d.[CheckInTime]
	  ,d.[IsDelete]
  FROM [Driver] d left join [Contact] c on d.DriverID=c.[FK_DriverID] left join [Truck] tt on  c.FK_TruckID=tt.TruckID where d.[IsDelete]=0");
			SqlDataReader reader = DBHelper.ExecuteReader(sql.ToString());
			List<Driver> driverlist = new List<Driver>();
			if (reader != null)
			{
				while (reader.Read())
				{
					Driver diver = new Driver();

					diver.DriverID = Convert.ToInt32(reader["DriverID"]);
					diver.Name = reader["Name"].ToString();
					diver.Sex = Convert.ToInt32(reader["Sex"]);
					diver.SexName = reader["SexName"].ToString();
					diver.Phone = reader["Phone"].ToString();
					diver.State = Convert.ToByte(reader["State"]);
					diver.IDCard = reader["IDCard"].ToString();
					if (string.IsNullOrWhiteSpace(reader["Number"].ToString()))
					{
						diver.Number = "未绑定";
					}
					else
					{
						diver.Number = reader["Number"].ToString();
					}
					
					diver.FK_TeamID = Convert.ToInt32(reader["FK_TeamID"]);
					diver.CheckInTime = Convert.ToDateTime(reader["CheckInTime"]);
					diver.Birth = Convert.ToDateTime(reader["Birth"]);
					if (string.IsNullOrWhiteSpace(reader["TruckID"].ToString()))
					{
						diver.TruckID = 0;
					}
					else
					{
						diver.TruckID = Convert.ToInt32(reader["TruckID"]);
					}                    
					driverlist.Add(diver);
				}
			}
			return driverlist;
		}
		public static List<Driver> GetDriverInfo(Driver dri,int pageSize,int pageIndex,out int recordCount)
		{
			recordCount = 0;
			Paging page = new Paging();
			page.TableName = @"[Driver] d left join [Contact] c on d.DriverID=c.[FK_DriverID] left join [Truck] tt on  c.FK_TruckID=tt.TruckID";
			page.PrimaryKey = "DriverID";
			page.Fields = @"[DriverID]
	  ,[Name]
	  ,[Sex]
	  ,case [Sex]
		when 1 then '女' else '男' end as SexName
	  ,[Birth]
	  ,[Phone]
	  ,d.[State]
	  ,[IDCard]
	  ,[Number]
	  ,d.[FK_TeamID]
	  ,[TruckID]
	  ,d.[CheckInTime]";
			StringBuilder where = new StringBuilder(@"d.IsDelete=0");
			List<string> wherelist = new List<string>();
			if (!string.IsNullOrWhiteSpace(dri.Name))
			{
				wherelist.Add($"Name like '%{dri.Name}%'");
				
			}
			if (dri.Sex != -1)
			{
				wherelist.Add($"Sex={dri.Sex}");
				
			}
			if (!string.IsNullOrWhiteSpace(dri.BeginBirth))
			{
				wherelist.Add($"Birth > '{dri.BeginBirth}'");
				
			}
			if (!string.IsNullOrWhiteSpace(dri.EndBirth))
			{
				wherelist.Add($"Birth < '{dri.EndBirth}'");
				
			}
			if (!string.IsNullOrWhiteSpace(dri.Phone))
			{
				wherelist.Add($"Phone like '{dri.Phone}'");
				
			}
			if (dri.FK_TeamID != -1)
			{
				wherelist.Add($"d.FK_TeamID='{dri.FK_TeamID}'");
				
			}
			if (!string.IsNullOrWhiteSpace(dri.BeginInTime))
			{
				wherelist.Add($"Birth > '{dri.BeginInTime}'");
				
			}
			if (!string.IsNullOrWhiteSpace(dri.EndInTime))
			{
				wherelist.Add($"Birth < '{dri.EndInTime}'");
				
			}
			if (!string.IsNullOrWhiteSpace(dri.IDCard))
			{
				wherelist.Add($"Phone like '%{dri.IDCard}%'");
				
			}
			if (dri.State != 0)
			{
				if (dri.State==2)
				{
					wherelist.Add($"d.DriverID NOT IN (SELECT c2.FK_DriverID FROM Contact AS c2)");
				}
				else
				{
					wherelist.Add($"d.DriverID IN (SELECT c2.FK_DriverID FROM Contact AS c2)");
				}
				
				
			}
			if (wherelist.Count() > 0)
			{
				where.Append($" and {string.Join(" and ", wherelist.ToArray())}");
			}
			page.Condition = where.ToString();
			page.PageSize = pageSize;
			page.PageIndex = pageIndex;
			DataTable dt = PublicPaging.ProcGetPageData(page, out recordCount);
			List<Driver> driverlist = new List<Driver>();
			if (dt.Rows.Count>0)
			{
				foreach (DataRow item in dt.Rows)
				{
					Driver diver = new Driver();

					diver.DriverID = Convert.ToInt32(item["DriverID"]);
					diver.Name = item["Name"].ToString();
					diver.Sex = Convert.ToInt32(item["Sex"]);
					diver.SexName = item["SexName"].ToString();               
					diver.Phone = item["Phone"].ToString();
					diver.State = Convert.ToByte(item["State"]);
					diver.IDCard = item["IDCard"].ToString();
					if (string.IsNullOrWhiteSpace(item["Number"].ToString()))
					{
						diver.Number = "未绑定";
					}
					else
					{
						diver.Number = item["Number"].ToString();
					}
					
					diver.FK_TeamID = Convert.ToInt32(item["FK_TeamID"]);
					diver.CheckInTime = Convert.ToDateTime(item["CheckInTime"]);
					diver.Birth = Convert.ToDateTime(item["Birth"]);
					if (string.IsNullOrWhiteSpace(item["TruckID"].ToString()))
					{
						diver.TruckID = 0;
					}
					else
					{
						diver.TruckID = Convert.ToInt32(item["TruckID"]);
					}
					
					driverlist.Add(diver);
				}
			}
			return driverlist;
		}
		public static int DeleteDriver(int driverId)
		{
			string sql = "update [Driver] set [IsDelete]=1 where DriverID=@DriverID";
			SqlParameter[] para = {new SqlParameter("@DriverID",driverId) };
			return DBHelper.ExcuteNonQuery(sql,para);
		}

		public static object GetDriverID(int driverId)
		{
			string sql = "select DriverID from [Driver] where DriverID=@DriverID";
			SqlParameter[] para = { new SqlParameter("@DriverID", driverId) };
			return DBHelper.ExcuteScalar(sql, para);
		}
		public static object GetDriverIDByContact(int driverId)
		{
			string sql = "select FK_DriverID from [Contact] where FK_DriverID=@DriverID";
			SqlParameter[] para = { new SqlParameter("@DriverID", driverId) };
			return DBHelper.ExcuteScalar(sql, para);
		}
		public static object GetDriverNameById(int driverId)
		{
			string sql = "select [Name] from [Driver] where [DriverID]=@DriverID";
			SqlParameter[] para = { new SqlParameter("@DriverID",driverId)};
			return DBHelper.ExcuteScalar(sql,para);
		}
		public static int BindState(int truckId)
		{
			string sql = "update [Driver] set [State]=1 where [DriverID]=(Select [FK_DriverID] from [Contact] where FK_TruckID=@TruckID)";
			SqlParameter[] para =
				{
				new SqlParameter("@TruckID",truckId)
			};
			return DBHelper.ExcuteNonQuery(sql, para);
		}
		public static int CancelBindState(int truckId)
		{
			string sql = "update [Driver] set [State]=2 where [DriverID]=(Select [FK_DriverID] from [Contact] where FK_TruckID=@TruckID)";
			SqlParameter[] para =
				{
				new SqlParameter("@TruckID",truckId)
			};
			return DBHelper.ExcuteNonQuery(sql, para);
		}
		public static int AddDriver(Driver driver)
		{
			string sql = "insert into [Driver] values(@Name,@Sex,@Birth,@Phone,@IDCard,@FK_TeamID,2,@Remark,getdate(),0,getdate())";
			SqlParameter[] para =
			{
				new SqlParameter("@Name",driver.Name),
				new SqlParameter("@Sex",driver.Sex),
				new SqlParameter("@Birth",driver.Birth),
				new SqlParameter("@Phone",driver.Phone),
				new SqlParameter("@IDCard",driver.IDCard),
				new SqlParameter("@FK_TeamID",driver.FK_TeamID),
				new SqlParameter("@Remark",driver.Remark),
			};
			return DBHelper.ExcuteNonQuery(sql,para);
		}
		public static int UpdateDriver(Driver driver)
		{
			string procName = "P_Driver_AlterDriver";
			SqlParameter[] para =
				{
				new SqlParameter("@Name",driver.Name),
				new SqlParameter("@Sex",driver.Sex),
				new SqlParameter("@Birth",driver.Birth),
				new SqlParameter("@Phone",driver.Phone),
				new SqlParameter("@IDCard",driver.IDCard),
				new SqlParameter("@FK_TeamID",driver.FK_TeamID),
				new SqlParameter("@Remark",driver.Remark),
				new SqlParameter("@DriverID",driver.DriverID),
                new SqlParameter("@State",driver.State)
			};
			return DBHelper.ExcuteNonQueryProc(procName,para);
		}
		public static Driver GetDriverDetils(int driverId)
		{
			string procName = "P_Driver_GetDriverByID";
			SqlParameter[] para =
				{
				new SqlParameter("@DriverID",driverId),
			};
			Driver dri = new Driver();
			SqlDataReader sdr = DBHelper.ExecuteReaderProc(procName,para);
			if (sdr.HasRows)
			{
				while (sdr.Read())
				{
					dri.DriverID = Convert.ToInt32(sdr["DriverID"]);
					dri.Name = Convert.ToString(sdr["Name"]);
					dri.Phone = sdr["Phone"].ToString();
					dri.State = Convert.ToByte(sdr["State"]);
					dri.Sex = Convert.ToByte(sdr["Sex"]);
					dri.IDCard = Convert.ToString(sdr["IDCard"]);
					dri.Remark = Convert.ToString(sdr["Remark"]);
					dri.Birth = Convert.ToDateTime(sdr["Birth"]);
					dri.FK_TeamID = Convert.ToInt32(sdr["FK_TeamID"]);
					dri.CheckInTime = Convert.ToDateTime(sdr["CheckInTime"]);
				}
			}
			return dri;
		}
	}
}
