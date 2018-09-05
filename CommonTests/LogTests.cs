using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Common.Tests
{
    [TestClass()]
    public class LogTests
    {
        [TestMethod()]
        public void OutputTest()
        {
            Log.Output("test",
                       LogSettings.Default.LogFilePath,
                       LogSettings.Default.LogFileName);

            Assert.AreEqual(true,File.Exists(LogSettings.Default.LogFilePath + "\\" + LogSettings.Default.LogFileName));
        }

        [TestMethod()]
        public void ExceptionOutputTest()
        {
            try
            {
                throw new ArgumentException("Parameter cannot be null", "original");

            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex,
                                    LogSettings.Default.ExFilePath,
                                    LogSettings.Default.ExFileName);
            }

            Assert.AreEqual(true, File.Exists(LogSettings.Default.ExFilePath + "\\" + LogSettings.Default.ExFileName));
        }
    }
}