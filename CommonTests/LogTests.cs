using CommonTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Common.Tests
{
    [TestClass()]
    public class LogTests
    {
        /// <summary>
        /// OutputTest
        /// </summary>
        [TestMethod()]
        public void OutputTest()
        {
            Log.Output("test",
                       Settings.Default.LogFilePath,
                       Settings.Default.LogFileName);

            Assert.AreEqual(true,File.Exists(Settings.Default.LogFilePath + "\\" + Settings.Default.LogFileName));
        }

        /// <summary>
        /// ExceptionOutputTest
        /// </summary>
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
                                    Settings.Default.ExFilePath,
                                    Settings.Default.ExFileName);
            }

            Assert.AreEqual(true, File.Exists(Settings.Default.ExFilePath + "\\" + Settings.Default.ExFileName));
        }
    }
}