using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Common.Tests
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void ExceptionOutputTest()
        {
            string strFile = @".\errorLog.txt";

            Exception objEx = new Exception("Test");

            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }

            Common.Log.ExceptionOutput(objEx, strFile);

            Assert.AreEqual(true, File.Exists(strFile));

            StreamReader objReader = null;

            if (File.Exists(strFile))
            {
                objReader = new StreamReader(strFile);
                Assert.AreEqual("System.Exception: Test", objReader.ReadLine());

            }

            if (objReader != null)
            {
                objReader.Close();
            }

            if (File.Exists(strFile))
            {
                File.Delete(strFile);
            }
        }
    }
}