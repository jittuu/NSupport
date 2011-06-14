namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class DateTimeCalculations {
        public static DateTime Tomorrow(this DateTime source) {
            return source.AddDays(1);
        }

        public static DateTime Yesterday(this DateTime source) {
            return source.AddDays(-1);
        }

        public static DateTime NextYear(this DateTime source) {
            return source.AddYears(1);
        }

        public static DateTime PreviousYear(this DateTime source) {
            return source.AddYears(-1);
        }

        public static DateTime NextMonth(this DateTime source) {
            return source.AddMonths(1);
        }

        public static DateTime PreviousMonth(this DateTime source) {
            return source.AddMonths(-1);
        }

        public static DateTime BeginningOfDay(this DateTime source) {
            return source.Date;
        }

        public static DateTime EndOfDay(this DateTime source) {
            return source.Tomorrow().Date.AddSeconds(-1);
        }

        public static DateTime BeginningOfMonth(this DateTime source) {
            return new DateTime(source.Year, source.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime source) {
            return source.NextMonth().BeginningOfMonth().AddSeconds(-1);
        }

        public static DateTime BeginningOfYear(this DateTime source) {
            return new DateTime(source.Year, 1, 1);
        }

        public static DateTime EndOfYear(this DateTime source) {
            return source.NextYear().BeginningOfYear().AddSeconds(-1);
        }

        public static DateTime BeginningOfWeek(this DateTime source) {
            var beginningOfWeek = source;
            var dateTimeFormatInfo = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            while (beginningOfWeek.DayOfWeek != dateTimeFormatInfo.FirstDayOfWeek) {
                beginningOfWeek = beginningOfWeek.Yesterday();
            }

            return beginningOfWeek.BeginningOfDay();
        }

        public static DateTime NextWeek(this DateTime source) {
            return source.AddDays(7).BeginningOfDay();
        }

        public static DateTime NextWeek(this DateTime source, DayOfWeek day) {
            var nextWeek = source.NextWeek().BeginningOfWeek();
            while (nextWeek.DayOfWeek != day) {
                nextWeek = nextWeek.AddDays(1);
            }

            return nextWeek;
        }
    }
}
