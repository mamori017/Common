using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class SQLServerTests
    {
        SQLServer objDB = new SQLServer(CommonTests.Properties.Settings.Default.AppveyorSqlServerName,
                                        "",
                                        CommonTests.Properties.Settings.Default.AppveyorSqlServerUser,
                                        CommonTests.Properties.Settings.Default.AppveyorSqlServerPw);

        [TestMethod()]
        public void ConnectTest()
        {
            Assert.AreEqual(true, objDB.Connect());
        }

        [TestMethod()]
        public void DisconnectTest()
        {
            Assert.AreEqual(true, objDB.Disconnect());
        }
    }
}