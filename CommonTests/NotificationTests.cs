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
    public class NotificationTests
    {
        [TestMethod()]
        public void ShowNotifyTest()
        {
            try
            {
                Notification.ShowNotify("test1", "test2", CommonTests.Properties.Settings.Default.NotifierAppID);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
                throw;
            }

        }
    }
}