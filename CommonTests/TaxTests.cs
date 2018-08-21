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
    public class TaxTests
    {
        DateTime dateTime;
        Tax tax;

        /// <summary>
        /// 適用前日付
        /// </summary>
        private void SetBeforeStartDate()
        {
            dateTime = new DateTime(2018, 8, 21, 0, 0, 0);
            tax = new Tax(dateTime);
        }

        /// <summary>
        /// 新税率適用前(8%)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_1()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Alchol));
        }

        /// <summary>
        /// 新税率適用前(8%)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_2()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Food));
        }

        /// <summary>
        /// 新税率適用前(8%)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_3()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.FoodWithEatOut));
        }

        /// <summary>
        /// 新税率適用前(8%)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_4()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.NewsPaper));
        }

        /// <summary>
        /// 新税率適用前(8%)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_5()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Other));
        }

        /// <summary>
        /// 適用後日付
        /// </summary>
        private void SetAfterStartDate()
        {
            dateTime = new DateTime(2019, 10, 1, 0, 0, 0);
            tax = new Tax(dateTime);
        }

        /// <summary>
        /// 新税率適用後(10%)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_1()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.Alchol));
        }

        /// <summary>
        /// 新税率適用後(軽減税率対象)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_2()
        {
            SetAfterStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Food));
        }

        /// <summary>
        /// 新税率適用後(10%)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_3()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.FoodWithEatOut));
        }

        /// <summary>
        /// 新税率適用後
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_4()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.NewsPaper));
        }

        /// <summary>
        /// 新税率適用後
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_5()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.NewsPaper, 1));
        }

        /// <summary>
        /// 新税率適用後(軽減税率対象)
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_6()
        {
            SetAfterStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.NewsPaper, 2));
        }

        /// <summary>
        /// 新税率適用後
        /// </summary>
        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_7()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.Other));
        }

    }
}