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
        private SQLServer TestEnvJudge()
        {
            SQLServer objDB = null;

            try
            {
                string hostname = Dns.GetHostName();

                IPAddress[] adrList = Dns.GetHostAddresses(hostname);
                foreach (IPAddress address in adrList)
                {
                    if(address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        String[] appVeyorEnv = CommonTests.Properties.Settings.Default.AppveyorBuildEnv.Split(',');

                        if (Array.IndexOf(appVeyorEnv, address) > 0)
                        {
                            objDB = new SQLServer(CommonTests.Properties.Settings.Default.AppveyorSqlServerName,
                                                  "",
                                                  CommonTests.Properties.Settings.Default.AppveyorSqlServerUser,
                                                  CommonTests.Properties.Settings.Default.AppveyorSqlServerPw);
                            return objDB;
                        }
                    }
                }

                objDB = new SQLServer(CommonTests.Properties.Settings.Default.SqlServerName,
                                      "",
                                      CommonTests.Properties.Settings.Default.SqlServerUser,
                                      CommonTests.Properties.Settings.Default.SqlServerPw);

                return objDB;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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