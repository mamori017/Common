using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Common
{
    public class MySql
    {
        public MySqlConnection MySqlConnection { get; private set; }
        public MySqlTransaction MySqlTransaction { get; private set; }
        public MySqlCommand MySqlCommand { get; private set; }
        public string ServerName { get; private set; }
        public string UserId { get; private set; }
        public string Database { get; private set; }
        public string Password { get; private set; }
        public bool Disposed { get; private set; }

        public MySql(String mysqlServerName, String mysqlDatabase, String mysqlUser, String mysqlPassword)
        {
            ServerName = mysqlServerName;
            Database = mysqlDatabase;
            UserId = mysqlUser;
            Password = mysqlPassword;
        }

        public bool Connect()
        {
            try
            {
                MySqlConnection = new MySqlConnection
                {
                    ConnectionString = SqlConString()
                };
                MySqlConnection.Open();
                MySqlCommand = MySqlConnection.CreateCommand();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private String SqlConString()
        {
            String ret = string.Format("Server={0};Database={1};Uid={2};Pwd={3}",
                                        ServerName, Database, UserId, Password);
            return ret;
        }

        public bool BeginTrans()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Open && MySqlTransaction == null)
                {
                    MySqlTransaction = MySqlConnection.BeginTransaction();
                    MySqlCommand.Transaction = MySqlTransaction;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool RollBack()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Open && MySqlTransaction != null)
                {
                    MySqlTransaction.Rollback();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Commit()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Open && MySqlTransaction != null)
                {
                    MySqlTransaction.Commit();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Disconnect()
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Open)
                {
                    MySqlConnection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTable GetData(string sql)
        { 
            MySqlDataAdapter reader = null;
            DataTable ret = null;

            try
            {
                if (MySqlConnection.State == ConnectionState.Open)
                {
                    reader = new MySqlDataAdapter(sql, MySqlConnection);
                    ret = new DataTable();
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ChangeData(String sql)
        {
            int retCnt = 0;
            try
            {
                if (MySqlConnection.State == ConnectionState.Open)
                {
                    retCnt = MySqlCommand.ExecuteNonQuery();
                }
                return retCnt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CreateAndDropTable(String sql)
        {
            try
            {
                if (MySqlConnection.State == ConnectionState.Open)
                {
                    try
                    {
                        MySqlCommand.CommandText = sql;
                        MySqlCommand.ExecuteNonQuery();
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
                throw;
            }
        }
    }
}