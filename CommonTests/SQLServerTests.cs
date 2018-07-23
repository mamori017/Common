using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Common.Tests
{
    [TestClass()]
    public class SQLServerTests
    {
        List<string> arrAppveyorIp = new List<string> { "74.205.54.20", "104.197.110.30", "104.197.145.181", "146.148.85.29", "67.225.139.254", "67.225.138.82", "67.225.139.144" };

        private SQLServer TestEnvJudge()
        {
            SQLServer objDB = null;

            try
            {
                string hostname = Dns.GetHostName();
                IPAddress[] addr_arr = Dns.GetHostAddresses(hostname);

                foreach (IPAddress addr in addr_arr)
                {
                    string addr_str = addr.ToString();
                    if (arrAppveyorIp.IndexOf(addr.ToString()) < 0)
                    {
                        objDB = new SQLServer(CommonTests.Properties.Settings.Default.SqlServerName, "", CommonTests.Properties.Settings.Default.SqlServerUser, CommonTests.Properties.Settings.Default.SqlServerPw);
                    }
                    else
                    {
                        objDB = new SQLServer(CommonTests.Properties.Settings.Default.AppveyorSqlServerName, "", CommonTests.Properties.Settings.Default.AppveyorSqlServerUser, CommonTests.Properties.Settings.Default.AppveyorSqlServerPw);
                    }
                }
                return objDB;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [TestMethod()]
        public void ConnectTest()
        {
            SQLServer objDB = null;
            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    Assert.AreEqual(true, objDB.Connect());
                }
            }
            finally
            {
                objDB.Disconnect();
                objDB = null;
            }

        }

        [TestMethod()]
        public void DisconnectTest()
        {
            SQLServer objDB = null;
            try
            {
                objDB = TestEnvJudge();
                if (objDB != null)
                {
                    if (objDB.Connect())
                    {
                        Assert.AreEqual(true, objDB.Disconnect());
                    }
                }
            }
            finally
            {
                objDB = null;
            }
        }
    }
}