using System;
using System.Globalization;

namespace Common
{
    /// <summary>
    /// 日付編集
    /// </summary>
    public class DateEdit
    {
        /// <summary>
        /// 週開始日(日曜日)取得
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public static DateTime GetWeekStartDate(DateTime targetDate)
        {
                return targetDate.AddDays(-(int)targetDate.DayOfWeek);
        }

        /// <summary>
        /// 指定日が年内の第何週目に当たるか
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public static int GetWeekCount(DateTime startDate)
        {
            int weekCount = 0;

            weekCount = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(startDate,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            return weekCount;
        }

        /// <summary>
        /// 和暦
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetJapaneseEraName(int year, int month, int day)
        {
            string ret = "";

            DateTime dateTime = new DateTime(year, month, day);
            CultureInfo cultureInfo = new CultureInfo("ja-Jp");

            ret = cultureInfo.DateTimeFormat.GetEraName(cultureInfo.DateTimeFormat.Calendar.GetEra(dateTime));

            return ret;
        }

        /// <summary>
        /// 曜日
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetJapaneseWeekday(int year, int month, int day, bool shortest = false)
        {
            string ret = "";

            DateTime dateTime = new DateTime(year, month, day);
            CultureInfo cultureInfo = new CultureInfo("ja-Jp");

            if (shortest)
            {
                ret = cultureInfo.DateTimeFormat.GetShortestDayName(dateTime.DayOfWeek);
            }
            else
            {
                ret = cultureInfo.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            }
            return ret;
        }

        /// <summary>
        /// 月末日付
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public DateTime GeDaysInMonth(int year, int month, int day)
        {
            DateTime dateTime = new DateTime(year, month, day);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            return new DateTime(year, month, daysInMonth);
        }

        /// <summary>
        /// 次週の対象曜日と同曜日
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime NextWeekDay(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            DateTime dateTime = new DateTime(year, month, day);

            int dayDiff = (int)dayOfWeek - (int)dateTime.DayOfWeek;

            if(dayDiff <= 0)
            {
                dayDiff += 7;
            }
            return dateTime.AddDays(dayDiff);
        }
    }
}
