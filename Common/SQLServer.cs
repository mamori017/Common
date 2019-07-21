using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Common
{
    public class SQLServer
    {
        public SqlConnection Conn { get; private set; }
        public SqlTransaction Trans { get; private set; }
        public SqlCommand Cmd { get; private set; }
        public string ServerName { get; private set; }
        public string UserId { get; private set; }
        public string Catalog { get; private set; }
        public string Password { get; private set; }
        public bool Disposed { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="SqlServerName">SQLServer</param>
        /// <param name="SqlServerCatalog">Catalog</param>
        /// <param name="SqlServerUser">User Name</param>
        /// <param name="SqlServerPassword">Password</param>
        public SQLServer(string SqlServerName, string SqlServerCatalog, string SqlServerUser, string SqlServerPassword)
        {
            ServerName = SqlServerName;
            Catalog = SqlServerCatalog;
            UserId = SqlServerUser;
            Password = SqlServerPassword;
        }

        /// <summary>
        /// Database Connect
        /// </summary>
        /// <returns>True:Success/False:Fail</returns>
        public bool Connect()
        {
            try
            {
                Conn = new SqlConnection
                {
                    ConnectionString = SqlConString()
                };
                Conn.Open();
                Cmd = Conn.CreateCommand();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Database Connection String
        /// </summary>
        /// <returns>Connection String</returns>
        private string SqlConString()
        {
            return string.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerName, Catalog, UserId, Password); ;
        }

        /// <summary>
        /// Transaction Start
        /// </summary>
        /// <returns>True:Success/False:Fail</returns>
        public bool BeginTrans()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans == null)
                {
                    Trans = Conn.BeginTransaction();
                    Cmd.Transaction = Trans;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Rollback
        /// </summary>
        /// <returns>True:Success/False:Fail</returns>
        public bool RollBack()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans != null)
                {
                    Trans.Rollback();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Commit
        /// </summary>
        /// <returns>True:Success/False:Fail</returns>
        public bool Commit()
        {
            try
            {
                if (Conn.State == ConnectionState.Open && Trans != null)
                {
                    Trans.Commit();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <returns>True:Success/False:Fail</returns>
        public bool Disconnect()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ExecuteReader(Get)
        /// </summary>
        /// <param name="sql">Query</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteReader(string sql)
        {
            DataTable ret = null;

            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Cmd.CommandText = sql;
                    SqlDataReader reader = Cmd.ExecuteReader();
                    if (reader != null)
                    {
                        ret = new DataTable();
                        ret.Load(reader);
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ExecuteNonQuery(Create/Delete/Change)
        /// </summary>
        /// <param name="sql">Query</param>
        /// <returns>Target count</returns>
        public int ExecuteNonQuery(string sql)
        {
            var retCnt = 0;

            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Cmd.CommandText = sql;
                    retCnt = Cmd.ExecuteNonQuery();
                }
                return retCnt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get table lock info
        /// </summary>
        /// <param name="objectName"></param>
        /// <returns></returns>
        public bool GetTableLockInfo(string objectName)
        {
            var ret = false;

            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Cmd.CommandText = Query.GetLockInfoQuery();

                    SqlDataReader reader = Cmd.ExecuteReader();

                    if (reader != null)
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);

                        for (int i = 0; i < dataTable.Rows.Count - 1; i++)
                        {
                            if (dataTable.Rows[i].ItemArray[0].ToString() == "OBJECT" &&
                                dataTable.Rows[i].ItemArray[2].ToString() == objectName &&
                                dataTable.Rows[i].ItemArray[5].ToString() == "GRANT")
                            {
                                ret = true;
                            }
                        }
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get lock range
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Lock range</returns>
        private static string GetLockRange(string type)
        {
            var ret = "";

            switch (type)
            {
                case "DB":
                    ret = "DB単位";
                    break;
                case "TAB":
                    ret = "テーブル単位";
                    break;
                case "PAGE":
                    ret = "ページ単位";
                    break;
                case "ROW":
                    ret = "行単位";
                    break;
                case "KEY":
                    ret = "キー単位";
                    break;
                default:
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Get lock state
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Lock state</returns>
        private static string GetLockState(string type)
        {
            var ret = "";

            switch (type)
            {
                case "S":
                    ret = "共有ロック";
                    break;
                case "X":
                    ret = "排他ロック";
                    break;
                case "U":
                    ret = "更新ロック";
                    break;
                case "IS":
                    ret = "インテント共有";
                    break;
                case "IX":
                    ret = "インテント排他";
                    break;
                case "SIX":
                    ret = "インテント排他の共有";
                    break;
                case "IU":
                    ret = "インテント更新";
                    break;
                case "SIU":
                    ret = "共有インテント更新";
                    break;
                case "UIX":
                    ret = "更新インテント排他";
                    break;
                default:
                    break;
            }
            return ret;
        }

        /// <summary>
        /// Query
        /// </summary>
        private static class Query
        {
            /// <summary>
            /// Lock state query
            /// </summary>
            /// <returns>Query</returns>
            public static string GetLockInfoQuery()
            {
                try
                {
                    var sql = new StringBuilder();

                    sql.AppendLine("SELECT");
                    sql.AppendLine("  resource_type AS type");
                    sql.AppendLine(" ,resource_associated_entity_id as entity_id");
                    sql.AppendLine(" ,(CASE WHEN resource_type = 'OBJECT' THEN");
                    sql.AppendLine("             OBJECT_NAME(resource_associated_entity_id)");
                    sql.AppendLine("        ELSE");
                    sql.AppendLine("             (SELECT");
                    sql.AppendLine("                OBJECT_NAME(OBJECT_ID)");
                    sql.AppendLine("              FROM");
                    sql.AppendLine("                sys.partitions");
                    sql.AppendLine("              WHERE");
                    sql.AppendLine("                hobt_id = resource_associated_entity_id)");
                    sql.AppendLine("        END) AS object_name");
                    sql.AppendLine(" ,request_mode");
                    sql.AppendLine(" ,request_type");
                    sql.AppendLine(" ,request_status");
                    sql.AppendLine(" ,request_session_id AS Session_id");
                    sql.AppendLine(" ,(SELECT");
                    sql.AppendLine("     hostname");
                    sql.AppendLine("   FROM");
                    sql.AppendLine("     sys.sysprocesses");
                    sql.AppendLine("   WHERE");
                    sql.AppendLine("     spid = request_session_id) AS ProcessName");
                    sql.AppendLine("FROM");
                    sql.AppendLine("  sys.dm_tran_locks");
                    sql.AppendLine("WHERE");
                    sql.AppendLine("  resource_type <> 'DATABASE'");
                    sql.AppendLine("ORDER BY");
                    sql.AppendLine("  request_session_id");

                    return sql.ToString();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
