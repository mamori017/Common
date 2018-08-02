﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                objDB = new SQLServer(CommonTests.Properties.Settings.Default.AppveyorSqlServerName, "",
                    CommonTests.Properties.Settings.Default.AppveyorSqlServerUser, 
                    CommonTests.Properties.Settings.Default.AppveyorSqlServerPw);

                Console.WriteLine("=====appveyor=====");
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