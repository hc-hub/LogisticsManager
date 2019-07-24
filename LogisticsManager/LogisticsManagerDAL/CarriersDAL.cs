using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsManagerModel;
using System.Data.SqlClient;
using System.Data;

namespace LogisticsManagerDAL
{
    public class CarriersDAL
    {
        public static List<Carriers> GetCarriers()
        {
            string procName = "P_Carriers_GetFreeCariers";
            SqlDataReader reader = DBHelper.ExecuteReaderProc(procName);
            List<Carriers> carrlist = new List<Carriers>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Carriers carr = new Carriers();
                    carr.CarriersID = Convert.ToInt32(reader["CarriersID"]);
                    carr.SendLinkman = reader["SendLinkman"].ToString();
                    carr.SendCompany = reader["SendCompany"].ToString();
                    carr.SendAddress = reader["SendAddress"].ToString();
                    carr.ReceiveLinkman = reader["ReceiveLinkman"].ToString();
                    carr.ReceiveCompany = reader["ReceiveCompany"].ToString();
                    carr.ReceiveAddress = reader["ReceiveAddress"].ToString();
                    carr.LeaverDate = Convert.ToDateTime(reader["LeaverDate"]);
                    carr.TotalCost = Convert.ToDouble(reader["TotalCost"]);
                    carr.FinishedState = Convert.ToByte(reader["FinishedState"]);
                    carrlist.Add(carr);
                }
            }
            return carrlist;
        }
        public static List<Carriers> GetCarriersWhere(Carriers carr)
        {
            string sql = @"SELECT

        CarriersID,
		SendCompany,
		SendAddress,
		SendLinkman,
		SendPhone,
		ReceiveCompany,
		ReceiveAddress,
		ReceiveLinkman,
		ReceivePhone,
		LeaverDate,
		FinishedState,
		InsuranceCost,
		TransportCost,
		OtherCost,
		TotalCost,
		Remark,
		FK_UserID,
		CheckInTime,
		IsDelete,
		AlterTime
    FROM

        Carriers
    WHERE FinishedState = 0 AND IsDelete = 0";
            List<string> wherelist = new List<string>();
            List<SqlParameter> paralist = new List<SqlParameter>();
            if (carr.CarriersID!=0)
            {
                wherelist.Add(" CarriersID=@CarriersID");
                paralist.Add(new SqlParameter("@CarriersID",carr.CarriersID));
            }
            if (!string.IsNullOrWhiteSpace(carr.LeaverDateS))
            {
                wherelist.Add(" LeaverDate>@LeaverDateS");
                paralist.Add(new SqlParameter("@LeaverDateS", carr.LeaverDateS));
            }
            if (!string.IsNullOrWhiteSpace(carr.LeaverDateE))
            {
                wherelist.Add(" LeaverDate<@LeaverDateE");
                paralist.Add(new SqlParameter("@LeaverDateE", carr.LeaverDateE));
            }
            if (!string.IsNullOrWhiteSpace(carr.ReceiveLinkman))
            {
                wherelist.Add(" ReceiveLinkman like @ReceiveLinkman");
                paralist.Add(new SqlParameter("@ReceiveLinkman","%"+ carr.ReceiveLinkman + "%"));
            }
            if (!string.IsNullOrWhiteSpace(carr.SendLinkman))
            {
                wherelist.Add(" SendLinkman like @SendLinkman");
                paralist.Add(new SqlParameter("@SendLinkman", "%" + carr.SendLinkman + "%"));
            }
            if (wherelist.Count>0)
            {
                sql += " and " +string.Join(" and ",wherelist.ToArray());
            }
            SqlDataReader reader = DBHelper.ExecuteReader(sql,paralist.ToArray());
            List<Carriers> carrlist = new List<Carriers>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Carriers car = new Carriers();
                    car.CarriersID = Convert.ToInt32(reader["CarriersID"]);
                    car.SendLinkman = reader["SendLinkman"].ToString();
                    car.SendCompany = reader["SendCompany"].ToString();
                    car.SendAddress = reader["SendAddress"].ToString();
                    car.ReceiveLinkman = reader["ReceiveLinkman"].ToString();
                    car.ReceiveCompany = reader["ReceiveCompany"].ToString();
                    car.ReceiveAddress = reader["ReceiveAddress"].ToString();
                    car.LeaverDate = Convert.ToDateTime(reader["LeaverDate"]);
                    car.TotalCost = Convert.ToDouble(reader["TotalCost"]);
                    car.FinishedState = Convert.ToByte(reader["FinishedState"]);
                    carrlist.Add(car);
                }
            }
            return carrlist;
        }

        public static int AddCarriers(Carriers carr)
        {
            string procName = "P_Carriers_CreateCarriersGetCarriersID";
            SqlParameter[] para =
                {
                new SqlParameter("@SendCompany",carr.SendCompany),
                new SqlParameter("@SendAddress",carr.SendAddress),
                new SqlParameter("@SendLinkman",carr.SendLinkman),
                new SqlParameter("@SendPhone",carr.SendPhone),
                new SqlParameter("@ReceiveCompany",carr.ReceiveCompany),
                new SqlParameter("@ReceiveAddress",carr.ReceiveAddress),
                new SqlParameter("@ReceiveLinkman",carr.ReceiveLinkman),
                new SqlParameter("@ReceivePhone",carr.ReceivePhone),
                new SqlParameter("@InsuranceCost",carr.InsuranceCost),
                new SqlParameter("@TransportCost",carr.TransportCost),
                new SqlParameter("@OtherCost",carr.OtherCost),
                new SqlParameter("@FK_UserID",carr.FK_UserID)
            };
            return DBHelper.ExcuteNonQueryProc(procName, para);
        }
        public static int DeleteCarriers(int Id)
        {
            string procName = "P_Carriers_DeleteCarriers";
            SqlParameter[] para = { new SqlParameter("@CarriersID", Id) };
            return DBHelper.ExcuteNonQueryProc(procName, para);
        }
        public static int GetStateById(int Id)
        {
            string sql = "select FinishedState from [Carriers] where CarriersID=@CarriersID";
            SqlParameter[] para =
                {
                new SqlParameter("@CarriersID",Id)
            };
            return DBHelper.ExcuteNonQuery(sql);
        }
        public static Carriers GetOneCarriers(int carriersID)
        {
            Carriers result = new Carriers();
            string procName = "dbo.P_Carriers_GetOneCarriers";
            SqlParameter[] prams = { new SqlParameter("@CarriersID", carriersID) };
            SqlDataReader sdr = DBHelper.ExecuteReaderProc(procName, prams);
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    result.CarriersID = Convert.ToInt32(sdr["CarriersID"]);
                    result.SendCompany = sdr["SendCompany"].ToString();
                    result.SendAddress = sdr["SendAddress"].ToString();
                    result.SendPhone = sdr["SendPhone"].ToString();
                    result.ReceiveLinkman = sdr["ReceiveLinkman"].ToString();
                    result.ReceiveCompany = sdr["ReceiveCompany"].ToString();
                    result.ReceivePhone = sdr["ReceivePhone"].ToString();
                    result.ReceiveAddress = sdr["ReceiveAddress"].ToString();
                    result.FinishedState = Convert.ToByte(sdr["FinishedState"]);
                    if (sdr["ReceiveDate"] != DBNull.Value)
                    {
                        result.ReceiveDate = Convert.ToDateTime(sdr["ReceiveDate"]);
                    }
                    result.TransportCost = Convert.ToDouble(sdr["TransportCost"]);
                    result.InsuranceCost = Convert.ToDouble(sdr["InsuranceCost"]);
                    result.OtherCost = Convert.ToDouble(sdr["OtherCost"]);
                    result.TotalCost = Convert.ToDouble(sdr["TotalCost"]);
                    if (sdr["LeaverDate"] != DBNull.Value)
                    {
                        result.LeaverDate = Convert.ToDateTime(sdr["LeaverDate"]);
                    }
                    result.SendLinkman = sdr["SendLinkman"].ToString();
                    result.FK_UserID = Convert.ToInt32(sdr["FK_UserID"]);
                    result.Remark = sdr["Remark"].ToString();
                }
            }
            return result;
        }
        public static List<Carriers> GetCarriersByUserID(int userId)
        {
            string procName = "P_Carriers_GetCarriersByUserID";
            SqlParameter[] para =
                {
                new SqlParameter("@FK_UserID",SqlDbType.Int),
            };
            para[0].Value = userId;
            SqlDataReader sdr = DBHelper.ExecuteReaderProc(procName, para);
            List<Carriers> carrierslist = new List<Carriers>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Carriers result = new Carriers();
                    result.CarriersID = Convert.ToInt32(sdr["CarriersID"]);
                    result.SendCompany = sdr["SendCompany"].ToString();
                    result.SendAddress = sdr["SendAddress"].ToString();
                    result.SendPhone = sdr["SendPhone"].ToString();
                    result.ReceiveLinkman = sdr["ReceiveLinkman"].ToString();
                    result.ReceiveCompany = sdr["ReceiveCompany"].ToString();
                    result.ReceivePhone = sdr["ReceivePhone"].ToString();
                    result.ReceiveAddress = sdr["ReceiveAddress"].ToString();
                    result.FinishedState = Convert.ToByte(sdr["FinishedState"]);
                    if (sdr["ReceiveDate"] != DBNull.Value)
                    {
                        result.ReceiveDate = Convert.ToDateTime(sdr["ReceiveDate"]);
                    }
                    result.TransportCost = Convert.ToDouble(sdr["TransportCost"]);
                    result.InsuranceCost = Convert.ToDouble(sdr["InsuranceCost"]);
                    result.OtherCost = Convert.ToDouble(sdr["OtherCost"]);
                    result.TotalCost = Convert.ToDouble(sdr["TotalCost"]);
                    if (sdr["LeaverDate"] != DBNull.Value)
                    {
                        result.LeaverDate = Convert.ToDateTime(sdr["LeaverDate"]);
                    }
                    result.SendLinkman = sdr["SendLinkman"].ToString();
                    result.FK_UserID = Convert.ToInt32(sdr["FK_UserID"]);
                    result.Remark = sdr["Remark"].ToString();
                    carrierslist.Add(result);
                }
            }
            return carrierslist;
        }
        public static int ReceiveCarriers(int carriersId)
        {
            string procName = "P_Carriers_ReceiveCarriers";
            SqlParameter[] para = { new SqlParameter("@CarriersID", carriersId) };
            return DBHelper.ExecuteNoQueryByProc(procName, para);

        }
        public static List<Carriers> GetCostByUserId(int userId, Carriers carr, int pageSize, int pageIndex, out int recordCount)
        {
            recordCount = 0;
            Paging page = new Paging();
            page.TableName = "[Carriers] a inner join [Scheduling] b on a.CarriersID=b.FK_CarriersID";
            page.PrimaryKey = "[SchedulingID]";
            page.Fields = @"[SchedulingID]
      ,[CarriersID]
      ,[SendCompany]
      ,[ReceiveDate]
      ,[FinishedState]
      ,a.[TotalCost] as [TotalCostC]
      ,[OilCost]
      ,[Toll]
      ,[Fine]
      ,b.[OtherCost]
      ,b.[TotalCost] as [TotalCostS]
      ,b.[FK_UserID]
      ,b.[IsDelete]
      ,b.[AlterTime]";
            List<string> wherelist = new List<string>();
            StringBuilder where = new StringBuilder();
            where.Append("b.IsDelete=0 and FinishedState>1");
            if (carr.FinishedState != 0)
            {
                if (carr.FinishedState == 1)
                {
                    wherelist.Add($" FinishedState=2");
                }
                else
                {
                    wherelist.Add($" FinishedState=3");
                }
            }
            if (!string.IsNullOrWhiteSpace(carr.ReceiveDateS))
            {
                wherelist.Add($" ReceiveDate>'{carr.ReceiveDateS}'");
            }
            if (!string.IsNullOrWhiteSpace(carr.ReceiveDateE))
            {
                wherelist.Add($" ReceiveDate<'{carr.ReceiveDateE}'");
            }
            if (wherelist.Count > 0)
            {
                where.Append(" and "+string.Join($" and ", wherelist));
            }
            page.Condition = where.ToString();
            page.PageSize = pageSize;
            page.PageIndex = pageIndex;
            DataTable dt = PublicPaging.ProcGetPageData(page, out recordCount);
            List<Carriers> carrlist = new List<Carriers>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Carriers ca = new Carriers();
                    ca.CarriersID = Convert.ToInt32(item["CarriersID"]);
                    ca.SchedulingID = Convert.ToInt32(item["SchedulingID"]);
                    ca.SendCompany = item["SendCompany"].ToString();

                    ca.ReceiveDate = Convert.ToDateTime(item["ReceiveDate"]);



                    ca.FinishedState = Convert.ToByte(item["FinishedState"]);
                    ca.TotalCost = Convert.ToDouble(item["TotalCostC"]);
                    ca.OilCost = Convert.ToDouble(item["OilCost"]);
                    ca.Toll = Convert.ToDouble(item["Toll"]);
                    ca.Fine = Convert.ToDouble(item["Fine"]);
                    ca.OtherCost = Convert.ToDouble(item["OtherCost"]);
                    ca.TotalCostS = Convert.ToDouble(item["TotalCostS"]);
                    ca.FK_UserID = Convert.ToInt32(item["FK_UserID"]);
                    ca.IsDelete = Convert.ToByte(item["IsDelete"]);
                    ca.AlterTime = Convert.ToDateTime(item["AlterTime"]);
                    carrlist.Add(ca);
                }
            }
            return carrlist;
        }
        public static Carriers GetCarriersDetils(int carriersId)
        {
            string procName = "P_Carriers_GetOneCarriers";
            SqlParameter[] para = { new SqlParameter("@CarriersID",carriersId)};
            SqlDataReader sdr = DBHelper.ExecuteReaderProc(procName,para);
            Carriers result = new Carriers();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    
                    result.CarriersID = Convert.ToInt32(sdr["CarriersID"]);
                    result.SendCompany = sdr["SendCompany"].ToString();
                    result.SendAddress = sdr["SendAddress"].ToString();
                    result.SendPhone = sdr["SendPhone"].ToString();
                    result.ReceiveLinkman = sdr["ReceiveLinkman"].ToString();
                    result.ReceiveCompany = sdr["ReceiveCompany"].ToString();
                    result.ReceivePhone = sdr["ReceivePhone"].ToString();
                    result.ReceiveAddress = sdr["ReceiveAddress"].ToString();
                    result.FinishedState = Convert.ToByte(sdr["FinishedState"]);
                    if (sdr["ReceiveDate"] != DBNull.Value)
                    {
                        result.ReceiveDate = Convert.ToDateTime(sdr["ReceiveDate"]);
                    }
                    result.TransportCost = Convert.ToDouble(sdr["TransportCost"]);
                    result.InsuranceCost = Convert.ToDouble(sdr["InsuranceCost"]);
                    result.OtherCost = Convert.ToDouble(sdr["OtherCost"]);
                    result.TotalCost = Convert.ToDouble(sdr["TotalCost"]);
                    if (sdr["LeaverDate"] != DBNull.Value)
                    {
                        result.LeaverDate = Convert.ToDateTime(sdr["LeaverDate"]);
                    }
                    result.SendLinkman = sdr["SendLinkman"].ToString();
                    result.FK_UserID = Convert.ToInt32(sdr["FK_UserID"]);
                    result.Remark = sdr["Remark"].ToString();
                }
            }
            return result;
        }
        public static int UpdateCarriersByCarriers(Carriers carr)
        {


            string sql = @"UPDATE  dbo.Carriers SET SendCompany=@senndCompany,SendAddress=@sendaddress,SendLinkman=@seendlinkman,SendPhone=@sendphone,InsuranceCost=@insurancecost,OtherCost=@otherCost,
                    ReceiveCompany=@receivecompany,ReceiveAddress=@receiveaddress,ReceiveLinkman=@receivelinkman,ReceivePhone=@receivephone,TransportCost=@transportcost where CarriersID=@carriersid";
            SqlParameter[] pars = { new SqlParameter("@senndCompany",carr.SendCompany),
                new SqlParameter("@sendaddress",carr.SendAddress),
                new SqlParameter("@seendlinkman",carr.SendLinkman),
                new SqlParameter("@sendphone",carr.SendPhone),
                new SqlParameter("@insurancecost",carr.InsuranceCost),
                new SqlParameter("@otherCost",carr.OtherCost),
                new SqlParameter("@receivecompany",carr.ReceiveCompany),
                new SqlParameter("@receiveaddress",carr.ReceiveAddress),

                new SqlParameter("@receivelinkman",carr.ReceiveLinkman),

                new SqlParameter("@receivephone",carr.ReceivePhone),
                 new SqlParameter("@transportcost",carr.TransportCost),
                  new SqlParameter("@carriersid",carr.CarriersID),

            };

            return DBHelper.ExcuteNonQuery(sql, pars);




        }
        public static List<Carriers> GetCarriersH(Carriers carr, int pageSize, int pageIndex, out int recordCount)
        {
            recordCount = 0;
            Paging page = new Paging();
            page.TableName = "[Carriers]";
            page.PrimaryKey = "[CarriersID]";
            page.Fields = @"[CarriersID]
      ,[SendCompany]
      ,[SendLinkman]
      ,[ReceiveCompany]
      ,[ReceiveLinkman]
      ,[LeaverDate]
      ,[TotalCost]
      ,[FK_UserID]";
            List<string> wherelist = new List<string>();
            StringBuilder where = new StringBuilder();
            where.Append("IsDelete=0 and FinishedState=3");
            if (carr.CarriersID!=0)
            {
                wherelist.Add($" CarriersID='{carr.CarriersID}'");
            }
            if (!string.IsNullOrWhiteSpace(carr.LeaverDateS))
            {
                wherelist.Add($" LeaverDate>'{carr.LeaverDateS}'");
            }
            if (!string.IsNullOrWhiteSpace(carr.LeaverDateE))
            {
                wherelist.Add($" LeaverDate<'{carr.LeaverDateE}'");
            }
            if (!string.IsNullOrWhiteSpace(carr.SendLinkman))
            {
                wherelist.Add($" SendLinkman like '%{carr.SendLinkman}%'");
            }
            if (!string.IsNullOrWhiteSpace(carr.ReceiveLinkman))
            {
                wherelist.Add($" ReceiveLinkman like '%{carr.ReceiveLinkman}%'");
            }
            if (!string.IsNullOrWhiteSpace(carr.UserName))
            {
                wherelist.Add($" FK_UserID in (select UserID from [User] where UserName like '%{carr.UserName}%')");
            }
            if (!string.IsNullOrWhiteSpace(carr.ReceiveDateS))
            {
                wherelist.Add($" ReceiveDate>'{carr.ReceiveDateS}'");
            }
            if (!string.IsNullOrWhiteSpace(carr.ReceiveDateE))
            {
                wherelist.Add($" ReceiveDate<'{carr.ReceiveDateE}'");
            }
            if (wherelist.Count > 0)
            {
                where.Append(" and " + string.Join($" and ", wherelist));
            }
            page.Condition = where.ToString();
            page.PageSize = pageSize;
            page.PageIndex = pageIndex;
            DataTable dt = PublicPaging.ProcGetPageData(page, out recordCount);
            List<Carriers> carrlist = new List<Carriers>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Carriers ca = new Carriers();
                    ca.CarriersID = Convert.ToInt32(item["CarriersID"]);
                    ca.SendCompany = item["SendCompany"].ToString();
                    ca.SendLinkman = item["SendLinkman"].ToString();
                    ca.ReceiveCompany = item["ReceiveCompany"].ToString();
                    ca.ReceiveLinkman = item["ReceiveLinkman"].ToString();
                    ca.LeaverDate = Convert.ToDateTime(item["LeaverDate"]);
                    ca.TotalCost = Convert.ToDouble(item["TotalCost"]);
                    ca.FK_UserID = Convert.ToInt32(item["FK_UserID"]);

                    carrlist.Add(ca);
                }
            }
            return carrlist;
        }
    }
}
