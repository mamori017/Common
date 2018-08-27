using System;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class Tax
    {
        /// <summary>
        /// 
        /// </summary>
        private int OldTax { get; }

        /// <summary>
        /// 
        /// </summary>
        private int NewTax { get; }

        /// <summary>
        /// 
        /// </summary>
        private int ReducedTax { get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime NewTaxStartDate { get; }

        /// <summary>
        /// 
        /// </summary>
        public int ApplyTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime TargetDate { get; }

        /// <summary>
        /// 
        /// </summary>
        public enum ItemType
        {
            Food,
            FoodWithEatOut,
            Alchol,
            NewsPaper,
            Other
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        public Tax(DateTime dateTime)
        {
            OldTax = 8;
            NewTax = 10;
            ReducedTax = 8;
            NewTaxStartDate = new DateTime(2019,10,1,0,0,0);
            TargetDate = dateTime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="itemType"></param>
        /// <param name="issuePerWeek"></param>
        /// <returns></returns>
        public double TaxInPrice(int price,  ItemType itemType, int issuePerWeek = 0)
        {
            double ret = 0;

            if (itemType == ItemType.Food || itemType == ItemType.FoodWithEatOut || itemType == ItemType.Alchol || itemType == ItemType.Other)
            {
                ret = FoodTax(price, itemType);
            }
            else if(itemType == ItemType.NewsPaper)
            {
                ret = NewsPaperTax(price, issuePerWeek);
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public double FoodTax(int price, ItemType itemType)
        {
            return Math.Floor(price + (price * (FoodTax(itemType) / 100)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eatOut"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public double FoodTax(ItemType itemType)
        {
            if (TargetDate >= NewTaxStartDate)
            {
                if (itemType == ItemType.FoodWithEatOut || itemType == ItemType.Alchol || itemType == ItemType.Other)
                {
                    ApplyTax = NewTax;
                }
                else
                {
                    ApplyTax = OldTax;
                }
            }
            else
            {
                ApplyTax = OldTax;
            }

            return ApplyTax;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="issuePerWeek"></param>
        /// <returns></returns>
        public double NewsPaperTax(int price, int issuePerWeek)
        {
            return Math.Floor(price + (price * (NewsPaperTax(issuePerWeek) / 100)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="issuePerWeek"></param>
        /// <returns></returns>
        public double NewsPaperTax(int issuePerWeek)
        {
            if (TargetDate >= NewTaxStartDate)
            {
                if (issuePerWeek >= 2)
                {
                    ApplyTax = OldTax;
                }
                else
                {
                    ApplyTax = NewTax;
                }
            }
            else
            {
                ApplyTax = OldTax;
            }

            return ApplyTax;
        }
    }
}