using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LogisticsManagerDAL
{
    public class DBHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public static DataTable ExecuteDataTable(string sql, SqlParameter[] para = null, CommandType comtype = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(connString)) {
                if (conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = comtype;
                    if (para != null)
                    {
                        foreach (var item in para)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    DataTable table = new DataTable();
                    SqlDataReader reader = cmd.ExecuteReader();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static DataTable ExecuteDataTableProc(string sql,params SqlParameter[] para)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (para != null)
                    {
                        foreach (var item in para)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    DataTable table = new DataTable();
                    SqlDataReader reader = cmd.ExecuteReader();
                    table.Load(reader);
                    return table;
                }
            }
        }
        public static DataSet GetDataSet(string strSQL,SqlParameter[] pas=null, CommandType cmdtype=CommandType.Text)
        {
            DataSet dt = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                da.SelectCommand.CommandType = cmdtype;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);
            }
            return dt;

        }        
        public static SqlDataReader ExecuteReader(string sql, SqlParameter[] pams = null, CommandType cmdType = CommandType.Text)
        {
            //1.声明数据库连接
            SqlConnection conn = new SqlConnection(connString);
            //2.声明命令
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                //添加参数
                if (pams != null && pams.Length > 0)
                {
                    cmd.Parameters.AddRange(pams);
                }
                cmd.CommandType = cmdType;
                //3.打开数据库连接
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //4.执行命令
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

        }
        public static int ExcuteNonQuery(string sql, SqlParameter[] para = null, CommandType comdType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = comdType;
                    if (para != null)
                    {
                        foreach (var item in para)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static int ExecuteNoQueryByProc(string procName, params SqlParameter[] pams)
        {
            //1.声明数据库连接
            SqlConnection conn = new SqlConnection(connString);
            //2.声明命令
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                //添加参数

                //3.打开数据库连接
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (pams != null)
                {
                    cmd.Parameters.AddRange(pams);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                //4.执行命令c
                return cmd.ExecuteNonQuery();
            }

        }
        public static object ExcuteScalar(string sql, SqlParameter[] para = null, CommandType comdType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = comdType;
                    if (para != null)
                    {
                        foreach (var item in para)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExecuteReaderProc(string procName,params SqlParameter[] pams)
        {
            //1.声明数据库连接
            SqlConnection conn = new SqlConnection(connString);
            //2.声明命令
            using (SqlCommand cmd = new SqlCommand(procName, conn))
            {
                //添加参数
                if (pams != null && pams.Length > 0)
                {
                    cmd.Parameters.AddRange(pams);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                //3.打开数据库连接
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //4.执行命令
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

        }
        public static int ExcuteNonQueryProc(string sql,params SqlParameter[] para)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (para != null)
                    {
                        foreach (var item in para)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}