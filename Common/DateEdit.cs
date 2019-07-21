using System;
using System.Globalization;

namespace Common
{
    public static class DateEdit
    {
        public static DateTime GetWeekStartDate(DateTime targetDate)
        {
            return targetDate.AddDays(-(int)targetDate.DayOfWeek);
        }

        public static int GetWeekCount(DateTime startDate)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(startDate,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                                                                        CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        public static string GetJapaneseEraName(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            var cultureInfo = new CultureInfo("ja-Jp");

            cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();

            return cultureInfo.DateTimeFormat.GetEraName(cultureInfo.DateTimeFormat.Calendar.GetEra(dateTime));
        }

        public static string GetJapaneseWeekday(int year, int month, int day, bool shortest = false)
        {
            var dateTime = new DateTime(year, month, day);
            var cultureInfo = new CultureInfo("ja-Jp");

            return shortest ? cultureInfo.DateTimeFormat.GetShortestDayName(dateTime.DayOfWeek) : cultureInfo.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
        }

        public static DateTime GetDaysInMonth(int year, int month, int day)
        {
            // TODO: Test
            //DateTime dateTime = new DateTime(year, month, day);
            //int daysInMonth = DateTime.DaysInMonth(year, month);

            //return new DateTime(year, month, daysInMonth);

            return new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }

        public static DateTime NextWeekDay(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var dateTime = new DateTime(year, month, day);

            int dayDiff = (int)dayOfWeek - (int)dateTime.DayOfWeek;

            if(dayDiff <= 0)
            {
                dayDiff += 7;
            }
            return dateTime.AddDays(dayDiff);
        }
    }
}
