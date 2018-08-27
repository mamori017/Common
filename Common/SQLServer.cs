using System;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    /// <summary>
    /// </summary>
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
        /// </summary>
        /// <param name="SqlServerName"></param>
        /// <param name="SqlServerCatalog"></param>
        /// <param name="SqlServerUser"></param>
        /// <param name="SqlServerPassword"></param>
        public SQLServer(String SqlServerName, String SqlServerCatalog, String SqlServerUser, String SqlServerPassword)
        {
            ServerName = SqlServerName;
            Catalog = SqlServerCatalog;
            UserId = SqlServerUser;
            Password = SqlServerPassword;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
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
        /// </summary>
        /// <returns></returns>
        private String SqlConString()
        {
            String ret = "Data Source =" + ServerName +
                         ";Initial Catalog=" + Catalog +
                         ";User ID=" + UserId +
                         ";Password=" + Password;
            return ret;
        }

        /// <summary>
        /// Transaction Start
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetData(string sql)
        {
            SqlDataReader reader = null;
            DataTable ret = null;
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Cmd.CommandText = sql;
                    reader = Cmd.ExecuteReader();
                    if (reader != null)
                    {
                        ret = new DataTable();
                        ret.Load(reader);
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ChangeData(String sql)
        {
            int retCnt = 0;
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Cmd.CommandText = sql;
                    retCnt = Cmd.ExecuteNonQuery();
                }
                return retCnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// CreateAndDropTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool CreateAndDropTable(String sql)
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                {
                    try
                    {
                        Cmd.CommandText = sql;
                        Cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
