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
    public class DateEditTests
    {
        [TestMethod()]
        public void GetWeekStartDateTest()
        {
            System.DateTime testDate = System.DateTime.Parse("2018/07/19");

            System.DateTime outputDate = DateEdit.GetWeekStartDate(testDate);

            Assert.AreEqual("2018/07/15", outputDate.ToShortDateString());
        }

        [TestMethod()]
        public void GetWeekCountTest()
        {
            System.DateTime testDate = System.DateTime.Parse("2018/07/19");

            int outputCount = DateEdit.GetWeekCount(testDate);

            Assert.AreEqual(29, outputCount);
        }
    }
}