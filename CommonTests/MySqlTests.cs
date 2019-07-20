using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Net;

namespace Common.Tests
{
    [TestClass()]
    public class MySqlTests
    {
        [TestMethod()]
        public void Test()
        {
            MySql objDB = null;

            try
            {
                objDB = new MySql(MySqlSettings.Default.Server, MySqlSettings.Default.Database, MySqlSettings.Default.User, MySqlSettings.Default.Password);
                Assert.AreEqual(objDB.Connect(), true);
            }
            catch
            {
                Assert.AreEqual(true, false);
            }
            finally
            {
                objDB.Disconnect();
            }
        }
    }
}