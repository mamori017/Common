using System;
using System.Globalization;

namespace Common
{
    public static class DateEdit
    {
        /// <summary>
        /// GetWeekStartDate
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public static DateTime GetWeekStartDate(DateTime targetDate)
        {
                return targetDate.AddDays(-(int)targetDate.DayOfWeek);
        }

        /// <summary>
        /// GetWeekCount
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
    }
}
