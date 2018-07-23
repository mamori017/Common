using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class SQLServerTests
    {
        SQLServer objDB = new SQLServer("(local)\\SQL2014", "", "sa", "Password12!");

        [TestMethod()]
        public void ConnectTest()
        {
            Assert.AreEqual(true, objDB.Connect());
        }
    }
}