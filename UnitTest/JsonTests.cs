using System;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass()]
    public class JsonTests
    {
        [TestMethod()]
        public void GetJsonTest()
        {
            Json objJson = new Json();

            string ret = objJson.GetJson(@"https://api.github.com/users/mamori017/repos?page=1&per_page=1");

            if (ret == "")
            {
                System.Console.WriteLine(ret);
                Assert.Fail();
            }
            else
            {
                System.Console.WriteLine(ret);
                Assert.AreEqual(1, 1);
            }
        }
    }
}