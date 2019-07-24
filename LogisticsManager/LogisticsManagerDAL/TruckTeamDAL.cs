using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagerModel;
using System.Data;
using System.Data.SqlClient;

namespace LogisticsManagerDAL
{
    public class TruckTeamDAL
    {
        public static DataSet GetTruckTeam()
        {
            string sql = @"SELECT [TeamID]
      ,[TeamName]
      ,[Leader]
      ,[Remark]
      ,[CheckInTime]
      ,[AlterTime]
  FROM [TruckTeam] where IsDelete=0";
            return DBHelper.GetDataSet(sql);
        }
        public static SqlDataReader GetTruckName()
        {
            string sql = "select [TeamID],[TeamName] from [TruckTeam] where IsDelete=0";
            return DBHelper.ExecuteReader(sql);
        }
        public static int GetTeamId( int teamId)
        {
            string sql = "select COUNT(*) from Truck where FK_TeamID in (select TeamID from TruckTeam WHERE TeamID=@TeamID)";
            SqlParameter[] para = { new SqlParameter("@TeamID",teamId)};
            return Convert.ToInt32(DBHelper.ExcuteScalar(sql,para));
        }
        public static List<TruckTeam> GetTruckTeams()
        {
            string sql = @"SELECT [TeamID]
      ,[TeamName]
      ,[Leader]
      ,[Remark]
      ,[CheckInTime]
      ,[AlterTime]
  FROM[TruckTeam] where IsDelete=0";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql);
            List<TruckTeam> truckTeamlist = new List<TruckTeam>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    TruckTeam truckTeam = new TruckTeam();
                    truckTeam.TeamID = Convert.ToInt32(sdr["TeamID"]);
                    truckTeam.TeamName = sdr["TeamName"].ToString();
                    truckTeam.Leader = sdr["Leader"].ToString();
                    truckTeam.CheckInTime = Convert.ToDateTime(sdr["CheckInTime"]);
                    truckTeam.AlterTime = Convert.ToDateTime(sdr["AlterTime"]);
                    truckTeam.Remark = sdr["Remark"].ToString();
                    truckTeamlist.Add(truckTeam);
                }
            }
            return truckTeamlist;
        }
        public static List<TruckTeam> GetTruckTeams(TruckTeam tt)
        {
            StringBuilder sql = new StringBuilder(@"SELECT [TeamID]
      ,[TeamName]
      ,[Leader]
      ,[Remark]
      ,[CheckInTime]
      ,[AlterTime]
  FROM[TruckTeam] and IsDelete=0");
            List<string> wherelist = new List<string>();
            List<SqlParameter> paralist = new List<SqlParameter>();
            if (tt.TeamName!="-1")
            {
                wherelist.Add("TeamName=@TeamName");
                paralist.Add(new SqlParameter("@TeamName",tt.TeamName));
            }
            if (!string.IsNullOrWhiteSpace(tt.Leader))
            {
                wherelist.Add("Leader=@Leader");
                paralist.Add(new SqlParameter("@Leader", tt.Leader));
            }
            if (wherelist.Count>0)
            {
                sql.Append($" where {string.Join(" and ",wherelist.ToArray())}");
            }
            SqlDataReader sdr = DBHelper.ExecuteReader(sql.ToString(),paralist.ToArray());
            List<TruckTeam> truckTeamlist = new List<TruckTeam>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    TruckTeam truckTeam = new TruckTeam();
                    truckTeam.TeamID = Convert.ToInt32(sdr["TeamID"]);
                    truckTeam.TeamName = sdr["TeamName"].ToString();
                    truckTeam.Leader = sdr["Leader"].ToString();
                    truckTeam.CheckInTime = Convert.ToDateTime(sdr["CheckInTime"]);
                    truckTeam.AlterTime = Convert.ToDateTime(sdr["AlterTime"]);
                    truckTeam.Remark = sdr["Remark"].ToString();
                    truckTeamlist.Add(truckTeam);
                }
            }
            return truckTeamlist;
        }


        public static DataTable GetTruckTeam(TruckTeam team)
        {
            StringBuilder sql = new StringBuilder(@"SELECT [TeamID]
      ,[TeamName]
      ,[Leader]
      ,[Remark]
      ,[CheckInTime]
      ,[AlterTime]
  FROM[TruckTeam] where IsDelete=0");
            List<string> wherelist = new List<string>();
            List<SqlParameter> para = new List<SqlParameter>();
            if (team.TeamID != -1)
            {
                wherelist.Add("[TeamID]=@TeamID");
                para.Add(new SqlParameter("@TeamID", team.TeamID));
            }
            if (!string.IsNullOrWhiteSpace(team.Leader))
            {
                wherelist.Add("[Leader] like @Leader");
                para.Add(new SqlParameter("@Leader", "%" + team.Leader + "%"));
            }
            if (wherelist.Count > 0)
            {
                sql.Append($" and {string.Join(" and ", wherelist.ToArray())}");
            }
            return DBHelper.ExecuteDataTable(sql.ToString(), para.ToArray());
        }
        public static int AddTruckTeam(TruckTeam tm)
        {
            string sql = "insert into [TruckTeam] values(@TeamName,@Leader,@Remark,getdate(),0,getdate())";
            SqlParameter[] para = 
            {
                new SqlParameter("@TeamName",tm.TeamName),
                new SqlParameter("@Leader",tm.Leader),
                new SqlParameter("@Remark",tm.Remark)
            };
            return DBHelper.ExcuteNonQuery(sql,para);
        }
        public static int UpdateTruckTeam(TruckTeam tt)
        {
            string sql = "update [TruckTeam] set TeamName=@TeamName,Leader=@Leader,CheckInTime=@CheckInTime,Remark=@Remark,AlterTime=getdate() where TeamID=@TeamID";
            SqlParameter[] para =
                {
                new SqlParameter("@TeamID",tt.TeamID),
                new SqlParameter("@Leader",tt.Leader),
                new SqlParameter("@Remark",tt.Remark),
                new SqlParameter("@TeamName",tt.TeamName),
                new SqlParameter("@CheckInTime",tt.CheckInTime)
            };
            return DBHelper.ExcuteNonQuery(sql,para);
        }
        public static int DeleteTruckTeam(int teamId)
        {
            string sql = "update [TruckTeam] set IsDelete=1 where [TeamID]=@TeamID";
            SqlParameter[] para = { new SqlParameter("@TeamID",teamId) };
            return DBHelper.ExcuteNonQuery(sql, para);
        }
        public static object GetTruckNameById(int teamId)
        {
            string sql = "select [TeamName] from [TruckTeam] where [TeamID]=@TeamID and IsDelete=0";
            SqlParameter[] para = { new SqlParameter("@TeamID", teamId) };
            return DBHelper.ExcuteScalar(sql, para);
        }
        
    }
}
