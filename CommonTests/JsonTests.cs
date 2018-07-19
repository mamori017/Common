using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;

namespace Common.Tests
{
    [TestClass()]
    public class JsonTests
    {
        [TestMethod()]
        public void GetJsonTest()
        {
            string ret = Json.GetJson(@"https://api.github.com/users/mamori017/repos?page=1&per_page=1");

            Console.WriteLine(ret);

            if (ret == "")
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(true, true);
            }
        }
    }
}