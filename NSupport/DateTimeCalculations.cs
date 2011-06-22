namespace NSupport {
    using System;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for <see cref="DateTime"/> for calcualtions.
    /// </summary>
    public static class DateTimeCalculations {
        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that adds one day to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that adds one day to the value of this instance.</returns>
        public static DateTime Tomorrow(this DateTime source) {
            return source.AddDays(1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that minus one day to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that minus one day to the value of this instance.</returns>
        public static DateTime Yesterday(this DateTime source) {
            return source.AddDays(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that adds one year to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that adds one year to the value of this instance.</returns>
        public static DateTime NextYear(this DateTime source) {
            return source.AddYears(1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that minus one year to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that minus one year to the value of this instance.</returns>
        public static DateTime PreviousYear(this DateTime source) {
            return source.AddYears(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that adds one month to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that adds one month to the value of this instance.</returns>
        public static DateTime NextMonth(this DateTime source) {
            return source.AddMonths(1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that minus one month to the value of this instance.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that minus one month to the value of this instance.</returns>
        public static DateTime PreviousMonth(this DateTime source) {
            return source.AddMonths(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime BeginningOfDay(this DateTime source) {
            return source.Date;
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime Midnight(this DateTime source) {
            return source.BeginningOfDay();
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> with the time value set to (23:59:59).</returns>
        public static DateTime EndOfDay(this DateTime source) {
            return source.Tomorrow().Date.AddSeconds(-1);
        }

        /// <summary>
        /// Returns the first day of the current month with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns the first day of the current month with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime BeginningOfMonth(this DateTime source) {
            return new DateTime(source.Year, source.Month, 1);
        }

        /// <summary>
        /// Returns the last day of the current month with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns the last day of the current month with the time value set to (23:59:59).</returns>        
        public static DateTime EndOfMonth(this DateTime source) {
            return source.NextMonth().BeginningOfMonth().AddSeconds(-1);
        }

        /// <summary>
        /// Returns the first day of the current year with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns the first day of the current year with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime BeginningOfYear(this DateTime source) {
            return new DateTime(source.Year, 1, 1);
        }

        /// <summary>
        /// Returns the last day of the current year with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns the last day of the current year with the time value set to (23:59:59).</returns>   
        public static DateTime EndOfYear(this DateTime source) {
            return source.NextYear().BeginningOfYear().AddSeconds(-1);
        }

        /// <summary>
        /// Returns the first day of the current week with the time value set to 12:00:00 midnight (00:00:00).
        /// This method is culture-aware method which calculates based on <see cref="System.Globalization.DateTimeFormatInfo.FirstDayOfWeek" />.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns the first day of the current week with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime BeginningOfWeek(this DateTime source) {
            var beginningOfWeek = source;
            var dateTimeFormatInfo = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat;
            while (beginningOfWeek.DayOfWeek != dateTimeFormatInfo.FirstDayOfWeek) {
                beginningOfWeek = beginningOfWeek.Yesterday();
            }

            return beginningOfWeek.BeginningOfDay();
        }

        /// <summary>
        /// Returns the last day of the current week with the time value set to (23:59:59).
        /// This method is culture-aware method which calculates based on <see cref="System.Globalization.DateTimeFormatInfo.FirstDayOfWeek" />.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns the last day of the current week with the time value set to (23:59:59).</returns>
        public static DateTime EndOfWeek(this DateTime source) {
            return source.NextWeek().BeginningOfWeek().AddSeconds(-1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that adds seven days to the value of this instance with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that adds seven days to the value of this instance with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime NextWeek(this DateTime source) {
            return source.AddDays(7).BeginningOfDay();
        }

        /// <summary>
        /// Returns the given <paramref name="day" /> of next week with the time value set to 12:00:00 midnight (00:00:00).
        /// This method is culture-aware method which calculates based on <see cref="System.Globalization.DateTimeFormatInfo.FirstDayOfWeek" />.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <param name="day">The <see cref="System.DayOfWeek" /> of next week.</param>
        /// <returns>Returns the given <paramref name="day" /> of next week with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime NextWeek(this DateTime source, DayOfWeek day) {
            var nextWeek = source.NextWeek().BeginningOfWeek();
            while (nextWeek.DayOfWeek != day) {
                nextWeek = nextWeek.AddDays(1);
            }

            return nextWeek;
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> representing the start of the current quarter (1st of January, April, July, October) with the time value set to 12:00:00 midnight (00:00:00).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> representing the start of the current quarter (1st of January, April, July, October) with the time value set to 12:00:00 midnight (00:00:00).</returns>
        public static DateTime BeginningOfQuarter(this DateTime source) {            
            var quarterMonth = new int[] { 10, 7, 4, 1 }.First(m => m <= source.Month);
            return new DateTime(source.Year, quarterMonth, 1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> representing the end of the current quarter (last day of March, June, September, December) with the time value set to (23:59:59).
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> representing the end of the current quarter (last day of March, June, September, December) with the time value set to (23:59:59).</returns>
        public static DateTime EndOfQuarter(this DateTime source) {
            var quarterMonth = new int[] { 3, 6, 9, 12 }.First(m => m >= source.Month);
            return new DateTime(source.Year, quarterMonth, 1).EndOfMonth();
        }

        /// <summary>
        /// Returns true if the instance <see cref="System.DateTime" /> is today regardless of time, otherwise false.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns true if the instance Date is today regardless of time.</returns>
        public static bool IsToday(this DateTime source) {
            return source.Date == DateTime.Today;
        }

        /// <summary>
        /// Returns true if the instance <see cref="System.DateTime" /> is greater than <see cref="System.DateTime.Now" />, otherwise false.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns true if the instance <see cref="System.DateTime" /> is greater than <see cref="System.DateTime.Now" />.</returns>
        public static bool IsFuture(this DateTime source) {
            return source > DateTime.Now;
        }

        /// <summary>
        /// Returns true if the instance <see cref="System.DateTime" /> is less than <see cref="System.DateTime.Now" />, otherwise false.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <returns>Returns true if the instance <see cref="System.DateTime" /> is less than <see cref="System.DateTime.Now" />.</returns>
        public static bool IsPast(this DateTime source) {
            return source < DateTime.Now;
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that adds the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <param name="years">The number of years to add.</param>
        /// <param name="months">The number of months to add.</param>
        /// <param name="days">The number of days to add.</param>
        /// <param name="hours">The number of hours to add.</param>
        /// <param name="minutes">The number of minutes to add.</param>
        /// <param name="seconds">The number of seconds to add.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that adds the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.</returns>
        public static DateTime Advance(this DateTime source, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0) {
            return source.AddYears(years)
                .AddMonths(months)
                .AddDays(days)
                .AddHours(hours)
                .AddMinutes(minutes)
                .AddSeconds(seconds);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that minus the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <param name="years">The number of years to reduce.</param>
        /// <param name="months">The number of months to reduce.</param>
        /// <param name="days">The number of days to reduce.</param>
        /// <param name="hours">The number of hours to reduce.</param>
        /// <param name="minutes">The number of minutes to reduce.</param>
        /// <param name="seconds">The number of seconds to reduce.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that minus the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />) value/s.</returns>        
        public static DateTime Ago(this DateTime source, int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0) {
            return source.AddYears(years * -1)
                .AddMonths(months * -1)
                .AddDays(days * -1)
                .AddHours(hours * -1)
                .AddMinutes(minutes * -1)
                .AddSeconds(seconds * -1);
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime" /> that change the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />, <paramref name="milliseconds" />) value/s.
        /// </summary>
        /// <param name="source"><see cref="System.DateTime" /> instance.</param>
        /// <param name="years">The number of years to change.</param>
        /// <param name="months">The number of months to change.</param>
        /// <param name="days">The number of days to change.</param>
        /// <param name="hours">The number of hours to change.</param>
        /// <param name="minutes">The number of minutes to change.</param>
        /// <param name="seconds">The number of seconds to change.</param>
        /// <param name="milliseconds">The number of milliseconds to change.</param>
        /// <returns>Returns a new <see cref="System.DateTime" /> that change the provided parameters (<paramref name="years" />, <paramref name="months" />, <paramref name="days" />, <paramref name="hours" />, <paramref name="minutes" />, <paramref name="seconds" />, <paramref name="milliseconds" />) value/s.</returns>
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
