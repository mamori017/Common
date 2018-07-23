using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
                Notification.ShowNotify("test1", 
                                        "test2", 
                                        CommonTests.Properties.Settings.Default.NotificationAppID,
                                        CommonTests.Properties.Settings.Default.NotificationIconPath);

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