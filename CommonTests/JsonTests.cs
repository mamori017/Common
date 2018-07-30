using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json.Linq;

namespace Common.Tests
{
    [TestClass()]
    public class JsonTests
    {
        [TestMethod()]
        public void GetJsonDictionaryTest()
        {
            JObject ret = Common.Json.GetJsonObject(CommonTests.Properties.Settings.Default.JsonUrl);

            Assert.AreEqual(ret["pinpointLocations"][0]["name"].ToString(),"大牟田市");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.AggregateException))]
        public void GetJsonDictionaryExceptionTest()
        {
            JObject jsonret = Common.Json.GetJsonObject(CommonTests.Properties.Settings.Default.JsonUrl.Replace("400040","123456"));


        }

    }
}