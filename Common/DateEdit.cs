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

        /// <summary>
        /// GetDateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTimeKind"></param>
        /// <returns></returns>
        public static DateTimeOffset GetDateTimeOffset(DateTime dateTime, DateTimeKind dateTimeKind)
        {

            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);

            return dateTimeOffset;
        }

        /// <summary>
        /// GetDateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="spanHour"></param>
        /// <param name="spanMin"></param>
        /// <param name="spanSec"></param>
        /// <param name="unspecified"></param>
        /// <returns></returns>
        public static DateTimeOffset GetDateTimeOffset(DateTime dateTime, int spanHour, int spanMin, int spanSec, bool unspecified = false)
        {
            DateTimeOffset dateTimeOffset;

            if (spanHour >= 59 || spanMin >= 59 || spanSec >= 59)
            {
                spanHour = 0;
                spanMin = 0;
                spanSec = 0;
            }

            if (unspecified)
            {
                dateTimeOffset = new DateTimeOffset(DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified),
                                                    new TimeSpan(spanHour, spanMin, spanSec));
            }
            else
            {
                dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(spanHour, spanMin, spanSec));
            }

            return dateTimeOffset;
        }

        /// <summary>
        /// GetDateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset GetDateTimeOffset(string dateTime)
        {
            bool parseRet = DateTimeOffset.TryParse(dateTime, out DateTimeOffset dateTimeOffset);

            return dateTimeOffset;
        }


    }
}
