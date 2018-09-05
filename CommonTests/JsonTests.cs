using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using CommonTests.Properties;

namespace Common.Tests
{
    [TestClass()]
    public class JsonTests
    {
        [TestMethod()]
        public void GetJsonDictionaryTest()
        {
            JObject ret = Json.GetJsonObject(JsonSettings.Default.JsonUrl);

            Assert.AreEqual(ret["pinpointLocations"][0]["name"].ToString(),"大牟田市");
        }

        [TestMethod()]
        [ExpectedException(typeof(AggregateException))]
        public void GetJsonDictionaryExceptionTest()
        {
            JObject jsonret = Json.GetJsonObject(JsonSettings.Default.JsonUrl.Replace("400040","123456"));


        }

    }
}