using System;
using System.Globalization;

namespace Common
{
    class DateEdit
    {
        /// <summary>
        /// GetWeekStartDate
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public static DateTime GetWeekStartDate(DateTime targetDate)
        {
            try
            {
                return targetDate.AddDays(-(int)targetDate.DayOfWeek);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetWeekCount
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public static int GetWeekCount(DateTime startDate)
        {
            int weekCount = 0;

            try
            {
                weekCount = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(startDate,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
                return weekCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
