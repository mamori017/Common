using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class LogTests
    {
        [TestMethod()]
        public void OutputTest()
        {
            Log.Output("test",
                       CommonTests.Properties.Settings.Default.LogFilePath,
                       CommonTests.Properties.Settings.Default.LogFileName);

            Assert.AreEqual(true,File.Exists(CommonTests.Properties.Settings.Default.LogFilePath + "\\" + CommonTests.Properties.Settings.Default.LogFileName));
        }

        [TestMethod()]
        public void ExceptionOutputTest()
        {
            try
            {
                throw new System.ArgumentException("Parameter cannot be null", "original");

            }
            catch (Exception ex)
            {
                Log.ExceptionOutput(ex,
                                    CommonTests.Properties.Settings.Default.ExFilePath,
                                    CommonTests.Properties.Settings.Default.ExFileName);
            }

            Assert.AreEqual(true, File.Exists(CommonTests.Properties.Settings.Default.ExFilePath + "\\" + CommonTests.Properties.Settings.Default.ExFileName));
        }
    }
}