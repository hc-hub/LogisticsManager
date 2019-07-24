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
    public class TruckDAL
    {
        
        public static DataTable GetTruck_Type()
        {
            string sql = "select distinct[Type] from [Truck]";
            return DBHelper.ExecuteDataTable(sql);
        }
        public static DataTable GetTruck_State()
        {
            string sql = "select  distinct [State],case [State] when 1 then '承运中' else '空闲中' end as [StateName] from [Truck]";
            return DBHelper.ExecuteDataTable(sql);
        }
        public static List<Truck> GetTruck(Truck tk,int pageSize, int pageIndex, out int recordCount)
        {
            Paging page = new Paging();
            page.TableName = "[Truck] tk inner join TruckTeam tm on tk.FK_TeamID = tm.TeamID";
            page.PrimaryKey = "TruckID";
            page.Fields = @"[TruckID]
      ,[Number]
      ,[BuyDate]  
      ,[Type]
      ,[Length]
      ,[Tonnage]
      ,[TeamName]
      ,[State]     
      ,tk.[CheckInTime]
      ,tk.[AlterTime]
      ,tk.[Remark]
      ,case [State]
        when 1  then "+"'承运中'"+" else "+"'空闲中'"+" end as [StateName]";
            List<string> wherelist = new List<string>();
            wherelist.Add("tk.IsDelete=0");
            StringBuilder where = new StringBuilder();
            if (tk.FK_TeamID!=-1)
            {
                wherelist.Add($" FK_TeamID={tk.FK_TeamID}");
            }
            if (!string.IsNullOrWhiteSpace(tk.Number))
            {
                wherelist.Add($" Number like '%{tk.Number}%'");
            }
            if (tk.Type!="-1")
            {
                wherelist.Add($" Type='{tk.Type}'");
            }
            if (tk.State!=-1)
            {
                wherelist.Add($" State={tk.State}");
            }
            if (wherelist.Count>0)
            {
                where.Append(string.Join(" and ",wherelist));
            }
            page.Condition = where.ToString();
            page.Sort = "TruckID";
            page.PageIndex = pageIndex;
            page.PageSize = pageSize;
            DataTable dt= PublicPaging.ProcGetPageData(page,out recordCount);
            List<Truck> trucklist = new List<Truck>();
            
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Truck truck = new Truck();
                    truck.TruckID = Convert.ToInt32(item["TruckID"]);
                    truck.Number = item["Number"].ToString();
                    truck.BuyDate = Convert.ToDateTime(item["BuyDate"]);
                    truck.Type = item["Type"].ToString();
                    truck.Length = item["Length"].ToString();
                    truck.Tonnage = Convert.ToInt32(item["Tonnage"]);
                    truck.TeamName = item["TeamName"].ToString();
                    truck.State = Convert.ToInt32(item["State"]);
                    truck.StateName = item["StateName"].ToString();
                    truck.CheckInTime = Convert.ToDateTime(item["CheckInTime"]);
                    truck.AlterTime = Convert.ToDateTime(item["AlterTime"]);
                    truck.Remark = item["Remark"].ToString();
                    trucklist.Add(truck);

                }
            }
            return trucklist;
        }
        //public static List<Truck> GetTruck(Truck tk,int pageSize,int pageIndex,out int recordCount)
        //{
        //    //          StringBuilder sql = new StringBuilder(@"SELECT [TruckID]
        //    //    ,[Number]
        //    //    ,[BuyDate]
        //    //    ,[Type]
        //    //    ,[Length]
        //    //    ,[Tonnage]
        //    //    ,[TeamName]
        //    //    ,[FK_TeamID]
        //    //    ,[State]
        //    //    ,case [State]
        //    //      when 1  then '承运中' else '空闲中' end as [StateName]
        //    //    ,tk.[CheckInTime]
        //    //    ,tk.[AlterTime]
        //    //    ,tk.[Remark]
        //    //FROM[Truck] tk inner join TruckTeam tm on tk.FK_TeamID=tm.TeamID");
        //    //          List<string> wherelist = new List<string>();
        //    //          List<SqlParameter> para = new List<SqlParameter>();
        //    //          if (tk.TeamName != "-1")
        //    //          {
        //    //              wherelist.Add("[TeamName]=@TeamName");
        //    //              para.Add(new SqlParameter("@TeamName", tk.TeamName));
        //    //          }
        //    //          if (!string.IsNullOrWhiteSpace(tk.Number))
        //    //          {
        //    //              wherelist.Add("[Number] like @Number");
        //    //              para.Add(new SqlParameter("@Number", "%" + tk.Number + "%"));
        //    //          }
        //    //          if (tk.Type != "-1")
        //    //          {
        //    //              wherelist.Add("[Type]=@Type");
        //    //              para.Add(new SqlParameter("@Type", tk.Type));
        //    //          }
        //    //          if (tk.State != -1)
        //    //          {
        //    //              wherelist.Add("[State]=@State");
        //    //              para.Add(new SqlParameter("@State", tk.State));
        //    //          }
        //    //          if (wherelist.Count > 0)
        //    //          {
        //    //              sql.Append($" where {string.Join(" and ", wherelist)}");
        //    //          }
        //    recordCount = 0;
        //    string procName= "P_Carriers_SelectWhere";
        //    SqlParameter[] para =
        //        {
        //        new SqlParameter("@teamID",SqlDbType.Int),
        //        new SqlParameter("@truckNum",SqlDbType.VarChar,50),
        //        new SqlParameter("@truckType",SqlDbType.VarChar,50),
        //        new SqlParameter("@truckState",SqlDbType.Int),
        //        new SqlParameter("@PageSize",SqlDbType.Int),
        //        new SqlParameter("@PageIndex",SqlDbType.Int),
        //        new SqlParameter("@RecordCount",SqlDbType.Int)
        //    };
        //    para[0].Value = tk.FK_TeamID;
        //    para[1].Value = tk.Number;
        //    para[2].Value = tk.Type;
        //    para[3].Value = tk.State;
        //    para[4].Value = pageSize;
        //    para[5].Value = pageIndex;
        //    para[6].Direction = ParameterDirection.Output;
        //    SqlDataReader sdr = DBHelper.ExecuteReaderProc(procName,para);

        //    List<Truck> trucklist = new List<Truck>();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //            Truck truck = new Truck();
        //            truck.TruckID = Convert.ToInt32(sdr["TruckID"]);
        //            truck.Number = sdr["Number"].ToString();
        //            truck.BuyDate = Convert.ToDateTime(sdr["BuyDate"]);
        //            truck.Type = sdr["Type"].ToString();
        //            truck.Length = sdr["Length"].ToString();
        //            truck.Tonnage = Convert.ToInt32(sdr["Tonnage"]);
        //            truck.TeamName = sdr["TeamName"].ToString();
        //            truck.State = Convert.ToInt32(sdr["State"]);
        //            truck.StateName = sdr["StateName"].ToString();
        //            truck.CheckInTime = Convert.ToDateTime(sdr["CheckInTime"]);
        //            truck.AlterTime = Convert.ToDateTime(sdr["AlterTime"]);
        //            truck.Remark = sdr["Remark"].ToString();
        //            trucklist.Add(truck);

        //        }
        //        sdr.Close();
        //        recordCount = Convert.ToInt32(para[6].Value);
        //    }
            
        //    return trucklist;
        //} 
        public static int AddTruck(Truck tk)
        {
            string sql = "insert into Truck values(@Number,@BuyDate,@Type,@Length,@Tonnage,@FK_TeamID,2,@Remark,getdate(),0,getdate())";
            SqlParameter[] para =
            {
                new SqlParameter("@Number",tk.Number),
                new SqlParameter("@BuyDate",tk.BuyDate),
                new SqlParameter("@Type",tk.Type),
                new SqlParameter("@Length",tk.Length),
                new SqlParameter("@Tonnage",tk.Tonnage),
                new SqlParameter("@FK_TeamID",tk.FK_TeamID),
                new SqlParameter("@Remark",tk.Remark)
            };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static DataSet GetTruckByDriverId(int driverId)
        {
            string sql = @"SELECT [TruckID]
      ,[Number]
      ,[BuyDate]
      ,[Type]
      ,[Length]
      ,[Tonnage]
      ,[FK_TeamID]
      ,[State]      
  FROM [Truck] where [State]=2 and [FK_TeamID]=(select [FK_TeamID] from [Driver] where [DriverID]=@DriverID) and TruckID NOT IN(SELECT c2.FK_TruckID FROM Contact AS c2) and IsDelete=0";
            SqlParameter[] para = { new SqlParameter("@DriverID", driverId) };
            return DBHelper.GetDataSet(sql, para);
        }
        public static Truck GetTruckById(int truckId)
        {
            string sql = @"SELECT [TruckID]
      ,[Number]
      ,[BuyDate]
      ,[Type]
      ,[Length]
      ,[Tonnage]
      ,[TeamName]
      ,[FK_TeamID]
      ,[State]
      ,case [State]
        when 1  then '承运中' else '空闲中' end as [StateName]
      ,tk.[CheckInTime]
      ,tk.[AlterTime]
      ,tk.[Remark]
  FROM[Truck] tk inner join TruckTeam tm on tk.FK_TeamID=tm.TeamID where [TruckID]=@TruckId and tk.IsDelete=0";
            SqlParameter[] para = { new SqlParameter("@TruckId", truckId) };
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, para);
            Truck truck = new Truck();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    truck.TruckID = Convert.ToInt32(sdr["TruckID"]);
                    truck.FK_TeamID = Convert.ToInt32(sdr["FK_TeamID"]);
                    truck.Number = sdr["Number"].ToString();
                    truck.BuyDate = Convert.ToDateTime(sdr["BuyDate"]);
                    truck.Type = sdr["Type"].ToString();
                    truck.Length = sdr["Length"].ToString();
                    truck.Tonnage = Convert.ToInt32(sdr["Tonnage"]);
                    truck.TeamName = sdr["TeamName"].ToString();
                    truck.State = Convert.ToInt32(sdr["State"]);
                    truck.StateName = sdr["StateName"].ToString();
                    truck.CheckInTime = Convert.ToDateTime(sdr["CheckInTime"]);
                    truck.AlterTime = Convert.ToDateTime(sdr["AlterTime"]);
                    truck.Remark = sdr["Remark"].ToString();
                }
            }
            return truck;
        }
        public static int UpdateTruckInfo(Truck tk)
        {
            string sql = "update [Truck] set Number=@Number,BuyDate=@BuyDate,Type=@Type,Length=@Length,Tonnage=@Tonnage,FK_TeamID=@FK_TeamID,State=@State,Remark=@Remark,AlterTime=getdate() where TruckID=@TruckID";
            SqlParameter[] para =
                {
                new SqlParameter("@Number",tk.Number),
                new SqlParameter("@BuyDate",tk.BuyDate),
                new SqlParameter("@Type",tk.Type),
                new SqlParameter("@Length",tk.Length),
                new SqlParameter("@Tonnage",tk.Tonnage),
                new SqlParameter("@FK_TeamID",tk.FK_TeamID),
                new SqlParameter("@State",tk.State),
                new SqlParameter("@Remark",tk.Remark),
                new SqlParameter("@TruckID",tk.TruckID)
            };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static int DeleteTruck(int truckId)
        {
            string sql = "Update [Truck] set IsDelete=1 where [TruckID]=@TruckID";
            SqlParameter[] para = { new SqlParameter("@TruckID", truckId) };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static object GetTruckID(int truckId)
        {
            string sql = "select TruckID from [Truck] where TruckID=@TruckID and IsDelete=0";
            SqlParameter[] para = { new SqlParameter("@TruckID", truckId) };
            return DBHelper.ExcuteScalar(sql, para);
        }
        public static object GetTruckByContact(int truckId)
        {
            string sql = "select FK_TruckID from [Contact] where FK_TruckID=@FK_TruckID";
            SqlParameter[] para = { new SqlParameter("@FK_TruckID", truckId) };
            return DBHelper.ExcuteScalar(sql, para);
        }
        public static object GetTruckByScheduling(int truckId)
        {
            string sql = "select FK_TruckID from [Scheduling] where FK_TruckID=@FK_TruckID and IsDelete=0";
            SqlParameter[] para = { new SqlParameter("@FK_TruckID", truckId) };
            return DBHelper.ExcuteScalar(sql, para);
        }
        public static int BindState(int truckId)
        {
            string sql = "update [Truck] set [State]=1 where [TruckID]=@TruckID";
            SqlParameter[] para =
                {
                new SqlParameter("@TruckID",truckId)
            };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static int CancelBindState(int truckId)
        {
            string sql = "update [Truck] set [State]=2 where [TruckID]=@TruckID";
            SqlParameter[] para =
                {
                new SqlParameter("@TruckID",truckId)
            };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static List<Truck> GetNotCommandTruck()
        {
            List<Truck> result = new List<Truck>();
            string procName = "P_Truck_NotCommondTruck";
            SqlDataReader sdr = DBHelper.ExecuteReaderProc(procName);
            if (sdr.HasRows)
            {

            
                while (sdr.Read())
                {
                    Truck truck = new Truck();
                    truck.TruckID = Convert.ToInt32(sdr["TruckID"]);
                    truck.Number = sdr["Number"].ToString();
                    //truck.BuyDate = Convert.ToDateTime(sdr["BuyDate"]);
                    truck.Type = sdr["Type"].ToString();
                    truck.Length = sdr["Length"].ToString();
                    truck.Tonnage = Convert.ToInt32(sdr["Tonnage"]);
                    truck.TeamName = sdr["TeamName"].ToString();
                    truck.Name = sdr["Name"].ToString();
                    //truck.State = Convert.ToInt32(sdr["State"]);
                    //truck.CheckInTime = Convert.ToDateTime(sdr["CheckInTime"]);
                    //truck.AlterTime = Convert.ToDateTime(sdr["AlterTime"]);
                    result.Add(truck);
                }
            }
            return result;
            
        }
    }
}
