using AdjustmentSys.Tool.Enums;
using AdjustmentSys.Tool.FileOpter;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdjustmentSys.Tool
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class DBHelper
    {
        public readonly static string SqlConn = IniConfigTB.ConnString;//"Server=47.109.107.251,1433;database=AdjustmentSysDB;uid=sa;pwd=LDSsql20231106;TrustServerCertificate=true";

        /// <summary>
        /// 执行增、删、改的方法：ExecuteNonQuery,返回true,false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sql, SqlParameter[] pms)
        {
            using (SqlConnection conn = new SqlConnection(SqlConn))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (pms != null && pms.Length > 0)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        cmd.Transaction = transaction;
                        int rows = cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return rows > 0;
                    }
                }
            }
        }


        /// <summary>
        ///  执行增、删、改的方法：ExecuteNonQuery,返回true,false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sql, Dictionary<string, object> pms)
        {
            SqlParameter[] parameters = null;

            if (pms != null && pms.Count > 0)
            {
                parameters = DictionaryToSqlParameters(pms).ToArray();
            }

            return ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        ///  执行增、删、改的方法：ExecuteNonQuery,返回true,false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, new SqlParameter[] { });
        }

        /// <summary>
        /// 执行一个TSQL命令
        /// </summary>
        /// <param name="sqlcmd">TSQL语句</param>
        /// <returns></returns>
        public static bool Execute(string sqlcmd)
        {
            SqlConnection conn = new SqlConnection(SqlConn);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    int rows= cmd.ExecuteNonQuery();
                    return rows > 0 ;
                }
            }
            catch (Exception ex)
            {
                string errorInfo = "调用<public static int ExecuteNonQuery(string sqlcmd)>方法时发生错误：" + ex.Message;
                OperateLog.WriteLog(LogTypeEnum.数据库, errorInfo);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 将查出的数据装到实体里面，返回一个List
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static List<T> ExecuteQuery<T>(string sql, SqlParameter[] pms) where T : new()
        {
            using (var connection = new SqlConnection(SqlConn))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    if (pms != null && pms.Length > 0)
                    {
                        command.Parameters.AddRange(pms);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        List<T> tList = new List<T>();

                        while (reader.Read()) // 遍历结果集中的每一行数据  
                        {
                            var t = ConvertToModel<T>(reader);
                            tList.Add(t);
                        }
                        return tList;
                    }
                }
            }
        }

        /// <summary>
        /// 将查出的数据装到实体里面，返回一个List
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static List<T> ExecuteQuery<T>(string sql, Dictionary<string, object> pms) where T : new()
        {
            SqlParameter[] parameters = null;

            if (pms != null)
            {
                parameters = DictionaryToSqlParameters(pms).ToArray();
            }

            return ExecuteQuery<T>(sql, parameters);
        }


        /// <summary>
        /// 将查出的数据装到实体里面，返回一个List
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> ExecuteQuery<T>(string sql) where T : new()
        {
            return ExecuteQuery<T>(sql, new SqlParameter[] { });
        }

        /// <summary>
        /// 将查出的数据装到实体里面，返回一个实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static T ExecuteQueryOne<T>(string sql, SqlParameter[] pms) where T : new()
        {
            using (var connection = new SqlConnection(SqlConn))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    if (pms != null && pms.Length > 0)
                    {
                        command.Parameters.AddRange(pms);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // 遍历结果集中的每一行数据  
                        {

                            var t = ConvertToModel<T>(reader);

                            return t;
                        }

                        return default(T);
                    }
                }
            }
        }

        /// <summary>
        /// 将查出的数据装到实体里面，返回一个实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static T ExecuteQueryOne<T>(string sql, Dictionary<string, object> pms) where T : new()
        {
            SqlParameter[] parameters = null;

            if (pms != null && parameters.Length > 0)
            {
                parameters = DictionaryToSqlParameters(pms).ToArray();
            }

            return ExecuteQueryOne<T>(sql, parameters);
        }

        /// <summary>
        /// 将查出的数据装到实体里面，返回一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static T ExecuteQueryOne<T>(string sql) where T : new()
        {
            return ExecuteQueryOne<T>(sql, new SqlParameter[] { });
        }

        /// <summary>
        /// 返回第一行第一列的值
        /// </summary>
        /// <param name="sqlcmd">TSQL语句</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlcmd)
        {
            SqlConnection conn = new SqlConnection(SqlConn);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                {
                    object Result = null;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    Result = cmd.ExecuteScalar();
                    if (Result == null)
                    {
                        return -1;
                    }
                    else
                    {
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 将查出的数据装到table里，返回一个DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryDataTable(string sql, SqlParameter[] pms = null)
        {
            DataTable dt = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, SqlConn))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// 将查出的数据装到table里，返回一个DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryDataTable(string sql, Dictionary<string, object> pms)
        {
            SqlParameter[] parameters = null;

            if (pms != null)
            {
                parameters = DictionaryToSqlParameters(pms).ToArray();
            }

            return ExecuteQueryDataTable(sql, parameters);
        }

        /// <summary>
        /// 将查出的数据装到table里，返回一个DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryDataTable(string sql)
        {
            SqlParameter[] parameters = null;

            return ExecuteQueryDataTable(sql, parameters);
        }

        /// <summary>
        /// 字典转SqlParameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static List<SqlParameter> DictionaryToSqlParameters(Dictionary<string, object> parameters)
        {
            List<SqlParameter> SqlParameters = new List<SqlParameter>();

            foreach (var kvp in parameters)
            {
                string parameterName = kvp.Key;
                object parameterValue = kvp.Value;

                // 创建 SqlParameter 对象  
                SqlParameter SqlParameter = new SqlParameter(parameterName, parameterValue);
                SqlParameters.Add(SqlParameter);
            }
            return SqlParameters;
        }

        /// <summary>
        /// 按列名转换(单条使用比较方便)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T ConvertToModel<T>(SqlDataReader reader) where T : new()
        {
            T t = new T();

            PropertyInfo[] propertys = t.GetType().GetProperties();

            List<string> drColumnNames = new List<string>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                drColumnNames.Add(reader.GetName(i));
            }

            foreach (PropertyInfo pi in propertys)
            {
                if (drColumnNames.Contains(pi.Name))
                {
                    if (!pi.CanWrite)
                    {
                        continue;
                    }
                    var value = reader[pi.Name];
                    if (value != DBNull.Value)
                    {
                        pi.SetValue(t, value, null);
                    }
                }
            }
            return t;
        }

        public DataSet GetPagedData(string sqlQuery, int pageIndex, int pageSize)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(SqlConn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                // 设置参数
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int)).Value = pageIndex;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int)).Value = pageSize;

                // 分页的SQL查询需要你自己写，这里以存储过程为例
                // 假设你有一个名为GetPagedData的存储过程
                adapter.SelectCommand.CommandText = "GetPagedData";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 设置适当的参数
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int)).Value = pageIndex;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int)).Value = pageSize;

                // 填充DataSet
                adapter.Fill(ds);
            }
            return ds;
        }

        /// <summary>
        /// 将查出的数据装到实体里面，返回一个List
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        //public static List<T> GetPageData<T>(string sql, SqlParameter[] pms, int pageIndex, int pageSize,out int totalCount) where T : new()
        //{
        //    using (var connection = new SqlConnection(SqlConn))
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand(sql, connection))
        //        {
        //            if (pms != null && pms.Length > 0)
        //            {
        //                command.Parameters.AddRange(pms);
        //            }

        //            using (var reader = command.ExecuteReader())
        //            {
        //                List<T> tList = new List<T>();

        //                while (reader.Read()) // 遍历结果集中的每一行数据  
        //                {
        //                    var t = ConvertToModel<T>(reader);
        //                    tList.Add(t);
        //                }
        //                return tList;
        //            }
        //        }
        //    }
        //}
    }
}
