namespace NSupport {
    using System;
    using System.Linq;

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

        public static DateTime Midnight(this DateTime source) {
            return source.BeginningOfDay();
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

        public static DateTime EndOfWeek(this DateTime source) {
            return source.NextWeek().BeginningOfWeek().AddSeconds(-1);
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

        public static DateTime BeginningOfQuarter(this DateTime source) {            
            var quarterMonth = new int[] { 10, 7, 4, 1 }.First(m => m <= source.Month);
            return new DateTime(source.Year, quarterMonth, 1);
        }

        public static DateTime EndOfQuarter(this DateTime source) {
            var quarterMonth = new int[] { 3, 6, 9, 12 }.First(m => m >= source.Month);
            return new DateTime(source.Year, quarterMonth, 1).EndOfMonth();
        }

        public static bool IsToday(this DateTime source) {
            return source.Date == DateTime.Today;
        }

        public static bool IsFuture(this DateTime source) {
            return source > DateTime.Now;
        }

        public static bool IsPast(this DateTime source) {
            return source < DateTime.Now;
        }

        public static DateTime Advance(this DateTime source, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0) {
            return source.AddYears(years)
                .AddMonths(months)
                .AddDays(days)
                .AddHours(hours)
                .AddMinutes(minutes)
                .AddSeconds(seconds);
        }

        public static DateTime Ago(this DateTime source, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0) {
            return source.AddYears(years * -1)
                .AddMonths(months * -1)
                .AddDays(days * -1)
                .AddHours(hours * -1)
                .AddMinutes(minutes * -1)
                .AddSeconds(seconds * -1);
        }

        public static DateTime Change(this DateTime source, int? years = null, int? months = null, int? days = null, int? hours = null, int? minutes = null, int? seconds = null, int? milliseconds = null) {
            var y = years ?? source.Year;
            var m = months ?? source.Month;
            var d = days ?? source.Day;
            var h = hours ?? source.Hour;
            var min = minutes ?? source.Minute;
            var s = seconds ?? source.Second;
            var ms = milliseconds ?? source.Millisecond;

            return new DateTime(y, m, d, h, min, s, ms); 
        }
    }
}
