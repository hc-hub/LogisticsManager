using LogisticsManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LogisticsManagerBLL
{
    public class TruckTeamBLL
    {
        public static DataSet GetTruckTeam()
        {
            return LogisticsManagerDAL.TruckTeamDAL.GetTruckTeam();
        }
        public static SqlDataReader GetTruckName()
        {
            return LogisticsManagerDAL.TruckTeamDAL.GetTruckName();
        }
        public static DataTable GetTruckTeam(TruckTeam team)
        {
            return LogisticsManagerDAL.TruckTeamDAL.GetTruckTeam(team);
        }
        public static int AddTruckTeam(TruckTeam tm)
        {
            return LogisticsManagerDAL.TruckTeamDAL.AddTruckTeam(tm);
        }
        public static List<TruckTeam> GetTruckTeams()
        {
            return LogisticsManagerDAL.TruckTeamDAL.GetTruckTeams();
        }
        public static List<TruckTeam> GetTruckTeams(TruckTeam tt)
        {
            return LogisticsManagerDAL.TruckTeamDAL.GetTruckTeams(tt);
        }
        public static int UpdateTruckTeam(TruckTeam tt)
        {
            return LogisticsManagerDAL.TruckTeamDAL.UpdateTruckTeam(tt);
        }
        public static string DeleteTruckTeam(int teamId)
        {
            if (LogisticsManagerDAL.TruckTeamDAL.GetTeamId(teamId) > 0)
            {
                return "该车队存在车辆，无法删除！";
            }
            else
            {
                if (LogisticsManagerDAL.TruckTeamDAL.DeleteTruckTeam(teamId) > 0)
                {
                    return "删除成功！";

                }
                else
                {
                    return "删除失败！";
                }

            }
        }
        public static string GetTruckNameById(int teamId)
        {
            return LogisticsManagerDAL.TruckTeamDAL.GetTruckNameById(teamId).ToString();
        }
    }
}
