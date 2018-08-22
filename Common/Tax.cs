using System;

namespace Common
{
    /// <summary>
    /// 軽減税率計算(2019/10/1-)
    /// </summary>
    public class Tax
    {
        /// <summary>
        /// 現(旧)税率
        /// </summary>
        private int OldTax { get; }

        /// <summary>
        /// 新税率
        /// </summary>
        private int NewTax { get; }

        /// <summary>
        /// 軽減税率
        /// </summary>
        private int ReducedTax { get; }

        /// <summary>
        /// 新税率適用開始日付
        /// </summary>
        public DateTime NewTaxStartDate { get; }

        /// <summary>
        /// 適用税率 
        /// </summary>
        public int ApplyTax { get; set; }

        /// <summary>
        /// 対象日付
        /// </summary>
        public DateTime TargetDate { get; }

        /// <summary>
        /// 品目種別
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
        /// 税率計算
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
        /// 税込価格
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
        /// 食品税込価格
        /// </summary>
        /// <param name="price"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public double FoodTax(int price, ItemType itemType)
        {
            return Math.Floor(price + (price * (FoodTax(itemType) / 100)));
        }

        /// <summary>
        /// 食品税率
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
                    // 外食or酒類orその他
                    ApplyTax = NewTax;
                }
                else
                {
                    // その他
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
        /// 新聞税込価格
        /// </summary>
        /// <param name="eatOut"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public double NewsPaperTax(int price, int issuePerWeek)
        {
            return Math.Floor(price + (price * (NewsPaperTax(issuePerWeek) / 100)));
        }

        /// <summary>
        /// 新聞税率
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