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
        [TestMethod()]
        public void ConnectTest()
        {
            //IPアドレス
            string addr_ip;

            try
            {
                //ホスト名を取得
                string hostname = System.Net.Dns.GetHostName();

                //ホスト名からIPアドレスを取得
                System.Net.IPAddress[] addr_arr = System.Net.Dns.GetHostAddresses(hostname);

                //探す
                addr_ip = "";
                foreach (System.Net.IPAddress addr in addr_arr)
                {
                    string addr_str = addr.ToString();

                    //IPv4 && localhostでない
                    if (addr_str.IndexOf(".") > 0 && !addr_str.StartsWith("127."))
                    {
                        addr_ip = addr_str;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                addr_ip = "";
            }

            if (addr_ip=="")
            {
                SQLServer objDB = new SQLServer(CommonTests.Properties.Settings.Default.AppveyorSqlServerName,
                                                   "",
                                                   CommonTests.Properties.Settings.Default.AppveyorSqlServerUser,
                                                   CommonTests.Properties.Settings.Default.AppveyorSqlServerPw);

                Assert.AreEqual(true, objDB.Connect());
            }
            else
            {
                Assert.Fail();
            }


        }

//        [TestMethod()]
//        public void DisconnectTest()
//        {
//            Assert.AreEqual(true, objDB.Disconnect());
//        }
    }
}